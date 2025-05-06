<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCNESAlteracoes
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCNESAlteracoes))
        Me.dgAlteracoesPendentes = New System.Windows.Forms.DataGridView()
        Me.btConcluirCadastro = New System.Windows.Forms.Button()
        Me.btFechar = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgHistoricoAlteracoes = New System.Windows.Forms.DataGridView()
        CType(Me.dgAlteracoesPendentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgHistoricoAlteracoes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.dgAlteracoesPendentes.Location = New System.Drawing.Point(0, 0)
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
        Me.dgAlteracoesPendentes.Size = New System.Drawing.Size(726, 341)
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
        Me.btConcluirCadastro.Text = "Concluir alteração"
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
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(735, 367)
        Me.TabControl1.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgAlteracoesPendentes)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(727, 341)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Alterações pendentes"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgHistoricoAlteracoes)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(727, 341)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Histórico"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgHistoricoAlteracoes
        '
        Me.dgHistoricoAlteracoes.AllowUserToAddRows = False
        Me.dgHistoricoAlteracoes.AllowUserToDeleteRows = False
        Me.dgHistoricoAlteracoes.AllowUserToOrderColumns = True
        Me.dgHistoricoAlteracoes.AllowUserToResizeRows = False
        Me.dgHistoricoAlteracoes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgHistoricoAlteracoes.BackgroundColor = System.Drawing.Color.White
        Me.dgHistoricoAlteracoes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgHistoricoAlteracoes.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgHistoricoAlteracoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgHistoricoAlteracoes.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgHistoricoAlteracoes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.dgHistoricoAlteracoes.Location = New System.Drawing.Point(0, 0)
        Me.dgHistoricoAlteracoes.MultiSelect = False
        Me.dgHistoricoAlteracoes.Name = "dgHistoricoAlteracoes"
        Me.dgHistoricoAlteracoes.ReadOnly = True
        Me.dgHistoricoAlteracoes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgHistoricoAlteracoes.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgHistoricoAlteracoes.RowHeadersWidth = 4
        Me.dgHistoricoAlteracoes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgHistoricoAlteracoes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgHistoricoAlteracoes.Size = New System.Drawing.Size(726, 341)
        Me.dgHistoricoAlteracoes.TabIndex = 32
        Me.dgHistoricoAlteracoes.TabStop = False
        '
        'FormAlteracoesCNES
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 420)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btConcluirCadastro)
        Me.Controls.Add(Me.btFechar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAlteracoesCNES"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alterações CNES"
        CType(Me.dgAlteracoesPendentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgHistoricoAlteracoes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgAlteracoesPendentes As DataGridView
    Friend WithEvents btConcluirCadastro As Button
    Friend WithEvents btFechar As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents dgHistoricoAlteracoes As DataGridView
End Class
