Public Class Flogs
    Dim vlogs As New Logs
    Dim vmain As New Main

    Private Sub search()
        vlogs.loadLogs(dgLogs, "WHERE logs.action LIKE '%" & tbSearch.Text & "%' AND logs.time BETWEEN '" & vmain.mysqlDateFormat(dtpInicial.Value.Date) & "' AND '" & vmain.mysqlDateFormat(dtpFinal.Value.Date) & "'")
    End Sub

    Private Sub Flogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpInicial.Value = Date.Today.AddDays(-1)
        dtpFinal.Value = Date.Today.AddDays(+1)
    End Sub

    Private Sub dtpInicial_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpInicial.ValueChanged
        vlogs.loadLogs(dgLogs, "WHERE logs.time BETWEEN '" & vmain.mysqlDateFormat(dtpInicial.Value.Date) & "' AND '" & vmain.mysqlDateFormat(dtpFinal.Value.Date) & "'")

    End Sub

    Private Sub dtpFinal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFinal.ValueChanged
        vlogs.loadLogs(dgLogs, "WHERE logs.time BETWEEN '" & vmain.mysqlDateFormat(dtpInicial.Value.Date) & "' AND '" & vmain.mysqlDateFormat(dtpFinal.Value.Date) & "'")
    End Sub

    Private Sub btSearchLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSearchLog.Click
        search()
    End Sub

    Private Sub tbSearch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbSearch.KeyDown
        If e.KeyData = Keys.Return Then
            e.SuppressKeyPress = True
            search()
        End If

    End Sub

    Private Sub btSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSair.Click
        Me.Dispose()
    End Sub

End Class