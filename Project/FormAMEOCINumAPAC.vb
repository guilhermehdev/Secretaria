Imports System.IO
Imports System.Security.Cryptography
Imports System.Text.RegularExpressions
Imports ClosedXML.Excel
Imports System.Text
Imports System.Windows

Public Class FormAMEOCINumAPAC
    Dim m As New Main
    Dim iduser As Integer = FormAMEOCI.idUser

    Public Sub loadNUMAPAC(datagridview As DataGridView, Optional faixaIni As String = Nothing, Optional faixaFim As String = Nothing, Optional available As Boolean = False, Optional user As Integer = Nothing, Optional dtIni As Date = Nothing, Optional dtFim As Date = Nothing, Optional oci As String = "", Optional status As String = "", Optional dtlanc As Date = Nothing, Optional order As String = "id", Optional custom As String = "", Optional medico As String = "", Optional labelCount As Label = Nothing)

        Try
            Dim where As String = "WHERE 1=1 "

            If Not String.IsNullOrEmpty(faixaIni) AndAlso Not String.IsNullOrEmpty(faixaFim) Then
                where &= $" AND oci.num_apac BETWEEN '{faixaIni}' AND '{faixaFim}' "
            End If
            If available = True Then
                where &= " AND oci.status = 'DISP' "
            End If
            If user <> Nothing Then
                where &= $" AND oci.id_usuario ={user} "
            End If
            If dtIni <> Nothing AndAlso dtFim <> Nothing Then
                where &= $" AND oci.data BETWEEN '{dtIni.ToString("yyyy-MM-dd")}' AND '{dtFim.ToString("yyyy-MM-dd")}' "
            End If
            If Not String.IsNullOrWhiteSpace(oci) Then
                where &= $" AND oci.id_cod_principal ={oci} "
            End If
            If Not String.IsNullOrWhiteSpace(status) Then
                where &= $" AND oci.status ='{status}' "
            End If
            ' Antes checava FormAMEOCI.dtpSearchData.CustomFormat (controle de OUTRA tela,
            ' sem relação com essa busca) - se esse DateTimePicker tivesse CustomFormat
            ' configurado no Designer (comum, independente do usuário ter escolhido algo),
            ' essa condição virava sempre verdadeira e aplicava o filtro com "dtlanc" no
            ' valor padrão (Date.MinValue), zerando o resultado inteiro. Agora checa o
            ' próprio parâmetro dtlanc, igual já fazia com dtIni/dtFim acima.
            If dtlanc <> Nothing Then
                where &= $" AND DATE(oci.data_lanc) ='{m.mysqlDateFormat(dtlanc)}' "
            End If
            If Not String.IsNullOrWhiteSpace(medico) Then
                where &= $" AND oci.id_medico ='{medico}' "
            End If

            Dim query = $"SELECT oci.id, oci.num_apac, cod_oci_principal.abrev AS oci, pacientes.nome, pacientes.dtnasc AS dtnasc, oci.`data`, oci.compet, servidores.nome AS medico, oci.status, usuarios.nome AS responsavel 
            FROM oci 
           LEFT JOIN pacientes ON pacientes.id = oci.id_paciente 
           LEFT JOIN servidores ON servidores.SUS = oci.id_medico
           LEFT JOIN cod_oci_principal ON cod_oci_principal.id = oci.id_cod_principal 
           LEFT JOIN usuarios ON usuarios.id = oci.id_usuario {where} {custom} ORDER BY {order}"

            Debug.Write(query)

            Dim data = FormAMEmain.getDataset(query)

            If data.Rows.Count > 0 Then

                datagridview.DataSource = data
                datagridview.Tag = data.DefaultView

                datagridview.Columns("id").Visible = False
                datagridview.Columns("num_apac").HeaderText = "Número APAC"
                datagridview.Columns("num_apac").Width = 100
                datagridview.Columns("oci").HeaderText = "OCI"
                datagridview.Columns("oci").Width = 220
                datagridview.Columns("nome").HeaderText = "Paciente"
                datagridview.Columns("nome").Width = 250
                datagridview.Columns("dtnasc").HeaderText = "Nascimento"
                datagridview.Columns("dtnasc").Width = 80
                datagridview.Columns("data").HeaderText = "Data"
                datagridview.Columns("data").Width = 70
                datagridview.Columns("compet").HeaderText = "Comp"
                datagridview.Columns("compet").Width = 80
                datagridview.Columns("medico").HeaderText = "Médico"
                datagridview.Columns("medico").Width = 200
                datagridview.Columns("status").HeaderText = "Status"
                datagridview.Columns("status").Width = 60
                datagridview.Columns("responsavel").HeaderText = "Usuário"
                datagridview.Columns("responsavel").Width = 150

                ' labelCount é Optional - se quem chamou não passou (como no cbMedico_SelectedIndexChanged
                ' que você me mostrou), ele vem Nothing e um .Text direto quebraria com
                ' NullReferenceException, engolido silenciosamente pelo Catch abaixo.
                If labelCount IsNot Nothing Then labelCount.Text = $"{data.Rows.Count} registros"

            Else
                datagridview.DataSource = Nothing
                If labelCount IsNot Nothing Then labelCount.Text = "0 registros"
            End If

        Catch ex As Exception
            ' Descomentado de propósito - estava engolindo qualquer erro (SQL, coluna
            ' inexistente, etc.) sem mostrar nada, o que mascarou o bug do dtpSearchData
            ' por quem sabe quanto tempo. Se quiser voltar a não mostrar popup em produção,
            ' pelo menos loga em algum lugar (Debug.WriteLine, arquivo de log) em vez de
            ' descartar a exceção inteira.
            MsgBox("Erro ao carregar números APAC: " & ex.Message)
        End Try
    End Sub
    Private Sub FormAMEOCINumAPAC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormAMEmain.loadComboBox("SELECT id, abrev FROM cod_oci_principal", cbOCI, "abrev", "id")
        FormAMEmain.loadComboBox("SELECT id, nome FROM usuarios ORDER BY nome", cbUsuarios, "nome", "id")
        FormAMEOCI.loadComp(cbSearchComp)
        ToolStripStatusLabel1.Text = ""
        FormAMEmain.loadComboBox("SELECT SUS AS id, nome FROM servidores WHERE SUS IS NOT NULL", cbMedico, "nome", "id")
        cbMedico.DisplayMember = "nome"
        cbMedico.ValueMember = "id"
        cbMedico.SelectedIndex = 0
        cbMedico.SelectedIndex = 0
        chkDisponiveis.Checked = False
        cbOCI.SelectedIndex = 0
        cbUsuarios.SelectedIndex = -1
        cbSearchComp.SelectedIndex = 0
        FormAMEOCI.LimparData()
        'FormAMEOCI.loadAllOCI(dgvNumerosAPAC)
    End Sub

    Private Sub loadByAPACinterval()
        dgvNumerosAPAC.DataSource = Nothing
        If tbAPACFim.Text.Length = 13 Then
            chkDisponiveis.Checked = False
            cbOCI.SelectedIndex = -1
            cbUsuarios.SelectedIndex = -1
            If tbAPACIni.Text.Length > 0 AndAlso tbAPACFim.Text.Length > 0 Then
                loadNUMAPAC(dgvNumerosAPAC, tbAPACIni.Text, tbAPACFim.Text, False,,,,,,, "oci.data_lanc DESC")
            End If
        End If

    End Sub

    Private Sub tbAPACFim_TextChanged(sender As Object, e As EventArgs) Handles tbAPACFim.TextChanged
        loadByAPACinterval()
    End Sub
    Private Sub tbAPACIni_TextChanged(sender As Object, e As EventArgs) Handles tbAPACIni.TextChanged
        loadByAPACinterval()
    End Sub

    Private Sub cbUsuarios_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbUsuarios.SelectionChangeCommitted
        dgvNumerosAPAC.DataSource = Nothing
        tbAPACIni.Text = ""
        tbAPACFim.Text = ""
        cbOCI.SelectedIndex = 0
        cbStatus.SelectedIndex = -1
        chkDisponiveis.Checked = False
        loadNUMAPAC(dgvNumerosAPAC,,,, iduser)
    End Sub
    Private Sub loadByData()
        dgvNumerosAPAC.DataSource = Nothing
        tbAPACIni.Text = ""
        tbAPACFim.Text = ""
        cbOCI.SelectedIndex = 0
        cbUsuarios.SelectedIndex = -1
        cbStatus.SelectedIndex = -1
        chkDisponiveis.Checked = False

        Dim oci As String = cbOCI.SelectedValue
        Dim medico As String = cbMedico.SelectedValue
        Dim comp As String = cbSearchComp.SelectedValue

        If oci > 0 Then
            oci = oci
        Else
            oci = ""
        End If

        If medico > 0 Then
            medico = medico
        Else
            medico = ""
        End If

        If cbSearchComp.SelectedValue > 0 Then
            comp = $"AND compet='{cbSearchComp.Text}'"
        Else
            comp = ""
        End If

        loadNUMAPAC(dgvNumerosAPAC,,,,, dtpIni.Value, dtpFim.Value, oci, , , "num_apac", comp, medico)
    End Sub
    Private Sub dtpIni_ValueChanged(sender As Object, e As EventArgs) Handles dtpIni.ValueChanged
        loadByData()
    End Sub
    Private Sub dtpFim_ValueChanged(sender As Object, e As EventArgs) Handles dtpFim.ValueChanged
        loadByData()
    End Sub

    Private Sub cbOCI_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbOCI.SelectionChangeCommitted
        dgvNumerosAPAC.DataSource = Nothing
        tbAPACIni.Text = ""
        tbAPACFim.Text = ""
        cbUsuarios.SelectedIndex = -1
        cbStatus.SelectedIndex = -1
        chkDisponiveis.Checked = False

        Dim oci As String = cbOCI.SelectedValue
        Dim medico As String = cbMedico.SelectedValue
        Dim comp As String = cbSearchComp.SelectedValue

        If oci > 0 Then
            oci = oci
        Else
            oci = ""
        End If

        If medico > 0 Then
            medico = medico
        Else
            medico = ""
        End If

        If cbSearchComp.SelectedValue > 0 Then
            comp = $"AND compet='{cbSearchComp.Text}'"
        Else
            comp = ""
        End If

        ' OCI ignora competência de propósito - mesmo que cbSearchComp tenha algo selecionado,
        ' não passamos esse filtro aqui.
        loadNUMAPAC(dgvNumerosAPAC,,, False,,,, oci, "CONC",,, comp, medico)
    End Sub

    Private Sub cbStatus_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbStatus.SelectionChangeCommitted
        dgvNumerosAPAC.DataSource = Nothing
        tbAPACIni.Text = ""
        tbAPACFim.Text = ""
        cbUsuarios.SelectedIndex = -1
        cbOCI.SelectedIndex = 0
        chkDisponiveis.Checked = False
        loadNUMAPAC(dgvNumerosAPAC,,,,,, , , CStr(cbStatus.SelectedItem))
    End Sub

    Private Sub AlterarStatusToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles AlterarStatusToolStripMenuItem.Click
        If dgvNumerosAPAC.SelectedRows.Count = 0 Then
            MsgBox("Selecione ao menos uma linha.")
            Exit Sub
        End If

        Using frm As New FormAMEOCIstatus
            If frm.ShowDialog() = DialogResult.OK Then
                Dim novoStatus As String = frm.StatusSelecionado
                If String.IsNullOrWhiteSpace(novoStatus) Then Exit Sub

                For Each row As DataGridViewRow In dgvNumerosAPAC.SelectedRows
                    Dim id As Integer = CInt(row.Cells("id").Value)
                    ' Ao mudar o status, o registro deixa de representar o lote
                    ' exportado atual e deve voltar a ser considerado pendente.
                    Dim sql As String = $"UPDATE oci SET status = '{novoStatus}', exportado = 0 WHERE id = {id}"
                    FormAMEmain.doQuery(sql)
                    row.Cells("status").Value = novoStatus
                Next
            End If
        End Using

        MsgBox("Status atualizado em " & dgvNumerosAPAC.SelectedRows.Count & " Números APAC.", MsgBoxStyle.Information)
    End Sub

    Private Sub CopiarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopiarToolStripMenuItem.Click

        If dgvNumerosAPAC.SelectedCells.Count = 0 Then
            MsgBox("Nenhuma célula selecionada.")
            Exit Sub
        End If

        Dim sb As New Text.StringBuilder()

        ' Percorre as linhas NA ORDEM VISUAL
        For Each row As DataGridViewRow In dgvNumerosAPAC.Rows
            ' Pega somente o que está selecionado na coluna 1
            Dim cell = row.Cells(1)
            If cell.Selected AndAlso cell.Value IsNot Nothing Then
                sb.AppendLine(cell.Value.ToString())
            End If
        Next

        Clipboard.SetText(sb.ToString())

        'If dgvNumerosAPAC.SelectedCells.Count = 0 Then
        '    MsgBox("Nenhuma célula selecionada.")
        '    Exit Sub
        'End If

        '' Descobre a coluna da primeira célula selecionada
        'Dim colIndex As Integer = dgvNumerosAPAC.SelectedCells(0).ColumnIndex
        'Dim sb As New Text.StringBuilder()

        '' Copia só as células da mesma coluna
        'For Each cell As DataGridViewCell In dgvNumerosAPAC.SelectedCells
        '    If cell.ColumnIndex = 1 Then
        '        sb.AppendLine(cell.Value.ToString())
        '    End If
        'Next

        ' Copia para área de transferência
        ' Clipboard.SetText(sb.ToString())
        ' MsgBox("Dados copiados da coluna '" & dgvNumerosAPAC.Columns(colIndex).HeaderText & "'.", MsgBoxStyle.Information)
    End Sub

    Private Sub dgvNumerosAPAC_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvNumerosAPAC.CellFormatting
        If dgvNumerosAPAC.Columns(e.ColumnIndex).Name = "status" AndAlso e.Value IsNot Nothing Then
            Dim valor As String = e.Value.ToString()

            Dim row As DataGridViewRow = dgvNumerosAPAC.Rows(e.RowIndex)

            Select Case valor
                'Case "DISP"
                '    row.DefaultCellStyle.BackColor = Color.LightGreen
                '    row.DefaultCellStyle.ForeColor = Color.DarkGreen

                'Case "CONC"
                '    row.DefaultCellStyle.BackColor = Color.SteelBlue
                '    row.DefaultCellStyle.ForeColor = Color.White

                'Case "CANC"
                '    row.DefaultCellStyle.BackColor = Color.DarkGray
                '    row.DefaultCellStyle.ForeColor = Color.White

                'Case "BLOQ"
                '    row.DefaultCellStyle.BackColor = Color.Maroon
                '    row.DefaultCellStyle.ForeColor = Color.White
            End Select
        End If
    End Sub

    Public Sub loadAPACAvailable()
        dgvNumerosAPAC.DataSource = Nothing
        chkDisponiveis.Checked = True
        loadNUMAPAC(dgvNumerosAPAC,,, True)
    End Sub


    Private Sub cbSearchComp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSearchComp.SelectedIndexChanged
        Dim comp As String = ""
        Dim oci As String = cbOCI.SelectedValue
        Dim medico As String = cbMedico.SelectedValue
        chkDisponiveis.Checked = False
        Try

            If cbSearchComp.SelectedValue > 0 Then
                comp = $"AND compet='{cbSearchComp.Text}'"
            Else
                comp = ""
            End If

            If oci > 0 Then
                oci = oci
            Else
                oci = ""
            End If

            If medico > 0 Then
                medico = medico
            Else
                medico = ""
            End If

            loadNUMAPAC(dgvNumerosAPAC,,, False,,,, oci, "CONC",,, comp, medico)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cbMedico_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMedico.SelectedIndexChanged
        Try
            Dim oci As String = cbOCI.SelectedValue
            Dim comp As String = ""
            Dim medico As String = If(cbMedico.SelectedValue Is Nothing OrElse cbMedico.SelectedValue Is DBNull.Value, "", cbMedico.SelectedValue.ToString)
            Dim dtini
            Dim dtfim

            chkDisponiveis.Checked = False

            If oci > 0 Then
                oci = oci
            Else
                oci = ""
            End If

            If cbSearchComp.SelectedValue > 0 Then
                comp = $"AND compet='{cbSearchComp.Text}'"
                dtini = Nothing
                dtfim = Nothing
            Else
                comp = ""
                dtini = dtpIni.Value
                dtfim = dtpFim.Value
            End If

            loadNUMAPAC(dgvNumerosAPAC,,, False,, dtini, dtfim, oci, "CONC",, "id DESC", comp, medico)
            ToolStripStatusLabel1.Text = dgvNumerosAPAC.RowCount & " Registros"
        Catch ex As Exception
            MsgBox("Erro ao filtrar por médico: " & ex.Message)
        End Try
    End Sub
    Private Sub ExcluirOCIToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExcluirOCIToolStripMenuItem.Click
        If FormAMEOCI.deleteOCI(dgvNumerosAPAC.SelectedRows(0).Cells(0).Value) Then
            FormAMEOCI.LimparData()
            FormAMEOCI.loadAllOCI(dgvNumerosAPAC)
        End If
    End Sub
    Private Sub dgvNumerosAPAC_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvNumerosAPAC.RowsAdded
        ToolStripStatusLabel1.Text = $"{dgvNumerosAPAC.Rows.Count} registros."
    End Sub
    Private Sub dgvNumerosAPAC_SelectionChanged(sender As Object, e As EventArgs) Handles dgvNumerosAPAC.SelectionChanged
        Dim qtdSelec = dgvNumerosAPAC.SelectedRows.Count.ToString
        If qtdSelec > 1 Then
            ToolStripStatusLabel1.Text = $"{qtdSelec} registros selecionados."
        Else
            ToolStripStatusLabel1.Text = $"{dgvNumerosAPAC.Rows.Count} registros."
        End If
    End Sub
    Private Sub btImprimirOCI_Click(sender As Object, e As EventArgs) Handles btImprimirOCI.Click
        ExportarParaAssinatura()
    End Sub

    Private Sub ExportarParaAssinatura()
        If dgvNumerosAPAC.RowCount = 0 Then
            MsgBox("Nenhum registro para exportar.")
            Exit Sub
        End If

        Dim oci As New OCI
        Dim quantidade As Integer = 0
        Dim pastaServidorBase As String = $"\\{My.Settings.server}\Gerenciador\AME\Impressos\OCI\Gerados"

        Try
            For Each row As DataGridViewRow In dgvNumerosAPAC.Rows
                If row.IsNewRow Then Continue For

                Dim medico As String = cbMedico.Text
                Dim dataOCI As Date = CDate(row.Cells(5).Value)
                Dim pastaServidor As String = Path.Combine(
                    pastaServidorBase,
                    NomeSeguroParaPasta(medico),
                    dataOCI.ToString("dd-MM-yyyy")
                )

                Directory.CreateDirectory(pastaServidor)

                Dim nomeArquivo As String = $"{row.Cells(0).Value}-{row.Cells(3).Value}.pdf"
                Dim pdfServidor As String = Path.Combine(pastaServidor, nomeArquivo)

                ' Gera diretamente no servidor. Não abre diálogo e não cria
                ' uma cópia local para o fluxo de assinatura.
                oci.printOCI(CInt(row.Cells(0).Value), pdfServidor)
                quantidade += 1
            Next

            m.msgAlert($"{quantidade} PDF(s) enviado(s) para assinatura digital.")
        Catch ex As Exception
            MsgBox("Não foi possível exportar os PDFs para assinatura:" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btImprimirDia_Click(sender As Object, e As EventArgs) Handles btImprimirDia.Click
        ExportarParaConferencia()
    End Sub

    Private Sub ExportarParaConferencia()
        If dgvNumerosAPAC.RowCount = 0 Then
            MsgBox("Nenhum registro para exportar.")
            Exit Sub
        End If

        SaveFileDialog1.Title = "Salvar PDF"
        SaveFileDialog1.FileName = $"{NomeSeguroParaPasta(cbMedico.Text)}_conferencia.pdf"

        If SaveFileDialog1.ShowDialog() <> DialogResult.OK Then
            Exit Sub
        End If

        Dim pdfDestino As String = SaveFileDialog1.FileName
        Dim pastaTemporaria As String = Path.Combine(
            Path.GetTempPath(),
            "OCI_Conferencia_" & Guid.NewGuid().ToString("N")
        )
        Dim arquivosTemporarios As New List(Of String)
        Dim oci As New OCI
        Dim quantidade As Integer = 0

        Try
            Directory.CreateDirectory(pastaTemporaria)

            For Each row As DataGridViewRow In dgvNumerosAPAC.Rows
                If row.IsNewRow Then Continue For

                Dim nomeArquivo As String = $"{row.Cells(0).Value}-{row.Cells(3).Value}.pdf"
                Dim pdfLocal As String = Path.Combine(pastaTemporaria, nomeArquivo)
                oci.printOCI(CInt(row.Cells(0).Value), pdfLocal)
                arquivosTemporarios.Add(pdfLocal)
                quantidade += 1
            Next

            If arquivosTemporarios.Count = 0 OrElse Not oci.UnirPDFs(arquivosTemporarios, pdfDestino) Then
                MsgBox("Não foi possível unir os PDFs para conferência.")
                Exit Sub
            End If

            If m.msgQuestion($"Deseja abrir o arquivo?", "Conferência") Then
                Process.Start(New ProcessStartInfo(pdfDestino) With {.UseShellExecute = True})
            End If
        Catch ex As Exception
            MsgBox("Não foi possível exportar os PDFs:" & vbCrLf & ex.Message)
        Finally
            If Directory.Exists(pastaTemporaria) Then
                Try
                    Directory.Delete(pastaTemporaria, True)
                Catch
                End Try
            End If
        End Try
    End Sub

    Private Sub CopiarPdfOCIParaServidor(pdfLocal As String, medico As String, dataOCI As Date)
        If Not File.Exists(pdfLocal) Then
            Exit Sub
        End If

        Try
            Dim pastaServidorBase As String = $"\\{My.Settings.server}\Gerenciador\AME\Impressos\OCI\Gerados"
            Dim nomeMedico As String = NomeSeguroParaPasta(medico)
            Dim pastaServidor As String = Path.Combine(
                pastaServidorBase,
                nomeMedico,
                dataOCI.ToString("dd-MM-yyyy")
            )

            If Not Directory.Exists(pastaServidor) Then
                Directory.CreateDirectory(pastaServidor)
            End If

            Dim pdfServidor As String = Path.Combine(pastaServidor, Path.GetFileName(pdfLocal))
            File.Copy(pdfLocal, pdfServidor, True)
        Catch ex As Exception
            Debug.Write("PDF local gerado, mas não foi possível copiar para o servidor:" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Function NomeSeguroParaPasta(nome As String) As String
        Dim resultado As String = If(nome, String.Empty).Trim()

        For Each caractere As Char In Path.GetInvalidFileNameChars()
            resultado = resultado.Replace(caractere, "_"c)
        Next

        If String.IsNullOrWhiteSpace(resultado) Then
            resultado = "Sem medico"
        End If

        Return resultado
    End Function

    Private Sub EditarOCIToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarOCIToolStripMenuItem.Click
        FormAMEOCI.editOCI(dgvNumerosAPAC.SelectedRows(0).Cells(0).Value)
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chkDisponiveis.CheckedChanged, chkDisponiveis.CheckedChanged
        If chkDisponiveis.Checked Then
            loadAPACAvailable()
        Else
            dgvNumerosAPAC.DataSource = Nothing
            gbSearch.Enabled = True
        End If
    End Sub

    Private Sub ExportarEmPDFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportarEmPDFToolStripMenuItem.Click
        If dgvNumerosAPAC.SelectedRows.Count = 0 Then
            MsgBox("Selecione uma OCI para exportar.")
            Exit Sub
        End If

        SaveFileDialog1.Title = "Salvar OCI para conferência"
        SaveFileDialog1.FileName = $"{dgvNumerosAPAC.SelectedRows(0).Cells(1).Value}-{dgvNumerosAPAC.SelectedRows(0).Cells(3).Value}.pdf"

        If SaveFileDialog1.ShowDialog() <> DialogResult.OK Then
            Exit Sub
        End If

        Try
            Dim oci As New OCI
            oci.printOCI(
                CInt(dgvNumerosAPAC.SelectedRows(0).Cells(0).Value),
                SaveFileDialog1.FileName
            )

            m.msgAlert("PDF individual salvo para conferência no computador.")
        Catch ex As Exception
            MsgBox("Não foi possível exportar o PDF individual:" & vbCrLf & ex.Message)
        End Try
    End Sub

End Class
