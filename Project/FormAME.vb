Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.parser
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json
Imports System.Collections.Generic
Imports System.Data


Public Class FormAME
    Dim pdf As New PDF
    Dim pdfPath As String = "D:\Desktop\mensal_abril.pdf"

    Function getMonthlyData(ByVal caminhoPDF As String) As Dictionary(Of String, HashSet(Of String))
        Dim linhasPorEspecialidade As New Dictionary(Of String, HashSet(Of String))()
        Dim regexIgnorarTrecho As New Regex("44 - PREFEITURA MUNICIPAL DE PERUIBE.*?Página", RegexOptions.Singleline Or RegexOptions.IgnoreCase)

        ' Expressões regulares para remover valores dinâmicos
        Dim regexDataHora As New Regex("\d{2}/\d{2}/\d{4} - \d{2}:\d{2}:\d{2}")
        Dim regexPagina As New Regex("Página \d+/\d+")

        ' HashSet global para evitar duplicações
        Dim linhasProcessadas As New HashSet(Of String)()
        Dim paginasProcessadas As New HashSet(Of Integer)() ' Para garantir que cada página seja processada apenas uma vez

        Try
            Using reader As New PdfReader(caminhoPDF)
                For i As Integer = 1 To reader.NumberOfPages
                    ' Verifica se a página já foi processada
                    If paginasProcessadas.Contains(i) Then Continue For
                    paginasProcessadas.Add(i)

                    Dim textoPagina As String = PdfTextExtractor.GetTextFromPage(reader, i)

                    ' Substituir caracteres de quebra de linha específicos do PDF por Environment.NewLine
                    textoPagina = textoPagina.Replace(vbLf, Environment.NewLine).Replace(vbCr, Environment.NewLine)

                    textoPagina = regexIgnorarTrecho.Replace(textoPagina, "Página")
                    textoPagina = regexDataHora.Replace(textoPagina, "")
                    textoPagina = regexPagina.Replace(textoPagina, "")

                    ' Agora dividir o texto da página em linhas
                    Dim linhasPagina As String() = textoPagina.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)

                    Dim especialidadeAtual As String = ""

                    For Each linha In linhasPagina
                        linha = linha.Trim()

                        If linhasProcessadas.Contains(linha) Then Continue For
                        linhasProcessadas.Add(linha)

                        ' Se a linha contém uma especialidade, atualiza a variável
                        If linha.Contains("Especialidade") Then
                            especialidadeAtual = linha.Replace("Especialidade", "").Trim()
                            If Not linhasPorEspecialidade.ContainsKey(especialidadeAtual) Then
                                linhasPorEspecialidade(especialidadeAtual) = New HashSet(Of String)()
                            End If
                        End If

                        ' Adiciona apenas linhas relevantes e evita duplicação
                        If Not String.IsNullOrEmpty(especialidadeAtual) AndAlso (linha.Contains("Profissional") OrElse linha.Contains("Tipo de Atendimento")) Then
                            linhasPorEspecialidade(especialidadeAtual).Add(linha)
                        End If

                        Console.WriteLine(linha)
                    Next
                Next
            End Using
        Catch ex As Exception
            Console.WriteLine("Erro ao processar o PDF: " & ex.Message)
        End Try

        Return linhasPorEspecialidade
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim dadosPorEspecialidade As Dictionary(Of String, HashSet(Of String)) = getMonthlyData(pdfPath)

        Dim palavraProcurada As String = "Profissional"
        Dim palavrasEncontradas As New List(Of String)()

        ' Percorrer os dados retornados
        For Each especialidade As String In dadosPorEspecialidade.Keys
            Dim linhas As HashSet(Of String) = dadosPorEspecialidade(especialidade)
            For Each linha As String In linhas
                ' Verificar se a palavra procurada está na linha
                If linha.Contains(palavraProcurada) Then
                    palavrasEncontradas.Add($"Encontrada em {especialidade}: {linha}")
                End If
            Next
        Next

        '' Exibir as palavras encontradas
        'Console.WriteLine("Resultados:")
        'For Each resultado In palavrasEncontradas
        '    Console.WriteLine(resultado)
        'Next

    End Sub

    Private Sub FormAME_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Fstart.Visible = True
    End Sub

End Class

Public Class AtendimentoData
    Public Property Tipo As String
    Public Property Agendados As Integer
    Public Property Presentes As Integer
    Public Property PercentualPresente As Decimal
    Public Property Faltosos As Integer
    Public Property PercentualFaltoso As Decimal
    Public Property Livre As Integer
    Public Property Disponibilizadas As Integer
    Public Property DemandaTotal As Integer
End Class