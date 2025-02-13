Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class FormOuvidoriasOK
    Dim main As New Main
    Dim protocolsData As DataTable
    Private Sub FormOuvidoriasOK_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = FmainOuvidoria.Icon
        Try

            getProtocols()
            dgProtocolosOK.Columns(0).Visible = False
            dgProtocolosOK.Columns(1).HeaderText = "Protocolo"
            dgProtocolosOK.Columns(1).Width = 60
            dgProtocolosOK.Columns(2).HeaderText = "Destino"
            dgProtocolosOK.Columns(2).Width = 200
            dgProtocolosOK.Columns(3).HeaderText = "Data abertura"
            dgProtocolosOK.Columns(3).Width = 80
            dgProtocolosOK.Columns(4).HeaderText = "1º Contato"
            dgProtocolosOK.Columns(4).Width = 80
            dgProtocolosOK.Columns(5).HeaderText = "Status"
            dgProtocolosOK.Columns(5).Width = 80
            dgProtocolosOK.Columns(6).Visible = False
            dgProtocolosOK.Columns(7).Visible = False
            dgProtocolosOK.Columns(8).Visible = False
            dgProtocolosOK.Columns(9).Visible = False

        Catch ex As Exception

        End Try

    End Sub

    Private Function getProtocols()
        Dim data = main.getDataset("SELECT manifestacoes.id, ouvidoria.protocolo,destinos.descricao ,ouvidoria.abertura, ouvidoria.1contato,ouvidoria.`status`, manifestacoes.manifest, manifestacoes.resposta, manifestacoes.ok, destinos.id AS id_destino
        FROM manifestacoes
        JOIN ouvidoria ON ouvidoria.id = manifestacoes.id_ouvidoria
        JOIN destinos ON destinos.id = ouvidoria.id_destino
        WHERE manifestacoes.ok = 1 AND ouvidoria.status != 'Concluido'")

        If data.Rows.Count > 0 Then
            dgProtocolosOK.DataSource = data
            protocolsData = data
            Return data
        Else
            ' main.msgInfo("Não existem registros.")
            RichTextBoxRespostaAutorizada.Clear()
            Return False
        End If

        dgProtocolosOK.ClearSelection()

    End Function

    Private Function getDestino(idDestino As Integer, resposta As String)
        Select Case idDestino
            Case 1
                Return "Conforme esclarecimentos do Ambulatório Médico de Especialidades (AME) de Peruíbe:" & vbCrLf & vbCrLf & resposta & vbCrLf & vbCrLf & "Sendo assim encerramos essa requisição."
            Case 2
                Return "Conforme esclarecimentos do Departamento de Atenção Básica:" & vbCrLf & vbCrLf & resposta & vbCrLf & vbCrLf & "Sendo assim encerramos essa requisição."
            Case 3
                Return "Conforme esclarecimentos do CAPS:" & vbCrLf & vbCrLf & resposta & vbCrLf & vbCrLf & "Sendo assim encerramos essa requisição."
            Case 4
                Return "Conforme esclarecimentos da Casa da Mulher e da Criança:" & vbCrLf & vbCrLf & resposta & vbCrLf & vbCrLf & "Sendo assim encerramos essa requisição."
            Case 5
                Return "Conforme esclarecimentos do Controle de Endemias:" & vbCrLf & vbCrLf & resposta & vbCrLf & vbCrLf & "Sendo assim encerramos essa requisição."
            Case 6
                Return "Conforme esclarecimentos da Assistência Farmacêutica:" & vbCrLf & vbCrLf & resposta & vbCrLf & vbCrLf & "Sendo assim encerramos essa requisição."
            Case 7
                Return "Conforme esclarecimentos do Setor de Frota da Saúde:" & vbCrLf & vbCrLf & resposta & vbCrLf & vbCrLf & "Sendo assim encerramos essa requisição."
            Case 8
                Return "Conforme esclarecimentos da Central de Regulação de Vagas:" & vbCrLf & vbCrLf & resposta & vbCrLf & vbCrLf & "Sendo assim encerramos essa requisição."
            Case 9
                Return "Conforme esclarecimentos da Central de Regulação de Vagas:" & vbCrLf & vbCrLf & resposta & vbCrLf & vbCrLf & "Sendo assim encerramos essa requisição."
            Case 10
                Return "Conforme esclarecimentos do Serviço de Atendimento Especializado (SAE):" & vbCrLf & vbCrLf & resposta & vbCrLf & vbCrLf & "Sendo assim encerramos essa requisição."
            Case 11
                Return "Conforme esclarecimentos da Secretaria Municipal de Saúde de Peruibe:" & vbCrLf & vbCrLf & resposta & vbCrLf & vbCrLf & "Sendo assim encerramos essa requisição."
            Case 12
                Return "Conforme esclarecimentos da Unidade de Pronto Atendimento de Peruibe - UPA24H:" & vbCrLf & vbCrLf & resposta & vbCrLf & vbCrLf & "Sendo assim encerramos essa requisição."
            Case 13
                Return "Conforme esclarecimentos do Serviço Municipal De Vigilância Sanitária:" & vbCrLf & vbCrLf & resposta & vbCrLf & vbCrLf & "Sendo assim encerramos essa requisição."
            Case 14
                Return "Conforme esclarecimentos do Centro de Controle de Zoonoses:" & vbCrLf & vbCrLf & resposta & vbCrLf & vbCrLf & "Sendo assim encerramos essa requisição."
            Case 15
                Return "Conforme esclarecimentos do AMFFITO:" & vbCrLf & vbCrLf & resposta & vbCrLf & vbCrLf & "Sendo assim encerramos essa requisição."
            Case 16
                Return "Conforme esclarecimentos do Departamento de Saúde Bucal:" & vbCrLf & vbCrLf & resposta & vbCrLf & vbCrLf & "Sendo assim encerramos essa requisição."
            Case 17
                Return "Conforme esclarecimentos do Serviço de Atenção Psicosocial a Infância e Juventude-SAPSIJ:" & vbCrLf & vbCrLf & resposta & vbCrLf & vbCrLf & "Sendo assim encerramos essa requisição."
            Case Else
                Return False
        End Select

    End Function

    Private Sub btCopiaResposta_Click(sender As Object, e As EventArgs) Handles btCopiaResposta.Click
        If RichTextBoxRespostaAutorizada.TextLength > 0 Then
            Clipboard.SetText(RichTextBoxRespostaAutorizada.Text)
            main.msgInfo("Copiado!")
        End If

    End Sub
    Private Sub tbBuscaProtocolo_TextChanged(sender As Object, e As EventArgs) Handles tbBuscaProtocolo.TextChanged
        Dim filtro As String = tbBuscaProtocolo.Text.ToLower() ' Obtém o texto do TextBox em minúsculas
        For Each row As DataGridViewRow In dgProtocolosOK.Rows
            Dim valorCelula As String = row.Cells("Protocolo").Value.ToString().ToLower() ' Obtém o valor da coluna em minúsculas
            If valorCelula.Contains(filtro) Then
                row.Visible = True ' Exibe a linha se o valor da célula contém o filtro
            Else
                row.Visible = False ' Oculta a linha se o valor da célula não contém o filtro
            End If
        Next
    End Sub

    Private Sub btRefresh_Click(sender As Object, e As EventArgs) Handles btRefresh.Click
        getProtocols()
    End Sub

    Private Sub dgProtocolosOK_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgProtocolosOK.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Try
                Dim valorCelula As String = dgProtocolosOK.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
                Clipboard.SetText(valorCelula)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub dgProtocolosOK_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgProtocolosOK.RowsAdded
        StatusLabelRegistrosOuve.Text = $"Registros: {dgProtocolosOK.Rows.Count}"
    End Sub

    Private Sub dgProtocolosOK_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgProtocolosOK.RowsRemoved
        StatusLabelRegistrosOuve.Text = $"Registros: {dgProtocolosOK.Rows.Count}"
    End Sub

    Private Sub btConcluirOuvidoria_Click(sender As Object, e As EventArgs) Handles btConcluirOuvidoria.Click
        Try
            Dim dataAtual As DateTime = DateTime.Now
            Dim dataEncerramento As String = dataAtual.ToString("dd/MM/yyyy HH:mm")
            Dim protocolo = dgProtocolosOK.SelectedRows.Item(0).Cells(1).Value

            If protocolo <> Nothing And RichTextBoxRespostaAutorizada.TextLength > 0 Then

                If main.doQuery($"UPDATE ouvidoria SET status='Concluido', encerramento='{dataEncerramento}' WHERE protocolo={protocolo}") Then
                    main.msgInfo("Ouvidoria concluida com sucesso!")
                    RichTextBoxRespostaAutorizada.Clear()
                    getProtocols()
                End If

            Else
                main.msgAlert("Selecione um protocolo.")
            End If

        Catch ex As Exception
            'MsgBox($"Falha ao atualizar! {vbCrLf & vbCrLf} {ex.Message}")
            main.msgAlert("Selecione um protocolo.")
        End Try
    End Sub

    Private Sub dgProtocolosOK_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgProtocolosOK.CellEnter
        Try
            Dim resposta = protocolsData.Rows(dgProtocolosOK.SelectedRows.Item(0).Index).Item(7).ToString
            RichTextBoxRespostaAutorizada.Text = getDestino(protocolsData.Rows(dgProtocolosOK.SelectedRows.Item(0).Index).Item(9), resposta)
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

End Class