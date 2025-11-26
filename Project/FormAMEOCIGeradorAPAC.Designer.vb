<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAMEOCIGeradorAPAC
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.numQtd = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbFaixaFim = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbFaixaInicio = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btFechar = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        CType(Me.numQtd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Qtd"
        '
        'numQtd
        '
        Me.numQtd.Location = New System.Drawing.Point(29, 110)
        Me.numQtd.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numQtd.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numQtd.Name = "numQtd"
        Me.numQtd.Size = New System.Drawing.Size(115, 20)
        Me.numQtd.TabIndex = 41
        Me.numQtd.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Faixa fim"
        '
        'tbFaixaFim
        '
        Me.tbFaixaFim.Location = New System.Drawing.Point(29, 70)
        Me.tbFaixaFim.MaxLength = 13
        Me.tbFaixaFim.Name = "tbFaixaFim"
        Me.tbFaixaFim.Size = New System.Drawing.Size(115, 20)
        Me.tbFaixaFim.TabIndex = 39
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Faixa inicio"
        '
        'tbFaixaInicio
        '
        Me.tbFaixaInicio.Location = New System.Drawing.Point(29, 31)
        Me.tbFaixaInicio.MaxLength = 13
        Me.tbFaixaInicio.Name = "tbFaixaInicio"
        Me.tbFaixaInicio.Size = New System.Drawing.Size(115, 20)
        Me.tbFaixaInicio.TabIndex = 37
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(29, 136)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(115, 23)
        Me.Button2.TabIndex = 36
        Me.Button2.Text = "Gerar numeros APAC"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btFechar
        '
        Me.btFechar.Location = New System.Drawing.Point(29, 162)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(115, 23)
        Me.btFechar.TabIndex = 43
        Me.btFechar.Text = "Fechar"
        Me.btFechar.UseVisualStyleBackColor = True
        '
        'FormAMEOCIGeradorAPAC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(174, 204)
        Me.Controls.Add(Me.btFechar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.numQtd)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbFaixaFim)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbFaixaInicio)
        Me.Controls.Add(Me.Button2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAMEOCIGeradorAPAC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OCI - Gerador APAC"
        CType(Me.numQtd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents numQtd As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents tbFaixaFim As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tbFaixaInicio As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents btFechar As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
End Class
