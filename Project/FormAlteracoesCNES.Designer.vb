<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAlteracoesCNES
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAlteracoesCNES))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgAlteracoesPendentes = New System.Windows.Forms.DataGridView()
        Me.btConcluirCadastro = New System.Windows.Forms.Button()
        Me.btFechar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgAlteracoesPendentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgAlteracoesPendentes)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(735, 365)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Alterações pendentes"
        '
        'dgAlteracoesPendentes
        '
        Me.dgAlteracoesPendentes.AllowUserToAddRows = False
        Me.dgAlteracoesPendentes.AllowUserToDeleteRows = False
        Me.dgAlteracoesPendentes.AllowUserToOrderColumns = True
        Me.dgAlteracoesPendentes.AllowUserToResizeRows = False
        Me.dgAlteracoesPendentes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgAlteracoesPendentes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgAlteracoesPendentes.BackgroundColor = System.Drawing.Color.White
        Me.dgAlteracoesPendentes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgAlteracoesPendentes.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgAlteracoesPendentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgAlteracoesPendentes.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgAlteracoesPendentes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.dgAlteracoesPendentes.Location = New System.Drawing.Point(6, 19)
        Me.dgAlteracoesPendentes.MultiSelect = False
        Me.dgAlteracoesPendentes.Name = "dgAlteracoesPendentes"
        Me.dgAlteracoesPendentes.ReadOnly = True
        Me.dgAlteracoesPendentes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgAlteracoesPendentes.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgAlteracoesPendentes.RowHeadersWidth = 4
        Me.dgAlteracoesPendentes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgAlteracoesPendentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgAlteracoesPendentes.Size = New System.Drawing.Size(723, 340)
        Me.dgAlteracoesPendentes.TabIndex = 31
        Me.dgAlteracoesPendentes.TabStop = False
        '
        'btConcluirCadastro
        '
        Me.btConcluirCadastro.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btConcluirCadastro.Location = New System.Drawing.Point(490, 385)
        Me.btConcluirCadastro.Name = "btConcluirCadastro"
        Me.btConcluirCadastro.Size = New System.Drawing.Size(149, 23)
        Me.btConcluirCadastro.TabIndex = 4
        Me.btConcluirCadastro.Text = "Concluir cadastro"
        Me.btConcluirCadastro.UseVisualStyleBackColor = True
        '
        'btFechar
        '
        Me.btFechar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btFechar.Location = New System.Drawing.Point(645, 385)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(75, 23)
        Me.btFechar.TabIndex = 5
        Me.btFechar.Text = "Fechar"
        Me.btFechar.UseVisualStyleBackColor = True
        '
        'FormAlteracoesCNES
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 420)
        Me.Controls.Add(Me.btConcluirCadastro)
        Me.Controls.Add(Me.btFechar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAlteracoesCNES"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alerações CNES"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgAlteracoesPendentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dgAlteracoesPendentes As DataGridView
    Friend WithEvents btConcluirCadastro As Button
    Friend WithEvents btFechar As Button
End Class
