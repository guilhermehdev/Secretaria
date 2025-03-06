Imports iTextSharp.text.pdf

Public Class FCNES
    Dim pdfPath As String = Application.StartupPath & "/PDF/equipes.pdf"
    Dim xml As New XML
    Private Sub PlanejamentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlanejamentoToolStripMenuItem.Click
        FplanejCNES.Show()
    End Sub

    Private Sub FCNES_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        xml.equipesXML()


    End Sub

End Class