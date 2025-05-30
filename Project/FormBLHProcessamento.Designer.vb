<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormBLHProcessamento
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBLHProcessamento))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbOrigem = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.tbBuscaDN = New System.Windows.Forms.MaskedTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tbBuscaDoadora = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dgLeite = New System.Windows.Forms.DataGridView()
        Me.btCancelar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.gbMotivos = New System.Windows.Forms.GroupBox()
        Me.cbExamesVencidos = New System.Windows.Forms.CheckBox()
        Me.cbEmbalagem = New System.Windows.Forms.CheckBox()
        Me.cbRefrigeracao = New System.Windows.Forms.CheckBox()
        Me.cbVencidos15dias = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbNaoConforme = New System.Windows.Forms.RadioButton()
        Me.rbConforme = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbTipoLeite = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbVolume = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbDataOrdenha = New System.Windows.Forms.MaskedTextBox()
        Me.cbParto = New System.Windows.Forms.ComboBox()
        Me.cbDoadoras = New System.Windows.Forms.ComboBox()
        Me.btSalvarDoadora = New System.Windows.Forms.Button()
        Me.btExcluirLeite = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dgSelecaoLeite = New System.Windows.Forms.DataGridView()
        Me.tbDataFin = New System.Windows.Forms.DateTimePicker()
        Me.tbDataIni = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.FlowSelecionados = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tbDataPasteu = New System.Windows.Forms.DateTimePicker()
        Me.btSalvarSelecionados = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgLeite, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.gbMotivos.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.tbVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgSelecaoLeite, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(434, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Data do parto* "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(553, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Origem*"
        '
        'cbOrigem
        '
        Me.cbOrigem.FormattingEnabled = True
        Me.cbOrigem.Items.AddRange(New Object() {"HRI", "CASA", "CESCRIM", "PG", "ITANHAÉM"})
        Me.cbOrigem.Location = New System.Drawing.Point(556, 31)
        Me.cbOrigem.Name = "cbOrigem"
        Me.cbOrigem.Size = New System.Drawing.Size(222, 21)
        Me.cbOrigem.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Doadora*"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.HotTrack = True
        Me.TabControl1.Location = New System.Drawing.Point(12, 7)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(805, 534)
        Me.TabControl1.TabIndex = 22
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.dgLeite)
        Me.TabPage1.Controls.Add(Me.btCancelar)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.cbParto)
        Me.TabPage1.Controls.Add(Me.cbDoadoras)
        Me.TabPage1.Controls.Add(Me.btSalvarDoadora)
        Me.TabPage1.Controls.Add(Me.btExcluirLeite)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.cbOrigem)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(797, 508)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Cadastro"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.tbBuscaDN)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.tbBuscaDoadora)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Location = New System.Drawing.Point(4, 216)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(788, 48)
        Me.GroupBox3.TabIndex = 35
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Pesquisar leites cadastrados"
        '
        'tbBuscaDN
        '
        Me.tbBuscaDN.Location = New System.Drawing.Point(378, 25)
        Me.tbBuscaDN.Mask = "00/00/0000"
        Me.tbBuscaDN.Name = "tbBuscaDN"
        Me.tbBuscaDN.Size = New System.Drawing.Size(65, 20)
        Me.tbBuscaDN.TabIndex = 35
        Me.tbBuscaDN.ValidatingType = GetType(Date)
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(352, 28)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(26, 13)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "DN:"
        '
        'tbBuscaDoadora
        '
        Me.tbBuscaDoadora.Location = New System.Drawing.Point(58, 25)
        Me.tbBuscaDoadora.Name = "tbBuscaDoadora"
        Me.tbBuscaDoadora.Size = New System.Drawing.Size(288, 20)
        Me.tbBuscaDoadora.TabIndex = 32
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 28)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 13)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "Doadora:"
        '
        'dgLeite
        '
        Me.dgLeite.AllowUserToAddRows = False
        Me.dgLeite.AllowUserToDeleteRows = False
        Me.dgLeite.AllowUserToOrderColumns = True
        Me.dgLeite.AllowUserToResizeRows = False
        Me.dgLeite.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgLeite.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgLeite.BackgroundColor = System.Drawing.Color.White
        Me.dgLeite.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgLeite.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgLeite.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgLeite.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgLeite.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgLeite.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.dgLeite.Location = New System.Drawing.Point(4, 264)
        Me.dgLeite.MultiSelect = False
        Me.dgLeite.Name = "dgLeite"
        Me.dgLeite.ReadOnly = True
        Me.dgLeite.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgLeite.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgLeite.RowHeadersWidth = 4
        Me.dgLeite.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgLeite.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgLeite.Size = New System.Drawing.Size(788, 209)
        Me.dgLeite.TabIndex = 32
        Me.dgLeite.TabStop = False
        '
        'btCancelar
        '
        Me.btCancelar.BackColor = System.Drawing.Color.Chocolate
        Me.btCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btCancelar.FlatAppearance.BorderSize = 0
        Me.btCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btCancelar.ForeColor = System.Drawing.Color.White
        Me.btCancelar.Location = New System.Drawing.Point(156, 478)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btCancelar.TabIndex = 30
        Me.btCancelar.Text = "Cancelar"
        Me.btCancelar.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.gbMotivos)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cbTipoLeite)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.tbVolume)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.tbDataOrdenha)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 61)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(776, 151)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Dados do leite"
        '
        'gbMotivos
        '
        Me.gbMotivos.Controls.Add(Me.cbExamesVencidos)
        Me.gbMotivos.Controls.Add(Me.cbEmbalagem)
        Me.gbMotivos.Controls.Add(Me.cbRefrigeracao)
        Me.gbMotivos.Controls.Add(Me.cbVencidos15dias)
        Me.gbMotivos.Enabled = False
        Me.gbMotivos.Location = New System.Drawing.Point(329, 31)
        Me.gbMotivos.Name = "gbMotivos"
        Me.gbMotivos.Size = New System.Drawing.Size(320, 114)
        Me.gbMotivos.TabIndex = 2
        Me.gbMotivos.TabStop = False
        Me.gbMotivos.Text = "Motivos"
        '
        'cbExamesVencidos
        '
        Me.cbExamesVencidos.AutoSize = True
        Me.cbExamesVencidos.Location = New System.Drawing.Point(203, 70)
        Me.cbExamesVencidos.Name = "cbExamesVencidos"
        Me.cbExamesVencidos.Size = New System.Drawing.Size(109, 17)
        Me.cbExamesVencidos.TabIndex = 3
        Me.cbExamesVencidos.Text = "Exames vencidos"
        Me.cbExamesVencidos.UseVisualStyleBackColor = True
        '
        'cbEmbalagem
        '
        Me.cbEmbalagem.AutoSize = True
        Me.cbEmbalagem.Location = New System.Drawing.Point(203, 34)
        Me.cbEmbalagem.Name = "cbEmbalagem"
        Me.cbEmbalagem.Size = New System.Drawing.Size(81, 17)
        Me.cbEmbalagem.TabIndex = 2
        Me.cbEmbalagem.Text = "Embalagem"
        Me.cbEmbalagem.UseVisualStyleBackColor = True
        '
        'cbRefrigeracao
        '
        Me.cbRefrigeracao.AutoSize = True
        Me.cbRefrigeracao.Location = New System.Drawing.Point(19, 70)
        Me.cbRefrigeracao.Name = "cbRefrigeracao"
        Me.cbRefrigeracao.Size = New System.Drawing.Size(149, 17)
        Me.cbRefrigeracao.TabIndex = 1
        Me.cbRefrigeracao.Text = "Problemas de refrigeração"
        Me.cbRefrigeracao.UseVisualStyleBackColor = True
        '
        'cbVencidos15dias
        '
        Me.cbVencidos15dias.AutoSize = True
        Me.cbVencidos15dias.Location = New System.Drawing.Point(19, 34)
        Me.cbVencidos15dias.Name = "cbVencidos15dias"
        Me.cbVencidos15dias.Size = New System.Drawing.Size(168, 17)
        Me.cbVencidos15dias.TabIndex = 0
        Me.cbVencidos15dias.Text = "Vencimento superior a 15 dias"
        Me.cbVencidos15dias.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbNaoConforme)
        Me.GroupBox2.Controls.Add(Me.rbConforme)
        Me.GroupBox2.Location = New System.Drawing.Point(183, 31)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(140, 114)
        Me.GroupBox2.TabIndex = 31
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Criterios de conformidade"
        '
        'rbNaoConforme
        '
        Me.rbNaoConforme.AutoSize = True
        Me.rbNaoConforme.Location = New System.Drawing.Point(24, 70)
        Me.rbNaoConforme.Name = "rbNaoConforme"
        Me.rbNaoConforme.Size = New System.Drawing.Size(92, 17)
        Me.rbNaoConforme.TabIndex = 1
        Me.rbNaoConforme.Text = "Não conforme"
        Me.rbNaoConforme.UseVisualStyleBackColor = True
        '
        'rbConforme
        '
        Me.rbConforme.AutoSize = True
        Me.rbConforme.Checked = True
        Me.rbConforme.Location = New System.Drawing.Point(24, 36)
        Me.rbConforme.Name = "rbConforme"
        Me.rbConforme.Size = New System.Drawing.Size(70, 17)
        Me.rbConforme.TabIndex = 0
        Me.rbConforme.TabStop = True
        Me.rbConforme.Text = "Conforme"
        Me.rbConforme.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 84)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 13)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Tipo do leite*"
        '
        'cbTipoLeite
        '
        Me.cbTipoLeite.FormattingEnabled = True
        Me.cbTipoLeite.Location = New System.Drawing.Point(16, 101)
        Me.cbTipoLeite.Name = "cbTipoLeite"
        Me.cbTipoLeite.Size = New System.Drawing.Size(161, 21)
        Me.cbTipoLeite.TabIndex = 29
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(101, 43)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "Volume*"
        '
        'tbVolume
        '
        Me.tbVolume.Location = New System.Drawing.Point(104, 60)
        Me.tbVolume.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.tbVolume.Name = "tbVolume"
        Me.tbVolume.Size = New System.Drawing.Size(73, 20)
        Me.tbVolume.TabIndex = 27
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 13)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Data ordenha*"
        '
        'tbDataOrdenha
        '
        Me.tbDataOrdenha.Location = New System.Drawing.Point(16, 59)
        Me.tbDataOrdenha.Mask = "00/00/0000"
        Me.tbDataOrdenha.Name = "tbDataOrdenha"
        Me.tbDataOrdenha.Size = New System.Drawing.Size(82, 20)
        Me.tbDataOrdenha.TabIndex = 25
        Me.tbDataOrdenha.ValidatingType = GetType(Date)
        '
        'cbParto
        '
        Me.cbParto.FormattingEnabled = True
        Me.cbParto.Location = New System.Drawing.Point(437, 31)
        Me.cbParto.Name = "cbParto"
        Me.cbParto.Size = New System.Drawing.Size(115, 21)
        Me.cbParto.TabIndex = 22
        '
        'cbDoadoras
        '
        Me.cbDoadoras.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbDoadoras.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbDoadoras.FormattingEnabled = True
        Me.cbDoadoras.Location = New System.Drawing.Point(16, 31)
        Me.cbDoadoras.Name = "cbDoadoras"
        Me.cbDoadoras.Size = New System.Drawing.Size(417, 21)
        Me.cbDoadoras.TabIndex = 21
        '
        'btSalvarDoadora
        '
        Me.btSalvarDoadora.BackColor = System.Drawing.Color.ForestGreen
        Me.btSalvarDoadora.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btSalvarDoadora.FlatAppearance.BorderSize = 0
        Me.btSalvarDoadora.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btSalvarDoadora.ForeColor = System.Drawing.Color.White
        Me.btSalvarDoadora.Location = New System.Drawing.Point(4, 478)
        Me.btSalvarDoadora.Name = "btSalvarDoadora"
        Me.btSalvarDoadora.Size = New System.Drawing.Size(75, 23)
        Me.btSalvarDoadora.TabIndex = 26
        Me.btSalvarDoadora.Text = "Salvar"
        Me.btSalvarDoadora.UseVisualStyleBackColor = False
        '
        'btExcluirLeite
        '
        Me.btExcluirLeite.BackColor = System.Drawing.Color.DarkRed
        Me.btExcluirLeite.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btExcluirLeite.Enabled = False
        Me.btExcluirLeite.FlatAppearance.BorderSize = 0
        Me.btExcluirLeite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btExcluirLeite.ForeColor = System.Drawing.Color.White
        Me.btExcluirLeite.Location = New System.Drawing.Point(80, 478)
        Me.btExcluirLeite.Name = "btExcluirLeite"
        Me.btExcluirLeite.Size = New System.Drawing.Size(75, 23)
        Me.btExcluirLeite.TabIndex = 28
        Me.btExcluirLeite.Text = "Excluir"
        Me.btExcluirLeite.UseVisualStyleBackColor = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TabPage2.Controls.Add(Me.GroupBox5)
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(797, 508)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Pasteurização"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.dgSelecaoLeite)
        Me.GroupBox5.Controls.Add(Me.tbDataFin)
        Me.GroupBox5.Controls.Add(Me.tbDataIni)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(495, 489)
        Me.GroupBox5.TabIndex = 38
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Selecionar para pasteurização"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(85, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Periodo ordenha"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(113, 47)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(13, 13)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "à"
        '
        'dgSelecaoLeite
        '
        Me.dgSelecaoLeite.AllowUserToAddRows = False
        Me.dgSelecaoLeite.AllowUserToDeleteRows = False
        Me.dgSelecaoLeite.AllowUserToOrderColumns = True
        Me.dgSelecaoLeite.AllowUserToResizeRows = False
        Me.dgSelecaoLeite.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgSelecaoLeite.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgSelecaoLeite.BackgroundColor = System.Drawing.Color.White
        Me.dgSelecaoLeite.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgSelecaoLeite.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSelecaoLeite.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgSelecaoLeite.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgSelecaoLeite.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgSelecaoLeite.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.dgSelecaoLeite.Location = New System.Drawing.Point(9, 67)
        Me.dgSelecaoLeite.MultiSelect = False
        Me.dgSelecaoLeite.Name = "dgSelecaoLeite"
        Me.dgSelecaoLeite.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSelecaoLeite.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgSelecaoLeite.RowHeadersWidth = 4
        Me.dgSelecaoLeite.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgSelecaoLeite.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSelecaoLeite.Size = New System.Drawing.Size(480, 422)
        Me.dgSelecaoLeite.TabIndex = 2
        '
        'tbDataFin
        '
        Me.tbDataFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.tbDataFin.Location = New System.Drawing.Point(132, 41)
        Me.tbDataFin.Name = "tbDataFin"
        Me.tbDataFin.Size = New System.Drawing.Size(98, 20)
        Me.tbDataFin.TabIndex = 1
        '
        'tbDataIni
        '
        Me.tbDataIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.tbDataIni.Location = New System.Drawing.Point(9, 41)
        Me.tbDataIni.Name = "tbDataIni"
        Me.tbDataIni.Size = New System.Drawing.Size(98, 20)
        Me.tbDataIni.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.FlowSelecionados)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.tbDataPasteu)
        Me.GroupBox4.Controls.Add(Me.btSalvarSelecionados)
        Me.GroupBox4.Location = New System.Drawing.Point(507, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(284, 489)
        Me.GroupBox4.TabIndex = 37
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Detalhes da pasteurização"
        '
        'FlowSelecionados
        '
        Me.FlowSelecionados.Location = New System.Drawing.Point(11, 67)
        Me.FlowSelecionados.Name = "FlowSelecionados"
        Me.FlowSelecionados.Size = New System.Drawing.Size(267, 387)
        Me.FlowSelecionados.TabIndex = 6
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(8, 25)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(33, 13)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "Data "
        '
        'tbDataPasteu
        '
        Me.tbDataPasteu.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.tbDataPasteu.Location = New System.Drawing.Point(11, 41)
        Me.tbDataPasteu.Name = "tbDataPasteu"
        Me.tbDataPasteu.Size = New System.Drawing.Size(99, 20)
        Me.tbDataPasteu.TabIndex = 4
        '
        'btSalvarSelecionados
        '
        Me.btSalvarSelecionados.BackColor = System.Drawing.Color.ForestGreen
        Me.btSalvarSelecionados.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btSalvarSelecionados.Enabled = False
        Me.btSalvarSelecionados.FlatAppearance.BorderSize = 0
        Me.btSalvarSelecionados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btSalvarSelecionados.ForeColor = System.Drawing.Color.White
        Me.btSalvarSelecionados.Location = New System.Drawing.Point(6, 460)
        Me.btSalvarSelecionados.Name = "btSalvarSelecionados"
        Me.btSalvarSelecionados.Size = New System.Drawing.Size(117, 23)
        Me.btSalvarSelecionados.TabIndex = 3
        Me.btSalvarSelecionados.Text = "Salvar pasteurização"
        Me.btSalvarSelecionados.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Black
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(784, 545)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(33, 23)
        Me.Button4.TabIndex = 29
        Me.Button4.Text = "Sair"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'FormBLHProcessamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(829, 574)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormBLHProcessamento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleção LHOC"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgLeite, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbMotivos.ResumeLayout(False)
        Me.gbMotivos.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.tbVolume, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.dgSelecaoLeite, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cbOrigem As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents cbDoadoras As ComboBox
    Friend WithEvents cbParto As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents tbDataOrdenha As MaskedTextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents tbVolume As NumericUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents cbTipoLeite As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rbNaoConforme As RadioButton
    Friend WithEvents rbConforme As RadioButton
    Friend WithEvents gbMotivos As GroupBox
    Friend WithEvents cbExamesVencidos As CheckBox
    Friend WithEvents cbEmbalagem As CheckBox
    Friend WithEvents cbRefrigeracao As CheckBox
    Friend WithEvents cbVencidos15dias As CheckBox
    Friend WithEvents btCancelar As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents btSalvarDoadora As Button
    Friend WithEvents btExcluirLeite As Button
    Friend WithEvents dgLeite As DataGridView
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents tbBuscaDoadora As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents tbBuscaDN As MaskedTextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents dgSelecaoLeite As DataGridView
    Friend WithEvents tbDataFin As DateTimePicker
    Friend WithEvents tbDataIni As DateTimePicker
    Friend WithEvents btSalvarSelecionados As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Label14 As Label
    Friend WithEvents tbDataPasteu As DateTimePicker
    Friend WithEvents FlowSelecionados As FlowLayoutPanel
End Class
