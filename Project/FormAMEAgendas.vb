
Public Class FormAMEAgendas
    Dim cm As New Main
    Dim m As New FormAMEmain
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim pdf As New PDF

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            SaveFileDialog1.FileName = $"Agenda {pdf.mesExtenso()}.pdf"
            SaveFileDialog1.ShowDialog()

            pdf.GerarRelatorioPDF3Colunas(OpenFileDialog1.FileNames, SaveFileDialog1.FileName)

        End If
    End Sub
    Private Sub loadGrades()
        Dim dataGrade As DataTable = m.getDataset($"SELECT grade_semanal_medicos.id, servidores.nome AS Profissional, dias.dia AS Dia, especs.especialidade AS Especialidade, grade_semanal_medicos.vagas AS Vagas
        FROM grade_semanal_medicos
        JOIN servidores ON servidores.id = grade_semanal_medicos.id_servidor
        JOIN dias ON dias.id = grade_semanal_medicos.id_dia_semana
        JOIN especs ON especs.id = grade_semanal_medicos.id_espec
        WHERE grade_semanal_medicos.id_servidor={cbProfissional.SelectedValue}")

        dgGrades.DataSource = dataGrade
        dgGrades.Columns("id").Visible = False
        dgGrades.Columns("Profissional").Width = 200
        dgGrades.Columns("Dia").Width = 50
        dgGrades.Columns("Especialidade").Width = 150
        dgGrades.Columns("Vagas").Width = 80

    End Sub
    Private Sub FormAMEAgendas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        m.loadComboBox("SELECT id, nome FROM servidores ORDER BY nome", cbProfissional, "nome", "id")
        cbProfissional.SelectedIndex = -1
        m.loadComboBox("SELECT id, dia FROM dias ORDER BY id", cbDiasemana, "dia", "id")

    End Sub
    Private Sub cbProfissional_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbProfissional.SelectionChangeCommitted
        m.loadComboBox($"SELECT especs.id, especs.especialidade AS espec 
        FROM especs 
        JOIN servidores ON servidores.id_espec = especs.id
        WHERE servidores.id = {cbProfissional.SelectedValue} ORDER BY nome", cbEspecialidade, "espec", "id")
    End Sub
    Private Sub btSalvarGrade_Click(sender As Object, e As EventArgs) Handles btSalvarGrade.Click
        If m.doQuery($"INSERT INTO grade_semanal_medicos (id_dia_semana, id_servidor, id_espec, vagas) VALUES ({cbDiasemana.SelectedValue},{cbProfissional.SelectedValue},{cbEspecialidade.SelectedValue},{Nvagas.Value})") Then
            loadGrades()
        End If

    End Sub
    Private Sub FormAMEAgendas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        FormAMEmain.Visible = True
    End Sub
    Private Sub cbEspecialidade_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEspecialidade.SelectedIndexChanged
        loadGrades()
    End Sub
End Class