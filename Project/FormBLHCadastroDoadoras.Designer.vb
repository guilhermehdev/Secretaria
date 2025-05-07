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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBLHCadastroDoadoras))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
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
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbBusca = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cbPartos = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbBuscaDN = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbNovoParto = New System.Windows.Forms.MaskedTextBox()
        Me.btExcluirParto = New System.Windows.Forms.Button()
        Me.btNovoParto = New System.Windows.Forms.Button()
        Me.tbNasc = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgDoadoras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
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
        Me.GroupBox1.Location = New System.Drawing.Point(12, 280)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(405, 208)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Dados doadora"
        '
        'tbDataCadastro
        '
        Me.tbDataCadastro.AllowPromptAsInput = False
        Me.tbDataCadastro.CausesValidation = False
        Me.tbDataCadastro.Cursor = System.Windows.Forms.Cursors.Default
        Me.tbDataCadastro.Location = New System.Drawing.Point(334, 42)
        Me.tbDataCadastro.Mask = "00/00/0000"
        Me.tbDataCadastro.Name = "tbDataCadastro"
        Me.tbDataCadastro.ReadOnly = True
        Me.tbDataCadastro.Size = New System.Drawing.Size(65, 20)
        Me.tbDataCadastro.TabIndex = 1
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
        Me.dgDoadoras.Location = New System.Drawing.Point(6, 53)
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
        Me.dgDoadoras.Size = New System.Drawing.Size(393, 211)
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
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(405, 270)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Doadoras cadastradas"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Nome:"
        '
        'tbBusca
        '
        Me.tbBusca.Location = New System.Drawing.Point(44, 29)
        Me.tbBusca.Name = "tbBusca"
        Me.tbBusca.Size = New System.Drawing.Size(258, 20)
        Me.tbBusca.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 490)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(429, 22)
        Me.StatusStrip1.TabIndex = 36
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(67, 17)
        Me.ToolStripStatusLabel1.Text = "N Registros"
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
        'cbPartos
        '
        Me.cbPartos.FormattingEnabled = True
        Me.cbPartos.Location = New System.Drawing.Point(9, 29)
        Me.cbPartos.Name = "cbPartos"
        Me.cbPartos.Size = New System.Drawing.Size(84, 21)
        Me.cbPartos.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(308, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "DN:"
        '
        'tbBuscaDN
        '
        Me.tbBuscaDN.Location = New System.Drawing.Point(334, 29)
        Me.tbBuscaDN.Mask = "00/00/0000"
        Me.tbBuscaDN.Name = "tbBuscaDN"
        Me.tbBuscaDN.Size = New System.Drawing.Size(65, 20)
        Me.tbBuscaDN.TabIndex = 1
        Me.tbBuscaDN.ValidatingType = GetType(Date)
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
        'tbNovoParto
        '
        Me.tbNovoParto.Location = New System.Drawing.Point(9, 69)
        Me.tbNovoParto.Mask = "00/00/0000"
        Me.tbNovoParto.Name = "tbNovoParto"
        Me.tbNovoParto.Size = New System.Drawing.Size(84, 20)
        Me.tbNovoParto.TabIndex = 2
        Me.tbNovoParto.ValidatingType = GetType(Date)
        '
        'btExcluirParto
        '
        Me.btExcluirParto.BackColor = System.Drawing.Color.DarkRed
        Me.btExcluirParto.Cursor = System.Windows.Forms.Cursors.Hand
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
        'btNovoParto
        '
        Me.btNovoParto.BackColor = System.Drawing.Color.ForestGreen
        Me.btNovoParto.Cursor = System.Windows.Forms.Cursors.Hand
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
        'tbNasc
        '
        Me.tbNasc.Location = New System.Drawing.Point(266, 42)
        Me.tbNasc.Mask = "00/00/0000"
        Me.tbNasc.Name = "tbNasc"
        Me.tbNasc.ReadOnly = True
        Me.tbNasc.Size = New System.Drawing.Size(65, 20)
        Me.tbNasc.TabIndex = 16
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
        'FormBLHCadastroDoadoras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(429, 512)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormBLHCadastroDoadoras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BLH - Cadastro de doadoras"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgDoadoras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
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
End Class
