Imports System.Text
Imports System.Text.RegularExpressions
Imports UglyToad.PdfPig
Imports UglyToad.PdfPig.Graphics

Public Class PDFPig
    Dim caminhoPdf As String = "E:\Desktop\mensal_abril.pdf"


    Public Function ExtrairDadosPDF() As String
        Dim textoFormatado As New StringBuilder()

        Using document = PdfDocument.Open(caminhoPdf)
            For Each page In document.GetPages()
                Dim palavras = page.GetWords()
                For Each palavra In palavras
                    textoFormatado.AppendLine(palavra.Text.Trim())
                Next
            Next
        End Using

        Return textoFormatado.ToString()
    End Function



End Class

