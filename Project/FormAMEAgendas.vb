
Public Class FormAMEAgendas

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim pdf As New PDF

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

            Dim teste = pdf.AgruparConsultasPDF(OpenFileDialog1.FileNames(0))
            MessageBox.Show(teste.Count)

            pdf.GerarRelatorioPDF3Colunas(
                OpenFileDialog1.FileNames,
                "D:\Desktop\agenda_relatorio.pdf"
            )

        End If
    End Sub

End Class