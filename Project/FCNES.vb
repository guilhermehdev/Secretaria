Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Imports iTextSharp.text.pdf

Public Class FCNES
    Dim pdfPath As String = Application.StartupPath & "/PDF/equipes.pdf"
    Dim xml As New XML
    Private draggedImage As Bitmap ' Armazena a imagem do controle sendo arrastado
    Private dragOffset As Point ' Armazena o offset do cursor em relação ao controle
    Private isDragging As Boolean ' Indica se um arrasto está em progresso

    Private Sub PlanejamentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlanejamentoToolStripMenuItem.Click
        FplanejCNES.Show()
    End Sub

    Private Sub Container_DragEnter(sender As Object, e As DragEventArgs)
        If e.Data.GetDataPresent(GetType(Label)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub


    Private Sub Container_DragDrop(sender As Object, e As DragEventArgs)
        Dim container As FlowLayoutPanel = DirectCast(sender, FlowLayoutPanel)
        Dim control As Control = DirectCast(e.Data.GetData(GetType(Label)), Control)

        ' Adiciona o controle ao container de destino
        container.Controls.Add(control)

        ' Limpa os dados do arrasto
        draggedImage = Nothing
        isDragging = False
        container.Refresh()
    End Sub

    Private Sub Container_DragLeave(sender As Object, e As EventArgs)
        Dim container As Control = DirectCast(sender, Control)
        container.Refresh() ' Limpa qualquer imagem residual
    End Sub

    Private Sub Control_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            Dim control As Control = DirectCast(sender, Control)

            ' Captura a imagem do controle
            draggedImage = New Bitmap(control.Width, control.Height)
            control.DrawToBitmap(draggedImage, New Rectangle(0, 0, draggedImage.Width, draggedImage.Height))

            ' Calcula o offset do cursor em relação ao controle
            dragOffset = e.Location

            ' Indica que o arrasto começou
            isDragging = True

            ' Inicia o arrasto
            control.DoDragDrop(control, DragDropEffects.Move)
        End If
    End Sub


    Private Sub Container_DragOver(sender As Object, e As DragEventArgs)
        If isDragging AndAlso draggedImage IsNot Nothing Then
            Dim container As Control = DirectCast(sender, Control)
            Dim graphics As Graphics = container.CreateGraphics()

            ' Limpa o fundo antes de desenhar a nova posição
            container.Refresh()

            ' Calcula a posição para desenhar a imagem
            Dim cursorPosition As Point = container.PointToClient(New Point(e.X, e.Y))
            Dim drawPosition As New Point(cursorPosition.X - dragOffset.X, cursorPosition.Y - dragOffset.Y)

            ' Desenha a imagem
            graphics.DrawImage(draggedImage, drawPosition)
        End If

        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub FCNES_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim estabelecimentos = xml.equipesXML()

        For Each est In estabelecimentos

            If est.Equipes IsNot Nothing Then

                For Each eq In est.Equipes
                    ' Console.WriteLine($"  Equipe: {eq.NomeReferencia}")
                    Dim unidade As New FlowLayoutPanel()
                    Dim labelNome As New Label()
                    Dim panelNome As New Panel()

                    unidade.Name = est.NOME
                    unidade.AllowDrop = True
                    unidade.Width = 320
                    unidade.Height = 400
                    unidade.Margin = New Padding(20)
                    unidade.Padding = New Padding(0)
                    unidade.AutoScroll = True
                    unidade.FlowDirection = FlowDirection.TopDown
                    unidade.BorderStyle = BorderStyle.FixedSingle
                    unidade.WrapContents = False
                    unidade.HorizontalScroll.Visible = False
                    AddHandler unidade.DragEnter, AddressOf Container_DragEnter
                    AddHandler unidade.DragDrop, AddressOf Container_DragDrop
                    AddHandler unidade.DragOver, AddressOf Container_DragOver
                    AddHandler unidade.DragLeave, AddressOf Container_DragLeave

                    labelNome.AutoSize = False
                    labelNome.Width = 300
                    labelNome.BackColor = Color.White
                    labelNome.ForeColor = Color.Black
                    labelNome.Font = New Font("Calibri", 12, FontStyle.Bold)
                    labelNome.Text = eq.NomeReferencia
                    labelNome.TextAlign = ContentAlignment.MiddleCenter
                    labelNome.Anchor = AnchorStyles.Top
                    labelNome.Margin = New Padding(0, 0, 0, 10)

                    PanelContainer.Controls.Add(unidade)
                    unidade.Controls.Add(labelNome)

                    If eq.Profissionais IsNot Nothing Then

                        For Each prof In eq.Profissionais
                            Dim labelProf As New Label()

                            labelProf.AutoSize = False
                            labelProf.Width = 280
                            labelProf.Height = 40
                            labelProf.Font = New Font("Calibri", 10, FontStyle.Regular)
                            labelProf.Text = prof.Nome & vbCrLf & xml.getCBOXML(prof.CBOLOTACAO)
                            labelProf.Margin = New Padding(10, 5, 5, 10)
                            labelProf.Padding = New Padding(2, 2, 2, 2)
                            labelProf.BorderStyle = BorderStyle.None
                            labelProf.ForeColor = Color.White

                            AddHandler labelProf.MouseDown, AddressOf Control_MouseDown

                            Select Case prof.CBOLOTACAO
                                Case "225142"
                                    labelProf.BackColor = Color.ForestGreen
                                Case "223565"
                                    labelProf.BackColor = Color.IndianRed
                                Case "322245"
                                    labelProf.BackColor = Color.Orange
                                Case "515105"
                                    labelProf.BackColor = Color.SteelBlue
                                Case Else
                                    labelProf.BackColor = Color.DarkSlateGray
                            End Select


                            unidade.Controls.Add(labelProf)
                        Next
                    End If
                Next
            End If

            ' Console.WriteLine(New String("-"c, 50))
        Next

    End Sub

    Private Sub FCNES_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PanelContainer.Height = Me.Height
    End Sub

    Private Sub FCNES_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

End Class