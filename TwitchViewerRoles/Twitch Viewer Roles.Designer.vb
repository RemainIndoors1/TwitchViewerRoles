<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TwitchViewerRoles
    Inherits Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TwitchViewerRoles))
        Me.ChannelName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SAMMICorePath = New System.Windows.Forms.TextBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.UsersTree = New System.Windows.Forms.TreeView()
        Me.AppLabel = New System.Windows.Forms.Label()
        Me.PermFileTree = New System.Windows.Forms.TreeView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.ManualAddUser = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.SearchButton = New System.Windows.Forms.PictureBox()
        Me.LB_Browse_Button = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MinimizeButton = New System.Windows.Forms.PictureBox()
        Me.CloseButton = New System.Windows.Forms.PictureBox()
        Me.HeaderBar = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.DocLabel = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LB_Browse_Button, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MinimizeButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CloseButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HeaderBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ChannelName
        '
        Me.ChannelName.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.ChannelName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChannelName.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChannelName.ForeColor = System.Drawing.SystemColors.InactiveBorder
        Me.ChannelName.Location = New System.Drawing.Point(600, 99)
        Me.ChannelName.Name = "ChannelName"
        Me.ChannelName.Size = New System.Drawing.Size(260, 24)
        Me.ChannelName.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.Location = New System.Drawing.Point(439, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 26)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Channel Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label2.Location = New System.Drawing.Point(396, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(189, 26)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "SAMMI Core Folder:"
        '
        'SAMMICorePath
        '
        Me.SAMMICorePath.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.SAMMICorePath.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.SAMMICorePath.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SAMMICorePath.ForeColor = System.Drawing.SystemColors.InactiveBorder
        Me.SAMMICorePath.Location = New System.Drawing.Point(600, 54)
        Me.SAMMICorePath.Name = "SAMMICorePath"
        Me.SAMMICorePath.Size = New System.Drawing.Size(260, 24)
        Me.SAMMICorePath.TabIndex = 12
        '
        'UsersTree
        '
        Me.UsersTree.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.UsersTree.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.UsersTree.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsersTree.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.UsersTree.HideSelection = False
        Me.UsersTree.Location = New System.Drawing.Point(12, 46)
        Me.UsersTree.Name = "UsersTree"
        Me.UsersTree.Size = New System.Drawing.Size(323, 529)
        Me.UsersTree.TabIndex = 15
        '
        'AppLabel
        '
        Me.AppLabel.AutoSize = True
        Me.AppLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.AppLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AppLabel.ForeColor = System.Drawing.Color.Silver
        Me.AppLabel.Location = New System.Drawing.Point(10, 8)
        Me.AppLabel.Name = "AppLabel"
        Me.AppLabel.Size = New System.Drawing.Size(259, 20)
        Me.AppLabel.TabIndex = 17
        Me.AppLabel.Text = "Twitch Viewer Roles - SAMMI"
        '
        'PermFileTree
        '
        Me.PermFileTree.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PermFileTree.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.PermFileTree.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PermFileTree.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.PermFileTree.Location = New System.Drawing.Point(471, 178)
        Me.PermFileTree.Name = "PermFileTree"
        Me.PermFileTree.Size = New System.Drawing.Size(549, 397)
        Me.PermFileTree.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label3.Location = New System.Drawing.Point(465, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 26)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Permissions:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.Panel1.Controls.Add(Me.PictureBox4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(352, 664)
        Me.Panel1.TabIndex = 20
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.PictureBox4.Location = New System.Drawing.Point(0, 32)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(10, 575)
        Me.PictureBox4.TabIndex = 0
        Me.PictureBox4.TabStop = False
        '
        'ManualAddUser
        '
        Me.ManualAddUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.ManualAddUser.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ManualAddUser.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ManualAddUser.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.ManualAddUser.Location = New System.Drawing.Point(43, 618)
        Me.ManualAddUser.Margin = New System.Windows.Forms.Padding(5)
        Me.ManualAddUser.Name = "ManualAddUser"
        Me.ManualAddUser.Size = New System.Drawing.Size(264, 24)
        Me.ManualAddUser.TabIndex = 22
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.PictureBox2.BackgroundImage = Global.TwitchViewerRoles.My.Resources.Resources.textbox_Corners
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(15, 605)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(332, 52)
        Me.PictureBox2.TabIndex = 21
        Me.PictureBox2.TabStop = False
        '
        'SearchButton
        '
        Me.SearchButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SearchButton.Image = Global.TwitchViewerRoles.My.Resources.Resources.SearchButton
        Me.SearchButton.Location = New System.Drawing.Point(881, 97)
        Me.SearchButton.Name = "SearchButton"
        Me.SearchButton.Size = New System.Drawing.Size(90, 33)
        Me.SearchButton.TabIndex = 16
        Me.SearchButton.TabStop = False
        '
        'LB_Browse_Button
        '
        Me.LB_Browse_Button.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LB_Browse_Button.Image = CType(resources.GetObject("LB_Browse_Button.Image"), System.Drawing.Image)
        Me.LB_Browse_Button.Location = New System.Drawing.Point(881, 51)
        Me.LB_Browse_Button.Name = "LB_Browse_Button"
        Me.LB_Browse_Button.Size = New System.Drawing.Size(90, 33)
        Me.LB_Browse_Button.TabIndex = 14
        Me.LB_Browse_Button.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.TwitchViewerRoles.My.Resources.Resources.HoverMax
        Me.PictureBox1.Location = New System.Drawing.Point(945, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(44, 34)
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'MinimizeButton
        '
        Me.MinimizeButton.BackgroundImage = Global.TwitchViewerRoles.My.Resources.Resources.Minimize
        Me.MinimizeButton.Location = New System.Drawing.Point(901, 0)
        Me.MinimizeButton.Name = "MinimizeButton"
        Me.MinimizeButton.Size = New System.Drawing.Size(44, 34)
        Me.MinimizeButton.TabIndex = 7
        Me.MinimizeButton.TabStop = False
        '
        'CloseButton
        '
        Me.CloseButton.BackgroundImage = Global.TwitchViewerRoles.My.Resources.Resources.Close
        Me.CloseButton.Location = New System.Drawing.Point(988, 0)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(44, 34)
        Me.CloseButton.TabIndex = 6
        Me.CloseButton.TabStop = False
        '
        'HeaderBar
        '
        Me.HeaderBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.HeaderBar.BackgroundImage = Global.TwitchViewerRoles.My.Resources.Resources.MenuBar
        Me.HeaderBar.Image = Global.TwitchViewerRoles.My.Resources.Resources.MenuBar
        Me.HeaderBar.Location = New System.Drawing.Point(-46, 0)
        Me.HeaderBar.Margin = New System.Windows.Forms.Padding(0)
        Me.HeaderBar.Name = "HeaderBar"
        Me.HeaderBar.Size = New System.Drawing.Size(1079, 34)
        Me.HeaderBar.TabIndex = 4
        Me.HeaderBar.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.PictureBox3.Location = New System.Drawing.Point(0, 597)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(1032, 67)
        Me.PictureBox3.TabIndex = 23
        Me.PictureBox3.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.PictureBox5.Location = New System.Drawing.Point(1023, 32)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(10, 575)
        Me.PictureBox5.TabIndex = 24
        Me.PictureBox5.TabStop = False
        '
        'DocLabel
        '
        Me.DocLabel.AutoSize = True
        Me.DocLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.DocLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DocLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DocLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.DocLabel.Location = New System.Drawing.Point(886, 634)
        Me.DocLabel.Name = "DocLabel"
        Me.DocLabel.Size = New System.Drawing.Size(122, 20)
        Me.DocLabel.TabIndex = 25
        Me.DocLabel.Text = "Documentation"
        '
        'TwitchViewerRoles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1032, 664)
        Me.Controls.Add(Me.DocLabel)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.ManualAddUser)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PermFileTree)
        Me.Controls.Add(Me.AppLabel)
        Me.Controls.Add(Me.SearchButton)
        Me.Controls.Add(Me.UsersTree)
        Me.Controls.Add(Me.LB_Browse_Button)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.SAMMICorePath)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MinimizeButton)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.HeaderBar)
        Me.Controls.Add(Me.ChannelName)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TwitchViewerRoles"
        Me.Text = "Twitch Viewer Roles"
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LB_Browse_Button, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MinimizeButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CloseButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HeaderBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ChannelName As TextBox
    Friend WithEvents HeaderBar As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CloseButton As PictureBox
    Friend WithEvents MinimizeButton As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents SAMMICorePath As TextBox
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents LB_Browse_Button As PictureBox
    Friend WithEvents UsersTree As TreeView
    Friend WithEvents SearchButton As PictureBox
    Friend WithEvents AppLabel As Label
    Friend WithEvents PermFileTree As TreeView
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents ManualAddUser As TextBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents DocLabel As Label
End Class
