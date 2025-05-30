<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBLHSorologias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBLHSorologias))
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbResultado = New System.Windows.Forms.ComboBox()
        Me.tbDataVencimento = New System.Windows.Forms.MaskedTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tbDataSorologia = New System.Windows.Forms.MaskedTextBox()
        Me.btSalvarSorologias = New System.Windows.Forms.Button()
        Me.dgSorologias = New System.Windows.Forms.DataGridView()
        Me.btExcluirDoadora = New System.Windows.Forms.Button()
        CType(Me.dgSorologias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 84)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 13)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "Resultado "
        '
        'cbResultado
        '
        Me.cbResultado.FormattingEnabled = True
        Me.cbResultado.Items.AddRange(New Object() {"REGULAR", "VENCIDO"})
        Me.cbResultado.Location = New System.Drawing.Point(15, 99)
        Me.cbResultado.Name = "cbResultado"
        Me.cbResultado.Size = New System.Drawing.Size(107, 21)
        Me.cbResultado.TabIndex = 32
        '
        'tbDataVencimento
        '
        Me.tbDataVencimento.Location = New System.Drawing.Point(15, 62)
        Me.tbDataVencimento.Mask = "00/00/0000"
        Me.tbDataVencimento.Name = "tbDataVencimento"
        Me.tbDataVencimento.ReadOnly = True
        Me.tbDataVencimento.Size = New System.Drawing.Size(107, 20)
        Me.tbDataVencimento.TabIndex = 33
        Me.tbDataVencimento.ValidatingType = GetType(Date)
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 13)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Data sorologia "
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 47)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 13)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "Vencimento "
        '
        'tbDataSorologia
        '
        Me.tbDataSorologia.Location = New System.Drawing.Point(15, 25)
        Me.tbDataSorologia.Mask = "00/00/0000"
        Me.tbDataSorologia.Name = "tbDataSorologia"
        Me.tbDataSorologia.Size = New System.Drawing.Size(107, 20)
        Me.tbDataSorologia.TabIndex = 31
        Me.tbDataSorologia.ValidatingType = GetType(Date)
        '
        'btSalvarSorologias
        '
        Me.btSalvarSorologias.BackColor = System.Drawing.Color.ForestGreen
        Me.btSalvarSorologias.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btSalvarSorologias.FlatAppearance.BorderSize = 0
        Me.btSalvarSorologias.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btSalvarSorologias.ForeColor = System.Drawing.Color.White
        Me.btSalvarSorologias.Location = New System.Drawing.Point(15, 126)
        Me.btSalvarSorologias.Name = "btSalvarSorologias"
        Me.btSalvarSorologias.Size = New System.Drawing.Size(107, 23)
        Me.btSalvarSorologias.TabIndex = 37
        Me.btSalvarSorologias.Text = "Salvar"
        Me.btSalvarSorologias.UseVisualStyleBackColor = False
        '
        'dgSorologias
        '
        Me.dgSorologias.AllowUserToAddRows = False
        Me.dgSorologias.AllowUserToDeleteRows = False
        Me.dgSorologias.AllowUserToOrderColumns = True
        Me.dgSorologias.AllowUserToResizeRows = False
        Me.dgSorologias.BackgroundColor = System.Drawing.Color.White
        Me.dgSorologias.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgSorologias.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgSorologias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgSorologias.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgSorologias.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.dgSorologias.Location = New System.Drawing.Point(128, 25)
        Me.dgSorologias.MultiSelect = False
        Me.dgSorologias.Name = "dgSorologias"
        Me.dgSorologias.ReadOnly = True
        Me.dgSorologias.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSorologias.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgSorologias.RowHeadersWidth = 4
        Me.dgSorologias.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgSorologias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSorologias.Size = New System.Drawing.Size(107, 95)
        Me.dgSorologias.TabIndex = 38
        Me.dgSorologias.TabStop = False
        '
        'btExcluirDoadora
        '
        Me.btExcluirDoadora.BackColor = System.Drawing.Color.DarkRed
        Me.btExcluirDoadora.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btExcluirDoadora.Enabled = False
        Me.btExcluirDoadora.FlatAppearance.BorderSize = 0
        Me.btExcluirDoadora.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btExcluirDoadora.ForeColor = System.Drawing.Color.White
        Me.btExcluirDoadora.Location = New System.Drawing.Point(128, 126)
        Me.btExcluirDoadora.Name = "btExcluirDoadora"
        Me.btExcluirDoadora.Size = New System.Drawing.Size(107, 23)
        Me.btExcluirDoadora.TabIndex = 39
        Me.btExcluirDoadora.Text = "Excluir"
        Me.btExcluirDoadora.UseVisualStyleBackColor = False
        '
        'FormBLHSorologias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(249, 168)
        Me.Controls.Add(Me.btExcluirDoadora)
        Me.Controls.Add(Me.dgSorologias)
        Me.Controls.Add(Me.btSalvarSorologias)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cbResultado)
        Me.Controls.Add(Me.tbDataVencimento)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.tbDataSorologia)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormBLHSorologias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BLH - Sorologias"
        CType(Me.dgSorologias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label10 As Label
    Friend WithEvents cbResultado As ComboBox
    Friend WithEvents tbDataVencimento As MaskedTextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents tbDataSorologia As MaskedTextBox
    Friend WithEvents btSalvarSorologias As Button
    Friend WithEvents dgSorologias As DataGridView
    Friend WithEvents btExcluirDoadora As Button
End Class
