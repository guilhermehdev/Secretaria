Public Class FmainEmendas
    Dim m As New Main

    Dim dgCollumsHeaderText() As String = {"ID", "Recurso", "Ano", "Emenda", "Portaria", "CIB", "Objeto", "Parlamentar", "CNES", "Situação", "Valor", "Obs", "Banco", "Conta", "Depósito", "Conta 4R anterior", "Conta 4R vigente", "Ficha 4R vigente", "Portfolio", "Rag", "Fim contrato"}
    Dim dgCollumsVisible() As Boolean = {False, True, True, True, True, True, True, True, True, True, True, True, True, True, True, True, True, True, True, True, True}
    Dim dgCollumsWidth() As Integer = {0, 100, 100, 70, 80, 80, 80, 300, 90, 140, 70, 140, 100, 100, 100, 100, 100, 100, 100, 100, 100}
    Public queryEmendas = "SELECT emendas.id, recursos.descricao AS recurso, emendas.ano_ref AS ano, emendas.id_emenda AS emenda, emendas.portaria, emendas.cib, emendas.objeto, emendas.parlamentar AS `parlamentar`, cnes.descricao AS cnes, situacoes.descricao AS situacao, emendas.valor, emendas.obs, bancos.descricao AS banco, contas.numero AS conta, emendas.data_deposito, conta4r_anterior.numero AS conta4rant, conta4r_vigente.numero AS conta4rvig, ficha4r_vigente.numero AS ficha4rvig, emendas.porfolio, emendas.rag, emendas.data_termino_contrato FROM emendas JOIN recursos ON emendas.id_recursos = recursos.id JOIN cnes ON emendas.cnes = cnes.id JOIN situacoes ON emendas.situacao_atual = situacoes.id JOIN bancos ON emendas.banco = bancos.id JOIN contas ON emendas.contas = contas.id JOIN conta4r_anterior ON emendas.conta4R_anterior = conta4r_anterior.id JOIN conta4r_vigente ON emendas.conta4r_vigente = conta4r_vigente.id JOIN ficha4r_vigente ON emendas.ficha4r_vigente = ficha4r_vigente.id ORDER BY emendas.id_emenda"

    Protected Friend Sub loadEmendas()
        m.loadDataGrid(queryEmendas, dgListEmendas, dgCollumsVisible, dgCollumsHeaderText, dgCollumsWidth, DataGridViewAutoSizeColumnsMode.None, True)
    End Sub

    Private Sub FmainEmendas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadEmendas()
    End Sub

    Private Sub FmainEmendas_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub EmendaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmendaToolStripMenuItem.Click
        FcadEmendas.ShowDialog()
    End Sub

End Class