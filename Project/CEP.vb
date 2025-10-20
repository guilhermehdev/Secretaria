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

    Public Function searchCEPviacep(cep As String) As CEP
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
    Public Function getAddress(Optional cep As String = "", Optional logradouro As String = "", Optional bairro As String = "")
        Dim query As String = "SELECT * FROM ceps_peruibe WHERE 1=1 "
        Dim conn As New FormAMEmain
        Dim address As DataTable

        Try
            If cep <> "" Then
                query &= $"AND cep = '{cep}'"
            ElseIf logradouro <> "" Then
                query &= $"AND logradouro LIKE '%{logradouro}%'"
            ElseIf bairro <> "" Then
                query &= $"AND bairro LIKE '%{bairro}%'"
            Else
                ' nenhum filtro — evita query perigosa
                Throw New Exception("É necessário informar ao menos um parâmetro (cep, logradouro ou bairro).")
            End If

            address = conn.getDataset(query)
            Return address

        Catch ex As Exception
            Debug.WriteLine("Erro em getAddress: " & ex.Message)
            Return Nothing
        End Try

    End Function

End Class

