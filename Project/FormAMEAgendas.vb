
Public Class FormAMEAgendas
    Private Sub FormAMEAgendas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim pdf As New PDF

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim filePath As String = OpenFileDialog1.FileName
            Dim lista = pdf.AgruparConsultasPDF(filePath)

            For Each item In lista
                ListBox1.Items.Add(item)
            Next

        End If
    End Sub

End Class