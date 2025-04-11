<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FCNES
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FCNES))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PanelContainer = New System.Windows.Forms.FlowLayoutPanel()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.PlanejamentoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RelatóriosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CadastrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PendentesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlteraçõesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploadXMLEsusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FecharToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btNovo = New System.Windows.Forms.Button()
        Me.FlowLayoutPanelAleracoes = New System.Windows.Forms.FlowLayoutPanel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TimerBordas = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(332, 37)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(922, 547)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.PanelContainer)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(914, 521)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Equipes"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'PanelContainer
        '
        Me.PanelContainer.AllowDrop = True
        Me.PanelContainer.AutoScroll = True
        Me.PanelContainer.AutoSize = True
        Me.PanelContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PanelContainer.BackColor = System.Drawing.Color.Beige
        Me.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelContainer.Location = New System.Drawing.Point(3, 3)
        Me.PanelContainer.Name = "PanelContainer"
        Me.PanelContainer.Padding = New System.Windows.Forms.Padding(3)
        Me.PanelContainer.Size = New System.Drawing.Size(908, 515)
        Me.PanelContainer.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(914, 521)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Unidades"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PlanejamentoToolStripMenuItem, Me.CadastrosToolStripMenuItem, Me.ConfigToolStripMenuItem, Me.FecharToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.Size = New System.Drawing.Size(1254, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'PlanejamentoToolStripMenuItem
        '
        Me.PlanejamentoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RelatóriosToolStripMenuItem})
        Me.PlanejamentoToolStripMenuItem.Name = "PlanejamentoToolStripMenuItem"
        Me.PlanejamentoToolStripMenuItem.Size = New System.Drawing.Size(92, 20)
        Me.PlanejamentoToolStripMenuItem.Text = "Planejamento"
        '
        'RelatóriosToolStripMenuItem
        '
        Me.RelatóriosToolStripMenuItem.Name = "RelatóriosToolStripMenuItem"
        Me.RelatóriosToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.RelatóriosToolStripMenuItem.Text = "Relatórios"
        '
        'CadastrosToolStripMenuItem
        '
        Me.CadastrosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PendentesToolStripMenuItem, Me.AlteraçõesToolStripMenuItem})
        Me.CadastrosToolStripMenuItem.Name = "CadastrosToolStripMenuItem"
        Me.CadastrosToolStripMenuItem.Size = New System.Drawing.Size(81, 20)
        Me.CadastrosToolStripMenuItem.Text = "Movimento"
        '
        'PendentesToolStripMenuItem
        '
        Me.PendentesToolStripMenuItem.Name = "PendentesToolStripMenuItem"
        Me.PendentesToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.PendentesToolStripMenuItem.Text = "Cadastro"
        '
        'AlteraçõesToolStripMenuItem
        '
        Me.AlteraçõesToolStripMenuItem.Name = "AlteraçõesToolStripMenuItem"
        Me.AlteraçõesToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AlteraçõesToolStripMenuItem.Text = "Alterações"
        '
        'ConfigToolStripMenuItem
        '
        Me.ConfigToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UploadXMLEsusToolStripMenuItem})
        Me.ConfigToolStripMenuItem.Name = "ConfigToolStripMenuItem"
        Me.ConfigToolStripMenuItem.Size = New System.Drawing.Size(96, 20)
        Me.ConfigToolStripMenuItem.Text = "Configurações"
        '
        'UploadXMLEsusToolStripMenuItem
        '
        Me.UploadXMLEsusToolStripMenuItem.Name = "UploadXMLEsusToolStripMenuItem"
        Me.UploadXMLEsusToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.UploadXMLEsusToolStripMenuItem.Text = "Upload XML Esus"
        '
        'FecharToolStripMenuItem
        '
        Me.FecharToolStripMenuItem.Name = "FecharToolStripMenuItem"
        Me.FecharToolStripMenuItem.Size = New System.Drawing.Size(38, 20)
        Me.FecharToolStripMenuItem.Text = "Sair"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btNovo)
        Me.GroupBox1.Controls.Add(Me.FlowLayoutPanelAleracoes)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 37)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(318, 547)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Alterações pendentes"
        '
        'btNovo
        '
        Me.btNovo.BackColor = System.Drawing.Color.White
        Me.btNovo.BackgroundImage = CType(resources.GetObject("btNovo.BackgroundImage"), System.Drawing.Image)
        Me.btNovo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btNovo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btNovo.FlatAppearance.BorderSize = 0
        Me.btNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btNovo.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btNovo.Location = New System.Drawing.Point(281, 19)
        Me.btNovo.Name = "btNovo"
        Me.btNovo.Size = New System.Drawing.Size(31, 24)
        Me.btNovo.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.btNovo, "Inserir novo cadastro")
        Me.btNovo.UseVisualStyleBackColor = False
        '
        'FlowLayoutPanelAleracoes
        '
        Me.FlowLayoutPanelAleracoes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanelAleracoes.AutoScroll = True
        Me.FlowLayoutPanelAleracoes.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FlowLayoutPanelAleracoes.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanelAleracoes.Location = New System.Drawing.Point(6, 49)
        Me.FlowLayoutPanelAleracoes.Name = "FlowLayoutPanelAleracoes"
        Me.FlowLayoutPanelAleracoes.Padding = New System.Windows.Forms.Padding(2, 4, 0, 0)
        Me.FlowLayoutPanelAleracoes.Size = New System.Drawing.Size(306, 491)
        Me.FlowLayoutPanelAleracoes.TabIndex = 0
        Me.FlowLayoutPanelAleracoes.WrapContents = False
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 8000
        Me.ToolTip1.BackColor = System.Drawing.Color.IndianRed
        Me.ToolTip1.ForeColor = System.Drawing.Color.White
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.OwnerDraw = True
        Me.ToolTip1.ReshowDelay = 100
        Me.ToolTip1.ShowAlways = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.DefaultExt = "xml"
        Me.OpenFileDialog1.FileName = "EQUIPES.xml"
        '
        'TimerBordas
        '
        Me.TimerBordas.Enabled = True
        Me.TimerBordas.Interval = 200
        '
        'FCNES
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1254, 596)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FCNES"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CNES"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents PlanejamentoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PanelContainer As FlowLayoutPanel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents ConfigToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UploadXMLEsusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents FecharToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FlowLayoutPanelAleracoes As FlowLayoutPanel
    Friend WithEvents TimerBordas As Timer
    Friend WithEvents btNovo As Button
    Friend WithEvents RelatóriosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CadastrosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PendentesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AlteraçõesToolStripMenuItem As ToolStripMenuItem
End Class
