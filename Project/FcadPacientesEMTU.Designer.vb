<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FcadPacientesEMTU
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tbNome = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbLaudo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpDataSol = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpDataRetirada = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.mtbRG = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbNomeRetirada = New System.Windows.Forms.TextBox()
        Me.btSalvar = New System.Windows.Forms.Button()
        Me.btFechar = New System.Windows.Forms.Button()
        Me.btNovo = New System.Windows.Forms.Button()
        Me.cbEmissao = New System.Windows.Forms.ComboBox()
        Me.tbObs = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btAtualizar = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.mtbTel = New System.Windows.Forms.MaskedTextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbNome
        '
        Me.tbNome.Location = New System.Drawing.Point(12, 39)
        Me.tbNome.Name = "tbNome"
        Me.tbNome.Size = New System.Drawing.Size(250, 20)
        Me.tbNome.TabIndex = 0
        Me.tbNome.Tag = "Nome"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nome"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(110, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Laudo"
        '
        'tbLaudo
        '
        Me.tbLaudo.Location = New System.Drawing.Point(113, 87)
        Me.tbLaudo.Name = "tbLaudo"
        Me.tbLaudo.Size = New System.Drawing.Size(126, 20)
        Me.tbLaudo.TabIndex = 2
        Me.tbLaudo.Tag = "Laudo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Tipo de emissão"
        '
        'dtpDataSol
        '
        Me.dtpDataSol.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDataSol.Location = New System.Drawing.Point(245, 87)
        Me.dtpDataSol.Name = "dtpDataSol"
        Me.dtpDataSol.Size = New System.Drawing.Size(113, 20)
        Me.dtpDataSol.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(242, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Data da solicitação"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.dtpDataRetirada)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.mtbRG)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.tbNomeRetirada)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 206)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(346, 123)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Retirada"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(109, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Data da retirada"
        '
        'dtpDataRetirada
        '
        Me.dtpDataRetirada.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDataRetirada.Location = New System.Drawing.Point(112, 90)
        Me.dtpDataRetirada.Name = "dtpDataRetirada"
        Me.dtpDataRetirada.Size = New System.Drawing.Size(117, 20)
        Me.dtpDataRetirada.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "RG"
        '
        'mtbRG
        '
        Me.mtbRG.Location = New System.Drawing.Point(16, 90)
        Me.mtbRG.Mask = "99,999,999-99"
        Me.mtbRG.Name = "mtbRG"
        Me.mtbRG.Size = New System.Drawing.Size(90, 20)
        Me.mtbRG.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Nome"
        '
        'tbNomeRetirada
        '
        Me.tbNomeRetirada.Location = New System.Drawing.Point(16, 43)
        Me.tbNomeRetirada.Name = "tbNomeRetirada"
        Me.tbNomeRetirada.Size = New System.Drawing.Size(312, 20)
        Me.tbNomeRetirada.TabIndex = 2
        '
        'btSalvar
        '
        Me.btSalvar.Location = New System.Drawing.Point(93, 335)
        Me.btSalvar.Name = "btSalvar"
        Me.btSalvar.Size = New System.Drawing.Size(75, 23)
        Me.btSalvar.TabIndex = 9
        Me.btSalvar.Text = "Salvar"
        Me.btSalvar.UseVisualStyleBackColor = True
        '
        'btFechar
        '
        Me.btFechar.Location = New System.Drawing.Point(283, 335)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(75, 23)
        Me.btFechar.TabIndex = 10
        Me.btFechar.Text = "Fechar"
        Me.btFechar.UseVisualStyleBackColor = True
        '
        'btNovo
        '
        Me.btNovo.Location = New System.Drawing.Point(12, 335)
        Me.btNovo.Name = "btNovo"
        Me.btNovo.Size = New System.Drawing.Size(75, 23)
        Me.btNovo.TabIndex = 11
        Me.btNovo.Text = "Novo"
        Me.btNovo.UseVisualStyleBackColor = True
        '
        'cbEmissao
        '
        Me.cbEmissao.FormattingEnabled = True
        Me.cbEmissao.Items.AddRange(New Object() {"1ª Via", "2ª Via", "Renovação"})
        Me.cbEmissao.Location = New System.Drawing.Point(12, 87)
        Me.cbEmissao.Name = "cbEmissao"
        Me.cbEmissao.Size = New System.Drawing.Size(95, 21)
        Me.cbEmissao.TabIndex = 12
        Me.cbEmissao.Tag = "Emissão"
        '
        'tbObs
        '
        Me.tbObs.Location = New System.Drawing.Point(12, 136)
        Me.tbObs.Multiline = True
        Me.tbObs.Name = "tbObs"
        Me.tbObs.Size = New System.Drawing.Size(346, 61)
        Me.tbObs.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 120)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Obs."
        '
        'btAtualizar
        '
        Me.btAtualizar.Location = New System.Drawing.Point(174, 335)
        Me.btAtualizar.Name = "btAtualizar"
        Me.btAtualizar.Size = New System.Drawing.Size(75, 23)
        Me.btAtualizar.TabIndex = 15
        Me.btAtualizar.Text = "Alterar"
        Me.btAtualizar.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(265, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Telefone"
        '
        'mtbTel
        '
        Me.mtbTel.Location = New System.Drawing.Point(268, 39)
        Me.mtbTel.Mask = "(99)99999-9999"
        Me.mtbTel.Name = "mtbTel"
        Me.mtbTel.Size = New System.Drawing.Size(90, 20)
        Me.mtbTel.TabIndex = 16
        '
        'FcadPacientesEMTU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(372, 373)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.mtbTel)
        Me.Controls.Add(Me.btAtualizar)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tbObs)
        Me.Controls.Add(Me.cbEmissao)
        Me.Controls.Add(Me.btNovo)
        Me.Controls.Add(Me.btFechar)
        Me.Controls.Add(Me.btSalvar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpDataSol)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbLaudo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbNome)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FcadPacientesEMTU"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de usuários"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbNome As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbLaudo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpDataSol As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents mtbRG As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbNomeRetirada As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpDataRetirada As System.Windows.Forms.DateTimePicker
    Friend WithEvents btSalvar As System.Windows.Forms.Button
    Friend WithEvents btFechar As System.Windows.Forms.Button
    Friend WithEvents btNovo As System.Windows.Forms.Button
    Friend WithEvents cbEmissao As System.Windows.Forms.ComboBox
    Friend WithEvents tbObs As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btAtualizar As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents mtbTel As System.Windows.Forms.MaskedTextBox
End Class
