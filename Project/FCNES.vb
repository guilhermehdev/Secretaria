Imports System.IO
Imports System.Net
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Window
Imports Org.BouncyCastle.Cms
Imports ServiceStack

Public Class FCNES
    Dim xml As New XML
    Dim m As New Main
    Dim sourceContainer As FlowLayoutPanel = Nothing ' Container de origem do Label
    Private toolTipTimer As New Timer()
    Private scrollTimer As New Timer()
    Private scrollDirection As Integer = 0 ' 1 para baixo, -1 para cima.
    Private idProf As Integer
    Private ScrollBarVisivelAnterior As Boolean = False
    Dim contextMenuLabel As New ContextMenuStrip() ' Instância global do ContextMenuStrip
    Dim selectedLabel As Label = Nothing ' Label selecionado para movimentação


    Private Sub Container_DragEnter(sender As Object, e As DragEventArgs)
        If e.Data.GetDataPresent(GetType(Label)) Then
            Dim destinationContainer = DirectCast(sender, FlowLayoutPanel)

            e.Effect = DragDropEffects.Move ' Permite o drop
        Else
            e.Effect = DragDropEffects.None ' Não permite o drop
        End If
    End Sub

    Private Sub Control_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            Dim label As Label = DirectCast(sender, Label)
            'Dim labelText As Label ' Captura o texto do label
            ' Identifica o container de origem

            insertAlteracao(label)
            ' ToolTip1.Show($"{nome}{vbCrLf}{cbo}{vbCrLf}Saindo de Equipe: {sourceContainer.Name}", sourceContainer, 10, 10, 6000)
            ' Inicia o arrasto
            label.DoDragDrop(label, DragDropEffects.Move)

            addPanelAlteracoes()

        End If
    End Sub

    Private Sub insertAlteracao(label As Label)
        Dim labelItens() As String = label.Tag.Split("/"c)
        sourceContainer = DirectCast(label.Parent, FlowLayoutPanel)
        ' Mostra o ToolTip indicando a origem

        Dim nome As String = labelItens(0)
        Dim cbo As String = labelItens(1)
        Dim cpf As String = labelItens(2)

        m.SQLinsert("movimento", "unidade_out, equipe_out, profissional, cbo, cpf", "'" & sourceContainer.Tag & "','" & sourceContainer.Name & "','" & nome & "','" & cbo & "','" & cpf & "'")
    End Sub

    Private Sub updateAlteracao(destinationContainer As FlowLayoutPanel)
        idProf = m.getDataset("SELECT MAX(id) FROM movimento").Rows(0).Item(0)
        m.SQLGeneric($"UPDATE movimento SET unidade_in='{destinationContainer.Tag}',equipe_in='{destinationContainer.Name}' WHERE id={idProf}")
    End Sub

    Private Sub Container_DragDrop(sender As Object, e As DragEventArgs)
        Dim destinationContainer As FlowLayoutPanel = DirectCast(sender, FlowLayoutPanel)
        Dim control As Label = DirectCast(e.Data.GetData(GetType(Label)), Label)
        Dim labelText As String = control.Text

        ' Adiciona o controle ao container de destino
        destinationContainer.Controls.Add(control)
        destinationContainer.Controls.SetChildIndex(control, 1)
        ' Oculta o ToolTip após alguns segundos
        ToolTip1.Hide(destinationContainer)

        updateAlteracao(destinationContainer)

        'ToolTip1.Show($"{labelText}{vbCrLf}Movido para Equipe: {destinationContainer.Name}", destinationContainer, 10, 10, 6000)
        toolTipTimer.Tag = destinationContainer ' Armazena o container para ocultar depois
        toolTipTimer.Start()
        sourceContainer = Nothing

        scrollTimer.Stop() ' Para a rolagem ao soltar o label
    End Sub

    Private Sub Container_DragOver(sender As Object, e As DragEventArgs) Handles PanelContainer.DragOver
        e.Effect = DragDropEffects.Move
        Dim container As FlowLayoutPanel = DirectCast(sender, FlowLayoutPanel)
        Dim mousePosition As Point = PanelContainer.PointToClient(Cursor.Position)
        Dim scrollThreshold As Integer = 30 ' Ajuste a distância da borda conforme necessário

        If mousePosition.Y < scrollThreshold Then
            ' Rolar para cima
            scrollDirection = -1
            If Not scrollTimer.Enabled Then scrollTimer.Start()
        ElseIf mousePosition.Y > PanelContainer.ClientSize.Height - scrollThreshold Then
            ' Rolar para baixo
            scrollDirection = 1
            If Not scrollTimer.Enabled Then scrollTimer.Start()
        Else
            ' Parar a rolagem
            scrollTimer.Stop()
        End If
    End Sub

    Private Sub scrollTimer_Tick(sender As Object, e As EventArgs)
        ' Debug.WriteLine("scrollTimer_Tick disparado!")
        Try
            Dim scrollAmount As Integer = 10 ' Ajuste a velocidade da rolagem conforme necessário
            PanelContainer.VerticalScroll.Value += scrollDirection * scrollAmount

            ' Garante que o valor do scroll esteja dentro dos limites
            PanelContainer.VerticalScroll.Value = Math.Max(PanelContainer.VerticalScroll.Minimum, Math.Min(PanelContainer.VerticalScroll.Maximum, PanelContainer.VerticalScroll.Value))
        Catch ex As Exception

        End Try

    End Sub

    Private Sub addPanelAlteracoes()
        Dim alteraData = m.getDataset("SELECT * FROM movimento WHERE `status` = 0")

        FlowLayoutPanelAleracoes.Controls.Clear()

        For Each row In alteraData.Rows
            Dim id = row(0).ToString
            Dim unidade_out = row(1).ToString
            Dim equipe_out = row(2).ToString
            Dim unidade_in = row(3).ToString
            Dim equipe_in = row(4).ToString
            Dim profissional = row(5).ToString
            Dim cbo = row(6).ToString
            Dim cpf = row(7).ToString

            ' Cria um novo Panel
            Dim containerPanel As New Panel With {
            .Size = New Size(280, 150),  ' Tamanho do painel
            .BackColor = Color.White,
            .BorderStyle = BorderStyle.FixedSingle,
            .Tag = profissional,
            .Name = id
            }

            ' Criar uma forma de região com cantos arredondados
            Dim radius As Integer = 20  ' Raio dos cantos arredondados
            Dim rect As New Rectangle(0, 0, containerPanel.Width, containerPanel.Height)
            Dim path As New Drawing2D.GraphicsPath()

            ' Adicionar cantos arredondados em todos os cantos do Panel
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 100) ' Canto superior esquerdo
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 100) ' Canto superior direito
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 100) ' Canto inferior direito
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 100) ' Canto inferior esquerdo

            ' Fechar o caminho
            path.CloseFigure()

            ' Atribuir a região arredondada ao Panel
            containerPanel.Region = New Region(path)

            ' Cria uma Label para o nome e cargo
            Dim lblProfissional As New Label With {
                .Text = $"{profissional}",
                .Location = New Point(5, 5),
                .AutoSize = False,
                .Width = 246,
                .Height = 16,
                .Font = New Font("Calibri", 10, FontStyle.Bold),
                .ForeColor = Color.SteelBlue
            }

            Dim lblCBO As New Label With {
                .Text = $"{cbo}",
                .Location = New Point(5, 21),
                .AutoSize = False,
                .Width = 246,
                .Height = 30,
                .Font = New Font("Calibri", 9, FontStyle.Italic),
                .ForeColor = Color.DarkSlateGray
            }

            Dim imgSetaVermelha As New PictureBox With {
                .Size = New Size(22, 37),
                .Location = New Point(5, 55),
                .Image = My.Resources.arrowdown,
                .SizeMode = PictureBoxSizeMode.StretchImage
            }
            imgSetaVermelha.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)

            Dim lblUnidadeOut As New Label With {
                .Text = unidade_out & vbCrLf & "Equipe:" & equipe_out,
                .Location = New Point(27, 55),
                .AutoSize = False,
                .Width = 262,
                .Height = 40,
                .Font = New Font("Calibri", 8, FontStyle.Regular),
                .Name = "out-" & id,
                .Tag = equipe_out
            }

            Dim lblLinhaHorizontal As New Label With {
                .Text = "----------------------------------------------------------------------------------",
                .Location = New Point(5, 90),
                .AutoSize = True,
                .Font = New Font("Calibri", 8, FontStyle.Bold),
                .BackColor = Color.Transparent
            }

            Dim imgSetaVerde As New PictureBox With {
                .Size = New Size(22, 37),
                .Location = New Point(5, 101),
                .Image = My.Resources.uparrow,
                .SizeMode = PictureBoxSizeMode.StretchImage
            }
            imgSetaVerde.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)

            Dim lblUnidadeIn As New Label With {
                .Text = unidade_in & vbCrLf & "Equipe: " & equipe_in,
                .Location = New Point(27, 101),
                .AutoSize = False,
                .Width = 262,
                .Height = 40,
                .Font = New Font("Calibri", 8, FontStyle.Regular),
                .Name = "in-" & id,
                .Tag = equipe_in
            }

            Dim btnDelete As New Button With {
                .Text = "X",
                .Name = cpf,
                .Tag = id,
                .Location = New Point(250, 5),
                .Width = 25,
                .Height = 25,
                .BackColor = Color.IndianRed,
                .ForeColor = Color.White,
                .FlatStyle = FlatStyle.Flat,
                .Cursor = Cursors.Hand
            }

            AddHandler btnDelete.Click, AddressOf deleteAlteracao

            ' Adiciona os controles ao painel
            containerPanel.Controls.Add(lblProfissional)
            containerPanel.Controls.Add(lblCBO)
            containerPanel.Controls.Add(imgSetaVermelha)
            containerPanel.Controls.Add(lblUnidadeOut)
            containerPanel.Controls.Add(lblLinhaHorizontal)
            containerPanel.Controls.Add(imgSetaVerde)
            containerPanel.Controls.Add(lblUnidadeIn)
            containerPanel.Controls.Add(btnDelete)
            ' Adiciona o painel ao FlowLayoutPanel
            FlowLayoutPanelAleracoes.Controls.Add(containerPanel)

        Next

    End Sub

    ' Evento para mover o Label para o container selecionado
    Private Sub MoveLabelToContainer(sender As Object, e As EventArgs)
        If selectedLabel IsNot Nothing Then
            Dim menuItem = DirectCast(sender, ToolStripMenuItem)
            Dim destinationContainer = PanelContainer.Controls.Find(menuItem.Text, True).FirstOrDefault()
            AddHandler selectedLabel.Paint, AddressOf CustomLabel_Paint

            If TypeOf destinationContainer Is FlowLayoutPanel Then
                Dim container = DirectCast(destinationContainer, FlowLayoutPanel)

                ' Move o Label para o container selecionado
                insertAlteracao(selectedLabel)
                selectedLabel.Parent.Controls.Remove(selectedLabel)
                updateAlteracao(destinationContainer)
                container.Controls.Add(selectedLabel)
                addPanelAlteracoes()
            End If

            selectedLabel = Nothing ' Reseta a seleção
        End If
    End Sub
    Private Sub deleteAlteracao(sender As Object, e As EventArgs)
        Dim delButton As Button = DirectCast(sender, Button)
        Dim panelAlt = FlowLayoutPanelAleracoes.Controls.Find(delButton.Tag, True).FirstOrDefault()
        Dim eqOrigin = panelAlt.Controls.Find("in-" & delButton.Tag, True).FirstOrDefault()
        Dim eqSendTo = panelAlt.Controls.Find("out-" & delButton.Tag, True).FirstOrDefault()

        If m.msgQuestion("Excluir esta alteração?", "Atenção") Then

            If m.doQuery($"DELETE FROM movimento WHERE id ={delButton.Tag}") Then
                addPanelAlteracoes()
                moveLabelsFast(eqSendTo, eqOrigin, delButton)
            End If
        End If

    End Sub

    Private Sub CustomLabel_Paint(sender As Object, e As PaintEventArgs)
        Dim label As Label = DirectCast(sender, Label)
        Dim borderColor As Color = Color.Red ' Cor da borda
        Dim borderWidth As Integer = 3       ' Largura da borda

        ' Desenhar a borda ao redor do Label
        Using pen As New Pen(borderColor, borderWidth)
            e.Graphics.DrawRectangle(pen, 0, 0, label.Width - borderWidth, label.Height - borderWidth)
        End Using

    End Sub

    Private Sub moveLabelsFast(equipeDestino As Label, equipeOrigem As Label, cpfProfissional As Button)
        Dim panelSendTo = PanelContainer.Controls.Find(equipeDestino.Tag, True).FirstOrDefault()
        Dim panelOrigin = PanelContainer.Controls.Find(equipeOrigem.Tag, True).FirstOrDefault()

        Dim label As Label = DirectCast(panelOrigin.Controls.Find(cpfProfissional.Name, True).FirstOrDefault(), Label)

        panelOrigin.Controls.Remove(label)
        panelSendTo.Controls.Add(label)

    End Sub

    Private Sub FCNES_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = FplanejCNES.Icon
        Dim estabelecimentos As List(Of Estabelecimento) = xml.equipesXML().ToList()
        AddHandler contextMenuLabel.Opening, AddressOf contextMenuLabel_Opening

        contextMenuLabel.Items.Clear()
        xml.verificarAlteracao()

        Do While estabelecimentos.Count = 0 ' Verifica se a lista está vazia
            xml.copyXMLFileFromServer()
            estabelecimentos = xml.equipesXML().ToList() ' Supondo que xml.equipesXML() retorne um array
        Loop

        AddHandler PanelContainer.DragOver, AddressOf Container_DragOver

        If estabelecimentos.Count > 0 Then

            addPanelAlteracoes()

            For Each est In estabelecimentos
                If est.Equipes IsNot Nothing Then
                    For Each eq In est.Equipes
                        Dim unidade As New FlowLayoutPanel()
                        unidade.Name = eq.NomeReferencia
                        unidade.Tag = est.NOME
                        unidade.AllowDrop = True
                        unidade.Width = 280
                        unidade.Height = 400
                        unidade.Margin = New Padding(5)
                        unidade.Padding = New Padding(0)
                        unidade.AutoScroll = True
                        unidade.FlowDirection = FlowDirection.TopDown
                        unidade.BorderStyle = BorderStyle.FixedSingle
                        unidade.WrapContents = False
                        unidade.BackColor = Color.DarkSlateGray
                        unidade.VerticalScroll.Visible = False

                        Dim radiusUnidade As Integer = 20  ' Raio dos cantos arredondados
                        Dim rectUnidade As New Rectangle(0, 0, unidade.Width, unidade.Height)
                        Dim pathUnidade As New Drawing2D.GraphicsPath()

                        ' Adicionar canto superior esquerdo arredondado
                        pathUnidade.AddArc(rectUnidade.X, rectUnidade.Y, radiusUnidade, radiusUnidade, 180, 90) ' Canto superior esquerdo

                        ' Adicionar linha reta para o lado superior direito
                        pathUnidade.AddLine(rectUnidade.X + radiusUnidade, rectUnidade.Y, rectUnidade.Width, rectUnidade.Y)

                        ' Adicionar linha reta para o lado direito
                        pathUnidade.AddLine(rectUnidade.Width, rectUnidade.Y + radiusUnidade, rectUnidade.Width, rectUnidade.Height - radiusUnidade)

                        ' Adicionar canto inferior direito (quadrado, sem arredondamento)
                        pathUnidade.AddLine(rectUnidade.Width, rectUnidade.Height, rectUnidade.Width - radiusUnidade, rectUnidade.Height)

                        ' Adicionar canto inferior esquerdo arredondado
                        pathUnidade.AddArc(rectUnidade.X, rectUnidade.Height - radiusUnidade, radiusUnidade, radiusUnidade, 90, 90) ' Canto inferior esquerdo

                        ' Fechar o caminho
                        pathUnidade.CloseFigure()

                        ' Atribuir a região arredondada ao FlowLayoutPanel
                        unidade.Region = New Region(pathUnidade)

                        ' Adiciona os eventos de drag-and-drop
                        AddHandler unidade.DragEnter, AddressOf Container_DragEnter
                        AddHandler unidade.DragDrop, AddressOf Container_DragDrop

                        Dim labelNome As New Label() With {
                            .AutoSize = False,
                            .Width = 255,
                            .Height = 50,
                            .BackColor = Color.DarkSlateGray,
                            .ForeColor = Color.Cyan,
                            .Font = New Font("Calibri", 12, FontStyle.Bold),
                            .Text = eq.NomeReferencia & " - " & eq.INE,
                            .TextAlign = ContentAlignment.MiddleCenter,
                            .Margin = New Padding(0, 0, 0, 10)
                        }

                        unidade.Controls.Add(labelNome)

                        If eq.Profissionais IsNot Nothing Then
                            For Each prof In eq.Profissionais
                                Dim labelProf As New Label()

                                labelProf.Name = prof.CPF
                                labelProf.AutoSize = False
                                labelProf.MinimumSize = New Size(245, 60)
                                labelProf.Font = New Font("Calibri", 10, FontStyle.Regular)
                                labelProf.Tag = prof.Nome & "/" & xml.getCBOXML(prof.CBOLOTACAO) & "/" & prof.CPF
                                labelProf.Text = prof.Nome & vbCrLf & xml.getCBOXML(prof.CBOLOTACAO)
                                labelProf.Margin = New Padding(7, 5, 5, 6)
                                labelProf.Padding = New Padding(3, 3, 2, 2)
                                labelProf.BorderStyle = BorderStyle.None
                                labelProf.ForeColor = Color.White
                                labelProf.Cursor = Cursors.Hand
                                labelProf.ContextMenuStrip = contextMenuLabel

                                ' Adiciona o evento de MouseDown para arrastar
                                AddHandler labelProf.MouseDown, AddressOf Control_MouseDown
                                AddHandler labelProf.MouseUp, AddressOf Label_MouseUp

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
                                        labelProf.BackColor = Color.DimGray
                                End Select

                                Dim radius As Integer = 5  ' Ajuste o valor para deixar mais ou menos arredondado

                                ' Criar uma forma de região com cantos arredondados
                                Dim rect As New Rectangle(0, 0, labelProf.Width, labelProf.Height)
                                Dim path As New Drawing2D.GraphicsPath()

                                ' Adicionar cantos arredondados em todos os cantos do Label
                                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90) ' Canto superior esquerdo
                                path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90) ' Canto superior direito
                                path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90) ' Canto inferior direito
                                path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90) ' Canto inferior esquerdo

                                ' Fechar o caminho
                                path.CloseFigure()

                                ' Atribuir a região arredondada ao Label
                                labelProf.Region = New Region(path)

                                unidade.Controls.Add(labelProf)
                                PanelContainer.Controls.Add(unidade)
                            Next

                        End If
                    Next

                End If
            Next

        End If

    End Sub

    Private Sub contextMenuLabel_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim menu = DirectCast(sender, ContextMenuStrip)
        menu.Items.Clear()

        ' Adiciona o cabeçalho como um item não clicável
        Dim headerItem As New ToolStripMenuItem("Enviar para Equipe...") With {
        .Font = New Font("Segoe UI", 10, FontStyle.Bold),
        .ForeColor = Color.DarkBlue,
        .Enabled = False ' Impede que o cabeçalho seja clicado
    }
        menu.Items.Add(headerItem)

        ' Adiciona um separador após o cabeçalho
        menu.Items.Add(New ToolStripSeparator())

        ' Adiciona as opções dinamicamente com base nos containers disponíveis
        For Each container As FlowLayoutPanel In PanelContainer.Controls
            Dim item As New ToolStripMenuItem(container.Name)
            AddHandler item.Click, AddressOf MoveLabelToContainer
            menu.Items.Add(item)
        Next

        ' Obtém o Label associado ao menu
        Dim sourceControl = contextMenuLabel.SourceControl
        If TypeOf sourceControl Is Label Then
            selectedLabel = DirectCast(sourceControl, Label)
        Else
            ' Cancela a abertura se não houver Label selecionado
            e.Cancel = True
        End If

    End Sub

    Private Sub FCNES_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PanelContainer.Height = Me.Height
    End Sub

    Public Sub New()
        InitializeComponent()
        toolTipTimer.Interval = 2000 ' 2 segundos
        AddHandler toolTipTimer.Tick, AddressOf toolTipTimer_Tick
        scrollTimer.Interval = 10 ' Ajuste o intervalo conforme necessário
        AddHandler scrollTimer.Tick, AddressOf scrollTimer_Tick
        FlowLayoutPanelAleracoes.Focus()
    End Sub

    Private Sub toolTipTimer_Tick(sender As Object, e As EventArgs)
        toolTipTimer.Stop()
        ToolTip1.Hide(DirectCast(toolTipTimer.Tag, FlowLayoutPanel))
    End Sub

    Private Sub FCNES_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Fstart.Visible = True
        ToolTip1.Active = False
    End Sub

    Private Sub PanelContainer_MouseUp(sender As Object, e As MouseEventArgs) Handles PanelContainer.MouseUp
        scrollTimer.Stop()
    End Sub

    Private Sub UploadXMLEsusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadXMLEsusToolStripMenuItem.Click
        xml.copyXMLFileToServer()
    End Sub

    Private Sub FecharToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FecharToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub PlanejamentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlanejamentoToolStripMenuItem.Click
        FplanejCNES.Show()
    End Sub
    Private Sub Label_MouseUp(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim label = DirectCast(sender, Label)
            contextMenuLabel.Show(label, e.Location)
        End If
    End Sub

End Class
