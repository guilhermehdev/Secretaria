Public Class Fusuarios
    Dim vmain As New Main
    Dim vusuarios As New Usuarios
    Dim vlog As New Logs
   
    Private Sub Fusuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        vmain.bnew = btNew
        vmain.bsave = btSave
        vmain.bupdate = btUpdate
        vmain.bdelete = btDelete
        vmain.bcancel = btCancel
        vmain.bexit = btSair

        vusuarios.loadUsuarios(dgUsuarios, , DataGridViewAutoSizeColumnsMode.DisplayedCells)
    End Sub

    Private Sub chkExibeSenha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExibeSenha.CheckedChanged
        If chkExibeSenha.Checked Then
            tbSenha.UseSystemPasswordChar = False
            tbSenha.PasswordChar = Nothing
        Else
            tbSenha.UseSystemPasswordChar = True
            tbSenha.PasswordChar = "*"
        End If

    End Sub

    Private Sub btNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNew.Click
        vmain.clearFields(gbDadosUsuario)
        vmain.activeFields(gbDadosUsuario, True)
        tbDesc.Focus()
    End Sub

    Private Sub btCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancel.Click
        vmain.clearFields(gbDadosUsuario)
        vmain.activeFields(gbDadosUsuario, False)
    End Sub

    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click

        If tbDesc.Text <> String.Empty And tbSenha.Text <> String.Empty Then
            vusuarios.saveUsuario(tbDesc.Text, tbSenha.Text, cbAtivo.SelectedIndex, chkCadCli.CheckState, chkCadProd.CheckState, chkVendas.CheckState, chkCaixa.CheckState, chkRelatVendas.CheckState, chkConCli.CheckState, chkRelatCaixa.CheckState, chkBanco.CheckState, chkBkpBanco.CheckState, chkConProd.CheckState, chkCadUsuarios.CheckState, dgUsuarios)

            ' vlog.insertLog("USUÁRIO CADASTRADO | NOME: " & tbDesc.Text, Flogin.idOperador)

        Else
            vmain.msgAlert("Preencha os campos em branco!")
        End If

    End Sub

    Private Sub btUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btUpdate.Click

        If tbDesc.Text <> String.Empty And tbSenha.Text <> String.Empty Then
            If dgUsuarios.SelectedRows.Item(0).Cells(4).Value = 10 Then
                vusuarios.updateUsuario(tbDesc.Text, tbSenha.Text, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, dgUsuarios)
                '  vlog.insertLog("ADMINISTRADOR ATUALIZADO | NOME: " & tbDesc.Text, Flogin.idOperador)
            Else
                vusuarios.updateUsuario(tbDesc.Text, tbSenha.Text, cbAtivo.SelectedIndex, chkCadCli.CheckState, chkCadProd.CheckState, chkVendas.CheckState, chkCaixa.CheckState, chkRelatVendas.CheckState, chkConCli.CheckState, chkRelatCaixa.CheckState, chkBanco.CheckState, chkBkpBanco.CheckState, chkConProd.CheckState, chkCadUsuarios.CheckState, dgUsuarios)
                ' vlog.insertLog("USUÁRIO ATUALIZADO | NOME: " & tbDesc.Text, Flogin.idOperador)
            End If
        Else
            vmain.msgAlert("Preencha os campos em branco!")
        End If

    End Sub

    Private Sub btDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDelete.Click
        If dgUsuarios.SelectedRows.Item(0).Cells(4).Value <> 10 Then
            ' vlog.insertLog("USUÁRIO EXCLUÍDO | NOME: " & tbDesc.Text, Flogin.idOperador)
            vusuarios.deleteUsuario(dgUsuarios.SelectedRows.Item(0).Cells(0).Value, dgUsuarios)
            vmain.activeFields(gbDadosUsuario, False)
        Else
            vmain.msgAlert("Este usuário é o administrador do sistema e não pode ser excluído!")
            vmain.activeFields(gbDadosUsuario, False)
        End If
    End Sub

    Private Sub btSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSair.Click
        Me.Dispose()
    End Sub

    Private Sub dgUsuarios_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgUsuarios.CellEnter
        Try
            If dgUsuarios.SelectedRows.Item(0).Cells(3).Value = 0 Then
                cbAtivo.Text = "NÃO"
            Else
                cbAtivo.Text = "SIM"
            End If
        Catch ex As Exception

        End Try

    End Sub

End Class