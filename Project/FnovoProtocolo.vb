Public Class FnovoProtocolo
    Dim m As New Main
    Dim vcaixa As New Caixa
    Dim vlog As New Logs
    Dim vlInicial As Decimal
    Dim dados As DataTable

    Private Sub FnovoProtocolo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m.loadComboBox("SELECT id,descricao FROM destinos WHERE id <> 0 ORDER BY descricao", cbDestinatario, "descricao", "id")
        cbFormaEnvio.SelectedIndex = 0
        cbOrigem.SelectedIndex = 0
        cbDestinatario.SelectedIndex = -1
    End Sub

    Private Sub btSalvarProtocolo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSalvarProtocolo.Click

        If m.requiredFields(tbProtocolo, cbDestinatario, mtbAbertura) Then
            If m.SQLinsert("ouvidoria", "protocolo,sistema,id_destino,forma_envio,abertura,1contato", "'" & tbProtocolo.Text & "','" & cbOrigem.Text & "'," & cbDestinatario.SelectedValue & ",'" & cbFormaEnvio.Text & "','" & m.mysqlDateFormat(mtbAbertura.Text) & "','" & m.mysqlDateFormat(Date.Today.Date) & "'", True) Then
                FmainOuvidoria.loadProtocolos("WHERE ouvidoria.sistema = 'eOuve' AND ouvidoria.`status` = 'Em andamento'")
                m.clearFields(gbDadosProtocolo)
            End If
        End If

    End Sub

    Private Sub btSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSair.Click
        Me.Close()
    End Sub

    Private Sub btEnviarEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEnviarEmail.Click
        If tbProtocolo.Text <> Nothing Then
            Fmail.ShowDialog()
        Else
            m.msgInfo("Protocolo não pode ser vazio!")
            tbProtocolo.Focus()
        End If
    End Sub

    Private Sub FnovoProtocolo_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        tbProtocolo.Focus()
    End Sub

    Private Sub cbDestinatario_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDestinatario.SelectionChangeCommitted
        Dim frase = m.SQLread("respostas", "resposta", "WHERE id_destino=" & cbDestinatario.SelectedValue & " AND tipo=1").Rows(0).Item(0).ToString

        Dim copy_buffer As New System.Text.StringBuilder
        copy_buffer.AppendLine(frase)
        If copy_buffer.Length > 0 Then
            Clipboard.SetText(copy_buffer.ToString)
        End If

    End Sub


End Class