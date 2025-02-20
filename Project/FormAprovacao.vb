Public Class FormAprovacao
    Dim m As New Main

    Public Sub getProtocols()
        Dim data = FmainOuvidoria.chechAprova()
        Me.Icon = FmainOuvidoria.Icon

        lbAguardando.Items.Clear()

        For Each protocol In data
            lbAguardando.Items.Add(protocol)
        Next

        ToolStripStatusLabel1.Text = lbAguardando.Items.Count & " Registros"
    End Sub
    Private Sub FormAprovacao_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getProtocols()
    End Sub

    Private Sub lbAguardando_DoubleClick(sender As Object, e As EventArgs) Handles lbAguardando.DoubleClick
        m.copyFromListBox(lbAguardando)
        FormOuvidoriaAndamento.Show()
        FormOuvidoriaAndamento.protocolo = Clipboard.GetText
        FormOuvidoriaAndamento.getManifestacoes()
    End Sub

End Class