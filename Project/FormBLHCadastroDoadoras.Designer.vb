<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBLHCadastroDoadoras
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
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

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBLHCadastroDoadoras))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tbNasc = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btNovoParto = New System.Windows.Forms.Button()
        Me.btExcluirParto = New System.Windows.Forms.Button()
        Me.tbNovoParto = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbPartos = New System.Windows.Forms.ComboBox()
        Me.tbDataCadastro = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btCancelar = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.tbOBS = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btSalvarDoadora = New System.Windows.Forms.Button()
        Me.btAtualizarDoadora = New System.Windows.Forms.Button()
        Me.btExcluirDoadora = New System.Windows.Forms.Button()
        Me.tbNome = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgDoadoras = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tbBuscaDN = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbBusca = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btReativar = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.tbBuscaDNDesativados = New System.Windows.Forms.MaskedTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbBuscaDesativados = New System.Windows.Forms.TextBox()
        Me.dgDoadorasDesativadas = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgDoadoras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgDoadorasDesativadas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tbNasc)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.tbDataCadastro)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btCancelar)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.tbOBS)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.btSalvarDoadora)
        Me.GroupBox1.Controls.Add(Me.btAtualizarDoadora)
        Me.GroupBox1.Controls.Add(Me.btExcluirDoadora)
        Me.GroupBox1.Controls.Add(Me.tbNome)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 274)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(405, 208)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Dados da nova doadora"
        '
        'tbNasc
        '
        Me.tbNasc.Location = New System.Drawing.Point(266, 42)
        Me.tbNasc.Mask = "00/00/0000"
        Me.tbNasc.Name = "tbNasc"
        Me.tbNasc.Size = New System.Drawing.Size(65, 20)
        Me.tbNasc.TabIndex = 1
        Me.tbNasc.ValidatingType = GetType(Date)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(263, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Nascimento"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btNovoParto)
        Me.GroupBox3.Controls.Add(Me.btExcluirParto)
        Me.GroupBox3.Controls.Add(Me.tbNovoParto)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.cbPartos)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 68)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(124, 105)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Partos"
        '
        'btNovoParto
        '
        Me.btNovoParto.BackColor = System.Drawing.Color.ForestGreen
        Me.btNovoParto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btNovoParto.Enabled = False
        Me.btNovoParto.FlatAppearance.BorderSize = 0
        Me.btNovoParto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btNovoParto.ForeColor = System.Drawing.Color.White
        Me.btNovoParto.Location = New System.Drawing.Point(95, 67)
        Me.btNovoParto.Name = "btNovoParto"
        Me.btNovoParto.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btNovoParto.Size = New System.Drawing.Size(23, 23)
        Me.btNovoParto.TabIndex = 3
        Me.btNovoParto.Text = "+"
        Me.btNovoParto.UseVisualStyleBackColor = False
        '
        'btExcluirParto
        '
        Me.btExcluirParto.BackColor = System.Drawing.Color.DarkRed
        Me.btExcluirParto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btExcluirParto.Enabled = False
        Me.btExcluirParto.FlatAppearance.BorderSize = 0
        Me.btExcluirParto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btExcluirParto.ForeColor = System.Drawing.Color.White
        Me.btExcluirParto.Location = New System.Drawing.Point(95, 28)
        Me.btExcluirParto.Name = "btExcluirParto"
        Me.btExcluirParto.Size = New System.Drawing.Size(23, 23)
        Me.btExcluirParto.TabIndex = 1
        Me.btExcluirParto.Text = "X"
        Me.btExcluirParto.UseVisualStyleBackColor = False
        '
        'tbNovoParto
        '
        Me.tbNovoParto.Location = New System.Drawing.Point(9, 69)
        Me.tbNovoParto.Mask = "00/00/0000"
        Me.tbNovoParto.Name = "tbNovoParto"
        Me.tbNovoParto.Size = New System.Drawing.Size(84, 20)
        Me.tbNovoParto.TabIndex = 2
        Me.tbNovoParto.ValidatingType = GetType(Date)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Incluir nova data"
        '
        'cbPartos
        '
        Me.cbPartos.FormattingEnabled = True
        Me.cbPartos.Location = New System.Drawing.Point(9, 29)
        Me.cbPartos.Name = "cbPartos"
        Me.cbPartos.Size = New System.Drawing.Size(84, 21)
        Me.cbPartos.TabIndex = 0
        '
        'tbDataCadastro
        '
        Me.tbDataCadastro.AllowPromptAsInput = False
        Me.tbDataCadastro.CausesValidation = False
        Me.tbDataCadastro.Cursor = System.Windows.Forms.Cursors.Default
        Me.tbDataCadastro.Enabled = False
        Me.tbDataCadastro.Location = New System.Drawing.Point(334, 42)
        Me.tbDataCadastro.Mask = "00/00/0000"
        Me.tbDataCadastro.Name = "tbDataCadastro"
        Me.tbDataCadastro.ReadOnly = True
        Me.tbDataCadastro.Size = New System.Drawing.Size(65, 20)
        Me.tbDataCadastro.TabIndex = 2
        Me.tbDataCadastro.TabStop = False
        Me.tbDataCadastro.ValidatingType = GetType(Date)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(331, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Cadastro"
        '
        'btCancelar
        '
        Me.btCancelar.BackColor = System.Drawing.Color.Chocolate
        Me.btCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btCancelar.FlatAppearance.BorderSize = 0
        Me.btCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btCancelar.ForeColor = System.Drawing.Color.White
        Me.btCancelar.Location = New System.Drawing.Point(233, 179)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btCancelar.TabIndex = 7
        Me.btCancelar.Text = "Cancelar"
        Me.btCancelar.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Black
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(366, 179)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(33, 23)
        Me.Button4.TabIndex = 8
        Me.Button4.Text = "Sair"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'tbOBS
        '
        Me.tbOBS.Location = New System.Drawing.Point(136, 81)
        Me.tbOBS.Multiline = True
        Me.tbOBS.Name = "tbOBS"
        Me.tbOBS.Size = New System.Drawing.Size(263, 92)
        Me.tbOBS.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(133, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Obs."
        '
        'btSalvarDoadora
        '
        Me.btSalvarDoadora.BackColor = System.Drawing.Color.ForestGreen
        Me.btSalvarDoadora.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btSalvarDoadora.FlatAppearance.BorderSize = 0
        Me.btSalvarDoadora.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btSalvarDoadora.ForeColor = System.Drawing.Color.White
        Me.btSalvarDoadora.Location = New System.Drawing.Point(5, 179)
        Me.btSalvarDoadora.Name = "btSalvarDoadora"
        Me.btSalvarDoadora.Size = New System.Drawing.Size(75, 23)
        Me.btSalvarDoadora.TabIndex = 4
        Me.btSalvarDoadora.Text = "Salvar"
        Me.btSalvarDoadora.UseVisualStyleBackColor = False
        '
        'btAtualizarDoadora
        '
        Me.btAtualizarDoadora.BackColor = System.Drawing.Color.SteelBlue
        Me.btAtualizarDoadora.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btAtualizarDoadora.Enabled = False
        Me.btAtualizarDoadora.FlatAppearance.BorderSize = 0
        Me.btAtualizarDoadora.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btAtualizarDoadora.ForeColor = System.Drawing.Color.White
        Me.btAtualizarDoadora.Location = New System.Drawing.Point(81, 179)
        Me.btAtualizarDoadora.Name = "btAtualizarDoadora"
        Me.btAtualizarDoadora.Size = New System.Drawing.Size(75, 23)
        Me.btAtualizarDoadora.TabIndex = 5
        Me.btAtualizarDoadora.Text = "Atualizar"
        Me.btAtualizarDoadora.UseVisualStyleBackColor = False
        '
        'btExcluirDoadora
        '
        Me.btExcluirDoadora.BackColor = System.Drawing.Color.DarkRed
        Me.btExcluirDoadora.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btExcluirDoadora.Enabled = False
        Me.btExcluirDoadora.FlatAppearance.BorderSize = 0
        Me.btExcluirDoadora.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btExcluirDoadora.ForeColor = System.Drawing.Color.White
        Me.btExcluirDoadora.Location = New System.Drawing.Point(157, 179)
        Me.btExcluirDoadora.Name = "btExcluirDoadora"
        Me.btExcluirDoadora.Size = New System.Drawing.Size(75, 23)
        Me.btExcluirDoadora.TabIndex = 6
        Me.btExcluirDoadora.Text = "Excluir"
        Me.btExcluirDoadora.UseVisualStyleBackColor = False
        '
        'tbNome
        '
        Me.tbNome.Location = New System.Drawing.Point(9, 42)
        Me.tbNome.Name = "tbNome"
        Me.tbNome.Size = New System.Drawing.Size(254, 20)
        Me.tbNome.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nome *"
        '
        'dgDoadoras
        '
        Me.dgDoadoras.AllowUserToAddRows = False
        Me.dgDoadoras.AllowUserToDeleteRows = False
        Me.dgDoadoras.AllowUserToOrderColumns = True
        Me.dgDoadoras.AllowUserToResizeRows = False
        Me.dgDoadoras.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDoadoras.BackgroundColor = System.Drawing.Color.White
        Me.dgDoadoras.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgDoadoras.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgDoadoras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgDoadoras.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgDoadoras.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.dgDoadoras.Location = New System.Drawing.Point(6, 41)
        Me.dgDoadoras.MultiSelect = False
        Me.dgDoadoras.Name = "dgDoadoras"
        Me.dgDoadoras.ReadOnly = True
        Me.dgDoadoras.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDoadoras.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgDoadoras.RowHeadersWidth = 4
        Me.dgDoadoras.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgDoadoras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgDoadoras.Size = New System.Drawing.Size(393, 223)
        Me.dgDoadoras.TabIndex = 2
        Me.dgDoadoras.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.tbBuscaDN)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.tbBusca)
        Me.GroupBox2.Controls.Add(Me.dgDoadoras)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(405, 270)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'tbBuscaDN
        '
        Me.tbBuscaDN.Location = New System.Drawing.Point(334, 15)
        Me.tbBuscaDN.Mask = "00/00/0000"
        Me.tbBuscaDN.Name = "tbBuscaDN"
        Me.tbBuscaDN.Size = New System.Drawing.Size(65, 20)
        Me.tbBuscaDN.TabIndex = 1
        Me.tbBuscaDN.ValidatingType = GetType(Date)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(308, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "DN:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Nome:"
        '
        'tbBusca
        '
        Me.tbBusca.Location = New System.Drawing.Point(44, 15)
        Me.tbBusca.Name = "tbBusca"
        Me.tbBusca.Size = New System.Drawing.Size(258, 20)
        Me.tbBusca.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 526)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(443, 22)
        Me.StatusStrip1.TabIndex = 36
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(67, 17)
        Me.ToolStripStatusLabel1.Text = "N Registros"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(9, 8)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(425, 515)
        Me.TabControl1.TabIndex = 37
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(417, 489)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Doadoras cadastradas"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btReativar)
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(417, 489)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Cadastros desativados"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btReativar
        '
        Me.btReativar.BackColor = System.Drawing.Color.ForestGreen
        Me.btReativar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btReativar.Enabled = False
        Me.btReativar.FlatAppearance.BorderSize = 0
        Me.btReativar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btReativar.ForeColor = System.Drawing.Color.White
        Me.btReativar.Location = New System.Drawing.Point(12, 276)
        Me.btReativar.Name = "btReativar"
        Me.btReativar.Size = New System.Drawing.Size(112, 23)
        Me.btReativar.TabIndex = 5
        Me.btReativar.Text = "Reativar cadastro"
        Me.btReativar.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.tbBuscaDNDesativados)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.tbBuscaDesativados)
        Me.GroupBox4.Controls.Add(Me.dgDoadorasDesativadas)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(405, 270)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        '
        'tbBuscaDNDesativados
        '
        Me.tbBuscaDNDesativados.Location = New System.Drawing.Point(334, 15)
        Me.tbBuscaDNDesativados.Mask = "00/00/0000"
        Me.tbBuscaDNDesativados.Name = "tbBuscaDNDesativados"
        Me.tbBuscaDNDesativados.Size = New System.Drawing.Size(65, 20)
        Me.tbBuscaDNDesativados.TabIndex = 1
        Me.tbBuscaDNDesativados.ValidatingType = GetType(Date)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(308, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "DN:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Nome:"
        '
        'tbBuscaDesativados
        '
        Me.tbBuscaDesativados.Location = New System.Drawing.Point(44, 15)
        Me.tbBuscaDesativados.Name = "tbBuscaDesativados"
        Me.tbBuscaDesativados.Size = New System.Drawing.Size(258, 20)
        Me.tbBuscaDesativados.TabIndex = 0
        '
        'dgDoadorasDesativadas
        '
        Me.dgDoadorasDesativadas.AllowUserToAddRows = False
        Me.dgDoadorasDesativadas.AllowUserToDeleteRows = False
        Me.dgDoadorasDesativadas.AllowUserToOrderColumns = True
        Me.dgDoadorasDesativadas.AllowUserToResizeRows = False
        Me.dgDoadorasDesativadas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDoadorasDesativadas.BackgroundColor = System.Drawing.Color.White
        Me.dgDoadorasDesativadas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgDoadorasDesativadas.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgDoadorasDesativadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgDoadorasDesativadas.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgDoadorasDesativadas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.dgDoadorasDesativadas.Location = New System.Drawing.Point(6, 41)
        Me.dgDoadorasDesativadas.MultiSelect = False
        Me.dgDoadorasDesativadas.Name = "dgDoadorasDesativadas"
        Me.dgDoadorasDesativadas.ReadOnly = True
        Me.dgDoadorasDesativadas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDoadorasDesativadas.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgDoadorasDesativadas.RowHeadersWidth = 4
        Me.dgDoadorasDesativadas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgDoadorasDesativadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgDoadorasDesativadas.Size = New System.Drawing.Size(393, 223)
        Me.dgDoadorasDesativadas.TabIndex = 2
        Me.dgDoadorasDesativadas.TabStop = False
        '
        'FormBLHCadastroDoadoras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(443, 548)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormBLHCadastroDoadoras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BLH - Cadastro de doadoras"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgDoadoras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dgDoadorasDesativadas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents tbNome As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dgDoadoras As DataGridView
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btExcluirDoadora As Button
    Friend WithEvents btAtualizarDoadora As Button
    Friend WithEvents btSalvarDoadora As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents Button4 As Button
    Friend WithEvents tbOBS As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents tbBusca As TextBox
    Friend WithEvents btCancelar As Button
    Friend WithEvents tbDataCadastro As MaskedTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cbPartos As ComboBox
    Friend WithEvents tbBuscaDN As MaskedTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tbNovoParto As MaskedTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btExcluirParto As Button
    Friend WithEvents btNovoParto As Button
    Friend WithEvents tbNasc As MaskedTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents tbBuscaDNDesativados As MaskedTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents tbBuscaDesativados As TextBox
    Friend WithEvents dgDoadorasDesativadas As DataGridView
    Friend WithEvents btReativar As Button
End Class
