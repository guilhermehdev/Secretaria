Imports System.IO
Imports System.Net
Imports ServiceStack

Public Class FCNES
    Dim xml As New XML
    Dim m As New Main
    Dim sourceContainer As FlowLayoutPanel = Nothing ' Container de origem do Label
    Private toolTipTimer As New Timer()
    Private scrollTimer As New Timer()
    Private scrollDirection As Integer = 0 ' 1 para baixo, -1 para cima.
    Private idProf As Integer


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
            Dim labelItens() As String = label.Tag.Split("/"c)
            sourceContainer = DirectCast(label.Parent, FlowLayoutPanel)
            ' Mostra o ToolTip indicando a origem

            Dim nome As String = labelItens(0)
            Dim cbo As String = labelItens(1)


            m.SQLinsert("movimento", "unidade_out, equipe_out, profissional, cbo", "'" & sourceContainer.Tag & "','" & sourceContainer.Name & "','" & nome & "','" & cbo & "'")


            ToolTip1.Show($"{nome}{vbCrLf}{cbo}{vbCrLf}Saindo de Equipe: {sourceContainer.Name}", sourceContainer, 10, 10, 6000)
            ' Inicia o arrasto
            label.DoDragDrop(label, DragDropEffects.Move)

            addPanelAlteracoes()

        End If
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

        idProf = m.getDataset("SELECT MAX(id) FROM movimento").Rows(0).Item(0)

        m.SQLGeneric($"UPDATE movimento SET unidade_in='{destinationContainer.Tag}',equipe_in='{destinationContainer.Name}' WHERE id={idProf}")

        ToolTip1.Show($"{labelText}{vbCrLf}Movido para Equipe: {destinationContainer.Name}", destinationContainer, 10, 10, 6000)
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
            Dim scrollAmount As Integer = 50 ' Ajuste a velocidade da rolagem conforme necessário
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

            ' Cria um novo Panel
            Dim novoPanel As New Panel With {
            .Size = New Size(190, 120),  ' Tamanho do painel
            .BackColor = Color.White,
            .BorderStyle = BorderStyle.FixedSingle
            }

            ' Cria uma Label para o nome e cargo
            Dim lblProfissional As New Label With {
                .Text = $"{profissional}",
                .Location = New Point(5, 5),
                .AutoSize = False,
                .Width = 180,
                .Height = 15,
                .Font = New Font("Calibri", 10, FontStyle.Bold)
            }

            Dim lblCBO As New Label With {
                .Text = $"{cbo}",
                .Location = New Point(5, 20),
                .AutoSize = False,
                .Width = 180,
                .Height = 30,
                .Font = New Font("Calibri", 9, FontStyle.Italic),
                .ForeColor = Color.DarkSlateGray
            }

            Dim imgSetaVermelha As New PictureBox With {
                .Size = New Size(20, 20),
                .Location = New Point(5, 57),
                .Image = My.Resources.arrowdown,
                .SizeMode = PictureBoxSizeMode.StretchImage
            }
            imgSetaVermelha.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)

            Dim lblUnidadeOut As New Label With {
                .Text = unidade_out & vbCrLf & "Equipe:" & equipe_out,
                .Location = New Point(30, 55),
                .AutoSize = True,
                .Width = 180,
                .Font = New Font("Calibri", 8, FontStyle.Italic)
            }

            Dim lblLinhaHorizontal As New Label With {
                .Text = "------------------------------------------------------",
                .Location = New Point(5, 75),
                .AutoSize = True,
                .Font = New Font("Calibri", 8, FontStyle.Bold)
            }

            Dim imgSetaVerde As New PictureBox With {
                .Size = New Size(20, 20),
                .Location = New Point(5, 87),
                .Image = My.Resources.uparrow,
                .SizeMode = PictureBoxSizeMode.StretchImage
            }
            imgSetaVerde.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)

            Dim lblUnidadeIn As New Label With {
                .Text = unidade_in & vbCrLf & "Equipe:" & equipe_in,
                .Location = New Point(30, 85),
                .AutoSize = True,
                .Width = 180,
                .Font = New Font("Calibri", 8, FontStyle.Italic)
            }

            Dim btnDelete As New Button With {
                .Text = "X",
                .Name = "btnDelAlt",
                .Tag = id,
                .Location = New Point(160, 90),
                .Width = 25,
                .Height = 25,
                .BackColor = Color.IndianRed,
                .ForeColor = Color.White,
                .FlatStyle = FlatStyle.Flat,
                .Cursor = Cursors.Hand
            }

            AddHandler btnDelete.Click, AddressOf deleteAlteracao

            ' Adiciona os controles ao painel
            novoPanel.Controls.Add(lblProfissional)
            novoPanel.Controls.Add(lblCBO)
            novoPanel.Controls.Add(imgSetaVermelha)
            novoPanel.Controls.Add(lblUnidadeOut)
            novoPanel.Controls.Add(lblLinhaHorizontal)
            novoPanel.Controls.Add(imgSetaVerde)
            novoPanel.Controls.Add(lblUnidadeIn)
            novoPanel.Controls.Add(btnDelete)
            ' Adiciona o painel ao FlowLayoutPanel
            FlowLayoutPanelAleracoes.Controls.Add(novoPanel)

        Next

    End Sub
    Private Sub deleteAlteracao(sender As Object, e As EventArgs)
        Dim botao As Button = DirectCast(sender, Button)

        If m.msgQuestion("Excluir esta alteração?", "Atenção") Then
            If m.doQuery($"DELETE FROM movimento WHERE id ={botao.Tag}") Then
                addPanelAlteracoes()
            End If
        End If

    End Sub

    ' Evento Load para configurar os containers e labels
    Private Sub FCNES_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = FplanejCNES.Icon
        Dim estabelecimentos As List(Of Estabelecimento) = xml.equipesXML().ToList()

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
                        unidade.Width = 300
                        unidade.Height = 400
                        unidade.Margin = New Padding(10)
                        unidade.Padding = New Padding(0)
                        unidade.AutoScroll = True
                        unidade.FlowDirection = FlowDirection.TopDown
                        unidade.BorderStyle = BorderStyle.FixedSingle
                        unidade.WrapContents = False
                        unidade.HorizontalScroll.Visible = False
                        unidade.BackColor = Color.DarkSlateGray

                        ' Adiciona os eventos de drag-and-drop
                        AddHandler unidade.DragEnter, AddressOf Container_DragEnter
                        AddHandler unidade.DragDrop, AddressOf Container_DragDrop

                        Dim labelNome As New Label() With {
                            .AutoSize = False,
                            .Width = 280,
                            .BackColor = Color.DarkSlateGray,
                            .ForeColor = Color.Cyan,
                            .Font = New Font("Calibri", 12, FontStyle.Bold),
                            .Text = eq.NomeReferencia & " - " & eq.INE,
                            .TextAlign = ContentAlignment.MiddleCenter,
                            .Margin = New Padding(0, 0, 0, 10)
                        }

                        PanelContainer.Controls.Add(unidade)
                        unidade.Controls.Add(labelNome)

                        If eq.Profissionais IsNot Nothing Then
                            For Each prof In eq.Profissionais
                                Dim labelProf As New Label()

                                labelProf.AutoSize = False
                                labelProf.Width = 260
                                labelProf.Height = 45
                                labelProf.Font = New Font("Calibri", 10, FontStyle.Regular)
                                labelProf.Tag = prof.Nome & "/" & xml.getCBOXML(prof.CBOLOTACAO)
                                labelProf.Text = prof.Nome & vbCrLf & xml.getCBOXML(prof.CBOLOTACAO)
                                labelProf.Margin = New Padding(10, 5, 5, 10)
                                labelProf.Padding = New Padding(2, 2, 2, 2)
                                labelProf.BorderStyle = BorderStyle.None
                                labelProf.BackColor = Color.SteelBlue
                                labelProf.ForeColor = Color.White

                                ' Adiciona o evento de MouseDown para arrastar
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
            Next

        Else


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

    End Sub

    Private Sub toolTipTimer_Tick(sender As Object, e As EventArgs)
        toolTipTimer.Stop()
        ToolTip1.Hide(DirectCast(toolTipTimer.Tag, FlowLayoutPanel))
    End Sub

    Private Sub FCNES_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
        ToolTip1.Active = False
    End Sub

    Private Sub PanelContainer_MouseUp(sender As Object, e As MouseEventArgs) Handles PanelContainer.MouseUp
        scrollTimer.Stop()
    End Sub

    Private Sub UploadXMLEsusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadXMLEsusToolStripMenuItem.Click
        xml.copyXMLFileToServer()
    End Sub

    Private Sub FecharToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FecharToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub PlanejamentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlanejamentoToolStripMenuItem.Click
        FplanejCNES.Show()
    End Sub

End Class
