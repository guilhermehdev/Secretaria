<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAME
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgAME = New System.Windows.Forms.DataGridView()
        Me.ComboBoxEspecialidade = New System.Windows.Forms.ComboBox()
        Me.ComboBoxProfissional = New System.Windows.Forms.ComboBox()
        Me.ButtonFiltrar = New System.Windows.Forms.Button()
        Me.ButtonExportarExcel = New System.Windows.Forms.Button()
        Me.LabelTotais = New System.Windows.Forms.Label()
        CType(Me.dgAME, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgAME
        '
        Me.dgAME.AllowUserToAddRows = False
        Me.dgAME.AllowUserToDeleteRows = False
        Me.dgAME.AllowUserToOrderColumns = True
        Me.dgAME.AllowUserToResizeRows = False
        Me.dgAME.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgAME.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgAME.BackgroundColor = System.Drawing.Color.White
        Me.dgAME.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgAME.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgAME.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgAME.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgAME.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.dgAME.Location = New System.Drawing.Point(12, 41)
        Me.dgAME.MultiSelect = False
        Me.dgAME.Name = "dgAME"
        Me.dgAME.ReadOnly = True
        Me.dgAME.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgAME.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgAME.RowHeadersWidth = 4
        Me.dgAME.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgAME.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgAME.Size = New System.Drawing.Size(1004, 484)
        Me.dgAME.TabIndex = 31
        Me.dgAME.TabStop = False
        '
        'ComboBoxEspecialidade
        '
        Me.ComboBoxEspecialidade.FormattingEnabled = True
        Me.ComboBoxEspecialidade.Location = New System.Drawing.Point(12, 14)
        Me.ComboBoxEspecialidade.Name = "ComboBoxEspecialidade"
        Me.ComboBoxEspecialidade.Size = New System.Drawing.Size(194, 21)
        Me.ComboBoxEspecialidade.TabIndex = 32
        '
        'ComboBoxProfissional
        '
        Me.ComboBoxProfissional.FormattingEnabled = True
        Me.ComboBoxProfissional.Location = New System.Drawing.Point(229, 14)
        Me.ComboBoxProfissional.Name = "ComboBoxProfissional"
        Me.ComboBoxProfissional.Size = New System.Drawing.Size(254, 21)
        Me.ComboBoxProfissional.TabIndex = 33
        '
        'ButtonFiltrar
        '
        Me.ButtonFiltrar.Location = New System.Drawing.Point(489, 14)
        Me.ButtonFiltrar.Name = "ButtonFiltrar"
        Me.ButtonFiltrar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonFiltrar.TabIndex = 34
        Me.ButtonFiltrar.Text = "Button2"
        Me.ButtonFiltrar.UseVisualStyleBackColor = True
        '
        'ButtonExportarExcel
        '
        Me.ButtonExportarExcel.Location = New System.Drawing.Point(570, 14)
        Me.ButtonExportarExcel.Name = "ButtonExportarExcel"
        Me.ButtonExportarExcel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonExportarExcel.TabIndex = 35
        Me.ButtonExportarExcel.Text = "Button2"
        Me.ButtonExportarExcel.UseVisualStyleBackColor = True
        '
        'LabelTotais
        '
        Me.LabelTotais.AutoSize = True
        Me.LabelTotais.Location = New System.Drawing.Point(675, 19)
        Me.LabelTotais.Name = "LabelTotais"
        Me.LabelTotais.Size = New System.Drawing.Size(39, 13)
        Me.LabelTotais.TabIndex = 36
        Me.LabelTotais.Text = "Label1"
        '
        'FormAME
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 537)
        Me.Controls.Add(Me.LabelTotais)
        Me.Controls.Add(Me.ButtonExportarExcel)
        Me.Controls.Add(Me.ButtonFiltrar)
        Me.Controls.Add(Me.ComboBoxProfissional)
        Me.Controls.Add(Me.ComboBoxEspecialidade)
        Me.Controls.Add(Me.dgAME)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAME"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AME"
        CType(Me.dgAME, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgAME As DataGridView
    Friend WithEvents ComboBoxEspecialidade As ComboBox
    Friend WithEvents ComboBoxProfissional As ComboBox
    Friend WithEvents ButtonFiltrar As Button
    Friend WithEvents ButtonExportarExcel As Button
    Friend WithEvents LabelTotais As Label
End Class
