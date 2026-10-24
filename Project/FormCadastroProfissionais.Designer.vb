<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAMECadastroProfissionais
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAMECadastroProfissionais))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbNomeProfissional = New System.Windows.Forms.TextBox()
        Me.dtNascimentoprofissional = New System.Windows.Forms.MaskedTextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtCpfProfissional = New System.Windows.Forms.MaskedTextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtCnsProfissional = New System.Windows.Forms.MaskedTextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbCBO = New System.Windows.Forms.TextBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.cbNivelautorizador = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cbEspecialidades = New System.Windows.Forms.ComboBox()
        Me.btSalvarProfissional = New System.Windows.Forms.Button()
        Me.btAtualizarProfissional = New System.Windows.Forms.Button()
        Me.dgProfissionais = New System.Windows.Forms.DataGridView()
        Me.btFechar = New System.Windows.Forms.Button()
        Me.lbQtdRegistros = New System.Windows.Forms.Label()
        CType(Me.dgProfissionais, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 69
        Me.Label5.Text = "Nome"
        '
        'tbNomeProfissional
        '
        Me.tbNomeProfissional.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.tbNomeProfissional.ForeColor = System.Drawing.SystemColors.Info
        Me.tbNomeProfissional.Location = New System.Drawing.Point(15, 34)
        Me.tbNomeProfissional.MaxLength = 13
        Me.tbNomeProfissional.Name = "tbNomeProfissional"
        Me.tbNomeProfissional.Size = New System.Drawing.Size(308, 20)
        Me.tbNomeProfissional.TabIndex = 68
        '
        'dtNascimentoprofissional
        '
        Me.dtNascimentoprofissional.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.dtNascimentoprofissional.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtNascimentoprofissional.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtNascimentoprofissional.ForeColor = System.Drawing.SystemColors.Info
        Me.dtNascimentoprofissional.Location = New System.Drawing.Point(329, 34)
        Me.dtNascimentoprofissional.Mask = "00/00/0000"
        Me.dtNascimentoprofissional.Name = "dtNascimentoprofissional"
        Me.dtNascimentoprofissional.Size = New System.Drawing.Size(72, 21)
        Me.dtNascimentoprofissional.TabIndex = 70
        Me.dtNascimentoprofissional.ValidatingType = GetType(Date)
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(326, 19)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(63, 13)
        Me.Label25.TabIndex = 71
        Me.Label25.Text = "Nascimento"
        '
        'txtCpfProfissional
        '
        Me.txtCpfProfissional.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCpfProfissional.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCpfProfissional.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCpfProfissional.ForeColor = System.Drawing.SystemColors.Info
        Me.txtCpfProfissional.Location = New System.Drawing.Point(409, 34)
        Me.txtCpfProfissional.Mask = "99999999999"
        Me.txtCpfProfissional.Name = "txtCpfProfissional"
        Me.txtCpfProfissional.Size = New System.Drawing.Size(95, 21)
        Me.txtCpfProfissional.TabIndex = 72
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(407, 19)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(27, 13)
        Me.Label16.TabIndex = 73
        Me.Label16.Text = "CPF"
        '
        'txtCnsProfissional
        '
        Me.txtCnsProfissional.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCnsProfissional.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCnsProfissional.ForeColor = System.Drawing.SystemColors.Info
        Me.txtCnsProfissional.Location = New System.Drawing.Point(510, 34)
        Me.txtCnsProfissional.Mask = "9999,9999,9999,999"
        Me.txtCnsProfissional.Name = "txtCnsProfissional"
        Me.txtCnsProfissional.Size = New System.Drawing.Size(127, 21)
        Me.txtCnsProfissional.TabIndex = 75
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(508, 19)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(29, 13)
        Me.Label17.TabIndex = 74
        Me.Label17.Text = "CNS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 77
        Me.Label2.Text = "CBO"
        '
        'tbCBO
        '
        Me.tbCBO.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.tbCBO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbCBO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCBO.ForeColor = System.Drawing.SystemColors.Info
        Me.tbCBO.Location = New System.Drawing.Point(15, 73)
        Me.tbCBO.MaxLength = 13
        Me.tbCBO.Name = "tbCBO"
        Me.tbCBO.Size = New System.Drawing.Size(97, 21)
        Me.tbCBO.TabIndex = 76
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(326, 57)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(60, 13)
        Me.Label48.TabIndex = 78
        Me.Label48.Text = "Autorizador"
        '
        'cbNivelautorizador
        '
        Me.cbNivelautorizador.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cbNivelautorizador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbNivelautorizador.ForeColor = System.Drawing.Color.Orange
        Me.cbNivelautorizador.FormattingEnabled = True
        Me.cbNivelautorizador.Location = New System.Drawing.Point(329, 73)
        Me.cbNivelautorizador.Name = "cbNivelautorizador"
        Me.cbNivelautorizador.Size = New System.Drawing.Size(175, 21)
        Me.cbNivelautorizador.TabIndex = 79
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(114, 57)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(73, 13)
        Me.Label24.TabIndex = 80
        Me.Label24.Text = "Especialidade"
        '
        'cbEspecialidades
        '
        Me.cbEspecialidades.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cbEspecialidades.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEspecialidades.ForeColor = System.Drawing.SystemColors.Info
        Me.cbEspecialidades.FormattingEnabled = True
        Me.cbEspecialidades.Location = New System.Drawing.Point(117, 73)
        Me.cbEspecialidades.Name = "cbEspecialidades"
        Me.cbEspecialidades.Size = New System.Drawing.Size(203, 21)
        Me.cbEspecialidades.TabIndex = 81
        Me.cbEspecialidades.Tag = "ign"
        '
        'btSalvarProfissional
        '
        Me.btSalvarProfissional.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.btSalvarProfissional.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btSalvarProfissional.FlatAppearance.BorderSize = 0
        Me.btSalvarProfissional.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btSalvarProfissional.ForeColor = System.Drawing.Color.Transparent
        Me.btSalvarProfissional.Location = New System.Drawing.Point(511, 71)
        Me.btSalvarProfissional.Name = "btSalvarProfissional"
        Me.btSalvarProfissional.Size = New System.Drawing.Size(60, 22)
        Me.btSalvarProfissional.TabIndex = 82
        Me.btSalvarProfissional.Text = "Salvar"
        Me.btSalvarProfissional.UseVisualStyleBackColor = False
        '
        'btAtualizarProfissional
        '
        Me.btAtualizarProfissional.BackColor = System.Drawing.Color.Orange
        Me.btAtualizarProfissional.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btAtualizarProfissional.FlatAppearance.BorderSize = 0
        Me.btAtualizarProfissional.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btAtualizarProfissional.ForeColor = System.Drawing.Color.Transparent
        Me.btAtualizarProfissional.Location = New System.Drawing.Point(577, 71)
        Me.btAtualizarProfissional.Name = "btAtualizarProfissional"
        Me.btAtualizarProfissional.Size = New System.Drawing.Size(60, 22)
        Me.btAtualizarProfissional.TabIndex = 83
        Me.btAtualizarProfissional.Text = "Atualizar"
        Me.btAtualizarProfissional.UseVisualStyleBackColor = False
        '
        'dgProfissionais
        '
        Me.dgProfissionais.AllowUserToAddRows = False
        Me.dgProfissionais.AllowUserToDeleteRows = False
        Me.dgProfissionais.AllowUserToOrderColumns = True
        Me.dgProfissionais.AllowUserToResizeRows = False
        Me.dgProfissionais.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.dgProfissionais.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgProfissionais.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProfissionais.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgProfissionais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.OrangeRed
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgProfissionais.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgProfissionais.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.dgProfissionais.Location = New System.Drawing.Point(15, 100)
        Me.dgProfissionais.MultiSelect = False
        Me.dgProfissionais.Name = "dgProfissionais"
        Me.dgProfissionais.ReadOnly = True
        Me.dgProfissionais.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProfissionais.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgProfissionais.RowHeadersWidth = 4
        Me.dgProfissionais.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgProfissionais.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgProfissionais.Size = New System.Drawing.Size(622, 323)
        Me.dgProfissionais.TabIndex = 84
        Me.dgProfissionais.TabStop = False
        '
        'btFechar
        '
        Me.btFechar.BackColor = System.Drawing.Color.IndianRed
        Me.btFechar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btFechar.FlatAppearance.BorderSize = 0
        Me.btFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btFechar.ForeColor = System.Drawing.Color.Transparent
        Me.btFechar.Location = New System.Drawing.Point(577, 429)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(60, 22)
        Me.btFechar.TabIndex = 85
        Me.btFechar.Text = "Fechar"
        Me.btFechar.UseVisualStyleBackColor = False
        '
        'lbQtdRegistros
        '
        Me.lbQtdRegistros.AutoSize = True
        Me.lbQtdRegistros.Location = New System.Drawing.Point(12, 435)
        Me.lbQtdRegistros.Name = "lbQtdRegistros"
        Me.lbQtdRegistros.Size = New System.Drawing.Size(25, 13)
        Me.lbQtdRegistros.TabIndex = 86
        Me.lbQtdRegistros.Text = "000"
        '
        'FormAMECadastroProfissionais
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(653, 459)
        Me.Controls.Add(Me.lbQtdRegistros)
        Me.Controls.Add(Me.btFechar)
        Me.Controls.Add(Me.dgProfissionais)
        Me.Controls.Add(Me.btAtualizarProfissional)
        Me.Controls.Add(Me.btSalvarProfissional)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.cbEspecialidades)
        Me.Controls.Add(Me.Label48)
        Me.Controls.Add(Me.cbNivelautorizador)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbCBO)
        Me.Controls.Add(Me.txtCnsProfissional)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtCpfProfissional)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.dtNascimentoprofissional)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tbNomeProfissional)
        Me.ForeColor = System.Drawing.SystemColors.Info
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAMECadastroProfissionais"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro Profissionais"
        CType(Me.dgProfissionais, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label5 As Label
    Friend WithEvents tbNomeProfissional As TextBox
    Friend WithEvents dtNascimentoprofissional As MaskedTextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents txtCpfProfissional As MaskedTextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtCnsProfissional As MaskedTextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tbCBO As TextBox
    Friend WithEvents Label48 As Label
    Friend WithEvents cbNivelautorizador As ComboBox
    Friend WithEvents Label24 As Label
    Friend WithEvents cbEspecialidades As ComboBox
    Friend WithEvents btSalvarProfissional As Button
    Friend WithEvents btAtualizarProfissional As Button
    Friend WithEvents dgProfissionais As DataGridView
    Friend WithEvents btFechar As Button
    Friend WithEvents lbQtdRegistros As Label
End Class
