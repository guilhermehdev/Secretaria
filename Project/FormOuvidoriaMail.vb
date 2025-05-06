Imports System.IO

Public Class FormOuvidoriaMail
    Dim m As New Main
    Dim dados As DataTable
    Dim mail As New Mail
    Dim arrAtachments As New ArrayList

    Private Sub Fmail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dados = m.loadComboBox("SELECT id,email,descricao FROM destinos ORDER BY descricao", cbEmail, "email", "id")
        lbDestino.Text = m.searchDataTable(dados, "email", cbEmail.Text, "descricao")
        m.loadComboBox("SELECT id,resposta FROM respostas ORDER BY resposta", cbRespostas, "resposta", "id")

        cbTipoResposta.SelectedIndex = 0
        cbRespostas.SelectedIndex = -1

        If FormOuvidoriaNovoProtocolo.Visible = True Then
            cbEmail.SelectedIndex = FormOuvidoriaNovoProtocolo.cbDestinatario.SelectedIndex
            If FormOuvidoriaNovoProtocolo.cbOrigem.SelectedIndex = 0 Then
                tbAssunto.Text = "Protocolo " & FormOuvidoriaNovoProtocolo.tbProtocolo.Text & " da Ouvidoria"
            Else
                tbAssunto.Text = "Protocolo " & FormOuvidoriaNovoProtocolo.tbProtocolo.Text & " da Ouvidoria - OuvidorSUS"
            End If

        ElseIf FormOuvidoriaeditarProtocolo.Visible = True Then
            cbEmail.SelectedIndex = FormOuvidoriaEditarProtocolo.cbEditarDestinatario.SelectedIndex
            If FormOuvidoriaEditarProtocolo.cbEditarOrigem.SelectedIndex = 0 Then
                tbAssunto.Text = "Protocolo " & FormOuvidoriaEditarProtocolo.tbEditarProtocolo.Text & " da Ouvidoria"
            Else
                tbAssunto.Text = "Protocolo " & FormOuvidoriaEditarProtocolo.tbEditarProtocolo.Text & " da Ouvidoria - OuvidorSUS"
            End If

        End If

    End Sub

    Private Sub cbEmail_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbEmail.TextChanged
        lbDestino.Text = m.searchDataTable(dados, "email", cbEmail.Text, "descricao")
    End Sub

    Private Sub btSendEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSendEmail.Click

        If m.getDataset("SELECT 1contato FROM ouvidoria WHERE id =" & FormOuvidoriaMain.dgListProtocolos.CurrentRow.Cells(1).Value).Rows(0).Item(0).ToString = "" Then
            m.SQLupdate("ouvidoria", "1contato='" & m.mysqlDateFormat(Date.Today) & "'", "id", FormOuvidoriaMain.dgListProtocolos, FormOuvidoriaMain.dgListProtocolos.CurrentRow.Cells(1).Value, Nothing, False, False, "", False, 1)
            FormOuvidoriaMain.loadProtocolos("WHERE ouvidoria.sistema = '" & FormOuvidoriaMain.cbBuscaOrigem.Text & "' AND ouvidoria.`status` = 'Em andamento'")
        Else
            m.SQLupdate("ouvidoria", "2contato='" & m.mysqlDateFormat(Date.Today) & "'", "id", FormOuvidoriaMain.dgListProtocolos, FormOuvidoriaMain.dgListProtocolos.CurrentRow.Cells(1).Value, Nothing, False, False, "", False, 1)
            FormOuvidoriaMain.loadProtocolos("WHERE ouvidoria.sistema = '" & FormOuvidoriaMain.cbBuscaOrigem.Text & "' AND ouvidoria.`status` = 'Em andamento'")
        End If

        If mail.enviaMensagemEmail("ouvidoria.saude.pmp@gmail.com", cbEmail.Text, tbAssunto.Text, tbEmail.Text, arrAtachments) Then
            m.msgInfo("Email enviado com sucesso!")
        End If

    End Sub

    Private Sub cbTipoResposta_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTipoResposta.SelectionChangeCommitted
        Dim saudacao As String
        Dim email As String

        tbEmail.Text = ""
        cbRespostas.SelectedIndex = -1

        If DateDiff(DateInterval.Hour, Convert.ToDateTime("13:00:00"), Now) >= 0 Then
            saudacao = "Boa tarde!"
        Else
            saudacao = "Bom dia!"
        End If

        If cbTipoResposta.SelectedIndex = 0 Then
            m.loadComboBox("SELECT id,resposta FROM respostas ORDER BY resposta", cbRespostas, "resposta", "id")
        ElseIf cbTipoResposta.SelectedIndex = 1 Then
            m.loadComboBox("SELECT id,resposta FROM respostas WHERE tipo=1 ORDER BY resposta", cbRespostas, "resposta", "id")
        ElseIf cbTipoResposta.SelectedIndex = 2 Then
            m.loadComboBox("SELECT id,resposta FROM respostas WHERE tipo=2 ORDER BY resposta", cbRespostas, "resposta", "id")
        ElseIf cbTipoResposta.SelectedIndex = 3 Then
            m.loadComboBox("SELECT id,resposta FROM respostas WHERE tipo=3 ORDER BY resposta", cbRespostas, "resposta", "id")
        ElseIf cbTipoResposta.SelectedIndex = 4 Then
            m.loadComboBox("SELECT id,resposta FROM respostas WHERE tipo=4 ORDER BY resposta", cbRespostas, "resposta", "id")
        ElseIf cbTipoResposta.SelectedIndex = 5 Then
            m.loadComboBox("SELECT id,resposta FROM respostas WHERE tipo=5 ORDER BY resposta", cbRespostas, "resposta", "id")
        ElseIf cbTipoResposta.SelectedIndex = 6 Then
            email = saudacao & vbCrLf & vbCrLf & "Segue em anexo o arquivo da reclamação. Favor confirmar o recebimento do mesmo. <br><br>" & vbCrLf & vbCrLf & "Att."
            tbEmail.Text = email
        ElseIf cbTipoResposta.SelectedIndex = 7 Then
            email = saudacao & vbCrLf & vbCrLf & "Segue em anexo, para conhecimento, o arquivo com elogio ao departamento, protocolo já respondido no sistema. <br><br>" & vbCrLf & vbCrLf & "Att."
            tbEmail.Text = email
        End If
    End Sub

    Private Sub btAnexos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAnexos.Click
        attachment(ofdAttachments)
    End Sub

    Private Sub attachment(ByVal openFileDialog As Object)
        openFileDialog.ShowDialog()

        lbAnexos.Text = ""
        arrAtachments.Clear()

        For i = 0 To openFileDialog.FileNames.Length - 1
            Dim s As String() = (openFileDialog.FileNames(i).ToString()).Split("\"c)
            Dim count As Integer = s.Length
            arrAtachments.Add(openFileDialog.FileNames(i))

            If openFileDialog.FileNames.Length > 1 Then
                lbAnexos.Text += s(count - 1) & ", "
            Else
                lbAnexos.Text += s(count - 1)
            End If

        Next

    End Sub


    Private Sub btSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSair.Click
        Me.Close()
    End Sub

    Private Sub cbRespostas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRespostas.SelectedIndexChanged
        Dim saudacao As String
        Dim email As String

        If DateDiff(DateInterval.Hour, Convert.ToDateTime("13:00:00"), Now) >= 0 Then
            saudacao = "Boa tarde!"
        Else
            saudacao = "Bom dia!"
        End If

        email = saudacao & vbCrLf & vbCrLf & cbRespostas.Text & vbCrLf
        tbEmail.Text = email

    End Sub

    Private Sub btLimparEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLimparEmail.Click
        If m.msgQuestion("Limpar contúdo do Email?", "Limpar") Then
            tbEmail.Clear()
            tbEmail.Focus()
        End If

    End Sub

End Class