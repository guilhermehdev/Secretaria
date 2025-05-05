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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgAME = New System.Windows.Forms.DataGridView()
        Me.ComboBoxEspecialidade = New System.Windows.Forms.ComboBox()
        Me.ComboBoxProfissional = New System.Windows.Forms.ComboBox()
        Me.ButtonFiltrar = New System.Windows.Forms.Button()
        Me.ButtonExportarExcel = New System.Windows.Forms.Button()
        Me.LabelTotais = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ImportarPDFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GCASPPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.dgAME, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
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
        Me.dgAME.BackgroundColor = System.Drawing.Color.White
        Me.dgAME.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgAME.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgAME.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgAME.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgAME.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgAME.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.dgAME.Location = New System.Drawing.Point(12, 73)
        Me.dgAME.MultiSelect = False
        Me.dgAME.Name = "dgAME"
        Me.dgAME.ReadOnly = True
        Me.dgAME.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgAME.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgAME.RowHeadersWidth = 4
        Me.dgAME.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgAME.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgAME.Size = New System.Drawing.Size(1004, 420)
        Me.dgAME.TabIndex = 31
        Me.dgAME.TabStop = False
        '
        'ComboBoxEspecialidade
        '
        Me.ComboBoxEspecialidade.FormattingEnabled = True
        Me.ComboBoxEspecialidade.Location = New System.Drawing.Point(12, 46)
        Me.ComboBoxEspecialidade.Name = "ComboBoxEspecialidade"
        Me.ComboBoxEspecialidade.Size = New System.Drawing.Size(211, 21)
        Me.ComboBoxEspecialidade.TabIndex = 32
        '
        'ComboBoxProfissional
        '
        Me.ComboBoxProfissional.FormattingEnabled = True
        Me.ComboBoxProfissional.Location = New System.Drawing.Point(229, 46)
        Me.ComboBoxProfissional.Name = "ComboBoxProfissional"
        Me.ComboBoxProfissional.Size = New System.Drawing.Size(254, 21)
        Me.ComboBoxProfissional.TabIndex = 33
        '
        'ButtonFiltrar
        '
        Me.ButtonFiltrar.Location = New System.Drawing.Point(489, 45)
        Me.ButtonFiltrar.Name = "ButtonFiltrar"
        Me.ButtonFiltrar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonFiltrar.TabIndex = 34
        Me.ButtonFiltrar.Text = "Filtrar"
        Me.ButtonFiltrar.UseVisualStyleBackColor = True
        '
        'ButtonExportarExcel
        '
        Me.ButtonExportarExcel.Location = New System.Drawing.Point(570, 45)
        Me.ButtonExportarExcel.Name = "ButtonExportarExcel"
        Me.ButtonExportarExcel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonExportarExcel.TabIndex = 35
        Me.ButtonExportarExcel.Text = "Excel"
        Me.ButtonExportarExcel.UseVisualStyleBackColor = True
        '
        'LabelTotais
        '
        Me.LabelTotais.AutoSize = True
        Me.LabelTotais.Location = New System.Drawing.Point(651, 49)
        Me.LabelTotais.Name = "LabelTotais"
        Me.LabelTotais.Size = New System.Drawing.Size(60, 13)
        Me.LabelTotais.TabIndex = 36
        Me.LabelTotais.Text = "Resultados"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 496)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1028, 22)
        Me.StatusStrip1.TabIndex = 37
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Especialidade"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(226, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Profissional"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportarPDFToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1028, 24)
        Me.MenuStrip1.TabIndex = 40
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ImportarPDFToolStripMenuItem
        '
        Me.ImportarPDFToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GCASPPToolStripMenuItem})
        Me.ImportarPDFToolStripMenuItem.Name = "ImportarPDFToolStripMenuItem"
        Me.ImportarPDFToolStripMenuItem.Size = New System.Drawing.Size(68, 20)
        Me.ImportarPDFToolStripMenuItem.Text = "Importar "
        '
        'GCASPPToolStripMenuItem
        '
        Me.GCASPPToolStripMenuItem.Name = "GCASPPToolStripMenuItem"
        Me.GCASPPToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.GCASPPToolStripMenuItem.Text = "GCASPP"
        '
        'FormAME
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 518)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.LabelTotais)
        Me.Controls.Add(Me.ButtonExportarExcel)
        Me.Controls.Add(Me.ButtonFiltrar)
        Me.Controls.Add(Me.ComboBoxProfissional)
        Me.Controls.Add(Me.ComboBoxEspecialidade)
        Me.Controls.Add(Me.dgAME)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormAME"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AME"
        CType(Me.dgAME, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgAME As DataGridView
    Friend WithEvents ComboBoxEspecialidade As ComboBox
    Friend WithEvents ComboBoxProfissional As ComboBox
    Friend WithEvents ButtonFiltrar As Button
    Friend WithEvents ButtonExportarExcel As Button
    Friend WithEvents LabelTotais As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ImportarPDFToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GCASPPToolStripMenuItem As ToolStripMenuItem
End Class
