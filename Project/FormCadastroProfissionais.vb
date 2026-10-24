Imports System.Globalization
Imports System.Text.RegularExpressions

Public Class FormAMECadastroProfissionais
    Private ReadOnly ui As New Main
    Private profissionalId As Integer

    ' Vínculos utilizados pelos profissionais cadastrados no AME.
    Private Const IdSetorMedico As Integer = 3
    Private Const IdUnidadeAme As Integer = 1

    Private Sub FormAMECadastroProfissionais_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregarNiveisAutorizador()
        CarregarEspecialidades()
        CarregarProfissionais()
        LimparFormulario()
    End Sub

    Private Sub CarregarNiveisAutorizador()
        Dim niveis As New DataTable()
        niveis.Columns.Add("id", GetType(Integer))
        niveis.Columns.Add("descricao", GetType(String))
        niveis.Rows.Add(0, "Executante")
        niveis.Rows.Add(1, "Autorizador nível 1")
        niveis.Rows.Add(2, "Autorizador nível 2")

        cbNivelautorizador.DataSource = niveis
        cbNivelautorizador.DisplayMember = "descricao"
        cbNivelautorizador.ValueMember = "id"
    End Sub

    Private Sub CarregarEspecialidades()
        Dim especialidades = FormAMEmain.getDataset("SELECT id, especialidade FROM especs ORDER BY especialidade")
        cbEspecialidades.DataSource = especialidades
        cbEspecialidades.DisplayMember = "especialidade"
        cbEspecialidades.ValueMember = "id"
    End Sub

    Private Sub CarregarProfissionais()
        Dim query = "SELECT s.id, s.nome, DATE_FORMAT(s.dtnasc, '%d/%m/%Y') AS nascimento, " &
                    "s.CPF AS cpf, s.SUS AS cns, COALESCE(e.especialidade, '') AS especialidade, " &
                    "s.cbo, CASE s.oci_autorizador WHEN 1 THEN 'Nível 1' WHEN 2 THEN 'Nível 2' ELSE 'Não' END AS autorizador, " &
                    "s.dtnasc AS data_nascimento, " &
                    "s.oci_autorizador AS nivel_autorizador, s.id_espec " &
                    "FROM servidores s LEFT JOIN especs e ON e.id = s.id_espec " &
                    "WHERE UPPER(TRIM(s.nome)) <> 'TODOS' ORDER BY s.nome"

        Dim profissionais = FormAMEmain.getDataset(query)
        dgProfissionais.DataSource = profissionais

        If dgProfissionais.Columns.Count = 0 Then
            lbQtdRegistros.Text = "0" & "Registros"
            Return
        End If

        OcultarColuna("id")
        OcultarColuna("data_nascimento")
        OcultarColuna("nivel_autorizador")
        OcultarColuna("id_espec")

        DefinirCabecalho("nome", "Nome", 190)
        DefinirCabecalho("nascimento", "Nascimento", 75)
        DefinirCabecalho("cpf", "CPF", 95)
        DefinirCabecalho("cns", "CNS", 115)
        DefinirCabecalho("especialidade", "Especialidade", 120)
        DefinirCabecalho("cbo", "CBO", 55)
        DefinirCabecalho("autorizador", "Aut.", 55)

        lbQtdRegistros.Text = profissionais.Rows.Count.ToString() & " Registros"
        dgProfissionais.ClearSelection()
    End Sub

    Private Sub DefinirCabecalho(nomeColuna As String, texto As String, largura As Integer)
        If dgProfissionais.Columns.Contains(nomeColuna) Then
            dgProfissionais.Columns(nomeColuna).HeaderText = texto
            dgProfissionais.Columns(nomeColuna).Width = largura
        End If
    End Sub

    Private Sub OcultarColuna(nomeColuna As String)
        If dgProfissionais.Columns.Contains(nomeColuna) Then dgProfissionais.Columns(nomeColuna).Visible = False
    End Sub

    Private Function SomenteDigitos(valor As String) As String
        Return Regex.Replace(If(valor, String.Empty), "\D", String.Empty)
    End Function

    Private Function ObterDataNascimento(ByRef dataNascimento As Object) As Boolean
        Dim texto = dtNascimentoprofissional.Text.Trim()
        If String.IsNullOrWhiteSpace(texto.Replace("/", String.Empty)) Then
            dataNascimento = DBNull.Value
            Return True
        End If

        Dim data As DateTime
        If Not DateTime.TryParseExact(texto, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, data) Then
            ui.msgAlert("Informe uma data de nascimento válida.")
            dtNascimentoprofissional.Focus()
            Return False
        End If

        If data.Date > DateTime.Today Then
            ui.msgAlert("A data de nascimento não pode ser futura.")
            dtNascimentoprofissional.Focus()
            Return False
        End If

        dataNascimento = data.Date
        Return True
    End Function

    Private Function ValidarFormulario(ByRef dataNascimento As Object,
                                       ByRef cpf As String,
                                       ByRef cns As Object,
                                       ByRef cbo As String,
                                       ByRef nivelAutorizador As Integer,
                                       ByRef idEspecialidade As Object) As Boolean
        If String.IsNullOrWhiteSpace(tbNomeProfissional.Text) Then
            ui.msgAlert("Informe o nome do profissional.")
            tbNomeProfissional.Focus()
            Return False
        End If

        cpf = SomenteDigitos(txtCpfProfissional.Text)
        If cpf.Length <> 11 Then
            ui.msgAlert("Informe um CPF com 11 dígitos.")
            txtCpfProfissional.Focus()
            Return False
        End If

        If (New Main).ValidarCPF(cpf) = False Then
            ui.msgAlert("O CPF informado é inválido.")
            txtCpfProfissional.Focus()
            Return False
        End If

        Dim cnsTexto = SomenteDigitos(txtCnsProfissional.Text)
        If cnsTexto.Length = 0 Then
            cns = DBNull.Value
        ElseIf cnsTexto.Length <> 15 Then
            ui.msgAlert("O CNS deve ter 15 dígitos.")
            txtCnsProfissional.Focus()
            Return False
        Else
            cns = cnsTexto
        End If

        cbo = SomenteDigitos(tbCBO.Text)
        If cbo.Length <> 6 Then
            ui.msgAlert("Informe o CBO com 6 dígitos.")
            tbCBO.Focus()
            Return False
        End If

        If cbNivelautorizador.SelectedIndex < 0 Then
            ui.msgAlert("Selecione o nível de autorizador.")
            cbNivelautorizador.Focus()
            Return False
        End If
        nivelAutorizador = Convert.ToInt32(cbNivelautorizador.SelectedValue)

        If cbEspecialidades.SelectedIndex < 0 OrElse cbEspecialidades.SelectedValue Is Nothing Then
            idEspecialidade = DBNull.Value
        Else
            idEspecialidade = Convert.ToInt32(cbEspecialidades.SelectedValue)
        End If

        Return ObterDataNascimento(dataNascimento)
    End Function

    Private Sub btSalvarProfissional_Click(sender As Object, e As EventArgs) Handles btSalvarProfissional.Click
        Dim dataNascimento As Object = Nothing
        Dim cpf As String = Nothing
        Dim cns As Object = Nothing
        Dim cbo As String = Nothing
        Dim nivelAutorizador As Integer
        Dim idEspecialidade As Object = Nothing

        If Not ValidarFormulario(dataNascimento, cpf, cns, cbo, nivelAutorizador, idEspecialidade) Then Return

        Try
            Dim parametros As New Dictionary(Of String, Object) From {
                {"@nome", tbNomeProfissional.Text.Trim().ToUpperInvariant()},
                {"@dtnasc", dataNascimento}, {"@cpf", cpf}, {"@sus", cns}, {"@cbo", cbo},
                {"@autorizador", nivelAutorizador}, {"@id_espec", idEspecialidade},
                {"@setor", IdSetorMedico}, {"@unidade", IdUnidadeAme}
            }

            FormAMEmain.doQuery("INSERT INTO servidores " &
                                "(nome, dtnasc, CPF, SUS, id_setor, id_unidade, cbo, oci_autorizador, id_espec) " &
                                "VALUES (@nome, @dtnasc, @cpf, @sus, @setor, @unidade, @cbo, @autorizador, @id_espec)", parametros)

            ui.msgInfo("Profissional cadastrado com sucesso!")
            CarregarProfissionais()
            LimparFormulario()
        Catch ex As Exception
            ExibirErroBanco(ex)
        End Try
    End Sub

    Private Sub btAtualizarProfissional_Click(sender As Object, e As EventArgs) Handles btAtualizarProfissional.Click
        If profissionalId <= 0 Then
            ui.msgAlert("Selecione um profissional na lista para atualizar.")
            Return
        End If

        Dim dataNascimento As Object = Nothing
        Dim cpf As String = Nothing
        Dim cns As Object = Nothing
        Dim cbo As String = Nothing
        Dim nivelAutorizador As Integer
        Dim idEspecialidade As Object = Nothing

        If Not ValidarFormulario(dataNascimento, cpf, cns, cbo, nivelAutorizador, idEspecialidade) Then Return

        Try
            Dim parametros As New Dictionary(Of String, Object) From {
                {"@nome", tbNomeProfissional.Text.Trim().ToUpperInvariant()},
                {"@dtnasc", dataNascimento}, {"@cpf", cpf}, {"@sus", cns}, {"@cbo", cbo},
                {"@autorizador", nivelAutorizador}, {"@id_espec", idEspecialidade}, {"@id", profissionalId}
            }

            FormAMEmain.doQuery("UPDATE servidores SET nome=@nome, dtnasc=@dtnasc, CPF=@cpf, SUS=@sus, " &
                                "cbo=@cbo, oci_autorizador=@autorizador, id_espec=@id_espec WHERE id=@id", parametros)

            ui.msgInfo("Profissional atualizado com sucesso!")
            CarregarProfissionais()
            LimparFormulario()
        Catch ex As Exception
            ExibirErroBanco(ex)
        End Try
    End Sub

    Private Sub dgProfissionais_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgProfissionais.CellClick
        If e.RowIndex < 0 Then Return

        Dim linha = dgProfissionais.Rows(e.RowIndex)
        profissionalId = Convert.ToInt32(linha.Cells("id").Value)
        tbNomeProfissional.Text = Convert.ToString(linha.Cells("nome").Value)
        txtCpfProfissional.Text = SomenteDigitos(Convert.ToString(linha.Cells("cpf").Value))
        txtCnsProfissional.Text = SomenteDigitos(Convert.ToString(linha.Cells("cns").Value))
        tbCBO.Text = Convert.ToString(linha.Cells("cbo").Value)

        If linha.Cells("data_nascimento").Value Is DBNull.Value OrElse linha.Cells("data_nascimento").Value Is Nothing Then
            dtNascimentoprofissional.Clear()
        Else
            dtNascimentoprofissional.Text = Convert.ToDateTime(linha.Cells("data_nascimento").Value).ToString("dd/MM/yyyy")
        End If

        If linha.Cells("nivel_autorizador").Value Is DBNull.Value Then
            cbNivelautorizador.SelectedValue = 0
        Else
            cbNivelautorizador.SelectedValue = Convert.ToInt32(linha.Cells("nivel_autorizador").Value)
        End If

        If linha.Cells("id_espec").Value Is DBNull.Value OrElse linha.Cells("id_espec").Value Is Nothing Then
            cbEspecialidades.SelectedIndex = -1
        Else
            cbEspecialidades.SelectedValue = Convert.ToInt32(linha.Cells("id_espec").Value)
        End If

        btAtualizarProfissional.Enabled = True
    End Sub

    Private Sub LimparFormulario()
        profissionalId = 0
        tbNomeProfissional.Clear()
        dtNascimentoprofissional.Clear()
        txtCpfProfissional.Clear()
        txtCnsProfissional.Clear()
        tbCBO.Clear()
        If cbNivelautorizador.Items.Count > 0 Then cbNivelautorizador.SelectedValue = 0
        cbEspecialidades.SelectedIndex = -1
        btAtualizarProfissional.Enabled = False
        tbNomeProfissional.Focus()
    End Sub

    Private Sub ExibirErroBanco(ex As Exception)
        Dim mensagem = ex.Message
        If mensagem.IndexOf("Duplicate", StringComparison.OrdinalIgnoreCase) >= 0 Then
            If mensagem.IndexOf("CPF", StringComparison.OrdinalIgnoreCase) >= 0 Then
                ui.msgAlert("Já existe um profissional cadastrado com este CPF.")
            ElseIf mensagem.IndexOf("SUS", StringComparison.OrdinalIgnoreCase) >= 0 Then
                ui.msgAlert("Já existe um profissional cadastrado com este CNS.")
            Else
                ui.msgAlert("Já existe um cadastro com um dos dados informados.")
            End If
        Else
            ui.msgError("Não foi possível gravar o profissional." & vbCrLf & mensagem)
        End If
    End Sub

    Private Sub btFechar_Click(sender As Object, e As EventArgs) Handles btFechar.Click
        Me.Close()
    End Sub
End Class
