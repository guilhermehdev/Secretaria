Imports Mysqlx.XDevAPI.Relational

Public Class FormLoginCadUsuario
    Dim m As New Main
    Private userData As DataTable
    Private Sub FormCadUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadUsers()
        cbUsuariosCadastrados.SelectedIndex = -1
    End Sub

    Private Sub loadUsers()
        cancel()
        userData = m.loadComboBox("SELECT * FROM usuarios ORDER BY nome", cbUsuariosCadastrados, "nome", "id")
        cbNivelAcesso.SelectedIndex = 0
        m.loadComboBox("SELECT * FROM usuarios ORDER BY nome", FormLogin.cbUsuarios, "nome", "id")
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

    Private Sub cancel()
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

    Private Sub btCancelaEdicao_Click(sender As Object, e As EventArgs) Handles btCancelaEdicao.Click
        cancel()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub FormCadUsuario_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        FormSystemStart.Visible = True
    End Sub
    Private Sub btSalvarUsuario_Click(sender As Object, e As EventArgs) Handles btSalvarUsuario.Click
        If tbNovoNome.Text IsNot "" AndAlso tbNovaSenha.Text IsNot "" AndAlso tbNovaSenhaConfirma.Text IsNot "" Then

            If tbNovaSenha.Text = tbNovaSenhaConfirma.Text Then
                m.doQuery($"INSERT INTO usuarios (nome, senha, level, ativo, eouve, emtu, cnes) VALUES ('{tbNovoNome.Text.ToUpper}', '{tbNovaSenha.Text}', {cbNivelAcesso.SelectedItem}, {If(CheckBoxAtivo.Checked, 1, 0)}, {If(CheckBoxeOuve.Checked, 1, 0)}, {If(CheckBoxEMTU.Checked, 1, 0)}, {If(CheckBoxCNES.Checked, 1, 0)})", True)
                loadUsers()
                m.msgInfo("Usuário cadastrado com sucesso")
                cancel()
            Else
                m.msgAlert("As senhas não conferem")
            End If
        Else
            m.msgAlert("Preencha todos os campos")
        End If
    End Sub

    Private Sub btAtualizarUsuario_Click(sender As Object, e As EventArgs) Handles btAtualizarUsuario.Click
        If tbNovoNome.Text IsNot "" AndAlso tbNovaSenha.Text IsNot "" AndAlso tbNovaSenhaConfirma.Text IsNot "" Then
            If tbNovaSenha.Text = tbNovaSenhaConfirma.Text Then
                m.doQuery($"UPDATE usuarios set nome='{tbNovoNome.Text.ToUpper}', senha='{tbNovaSenha.Text}', level={cbNivelAcesso.SelectedItem}, ativo={If(CheckBoxAtivo.Checked, 1, 0)}, eouve={If(CheckBoxeOuve.Checked, 1, 0)}, emtu={If(CheckBoxEMTU.Checked, 1, 0)}, cnes={If(CheckBoxCNES.Checked, 1, 0)} WHERE id={cbUsuariosCadastrados.SelectedValue }", True)
                loadUsers()
                m.msgInfo("Usuário atualizado com sucesso")
            Else
                m.msgAlert("As senhas não conferem")
            End If
        Else
            m.msgAlert("Preencha todos os campos")
        End If

    End Sub
End Class