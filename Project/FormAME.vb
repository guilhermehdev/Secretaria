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
    Dim pdfPath As String = "E:\Desktop\mensal_abril.pdf"

    'Public Function GerarTabelaPorItens(texto As String, itensEspecificos() As String) As DataTable
    '    ' Dividir o texto em linhas
    '    Dim linhas() As String = texto.Split(New String() {Environment.NewLine}, StringSplitOptions.None)

    '    ' Criar um DataTable para armazenar os resultados
    '    Dim tabela As New DataTable()
    '    tabela.Columns.Add("Espec", GetType(String)) ' Coluna para o item encontrado
    '    Dim capturarEspecialidade As Boolean = False

    '    ' Percorrer cada linha do texto
    '    For Each linha As String In linhas
    '        linha = linha.Trim() ' Remover espaços em branco

    '        ' Verificar se a linha contém o item específico
    '        For Each item As String In itensEspecificos
    '            If linha.Contains(item) Then
    '                capturarEspecialidade = True ' Ativar captura nas próximas linhas
    '                Exit For ' Parar a verificação atual
    '            End If
    '        Next

    '        ' Capturar o nome da especialidade após o item encontrado
    '        ' Capturar apenas o nome da especialidade, ignorando códigos e outros detalhes
    '        If capturarEspecialidade AndAlso Not String.IsNullOrWhiteSpace(linha) Then
    '            If Not itensEspecificos.Any(Function(it) linha.Contains(it)) Then
    '                tabela.Rows.Add(linha) ' Adicionar ao DataTable apenas o nome da especialidade
    '                capturarEspecialidade = False ' Resetar captura após identificar a especialidade
    '            End If
    '        End If

    '    Next
    '    ' Retornar o DataTable com os resultados encontrados
    '    Return tabela
    'End Function

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
                    i += 2
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

    Private Function CorrigirLinha(linha As String) As List(Of String)
        Dim partes As New List(Of String)()

        ' Verifica se tem palavras coladas como "Especialidade2" ou "TotalCONSULTA"
        Dim match = Regex.Match(linha, "^([A-Za-z]+)(\d+)$")
        If match.Success Then
            partes.Add(match.Groups(1).Value)
            partes.Add(match.Groups(2).Value)
        Else
            ' Verifica colagem tipo "TotalCONSULTA" (duas palavras)
            match = Regex.Match(linha, "^([A-Za-z]+)([A-Za-z\-]+)$")
            If match.Success Then
                partes.Add(match.Groups(1).Value)
                partes.Add(match.Groups(2).Value)
            Else
                partes.Add(linha) ' Se não, mantém a linha
            End If
        End If

        Return partes
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'TextBox1.Text = pig.ExtrairDadosPDF()
        ' RichTextBox1.Text = pig.ExtrairDadosPDF()

        Dim consultasExtraidas As List(Of Consulta) = ExtrairConsultas()
        dgAME.DataSource = consultasExtraidas

    End Sub

    Private Sub FormAME_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Fstart.Visible = True
    End Sub

    Private Sub dgAME_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgAME.CellClick
        Dim m As New Main

        m.copyDatagridCellValue(dgAME, e)
    End Sub

End Class

Public Class Consulta
    Public Property Unidade As String
    Public Property Especialidade As String
    Public Property Profissional As String
    Public Property Total As Integer
    Public Property Demanda As Integer
    Public Property Disponibilizadas As Integer
    Public Property Livre As Integer
    Public Property PercentualFaltosos As Double
    Public Property Faltosos As Integer
    Public Property PercentualPresentes As Double
    Public Property Presentes As Integer
    Public Property Agendados As Integer
    Public Property TipoAtendimento As String
End Class