<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FplanejCNES
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FplanejCNES))
        Me.cbFormaContratoEstab = New System.Windows.Forms.ComboBox()
        Me.Label252 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbcbFormaContratoEmpreg = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbDetalhamento = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.lbNMTotal = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lbNSTotal = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lbACStotal = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lbEnfTotal = New System.Windows.Forms.Label()
        Me.lbMedTotal = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.rbPrivado = New System.Windows.Forms.RadioButton()
        Me.rbPublico = New System.Windows.Forms.RadioButton()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.tpCBOmedico = New System.Windows.Forms.TabPage()
        Me.lbMedicos = New System.Windows.Forms.ListBox()
        Me.tpCBOenfermeiro = New System.Windows.Forms.TabPage()
        Me.lbEnfermeiro = New System.Windows.Forms.ListBox()
        Me.tpCBOnivelSuperior = New System.Windows.Forms.TabPage()
        Me.lbSuperior = New System.Windows.Forms.ListBox()
        Me.tpCBOnivelMedio = New System.Windows.Forms.TabPage()
        Me.lbMedio = New System.Windows.Forms.ListBox()
        Me.tpCBOacs = New System.Windows.Forms.TabPage()
        Me.lbACS = New System.Windows.Forms.ListBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dgPlanejamento = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TextBoxCPF = New System.Windows.Forms.TextBox()
        Me.TextBoxNome = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ConfiguraçõesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportarPDFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FecharToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl.SuspendLayout()
        Me.tpCBOmedico.SuspendLayout()
        Me.tpCBOenfermeiro.SuspendLayout()
        Me.tpCBOnivelSuperior.SuspendLayout()
        Me.tpCBOnivelMedio.SuspendLayout()
        Me.tpCBOacs.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.dgPlanejamento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbFormaContratoEstab
        '
        Me.cbFormaContratoEstab.FormattingEnabled = True
        Me.cbFormaContratoEstab.Location = New System.Drawing.Point(17, 71)
        Me.cbFormaContratoEstab.Name = "cbFormaContratoEstab"
        Me.cbFormaContratoEstab.Size = New System.Drawing.Size(438, 21)
        Me.cbFormaContratoEstab.TabIndex = 31
        '
        'Label252
        '
        Me.Label252.AutoSize = True
        Me.Label252.Location = New System.Drawing.Point(14, 55)
        Me.Label252.Name = "Label252"
        Me.Label252.Size = New System.Drawing.Size(214, 13)
        Me.Label252.TabIndex = 32
        Me.Label252.Text = "Forma de contratação com estabelecimento"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(193, 13)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Forma de contratação com empregador"
        '
        'cbcbFormaContratoEmpreg
        '
        Me.cbcbFormaContratoEmpreg.FormattingEnabled = True
        Me.cbcbFormaContratoEmpreg.Location = New System.Drawing.Point(17, 111)
        Me.cbcbFormaContratoEmpreg.Name = "cbcbFormaContratoEmpreg"
        Me.cbcbFormaContratoEmpreg.Size = New System.Drawing.Size(438, 21)
        Me.cbcbFormaContratoEmpreg.TabIndex = 33
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Detalhamento"
        '
        'cbDetalhamento
        '
        Me.cbDetalhamento.FormattingEnabled = True
        Me.cbDetalhamento.Location = New System.Drawing.Point(17, 151)
        Me.cbDetalhamento.Name = "cbDetalhamento"
        Me.cbDetalhamento.Size = New System.Drawing.Size(438, 21)
        Me.cbDetalhamento.TabIndex = 35
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Controls.Add(Me.rbPrivado)
        Me.GroupBox2.Controls.Add(Me.rbPublico)
        Me.GroupBox2.Controls.Add(Me.cbFormaContratoEstab)
        Me.GroupBox2.Controls.Add(Me.Label252)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.cbcbFormaContratoEmpreg)
        Me.GroupBox2.Controls.Add(Me.cbDetalhamento)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(698, 191)
        Me.GroupBox2.TabIndex = 38
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Dados de contratação"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label60)
        Me.GroupBox1.Controls.Add(Me.lbNMTotal)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.lbNSTotal)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.lbACStotal)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.lbEnfTotal)
        Me.GroupBox1.Controls.Add(Me.lbMedTotal)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Location = New System.Drawing.Point(461, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(237, 191)
        Me.GroupBox1.TabIndex = 39
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Resultados encontrados"
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.Location = New System.Drawing.Point(61, 46)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(63, 13)
        Me.Label60.TabIndex = 60
        Me.Label60.Text = "MÉDICOS"
        '
        'lbNMTotal
        '
        Me.lbNMTotal.AutoSize = True
        Me.lbNMTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNMTotal.ForeColor = System.Drawing.Color.DarkKhaki
        Me.lbNMTotal.Location = New System.Drawing.Point(27, 86)
        Me.lbNMTotal.Name = "lbNMTotal"
        Me.lbNMTotal.Size = New System.Drawing.Size(31, 16)
        Me.lbNMTotal.TabIndex = 135
        Me.lbNMTotal.Text = "000"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(61, 88)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(143, 13)
        Me.Label26.TabIndex = 134
        Me.Label26.Text = "OUTROS NIVEL MÉDIO"
        '
        'lbNSTotal
        '
        Me.lbNSTotal.AutoSize = True
        Me.lbNSTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNSTotal.ForeColor = System.Drawing.Color.SeaGreen
        Me.lbNSTotal.Location = New System.Drawing.Point(27, 107)
        Me.lbNSTotal.Name = "lbNSTotal"
        Me.lbNSTotal.Size = New System.Drawing.Size(31, 16)
        Me.lbNSTotal.TabIndex = 101
        Me.lbNSTotal.Text = "000"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(61, 109)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(167, 13)
        Me.Label18.TabIndex = 100
        Me.Label18.Text = "OUTROS NIVEL SUPERIOR"
        '
        'lbACStotal
        '
        Me.lbACStotal.AutoSize = True
        Me.lbACStotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbACStotal.ForeColor = System.Drawing.Color.DarkViolet
        Me.lbACStotal.Location = New System.Drawing.Point(27, 128)
        Me.lbACStotal.Name = "lbACStotal"
        Me.lbACStotal.Size = New System.Drawing.Size(31, 16)
        Me.lbACStotal.TabIndex = 67
        Me.lbACStotal.Text = "000"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(61, 130)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(31, 13)
        Me.Label14.TabIndex = 66
        Me.Label14.Text = "ACS"
        '
        'lbEnfTotal
        '
        Me.lbEnfTotal.AutoSize = True
        Me.lbEnfTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEnfTotal.ForeColor = System.Drawing.Color.IndianRed
        Me.lbEnfTotal.Location = New System.Drawing.Point(27, 65)
        Me.lbEnfTotal.Name = "lbEnfTotal"
        Me.lbEnfTotal.Size = New System.Drawing.Size(31, 16)
        Me.lbEnfTotal.TabIndex = 63
        Me.lbEnfTotal.Text = "000"
        '
        'lbMedTotal
        '
        Me.lbMedTotal.AutoSize = True
        Me.lbMedTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMedTotal.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbMedTotal.Location = New System.Drawing.Point(27, 44)
        Me.lbMedTotal.Name = "lbMedTotal"
        Me.lbMedTotal.Size = New System.Drawing.Size(31, 16)
        Me.lbMedTotal.TabIndex = 61
        Me.lbMedTotal.Text = "000"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(61, 67)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 13)
        Me.Label10.TabIndex = 62
        Me.Label10.Text = "ENFERMEIROS"
        '
        'rbPrivado
        '
        Me.rbPrivado.AutoSize = True
        Me.rbPrivado.Location = New System.Drawing.Point(83, 26)
        Me.rbPrivado.Name = "rbPrivado"
        Me.rbPrivado.Size = New System.Drawing.Size(61, 17)
        Me.rbPrivado.TabIndex = 38
        Me.rbPrivado.Text = "Privado"
        Me.rbPrivado.UseVisualStyleBackColor = True
        '
        'rbPublico
        '
        Me.rbPublico.AutoSize = True
        Me.rbPublico.Checked = True
        Me.rbPublico.Location = New System.Drawing.Point(17, 26)
        Me.rbPublico.Name = "rbPublico"
        Me.rbPublico.Size = New System.Drawing.Size(60, 17)
        Me.rbPublico.TabIndex = 37
        Me.rbPublico.TabStop = True
        Me.rbPublico.Text = "Público"
        Me.rbPublico.UseVisualStyleBackColor = True
        '
        'TabControl
        '
        Me.TabControl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl.Controls.Add(Me.tpCBOmedico)
        Me.TabControl.Controls.Add(Me.tpCBOenfermeiro)
        Me.TabControl.Controls.Add(Me.tpCBOnivelSuperior)
        Me.TabControl.Controls.Add(Me.tpCBOnivelMedio)
        Me.TabControl.Controls.Add(Me.tpCBOacs)
        Me.TabControl.Location = New System.Drawing.Point(716, 24)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(297, 247)
        Me.TabControl.TabIndex = 39
        '
        'tpCBOmedico
        '
        Me.tpCBOmedico.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tpCBOmedico.Controls.Add(Me.lbMedicos)
        Me.tpCBOmedico.Location = New System.Drawing.Point(4, 22)
        Me.tpCBOmedico.Name = "tpCBOmedico"
        Me.tpCBOmedico.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCBOmedico.Size = New System.Drawing.Size(289, 221)
        Me.tpCBOmedico.TabIndex = 0
        Me.tpCBOmedico.Text = "CBOs Médicos"
        '
        'lbMedicos
        '
        Me.lbMedicos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMedicos.FormattingEnabled = True
        Me.lbMedicos.ItemHeight = 15
        Me.lbMedicos.Location = New System.Drawing.Point(6, 1)
        Me.lbMedicos.Name = "lbMedicos"
        Me.lbMedicos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbMedicos.Size = New System.Drawing.Size(277, 214)
        Me.lbMedicos.TabIndex = 62
        '
        'tpCBOenfermeiro
        '
        Me.tpCBOenfermeiro.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tpCBOenfermeiro.Controls.Add(Me.lbEnfermeiro)
        Me.tpCBOenfermeiro.Location = New System.Drawing.Point(4, 22)
        Me.tpCBOenfermeiro.Name = "tpCBOenfermeiro"
        Me.tpCBOenfermeiro.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCBOenfermeiro.Size = New System.Drawing.Size(289, 221)
        Me.tpCBOenfermeiro.TabIndex = 1
        Me.tpCBOenfermeiro.Text = "CBOs Enfermeiros"
        '
        'lbEnfermeiro
        '
        Me.lbEnfermeiro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEnfermeiro.FormattingEnabled = True
        Me.lbEnfermeiro.ItemHeight = 15
        Me.lbEnfermeiro.Location = New System.Drawing.Point(6, 1)
        Me.lbEnfermeiro.Name = "lbEnfermeiro"
        Me.lbEnfermeiro.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbEnfermeiro.Size = New System.Drawing.Size(277, 214)
        Me.lbEnfermeiro.TabIndex = 64
        '
        'tpCBOnivelSuperior
        '
        Me.tpCBOnivelSuperior.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tpCBOnivelSuperior.Controls.Add(Me.lbSuperior)
        Me.tpCBOnivelSuperior.Location = New System.Drawing.Point(4, 22)
        Me.tpCBOnivelSuperior.Name = "tpCBOnivelSuperior"
        Me.tpCBOnivelSuperior.Size = New System.Drawing.Size(289, 221)
        Me.tpCBOnivelSuperior.TabIndex = 3
        Me.tpCBOnivelSuperior.Text = "CBOs outros nível superior"
        '
        'lbSuperior
        '
        Me.lbSuperior.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSuperior.FormattingEnabled = True
        Me.lbSuperior.ItemHeight = 15
        Me.lbSuperior.Location = New System.Drawing.Point(6, 1)
        Me.lbSuperior.Name = "lbSuperior"
        Me.lbSuperior.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbSuperior.Size = New System.Drawing.Size(277, 214)
        Me.lbSuperior.TabIndex = 102
        '
        'tpCBOnivelMedio
        '
        Me.tpCBOnivelMedio.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tpCBOnivelMedio.Controls.Add(Me.lbMedio)
        Me.tpCBOnivelMedio.Location = New System.Drawing.Point(4, 22)
        Me.tpCBOnivelMedio.Name = "tpCBOnivelMedio"
        Me.tpCBOnivelMedio.Size = New System.Drawing.Size(289, 221)
        Me.tpCBOnivelMedio.TabIndex = 4
        Me.tpCBOnivelMedio.Text = "CBOs outros nivel médio"
        '
        'lbMedio
        '
        Me.lbMedio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMedio.FormattingEnabled = True
        Me.lbMedio.ItemHeight = 15
        Me.lbMedio.Location = New System.Drawing.Point(6, 1)
        Me.lbMedio.Name = "lbMedio"
        Me.lbMedio.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbMedio.Size = New System.Drawing.Size(277, 214)
        Me.lbMedio.TabIndex = 136
        '
        'tpCBOacs
        '
        Me.tpCBOacs.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tpCBOacs.Controls.Add(Me.lbACS)
        Me.tpCBOacs.Location = New System.Drawing.Point(4, 22)
        Me.tpCBOacs.Name = "tpCBOacs"
        Me.tpCBOacs.Size = New System.Drawing.Size(289, 221)
        Me.tpCBOacs.TabIndex = 2
        Me.tpCBOacs.Text = "CBOs ACS"
        '
        'lbACS
        '
        Me.lbACS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbACS.FormattingEnabled = True
        Me.lbACS.ItemHeight = 15
        Me.lbACS.Location = New System.Drawing.Point(6, 1)
        Me.lbACS.Name = "lbACS"
        Me.lbACS.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbACS.Size = New System.Drawing.Size(277, 214)
        Me.lbACS.TabIndex = 68
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 30000
        Me.ToolTip1.InitialDelay = 200
        Me.ToolTip1.ReshowDelay = 100
        Me.ToolTip1.ShowAlways = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 481)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1025, 22)
        Me.StatusStrip1.TabIndex = 40
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(37, 17)
        Me.ToolStripStatusLabel1.Text = "          "
        '
        'dgPlanejamento
        '
        Me.dgPlanejamento.AllowUserToAddRows = False
        Me.dgPlanejamento.AllowUserToDeleteRows = False
        Me.dgPlanejamento.AllowUserToOrderColumns = True
        Me.dgPlanejamento.AllowUserToResizeRows = False
        Me.dgPlanejamento.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgPlanejamento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgPlanejamento.BackgroundColor = System.Drawing.Color.White
        Me.dgPlanejamento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgPlanejamento.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgPlanejamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgPlanejamento.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgPlanejamento.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.dgPlanejamento.Location = New System.Drawing.Point(12, 276)
        Me.dgPlanejamento.MultiSelect = False
        Me.dgPlanejamento.Name = "dgPlanejamento"
        Me.dgPlanejamento.ReadOnly = True
        Me.dgPlanejamento.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPlanejamento.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgPlanejamento.RowHeadersWidth = 4
        Me.dgPlanejamento.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgPlanejamento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgPlanejamento.Size = New System.Drawing.Size(997, 191)
        Me.dgPlanejamento.TabIndex = 30
        Me.dgPlanejamento.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TextBoxCPF)
        Me.GroupBox3.Controls.Add(Me.TextBoxNome)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 221)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(698, 50)
        Me.GroupBox3.TabIndex = 41
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Busca "
        '
        'TextBoxCPF
        '
        Me.TextBoxCPF.Location = New System.Drawing.Point(44, 20)
        Me.TextBoxCPF.MaxLength = 11
        Me.TextBoxCPF.Name = "TextBoxCPF"
        Me.TextBoxCPF.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxCPF.TabIndex = 4
        '
        'TextBoxNome
        '
        Me.TextBoxNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxNome.Location = New System.Drawing.Point(194, 20)
        Me.TextBoxNome.Name = "TextBoxNome"
        Me.TextBoxNome.Size = New System.Drawing.Size(495, 20)
        Me.TextBoxNome.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(150, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Nome:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "CPF:"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfiguraçõesToolStripMenuItem, Me.FecharToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1025, 24)
        Me.MenuStrip1.TabIndex = 42
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ConfiguraçõesToolStripMenuItem
        '
        Me.ConfiguraçõesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportarPDFToolStripMenuItem})
        Me.ConfiguraçõesToolStripMenuItem.Name = "ConfiguraçõesToolStripMenuItem"
        Me.ConfiguraçõesToolStripMenuItem.Size = New System.Drawing.Size(96, 20)
        Me.ConfiguraçõesToolStripMenuItem.Text = "Configurações"
        '
        'ImportarPDFToolStripMenuItem
        '
        Me.ImportarPDFToolStripMenuItem.Name = "ImportarPDFToolStripMenuItem"
        Me.ImportarPDFToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.ImportarPDFToolStripMenuItem.Text = "Importar PDF"
        '
        'FecharToolStripMenuItem
        '
        Me.FecharToolStripMenuItem.Name = "FecharToolStripMenuItem"
        Me.FecharToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.FecharToolStripMenuItem.Text = "Fechar"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'FplanejCNES
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1025, 503)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TabControl)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dgPlanejamento)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "FplanejCNES"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CNES - Planejamento"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl.ResumeLayout(False)
        Me.tpCBOmedico.ResumeLayout(False)
        Me.tpCBOenfermeiro.ResumeLayout(False)
        Me.tpCBOnivelSuperior.ResumeLayout(False)
        Me.tpCBOnivelMedio.ResumeLayout(False)
        Me.tpCBOacs.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.dgPlanejamento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbFormaContratoEstab As System.Windows.Forms.ComboBox
    Friend WithEvents Label252 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbcbFormaContratoEmpreg As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbDetalhamento As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbPrivado As System.Windows.Forms.RadioButton
    Friend WithEvents rbPublico As System.Windows.Forms.RadioButton
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents tpCBOmedico As System.Windows.Forms.TabPage
    Friend WithEvents tpCBOenfermeiro As System.Windows.Forms.TabPage
    Friend WithEvents tpCBOacs As System.Windows.Forms.TabPage
    Friend WithEvents lbMedTotal As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lbEnfTotal As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lbACStotal As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tpCBOnivelSuperior As System.Windows.Forms.TabPage
    Friend WithEvents lbNSTotal As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents tpCBOnivelMedio As System.Windows.Forms.TabPage
    Friend WithEvents lbNMTotal As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents dgPlanejamento As DataGridView
    Friend WithEvents lbMedicos As ListBox
    Friend WithEvents lbEnfermeiro As ListBox
    Friend WithEvents lbACS As ListBox
    Friend WithEvents lbSuperior As ListBox
    Friend WithEvents lbMedio As ListBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxNome As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBoxCPF As TextBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ConfiguraçõesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportarPDFToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FecharToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
