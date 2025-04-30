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
        sfd.Title = "Salvar Relatório Formato Abril"

        If sfd.ShowDialog() = DialogResult.OK Then
            ExportarDataTableResumoAbril(tabelaConsultasFiltradas, sfd.FileName, "Abril")
        End If
    End Sub

    Private Sub ExportarDataTableResumoAbril(tabela As DataTable, caminho As String, SheetName As String)
        Dim excelApp As Object = CreateObject("Excel.Application")
        excelApp.DisplayAlerts = False

        Dim workbook = excelApp.Workbooks.Add()
        Dim worksheet = workbook.Sheets(1)
        worksheet.Name = SheetName

        ' Tipos desejados
        Dim tipoConsulta = "CONSULTA SUBSEQUENTE-RETORNO"
        Dim tipoRegulacao = "REGULAÇÃO"

        ' Agrupar por Especialidade + Profissional
        Dim grupos = tabela.AsEnumerable().
        Where(Function(r) r("TipoAtendimento").ToString() = tipoConsulta OrElse r("TipoAtendimento").ToString() = tipoRegulacao).
        GroupBy(Function(r) New With {
            Key .Especialidade = r("Especialidade").ToString(),
            Key .Profissional = r("Profissional").ToString()
        }).ToList()


        ' Cabeçalhos
        worksheet.Cells(1, 1).Value = "ESPECIALIDADE"
        worksheet.Cells(1, 1).FONT.Bold = True
        worksheet.Cells(1, 2).Value = "PROFISSIONAL"
        worksheet.Cells(1, 2).FONT.Bold = True
        worksheet.Cells(1, 3).Value = $"RETORNO"
        worksheet.Cells(1, 3).FONT.Bold = True
        worksheet.Cells(1, 4).Value = $"1ª CONSULTA"
        worksheet.Cells(1, 4).FONT.Bold = True
        worksheet.Cells(1, 5).Value = "DISPONIVEL"
        worksheet.Cells(1, 5).FONT.Bold = True
        worksheet.Cells(1, 6).Value = "FATURADO"
        worksheet.Cells(1, 6).FONT.Bold = True
        worksheet.Cells(1, 7).Value = "FALTAS"
        worksheet.Cells(1, 7).FONT.Bold = True
        worksheet.Cells(1, 8).Value = "% FALTAS"
        worksheet.Cells(1, 8).FONT.Bold = True

        worksheet.Rows("1:1").Font.Bold = True
        worksheet.Rows("1:1").Interior.Color = RGB(79, 129, 189)
        worksheet.Rows("1:1").Font.Color = RGB(255, 255, 255)
        worksheet.Rows("1:1").Font.Size = 9
        ' Preencher dados com fórmulas
        Dim linha = 2
        For Each grupo In grupos
            Dim disponibilizadasConsulta = grupo.
            Where(Function(r) r("TipoAtendimento").ToString() = tipoConsulta).
            Sum(Function(r) Convert.ToInt32(r("Disponibilizadas")))

            Dim disponibilizadasRegulacao = grupo.
            Where(Function(r) r("TipoAtendimento").ToString() = tipoRegulacao).
            Sum(Function(r) Convert.ToInt32(r("Disponibilizadas")))

            ' Dim presentes = grupo.Sum(Function(r) Convert.ToInt32(r("Presentes")))
            Dim presentes = 0

            worksheet.Cells(linha, 1).Value = grupo.Key.Especialidade
            worksheet.Cells(linha, 1).FONT.Bold = True
            worksheet.Cells(linha, 2).Value = grupo.Key.Profissional
            ' worksheet.Cells(linha, 2).FONT.Bold = True
            worksheet.Cells(linha, 3).Value = disponibilizadasConsulta
            'worksheet.Cells(linha, 3).FONT.Bold = True
            worksheet.Cells(linha, 4).Value = disponibilizadasRegulacao
            'worksheet.Cells(linha, 4).FONT.Bold = True

            ' Fórmulas: DISPONIBILIZADAS (E), FALTOSOS (G), % FALTOSOS (H)
            worksheet.Cells(linha, 5).Formula = $"=C{linha}+D{linha}"
            'worksheet.Cells(linha, 5).FONT.Bold = True
            worksheet.Cells(linha, 6).Value = presentes
            'worksheet.Cells(linha, 6).FONT.Bold = True
            worksheet.Cells(linha, 7).Formula = $"=E{linha}-F{linha}"
            'worksheet.Cells(linha, 7).FONT.Bold = True
            worksheet.Cells(linha, 8).Formula = $"=IF(E{linha}=0,0,G{linha}/E{linha})"
            'worksheet.Cells(linha, 8).FONT.Bold = True
            worksheet.Cells(linha, 8).NumberFormat = "0.00%"

            linha += 1
        Next

        ' Linha de total geral
        Dim linhaTotal As Integer = linha
        worksheet.Cells(linhaTotal, 1).Value = "TOTAL GERAL"
        worksheet.Cells(linhaTotal, 1).Font.Bold = True

        ' Soma de colunas 3 a 7
        For col = 3 To 7
            Dim colLetra = GetExcelColumnName(col)
            worksheet.Cells(linhaTotal, col).Formula = $"=SUM({colLetra}2:{colLetra}{linha - 1})"
            worksheet.Cells(linhaTotal, col).Font.Bold = True
        Next

        ' % Faltosos total com fórmula
        worksheet.Cells(linhaTotal, 8).Formula = $"=IF(E{linhaTotal}=0,0,G{linhaTotal}/E{linhaTotal})"
        worksheet.Cells(linhaTotal, 8).NumberFormat = "0.00%"
        worksheet.Cells(linhaTotal, 8).Font.Bold = True

        Dim celulasTotais = worksheet.Range($"A{linhaTotal}:B{linhaTotal}")
        celulasTotais.Merge()
        celulasTotais.Value = "TOTAL GERAL"
        celulasTotais.Font.Bold = True

        Dim especCardio = worksheet.Range($"A2:A3")
        especCardio.Merge()
        especCardio.Value = "CARDIOLOGIA"
        especCardio.Font.Bold = True
        especCardio.VerticalAlignment = -4108

        Dim especOfta = worksheet.Range($"A13:A14")
        especOfta.Merge()
        especOfta.Value = "OFTALMOLOGIA"
        especOfta.Font.Bold = True
        especOfta.VerticalAlignment = -4108

        Dim especOrto = worksheet.Range($"A15:A16")
        especOrto.Merge()
        especOrto.Value = "ORTOPEDIA"
        especOrto.Font.Bold = True
        especOrto.VerticalAlignment = -4108

        Dim especOtorrino = worksheet.Range($"A17:A18")
        especOtorrino.Merge()
        especOtorrino.Value = "OTORRINOLARINGOLOGIA"
        especOtorrino.Font.Bold = True
        especOtorrino.VerticalAlignment = -4108

        Dim especUsg = worksheet.Range($"A20:A23")
        especUsg.Merge()
        especUsg.Value = "ULTRASSONOGRAFIA"
        especUsg.Font.Bold = True
        especUsg.VerticalAlignment = -4108

        ' Congelar, ajustar
        worksheet.Range("A2").Select()
        excelApp.ActiveWindow.FreezePanes = True
        worksheet.Columns.AutoFit()

        ' Gráficos por Especialidade + Profissional
        'Dim chartTop As Integer = (linhaTotal + 2) * 15 ' posição inicial (pode ajustar)
        'For linhaGrafico As Integer = 2 To linhaTotal - 1
        '    Dim categoriaRange As String = $"E1:G1"
        '    Dim valorRange As String = $"E{linhaGrafico}:G{linhaGrafico}"
        '    Dim dadosGraficoRange As String = $"E{linhaGrafico - 1}:G{linhaGrafico}" ' inclui categorias + valores

        '    Dim chartObjects = worksheet.ChartObjects()
        '    Dim chartObject = chartObjects.Add(300, chartTop, 400, 200)
        '    Dim chart = chartObject.Chart
        '    chart.ChartType = 51 ' xlColumnClustered

        '    ' Usa a faixa de categorias + valores
        '    chart.SetSourceData(worksheet.Range(dadosGraficoRange))

        '    ' Título automático
        '    Dim nomeProfissional = worksheet.Cells(linhaGrafico, 2).Value
        '    Dim especialidade = worksheet.Cells(linhaGrafico, 1).Value
        '    chart.HasTitle = True
        '    chart.ChartTitle.Text = $"{especialidade} - {nomeProfissional}"

        '    chartTop += 220

        'Next


        'Dim chartObjects = worksheet.ChartObjects()
        'Dim chartObject = chartObjects.Add(300, 10, 500, 300) ' (x, y, largura, altura)
        'Dim chart = chartObject.Chart

        'chart.ChartType = 51 ' xlColumnClustered
        'chart.SetSourceData(worksheet.Range($"C{linhaTotal}:G{linhaTotal}"))
        'chart.HasTitle = True
        'chart.ChartTitle.Text = "Totais por Métrica"
        ' Determina o intervalo de células com conteúdo
        Dim ultimaLinha As Integer = worksheet.Cells(worksheet.Rows.Count, 1).End(-4162).Row ' xlUp
        Dim ultimaColuna As Integer = worksheet.Cells(1, worksheet.Columns.Count).End(-4159).Column ' xlToLeft

        ' Intervalo de células preenchidas
        Dim intervalo As Object = worksheet.Range(worksheet.Cells(1, 1), worksheet.Cells(ultimaLinha, ultimaColuna))

        ' Aplicar bordas no intervalo
        ComBorda(intervalo)

        worksheet.Columns("C:H").ColumnWidth = 10

        workbook.SaveAs(caminho)
        workbook.Close(False)
        excelApp.Quit()

        MsgBox("Relatório exportado com sucesso!", MsgBoxStyle.Information)
    End Sub
    Private Sub ComBorda(intervalo As Object)
        intervalo.Borders.Item(1).LineStyle = 1 ' Borda superior
        intervalo.Borders.Item(2).LineStyle = 1 ' Borda inferior
        intervalo.Borders.Item(3).LineStyle = 1 ' Borda esquerda
        intervalo.Borders.Item(4).LineStyle = 1 ' Borda direita
        intervalo.Borders.Item(5).LineStyle = 0 ' Bordas diagonais (não usadas)
        intervalo.Borders.Item(6).LineStyle = 0 ' Bordas diagonais (não usadas)
    End Sub

    Private Function GetExcelColumnName(colIndex As Integer) As String
        Dim dividend As Integer = colIndex
        Dim columnName As String = String.Empty
        Dim modulo As Integer

        While dividend > 0
            modulo = (dividend - 1) Mod 26
            columnName = Chr(65 + modulo) & columnName
            dividend = (dividend - modulo) \ 26
        End While

        Return columnName
    End Function


    Private Sub ExportarEXCEL(tabela As DataTable, caminho As String, SheetName As String)
        Dim excelApp As Object = CreateObject("Excel.Application")
        Dim workbook = excelApp.Workbooks.Add()
        Dim worksheet = workbook.Sheets(1)
        worksheet.Name = SheetName

        ' Obter todos os tipos de atendimento únicos
        ' Apenas tipos de atendimento permitidos
        Dim tiposPermitidos = New List(Of String) From {
    "CONSULTA SUBSEQUENTE-RETORNO",
    "REGULAÇÃO"
}

        ' Obter tipos existentes filtrando os permitidos
        Dim tiposAtendimento = tabela.DefaultView.ToTable(True, "TipoAtendimento") _
    .AsEnumerable().
    Select(Function(r) r(0).ToString()).
    Where(Function(t) tiposPermitidos.Contains(t)).
    Distinct().
    ToList()


        ' Estrutura da tabela pivotada em memória
        Dim linhasAgrupadas = tabela.AsEnumerable().
        GroupBy(Function(r) New With {
            Key .Especialidade = r("Especialidade").ToString(),
            Key .Profissional = r("Profissional").ToString()
        }).ToList()

        ' Cabeçalhos fixos
        worksheet.Cells(1, 1).Value = "ESPECIALIDADE"
        worksheet.Cells(1, 2).Value = "PROFISSIONAL"

        Dim colIndex As Integer = 3
        For Each tipo In tiposAtendimento
            worksheet.Cells(1, colIndex).Value = tipo & " - DISPONIBILIZADAS"
            worksheet.Cells(1, colIndex + 1).Value = tipo & " - PRESENTES"
            worksheet.Cells(1, colIndex + 2).Value = tipo & " - FALTOSOS"
            worksheet.Cells(1, colIndex + 3).Value = tipo & " - % FALTOSOS"
            colIndex += 4
        Next

        ' Preencher os dados
        Dim linhaExcel As Integer = 2
        For Each grupo In linhasAgrupadas
            worksheet.Cells(linhaExcel, 1).Value = grupo.Key.Especialidade
            worksheet.Cells(linhaExcel, 2).Value = grupo.Key.Profissional

            colIndex = 3
            For Each tipo In tiposAtendimento
                Dim linhaTipo = grupo.FirstOrDefault(Function(r) r("TipoAtendimento").ToString() = tipo)

                If linhaTipo IsNot Nothing Then
                    worksheet.Cells(linhaExcel, colIndex).Value = linhaTipo("Disponibilizadas")
                    worksheet.Cells(linhaExcel, colIndex + 1).Value = linhaTipo("Presentes")
                    worksheet.Cells(linhaExcel, colIndex + 2).Value = linhaTipo("Faltosos")
                    worksheet.Cells(linhaExcel, colIndex + 3).Value = Math.Round(Convert.ToDouble(linhaTipo("PercentualFaltosos")), 2) / 100.0
                    worksheet.Cells(linhaExcel, colIndex + 3).NumberFormat = "0.00%"
                Else
                    worksheet.Cells(linhaExcel, colIndex).Value = 0
                    worksheet.Cells(linhaExcel, colIndex + 1).Value = 0
                    worksheet.Cells(linhaExcel, colIndex + 2).Value = 0
                    worksheet.Cells(linhaExcel, colIndex + 3).Value = 0
                    worksheet.Cells(linhaExcel, colIndex + 3).NumberFormat = "0.00%"
                End If

                colIndex += 4
            Next

            linhaExcel += 1
        Next

        ' Congelar cabeçalhos e aplicar estilo
        worksheet.Range("A2").Select()
        excelApp.ActiveWindow.FreezePanes = True

        worksheet.Rows("1:1").Font.Bold = True
        worksheet.Rows("1:1").Interior.Color = RGB(79, 129, 189)
        worksheet.Rows("1:1").Font.Color = RGB(255, 255, 255)

        ' Autoajustar colunas
        worksheet.Columns.AutoFit()

        ' Salvar
        workbook.SaveAs(caminho)
        workbook.Close(False)
        excelApp.Quit()

        MsgBox("Arquivo Excel exportado com sucesso!", MsgBoxStyle.Information)
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