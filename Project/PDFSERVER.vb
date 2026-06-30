Imports System.Net
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks

Public Class PDFSERVER

    Private Shared listener As HttpListener

    Public Shared Sub Iniciar()

        listener = New HttpListener()

        listener.Prefixes.Add("http://+:8080/")

        listener.Start()

        Task.Run(AddressOf AguardarRequisicoes)

    End Sub

    Private Shared Async Function AguardarRequisicoes() As Task

        While listener.IsListening

            Dim contexto As HttpListenerContext = Await listener.GetContextAsync()

            Await Task.Run(Async Function()
                               Await Processar(contexto)
                           End Function)

        End While

    End Function

    Private Shared Async Function Processar(ctx As HttpListenerContext) As Task

        Try

            Dim cpf As String = ctx.Request.QueryString("cpf")
            Dim sexo As String = ctx.Request.QueryString("sexo")

            If String.IsNullOrEmpty(cpf) Then

                ctx.Response.StatusCode = 400
                Dim erro = Encoding.UTF8.GetBytes("CPF não informado")

                ctx.Response.OutputStream.Write(erro, 0, erro.Length)
                ctx.Response.Close()

                Exit Function

            End If

            Dim resultado = Await CADSUS.GerarCartaoSus(cpf, sexo)

            If resultado.Sucesso = False Then

                ctx.Response.StatusCode = 500
                Dim erro = Encoding.UTF8.GetBytes(resultado.Mensagem)
                ctx.Response.OutputStream.Write(erro, 0, erro.Length)

                Exit Function

            End If

            Select Case ctx.Request.Url.AbsolutePath.ToLower()

                Case "/sus"
                    Dim pdfBytes() As Byte = IO.File.ReadAllBytes(resultado.Arquivo)
                    ctx.Response.AddHeader("Content-Disposition", $"inline; filename=""CartaoSUS_{cpf}.pdf""")
                    ctx.Response.ContentType = "application/pdf"
                    ctx.Response.ContentLength64 = pdfBytes.Length
                    ctx.Response.OutputStream.Write(pdfBytes, 0, pdfBytes.Length)

                Case Else
                    ctx.Response.StatusCode = 404
                    Return

            End Select

        Catch ex As Exception

            ctx.Response.StatusCode = 500
            Dim erro = Encoding.UTF8.GetBytes(ex.Message)
            ctx.Response.OutputStream.Write(erro, 0, erro.Length)

        Finally
            ctx.Response.Close()
        End Try

    End Function

End Class