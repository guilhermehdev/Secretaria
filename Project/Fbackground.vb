Public Class Fbackground

   
    Private Sub btSelecionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSelecionar.Click
        If OpenFileDialog1.ShowDialog Then

            If OpenFileDialog1.CheckFileExists Then
                pbDemo.ImageLocation = OpenFileDialog1.FileName
                lbLocal.Text = OpenFileDialog1.FileName
            End If
        End If

    End Sub

    Private Sub Fbackground_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pbDemo.ImageLocation = My.Settings.background
    End Sub

    Private Sub btOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOK.Click
        My.Settings.background = pbDemo.ImageLocation
        My.Settings.Save()
        FmainOuvidoria.pbBackground.ImageLocation = My.Settings.background
        Me.Dispose()
    End Sub

    Private Sub btRemover_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRemover.Click
        My.Settings.background = Nothing
        pbDemo.ImageLocation = My.Settings.background
        FmainOuvidoria.pbBackground.ImageLocation = My.Settings.background
        My.Settings.Save()
    End Sub

End Class