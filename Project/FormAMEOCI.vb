Imports System.Globalization
Imports System.IO
Imports System.Text
Imports ClosedXML.Excel

Public Class FormAMEOCI
    Private linhas As New List(Of String)
    Dim m As New Main
    Dim result As DataTable
    Dim endereco As DataTable
    Dim queue As DataTable
    Dim cepObj As New CEP()
    Dim consulta As New CADSUS
    ' Variáveis globais
    Public popupGrid As DataGridView
    Private debounceTimer As New Timer() With {.Interval = 300}
    Friend isLoading As Boolean = False
    Private isQueue As Boolean = False
    Friend IDpacienteSelecionado As Integer? = Nothing
    Private updateMode As Boolean = False

    Private nasc = Nothing
    Private nome = Nothing
    Private sexo = Nothing
    Private cpf = Nothing
    Private mae = Nothing
    Private raca = Nothing
    Private ddd = Nothing
    Private telefone = Nothing
    Private cepRes = Nothing
    Private numero = Nothing
    Private complemento = Nothing
    Private colapsed As Boolean = False
    Public Property idUser As Integer

    ''' <summary>
    ''' Converte a competência no formato usado pelos arquivos .JUL e por
    ''' My.Settings.OCIcompetencia (AAAAMM, ex: "202608") pro formato guardado
    ''' na coluna oci.compet do banco (mês abreviado/ano, ex: "AGO/2026").
    ''' Use essa função em QUALQUER lugar que precise comparar ou gravar
    ''' compet= no banco a partir de uma competência em formato AAAAMM -
    ''' os dois formatos não são iguais e comparar um com o outro direto
    ''' (sem converter) nunca dá match (foi o que causava o "Nenhuma APAC
    ''' encontrada" no RegerarLoteCompetencia antes desse fix).
    ''' </summary>
    Public Function CompetenciaParaBanco(competenciaAAAAMM As String) As String
        Return MonthName(Convert.ToInt32(competenciaAAAAMM.Substring(4, 2)), True).ToUpper & "/" & competenciaAAAAMM.Substring(0, 4)
    End Function

    Public Function competencia(compet As String)
        compet = CompetenciaParaBanco(compet)
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
    Private Function saveAPAC(Optional silencioso As Boolean = False, Optional ByRef mensagemErro As String = "")
        If Not txtNumApac.Text.Length = 13 Then
            FalharValidacao(mensagemErro, silencioso, "Preencha o número da APAC corretamente.", txtNumApac)
            Return False
        End If
        If txtCNSMedicoExecutante.SelectedIndex = -1 Then
            FalharValidacao(mensagemErro, silencioso, "Selecione o médico.", txtCNSMedicoExecutante)
            Return False
        End If
        If txtProcedimentoPrincipal.SelectedIndex = -1 Then
            FalharValidacao(mensagemErro, silencioso, "Selecione o procedimento principal.", txtProcedimentoPrincipal)
            Return False
        End If
        If dgvProcedimentos.Rows.Count <= 1 Then
            If Not silencioso Then CodProcedimento.DroppedDown = True
            FalharValidacao(mensagemErro, silencioso, "Adicione um procedimento secundário.", CodProcedimento, 1)
            Return False
        End If
        If txtNomeMedicoSolicitante.Text = txtNomeAutorizador.Text Then
            If Not silencioso Then txtNomeAutorizador.DroppedDown = True
            FalharValidacao(mensagemErro, silencioso, "Os medicos Solicitante e Autorizador nao podem ser os mesmos.", txtNomeAutorizador, 1)
            Return False
        End If

        Dim idPac As Object = IDpacienteSelecionado
        Dim idEnd As Integer = 0
        Dim telfixo As String = ""
        Try

            If endereco Is Nothing OrElse endereco.Rows.Count = 0 Then
                ' Endereço é obrigatório - antes isso caía em idEnd=0 silenciosamente
                ' para paciente novo (sem nenhum aviso), permitindo gravar com um
                ' id_logradouro inválido. Agora bloqueia em qualquer um dos dois casos
                ' (paciente novo ou existente).
                FalharValidacao(mensagemErro, silencioso, "Endereço inválido.")
                Return False
            Else
                idEnd = endereco.Rows(0).Item("id")
            End If


            If txtTelefone.Text.Length < 8 Or txtDDD.Text.Length < 2 Then
                FalharValidacao(mensagemErro, silencioso, "Telefone inválido.")
                Return False
            Else
                If txtTelefone.Text.Length = 8 Then
                    telfixo = txtTelefone.Text.Insert(4, "-")
                Else
                    telfixo = txtTelefone.Text.Insert(5, "-")
                End If
            End If

            'If txtTelefone.Text.Length = 8 Then
            '    telfixo = txtTelefone.Text.Insert(4, "-")
            'Else
            '    telfixo = txtTelefone.Text.Insert(5, "-")
            'End If

            If idPac = Nothing Then

                Try
                    idPac = FormAMEmain.doQuery($"INSERT INTO pacientes (nome, dtnasc, mae, tel, cpf, id_logradouro, numero, complemento, sexo, raca, sus) VALUES ('{txtNomePaciente.Text.Trim()}', '{m.mysqlDateFormat(dtNascimento.Text)}', '{txtNomeMae.Text.Trim()}', '({txtDDD.Text}){telfixo}', '{txtCpfPaciente.Text.Trim()}',{idEnd}, '{txtNumero.Text.Trim()}', '{txtComplemento.Text.Trim()}', '{txtSexo.Text}', '{txtRaca.SelectedValue}', '{txtCnsPaciente.Text}')")

                Catch ex As Exception
                    mensagemErro = ex.Message
                    If Not silencioso Then MsgBox(ex.Message)
                    Return False
                End Try

            Else

                If detectChanges() Then
                    ' Antes, o retorno de atPac() era ignorado: se o endereço (ou nome,
                    ' CPF, telefone etc.) fosse inválido, atPac() mostrava o erro mas
                    ' saveAPAC() continuava e gravava a APAC mesmo assim. Agora aborta.
                    If Not atPac(silencioso, mensagemErro) Then
                        Return False
                    End If
                End If

            End If

            If txtProcedimentoPrincipal.SelectedValue Is Nothing Then
                Throw New Exception("Procedimento principal inválido.")
            End If

            Try

                Dim cidSec = If(txtCidSecundario.SelectedValue Is Nothing, "''", $"'{txtCidSecundario.SelectedValue}'")
                Dim procedSec = If(CodProcedimento.SelectedValue Is Nothing, "''", $"'{CodProcedimento.SelectedValue}'")

                ' situacao_rua/sem_cpf gravados como 0/1 (colunas TINYINT(1)); motivo_saida
                ' como o código de 2 dígitos mesmo (ex "12", "18") - ver ALTER TABLE enviado.
                Dim situacaoRuaVal As Integer = If(chkSituacaoRua.Checked, 1, 0)
                Dim semCpfVal As Integer = If(chkSemCpf.Checked, 1, 0)

                Dim query = $"UPDATE oci SET compet='{competencia(My.Settings.OCIcompetencia)}', data='{m.mysqlDateFormat(dtValidadeIni.Value)}', id_paciente={idPac}, id_medico='{txtCNSMedicoExecutante.SelectedValue}',  id_autorizador='{txtNomeAutorizador.SelectedValue}',  id_cod_principal={getProcedID(txtProcedimentoPrincipal.SelectedValue)}, cid_principal='{txtCidPrincipal.SelectedValue}', cid_sec={cidSec}, situacao_rua={situacaoRuaVal}, motivo_saida='{txtMotivoSaida.SelectedValue}', sem_cpf={semCpfVal}, status='CONC', id_usuario={idUser} WHERE num_apac='{txtNumApac.Text}'"


                If FormAMEmain.doQuery(query) Then

                    If txtProcedimentoPrincipal.SelectedValue = "0903010011" Then

                        For Each row As DataGridViewRow In dgvProcedimentos.Rows
                            If row.IsNewRow Then Continue For
                            If row.Cells(0).Value = "0301010072" Then Continue For ' Procedimento obrigatório, mas não deve ser inserido na tabela de secundários
                            Dim codProcSec = If(row.Cells(0).Value Is Nothing, "''", $"'{row.Cells(0).Value}'")
                            Dim cboSec = If(row.Cells(3).Value Is Nothing, "''", $"'{row.Cells(3).Value}'")
                            FormAMEmain.doQuery($"INSERT INTO procedimentos_secundarios (data, num_apac, id_paciente, cod_proced_secundario, qtd, cbo, medico_solicitante) VALUES ('{m.mysqlDateFormat(dtValidadeIni.Value)}', '{txtNumApac.Text}', {idPac}, {codProcSec}, {row.Cells(1).Value}, {cboSec}, '{txtCNSMedicoExecutante.SelectedValue}')")
                        Next

                    End If

                    btNovonumeroAPAC.Enabled = True
                    FormAMEOCINumAPAC.loadNUMAPAC(dgOCIcadastradas, Nothing, Nothing, False, idUser,,,, , (dtpSearchData.Value), "data_lanc DESC",,, lbStatusCads)
                    'txtNumApac.Text = GetAndLockNextApac()
                    IDpacienteSelecionado = Nothing

                    If isQueue Then
                        Dim queryUpdateQueue = $"UPDATE oci_fila SET status=1 WHERE id={dgQueueItens.SelectedRows.Item(0).Cells(0).Value}"
                        FormAMEmain.doQuery(queryUpdateQueue)
                        loadQueueOCI()
                        isQueue = False
                    End If

                End If

            Catch ex As Exception
                If ex.Message.Contains("Duplicate entry") Then
                    result.Clear()
                    If Not silencioso Then btnovo.PerformClick()
                    Return True
                Else
                    mensagemErro = ex.Message
                    Return False
                End If

            End Try

            result.Clear()
            If Not silencioso Then btnovo.PerformClick()
            Return True

        Catch ex As Exception
            mensagemErro = ex.Message
            If Not silencioso Then MsgBox("Erro ao salvar APAC: " & ex.Message)
            Return False
        End Try

    End Function
    Private Function atPac(Optional silencioso As Boolean = False, Optional ByRef mensagemErro As String = "")
        Dim idPac As Object = IDpacienteSelecionado
        Dim idEnd As Integer
        Dim telfixo As String

        If Not idPac = Nothing Then

            If endereco Is Nothing OrElse endereco.Rows.Count = 0 Then
                FalharValidacao(mensagemErro, silencioso, "Endereço inválido.")
                Return False
            Else
                idEnd = endereco.Rows(0).Item("id")
            End If

            If dtNascimento.Text.Length < 10 Then
                FalharValidacao(mensagemErro, silencioso, "Data de nascimento inválida.")
                Return False
            End If

            If txtNomePaciente.Text.Length < 4 Then
                FalharValidacao(mensagemErro, silencioso, "Nome inválido.")
                Return False
            End If

            If txtSexo.Text = Nothing Then
                FalharValidacao(mensagemErro, silencioso, "Sexo inválido.")
                Return False
            End If

            If txtRaca.SelectedValue < 0 Then
                FalharValidacao(mensagemErro, silencioso, "Raça inválida.")
                Return False
            End If

            If Not chkSemCpf.Checked Then
                If txtCpfPaciente.Text.Length < 11 Then
                    FalharValidacao(mensagemErro, silencioso, "CPF inválido.")
                    Return False
                End If
            End If

            If txtNomeMae.Text.Length < 3 Then
                FalharValidacao(mensagemErro, silencioso, "Nome da mãe inválido.")
                Return False
            End If

            If txtTelefone.Text.Length < 8 Or txtDDD.Text.Length < 2 Then
                FalharValidacao(mensagemErro, silencioso, "Telefone inválido.")
                Return False
            Else
                If txtTelefone.Text.Length = 8 Then
                    telfixo = txtTelefone.Text.Insert(4, "-")
                Else
                    telfixo = txtTelefone.Text.Insert(5, "-")
                End If
            End If

            If txtNumero.Text.Length < 1 Then
                FalharValidacao(mensagemErro, silencioso, "Número inválido.")
                Return False
            End If

            Try
                FormAMEmain.doQuery($"UPDATE pacientes SET dtnasc='{m.mysqlDateFormat(dtNascimento.Text)}', cpf='{txtCpfPaciente.Text.Trim()}', nome='{txtNomePaciente.Text}',mae='{txtNomeMae.Text.Trim()}', tel='({txtDDD.Text}){telfixo}', id_logradouro={idEnd}, numero='{txtNumero.Text.Trim()}', complemento='{txtComplemento.Text.Trim()}', sexo='{txtSexo.Text}', raca='{txtRaca.SelectedValue}', sus='{txtCnsPaciente.Text}' WHERE id={idPac}")
                If txtNumApac.Text.Length = 13 Then
                    UnlockApac(txtNumApac.Text)
                End If
                Return True
                ' MessageBox.Show("✅ Dados do paciente atualizados!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                mensagemErro = ex.Message
                If Not silencioso Then MsgBox("UPDATE " & ex.Message)
                Return False
            End Try

        Else
            FalharValidacao(mensagemErro, silencioso, "Selecione um paciente por data de nascimento, nome ou CPF")
            Return False
        End If

    End Function
    Private Sub btAtualizarDados_Click(sender As Object, e As EventArgs) Handles btAtualizarDados.Click
        If atPac() Then
            MessageBox.Show("✅ Dados do paciente atualizados!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    ''' <summary>
    ''' Centraliza o padrão de "falha de validação" usado em addAPAC()/saveAPAC()/
    ''' atPac(): quando silencioso=True (uso em lote), só registra a mensagem em
    ''' mensagemErro, sem popup nem troca de aba/foco - quem chamou decide o que
    ''' fazer com o erro. Quando silencioso=False (uso interativo de sempre), mantém
    ''' o comportamento de sempre (popup + foco/aba, quando informados).
    ''' </summary>
    Private Sub FalharValidacao(ByRef mensagemErro As String, silencioso As Boolean, mensagem As String, Optional foco As Control = Nothing, Optional aba As Integer = -1)
        mensagemErro = mensagem
        If silencioso Then Exit Sub
        If aba >= 0 Then TabControl1.SelectedTab = TabControl1.TabPages(aba)
        If foco IsNot Nothing Then foco.Focus()
        MessageBox.Show(mensagem, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    ''' <summary>
    ''' Valida e grava a APAC atual - no banco (via saveAPAC) e no arquivo .JUL.
    ''' Aceita opcionalmente um ApacRegistro pronto ("dados"): quando informado, ele é
    ''' jogado nos controles da tela (PreencherTelaComDados) antes de qualquer
    ''' validação, então tanto o uso interativo (clicar em Gravar, dados=Nothing, lê
    ''' o que já está na tela) quanto o uso em lote/programático (dados vindo do
    ''' banco, sem tela nenhuma envolvida por quem chama) passam pela MESMA lógica de
    ''' validação e escrita - não existem dois caminhos divergentes.
    '''
    ''' "silencioso" troca os MessageBox.Show() de validação/sucesso por só preencher
    ''' "mensagemErro" (ByRef) e retornar False/True - essencial pra rodar em lote sem
    ''' travar esperando clique em cada uma de possivelmente centenas de APACs.
    ''' </summary>
    Public Function addAPAC(Optional dados As ApacRegistro = Nothing, Optional silencioso As Boolean = False, Optional ByRef mensagemErro As String = "") As Boolean
        Try
            If dados IsNot Nothing Then
                PreencherTelaComDados(dados)
            End If

            ' ==================== VALIDAÇÕES ====================
            If CDate(dtValidadeIni.Value).Month <> My.Settings.OCIcompetencia.Substring(4) Then
                FalharValidacao(mensagemErro, silencioso, "Data inicial fora da competência atual.", dtValidadeIni, 0)
                Return False
            End If

            If txtNumApac.Text.Trim() = "" Then
                FalharValidacao(mensagemErro, silencioso, "Informe o número da APAC.", txtNumApac, 0)
                Return False
            End If

            If Not chkSemCpf.Checked Then
                If Not m.ValidarCPF(txtCpfPaciente.Text) Then
                    FalharValidacao(mensagemErro, silencioso, "CPF inválido. Verifique e tente novamente.", txtCpfPaciente, 0)
                    Return False
                End If
            End If

            ' Não usa Text.Trim()="" aqui: dtNascimento é MaskedTextBox e, vazio, o Text
            ' vem cheio de caracteres de máscara/literais (ex: "  /  /    ") que sobrevivem
            ' ao Trim() - a comparação com "" nunca detectava isso, deixando passar direto
            ' pra frente e só quebrando bem mais tarde, ao montar o registro 14, com um erro
            ' de conversão de data bem mais confuso. MaskCompleted é a forma correta de
            ' checar "todos os dígitos da máscara foram preenchidos", direto da própria
            ' MaskedTextBox, independente do caractere de prompt usado.
            If Not dtNascimento.MaskCompleted Then
                If Not silencioso Then chkResponsavel()
                FalharValidacao(mensagemErro, silencioso, "Informe a data de nascimento Do paciente.", dtNascimento, 0)
                Return False
            End If

            If txtProcedimentoPrincipal.SelectedValue = "0905010035" AndAlso CInt(m.AgeInMonths(m.mysqlDateFormat(dtNascimento.Text), m.mysqlDateFormat(dtValidadeIni.Value))) < 108 Then
                FalharValidacao(mensagemErro, silencioso, "Paciente com idade inferior a 9 anos não permitido para procedimento 0905010035.", Nothing, 0)
                Return False
            End If

            If txtProcedimentoPrincipal.SelectedValue = "0902010026" AndAlso CInt(m.AgeInMonths(m.mysqlDateFormat(dtNascimento.Text), m.mysqlDateFormat(dtValidadeIni.Value))) < 144 Then
                FalharValidacao(mensagemErro, silencioso, "Paciente com idade inferior a 12 anos não permitido para procedimento 0902010026.", Nothing, 0)
                Return False
            End If

            If txtNomePaciente.Text.Trim() = "" Then
                FalharValidacao(mensagemErro, silencioso, "Informe o nome Do paciente.", txtNomePaciente, 0)
                Return False
            End If
            If txtNomeMae.Text.Trim() = "" Then
                FalharValidacao(mensagemErro, silencioso, "Informe o nome da mãe.", txtNomeMae, 0)
                Return False
            End If
            If txtSexo.Text = "" Then
                FalharValidacao(mensagemErro, silencioso, "Informe o sexo.", txtSexo, 0)
                Return False
            End If
            If txtNomeRespPaciente.Text.Trim() = "" Then
                If Not chkResponsavel() Then
                    FalharValidacao(mensagemErro, silencioso, "Informe o nome Do responsável.", txtNomeRespPaciente, 0)
                    Return False
                End If
            End If
            If txtDDD.Text.Trim() = "" OrElse txtDDD.Text.Length < 2 Then
                FalharValidacao(mensagemErro, silencioso, "Informe o DDD.", txtDDD, 0)
                Return False
            End If
            If txtTelefone.Text.Trim() = "" OrElse txtTelefone.Text.Length < 8 Then
                FalharValidacao(mensagemErro, silencioso, "Informe o telefone.", txtTelefone, 0)
                Return False
            End If
            If txtCep.Text.Length < 8 Then
                FalharValidacao(mensagemErro, silencioso, "Informe o CEP corretamente.", txtCep, 0)
                Return False
            End If
            If txtNumero.Text.Trim() = "" Then
                FalharValidacao(mensagemErro, silencioso, "Informe o número Do logradouro.", txtNumero, 0)
                Return False
            End If
            If txtProcedimentoPrincipal.SelectedIndex < 0 Then
                If Not silencioso Then txtProcedimentoPrincipal.DroppedDown = True
                FalharValidacao(mensagemErro, silencioso, "Selecione o procedimento principal.", txtProcedimentoPrincipal, 1)
                Return False
            End If
            If txtRaca.SelectedIndex < 0 Then
                FalharValidacao(mensagemErro, silencioso, "Informe a raça.", txtRaca, 0)
                Return False
            End If

            ' ==================== CONFIGURAÇÕES ====================
            Dim competencia As String = My.Settings.OCIcompetencia
            Dim caminhoArquivo As String = Path.Combine(Application.StartupPath & "\APAC\EXPORTADOS", "AP" & competencia & chkMonthEXT())
            If Not Directory.Exists(Application.StartupPath & "\APAC\EXPORTADOS") Then
                Directory.CreateDirectory(Application.StartupPath & "\APAC\EXPORTADOS")
            End If

            ' ==================== GRAVA NO BANCO PRIMEIRO ====================
            ' IMPORTANTE: só gravamos no arquivo .JUL DEPOIS que saveAPAC() confirmar
            ' que passou em todas as validações (CNS, procedimento principal, médicos
            ' repetidos etc.). Gravar o arquivo antes disso deixava blocos de registros
            ' (14/06/13) órfãos no .JUL sempre que saveAPAC() falhava - e como a tela
            ' e a grid de procedimentos não eram limpas nesse caso, o próximo paciente
            ' herdava/duplicava os procedimentos do atendimento anterior.
            If Not updateMode Then
                If ExisteLancamentoDuplicado(competencia, txtNumApac.Text, txtProcedimentoPrincipal.SelectedValue, dtValidadeIni.Value) Then
                    FalharValidacao(mensagemErro, silencioso, $"Já existe uma APAC {txtNumApac.Text.Trim()} gravada com o mesmo procedimento principal e a mesma data inicial. Confira se não é duplicidade antes de gravar de novo.", txtNumApac, 0)
                    Return False
                End If
            End If

            If Not saveAPAC(silencioso, mensagemErro) Then
                Return False
            End If

            If updateMode Then
                RemoverRegistroApac($"14{competencia}{txtNumApac.Text}")
            End If


            ' ==================== CRIA STREAM ÚNICO ====================
            Using fs As New FileStream(caminhoArquivo, FileMode.Append, FileAccess.Write, FileShare.None)
                Using sw As New StreamWriter(fs, Encoding.GetEncoding("iso-8859-1"))
                    ' ================= HEADER (01) =================
                    If fs.Length = 0 Then
                        ' Antes fixo em "000001", errado sempre que mais de uma APAC cai
                        ' nesse mesmo arquivo (o normal, já que o arquivo é reaberto em modo
                        ' Append). Usa a quantidade real de APACs CONC dessa competência até
                        ' agora - ainda pode ficar defasado se mais APACs forem adicionadas
                        ' DEPOIS (o header não é reescrito), mas já é bem mais correto que um
                        ' valor fixo. RegenerarLoteCompetencia() sempre grava a contagem final
                        ' certa, porque reconstrói o arquivo inteiro de uma vez.
                        Dim qtdApacsCompetencia As Integer = 1
                        Try
                            qtdApacsCompetencia = Convert.ToInt32(FormAMEmain.getDataset($"SELECT COUNT(*) AS qtd FROM oci WHERE compet='{CompetenciaParaBanco(competencia)}' AND status='CONC'").Rows(0).Item("qtd"))
                            If qtdApacsCompetencia < 1 Then qtdApacsCompetencia = 1
                        Catch ex As Exception
                        End Try

                        sw.WriteLine(MontarHeaderApac(competencia, qtdApacsCompetencia))
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
                    r14.Append(FmtR(txtNumero.Text, 5))
                    r14.Append(If(txtComplemento.Text <> "", RemoverAcentos(FmtR(txtComplemento.Text, 10)), New String(" "c, 10)))
                    r14.Append(FmtR(txtCep.Text.Replace("-", ""), 8))
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
                    r14.Append(New String(" "c, 15)) 'SUS paciente em branco para evitar conflito
                    r14.Append(txtNomeMedicoSolicitante.SelectedValue.PadLeft(15, "0"c))
                    r14.Append(txtNomeAutorizador.SelectedValue.PadLeft(15, "0"c))
                    r14.Append(New String(" "c, 4)) ' Reservado
                    r14.Append(If(txtProntuario.Text <> "", FmtR(txtProntuario.Text, 10), New String(" "c, 10)))
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
                    'r14.Append(txtBairro.Text.PadRight(30, " "c))
                    r14.Append(Fmt(txtBairro.Text, 30))
                    r14.Append(FmtL(txtDDD.Text, 2))
                    r14.Append(FmtL(txtTelefone.Text, 9)) ' <- campo que causou o desalinhamento (espaço perdido no telefone)
                    r14.Append(FmtR(txtEmail.Text, 40))
                    r14.Append(txtCNSMedicoExecutante.SelectedValue.PadLeft(15, "0"c))
                    r14.Append(txtCpfPaciente.Text.Trim.PadLeft(11, "0"c))
                    r14.Append(FmtL(txtEquipe.Text, 10))
                    r14.Append(If(chkSituacaoRua.Checked, "S", "N"))
                    ' 49 - Fonte Orçamentária (2 posições, 534-535) - opcional, mantém em branco
                    r14.Append("  ")

                    ' 50 - Emendas Parlamentares
                    r14.Append("N")

                    ' 51 - Pessoa sem CPF/Registro Civil
                    r14.Append(If(chkSemCpf.Checked, "S", "N"))

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

                    Dim codigosJaGravados As New HashSet(Of String)()
                    For Each row As DataGridViewRow In dgvProcedimentos.Rows
                        If row.IsNewRow Then Continue For
                        Dim codigoLinha As String = row.Cells(0).Value.ToString()
                        ' Evita gravar o mesmo código de procedimento secundário mais de uma vez
                        ' na mesma APAC (proteção extra contra duplicidade na grid).
                        If Not codigosJaGravados.Add(codigoLinha) Then Continue For
                        Dim r13 As New StringBuilder()
                        r13.Append("13")
                        r13.Append(competencia)
                        r13.Append(txtNumApac.Text.PadLeft(13, "0"c))
                        r13.Append(codigoLinha.PadLeft(10, "0"c))
                        r13.Append(row.Cells(3).Value.ToString().PadLeft(6, "0"c))
                        r13.Append(row.Cells(1).Value.ToString().PadLeft(7, "0"c))
                        r13.Append(New String(" "c, 53))
                        sw.WriteLine(r13.ToString())
                    Next
                End Using
            End Using

            ' saveAPAC() já foi confirmado com sucesso lá em cima (ver "Return" acima
            ' caso tivesse falhado), então prossegue direto para o pós-gravação/reset da tela.
            If Not silencioso Then
                If updateMode Then
                    MessageBox.Show("✅ APAC atualizada!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("✅ Paciente adicionado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
            Dim selectedCNSExe As Integer = txtCNSMedicoExecutante.SelectedIndex
            Dim selectedAutorizador As Integer = txtNomeAutorizador.SelectedIndex
            Dim selectedCIDP As Integer = txtCidPrincipal.SelectedIndex
            Dim selectedCIDS As Integer = txtCidSecundario.SelectedIndex
            txtProcedimentoPrincipal_SelectedValueChanged(Nothing, Nothing)
            If Not silencioso Then
                TabControl1.SelectedTab = TabControl1.TabPages(0)  ' ativa a terceira aba (0-based)
            End If
            txtCNSMedicoExecutante.SelectedIndex = selectedCNSExe
            txtNomeAutorizador.SelectedIndex = selectedAutorizador
            txtCidPrincipal.SelectedIndex = selectedCIDP
            txtCidSecundario.SelectedIndex = selectedCIDS
            updateMode = False
            clearFields()
            mensagemErro = ""
            Return True
        Catch ex As Exception
            mensagemErro = ex.Message
            If Not silencioso Then
                MessageBox.Show("⚠️ Erro ao gravar registro: " & ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Verifica se já existe, no .JUL da competência informada, um lançamento com o
    ''' MESMO num_apac + MESMO procedimento principal + MESMA data inicial (dtValidadeIni).
    ''' Usado antes de saveAPAC() pra barrar duplicidade de verdade (ex: dois cliques em
    ''' "Gravar" sem querer) antes que vire registro duplicado no banco E no arquivo -
    ''' se a checagem só rodasse na hora de escrever o .JUL, o INSERT no banco já teria
    ''' acontecido de qualquer jeito.
    '''
    ''' Posições calculadas direto da ordem de r14.Append(...)/r13Principal.Append(...)
    ''' em addAPAC(): "14"(2) + competencia(6) + numApac(13) + uf(2) + cnes(7) +
    ''' dataGeracao(8) + dtValidadeIni(8) -> numApac começa em 8, dtValidadeIni em 38.
    ''' "13"(2) + competencia(6) + numApac(13) + procedimento(10) -> procedimento
    ''' começa em 21.
    ''' </summary>
    Public Function ExisteLancamentoDuplicado(competencia As String, numApac As String, procedimentoPrincipal As String, dataInicial As Date) As Boolean
        Dim caminhoArquivo As String = Path.Combine(Application.StartupPath & "\APAC\EXPORTADOS", "AP" & competencia & chkMonthEXT())
        If Not File.Exists(caminhoArquivo) Then Return False

        Dim linhas = File.ReadAllLines(caminhoArquivo, Encoding.GetEncoding("iso-8859-1"))
        Dim numApacAlvo As String = numApac.Trim().PadLeft(13, "0"c)
        Dim dataAlvo As String = dataInicial.ToString("yyyyMMdd")
        Dim procedAlvo As String = procedimentoPrincipal.Trim().PadLeft(10, "0"c)

        For i As Integer = 0 To linhas.Length - 1
            Dim linha = linhas(i)
            If Not linha.StartsWith("14") OrElse linha.Length < 46 Then Continue For
            If linha.Substring(8, 13) <> numApacAlvo Then Continue For
            If linha.Substring(38, 8) <> dataAlvo Then Continue For

            ' Achou "14" com mesmo num_apac + mesma data - confere o procedimento
            ' principal, que é sempre o "13" duas linhas depois (14, 06, 13-principal).
            If i + 2 < linhas.Length Then
                Dim linha13Principal = linhas(i + 2)
                If linha13Principal.StartsWith("13") AndAlso linha13Principal.Length >= 31 Then
                    If linha13Principal.Substring(21, 10) = procedAlvo Then
                        Return True
                    End If
                End If
            End If
        Next

        Return False
    End Function
    Private Sub btnAddPacAPAC_Click(sender As Object, e As EventArgs) Handles btnGerarArquivo.Click
        addAPAC()
    End Sub

    Public Sub RemoverRegistroApac(prefixoApac As String)
        Dim caminhoArquivo As String = Path.Combine(Application.StartupPath & "\APAC\EXPORTADOS", "AP" & My.Settings.OCIcompetencia & chkMonthEXT())

        ' Se o arquivo ainda nem existe (apagado manualmente, primeira geração dessa
        ' competência, ou "Gerar arquivo novamente" numa APAC que nunca foi escrita
        ' nesse arquivo específico) não tem nada pra remover - só sai. Sem essa
        ' checagem, File.ReadAllLines quebra com "Não foi possível localizar o
        ' arquivo" e a geração inteira falha por causa de um passo que era pra
        ' ser opcional (o registro novo ainda vai ser escrito normalmente depois).
        If Not File.Exists(caminhoArquivo) Then Exit Sub

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
        chkSemCpf.Checked = False
        txtMotivoSaida.SelectedIndex = 1 ' volta pro padrão "12 - ALTA MELHORADO"
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

    ''' <summary>
    ''' Preenche à direita e GARANTE o tamanho exato (corta o excedente), sem mexer em
    ''' acentuação/caixa. Diferente de usar .PadRight(tamanho) sozinho: PadRight nunca
    ''' encurta um texto que já é maior que "tamanho" - se isso acontecer num campo do
    ''' registro de largura fixa, TODO o resto da linha desliza uma ou mais posições
    ''' (foi exatamente isso que corrompeu CNS/CPF de um paciente por causa de um
    ''' espaço perdido no campo de telefone). Usar em campos de texto livre (telefone,
    ''' complemento, prontuário, e-mail, CEP etc.) em vez de .PadRight puro.
    ''' </summary>
    Private Function FmtR(valor As String, tamanho As Integer, Optional padChar As Char = " "c) As String
        If valor Is Nothing Then valor = ""
        valor = valor.Trim()
        Return valor.PadRight(tamanho, padChar).Substring(0, tamanho)
    End Function

    ''' <summary>
    ''' Igual ao FmtR, mas preenchendo/cortando pela ESQUERDA (mantém os dígitos mais à
    ''' direita quando precisa cortar) - usar em campos como DDD, telefone e equipe.
    ''' </summary>
    Private Function FmtL(valor As String, tamanho As Integer, Optional padChar As Char = " "c) As String
        If valor Is Nothing Then valor = ""
        valor = valor.Trim()
        If valor.Length > tamanho Then
            valor = valor.Substring(valor.Length - tamanho)
        End If
        Return valor.PadLeft(tamanho, padChar)
    End Function

    Public Function deleteProcedSec(APAC As String)
        Try
            Dim proced = dgvProcedimentos.CurrentRow.Cells(0).Value
            If proced = "0301010072" Then
                MessageBox.Show("Procedimento 0301010072 é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
            If m.msgQuestion("Excluir Procedimento?", "Atenção") Then
                FormAMEmain.doQuery($"DELETE FROM procedimentos_secundarios WHERE num_apac='{APAC}' AND cod_proced_secundario='{proced}'")
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub btnRemoverProcedimento_Click(sender As Object, e As EventArgs) Handles btnRemoverProcedimento.Click
        If dgvProcedimentos.SelectedRows.Count > 0 Then
            For Each row As DataGridViewRow In dgvProcedimentos.SelectedRows
                If Not row.IsNewRow Then

                    If txtProcedimentoPrincipal.SelectedValue = "0903010011" Then
                        If deleteProcedSec(txtNumApac.Text) Then
                            dgvProcedimentos.Rows.Remove(row)
                        End If
                        Exit Sub
                    End If

                    dgvProcedimentos.Rows.Remove(row)

                End If
            Next
        Else
            MessageBox.Show("Selecione um procedimento para remover.")
        End If
    End Sub
    Public Sub getMedSolicAut(Optional idstartIndexMedico As String = "")
        Dim main As New FormAMEmain
        Dim comboList As New List(Of System.Windows.Forms.ComboBox) From {
            txtCNSMedicoExecutante,
            txtNomeMedicoSolicitante
        }

        For Each cbb As ComboBox In comboList
            main.loadComboBox($"SELECT SUS, nome FROM servidores WHERE cbo ='{CBOmed.SelectedValue}'", cbb, "nome", "SUS", True)
        Next

        If idstartIndexMedico <> "" Then
            txtCNSMedicoExecutante.SelectedValue = idstartIndexMedico
            txtNomeMedicoSolicitante.SelectedValue = idstartIndexMedico
        End If

        main.loadComboBox($"Select SUS, nome FROM servidores WHERE oci_autorizador=1", txtNomeAutorizador, "nome", "SUS", True)

    End Sub
    Shared Function getPacientes(Optional ByVal cpf As String = Nothing, Optional nome As String = Nothing, Optional dtnasc As String = Nothing, Optional id As Integer = 0)
        Dim data As DataTable = Nothing
        Dim query As String = "Select pacientes.*, ceps_peruibe.cep As CEP,ceps_peruibe.tipo,ceps_peruibe.logradouro,ceps_peruibe.bairro
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
        Dim comboComp = FormAMEmain.getDataset("SELECT id, compet FROM oci WHERE compet IS NOT NULL AND compet <> '' GROUP BY compet ORDER BY data DESC")
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
    ''' <summary>
    ''' Monta um ApacRegistro com tudo que dá pra recuperar do banco pra uma OCI já
    ''' salva (id interno da tabela oci) - sem tocar em nenhum controle da tela.
    ''' Substitui a leitura que getOCIdata() fazia direto nos controles: agora ela é
    ''' feita aqui, num objeto, que tanto o carregamento pra edição (getOCIdata)
    ''' quanto a geração em lote (RegenerarLoteCompetencia) usam - o lote nunca
    ''' precisa abrir a tela.
    ''' </summary>
    Public Function MontarDadosApacDoOCI(idOci As Integer) As ApacRegistro
        Dim ociData = FormAMEmain.getDataset($"SELECT * FROM oci WHERE id={idOci}", True)
        If ociData Is Nothing OrElse ociData.Rows.Count = 0 Then
            Return Nothing
        End If
        Dim linhaOci = ociData.Rows(0)

        Dim idPac As Integer = Convert.ToInt32(linhaOci.Item("id_paciente"))
        Dim medicoCns As String = linhaOci.Item("id_medico").ToString()
        Dim autorizadorCns As String = linhaOci.Item("id_autorizador").ToString()

        Dim dados As New ApacRegistro With {
            .NumeroApac = linhaOci.Item("num_apac").ToString(),
            .competencia = linhaOci.Item("compet").ToString(),
            .data = Convert.ToDateTime(linhaOci.Item("data")),
            .IdPaciente = idPac,
            .SUSMedicoExecutante = medicoCns,
            .CnsExecutante = medicoCns,
            .CnsAutorizador = autorizadorCns,
            .ProcedimentoPrincipal = GetProcedCod(Convert.ToInt32(linhaOci.Item("id_cod_principal"))),
            .CidPrincipal = linhaOci.Item("cid_principal").ToString(),
            .CidSecundario = linhaOci.Item("cid_sec").ToString(),
            .SituacaoRua = If(Convert.ToBoolean(linhaOci.Item("situacao_rua")), "S", "N"),
            .MotivoSaida = linhaOci.Item("motivo_saida").ToString(),
            .SemCpf = If(Convert.ToBoolean(linhaOci.Item("sem_cpf")), "S", "N")
        }

        ' Nome do médico (mesma pessoa pro executante/solicitante nessa unidade) e
        ' do autorizador, via servidores (mesma tabela usada por getMedSolicAut).
        ' CBO do médico executante (registro 13 principal) também vem daqui.
        Try
            Dim medicoData = FormAMEmain.getDataset($"SELECT nome, cbo FROM servidores WHERE SUS='{medicoCns}'")
            If medicoData IsNot Nothing AndAlso medicoData.Rows.Count > 0 Then
                dados.NomeMedicoSolicitante = medicoData.Rows(0).Item("nome").ToString()
                dados.CboMedico = medicoData.Rows(0).Item("cbo").ToString()
            End If
        Catch ex As Exception
        End Try

        Try
            Dim autorizadorData = FormAMEmain.getDataset($"SELECT nome FROM servidores WHERE SUS='{autorizadorCns}'")
            If autorizadorData IsNot Nothing AndAlso autorizadorData.Rows.Count > 0 Then
                dados.NomeAutorizador = autorizadorData.Rows(0).Item("nome").ToString()
            End If
        Catch ex As Exception
        End Try

        ' Paciente + endereço (mesma query com JOIN em ceps_peruibe que getPacientes(id:=) usa).
        Try
            Dim pacData = getPacientes(, , , idPac)
            If pacData IsNot Nothing AndAlso pacData.Rows.Count > 0 Then
                Dim p = pacData.Rows(0)
                dados.NomePaciente = p.Item("nome").ToString()
                dados.MaePaciente = p.Item("mae").ToString()
                dados.CPFPaciente = p.Item("cpf").ToString()

                ' Isolado num Try próprio: se o dtnasc gravado no banco vier num formato
                ' que Convert.ToDateTime não engole (ex: data zerada '0000-00-00' do MySQL),
                ' isso NÃO pode derrubar sexo/raça/endereço/telefone junto - antes de isolar,
                ' uma exceção aqui interrompia o bloco inteiro e todos esses campos ficavam
                ' em branco silenciosamente, sem nenhum aviso.
                Try
                    dados.DtnascPaciente = Convert.ToDateTime(p.Item("dtnasc"))
                Catch ex As Exception
                End Try

                dados.SexoPaciente = p.Item("sexo").ToString()
                dados.Raca = p.Item("raca").ToString()
                dados.NomeResponsavelPaciente = If(m.CalcularIdade(dados.DtnascPaciente) >= 18, dados.NomePaciente, dados.MaePaciente)

                If Convert.ToInt32(p.Item("id_logradouro")) <> 0 Then
                    dados.IdEndereco = Convert.ToInt32(p.Item("id_logradouro"))
                    dados.CEPPaciente = p.Item("cep").ToString()
                    dados.numeroResPaciente = p.Item("numero").ToString()
                    dados.complementoPaciente = p.Item("complemento").ToString()
                    dados.LograPaciente = p.Item("logradouro").ToString()
                    dados.BairroPaciente = p.Item("bairro").ToString()

                    ' "tipo" vem como descrição (ex "RUA"); TipoLograPaciente precisa do
                    ' código (ex "081") - mesmo mapeamento reverso usado na tela (Sub cep()).
                    Dim tipoDescricao As String = p.Item("tipo").ToString()
                    Dim tiposLogradouro As New Dictionary(Of String, String) From {
                        {"081", "RUA"}, {"008", "AVENIDA"}, {"031", "ESTRADA"},
                        {"004", "ALAMEDA"}, {"065", "PRAÇA"}, {"105", "VIELA"}, {"095", "SETOR"}
                    }
                    Dim itemTipo = tiposLogradouro.FirstOrDefault(Function(x) x.Value.Equals(tipoDescricao, StringComparison.OrdinalIgnoreCase))
                    dados.TipoLograPaciente = If(itemTipo.Key IsNot Nothing, itemTipo.Key, "081")
                End If

                Try
                    Dim fullTel As String = p.Item("tel").ToString()
                    If fullTel.Length > 0 Then
                        dados.DDD = fullTel.Substring(1, 2)
                        Dim telSemDDD As String = If(fullTel.Length >= 14, fullTel.Substring(4, 10), fullTel.Substring(4, 9))
                        dados.Telefone = telSemDDD.Replace("-", "")
                    End If
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
        End Try

        ' Procedimentos secundários variáveis (só existe registro salvo pro código
        ' 0903010011 - os demais códigos têm lista fixa, recriada pela própria tela
        ' ao selecionar o procedimento principal - ver PreencherTelaComDados).
        If dados.ProcedimentoPrincipal = "0903010011" Then
            Try
                Dim secData = FormAMEmain.getDataset($"SELECT DISTINCT cod_oci_secundario.cod, procedimentos_secundarios.qtd, cod_oci_secundario.descricao, procedimentos_secundarios.cbo
FROM procedimentos_secundarios
JOIN cod_oci_secundario ON cod_oci_secundario.cod = procedimentos_secundarios.cod_proced_secundario
WHERE procedimentos_secundarios.`data`='{dados.data:yyyy-MM-dd}'
AND procedimentos_secundarios.id_paciente = {idPac}
AND procedimentos_secundarios.medico_solicitante ='{medicoCns}'")

                If secData IsNot Nothing AndAlso secData.Rows.Count > 0 Then
                    dados.ProcedimentosSecundarios = New List(Of ApacProcedimentoSecundario)
                    dados.ProcedimentosSecundarios.Add(New ApacProcedimentoSecundario With {
                        .Codigo = "0301010072",
                        .Quantidade = "1",
                        .Descricao = "CONSULTA MÉDICA NA ATENÇÃO ESPECIALIZADA",
                        .Cbo = secData.Rows(0).Item("cbo").ToString()
                    })
                    For Each row As DataRow In secData.Rows
                        Dim desc As String = row.Item("descricao").ToString()
                        If desc.Length > 13 Then desc = desc.Substring(13).Trim()
                        dados.ProcedimentosSecundarios.Add(New ApacProcedimentoSecundario With {
                            .Codigo = row.Item("cod").ToString(),
                            .Quantidade = row.Item("qtd").ToString(),
                            .Descricao = desc,
                            .Cbo = row.Item("cbo").ToString()
                        })
                    Next
                End If
            Catch ex As Exception
            End Try
        End If

        Return dados
    End Function

    ''' <summary>
    ''' Joga um ApacRegistro nos controles da tela - equivalente ao que a busca por
    ''' CPF/seleção de paciente já faz, só que orientado a dados prontos em vez de
    ''' interação do usuário. Usada pelo carregamento pra edição (getOCIdata) e por
    ''' addAPAC() quando chamado com o parâmetro "dados" preenchido. Começa com
    ''' clearFields() pra garantir que nada "grudado" de um registro anterior
    ''' sobreviva entre uma chamada e outra (importante em lote, que roda várias
    ''' seguidas na mesma tela).
    ''' </summary>
    Private Sub PreencherTelaComDados(dados As ApacRegistro)
        clearFields()
        txtCNSMedicoExecutante.SelectedIndex = -1
        txtNomeAutorizador.SelectedIndex = -1
        txtCidPrincipal.SelectedIndex = -1
        txtProcedimentoPrincipal.SelectedIndex = -1

        isLoading = True ' bloqueia o TextChanged do CPF pra não disparar uma busca por cima
        Try
            If dados.NumeroApac <> "" Then txtNumApac.Text = dados.NumeroApac
            If dados.data <> Date.MinValue Then dtValidadeIni.Value = dados.data

            If dados.IdPaciente.HasValue Then
                IDpacienteSelecionado = dados.IdPaciente.Value
                Dim pacData = getPacientes(, , , dados.IdPaciente.Value)
                If pacData IsNot Nothing AndAlso pacData.Rows.Count > 0 Then
                    result = pacData
                    ' Já preenche nome, mãe, sexo, nascimento, cpf, raça, endereço/tipo de
                    ' logradouro, ddd/telefone e o responsável pelo paciente (chkResponsavel).
                    resultPacientes(pacData)
                End If
            End If

            ' IMPORTANTE: resultPacientes() (assim como a busca por CPF normal) NÃO seta a
            ' variável de módulo "endereco" - ela só é preenchida pela Sub cep(), disparada
            ' quando o usuário sai do campo CEP na tela (txtCep_Leave/KeyDown). saveAPAC()/
            ' atPac() exigem "endereco" preenchido pra gravar ("Endereço inválido." senão).
            ' Sem essa interação manual, não teria como gravar por aqui - então resolve o
            ' endereço direto pelo id já conhecido (mesmo formato de colunas que
            ' CEP.getAddress() devolve, por isso os índices posicionais usados em cep()
            ' continuam funcionando).
            If dados.IdEndereco.HasValue Then
                Try
                    endereco = FormAMEmain.getDataset($"SELECT * FROM ceps_peruibe WHERE id={dados.IdEndereco.Value}")
                Catch ex As Exception
                End Try
            End If

            ' Sobrepõe explicitamente com o que veio em "dados", caso informado - cobre
            ' tanto o caso de IdPaciente não ter sido passado quanto de "dados" trazer um
            ' valor diferente do que está salvo agora em pacientes (ex.: dado vindo de um
            ' .JUL importado, não do cadastro atual).
            If dados.NomePaciente <> "" Then txtNomePaciente.Text = dados.NomePaciente
            If dados.MaePaciente <> "" Then txtNomeMae.Text = dados.MaePaciente
            If dados.CPFPaciente <> "" Then txtCpfPaciente.Text = dados.CPFPaciente
            If dados.SexoPaciente <> "" Then txtSexo.Text = dados.SexoPaciente
            If dados.DtnascPaciente <> Date.MinValue Then dtNascimento.Text = dados.DtnascPaciente.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
            If dados.Raca <> "" Then txtRaca.SelectedValue = dados.Raca
            If dados.NomeResponsavelPaciente <> "" Then txtNomeRespPaciente.Text = dados.NomeResponsavelPaciente

            If dados.CEPPaciente <> "" Then txtCep.Text = dados.CEPPaciente
            If dados.numeroResPaciente <> "" Then txtNumero.Text = dados.numeroResPaciente
            If dados.complementoPaciente <> "" Then txtComplemento.Text = dados.complementoPaciente
            If dados.LograPaciente <> "" Then txtLogradouro.Text = dados.LograPaciente
            If dados.BairroPaciente <> "" Then txtBairro.Text = dados.BairroPaciente
            If dados.TipoLograPaciente <> "" Then cbTipoLogradouro.SelectedValue = dados.TipoLograPaciente

            ' DDD antes do Telefone - txtDDD_TextChanged limpa txtTelefone quando o DDD
            ' atinge 2 dígitos, então setar na ordem contrária apagaria o telefone.
            If dados.DDD <> "" Then txtDDD.Text = dados.DDD
            If dados.Telefone <> "" Then txtTelefone.Text = dados.Telefone

            ' ORDEM IMPORTA: setar txtProcedimentoPrincipal.SelectedValue dispara
            ' txtProcedimentoPrincipal_SelectedValueChanged, que recria a grid de
            ' secundários fixos por código, chama getMedSolicAut() - que é quem
            ' preenche (DataSource) os combos txtCNSMedicoExecutante/
            ' txtNomeMedicoSolicitante/txtNomeAutorizador filtrados pelo CBO daquele
            ' procedimento - e TAMBÉM recarrega o DataSource de txtCidPrincipal/
            ' txtCidSecundario (filtrado pelos CIDs válidos pra esse procedimento) e
            ' força txtCidSecundario.SelectedIndex=-1 no final. Ou seja: CID, médico
            ' e autorizador só podem ser selecionados DEPOIS que o procedimento
            ' principal for setado - antes disso os combos estão vazios ou vão ser
            ' resetados por essa cascata.
            If dados.ProcedimentoPrincipal <> "" Then
                txtProcedimentoPrincipal.SelectedValue = dados.ProcedimentoPrincipal
            End If

            ' Se "dados" trouxer uma lista explícita de secundários (caso do
            ' 0903010011, cuja lista real vem do banco por paciente), ela substitui
            ' o que a auto-geração acima colocou (que é só um placeholder fixo pra
            ' esse código, ver txtProcedimentoPrincipal_SelectedValueChanged).
            If dados.ProcedimentosSecundarios IsNot Nothing AndAlso dados.ProcedimentosSecundarios.Count > 0 Then
                dgvProcedimentos.Rows.Clear()
                For Each item In dados.ProcedimentosSecundarios
                    dgvProcedimentos.Rows.Add(item.Codigo, item.Quantidade, item.Descricao, item.Cbo)
                Next
            End If

            ' Só agora, com os combos já carregados/resetados pela cascata acima, dá
            ' pra selecionar CID, médico e autorizador de fato.
            If dados.CidPrincipal <> "" Then txtCidPrincipal.SelectedValue = dados.CidPrincipal
            If dados.CidSecundario <> "" Then txtCidSecundario.SelectedValue = dados.CidSecundario

            If dados.SUSMedicoExecutante <> "" Then
                txtCNSMedicoExecutante.SelectedValue = dados.SUSMedicoExecutante
                txtNomeMedicoSolicitante.SelectedValue = dados.SUSMedicoExecutante
            End If
            If dados.CnsAutorizador <> "" Then txtNomeAutorizador.SelectedValue = dados.CnsAutorizador
            If dados.CboMedico <> "" Then CBOmed.SelectedValue = dados.CboMedico

            chkSituacaoRua.Checked = (dados.SituacaoRua = "S")
            chkSemCpf.Checked = (dados.SemCpf = "S")
            If dados.MotivoSaida <> "" Then txtMotivoSaida.SelectedValue = dados.MotivoSaida
        Finally
            isLoading = False
        End Try
    End Sub

    Public Sub getOCIdata(id As Integer)
        Try
            Dim dados = MontarDadosApacDoOCI(id)
            If dados Is Nothing Then
                m.msgAlert("OCI não encontrado!")
                Return
            End If
            PreencherTelaComDados(dados)
        Catch ex As Exception
            MsgBox("Erro ao carregar dados do OCI: " & ex.Message)
        End Try
    End Sub
    Private Function detectChanges()
        If dtNascimento.Text <> nasc OrElse txtNomePaciente.Text <> nome OrElse txtSexo.Text <> sexo OrElse txtCpfPaciente.Text <> cpf OrElse txtNomeMae.Text <> mae OrElse txtRaca.SelectedValue <> raca OrElse txtDDD.Text <> ddd OrElse txtTelefone.Text <> telefone OrElse txtCep.Text <> cepRes OrElse txtNumero.Text <> numero OrElse txtComplemento.Text <> complemento Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub loadQueueOCI()
        Dim dataset As DataTable = FormAMEmain.getDataset("SELECT 
            oci_fila.id_medico_solicitante AS idMedico,
            oci_fila.cod_proced_principal AS idCod,
            cod_oci_principal.abrev,
            servidores.nome,
            COUNT(*) AS total

        FROM oci_fila 

        JOIN cod_oci_principal 
            ON cod_oci_principal.id = oci_fila.cod_proced_principal

        JOIN servidores 
            ON servidores.SUS = oci_fila.id_medico_solicitante

        WHERE oci_fila.`status` = 0

        GROUP BY 
            oci_fila.id_medico_solicitante,
            oci_fila.cod_proced_principal,
            cod_oci_principal.abrev,
            servidores.nome")

        If dataset.Rows.Count = 0 Then
            dgQueueOCI.DataSource = Nothing
            dgQueueItens.DataSource = Nothing
            Exit Sub
        End If

        dgQueueOCI.DataSource = dataset
        dgQueueOCI.Columns("idMedico").Visible = False
        dgQueueOCI.Columns("idCod").Visible = False
        dgQueueOCI.Columns("abrev").HeaderText = "Procedimento"
        dgQueueOCI.Columns("abrev").Width = 210
        dgQueueOCI.Columns("nome").HeaderText = "Médico"
        dgQueueOCI.Columns("nome").Width = 192
        dgQueueOCI.Columns("total").HeaderText = "Total"
        dgQueueOCI.Columns("total").Width = 43

    End Sub

    Private Sub loadQueueItens(ByVal idMedico, ByVal idCod)

        queue = FormAMEmain.getDataset($"SELECT oci_fila.*, pacientes.nome AS paciente, pacientes.dtnasc, cod_oci_principal.cod AS proced
            FROM oci_fila
            JOIN pacientes ON pacientes.id = oci_fila.id_paciente
            JOIN cod_oci_principal ON cod_oci_principal.id = oci_fila.cod_proced_principal
            WHERE oci_fila.`status`= 0 
				AND oci_fila.id_medico_solicitante = '{idMedico}'
				AND oci_fila.cod_proced_principal = {idCod}
				ORDER BY oci_fila.`data`")

        dgQueueItens.DataSource = queue

        Try

            dgQueueItens.Columns("id").Visible = False
            dgQueueItens.Columns("id_medico_solicitante").Visible = False
            dgQueueItens.Columns("cod_proced_principal").Visible = False
            dgQueueItens.Columns("cid_principal").Visible = False
            dgQueueItens.Columns("cid_secundario").Visible = False
            dgQueueItens.Columns("id_paciente").Visible = False
            dgQueueItens.Columns("status").Visible = False

            dgQueueItens.Columns(3).HeaderText = "Data"
            dgQueueItens.Columns(3).Width = 70
            dgQueueItens.Columns("paciente").HeaderText = "Paciente"
            dgQueueItens.Columns("paciente").Width = 284
            dgQueueItens.Columns("dtnasc").HeaderText = "Data de Nascimento"
            dgQueueItens.Columns("dtnasc").Width = 90

            dgQueueItens.ClearSelection()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub getProcedSecundario(data As Date, idPac As Integer, medico As String)
        Dim proceds As DataTable = FormAMEmain.getDataset($"SELECT DISTINCT cod_oci_secundario.cod, procedimentos_secundarios.qtd, cod_oci_secundario.descricao, procedimentos_secundarios.cbo
FROM procedimentos_secundarios
JOIN cod_oci_secundario ON cod_oci_secundario.cod = procedimentos_secundarios.cod_proced_secundario
WHERE procedimentos_secundarios.`data`='{data:yyyy-MM-dd}'
AND procedimentos_secundarios.id_paciente = {idPac}
AND procedimentos_secundarios.medico_solicitante ='{medico}'")

        If proceds.Rows.Count = 0 Then Exit Sub

        dgvProcedimentos.Columns.Clear()

        dgvProcedimentos.Columns.Add("Codigo", "Procedimento")
        dgvProcedimentos.Columns("Codigo").Width = 80
        dgvProcedimentos.Columns.Add("Quantidade", "Qtd")
        dgvProcedimentos.Columns("Quantidade").Width = 40
        dgvProcedimentos.Columns.Add("Desc", "Descrição")
        dgvProcedimentos.Columns("Desc").Width = 300
        dgvProcedimentos.Columns.Add("CBO", "CBO")
        dgvProcedimentos.Columns("CBO").Width = 90

        dgvProcedimentos.Rows.Add("0301010072", "1", "Consulta médica na atenção especializada".ToUpper(), proceds.Rows(0)("cbo"))
        For Each row As DataRow In proceds.Rows
            Dim desc As String = row("descricao").ToString().Substring(13).Trim()
            dgvProcedimentos.Rows.Add(row("cod"), row("qtd"), desc, row("cbo"))
        Next

    End Sub
    Private Sub getQueueData(idQueue As Integer)
        Dim data() As DataRow = queue.Select("id = " & idQueue)

        If data.Length > 0 Then
            isLoading = True
            isQueue = True
            Dim row As DataRow = data(0)
            Dim idPac = row("id_paciente")
            Dim idMedico As String = row("id_medico_solicitante").ToString()

            result = getPacientes(, , , idPac)
            resultPacientes(result)
            dtValidadeIni.Value = CDate(row("data"))
            txtCNSMedicoExecutante.SelectedValue = idMedico
            txtNomeMedicoSolicitante.SelectedValue = idMedico
            txtProcedimentoPrincipal.SelectedValue = row("proced")
            txtCidPrincipal.SelectedValue = row("cid_principal")
            txtCidSecundario.SelectedValue = row("cid_secundario")

            If txtProcedimentoPrincipal.SelectedValue = "0903010011" Then
                getProcedSecundario(row("data"), idPac, txtCNSMedicoExecutante.SelectedValue)
            End If
        End If

        Clipboard.SetText(result(0)("dtnasc").ToString())
        isLoading = False

    End Sub

    Private Sub CentralizarFormulario()

        Me.Location = New Point(
        (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) \ 2,
        (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) \ 2
    )

    End Sub

    Private Sub colapse()
        Try
            If colapsed Then
                btOCIpendente.Left = -55
                btOCIpendente.Text = "Fechar"
                btOCIpendente.TextAlign = ContentAlignment.MiddleRight
                dgQueueOCI.Width = 450
                dgQueueItens.Width = 450
                TabControl1.Location = New Point(457, 43)
                Me.Width = 1035

                colapsed = False
            Else
                btOCIpendente.Left = 0
                btOCIpendente.Text = "OCIs pendentes"
                btOCIpendente.TextAlign = ContentAlignment.MiddleLeft
                dgQueueOCI.Width = 0
                dgQueueItens.Width = 0
                TabControl1.Location = New Point(14, 43)
                Me.Width = 600

                colapsed = True
            End If
            dgvSugestoes.Visible = False
            popupGrid.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub checkQueue()
        Dim dataset = FormAMEmain.getDataset("Select COUNT(*) As total FROM oci_fila WHERE `status`=0").Rows(0).Item("total")

        If dataset > 0 Then
            btOCIpendente.Visible = True
            Timer1.Start()
        Else
            btOCIpendente.Visible = False
            Timer1.Stop()
        End If
    End Sub

    Private Sub FormAMEOCI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        checkQueue()
        colapse()

        If My.Settings.databaseAME = "" Then
            FormAMEbd.ShowDialog()
            Me.Close()
            Return
        End If
        If My.Settings.OCIcompetencia = "" Then
            FormAMEOCIControleCompetencia.ShowDialog()
            Me.Close()
            Return
        End If

        LimparData()
        loadQueueOCI()

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
        .Width = 520,
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

        'AddHandler popupGrid.MouseLeave, AddressOf popupGrid_MouseLeave
        AddHandler debounceTimer.Tick, AddressOf BuscarPacientes
        AddHandler popupGrid.CellClick, AddressOf popupGrid_CellClick

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
                {"05", "INDIGENA"}
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
            CBOmed.SelectedIndex = -1
            txtRaca.SelectedIndex = 0

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

    Public Sub ExportedApac(prefixoApac)
        Dim caminhoArquivo As String = Path.Combine(Application.StartupPath & "\APAC\EXPORTADOS", "AP" & My.Settings.OCIcompetencia & chkMonthEXT())
        Dim linhas = File.ReadAllLines(caminhoArquivo, Encoding.GetEncoding("iso-8859-1"))
        Dim resultado As New List(Of String)
        Dim ignorar As Boolean = False

        For Each linha In linhas
            ' Se este 14 for o que deve ser removido
            If linha.StartsWith(prefixoApac) Then
                ignorar = True
                Continue For
            Else
                ignorar = False
            End If

            If Not ignorar Then
                resultado.Add(linha)
            End If

        Next

        ' Regrava o MESMO arquivo
        File.WriteAllLines(caminhoArquivo, resultado, Encoding.GetEncoding("iso-8859-1"))

    End Sub

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

    Public Function cep(param As String)
        Try

            Dim CODPOSTAL As New CEP()
            endereco = CODPOSTAL.getAddress(param)

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
                Return True
            Else
                MsgBox("CEP não encontrado ou erro na consulta.")
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

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
    Private Sub formatGrid(location As Point)
        dgvSugestoes.Width = 520
        dgvSugestoes.Height = 150
        dgvSugestoes.BringToFront()
        dgvSugestoes.Visible = True
        dgvSugestoes.Location = New Point(location)

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
        If dgvSugestoes.Columns.Contains("tipo") Then dgvSugestoes.Columns("tipo").Width = 90
        If dgvSugestoes.Columns.Contains("logradouro") Then dgvSugestoes.Columns("logradouro").Width = 200
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
            If colapsed Then
                formatGrid(New Point(38, 280))
            Else
                formatGrid(New Point(481, 280))
            End If

        Catch ex As Exception
            Debug.WriteLine("Erro ao carregar sugestões: " & ex.Message)
        End Try
    End Sub

    Private Sub dgvSugestoes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSugestoes.CellClick
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

            If colapsed Then
                formatGrid(New Point(38, 318))
            Else
                formatGrid(New Point(481, 318))
            End If

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
                txtLogradouro.Clear()
                txtBairro.Clear()
                If txtNumero.Text = "" Then txtNumero.Clear()
                txtComplemento.Clear()
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
        If isLoading Then Exit Sub
        Try
            debounceTimer.Stop()

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


            If txtNomePaciente.Text.Length >= 4 AndAlso isLoading = False Then
                popupGrid.Visible = True
                BuscarPacientes(sender, e, "nome")
                'debounceTimer.Start()
            Else
                popupGrid.Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            isLoading = False
        End Try

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
                If colapsed Then
                    popupGrid.Location = New Point(36, 268)
                Else
                    popupGrid.Location = New Point(480, 268)
                End If
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

                'If txtCpfPaciente.Text.Length = 11 Then
                '    ' Se CPF já estiver preenchido, oculta o grid 
                '    popupGrid.Visible = False
                'Else
                '    popupGrid.Visible = True
                'End If

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

            Try
                isLoading = True ' 🔒 bloqueia o TextChanged durante a seleção
                debounceTimer.Stop()
                Dim linhas() As DataRow = result.Select("id = " & IDpacienteSelecionado)
                If linhas.Length = 0 Then Exit Sub

                ' Cria uma cópia apenas com essa linha
                ' Dim dtSelecionado As DataTable = result.Clone()
                'dtSelecionado.ImportRow(linhas(0))
                'resultPacientes(dtSelecionado)
                resultPacientes(linhas.CopyToDataTable())
                popupGrid.Visible = False
            Finally
                isLoading = False ' 🔓 libera novamente
            End Try
        End If
    End Sub

    Private Sub resultPacientes(result As DataTable)

        Try
            IDpacienteSelecionado = result.Rows(0).Item("id")
            If result.Rows.Count > 0 Then
                ' txtNomePaciente.Text = result.Rows(0).Item("nome").ToString
                If result.Rows(0).Item("id_logradouro") <> 0 Then
                    txtCep.Text = result.Rows(0).Item("cep").ToString
                    txtNumero.Text = result.Rows(0).Item("numero").ToString
                    txtComplemento.Text = result.Rows(0).Item("complemento").ToString
                    ' getPacientes() já traz logradouro/bairro/tipo via JOIN com ceps_peruibe,
                    ' mas esses 3 campos não estavam sendo aplicados na tela (só cep/numero/
                    ' complemento eram). cbTipoLogradouro trabalha com código (ex "081"), não
                    ' com a descrição (ex "RUA") que vem do banco - por isso o mapeamento
                    ' reverso, igual ao que a busca por CEP (Sub cep(), acima) já faz.
                    txtLogradouro.Text = result.Rows(0).Item("logradouro").ToString
                    txtBairro.Text = result.Rows(0).Item("bairro").ToString
                    Dim tipoLograDescricao As String = result.Rows(0).Item("tipo").ToString
                    Dim itemTipoLogra = CType(cbTipoLogradouro.DataSource, BindingSource) _
                        .Cast(Of KeyValuePair(Of String, String))() _
                        .FirstOrDefault(Function(x) x.Value.Equals(tipoLograDescricao, StringComparison.OrdinalIgnoreCase))
                    If itemTipoLogra.Key IsNot Nothing Then
                        cbTipoLogradouro.SelectedValue = itemTipoLogra.Key
                    End If
                Else
                    txtCep.Text = ""
                    txtNumero.Text = ""
                    txtComplemento.Text = ""
                    txtLogradouro.Text = ""
                    txtBairro.Text = ""
                End If

                ' dtNascimento é MaskedTextBox com máscara fixa "00/00/0000" - precisa
                ' vir SEMPRE em dd/MM/yyyy. Usar .ToString() puro (como era antes) devolve
                ' a data no formato padrão da culture da máquina (ex: "8/15/2020 12:00:00
                ' AM" em en-US) - não bate com a máscara, e o resultado fica truncado/
                ' incompleto (o que gerava o erro "conversão da cadeia ' / / ' não é
                ' válida" mais adiante, ao tentar ler essa data de volta).
                ' Isolado do resto (nome/sexo/cpf/mãe logo abaixo): se o dtnasc gravado
                ' no banco não converter (ex: data zerada '0000-00-00' do MySQL), só a
                ' data fica em branco - não pode derrubar a atribuição dos campos
                ' seguintes junto, como acontecia antes de isolar isso num Try próprio.
                Try
                    Dim dtnascCol = result.Rows(0).Item("dtnasc")
                    dtNascimento.Text = If(IsDBNull(dtnascCol), "", Convert.ToDateTime(dtnascCol).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture))
                Catch ex As Exception
                    dtNascimento.Text = ""
                End Try
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

                nasc = dtNascimento.Text
                nome = txtNomePaciente.Text
                sexo = txtSexo.Text
                cpf = txtCpfPaciente.Text
                mae = txtNomeMae.Text
                raca = txtRaca.SelectedValue
                ddd = txtDDD.Text
                telefone = txtTelefone.Text
                cepRes = txtCep.Text
                numero = txtNumero.Text
                complemento = txtComplemento.Text

            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
    Private Function chkResponsavel()
        Try
            If m.CalcularIdade(CDate(dtNascimento.Text)) >= 18 Then
                txtNomeRespPaciente.Text = txtNomePaciente.Text.ToString
            Else
                txtNomeRespPaciente.Text = txtNomeMae.Text.ToString
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

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

    Private Sub onClose()
        'FormAMEmain.Visible = True
        If Not String.IsNullOrEmpty(txtNumApac.Text) Then
            UnlockApac(txtNumApac.Text)
        End If
        Application.Exit()
    End Sub
    Private Sub FormAMEOCI_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        onClose()
    End Sub
    Private Sub txtCpfPaciente_TextChanged(sender As Object, e As EventArgs) Handles txtCpfPaciente.TextChanged
        If isLoading Then Exit Sub

        If Not chkSemCpf.Checked Then

            If txtCpfPaciente.Text.Length = 11 Then
                Try
                    If m.ValidarCPF(txtCpfPaciente.Text) Then
                        result = getPacientes(txtCpfPaciente.Text.Trim())
                        resultPacientes(result)
                        popupGrid.Visible = False
                    Else
                        m.msgAlert("CPF invalido!")
                        txtCpfPaciente.Focus()
                        txtCpfPaciente.Clear()
                    End If

                Catch ex As Exception
                    m.msgAlert("CPF invalido!")
                Finally
                    isLoading = False
                End Try
            End If

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

    Private Sub btFechar_Click(sender As Object, e As EventArgs)
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

        If caminhoArquivo = "" OrElse Not File.Exists(caminhoArquivo) Then
            MessageBox.Show("Arquivo APAC não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lista.Add(New ApacRegistro With {
                .NumeroApac = 0
                })
            Return lista
        End If

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
                ' ATENÇÃO: isto pega o CNS do médico RESPONSÁVEL/solicitante (apa_cnsres,
                ' posições 282-296 da spec), não o do EXECUTANTE, apesar do nome da variável.
                ' O CNS do executante de verdade está em apa_cnsexec (497-511) - ver
                ' "cnsExecutante" mais abaixo. Mantive esse campo como estava pra não mudar
                ' o comportamento de quem já usa .SUSMedicoExecutante (ex: ExportarApacsExcel) -
                ' mas provavelmente vale renomear/trocar depois de confirmar o impacto.
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

                ' ---------- Campos que faltavam (adicionados) - posições conforme o
                ' layout oficial "Autorização de Procedimentos de Alta Complexidade" ----------
                Dim uf As String = linha.Substring(21, 2).Trim()                          ' apa_coduf       [22-23]
                Dim cnesExecutanteHdr As String = linha.Substring(23, 7).Trim()           ' apa_codcnes     [24-30]
                Dim dtValidadeFimTxt As String = linha.Substring(46, 8).Trim()            ' apa_dtfimval    [47-54]
                Dim tipoAtendimento As String = linha.Substring(54, 2).Trim()             ' apa_tipate      [55-56]
                Dim tipoApac As String = linha.Substring(56, 1).Trim()                    ' apa_tipapac     [57]
                Dim sexo As String = linha.Substring(185, 1).Trim()                       ' apa_sexopcnte   [186]
                Dim nomeMedicoSolicitante As String = linha.Substring(186, 30).Trim()     ' apa_nomeresp    [187-216]
                Dim motivoSaida As String = linha.Substring(226, 2).Trim()                ' apa_motsaida    [227-228]
                Dim dtAltaObitoTxt As String = linha.Substring(228, 8).Trim()              ' apa_dtobitoalta [229-236]
                Dim nomeAutorizador As String = linha.Substring(236, 30).Trim()           ' apa_nomediretor [237-266]
                Dim cnsPaciente As String = linha.Substring(266, 15).Trim()               ' apa_cnspct      [267-281]
                Dim cnsAutorizador As String = linha.Substring(296, 15).Trim()            ' apa_cnsdir      [297-311]
                Dim cidCausasAssoc As String = linha.Substring(311, 4).Trim()             ' apa_cidca       [312-315]
                Dim prontuario As String = linha.Substring(315, 10).Trim()                ' apa_npront      [316-325]
                Dim cnesSolicitante As String = linha.Substring(325, 7).Trim()            ' apa_codsol      [326-332]
                Dim dtSolicitacao As String = linha.Substring(332, 8).Trim()               ' apa_datsol      [333-340]
                Dim dtAutorizacaoTxt As String = linha.Substring(340, 8).Trim()            ' apa_dataut      [341-348]
                Dim codigoEmissor As String = linha.Substring(348, 10).Trim()             ' apa_codemis     [349-358]
                Dim caraterAtendimento As String = linha.Substring(358, 2).Trim()         ' apa_carate      [359-360]
                Dim apacAnterior As String = linha.Substring(360, 13).Trim()              ' apa_apacant     [361-373]
                Dim raca As String = linha.Substring(373, 2).Trim()                       ' apa_raca        [374-375]
                Dim nomeResponsavelPaciente As String = linha.Substring(375, 30).Trim()   ' apa_nomeresp    [376-405] (responsável pelo paciente)
                Dim nacionalidade As String = linha.Substring(405, 3).Trim()              ' apa_nascpcnte   [406-408]
                Dim etnia As String = linha.Substring(408, 4).Trim()                      ' APA_etnia       [409-412]
                Dim email As String = linha.Substring(456, 40).Trim()                     ' apa_email       [457-496]
                Dim cnsExecutante As String = linha.Substring(496, 15).Trim()             ' apa_cnsexec     [497-511] <- CNS do executante de verdade
                Dim equipe As String = linha.Substring(522, 10).Trim()                    ' apa_ine         [523-532]
                Dim situacaoRua As String = If(linha.Length > 532, linha.Substring(532, 1).Trim(), "")       ' apa_strua       [533]
                Dim fonteOrcamentaria As String = If(linha.Length > 534, linha.Substring(533, 2).Trim(), "") ' apa_fntorca     [534-535]
                Dim emendasParlamentares As String = If(linha.Length > 535, linha.Substring(535, 1).Trim(), "") ' apa_emenpar [536]
                Dim semCpf As String = If(linha.Length > 536, linha.Substring(536, 1).Trim(), "")            ' apa_semcpf      [537]

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
                .UF = uf,
                .CnesExecutante = cnesExecutanteHdr,
                .DtValidadeFim = dtValidadeFimTxt,
                .TipoAtendimento = tipoAtendimento,
                .TipoApac = tipoApac,
                .SexoPaciente = sexo,
                .NomeMedicoSolicitante = nomeMedicoSolicitante,
                .MotivoSaida = motivoSaida,
                .DtAltaObito = dtAltaObitoTxt,
                .NomeAutorizador = nomeAutorizador,
                .CnsPaciente = cnsPaciente,
                .CnsAutorizador = cnsAutorizador,
                .CidCausasAssociadas = cidCausasAssoc,
                .Prontuario = prontuario,
                .CnesSolicitante = cnesSolicitante,
                .DtSolicitacao = dtSolicitacao,
                .DtAutorizacao = dtAutorizacaoTxt,
                .CodigoEmissor = codigoEmissor,
                .CaraterAtendimento = caraterAtendimento,
                .ApacAnterior = apacAnterior,
                .Raca = raca,
                .NomeResponsavelPaciente = nomeResponsavelPaciente,
                .Nacionalidade = nacionalidade,
                .Etnia = etnia,
                .Email = email,
                .CnsExecutante = cnsExecutante,
                .Equipe = equipe,
                .SituacaoRua = situacaoRua,
                .FonteOrcamentaria = fonteOrcamentaria,
                .EmendasParlamentares = emendasParlamentares,
                .SemCpf = semCpf,
                .MaePaciente = mae,
                .TelPaciente = tel,
                .numeroResPaciente = numeroRes,
                .complementoPaciente = complento,
                .TipoLograPaciente = tipoLogra,
                .LograPaciente = logradouro,
                .BairroPaciente = bairro
            })
            ElseIf linha.StartsWith("06") Then
                ' Registro 06 (CID) - vem depois do registro 14 da mesma APAC no arquivo.
                ' corpo[1-2]="06", cmp[3-8], num_apac[9-21], cid_principal[22-25], cid_secundario[26-29]
                Dim numeroApac06 As String = If(linha.Length >= 21, linha.Substring(8, 13).Trim(), "")
                Dim cidPrincipal06 As String = If(linha.Length > 21, linha.Substring(21, Math.Min(4, linha.Length - 21)).Trim(), "")
                Dim cidSecundario06 As String = If(linha.Length > 25, linha.Substring(25, Math.Min(4, linha.Length - 25)).Trim(), "")

                If numeroApac06 <> "" Then
                    Dim apacCorrespondente = lista.Find(Function(x) x.NumeroApac = numeroApac06)
                    If apacCorrespondente IsNot Nothing Then
                        apacCorrespondente.CidPrincipal = cidPrincipal06
                        apacCorrespondente.CidSecundario = cidSecundario06
                    End If
                End If
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

                idPac = FormAMEmain.doQuery($"INSERT INTO pacientes (nome, dtnasc, mae, tel, cpf, id_logradouro, numero, complemento, sexo) VALUES ('{apac.NomePaciente.ToUpper}', '{m.mysqlDateFormat(apac.DtnascPaciente)}', '{apac.MaePaciente.ToUpper}', '{ddd}{tel}', '{apac.CPFPaciente}',{idLogra}, {num}, '{apac.complementoPaciente.ToUpper}', '{apac.SexoPaciente}')")
            Catch ex As Exception

                Try
                    idPac = FormAMEmain.getDataset($"SELECT id FROM pacientes WHERE cpf='{apac.CPFPaciente}'").Rows(0).Item("id")
                Catch exc As Exception

                    idPac = FormAMEmain.getDataset($"SELECT id FROM pacientes WHERE dtnasc='{m.mysqlDateFormat(apac.DtnascPaciente)}' AND nome LIKE '%{apac.NomePaciente}%'").Rows(0).Item("id")
                End Try
            End Try

            Try
                ' apac.SituacaoRua/SemCpf vêm como "S"/"N" do arquivo (ver importFromApacs);
                ' convertidos aqui pra 0/1 porque as colunas são TINYINT(1).
                Dim situacaoRuaVal As Integer = If(apac.SituacaoRua = "S", 1, 0)
                Dim semCpfVal As Integer = If(apac.SemCpf = "S", 1, 0)

                FormAMEmain.doQuery($"UPDATE oci SET data='{m.mysqlDateFormat(apac.data)}', id_paciente='{idPac}', id_medico='{apac.SUSMedicoExecutante}', id_autorizador='{apac.CnsAutorizador}', id_cod_principal={idProced}, cid_principal='{apac.CidPrincipal}', cid_sec='{apac.CidSecundario}', situacao_rua={situacaoRuaVal}, motivo_saida='{apac.MotivoSaida}', sem_cpf={semCpfVal}, status='CONC', id_usuario={idUser} WHERE num_apac='{apac.NumeroApac}'")
            Catch ex As Exception

            End Try
        Next
        MsgBox("Importação concluída!")
    End Sub
    Private Sub searchByDate()
        dtpSearchData.CustomFormat = "dd/MM/yyyy"
        FormAMEOCINumAPAC.loadNUMAPAC(dgOCIcadastradas, Nothing, Nothing, False, idUser,,,, , (dtpSearchData.Value), "num_apac", " AND status <> 'BLOQ'",, lbStatusCads)
        ckbSearchTodos.Checked = False
    End Sub

    Private Sub FormAMEOCI_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        popupGrid.Visible = False
    End Sub
    Private Sub clickDtpSearchData(sender As Object, e As EventArgs) Handles dtpSearchData.ValueChanged
        searchByDate()
    End Sub
    Public Sub loadAllOCI(dg As DataGridView)
        FormAMEOCINumAPAC.loadNUMAPAC(dg,,,, idUser,,,, "CONC", , "oci.data_lanc DESC, id_cod_principal, pacientes.nome",,, lbStatusCads)
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


    Private Sub TabControl1_Click(sender As Object, e As EventArgs) Handles TabControl1.Click
        popupGrid.Visible = False
        dgvSugestoes.Visible = False
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click
        popupGrid.Visible = False
        dgvSugestoes.Visible = False
    End Sub

    Private Sub dtNascimento_TextChanged(sender As Object, e As EventArgs) Handles dtNascimento.TextChanged
        If isLoading Then Exit Sub
        Try
            If dtNascimento.Text.Length = 10 Then
                popupGrid.Visible = True
                BuscarPacientes(sender, e, "dtnasc")
                chkResponsavel()
                Clipboard.SetText(dtNascimento.Text)
            Else
                popupGrid.Visible = False
                result.Clear()
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            isLoading = False
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
            txtTelefone.SelectAll()
        End If
    End Sub

    Private Sub FormAMEOCI_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If e.Control AndAlso e.KeyCode = Keys.V Then

            If Main.isCelular(Clipboard.GetText()) OrElse Main.isFixo(Clipboard.GetText()) Then
                e.SuppressKeyPress = True
                e.Handled = True
                Dim num = Main.PasteTelefone()
                txtDDD.Text = num.DDD
                txtTelefone.Text = num.Numero
            End If

        End If
    End Sub

    Private Sub ConsistênciaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsistênciaToolStripMenuItem.Click
        Process.Start($"C:\Program Files (x86)\Datasus\APAC\RCONSIST{chkMonthEXT()}")
    End Sub

    Public Sub editOCI(idOCI As Integer)
        updateMode = True
        getOCIdata(idOCI)
        TabControl1.SelectedTab = TabControl1.TabPages(0)
    End Sub

    ''' <summary>
    ''' Busca o id interno da OCI a partir do número da APAC (13 dígitos).
    ''' Retorna 0 se não encontrar.
    ''' </summary>
    Public Function getOCIIdPorNumApac(numApac As String) As Integer
        Try
            Dim dt = FormAMEmain.getDataset($"SELECT id FROM oci WHERE num_apac='{numApac.Trim()}'", True)
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                Return 0
            End If
            Return Convert.ToInt32(dt.Rows(0).Item("id"))
        Catch ex As Exception
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Regera o registro dessa APAC no arquivo .JUL a partir do que está salvo no banco -
    ''' de ponta a ponta, sem precisar clicar em Gravar manualmente. Reaproveita o mesmo
    ''' fluxo de edição (editOCI/getOCIdata) pra carregar paciente, endereço, procedimento
    ''' principal + secundários, CID, médico/autorizador, situação de rua/motivo de saída/
    ''' sem CPF - e no final chama addAPAC(), a mesma rotina usada ao salvar manualmente,
    ''' que valida os campos obrigatórios, remove o registro antigo dessa APAC do .JUL
    ''' (RemoverRegistroApac) e grava o novo no lugar.
    '''
    ''' Atenção: addAPAC() confere se o mês de dtValidadeIni bate com a competência
    ''' configurada em My.Settings.OCIcompetencia (é essa configuração que decide em qual
    ''' arquivo AP{competencia}.JUL o registro vai parar). Se a APAC for de uma competência
    ''' diferente da que está selecionada no sistema agora, addAPAC() vai barrar com
    ''' "Data inicial fora da competência atual." - troque a competência ativa antes de
    ''' regenerar um registro de um mês anterior.
    ''' </summary>
    Public Sub RegenerarArquivoPorNumApac(numApac As String)
        Dim id As Integer = getOCIIdPorNumApac(numApac)
        If id = 0 Then
            MessageBox.Show($"Nenhuma APAC encontrada com o número {numApac}.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        RegenerarArquivoPorId(id)
    End Sub

    ''' <summary>
    ''' Mesma coisa que RegenerarArquivoPorNumApac, mas recebendo o id interno da oci
    ''' diretamente (sem precisar dar a volta buscando o número da APAC no banco de
    ''' novo). Usado pelo menu de contexto da grid, que já tem o id disponível na
    ''' própria linha selecionada (mesma coluna que "Editar OCI" usa) - evita depender
    ''' do valor de num_apac exibido na grid bater exatamente com o gravado no banco
    ''' (zeros à esquerda, espaços etc. podiam fazer a busca reversa achar 0 linhas ou,
    ''' pior, carregar um registro diferente do que estava selecionado na tela).
    ''' </summary>
    Public Sub RegenerarArquivoPorId(id As Integer)
        Try

            Dim dados = MontarDadosApacDoOCI(id)
            If dados Is Nothing Then
                MessageBox.Show("OCI não encontrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            updateMode = True ' já existe uma entrada dessa APAC no arquivo - remove a antiga antes de gravar a nova
            Dim erro As String = ""
            If Not addAPAC(dados, silencioso:=False, mensagemErro:=erro) Then
                ' addAPAC() já mostra o popup de erro específico quando silencioso=False -
                ' não precisa duplicar mensagem aqui.
            End If
        Catch ex As Exception
            MsgBox($"Erro ao regenerar arquivo: {ex.Message}")
        End Try
    End Sub

    Private Sub GerarArquivoNovamenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GerarArquivoNovamenteToolStripMenuItem.Click
        If dgOCIcadastradas.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecione uma APAC na lista.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        RegenerarArquivoPorId(Convert.ToInt32(dgOCIcadastradas.SelectedRows(0).Cells(0).Value))
    End Sub


    ''' <summary>
    ''' Monta a linha de cabeçalho (registro "01") do .JUL. Extraída de addAPAC() pra
    ''' ser usada também por RegenerarLoteCompetencia(), que precisa escrever o header
    ''' com a quantidade final certa ANTES de começar a anexar os registros - evita ter
    ''' a mesma lógica de montagem do header duplicada em dois lugares.
    ''' </summary>
    Private Function MontarHeaderApac(competencia As String, quantidade As Integer) As String
        Dim header As New StringBuilder()
        header.Append("01#APAC")
        header.Append(competencia)
        header.Append(quantidade.ToString().PadLeft(6, "0"c)) ' Quantidade de APACs
        header.Append("0000")   ' Campo controle
        header.Append(Fmt(RemoverAcentos(My.Settings.OCInomeUnidade), 30))
        header.Append(Fmt(My.Settings.OCIsigla, 6))
        header.Append(My.Settings.OCIcnpj.Replace(".", "").Replace("/", "").Replace("-", "").PadLeft(14, "0"c))
        header.Append(Fmt(RemoverAcentos(My.Settings.OCIorgaoDestino), 40))
        header.Append(My.Settings.OCItipo.PadRight(1, " "c))
        header.Append(competencia & "20") ' Data competência
        header.Append("Versao 01.00".PadRight(15, " "c))
        Return header.ToString()
    End Function

    ''' <summary>
    ''' Regera do zero o arquivo .JUL da competência ATUALMENTE configurada em
    ''' My.Settings.OCIcompetencia, a partir de tudo que estiver com status='CONC' na
    ''' oci pra essa competência - decisão confirmada com o usuário: apaga o arquivo
    ''' existente e recria (em vez de tentar mesclar com o que já tinha nele).
    '''
    ''' Não é preciso abrir a tela pra cada APAC manualmente: MontarDadosApacDoOCI lê
    ''' tudo direto do banco e addAPAC() roda em modo silencioso (sem popup nenhum) -
    ''' só um resumo de sucesso/falha no final. Internamente addAPAC() ainda usa a
    ''' tela como "transporte" de dados pra saveAPAC()/atPac() (ver
    ''' PreencherTelaComDados) - não é um caminho 100% desacoplado da UI, mas quem
    ''' chama essa função não precisa saber ou se preocupar com isso.
    ''' </summary>
    Friend Sub RegenerarLoteCompetencia(competenciaAtiva As String)
        If competenciaAtiva = "" Then
            MessageBox.Show("Nenhuma competência configurada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim caminhoArquivo As String = Path.Combine(Application.StartupPath & "\APAC\EXPORTADOS", "AP" & competenciaAtiva & chkMonthEXT())

        Dim idsOci As DataTable = FormAMEmain.getDataset($"SELECT id, num_apac FROM oci WHERE compet='{CompetenciaParaBanco(competenciaAtiva)}' AND status='CONC' ORDER BY num_apac")
        If idsOci Is Nothing OrElse idsOci.Rows.Count = 0 Then
            MessageBox.Show("Nenhuma APAC com status CONC encontrada pra essa competência.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim confirmar = MessageBox.Show(
            $"Isso vai APAGAR o arquivo AP{competenciaAtiva}{chkMonthEXT()} atual (se existir) e recriar do zero, com as {idsOci.Rows.Count} APACs marcadas como CONC na competência {competenciaAtiva}." & vbCrLf & vbCrLf &
            "Confirma?", "Regerar lote da competência", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If confirmar <> DialogResult.Yes Then Return

        If Not Directory.Exists(Application.StartupPath & "\APAC\EXPORTADOS") Then
            Directory.CreateDirectory(Application.StartupPath & "\APAC\EXPORTADOS")
        End If

        ' Apaga o arquivo atual e escreve só o cabeçalho, já com a contagem final certa.
        ' addAPAC() só escreve header quando o arquivo está vazio (fs.Length=0) - como
        ' o arquivo já vai existir com o header dentro, as chamadas seguintes só
        ' anexam os registros 14/06/13 de cada APAC.
        If File.Exists(caminhoArquivo) Then
            File.Delete(caminhoArquivo)
        End If

        Using fs As New FileStream(caminhoArquivo, FileMode.Create, FileAccess.Write, FileShare.None)
            Using sw As New StreamWriter(fs, Encoding.GetEncoding("iso-8859-1"))
                sw.WriteLine(MontarHeaderApac(competenciaAtiva, idsOci.Rows.Count))
            End Using
        End Using

        Dim sucesso As Integer = 0
        Dim falhas As New List(Of String)

        For Each linha As DataRow In idsOci.Rows
            Dim idOci As Integer = Convert.ToInt32(linha.Item("id"))
            Dim numApac As String = linha.Item("num_apac").ToString()

            Dim dados = MontarDadosApacDoOCI(idOci)
            If dados Is Nothing Then
                falhas.Add($"{numApac}: registro não encontrado")
                Continue For
            End If

            updateMode = False ' inserção nova no arquivo recém-recriado, não "atualização"
            Dim erro As String = ""
            If addAPAC(dados, silencioso:=True, mensagemErro:=erro) Then
                sucesso += 1
            Else
                falhas.Add($"{numApac}: {erro}")
            End If
        Next

        Dim resumo As String = $"Regeração concluída: {sucesso} de {idsOci.Rows.Count} APACs gravadas."
        If falhas.Count > 0 Then
            resumo &= vbCrLf & vbCrLf & $"Falharam ({falhas.Count}):" & vbCrLf & String.Join(vbCrLf, falhas)
            m.msgAlert("Alguns erros foran encontrados durante a geração do arquivo. Veja o log em Configurações > Logs > Lote.")
        End If
        ' --- Geração do log ---
        Dim pastaLog As String = Path.Combine(Application.StartupPath, "Logs")
        If Not Directory.Exists(pastaLog) Then
            Directory.CreateDirectory(pastaLog)
        End If

        Dim caminhoLog As String = Path.Combine(pastaLog, "geracaoemlotelog.txt")

        Dim conteudoLog As New StringBuilder()
        conteudoLog.AppendLine("========================================")
        conteudoLog.AppendLine($"Regerar lote da competência - {DateTime.Now:dd/MM/yyyy HH:mm:ss}")
        conteudoLog.AppendLine("========================================")
        conteudoLog.AppendLine(resumo)
        conteudoLog.AppendLine()

        File.AppendAllText(caminhoLog, conteudoLog.ToString(), Encoding.UTF8)

        m.msgInfo($"Geração em lote de {competenciaAtiva} realizada com sucesso.")

        FormAMEOCINumAPAC.loadNUMAPAC(dgOCIcadastradas, Nothing, Nothing, False, idUser,,,, , (dtpSearchData.Value), "data_lanc DESC",,, lbStatusCads)
    End Sub
    Private Sub ExcluirRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExcluirRegistroToolStripMenuItem.Click

        '  MsgBox($"14{My.Settings.OCIcompetencia}{dgOCIcadastradas.SelectedRows(0).Cells(1).Value}")

        If deleteOCI(dgOCIcadastradas.SelectedRows(0).Cells(0).Value) Then
            RemoverRegistroApac($"14{My.Settings.OCIcompetencia}{dgOCIcadastradas.SelectedRows(0).Cells(1).Value}")
            FormAMEOCINumAPAC.loadNUMAPAC(dgOCIcadastradas, Nothing, Nothing, False, idUser,,,, , (dtpSearchData.Value), "data_lanc DESC")
        End If

    End Sub
    Private Sub EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem.Click
        editOCI(dgOCIcadastradas.SelectedRows(0).Cells(0).Value)
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
                procedSec.Add("0301010072", "0301010072 - CONSULTA MÉDICA NA ATENÇÃO ESPECIALIZADA")
                procedSec.Add("0211070041", "0211070041 - AUDIOMETRIA TONAL LIMIAR (VIA AÉREA/ÓSSEA)")
                cbo.Add("225275", "225275 - MÉDICO OTORRINOLARINGOLOGISTA")
                dgvProcedimentos.Rows.Add("0301010072", "1", "CONSULTA MÉDICA NA ATENÇÃO ESPECIALIZADA", "225275")
                dgvProcedimentos.Rows.Add("0211070041", "1", "AUDIOMETRIA TONAL LIMIAR (VIA AÉREA/ÓSSEA)", "225275")

            ElseIf txtProcedimentoPrincipal.SelectedValue = "0902010026" Then
                procedSec.Add("0301010072", "0301010072 - CONSULTA MÉDICA NA ATENÇÃO ESPECIALIZADA")
                procedSec.Add("0211020036", "0211020036 - ELETROCARDIOGRAMA (ECG)")
                cbo.Add("225120", "225120 - MÉDICO CARDIOLOGISTA")
                dgvProcedimentos.Rows.Add("0301010072", "1", "CONSULTA MÉDICA NA ATENÇÃO ESPECIALIZADA", "225120")
                dgvProcedimentos.Rows.Add("0211020036", "1", "ELETROCARDIOGRAMA (ECG)", "225120")

            ElseIf txtProcedimentoPrincipal.SelectedValue = "0902010018" Then
                procedSec.Add("0301010072", "0301010072 - CONSULTA MÉDICA NA ATENÇÃO ESPECIALIZADA")
                procedSec.Add("0211020036", "0211020036 - ELETROCARDIOGRAMA (ECG)")
                cbo.Add("225120", "225120 - MÉDICO CARDIOLOGISTA")
                dgvProcedimentos.Rows.Add("0301010072", "1", "CONSULTA MÉDICA NA ATENÇÃO ESPECIALIZADA", "225120")
                dgvProcedimentos.Rows.Add("0211020036", "1", "ELETROCARDIOGRAMA (ECG)", "225120")

            ElseIf txtProcedimentoPrincipal.SelectedValue = "0905010035" Then

                procedSec.Add("0301010072", "0301010072 - CONSULTA MÉDICA NA ATENÇÃO ESPECIALIZADA")
                procedSec.Add("0211060020", "0211060020 - BIOMICROSCOPIA DE FUNDO DE OLHO")
                procedSec.Add("0211060127", "0211060127 - MAPEAMENTO DE RETINA")
                procedSec.Add("0211060259", "0211060259 - TONOMETRIA")
                cbo.Add("225265", "225265 - MÉDICO OFTALMOLOGISTA")
                dgvProcedimentos.Rows.Add("0301010072", "1", "CONSULTA MÉDICA NA ATENÇÃO ESPECIALIZADA", "225265")
                dgvProcedimentos.Rows.Add("0211060020", "1", "BIOMICROSCOPIA DE FUNDO DE OLHO", "225265")
                dgvProcedimentos.Rows.Add("0211060127", "1", "MAPEAMENTO DE RETINA", "225265")
                dgvProcedimentos.Rows.Add("0211060259", "1", "TONOMETRIA", "225265")

            ElseIf txtProcedimentoPrincipal.SelectedValue = "0903010011" Then
                cbo.Add("225270", "225270 - MÉDICO ORTOPEDISTA E TRAUMATOLOGISTA")
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

                'procedSec.Add("0301010072", "0301010072 - CONSULTA MÉDICA NA ATENÇÃO ESPECIALIZADA")
                procedSec.Add("0301010307", "0301010307 - TELECONSULTA MÉDICA NA ATENÇÃO ESPECIALIZADA")

                dgvProcedimentos.Rows.Add("0301010072", "1", "CONSULTA MÉDICA NA ATENÇÃO ESPECIALIZADA", "225270")

            ElseIf txtProcedimentoPrincipal.SelectedValue = "0904010031" Then
                procedSec.Add("0301010072", "0301010072 - CONSULTA MÉDICA NA ATENÇÃO ESPECIALIZADA")
                procedSec.Add("0209040025", "0209040025 - LARINGOSCOPIA")
                procedSec.Add("0209040041", "0209040041 - VIDEOLARINGOSCOPIA")
                cbo.Add("225275", "225275 - MÉDICO OTORRINOLARINGOLOGISTA")
                dgvProcedimentos.Rows.Add("0301010072", "1", "CONSULTA MÉDICA NA ATENÇÃO ESPECIALIZADA", "225275")
                dgvProcedimentos.Rows.Add("0209040025", "1", "LARINGOSCOPIA", "225275")
                dgvProcedimentos.Rows.Add("0209040041", "1", "VIDEOLARINGOSCOPIA", "225275")

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

            If isQueue Then
                getMedSolicAut(dgQueueItens.CurrentRow.Cells(1).Value)
            Else
                getMedSolicAut()
            End If


            Dim queryCID As String = $"SELECT cid.cid,cid.descricao FROM cid 
        JOIN cod_oci_principal ON cid.id_oci_principal = cod_oci_principal.id
        WHERE cod_oci_principal.cod ='{txtProcedimentoPrincipal.SelectedValue}'"
            FormAMEmain.loadComboBox(queryCID, txtCidPrincipal, "descricao", "cid")
            FormAMEmain.loadComboBox(queryCID, txtCidSecundario, "descricao", "cid")

            txtCidSecundario.SelectedIndex = -1

        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub btExcluirPaciente_Click(sender As Object, e As EventArgs) Handles btExcluirPaciente.Click
        If IDpacienteSelecionado IsNot Nothing Then

            If m.msgQuestion("Tem certeza que deseja excluir este paciente? Essa ação é irreversível.", "Confirmar exclusão") Then
                FormAMEmain.doQuery("DELETE FROM pacientes WHERE id=" & IDpacienteSelecionado)
                MessageBox.Show("Paciente excluído com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If txtNumApac.Text.Length = 13 Then
                    UnlockApac(txtNumApac.Text)
                End If
                clearFields()
            End If

            btNovonumeroAPAC.Enabled = True

        Else
            MessageBox.Show("Selecione um paciente por data de nascimento, nome ou CPF", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub btOCIpendente_Click(sender As Object, e As EventArgs) Handles btOCIpendente.Click
        colapse()
        Timer1.Stop()
        btOCIpendente.ForeColor = Color.Linen
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If btOCIpendente.ForeColor = Color.Red Then
            btOCIpendente.ForeColor = Color.Yellow
        Else
            btOCIpendente.ForeColor = Color.Red
        End If
    End Sub
    Private Sub dgQueueOCI_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgQueueOCI.CellEnter
        loadQueueItens(dgQueueOCI.Rows(e.RowIndex).Cells(0).Value, dgQueueOCI.Rows(e.RowIndex).Cells(1).Value)
    End Sub
    Private Sub dgQueueItens_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgQueueItens.CellDoubleClick
        getQueueData(dgQueueItens.Rows(e.RowIndex).Cells(0).Value)
    End Sub

    Private Sub LimparControles(controles As Control.ControlCollection)

        For Each ctrl As Control In controles

            If String.Equals(Convert.ToString(ctrl.Tag), "ign") Then
                Continue For
            End If

            If TypeOf ctrl Is TextBox Then
                DirectCast(ctrl, TextBox).Clear()

            ElseIf TypeOf ctrl Is ComboBox Then
                DirectCast(ctrl, ComboBox).SelectedIndex = -1
                DirectCast(ctrl, ComboBox).Text = Nothing
            ElseIf TypeOf ctrl Is MaskedTextBox Then
                DirectCast(ctrl, MaskedTextBox).Clear()

            ElseIf TypeOf ctrl Is CheckBox Then
                DirectCast(ctrl, CheckBox).Checked = False

            End If

            If ctrl.HasChildren Then
                LimparControles(ctrl.Controls)
            End If

            btNovonumeroAPAC.Enabled = True
        Next

    End Sub

    Private Sub btnovo_Click(sender As Object, e As EventArgs) Handles btnovo.Click
        LimparControles(Me.Controls)
    End Sub

    Private Sub FormAMEOCI_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        CentralizarFormulario()
    End Sub

    Private Sub FecharToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FecharToolStripMenuItem.Click
        Me.Close()
        onClose()
    End Sub

    Private Sub getFromGCASPP()
        Try
            Dim leitor As New GCASPPReader
            Dim p = leitor.LerPaciente()
            Dim cepValido = p.CEP


            If txtNomePaciente.Text = "" Then txtNomePaciente.Text = p.Nome
            If txtCpfPaciente.Text = "" Then txtCpfPaciente.Text = p.CPF
            If txtNomeMae.Text = "" Then txtNomeMae.Text = p.Mae
            If txtSexo.Text = "" Then txtSexo.Text = p.Sexo.Substring(0, 1)
            If dtNascimento.Text = "  /  /" Then dtNascimento.Text = p.Nascimento
            If cepValido <> "11750-000" AndAlso cepValido <> "11750000" Then
                If txtCep.Text = "     -" Then txtCep.Text = cepValido
            End If
            If txtNumero.Text = "" Then txtNumero.Text = p.Numero
            If txtBairro.Text = "" Then txtBairro.Text = p.Bairro
            If txtLogradouro.Text = "" Then
                m.PreencherLogradouroSeparado(If(p.Logradouro Is Nothing, "", p.Logradouro.ToString()))
            End If
            chkResponsavel()

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btGCASPP.Click
        getFromGCASPP()
    End Sub

    Private Function LerTextoControle(hwnd As IntPtr) As String

        Dim tamanho As Integer = WinApi.SendMessage(hwnd, WinApi.WM_GETTEXTLENGTH, 0, Nothing)
        Dim sb As New StringBuilder(tamanho + 1)
        WinApi.SendMessage(hwnd, WinApi.WM_GETTEXT, sb.Capacity, sb)
        Return sb.ToString()

    End Function

    Private Function LerCaption(hwnd As IntPtr) As String

        Dim sb As New StringBuilder(500)

        WinApi.GetWindowText(hwnd, sb, sb.Capacity)

        Return sb.ToString()

    End Function

    Private Sub ListarControles(parent As IntPtr)

        Dim child As IntPtr = IntPtr.Zero
        Do
            child = WinApi.FindWindowEx(parent, child, Nothing, Nothing)

            If child = IntPtr.Zero Then Exit Do
            Dim sb As New System.Text.StringBuilder(256)

            WinApi.GetClassName(child, sb, sb.Capacity)
            Dim classe As String = sb.ToString()

            If classe = "TEdit" OrElse classe = "TDBEdit" OrElse classe = "TComboBox" OrElse classe = "TDBLookupComboBox" Then
                Dim txt As String = LerTextoControle(child)
                Dim caption As String = LerCaption(child)
                Debug.WriteLine($"HWND={child} Classe={classe} Valor=[{txt}]")
            End If
            ListarControles(child)
        Loop

    End Sub

    'Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles btCADSUS.Click
    '    Dim frm As New Form

    '    frm.FormBorderStyle = FormBorderStyle.None
    '    frm.StartPosition = FormStartPosition.CenterScreen
    '    frm.Size = New Size(170, 50)
    '    Dim lbl As New Label
    '    lbl.Dock = DockStyle.Fill
    '    lbl.TextAlign = ContentAlignment.MiddleCenter
    '    lbl.BackColor = Color.FromArgb(64, 64, 64)
    '    lbl.Font = New Font("Verdana", 8, FontStyle.Bold)
    '    lbl.ForeColor = Color.Gold

    '    frm.Controls.Add(lbl)

    '    If txtCpfPaciente.Text.Length <> 11 Then
    '        m.msgError("CPF inválido. Digite um CPF válido com 11 dígitos.")
    '        Exit Sub
    '    End If

    '    Dim paciente As Paciente = Await CADSUS.consultaCADSUS(txtCpfPaciente.Text)

    '    If paciente Is Nothing Then
    '        m.msgError("Paciente não encontrado.")
    '        Exit Sub
    '    Else
    '        Dim pacData = getPacientes(paciente.CPF)
    '        lbl.Text = "Consultando CADSUS. Aguarde..."
    '        frm.Show()

    '        If pacData.rows.count > 0 Then

    '            If pacData.rows(0).item("sexo") <> "" Then
    '                If m.msgQuestion("Imprimir cartão SUS do paciente?", "Paciente encontrado") Then

    '                    Dim url As String = $"http://{My.Settings.serverAME}:8080/sus?cpf={Uri.EscapeDataString(paciente.CPF)}&sexo={Uri.EscapeDataString(pacData.rows(0).item("sexo"))}"
    '                    Process.Start(New ProcessStartInfo With {.FileName = url, .UseShellExecute = True})

    '                End If

    '            End If

    '        End If
    '        frm.Close()
    '    End If

    '    'txtNomePaciente.Text = paciente.Nome
    '    'txtNomeMae.Text = paciente.NomeMae
    '    'dtNascimento.Text = paciente.DataNascimento
    '    txtCnsPaciente.Text = paciente.CNS

    'End Sub


    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles btCADSUS.Click
        Dim cpfDigitos As String = New String(txtCpfPaciente.Text.Where(AddressOf Char.IsDigit).ToArray())
        Dim cnsDigitos As String = New String(txtCnsPaciente.Text.Where(AddressOf Char.IsDigit).ToArray())
        Dim nome As String = txtNomePaciente.Text.Trim()

        Dim busca As String = ""
        If cpfDigitos.Length >= 11 Then
            busca = cpfDigitos
        ElseIf cnsDigitos.Length >= 15 Then
            busca = cnsDigitos
        ElseIf nome.Length >= 10 Then
            busca = nome
        End If

        If busca.Length < 10 Then
            m.msgInfo("Informe CPF, CNS ou nome completo do paciente.")
            Exit Sub
        End If

        If Await consulta.PuxadaSUS(busca) Then

        End If
    End Sub
    Private Sub txtCnsPaciente_TextChanged(sender As Object, e As EventArgs) Handles txtCnsPaciente.TextChanged
        If txtCnsPaciente.Text.Length >= 15 Then
            Clipboard.SetText(txtCnsPaciente.Text.Replace(".", ""))
        End If
    End Sub
    Private Sub ConsultasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultasToolStripMenuItem.Click
        FormAMEOCINumAPAC.Show()
    End Sub
    Private Sub ImportarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportarToolStripMenuItem.Click
        Dim desktop As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

        If OpenFileDialog1.ShowDialog Then
            Dim itens = (importFromApacs(OpenFileDialog1.FileName))
            If itens.Count = 1 AndAlso itens(0).NumeroApac = "0" Then
                Exit Sub
            End If
            APACtoDB(itens)
        End If
    End Sub
    Private Sub GeradorNumeraaoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeradorNumeraaoToolStripMenuItem.Click
        FormLogin.Show()
        FormLogin.system = "NUMAPAC"
    End Sub

    Private Function ExtrairAPACs(ByVal arquivo As String) As HashSet(Of String)

        Dim apacs As New HashSet(Of String)

        For Each linha As String In IO.File.ReadLines(arquivo)

            If linha.StartsWith("14") AndAlso linha.Length >= 21 Then

                Dim competencia As String = linha.Substring(2, 6)
                Dim apac As String = linha.Substring(8, 13)

                If IsNumeric(competencia) AndAlso IsNumeric(apac) Then
                    apacs.Add(apac)
                End If

            End If

        Next

        Return apacs

    End Function
    Private Sub FiltrarAPACToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FiltrarAPACToolStripMenuItem.Click

        Dim apacs = ExtrairAPACs(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\APTESTE.JUN")
        File.WriteAllLines("D:\Desktop\Found.TXT", apacs)

    End Sub
    Private Sub ExcluirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExcluirToolStripMenuItem.Click
        If m.msgQuestion("Deseja excluir OCI da fila? Esta ação é irreversível.", "Confirmação") Then
            If FormAMEmain.doQuery($"DELETE FROM oci_fila WHERE id={dgQueueItens.SelectedRows(0).Cells(0).Value}",, True) Then
                loadQueueOCI()
                ' loadQueueItens(dgQueueOCI.SelectedRows(0).Cells(0).Value, dgQueueOCI.SelectedRows(0).Cells(1).Value)
            End If
        End If
    End Sub
    Private Sub FormAMEOCI_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave
        Try
            popupGrid.Visible = False
            dgvSugestoes.Visible = False
        Catch ex As Exception

        End Try

    End Sub

    Private Sub chkSemCpf_CheckedChanged(sender As Object, e As EventArgs) Handles chkSemCpf.CheckedChanged
        If chkSemCpf.Checked Then
            txtCpfPaciente.Text = ""
            txtCpfPaciente.Enabled = False
            btCADSUS.Enabled = False
        Else
            txtCpfPaciente.Enabled = True
            btCADSUS.Enabled = True
        End If
    End Sub

    Private Sub btPrintSUS_Click(sender As Object, e As EventArgs) Handles btPrintSUS.Click
        If IDpacienteSelecionado IsNot Nothing And txtCpfPaciente.Text.Length >= 11 Then
            If m.msgQuestion("Imprimir cartão SUS do paciente?", "Paciente encontrado") Then
                Dim url As String = $"http://{My.Settings.serverAME}:8080/sus?cpf={Uri.EscapeDataString(txtCpfPaciente.Text)}&sexo={Uri.EscapeDataString(txtSexo.Text)}"
                Process.Start(New ProcessStartInfo With {.FileName = url, .UseShellExecute = True})
            End If
        Else
            m.msgAlert("Selecione um paciente com CPF válido para imprimir o cartão SUS.")
        End If
    End Sub
    Private Sub txtCnsPaciente_Enter(sender As Object, e As EventArgs) Handles txtCnsPaciente.Enter
        m.setCursorStart(txtCnsPaciente)
    End Sub
    Private Sub LoteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoteToolStripMenuItem.Click
        Dim caminhoLog As String = Path.Combine(Application.StartupPath, "Logs", "geracaoemlotelog.txt")

        If File.Exists(caminhoLog) Then
            Process.Start(New ProcessStartInfo(caminhoLog) With {.UseShellExecute = True})
        Else
            MessageBox.Show("Nenhum log encontrado ainda.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

End Class