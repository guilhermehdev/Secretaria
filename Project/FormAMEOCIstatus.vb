Imports Org.BouncyCastle.Asn1.Cmp

Public Class FormAMEOCIstatus

    Public Property StatusSelecionado As String = Nothing

    Private Sub btnConfirmaStatus_Click(sender As Object, e As EventArgs) Handles btnConfirmaStatus.Click
        If cbStatus.SelectedItem IsNot Nothing Then
            StatusSelecionado = cbStatus.SelectedItem.ToString()
            Me.DialogResult = DialogResult.OK
        Else
            MessageBox.Show("Por favor, selecione um status antes de confirmar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

End Class