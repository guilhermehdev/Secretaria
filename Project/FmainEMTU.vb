Public Class FmainEMTU
    Dim m As New Main

    Private Sub FmainCadastro_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Fstart.Visible = True
    End Sub

    Private Sub PacienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PacienteToolStripMenuItem.Click
        FcadPacientesEMTU.Text = "Cadastro de usuários"
        FcadPacientesEMTU.btNovo.Enabled = True
        FcadPacientesEMTU.btSalvar.Enabled = True
        FcadPacientesEMTU.btAtualizar.Visible = False
        m.clearFields(FcadPacientesEMTU)
        m.clearFields(FcadPacientesEMTU.GroupBox1)
        FcadPacientesEMTU.ShowDialog()
    End Sub

    Private Sub FmainCadastro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadGrid()
    End Sub

    Private Sub SairToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SairToolStripMenuItem.Click
        Me.Close()
    End Sub

    Public Sub loadGrid(Optional ByVal where As String = Nothing)
        m.loadDataGrid("SELECT * FROM emtu " & where & " ORDER BY nome", dgListPacientes, {False, True, True, True, True, True, True, True, True, True}, {"ID", "Nome", "Tel", "Emissão", "Laudo", "Data da solicitação", "Retirado por", "RG", "Data da retirada", "Obs"}, {0, 250, 100, 80, 90, 90, 200, 100, 90, 200}, DataGridViewAutoSizeColumnsMode.Fill)
        SsLabelRegistros.Text = "Registros: " & dgListPacientes.RowCount
    End Sub

    Private Sub ExcluirRegistroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcluirRegistroToolStripMenuItem.Click
        If m.SQLdelete("emtu", "id", dgListPacientes, 0, True) Then
            loadGrid()
        End If

    End Sub

    Private Sub dgListPacientes_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgListPacientes.CellDoubleClick
        Dim dados = m.getDataFromDatagridRow(dgListPacientes)

        FcadPacientesEMTU.tbNome.Text = dados(1)
        FcadPacientesEMTU.mtbTel.Text = dados(2)
        FcadPacientesEMTU.cbEmissao.Text = dados(3)
        FcadPacientesEMTU.tbLaudo.Text = dados(4)
        FcadPacientesEMTU.dtpDataSol.Value = dados(5)
        FcadPacientesEMTU.tbObs.Text = dados(9)
        FcadPacientesEMTU.tbNomeRetirada.Text = dados(6)
        FcadPacientesEMTU.mtbRG.Text = dados(7)
        If dados(8) <> "" Then
            FcadPacientesEMTU.dtpDataRetirada.Value = dados(8)
        End If

        FcadPacientesEMTU.btNovo.Enabled = False
        FcadPacientesEMTU.btSalvar.Enabled = False
        FcadPacientesEMTU.btAtualizar.Visible = True
        FcadPacientesEMTU.Text = "Alteração de dados"
        FcadPacientesEMTU.ShowDialog()


    End Sub

    Private Sub tbBuscaNome_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbBuscaNome.TextChanged

        If tbBuscaNome.Text.Length >= 3 Then
            loadGrid("WHERE nome LIKE '%" & tbBuscaNome.Text & "%'")
        Else
            loadGrid()
        End If

    End Sub

    Private Sub FmainEMTU_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Me.Cursor = Cursors.Default
    End Sub

End Class