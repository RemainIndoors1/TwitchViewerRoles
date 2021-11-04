Public Class UserRolesDialog

    Dim m_blnSpacePress As Boolean = False

    Private Sub GroupUserDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

#Region "Escape Space for GroupName"

    Private Sub UserDialogComboBox_KeyDown(senders As Object, e As KeyEventArgs) Handles UserDialogComboBox.KeyDown
        If e.KeyCode = Keys.Space Then
            m_blnSpacePress = True
        End If
    End Sub

    Private Sub UserDialogComboBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UserDialogComboBox.KeyPress
        If m_blnSpacePress Then
            e.Handled = True
            m_blnSpacePress = False
        End If
    End Sub

#End Region

End Class