Public Class Usuarios
    Dim vmain As New Main
    Dim mainTBs As Object = vmain.tbs
    Public WithEvents _gridview As DataGridView

    Dim queryUsuarios As String = "SELECT * FROM usuarios "

    Dim dgUsuariosCollumsHeaderText() As String = {"ID", "Nome", "", "", "", "Cad Cliente", "Cad Produto", "Vendas", "Caixa", "Relat Vendas", "Cons Cliente", "Relat Caixa", "Conf Banco", "Backup", "Cons Produto", "Cad Usuário"}
    Dim dgUsuariosCollums() As Boolean = {False, True, False, False, False, True, True, True, True, True, True, True, True, True, True, True}
    Dim dgUsuariosWidth() As Integer = {0, 140, 0, 30, 0, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30}


    Public Sub loadUsuarios(ByVal grid As DataGridView, Optional ByVal criterios As String = "", Optional ByVal collumMode As DataGridViewAutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None)
        Try
            vmain.loadDataGrid(queryUsuarios & criterios, grid, dgUsuariosCollums, dgUsuariosCollumsHeaderText, dgUsuariosWidth, collumMode)
            vmain.datagrid = grid
            _gridview = grid
        Catch ex As Exception

        End Try
    End Sub

    Public Sub saveUsuario(ByVal nome As String, ByVal senha As String, ByVal ativo As Integer, ByVal cadCli As Integer, ByVal cadProd As Integer, ByVal vendas As Integer, ByVal caixa As Integer, ByVal relatVendas As Integer, ByVal consCli As Integer, ByVal relatCaixa As Integer, ByVal confBanco As Integer, ByVal backup As Integer, ByVal consProd As Integer, ByVal cadUsuario As Integer, ByVal grid As DataGridView)
        Try
            vmain.SQLinsert("usuarios", "nome,senha,ativo,cadCliente,cadProdutos,vendas,caixa,relatorios,consultacli,relatoriocaixa,config,backup,consultaprod,cadUsuario", "'" & nome & "','" & senha & "'," & ativo & "," & cadCli & "," & cadProd & "," & vendas & "," & caixa & "," & relatVendas & "," & consCli & "," & relatCaixa & "," & confBanco & "," & backup & "," & consProd & "," & cadUsuario, True, True, queryUsuarios, grid, True)

        Catch ex As Exception

        End Try
    End Sub

    Public Sub updateUsuario(ByVal nome As String, ByVal senha As String, ByVal ativo As Integer, ByVal cadCli As Integer, ByVal cadProd As Integer, ByVal vendas As Integer, ByVal caixa As Integer, ByVal relatVendas As Integer, ByVal consCli As Integer, ByVal relatCaixa As Integer, ByVal confBanco As Integer, ByVal backup As Integer, ByVal consProd As Integer, ByVal cadUsuario As Integer, ByVal grid As DataGridView)
        Try
            vmain.SQLupdate("usuarios", "nome='" & nome & "',senha='" & senha & "',ativo=" & ativo & ",cadCliente=" & cadCli & ",cadProdutos=" & cadProd & ",vendas=" & vendas & ",caixa=" & caixa & ",relatorios=" & relatVendas & ",consultacli=" & consCli & ",relatoriocaixa=" & relatCaixa & ",config=" & confBanco & ",backup=" & backup & ",consultaprod=" & consProd & ",cadUsuario=" & cadUsuario, "id", grid, 0, Nothing, True, True, queryUsuarios)

        Catch ex As Exception

        End Try
    End Sub

    Public Sub deleteUsuario(ByVal id As Integer, ByVal grid As DataGridView)
        Try
            vmain.SQLdelete("usuarios", "id", grid, 0, True, True, queryUsuarios)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles _gridview.CellEnter
        mainTBs(1) = Fusuarios.tbDesc
        mainTBs(2) = Fusuarios.tbSenha
        mainTBs(3) = Nothing
        mainTBs(4) = Nothing
        mainTBs(5) = Fusuarios.chkCadCli
        mainTBs(6) = Fusuarios.chkCadProd
        mainTBs(7) = Fusuarios.chkVendas
        mainTBs(8) = Fusuarios.chkCaixa
        mainTBs(9) = Fusuarios.chkRelatVendas
        mainTBs(10) = Fusuarios.chkConCli
        mainTBs(11) = Fusuarios.chkRelatCaixa
        mainTBs(12) = Fusuarios.chkBanco
        mainTBs(13) = Fusuarios.chkBkpBanco
        mainTBs(14) = Fusuarios.chkConProd
        mainTBs(15) = Fusuarios.chkCadUsuarios


        Fusuarios.btUpdate.Enabled = True
        Fusuarios.btDelete.Enabled = True
        Fusuarios.btSave.Enabled = False

        vmain.activeFields(Fusuarios.gbDadosUsuario, True)

    End Sub

End Class
