Imports System.IO
Imports System.Security.Cryptography
Imports System.Text.RegularExpressions
Imports ClosedXML.Excel
Imports System.Text
Imports System.Windows

Public Class FormAMEOCINumAPAC
    Dim m As New Main

    Public Sub substituirNumAPAC(caminhoArquivo As String)
        ' Dicionário de números errados → certos
        Dim mapa As New Dictionary(Of String, String) From {
            {"3525705636574", "3525706138724"},
            {"3525705636585", "3525706138735"},
            {"3525705636596", "3525706138746"},
            {"3525705636607", "3525706138757"},
            {"3525705636618", "3525706138768"},
            {"3525705636629", "3525706138779"},
            {"3525705636630", "3525706138780"},
            {"3525705636640", "3525706138790"},
            {"3525705636651", "3525706138801"},
            {"3525705636662", "3525706138812"},
            {"3525705636673", "3525706138823"},
            {"3525705636684", "3525706138834"},
            {"3525705636695", "3525706138845"},
            {"3525705636706", "3525706138856"},
            {"3525705636717", "3525706138867"},
            {"3525705636728", "3525706138878"},
            {"3525705636739", "3525706138889"},
            {"3525705636740", "3525706138890"},
            {"3525705636750", "3525706138900"},
            {"3525705636761", "3525706138911"},
            {"3525705636772", "3525706138922"},
            {"3525705636783", "3525706138933"},
            {"3525705636805", "3525706138944"},
            {"3525705636816", "3525706138955"},
            {"3525705636827", "3525706138966"},
            {"3525705636838", "3525706138977"},
            {"3525705636849", "3525706138988"},
            {"3525705636850", "3525706138999"},
            {"3525705636860", "3525706139000"},
            {"3525705636871", "3525706139010"},
            {"3525705636882", "3525706139021"},
            {"3525705636893", "3525706139032"},
            {"3525705636904", "3525706139043"},
            {"3525705636915", "3525706139054"},
            {"3525705636926", "3525706139065"},
            {"3525705636937", "3525706139076"},
            {"3525705636948", "3525706139087"},
            {"3525705636959", "3525706139098"},
            {"3525705636960", "3525706139109"},
            {"3525705636970", "3525706139110"},
            {"3525705636981", "3525706139120"},
            {"3525705636992", "3525706139131"},
            {"3525705637003", "3525706139142"},
            {"3525705637014", "3525706139153"},
            {"3525705637025", "3525706139164"},
            {"3525705637036", "3525706139175"},
            {"3525705637047", "3525706139186"},
            {"3525705637058", "3525706139197"},
            {"3525705637069", "3525706139208"},
            {"3525705637070", "3525706139219"},
            {"3525705637080", "3525706139220"},
            {"3525705637091", "3525706139230"},
            {"3525705637102", "3525706139241"}
        }

        ' --- 1. Lê o arquivo original em bytes (mantendo codificação ANSI) ---
        Dim conteudoBytes As Byte() = File.ReadAllBytes(caminhoArquivo)
        Dim conteudo As String = Encoding.Default.GetString(conteudoBytes)

        ' --- 2. Substitui literalmente, sem regex ---
        For Each par In mapa
            conteudo = conteudo.Replace(par.Key, par.Value)
        Next

        ' --- 3. Força CRLF em todas as quebras ---
        conteudo = conteudo.Replace(vbCrLf, vbLf) ' normaliza
        conteudo = conteudo.Replace(vbCr, vbLf)
        conteudo = conteudo.Replace(vbLf, vbCrLf)

        ' --- 4. Divide por linhas e checa comprimento ---
        Dim linhas = conteudo.Split({vbCrLf}, StringSplitOptions.None)
        Dim linhasComErro As New List(Of String)
        For i = 0 To linhas.Length - 1
            If linhas(i).Trim().Length > 0 AndAlso linhas(i).Length <> 533 Then
                linhasComErro.Add($"Linha {i + 1}: {linhas(i).Length} caracteres (esperado: 533)")
            End If
        Next

        ' --- 5. Salva novamente em ANSI (sem mudar tamanho) ---
        Dim novoCaminho As String = Path.Combine(
        Path.GetDirectoryName(caminhoArquivo),
        Path.GetFileNameWithoutExtension(caminhoArquivo) & "_corrigido" & Path.GetExtension(caminhoArquivo)
    )

        File.WriteAllText(novoCaminho, conteudo, Encoding.Default)

        ' --- 6. Relatório visual ---
        If linhasComErro.Count > 0 Then
            MsgBox("⚠️ Linhas desalinhadas detectadas:" & vbCrLf & String.Join(vbCrLf, linhasComErro))
        Else
            MsgBox($"✅ Arquivo corrigido com sucesso e validado: {novoCaminho}")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            substituirNumAPAC(OpenFileDialog1.FileName)
        End If
    End Sub

    Public Sub loadNUMAPAC(datagridview As DataGridView, Optional faixaIni As String = Nothing, Optional faixaFim As String = Nothing, Optional available As Boolean = False, Optional user As Integer = Nothing, Optional dtIni As Date = Nothing, Optional dtFim As Date = Nothing, Optional oci As String = "", Optional status As String = "", Optional dtlanc As Date = Nothing, Optional order As String = "id", Optional custom As String = "", Optional medico As String = "")
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
            If FormAMEOCI.dtpSearchData.CustomFormat <> "" Then
                where &= $" AND DATE(oci.data_lanc) ='{m.mysqlDateFormat(dtlanc)}' "
            End If
            If Not String.IsNullOrWhiteSpace(medico) Then
                where &= $" AND oci.id_medico ='{medico}' "
            End If

            Dim data = FormAMEmain.getDataset($"SELECT oci.id, oci.num_apac, cod_oci_principal.abrev AS oci, pacientes.nome, pacientes.dtnasc AS dtnasc, oci.`data`, oci.compet, servidores.nome AS medico, oci.status, usuarios.nome AS responsavel 
                FROM oci 
               LEFT JOIN pacientes ON pacientes.id = oci.id_paciente 
               LEFT JOIN servidores ON servidores.SUS = oci.id_medico
               LEFT JOIN cod_oci_principal ON cod_oci_principal.id = oci.id_cod_principal 
               LEFT JOIN usuarios ON usuarios.id = oci.id_usuario {where} {custom} ORDER BY {order}")

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
            datagridview.Columns("responsavel").HeaderText = "Responsável"
            datagridview.Columns("responsavel").Width = 150
            ToolStripStatusLabel1.Text = datagridview.Rows.Count & " registros encontrados."

        Catch ex As Exception
            MsgBox("Erro ao carregar números APAC: " & ex.Message)
        End Try
    End Sub

    Private Sub FormAMEOCINumAPAC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormAMEmain.loadComboBox("SELECT id, abrev FROM cod_oci_principal", cbOCI, "abrev", "id")
        FormAMEmain.loadComboBox("SELECT id, nome FROM usuarios ORDER BY nome", cbUsuarios, "nome", "id")
        FormAMEOCI.loadComp(cbSearchComp)
        ToolStripStatusLabel1.Text = ""
        FormAMEmain.loadComboBox("SELECT SUS AS id, nome AS medico FROM servidores WHERE SUS IS NOT NULL", cbMedico, "medico", "id", True)
        cbMedico.SelectedIndex = 0
        cbOCI.SelectedIndex = 0
        cbUsuarios.SelectedIndex = -1
        cbSearchComp.SelectedIndex = 0
        rbTodos.Checked = True
    End Sub

    Private Sub loadByAPACinterval()
        dgvNumerosAPAC.DataSource = Nothing
        If tbAPACFim.Text.Length = 13 Then
            chkDisponiveis.Checked = False
            cbOCI.SelectedIndex = -1
            cbUsuarios.SelectedIndex = -1
            If tbAPACIni.Text.Length > 0 AndAlso tbAPACFim.Text > 0 Then
                loadNUMAPAC(dgvNumerosAPAC, tbAPACIni.Text, tbAPACFim.Text)
            End If
        End If

    End Sub

    Private Sub tbAPACFim_TextChanged(sender As Object, e As EventArgs)
        loadByAPACinterval()
    End Sub
    Private Sub tbAPACIni_TextChanged(sender As Object, e As EventArgs)
        loadByAPACinterval()
    End Sub

    Private Sub cbUsuarios_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbUsuarios.SelectionChangeCommitted
        dgvNumerosAPAC.DataSource = Nothing
        tbAPACIni.Text = ""
        tbAPACFim.Text = ""
        cbOCI.SelectedIndex = 0
        cbStatus.SelectedIndex = -1
        chkDisponiveis.Checked = False
        loadNUMAPAC(dgvNumerosAPAC,,,, CInt(cbUsuarios.SelectedValue))
    End Sub
    Private Sub loadByData()
        dgvNumerosAPAC.DataSource = Nothing
        tbAPACIni.Text = ""
        tbAPACFim.Text = ""
        cbOCI.SelectedIndex = 0
        cbUsuarios.SelectedIndex = -1
        cbStatus.SelectedIndex = -1
        chkDisponiveis.Checked = False
        loadNUMAPAC(dgvNumerosAPAC,,,,, dtpIni.Value, dtpFim.Value,,)
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

        If rbTodos.Checked Then
            If cbSearchComp.SelectedValue > 0 Then
                loadNUMAPAC(dgvNumerosAPAC,,, False,,,, oci, "CONC",,, $"AND compet='{cbSearchComp.Text}'", medico)
            Else
                loadNUMAPAC(dgvNumerosAPAC,,, False,,,, oci, "CONC")
            End If
        Else
            loadNUMAPAC(dgvNumerosAPAC,,,,,, , CStr(cbOCI.SelectedValue))
        End If

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
                    Dim sql As String = $"UPDATE oci SET status = '{novoStatus}' WHERE id = {id}"
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
        gbSearch.Enabled = False
        loadNUMAPAC(dgvNumerosAPAC,,, True)
    End Sub
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles chkDisponiveis.CheckedChanged
        If chkDisponiveis.Checked Then
            loadAPACAvailable()
        Else
            dgvNumerosAPAC.DataSource = Nothing
            gbSearch.Enabled = True
        End If
    End Sub
    Private Sub rbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles rbTodos.CheckedChanged
        If rbTodos.Checked Then
            dgvNumerosAPAC.DataSource = Nothing
            tbAPACFim.Text = ""
            tbAPACIni.Text = ""
            cbOCI.SelectedIndex = 0
            cbUsuarios.SelectedIndex = -1
            cbStatus.SelectedIndex = -1
            chkDisponiveis.Checked = False
            cbSearchComp.SelectedIndex = 0
            loadNUMAPAC(dgvNumerosAPAC,,,,,,,, "CONC",, "num_apac")
        End If
    End Sub
    Private Sub cbSearchComp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSearchComp.SelectedIndexChanged
        If rbTodos.Checked Then

            Dim comp As String = ""
            Dim oci As String = cbOCI.SelectedValue
            Dim medico As String = cbMedico.SelectedValue

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
        Else
            dgvNumerosAPAC.DataSource = Nothing
        End If
    End Sub

    Private Sub GeradorNumeraçãoAPACToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeradorNumeraçãoAPACToolStripMenuItem.Click
        FormAMEOCIGeradorAPAC.ShowDialog()
    End Sub
    Private Sub cbMedico_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMedico.SelectedIndexChanged
        Dim oci As String = cbOCI.SelectedValue
        Dim comp As String = ""
        Dim medico As String = cbMedico.SelectedValue.ToString

        If rbTodos.Checked Then

            If oci > 0 Then
                oci = oci
            Else
                oci = ""
            End If

            If cbSearchComp.SelectedValue > 0 Then
                comp = $"AND compet='{cbSearchComp.Text}'"
            Else
                comp = ""
            End If

            If medico > 0 Then
                medico = medico
            Else
                medico = ""
            End If

            loadNUMAPAC(dgvNumerosAPAC,,, False,,,, oci, "CONC",,, comp, medico)
        Else
            loadNUMAPAC(dgvNumerosAPAC,,, False,,,,, "CONC",,,, medico)
        End If
    End Sub


End Class