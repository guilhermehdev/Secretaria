Public Class FormMainBLH
    Dim blh As New BLH
    Dim importXLS As New XLStoSQL

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        importXLS.getXLSProcessamento()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        importXLS.getXLScadastroGeral()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If c1.Text = "" Or t1.Text = "" Or c2.Text = "" Or t2.Text = "" Or c3.Text = "" Or t3.Text = "" Then
            MessageBox.Show("Preencha todos os campos")
            Exit Sub
        End If

        lbGordura.Text = blh.PercentualDeGordura(CDbl(c1.Text), CDbl(t1.Text), CDbl(c2.Text), CDbl(t2.Text), CDbl(c3.Text), CDbl(t3.Text)).ToString

        lbCreme.Text = blh.percentualCreme(CDbl(c1.Text), CDbl(t1.Text), CDbl(c2.Text), CDbl(t2.Text), CDbl(c3.Text), CDbl(t3.Text)).ToString

        lbKal.Text = blh.Kcal(CDbl(c1.Text), CDbl(t1.Text), CDbl(c2.Text), CDbl(t2.Text), CDbl(c3.Text), CDbl(t3.Text)).ToString

    End Sub

End Class