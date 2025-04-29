Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.parser
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json
Imports System.Collections.Generic
Imports System.Data
Imports System.Text


Public Class FormAME
    Dim pdf As New PDF
    Dim pig As New PDFPig
    Dim pdfPath As String = "D:\Desktop\mensal_abril.pdf"
    Private tabelaConsultas As DataTable
    Private tabelaConsultasFiltradas As DataTable
    Public Function ExtrairConsultas() As List(Of Consulta)
        Dim consultas As New List(Of Consulta)()

        Dim textoFormatado As String = pig.ExtrairDadosPDF()
        Dim linhas() As String = textoFormatado.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)

        Dim especialidadeAtual As String = ""
        Dim profissionalAtual As String = ""
        Dim tipoAtendimentoAtual As String = ""

        Dim i As Integer = 0
        While i < linhas.Length
            Dim linha = linhas(i).Trim()

            If linha = "Especialidade" Then
                If i + 2 < linhas.Length Then
                    especialidadeAtual = linhas(i + 2).Trim()
                    Dim j = i + 3
                    While j < linhas.Length AndAlso Not linhas(j).StartsWith("Profissional") AndAlso Not IsNumeric(linhas(j))
                        ' Verificar se é uma data ou hora
                        If Regex.IsMatch(linhas(j), "^\d{2}/\d{2}/\d{4}") OrElse Regex.IsMatch(linhas(j), "^\d{2}:\d{2}:\d{2}") Then
                            Exit While
                        End If

                        especialidadeAtual &= " " & linhas(j).Trim()
                        j += 1
                    End While
                    especialidadeAtual = especialidadeAtual.Trim()
                    i = j - 1
                End If

            ElseIf linha = "Profissional" Then
                If i + 2 < linhas.Length Then
                    profissionalAtual = linhas(i + 2).Trim()
                    Dim j = i + 3
                    While j < linhas.Length AndAlso linhas(j) <> "Tipo" AndAlso linhas(j) <> "Tipo de Atendimento"
                        profissionalAtual &= " " & linhas(j).Trim()
                        j += 1
                    End While
                    i = j - 1
                End If

            ElseIf linha = "CONSULTA" OrElse linha = "NÃO" OrElse linha = "REGULAÇÃO" OrElse linha = "RESERVA" OrElse linha = "PROTESE" OrElse linha = "TESTE" Then
                tipoAtendimentoAtual = linha
                i += 1

                While i < linhas.Length AndAlso Not IsNumeric(linhas(i))
                    tipoAtendimentoAtual &= " " & linhas(i)
                    i += 1
                End While

                ' Agora ler os dados
                If i + 8 < linhas.Length Then
                    Dim agendados, presentes, faltosos, livre, disponibilizadas, demanda, total As Integer
                    Dim percentualPresente, percentualFaltoso As Double

                    Integer.TryParse(linhas(i), agendados)
                    Integer.TryParse(linhas(i + 1), presentes)
                    Double.TryParse(linhas(i + 2).Replace(",", "."), Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, percentualPresente)
                    Integer.TryParse(linhas(i + 3), faltosos)
                    Double.TryParse(linhas(i + 4).Replace(",", "."), Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, percentualFaltoso)
                    Integer.TryParse(linhas(i + 5), livre)
                    Integer.TryParse(linhas(i + 6), disponibilizadas)
                    Integer.TryParse(linhas(i + 7), demanda)
                    Integer.TryParse(linhas(i + 8), total)

                    Dim consulta As New Consulta With {
                     .Especialidade = especialidadeAtual,
                    .Profissional = profissionalAtual,
                    .TipoAtendimento = tipoAtendimentoAtual,
                    .Agendados = agendados,
                    .Presentes = presentes,
                    .PercentualPresentes = percentualPresente,
                    .Faltosos = faltosos,
                    .PercentualFaltosos = percentualFaltoso,
                    .Livre = livre,
                    .Disponibilizadas = disponibilizadas,
                    .Demanda = demanda,
                    .Total = total
                }

                    consultas.Add(consulta)

                    i += 8
                End If
            End If

            i += 1
        End While

        Return consultas
    End Function

    Public Function ListToDataTable(lista As List(Of Consulta)) As DataTable
        Dim tabela As New DataTable()

        tabela.Columns.Add("Especialidade", GetType(String))
        tabela.Columns.Add("Profissional", GetType(String))
        tabela.Columns.Add("TipoAtendimento", GetType(String))
        tabela.Columns.Add("Agendados", GetType(Integer))
        tabela.Columns.Add("Presentes", GetType(Integer))
        tabela.Columns.Add("PercentualPresentes", GetType(Double)) ' já como 0.6338 para exibir 63,38%
        tabela.Columns.Add("Faltosos", GetType(Integer))
        tabela.Columns.Add("PercentualFaltosos", GetType(Double)) ' idem
        tabela.Columns.Add("Livre", GetType(Integer))
        tabela.Columns.Add("Disponibilizadas", GetType(Integer))
        tabela.Columns.Add("Demanda", GetType(Integer))
        tabela.Columns.Add("Total", GetType(Integer))

        For Each item In lista
            tabela.Rows.Add(item.Especialidade,
                        item.Profissional,
                        item.TipoAtendimento,
                        item.Agendados,
                        item.Presentes,
                        item.PercentualPresentes / 100.0, ' 💡 aqui o segredo
                        item.Faltosos,
                        item.PercentualFaltosos / 100.0, ' 💡 idem
                        item.Livre,
                        item.Disponibilizadas,
                        item.Demanda,
                        item.Total)
        Next

        Return tabela
    End Function


    Private Sub CarregarConsultas()
        Dim consultasExtraidas As List(Of Consulta) = ExtrairConsultas()

        Dim consultasOrdenadas = consultasExtraidas _
        .OrderBy(Function(c) c.Especialidade) _
        .ThenBy(Function(c) c.Profissional) _
        .ThenBy(Function(c)
                    If c.TipoAtendimento.StartsWith("CONSULTA SUBSEQUENTE-RETORNO") Then
                        Return 1
                    ElseIf c.TipoAtendimento.StartsWith("REGULAÇÃO") Then
                        Return 2
                    Else
                        Return 3
                    End If
                End Function) _
        .ThenBy(Function(c) c.TipoAtendimento) _
        .ToList()

        tabelaConsultas = ListToDataTable(consultasOrdenadas)
        tabelaConsultasFiltradas = tabelaConsultas.Copy()

        dgAME.DataSource = tabelaConsultasFiltradas

        dgAME.Columns("Especialidade").Width = 180
        dgAME.Columns("Especialidade").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgAME.Columns("Profissional").Width = 220
        dgAME.Columns("Profissional").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgAME.Columns("TipoAtendimento").HeaderText = "Tipo de Atendimento"
        dgAME.Columns("TipoAtendimento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgAME.Columns("TipoAtendimento").Width = 210
        dgAME.Columns("PercentualPresentes").HeaderText = "% Pres"
        dgAME.Columns("PercentualPresentes").Width = 45
        dgAME.Columns("PercentualFaltosos").HeaderText = "% Faltas"
        dgAME.Columns("PercentualFaltosos").Width = 45
        dgAME.Columns("PercentualPresentes").DefaultCellStyle.Format = "P2"
        dgAME.Columns("PercentualFaltosos").DefaultCellStyle.Format = "P2"
        dgAME.Columns("Agendados").DefaultCellStyle.Format = "N0"
        dgAME.Columns("Agendados").HeaderText = "Agend"
        dgAME.Columns("Presentes").DefaultCellStyle.Format = "N0"
        dgAME.Columns("Presentes").HeaderText = "Pres"
        dgAME.Columns("Faltosos").DefaultCellStyle.Format = "N0"
        dgAME.Columns("Faltosos").HeaderText = "Faltas"
        dgAME.Columns("Livre").DefaultCellStyle.Format = "N0"

        dgAME.Columns("Demanda").DefaultCellStyle.Format = "N0"
        dgAME.Columns("Demanda").HeaderText = "Dem"
        dgAME.Columns("Total").DefaultCellStyle.Format = "N0"
        dgAME.Columns("Agendados").Width = 40
        dgAME.Columns("Presentes").Width = 40
        dgAME.Columns("Faltosos").Width = 40
        dgAME.Columns("Livre").Width = 40
        dgAME.Columns("Disponibilizadas").DefaultCellStyle.Format = "N0"
        dgAME.Columns("Disponibilizadas").Width = 40
        dgAME.Columns("Disponibilizadas").HeaderText = "Disp"
        dgAME.Columns("Demanda").Width = 40
        dgAME.Columns("Total").Width = 40


        ' Carregar os filtros
        CarregarFiltros()
    End Sub

    Private Sub CarregarFiltros()
        ComboBoxEspecialidade.Items.Clear()
        ComboBoxEspecialidade.Items.Add("TODOS")
        ComboBoxEspecialidade.Items.AddRange(tabelaConsultas.DefaultView.ToTable(True, "Especialidade").AsEnumerable().Select(Function(r) r(0).ToString()).ToArray())

        ComboBoxProfissional.Items.Clear()
        ComboBoxProfissional.Items.Add("TODOS")
        ComboBoxProfissional.Items.AddRange(tabelaConsultas.DefaultView.ToTable(True, "Profissional").AsEnumerable().Select(Function(r) r(0).ToString()).ToArray())

        ComboBoxEspecialidade.SelectedIndex = 0
        ComboBoxProfissional.SelectedIndex = 0
    End Sub

    Private Sub FormAME_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Fstart.Visible = True
    End Sub

    Private Sub dgAME_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgAME.CellClick
        Dim m As New Main

        m.copyDatagridCellValue(dgAME, e)
    End Sub

    Private Sub ButtonFiltrar_Click(sender As Object, e As EventArgs) Handles ButtonFiltrar.Click
        Dim filtro As String = ""

        If ComboBoxEspecialidade.SelectedIndex > 0 Then
            filtro &= $"Especialidade = '{ComboBoxEspecialidade.SelectedItem}'"
        End If

        If ComboBoxProfissional.SelectedIndex > 0 Then
            If filtro <> "" Then filtro &= " AND "
            filtro &= $"Profissional = '{ComboBoxProfissional.SelectedItem}'"
        End If

        Dim view As New DataView(tabelaConsultas)
        view.RowFilter = filtro

        tabelaConsultasFiltradas = view.ToTable()
        dgAME.DataSource = tabelaConsultasFiltradas
        AtualizarTotais()
        ' Atualizar totais
    End Sub

    Private Sub AtualizarTotais()
        Dim agendados = tabelaConsultasFiltradas.AsEnumerable().Sum(Function(r) Convert.ToInt32(r("Agendados")))
        Dim presentes = tabelaConsultasFiltradas.AsEnumerable().Sum(Function(r) Convert.ToInt32(r("Presentes")))
        Dim faltosos = tabelaConsultasFiltradas.AsEnumerable().Sum(Function(r) Convert.ToInt32(r("Faltosos")))

        LabelTotais.Text = $"Agendados: {agendados} | Presentes: {presentes} | Faltosos: {faltosos}"
    End Sub

    Private Sub ButtonExportarExcel_Click(sender As Object, e As EventArgs) Handles ButtonExportarExcel.Click
        Dim sfd As New SaveFileDialog()
        sfd.Filter = "Excel Files|*.xlsx"
        sfd.Title = "Salvar Arquivo Excel"

        If sfd.ShowDialog() = DialogResult.OK Then
            ExportarDataTableParaExcel(tabelaConsultasFiltradas, sfd.FileName)
            MessageBox.Show("Arquivo Excel exportado com sucesso!")
        End If
    End Sub

    Private Sub ExportarDataTableParaExcel(tabela As DataTable, caminho As String)
        Dim excelApp As Object = CreateObject("Excel.Application")
        Dim workbook = excelApp.Workbooks.Add()
        Dim worksheet = workbook.Sheets(1)

        ' Cabeçalhos
        For i As Integer = 0 To tabela.Columns.Count - 1
            worksheet.Cells(1, i + 1).Value = tabela.Columns(i).ColumnName
        Next

        ' Dados
        For i As Integer = 0 To tabela.Rows.Count - 1
            For j As Integer = 0 To tabela.Columns.Count - 1
                worksheet.Cells(i + 2, j + 1).Value = tabela.Rows(i)(j)
            Next
        Next

        workbook.SaveAs(caminho)
        workbook.Close()
        excelApp.Quit()
    End Sub

    Private Sub FormAME_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregarConsultas()
    End Sub
End Class

Public Class Consulta
    ' Public Property Unidade As String

    Public Property Especialidade As String
    Public Property Profissional As String
    Public Property TipoAtendimento As String
    Public Property Disponibilizadas As Integer
    Public Property Faltosos As Integer
    Public Property PercentualFaltosos As Double
    Public Property Demanda As Integer
    Public Property Total As Integer
    Public Property Agendados As Integer
    Public Property Livre As Integer
    Public Property PercentualPresentes As Double
    Public Property Presentes As Integer


End Class