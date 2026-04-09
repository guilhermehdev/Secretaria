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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.cbProfissional = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpDataConsulta = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbEspecialidade = New System.Windows.Forms.ComboBox()
        Me.Nvagas = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgGrades = New System.Windows.Forms.DataGridView()
        Me.btSalvarGrade = New System.Windows.Forms.Button()
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
        Me.cbProfissional.Location = New System.Drawing.Point(124, 44)
        Me.cbProfissional.Name = "cbProfissional"
        Me.cbProfissional.Size = New System.Drawing.Size(210, 23)
        Me.cbProfissional.TabIndex = 59
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(121, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "Profissional"
        '
        'dtpDataConsulta
        '
        Me.dtpDataConsulta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDataConsulta.Location = New System.Drawing.Point(18, 45)
        Me.dtpDataConsulta.Name = "dtpDataConsulta"
        Me.dtpDataConsulta.Size = New System.Drawing.Size(100, 20)
        Me.dtpDataConsulta.TabIndex = 61
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 62
        Me.Label2.Text = "Data"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(337, 28)
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
        Me.cbEspecialidade.Location = New System.Drawing.Point(340, 44)
        Me.cbEspecialidade.Name = "cbEspecialidade"
        Me.cbEspecialidade.Size = New System.Drawing.Size(153, 23)
        Me.cbEspecialidade.TabIndex = 63
        '
        'Nvagas
        '
        Me.Nvagas.Location = New System.Drawing.Point(499, 45)
        Me.Nvagas.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Nvagas.Name = "Nvagas"
        Me.Nvagas.Size = New System.Drawing.Size(53, 20)
        Me.Nvagas.TabIndex = 65
        Me.Nvagas.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(498, 28)
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
        Me.dgGrades.BackgroundColor = System.Drawing.Color.White
        Me.dgGrades.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgGrades.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgGrades.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgGrades.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgGrades.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.dgGrades.Location = New System.Drawing.Point(18, 73)
        Me.dgGrades.MultiSelect = False
        Me.dgGrades.Name = "dgGrades"
        Me.dgGrades.ReadOnly = True
        Me.dgGrades.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgGrades.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgGrades.RowHeadersWidth = 4
        Me.dgGrades.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgGrades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgGrades.Size = New System.Drawing.Size(534, 284)
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
        'FormAMEAgendas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 398)
        Me.Controls.Add(Me.btSalvarGrade)
        Me.Controls.Add(Me.dgGrades)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Nvagas)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbEspecialidade)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpDataConsulta)
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
    Friend WithEvents dtpDataConsulta As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cbEspecialidade As ComboBox
    Friend WithEvents Nvagas As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents dgGrades As DataGridView
    Friend WithEvents btSalvarGrade As Button
End Class
