Imports Mysqlx.XDevAPI.Relational

Public Class FormCadUsuario
    Dim m As New Main
    Private userData As DataTable
    Private Sub FormCadUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadUsers()
        cbUsuariosCadastrados.SelectedIndex = -1
    End Sub

    Private Sub loadUsers()
        userData = m.loadComboBox("SELECT * FROM usuarios WHERE ativo=1", cbUsuariosCadastrados, "nome", "id")

    End Sub

    Private Sub cbUsuariosCadastrados_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbUsuariosCadastrados.SelectionChangeCommitted

        Dim rows As DataRow() = userData.Select($"id={cbUsuariosCadastrados.SelectedValue}")
        If rows.Length > 0 Then
            tbNovoNome.Text = rows(0)("nome").ToString()
            tbNovaSenha.Text = rows(0)("senha").ToString()
            CheckBoxAtivo.Checked = rows(0)("ativo")
            cbNivelAcesso.SelectedValue = rows(0)("level")
            cbNivelAcesso.SelectedIndex = rows(0)("level")
            CheckBoxeOuve.Checked = rows(0)("eouve")
            CheckBoxEMTU.Checked = rows(0)("emtu")
            CheckBoxCNES.Checked = rows(0)("cnes")
        End If

        btSalvarUsuario.Enabled = False
        btCancelaEdicao.Enabled = True
        btAtualizarUsuario.Enabled = True
    End Sub

    Private Sub btCancelaEdicao_Click(sender As Object, e As EventArgs) Handles btCancelaEdicao.Click
        btSalvarUsuario.Enabled = True
        btCancelaEdicao.Enabled = False
        btAtualizarUsuario.Enabled = False
        tbNovoNome.Clear()
        tbNovoNome.Focus()
        tbNovaSenha.Clear()
        tbNovaSenhaConfirma.Clear()
        CheckBoxAtivo.Checked = False
        CheckBoxCNES.Checked = False
        CheckBoxEMTU.Checked = False
        CheckBoxeOuve.Checked = False
        cbNivelAcesso.SelectedIndex = -1
        cbUsuariosCadastrados.SelectedIndex = -1
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub FormCadUsuario_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Fstart.Visible = True
    End Sub

End Class