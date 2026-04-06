
Public Class FormAMEAgendas

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim pdf As New PDF

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim agenda = pdf.AgruparConsultasPDF(OpenFileDialog1.FileNames)

            ListBox1.Items.Clear()

            For Each linha In agenda
                ListBox1.Items.Add(linha)
            Next

        End If
    End Sub

End Class