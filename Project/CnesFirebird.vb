Imports System.Data
Imports FirebirdSql.Data.FirebirdClient

Public NotInheritable Class CnesFirebird

    Private Sub New()
    End Sub

    Private Shared Function ObterStringConexao() As String
        Dim servidor As String = If(String.IsNullOrWhiteSpace(My.Settings.cnesServer), "10.32.157.22", My.Settings.cnesServer)
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

        Return "Servidor: " & If(String.IsNullOrWhiteSpace(My.Settings.cnesServer), "10.32.157.22", My.Settings.cnesServer) &
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
            "WHERE p.STATUS = '1' " &
            "AND v.STATUS = '1' "

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
