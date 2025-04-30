<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBLHProcessamento
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgBLHprocessamento = New System.Windows.Forms.DataGridView()
        CType(Me.dgBLHprocessamento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgBLHprocessamento
        '
        Me.dgBLHprocessamento.AllowUserToAddRows = False
        Me.dgBLHprocessamento.AllowUserToDeleteRows = False
        Me.dgBLHprocessamento.AllowUserToOrderColumns = True
        Me.dgBLHprocessamento.AllowUserToResizeRows = False
        Me.dgBLHprocessamento.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgBLHprocessamento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgBLHprocessamento.BackgroundColor = System.Drawing.Color.White
        Me.dgBLHprocessamento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgBLHprocessamento.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgBLHprocessamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgBLHprocessamento.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgBLHprocessamento.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.dgBLHprocessamento.Location = New System.Drawing.Point(12, 33)
        Me.dgBLHprocessamento.MultiSelect = False
        Me.dgBLHprocessamento.Name = "dgBLHprocessamento"
        Me.dgBLHprocessamento.ReadOnly = True
        Me.dgBLHprocessamento.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgBLHprocessamento.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgBLHprocessamento.RowHeadersWidth = 4
        Me.dgBLHprocessamento.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgBLHprocessamento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgBLHprocessamento.Size = New System.Drawing.Size(981, 467)
        Me.dgBLHprocessamento.TabIndex = 31
        Me.dgBLHprocessamento.TabStop = False
        '
        'FormBLHProcessamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1005, 512)
        Me.Controls.Add(Me.dgBLHprocessamento)
        Me.Name = "FormBLHProcessamento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormBLHProcessamento"
        CType(Me.dgBLHprocessamento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgBLHprocessamento As DataGridView
End Class
