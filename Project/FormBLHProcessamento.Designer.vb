<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormBLHProcessamento
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
        Me.tbDataParto = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbResultado = New System.Windows.Forms.ComboBox()
        Me.tbDataVencimento = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbDataSorologia = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbOrigem = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'tbDataParto
        '
        Me.tbDataParto.Location = New System.Drawing.Point(61, 83)
        Me.tbDataParto.Mask = "00/00/0000"
        Me.tbDataParto.Name = "tbDataParto"
        Me.tbDataParto.Size = New System.Drawing.Size(67, 20)
        Me.tbDataParto.TabIndex = 3
        Me.tbDataParto.ValidatingType = GetType(Date)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(58, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Data do parto *"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(204, 106)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Resultado *"
        '
        'cbResultado
        '
        Me.cbResultado.FormattingEnabled = True
        Me.cbResultado.Items.AddRange(New Object() {"REGULAR", "VENCIDO"})
        Me.cbResultado.Location = New System.Drawing.Point(207, 121)
        Me.cbResultado.Name = "cbResultado"
        Me.cbResultado.Size = New System.Drawing.Size(73, 21)
        Me.cbResultado.TabIndex = 14
        '
        'tbDataVencimento
        '
        Me.tbDataVencimento.Location = New System.Drawing.Point(134, 121)
        Me.tbDataVencimento.Mask = "00/00/0000"
        Me.tbDataVencimento.Name = "tbDataVencimento"
        Me.tbDataVencimento.ReadOnly = True
        Me.tbDataVencimento.Size = New System.Drawing.Size(67, 20)
        Me.tbDataVencimento.TabIndex = 16
        Me.tbDataVencimento.ValidatingType = GetType(Date)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(131, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Vencimento *"
        '
        'tbDataSorologia
        '
        Me.tbDataSorologia.Location = New System.Drawing.Point(61, 121)
        Me.tbDataSorologia.Mask = "00/00/0000"
        Me.tbDataSorologia.Name = "tbDataSorologia"
        Me.tbDataSorologia.Size = New System.Drawing.Size(67, 20)
        Me.tbDataSorologia.TabIndex = 13
        Me.tbDataSorologia.ValidatingType = GetType(Date)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(58, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Data sorologia *"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(131, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Origem *"
        '
        'cbOrigem
        '
        Me.cbOrigem.FormattingEnabled = True
        Me.cbOrigem.Items.AddRange(New Object() {"HRI", "CASA", "CESCRIM", "PG", "ITANHAÉM"})
        Me.cbOrigem.Location = New System.Drawing.Point(134, 81)
        Me.cbOrigem.Name = "cbOrigem"
        Me.cbOrigem.Size = New System.Drawing.Size(146, 21)
        Me.cbOrigem.TabIndex = 12
        '
        'FormBLHProcessamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1005, 512)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cbResultado)
        Me.Controls.Add(Me.tbDataVencimento)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tbDataSorologia)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbOrigem)
        Me.Controls.Add(Me.tbDataParto)
        Me.Controls.Add(Me.Label2)
        Me.Name = "FormBLHProcessamento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormBLHProcessamento"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbDataParto As MaskedTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cbResultado As ComboBox
    Friend WithEvents tbDataVencimento As MaskedTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents tbDataSorologia As MaskedTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cbOrigem As ComboBox
End Class
