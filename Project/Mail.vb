Imports System.Net.Mail
Imports System.IO
Imports System.Net.Mime

Public Class Mail


    ' </summary>

    ' <param name="from">Endereco do Remetente</param>

    ' <param name="recepient">Destinatario</param>

    ' <param name="bcc">recipiente Bcc</param>

    ' <param name="cc">recipiente Cc</param>

    ' <param name="subject">Assunto do email</param>

    '<param name="body">Corpo da mensagem de email</param>



    Public Function enviaMensagemEmail(ByVal de As String, ByVal para As String, ByVal assunto As String, ByVal msg As String, Optional ByVal AttachmentFiles As ArrayList = Nothing, Optional ByVal bcc As String = Nothing, Optional ByVal cc As String = Nothing)
        Dim mMailMessage As New MailMessage()
        ' Dim Attachment As System.Net.Mail.Attachment
        Dim i, iCnt As Integer
        Dim strPath As String = Application.StartupPath

        ' Define o endereço do remetente
        mMailMessage.From = New MailAddress(de)

        ' Define o destinario da mensagem
        mMailMessage.To.Add(New MailAddress(para))

        ' Verifica se o valor para bcc é null ou uma string vazia
        If Not bcc Is Nothing And bcc <> String.Empty Then

            ' Define o endereço bcc
            mMailMessage.Bcc.Add(New MailAddress(bcc))

        End If

        ' verifica se o valor para cc é nulo ou uma string vazia
        If Not cc Is Nothing And cc <> String.Empty Then

            ' Define o endereço cc
            mMailMessage.CC.Add(New MailAddress(cc))

        End If

        If Not AttachmentFiles Is Nothing Then
            iCnt = AttachmentFiles.Count - 1
            For i = 0 To iCnt
                If FileExists(AttachmentFiles(i)) Then _
                 mMailMessage.Attachments.Add(New Attachment(AttachmentFiles(i)))
            Next

        End If

        ' Define o assunto
        mMailMessage.Subject = assunto

        ' Define o corpo da mensagem
        ' mMailMessage.Body = "<html><body><span style='font-family:calibri,serif;'>" & msg & "</span><img src=""cid:signature""/></body></html>"

        ' Define o formato do email como HTML
        mMailMessage.IsBodyHtml = True

        ' Dim signature As Attachment = New Attachment("D:\Desktop\assinatura.JPG")
        ' signature.ContentId = "signature"

        ' mMailMessage.Attachments.Add(attachImage)

        ' Define a prioridade da mensagem como normal
        mMailMessage.Priority = MailPriority.Normal


        Dim EMailBody As String = "<span style='font-family:calibri,serif;'>" & msg & "</span><br /><br /><img src=""cid:InlineImageID"" />"

        ' Now we'll create two email views: HTML and plain text
        ' First, create HTML view
        Dim HTMLEmail As AlternateView = AlternateView.CreateAlternateViewFromString( _
          EMailBody, Nothing, "text/html")
        ' Create plain text view for those visitors who prefer text only messages
        Dim PlainTextEmail As AlternateView = AlternateView.CreateAlternateViewFromString( _
          EMailBody, Nothing, "text/plain")

        ' We'll need LinkedResource class to place an image to HTML email
        Dim MyImage As LinkedResource = New LinkedResource(strPath & "\assinatura.JPG", "image/jpeg")
        ' Set ContentId property. Value of ContentId property must be the same as
        ' the src attribute of image tag in email body. In this case it is
        ' <img src="cid:InlineImageID" />
        MyImage.ContentId = "InlineImageID"

        ' Add this linked resource to HTML view
        HTMLEmail.LinkedResources.Add(MyImage)

        ' Add plain text and HTML views to an email
        mMailMessage.AlternateViews.Add(HTMLEmail)
        mMailMessage.AlternateViews.Add(PlainTextEmail)


        ' Cria uma instância de SmtpClient - Nota - Define qual o host a ser usado para envio

        ' de mensagens, no local de smtp.server.com use o nome do SEU servidor

        Dim mSmtpClient As New SmtpClient()
        mSmtpClient.Host = "smtp.gmail.com"
        mSmtpClient.Credentials = New System.Net.NetworkCredential("ouvidoria.saude.pmp@gmail.com", "fuprlqmakbajrowk")
        mSmtpClient.Port = 587
        mSmtpClient.EnableSsl = True
        ' Envia o email

        Try
            mSmtpClient.Send(mMailMessage)
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try

    End Function

    Private Function FileExists(ByVal FileFullPath As String) _
     As Boolean
        If Trim(FileFullPath) = "" Then Return False

        Dim f As New IO.FileInfo(FileFullPath)
        Return f.Exists

    End Function

End Class