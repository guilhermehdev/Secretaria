Public Class FormCNESCadastro


    Private carregandoTela As Boolean
    Private profissionalIdSelecionado As String = String.Empty
    Private campoBuscaAtivo As String = String.Empty

    Private Sub FormCNESCadastro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carregandoTela = True
        CarregarEstabelecimentos()
        CarregarCBOS()
        CarregarFormasContratacaoEstabelecimento()

        cbEstabelecimento.SelectedIndex = -1
        cbCBO.SelectedIndex = -1
        cbFormaContratoEstabCadastro.SelectedIndex = -1
        cbcbFormaContratoEmpregCadastro.DataSource = Nothing
        cbDetalhamentoCadastro.DataSource = Nothing
        rbSUSSim.Checked = True

        dgvProfissionais.DataSource = Nothing
        dgvVinculos.DataSource = Nothing
        ConfigurarGridProfissionais()
        ConfigurarGridVinculos()
        LimparCamposVinculo()
        AtualizarEstadoBotoes(False, False)
        carregandoTela = False
    End Sub

    Private Sub CamposBusca_TextChanged(sender As Object, e As EventArgs) _
        Handles TextBoxCPFCadastro.TextChanged, TextBoxNomeCadastro.TextChanged
        If carregandoTela Then Return

        'A digitação apenas invalida o resultado anterior. A consulta será
        'executada somente pelo Enter, evitando recargas inesperadas durante a
        'edição do CPF ou do nome.
        LimparResultadosBusca()
    End Sub

    Private Sub CampoBusca_Enter(sender As Object, e As EventArgs) _
        Handles TextBoxCPFCadastro.Enter, TextBoxNomeCadastro.Enter
        If carregandoTela Then Return

        If sender Is TextBoxCPFCadastro Then
            campoBuscaAtivo = "CPF"
        ElseIf sender Is TextBoxNomeCadastro Then
            campoBuscaAtivo = "NOME"
        End If
    End Sub

    Private Sub CamposBusca_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles TextBoxCPFCadastro.KeyDown, TextBoxNomeCadastro.KeyDown
        If e.KeyCode <> Keys.Enter Then Return

        e.SuppressKeyPress = True
        e.Handled = True
        BuscarProfissionais()
    End Sub

    Private Sub BuscarProfissionais()
        If carregandoTela Then Return

        Dim cpf As String = SomenteDigitos(TextBoxCPFCadastro.Text)
        Dim nome As String = TextBoxNomeCadastro.Text.Trim()

        If campoBuscaAtivo = "CPF" Then
            If cpf.Length <> 11 Then Return
            nome = String.Empty
        ElseIf campoBuscaAtivo = "NOME" Then
            If nome.Length < 3 Then Return
            cpf = String.Empty
        Else
            If cpf.Length <> 11 Then cpf = String.Empty
            If nome.Length < 3 Then nome = String.Empty
        End If

        If cpf.Length = 0 AndAlso nome.Length = 0 Then
            LimparResultadosBusca()
            Return
        End If

        Try
            Dim dados As DataTable = CnesFirebird.ConsultarProfissionaisCadastro(cpf, nome)
            carregandoTela = True
            dgvProfissionais.DataSource = dados
            ConfigurarGridProfissionais()
            dgvVinculos.DataSource = Nothing
            ConfigurarGridVinculos()
            profissionalIdSelecionado = String.Empty
            LimparCamposVinculo()

            If dgvProfissionais.Rows.Count > 0 Then
                dgvProfissionais.ClearSelection()
                dgvProfissionais.CurrentCell = Nothing
            End If
        Catch ex As Exception
            dgvProfissionais.DataSource = Nothing
            dgvVinculos.DataSource = Nothing
            profissionalIdSelecionado = String.Empty
            MostrarErroCNES("Não foi possível consultar os profissionais.", ex)
        Finally
            carregandoTela = False
        End Try

    End Sub

    Private Sub dgvProfissionais_CellClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles dgvProfissionais.CellClick
        If e.RowIndex < 0 OrElse carregandoTela Then Return

        dgvProfissionais.ClearSelection()
        dgvProfissionais.Rows(e.RowIndex).Selected = True
        CarregarProfissionalSelecionado()
    End Sub

    Private Sub CarregarProfissionalSelecionado()
        If dgvProfissionais.CurrentRow Is Nothing OrElse
           dgvProfissionais.CurrentRow.IsNewRow OrElse
           Not dgvProfissionais.Columns.Contains("PROFISSIONAL_ID") Then
            profissionalIdSelecionado = String.Empty
            dgvVinculos.DataSource = Nothing
            LimparCamposVinculo()
            Return
        End If

        Dim linha As DataGridViewRow = dgvProfissionais.CurrentRow
        profissionalIdSelecionado = ValorLinha(linha, "PROFISSIONAL_ID")
        If String.IsNullOrWhiteSpace(profissionalIdSelecionado) Then Return

        carregandoTela = True
        Try
            TextBoxCPFCadastro.Text = FormatarCPF(ValorLinha(linha, "CPF"))
            TextBoxNomeCadastro.Text = ValorLinha(linha, "NOME")
            txtCnsCadastro.Text = FormatarCNS(ValorLinha(linha, "CNS"))
            dtNascimento.Clear()

            If linha.Cells("NASCIMENTO").Value IsNot Nothing AndAlso
               linha.Cells("NASCIMENTO").Value IsNot DBNull.Value Then
                Dim dataNascimento As DateTime
                If DateTime.TryParse(linha.Cells("NASCIMENTO").Value.ToString(), dataNascimento) Then
                    dtNascimento.Text = dataNascimento.ToString("dd/MM/yyyy")
                End If
            End If
        Finally
            carregandoTela = False
        End Try

        AtualizarEstadoBotoes(True, False)
        CarregarVinculos(profissionalIdSelecionado)
    End Sub

    Private Sub CarregarVinculos(profissionalId As String)
        If String.IsNullOrWhiteSpace(profissionalId) Then
            dgvVinculos.DataSource = Nothing
            LimparCamposVinculo()
            Return
        End If

        Try
            Dim dados As DataTable = CnesFirebird.ConsultarVinculosProfissional(profissionalId)
            AdicionarDescricoesVinculo(dados)

            carregandoTela = True
            dgvVinculos.DataSource = dados
            ConfigurarGridVinculos()

            If dgvVinculos.Rows.Count > 0 Then
                dgvVinculos.ClearSelection()
                dgvVinculos.CurrentCell = dgvVinculos.Rows(0).Cells("ESTABELECIMENTO")
                dgvVinculos.Rows(0).Selected = True
            Else
                LimparCamposVinculo()
            End If
        Catch ex As Exception
            dgvVinculos.DataSource = Nothing
            LimparCamposVinculo()
            MostrarErroCNES("Não foi possível consultar os vínculos do profissional.", ex)
        Finally
            carregandoTela = False
        End Try

        If dgvVinculos.Rows.Count > 0 Then
            PreencherCamposVinculoSelecionado()
        Else
            AtualizarEstadoBotoes(True, False)
        End If
    End Sub

    Private Sub CarregarEstabelecimentos()
        Try
            Dim estabelecimentos As DataTable = CnesFirebird.ConsultarEstabelecimentos()

            cbEstabelecimento.DataSource = estabelecimentos
            cbEstabelecimento.DisplayMember = "NOME_FANTASIA"
            cbEstabelecimento.ValueMember = "UNIDADE_ID"
            cbEstabelecimento.SelectedIndex = -1
        Catch ex As Exception
            cbEstabelecimento.DataSource = Nothing
            MostrarErroCNES("Não foi possível carregar os estabelecimentos do CNES.", ex)
        End Try
    End Sub

    Private Sub CarregarCBOS()
        Try
            Dim cbos As DataTable = CnesFirebird.ConsultarCBOS()
            cbCBO.DataSource = cbos
            cbCBO.DisplayMember = "DESCRICAO"
            cbCBO.ValueMember = "COD_CBO"
            cbCBO.SelectedIndex = -1
        Catch ex As Exception
            cbCBO.DataSource = Nothing
            MostrarErroCNES("Não foi possível carregar os CBOs do CNES.", ex)
        End Try
    End Sub

    Private Sub CarregarFormasContratacaoEstabelecimento()
        Try
            Dim formas As DataTable = CnesFirebird.ConsultarFormasContratacaoEstabelecimento()
            cbFormaContratoEstabCadastro.DataSource = formas
            cbFormaContratoEstabCadastro.DisplayMember = "DESCRICAO"
            cbFormaContratoEstabCadastro.ValueMember = "CODIGO"
            cbFormaContratoEstabCadastro.SelectedIndex = -1
        Catch ex As Exception
            cbFormaContratoEstabCadastro.DataSource = Nothing
            MostrarErroCNES("Não foi possível carregar as formas de contratação do CNES.", ex)
        End Try
    End Sub

    Private Sub CarregarFormasContratacaoEmpregador()
        Dim codigoEstabelecimento As String = ValorComboSelecionado(cbFormaContratoEstabCadastro)

        cbcbFormaContratoEmpregCadastro.DataSource = Nothing
        cbDetalhamentoCadastro.DataSource = Nothing
        tbCNPJContratador.Clear()
        tbCNPJContratador.Enabled = False

        If String.IsNullOrWhiteSpace(codigoEstabelecimento) Then Return

        Try
            Dim formas As DataTable = CnesFirebird.ConsultarFormasContratacaoEmpregador(codigoEstabelecimento)
            cbcbFormaContratoEmpregCadastro.DataSource = formas
            cbcbFormaContratoEmpregCadastro.DisplayMember = "DESCRICAO"
            cbcbFormaContratoEmpregCadastro.ValueMember = "CODIGO"
            cbcbFormaContratoEmpregCadastro.SelectedIndex = -1
        Catch ex As Exception
            cbcbFormaContratoEmpregCadastro.DataSource = Nothing
            MostrarErroCNES("Não foi possível carregar os vínculos do CNES.", ex)
        End Try
    End Sub

    Private Sub CarregarDetalhamentosVinculo()
        Dim codigoEstabelecimento As String = ValorComboSelecionado(cbFormaContratoEstabCadastro)
        Dim codigoEmpregador As String = ValorComboSelecionado(cbcbFormaContratoEmpregCadastro)

        cbDetalhamentoCadastro.DataSource = Nothing
        tbCNPJContratador.Clear()
        tbCNPJContratador.Enabled = False

        If String.IsNullOrWhiteSpace(codigoEstabelecimento) OrElse
           String.IsNullOrWhiteSpace(codigoEmpregador) Then Return

        Try
            Dim detalhamentos As DataTable =
                CnesFirebird.ConsultarDetalhamentosVinculo(codigoEstabelecimento, codigoEmpregador)
            cbDetalhamentoCadastro.DataSource = detalhamentos
            cbDetalhamentoCadastro.DisplayMember = "DESCRICAO"
            cbDetalhamentoCadastro.ValueMember = "CODIGO"
            cbDetalhamentoCadastro.SelectedIndex = -1
        Catch ex As Exception
            cbDetalhamentoCadastro.DataSource = Nothing
            MostrarErroCNES("Não foi possível carregar os detalhamentos do vínculo.", ex)
        End Try
    End Sub

    Private Sub cbFormaContratoEstabCadastro_SelectionChangeCommitted(sender As Object, e As EventArgs) _
        Handles cbFormaContratoEstabCadastro.SelectionChangeCommitted
        If carregandoTela Then Return
        CarregarFormasContratacaoEmpregador()
    End Sub

    Private Sub cbcbFormaContratoEmpregCadastro_SelectionChangeCommitted(sender As Object, e As EventArgs) _
        Handles cbcbFormaContratoEmpregCadastro.SelectionChangeCommitted
        If carregandoTela Then Return
        CarregarDetalhamentosVinculo()
    End Sub

    Private Sub cbDetalhamentoCadastro_SelectionChangeCommitted(sender As Object, e As EventArgs) _
        Handles cbDetalhamentoCadastro.SelectionChangeCommitted
        AtualizarObrigatoriedadeCNPJ()
    End Sub

    Private Sub AtualizarObrigatoriedadeCNPJ()
        Dim item As DataRowView = TryCast(cbDetalhamentoCadastro.SelectedItem, DataRowView)
        Dim exigeCnpj As Boolean = False

        If item IsNot Nothing AndAlso item.Row.Table.Columns.Contains("SOLICITA_CNPJ") Then
            exigeCnpj = String.Equals(Convert.ToString(item.Row("SOLICITA_CNPJ")).Trim(),
                                      "S", StringComparison.OrdinalIgnoreCase)
        End If

        tbCNPJContratador.Enabled = exigeCnpj
        If Not exigeCnpj Then tbCNPJContratador.Clear()
    End Sub

    Private Sub dgvVinculos_SelectionChanged(sender As Object, e As EventArgs) _
        Handles dgvVinculos.SelectionChanged
        If carregandoTela Then Return
        PreencherCamposVinculoSelecionado()
    End Sub

    Private Sub PreencherCamposVinculoSelecionado()
        If dgvVinculos.CurrentRow Is Nothing OrElse dgvVinculos.CurrentRow.IsNewRow Then
            LimparCamposVinculo()
            Return
        End If

        Dim linha As DataGridViewRow = dgvVinculos.CurrentRow
        carregandoTela = True
        Try
            Dim cnes As String = ValorLinha(linha, "CNES")
            tbCNES.Text = cnes
            SelecionarComboPorValor(cbEstabelecimento, ValorLinha(linha, "UNIDADE_ID"))
            'Mantemos o CNES no campo também para facilitar a conferência do
            'relacionamento entre o vínculo e o estabelecimento.
            tbCNES.Text = cnes
            SelecionarComboPorPrefixo(cbCBO, ValorLinha(linha, "COD_CBO"))
            nudOutro.Value = ValorNumerico(linha, "CARGA_HORARIA_OUTRA")
            nudAmb.Value = ValorNumerico(linha, "CARGA_HORARIA_AMBULATORIAL")
            nudHosp.Value = ValorNumerico(linha, "CARGA_HORARIA_HOSPITALAR")

            Dim tipoSus As String = ValorLinha(linha, "TIPO_SUS").ToUpperInvariant()
            rbSUSSim.Checked = tipoSus = "S"
            rbSUSNao.Checked = Not rbSUSSim.Checked

            PreencherCombosContrato(ValorLinha(linha, "CODIGO_VINCULO"))
            TextBox1.Clear()
            cbUF.SelectedIndex = -1
            tbConselho.Clear()
            tbCNPJContratador.Text = FormatarCNPJ(ValorLinha(linha, "CNPJ_INTERMEDIADOR"))
            AtualizarObrigatoriedadeCNPJ()
        Finally
            carregandoTela = False
        End Try

        AtualizarEstadoBotoes(True, True)
    End Sub

    Private Sub PreencherCombosContrato(codigo As String)
        If String.IsNullOrWhiteSpace(codigo) OrElse codigo.Length < 6 Then
            cbFormaContratoEstabCadastro.SelectedIndex = -1
            cbcbFormaContratoEmpregCadastro.DataSource = Nothing
            cbDetalhamentoCadastro.DataSource = Nothing
            Return
        End If

        SelecionarComboPorValor(cbFormaContratoEstabCadastro, codigo.Substring(0, 2))
        If String.IsNullOrWhiteSpace(ValorComboSelecionado(cbFormaContratoEstabCadastro)) Then Return

        CarregarFormasContratacaoEmpregador()
        SelecionarComboPorValor(cbcbFormaContratoEmpregCadastro, codigo.Substring(2, 2))
        If String.IsNullOrWhiteSpace(ValorComboSelecionado(cbcbFormaContratoEmpregCadastro)) Then Return

        CarregarDetalhamentosVinculo()
        SelecionarComboPorValor(cbDetalhamentoCadastro, codigo)
        AtualizarObrigatoriedadeCNPJ()
    End Sub

    Private Sub cbEstabelecimento_SelectedValueChanged(sender As Object, e As EventArgs) _
        Handles cbEstabelecimento.SelectedValueChanged
        Dim item As DataRowView = TryCast(cbEstabelecimento.SelectedItem, DataRowView)
        If item IsNot Nothing AndAlso item.Row.Table.Columns.Contains("CNES") Then
            tbCNES.Text = Convert.ToString(item.Row("CNES")).Trim()
        ElseIf cbEstabelecimento.SelectedValue IsNot Nothing Then
            tbCNES.Text = Convert.ToString(cbEstabelecimento.SelectedValue)
        End If
    End Sub

    Private Sub ConfigurarGridProfissionais()
        dgvProfissionais.AutoGenerateColumns = True
        dgvProfissionais.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        dgvProfissionais.ScrollBars = ScrollBars.Both
        dgvProfissionais.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvProfissionais.MultiSelect = False

        OcultarColuna(dgvProfissionais, "PROFISSIONAL_ID")
        ConfigurarColuna(dgvProfissionais, "CPF", "CPF", 105, True)
        ConfigurarColuna(dgvProfissionais, "CNS", "CNS", 135, True)
        ConfigurarColuna(dgvProfissionais, "NOME", "Nome", 300, True)
        ConfigurarColuna(dgvProfissionais, "NASCIMENTO", "Nascimento", 90, True)
        If dgvProfissionais.Columns.Contains("NASCIMENTO") Then
            dgvProfissionais.Columns("NASCIMENTO").DefaultCellStyle.Format = "dd/MM/yyyy"
        End If
    End Sub

    Private Sub ConfigurarGridVinculos()
        dgvVinculos.AutoGenerateColumns = True
        dgvVinculos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        dgvVinculos.ScrollBars = ScrollBars.Both
        dgvVinculos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvVinculos.MultiSelect = False

        For Each coluna As String In New String() {
            "UNIDADE_ID", "COD_CBO", "RAZAO_SOCIAL", "TIPO_SUS", "CODIGO_VINCULO",
            "CNPJ_INTERMEDIADOR",
            "TP_PRECEPTOR", "TP_RESIDENTE", "STATUS_VINCULO", "STATUSMOV_VINCULO",
            "CHECKSUM_VINCULO"}
            OcultarColuna(dgvVinculos, coluna)
        Next

        ConfigurarColuna(dgvVinculos, "CNES", "CNES", 75, True)
        ConfigurarColuna(dgvVinculos, "ESTABELECIMENTO", "Estabelecimento", 180, True)
        ConfigurarColuna(dgvVinculos, "DESCRICAO_CBO", "CBO", 220, True)
        ConfigurarColuna(dgvVinculos, "CARGA_HORARIA_OUTRA", "CH outra", 65, True)
        ConfigurarColuna(dgvVinculos, "CARGA_HORARIA_AMBULATORIAL", "CH amb.", 65, True)
        ConfigurarColuna(dgvVinculos, "CARGA_HORARIA_HOSPITALAR", "CH hosp.", 65, True)
        ConfigurarColuna(dgvVinculos, "TIPO_VINCULO", "Vínculo", 260, True)
    End Sub

    Private Sub ConfigurarColuna(grid As DataGridView, nome As String, cabecalho As String,
                                 largura As Integer, visivel As Boolean)
        If Not grid.Columns.Contains(nome) Then Return
        Dim coluna As DataGridViewColumn = grid.Columns(nome)
        coluna.HeaderText = cabecalho
        coluna.Width = largura
        coluna.Visible = visivel
    End Sub

    Private Sub OcultarColuna(grid As DataGridView, nome As String)
        If grid.Columns.Contains(nome) Then grid.Columns(nome).Visible = False
    End Sub

    Private Sub AdicionarDescricoesVinculo(dados As DataTable)
        If dados Is Nothing Then Return
        If Not dados.Columns.Contains("TIPO_VINCULO") Then dados.Columns.Add("TIPO_VINCULO", GetType(String))
        For Each linha As DataRow In dados.Rows
            linha("TIPO_VINCULO") = DescricaoVinculo(ConversaoTexto(linha, "CODIGO_VINCULO"))
        Next
    End Sub

    Private Shared Function DescricaoVinculo(codigo As String) As String
        Select Case codigo.Trim()
            Case "010101" : Return "VÍNCULO EMPREGATÍCIO / ESTATUTÁRIO EFETIVO / SERVIDOR PRÓPRIO"
            Case "010102" : Return "VÍNCULO EMPREGATÍCIO / ESTATUTÁRIO EFETIVO / SERVIDOR CEDIDO"
            Case "010202" : Return "VÍNCULO EMPREGATÍCIO / EMPREGADO PÚBLICO CELETISTA / PRÓPRIO"
            Case "010301" : Return "VÍNCULO EMPREGATÍCIO / CONTRATADO TEMPORÁRIO / PÚBLICO"
            Case "010302" : Return "VÍNCULO EMPREGATÍCIO / CONTRATADO TEMPORÁRIO / PRIVADO"
            Case "010403" : Return "VÍNCULO EMPREGATÍCIO / CARGO COMISSIONADO / SERVIDOR PÚBLICO PRÓPRIO"
            Case "010500" : Return "VÍNCULO EMPREGATÍCIO / CELETISTA / NÃO SE APLICA"
            Case "020900" : Return "AUTÔNOMO / PESSOA JURÍDICA / NÃO SE APLICA"
            Case "021000" : Return "AUTÔNOMO / PESSOA FÍSICA / NÃO SE APLICA"
            Case "070101" : Return "BOLSA / BOLSISTA / PRÓPRIO"
            Case "080100" : Return "INTERMEDIADO / EMPREGADO PÚBLICO CELETISTA / NÃO SE APLICA"
            Case "080200" : Return "INTERMEDIADO / CONTRATADO TEMPORÁRIO / NÃO SE APLICA"
            Case "080300" : Return "INTERMEDIADO / CARGO COMISSIONADO / NÃO SE APLICA"
            Case "080400" : Return "INTERMEDIADO / CELETISTA / NÃO SE APLICA"
            Case "080501" : Return "INTERMEDIADO / AUTÔNOMO / PESSOA JURÍDICA"
            Case "080502" : Return "INTERMEDIADO / AUTÔNOMO / PESSOA FÍSICA"
            Case "090100" : Return "INFORMAL / CONTRATADO VERBALMENTE / NÃO SE APLICA"
            Case "090200" : Return "INFORMAL / VOLUNTARIADO / NÃO SE APLICA"
            Case Else : Return codigo
        End Select
    End Function

    Private Sub SelecionarComboPorValor(combo As ComboBox, valor As String)
        If String.IsNullOrWhiteSpace(valor) Then
            combo.SelectedIndex = -1
            Return
        End If

        For indice As Integer = 0 To combo.Items.Count - 1
            If String.Equals(ObterChaveItemCombo(combo, indice).Trim(), valor.Trim(),
                             StringComparison.OrdinalIgnoreCase) Then
                combo.SelectedIndex = indice
                Return
            End If
        Next

        combo.SelectedIndex = -1
    End Sub

    Private Shared Function ValorComboSelecionado(combo As ComboBox) As String
        If combo Is Nothing OrElse combo.SelectedIndex < 0 Then Return String.Empty

        Dim item As DataRowView = TryCast(combo.SelectedItem, DataRowView)
        If item IsNot Nothing AndAlso
           Not String.IsNullOrWhiteSpace(combo.ValueMember) AndAlso
           item.Row.Table.Columns.Contains(combo.ValueMember) Then
            Return Convert.ToString(item.Row(combo.ValueMember)).Trim()
        End If

        If combo.SelectedValue Is Nothing OrElse combo.SelectedValue Is DBNull.Value Then
            Return String.Empty
        End If

        Return Convert.ToString(combo.SelectedValue).Trim()
    End Function

    Private Sub SelecionarComboPorPrefixo(combo As ComboBox, prefixo As String)
        If String.IsNullOrWhiteSpace(prefixo) Then
            combo.SelectedIndex = -1
            Return
        End If

        For indice As Integer = 0 To combo.Items.Count - 1
            If ObterChaveItemCombo(combo, indice).Trim().StartsWith(prefixo.Trim(),
                                                                      StringComparison.OrdinalIgnoreCase) Then
                combo.SelectedIndex = indice
                Return
            End If
        Next

        combo.SelectedIndex = -1
    End Sub

    Private Shared Function ObterChaveItemCombo(combo As ComboBox, indice As Integer) As String
        If combo Is Nothing OrElse indice < 0 OrElse indice >= combo.Items.Count Then Return String.Empty

        Dim item As Object = combo.Items(indice)
        If item Is Nothing Then Return String.Empty

        Dim itemLinha As DataRowView = TryCast(item, DataRowView)
        If itemLinha IsNot Nothing AndAlso
           Not String.IsNullOrWhiteSpace(combo.ValueMember) AndAlso
           itemLinha.Row.Table.Columns.Contains(combo.ValueMember) Then
            Return Convert.ToString(itemLinha.Row(combo.ValueMember))
        End If

        'Quando a fonte é um Dictionary, cada item é um KeyValuePair. A chave
        'é o código do CNES, CBO ou vínculo; o valor é apenas a descrição.
        Dim propriedadeChave = item.GetType().GetProperty("Key")
        If propriedadeChave IsNot Nothing Then
            Return Convert.ToString(propriedadeChave.GetValue(item, Nothing))
        End If

        Return Convert.ToString(item)
    End Function

    Private Sub LimparResultadosBusca()
        carregandoTela = True
        Try
            dgvProfissionais.DataSource = Nothing
            dgvVinculos.DataSource = Nothing
            profissionalIdSelecionado = String.Empty
            LimparCamposVinculo()
        Finally
            carregandoTela = False
        End Try
    End Sub

    Private Sub LimparCamposVinculo()
        tbCNES.Clear()
        cbEstabelecimento.SelectedIndex = -1
        cbCBO.SelectedIndex = -1
        nudOutro.Value = 0
        nudAmb.Value = 0
        nudHosp.Value = 0
        rbSUSSim.Checked = True
        rbSUSNao.Checked = False
        cbFormaContratoEstabCadastro.SelectedIndex = -1
        cbcbFormaContratoEmpregCadastro.DataSource = Nothing
        cbDetalhamentoCadastro.DataSource = Nothing
        TextBox1.Clear()
        cbUF.SelectedIndex = -1
        tbConselho.Clear()
        tbCNPJContratador.Clear()
        tbCNPJContratador.Enabled = False
    End Sub

    Private Shared Function SomenteDigitos(valor As String) As String
        If valor Is Nothing Then Return String.Empty
        Return New String(valor.Where(Function(caractere) Char.IsDigit(caractere)).ToArray())
    End Function

    Private Shared Function FormatarCPF(valor As String) As String
        Dim cpf As String = SomenteDigitos(valor)
        If cpf.Length <> 11 Then Return valor
        Return cpf.Substring(0, 3) & "." & cpf.Substring(3, 3) & "." &
               cpf.Substring(6, 3) & "-" & cpf.Substring(9, 2)
    End Function

    Private Shared Function FormatarCNS(valor As String) As String
        Dim cns As String = SomenteDigitos(valor)
        If cns.Length <> 15 Then Return valor
        Return cns.Substring(0, 4) & "," & cns.Substring(4, 4) & "," &
               cns.Substring(8, 4) & "," & cns.Substring(12, 3)
    End Function

    Private Shared Function ValorLinha(linha As DataGridViewRow, coluna As String) As String
        If linha Is Nothing OrElse linha.DataGridView Is Nothing OrElse
           Not linha.DataGridView.Columns.Contains(coluna) Then Return String.Empty
        Return If(linha.Cells(coluna).Value Is Nothing OrElse linha.Cells(coluna).Value Is DBNull.Value,
                  String.Empty,
                  linha.Cells(coluna).Value.ToString().Trim())
    End Function

    Private Shared Function ConversaoTexto(linha As DataRow, coluna As String) As String
        If linha Is Nothing OrElse Not linha.Table.Columns.Contains(coluna) OrElse linha.IsNull(coluna) Then
            Return String.Empty
        End If
        Return linha(coluna).ToString().Trim()
    End Function

    Private Shared Function ValorNumerico(linha As DataGridViewRow, coluna As String) As Decimal
        Dim valor As Decimal
        If Decimal.TryParse(ValorLinha(linha, coluna), valor) Then
            Return Math.Max(0D, Math.Min(168D, valor))
        End If
        Return 0D
    End Function

    Private Sub MostrarErroCNES(contexto As String, ex As Exception)
        Dim mensagem As String = ex.Message
        If ex.InnerException IsNot Nothing Then mensagem &= Environment.NewLine & ex.InnerException.Message
        MessageBox.Show(contexto & Environment.NewLine & Environment.NewLine & mensagem,
                        "CNES - Firebird", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Private Sub AtualizarEstadoBotoes(profissionalSelecionado As Boolean,
                                      vinculoSelecionado As Boolean)
        btSalvar.Enabled = Not profissionalSelecionado
        btAtualizar.Enabled = profissionalSelecionado
        btExcluir.Enabled = profissionalSelecionado
        btSalvarVinculo.Enabled = profissionalSelecionado
        btAtualizarVinculo.Enabled = vinculoSelecionado
        btExcluirVinculo.Enabled = vinculoSelecionado
    End Sub

    Private Sub btNovo_Click(sender As Object, e As EventArgs) Handles btNovo.Click
        carregandoTela = True
        Try
            profissionalIdSelecionado = String.Empty
            campoBuscaAtivo = String.Empty
            TextBoxCPFCadastro.Clear()
            TextBoxNomeCadastro.Clear()
            txtCnsCadastro.Clear()
            dtNascimento.Clear()
            dgvProfissionais.DataSource = Nothing
            dgvVinculos.DataSource = Nothing
            LimparCamposVinculo()
            AtualizarEstadoBotoes(False, False)
        Finally
            carregandoTela = False
        End Try
        TextBoxCPFCadastro.Focus()
    End Sub

    Private Sub btSalvar_Click(sender As Object, e As EventArgs) Handles btSalvar.Click
        If Not ValidarProfissionalFormulario() Then Return
        If Not String.IsNullOrWhiteSpace(profissionalIdSelecionado) Then
            MessageBox.Show("O profissional selecionado está em modo de atualização. Use o botão Atualizar.",
                            "CNES", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Dim id As String = CnesFirebird.CadastrarProfissionalCadastro(
                SomenteDigitos(TextBoxCPFCadastro.Text), TextBoxNomeCadastro.Text,
                ObterDataNascimentoFormulario(), SomenteDigitos(txtCnsCadastro.Text),
                ObterUsuarioCNES())
            profissionalIdSelecionado = id
            campoBuscaAtivo = "CPF"
            MessageBox.Show("Profissional cadastrado com sucesso. Agora é possível adicionar os vínculos.",
                            "CNES", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BuscarProfissionais()
            profissionalIdSelecionado = id
            AtualizarEstadoBotoes(True, False)
        Catch ex As Exception
            MostrarErroCNES("Não foi possível cadastrar o profissional.", ex)
        End Try
    End Sub

    Private Sub btAtualizar_Click(sender As Object, e As EventArgs) Handles btAtualizar.Click
        If String.IsNullOrWhiteSpace(profissionalIdSelecionado) Then
            MessageBox.Show("Selecione um profissional no grid para atualizar.",
                            "CNES", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If Not ValidarProfissionalFormulario() Then Return

        Try
            CnesFirebird.AtualizarProfissionalCadastro(
                profissionalIdSelecionado, TextBoxNomeCadastro.Text,
                ObterDataNascimentoFormulario(), SomenteDigitos(txtCnsCadastro.Text),
                ObterUsuarioCNES())
            MessageBox.Show("Profissional atualizado com sucesso.",
                            "CNES", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BuscarProfissionais()
            profissionalIdSelecionado = String.Empty
            AtualizarEstadoBotoes(False, False)
        Catch ex As Exception
            MostrarErroCNES("Não foi possível atualizar o profissional.", ex)
        End Try
    End Sub

    Private Sub btExcluir_Click(sender As Object, e As EventArgs) Handles btExcluir.Click
        If String.IsNullOrWhiteSpace(profissionalIdSelecionado) Then
            MessageBox.Show("Selecione um profissional no grid para excluir.",
                            "CNES", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim resposta = MessageBox.Show(
            "O profissional e seus vínculos serão inativados e deixarão de aparecer nos registros ativos. Deseja continuar?",
            "Inativar profissional", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If resposta <> DialogResult.Yes Then Return

        Try
            CnesFirebird.InativarProfissional(profissionalIdSelecionado, ObterUsuarioCNES())
            MessageBox.Show("Profissional inativado com sucesso.",
                            "CNES", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btNovo.PerformClick()
        Catch ex As Exception
            MostrarErroCNES("Não foi possível inativar o profissional.", ex)
        End Try
    End Sub

    Private Sub btSalvarVinculo_Click(sender As Object, e As EventArgs) Handles btSalvarVinculo.Click
        If String.IsNullOrWhiteSpace(profissionalIdSelecionado) Then
            MessageBox.Show("Salve ou selecione um profissional antes de adicionar um vínculo.",
                            "CNES", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim dados As VinculoFormulario = Nothing
        If Not TentarObterVinculoFormulario(dados) Then Return

        Try
            CnesFirebird.CadastrarVinculo(
                profissionalIdSelecionado, dados.Cnes, dados.CodigoCbo, dados.CodigoVinculo,
                dados.CargaAmbulatorial, dados.CargaOutra, dados.CargaHospitalar,
                dados.TipoSus, dados.Cnpj, ObterUsuarioCNES())
            MessageBox.Show("Vínculo adicionado com sucesso.",
                            "CNES", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CarregarVinculos(profissionalIdSelecionado)
        Catch ex As Exception
            MostrarErroCNES("Não foi possível adicionar o vínculo.", ex)
        End Try
    End Sub

    Private Sub btAtualizarVinculo_Click(sender As Object, e As EventArgs) Handles btAtualizarVinculo.Click
        If String.IsNullOrWhiteSpace(profissionalIdSelecionado) OrElse dgvVinculos.CurrentRow Is Nothing Then
            MessageBox.Show("Selecione um vínculo no grid para atualizar.",
                            "CNES", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim dados As VinculoFormulario = Nothing
        If Not TentarObterVinculoFormulario(dados) Then Return
        Dim linha As DataGridViewRow = dgvVinculos.CurrentRow

        Try
            CnesFirebird.AtualizarVinculo(
                profissionalIdSelecionado, ValorLinha(linha, "UNIDADE_ID"),
                ValorLinha(linha, "COD_CBO"), ValorLinha(linha, "TIPO_SUS"),
                ValorLinha(linha, "CODIGO_VINCULO"), dados.Cnes, dados.CodigoCbo,
                dados.CodigoVinculo, dados.CargaAmbulatorial, dados.CargaOutra,
                dados.CargaHospitalar, dados.TipoSus, dados.Cnpj, ObterUsuarioCNES())
            MessageBox.Show("Vínculo atualizado com sucesso.",
                            "CNES", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CarregarVinculos(profissionalIdSelecionado)
        Catch ex As Exception
            MostrarErroCNES("Não foi possível atualizar o vínculo.", ex)
        End Try
    End Sub

    Private Sub btExcluirVinculo_Click(sender As Object, e As EventArgs) Handles btExcluirVinculo.Click
        If String.IsNullOrWhiteSpace(profissionalIdSelecionado) OrElse dgvVinculos.CurrentRow Is Nothing Then
            MessageBox.Show("Selecione um vínculo no grid para excluir.",
                            "CNES", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim resposta = MessageBox.Show(
            "O vínculo será inativado e deixará de aparecer nos registros ativos. Deseja continuar?",
            "Inativar vínculo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If resposta <> DialogResult.Yes Then Return

        Dim linha As DataGridViewRow = dgvVinculos.CurrentRow
        Try
            CnesFirebird.InativarVinculo(
                profissionalIdSelecionado, ValorLinha(linha, "UNIDADE_ID"),
                ValorLinha(linha, "COD_CBO"), ValorLinha(linha, "TIPO_SUS"),
                ValorLinha(linha, "CODIGO_VINCULO"), ObterUsuarioCNES())
            MessageBox.Show("Vínculo inativado com sucesso.",
                            "CNES", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CarregarVinculos(profissionalIdSelecionado)
        Catch ex As Exception
            MostrarErroCNES("Não foi possível inativar o vínculo.", ex)
        End Try
    End Sub

    Private Function ValidarProfissionalFormulario() As Boolean
        If SomenteDigitos(TextBoxCPFCadastro.Text).Length <> 11 Then
            MessageBox.Show("Informe um CPF com 11 dígitos.", "CNES", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBoxCPFCadastro.Focus()
            Return False
        End If
        If String.IsNullOrWhiteSpace(TextBoxNomeCadastro.Text) Then
            MessageBox.Show("Informe o nome do profissional.", "CNES", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBoxNomeCadastro.Focus()
            Return False
        End If

        Try
            ObterDataNascimentoFormulario()
            Dim cns As String = SomenteDigitos(txtCnsCadastro.Text)
            If cns.Length <> 0 AndAlso cns.Length <> 15 Then Throw New ArgumentException("O CNS deve conter 15 dígitos.")
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "CNES", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End Try
    End Function

    Private Function ObterDataNascimentoFormulario() As Nullable(Of DateTime)
        Dim texto As String = dtNascimento.Text.Replace("/", String.Empty).Trim()
        If texto.Length = 0 Then Return Nothing

        Dim data As DateTime
        If Not DateTime.TryParseExact(dtNascimento.Text.Trim(), "dd/MM/yyyy",
                                      Globalization.CultureInfo.InvariantCulture,
                                      Globalization.DateTimeStyles.None, data) Then
            Throw New ArgumentException("Informe uma data de nascimento válida.")
        End If
        If data.Date > DateTime.Today Then Throw New ArgumentException("A data de nascimento não pode ser futura.")
        Return data.Date
    End Function

    Private Function TentarObterVinculoFormulario(ByRef dados As VinculoFormulario) As Boolean
        Try
            dados = New VinculoFormulario()
            dados.Cnes = tbCNES.Text.Trim()
            dados.CodigoCbo = ValorComboSelecionado(cbCBO)
            dados.CodigoVinculo = ValorComboSelecionado(cbDetalhamentoCadastro)
            dados.TipoSus = If(rbSUSSim.Checked, "S", "N")
            dados.Cnpj = SomenteDigitos(tbCNPJContratador.Text)
            dados.CargaAmbulatorial = Convert.ToInt32(nudAmb.Value)
            dados.CargaOutra = Convert.ToInt32(nudOutro.Value)
            dados.CargaHospitalar = Convert.ToInt32(nudHosp.Value)

            If String.IsNullOrWhiteSpace(dados.Cnes) Then Throw New ArgumentException("Selecione o estabelecimento.")
            If String.IsNullOrWhiteSpace(dados.CodigoCbo) Then Throw New ArgumentException("Selecione o CBO.")
            If String.IsNullOrWhiteSpace(dados.CodigoVinculo) Then Throw New ArgumentException("Selecione o detalhamento do vínculo.")
            If tbCNPJContratador.Enabled AndAlso dados.Cnpj.Length <> 14 Then
                Throw New ArgumentException("Informe um CNPJ válido para o vínculo selecionado.")
            End If
            If dados.Cnpj.Length <> 0 AndAlso dados.Cnpj.Length <> 14 Then
                Throw New ArgumentException("O CNPJ deve conter 14 dígitos.")
            End If
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "CNES", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End Try
    End Function

    Private Function ObterUsuarioCNES() As String
        Return Environment.UserName.ToUpperInvariant()
    End Function

    Private Shared Function FormatarCNPJ(valor As String) As String
        Dim cnpj As String = SomenteDigitos(valor)
        If cnpj.Length <> 14 Then Return valor
        Return cnpj.Substring(0, 2) & "." & cnpj.Substring(2, 3) & "." &
               cnpj.Substring(5, 3) & "/" & cnpj.Substring(8, 4) & "-" & cnpj.Substring(12, 2)
    End Function

    Private Class VinculoFormulario
        Public Property Cnes As String
        Public Property CodigoCbo As String
        Public Property CodigoVinculo As String
        Public Property TipoSus As String
        Public Property Cnpj As String
        Public Property CargaAmbulatorial As Integer
        Public Property CargaOutra As Integer
        Public Property CargaHospitalar As Integer
    End Class

End Class
