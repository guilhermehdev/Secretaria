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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbResultado = New System.Windows.Forms.ComboBox()
        Me.tbDataVencimento = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbDataSorologia = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbOrigem = New System.Windows.Forms.ComboBox()
        Me.tbDataParto = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbNome = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgDoadoras = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btExcluirDoadora = New System.Windows.Forms.Button()
        Me.btAtualizarDoadora = New System.Windows.Forms.Button()
        Me.btSalvarDoadora = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbOBS = New System.Windows.Forms.TextBox()
        Me.tbBusca = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgDoadoras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tbOBS)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.btSalvarDoadora)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.btAtualizarDoadora)
        Me.GroupBox1.Controls.Add(Me.btExcluirDoadora)
        Me.GroupBox1.Controls.Add(Me.cbResultado)
        Me.GroupBox1.Controls.Add(Me.tbDataVencimento)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.tbDataSorologia)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbOrigem)
        Me.GroupBox1.Controls.Add(Me.tbDataParto)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.tbNome)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 280)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(349, 208)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Dados doadora"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(225, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Resultado"
        '
        'cbResultado
        '
        Me.cbResultado.FormattingEnabled = True
        Me.cbResultado.Items.AddRange(New Object() {"REGULAR", "VENCIDO"})
        Me.cbResultado.Location = New System.Drawing.Point(228, 80)
        Me.cbResultado.Name = "cbResultado"
        Me.cbResultado.Size = New System.Drawing.Size(103, 21)
        Me.cbResultado.TabIndex = 5
        '
        'tbDataVencimento
        '
        Me.tbDataVencimento.Location = New System.Drawing.Point(18, 120)
        Me.tbDataVencimento.Mask = "00/00/0000"
        Me.tbDataVencimento.Name = "tbDataVencimento"
        Me.tbDataVencimento.Size = New System.Drawing.Size(85, 20)
        Me.tbDataVencimento.TabIndex = 6
        Me.tbDataVencimento.ValidatingType = GetType(Date)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Vencimento"
        '
        'tbDataSorologia
        '
        Me.tbDataSorologia.Location = New System.Drawing.Point(145, 81)
        Me.tbDataSorologia.Mask = "00/00/0000"
        Me.tbDataSorologia.Name = "tbDataSorologia"
        Me.tbDataSorologia.Size = New System.Drawing.Size(78, 20)
        Me.tbDataSorologia.TabIndex = 4
        Me.tbDataSorologia.ValidatingType = GetType(Date)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(142, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Data sorologia"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Origem"
        '
        'cbOrigem
        '
        Me.cbOrigem.FormattingEnabled = True
        Me.cbOrigem.Items.AddRange(New Object() {"HRI", "CASA", "CESCRIM", "PG", "ITANHAÉM"})
        Me.cbOrigem.Location = New System.Drawing.Point(18, 80)
        Me.cbOrigem.Name = "cbOrigem"
        Me.cbOrigem.Size = New System.Drawing.Size(121, 21)
        Me.cbOrigem.TabIndex = 3
        '
        'tbDataParto
        '
        Me.tbDataParto.Location = New System.Drawing.Point(253, 42)
        Me.tbDataParto.Mask = "00/00/0000"
        Me.tbDataParto.Name = "tbDataParto"
        Me.tbDataParto.Size = New System.Drawing.Size(78, 20)
        Me.tbDataParto.TabIndex = 2
        Me.tbDataParto.ValidatingType = GetType(Date)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(250, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Data do parto"
        '
        'tbNome
        '
        Me.tbNome.Location = New System.Drawing.Point(18, 42)
        Me.tbNome.Name = "tbNome"
        Me.tbNome.Size = New System.Drawing.Size(229, 20)
        Me.tbNome.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nome"
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
        Me.dgDoadoras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
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
        Me.dgDoadoras.Size = New System.Drawing.Size(337, 211)
        Me.dgDoadoras.TabIndex = 0
        Me.dgDoadoras.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.tbBusca)
        Me.GroupBox2.Controls.Add(Me.dgDoadoras)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(349, 270)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Doadoras cadastradas"
        '
        'btExcluirDoadora
        '
        Me.btExcluirDoadora.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btExcluirDoadora.Location = New System.Drawing.Point(256, 173)
        Me.btExcluirDoadora.Name = "btExcluirDoadora"
        Me.btExcluirDoadora.Size = New System.Drawing.Size(75, 23)
        Me.btExcluirDoadora.TabIndex = 3
        Me.btExcluirDoadora.Text = "Excluir"
        Me.btExcluirDoadora.UseVisualStyleBackColor = True
        '
        'btAtualizarDoadora
        '
        Me.btAtualizarDoadora.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btAtualizarDoadora.Location = New System.Drawing.Point(175, 173)
        Me.btAtualizarDoadora.Name = "btAtualizarDoadora"
        Me.btAtualizarDoadora.Size = New System.Drawing.Size(75, 23)
        Me.btAtualizarDoadora.TabIndex = 2
        Me.btAtualizarDoadora.Text = "Atualizar"
        Me.btAtualizarDoadora.UseVisualStyleBackColor = True
        '
        'btSalvarDoadora
        '
        Me.btSalvarDoadora.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btSalvarDoadora.Location = New System.Drawing.Point(94, 173)
        Me.btSalvarDoadora.Name = "btSalvarDoadora"
        Me.btSalvarDoadora.Size = New System.Drawing.Size(75, 23)
        Me.btSalvarDoadora.TabIndex = 1
        Me.btSalvarDoadora.Text = "Salvar"
        Me.btSalvarDoadora.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 520)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(374, 22)
        Me.StatusStrip1.TabIndex = 36
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(119, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(286, 493)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "Fechar"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(106, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Obs."
        '
        'tbOBS
        '
        Me.tbOBS.Location = New System.Drawing.Point(109, 120)
        Me.tbOBS.Multiline = True
        Me.tbOBS.Name = "tbOBS"
        Me.tbOBS.Size = New System.Drawing.Size(222, 47)
        Me.tbOBS.TabIndex = 7
        '
        'tbBusca
        '
        Me.tbBusca.Location = New System.Drawing.Point(49, 29)
        Me.tbBusca.Name = "tbBusca"
        Me.tbBusca.Size = New System.Drawing.Size(294, 20)
        Me.tbBusca.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Busca:"
        '
        'FormBLHCadastroDoadoras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(374, 542)
        Me.Controls.Add(Me.Button4)
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents tbNome As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tbDataParto As MaskedTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cbOrigem As ComboBox
    Friend WithEvents tbDataVencimento As MaskedTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents tbDataSorologia As MaskedTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cbResultado As ComboBox
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
End Class
