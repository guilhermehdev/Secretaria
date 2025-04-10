Imports System.IO
Imports System.Net
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Window
Imports iTextSharp.text.html.simpleparser
Imports Org.BouncyCastle.Cms
Imports ServiceStack

Public Class FCNES
    Private toolTipTimer As New Timer()
    Private scrollTimer As New Timer()
    Private scrollDirection As Integer = 0 ' 1 para baixo, -1 para cima.
    Private idProf As Integer
    Private ScrollBarVisivelAnterior As Boolean = False
    Private sourceContainer As FlowLayoutPanel

    Private borderColorIndex As Integer = 0
    Private gradientColors As Color() = {Color.Cyan, Color.Magenta, Color.Yellow, Color.Lime}
    Private gradientOffset As Single = 0.0F


    Dim xml As New XML
    Dim m As New Main
    Dim contextMenuLabel As New ContextMenuStrip() ' Instância global do ContextMenuStrip
    Dim selectedLabel As Label = Nothing ' Label selecionado para movimentação
    Dim equipesCpfList As New List(Of (equipe_in As String, equipe_out As String, cpf As String))()
    Dim movingLabel As Label = Nothing


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
            movingLabel = DirectCast(sender, Label)

            'sourceContainer = DirectCast(label.Parent, FlowLayoutPanel)
            movingLabel.DoDragDrop(movingLabel, DragDropEffects.Move)
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

    Private Function getlabelTAG(label As Label)
        Dim labelItens() As String = label.Tag.Split("/"c)
        Dim nome As String = labelItens(0)
        Dim cbo As String = labelItens(1)
        Dim cpf As String = labelItens(2)
        Dim border As String = labelItens(3)

        Return labelItens

    End Function


    Private Sub Container_DragDrop(sender As Object, e As DragEventArgs)
        Dim labelProf As Label = DirectCast(e.Data.GetData(GetType(Label)), Label)
        Dim destinationContainer As FlowLayoutPanel = DirectCast(sender, FlowLayoutPanel)
        Dim originContainer = DirectCast(labelProf.Parent, FlowLayoutPanel)
        Dim labelText As String = labelProf.Text
        Dim containerAlteracoes = FlowLayoutPanelAleracoes
        Dim labelitens = getlabelTAG(labelProf)
        Dim nome As String = labelitens(0)
        Dim cbo As String = labelitens(1)
        Dim cpf As String = labelitens(2)
        Dim border As String = "Bordered"

        For Each control As Panel In containerAlteracoes.Controls

            Try
                Dim btn = control.Controls.Find(cpf, True).FirstOrDefault()

                If IsNumeric(btn.Tag) Then
                    m.msgAlert("Profissional já possui uma alteração em andamento!")
                    Exit Sub
                End If


            Catch ex As Exception

            End Try

        Next

        ' MsgBox(originContainer.Name & " - " & destinationContainer.Name)

        If originContainer.Name <> destinationContainer.Name Then

            insertAlteracao(movingLabel)
            ' Adiciona o controle ao container de destino
            destinationContainer.Controls.Add(labelProf)

            destinationContainer.Controls.SetChildIndex(labelProf, 1)
            ' Oculta o ToolTip após alguns segundos
            ToolTip1.Hide(destinationContainer)

            updateAlteracao(destinationContainer)

            sourceContainer = Nothing

            scrollTimer.Stop() ' Para a rolagem ao soltar o label

            labelProf.Invalidate() ' Força o redesenho para aplicar a borda
            AddHandler labelProf.Paint, AddressOf Label_Paint

            labelProf.Tag = nome & "/" & cbo & "/" & cpf & "/" & border

            addPanelAlteracoes()

        End If

    End Sub
    Private Sub InsertLabelContextMenu(sender As Object, e As EventArgs)
        If selectedLabel IsNot Nothing Then
            Dim menuItem = DirectCast(sender, ToolStripMenuItem)
            Dim destinationContainer = PanelContainer.Controls.Find(menuItem.Text, True).FirstOrDefault()
            Dim labelTag = getlabelTAG(selectedLabel)
            Dim border As String = "Borderless"
            Dim containerOrigin = selectedLabel.Parent
            Dim containerAlteracoes = FlowLayoutPanelAleracoes

            For Each control As Panel In containerAlteracoes.Controls

                Try
                    Dim btn = control.Controls.Find(labelTag(2), True).FirstOrDefault()
                    If IsNumeric(btn.Tag) Then
                        m.msgAlert("Profissional já possui uma alteração em andamento!")
                        Exit Sub
                    End If

                Catch ex As Exception

                End Try

            Next

            If containerOrigin.Name <> destinationContainer.Name Then

                If TypeOf destinationContainer Is FlowLayoutPanel Then
                    Dim container = DirectCast(destinationContainer, FlowLayoutPanel)

                    insertAlteracao(selectedLabel)
                    containerOrigin.Controls.Remove(selectedLabel)

                    updateAlteracao(destinationContainer)
                    container.Controls.Add(selectedLabel)
                    container.Controls.SetChildIndex(selectedLabel, 1)
                    container.PerformLayout()

                    addPanelAlteracoes()
                    border = "Bordered"

                    selectedLabel.Tag = labelTag(0) & "/" & labelTag(1) & "/" & labelTag(2) & "/" & border
                    AddHandler selectedLabel.Paint, AddressOf Label_Paint
                    selectedLabel = Nothing
                End If

            End If

        End If

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

    Public Sub addPanelAlteracoes()
        Dim alteraData = m.getDataset("SELECT * FROM movimento WHERE `status` = 0 ORDER BY id DESC")

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

            equipesCpfList.Add((equipe_in, equipe_out, cpf))

            ' Cria um novo Panel
            Dim containerPanel As New Panel With {
            .Size = New Size(280, 150),  ' Tamanho do painel
            .BackColor = Color.White,
            .BorderStyle = BorderStyle.FixedSingle,
            .Tag = cpf,
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
                .ForeColor = Color.SteelBlue,
                .Tag = cpf
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
                .Text = "Unidade: " & unidade_out & vbCrLf & "Equipe: " & equipe_out,
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
                .Text = "Unidade: " & unidade_in & vbCrLf & "Equipe: " & equipe_in,
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

            containerPanel.Controls.Add(lblProfissional)
            containerPanel.Controls.Add(lblCBO)
            containerPanel.Controls.Add(imgSetaVermelha)
            containerPanel.Controls.Add(lblUnidadeOut)
            containerPanel.Controls.Add(lblLinhaHorizontal)
            containerPanel.Controls.Add(imgSetaVerde)
            containerPanel.Controls.Add(lblUnidadeIn)
            containerPanel.Controls.Add(btnDelete)

            If equipe_in <> equipe_out Then

                Try

                    FlowLayoutPanelAleracoes.Controls.Add(containerPanel)
                    Dim label As Label

                    If equipe_in <> "DESLIGAMENTO DA AB" And equipe_in <> "DESLIGAMENTO DO CNES" Then
                        moveLabelsFast(lblUnidadeIn, lblUnidadeOut, btnDelete)

                        Dim flowPanelDestino As FlowLayoutPanel = PanelContainer.Controls.Find(equipe_in, True).FirstOrDefault()
                        label = flowPanelDestino.Controls.Find(cpf, True).FirstOrDefault()

                    Else

                        Dim flowPanelOrigin As FlowLayoutPanel = PanelContainer.Controls.Find(equipe_out, True).FirstOrDefault()
                        label = flowPanelOrigin.Controls.Find(cpf, True).FirstOrDefault()

                    End If

                    label.Invalidate()
                    Dim labelItens = getlabelTAG(label)
                    label.Tag = labelItens(0) & "/" & labelItens(1) & "/" & labelItens(2) & "/" & "Bordered"

                    AddHandler label.Paint, AddressOf Label_Paint

                Catch ex As Exception

                End Try


            End If
        Next

    End Sub
    Private Sub moveLabelsFast(equipeDestino As Label, equipeOrigem As Label, cpfProfissional As Button)
        Try

            Dim panelSendTo = PanelContainer.Controls.Find(equipeDestino.Tag, True).FirstOrDefault()
            Dim panelOrigin = PanelContainer.Controls.Find(equipeOrigem.Tag, True).FirstOrDefault()

            Dim label As Label = DirectCast(panelOrigin.Controls.Find(cpfProfissional.Name, True).FirstOrDefault(), Label)


            panelOrigin.Controls.Remove(label)
            panelSendTo.Controls.Add(label)
            panelSendTo.Controls.SetChildIndex(label, 1)

        Catch ex As Exception
            'Return m.msgError(ex.Message)
        End Try

    End Sub

    Private Sub deleteAlteracao(sender As Object, e As EventArgs)
        Dim delButton As Button = DirectCast(sender, Button)
        Dim panelAlt = FlowLayoutPanelAleracoes.Controls.Find(delButton.Tag, True).FirstOrDefault()
        Dim eqOrigin = panelAlt.Controls.Find("in-" & delButton.Tag, True).FirstOrDefault()
        Dim eqSendTo = panelAlt.Controls.Find("out-" & delButton.Tag, True).FirstOrDefault()
        Dim labelProf As Label = DirectCast(PanelContainer.Controls.Find(delButton.Name, True).FirstOrDefault(), Label)

        If m.msgQuestion("Excluir esta alteração?", "Atenção") Then

            m.doQuery($"DELETE FROM servidor_cnes WHERE id_movimento ={delButton.Tag}")

            If m.doQuery($"DELETE FROM movimento WHERE id ={delButton.Tag}") Then
                addPanelAlteracoes()
                moveLabelsFast(eqSendTo, eqOrigin, delButton)
                ClearLabelBorders(labelProf)
            End If
        End If

    End Sub

    Private Sub ClearLabelBorders(labelProf As Label)
        Try
            ' Garante que o PanelContainer e seus controles existem
            If PanelContainer IsNot Nothing AndAlso PanelContainer.Controls.Count > 0 Then
                ' Itera sobre todos os FlowLayoutPanels no PanelContainer
                For Each container As Control In PanelContainer.Controls
                    If TypeOf container Is FlowLayoutPanel Then
                        ' Itera sobre os Labels dentro de cada FlowLayoutPanel
                        For Each ctrl As Control In container.Controls
                            If TypeOf ctrl Is Label Then
                                Dim labelItens() As String = labelProf.Tag.Split("/"c)
                                If labelItens.Length >= 3 Then
                                    Dim nome As String = labelItens(0)
                                    Dim cbo As String = labelItens(1)
                                    Dim cpf As String = labelItens(2)

                                    ' MsgBox(labelItens(3))

                                    ' Redefine o estado do Label
                                    If labelItens.Length > 3 AndAlso labelItens(3) = "Bordered" Then
                                        labelProf.Invalidate() ' Força o redesenho para remover a borda
                                        labelProf.Tag = $"{nome}/{cbo}/{cpf}/Borderless" ' Remove a marcação
                                    End If
                                End If

                            End If
                        Next
                    End If
                Next
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub FCNES_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = FplanejCNES.Icon
        Dim estabelecimentos As List(Of Estabelecimento) = xml.equipesXML().ToList()
        AddHandler contextMenuLabel.Opening, AddressOf contextMenuLabel_Opening
        TimerBordas.Start()
        contextMenuLabel.Items.Clear()
        xml.verificarAlteracao()

        Do While estabelecimentos.Count = 0
            xml.copyXMLFileFromServer()
            estabelecimentos = xml.equipesXML().ToList()
        Loop

        AddHandler PanelContainer.DragOver, AddressOf Container_DragOver

        If estabelecimentos.Count > 0 Then

            For Each est In estabelecimentos
                If est.Equipes IsNot Nothing Then
                    For Each eq In est.Equipes
                        Dim unidade As New FlowLayoutPanel()
                        unidade.Name = eq.NomeReferencia
                        unidade.Tag = est.NOME
                        unidade.AllowDrop = True
                        unidade.Width = 210
                        unidade.Height = 500
                        unidade.Margin = New Padding(5)
                        unidade.Padding = New Padding(0)
                        unidade.AutoScroll = True
                        unidade.FlowDirection = FlowDirection.TopDown
                        unidade.BorderStyle = BorderStyle.FixedSingle
                        unidade.WrapContents = False
                        unidade.BackColor = Color.FromArgb(34, 34, 34)
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

                        Dim labelNomeEquipe As New Label() With {
                            .AutoSize = False,
                            .Width = 190,
                            .Height = 50,
                            .BackColor = Color.FromArgb(34, 34, 34),
                            .ForeColor = Color.Cyan,
                            .Font = New Font("Calibri", 10, FontStyle.Bold),
                            .Text = eq.NomeReferencia & " - " & eq.INE,
                            .TextAlign = ContentAlignment.MiddleCenter,
                            .Margin = New Padding(0, 0, 0, 10),
                            .Padding = New Padding(5, 0, 0, 0),
                            .Name = "title"
                        }

                        unidade.Controls.Add(labelNomeEquipe)

                        Dim labelProfSize As Size
                        If eq.Profissionais.Count > 4 Then
                            labelProfSize = New Size(175, 45)
                        Else
                            labelProfSize = New Size(193, 45)
                        End If

                        If eq.Profissionais IsNot Nothing Then
                            For Each prof In eq.Profissionais
                                Dim labelProf As New Label()

                                labelProf.Name = prof.CPF
                                labelProf.AutoSize = False
                                labelProf.MinimumSize = New Size(175, 45)
                                labelProf.Font = New Font("Calibri", 8, FontStyle.Regular)
                                labelProf.Tag = prof.Nome & "/" & xml.getCBOXML(prof.CBOLOTACAO) & "/" & prof.CPF & "/" & "Borderless"
                                labelProf.Text = prof.Nome & vbCrLf & xml.getCBOXML(prof.CBOLOTACAO)
                                labelProf.Margin = New Padding(7, 5, 5, 6)
                                labelProf.Padding = New Padding(3, 3, 2, 0)
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
                                        labelProf.BackColor = Color.DarkOrange
                                    Case "515105"
                                        labelProf.BackColor = Color.SteelBlue
                                    Case Else
                                        labelProf.BackColor = Color.DimGray
                                End Select

                                Dim radius As Integer = 8  ' Ajuste o valor para deixar mais ou menos arredondado

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

        addPanelAlteracoes()

    End Sub

    Private Sub Label_Paint(sender As Object, e As PaintEventArgs)
        Dim label As Label = DirectCast(sender, Label)
        Dim borderColor As Color = Color.Transparent ' Sem borda por padrão
        Dim borderWidth As Integer = 4

        ' Verifica se o Label está marcado para ter uma borda
        If label.Tag IsNot Nothing Then
            Dim labelItens() As String = label.Tag.ToString().Split("/"c)
            If labelItens.Length >= 4 AndAlso labelItens(3) = "Bordered" Then
                borderColor = Color.FromArgb(255, 0, 0) ' Define a cor da borda
            End If
        End If

        ' Desenha a borda somente se a cor não for transparente
        If borderColor <> Color.Transparent Then
            Using pen As New Pen(borderColor, borderWidth)
                e.Graphics.DrawRectangle(pen, 0, 0, label.Width, label.Height)
            End Using
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

        ' Opção de desligamento
        Dim DesligamentoAB As New ToolStripMenuItem("Desligar da AB") With {
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .ForeColor = Color.DarkRed
        }
        Dim DesligamentoCNES As New ToolStripMenuItem("Desligar do CNES") With {
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .ForeColor = Color.DarkRed
        }
        AddHandler DesligamentoAB.Click, AddressOf DesligarAB
        menu.Items.Add(DesligamentoAB)

        AddHandler DesligamentoCNES.Click, AddressOf DesligarCNES
        menu.Items.Add(DesligamentoCNES)

        ' Adiciona as opções dinamicamente com base nos containers disponíveis
        For Each container As FlowLayoutPanel In PanelContainer.Controls
            Dim item As New ToolStripMenuItem(container.Name)
            AddHandler item.Click, AddressOf InsertLabelContextMenu
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

    ' Função para remover o Label do container
    Private Sub DesligarAB(sender As Object, e As EventArgs)
        If selectedLabel IsNot Nothing AndAlso selectedLabel.Parent IsNot Nothing Then
            insertAlteracao(selectedLabel)
            'selectedLabel.Parent.Controls.Remove(selectedLabel)
            idProf = m.getDataset("SELECT MAX(id) FROM movimento").Rows(0).Item(0)
            Dim destino As String = InputBox("Para qual unidade o servidor foi destinado?", "")
            m.SQLGeneric($"UPDATE movimento SET unidade_in='{destino.ToUpper}',equipe_in='DESLIGAMENTO DA AB' WHERE id={idProf}")
            addPanelAlteracoes()

            selectedLabel.Invalidate()
            Dim labelItens = getlabelTAG(selectedLabel)
            selectedLabel.Tag = labelItens(0) & "/" & labelItens(1) & "/" & labelItens(2) & "/" & "Bordered"
            AddHandler selectedLabel.Paint, AddressOf Label_Paint

        End If
    End Sub

    Private Sub DesligarCNES(sender As Object, e As EventArgs)
        If selectedLabel IsNot Nothing AndAlso selectedLabel.Parent IsNot Nothing Then
            insertAlteracao(selectedLabel)
            idProf = m.getDataset("SELECT MAX(id) FROM movimento").Rows(0).Item(0)
            m.SQLGeneric($"UPDATE movimento SET unidade_in='DESLIGAMENTO DO CNES',equipe_in='DESLIGAMENTO DO CNES' WHERE id={idProf}")
            addPanelAlteracoes()

            selectedLabel.Invalidate()
            Dim labelItens = getlabelTAG(selectedLabel)
            selectedLabel.Tag = labelItens(0) & "/" & labelItens(1) & "/" & labelItens(2) & "/" & "Bordered"
            AddHandler selectedLabel.Paint, AddressOf Label_Paint
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
    Private Sub Label_MouseUp(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim label = DirectCast(sender, Label)
            contextMenuLabel.Show(label, e.Location)
        End If
    End Sub
    Private Sub FCNES_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btNovo_Click(sender As Object, e As EventArgs) Handles btNovo.Click
        FormCadastroServidorCNES.Show()
    End Sub
    Private Sub RelatóriosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RelatóriosToolStripMenuItem.Click
        FplanejCNES.Show()
    End Sub

End Class
