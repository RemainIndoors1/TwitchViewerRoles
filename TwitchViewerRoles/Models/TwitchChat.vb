Imports System.Collections.Generic
'Public Class Links
'    Public Property 
'End Class

Public Class Chatters
    Public Property broadcaster As New List(Of String)
    Public Property vips As New List(Of String)
    Public Property moderators As New List(Of String)
    Public Property staff As New List(Of String)
    Public Property admins As New List(Of String)
    Public Property global_mods As New List(Of String)
    Public Property viewers As New List(Of String)
End Class

Public Class TwitchChat
    Public Property chatter_count As Integer
    Public Property chatters As Chatters
End Class

