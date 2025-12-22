Imports System.Globalization
Imports System.IO
Imports System.Security.Principal
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Web
Imports ClosedXML.Excel
Imports Google.Protobuf.WellKnownTypes
Imports MySql.Data.MySqlClient
Imports Mysqlx.XDevAPI.Common

Public Class FormAMEOCI
    Private linhas As New List(Of String)
    Dim m As New Main
    Dim result As DataTable
    Dim endereco As DataTable
    Dim cepObj As New CEP()
    ' Variáveis globais
    Private popupGrid As DataGridView
    Private debounceTimer As New Timer() With {.Interval = 300}
    Private isLoading As Boolean = False
    Private IDpacienteSelecionado As Integer? = Nothing
    Private updateMode As Boolean = False
    Public Property idUser As Integer

    Public Function competencia(compet As String)
        compet = MonthName(My.Settings.OCIcompetencia.Substring(4, 2), True).ToUpper & "/" & My.Settings.OCIcompetencia.Substring(0, 4)
        Return compet

    End Function

    Private Function hasCPF(cpfValue As Object) As Boolean

        ' 1. Trata NULO vindo do banco (DBNull)
        If cpfValue Is DBNull.Value Then
            Return False
        End If

        ' 2. Trata Nothing do VB
        If cpfValue Is Nothing Then
            Return False
        End If

        ' 3. Converte pra string
        Dim cpf As String = cpfValue.ToString().Trim()

        ' 4. Se string vazia → não tem CPF
        If cpf = "" Then
            Return False
        End If

        ' 5. Se chegou aqui → tem CPF
        Return True
    End Function


    Private Function completeCPF(id As Integer)
        Dim dt = FormAMEmain.getDataset($"SELECT cpf FROM pacientes WHERE id={id}")

        If dt.Rows.Count > 0 Then
            If hasCPF(dt.Rows(0)("cpf")) Then
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If
    End Function
    Public Function CarregarProcedimentosIdCod() As Dictionary(Of Integer, String)
        Dim procedimentos As New Dictionary(Of Integer, String)

        Dim data = FormAMEmain.getDataset("SELECT cod, id FROM cod_oci_principal")

        For Each rdr As DataRow In data.Rows
            Dim cod As String = rdr("cod").ToString().Trim()
            Dim id As Integer = Convert.ToInt32(rdr("id"))

            If Not procedimentos.ContainsKey(id) Then
                procedimentos.Add(id, cod)
            End If
        Next

        Return procedimentos
    End Function
    Private Function GetProcedCod(idProcedimento As Integer) As String
        Dim dictProceds = CarregarProcedimentosIdCod()

        If dictProceds.ContainsKey(idProcedimento) Then
            Return dictProceds(idProcedimento)
        End If

        Return String.Empty
    End Function


    Private Function getProcedID(codProcedimentoPrincipal As String)
        Dim dictProceds As Dictionary(Of String, Integer) = CarregarProcedimentosCodId()
        Dim idProced As Integer

        Dim codigoBusca As String = codProcedimentoPrincipal
        If dictProceds.ContainsKey(codigoBusca) Then
            idProced = dictProceds(codigoBusca)
        End If

        Return idProced
    End Function

    Private Function saveAPAC()
        If Not txtNumApac.Text.Length = 13 Then
            MessageBox.Show("Preencha o número da APAC corretamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtNumApac.Focus()
            Return False
        End If
        If txtCNSMedicoExecutante.SelectedIndex = -1 Then
            MessageBox.Show("Selecione o médico.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCNSMedicoExecutante.Focus()
            Return False
        End If
        If txtProcedimentoPrincipal.SelectedIndex = -1 Then
            MessageBox.Show("Selecione o procedimento principal.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtProcedimentoPrincipal.Focus()
            Return False
        End If
        If dgvProcedimentos.Rows.Count <= 1 Then
            MessageBox.Show("Adicione um procedimento secundário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TabControl1.SelectedTab = TabControl1.TabPages(1)
            CodProcedimento.Focus()
            CodProcedimento.DroppedDown = True
            Return False
        End If
        If txtNomeMedicoSolicitante.Text = txtNomeAutorizador.Text Then
            MessageBox.Show("Os medicos Solicitante e Autorizador nao podem ser os mesmos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TabControl1.SelectedTab = TabControl1.TabPages(1)
            txtNomeAutorizador.Focus()
            txtNomeAutorizador.DroppedDown = True
            Return False
        End If

        'Dim dictProceds As Dictionary(Of String, Integer) = CarregarProcedimentosCodId()
        'Dim idProced As Integer

        'Dim codigoBusca As String = txtProcedimentoPrincipal.SelectedValue
        'If dictProceds.ContainsKey(codigoBusca) Then
        '    idProced = dictProceds(codigoBusca)
        'End If

        Dim idPac As Object = IDpacienteSelecionado
        Dim idEnd As Integer = 0
        Dim telfixo As String = ""
        Try

            If endereco Is Nothing OrElse endereco.Rows.Count = 0 Then
                idEnd = 0
            Else
                idEnd = endereco.Rows(0).Item("id")
            End If

            If txtTelefone.Text.Length = 8 Then
                telfixo = txtTelefone.Text.Insert(4, "-")
            Else
                telfixo = txtTelefone.Text.Insert(5, "-")
            End If

            If idPac = Nothing Then

                Try
                    idPac = FormAMEmain.doQuery($"INSERT INTO pacientes (nome, dtnasc, mae, tel, cpf, id_logradouro, numero, complemento, sexo, raca) VALUES ('{txtNomePaciente.Text.Trim()}', '{m.mysqlDateFormat(dtNascimento.Text)}', '{txtNomeMae.Text.Trim()}', '({txtDDD.Text}){telfixo}', '{txtCpfPaciente.Text.Trim()}',{idEnd}, '{txtNumero.Text.Trim()}', '{txtComplemento.Text.Trim()}', '{txtSexo.Text}', '{txtRaca.SelectedValue}')")

                Catch ex As Exception
                    Return False
                End Try

            Else

                Try
                    FormAMEmain.doQuery($"UPDATE pacientes SET cpf='{txtCpfPaciente.Text.Trim()}', mae='{txtNomeMae.Text.Trim()}', tel='({txtDDD.Text}){telfixo}', id_logradouro={idEnd}, numero='{txtNumero.Text.Trim()}', complemento='{txtComplemento.Text.Trim()}', sexo='{txtSexo.Text}', raca='{txtRaca.SelectedValue}' WHERE id={idPac}")
                    UnlockApac(txtNumApac.Text)
                Catch ex As Exception
                    ' MsgBox(ex.Message)
                    Return False
                End Try

            End If

            If txtProcedimentoPrincipal.SelectedValue Is Nothing Then
                Throw New Exception("Procedimento principal inválido.")
            End If

            'If CodProcedimento.SelectedValue Is Nothing Then
            '    Throw New Exception("Procedimento secundário inválido.")
            'End If

            Dim query = $"UPDATE oci Set compet='{competencia(My.Settings.OCIcompetencia)}', data='{m.mysqlDateFormat(dtValidadeIni.Value)}', id_paciente={idPac}, id_medico='{txtCNSMedicoExecutante.SelectedValue}',  id_autorizador='{txtNomeAutorizador.SelectedValue}',  id_cod_principal={getProcedID(txtProcedimentoPrincipal.SelectedValue)}, proced_secundario={CodProcedimento.SelectedValue}, cid_principal='{txtCidPrincipal.SelectedValue}', cid_sec='{txtCidSecundario.SelectedValue}' , status='CONC', id_usuario={idUser} WHERE num_apac='{txtNumApac.Text}'"

            If FormAMEmain.doQuery(query) Then
                btNovonumeroAPAC.Enabled = True
                FormAMEOCINumAPAC.loadNUMAPAC(dgOCIcadastradas, Nothing, Nothing, False, idUser,,,, , (dtpSearchData.Value), "data_lanc DESC",,, lbStatusCads)
                'txtNumApac.Text = GetAndLockNextApac()
                IDpacienteSelecionado = Nothing
            End If

            result.Clear()
            clearFields()
            Return True

        Catch ex As Exception
            MsgBox("Erro ao salvar APAC: " & ex.Message)
            'Dim queryCPF = FormAMEmain.getDataset($"SELECT id FROM pacientes WHERE cpf='{txtCpfPaciente.Text}'").Rows(0).Item("id").ToString()
            'If queryCPF.Count > 0 Then
            '    idPac = queryCPF
            'End If
            Return False
        End Try

    End Function
    Public Sub addAPAC()
        Try
            ' ==================== VALIDAÇÕES ====================
            If txtNumApac.Text.Trim() = "" Then Throw New Exception("Informe o número da APAC.")
            TabControl1.SelectedTab = TabControl1.TabPages(0)
            txtNumApac.Focus()
            If Not m.ValidarCPF(txtCpfPaciente.Text) Then
                MessageBox.Show("CPF inválido. Verifique e tente novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCpfPaciente.Focus()
                Return
            End If

            If dtNascimento.Text.Trim() = "" Then Throw New Exception("Informe a data de nascimento Do paciente.")
            TabControl1.SelectedTab = TabControl1.TabPages(0)
            dtNascimento.Focus()
            chkResponsavel()

            If txtProcedimentoPrincipal.SelectedValue = "0905010035" AndAlso CInt(m.AgeInMonths(m.mysqlDateFormat(dtNascimento.Text), m.mysqlDateFormat(dtValidadeIni.Value))) < 108 Then
                Throw New Exception("Paciente com idade inferior a 9 anos não permitido para procedimento 0905010035.")
                TabControl1.SelectedTab = TabControl1.TabPages(0)
            End If

            If txtNomePaciente.Text.Trim() = "" Then
                TabControl1.SelectedTab = TabControl1.TabPages(0)
                txtNomePaciente.Focus()
                Throw New Exception("Informe o nome Do paciente.")
            End If
            If txtNomeMae.Text.Trim() = "" Then
                TabControl1.SelectedTab = TabControl1.TabPages(0)
                txtNomeMae.Focus()
                Throw New Exception("Informe o nome da mãe.")
            End If
            If txtSexo.Text = "" Then
                TabControl1.SelectedTab = TabControl1.TabPages(0)
                txtSexo.Focus()
                Throw New Exception("Informe o sexo.")
            End If
            If txtNomeRespPaciente.Text.Trim() = "" Then
                TabControl1.SelectedTab = TabControl1.TabPages(0)
                txtNomeRespPaciente.Focus()
                Throw New Exception("Informe o nome Do responsável.")
            End If
            If txtDDD.Text.Trim() = "" Then
                TabControl1.SelectedTab = TabControl1.TabPages(0)
                txtDDD.Focus()
                Throw New Exception("Informe o DDD.")
            End If
            If txtTelefone.Text.Trim() = "" Then
                TabControl1.SelectedTab = TabControl1.TabPages(0)
                txtTelefone.Focus()
                Throw New Exception("Informe o telefone.")
            End If
            If txtCep.Text.Length < 8 Then
                TabControl1.SelectedTab = TabControl1.TabPages(0)
                txtCep.Focus()
                Throw New Exception("Informe o CEP corretamente.")
            End If
            If txtNumero.Text.Trim() = "" Then
                TabControl1.SelectedTab = TabControl1.TabPages(0)
                txtNumero.Focus()
                Throw New Exception("Informe o número Do logradouro.")
            End If
            If txtProcedimentoPrincipal.SelectedIndex < 0 Then
                TabControl1.SelectedTab = TabControl1.TabPages(1)
                txtProcedimentoPrincipal.Focus()
                txtProcedimentoPrincipal.DroppedDown = True
                Throw New Exception("Selecione o procedimento principal.")
            End If


            ' ==================== CONFIGURAÇÕES ====================
            Dim competencia As String = My.Settings.OCIcompetencia
            Dim caminhoArquivo As String = Path.Combine(Application.StartupPath & "\APAC\EXPORTADOS", "AP" & competencia & chkMonthEXT())
            If Not Directory.Exists(Application.StartupPath & "\APAC\EXPORTADOS") Then
                Directory.CreateDirectory(Application.StartupPath & "\APAC\EXPORTADOS")
            End If
            Dim codigos As New List(Of String)
            Dim quantidades As New List(Of Integer)

            For Each row As DataGridViewRow In dgvProcedimentos.Rows
                If Not row.IsNewRow Then
                    codigos.Add(row.Cells("Codigo").Value.ToString())
                    quantidades.Add(Convert.ToInt32(row.Cells("Quantidade").Value))
                End If
            Next

            If updateMode Then
                RemoverRegistroApac($"14{competencia}{txtNumApac.Text}")
            End If


            ' ==================== CRIA STREAM ÚNICO ====================
            Using fs As New FileStream(caminhoArquivo, FileMode.Append, FileAccess.Write, FileShare.None)
                Using sw As New StreamWriter(fs, Encoding.GetEncoding("iso-8859-1"))
                    ' ================= HEADER (01) =================
                    If fs.Length = 0 Then
                        Dim header As New StringBuilder()
                        header.Append("01#APAC")
                        header.Append(competencia)
                        header.Append("000001") ' Quantidade de APACs (ajuste se gerar mais)
                        header.Append("0000")   ' Campo controle
                        header.Append(Fmt(RemoverAcentos(My.Settings.OCInomeUnidade), 30))
                        header.Append(Fmt(My.Settings.OCIsigla, 6))
                        header.Append(My.Settings.OCIcnpj.Replace(".", "").Replace("/", "").Replace("-", "").PadLeft(14, "0"c))
                        header.Append(Fmt(RemoverAcentos(My.Settings.OCIorgaoDestino), 40))
                        header.Append(My.Settings.OCItipo.PadRight(1, " "c))
                        header.Append(competencia & "20") ' Data competência
                        header.Append("Versao 01.00".PadRight(15, " "c))
                        sw.WriteLine(header.ToString())
                    End If

                    ' ================= REGISTRO 14 =================
                    Dim r14 As New StringBuilder()
                    r14.Append("14") ' Tipo de registro
                    r14.Append(competencia)
                    r14.Append(txtNumApac.Text.PadLeft(13, "0"c))
                    r14.Append(My.Settings.OCIuf.PadRight(2, " "c))
                    r14.Append(txtCnesExecutante.Text.PadLeft(7, "0"c))
                    r14.Append(Date.Now.ToString("yyyyMMdd"))
                    r14.Append(dtValidadeIni.Value.ToString("yyyyMMdd"))
                    r14.Append(dtValidadeFim.Value.ToString("yyyyMMdd"))
                    r14.Append("00") ' Tipo atendimento
                    r14.Append(txtTipoApac.SelectedValue.ToString())
                    r14.Append(Fmt(txtNomePaciente.Text, 30))
                    r14.Append(Fmt(txtNomeMae.Text, 30))
                    r14.Append(Fmt(txtLogradouro.Text, 30))
                    r14.Append(txtNumero.Text.PadRight(5, " "c))
                    r14.Append(If(txtComplemento.Text <> "", RemoverAcentos(txtComplemento.Text.PadRight(10, " "c)), New String(" "c, 10)))
                    r14.Append(txtCep.Text.Replace("-", "").PadRight(8, " "c))
                    r14.Append(txtMunIbge.Text.PadLeft(7, "0"c))
                    r14.Append(Format(CDate(dtNascimento.Text).ToString("yyyyMMdd")))
                    r14.Append(txtSexo.Text.PadRight(1, " "c))
                    r14.Append(Fmt(txtNomeMedicoSolicitante.Text, 30))
                    r14.Append(txtProcedimentoPrincipal.SelectedValue.PadLeft(10, "0"c))
                    r14.Append(txtMotivoSaida.SelectedValue.ToString().PadLeft(2, "0"c))
                    If txtMotivoSaida.SelectedValue.ToString() <> "00" Then
                        r14.Append(dtAltaObito.Value.ToString("yyyyMMdd"))
                    Else
                        r14.Append(New String(" "c, 8))
                    End If
                    r14.Append(Fmt(txtNomeAutorizador.Text, 30))
                    r14.Append(If(txtCnsPaciente.Text.Length > 0, txtCnsPaciente.Text.PadLeft(15, "0"c), New String(" "c, 15)))
                    r14.Append(txtNomeMedicoSolicitante.SelectedValue.PadLeft(15, "0"c))
                    r14.Append(txtNomeAutorizador.SelectedValue.PadLeft(15, "0"c))
                    r14.Append(New String(" "c, 4)) ' Reservado
                    r14.Append(If(txtProntuario.Text <> "", txtProntuario.Text.PadRight(10, " "c), New String(" "c, 10)))
                    r14.Append(txtCnesSolicitante.Text.PadLeft(7, "0"c))
                    r14.Append(dtEmissao.Value.ToString("yyyyMMdd"))
                    r14.Append(dtAutorizacao.Value.ToString("yyyyMMdd"))
                    r14.Append(Fmt(txtGestor.Text, 10))
                    r14.Append(txtTipoAtend.SelectedValue.PadLeft(2, "0"c))
                    r14.Append(If(String.IsNullOrWhiteSpace(txtApacAnterior.Text), "0000000000000", txtApacAnterior.Text.PadLeft(13, "0"c)))
                    r14.Append(txtRaca.SelectedValue.ToString().PadLeft(2, "0"c))
                    r14.Append(Fmt(txtNomeRespPaciente.Text, 30))
                    r14.Append("010")
                    r14.Append(New String(" "c, 4))
                    r14.Append(cbTipoLogradouro.SelectedValue.PadLeft(3, "0"c))
                    r14.Append(txtBairro.Text.PadRight(30, " "c))
                    r14.Append(txtDDD.Text.PadLeft(2, " "c))
                    r14.Append(txtTelefone.Text.PadLeft(9, " "c))
                    r14.Append(txtEmail.Text.PadRight(40, " "c))
                    r14.Append(txtCNSMedicoExecutante.SelectedValue.PadLeft(15, "0"c))
                    r14.Append(txtCpfPaciente.Text.Trim)
                    r14.Append(txtEquipe.Text.PadLeft(10, " "c))
                    r14.Append(If(chkSituacaoRua.Checked, "S", "N"))
                    sw.WriteLine(r14.ToString())

                    ' ================= REGISTRO 06 =================
                    Dim r06 As New StringBuilder()
                    r06.Append("06")
                    r06.Append(competencia)
                    r06.Append(txtNumApac.Text.PadLeft(13, "0"c))
                    r06.Append(txtCidPrincipal.SelectedValue.PadRight(4, " "c))
                    If txtCidSecundario.SelectedIndex >= 0 Then
                        r06.Append(txtCidSecundario.SelectedValue.PadRight(4, " "c))
                    Else
                        r06.Append(New String(" "c, 4))
                    End If

                    sw.WriteLine(r06.ToString())

                    ' ================= REGISTRO 13 (Principal + Secundários) =================
                    Dim r13Principal As New StringBuilder()
                    r13Principal.Append("13")
                    r13Principal.Append(competencia)
                    r13Principal.Append(txtNumApac.Text.PadLeft(13, "0"c))
                    r13Principal.Append(txtProcedimentoPrincipal.SelectedValue.PadLeft(10, "0"c))
                    r13Principal.Append(CBOmed.SelectedValue.PadLeft(6, "0"c))
                    r13Principal.Append("0000001")
                    r13Principal.Append(New String(" "c, 53))
                    sw.WriteLine(r13Principal.ToString())

                    For Each row As DataGridViewRow In dgvProcedimentos.Rows
                        If row.IsNewRow Then Continue For
                        Dim r13 As New StringBuilder()
                        r13.Append("13")
                        r13.Append(competencia)
                        r13.Append(txtNumApac.Text.PadLeft(13, "0"c))
                        r13.Append(row.Cells(0).Value.ToString().PadLeft(10, "0"c))
                        r13.Append(row.Cells(3).Value.ToString().PadLeft(6, "0"c))
                        r13.Append(row.Cells(1).Value.ToString().PadLeft(7, "0"c))
                        r13.Append(New String(" "c, 53))
                        sw.WriteLine(r13.ToString())
                    Next
                End Using
            End Using

            If saveAPAC() Then
                MessageBox.Show("✅ Paciente adicionado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim selectedCNSExe As Integer = txtCNSMedicoExecutante.SelectedIndex
                Dim selectedAutorizador As Integer = txtNomeAutorizador.SelectedIndex
                Dim selectedCIDP As Integer = txtCidPrincipal.SelectedIndex
                Dim selectedCIDS As Integer = txtCidSecundario.SelectedIndex
                txtProcedimentoPrincipal_SelectedValueChanged(Nothing, Nothing)
                TabControl1.SelectedTab = TabControl1.TabPages(0)  ' ativa a terceira aba (0-based)
                txtCNSMedicoExecutante.SelectedIndex = selectedCNSExe
                txtNomeAutorizador.SelectedIndex = selectedAutorizador
                txtCidPrincipal.SelectedIndex = selectedCIDP
                txtCidSecundario.SelectedIndex = selectedCIDS
                updateMode = False
            End If
        Catch ex As Exception
            MessageBox.Show("⚠️ Erro ao gravar registro: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnAddPacAPAC_Click(sender As Object, e As EventArgs) Handles btnGerarArquivo.Click
        addAPAC()
    End Sub

    Public Sub RemoverRegistroApac(prefixoApac As String)
        Dim caminhoArquivo As String = Path.Combine(Application.StartupPath & "\APAC\EXPORTADOS", "AP" & My.Settings.OCIcompetencia & chkMonthEXT())
        Dim linhas = File.ReadAllLines(caminhoArquivo, Encoding.GetEncoding("iso-8859-1"))
        Dim resultado As New List(Of String)
        Dim ignorar As Boolean = False

        For Each linha In linhas

            If linha.StartsWith("14") Then

                ' Se este 14 for o que deve ser removido
                If linha.StartsWith(prefixoApac) Then
                    ignorar = True
                    Continue For
                Else
                    ignorar = False
                End If
            End If

            If Not ignorar Then
                resultado.Add(linha)
            End If

        Next

        ' Regrava o MESMO arquivo
        File.WriteAllLines(caminhoArquivo, resultado, Encoding.GetEncoding("iso-8859-1"))

    End Sub

    Public Function RemoverAcentos(texto As String) As String
        If String.IsNullOrWhiteSpace(texto) Then Return texto

        ' Normaliza o texto para decompor acentos (ex: Á -> A + ́)
        Dim normalized As String = texto.Normalize(NormalizationForm.FormD)
        Dim sb As New StringBuilder()

        For Each c As Char In normalized
            Dim uc As UnicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c)
            ' Pula caracteres de acento (NonSpacingMark)
            If uc <> UnicodeCategory.NonSpacingMark Then
                sb.Append(c)
            End If
        Next

        ' Remove cedilha e tildes específicos
        Dim semAcento As String = sb.ToString().Normalize(NormalizationForm.FormC)
        semAcento = semAcento.Replace("ç", "C").Replace("Ç", "C")

        Return semAcento.ToUpper

    End Function
    Private Sub clearFields()
        txtCpfPaciente.Clear()
        txtCnsPaciente.Clear()
        txtProntuario.Clear()
        dtNascimento.Clear()
        txtSexo.SelectedIndex = 0
        txtNomePaciente.Text = ""
        txtNomeMae.Clear()
        txtNomeRespPaciente.Clear()
        txtRaca.SelectedIndex = 0
        chkSituacaoRua.Checked = False
        txtEmail.Clear()
        txtDDD.Clear()
        txtTelefone.Clear()
        txtCep.Clear()
        cbTipoLogradouro.SelectedIndex = 0
        txtCidSecundario.SelectedIndex = -1
        txtLogradouro.Clear()
        txtNumero.Clear()
        txtBairro.Clear()
        txtComplemento.Clear()
        txtNumApac.Clear()
        txtNumApac.Focus()

    End Sub
    Private Sub btnAdicionarProcedimento_Click(sender As Object, e As EventArgs) Handles btnAdicionarProcedimento.Click
        Dim cod As String = CodProcedimento.SelectedValue.Trim()
        If String.IsNullOrWhiteSpace(cod) Then Exit Sub

        Dim cbo As String = CBOmed.SelectedValue.Trim()
        Dim qtd As String = Quantidade.Text.Trim()
        Dim desc As String = CodProcedimento.Text.Substring(13).Trim()

        ' Adiciona a linha com todas as colunas necessárias
        dgvProcedimentos.Rows.Add(cod, qtd, desc, cbo)
        Quantidade.Text = 1
    End Sub
    Public Function CalcularCampoControle(apacNumber As String, codigosProcedimento As List(Of String), quantidadesProcedimento As List(Of Integer)) As String
        Dim total As Long = 0

        ' Soma os dígitos dos códigos dos procedimentos
        For Each codigo In codigosProcedimento
            Dim apenasDigitos = New String(codigo.Where(Function(c) Char.IsDigit(c)).ToArray())
            If apenasDigitos <> "" Then
                total += CLng(apenasDigitos)
            End If
        Next

        ' Soma as quantidades dos procedimentos
        For Each qtd In quantidadesProcedimento
            total += CLng(qtd)
        Next

        ' Soma os dígitos do número da APAC
        Dim apacNumeros = New String(apacNumber.Where(Function(c) Char.IsDigit(c)).ToArray())
        If apacNumeros <> "" Then
            total += CLng(apacNumeros)
        End If

        ' Calcula o campo controle: (total Mod 1111) + 1111
        Dim resto As Integer = CInt(total Mod 1111)
        Dim campoControle As Integer = resto + 1111

        ' Retorna com 4 dígitos, zeros à esquerda
        Return campoControle.ToString().PadLeft(4, "0"c)
    End Function
    Private Function GetNextLoteNumber(qtdApacs As Integer) As String
        ' Retorna a quantidade de APACs do lote com 6 dígitos
        Return qtdApacs.ToString().PadLeft(6, "0"c)
    End Function

    Private Function Fmt(valor As String, tamanho As Integer) As String
        If valor Is Nothing Then valor = ""
        valor = valor.Trim()
        Return RemoverAcentos(valor.PadRight(tamanho, " "c).Substring(0, tamanho))
    End Function
    Private Sub btnRemoverProcedimento_Click(sender As Object, e As EventArgs) Handles btnRemoverProcedimento.Click
        If dgvProcedimentos.SelectedRows.Count > 0 Then
            For Each row As DataGridViewRow In dgvProcedimentos.SelectedRows
                If Not row.IsNewRow Then
                    dgvProcedimentos.Rows.Remove(row)
                End If
            Next
        Else
            MessageBox.Show("Selecione um procedimento para remover.")
        End If
    End Sub
    Public Sub getServersSUS()
        Dim main As New FormAMEmain
        Dim comboList As New List(Of System.Windows.Forms.ComboBox) From {
            txtCNSMedicoExecutante,
            txtNomeMedicoSolicitante
        }

        For Each cbb As ComboBox In comboList
            main.loadComboBox($"SELECT SUS, nome FROM servidores WHERE cbo ='{CBOmed.SelectedValue}'", cbb, "nome", "SUS", True)
        Next

        main.loadComboBox($"SELECT SUS, nome FROM servidores WHERE oci_autorizador=1", txtNomeAutorizador, "nome", "SUS", True)

    End Sub
    Private Function getPacientes(Optional ByVal cpf As String = Nothing, Optional nome As String = Nothing, Optional dtnasc As String = Nothing, Optional id As Integer = 0)
        Dim data As DataTable = Nothing
        Dim query As String = "SELECT pacientes.*, ceps_peruibe.cep AS CEP,ceps_peruibe.tipo,ceps_peruibe.logradouro,ceps_peruibe.bairro
          FROM pacientes
          JOIN ceps_peruibe ON pacientes.id_logradouro = ceps_peruibe.id "
        Dim orderBy As String = " ORDER BY pacientes.nome"

        Try

            If cpf IsNot Nothing Then
                data = FormAMEmain.getDataset(query & $" WHERE pacientes.cpf ='{cpf}' {orderBy}")

            ElseIf nome IsNot Nothing Then
                data = FormAMEmain.getDataset(query & $" WHERE pacientes.nome LIKE '%{nome}%' {orderBy}")

            ElseIf dtnasc IsNot Nothing Then

                data = FormAMEmain.getDataset(query & $" WHERE pacientes.dtnasc ='{dtnasc}' {orderBy}")
            ElseIf id > 0 Then

                data = FormAMEmain.getDataset(query & $" WHERE pacientes.id ={id} {orderBy}")
            End If

            Return data

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function ExtrairApacsNaoUsadas(usadas As IEnumerable(Of String), caminhoArquivo As String) As List(Of ApacRegistro)
        Dim lista As New List(Of ApacRegistro)
        Dim usadasSet As New HashSet(Of String)(usadas) ' busca rápida
        Dim linhas = File.ReadAllLines(caminhoArquivo, Encoding.GetEncoding("ISO-8859-1"))

        For Each linha As String In linhas
            If linha.StartsWith("14") AndAlso linha.Length > 80 Then
                ' Extrai número da APAC
                Dim numero As String = linha.Substring(8, 13).Trim()

                ' Pula os códigos até achar o nome
                Dim i As Integer = 21
                While i < linha.Length AndAlso (Char.IsDigit(linha(i)) OrElse Char.IsWhiteSpace(linha(i)))
                    i += 1
                End While

                ' Extrai o nome (até 30 caracteres)
                Dim nome As String = ""
                If i < linha.Length Then
                    Dim tamanho = Math.Min(30, linha.Length - i)
                    nome = linha.Substring(i, tamanho).Trim()
                End If

                ' Só adiciona se NÃO estiver na lista de usadas
                If Not usadasSet.Contains(numero) Then
                    lista.Add(New ApacRegistro With {
                    .NumeroApac = numero,
                    .NomePaciente = nome
                })
                End If
            End If
        Next

        Return lista
    End Function
    Public Function ExtrairApacsOUT_Cruzado(caminhoOut As String, apacsUsadas As IEnumerable(Of String)) As List(Of ApacRegistro)
        Dim usados = New HashSet(Of String)(apacsUsadas) ' busca O(1)
        Dim lista As New List(Of ApacRegistro)

        ' Use ISO-8859-1 pois arquivos do SUS costumam vir nessa codificação
        Dim linhas = File.ReadAllLines(caminhoOut, Encoding.GetEncoding("ISO-8859-1"))

        For Each linha In linhas
            If Not linha.StartsWith("14") Then Continue For

            ' Procura todos os grupos de 13 dígitos (podem existir outros campos numéricos)
            Dim m As Match = Regex.Match(linha, "\d{13}")
            While m.Success
                Dim apac As String = m.Value
                If usados.Contains(apac) Then
                    ' Começa logo após o número da APAC
                    Dim i As Integer = m.Index + m.Length

                    ' Pula dígitos e espaços que vêm logo em seguida
                    While i < linha.Length AndAlso (Char.IsDigit(linha(i)) OrElse Char.IsWhiteSpace(linha(i)))
                        i += 1
                    End While

                    ' A partir daqui deve começar o nome (letras e espaços). Captura até 30 chars.
                    Dim maxLen As Integer = Math.Min(30, Math.Max(0, linha.Length - i))
                    Dim rawNome As String = If(maxLen > 0, linha.Substring(i, maxLen), "").Trim()

                    ' Limpa o nome mantendo letras com acento/ç e espaços (evita pegar ruídos se vier algo fora do padrão)
                    Dim nomeMatch = Regex.Match(rawNome, "^[A-ZÁÂÃÀÉÊÍÓÔÕÚÜÇ\s]{3,}", RegexOptions.CultureInvariant)
                    Dim nome As String = If(nomeMatch.Success, nomeMatch.Value.Trim(), rawNome)

                    ' Normaliza para maiúsculas pt-BR
                    nome = nome.ToUpper(New CultureInfo("pt-BR"))

                    lista.Add(New ApacRegistro With {.NumeroApac = apac, .NomePaciente = nome})
                    Exit While ' achou a APAC dessa linha que interessa; segue para próxima linha
                End If
                m = m.NextMatch()
            End While
        Next

        Return lista
    End Function

    Public Sub ExportarApacsExcel(lista As List(Of ApacRegistro), caminho As String)
        Using wb As New XLWorkbook()

            Dim competencia As String = lista.FirstOrDefault()?.competencia
            Dim mes As Integer = Integer.Parse(competencia.Substring(4, 2))
            Dim ano As String = competencia.Substring(0, 4)
            Dim ws = wb.Worksheets.Add($"APACs {mes - ano}")
            ws.Cell(1, 6).Value = MonthName(mes).ToUpper() & "/" & ano
            ws.Cell(1, 6).Style.Font.Bold = True
            ws.Cell(1, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center

            Dim linha As Integer = 1
            For Each apac In lista
                ' Converte o Nº APAC para Decimal para garantir tipo numérico
                Dim num As Decimal
                If Not Decimal.TryParse(apac.NumeroApac, NumberStyles.None, CultureInfo.InvariantCulture, num) Then
                    ' Se der falha (não deve), grava como texto mesmo
                    ws.Cell(linha, 1).Value = apac.NumeroApac
                Else
                    ws.Cell(linha, 1).Value = num
                End If

                ws.Cell(linha, 2).Value = apac.NomePaciente

                Dim proc As Decimal
                If Decimal.TryParse(apac.ProcedimentoPrincipal, NumberStyles.None, CultureInfo.InvariantCulture, proc) Then
                    ws.Cell(linha, 3).Value = proc
                Else
                    ws.Cell(linha, 3).Value = apac.ProcedimentoPrincipal
                End If

                Dim sus As Decimal
                If Decimal.TryParse(apac.SUSMedicoExecutante, NumberStyles.None, CultureInfo.InvariantCulture, sus) Then
                    ws.Cell(linha, 4).Value = sus
                Else
                    ws.Cell(linha, 4).Value = apac.SUSMedicoExecutante
                End If

                Dim dataApac As Date
                If DateTime.TryParseExact(apac.data, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, dataApac) Then
                    ws.Cell(linha, 5).Value = dataApac
                    ws.Cell(linha, 5).Style.DateFormat.Format = "dd/MM/yyyy"
                Else
                    ws.Cell(linha, 5).Value = apac.data
                End If

                linha += 1
            Next

            ' Aplica formatação numérica sem casas decimais à coluna 1 (somente sobre as células usadas)
            If lista.Count > 0 Then
                ws.Range(1, 1, lista.Count, 1).Style.NumberFormat.Format = "0"
                ws.Range(1, 3, lista.Count, 3).Style.NumberFormat.Format = "0"
                ws.Range(1, 4, lista.Count, 4).Style.NumberFormat.Format = "0"
            End If

            ' Ajusta larguras
            ws.Columns(1, 6).AdjustToContents()

            wb.SaveAs(caminho)
        End Using
    End Sub
    Private Sub loadNumAPAC()
        Dim query = "SELECT num_apac INTO @apac FROM oci WHERE status = 'DISP' ORDER BY id LIMIT 1;
                     UPDATE oci SET status = 'BLOQ' WHERE num_apac = @apac;"
    End Sub

    Public Function GetAndLockNextApac() As String
        Try
            ' 1️⃣ Busca a próxima APAC disponível
            Dim dt As DataTable = FormAMEmain.getDataset("SELECT num_apac FROM oci WHERE status='DISP' ORDER BY id LIMIT 1")

            If dt.Rows.Count = 0 Then
                btNovonumeroAPAC.Enabled = False
                lbRestanteAPAC.Text = "0"
                Return Nothing
            End If

            Dim apac As String = dt.Rows(0)("num_apac").ToString()

            ' 2️⃣ Bloqueia a APAC encontrada
            Dim sqlUpdate As String = "UPDATE oci SET status='BLOQ' WHERE num_apac=@apac"
            Dim p As New Dictionary(Of String, Object) From {{"@apac", apac}}
            FormAMEmain.doQuery(sqlUpdate, p)

            lbRestanteAPAC.Text = dt.Rows.Count - 1 & " restante(s)"

            Return apac

        Catch ex As Exception
            MsgBox("Erro ao buscar/bloquear APAC: " & ex.Message)
            Return Nothing
        End Try
    End Function
    Public Sub UnlockApac(numApac As String)
        If String.IsNullOrWhiteSpace(numApac) Then Exit Sub

        Try
            Dim sql As String = "UPDATE oci SET status='DISP' WHERE num_apac=@apac AND status='BLOQ'"
            Dim p As New Dictionary(Of String, Object) From {{"@apac", numApac}}
            FormAMEmain.doQuery(sql, p)
        Catch ex As Exception
            MsgBox("Erro ao liberar APAC: " & ex.Message)
        End Try
    End Sub

    Private Sub loadAPACbyUser(idUser As Integer)
        FormAMEOCINumAPAC.loadNUMAPAC(dgOCIcadastradas, , , , idUser,,,, "CONC", Nothing, "data_lanc DESC")
        lbStatusCads.Text = $"{dgOCIcadastradas.Rows.Count} registros"
    End Sub
    Public Function loadAPACdisp()
        Dim apacDisp = FormAMEmain.getDataset("SELECT count(num_apac) AS apacs FROM oci WHERE status='DISP'").Rows(0).Item("apacs")
        If apacDisp = 0 Then
            btNovonumeroAPAC.Enabled = False
            Return "0 restante(s)"
        Else
            ' btNovonumeroAPAC.Enabled = True
            Return apacDisp & " restante(s)"
        End If
    End Function
    Public Sub LimparData()
        dtpSearchData.Format = DateTimePickerFormat.Custom
        dtpSearchData.CustomFormat = ""
    End Sub

    Public Sub loadComp(combobox As ComboBox)
        Dim comboComp = FormAMEmain.getDataset("SELECT id, compet FROM oci WHERE compet IS NOT NULL AND compet <> '' GROUP BY compet ORDER BY compet DESC")
        Dim dtFinal As DataTable = comboComp.Clone()

        ' Adiciona o item TODOS como primeira linha
        Dim rowTodos As DataRow = dtFinal.NewRow()
        rowTodos("id") = 0
        rowTodos("compet") = "TODOS"
        dtFinal.Rows.Add(rowTodos)

        ' Copia os dados originais
        For Each r As DataRow In comboComp.Rows
            dtFinal.ImportRow(r)
        Next

        ' Joga no ComboBox
        With combobox
            .DataSource = dtFinal
            .DisplayMember = "compet"
            .ValueMember = "id"
        End With

    End Sub
    Private Sub popupGrid_MouseLeave()
        popupGrid.Visible = False
    End Sub

    Public Function deleteOCI(id As Integer)
        Try
            If m.msgQuestion("Excluir OCI?", "Atenção") Then
                FormAMEmain.doQuery($"UPDATE oci Set compet='', data=NULL, id_paciente=NULL, id_medico=NULL, id_cod_principal=NULL, status='DISP', id_usuario=NULL WHERE id={id}",, True)
                lbRestanteAPAC.Text = loadAPACdisp()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Sub getOCIdata(id As Integer)
        Try
            Dim ociData = FormAMEmain.getDataset($"SELECT * FROM OCI WHERE id={id}", True)
            If ociData.Rows.Count = 0 Then
                m.msgAlert("OCI não encontrado!")
                Return
            End If

            txtNumApac.Text = ociData.Rows(0).Item("num_apac").ToString()
            dtValidadeIni.Value = CDate(ociData.Rows(0).Item("data"))
            IDpacienteSelecionado = ociData.Rows(0).Item("id_paciente")

            Dim pacData = FormAMEmain.getDataset($"SELECT cpf FROM pacientes WHERE id={IDpacienteSelecionado}", True)
            txtCpfPaciente.Text = pacData.Rows(0).Item("cpf").ToString()
            txtProcedimentoPrincipal.SelectedValue = GetProcedCod(ociData.Rows(0).Item("id_cod_principal").ToString())
            txtCidPrincipal.SelectedValue = ociData.Rows(0).Item("cid_principal").ToString()
            CodProcedimento.SelectedValue = ociData.Rows(0).Item("proced_secundario").ToString()
            txtCidSecundario.SelectedValue = ociData.Rows(0).Item("cid_sec").ToString()
            txtCNSMedicoExecutante.SelectedValue = ociData.Rows(0).Item("id_medico").ToString()
            txtNomeAutorizador.SelectedValue = ociData.Rows(0).Item("id_autorizador").ToString()

        Catch ex As Exception
            MsgBox("Erro ao carregar dados do OCI: " & ex.Message)
        End Try
    End Sub

    'Private Sub updateOCI(apac As String, idPac As Integer)
    '    Try
    '        FormAMEmain.doQuery($"UPDATE pacientes SET cpf='{txtCpfPaciente.Text.Trim()}', mae='{txtNomeMae.Text.Trim()}', tel='({txtDDD.Text}){txtTelefone.Text.Insert(5, "-")}', id_logradouro={endereco.Rows(0).Item("id")}, numero='{txtNumero.Text.Trim()}', complemento='{txtComplemento.Text.Trim()}', sexo='{txtSexo.Text}', raca='{txtRaca.SelectedValue}' WHERE id={idPac}")

    '        Dim query = $"UPDATE oci Set data='{m.mysqlDateFormat(dtValidadeIni.Value)}', id_paciente={idPac}, id_medico='{txtCNSMedicoExecutante.SelectedValue}', id_autorizador='{txtNomeAutorizador.SelectedValue}',  id_cod_principal={getProcedID(txtProcedimentoPrincipal.SelectedValue)}, proced_secundario={CodProcedimento.SelectedValue}, cid_principal='{txtCidPrincipal.SelectedValue}', cid_sec='{txtCidSecundario.SelectedValue}' status='CONC', id_usuario={idUser} WHERE num_apac='{apac}'"

    '        FormAMEmain.doQuery(query,, True)

    '        MsgBox("OCI atualizado com sucesso!")
    '        RemoverRegistroApac($"14{My.Settings.OCIcompetencia}{apac}")
    '        addAPAC()

    '    Catch ex As Exception
    '        Debug.WriteLine("Erro ao atualizar OCI: " & ex.Message)
    '    End Try

    'End Sub
    Private Sub FormAMEOCI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.databaseAME = "" Then
            FormAMEbd.ShowDialog()
            Me.Close()
            Return
        End If

        LimparData()

        Me.Text = $"Gerenciamento de APACs OCI - Competência {competencia(My.Settings.OCIcompetencia)}"
        ' loadAPACbyUser(idUser)
        lbRestanteAPAC.Text = loadAPACdisp()

        dtValidadeIni.Focus()
        Dim novoMes As Integer

        ' Inicializa o grid
        popupGrid = New DataGridView With {
        .Visible = False,
        .ReadOnly = True,
        .AllowUserToAddRows = False,
        .AllowUserToDeleteRows = False,
        .AllowUserToResizeRows = False,
        .RowHeadersVisible = False,
        .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
        .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
        .BackgroundColor = Color.White,
        .BorderStyle = BorderStyle.FixedSingle,
        .Width = 500,
        .Height = 250,
        .MultiSelect = False,
        .TabStop = True,
        .Cursor = Cursors.Hand
    }

        popupGrid.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        popupGrid.CellBorderStyle = DataGridViewCellBorderStyle.Sunken
        popupGrid.DefaultCellStyle.Font = New Font("Segoe UI", 9)
        popupGrid.DefaultCellStyle.SelectionBackColor = Color.DarkOrange
        popupGrid.DefaultCellStyle.SelectionForeColor = Color.White
        popupGrid.RowHeadersVisible = False

        ' Adiciona ao formulário
        Me.Controls.Add(popupGrid)
        popupGrid.BringToFront()

        AddHandler popupGrid.MouseLeave, AddressOf popupGrid_MouseLeave
        AddHandler debounceTimer.Tick, AddressOf BuscarPacientes
        AddHandler popupGrid.CellDoubleClick, AddressOf popupGrid_CellClick

        Try
            ' 1. Converter a string para um número inteiro

            If Integer.TryParse(My.Settings.OCIcompetencia.Substring(4, 2), novoMes) Then

                ' O TryParse foi bem-sucedido e a variável novoMes agora contém o valor numérico (1 a 12)

                ' Pega a data atual do DateTimePicker
                Dim dataAtual As Date = dtValidadeIni.Value

                ' Pega o Ano e o Dia da data atual
                Dim anoAtual As Integer = dataAtual.Year
                Dim diaAtual As Integer = dataAtual.Day

                Try
                    ' 2. Criar uma nova data com o Novo Mês, mas mantendo o Ano e o Dia atuais
                    dtValidadeIni.Value = New Date(anoAtual, novoMes, diaAtual)

                Catch ex As ArgumentOutOfRangeException

                    ' Este erro ocorre se o dia atual for inválido no novo mês.
                    ' Exemplo: Tentar colocar o dia 31 em um mês que só tem 30 dias (como Abril, Junho, Setembro, Novembro).

                    ' Solução Comum: Ajustar para o último dia válido do novo mês.
                    Dim ultimoDiaDoMes As Integer = Date.DaysInMonth(anoAtual, novoMes)
                    dtValidadeIni.Value = New Date(anoAtual, novoMes, ultimoDiaDoMes)

                    ' (Opcional) Mostrar uma mensagem de aviso
                    MessageBox.Show($"O dia {diaAtual} não existe no mês {novoMes}. A data foi ajustada para o dia {ultimoDiaDoMes}.", "Ajuste de Data", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End Try

            Else
                ' (Opcional) Tratamento de erro se a string não puder ser convertida
                MessageBox.Show("A String Do mês não é um número válido (01-12).", "Erro de Conversão", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            dgvProcedimentos.Columns.Clear()

            dgvProcedimentos.Columns.Add("Codigo", "Procedimento")
            dgvProcedimentos.Columns("Codigo").Width = 80
            dgvProcedimentos.Columns.Add("Quantidade", "Qtd")
            dgvProcedimentos.Columns("Quantidade").Width = 40
            dgvProcedimentos.Columns.Add("Desc", "Descrição")
            dgvProcedimentos.Columns("Desc").Width = 300
            dgvProcedimentos.Columns.Add("CBO", "CBO")
            dgvProcedimentos.Columns("CBO").Width = 90

            'dgvProcedimentos.AllowUserToAddRows = True
            dgvProcedimentos.AllowUserToDeleteRows = True
            ' dgvProcedimentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            txtSexo.SelectedIndex = 0

            Dim cbProcedPrincipal As New Dictionary(Of String, String) From {
                {"0904010015", "0904010015 - OCI Avaliação inicial diagnóstica de deficit auditivo"},
                {"0902010026", "0902010026 - OCI Avaliação Cardiológica"},
                {"0902010018", "0902010018 - OCI Avaliação de risco cirúrgico"},
                {"0905010035", "0905010035 - OCI Avaliação inicial em oftalmologia"},
                {"0903010011", "0903010011 - OCI Avaliação disgnóstica em ortopedia com recursos de raio-x"},
                {"0904010031", "0904010031 - OCI Avaliação disgnóstica de nasofaringe e orofaringe"}
            }

            txtProcedimentoPrincipal.DataSource = New BindingSource(cbProcedPrincipal, Nothing)
            txtProcedimentoPrincipal.DisplayMember = "Value"   ' O que aparece para o usuário
            txtProcedimentoPrincipal.ValueMember = "Key"
            txtProcedimentoPrincipal.SelectedIndex = -1

            Dim tipoLogra As New Dictionary(Of String, String) From {
                {"081", "RUA"},
                {"008", "AVENIDA"},
                {"031", "ESTRADA"},
                {"004", "ALAMEDA"},
                {"065", "PRAÇA"},
                {"105", "VIELA"},
                {"095", "SETOR"}
            }

            cbTipoLogradouro.DataSource = New BindingSource(tipoLogra, Nothing)
            cbTipoLogradouro.DisplayMember = "Value"   ' O que aparece para o usuário
            cbTipoLogradouro.ValueMember = "Key"
            cbTipoLogradouro.SelectedIndex = 0


            Dim racas As New Dictionary(Of String, String) From {
                {"01", "BRANCA"},
                {"02", "PRETA"},
                {"03", "PARDA"},
                {"04", "AMARELA"},
                {"05", "INDIGENA"},
                {"99", "SEM INFO"}
            }

            txtRaca.DataSource = New BindingSource(racas, Nothing)
            txtRaca.DisplayMember = "Value"   ' O que aparece para o usuário
            txtRaca.ValueMember = "Key"

            Dim tipo As New Dictionary(Of String, String) From {
                {"1", "INICIAL"},
                {"2", "CONTINUIDADE"},
                {"3", "UNICA"},
                {"4", "ENCERRAMENTO"}
            }

            txtTipoApac.DataSource = New BindingSource(tipo, Nothing)
            txtTipoApac.DisplayMember = "Value"   ' O que aparece para o usuário
            txtTipoApac.ValueMember = "Key"
            txtTipoApac.SelectedIndex = 2

            Dim tipoAtend As New Dictionary(Of String, String) From {
               {"01", "ELETIVO"},
               {"02", "URGENCIA"},
               {"03", "ACIDENTE NO LOCAL DE TRAB.OU A SERV.EMPR"},
               {"04", "ACIDENTE NO TRAJETO PARA O TRABALHO"},
               {"05", "OUTROS TIPOS DE ACIDENTE DE TRANSITO"},
               {"06", "OUTROS TIPOS DE LESOES/ENV.POR AGENT.Q/F"}
           }

            txtTipoAtend.DataSource = New BindingSource(tipoAtend, Nothing)
            txtTipoAtend.DisplayMember = "Value"   ' O que aparece para o usuário
            txtTipoAtend.ValueMember = "Key"
            txtTipoAtend.SelectedIndex = 0

            Dim motivo As New Dictionary(Of String, String) From {
                {"11", "ALTA CURADO"},
                {"12", "ALTA MELHORADO"},
                {"14", "ALTA A PEDIDO"},
                {"15", "ALTA COM PREVISAO DE RETORNO P/ACOMP.PAC"},
                {"16", "ALTA POR EVASAO"},
                {"18", "ALTA POR OUTROS MOTIVOS"}
            }

            txtMotivoSaida.DataSource = New BindingSource(motivo, Nothing)
            txtMotivoSaida.DisplayMember = "Value"   ' O que aparece para o usuário
            txtMotivoSaida.ValueMember = "Key"
            txtMotivoSaida.SelectedIndex = 1

            txtCidPrincipal.SelectedIndex = -1
            txtCNSMedicoExecutante.SelectedIndex = -1
            txtNomeAutorizador.SelectedIndex = -1

            searchByDate()

        Catch ex As Exception
            ' MsgBox(ex.Message)
            FormAMEOCIControleCompetencia.ShowDialog()
        End Try

    End Sub

    Private Function chkMonthEXT()

        Select Case My.Settings.OCIcompetencia.Substring(4, 2)
            Case "01"
                Return ".JAN"
            Case "02"
                Return ".FEV"
            Case "03"
                Return ".MAR"
            Case "04"
                Return ".ABR"
            Case "05"
                Return ".MAI"
            Case "06"
                Return ".JUN"
            Case "07"
                Return ".JUL"
            Case "08"
                Return ".AGO"
            Case "09"
                Return ".Set"
            Case "10"
                Return ".OUT"
            Case "11"
                Return ".NOV"
            Case "12"
                Return ".DEZ"
            Case Else
                Return ""
        End Select

    End Function

    Private Sub btAddAPAC_Click(sender As Object, e As EventArgs) Handles btAddAPAC.Click
        ' Caminho padrão
        Dim pastaDestino As String = Application.StartupPath & "\APAC\EXPORTADOS"
        If Not Directory.Exists(pastaDestino) Then
            Directory.CreateDirectory(pastaDestino)
        End If

        Dim fileAPAC As String

        'If txtCompetencia.Text.Contains("/") Then
        '    Dim partes() As String = txtCompetencia.Text.Split("/")
        '    fileAPAC = "AP" & partes(1) & partes(0).PadLeft(2, "0"c) & chkMonthEXT()
        'Else
        fileAPAC = "AP" & My.Settings.OCIcompetencia & chkMonthEXT()
        'End If

        Dim filePath As String = Path.Combine(pastaDestino, fileAPAC)

        ' Verifica se o arquivo existe
        If Not File.Exists(filePath) Then
            MessageBox.Show("Nenhuma APAC foi adicionada ainda.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Pergunta onde salvar a cópia/exportação
        Dim saveDialog As New SaveFileDialog()
        saveDialog.Title = "Exportar arquivo APAC"
        saveDialog.Filter = $"Arquivos APAC (*{chkMonthEXT()})|*{chkMonthEXT()}|Todos os arquivos (*{chkMonthEXT()})|*{chkMonthEXT()}"
        saveDialog.FileName = fileAPAC

        If saveDialog.ShowDialog() = DialogResult.OK Then
            'File.Copy(filePath, saveDialog.FileName, True)
            If File.Exists(filePath) Then
                File.Copy(filePath, saveDialog.FileName)
                MessageBox.Show($"Arquivo exportado com sucesso!{vbCrLf}{saveDialog.FileName}", "Exportação concluída", MessageBoxButtons.OK, MessageBoxIcon.Information)
                File.WriteAllText(filePath, "")
            End If

        End If

    End Sub

    Private Sub ControleDeCompetênciaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ControleDeCompetênciaToolStripMenuItem.Click
        FormAMEOCIControleCompetencia.ShowDialog()
    End Sub
    Private Sub NúmerosAPACToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NúmerosAPACToolStripMenuItem.Click
        FormLogin.Show()
        FormLogin.system = "NUMAPAC"
        'Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub cep(param As String)
        Try

            Dim CEP As New CEP()
            endereco = CEP.getAddress(param)

            If endereco IsNot Nothing Then

                Dim tipo = endereco.Rows(0).Item(2).ToString
                Dim logra = endereco.Rows(0).Item(3).ToString
                Dim bairro = endereco.Rows(0).Item(4).ToString
                Dim foundItem = CType(cbTipoLogradouro.DataSource, BindingSource) _
                .Cast(Of KeyValuePair(Of String, String))() _
                .FirstOrDefault(Function(x) x.Value.Equals(tipo, StringComparison.OrdinalIgnoreCase))

                If foundItem.Key IsNot Nothing Then
                    cbTipoLogradouro.SelectedValue = foundItem.Key
                End If

                txtLogradouro.Text = logra
                txtBairro.Text = bairro

            Else
                MsgBox("CEP não encontrado ou erro na consulta.")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtCep_Leave(sender As Object, e As EventArgs) Handles txtCep.Leave
        cep(txtCep.Text.Trim())
        dgvSugestoes.Visible = False
    End Sub
    Private Sub txtCep_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCep.KeyDown
        If e.KeyCode = Keys.Enter Then
            cep(txtCep.Text.Trim())
            dgvSugestoes.Visible = False
            txtNumero.Focus()
        End If
    End Sub
    Private Sub formatGrid()
        dgvSugestoes.Width = 650
        dgvSugestoes.Height = 150
        dgvSugestoes.BringToFront()
        dgvSugestoes.Visible = True
        dgvSugestoes.Location = New Point(24, 235)

        ' Oculta o ID (se existir)
        If dgvSugestoes.Columns.Contains("id") Then
            dgvSugestoes.Columns("id").Visible = False
        End If

        ' Ajusta os headers
        If dgvSugestoes.Columns.Contains("cep") Then dgvSugestoes.Columns("cep").HeaderText = "CEP"
        If dgvSugestoes.Columns.Contains("tipo") Then dgvSugestoes.Columns("tipo").HeaderText = "Tipo"
        If dgvSugestoes.Columns.Contains("logradouro") Then dgvSugestoes.Columns("logradouro").HeaderText = "Logradouro"
        If dgvSugestoes.Columns.Contains("bairro") Then dgvSugestoes.Columns("bairro").HeaderText = "Bairro"

        ' Ajusta larguras
        If dgvSugestoes.Columns.Contains("cep") Then dgvSugestoes.Columns("cep").Width = 80
        If dgvSugestoes.Columns.Contains("tipo") Then dgvSugestoes.Columns("tipo").Width = 70
        If dgvSugestoes.Columns.Contains("logradouro") Then dgvSugestoes.Columns("logradouro").Width = 300
        If dgvSugestoes.Columns.Contains("bairro") Then dgvSugestoes.Columns("bairro").Width = 200

        ' Aparência geral
        dgvSugestoes.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        dgvSugestoes.DefaultCellStyle.Font = New Font("Segoe UI", 9)
        dgvSugestoes.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue
        dgvSugestoes.DefaultCellStyle.SelectionForeColor = Color.Black
        dgvSugestoes.RowHeadersVisible = False
        dgvSugestoes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        dgvSugestoes.AllowUserToResizeRows = False
        dgvSugestoes.AllowUserToResizeColumns = False
    End Sub

    Private Sub txtLogradouro_TextChanged(sender As Object, e As EventArgs) Handles txtLogradouro.TextChanged
        Try
            Dim texto = txtLogradouro.Text.Trim()
            If texto.Length < 3 Then
                dgvSugestoes.Visible = False
                Exit Sub
            End If

            ' Busca no banco (usa sua função existente)
            Dim resultado As DataTable = cepObj.getAddress("", texto, "")

            If resultado Is Nothing OrElse resultado.Rows.Count = 0 Then
                dgvSugestoes.Visible = False
                Exit Sub
            End If

            ' Configura grid
            dgvSugestoes.DataSource = resultado
            formatGrid()

        Catch ex As Exception
            Debug.WriteLine("Erro ao carregar sugestões: " & ex.Message)
        End Try
    End Sub

    Private Sub dgvSugestoes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSugestoes.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        Dim linha As DataGridViewRow = dgvSugestoes.Rows(e.RowIndex)

        Dim tipo = linha.Cells("tipo").Value.ToString()
        Dim logra = linha.Cells("logradouro").Value.ToString()
        Dim bairro = linha.Cells("bairro").Value.ToString()
        Dim cep = linha.Cells("cep").Value.ToString()

        ' Preenche os campos
        txtCep.Text = cep
        txtLogradouro.Text = logra
        txtBairro.Text = bairro

        ' Seleciona tipo no ComboBox
        Dim foundItem = CType(cbTipoLogradouro.DataSource, BindingSource) _
            .Cast(Of KeyValuePair(Of String, String))() _
            .FirstOrDefault(Function(x) x.Value.Equals(tipo, StringComparison.OrdinalIgnoreCase))

        If foundItem.Key IsNot Nothing Then
            cbTipoLogradouro.SelectedValue = foundItem.Key
        End If

        dgvSugestoes.Visible = False
        txtNumero.Focus()

    End Sub
    Private Sub txtLogradouro_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLogradouro.KeyDown
        If e.KeyCode = Keys.Escape Then dgvSugestoes.Visible = False
    End Sub
    Private Sub txtBairro_TextChanged(sender As Object, e As EventArgs) Handles txtBairro.TextChanged
        Try
            Dim texto = txtBairro.Text.Trim()
            If texto.Length < 1 Then
                dgvSugestoes.Visible = False
                Exit Sub
            End If

            ' Busca no banco (usa sua função existente)
            Dim cepObj As New CEP()
            Dim resultado As DataTable = cepObj.getAddress("", "", texto)

            If resultado Is Nothing OrElse resultado.Rows.Count = 0 Then
                dgvSugestoes.Visible = False
                Exit Sub
            End If

            ' Configura grid
            dgvSugestoes.DataSource = resultado
            formatGrid()

        Catch ex As Exception
            Debug.WriteLine("Erro ao carregar sugestões: " & ex.Message)
        End Try
    End Sub
    Private Sub txtBairro_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBairro.KeyDown
        If e.KeyCode = Keys.Escape Then dgvSugestoes.Visible = False
    End Sub

    Private Sub txtCep_TextChanged(sender As Object, e As EventArgs) Handles txtCep.TextChanged
        If txtCep.Text.Length = 9 Then
            cep(txtCep.Text.Trim())
            dgvSugestoes.Visible = False
        Else
            Try
                cbTipoLogradouro.SelectedIndex = 0
                txtLogradouro.Text = ""
                txtBairro.Text = ""
                txtNumero.Text = ""
                txtComplemento.Text = ""
            Catch ex As Exception

            End Try

        End If
    End Sub

    ' nível de classe:
    Private _upperLock As Boolean = False
    Private Sub cbo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNomePaciente.KeyPress
        ' já sobe letras na digitação (evita mexer em Text)
        If Char.IsLetter(e.KeyChar) Then e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub
    Private Sub cbo_TextChanged(sender As Object, e As EventArgs) Handles txtNomePaciente.TextChanged
        If _upperLock Then Return
        Dim cb = DirectCast(sender, ComboBox)
        Dim txt = cb.Text
        Dim upper = txt.ToUpper()

        If txt <> upper Then
            _upperLock = True
            Dim pos = cb.SelectionStart
            cb.Text = upper
            ' protege o cursor mesmo se o texto encurtar
            cb.SelectionStart = Math.Min(pos, cb.Text.Length)
            _upperLock = False
        End If

        If isLoading Then Exit Sub
        debounceTimer.Stop()

        If txtNomePaciente.Text.Length >= 4 Then
            debounceTimer.Start()
        Else
            popupGrid.Visible = False
        End If

    End Sub

    Private Sub BuscarPacientes(sender As Object, e As EventArgs, Optional parameter As String = "nome")
        debounceTimer.Stop()
        Dim texto As String = txtNomePaciente.Text.Trim()

        Try
            isLoading = True
            If parameter = "nome" Then
                If texto.Length < 4 Then
                    popupGrid.Visible = False
                    Exit Sub
                End If

                result = getPacientes(, txtNomePaciente.Text,,)
            ElseIf parameter = "cpf" Then
                result = getPacientes(txtCpfPaciente.Text)
            ElseIf parameter = "dtnasc" Then
                result = getPacientes(, , m.mysqlDateFormat(dtNascimento.Text))
            End If

            If result.Rows.Count > 0 Then
                popupGrid.DataSource = result

                ' Posiciona o grid logo abaixo do textbox
                popupGrid.Location = New Point(30, 225)
                ' ======== CONFIGURAÇÃO DE COLUNAS INDIVIDUAIS ========

                For Each col As DataGridViewColumn In popupGrid.Columns
                    If col.Name.ToLower() <> "nome" AndAlso col.Name.ToLower() <> "dtnasc" Then
                        col.Visible = False
                    End If
                Next

                If popupGrid.Columns.Contains("nome") Then
                    popupGrid.Columns("nome").HeaderText = "Nome do Paciente"
                    popupGrid.Columns("dtnasc").Width = 250
                    popupGrid.Columns("nome").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End If

                If popupGrid.Columns.Contains("dtnasc") Then
                    popupGrid.Columns("dtnasc").HeaderText = "Nascimento"
                    popupGrid.Columns("dtnasc").Width = 80
                    popupGrid.Columns("dtnasc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End If

                If txtCpfPaciente.Text.Length = 11 Then
                    ' Se CPF já estiver preenchido, oculta o grid 
                    popupGrid.Visible = False
                Else
                    popupGrid.Visible = True
                End If

            Else
                result.Clear()
                popupGrid.Visible = False
            End If

        Catch ex As Exception
            popupGrid.Visible = False
        Finally
            isLoading = False
        End Try
    End Sub

    Private Sub popupGrid_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then
            IDpacienteSelecionado = CInt(popupGrid.Rows(e.RowIndex).Cells("id").Value)

            ' MsgBox(IDpacienteSelecionado)

            Try
                isLoading = True ' 🔒 bloqueia o TextChanged durante a seleção
                debounceTimer.Stop()
                Dim linhas() As DataRow = result.Select("id = " & IDpacienteSelecionado)
                If linhas.Length = 0 Then Exit Sub

                ' Cria uma cópia apenas com essa linha
                Dim dtSelecionado As DataTable = result.Clone()
                dtSelecionado.ImportRow(linhas(0))
                popupGrid.Visible = False
                resultPacientes(dtSelecionado)

            Finally
                isLoading = False ' 🔓 libera novamente
            End Try
        End If
    End Sub

    Private Sub resultPacientes(result As DataTable)

        Try
            'MsgBox(result.Rows(0).Item("id"))
            If result.Rows.Count > 0 Then
                ' txtNomePaciente.Text = result.Rows(0).Item("nome").ToString
                If result.Rows(0).Item("id_logradouro") <> 0 Then
                    txtCep.Text = result.Rows(0).Item("cep").ToString
                    txtNumero.Text = result.Rows(0).Item("numero").ToString
                    txtComplemento.Text = result.Rows(0).Item("complemento").ToString
                Else
                    txtCep.Text = ""
                    txtNumero.Text = ""
                    txtComplemento.Text = ""
                    txtLogradouro.Text = ""
                    txtBairro.Text = ""
                End If

                dtNascimento.Text = result.Rows(0).Item("dtnasc").ToString
                txtNomePaciente.Text = result.Rows(0).Item("nome").ToString
                txtSexo.Text = result.Rows(0).Item("sexo").ToString
                txtCpfPaciente.Text = result.Rows(0).Item("cpf").ToString
                txtNomeMae.Text = result.Rows(0).Item("mae").ToString

                If IsDBNull(result.Rows(0).Item("raca")) Then
                    txtRaca.SelectedValue = "01"
                Else
                    txtRaca.SelectedValue = result.Rows(0).Item("raca")
                End If
                'chkSituacaoRua.Checked = CBool(result.Rows(0).Item("situacao_rua"))

                Try
                        Dim fullTel = result.Rows(0).Item("tel").ToString
                        If fullTel.Length > 0 Then
                            Dim ddd = result.Rows(0).Item("tel").ToString.Substring(1, 2)
                            txtDDD.Text = ddd
                            If fullTel.Length >= 14 Then
                                Dim tel = result.Rows(0).Item("tel").ToString.Substring(4, 10)
                                txtTelefone.Text = tel.Replace("-", "")
                            Else
                                Dim tel = result.Rows(0).Item("tel").ToString.Substring(4, 9)
                                txtTelefone.Text = tel.Replace("-", "")
                            End If
                        End If

                    Catch ex As Exception

                    End Try
                    chkResponsavel()
                End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub chkResponsavel()
        Try
            If m.CalcularIdade(CDate(dtNascimento.Text)) >= 18 Then
                txtNomeRespPaciente.Text = txtNomePaciente.Text.ToString
            Else
                txtNomeRespPaciente.Text = txtNomeMae.Text.ToString
            End If
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dtValidadeIni_Leave(sender As Object, e As EventArgs) Handles dtValidadeIni.Leave
        'dtValidadeFim.Value = dtValidadeIni.Value.AddMonths(1)
        'dtAltaObito.Value = dtValidadeIni.Value
        'dtEmissao.Value = dtValidadeIni.Value
        'dtAutorizacao.Value = dtValidadeIni.Value
    End Sub
    Private Sub txtNomePaciente_Leave(sender As Object, e As EventArgs) Handles txtNomePaciente.Leave
        chkResponsavel()
        'MsgBox(m.SafeValue(result, "id", 0))
    End Sub

    Private Sub txtCNSMedicoExecutante_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtCNSMedicoExecutante.SelectedIndexChanged
        Try
            txtNomeMedicoSolicitante.SelectedIndex = txtCNSMedicoExecutante.SelectedIndex
        Catch ex As Exception

        End Try
    End Sub
    Private Sub FormAMEOCI_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        FormSystemStart.Visible = True
        If Not String.IsNullOrEmpty(txtNumApac.Text) Then
            UnlockApac(txtNumApac.Text)
        End If
    End Sub
    Private Sub txtCpfPaciente_TextChanged(sender As Object, e As EventArgs) Handles txtCpfPaciente.TextChanged
        If txtCpfPaciente.Text.Length = 11 Then
            Try
                If m.ValidarCPF(txtCpfPaciente.Text) Then
                    result = getPacientes(txtCpfPaciente.Text.Trim())
                    resultPacientes(result)
                    popupGrid.Visible = False
                Else
                    MsgBox("CPF invalido!")
                    txtCpfPaciente.Focus()
                    txtCpfPaciente.Clear()
                End If

            Catch ex As Exception
                MsgBox("CPF invalido!")
            End Try
        End If
    End Sub

    Private Sub FormAMEOCI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) OrElse e.KeyChar = ChrW(Keys.Tab) Then
            dgvSugestoes.Visible = False
            popupGrid.Visible = False
        End If
    End Sub

    Public Sub ExportarCSV(lista As List(Of ApacRegistro), destino As String)
        Using sw As New StreamWriter(destino, False, Encoding.UTF8)
            sw.WriteLine("NumeroAPAC;NomePaciente")
            For Each item In lista
                sw.WriteLine($"{item.NumeroApac};{item.NomePaciente}")
            Next
        End Using
    End Sub
    Public Function CarregarProcedimentosCodId() As Dictionary(Of String, Integer)
        Dim procedimentos As New Dictionary(Of String, Integer)

        Dim data = FormAMEmain.getDataset("SELECT cod, id FROM cod_oci_principal")

        For Each rdr As DataRow In data.Rows
            Dim cod As String = rdr("cod").ToString().Trim()
            Dim id As Integer = Convert.ToInt32(rdr("id"))
            If Not procedimentos.ContainsKey(cod) Then
                procedimentos.Add(cod, id)
            End If
        Next

        Return procedimentos
    End Function

    Private Sub btFechar_Click(sender As Object, e As EventArgs) Handles btFechar.Click
        FormSystemStart.Visible = True
        If Not String.IsNullOrEmpty(txtNumApac.Text) Then
            UnlockApac(txtNumApac.Text)
            btNovonumeroAPAC.Enabled = True
        End If
        Me.Close()
    End Sub
    Private Sub btNovonumeroAPAC_Click(sender As Object, e As EventArgs) Handles btNovonumeroAPAC.Click
        txtNumApac.Text = GetAndLockNextApac()
        dtValidadeIni.Focus()
        btNovonumeroAPAC.Enabled = False
        lbRestanteAPAC.Text = loadAPACdisp()
    End Sub

    Public Function importFromApacs(caminhoArquivo As String) As List(Of ApacRegistro)
        Dim lista As New List(Of ApacRegistro)
        Dim linhas = File.ReadAllLines(caminhoArquivo, Encoding.GetEncoding("ISO-8859-1"))

        For Each linha As String In linhas
            If linha.StartsWith("14") Then
                ' Número APAC
                Dim numero As String = linha.Substring(8, 13).Trim()

                ' Ignora qualquer bloco numérico após a APAC (como 0320251103003)
                Dim i As Integer = 21
                While i < linha.Length AndAlso (Char.IsDigit(linha(i)) OrElse Char.IsWhiteSpace(linha(i)))
                    i += 1
                End While

                Dim nome As String = ""
                If i < linha.Length Then
                    Dim tamanho = Math.Min(30, linha.Length - i)
                    nome = linha.Substring(i, tamanho).Trim()
                End If

                Dim procedimento As String = linha.Substring(216, 10).Trim()
                Dim susMedico As String = linha.Substring(281, 15).Trim()
                Dim dataTxt As String = linha.Substring(38, 8).Trim()
                Dim compt As String = linha.Substring(2, 6).Trim()
                Dim cpf As String = linha.Substring(511, 11).Trim()
                Dim dtnasc As String = linha.Substring(177, 8).Trim()
                Dim cep As String = linha.Substring(162, 8).Trim()
                Dim tel As String = linha.Substring(445, 11).Trim()
                Dim mae As String = linha.Substring(87, 30).Trim()
                Dim numeroRes As String = linha.Substring(147, 5).Trim()
                Dim complento As String = linha.Substring(152, 10).Trim()
                Dim tipoLogra As String = linha.Substring(412, 3).Trim()
                Dim logradouro As String = linha.Substring(117, 30).Trim()
                Dim bairro As String = linha.Substring(415, 30).Trim()

                lista.Add(New ApacRegistro With {
                .NumeroApac = numero,
                .NomePaciente = nome,
                .ProcedimentoPrincipal = procedimento,
                .SUSMedicoExecutante = susMedico,
                .data = DateTime.ParseExact(dataTxt, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None),
                .competencia = compt,
                .CPFPaciente = cpf,
                .DtnascPaciente = DateTime.ParseExact(dtnasc, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None),
                .CEPPaciente = cep,
                .MaePaciente = mae,
                .TelPaciente = tel,
                .numeroResPaciente = numeroRes,
                .complementoPaciente = complento,
                .TipoLograPaciente = tipoLogra,
                .LograPaciente = logradouro,
                .BairroPaciente = bairro
            })
            End If
        Next

        Return lista
    End Function
    Public Function GetDescricaoLogradouro(cod As String) As String
        Dim c As String = cod.Trim().PadLeft(3, "0"c)

        Select Case c
        ' --- da tela do APAC.exe (print) ---
            Case "001" : Return "ACESSO"
            Case "002" : Return "ADRO"
            Case "004" : Return "ALAMEDA"
            Case "005" : Return "ALTO"
            Case "007" : Return "ATALHO"
            Case "008" : Return "AVENIDA"
            Case "009" : Return "BALNEARIO"
            Case "010" : Return "BELVEDERE"
            Case "011" : Return "BECO"
            Case "012" : Return "BLOCO"
            Case "013" : Return "BOSQUE"
            Case "014" : Return "BOULEVARD"
            Case "015" : Return "BAIXA"

        ' --- códigos que você já usa na sua base ---
            Case "031" : Return "ESTRADA"
            Case "065" : Return "PRAÇA"
            Case "081" : Return "RUA"
            Case "095" : Return "SETOR"
            Case "105" : Return "VIELA"

                ' fallback: se não tiver na tabela, devolve o próprio código
            Case Else
                Return $"CÓDIGO {c}"
        End Select
    End Function

    Private Sub APACtoDB(apacs As List(Of ApacRegistro))
        Dim proceds As New List(Of String)
        Dim dictProceds As Dictionary(Of String, Integer) = CarregarProcedimentosCodId()
        Dim idProced As Integer

        For Each apac In apacs
            Dim codigoBusca As String = apac.ProcedimentoPrincipal
            If dictProceds.ContainsKey(codigoBusca) Then
                idProced = dictProceds(codigoBusca)
            End If

            Dim ddd As String = ""
            Dim tel As String = ""
            If apac.TelPaciente.Length > 0 Then
                ddd = $"({apac.TelPaciente.Substring(0, 2)})"
                tel = apac.TelPaciente.Substring(2, apac.TelPaciente.Length - 2)
            End If

            Dim dtLogra = cepObj.getAddress(apac.CEPPaciente.Insert(5, "-"))
            Dim idLogra As Integer = 0
            Dim idPac As Integer = 0

            If dtLogra IsNot Nothing AndAlso dtLogra.Rows.Count > 0 Then
                idLogra = Convert.ToInt32(dtLogra.Rows(0)("id"))
            Else
                Try
                    idLogra = FormAMEmain.doQuery($"INSERT INTO ceps_peruibe (cep, tipo, logradouro, bairro) VALUES ('{apac.CEPPaciente}', '{GetDescricaoLogradouro(apac.TipoLograPaciente.ToUpper)}', '{apac.LograPaciente.ToUpper}', '{apac.BairroPaciente.ToUpper}')")
                Catch ex As Exception

                End Try
            End If

            Try
                Dim num As Integer
                If Not IsNumeric(apac.numeroResPaciente) Then
                    num = 0
                Else
                    num = apac.numeroResPaciente
                End If

                idPac = FormAMEmain.doQuery($"INSERT INTO pacientes (nome, dtnasc, mae, tel, cpf, id_logradouro, numero, complemento, sexo) VALUES ('{apac.NomePaciente.ToUpper}', '{m.mysqlDateFormat(apac.DtnascPaciente)}', '{apac.MaePaciente.ToUpper}', '{ddd}{tel}', '{apac.CPFPaciente}',{idLogra}, {num}, '{apac.complementoPaciente.ToUpper}', '{txtSexo.Text}')")
            Catch ex As Exception

                Try
                    idPac = FormAMEmain.getDataset($"SELECT id FROM pacientes WHERE cpf='{apac.CPFPaciente}'").Rows(0).Item("id")
                Catch exc As Exception

                    idPac = FormAMEmain.getDataset($"SELECT id FROM pacientes WHERE dtnasc='{m.mysqlDateFormat(apac.DtnascPaciente)}' AND nome LIKE '%{apac.NomePaciente}%'").Rows(0).Item("id")
                End Try
            End Try

            Try
                FormAMEmain.doQuery($"UPDATE oci SET compet='{competencia(apac.competencia)}', data='{m.mysqlDateFormat(apac.data)}', id_paciente='{idPac}', id_medico='{apac.SUSMedicoExecutante}', id_cod_principal={idProced}, status='CONC', id_usuario={idUser} WHERE num_apac='{apac.NumeroApac}'")
            Catch ex As Exception

            End Try
        Next
        MsgBox("Importação concluída!")
    End Sub
    Private Sub searchByDate()
        dtpSearchData.CustomFormat = "dd/MM/yyyy"
        FormAMEOCINumAPAC.loadNUMAPAC(dgOCIcadastradas, Nothing, Nothing, False, idUser,,,, , (dtpSearchData.Value), "data_lanc DESC",,, lbStatusCads)
        ckbSearchTodos.Checked = False
    End Sub

    Private Sub FormAMEOCI_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        popupGrid.Visible = False
    End Sub
    Private Sub clickDtpSearchData(sender As Object, e As EventArgs) Handles dtpSearchData.ValueChanged
        searchByDate()
    End Sub
    Public Sub loadAllOCI(dg As DataGridView)
        FormAMEOCINumAPAC.loadNUMAPAC(dg,,,, idUser,,,, "CONC",, "oci.data_lanc DESC, id_cod_principal, pacientes.nome",,, lbStatusCads)
    End Sub
    Private Sub ckbSearchTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ckbSearchTodos.CheckedChanged
        If ckbSearchTodos.Checked Then
            LimparData()
            loadAllOCI(dgOCIcadastradas)
        Else
            dgOCIcadastradas.DataSource = Nothing
            lbStatusCads.Text = "0 registros"
        End If

    End Sub
    Private Sub ImportarAPACToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportarAPACToolStripMenuItem.Click
        Dim desktop As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

        If OpenFileDialog1.ShowDialog Then
            Dim itens = (importFromApacs(OpenFileDialog1.FileName))
            'ExportarApacsExcel(itens, desktop & "\APAC.xlsx")
            APACtoDB(itens)
        End If
    End Sub

    Private Sub TabControl1_Click(sender As Object, e As EventArgs) Handles TabControl1.Click
        popupGrid.Visible = False
    End Sub
    Private Sub GroupBox1_MouseHover(sender As Object, e As EventArgs) Handles GroupBox1.MouseHover
        popupGrid.Visible = False
    End Sub
    Private Sub GroupBox2_MouseHover(sender As Object, e As EventArgs) Handles GroupBox2.MouseHover
        popupGrid.Visible = False
    End Sub
    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click
        popupGrid.Visible = False
    End Sub
    Private Sub GroupBox5_MouseHover(sender As Object, e As EventArgs) Handles GroupBox5.MouseHover
        popupGrid.Visible = False
    End Sub
    Private Sub dtNascimento_TextChanged(sender As Object, e As EventArgs) Handles dtNascimento.TextChanged
        Try

            If dtNascimento.Text.Length = 10 Then
                popupGrid.Visible = True
                BuscarPacientes(sender, e, "dtnasc")
                chkResponsavel()
            Else
                popupGrid.Visible = False
                result.Clear()
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub txtNomeMae_Leave(sender As Object, e As EventArgs) Handles txtNomeMae.Leave
        chkResponsavel()
    End Sub

    Private Sub dtNascimento_Enter(sender As Object, e As EventArgs) Handles dtNascimento.Enter
        m.setCursorStart(dtNascimento)
    End Sub

    Private Sub txtCep_Enter(sender As Object, e As EventArgs) Handles txtCep.Enter
        m.setCursorStart(txtCep)
    End Sub
    Private Sub txtCpfPaciente_Enter(sender As Object, e As EventArgs) Handles txtCpfPaciente.Enter
        m.setCursorStart(txtCpfPaciente)
    End Sub
    Private Sub dtNascimento_Click(sender As Object, e As EventArgs) Handles dtNascimento.Click
        m.setCursorStart(dtNascimento)
    End Sub
    Private Sub txtCep_Click(sender As Object, e As EventArgs) Handles txtCep.Click
        m.setCursorStart(txtCep)
    End Sub
    Private Sub txtCpfPaciente_Click(sender As Object, e As EventArgs) Handles txtCpfPaciente.Click
        m.setCursorStart(txtCpfPaciente)
    End Sub
    Private Sub txtDDD_TextChanged(sender As Object, e As EventArgs) Handles txtDDD.TextChanged
        If txtDDD.Text.Length >= 2 Then
            txtTelefone.Focus()
            txtTelefone.SelectionStart = 0
        End If
    End Sub

    Private Sub FormAMEOCI_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.V Then
            If m.TelefoneValido(Clipboard.GetText) Then
                txtDDD.Focus()
                m.PasteTelefone(txtDDD, txtTelefone)
            End If
        End If
    End Sub

    Private Sub ConsistênciaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsistênciaToolStripMenuItem.Click
        Process.Start($"C:\Program Files (x86)\Datasus\APAC\RCONSIST{chkMonthEXT()}")
    End Sub

    Private Sub ExcluirNãoUtilizadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExcluirNãoUtilizadosToolStripMenuItem.Click
        Dim sequencia = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\sequencia.txt").ToList()
        Dim usados As New HashSet(Of String)

        For Each linha In File.ReadLines(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\APBKP.NOV")
            If linha.StartsWith("14") Then
                Dim numeroApac = linha.Substring(8, 13).Trim()
                usados.Add(numeroApac)
            End If
        Next

        ' Diferença: sequência - usadas
        Dim naoUsadas = sequencia.Except(usados).ToList()

        ' Monta relatório
        Dim sb As New StringBuilder()
        sb.AppendLine("RELATÓRIO DE CONTROLE DE APAC")
        sb.AppendLine("================================")
        sb.AppendLine("Data: " & DateTime.Now.ToString("dd/MM/yyyy HH:mm"))
        sb.AppendLine()
        sb.AppendLine("Total na sequência original: " & sequencia.Count)
        sb.AppendLine("Total de APACs usadas: " & usados.Count)
        sb.AppendLine("Total de APACs NÃO usadas: " & naoUsadas.Count)
        sb.AppendLine()
        sb.AppendLine("LISTA DE APACs NÃO UTILIZADAS:")
        sb.AppendLine("--------------------------------")

        For Each n In naoUsadas
            sb.AppendLine(n)
        Next

        ' Grava arquivo TXT
        File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\resultado.txt", sb.ToString(), Encoding.UTF8)

    End Sub
    Private Sub ExcluirRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExcluirRegistroToolStripMenuItem.Click
        If deleteOCI(dgOCIcadastradas.SelectedRows(0).Cells(0).Value) Then
            RemoverRegistroApac($"14{My.Settings.OCIcompetencia}{dgOCIcadastradas.SelectedRows(0).Cells(1).Value}")
            FormAMEOCINumAPAC.loadNUMAPAC(dgOCIcadastradas, Nothing, Nothing, False, idUser,,,, , (dtpSearchData.Value), "data_lanc DESC")
        End If

    End Sub
    Private Sub EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem.Click
        updateMode = True
        getOCIdata(dgOCIcadastradas.SelectedRows(0).Cells(0).Value)
    End Sub
    Private Sub dtValidadeIni_ValueChanged(sender As Object, e As EventArgs) Handles dtValidadeIni.ValueChanged
        dtValidadeFim.Value = dtValidadeIni.Value.AddMonths(1)
        dtAltaObito.Value = dtValidadeIni.Value
        dtEmissao.Value = dtValidadeIni.Value
        dtAutorizacao.Value = dtValidadeIni.Value
    End Sub

    Private Sub txtProcedimentoPrincipal_SelectedValueChanged(sender As Object, e As EventArgs) Handles txtProcedimentoPrincipal.SelectedValueChanged
        Dim procedSec As New Dictionary(Of String, String)
        Dim cbo As New Dictionary(Of String, String)

        Try
            dgvProcedimentos.Rows.Clear()
            procedSec.Clear()
            cbo.Clear()

            If txtProcedimentoPrincipal.SelectedValue = "0904010015" Then
                procedSec.Add("0301010072", "0301010072 - Consulta médica na atenção especializada")
                procedSec.Add("0211070041", "0211070041 - Audiometria tonal limiar (via aérea/óssea)")
                cbo.Add("225275", "225275 - Médico Otorrinolaringologista")
                dgvProcedimentos.Rows.Add("0301010072", "1", "Consulta médica na atenção especializada", "225275")
                dgvProcedimentos.Rows.Add("0211070041", "1", "Audiometria tonal limiar (via aérea/óssea)", "225275")

            ElseIf txtProcedimentoPrincipal.SelectedValue = "0902010026" Then
                procedSec.Add("0301010072", "0301010072 - Consulta médica na atenção especializada")
                procedSec.Add("0211020036", "0211020036 - Eletrocardiograma (ECG)")
                cbo.Add("225120", "225120 - Médico Cardiologista")
                dgvProcedimentos.Rows.Add("0301010072", "1", "Consulta médica na atenção especializada", "225120")
                dgvProcedimentos.Rows.Add("0211020036", "1", "Eletrocardiograma (ECG)", "225120")

            ElseIf txtProcedimentoPrincipal.SelectedValue = "0902010018" Then
                procedSec.Add("0301010072", "0301010072 - Consulta médica na atenção especializada")
                procedSec.Add("0211020036", "0211020036 - Eletrocardiograma (ECG)")
                cbo.Add("225120", "225120 - Médico Cardiologista")
                dgvProcedimentos.Rows.Add("0301010072", "1", "Consulta médica na atenção especializada", "225120")
                dgvProcedimentos.Rows.Add("0211020036", "1", "Eletrocardiograma (ECG)", "225120")

            ElseIf txtProcedimentoPrincipal.SelectedValue = "0905010035" Then
                procedSec.Add("0301010072", "0301010072 - Consulta médica na atenção especializada")
                procedSec.Add("0211060020", "0211060020 - Biomicroscopia de fundo de olho")
                procedSec.Add("0211060127", "0211060127 - Mapeamento de retina")
                procedSec.Add("0211060259", "0211060259 - Tonometria")
                cbo.Add("225265", "225265 - Médico Oftalmologista")
                dgvProcedimentos.Rows.Add("0301010072", "1", "Consulta médica na atenção especializada", "225265")
                dgvProcedimentos.Rows.Add("0211060020", "1", "Biomicroscopia de fundo de olho", "225265")
                dgvProcedimentos.Rows.Add("0211060127", "1", "Mapeamento de retina", "225265")
                dgvProcedimentos.Rows.Add("0211060259", "1", "Tonometria", "225265")

            ElseIf txtProcedimentoPrincipal.SelectedValue = "0903010011" Then
                cbo.Add("225270", "225270 - Médico ortopedista e traumatologista")
                procedSec.Add("0204020034", "0204020034 - RADIOGRAFIA DE COLUNA CERVICAL (AP + LATERAL + TO + OBLÍQUAS)")
                procedSec.Add("0204020042", "0204020042 - RADIOGRAFIA DE COLUNA CERVICAL (AP + LATERAL + TO / FLEXÃO)")
                procedSec.Add("0204020077", "0204020077 - RADIOGRAFIA DE COLUNA LOMBO-SACRA (C/ OBLÍQUAS)")
                procedSec.Add("0204020085", "0204020085 - RADIOGRAFIA DE COLUNA LOMBO-SACRA FUNCIONAL / DINÂMICA")
                procedSec.Add("0204020093", "0204020093 - RADIOGRAFIA DE COLUNA TORÁCICA (AP + LATERAL)")
                procedSec.Add("0204020107", "0204020107 - RADIOGRAFIA DE COLUNA TORACO-LOMBAR")
                procedSec.Add("0204020131", "0204020131 - RADIOGRAFIA PANORÂMICA DE COLUNA TOTAL - TELESPONDILOGRAFIA")

                procedSec.Add("0204040035", "0204040035 - RADIOGRAFIA DE ARTICULAÇÃO ESCÁPULO-UMERAL")
                procedSec.Add("0204040078", "0204040078 - RADIOGRAFIA DE COTOVELO")
                procedSec.Add("0204040094", "0204040094 - RADIOGRAFIA DE MÃO")
                procedSec.Add("0204040116", "0204040116 - RADIOGRAFIA DE ESCÁPULA/OMBRO (TRÊS POSIÇÕES)")
                procedSec.Add("0204040124", "0204040124 - RADIOGRAFIA DE PUNHO (AP + LATERAL + OBLÍQUA)")

                procedSec.Add("0204060060", "0204060060 - RADIOGRAFIA DE ARTICULAÇÃO COXO-FEMORAL")
                procedSec.Add("0204060095", "0204060095 - RADIOGRAFIA DE BACIA")
                procedSec.Add("0204060109", "0204060109 - RADIOGRAFIA DE CALCÂNEO")
                procedSec.Add("0204060125", "0204060125 - RADIOGRAFIA DE JOELHO (AP + LATERAL)")
                procedSec.Add("0204060133", "0204060133 - RADIOGRAFIA DE JOELHO OU PATELA (AP + LATERAL + AXIAL)")
                procedSec.Add("0204060141", "0204060141 - RADIOGRAFIA DE JOELHO OU PATELA (AP + LATERAL + OBLÍQUA + 3)")
                procedSec.Add("0204060150", "0204060150 - RADIOGRAFIA DE PÉ / DEDOS DO PÉ")
                procedSec.Add("0204060176", "0204060176 - RADIOGRAFIA PANORÂMICA DE MEMBROS INFERIORES")

                procedSec.Add("0301010072", "0301010072 - Consulta médica na atenção especializada")
                procedSec.Add("0301010307", "0301010307 - TELECONSULTA MÉDICA NA ATENÇÃO ESPECIALIZADA")

                dgvProcedimentos.Rows.Add("0301010072", "1", "Consulta médica na atenção especializada", "225270")

            ElseIf txtProcedimentoPrincipal.SelectedValue = "0904010031" Then
                procedSec.Add("0301010072", "0301010072 - Consulta médica na atenção especializada")
                procedSec.Add("0209040025", "0209040025 - Laringoscopia")
                procedSec.Add("0209040041", "0209040041 - Videolaringoscopia")
                cbo.Add("225275", "225275 - Médico Otorrinolaringologista")
                dgvProcedimentos.Rows.Add("0301010072", "1", "Consulta médica na atenção especializada", "225275")
                dgvProcedimentos.Rows.Add("0209040025", "1", "Laringoscopia", "225275")
                dgvProcedimentos.Rows.Add("0209040041", "1", "Videolaringoscopia", "225275")

            End If

            If txtProcedimentoPrincipal.SelectedIndex >= 0 Then

                CodProcedimento.DataSource = New BindingSource(procedSec, Nothing)
                CodProcedimento.DisplayMember = "Value"   ' O que aparece para o usuário
                CodProcedimento.ValueMember = "Key"
                CodProcedimento.SelectedIndex = 0

            Else

                CodProcedimento.DataSource = Nothing

            End If

            CBOmed.DataSource = New BindingSource(cbo, Nothing)
            CBOmed.DisplayMember = "Value"   ' O que aparece para o usuário
            CBOmed.ValueMember = "Key"
            CBOmed.SelectedIndex = 0
            Quantidade.Text = "1"

            getServersSUS()
            Dim queryCID As String = $"SELECT cid.cid,cid.descricao FROM cid 
        JOIN cod_oci_principal ON cid.id_oci_principal = cod_oci_principal.id
        WHERE cod_oci_principal.cod ='{txtProcedimentoPrincipal.SelectedValue}'"
            FormAMEmain.loadComboBox(queryCID, txtCidPrincipal, "descricao", "cid")
            FormAMEmain.loadComboBox(queryCID, txtCidSecundario, "descricao", "cid")

            txtCidSecundario.SelectedIndex = -1

        Catch ex As Exception

        End Try

    End Sub

End Class
Public Class ApacRegistro
    Public Property NumeroApac As String
    Public Property NomePaciente As String
    Public Property DtnascPaciente As Date
    Public Property CPFPaciente As String
    Public Property MaePaciente As String
    Public Property CEPPaciente As String
    Public Property TipoLograPaciente As String
    Public Property LograPaciente As String
    Public Property BairroPaciente As String
    Public Property numeroResPaciente As String
    Public Property complementoPaciente As String
    Public Property TelPaciente As String
    Public Property ProcedimentoPrincipal As String
    Public Property SUSMedicoExecutante As String
    Public Property data As Date
    Public Property competencia As String
End Class
