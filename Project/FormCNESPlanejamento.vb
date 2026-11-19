Imports System.IO
Imports System.Net
Imports com.itextpdf.text.pdf

Public Class FormCNESPlanejamento
    Dim pdf As New PDF
    Dim profs As DataTable
    Dim arrayOfMedicos As Array
    Dim columnIndex As Integer
    Dim main As New Main
    Private firebirdDisponivel As Boolean
    Private firebirdErro As String = String.Empty
    Private formatandoCPF As Boolean
    Private carregandoFonte As Boolean

    Private Sub FplanejCNES_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim versao As Version = GetType(FormCNESPlanejamento).Assembly.GetName().Version
        Me.Text = "CNES - Planejamento - v" & versao.ToString(3)

        InicializarFonteCNES()

        clearLabels()

        firebirdDisponivel = CnesFirebird.TestarConexao(firebirdErro)
        'ImportarPDFToolStripMenuItem.Enabled = False
        'UploadPDFParaServidorToolStripMenuItem.Enabled = False

        If Not firebirdDisponivel Then
            MarcarFirebirdIndisponivel()
            MessageBox.Show("Não foi possível conectar ao banco CNES Firebird." &
                            Environment.NewLine & Environment.NewLine &
                            firebirdErro &
                            Environment.NewLine & Environment.NewLine &
                            CnesFirebird.ObterDiagnostico() &
                            Environment.NewLine &
                            "Executável: " & Application.ExecutablePath,
                            "Conexão com o CNES",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
        Else
            CarregarFormasContratacaoEstabelecimento()
            AtualizarStatusFonte()
        End If
    End Sub

    Private Sub CarregarFormasContratacaoEstabelecimento()
        Try
            Dim formas As DataTable = CnesFirebird.ConsultarFormasContratacaoEstabelecimento()
            cbFormaContratoEstab.DataSource = formas
            cbFormaContratoEstab.DisplayMember = "DESCRICAO"
            cbFormaContratoEstab.ValueMember = "CODIGO"
            cbFormaContratoEstab.SelectedIndex = -1

            cbcbFormaContratoEmpreg.DataSource = Nothing
            cbDetalhamento.DataSource = Nothing
            cbcbFormaContratoEmpreg.SelectedIndex = -1
            cbDetalhamento.SelectedIndex = -1
        Catch ex As Exception
            firebirdErro = ex.Message
            MarcarFirebirdIndisponivel()
        End Try
    End Sub

    Private Sub CarregarFormasContratacaoEmpregador(codigoEstabelecimento As String)
        Try
            Dim formas As DataTable = CnesFirebird.ConsultarFormasContratacaoEmpregador(codigoEstabelecimento)
            cbcbFormaContratoEmpreg.DataSource = formas
            cbcbFormaContratoEmpreg.DisplayMember = "DESCRICAO"
            cbcbFormaContratoEmpreg.ValueMember = "CODIGO"
            cbcbFormaContratoEmpreg.SelectedIndex = -1

            cbDetalhamento.DataSource = Nothing
            cbDetalhamento.SelectedIndex = -1
        Catch ex As Exception
            firebirdErro = ex.Message
            MarcarFirebirdIndisponivel()
        End Try
    End Sub

    Private Sub CarregarDetalhamentosVinculo(codigoEstabelecimento As String, codigoEmpregador As String)
        Try
            Dim detalhamentos As DataTable =
                CnesFirebird.ConsultarDetalhamentosVinculo(codigoEstabelecimento, codigoEmpregador)
            cbDetalhamento.DataSource = detalhamentos
            cbDetalhamento.DisplayMember = "DESCRICAO"
            cbDetalhamento.ValueMember = "CODIGO"
            cbDetalhamento.SelectedIndex = -1
        Catch ex As Exception
            firebirdErro = ex.Message
            MarcarFirebirdIndisponivel()
        End Try
    End Sub

    Private Function TipoFonteNormalizado() As String
        If String.Equals(My.Settings.tipoFonte, "Remoto", StringComparison.OrdinalIgnoreCase) Then
            Return "Remoto"
        End If

        Return "Local"
    End Function

    Private Function ObterIpFonte(tipoFonte As String) As String
        If String.Equals(tipoFonte, "Remoto", StringComparison.OrdinalIgnoreCase) Then
            Return My.Settings.ipRemoto
        End If

        Return My.Settings.ipLocal
    End Function

    Private Sub InicializarFonteCNES()
        carregandoFonte = True
        Try
            Dim tipoFonte As String = TipoFonteNormalizado()
            tstBancoRemoto.SelectedItem = tipoFonte

            If String.IsNullOrWhiteSpace(My.Settings.tipoFonte) Then
                My.Settings.tipoFonte = tipoFonte
                My.Settings.Save()
            End If
        Finally
            carregandoFonte = False
        End Try
    End Sub

    Private Function EnderecoFonteValido(valor As String) As Boolean
        If String.IsNullOrWhiteSpace(valor) Then Return False

        'Aceita IP ou nome de máquina, evitando bloquear instalações que usem
        'DNS/hostname em vez de um endereço IPv4 literal.
        Return System.Text.RegularExpressions.Regex.IsMatch(
            valor.Trim(),
            "^[A-Za-z0-9][A-Za-z0-9.-]*$"
        )
    End Function

    Private Sub tstBancoRemoto_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles tstBancoRemoto.SelectedIndexChanged

        If carregandoFonte OrElse tstBancoRemoto.SelectedIndex < 0 Then Return

        Dim tipoAnterior As String = TipoFonteNormalizado()
        Dim tipoNovo As String = If(String.Equals(Convert.ToString(tstBancoRemoto.SelectedItem), "Remoto", StringComparison.OrdinalIgnoreCase),
                                    "Remoto",
                                    "Local")
        Dim ipAtual As String = ObterIpFonte(tipoNovo)
        Dim descricao As String = If(tipoNovo = "Remoto", "remoto", "local")

        Dim ipInformado As String = Microsoft.VisualBasic.Interaction.InputBox(
            "Informe o IP ou nome da máquina do banco CNES " & descricao & ":",
            "Fonte do banco CNES",
            ipAtual)

        If String.IsNullOrWhiteSpace(ipInformado) Then
            carregandoFonte = True
            Try
                tstBancoRemoto.SelectedItem = tipoAnterior
            Finally
                carregandoFonte = False
            End Try
            Return
        End If

        ipInformado = ipInformado.Trim()
        If Not EnderecoFonteValido(ipInformado) Then
            MessageBox.Show("Informe um IP ou nome de máquina válido.",
                            "Fonte do banco CNES",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
            carregandoFonte = True
            Try
                tstBancoRemoto.SelectedItem = tipoAnterior
            Finally
                carregandoFonte = False
            End Try
            Return
        End If

        If tipoNovo = "Remoto" Then
            My.Settings.ipRemoto = ipInformado
        Else
            My.Settings.ipLocal = ipInformado
        End If

        My.Settings.tipoFonte = tipoNovo
        My.Settings.Save()

        firebirdErro = String.Empty
        firebirdDisponivel = CnesFirebird.TestarConexao(firebirdErro)
        If firebirdDisponivel Then
            AtualizarStatusFonte()
            CarregarFormasContratacaoEstabelecimento()
        Else
            MarcarFirebirdIndisponivel()
            MessageBox.Show("A fonte foi salva, mas o banco CNES não está acessível." &
                            Environment.NewLine & Environment.NewLine &
                            firebirdErro,
                            "Conexão com o CNES",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub AtualizarStatusFonte(Optional quantidade As Integer = -1)
        If Not firebirdDisponivel Then
            If String.IsNullOrWhiteSpace(firebirdErro) Then
                ToolStripStatusLabel1.Text = "Fonte: Firebird indisponível"
            Else
                ToolStripStatusLabel1.Text = "Firebird indisponível: " & firebirdErro
            End If
            Return
        End If

        Dim fonte As String = "Firebird (" & TipoFonteNormalizado() & ")"
        If quantidade >= 0 Then
            ToolStripStatusLabel1.Text = "Fonte: " & fonte & " | Registros: " & quantidade
        Else
            ToolStripStatusLabel1.Text = "Fonte de profissionais: " & fonte
        End If
    End Sub

    Private Sub MarcarFirebirdIndisponivel()
        firebirdDisponivel = False

        If String.IsNullOrWhiteSpace(firebirdErro) Then
            firebirdErro = "O teste de conexão retornou falso sem uma mensagem de exceção."
            ToolStripStatusLabel1.Text = "Firebird indisponível: " & firebirdErro
        Else
            ToolStripStatusLabel1.Text = "Firebird indisponível: " & firebirdErro
        End If
    End Sub

    Private Function ConsultarProfissionaisPorBusca(cpf As String, nome As String) As DataTable
        If firebirdDisponivel Then
            Try
                Return CnesFirebird.ConsultarProfissionais(cpf, nome)
            Catch ex As Exception
                firebirdErro = ex.Message
                MarcarFirebirdIndisponivel()
            End Try
        End If

        Return New DataTable()
    End Function

    Private Function ObterCodigoVinculoCNES() As String
        If cbFormaContratoEstab.SelectedValue Is Nothing OrElse
           cbcbFormaContratoEmpreg.SelectedValue Is Nothing OrElse
           cbDetalhamento.SelectedValue Is Nothing Then
            Return String.Empty
        End If

        Dim parteEstabelecimento As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(Convert.ToString(cbFormaContratoEstab.SelectedValue), "^\d{2}")
        Dim parteEmpregador As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(Convert.ToString(cbcbFormaContratoEmpreg.SelectedValue), "^\d{2}")
        Dim parteDetalhamento As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(Convert.ToString(cbDetalhamento.SelectedValue), "^\d{2}")

        If Not parteEstabelecimento.Success OrElse
           Not parteEmpregador.Success OrElse
           Not parteDetalhamento.Success Then
            Return String.Empty
        End If

        Return parteEstabelecimento.Value & parteEmpregador.Value & parteDetalhamento.Value
    End Function

    Private Sub copyXMLfromServer()
        Try

            If My.Settings.server = "" Then
                FormSystemConnSettings.ShowDialog()
                Exit Sub
            End If

            If Not Directory.Exists(Application.StartupPath & "\PDF") Or Not File.Exists(Application.StartupPath & "\PDF\PROFISSIONAIS.pdf") Then
                Directory.CreateDirectory(Application.StartupPath & "\PDF")

                Dim origem As String = $"http://{My.Settings.server}/Secretaria/CNES/PROFISSIONAIS.pdf"
                Dim destino As String = Application.StartupPath & "\PDF\PROFISSIONAIS.pdf"

                ' Verificar se o arquivo existe no servidor HTTP
                Dim request As HttpWebRequest = CType(WebRequest.Create(origem), HttpWebRequest)
                request.Method = "HEAD"

                Using response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                    If response.StatusCode = HttpStatusCode.OK Then
                        Dim clienteWeb As New WebClient()
                        clienteWeb.DownloadFile(origem, destino)
                        MsgBox("Atualizando arquivo de profissionais...")
                    Else
                        MsgBox("Arquivo não encontrado no servidor.")
                    End If
                End Using
            End If

        Catch ex As Exception
            MessageBox.Show("Erro ao copiar arquivo: " & ex.Message)
        End Try
    End Sub

    Function QuebrarTexto(texto As String, larguraMaxima As Integer, fonte As Font) As List(Of String)
        Dim partes As New List(Of String)
        Dim palavras = texto.Split(" "c)
        Dim linhaAtual As String = String.Empty

        For Each palavra In palavras
            If TextRenderer.MeasureText(linhaAtual & " " & palavra, fonte).Width > larguraMaxima Then
                partes.Add(linhaAtual)
                linhaAtual = palavra
            Else
                linhaAtual &= If(String.IsNullOrEmpty(linhaAtual), "", " ") & palavra
            End If
        Next

        If Not String.IsNullOrEmpty(linhaAtual) Then
            partes.Add(linhaAtual & vbCrLf & vbCrLf)
        End If

        Return partes
    End Function

    Private Sub cbFormaContratoEstab_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFormaContratoEstab.SelectionChangeCommitted
        If Not firebirdDisponivel Then
            AtualizarStatusFonte()
            Return
        End If

        CarregarFormasContratacaoEmpregador(Convert.ToString(cbFormaContratoEstab.SelectedValue))
    End Sub

    Private Sub cbcbFormaContratoEmpreg_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbcbFormaContratoEmpreg.SelectionChangeCommitted
        If Not firebirdDisponivel Then
            AtualizarStatusFonte()
            Return
        End If

        CarregarDetalhamentosVinculo(
            Convert.ToString(cbFormaContratoEstab.SelectedValue),
            Convert.ToString(cbcbFormaContratoEmpreg.SelectedValue))
        dgPlanejamento.DataSource = Nothing
    End Sub

    Private Sub cbDetalhamento_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDetalhamento.SelectionChangeCommitted
        If Not firebirdDisponivel Then
            AtualizarStatusFonte()
            Return
        End If

        Dim gestao = 0
        Dim fc As String = cbFormaContratoEstab.SelectedValue & cbcbFormaContratoEmpreg.SelectedValue & cbDetalhamento.SelectedValue
        If rbPublico.Checked Then
            gestao = 0
        ElseIf rbPrivado.Checked Then
            gestao = 1
        End If

        Dim data As New DataTable()
        If firebirdDisponivel Then
            Try
                data = CnesFirebird.ConsultarProfissionais(codigoVinculo:=ObterCodigoVinculoCNES())
            Catch ex As Exception
                firebirdErro = ex.Message
                MarcarFirebirdIndisponivel()
                Return
            End Try
        End If

        AplicarDescricaoTipoVinculo(data)
        dgPlanejamento.DataSource = data
        datagridConfig(False)

        CBOmedicos(data, gestao)
        CBOenfermeiros(data, gestao)
        CBOacs(data, gestao)
        CBOoutrosNivelSuperior(data, gestao)
        CBOoutrosNivelMedio(data, gestao)

    End Sub

    Private Sub datagridConfig(Optional collumCBOvisible = True)
        Try
            dgPlanejamento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            dgPlanejamento.ScrollBars = ScrollBars.Both

            ConfigurarColuna("CPF", "CPF", 100, True)
            ConfigurarColuna("CNS", "CNS", 125, True)
            ConfigurarColuna("NOME", "Nome", 250, True)
            ConfigurarColuna("CNES", "CNES", 90, True)
            ConfigurarColuna("CBO", "CBO", 70, collumCBOvisible)
            ConfigurarColuna("DESCRICAO_CBO", "Descrição do CBO", 220, True)
            ConfigurarColuna("Descrição", "Descrição", 220, True)
            ConfigurarColuna("NASCIMENTO", "Nascimento", 90, True)
            ConfigurarColuna("CARGA_HORARIA_OUTRA", "Carga outra", 90, True)
            ConfigurarColuna("CARGA_HORARIA_AMBULATORIAL", "Carga amb.", 90, True)
            ConfigurarColuna("CARGA_HORARIA_HOSPITALAR", "Carga hosp.", 90, True)
            ConfigurarColuna("TIPO_SUS", "Tipo SUS", 90, False)
            ConfigurarColuna("TIPO_VINCULO", "Vínculo", 300, True)
            ConfigurarColuna("RAZAO_SOCIAL", "Razão social", 180, False)
            ConfigurarColuna("NOME_FANTASIA", "Estabelecimento", 180, True)
            ConfigurarColuna("PROFISSIONAL_ID", "Profissional ID", 100, False)
            ConfigurarColuna("UNIDADE_ID", "Unidade ID", 100, False)
            AtualizarStatusFonte(dgPlanejamento.Rows.Count)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AplicarDescricaoTipoVinculo(data As DataTable)
        If data Is Nothing OrElse Not data.Columns.Contains("TIPO_VINCULO") Then Return

        For Each linha As DataRow In data.Rows
            If linha.IsNull("TIPO_VINCULO") Then Continue For

            Dim codigo As String = linha("TIPO_VINCULO").ToString().Trim()
            Dim descricao As String = ObterDescricaoVinculoPorCodigo(codigo)

            'Se o registro corresponde à seleção atual, usamos também a
            'descrição dos comboboxes, mantendo a mesma regra da tela.
            If codigo = ObterCodigoVinculoCNES() Then
                Dim descricaoSelecionada As String = ObterDescricaoVinculoSelecionado()
                If Not String.IsNullOrWhiteSpace(descricaoSelecionada) Then
                    descricao = descricaoSelecionada
                End If
            End If

            If Not String.IsNullOrWhiteSpace(descricao) Then
                linha("TIPO_VINCULO") = descricao
            End If
        Next
    End Sub

    Private Function ObterDescricaoVinculoPorCodigo(codigo As String) As String
        Dim descricoes As New Dictionary(Of String, String) From {
            {"010101", "VINCULO EMPREGATICIO / ESTATUTARIO EFETIVO / SERVIDOR PROPRIO"},
            {"010102", "VINCULO EMPREGATICIO / ESTATUTARIO EFETIVO / SERVIDOR CEDIDO"},
            {"010202", "VINCULO EMPREGATICIO / EMPREGADO PUBLICO CELETISTA / PROPRIO"},
            {"010301", "VINCULO EMPREGATICIO / CONTRATADO TEMPORARIO / PUBLICO"},
            {"010302", "VINCULO EMPREGATICIO / CONTRATADO TEMPORARIO / PRIVADO"},
            {"010403", "VINCULO EMPREGATICIO / CARGO COMISSIONADO / SERVIDOR PUBLICO PROPRIO"},
            {"010500", "VINCULO EMPREGATICIO / CELETISTA / NAO SE APLICA"},
            {"020900", "AUTONOMO / PESSOA JURIDICA / NAO SE APLICA"},
            {"021000", "AUTONOMO / PESSOA FISICA / NAO SE APLICA"},
            {"070101", "BOLSA / BOLSISTA / PROPRIO"},
            {"080100", "INTERMEDIADO / EMPREGADO PUBLICO CELETISTA / NAO SE APLICA"},
            {"080200", "INTERMEDIADO / CONTRATADO TEMPORARIO / NAO SE APLICA"},
            {"080300", "INTERMEDIADO / CARGO COMISSIONADO / NAO SE APLICA"},
            {"080400", "INTERMEDIADO / CELETISTA / NAO SE APLICA"},
            {"080501", "INTERMEDIADO / AUTONOMO / PESSOA JURIDICA"},
            {"080502", "INTERMEDIADO / AUTONOMO / PESSOA FISICA"},
            {"090100", "INFORMAL / CONTRATADO VERBALMENTE / NAO SE APLICA"},
            {"090200", "INFORMAL / VOLUNTARIADO / NAO SE APLICA"}
        }

        If descricoes.ContainsKey(codigo) Then Return descricoes(codigo)
        Return codigo
    End Function

    Private Function ObterDescricaoVinculoSelecionado() As String
        Dim partes As New List(Of String)()

        AdicionarParteVinculo(partes, cbFormaContratoEstab)
        AdicionarParteVinculo(partes, cbcbFormaContratoEmpreg)
        AdicionarParteVinculo(partes, cbDetalhamento)

        If partes.Count = 0 Then Return String.Empty
        Return String.Join(" / ", partes.ToArray())
    End Function

    Private Sub AdicionarParteVinculo(partes As List(Of String), combo As ComboBox)
        If combo Is Nothing OrElse combo.SelectedIndex < 0 OrElse String.IsNullOrWhiteSpace(combo.Text) Then Return

        Dim texto As String = combo.Text.Trim()
        Dim separador As Integer = texto.IndexOf("-"c)
        If separador >= 0 AndAlso separador < texto.Length - 1 Then
            texto = texto.Substring(separador + 1).Trim()
        End If

        If Not String.IsNullOrWhiteSpace(texto) Then partes.Add(texto)
    End Sub

    Private Sub ConfigurarColuna(nome As String, cabecalho As String, largura As Integer, visivel As Boolean)
        If Not dgPlanejamento.Columns.Contains(nome) Then Return

        With dgPlanejamento.Columns(nome)
            .HeaderText = cabecalho
            .Width = largura
            .Visible = visivel
        End With
    End Sub

    Private Sub dgPlanejamento_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgPlanejamento.CellFormatting
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return
        If dgPlanejamento.Columns(e.ColumnIndex).Name <> "NASCIMENTO" Then Return

        If e.Value Is Nothing OrElse e.Value Is DBNull.Value OrElse String.IsNullOrWhiteSpace(Convert.ToString(e.Value)) Then
            e.Value = "Não informado"
            e.FormattingApplied = True
        ElseIf TypeOf e.Value Is DateTime Then
            e.Value = DirectCast(e.Value, DateTime).ToString("dd/MM/yyyy")
            e.FormattingApplied = True
        End If
    End Sub

    Private Sub getByCBO(data As DataTable, CBOarray As String(), lbTotal As Label, listBox As ListBox)
        Dim cpfCboDict As New Dictionary(Of String, HashSet(Of Integer))
        Dim cpfList As New HashSet(Of String) ' Lista de CPFs únicos, somente com CBOs válidos
        Dim cboCount As New Dictionary(Of Integer, Integer) ' Contagem global de CBOs válidos

        For Each row As DataRow In data.Rows
            Dim cpf As String = row.Item(0).ToString()
            Dim cbo As Integer = Convert.ToInt32(row.Item(4))

            ' Verificar se o CBO é válido
            If CBOarray.Contains(cbo.ToString()) Then
                ' Adicionar CPF e CBO ao dicionário
                If Not cpfCboDict.ContainsKey(cpf) Then
                    cpfCboDict(cpf) = New HashSet(Of Integer)
                End If

                If Not cpfCboDict(cpf).Contains(cbo) Then
                    cpfCboDict(cpf).Add(cbo)

                    If Not cboCount.ContainsKey(cbo) Then
                        cboCount(cbo) = 0
                    End If
                    cboCount(cbo) += 1
                End If

                ' Adicionar CPF à lista apenas se tiver um CBO válido
                cpfList.Add(cpf)
            Else

            End If
        Next

        Dim total As Integer
        Dim listCBOS As New List(Of String)
        For Each cbo In cboCount.Keys
            Dim descricaoCbo As String = cbo.ToString()
            If data.Columns.Contains("DESCRICAO_CBO") Then
                Dim linhaCbo As DataRow = data.AsEnumerable().FirstOrDefault(
                    Function(linha) Convert.ToString(linha("CBO")) = cbo.ToString() AndAlso
                                    Not IsDBNull(linha("DESCRICAO_CBO")))
                If linhaCbo IsNot Nothing Then
                    descricaoCbo = Convert.ToString(linhaCbo("DESCRICAO_CBO"))
                End If
            End If

            Dim partes = QuebrarTexto($"{cbo} - {descricaoCbo}: {cboCount(cbo)}", listBox.Width - 20, listBox.Font)
            For Each parte In partes
                listBox.Items.Add(parte)
            Next
            total += cboCount(cbo)
        Next

        lbTotal.Text = total.ToString()

    End Sub

    Private Sub CBOmedicos(fcDatatable As DataTable, ByVal gestao As Integer)
        Dim cbosMedicos As String() = {223305, 225103, 225112, 225120, 225121, 225124, 225125, 225127, 225133, 225270, 225250, 225142, 225275, 225155, 225165, 225320, 225185, 225203, 225225, 225235, 225151, 225265, 225135, 225180, 225285, 225310, 225140}
        lbMedicos.Items.Clear()
        getByCBO(fcDatatable, cbosMedicos, lbMedTotal, lbMedicos)
    End Sub

    Private Sub CBOenfermeiros(fcDatatable As DataTable, ByVal gestao As Integer)
        Dim cbosEnf As String() = {223505, 223545, 223565}
        lbEnfermeiro.Items.Clear()
        getByCBO(fcDatatable, cbosEnf, lbEnfTotal, lbEnfermeiro)
    End Sub

    Private Sub CBOacs(fcDatatable As DataTable, ByVal gestao As String)
        Dim cbosACS As String() = {515105}
        lbACS.Items.Clear()
        getByCBO(fcDatatable, cbosACS, lbACStotal, lbACS)
    End Sub

    Private Sub CBOoutrosNivelSuperior(fcDatatable As DataTable, ByVal gestao As String)
        Dim cbosNivelSuperior As String() = {221205, 221105, 223208, 223212, 223240, 223256, 223260, 223268, 223293, 223405, 223415, 223605, 223710, 223810, 223905, 251510, 251605, 111415, 123115, 131205}
        lbSuperior.Items.Clear()
        getByCBO(fcDatatable, cbosNivelSuperior, lbNSTotal, lbSuperior)
    End Sub

    Private Sub CBOoutrosNivelMedio(fcDatatable As DataTable, ByVal gestao As String)
        Dim cbosNivelMedio As String() = {313220, 322245, 322250, 322430, 515215, 422110, 322605, 324115, 325110, 351605, 322205, 322230, 322410, 322415, 324120, 324220, 325115, 351105, 352210, 324205, 410105, 411005, 411010, 412110, 413110, 422105, 422205, 515140}
        lbMedio.Items.Clear()
        getByCBO(fcDatatable, cbosNivelMedio, lbNMTotal, lbMedio)
    End Sub

    Private Sub rbPublico_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPublico.CheckedChanged
        cbFormaContratoEstab.SelectedIndex = -1
        cbcbFormaContratoEmpreg.SelectedIndex = -1
        cbDetalhamento.SelectedIndex = -1
        clearLabels()
    End Sub

    Private Sub rbPrivado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPrivado.CheckedChanged
        cbFormaContratoEstab.SelectedIndex = -1
        cbcbFormaContratoEmpreg.SelectedIndex = -1
        cbDetalhamento.SelectedIndex = -1
        clearLabels()
    End Sub

    Private Sub clearLabels()
        dgPlanejamento.DataSource = Nothing
        lbACS.Items.Clear()
        lbEnfermeiro.Items.Clear()
        lbMedicos.Items.Clear()
        lbMedio.Items.Clear()
        lbSuperior.Items.Clear()

        lbMedTotal.Text = "0"
        lbEnfTotal.Text = "0"
        lbACStotal.Text = "0"
        lbNSTotal.Text = "0"
        lbNMTotal.Text = "0"

    End Sub

    Private Sub TextBoxCPF_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCPF.TextChanged
        If formatandoCPF Then Return

        Dim cpf As String = SomenteDigitos(TextBoxCPF.Text)
        If cpf.Length > 11 Then cpf = cpf.Substring(0, 11)

        Dim cpfFormatado As String = FormatarCPF(cpf)
        If TextBoxCPF.Text <> cpfFormatado Then
            formatandoCPF = True
            TextBoxCPF.Text = cpfFormatado
            TextBoxCPF.SelectionStart = TextBoxCPF.TextLength
            formatandoCPF = False
        End If

        Dim nome As String = TextBoxNome.Text.Trim()
        If cpf.Length <> 11 AndAlso nome.Length < 5 Then
            LimparResultadosBusca()
            Return
        End If

        Dim data As DataTable = ConsultarProfissionaisPorBusca(If(cpf.Length = 11, cpf, String.Empty), If(nome.Length >= 5, nome, String.Empty))
        AplicarDescricaoTipoVinculo(data)
        dgPlanejamento.DataSource = data
        datagridConfig()
    End Sub

    Private Sub TextBoxCPF_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxCPF.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxNome_TextChanged(sender As Object, e As EventArgs) Handles TextBoxNome.TextChanged
        Dim cpf As String = SomenteDigitos(TextBoxCPF.Text)
        Dim nome As String = TextBoxNome.Text.Trim()

        If cpf.Length <> 11 AndAlso nome.Length < 5 Then
            LimparResultadosBusca()
            Return
        End If

        Dim data As DataTable = ConsultarProfissionaisPorBusca(If(cpf.Length = 11, cpf, String.Empty), If(nome.Length >= 5, nome, String.Empty))
        AplicarDescricaoTipoVinculo(data)
        dgPlanejamento.DataSource = data
        datagridConfig()
    End Sub

    Private Sub LimparResultadosBusca()
        dgPlanejamento.DataSource = Nothing
        lbMedicos.Items.Clear()
        lbEnfermeiro.Items.Clear()
        lbACS.Items.Clear()
        lbSuperior.Items.Clear()
        lbMedio.Items.Clear()
        lbMedTotal.Text = "0"
        lbEnfTotal.Text = "0"
        lbACStotal.Text = "0"
        lbNSTotal.Text = "0"
        lbNMTotal.Text = "0"
    End Sub

    Private Function SomenteDigitos(valor As String) As String
        If valor Is Nothing Then Return String.Empty

        Dim resultado As New System.Text.StringBuilder()
        For Each caractere As Char In valor
            If caractere >= "0"c AndAlso caractere <= "9"c Then
                resultado.Append(caractere)
            End If
        Next
        Return resultado.ToString()
    End Function

    Private Function FormatarCPF(cpf As String) As String
        If String.IsNullOrEmpty(cpf) Then Return String.Empty
        If cpf.Length <= 3 Then Return cpf
        If cpf.Length <= 6 Then Return cpf.Substring(0, 3) & "." & cpf.Substring(3)
        If cpf.Length <= 9 Then Return cpf.Substring(0, 3) & "." & cpf.Substring(3, 3) & "." & cpf.Substring(6)
        Return cpf.Substring(0, 3) & "." & cpf.Substring(3, 3) & "." & cpf.Substring(6, 3) & "-" & cpf.Substring(9)
    End Function

    Private Sub dgPlanejamento_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgPlanejamento.CellMouseClick
        If e.Button = MouseButtons.Right Then
            If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
                ' Seleciona a célula clicada
                dgPlanejamento.ClearSelection()
                dgPlanejamento.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True

                columnIndex = e.ColumnIndex
                main.copyFromDatagridview(dgPlanejamento, columnIndex)
                main.msgInfo("Copiado!")
                'MessageBox.Show($"Célula selecionada: Linha {e.RowIndex}, Coluna {e.ColumnIndex}")
            End If
        End If
    End Sub

    Private Sub FecharToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FecharToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub ImportarPDFToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim filePath = Application.StartupPath & "\PDF\PROFISSIONAIS.pdf"
        OpenFileDialog1.Filter = "pdf Files (*.pdf)|*.pdf"
        OpenFileDialog1.FileName = "PROFISSIONAIS.pdf"

        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim pdfFile = OpenFileDialog1.FileName
            If File.Exists(filePath) Then
                If MessageBox.Show("Substituir arquivo existente?", "Atenção", MessageBoxButtons.YesNoCancel) = DialogResult.Yes Then
                    File.Copy(pdfFile, filePath, True)
                Else
                    Exit Sub
                End If
            Else
                File.Copy(pdfFile, filePath, False)
            End If
            MessageBox.Show("Importado com sucesso!", "Importar arquivo PDF", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub UploadPDFParaServidorToolStripMenuItem_Click(sender As Object, e As EventArgs)
        OpenFileDialog1.Filter = "pdf Files (*.pdf)|*.pdf"

        OpenFileDialog1.ShowDialog()

        Dim arquivoLocal As String = OpenFileDialog1.FileName
        Dim caminhoServidor As String = $"\\{My.Settings.server}\htdocs\Secretaria\CNES\PROFISSIONAIS.pdf"

        Try
            File.Copy(arquivoLocal, caminhoServidor, True)
            MessageBox.Show("Arquivo copiado com sucesso!")

        Catch ex As Exception
            ' MessageBox.Show($"Erro ao copiar arquivo: {ex.Message}{vbCrLf}{ex.StackTrace}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub FormCNESPlanejamento_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        FormSystemStart.Visible = True
        ToolTip1.Active = False
    End Sub

    Private Sub ProfissionaisToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProfissionaisToolStripMenuItem.Click
        FormCNESCadastro.Show()
    End Sub

End Class
