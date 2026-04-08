
Public Class FormAMEAgendas

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim pdf As New PDF

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            SaveFileDialog1.FileName = $"Agenda {pdf.mesExtenso()}.pdf"
            SaveFileDialog1.ShowDialog()

            pdf.GerarRelatorioPDF3Colunas(OpenFileDialog1.FileNames, SaveFileDialog1.FileName)

        End If
    End Sub

End Class