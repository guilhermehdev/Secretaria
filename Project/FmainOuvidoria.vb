Imports System.IO

Public Class FmainOuvidoria
    Dim m As New Main
    Dim qryProtocolos = "SELECT ouvidoria.id_destino AS iddestino,ouvidoria.id AS id,ouvidoria.protocolo,ouvidoria.sistema,ouvidoria.forma_envio,ouvidoria.abertura,ouvidoria.1contato,ouvidoria.encerramento,ouvidoria.`status`,destinos.descricao AS destino,coordenador.nome AS coordenador FROM ouvidoria JOIN destinos ON ouvidoria.id_destino = destinos.id JOIN coordenador ON coordenador.id = destinos.id_coordenador "
    Dim dgProtocolosCollumsHeaderText() As String = {"iddestino", "ID", "Protocolo", "Canal", "Forma de envio", "Abertura", "1º contato", "Encerramento", "Status", "Destino", "Coordenador", "Prazo"}
    Dim dgProtocolosCollums() As Boolean = {False, False, True, True, True, True, True, True, True, True, True, True}
    Dim dgProtocolosCollumsWidth() As Integer = {0, 60, 60, 50, 60, 80, 80, 115, 90, 200, 100, 0}
    Dim col As New DataGridViewTextBoxColumn

    Private Sub btNovoProtocolo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNovoProtocolo.Click
        FnovoProtocolo.ShowDialog()
    End Sub

    Private Sub BancoDeDadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BancoDeDadosToolStripMenuItem.Click

        FConnSettings.ShowDialog()
    End Sub

    Private Sub UsuáriosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsuáriosToolStripMenuItem.Click
        Fusuarios.ShowDialog()
    End Sub

    Private Sub BackupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupToolStripMenuItem.Click
        Fbackup.ShowDialog()
    End Sub

    Private Sub Fmain_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Me.BringToFront()
    End Sub

    Private Sub SairToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SairToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub niMinimizar_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles niMinimizar.MouseDoubleClick
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Show()
            Me.WindowState = FormWindowState.Maximized
            Me.BringToFront()
        Else
            Me.WindowState = FormWindowState.Minimized
            Me.Hide()
        End If

        Me.BringToFront()

    End Sub

    Private Sub LogsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogsToolStripMenuItem.Click
        Flogs.ShowDialog()
    End Sub

    Private Function getData()
        Dim dgContainer = dgListProtocolos.SelectedRows.Item(0)
        Dim arrOfProtocolo As Array = {dgContainer.Cells(0).Value, dgContainer.Cells(1).Value, dgContainer.Cells(2).Value, dgContainer.Cells(3).Value, dgContainer.Cells(4).Value, dgContainer.Cells(5).Value, dgContainer.Cells(6).Value, dgContainer.Cells(7).Value, dgContainer.Cells(8).Value, dgContainer.Cells(9).Value, dgContainer.Cells(10).Value, dgContainer.Cells(11).Value}

        Return arrOfProtocolo

    End Function


    Private Sub Fmain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            pbBackground.ImageLocation = My.Settings.background

            col.DataPropertyName = "prazo"
            col.HeaderText = "Prazo"
            col.Name = "prazo"
            col.Width = 99

            m.loadComboBox("SELECT id,descricao FROM destinos ORDER BY id", cbBuscaDestinatario, "descricao", "id")
            cbBuscaDestinatario.SelectedIndex = 0
            cbBuscaStatus.SelectedIndex = 1
            cbBuscaOrigem.SelectedIndex = 0
            tbBuscaProtocolo.Focus()
            tbBuscaProtocolo.SelectAll()

            loadProtocolos("WHERE ouvidoria.sistema = 'eOuve' AND ouvidoria.`status` = 'Em andamento'")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub rowColors()
        For row = 0 To dgListProtocolos.Rows.Count - 1
            Dim prazo = DateDiff("d", dgListProtocolos.Rows.Item(row).Cells(5).Value, Now)
            Dim sts = dgListProtocolos.Rows.Item(row).Cells(8).Value
            Dim canal = dgListProtocolos.Rows.Item(row).Cells(3).Value

            Try

                If prazo > 30 And canal <> "OuvidorSUS" Then
                    If sts = "Em andamento" Or sts = "Vencido" Then
                        dgListProtocolos.Rows.Item(row).Cells(11).Value = "vencido a " & prazo - 30 & " dias"
                        m.doQuery("UPDATE ouvidoria SET status='Vencido' WHERE id=" & dgListProtocolos.Rows.Item(row).Cells(1).Value)
                    End If
                Else
                    If sts = "Em andamento" Then
                        dgListProtocolos.Rows.Item(row).Cells(11).Value = prazo & " dias"
                    End If
                End If

                Select Case sts
                    Case "Em andamento"
                        dgListProtocolos.Rows.Item(row).DefaultCellStyle.BackColor = Color.Yellow
                    Case "Concluido"
                        dgListProtocolos.Rows.Item(row).DefaultCellStyle.BackColor = Color.YellowGreen
                    Case "Duplicado"
                        dgListProtocolos.Rows.Item(row).DefaultCellStyle.BackColor = Color.DarkOrange
                        dgListProtocolos.Rows.Item(row).DefaultCellStyle.ForeColor = Color.White
                    Case "Cancelado"
                        dgListProtocolos.Rows.Item(row).DefaultCellStyle.BackColor = Color.Gray
                        dgListProtocolos.Rows.Item(row).DefaultCellStyle.ForeColor = Color.White
                    Case "Elogio"
                        dgListProtocolos.Rows.Item(row).DefaultCellStyle.BackColor = Color.SkyBlue
                        dgListProtocolos.Rows.Item(row).DefaultCellStyle.ForeColor = Color.Black
                    Case "Reencaminhado"
                        dgListProtocolos.Rows.Item(row).DefaultCellStyle.BackColor = Color.RosyBrown
                        dgListProtocolos.Rows.Item(row).DefaultCellStyle.ForeColor = Color.Black
                    Case "Vencido"
                        dgListProtocolos.Rows.Item(row).DefaultCellStyle.BackColor = Color.IndianRed
                        dgListProtocolos.Rows.Item(row).DefaultCellStyle.ForeColor = Color.White
                End Select

            Catch ex As Exception

            End Try

        Next

        dgListProtocolos.FirstDisplayedScrollingRowIndex = 0
        dgListProtocolos.Rows(0).Selected = True

    End Sub

    Public Sub loadProtocolos(Optional ByVal params As String = "")
        Try
            dgListProtocolos.Columns.Remove(col)
        Catch ex As Exception

        End Try

        Try

            m.loadDataGrid(qryProtocolos & params & " ORDER BY status DESC, protocolo DESC", dgListProtocolos, dgProtocolosCollums, dgProtocolosCollumsHeaderText, dgProtocolosCollumsWidth, DataGridViewAutoSizeColumnsMode.None)

            If dgListProtocolos.RowCount > 0 Then

                If dgListProtocolos.Columns.Count <= 12 Then
                    dgListProtocolos.Columns.Add(col)
                Else

                End If

                rowColors()
                statusLabel.Text = dgListProtocolos.RowCount & " registros"

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub PlanoDeFundoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlanoDeFundoToolStripMenuItem.Click
        Fbackground.ShowDialog()
    End Sub

    Private Sub dgListProtocolos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgListProtocolos.CellDoubleClick

        m.loadComboBox("SELECT id,descricao FROM destinos ORDER BY descricao", FeditarProtocolo.cbEditarDestinatario, "descricao", "id")
        FeditarProtocolo.cbEditarDestinatario.SelectedValue = getData(0)
        FeditarProtocolo.tbEditarProtocolo.Text = getData(2).ToString
        FeditarProtocolo.cbEditarOrigem.Text = getData(3).ToString
        FeditarProtocolo.cbEditarFormaEnvio.Text = getData(4).ToString
        FeditarProtocolo.mtbEditarAbertura.Text = getData(5).ToString

        If Not IsDate(getData(6)) Then
            FeditarProtocolo.mtbEditar1contato.Text = Date.Today.Date.ToString
        Else
            FeditarProtocolo.mtbEditar1contato.Text = getData(6).ToString
        End If
        FeditarProtocolo.cbEditarStatus.Text = getData(8).ToString
        FeditarProtocolo.mtbEditarEncerramento.Text = getData(7).ToString

        FeditarProtocolo.ShowDialog()

    End Sub

    Private Sub dgListProtocolos_Sorted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgListProtocolos.Sorted
        rowColors()
    End Sub

    Private Sub tbBuscaProtocolo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbBuscaProtocolo.TextChanged
        If tbBuscaProtocolo.TextLength >= 7 Then
            loadProtocolos("WHERE ouvidoria.protocolo =" & tbBuscaProtocolo.Text)
        Else
            loadProtocolos()
        End If


    End Sub

    Private Sub cbBuscaDestinatario_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbBuscaDestinatario.SelectionChangeCommitted
        reloadGrid()
    End Sub

    Private Sub cbBuscaStatus_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbBuscaStatus.TextChanged
        reloadGrid()

        'If cbBuscaDestinatario.SelectedIndex < 0 Then
        'If cbBuscaStatus.SelectedIndex = 0 Then
        'loadProtocolos("WHERE ouvidoria.sistema='" & cbBuscaOrigem.Text & "'")
        'Else
        'loadProtocolos("WHERE ouvidoria.status='" & cbBuscaStatus.Text & "' AND ouvidoria.sistema='" & cbBuscaOrigem.Text & "'")
        'End If
        'Else
        'If cbBuscaStatus.SelectedIndex = 0 Then
        'loadProtocolos("WHERE ouvidoria.id_destino=" & cbBuscaDestinatario.SelectedValue & " AND ouvidoria.sistema='" & cbBuscaOrigem.Text & "'")
        'Else
        'loadProtocolos("WHERE ouvidoria.status='" & cbBuscaStatus.Text & "' AND ouvidoria.id_destino=" & cbBuscaDestinatario.SelectedValue & " AND ouvidoria.sistema='" & cbBuscaOrigem.Text & "'")
        'End If
        'End If

    End Sub

    Private Sub btRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRefresh.Click
        reloadGrid()
    End Sub

    Public Sub reloadGrid()
        If cbBuscaStatus.SelectedIndex = 0 And cbBuscaDestinatario.SelectedIndex = 0 Then
            loadProtocolos("WHERE ouvidoria.sistema='" & cbBuscaOrigem.Text & "'")
        ElseIf cbBuscaStatus.SelectedIndex > 0 And cbBuscaDestinatario.SelectedIndex > 0 Then
            loadProtocolos("WHERE ouvidoria.status='" & cbBuscaStatus.Text & "' AND ouvidoria.id_destino=" & cbBuscaDestinatario.SelectedValue & " AND ouvidoria.sistema='" & cbBuscaOrigem.Text & "'")
        ElseIf cbBuscaStatus.SelectedIndex = 0 And cbBuscaDestinatario.SelectedIndex > 0 Then
            loadProtocolos("WHERE ouvidoria.id_destino=" & cbBuscaDestinatario.SelectedValue & " AND ouvidoria.sistema='" & cbBuscaOrigem.Text & "'")
        ElseIf cbBuscaStatus.SelectedIndex > 0 And cbBuscaDestinatario.SelectedIndex = 0 Then
            loadProtocolos("WHERE ouvidoria.status='" & cbBuscaStatus.Text & "' AND ouvidoria.sistema='" & cbBuscaOrigem.Text & "'")
        End If
    End Sub

    Private Sub FmainOuvidoria_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub


    Private Sub cbBuscaOrigem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbBuscaOrigem.SelectedIndexChanged
        reloadGrid()
    End Sub

    Private Sub PrazosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrazosToolStripMenuItem.Click
        FRelatorioPrazos.Show()
    End Sub

    Private Sub dgListProtocolos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgListProtocolos.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Try
                Dim valorCelula As String = dgListProtocolos.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
                Clipboard.SetText(valorCelula)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub ImportarDoEOuveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportarDoEOuveToolStripMenuItem.Click
        Dim pdfFiles As New List(Of String)()
        Dim pdfNotFound As New List(Of String)()
        Dim pdf As New PDF

        OpenFileDialog1.Filter = "PDF Files (*.pdf)|*.pdf"
        OpenFileDialog1.Multiselect = True

        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            pdfFiles.AddRange(OpenFileDialog1.FileNames)
        End If

        For Each pdfFile As String In pdfFiles
            Dim dataOuvidoria As Dictionary(Of String, String) = pdf.ExtrairDadosOuvidoria(pdfFile)
            Dim datatable = m.getDataset($"SELECT id FROM ouvidoria WHERE protocolo ={dataOuvidoria("MANIFESTAÇÃO")}")
            Dim id As Integer

            If datatable.Rows.Count > 0 Then
                Dim dataManifestacao As String
                id = datatable.Rows(0).Item(0)

                dataManifestacao = "Protocolo: " & dataOuvidoria("MANIFESTAÇÃO") & vbCrLf & vbCrLf & "Data: " & dataOuvidoria("Recebido em") & vbCrLf & vbCrLf & "Solicitante: " & dataOuvidoria("Solicitante") & vbCrLf & vbCrLf & "Telefone: " & dataOuvidoria("Telefone") & vbCrLf & vbCrLf & "Manifestação: " & dataOuvidoria("Manifestação") & vbCrLf & vbCrLf & dataOuvidoria("Andamento")

                Dim res = m.SQLinsert("manifestacoes", "manifest,id_ouvidoria", "'" & dataManifestacao & "'," & id)

                If res <> True Then
                    m.doQuery($"UPDATE manifestacoes SET manifest='{dataManifestacao}' WHERE id_ouvidoria={id}")
                End If

            Else
                pdfNotFound.Add(dataOuvidoria("MANIFESTAÇÃO"))
            End If
        Next



        MessageBox.Show($"{pdfFiles.Count} arquivo(s) PDF importado(s) com sucesso!", "Importar arquivos PDF", MessageBoxButtons.OK)

        Dim joinProtocols As String = String.Join(vbCrLf, pdfNotFound)

        If joinProtocols.Count > 0 Then
            m.msgAlert($"Protocolos não cadastrados:{vbCrLf & vbCrLf & joinProtocols}")
        End If

    End Sub

    Private Sub ProntasParaEnvioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProntasParaEnvioToolStripMenuItem.Click
        FormOuvidoriasOK.Show()
    End Sub

End Class
