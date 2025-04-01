Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Drive.v3
Imports Google.Apis.Services
Imports Google.Apis.Upload
Imports System.IO

Public Class GoogleDriveUploader

    Public Shared Function UploadArquivo(ByVal caminhoArquivo As String, ByVal credenciaisPath As String) As String
        Try
            Dim credential As GoogleCredential
            Using stream = New FileStream(credenciaisPath, FileMode.Open, FileAccess.Read)
                credential = GoogleCredential.FromStream(stream).CreateScoped(DriveService.ScopeConstants.DriveFile)
            End Using

            Dim service = New DriveService(New BaseClientService.Initializer() With {
                .HttpClientInitializer = credential,
                .ApplicationName = "MysqlBackupSecretaria"
            })

            Dim fileMetadata = New Google.Apis.Drive.v3.Data.File() With {
                .Name = Path.GetFileName(caminhoArquivo)
            }

            Using fileStream = New FileStream(caminhoArquivo, FileMode.Open)
                Dim request = service.Files.Create(fileMetadata, fileStream, "application/octet-stream")
                request.Fields = "id"
                request.Upload()
                Return request.ResponseBody.Id
            End Using
        Catch ex As Exception
            MessageBox.Show("Erro ao fazer upload para o Google Drive: " & ex.Message)
            Return String.Empty
        End Try
    End Function

End Class
