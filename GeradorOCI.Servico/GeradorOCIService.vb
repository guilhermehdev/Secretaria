Imports System.IO
Imports System.Timers
Imports System.Threading

Imports System.Configuration

Imports System.Collections.Generic
Imports System.Text
Imports System.Web.Script.Serialization

Public Class GeradorOCIService

    Private _timer As System.Timers.Timer
    Private _pastaLog As String
    Private _processando As Integer = 0
    Private _gerador As GeradorOCI.Core.OCI
    Private _pastaEntrada As String
    Private _pastaProcessando As String
    Private _pastaConcluidos As String
    Private _pastaErros As String
    Private ReadOnly _json As New JavaScriptSerializer()

    Protected Overrides Sub OnStart(ByVal args() As String)

        _pastaLog = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "Logs"
        )

        Directory.CreateDirectory(_pastaLog)

        Dim configuracaoBanco = ConfigurationManager.ConnectionStrings("AME")

        If configuracaoBanco Is Nothing OrElse String.IsNullOrWhiteSpace(configuracaoBanco.ConnectionString) Then
            Throw New ConfigurationErrorsException(
                "A conexão 'AME' não foi encontrada no arquivo de configuração do serviço."
            )
        End If

        _gerador = New GeradorOCI.Core.OCI(configuracaoBanco.ConnectionString)

        _pastaEntrada = ObterPastaFila("FilaOCIEntrada", "FilaOCI\Entrada")
        _pastaProcessando = ObterPastaFila("FilaOCIProcessando", "FilaOCI\Processando")
        _pastaConcluidos = ObterPastaFila("FilaOCIConcluidos", "FilaOCI\Concluidos")
        _pastaErros = ObterPastaFila("FilaOCIErros", "FilaOCI\Erros")

        Directory.CreateDirectory(_pastaEntrada)
        Directory.CreateDirectory(_pastaProcessando)
        Directory.CreateDirectory(_pastaConcluidos)
        Directory.CreateDirectory(_pastaErros)

        RegistrarLog("Serviço GeradorOCI iniciado. Entrada: " & _pastaEntrada)

        _timer = New System.Timers.Timer(5000)
        _timer.AutoReset = True

        AddHandler _timer.Elapsed, AddressOf VerificarFila

        _timer.Start()

    End Sub

    Protected Overrides Sub OnStop()

        If _timer IsNot Nothing Then
            _timer.Stop()
            _timer.Dispose()
            _timer = Nothing
        End If

        RegistrarLog("Serviço GeradorOCI finalizado.")

    End Sub

    Private Sub VerificarFila(sender As Object, e As ElapsedEventArgs)

        ' Evita duas gerações simultâneas
        If Interlocked.Exchange(_processando, 1) = 1 Then
            Return
        End If

        Try

            For Each arquivo In Directory.GetFiles(_pastaEntrada, "*.json")
                ProcessarSolicitacao(arquivo)
            Next

        Catch ex As Exception

            RegistrarLog("Erro: " & ex.Message)

        Finally

            Interlocked.Exchange(_processando, 0)

        End Try

    End Sub

    Private Sub ProcessarSolicitacao(caminhoSolicitacao As String)

        Dim nomeArquivo = Path.GetFileName(caminhoSolicitacao)
        Dim caminhoProcessando = Path.Combine(_pastaProcessando, nomeArquivo)

        Try
            File.Move(caminhoSolicitacao, caminhoProcessando)
        Catch ex As IOException
            ' Outro ciclo já pode ter assumido este arquivo.
            Return
        End Try

        Try
            Dim solicitacao = _json.Deserialize(Of SolicitacaoLote)(
                File.ReadAllText(caminhoProcessando, Encoding.UTF8)
            )

            If solicitacao Is Nothing OrElse solicitacao.IdsOCI Is Nothing OrElse solicitacao.IdsOCI.Count = 0 Then
                Throw New InvalidOperationException("A solicitação não contém IDs de OCI.")
            End If

            Dim idLote = If(String.IsNullOrWhiteSpace(solicitacao.Id),
                            Path.GetFileNameWithoutExtension(nomeArquivo),
                            SanitizarNome(solicitacao.Id))

            Dim nomePdf = SanitizarNome(If(solicitacao.PdfNome, idLote & ".pdf"))
            If Not nomePdf.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase) Then
                nomePdf &= ".pdf"
            End If

            Dim caminhoPdf = Path.Combine(_pastaConcluidos, idLote & "_" & nomePdf)
            Dim mensagem As String = Nothing

            If Not _gerador.GerarPdfLoteOCI(solicitacao.IdsOCI, caminhoPdf, mensagem) Then
                Throw New InvalidOperationException(If(mensagem, "Não foi possível gerar o PDF."))
            End If

            GravarResultado(_pastaConcluidos, idLote, "concluido", caminhoPdf, mensagem, solicitacao.FilaId, solicitacao.NumApac)
            File.Delete(caminhoProcessando)
            RegistrarLog("Lote " & idLote & " concluído: " & caminhoPdf)

        Catch ex As Exception
            Dim idErro = Path.GetFileNameWithoutExtension(nomeArquivo)
            GravarResultado(_pastaErros, idErro, "erro", Nothing, ex.Message, Nothing, Nothing)
            RegistrarLog("Erro no lote " & idErro & ": " & ex.Message)

            Try
                File.Delete(caminhoProcessando)
            Catch
            End Try
        End Try

    End Sub

    Private Sub GravarResultado(pasta As String, idLote As String, status As String, caminhoPdf As String, mensagem As String, filaId As Nullable(Of Integer), numApac As String)
        Dim resultado As New Dictionary(Of String, Object) From {
            {"id", idLote},
            {"status", status},
            {"arquivo", caminhoPdf},
            {"mensagem", mensagem},
            {"data", DateTime.Now.ToString("o")}
        }

        If filaId.HasValue Then
            resultado("filaId") = filaId.Value
        End If

        If Not String.IsNullOrWhiteSpace(numApac) Then
            resultado("numApac") = numApac
        End If

        File.WriteAllText(
            Path.Combine(pasta, idLote & ".json"),
            _json.Serialize(resultado),
            Encoding.UTF8
        )
    End Sub

    Private Function ObterPastaFila(chave As String, padrao As String) As String
        Dim valor = ConfigurationManager.AppSettings(chave)

        If String.IsNullOrWhiteSpace(valor) Then
            valor = padrao
        End If

        If Path.IsPathRooted(valor) Then
            Return valor
        End If

        Return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, valor)
    End Function

    Private Function SanitizarNome(valor As String) As String
        Dim nome = Path.GetFileName(valor)

        If String.IsNullOrWhiteSpace(nome) Then
            Throw New InvalidOperationException("Nome de arquivo inválido na solicitação.")
        End If

        For Each caractere In Path.GetInvalidFileNameChars()
            nome = nome.Replace(caractere, "_"c)
        Next

        Return nome
    End Function

    Private Class SolicitacaoLote
        Public Property Id As String
        Public Property IdsOCI As List(Of Integer)
        Public Property PdfNome As String
        Public Property FilaId As Nullable(Of Integer)
        Public Property NumApac As String
    End Class

    Private Sub RegistrarLog(mensagem As String)

        Try

            Dim arquivoLog = Path.Combine(
                _pastaLog,
                "gerador-oci-" & DateTime.Now.ToString("yyyy-MM-dd") & ".log"
            )

            File.AppendAllText(
                arquivoLog,
                DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") &
                " - " & mensagem & Environment.NewLine
            )

        Catch
            ' Evita que erro de log derrube o serviço
        End Try

    End Sub

End Class
