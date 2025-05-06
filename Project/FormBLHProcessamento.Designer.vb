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
        Me.tbNome = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbDataParto
        '
        Me.tbDataParto.Location = New System.Drawing.Point(26, 86)
        Me.tbDataParto.Mask = "00/00/0000"
        Me.tbDataParto.Name = "tbDataParto"
        Me.tbDataParto.Size = New System.Drawing.Size(67, 20)
        Me.tbDataParto.TabIndex = 3
        Me.tbDataParto.ValidatingType = GetType(Date)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Data do parto *"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(169, 109)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Resultado *"
        '
        'cbResultado
        '
        Me.cbResultado.FormattingEnabled = True
        Me.cbResultado.Items.AddRange(New Object() {"REGULAR", "VENCIDO"})
        Me.cbResultado.Location = New System.Drawing.Point(172, 124)
        Me.cbResultado.Name = "cbResultado"
        Me.cbResultado.Size = New System.Drawing.Size(73, 21)
        Me.cbResultado.TabIndex = 14
        '
        'tbDataVencimento
        '
        Me.tbDataVencimento.Location = New System.Drawing.Point(99, 124)
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
        Me.Label5.Location = New System.Drawing.Point(96, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Vencimento *"
        '
        'tbDataSorologia
        '
        Me.tbDataSorologia.Location = New System.Drawing.Point(26, 124)
        Me.tbDataSorologia.Mask = "00/00/0000"
        Me.tbDataSorologia.Name = "tbDataSorologia"
        Me.tbDataSorologia.Size = New System.Drawing.Size(67, 20)
        Me.tbDataSorologia.TabIndex = 13
        Me.tbDataSorologia.ValidatingType = GetType(Date)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Data sorologia *"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(96, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Origem *"
        '
        'cbOrigem
        '
        Me.cbOrigem.FormattingEnabled = True
        Me.cbOrigem.Items.AddRange(New Object() {"HRI", "CASA", "CESCRIM", "PG", "ITANHAÉM"})
        Me.cbOrigem.Location = New System.Drawing.Point(99, 84)
        Me.cbOrigem.Name = "cbOrigem"
        Me.cbOrigem.Size = New System.Drawing.Size(146, 21)
        Me.cbOrigem.TabIndex = 12
        '
        'tbNome
        '
        Me.tbNome.Location = New System.Drawing.Point(26, 46)
        Me.tbNome.Name = "tbNome"
        Me.tbNome.Size = New System.Drawing.Size(249, 20)
        Me.tbNome.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Nome *"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 26)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(697, 474)
        Me.TabControl1.TabIndex = 22
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.tbNome)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.tbDataParto)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.cbOrigem)
        Me.TabPage1.Controls.Add(Me.cbResultado)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.tbDataVencimento)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.tbDataSorologia)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(689, 448)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(689, 448)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'FormBLHProcessamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(722, 512)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FormBLHProcessamento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormBLHProcessamento"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)

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
    Friend WithEvents tbNome As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
End Class
