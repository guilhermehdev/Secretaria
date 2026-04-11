<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAMEAgendas
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.cbProfissional = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbEspecialidade = New System.Windows.Forms.ComboBox()
        Me.Nvagas = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgGrades = New System.Windows.Forms.DataGridView()
        Me.btSalvarGrade = New System.Windows.Forms.Button()
        Me.cbDiasemana = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.Nvagas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgGrades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(477, 363)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 58
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Multiselect = True
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "pdf"
        '
        'cbProfissional
        '
        Me.cbProfissional.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProfissional.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cbProfissional.FormattingEnabled = True
        Me.cbProfissional.Location = New System.Drawing.Point(139, 44)
        Me.cbProfissional.Name = "cbProfissional"
        Me.cbProfissional.Size = New System.Drawing.Size(210, 23)
        Me.cbProfissional.TabIndex = 59
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(136, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "Profissional"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(352, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 64
        Me.Label3.Text = "Especialidade"
        '
        'cbEspecialidade
        '
        Me.cbEspecialidade.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cbEspecialidade.Enabled = False
        Me.cbEspecialidade.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbEspecialidade.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEspecialidade.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cbEspecialidade.FormattingEnabled = True
        Me.cbEspecialidade.Location = New System.Drawing.Point(355, 44)
        Me.cbEspecialidade.Name = "cbEspecialidade"
        Me.cbEspecialidade.Size = New System.Drawing.Size(153, 23)
        Me.cbEspecialidade.TabIndex = 63
        '
        'Nvagas
        '
        Me.Nvagas.Location = New System.Drawing.Point(514, 45)
        Me.Nvagas.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Nvagas.Name = "Nvagas"
        Me.Nvagas.Size = New System.Drawing.Size(53, 20)
        Me.Nvagas.TabIndex = 65
        Me.Nvagas.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(513, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 66
        Me.Label4.Text = "Vagas"
        '
        'dgGrades
        '
        Me.dgGrades.AllowUserToAddRows = False
        Me.dgGrades.AllowUserToDeleteRows = False
        Me.dgGrades.AllowUserToOrderColumns = True
        Me.dgGrades.AllowUserToResizeRows = False
        Me.dgGrades.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgGrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgGrades.BackgroundColor = System.Drawing.Color.White
        Me.dgGrades.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgGrades.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgGrades.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgGrades.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgGrades.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.dgGrades.Location = New System.Drawing.Point(18, 73)
        Me.dgGrades.MultiSelect = False
        Me.dgGrades.Name = "dgGrades"
        Me.dgGrades.ReadOnly = True
        Me.dgGrades.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgGrades.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgGrades.RowHeadersWidth = 4
        Me.dgGrades.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgGrades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgGrades.Size = New System.Drawing.Size(549, 284)
        Me.dgGrades.TabIndex = 67
        Me.dgGrades.TabStop = False
        '
        'btSalvarGrade
        '
        Me.btSalvarGrade.Location = New System.Drawing.Point(396, 363)
        Me.btSalvarGrade.Name = "btSalvarGrade"
        Me.btSalvarGrade.Size = New System.Drawing.Size(75, 23)
        Me.btSalvarGrade.TabIndex = 68
        Me.btSalvarGrade.Text = "Gravar"
        Me.btSalvarGrade.UseVisualStyleBackColor = True
        '
        'cbDiasemana
        '
        Me.cbDiasemana.FormattingEnabled = True
        Me.cbDiasemana.Location = New System.Drawing.Point(18, 46)
        Me.cbDiasemana.Name = "cbDiasemana"
        Me.cbDiasemana.Size = New System.Drawing.Size(115, 21)
        Me.cbDiasemana.TabIndex = 69
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 70
        Me.Label5.Text = "Dia da semana"
        '
        'FormAMEAgendas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(585, 398)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbDiasemana)
        Me.Controls.Add(Me.btSalvarGrade)
        Me.Controls.Add(Me.dgGrades)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Nvagas)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbEspecialidade)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbProfissional)
        Me.Controls.Add(Me.Button1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAMEAgendas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agenda"
        CType(Me.Nvagas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgGrades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents cbProfissional As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cbEspecialidade As ComboBox
    Friend WithEvents Nvagas As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents dgGrades As DataGridView
    Friend WithEvents btSalvarGrade As Button
    Friend WithEvents cbDiasemana As ComboBox
    Friend WithEvents Label5 As Label
End Class
