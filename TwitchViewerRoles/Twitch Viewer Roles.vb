Imports Newtonsoft.Json
Imports System.Net
Imports System.IO

Public Class Form1

    '--- Global Permissions Group object loaded from ini file
    Dim m_objPermGroups As New PermissionGroups

    '--- Name of the ini file that's created
    Const c_strFileName As String = "twitchviewerroles.ini"

    '--- Name of SAMMI Core.exe for correct folder validation
    Const c_strLBexeFileName As String = "SAMMI Core.exe"

#Region "Startup"

    '--- Called on Application start
    Private Sub LoadApplication(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Try

            Me.Location = My.Settings.Location

            If Not String.IsNullOrEmpty(My.Settings.LBPath) Then
                SAMMICorePath.Text = My.Settings.LBPath
                LoadLioaranBoardPermissions(SAMMICorePath.Text, True, False)
            Else
                PermFileTree.Nodes.Add("StartMessage", "Select SAMMI Core.exe Folder Above")
            End If
            If Not String.IsNullOrEmpty(My.Settings.ChannelName) Then
                ChannelName.Text = My.Settings.ChannelName
            End If
            ManualAddUser.Text = "Manually Add User‎‎‎ ‎"
            ManualAddUser.ForeColor = Color.FromArgb(255, 114, 118, 125)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

#End Region

#Region " Move Form "

    Public blnMoveForm As Boolean
    Public MoveForm_MousePosition As Point

    Public Sub MoveForm_MouseDown(sender As Object, e As MouseEventArgs) Handles _
    AppLabel.MouseDown, HeaderBar.MouseDown

        Try

            If e.Button = MouseButtons.Left Then
                blnMoveForm = True
                Me.Cursor = Cursors.NoMove2D
                MoveForm_MousePosition = e.Location
            End If

        Catch

        End Try

    End Sub

    Public Sub MoveForm_MouseMove(sender As Object, e As MouseEventArgs) Handles _
    AppLabel.MouseMove, HeaderBar.MouseMove

        Try

            If blnMoveForm Then
                Me.Location = Me.Location + (e.Location - MoveForm_MousePosition)
            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub MoveForm_MouseUp(sender As Object, e As MouseEventArgs) Handles _
    AppLabel.MouseUp, HeaderBar.MouseUp

        Try
            If e.Button = MouseButtons.Left Then
                blnMoveForm = False
                Me.Cursor = Cursors.Default
                My.Settings.Location = Me.Location
                My.Settings.Save()
            ElseIf e.Button = MouseButtons.Right Then
                'Dim cmsExitMenu As New ContextMenuStrip
                'Dim item1 = cmsExitMenu.Items.Add("Exit")
                'Dim item2 = cmsExitMenu.Items.Add("Adjust date/time")
                'item1.Tag = 1
                'item2.Tag = 2
                'AddHandler item1.Click, AddressOf ExitClock
                'AddHandler item2.Click, AddressOf MyForm_DoubleClick
                'cmsExitMenu.Show(sender, e.Location)
            End If
        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "Title Bar Controls"

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub

    Private Sub CloseButton_Hover(sender As Object, e As EventArgs) Handles CloseButton.MouseHover
        CloseButton.BackgroundImage = My.Resources.HoverClose
    End Sub

    Private Sub CloseButton_MouseLeave(sender As Object, e As EventArgs) Handles CloseButton.MouseLeave
        CloseButton.BackgroundImage = My.Resources.Close
    End Sub

    Private Sub MinButton_Click(sender As Object, e As EventArgs) Handles MinimizeButton.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub MinButton_Hover(sender As Object, e As EventArgs) Handles MinimizeButton.MouseHover
        MinimizeButton.BackgroundImage = My.Resources.HoverMin
    End Sub

    Private Sub MinButton_MouseLeave(sender As Object, e As EventArgs) Handles MinimizeButton.MouseLeave
        MinimizeButton.BackgroundImage = My.Resources.Minimize
    End Sub

#End Region

#Region "Button Handlers"

    '--- Browse - Select SAMMI Folder Location
    Private Sub LB_Browse_Button_Click(sender As Object, e As EventArgs) Handles LB_Browse_Button.Click
        Try
            If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
                SAMMICorePath.Text = FolderBrowserDialog1.SelectedPath
                My.Settings.LBPath = SAMMICorePath.Text
                My.Settings.Save()
                LoadLioaranBoardPermissions(SAMMICorePath.Text, False, False)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    '--- Call LoadUsersList and store ChannelName in memory to show on reopen
    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        Try
            LoadUsersList()
            If Not String.IsNullOrEmpty(ChannelName.Text.Trim) Then
                My.Settings.ChannelName = ChannelName.Text.Trim
                My.Settings.Save()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ChannelName_KeyUp(sender As Object, e As KeyEventArgs) Handles ChannelName.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                SearchButton_Click(sender, e)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

#End Region

#Region "Permissions File Operations etc"

    '--- Parse c_strFileName file into mod-level object then populate Permissions Tree
    Private Sub LoadLioaranBoardPermissions(p_strfilePath As String, p_blnStartup As Boolean, p_blnDeleteGroup As Boolean)

        Try
            m_objPermGroups.Groups.Clear()

            If ThisIsTheRightFolder(p_strfilePath) Then

                If Not String.IsNullOrEmpty(p_strfilePath) Then

                    If File.Exists(p_strfilePath & "\" & c_strFileName) Then

                        Dim strFileLine As String = String.Empty
                        Dim strGroupName As String = String.Empty
                        UserRolesDialog.UserDialogComboBox.Items.Clear()

                        Using objReader As New StreamReader(p_strfilePath & "\" & c_strFileName)

                            Do While objReader.Peek() <> -1

                                strFileLine = objReader.ReadLine()
                                strGroupName = ParsePermissionFileLine(strFileLine, strGroupName)
                                If (Not UserRolesDialog.UserDialogComboBox.Items.Contains(strGroupName.Trim("[").Trim("]").Trim())) Then
                                    UserRolesDialog.UserDialogComboBox.Items.Add(strGroupName.Trim("[").Trim("]").Trim())
                                End If

                            Loop

                        End Using

                        PopulatePermissionTree(m_objPermGroups, p_blnDeleteGroup)

                    Else

                        '--- Create a c_strFileName file in the given path
                        Dim fi As New FileInfo(p_strfilePath & "\" & c_strFileName)

                        If fi.Exists Then
                            Return
                        End If

                        Using swObject As StreamWriter = fi.CreateText()
                            swObject.WriteLine("")
                        End Using

                        PermFileTree.Nodes.Clear()
                        PermFileTree.Nodes.Add("SAMMI Core Path selected. ^-^")

                    End If

                Else

                    PermFileTree.Nodes.Clear()
                    PermFileTree.Nodes.Add("Placeholder", "Select SAMMI Core Receiver Folder Above")

                End If

            Else

                If Not p_blnStartup Then
                    MessageBox.Show("This isn't the right folder. Please select the folder your SAMMI Core.exe is in")
                End If

                SAMMICorePath.Text = String.Empty
                PermFileTree.Nodes.Clear()
                PermFileTree.Nodes.Add("Placeholder", "Select SAMMI Core.exe Folder Above")
                My.Settings.LBPath = String.Empty
                My.Settings.Save()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Function ThisIsTheRightFolder(p_strPath As String) As Boolean

        Try
            Dim strFilePath As String = p_strPath & "\" & c_strLBexeFileName

            If File.Exists(strFilePath) Then
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

        Return False

    End Function

    '--- Parse Single line from Permissions File into mod-level permission Groups object
    Private Function ParsePermissionFileLine(p_strLine As String, p_strGroupName As String) As String

        Dim GroupName As String = p_strGroupName

        Try

            If p_strLine?.StartsWith("[") AndAlso p_strLine.Contains("]") Then

                GroupName = p_strLine.Trim

                If Not m_objPermGroups.Groups.ContainsKey(GroupName) Then
                    m_objPermGroups.Groups.Add(GroupName, New Users)
                End If

            ElseIf Not String.IsNullOrEmpty(p_strLine) AndAlso Not String.IsNullOrEmpty(GroupName) Then

                If m_objPermGroups.Groups.ContainsKey(GroupName) Then
                    m_objPermGroups.Groups(GroupName).PermUsers.Add(p_strLine.Trim.Replace("=""true""", ""))
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

        Return GroupName

    End Function

    '--- Reloads Permissions Tree with current list of objects in p_objPermGroups parameter
    Private Sub PopulatePermissionTree(p_objPermGroups As PermissionGroups, p_blnDeleteGroup As Boolean)
        Try

            If p_objPermGroups IsNot Nothing AndAlso p_objPermGroups.Groups.Count > 0 Then

                Dim lstExpandedNodes As New List(Of Integer)

                If Not p_blnDeleteGroup AndAlso PermFileTree.Nodes IsNot Nothing Then

                    For Each objNode As TreeNode In PermFileTree.Nodes
                        If objNode.IsExpanded Then
                            lstExpandedNodes.Add(objNode.Index)
                        End If
                    Next

                End If

                PermFileTree.Nodes.Clear()

                For Each strGroupName As String In p_objPermGroups.Groups.Keys

                    PermFileTree.Nodes.Add(strGroupName, strGroupName)

                    For Each strUser As String In p_objPermGroups.Groups(strGroupName).PermUsers
                        PermFileTree.Nodes.Item(strGroupName).Nodes.Add(strUser)
                    Next

                Next

                If Not p_blnDeleteGroup Then
                    For Each nodeIndex As Integer In lstExpandedNodes
                        PermFileTree.Nodes.Item(nodeIndex).Expand()
                    Next
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

#End Region

#Region "Node Tree Context Menu Handling"

    '--- Make sure right clicking on a user in the UsersTree selects that user
    Private Sub UsersTree_MouseDown(sender As Object, e As MouseEventArgs) Handles UsersTree.NodeMouseClick

        Try
            UsersTree.SelectedNode = UsersTree.GetNodeAt(e.X, e.Y)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    '--- Context Menu for Chat UsersTree
    Private Sub UsersTree_Click(sender As Object, e As MouseEventArgs) Handles UsersTree.Click

        Try

            If e.Button = MouseButtons.Right Then

                Dim nodeText As String = UsersTree.SelectedNode.Text
                Dim strMenuMessage As String = String.Empty
                Dim fnFunctionToCall As EventHandler

                If nodeText = "Broadcasters" OrElse nodeText = "VIPs" OrElse nodeText = "Mods" OrElse
                    nodeText = "Staff" OrElse nodeText = "Admin" OrElse nodeText = "Global Mods" OrElse nodeText = "Users" Then
                    strMenuMessage = "Add All Users To Role..."
                    fnFunctionToCall = AddressOf AddGroupUserPermissions
                Else
                    strMenuMessage = "Add User To Role..."
                    fnFunctionToCall = AddressOf CallUserPermission
                End If

                Dim nodeContextMenu As New ContextMenuStrip
                Dim item1 = nodeContextMenu.Items.Add(strMenuMessage)

                item1.Tag = 1
                AddHandler item1.Click, fnFunctionToCall
                nodeContextMenu.Show(sender, e.Location)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    '--- Make sure right clicking on a user in the PermFileTree selects that user
    Private Sub PermFileTree_MouseDown(sender As Object, e As MouseEventArgs) Handles PermFileTree.NodeMouseClick

        Try
            PermFileTree.SelectedNode = PermFileTree.GetNodeAt(e.X, e.Y)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    '--- Context Menu for Chat UsersTree
    Private Sub PermFileTree_Click(sender As Object, e As MouseEventArgs) Handles PermFileTree.Click

        Try

            If e.Button = MouseButtons.Right Then

                Dim strNodeName As String = PermFileTree.SelectedNode.Text
                Dim strContextMenuMessage As String = String.Empty
                Dim fnFunctionToCall As EventHandler

                If strNodeName?.StartsWith("[") Then
                    strContextMenuMessage = "Export Button Example Json"
                    fnFunctionToCall = AddressOf ExportJsonButton
                Else
                    strContextMenuMessage = "Remove User Permission"
                    fnFunctionToCall = AddressOf RemoveUserPermission
                End If

                Dim nodeContextMenu As New ContextMenuStrip
                Dim item1 = nodeContextMenu.Items.Add(strContextMenuMessage)

                item1.Tag = 1
                AddHandler item1.Click, fnFunctionToCall

                If strContextMenuMessage = "Export Button Example Json" Then
                    Dim item2 = nodeContextMenu.Items.Add("Delete Role")
                    item2.Tag = 2
                    AddHandler item2.Click, AddressOf DeleteUserGroup
                End If

                nodeContextMenu.Show(sender, e.Location)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

#End Region

#Region "User Permission Management"

    '--- Removes user from c_strFileName file and reloads Permissions Tree
    Private Sub RemoveUserPermission()

        Try

            Dim strUserName As String = PermFileTree.SelectedNode.Text & "=""true"""
            Dim strParentNode As String = PermFileTree.SelectedNode.Parent.Text
            Dim stringList As New List(Of String)
            Dim blnFoundGroup As Boolean = False
            Dim blnSkipUser As Boolean = False

            Dim lines As List(Of String) = File.ReadAllLines(SAMMICorePath.Text & "\" & c_strFileName).ToList

            For Each strLine As String In lines
                If Not String.IsNullOrEmpty(strLine) AndAlso strLine.StartsWith("[") Then
                    If strLine.Trim() = strParentNode Then
                        blnFoundGroup = True
                    Else
                        blnFoundGroup = False
                    End If
                End If
                If blnFoundGroup AndAlso strLine = strUserName Then
                    blnSkipUser = True
                Else
                    blnSkipUser = False
                End If
                If Not blnSkipUser Then
                    stringList.Add(strLine)
                End If
            Next

            File.Delete(SAMMICorePath.Text & "\" & c_strFileName)
            File.WriteAllLines(SAMMICorePath.Text & "\" & c_strFileName, stringList)

            LoadLioaranBoardPermissions(SAMMICorePath.Text, False, False)

            For Each node As TreeNode In PermFileTree.Nodes
                If node.Text = strParentNode Then
                    node.Expand()
                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    '--- Adds whole group of users to c_strFileName file and reloads Permissions Tree
    Private Sub AddGroupUserPermissions()

        Try

            UserRolesDialog.Location = New Point(Me.Location.X + 100, Me.Location.Y + 100)

            Dim dialogResult As DialogResult = UserRolesDialog.ShowDialog()
            If dialogResult = DialogResult.OK Then
                Dim strGroup = UserRolesDialog.UserDialogComboBox.Text

                Dim usersList As New List(Of String)

                For Each objNode As TreeNode In UsersTree.SelectedNode.Nodes

                    If Not m_objPermGroups.Groups.ContainsKey("[" & strGroup & "]") OrElse
                        Not m_objPermGroups.Groups("[" & strGroup & "]").PermUsers.Contains(objNode.Text) Then
                        usersList.Add(objNode.Text & "=""true""")
                    End If

                Next

                Dim stringList As New List(Of String)
                Dim blnFoundGroup As Boolean = False
                Dim blnSkipUser As Boolean = False

                Dim lines As List(Of String) = File.ReadAllLines(SAMMICorePath.Text & "\" & c_strFileName).ToList
                Dim intGroupLine As Integer = 0
                Dim intLineCount As Integer = 0
                For Each strLine As String In lines

                    If Not String.IsNullOrEmpty(strLine) AndAlso strLine.StartsWith("[") Then
                        If strLine.Trim("[").Trim("]").Trim() = strGroup Then
                            blnFoundGroup = True
                            intGroupLine = intLineCount
                        End If
                    End If
                    If Not String.IsNullOrEmpty(strLine) Then
                        stringList.Add(strLine)
                    End If
                    intLineCount += 1

                Next

                If blnFoundGroup Then

                    Dim intUserIndex As Integer = 0
                    For Each strUserName As String In usersList
                        stringList.Insert(intGroupLine + 1 + intUserIndex, strUserName)
                        intUserIndex += 1
                    Next

                Else

                    stringList.Add("[" & strGroup & "]")
                    For Each strUserName As String In usersList
                        stringList.Add(strUserName)
                    Next

                End If

                File.Delete(SAMMICorePath.Text & "\" & c_strFileName)
                File.WriteAllLines(SAMMICorePath.Text & "\" & c_strFileName, stringList)

                LoadLioaranBoardPermissions(SAMMICorePath.Text, False, False)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub CallUserPermission()

        Try
            Dim strUserName As String = UsersTree.SelectedNode.Text & "=""true"""
            AddUserPermission(strUserName)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    '--- Adds selected user to c_strFileName file and reloads Permissions Tree
    Private Sub AddUserPermission(p_strUserName As String)

        Try

            UserRolesDialog.Location = New Point(Me.Location.X + 100, Me.Location.Y + 100)

            Dim dialogResult As DialogResult = UserRolesDialog.ShowDialog()
            If dialogResult = DialogResult.OK Then

                Dim strGroup = UserRolesDialog.UserDialogComboBox.Text

                '--- Don't add the user to this group if they're already there
                If m_objPermGroups.Groups.ContainsKey("[" & strGroup & "]") AndAlso
                    m_objPermGroups.Groups("[" & strGroup & "]").PermUsers.Contains(p_strUserName.Trim("=""true""")) Then
                    Return
                End If

                Dim stringList As New List(Of String)
                Dim blnFoundGroup As Boolean = False
                Dim blnSkipUser As Boolean = False

                Dim lines As List(Of String) = File.ReadAllLines(SAMMICorePath.Text & "\" & c_strFileName).ToList
                Dim intGroupLine As Integer = 0
                Dim intLineCount As Integer = 0

                For Each strLine As String In lines

                    If Not String.IsNullOrEmpty(strLine) AndAlso strLine.StartsWith("[") Then
                        If strLine.Trim("[").Trim("]").Trim() = strGroup Then
                            blnFoundGroup = True
                            intGroupLine = intLineCount
                        End If
                    End If
                    If Not String.IsNullOrEmpty(strLine) Then
                        stringList.Add(strLine)
                    End If
                    intLineCount += 1

                Next

                If blnFoundGroup Then
                    stringList.Insert(intGroupLine + 1, p_strUserName)
                Else
                    stringList.Add("[" & strGroup & "]")
                    stringList.Add(p_strUserName)
                End If

                File.Delete(SAMMICorePath.Text & "\" & c_strFileName)
                File.WriteAllLines(SAMMICorePath.Text & "\" & c_strFileName, stringList)

                LoadLioaranBoardPermissions(SAMMICorePath.Text, False, False)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    '--- Display Warning message, then Delete Group and all users in that group
    Private Sub DeleteUserGroup()
        Try

            If MessageBox.Show(Me, "Are you sure you want to delete this Role?", "Delete Role", MessageBoxButtons.OKCancel) = DialogResult.OK Then

                '--- Delete Group and all users from file then reload
                Dim strParentNode As String = PermFileTree.SelectedNode.Text
                Dim stringList As New List(Of String)
                Dim blnFoundGroup As Boolean = False
                Dim blnSkipLine As Boolean = False

                Dim lines As List(Of String) = File.ReadAllLines(SAMMICorePath.Text & "\" & c_strFileName).ToList

                For Each strLine As String In lines

                    If Not String.IsNullOrEmpty(strLine) AndAlso strLine.StartsWith("[") Then
                        If strLine.Trim() = strParentNode Then
                            blnFoundGroup = True
                        Else
                            blnFoundGroup = False
                        End If
                    End If

                    If blnFoundGroup Then
                        blnSkipLine = True
                    Else
                        blnSkipLine = False
                    End If

                    If Not blnSkipLine Then
                        stringList.Add(strLine)
                    End If

                Next

                File.Delete(SAMMICorePath.Text & "\" & c_strFileName)
                File.WriteAllLines(SAMMICorePath.Text & "\" & c_strFileName, stringList)

                LoadLioaranBoardPermissions(SAMMICorePath.Text, False, True)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

#End Region

#Region "Manual Add User"

    Private Sub ManualAddUser_GotFocus(sender As Object, e As EventArgs) Handles ManualAddUser.GotFocus
        If ManualAddUser.Text = "Manually Add User‎‎‎ ‎" Then
            ManualAddUser.Text = ""
            ManualAddUser.ForeColor = Color.FromArgb(255, 220, 221, 217)
            ManualAddUser.BackColor = Color.FromArgb(255, 39, 40, 42)
            PictureBox2.BackgroundImage = My.Resources.AddUserText
        End If
    End Sub

    Private Sub ManualAddUser_LostFocus(sender As Object, e As EventArgs) Handles ManualAddUser.LostFocus
        If ManualAddUser.Text = "" Then
            ManualAddUser.Text = "Manually Add User‎‎‎ ‎"
            ManualAddUser.ForeColor = Color.FromArgb(255, 114, 118, 125)
            PictureBox2.BackgroundImage = My.Resources.textbox_Corners
            ManualAddUser.BackColor = Color.FromArgb(255, 34, 35, 37)
        End If
    End Sub

    Dim m_blnSpacePress As Boolean = False

    Private Sub ManualAddUser_KeyDown(senders As Object, e As KeyEventArgs) Handles ManualAddUser.KeyDown
        If e.KeyCode = Keys.Space Then
            m_blnSpacePress = True
        End If
    End Sub

    Private Sub ManualAddUser_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ManualAddUser.KeyPress
        If m_blnSpacePress Then
            e.Handled = True
            m_blnSpacePress = False
        End If
    End Sub

    Private Sub ManualAddUser_KeyUp(sender As Object, e As KeyEventArgs) Handles ManualAddUser.KeyUp

        If e.KeyCode = Keys.Enter AndAlso Not String.IsNullOrEmpty(ManualAddUser.Text) Then
            AddUserPermission(ManualAddUser.Text.ToLower & "=""true""")
            ManualAddUser.Text = ""
            ManualAddUser_LostFocus(sender, e)
            PermFileTree.Focus()
        End If

    End Sub

#End Region

#Region "Utilities"

    '--- Calls Twitch GET API to get Chat users and populates Chat Tree
    Private Sub LoadUsersList()
        Try
            Dim channelName = Me.ChannelName.Text.Trim
            Me.ChannelName.Text = channelName

            If String.IsNullOrEmpty(Me.ChannelName.Text) Then
                MessageBox.Show("Please input a channel name... Nerd")
                Return
            End If

            Dim URL As String = "https://tmi.twitch.tv/group/user/" & channelName.ToLower & "/chatters"

            Dim myReq As HttpWebRequest
            Dim myResp As HttpWebResponse
            Dim myReader As StreamReader
            myReq = HttpWebRequest.Create(URL)
            myReq.Method = "GET"

            myResp = myReq.GetResponse
            myReader = New StreamReader(myResp.GetResponseStream)
            Dim objChat As TwitchChat = JsonConvert.DeserializeObject(Of TwitchChat)(myReader.ReadToEnd)

            UsersTree.Nodes.Clear()

            UsersTree.Nodes.Add("Broadcaster", "Broadcasters")
            For Each strBroadcaster As String In objChat.chatters.broadcaster
                UsersTree.Nodes.Item("Broadcaster").Nodes.Add(strBroadcaster)
            Next
            UsersTree.Nodes.Add("VIP", "VIPs")
            For Each strVIP As String In objChat.chatters.vips
                UsersTree.Nodes.Item("VIP").Nodes.Add(strVIP)
            Next
            UsersTree.Nodes.Add("Mods", "Mods")
            For Each strMod As String In objChat.chatters.moderators
                UsersTree.Nodes.Item("Mods").Nodes.Add(strMod)
            Next
            UsersTree.Nodes.Add("Staff", "Staff")
            For Each strStaff As String In objChat.chatters.staff
                UsersTree.Nodes.Item("Staff").Nodes.Add(strStaff)
            Next
            UsersTree.Nodes.Add("Admin", "Admin")
            For Each strAdmin As String In objChat.chatters.admins
                UsersTree.Nodes.Item("Admin").Nodes.Add(strAdmin)
            Next
            UsersTree.Nodes.Add("GlobalMods", "Global Mods")
            For Each strGlobalMod As String In objChat.chatters.global_mods
                UsersTree.Nodes.Item("GlobalMods").Nodes.Add(strGlobalMod)
            Next
            UsersTree.Nodes.Add("Users", "Users")
            For Each strViewer As String In objChat.chatters.viewers
                UsersTree.Nodes.Item("Users").Nodes.Add(strViewer)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    '--- Gets selected Group Name from Permission Tree, replaces GroupName in json string
    '--- and copies the SAMMI json string to your clipboard
    Private Sub ExportJsonButton()
        Try
            Dim strNodeName As String = PermFileTree.SelectedNode.Text.Trim("[").Trim("]").Trim()

            'Dim strValue As String = "{ ""websocketvalue4_1"": ""allowed_user"", ""websocketvalue2_2"": ""=="", ""websocketdelay2"": 0.000000, ""websocketaction1"": 40.000000, ""websocketvalue3_4"": """", ""exported_with"": ""Version V 1.44b"", ""websocketvalue3_0"": ""false"", ""color"": 12632256.000000, ""websocketvalue5_3"": """", ""websocketvalue2_0"": ""User Name"", ""websocketdelay0"": 0.000000, ""websocketaction3"": 92.000000, ""websocketvalue4_3"": """", ""websocketvalue5_1"": """", ""text"": """", ""websocketvalue2_4"": ""false"", ""websocketvalue3_2"": ""\""true\"""", ""websocketdelay4"": 0.000000, ""websocketvalue6_3"": """", ""websocketvalue8_3"": """", ""websocketvalue1_2"": ""allowed_user"", ""combine"": 0.000000, ""websocketvalue7_1"": """", ""websocketvalue8_1"": """", ""websocketvalue1_4"": ""ID44"", ""websocketvalue6_1"": """", ""websocketvalue7_3"": """", ""picture"": """", ""websocketvalue1_0"": ""username"", ""websocketvalue3_1"": ""\/$username$\/"", ""websocketaction4"": 34.000000, ""activepress"": 0.000000, ""websocketvalue5_2"": ""0"", ""websocketvalue4_4"": """", ""www"": 1.000000, ""websocketvalue4_0"": """", ""websocketdelay3"": 0.000000, ""websocketaction0"": 35.000000, ""websocketvalue2_3"": """", ""websocketvalue5_0"": """", ""websocketvalue3_3"": """", ""websocketdelay1"": 0.000000, ""hhh"": 1.000000, ""websocketaction2"": 121.000000, ""websocketvalue2_1"": ""!!!!!!!!!!"", ""group_id"": """", ""websocketvalue5_4"": """", ""websocketvalue4_2"": ""2"", ""websocketvalue1_3"": ""Call Another Button here, or add commands for this button (example below calls another button)"", ""websocketvalue7_0"": """", ""pubsubqueue"": 0.000000, ""websocketvalue6_2"": """", ""type"": 32.000000, ""websocketvalue7_4"": """", ""websocketvalue8_2"": """", ""websocketvalue6_4"": """", ""border_size"": 0.000000, ""websocketvalue7_2"": """", ""button_id"": ""ID59"", ""websocketvalue1_1"": ""@@@@@@@@@@"", ""websocketvalue8_4"": """", ""websocketvalue8_0"": """", ""websocketvalue6_0"": """" }"
            Dim strValue As String = "{ ""color"": 5095486.0, ""persistent"": true, ""text"": ""Sample TVR"", ""release_duration"": 0.0, ""queueable"": false, ""command_list"": [ { ""b1"": ""user_name"", ""cmd"": 66.0, ""obsid"": ""Main"", ""pos"": 0.0, ""vis"": true, ""ms"": 0.0, ""sel"": false, ""dis"": false, ""xpan"": 0.0, ""b0"": ""username"" }, { ""b1"": ""!!!!!!!!!!"", ""b3"": ""allowed_user"", ""cmd"": 127.0, ""obsid"": ""Main"", ""pos"": 1.0, ""vis"": true, ""ms"": 0.0, ""sel"": false, ""dis"": false, ""xpan"": 0.0, ""b0"": ""@@@@@@@@@@"", ""b2"": ""\/$username$\/"" }, { ""b53"": """", ""b5"": """", ""b13"": ""=="", ""v14"": 0.0, ""b36"": """", ""b38"": """", ""v10"": 0.0, ""b32"": """", ""b19"": ""=="", ""b57"": """", ""b59"": """", ""b17"": """", ""b1"": ""=="", ""v18"": 0.0, ""v16"": 0.0, ""b34"": ""=="", ""b7"": ""=="", ""b11"": """", ""b9"": """", ""b51"": """", ""b15"": """", ""b3"": """", ""b55"": ""=="", ""v12"": 0.0, ""cmd"": 7.0, ""b30"": """", ""b43"": ""=="", ""v21"": 0.0, ""v1"": 0.0, ""b26"": """", ""b28"": ""=="", ""obsid"": ""Main"", ""b22"": ""=="", ""pos"": 2.0, ""v5"": 0.0, ""b47"": """", ""b49"": ""=="", ""v3"": 0.0, ""vis"": true, ""b24"": """", ""ms"": 0.0, ""b41"": """", ""sel"": false, ""b45"": """", ""v9"": 0.0, ""dis"": false, ""xpan"": 0.0, ""b20"": """", ""v7"": 0.0, ""b33"": """", ""v11"": 0.0, ""b16"": ""=="", ""b0"": ""allowed_user"", ""b58"": ""=="", ""b56"": """", ""b18"": """", ""b4"": ""=="", ""b12"": """", ""b52"": ""=="", ""b39"": """", ""b37"": ""=="", ""v15"": 0.0, ""b54"": """", ""b14"": """", ""b2"": ""\""true\"""", ""b31"": ""=="", ""v13"": 0.0, ""b35"": """", ""v17"": 0.0, ""v19"": 0.0, ""b50"": """", ""b8"": """", ""b6"": """", ""b10"": ""=="", ""b23"": """", ""v4"": 0.0, ""b48"": """", ""b46"": ""=="", ""v20"": 0.0, ""b42"": """", ""b29"": """", ""v0"": 2.0, ""b27"": """", ""b44"": """", ""b21"": """", ""v6"": 0.0, ""v8"": 0.0, ""v2"": 1.0, ""b25"": ""=="", ""b40"": ""=="", ""v22"": 0.0 }, { ""cmd"": 6.0, ""obsid"": ""Main"", ""pos"": 3.0, ""vis"": true, ""ms"": 0.0, ""sel"": false, ""dis"": false, ""xpan"": 0.0, ""b0"": ""Call Another Button here, or add commands for this button (example below calls another button)"", ""v0"": 0.0 }, { ""b1"": ""0"", ""cmd"": 132.0, ""obsid"": ""Main"", ""pos"": 4.0, ""vis"": true, ""ms"": 0.0, ""sel"": false, ""dis"": false, ""xpan"": 0.0, ""b0"": ""ID54"", ""v0"": false } ], ""press_type"": 0.0, ""x"": 0.0, ""border"": 2.0, ""image"": """", ""triggers"": [ ], ""group_id"": """", ""overlappable"": false, ""init_variable"": """", ""width"": 0.19999999999999995559107901499374, ""button_id"": ""ID1"", ""button_duration"": 0.0, ""y"": 0.80000000000000004440892098500626, ""switch_deck"": """", ""height"": 0.20000000000000006661338147750939, ""release_list"": [ ], ""functions"": 65.0, ""stretch"": false }"

            Dim strExampleButton As String = strValue.Replace("!!!!!!!!!!", strNodeName).Replace("@@@@@@@@@@", c_strFileName)

            Clipboard.SetText(strExampleButton)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub DocLabel_Click(sender As Object, e As EventArgs) Handles DocLabel.Click
        Try
            System.Diagnostics.Process.Start("https://github.com/RemainIndoors1/TwitchViewerRoles/blob/master/README.md")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

#End Region

End Class
