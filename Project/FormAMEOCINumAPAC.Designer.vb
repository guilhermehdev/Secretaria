<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAMEOCINumAPAC
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.tbFaixaInicio = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbFaixaFim = New System.Windows.Forms.TextBox()
        Me.numQtd = New System.Windows.Forms.NumericUpDown()
        Me.dgvNumerosAPAC = New System.Windows.Forms.DataGridView()
        Me.ctxMenuAPAC = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AlterarStatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbStatus = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbOCI = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpFim = New System.Windows.Forms.DateTimePicker()
        Me.dtpIni = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbUsuarios = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkDisponiveis = New System.Windows.Forms.CheckBox()
        Me.tbAPACFim = New System.Windows.Forms.TextBox()
        Me.tbAPACIni = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.statusLabelRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.CopiarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.numQtd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvNumerosAPAC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMenuAPAC.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(275, 35)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(115, 23)
        Me.Button2.TabIndex = 26
        Me.Button2.Text = "Gerar numeros APAC"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'tbFaixaInicio
        '
        Me.tbFaixaInicio.Location = New System.Drawing.Point(12, 37)
        Me.tbFaixaInicio.MaxLength = 13
        Me.tbFaixaInicio.Name = "tbFaixaInicio"
        Me.tbFaixaInicio.Size = New System.Drawing.Size(91, 20)
        Me.tbFaixaInicio.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Faixa inicio"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(106, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Faixa fim"
        '
        'tbFaixaFim
        '
        Me.tbFaixaFim.Location = New System.Drawing.Point(109, 37)
        Me.tbFaixaFim.MaxLength = 13
        Me.tbFaixaFim.Name = "tbFaixaFim"
        Me.tbFaixaFim.Size = New System.Drawing.Size(91, 20)
        Me.tbFaixaFim.TabIndex = 29
        '
        'numQtd
        '
        Me.numQtd.Location = New System.Drawing.Point(206, 37)
        Me.numQtd.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numQtd.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numQtd.Name = "numQtd"
        Me.numQtd.Size = New System.Drawing.Size(63, 20)
        Me.numQtd.TabIndex = 31
        Me.numQtd.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'dgvNumerosAPAC
        '
        Me.dgvNumerosAPAC.AllowUserToAddRows = False
        Me.dgvNumerosAPAC.AllowUserToDeleteRows = False
        Me.dgvNumerosAPAC.AllowUserToOrderColumns = True
        Me.dgvNumerosAPAC.AllowUserToResizeRows = False
        Me.dgvNumerosAPAC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvNumerosAPAC.BackgroundColor = System.Drawing.Color.White
        Me.dgvNumerosAPAC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvNumerosAPAC.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvNumerosAPAC.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvNumerosAPAC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNumerosAPAC.ContextMenuStrip = Me.ctxMenuAPAC
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvNumerosAPAC.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvNumerosAPAC.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.dgvNumerosAPAC.Location = New System.Drawing.Point(6, 66)
        Me.dgvNumerosAPAC.Name = "dgvNumerosAPAC"
        Me.dgvNumerosAPAC.ReadOnly = True
        Me.dgvNumerosAPAC.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvNumerosAPAC.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvNumerosAPAC.RowHeadersWidth = 4
        Me.dgvNumerosAPAC.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvNumerosAPAC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvNumerosAPAC.Size = New System.Drawing.Size(930, 357)
        Me.dgvNumerosAPAC.TabIndex = 33
        Me.dgvNumerosAPAC.TabStop = False
        '
        'ctxMenuAPAC
        '
        Me.ctxMenuAPAC.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AlterarStatusToolStripMenuItem, Me.CopiarToolStripMenuItem})
        Me.ctxMenuAPAC.Name = "ctxMenuAPAC"
        Me.ctxMenuAPAC.Size = New System.Drawing.Size(145, 48)
        '
        'AlterarStatusToolStripMenuItem
        '
        Me.AlterarStatusToolStripMenuItem.Name = "AlterarStatusToolStripMenuItem"
        Me.AlterarStatusToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.AlterarStatusToolStripMenuItem.Text = "Alterar Status"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.cbStatus)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cbOCI)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.dtpFim)
        Me.GroupBox1.Controls.Add(Me.dtpIni)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cbUsuarios)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.chkDisponiveis)
        Me.GroupBox1.Controls.Add(Me.tbAPACFim)
        Me.GroupBox1.Controls.Add(Me.tbAPACIni)
        Me.GroupBox1.Controls.Add(Me.dgvNumerosAPAC)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(942, 429)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Números gerados"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(857, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 13)
        Me.Label10.TabIndex = 48
        Me.Label10.Text = "Status"
        '
        'cbStatus
        '
        Me.cbStatus.FormattingEnabled = True
        Me.cbStatus.Items.AddRange(New Object() {"DISP", "CONC", "CANC", "BLOQ"})
        Me.cbStatus.Location = New System.Drawing.Point(860, 40)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Size = New System.Drawing.Size(76, 21)
        Me.cbStatus.TabIndex = 47
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(597, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(25, 13)
        Me.Label9.TabIndex = 46
        Me.Label9.Text = "OCI"
        '
        'cbOCI
        '
        Me.cbOCI.FormattingEnabled = True
        Me.cbOCI.Location = New System.Drawing.Point(600, 40)
        Me.cbOCI.Name = "cbOCI"
        Me.cbOCI.Size = New System.Drawing.Size(254, 21)
        Me.cbOCI.TabIndex = 45
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(422, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 44
        Me.Label8.Text = "Data"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(505, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(13, 13)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "à"
        '
        'dtpFim
        '
        Me.dtpFim.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFim.Location = New System.Drawing.Point(519, 40)
        Me.dtpFim.Name = "dtpFim"
        Me.dtpFim.Size = New System.Drawing.Size(78, 20)
        Me.dtpFim.TabIndex = 42
        '
        'dtpIni
        '
        Me.dtpIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpIni.Location = New System.Drawing.Point(425, 40)
        Me.dtpIni.Name = "dtpIni"
        Me.dtpIni.Size = New System.Drawing.Size(78, 20)
        Me.dtpIni.TabIndex = 41
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(284, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "Usuário"
        '
        'cbUsuarios
        '
        Me.cbUsuarios.FormattingEnabled = True
        Me.cbUsuarios.Location = New System.Drawing.Point(287, 40)
        Me.cbUsuarios.Name = "cbUsuarios"
        Me.cbUsuarios.Size = New System.Drawing.Size(135, 21)
        Me.cbUsuarios.TabIndex = 39
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(85, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "Intervalo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(180, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(13, 13)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "e"
        '
        'chkDisponiveis
        '
        Me.chkDisponiveis.AutoSize = True
        Me.chkDisponiveis.Location = New System.Drawing.Point(7, 42)
        Me.chkDisponiveis.Name = "chkDisponiveis"
        Me.chkDisponiveis.Size = New System.Drawing.Size(80, 17)
        Me.chkDisponiveis.TabIndex = 34
        Me.chkDisponiveis.Text = "Disponiveis"
        Me.chkDisponiveis.UseVisualStyleBackColor = True
        '
        'tbAPACFim
        '
        Me.tbAPACFim.Location = New System.Drawing.Point(193, 40)
        Me.tbAPACFim.MaxLength = 13
        Me.tbAPACFim.Name = "tbAPACFim"
        Me.tbAPACFim.Size = New System.Drawing.Size(91, 20)
        Me.tbAPACFim.TabIndex = 36
        '
        'tbAPACIni
        '
        Me.tbAPACIni.Location = New System.Drawing.Point(88, 40)
        Me.tbAPACIni.MaxLength = 13
        Me.tbAPACIni.Name = "tbAPACIni"
        Me.tbAPACIni.Size = New System.Drawing.Size(91, 20)
        Me.tbAPACIni.TabIndex = 35
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(203, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Qtd"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(873, 520)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 36
        Me.Button1.Text = "Correção"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusLabelRegistros, Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 499)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(966, 22)
        Me.StatusStrip1.TabIndex = 37
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'statusLabelRegistros
        '
        Me.statusLabelRegistros.Name = "statusLabelRegistros"
        Me.statusLabelRegistros.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(32, 17)
        Me.ToolStripStatusLabel1.Text = "Regs"
        '
        'CopiarToolStripMenuItem
        '
        Me.CopiarToolStripMenuItem.Name = "CopiarToolStripMenuItem"
        Me.CopiarToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.CopiarToolStripMenuItem.Text = "Copiar"
        '
        'FormAMEOCINumAPAC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(966, 521)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.numQtd)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbFaixaFim)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbFaixaInicio)
        Me.Controls.Add(Me.Button2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAMEOCINumAPAC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gerador APAC"
        CType(Me.numQtd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvNumerosAPAC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMenuAPAC.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As Button
    Friend WithEvents tbFaixaInicio As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tbFaixaFim As TextBox
    Friend WithEvents numQtd As NumericUpDown
    Friend WithEvents dgvNumerosAPAC As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents Button1 As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents chkDisponiveis As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents tbAPACFim As TextBox
    Friend WithEvents tbAPACIni As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cbUsuarios As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents dtpFim As DateTimePicker
    Friend WithEvents dtpIni As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents cbOCI As ComboBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents cbStatus As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents statusLabelRegistros As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ctxMenuAPAC As ContextMenuStrip
    Friend WithEvents AlterarStatusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopiarToolStripMenuItem As ToolStripMenuItem
End Class
