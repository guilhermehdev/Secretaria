<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCNESCadastro
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCNESCadastro))
        Me.TextBoxCPFCadastro = New System.Windows.Forms.MaskedTextBox()
        Me.TextBoxNomeCadastro = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtCnsCadastro = New System.Windows.Forms.MaskedTextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.dtNascimento = New System.Windows.Forms.MaskedTextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.btConsultaCADSUS = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btExcluirVinculo = New System.Windows.Forms.Button()
        Me.btAtualizarVinculo = New System.Windows.Forms.Button()
        Me.tbCNPJContratador = New System.Windows.Forms.MaskedTextBox()
        Me.btSalvarVinculo = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cbDetalhamentoCadastro = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbSUSSim = New System.Windows.Forms.RadioButton()
        Me.rbSUSNao = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nudOutro = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.nudHosp = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.nudAmb = New System.Windows.Forms.NumericUpDown()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbConselho = New System.Windows.Forms.TextBox()
        Me.cbUF = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.cbCBO = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tbCNES = New System.Windows.Forms.TextBox()
        Me.cbEstabelecimento = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbFormaContratoEstabCadastro = New System.Windows.Forms.ComboBox()
        Me.Label252 = New System.Windows.Forms.Label()
        Me.cbcbFormaContratoEmpregCadastro = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvProfissionais = New System.Windows.Forms.DataGridView()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btExcluir = New System.Windows.Forms.Button()
        Me.btAtualizar = New System.Windows.Forms.Button()
        Me.btNovo = New System.Windows.Forms.Button()
        Me.btSalvar = New System.Windows.Forms.Button()
        Me.dgvVinculos = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.nudOutro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudHosp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAmb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvProfissionais, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvVinculos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBoxCPFCadastro
        '
        Me.TextBoxCPFCadastro.Location = New System.Drawing.Point(16, 33)
        Me.TextBoxCPFCadastro.Mask = "000\.000\.000\-00"
        Me.TextBoxCPFCadastro.Name = "TextBoxCPFCadastro"
        Me.TextBoxCPFCadastro.Size = New System.Drawing.Size(89, 20)
        Me.TextBoxCPFCadastro.TabIndex = 140
        '
        'TextBoxNomeCadastro
        '
        Me.TextBoxNomeCadastro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxNomeCadastro.Location = New System.Drawing.Point(215, 33)
        Me.TextBoxNomeCadastro.Name = "TextBoxNomeCadastro"
        Me.TextBoxNomeCadastro.Size = New System.Drawing.Size(334, 20)
        Me.TextBoxNomeCadastro.TabIndex = 139
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(212, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 138
        Me.Label4.Text = "Nome"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 137
        Me.Label1.Text = "CPF"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtCnsCadastro)
        Me.GroupBox1.Controls.Add(Me.btSalvar)
        Me.GroupBox1.Controls.Add(Me.btExcluir)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.btAtualizar)
        Me.GroupBox1.Controls.Add(Me.btNovo)
        Me.GroupBox1.Controls.Add(Me.dtNascimento)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.btConsultaCADSUS)
        Me.GroupBox1.Controls.Add(Me.TextBoxCPFCadastro)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TextBoxNomeCadastro)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(682, 90)
        Me.GroupBox1.TabIndex = 141
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Profissional"
        '
        'txtCnsCadastro
        '
        Me.txtCnsCadastro.BackColor = System.Drawing.Color.White
        Me.txtCnsCadastro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCnsCadastro.ForeColor = System.Drawing.Color.Black
        Me.txtCnsCadastro.Location = New System.Drawing.Point(551, 33)
        Me.txtCnsCadastro.Mask = "9999,9999,9999,999"
        Me.txtCnsCadastro.Name = "txtCnsCadastro"
        Me.txtCnsCadastro.Size = New System.Drawing.Size(121, 21)
        Me.txtCnsCadastro.TabIndex = 145
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(548, 17)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(29, 13)
        Me.Label17.TabIndex = 144
        Me.Label17.Text = "CNS"
        '
        'dtNascimento
        '
        Me.dtNascimento.BackColor = System.Drawing.Color.White
        Me.dtNascimento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtNascimento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtNascimento.ForeColor = System.Drawing.Color.Black
        Me.dtNascimento.Location = New System.Drawing.Point(141, 33)
        Me.dtNascimento.Mask = "00/00/0000"
        Me.dtNascimento.Name = "dtNascimento"
        Me.dtNascimento.Size = New System.Drawing.Size(72, 21)
        Me.dtNascimento.TabIndex = 142
        Me.dtNascimento.ValidatingType = GetType(Date)
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(138, 17)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(63, 13)
        Me.Label25.TabIndex = 143
        Me.Label25.Text = "Nascimento"
        '
        'btConsultaCADSUS
        '
        Me.btConsultaCADSUS.BackgroundImage = Global.Project.My.Resources.Resources.sus
        Me.btConsultaCADSUS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btConsultaCADSUS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btConsultaCADSUS.FlatAppearance.BorderSize = 0
        Me.btConsultaCADSUS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btConsultaCADSUS.Location = New System.Drawing.Point(106, 33)
        Me.btConsultaCADSUS.Name = "btConsultaCADSUS"
        Me.btConsultaCADSUS.Size = New System.Drawing.Size(33, 21)
        Me.btConsultaCADSUS.TabIndex = 141
        Me.btConsultaCADSUS.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.dgvVinculos)
        Me.GroupBox2.Controls.Add(Me.btExcluirVinculo)
        Me.GroupBox2.Controls.Add(Me.btAtualizarVinculo)
        Me.GroupBox2.Controls.Add(Me.tbCNPJContratador)
        Me.GroupBox2.Controls.Add(Me.btSalvarVinculo)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.cbDetalhamentoCadastro)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.nudOutro)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.nudHosp)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.nudAmb)
        Me.GroupBox2.Controls.Add(Me.Label43)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.tbConselho)
        Me.GroupBox2.Controls.Add(Me.cbUF)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.cbCBO)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.tbCNES)
        Me.GroupBox2.Controls.Add(Me.cbEstabelecimento)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cbFormaContratoEstabCadastro)
        Me.GroupBox2.Controls.Add(Me.Label252)
        Me.GroupBox2.Controls.Add(Me.cbcbFormaContratoEmpregCadastro)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 108)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(682, 343)
        Me.GroupBox2.TabIndex = 142
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Vínculo"
        '
        'btExcluirVinculo
        '
        Me.btExcluirVinculo.BackColor = System.Drawing.Color.IndianRed
        Me.btExcluirVinculo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btExcluirVinculo.FlatAppearance.BorderSize = 0
        Me.btExcluirVinculo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btExcluirVinculo.ForeColor = System.Drawing.Color.White
        Me.btExcluirVinculo.Location = New System.Drawing.Point(133, 309)
        Me.btExcluirVinculo.Name = "btExcluirVinculo"
        Me.btExcluirVinculo.Size = New System.Drawing.Size(60, 23)
        Me.btExcluirVinculo.TabIndex = 147
        Me.btExcluirVinculo.Text = "Excluir"
        Me.btExcluirVinculo.UseVisualStyleBackColor = False
        '
        'btAtualizarVinculo
        '
        Me.btAtualizarVinculo.BackColor = System.Drawing.Color.Orange
        Me.btAtualizarVinculo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btAtualizarVinculo.FlatAppearance.BorderSize = 0
        Me.btAtualizarVinculo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btAtualizarVinculo.ForeColor = System.Drawing.Color.White
        Me.btAtualizarVinculo.Location = New System.Drawing.Point(72, 309)
        Me.btAtualizarVinculo.Name = "btAtualizarVinculo"
        Me.btAtualizarVinculo.Size = New System.Drawing.Size(60, 23)
        Me.btAtualizarVinculo.TabIndex = 146
        Me.btAtualizarVinculo.Text = "Atualizar"
        Me.btAtualizarVinculo.UseVisualStyleBackColor = False
        '
        'tbCNPJContratador
        '
        Me.tbCNPJContratador.Location = New System.Drawing.Point(351, 166)
        Me.tbCNPJContratador.Mask = "00.000.000/0000-00"
        Me.tbCNPJContratador.Name = "tbCNPJContratador"
        Me.tbCNPJContratador.Size = New System.Drawing.Size(113, 20)
        Me.tbCNPJContratador.TabIndex = 141
        '
        'btSalvarVinculo
        '
        Me.btSalvarVinculo.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.btSalvarVinculo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btSalvarVinculo.FlatAppearance.BorderSize = 0
        Me.btSalvarVinculo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btSalvarVinculo.ForeColor = System.Drawing.Color.White
        Me.btSalvarVinculo.Location = New System.Drawing.Point(11, 309)
        Me.btSalvarVinculo.Name = "btSalvarVinculo"
        Me.btSalvarVinculo.Size = New System.Drawing.Size(60, 23)
        Me.btSalvarVinculo.TabIndex = 144
        Me.btSalvarVinculo.Text = "Adicionar"
        Me.btSalvarVinculo.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(348, 150)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(115, 13)
        Me.Label12.TabIndex = 140
        Me.Label12.Text = "CNPJ do intermediador"
        '
        'cbDetalhamentoCadastro
        '
        Me.cbDetalhamentoCadastro.FormattingEnabled = True
        Me.cbDetalhamentoCadastro.Location = New System.Drawing.Point(351, 125)
        Me.cbDetalhamentoCadastro.Name = "cbDetalhamentoCadastro"
        Me.cbDetalhamentoCadastro.Size = New System.Drawing.Size(315, 21)
        Me.cbDetalhamentoCadastro.TabIndex = 41
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbSUSSim)
        Me.GroupBox3.Controls.Add(Me.rbSUSNao)
        Me.GroupBox3.Location = New System.Drawing.Point(208, 150)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(119, 36)
        Me.GroupBox3.TabIndex = 64
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "SUS"
        '
        'rbSUSSim
        '
        Me.rbSUSSim.AutoSize = True
        Me.rbSUSSim.Location = New System.Drawing.Point(13, 14)
        Me.rbSUSSim.Name = "rbSUSSim"
        Me.rbSUSSim.Size = New System.Drawing.Size(44, 17)
        Me.rbSUSSim.TabIndex = 62
        Me.rbSUSSim.Text = "SIM"
        Me.rbSUSSim.UseVisualStyleBackColor = True
        '
        'rbSUSNao
        '
        Me.rbSUSNao.AutoSize = True
        Me.rbSUSNao.Checked = True
        Me.rbSUSNao.Location = New System.Drawing.Point(63, 14)
        Me.rbSUSNao.Name = "rbSUSNao"
        Me.rbSUSNao.Size = New System.Drawing.Size(48, 17)
        Me.rbSUSNao.TabIndex = 63
        Me.rbSUSNao.TabStop = True
        Me.rbSUSNao.Text = "NÃO"
        Me.rbSUSNao.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(348, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Detalhamento"
        '
        'nudOutro
        '
        Me.nudOutro.Location = New System.Drawing.Point(140, 161)
        Me.nudOutro.Maximum = New Decimal(New Integer() {168, 0, 0, 0})
        Me.nudOutro.Name = "nudOutro"
        Me.nudOutro.Size = New System.Drawing.Size(60, 20)
        Me.nudOutro.TabIndex = 61
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(137, 147)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 13)
        Me.Label11.TabIndex = 60
        Me.Label11.Text = "CH Outro"
        '
        'nudHosp
        '
        Me.nudHosp.Location = New System.Drawing.Point(75, 161)
        Me.nudHosp.Maximum = New Decimal(New Integer() {168, 0, 0, 0})
        Me.nudHosp.Name = "nudHosp"
        Me.nudHosp.Size = New System.Drawing.Size(60, 20)
        Me.nudHosp.TabIndex = 59
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(72, 147)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 13)
        Me.Label10.TabIndex = 58
        Me.Label10.Text = "CH Hosp"
        '
        'nudAmb
        '
        Me.nudAmb.Location = New System.Drawing.Point(11, 162)
        Me.nudAmb.Maximum = New Decimal(New Integer() {168, 0, 0, 0})
        Me.nudAmb.Name = "nudAmb"
        Me.nudAmb.Size = New System.Drawing.Size(60, 20)
        Me.nudAmb.TabIndex = 57
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(8, 147)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(46, 13)
        Me.Label43.TabIndex = 56
        Me.Label43.Text = "CH Amb"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(198, 108)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 13)
        Me.Label9.TabIndex = 54
        Me.Label9.Text = "Nº conselho"
        '
        'tbConselho
        '
        Me.tbConselho.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.tbConselho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbConselho.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbConselho.ForeColor = System.Drawing.Color.Orange
        Me.tbConselho.Location = New System.Drawing.Point(201, 123)
        Me.tbConselho.MaxLength = 9
        Me.tbConselho.Name = "tbConselho"
        Me.tbConselho.ReadOnly = True
        Me.tbConselho.Size = New System.Drawing.Size(126, 21)
        Me.tbConselho.TabIndex = 53
        '
        'cbUF
        '
        Me.cbUF.FormattingEnabled = True
        Me.cbUF.Location = New System.Drawing.Point(140, 123)
        Me.cbUF.Name = "cbUF"
        Me.cbUF.Size = New System.Drawing.Size(55, 21)
        Me.cbUF.TabIndex = 51
        Me.cbUF.Text = "UF"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(137, 108)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(21, 13)
        Me.Label8.TabIndex = 52
        Me.Label8.Text = "UF"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 108)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 13)
        Me.Label7.TabIndex = 50
        Me.Label7.Text = "Orgão emissor"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Orange
        Me.TextBox1.Location = New System.Drawing.Point(11, 123)
        Me.TextBox1.MaxLength = 9
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(123, 21)
        Me.TextBox1.TabIndex = 49
        '
        'cbCBO
        '
        Me.cbCBO.FormattingEnabled = True
        Me.cbCBO.Location = New System.Drawing.Point(99, 84)
        Me.cbCBO.Name = "cbCBO"
        Me.cbCBO.Size = New System.Drawing.Size(229, 21)
        Me.cbCBO.TabIndex = 47
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(96, 69)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "CBO"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(9, 69)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(36, 13)
        Me.Label27.TabIndex = 46
        Me.Label27.Text = "CNES"
        '
        'tbCNES
        '
        Me.tbCNES.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.tbCNES.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbCNES.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCNES.ForeColor = System.Drawing.Color.Orange
        Me.tbCNES.Location = New System.Drawing.Point(12, 84)
        Me.tbCNES.MaxLength = 9
        Me.tbCNES.Name = "tbCNES"
        Me.tbCNES.ReadOnly = True
        Me.tbCNES.Size = New System.Drawing.Size(83, 21)
        Me.tbCNES.TabIndex = 45
        '
        'cbEstabelecimento
        '
        Me.cbEstabelecimento.FormattingEnabled = True
        Me.cbEstabelecimento.Location = New System.Drawing.Point(12, 45)
        Me.cbEstabelecimento.Name = "cbEstabelecimento"
        Me.cbEstabelecimento.Size = New System.Drawing.Size(316, 21)
        Me.cbEstabelecimento.TabIndex = 43
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "Estabelecimento"
        '
        'cbFormaContratoEstabCadastro
        '
        Me.cbFormaContratoEstabCadastro.FormattingEnabled = True
        Me.cbFormaContratoEstabCadastro.Location = New System.Drawing.Point(351, 45)
        Me.cbFormaContratoEstabCadastro.Name = "cbFormaContratoEstabCadastro"
        Me.cbFormaContratoEstabCadastro.Size = New System.Drawing.Size(316, 21)
        Me.cbFormaContratoEstabCadastro.TabIndex = 37
        '
        'Label252
        '
        Me.Label252.AutoSize = True
        Me.Label252.Location = New System.Drawing.Point(348, 29)
        Me.Label252.Name = "Label252"
        Me.Label252.Size = New System.Drawing.Size(214, 13)
        Me.Label252.TabIndex = 38
        Me.Label252.Text = "Forma de contratação com estabelecimento"
        '
        'cbcbFormaContratoEmpregCadastro
        '
        Me.cbcbFormaContratoEmpregCadastro.FormattingEnabled = True
        Me.cbcbFormaContratoEmpregCadastro.Location = New System.Drawing.Point(351, 85)
        Me.cbcbFormaContratoEmpregCadastro.Name = "cbcbFormaContratoEmpregCadastro"
        Me.cbcbFormaContratoEmpregCadastro.Size = New System.Drawing.Size(315, 21)
        Me.cbcbFormaContratoEmpregCadastro.TabIndex = 39
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(348, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(193, 13)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Forma de contratação com empregador"
        '
        'dgvProfissionais
        '
        Me.dgvProfissionais.AllowUserToAddRows = False
        Me.dgvProfissionais.AllowUserToDeleteRows = False
        Me.dgvProfissionais.AllowUserToOrderColumns = True
        Me.dgvProfissionais.AllowUserToResizeRows = False
        Me.dgvProfissionais.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvProfissionais.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.dgvProfissionais.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvProfissionais.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProfissionais.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvProfissionais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.OrangeRed
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProfissionais.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvProfissionais.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.dgvProfissionais.Location = New System.Drawing.Point(12, 457)
        Me.dgvProfissionais.MultiSelect = False
        Me.dgvProfissionais.Name = "dgvProfissionais"
        Me.dgvProfissionais.ReadOnly = True
        Me.dgvProfissionais.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProfissionais.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvProfissionais.RowHeadersWidth = 4
        Me.dgvProfissionais.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvProfissionais.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProfissionais.Size = New System.Drawing.Size(682, 136)
        Me.dgvProfissionais.TabIndex = 65
        Me.dgvProfissionais.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Location = New System.Drawing.Point(351, 192)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(331, 151)
        Me.GroupBox4.TabIndex = 143
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Equipes"
        '
        'btExcluir
        '
        Me.btExcluir.BackColor = System.Drawing.Color.IndianRed
        Me.btExcluir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btExcluir.FlatAppearance.BorderSize = 0
        Me.btExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btExcluir.ForeColor = System.Drawing.Color.White
        Me.btExcluir.Location = New System.Drawing.Point(239, 59)
        Me.btExcluir.Name = "btExcluir"
        Me.btExcluir.Size = New System.Drawing.Size(75, 23)
        Me.btExcluir.TabIndex = 146
        Me.btExcluir.Text = "Excluir"
        Me.btExcluir.UseVisualStyleBackColor = False
        '
        'btAtualizar
        '
        Me.btAtualizar.BackColor = System.Drawing.Color.Orange
        Me.btAtualizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btAtualizar.FlatAppearance.BorderSize = 0
        Me.btAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btAtualizar.ForeColor = System.Drawing.Color.White
        Me.btAtualizar.Location = New System.Drawing.Point(163, 59)
        Me.btAtualizar.Name = "btAtualizar"
        Me.btAtualizar.Size = New System.Drawing.Size(75, 23)
        Me.btAtualizar.TabIndex = 145
        Me.btAtualizar.Text = "Atualizar"
        Me.btAtualizar.UseVisualStyleBackColor = False
        '
        'btNovo
        '
        Me.btNovo.BackColor = System.Drawing.Color.SteelBlue
        Me.btNovo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btNovo.FlatAppearance.BorderSize = 0
        Me.btNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btNovo.ForeColor = System.Drawing.Color.White
        Me.btNovo.Location = New System.Drawing.Point(16, 59)
        Me.btNovo.Name = "btNovo"
        Me.btNovo.Size = New System.Drawing.Size(70, 23)
        Me.btNovo.TabIndex = 0
        Me.btNovo.Text = "Novo"
        Me.btNovo.UseVisualStyleBackColor = False
        '
        'btSalvar
        '
        Me.btSalvar.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.btSalvar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btSalvar.Enabled = False
        Me.btSalvar.FlatAppearance.BorderSize = 0
        Me.btSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btSalvar.ForeColor = System.Drawing.Color.White
        Me.btSalvar.Location = New System.Drawing.Point(87, 59)
        Me.btSalvar.Name = "btSalvar"
        Me.btSalvar.Size = New System.Drawing.Size(75, 23)
        Me.btSalvar.TabIndex = 147
        Me.btSalvar.Text = "Salvar"
        Me.btSalvar.UseVisualStyleBackColor = False
        '
        'dgvVinculos
        '
        Me.dgvVinculos.AllowUserToAddRows = False
        Me.dgvVinculos.AllowUserToDeleteRows = False
        Me.dgvVinculos.AllowUserToOrderColumns = True
        Me.dgvVinculos.AllowUserToResizeRows = False
        Me.dgvVinculos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvVinculos.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.dgvVinculos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvVinculos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVinculos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvVinculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.OrangeRed
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvVinculos.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvVinculos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.dgvVinculos.Location = New System.Drawing.Point(11, 192)
        Me.dgvVinculos.MultiSelect = False
        Me.dgvVinculos.Name = "dgvVinculos"
        Me.dgvVinculos.ReadOnly = True
        Me.dgvVinculos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVinculos.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvVinculos.RowHeadersWidth = 4
        Me.dgvVinculos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvVinculos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvVinculos.Size = New System.Drawing.Size(329, 111)
        Me.dgvVinculos.TabIndex = 148
        Me.dgvVinculos.TabStop = False
        '
        'FormCNESCadastro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(706, 605)
        Me.Controls.Add(Me.dgvProfissionais)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FormCNESCadastro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Profissionais"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.nudOutro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudHosp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAmb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvProfissionais, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvVinculos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TextBoxCPFCadastro As MaskedTextBox
    Friend WithEvents TextBoxNomeCadastro As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btConsultaCADSUS As Button
    Friend WithEvents dtNascimento As MaskedTextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents txtCnsCadastro As MaskedTextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cbFormaContratoEstabCadastro As ComboBox
    Friend WithEvents Label252 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cbcbFormaContratoEmpregCadastro As ComboBox
    Friend WithEvents cbDetalhamentoCadastro As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cbEstabelecimento As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents tbCNES As TextBox
    Friend WithEvents cbCBO As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cbUF As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents tbConselho As TextBox
    Friend WithEvents nudOutro As NumericUpDown
    Friend WithEvents Label11 As Label
    Friend WithEvents nudHosp As NumericUpDown
    Friend WithEvents Label10 As Label
    Friend WithEvents nudAmb As NumericUpDown
    Friend WithEvents Label43 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents rbSUSSim As RadioButton
    Friend WithEvents rbSUSNao As RadioButton
    Friend WithEvents dgvProfissionais As DataGridView
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label12 As Label
    Friend WithEvents btSalvarVinculo As Button
    Friend WithEvents btExcluir As Button
    Friend WithEvents btAtualizar As Button
    Friend WithEvents btNovo As Button
    Friend WithEvents tbCNPJContratador As MaskedTextBox
    Friend WithEvents btSalvar As Button
    Friend WithEvents btAtualizarVinculo As Button
    Friend WithEvents btExcluirVinculo As Button
    Friend WithEvents dgvVinculos As DataGridView
End Class
