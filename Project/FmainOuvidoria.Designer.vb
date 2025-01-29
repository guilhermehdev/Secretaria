<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FmainOuvidoria
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FmainOuvidoria))
        Me.Tbackup = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.CadastroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsuáriosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RelatóriosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrazosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpçõesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BancoDeDadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlanoDeFundoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SairToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.niMinimizar = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.btNovoProtocolo = New System.Windows.Forms.Button()
        Me.dgListProtocolos = New System.Windows.Forms.DataGridView()
        Me.statusBar = New System.Windows.Forms.StatusStrip()
        Me.statusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbBuscaOrigem = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbBuscaStatus = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbBuscaDestinatario = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbBuscaProtocolo = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btRefresh = New System.Windows.Forms.Button()
        Me.pbBackground = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgListProtocolos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.statusBar.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pbBackground, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Tbackup
        '
        Me.Tbackup.Interval = 1000
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CadastroToolStripMenuItem, Me.RelatóriosToolStripMenuItem, Me.OpçõesToolStripMenuItem, Me.SairToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(981, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'CadastroToolStripMenuItem
        '
        Me.CadastroToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UsuáriosToolStripMenuItem})
        Me.CadastroToolStripMenuItem.Name = "CadastroToolStripMenuItem"
        Me.CadastroToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.CadastroToolStripMenuItem.Text = "Cadastro"
        '
        'UsuáriosToolStripMenuItem
        '
        Me.UsuáriosToolStripMenuItem.Name = "UsuáriosToolStripMenuItem"
        Me.UsuáriosToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.UsuáriosToolStripMenuItem.Text = "Usuários"
        '
        'RelatóriosToolStripMenuItem
        '
        Me.RelatóriosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrazosToolStripMenuItem, Me.LogsToolStripMenuItem})
        Me.RelatóriosToolStripMenuItem.Name = "RelatóriosToolStripMenuItem"
        Me.RelatóriosToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
        Me.RelatóriosToolStripMenuItem.Text = "Relatórios"
        '
        'PrazosToolStripMenuItem
        '
        Me.PrazosToolStripMenuItem.Name = "PrazosToolStripMenuItem"
        Me.PrazosToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PrazosToolStripMenuItem.Text = "Prazos"
        '
        'LogsToolStripMenuItem
        '
        Me.LogsToolStripMenuItem.Name = "LogsToolStripMenuItem"
        Me.LogsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.LogsToolStripMenuItem.Text = "Logs"
        '
        'OpçõesToolStripMenuItem
        '
        Me.OpçõesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BancoDeDadosToolStripMenuItem, Me.PlanoDeFundoToolStripMenuItem})
        Me.OpçõesToolStripMenuItem.Name = "OpçõesToolStripMenuItem"
        Me.OpçõesToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.OpçõesToolStripMenuItem.Text = "Opções"
        '
        'BancoDeDadosToolStripMenuItem
        '
        Me.BancoDeDadosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BackupToolStripMenuItem})
        Me.BancoDeDadosToolStripMenuItem.Name = "BancoDeDadosToolStripMenuItem"
        Me.BancoDeDadosToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.BancoDeDadosToolStripMenuItem.Text = "Banco de Dados"
        '
        'BackupToolStripMenuItem
        '
        Me.BackupToolStripMenuItem.Name = "BackupToolStripMenuItem"
        Me.BackupToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.BackupToolStripMenuItem.Text = "Backup"
        '
        'PlanoDeFundoToolStripMenuItem
        '
        Me.PlanoDeFundoToolStripMenuItem.Name = "PlanoDeFundoToolStripMenuItem"
        Me.PlanoDeFundoToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.PlanoDeFundoToolStripMenuItem.Text = "Plano de Fundo"
        '
        'SairToolStripMenuItem
        '
        Me.SairToolStripMenuItem.Name = "SairToolStripMenuItem"
        Me.SairToolStripMenuItem.Size = New System.Drawing.Size(38, 20)
        Me.SairToolStripMenuItem.Text = "Sair"
        '
        'niMinimizar
        '
        Me.niMinimizar.Visible = True
        '
        'btNovoProtocolo
        '
        Me.btNovoProtocolo.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.btNovoProtocolo.FlatAppearance.BorderSize = 0
        Me.btNovoProtocolo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btNovoProtocolo.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btNovoProtocolo.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btNovoProtocolo.Location = New System.Drawing.Point(12, 38)
        Me.btNovoProtocolo.Name = "btNovoProtocolo"
        Me.btNovoProtocolo.Size = New System.Drawing.Size(143, 44)
        Me.btNovoProtocolo.TabIndex = 1
        Me.btNovoProtocolo.Text = "Novo Protocolo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btNovoProtocolo.UseVisualStyleBackColor = False
        '
        'dgListProtocolos
        '
        Me.dgListProtocolos.AllowUserToAddRows = False
        Me.dgListProtocolos.AllowUserToDeleteRows = False
        Me.dgListProtocolos.AllowUserToResizeRows = False
        Me.dgListProtocolos.BackgroundColor = System.Drawing.Color.White
        Me.dgListProtocolos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgListProtocolos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.dgListProtocolos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgListProtocolos.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgListProtocolos.Location = New System.Drawing.Point(12, 95)
        Me.dgListProtocolos.MultiSelect = False
        Me.dgListProtocolos.Name = "dgListProtocolos"
        Me.dgListProtocolos.ReadOnly = True
        Me.dgListProtocolos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgListProtocolos.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgListProtocolos.RowHeadersWidth = 4
        Me.dgListProtocolos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgListProtocolos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgListProtocolos.Size = New System.Drawing.Size(957, 485)
        Me.dgListProtocolos.TabIndex = 24
        Me.dgListProtocolos.TabStop = False
        '
        'statusBar
        '
        Me.statusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusLabel})
        Me.statusBar.Location = New System.Drawing.Point(0, 594)
        Me.statusBar.Name = "statusBar"
        Me.statusBar.Size = New System.Drawing.Size(981, 22)
        Me.statusBar.TabIndex = 25
        Me.statusBar.Text = "teste"
        '
        'statusLabel
        '
        Me.statusLabel.Name = "statusLabel"
        Me.statusLabel.Size = New System.Drawing.Size(52, 17)
        Me.statusLabel.Text = "registros"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btRefresh)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbBuscaOrigem)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cbBuscaStatus)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbBuscaDestinatario)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.tbBuscaProtocolo)
        Me.GroupBox1.Location = New System.Drawing.Point(161, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(808, 62)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Buscar por"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(459, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Canal de origem"
        '
        'cbBuscaOrigem
        '
        Me.cbBuscaOrigem.FormattingEnabled = True
        Me.cbBuscaOrigem.Items.AddRange(New Object() {"eOuve", "OuvidorSUS"})
        Me.cbBuscaOrigem.Location = New System.Drawing.Point(462, 34)
        Me.cbBuscaOrigem.Name = "cbBuscaOrigem"
        Me.cbBuscaOrigem.Size = New System.Drawing.Size(92, 21)
        Me.cbBuscaOrigem.TabIndex = 20
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(337, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Status"
        '
        'cbBuscaStatus
        '
        Me.cbBuscaStatus.FormattingEnabled = True
        Me.cbBuscaStatus.Items.AddRange(New Object() {"Todos", "Em andamento", "Concluido", "Duplicado", "Cancelado", "Reencaminhado", "Elogio", "Vencido"})
        Me.cbBuscaStatus.Location = New System.Drawing.Point(340, 34)
        Me.cbBuscaStatus.Name = "cbBuscaStatus"
        Me.cbBuscaStatus.Size = New System.Drawing.Size(116, 21)
        Me.cbBuscaStatus.TabIndex = 18
        Me.cbBuscaStatus.Tag = "Destinatário"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(128, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Destino"
        '
        'cbBuscaDestinatario
        '
        Me.cbBuscaDestinatario.FormattingEnabled = True
        Me.cbBuscaDestinatario.Location = New System.Drawing.Point(131, 34)
        Me.cbBuscaDestinatario.Name = "cbBuscaDestinatario"
        Me.cbBuscaDestinatario.Size = New System.Drawing.Size(203, 21)
        Me.cbBuscaDestinatario.TabIndex = 6
        Me.cbBuscaDestinatario.Tag = "Destinatário"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Nº Protocolo"
        '
        'tbBuscaProtocolo
        '
        Me.tbBuscaProtocolo.BackColor = System.Drawing.SystemColors.ControlText
        Me.tbBuscaProtocolo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbBuscaProtocolo.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.tbBuscaProtocolo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBuscaProtocolo.ForeColor = System.Drawing.Color.Orange
        Me.tbBuscaProtocolo.Location = New System.Drawing.Point(20, 33)
        Me.tbBuscaProtocolo.MaxLength = 8
        Me.tbBuscaProtocolo.Name = "tbBuscaProtocolo"
        Me.tbBuscaProtocolo.Size = New System.Drawing.Size(105, 22)
        Me.tbBuscaProtocolo.TabIndex = 0
        Me.tbBuscaProtocolo.Tag = "Nº Protocolo"
        '
        'btRefresh
        '
        Me.btRefresh.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btRefresh.BackgroundImage = Global.Project.My.Resources.Resources.reload
        Me.btRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btRefresh.FlatAppearance.BorderSize = 0
        Me.btRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btRefresh.ForeColor = System.Drawing.Color.White
        Me.btRefresh.Location = New System.Drawing.Point(560, 11)
        Me.btRefresh.Name = "btRefresh"
        Me.btRefresh.Size = New System.Drawing.Size(57, 44)
        Me.btRefresh.TabIndex = 22
        Me.ToolTip1.SetToolTip(Me.btRefresh, "Atualizar lista")
        Me.btRefresh.UseVisualStyleBackColor = False
        '
        'pbBackground
        '
        Me.pbBackground.BackColor = System.Drawing.SystemColors.Control
        Me.pbBackground.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbBackground.Location = New System.Drawing.Point(0, 0)
        Me.pbBackground.Name = "pbBackground"
        Me.pbBackground.Size = New System.Drawing.Size(981, 616)
        Me.pbBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbBackground.TabIndex = 4
        Me.pbBackground.TabStop = False
        '
        'FmainOuvidoria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(981, 616)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.statusBar)
        Me.Controls.Add(Me.dgListProtocolos)
        Me.Controls.Add(Me.btNovoProtocolo)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.pbBackground)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "FmainOuvidoria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Controle de Ouvidoria"
        Me.TransparencyKey = System.Drawing.Color.Tan
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgListProtocolos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.statusBar.ResumeLayout(False)
        Me.statusBar.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pbBackground, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tbackup As System.Windows.Forms.Timer
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents CadastroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SairToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpçõesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BancoDeDadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents niMinimizar As System.Windows.Forms.NotifyIcon
    Friend WithEvents btNovoProtocolo As System.Windows.Forms.Button
    Friend WithEvents RelatóriosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pbBackground As System.Windows.Forms.PictureBox
    Friend WithEvents PlanoDeFundoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BackupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UsuáriosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgListProtocolos As System.Windows.Forms.DataGridView
    Friend WithEvents statusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbBuscaProtocolo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbBuscaDestinatario As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbBuscaStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbBuscaOrigem As System.Windows.Forms.ComboBox
    Friend WithEvents btRefresh As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents statusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents PrazosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
