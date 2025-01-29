Public Class Logs
    Dim vmain As New Main

    Dim queryLogs As String = "SELECT logs.id,logs.action,usuarios.nome,logs.time FROM logs JOIN usuarios ON logs.id_usuario = usuarios.id "

    Dim dgLogsCollumsHeaderText() As String = {"ID", "Ação", "Usuário", "Data"}
    Dim dgLogsCollums() As Boolean = {False, True, True, True}
    Dim dgLogsWidth() As Integer = {0, 330, 140, 99}

    Public Sub loadLogs(ByVal grid As DataGridView, ByVal criterios As String, Optional ByVal collumMode As DataGridViewAutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None)
        vmain.loadDataGrid(queryLogs & criterios & " ORDER BY logs.time DESC", grid, dgLogsCollums, dgLogsCollumsHeaderText, dgLogsWidth, collumMode)
    End Sub

    Public Sub insertLog(ByVal action As String, ByVal idUsuario As Integer)
        vmain.SQLinsert("logs", "action,id_usuario", "'" & action & "'," & idUsuario)
    End Sub

End Class
