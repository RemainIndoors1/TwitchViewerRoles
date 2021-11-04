Public Class PermissionGroups
    Public Property Groups As New Dictionary(Of String, Users)
End Class

Public Class Users
    Public Property PermUsers As New List(Of String)
End Class