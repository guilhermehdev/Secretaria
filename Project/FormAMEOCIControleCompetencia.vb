Public Class FormAMEOCIControleCompetencia
    Private Sub btSalvar_Click(sender As Object, e As EventArgs) Handles btSalvar.Click
        If txtCompetencia.Text.Contains("/") Then
            Dim partes() As String = txtCompetencia.Text.Split("/")
            My.Settings.OCIcompetencia = partes(1) & partes(0).PadLeft(2, "0"c)
        Else
            My.Settings.OCIcompetencia = txtCompetencia.Text
        End If

        My.Settings.OCInomeUnidade = txtOrgaoOrigem.Text
        My.Settings.OCIuf = txtUf.SelectedValue
        My.Settings.OCIsigla = txtSiglaOrgao.Text
        My.Settings.OCIcnpj = txtCGC.Text
        My.Settings.OCIcnsDiretor = txtCnsDiretor.Text
        My.Settings.OCIdiretor = txtNomeDiretor.Text
        My.Settings.OCIcpfDiretor = txtCPFDiretor.Text
        My.Settings.OCIorgaoDestino = txtOrgaoDestino.Text
        My.Settings.OCItipo = txtDestinoTipo.Text

        My.Settings.Save()
        MsgBox("Configurações salvas com sucesso! O sistema será reiniciado para aplicar as novas configurações.", MsgBoxStyle.Information, "Configurações Salvas")
        Application.Restart()

    End Sub

    Private Sub FormAMEOCIControleCompetencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim uf As New Dictionary(Of String, String) From {
            {"35", "SP"}
        }

        txtUf.DataSource = New BindingSource(uf, Nothing)
        txtUf.DisplayMember = "Value"   ' O que aparece para o usuário
        txtUf.ValueMember = "Key"
        txtUf.SelectedIndex = 0
        txtDestinoTipo.SelectedIndex = 0

        txtCompetencia.Text = My.Settings.OCIcompetencia
        txtUf.SelectedValue = My.Settings.OCIuf
        txtOrgaoOrigem.Text = My.Settings.OCInomeUnidade
        txtSiglaOrgao.Text = My.Settings.OCIsigla
        txtCGC.Text = My.Settings.OCIcnpj
        txtCnsDiretor.Text = My.Settings.OCIcnsDiretor
        txtNomeDiretor.Text = My.Settings.OCIdiretor
        txtCPFDiretor.Text = My.Settings.OCIcpfDiretor
        txtOrgaoDestino.Text = My.Settings.OCIorgaoDestino
        txtDestinoTipo.Text = My.Settings.OCItipo


    End Sub
    Private Sub btSair_Click(sender As Object, e As EventArgs) Handles btSair.Click
        Me.Close()
    End Sub

End Class