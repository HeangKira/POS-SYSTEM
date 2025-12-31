Public Class UserSession
    Public Shared Property Permissions As New List(Of UserPermission)
    Public Shared Property IsAdmin As Boolean = False

    ' Logic to check specific actions
    Public Shared Function HasAction(modulePath As String, actionType As String) As Boolean
        If IsAdmin Then Return True ' ADMIN bypass

        Dim perm = Permissions.FirstOrDefault(Function(x) x.module_path = modulePath)
        If perm Is Nothing Then Return False

        Select Case actionType.ToLower()
            Case "view" : Return perm.can_view
            Case "create" : Return perm.can_create
            Case "update" : Return perm.can_update
            Case "delete" : Return perm.can_delete
            Case Else : Return False
        End Select
    End Function
End Class

Public Class UserPermission
    Public Property module_path As String
    Public Property can_view As Boolean
    Public Property can_create As Boolean ' ⭐ ADDED
    Public Property can_update As Boolean ' ⭐ ADDED
    Public Property can_delete As Boolean ' ⭐ ADDED
End Class