Imports System.Net
Imports System.IO
Imports System.Web.Script.Serialization

Public Class CEP
    Public Property cep As String
    Public Property logradouro As String
    Public Property complemento As String
    Public Property bairro As String
    Public Property localidade As String
    Public Property uf As String
    Public Property ibge As String
    Public Property gia As String
    Public Property ddd As String
    Public Property siafi As String

    Public Function BuscarEnderecoPorCEP(cep As String) As CEP
        Try
            ' Remove caracteres não numéricos
            cep = New String(cep.Where(AddressOf Char.IsDigit).ToArray())

            Dim url As String = $"https://viacep.com.br/ws/{cep}/json/"
            Dim request As WebRequest = WebRequest.Create(url)
            request.Method = "GET"

            Using response As WebResponse = request.GetResponse()
                Using reader As New StreamReader(response.GetResponseStream())
                    Dim json As String = reader.ReadToEnd()

                    Dim serializer As New JavaScriptSerializer()
                    Dim endereco As CEP = serializer.Deserialize(Of CEP)(json)

                    ' Verifica se retornou erro
                    If json.Contains("""erro"": true") Then
                        Return Nothing
                    End If

                    Return endereco
                End Using
            End Using

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Class

