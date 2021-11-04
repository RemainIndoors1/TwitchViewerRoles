<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserRolesDialog
    Inherits DarkUI.Forms.DarkForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.UserDialogComboBox = New System.Windows.Forms.ComboBox()
        Me.UserDialogAccept = New System.Windows.Forms.Button()
        Me.UserDialogCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'UserDialogComboBox
        '
        Me.UserDialogComboBox.FormattingEnabled = True
        Me.UserDialogComboBox.Location = New System.Drawing.Point(40, 76)
        Me.UserDialogComboBox.Name = "UserDialogComboBox"
        Me.UserDialogComboBox.Size = New System.Drawing.Size(299, 24)
        Me.UserDialogComboBox.TabIndex = 0
        '
        'UserDialogAccept
        '
        Me.UserDialogAccept.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.UserDialogAccept.Location = New System.Drawing.Point(96, 151)
        Me.UserDialogAccept.Name = "UserDialogAccept"
        Me.UserDialogAccept.Size = New System.Drawing.Size(75, 23)
        Me.UserDialogAccept.TabIndex = 1
        Me.UserDialogAccept.Text = "Accept"
        Me.UserDialogAccept.UseVisualStyleBackColor = True
        '
        'UserDialogCancel
        '
        Me.UserDialogCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.UserDialogCancel.Location = New System.Drawing.Point(199, 151)
        Me.UserDialogCancel.Name = "UserDialogCancel"
        Me.UserDialogCancel.Size = New System.Drawing.Size(75, 23)
        Me.UserDialogCancel.TabIndex = 2
        Me.UserDialogCancel.Text = "Cancel"
        Me.UserDialogCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Trebuchet MS", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.Location = New System.Drawing.Point(55, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(262, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Select a Role Or Enter a New One"
        '
        'UserRolesDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(382, 243)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.UserDialogCancel)
        Me.Controls.Add(Me.UserDialogAccept)
        Me.Controls.Add(Me.UserDialogComboBox)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.TwitchViewerRoles.My.MySettings.Default, "Location", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = Global.TwitchViewerRoles.My.MySettings.Default.Location
        Me.Name = "UserRolesDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Add User Role"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents UserDialogComboBox As ComboBox
    Friend WithEvents UserDialogAccept As Button
    Friend WithEvents UserDialogCancel As Button
    Friend WithEvents Label1 As Label
End Class
