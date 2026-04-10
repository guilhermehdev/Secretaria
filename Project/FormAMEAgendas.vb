
Public Class FormAMEAgendas
    Dim m As New FormAMEmain
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim pdf As New PDF

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            SaveFileDialog1.FileName = $"Agenda {pdf.mesExtenso()}.pdf"
            SaveFileDialog1.ShowDialog()

            pdf.GerarRelatorioPDF3Colunas(OpenFileDialog1.FileNames, SaveFileDialog1.FileName)

        End If
    End Sub
    Private Sub FormAMEAgendas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        m.loadComboBox("SELECT id, nome FROM servidores ORDER BY nome", cbProfissional, "nome", "id")
        cbProfissional.SelectedIndex = -1
    End Sub
    Private Sub cbProfissional_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbProfissional.SelectionChangeCommitted
        m.loadComboBox($"SELECT especs.id, especs.especialidade AS espec 
        FROM especs 
        JOIN servidores ON servidores.id_espec = especs.id
        WHERE servidores.id = {cbProfissional.SelectedValue} ORDER BY nome", cbEspecialidade, "espec", "id")
    End Sub
    Private Sub btSalvarGrade_Click(sender As Object, e As EventArgs) Handles btSalvarGrade.Click
        m.doQuery($"INSERT INTO grade_semanal_medicos (id_dia_semana, id_servidor, id_espec, vagas) VALUES ()")
    End Sub


End Class