Imports System.Data
Imports FirebirdSql.Data.FirebirdClient

Public NotInheritable Class CnesFirebird

    Private Sub New()
    End Sub

    Private Shared Function ObterStringConexao() As String
        Dim servidor As String = If(String.IsNullOrWhiteSpace(My.Settings.cnesServer), "10.32.157.99", My.Settings.cnesServer)
        Dim porta As String = If(String.IsNullOrWhiteSpace(My.Settings.cnesPort), "3050", My.Settings.cnesPort)
        Dim banco As String = If(String.IsNullOrWhiteSpace(My.Settings.cnesDatabase),
                                 "C:\Program Files (x86)\Datasus\CNES\CNES.GDB",
                                 My.Settings.cnesDatabase)
        Dim usuario As String = If(String.IsNullOrWhiteSpace(My.Settings.cnesUser), "SYSDBA", My.Settings.cnesUser)
        Dim senha As String = If(String.IsNullOrWhiteSpace(My.Settings.cnesPassword), "masterkey", My.Settings.cnesPassword)
        Dim charset As String = If(String.IsNullOrWhiteSpace(My.Settings.cnesCharset), "WIN1252", My.Settings.cnesCharset)

        'Quando o executável é copiado sem o .config, o valor padrão gerado
        'pelo Settings.Designer pode conter duas barras invertidas. O Firebird
        'recebe esse caminho como está e não consegue localizar o banco no
        'servidor. Normalizamos o caminho antes de montar a conexão.
        banco = NormalizarCaminhoBanco(banco)

        Return String.Format(
            "DataSource={0};Port={1};Database={2};User ID={3};Password={4};Charset={5};",
            servidor,
            porta,
            banco,
            usuario,
            senha,
            charset)
    End Function

    Private Shared Function NormalizarCaminhoBanco(caminho As String) As String
        If caminho Is Nothing Then Return String.Empty

        Dim resultado As String = caminho.Trim().Trim(""""c)
        Do While resultado.Contains("\\")
            resultado = resultado.Replace("\\", "\")
        Loop

        Return resultado
    End Function

    Public Shared Function ObterDiagnostico() As String
        Dim banco As String = If(String.IsNullOrWhiteSpace(My.Settings.cnesDatabase),
                                 "C:\Program Files (x86)\Datasus\CNES\CNES.GDB",
                                 My.Settings.cnesDatabase)

        Return "Servidor: " & If(String.IsNullOrWhiteSpace(My.Settings.cnesServer), "10.32.157.99", My.Settings.cnesServer) &
               ":" & If(String.IsNullOrWhiteSpace(My.Settings.cnesPort), "3050", My.Settings.cnesPort) &
               Environment.NewLine &
               "Banco: " & NormalizarCaminhoBanco(banco) &
               Environment.NewLine &
               "Usuário: " & If(String.IsNullOrWhiteSpace(My.Settings.cnesUser), "SYSDBA", My.Settings.cnesUser) &
               Environment.NewLine &
               "Configuração: " & System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Secretaria.exe.config")
    End Function

    Public Shared Function TestarConexao(ByRef mensagemErro As String) As Boolean
        mensagemErro = String.Empty

        Try
            Using conexao As New FbConnection(ObterStringConexao())
                conexao.Open()
                If conexao.State = ConnectionState.Open Then
                    Return True
                End If

                mensagemErro = "A conexão foi criada, mas o estado retornado foi: " & conexao.State.ToString() & "."
                Return False
            End Using
        Catch ex As Exception
            mensagemErro = If(String.IsNullOrWhiteSpace(ex.Message), ex.GetType().FullName, ex.Message)
            If ex.InnerException IsNot Nothing Then
                mensagemErro &= Environment.NewLine & "Detalhe: " & ex.InnerException.Message
            End If
            Return False
        End Try
    End Function

    Public Shared Function ConsultarProfissionais(Optional cpf As String = "",
                                                   Optional nome As String = "",
                                                   Optional codigoVinculo As String = "") As DataTable
        Dim tabela As New DataTable()

        Dim sql As String =
            "SELECT " &
            "p.CPF_PROF AS CPF, " &
            "p.COD_CNS AS CNS, " &
            "p.NOME_PROF AS NOME, " &
            "e.CNES AS CNES, " &
            "v.COD_CBO AS CBO, " &
            "c.DESCRICAO AS DESCRICAO_CBO, " &
            "p.DATA_NASC AS NASCIMENTO, " &
            "v.CGHORAOUTR AS CARGA_HORARIA_OUTRA, " &
            "v.CG_HORAAMB AS CARGA_HORARIA_AMBULATORIAL, " &
            "v.CGHORAHOSP AS CARGA_HORARIA_HOSPITALAR, " &
            "v.TP_SUS_NAO_SUS AS TIPO_SUS, " &
            "v.IND_VINC AS TIPO_VINCULO, " &
            "e.R_SOCIAL AS RAZAO_SOCIAL, " &
            "e.NOME_FANTA AS NOME_FANTASIA, " &
            "p.PROF_ID AS PROFISSIONAL_ID, " &
            "v.UNIDADE_ID AS UNIDADE_ID " &
            "FROM LFCES018 p " &
            "INNER JOIN LFCES021 v ON v.PROF_ID = p.PROF_ID " &
            "INNER JOIN LFCES004 e ON e.UNIDADE_ID = v.UNIDADE_ID " &
            "LEFT JOIN NFCES026 c ON c.COD_CBO = v.COD_CBO " &
            "WHERE (p.STATUS = '1' OR p.STATUS IS NULL) " &
            "AND (v.STATUS = '1' OR v.STATUS IS NULL) "

        If Not String.IsNullOrWhiteSpace(cpf) Then
            sql &= "AND p.CPF_PROF = @cpf "
        End If

        If Not String.IsNullOrWhiteSpace(nome) Then
            sql &= "AND UPPER(p.NOME_PROF) LIKE UPPER(@nome) "
        End If

        If Not String.IsNullOrWhiteSpace(codigoVinculo) Then
            sql &= "AND v.IND_VINC = @codigoVinculo "
        End If

        sql &= "ORDER BY p.NOME_PROF, v.COD_CBO"

        Using conexao As New FbConnection(ObterStringConexao())
            conexao.Open()

            Using comando As New FbCommand(sql, conexao)
                If Not String.IsNullOrWhiteSpace(cpf) Then
                    comando.Parameters.Add("@cpf", FbDbType.VarChar, 11).Value = cpf.Trim()
                End If

                If Not String.IsNullOrWhiteSpace(nome) Then
                    comando.Parameters.Add("@nome", FbDbType.VarChar, 100).Value = "%" & nome.Trim() & "%"
                End If

                If Not String.IsNullOrWhiteSpace(codigoVinculo) Then
                    comando.Parameters.Add("@codigoVinculo", FbDbType.VarChar, 6).Value = codigoVinculo
                End If

                Using adaptador As New FbDataAdapter(comando)
                    adaptador.Fill(tabela)
                End Using
            End Using
        End Using

        LimparValoresTexto(tabela)
        Return tabela
    End Function

    ''' <summary>
    ''' Consulta a tabela de profissionais sem repetir o profissional por causa
    ''' da quantidade de vínculos existentes. Usada pelo grid principal do
    ''' formulário de cadastro.
    ''' </summary>
    Public Shared Function ConsultarProfissionaisCadastro(Optional cpf As String = "",
                                                           Optional nome As String = "") As DataTable
        Dim tabela As New DataTable()

        Dim sql As String =
            "SELECT " &
            "p.PROF_ID AS PROFISSIONAL_ID, " &
            "p.CPF_PROF AS CPF, " &
            "p.COD_CNS AS CNS, " &
            "p.NOME_PROF AS NOME, " &
            "p.DATA_NASC AS NASCIMENTO " &
            "FROM LFCES018 p " &
            "WHERE (p.STATUS = '1' OR p.STATUS IS NULL) "

        If Not String.IsNullOrWhiteSpace(cpf) Then
            sql &= "AND p.CPF_PROF = @cpf "
        End If

        If Not String.IsNullOrWhiteSpace(nome) Then
            sql &= "AND UPPER(p.NOME_PROF) LIKE UPPER(@nome) "
        End If

        sql &= "ORDER BY p.NOME_PROF"

        Using conexao As New FbConnection(ObterStringConexao())
            conexao.Open()

            Using comando As New FbCommand(sql, conexao)
                If Not String.IsNullOrWhiteSpace(cpf) Then
                    comando.Parameters.Add("@cpf", FbDbType.VarChar, 11).Value = cpf.Trim()
                End If

                If Not String.IsNullOrWhiteSpace(nome) Then
                    comando.Parameters.Add("@nome", FbDbType.VarChar, 100).Value = "%" & nome.Trim() & "%"
                End If

                Using adaptador As New FbDataAdapter(comando)
                    adaptador.Fill(tabela)
                End Using
            End Using
        End Using

        LimparValoresTexto(tabela)
        Return tabela
    End Function

    ''' <summary>
    ''' Consulta todos os vínculos do profissional selecionado no grid de
    ''' profissionais. Os códigos são mantidos no resultado para que a tela
    ''' consiga atualizar o registro correto, mesmo exibindo descrições.
    ''' </summary>
    Public Shared Function ConsultarVinculosProfissional(profissionalId As String) As DataTable
        Dim tabela As New DataTable()

        If String.IsNullOrWhiteSpace(profissionalId) Then Return tabela

        Dim sql As String =
            "SELECT " &
            "v.UNIDADE_ID AS UNIDADE_ID, " &
            "e.CNES AS CNES, " &
            "e.NOME_FANTA AS ESTABELECIMENTO, " &
            "e.R_SOCIAL AS RAZAO_SOCIAL, " &
            "v.COD_CBO AS COD_CBO, " &
            "c.DESCRICAO AS DESCRICAO_CBO, " &
            "v.CGHORAOUTR AS CARGA_HORARIA_OUTRA, " &
            "v.CG_HORAAMB AS CARGA_HORARIA_AMBULATORIAL, " &
            "v.CGHORAHOSP AS CARGA_HORARIA_HOSPITALAR, " &
            "v.TP_SUS_NAO_SUS AS TIPO_SUS, " &
            "v.IND_VINC AS CODIGO_VINCULO, " &
            "v.NU_CNPJ_DET_VINC AS CNPJ_INTERMEDIADOR, " &
            "v.TP_PRECEPTOR AS TP_PRECEPTOR, " &
            "v.TP_RESIDENTE AS TP_RESIDENTE, " &
            "v.STATUS AS STATUS_VINCULO, " &
            "v.STATUSMOV AS STATUSMOV_VINCULO, " &
            "v.CHECKSUM AS CHECKSUM_VINCULO " &
            "FROM LFCES021 v " &
            "INNER JOIN LFCES004 e ON e.UNIDADE_ID = v.UNIDADE_ID " &
            "LEFT JOIN NFCES026 c ON c.COD_CBO = v.COD_CBO " &
            "WHERE v.PROF_ID = @profissionalId " &
            "AND (v.STATUS = '1' OR v.STATUS IS NULL) " &
            "ORDER BY e.NOME_FANTA, v.COD_CBO"

        Using conexao As New FbConnection(ObterStringConexao())
            conexao.Open()

            Using comando As New FbCommand(sql, conexao)
                comando.Parameters.Add("@profissionalId", FbDbType.VarChar, 16).Value = profissionalId.Trim()

                Using adaptador As New FbDataAdapter(comando)
                    adaptador.Fill(tabela)
                End Using
            End Using
        End Using

        LimparValoresTexto(tabela)
        Return tabela
    End Function

    ''' <summary>
    ''' Retorna os estabelecimentos diretamente da tabela LFCES004.
    ''' UNIDADE_ID é a chave usada pelo vínculo em LFCES021 e, por isso, é
    ''' mantida como ValueMember no combo da tela.
    ''' </summary>
    Public Shared Function ConsultarEstabelecimentos() As DataTable
        Dim tabela As New DataTable()

        Dim sql As String =
            "SELECT " &
            "e.UNIDADE_ID AS UNIDADE_ID, " &
            "e.CNES AS CNES, " &
            "e.NOME_FANTA AS NOME_FANTASIA, " &
            "e.R_SOCIAL AS RAZAO_SOCIAL " &
            "FROM LFCES004 e " &
            "WHERE (e.STATUS = '1' OR (e.STATUS IS NULL AND e.STATUSMOV = '1')) " &
            "ORDER BY e.NOME_FANTA"

        Using conexao As New FbConnection(ObterStringConexao())
            conexao.Open()

            Using comando As New FbCommand(sql, conexao)
                Using adaptador As New FbDataAdapter(comando)
                    adaptador.Fill(tabela)
                End Using
            End Using
        End Using

        LimparValoresTexto(tabela)
        Return tabela
    End Function

    ''' <summary>
    ''' Lista os CBOs oficiais da base CNES.
    ''' </summary>
    Public Shared Function ConsultarCBOS() As DataTable
        Dim tabela As New DataTable()

        Const sql As String =
            "SELECT COD_CBO, DESCRICAO, INDPROFISS, TP_CBO_SAUDE, ST_CBO_REGULA " &
            "FROM NFCES026 " &
            "ORDER BY DESCRICAO"

        Using conexao As New FbConnection(ObterStringConexao())
            conexao.Open()
            Using comando As New FbCommand(sql, conexao)
                Using adaptador As New FbDataAdapter(comando)
                    adaptador.Fill(tabela)
                End Using
            End Using
        End Using

        LimparValoresTexto(tabela)
        Return tabela
    End Function

    ''' <summary>
    ''' Lista as formas de contratação com o estabelecimento.
    ''' </summary>
    Public Shared Function ConsultarFormasContratacaoEstabelecimento() As DataTable
        Return ConsultarTabelaContrato(
            "SELECT CD_VINCULACAO AS CODIGO, DS_VINCULACAO AS DESCRICAO " &
            "FROM NFCES056 WHERE ST_HABILITADO = 'S' ORDER BY CD_VINCULACAO")
    End Function

    ''' <summary>
    ''' Lista as formas de contratação com o empregador para uma forma de
    ''' contratação com o estabelecimento.
    ''' </summary>
    Public Shared Function ConsultarFormasContratacaoEmpregador(codigoEstabelecimento As String) As DataTable
        Dim tabela As New DataTable()
        If String.IsNullOrWhiteSpace(codigoEstabelecimento) Then Return tabela

        Const sql As String =
            "SELECT TP_VINCULO AS CODIGO, DS_VINCULO AS DESCRICAO " &
            "FROM NFCES057 " &
            "WHERE CD_VINCULACAO = @codigo " &
            "AND ST_HABILITADO = 'S' " &
            "ORDER BY TP_VINCULO"

        Using conexao As New FbConnection(ObterStringConexao())
            conexao.Open()
            Using comando As New FbCommand(sql, conexao)
                comando.Parameters.Add("@codigo", FbDbType.VarChar, 2).Value = codigoEstabelecimento.Trim()
                Using adaptador As New FbDataAdapter(comando)
                    adaptador.Fill(tabela)
                End Using
            End Using
        End Using

        LimparValoresTexto(tabela)
        Return tabela
    End Function

    ''' <summary>
    ''' Lista os detalhamentos e códigos de vínculo oficiais para a combinação
    ''' de forma de contratação com estabelecimento e empregador.
    ''' </summary>
    Public Shared Function ConsultarDetalhamentosVinculo(codigoEstabelecimento As String,
                                                         codigoEmpregador As String) As DataTable
        Dim tabela As New DataTable()
        If String.IsNullOrWhiteSpace(codigoEstabelecimento) OrElse
           String.IsNullOrWhiteSpace(codigoEmpregador) Then Return tabela

        Const sql As String =
            "SELECT IND_VINC AS CODIGO, DS_SUBVINCULO AS DESCRICAO, " &
            "ST_SOLICITA_CNPJ AS SOLICITA_CNPJ " &
            "FROM NFCES058 " &
            "WHERE CD_VINCULACAO = @codigoEstabelecimento " &
            "AND TP_VINCULO = @codigoEmpregador " &
            "AND ST_HABILITADO = 'S' " &
            "ORDER BY IND_VINC"

        Using conexao As New FbConnection(ObterStringConexao())
            conexao.Open()
            Using comando As New FbCommand(sql, conexao)
                comando.Parameters.Add("@codigoEstabelecimento", FbDbType.VarChar, 2).Value = codigoEstabelecimento.Trim()
                comando.Parameters.Add("@codigoEmpregador", FbDbType.VarChar, 2).Value = codigoEmpregador.Trim()
                Using adaptador As New FbDataAdapter(comando)
                    adaptador.Fill(tabela)
                End Using
            End Using
        End Using

        LimparValoresTexto(tabela)
        Return tabela
    End Function

    Private Shared Function ConsultarTabelaContrato(sql As String) As DataTable
        Dim tabela As New DataTable()

        Using conexao As New FbConnection(ObterStringConexao())
            conexao.Open()
            Using comando As New FbCommand(sql, conexao)
                Using adaptador As New FbDataAdapter(comando)
                    adaptador.Fill(tabela)
                End Using
            End Using
        End Using

        LimparValoresTexto(tabela)
        Return tabela
    End Function

    ''' <summary>
    ''' Inclui somente o profissional. O vínculo é incluído posteriormente pelo
    ''' botão de adicionar vínculo da tela.
    ''' </summary>
    Public Shared Function CadastrarProfissionalCadastro(cpf As String,
                                                          nome As String,
                                                          dataNascimento As Nullable(Of DateTime),
                                                          cns As String,
                                                          Optional usuario As String = "GUILHERME") As String
        cpf = SomenteDigitos(cpf)
        cns = SomenteDigitos(cns)
        nome = NormalizarNome(nome)
        usuario = NormalizarUsuario(usuario)

        ValidarDadosProfissional(cpf, nome)
        Dim profissionalId As String = "00000" & cpf

        Using conexao As New FbConnection(ObterStringConexao())
            conexao.Open()
            Using transacao As FbTransaction = conexao.BeginTransaction()
                Try
                    ValidarCPFInexistente(cpf, conexao, transacao)

                    Using comando As New FbCommand(
                        "INSERT INTO LFCES018 " &
                        "(PROF_ID, CPF_PROF, NOME_PROF, DATA_NASC, COD_CNS, STATUS, STATUSMOV, DATA_ATU, USUARIO, ST_NMPROF_CADSUS) " &
                        "VALUES (@profId, @cpf, @nome, @dataNasc, @cns, '1', '1', CURRENT_DATE, @usuario, 'S')",
                        conexao, transacao)
                        comando.Parameters.Add("@profId", FbDbType.VarChar, 16).Value = profissionalId
                        comando.Parameters.Add("@cpf", FbDbType.VarChar, 11).Value = cpf
                        comando.Parameters.Add("@nome", FbDbType.VarChar, 60).Value = nome
                        comando.Parameters.Add("@dataNasc", FbDbType.Date).Value =
                            If(dataNascimento.HasValue, CType(dataNascimento.Value.Date, Object), DBNull.Value)
                        comando.Parameters.Add("@cns", FbDbType.VarChar, 60).Value =
                            If(cns.Length = 0, CType(DBNull.Value, Object), cns)
                        comando.Parameters.Add("@usuario", FbDbType.VarChar, 60).Value = usuario
                        comando.ExecuteNonQuery()
                    End Using

                    transacao.Commit()
                    Return profissionalId
                Catch
                    Try
                        transacao.Rollback()
                    Catch
                    End Try
                    Throw
                End Try
            End Using
        End Using
    End Function

    Public Shared Sub AtualizarProfissionalCadastro(profissionalId As String,
                                                     nome As String,
                                                     dataNascimento As Nullable(Of DateTime),
                                                     cns As String,
                                                     Optional usuario As String = "GUILHERME")
        If String.IsNullOrWhiteSpace(profissionalId) Then
            Throw New ArgumentException("O profissional selecionado é obrigatório.", NameOf(profissionalId))
        End If

        nome = NormalizarNome(nome)
        cns = SomenteDigitos(cns)
        usuario = NormalizarUsuario(usuario)
        ValidarDadosProfissional("00000000000", nome, False)

        Using conexao As New FbConnection(ObterStringConexao())
            conexao.Open()
            Using comando As New FbCommand(
                "UPDATE LFCES018 SET NOME_PROF = @nome, DATA_NASC = @dataNasc, COD_CNS = @cns, " &
                "STATUS = '1', STATUSMOV = '2', DATA_ATU = CURRENT_DATE, USUARIO = @usuario " &
                "WHERE PROF_ID = @profId", conexao)
                comando.Parameters.Add("@nome", FbDbType.VarChar, 60).Value = nome
                comando.Parameters.Add("@dataNasc", FbDbType.Date).Value =
                    If(dataNascimento.HasValue, CType(dataNascimento.Value.Date, Object), DBNull.Value)
                comando.Parameters.Add("@cns", FbDbType.VarChar, 60).Value =
                    If(cns.Length = 0, CType(DBNull.Value, Object), cns)
                comando.Parameters.Add("@usuario", FbDbType.VarChar, 60).Value = usuario
                comando.Parameters.Add("@profId", FbDbType.VarChar, 16).Value = profissionalId.Trim()

                If comando.ExecuteNonQuery() = 0 Then
                    Throw New InvalidOperationException("O profissional selecionado não foi encontrado.")
                End If
            End Using
        End Using
    End Sub

    Public Shared Sub CadastrarVinculo(profissionalId As String,
                                       cnes As String,
                                       codigoCbo As String,
                                       codigoVinculo As String,
                                       cargaHorariaAmbulatorial As Integer,
                                       cargaHorariaOutra As Integer,
                                       cargaHorariaHospitalar As Integer,
                                       tipoSusNaoSus As String,
                                       Optional cnpjIntermediador As String = "",
                                       Optional usuario As String = "GUILHERME")
        ValidarDadosVinculo(profissionalId, cnes, codigoCbo, codigoVinculo,
                            cargaHorariaAmbulatorial, cargaHorariaOutra,
                            cargaHorariaHospitalar, tipoSusNaoSus)
        cnpjIntermediador = NormalizarCNPJ(cnpjIntermediador)
        usuario = NormalizarUsuario(usuario)

        Using conexao As New FbConnection(ObterStringConexao())
            conexao.Open()
            Using transacao As FbTransaction = conexao.BeginTransaction()
                Try
                    Dim unidadeId As String = ObterUnidadeId(cnes, conexao, transacao)
                    ValidarCbo(codigoCbo, conexao, transacao)
                    ValidarCargaHorariaCbo(codigoCbo, cargaHorariaAmbulatorial,
                                           cargaHorariaOutra, cargaHorariaHospitalar,
                                           conexao, transacao)
                    ValidarVinculo(codigoVinculo, conexao, transacao)
                    ValidarVinculoDuplicado(unidadeId, profissionalId, codigoCbo,
                                            tipoSusNaoSus, codigoVinculo, conexao, transacao)

                    InserirVinculo(unidadeId, profissionalId, codigoCbo, tipoSusNaoSus,
                                   codigoVinculo, cargaHorariaAmbulatorial,
                                   cargaHorariaOutra, cargaHorariaHospitalar,
                                   cnpjIntermediador, usuario, conexao, transacao)
                    transacao.Commit()
                Catch
                    Try
                        transacao.Rollback()
                    Catch
                    End Try
                    Throw
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub AtualizarVinculo(profissionalId As String,
                                       unidadeIdAnterior As String,
                                       cboAnterior As String,
                                       tipoSusAnterior As String,
                                       codigoVinculoAnterior As String,
                                       cnes As String,
                                       codigoCbo As String,
                                       codigoVinculo As String,
                                       cargaHorariaAmbulatorial As Integer,
                                       cargaHorariaOutra As Integer,
                                       cargaHorariaHospitalar As Integer,
                                       tipoSusNaoSus As String,
                                       Optional cnpjIntermediador As String = "",
                                       Optional usuario As String = "GUILHERME")
        ValidarDadosVinculo(profissionalId, cnes, codigoCbo, codigoVinculo,
                            cargaHorariaAmbulatorial, cargaHorariaOutra,
                            cargaHorariaHospitalar, tipoSusNaoSus)
        cnpjIntermediador = NormalizarCNPJ(cnpjIntermediador)
        usuario = NormalizarUsuario(usuario)

        Using conexao As New FbConnection(ObterStringConexao())
            conexao.Open()
            Using transacao As FbTransaction = conexao.BeginTransaction()
                Try
                    Dim unidadeIdNova As String = ObterUnidadeId(cnes, conexao, transacao)
                    ValidarCbo(codigoCbo, conexao, transacao)
                    ValidarCargaHorariaCbo(codigoCbo, cargaHorariaAmbulatorial,
                                           cargaHorariaOutra, cargaHorariaHospitalar,
                                           conexao, transacao)
                    ValidarVinculo(codigoVinculo, conexao, transacao)

                    If Not String.Equals(unidadeIdAnterior, unidadeIdNova, StringComparison.OrdinalIgnoreCase) OrElse
                       Not String.Equals(cboAnterior, codigoCbo, StringComparison.OrdinalIgnoreCase) OrElse
                       Not String.Equals(tipoSusAnterior, tipoSusNaoSus, StringComparison.OrdinalIgnoreCase) OrElse
                       Not String.Equals(codigoVinculoAnterior, codigoVinculo, StringComparison.OrdinalIgnoreCase) Then
                        ValidarVinculoDuplicado(unidadeIdNova, profissionalId, codigoCbo,
                                                tipoSusNaoSus, codigoVinculo, conexao, transacao)
                    End If

                    Using comando As New FbCommand(
                        "UPDATE LFCES021 SET UNIDADE_ID = @unidadeNova, COD_CBO = @cboNovo, " &
                        "TP_SUS_NAO_SUS = @susNovo, IND_VINC = @vinculoNovo, " &
                        "CGHORAOUTR = @cargaOutra, CG_HORAAMB = @cargaAmb, CGHORAHOSP = @cargaHosp, " &
                        "NU_CNPJ_DET_VINC = @cnpj, " &
                        "STATUS = '1', STATUSMOV = '2', DATA_ATU = CURRENT_DATE, USUARIO = @usuario " &
                        "WHERE UNIDADE_ID = @unidadeAnterior AND PROF_ID = @profId " &
                        "AND COD_CBO = @cboAnterior AND TP_SUS_NAO_SUS = @susAnterior " &
                        "AND IND_VINC = @vinculoAnterior", conexao, transacao)
                        comando.Parameters.Add("@unidadeNova", FbDbType.VarChar, 31).Value = unidadeIdNova
                        comando.Parameters.Add("@cboNovo", FbDbType.VarChar, 6).Value = codigoCbo
                        comando.Parameters.Add("@susNovo", FbDbType.Char, 1).Value = tipoSusNaoSus
                        comando.Parameters.Add("@vinculoNovo", FbDbType.VarChar, 6).Value = codigoVinculo
                        comando.Parameters.Add("@cargaOutra", FbDbType.Integer).Value = cargaHorariaOutra
                        comando.Parameters.Add("@cargaAmb", FbDbType.Integer).Value = cargaHorariaAmbulatorial
                        comando.Parameters.Add("@cargaHosp", FbDbType.Integer).Value = cargaHorariaHospitalar
                        comando.Parameters.Add("@cnpj", FbDbType.VarChar, 14).Value =
                            If(cnpjIntermediador.Length = 0, CType(DBNull.Value, Object), cnpjIntermediador)
                        comando.Parameters.Add("@usuario", FbDbType.VarChar, 60).Value = usuario
                        comando.Parameters.Add("@unidadeAnterior", FbDbType.VarChar, 31).Value = unidadeIdAnterior
                        comando.Parameters.Add("@profId", FbDbType.VarChar, 16).Value = profissionalId
                        comando.Parameters.Add("@cboAnterior", FbDbType.VarChar, 6).Value = cboAnterior
                        comando.Parameters.Add("@susAnterior", FbDbType.Char, 1).Value = tipoSusAnterior
                        comando.Parameters.Add("@vinculoAnterior", FbDbType.VarChar, 6).Value = codigoVinculoAnterior

                        If comando.ExecuteNonQuery() = 0 Then
                            Throw New InvalidOperationException("O vínculo selecionado não foi encontrado.")
                        End If
                    End Using

                    transacao.Commit()
                Catch
                    Try
                        transacao.Rollback()
                    Catch
                    End Try
                    Throw
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub InativarVinculo(profissionalId As String,
                                      unidadeId As String,
                                      codigoCbo As String,
                                      tipoSus As String,
                                      codigoVinculo As String,
                                      Optional usuario As String = "GUILHERME")
        If String.IsNullOrWhiteSpace(profissionalId) OrElse String.IsNullOrWhiteSpace(unidadeId) Then
            Throw New ArgumentException("O vínculo selecionado é obrigatório.")
        End If

        Using conexao As New FbConnection(ObterStringConexao())
            conexao.Open()
            Using comando As New FbCommand(
                "UPDATE LFCES021 SET STATUS = '0', STATUSMOV = '2', DATA_ATU = CURRENT_DATE, USUARIO = @usuario " &
                "WHERE UNIDADE_ID = @unidadeId AND PROF_ID = @profId AND COD_CBO = @cbo " &
                "AND TP_SUS_NAO_SUS = @sus AND IND_VINC = @vinculo", conexao)
                comando.Parameters.Add("@usuario", FbDbType.VarChar, 60).Value = NormalizarUsuario(usuario)
                comando.Parameters.Add("@unidadeId", FbDbType.VarChar, 31).Value = unidadeId
                comando.Parameters.Add("@profId", FbDbType.VarChar, 16).Value = profissionalId
                comando.Parameters.Add("@cbo", FbDbType.VarChar, 6).Value = codigoCbo
                comando.Parameters.Add("@sus", FbDbType.Char, 1).Value = tipoSus
                comando.Parameters.Add("@vinculo", FbDbType.VarChar, 6).Value = codigoVinculo

                If comando.ExecuteNonQuery() = 0 Then
                    Throw New InvalidOperationException("O vínculo selecionado não foi encontrado.")
                End If
            End Using
        End Using
    End Sub

    Public Shared Sub InativarProfissional(profissionalId As String,
                                           Optional usuario As String = "GUILHERME")
        If String.IsNullOrWhiteSpace(profissionalId) Then
            Throw New ArgumentException("O profissional selecionado é obrigatório.", NameOf(profissionalId))
        End If

        Using conexao As New FbConnection(ObterStringConexao())
            conexao.Open()
            Using transacao As FbTransaction = conexao.BeginTransaction()
                Try
                    Using comandoVinculos As New FbCommand(
                        "UPDATE LFCES021 SET STATUS = '0', STATUSMOV = '2', DATA_ATU = CURRENT_DATE, USUARIO = @usuario " &
                        "WHERE PROF_ID = @profId AND (STATUS = '1' OR STATUS IS NULL)", conexao, transacao)
                        comandoVinculos.Parameters.Add("@usuario", FbDbType.VarChar, 60).Value = NormalizarUsuario(usuario)
                        comandoVinculos.Parameters.Add("@profId", FbDbType.VarChar, 16).Value = profissionalId
                        comandoVinculos.ExecuteNonQuery()
                    End Using

                    Using comandoProfissional As New FbCommand(
                        "UPDATE LFCES018 SET STATUS = '0', STATUSMOV = '2', DATA_ATU = CURRENT_DATE, USUARIO = @usuario " &
                        "WHERE PROF_ID = @profId", conexao, transacao)
                        comandoProfissional.Parameters.Add("@usuario", FbDbType.VarChar, 60).Value = NormalizarUsuario(usuario)
                        comandoProfissional.Parameters.Add("@profId", FbDbType.VarChar, 16).Value = profissionalId
                        If comandoProfissional.ExecuteNonQuery() = 0 Then
                            Throw New InvalidOperationException("O profissional selecionado não foi encontrado.")
                        End If
                    End Using

                    transacao.Commit()
                Catch
                    Try
                        transacao.Rollback()
                    Catch
                    End Try
                    Throw
                End Try
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Inclui um profissional e seu vínculo em uma unidade CNES.
    ''' A operação é feita em uma única transação; qualquer falha desfaz as duas inclusões.
    ''' </summary>
    Public Shared Function CadastrarProfissional(cpf As String,
                                                  nome As String,
                                                  dataNascimento As Nullable(Of DateTime),
                                                  cns As String,
                                                  cnes As String,
                                                  codigoCbo As String,
                                                  codigoVinculo As String,
                                                  cargaHorariaAmbulatorial As Integer,
                                                  Optional cargaHorariaOutra As Integer = 0,
                                                  Optional cargaHorariaHospitalar As Integer = 0,
                                                  Optional tipoSusNaoSus As String = "S",
                                                  Optional usuario As String = "GUILHERME") As String
        cpf = SomenteDigitos(cpf)
        cns = SomenteDigitos(cns)
        nome = If(nome, String.Empty).Trim().ToUpperInvariant()
        cnes = If(cnes, String.Empty).Trim()
        codigoCbo = If(codigoCbo, String.Empty).Trim()
        codigoVinculo = If(codigoVinculo, String.Empty).Trim()
        tipoSusNaoSus = If(tipoSusNaoSus, String.Empty).Trim().ToUpperInvariant()
        usuario = If(usuario, String.Empty).Trim().ToUpperInvariant()

        If cpf.Length <> 11 Then Throw New ArgumentException("O CPF deve conter 11 dígitos.", NameOf(cpf))
        If String.IsNullOrWhiteSpace(nome) Then Throw New ArgumentException("O nome do profissional é obrigatório.", NameOf(nome))
        If cns.Length <> 15 Then Throw New ArgumentException("O CNS deve conter 15 dígitos.", NameOf(cns))
        If String.IsNullOrWhiteSpace(cnes) Then Throw New ArgumentException("O CNES é obrigatório.", NameOf(cnes))
        If codigoCbo.Length <> 6 Then Throw New ArgumentException("O CBO deve conter 6 dígitos.", NameOf(codigoCbo))
        If codigoVinculo.Length <> 6 Then Throw New ArgumentException("O vínculo deve conter 6 dígitos.", NameOf(codigoVinculo))
        If tipoSusNaoSus <> "S" AndAlso tipoSusNaoSus <> "N" Then
            Throw New ArgumentException("O tipo SUS deve ser S ou N.", NameOf(tipoSusNaoSus))
        End If
        If cargaHorariaAmbulatorial < 0 OrElse cargaHorariaOutra < 0 OrElse cargaHorariaHospitalar < 0 Then
            Throw New ArgumentException("As cargas horárias não podem ser negativas.")
        End If

        ' A base utiliza o CPF com cinco zeros à esquerda como identificador do profissional.
        Dim profissionalId As String = "00000" & cpf

        Using conexao As New FbConnection(ObterStringConexao())
            conexao.Open()

            Using transacao As FbTransaction = conexao.BeginTransaction()
                Try
                    Dim unidadeId As String = Nothing

                    Using comandoUnidade As New FbCommand(
                        "SELECT UNIDADE_ID FROM LFCES004 WHERE CNES = @cnes AND STATUS = '1'", conexao, transacao)
                        comandoUnidade.Parameters.Add("@cnes", FbDbType.VarChar, 7).Value = cnes
                        Dim valorUnidade As Object = comandoUnidade.ExecuteScalar()
                        If valorUnidade Is Nothing OrElse valorUnidade Is DBNull.Value Then
                            Throw New InvalidOperationException("O CNES informado não foi encontrado como unidade ativa: " & cnes)
                        End If
                        unidadeId = valorUnidade.ToString().Trim()
                    End Using

                    Using comandoCbo As New FbCommand(
                        "SELECT COUNT(*) FROM NFCES026 WHERE COD_CBO = @cbo", conexao, transacao)
                        comandoCbo.Parameters.Add("@cbo", FbDbType.VarChar, 6).Value = codigoCbo
                        If Convert.ToInt32(comandoCbo.ExecuteScalar()) = 0 Then
                            Throw New InvalidOperationException("O CBO não existe na base do CNES: " & codigoCbo)
                        End If
                    End Using

                    Using comandoVinculo As New FbCommand(
                        "SELECT COUNT(*) FROM LFCES021 WHERE IND_VINC = @vinculo", conexao, transacao)
                        comandoVinculo.Parameters.Add("@vinculo", FbDbType.VarChar, 6).Value = codigoVinculo
                        If Convert.ToInt32(comandoVinculo.ExecuteScalar()) = 0 Then
                            Throw New InvalidOperationException("O código de vínculo não existe na base do CNES: " & codigoVinculo)
                        End If
                    End Using

                    Using comandoCpf As New FbCommand(
                        "SELECT COUNT(*) FROM LFCES018 WHERE CPF_PROF = @cpf", conexao, transacao)
                        comandoCpf.Parameters.Add("@cpf", FbDbType.VarChar, 11).Value = cpf
                        If Convert.ToInt32(comandoCpf.ExecuteScalar()) > 0 Then
                            Throw New InvalidOperationException("O CPF já está cadastrado na base do CNES: " & cpf)
                        End If
                    End Using

                    Using comandoProfissional As New FbCommand(
                        "INSERT INTO LFCES018 " &
                        "(PROF_ID, CPF_PROF, NOME_PROF, DATA_NASC, COD_CNS, STATUS, STATUSMOV, DATA_ATU, USUARIO, ST_NMPROF_CADSUS) " &
                        "VALUES (@profId, @cpf, @nome, @dataNasc, @cns, '1', '1', CURRENT_DATE, @usuario, 'S')", conexao, transacao)
                        comandoProfissional.Parameters.Add("@profId", FbDbType.VarChar, 16).Value = profissionalId
                        comandoProfissional.Parameters.Add("@cpf", FbDbType.VarChar, 11).Value = cpf
                        comandoProfissional.Parameters.Add("@nome", FbDbType.VarChar, 60).Value = nome
                        comandoProfissional.Parameters.Add("@dataNasc", FbDbType.Date).Value =
                            If(dataNascimento.HasValue, CType(dataNascimento.Value.Date, Object), DBNull.Value)
                        comandoProfissional.Parameters.Add("@cns", FbDbType.VarChar, 60).Value = cns
                        comandoProfissional.Parameters.Add("@usuario", FbDbType.VarChar, 60).Value = usuario
                        comandoProfissional.ExecuteNonQuery()
                    End Using

                    Using comandoVinculo As New FbCommand(
                        "INSERT INTO LFCES021 " &
                        "(UNIDADE_ID, PROF_ID, COD_CBO, TP_SUS_NAO_SUS, IND_VINC, CGHORAOUTR, CG_HORAAMB, CGHORAHOSP, " &
                        "TP_PRECEPTOR, TP_RESIDENTE, STATUS, STATUSMOV, DATA_ATU, USUARIO) " &
                        "VALUES (@unidadeId, @profId, @cbo, @tipoSus, @vinculo, @cargaOutra, @cargaAmb, @cargaHosp, " &
                        "'2', '2', '1', '1', CURRENT_DATE, @usuario)", conexao, transacao)
                        comandoVinculo.Parameters.Add("@unidadeId", FbDbType.VarChar, 31).Value = unidadeId
                        comandoVinculo.Parameters.Add("@profId", FbDbType.VarChar, 16).Value = profissionalId
                        comandoVinculo.Parameters.Add("@cbo", FbDbType.VarChar, 6).Value = codigoCbo
                        comandoVinculo.Parameters.Add("@tipoSus", FbDbType.Char, 1).Value = tipoSusNaoSus
                        comandoVinculo.Parameters.Add("@vinculo", FbDbType.VarChar, 6).Value = codigoVinculo
                        comandoVinculo.Parameters.Add("@cargaOutra", FbDbType.Integer).Value = cargaHorariaOutra
                        comandoVinculo.Parameters.Add("@cargaAmb", FbDbType.Integer).Value = cargaHorariaAmbulatorial
                        comandoVinculo.Parameters.Add("@cargaHosp", FbDbType.Integer).Value = cargaHorariaHospitalar
                        comandoVinculo.Parameters.Add("@usuario", FbDbType.VarChar, 60).Value = usuario
                        comandoVinculo.ExecuteNonQuery()
                    End Using

                    transacao.Commit()
                    Return profissionalId
                Catch
                    Try
                        transacao.Rollback()
                    Catch
                    End Try
                    Throw
                End Try
            End Using
        End Using
    End Function

    Private Shared Function SomenteDigitos(valor As String) As String
        If valor Is Nothing Then Return String.Empty
        Return New String(valor.Where(Function(caractere) Char.IsDigit(caractere)).ToArray())
    End Function

    Private Shared Function NormalizarNome(valor As String) As String
        Dim nome As String = If(valor, String.Empty).Trim().ToUpperInvariant()
        If nome.Length > 60 Then
            Throw New ArgumentException("O nome do profissional não pode ultrapassar 60 caracteres.", NameOf(valor))
        End If
        Return nome
    End Function

    Private Shared Function NormalizarUsuario(valor As String) As String
        Dim usuario As String = If(valor, String.Empty).Trim().ToUpperInvariant()
        If usuario.Length = 0 Then usuario = Environment.UserName.ToUpperInvariant()
        If usuario.Length > 60 Then usuario = usuario.Substring(0, 60)
        Return usuario
    End Function

    Private Shared Function NormalizarCNPJ(valor As String) As String
        Dim cnpj As String = SomenteDigitos(valor)
        If cnpj.Length <> 0 AndAlso cnpj.Length <> 14 Then
            Throw New ArgumentException("O CNPJ do intermediador deve conter 14 dígitos.", NameOf(valor))
        End If
        Return cnpj
    End Function

    Private Shared Sub ValidarDadosProfissional(cpf As String,
                                                 nome As String,
                                                 Optional validarCpf As Boolean = True)
        If validarCpf AndAlso cpf.Length <> 11 Then
            Throw New ArgumentException("O CPF deve conter 11 dígitos.", NameOf(cpf))
        End If
        If String.IsNullOrWhiteSpace(nome) Then
            Throw New ArgumentException("O nome do profissional é obrigatório.", NameOf(nome))
        End If
    End Sub

    Private Shared Sub ValidarCPFInexistente(cpf As String,
                                              conexao As FbConnection,
                                              transacao As FbTransaction)
        Using comando As New FbCommand("SELECT COUNT(*) FROM LFCES018 WHERE CPF_PROF = @cpf", conexao, transacao)
            comando.Parameters.Add("@cpf", FbDbType.VarChar, 11).Value = cpf
            If Convert.ToInt32(comando.ExecuteScalar()) > 0 Then
                Throw New InvalidOperationException("O CPF já está cadastrado na base do CNES: " & cpf)
            End If
        End Using
    End Sub

    Private Shared Sub ValidarDadosVinculo(profissionalId As String,
                                            cnes As String,
                                            codigoCbo As String,
                                            codigoVinculo As String,
                                            cargaHorariaAmbulatorial As Integer,
                                            cargaHorariaOutra As Integer,
                                            cargaHorariaHospitalar As Integer,
                                            tipoSusNaoSus As String)
        If String.IsNullOrWhiteSpace(profissionalId) Then Throw New ArgumentException("O profissional selecionado é obrigatório.")
        If String.IsNullOrWhiteSpace(cnes) Then Throw New ArgumentException("Selecione o estabelecimento.")
        If codigoCbo.Length <> 6 Then Throw New ArgumentException("Selecione um CBO válido.")
        If codigoVinculo.Length <> 6 Then Throw New ArgumentException("Selecione um detalhamento de vínculo válido.")
        If tipoSusNaoSus <> "S" AndAlso tipoSusNaoSus <> "N" Then Throw New ArgumentException("Informe se o vínculo é SUS.")
        If cargaHorariaAmbulatorial < 0 OrElse cargaHorariaAmbulatorial > 168 OrElse
           cargaHorariaOutra < 0 OrElse cargaHorariaOutra > 168 OrElse
           cargaHorariaHospitalar < 0 OrElse cargaHorariaHospitalar > 168 Then
            Throw New ArgumentException("As cargas horárias devem estar entre 0 e 168 horas.")
        End If
    End Sub

    Private Shared Function ObterUnidadeId(cnes As String,
                                            conexao As FbConnection,
                                            transacao As FbTransaction) As String
        Using comando As New FbCommand(
            "SELECT UNIDADE_ID FROM LFCES004 WHERE CNES = @cnes " &
            "AND (STATUS = '1' OR (STATUS IS NULL AND STATUSMOV = '1'))", conexao, transacao)
            comando.Parameters.Add("@cnes", FbDbType.VarChar, 7).Value = cnes.Trim()
            Dim valor As Object = comando.ExecuteScalar()
            If valor Is Nothing OrElse valor Is DBNull.Value Then
                Throw New InvalidOperationException("O estabelecimento selecionado não está ativo no CNES: " & cnes)
            End If
            Return valor.ToString().Trim()
        End Using
    End Function

    Private Shared Sub ValidarCbo(codigoCbo As String,
                                  conexao As FbConnection,
                                  transacao As FbTransaction)
        Using comando As New FbCommand("SELECT COUNT(*) FROM NFCES026 WHERE COD_CBO = @cbo", conexao, transacao)
            comando.Parameters.Add("@cbo", FbDbType.VarChar, 6).Value = codigoCbo
            If Convert.ToInt32(comando.ExecuteScalar()) = 0 Then
                Throw New InvalidOperationException("O CBO não existe na base do CNES: " & codigoCbo)
            End If
        End Using
    End Sub

    Private Shared Sub ValidarCargaHorariaCbo(codigoCbo As String,
                                              cargaHorariaAmbulatorial As Integer,
                                              cargaHorariaOutra As Integer,
                                              cargaHorariaHospitalar As Integer,
                                              conexao As FbConnection,
                                              transacao As FbTransaction)
        Dim tipoCboSaude As String = String.Empty

        Using comando As New FbCommand(
            "SELECT TP_CBO_SAUDE FROM NFCES026 WHERE COD_CBO = @cbo", conexao, transacao)
            comando.Parameters.Add("@cbo", FbDbType.VarChar, 6).Value = codigoCbo
            Dim valor As Object = comando.ExecuteScalar()
            If valor IsNot Nothing AndAlso valor IsNot DBNull.Value Then
                tipoCboSaude = valor.ToString().Trim().ToUpperInvariant()
            End If
        End Using

        If tipoCboSaude = "N" AndAlso
           (cargaHorariaAmbulatorial > 0 OrElse cargaHorariaHospitalar > 0) Then
            Throw New InvalidOperationException(
                "O CBO " & codigoCbo & " não pertence à Assistência à Saúde." &
                Environment.NewLine &
                "Para este CBO, informe somente Carga Horária Outros;" &
                " as cargas Ambulatorial e Hospitalar devem ser zero.")
        End If
    End Sub

    Private Shared Sub ValidarVinculo(codigoVinculo As String,
                                      conexao As FbConnection,
                                      transacao As FbTransaction)
        Using comando As New FbCommand(
            "SELECT COUNT(*) FROM NFCES058 WHERE IND_VINC = @vinculo AND ST_HABILITADO = 'S'",
            conexao, transacao)
            comando.Parameters.Add("@vinculo", FbDbType.VarChar, 6).Value = codigoVinculo
            If Convert.ToInt32(comando.ExecuteScalar()) = 0 Then
                Throw New InvalidOperationException("O código de vínculo não existe ou está desabilitado: " & codigoVinculo)
            End If
        End Using
    End Sub

    Private Shared Sub ValidarVinculoDuplicado(unidadeId As String,
                                               profissionalId As String,
                                               codigoCbo As String,
                                               tipoSus As String,
                                               codigoVinculo As String,
                                               conexao As FbConnection,
                                               transacao As FbTransaction)
        Using comando As New FbCommand(
            "SELECT COUNT(*) FROM LFCES021 WHERE UNIDADE_ID = @unidadeId AND PROF_ID = @profId " &
            "AND COD_CBO = @cbo AND TP_SUS_NAO_SUS = @sus AND IND_VINC = @vinculo",
            conexao, transacao)
            comando.Parameters.Add("@unidadeId", FbDbType.VarChar, 31).Value = unidadeId
            comando.Parameters.Add("@profId", FbDbType.VarChar, 16).Value = profissionalId
            comando.Parameters.Add("@cbo", FbDbType.VarChar, 6).Value = codigoCbo
            comando.Parameters.Add("@sus", FbDbType.Char, 1).Value = tipoSus
            comando.Parameters.Add("@vinculo", FbDbType.VarChar, 6).Value = codigoVinculo
            If Convert.ToInt32(comando.ExecuteScalar()) > 0 Then
                Throw New InvalidOperationException("Esse vínculo já está cadastrado para o profissional.")
            End If
        End Using
    End Sub

    Private Shared Sub InserirVinculo(unidadeId As String,
                                      profissionalId As String,
                                      codigoCbo As String,
                                      tipoSus As String,
                                      codigoVinculo As String,
                                      cargaHorariaAmbulatorial As Integer,
                                      cargaHorariaOutra As Integer,
                                      cargaHorariaHospitalar As Integer,
                                      cnpjIntermediador As String,
                                      usuario As String,
                                      conexao As FbConnection,
                                      transacao As FbTransaction)
        Using comando As New FbCommand(
            "INSERT INTO LFCES021 " &
            "(UNIDADE_ID, PROF_ID, COD_CBO, TP_SUS_NAO_SUS, IND_VINC, NU_CNPJ_DET_VINC, CGHORAOUTR, CG_HORAAMB, CGHORAHOSP, " &
            "TP_PRECEPTOR, TP_RESIDENTE, STATUS, STATUSMOV, DATA_ATU, USUARIO) " &
            "VALUES (@unidadeId, @profId, @cbo, @tipoSus, @vinculo, @cnpj, @cargaOutra, @cargaAmb, @cargaHosp, " &
            "'2', '2', '1', '1', CURRENT_DATE, @usuario)", conexao, transacao)
            comando.Parameters.Add("@unidadeId", FbDbType.VarChar, 31).Value = unidadeId
            comando.Parameters.Add("@profId", FbDbType.VarChar, 16).Value = profissionalId
            comando.Parameters.Add("@cbo", FbDbType.VarChar, 6).Value = codigoCbo
            comando.Parameters.Add("@tipoSus", FbDbType.Char, 1).Value = tipoSus
            comando.Parameters.Add("@vinculo", FbDbType.VarChar, 6).Value = codigoVinculo
            comando.Parameters.Add("@cnpj", FbDbType.VarChar, 14).Value =
                If(cnpjIntermediador.Length = 0, CType(DBNull.Value, Object), cnpjIntermediador)
            comando.Parameters.Add("@cargaOutra", FbDbType.Integer).Value = cargaHorariaOutra
            comando.Parameters.Add("@cargaAmb", FbDbType.Integer).Value = cargaHorariaAmbulatorial
            comando.Parameters.Add("@cargaHosp", FbDbType.Integer).Value = cargaHorariaHospitalar
            comando.Parameters.Add("@usuario", FbDbType.VarChar, 60).Value = usuario
            comando.ExecuteNonQuery()
        End Using
    End Sub

    Private Shared Sub LimparValoresTexto(tabela As DataTable)
        For Each linha As DataRow In tabela.Rows
            For Each coluna As DataColumn In tabela.Columns
                If coluna.DataType Is GetType(String) AndAlso Not linha.IsNull(coluna) Then
                    linha(coluna) = linha(coluna).ToString().Trim()
                End If
            Next
        Next
    End Sub

End Class
