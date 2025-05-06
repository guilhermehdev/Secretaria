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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBLHProcessamento))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbResultado = New System.Windows.Forms.ComboBox()
        Me.tbDataVencimento = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbDataSorologia = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbOrigem = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btCancelar = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.btSalvarDoadora = New System.Windows.Forms.Button()
        Me.btAtualizarDoadora = New System.Windows.Forms.Button()
        Me.btExcluirDoadora = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.gbMotivos = New System.Windows.Forms.GroupBox()
        Me.cbExamesVencidos = New System.Windows.Forms.CheckBox()
        Me.cbEmbalagem = New System.Windows.Forms.CheckBox()
        Me.cbRefrigeracao = New System.Windows.Forms.CheckBox()
        Me.cbVencidos15dias = New System.Windows.Forms.CheckBox()
        Me.rbNaoConforme = New System.Windows.Forms.RadioButton()
        Me.rbConforme = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbTipoLeite = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbVolume = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbDataOrdenha = New System.Windows.Forms.MaskedTextBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.cbParto = New System.Windows.Forms.ComboBox()
        Me.cbDoadoras = New System.Windows.Forms.ComboBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gbMotivos.SuspendLayout()
        CType(Me.tbVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(325, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Data do parto "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(331, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Resultado "
        '
        'cbResultado
        '
        Me.cbResultado.FormattingEnabled = True
        Me.cbResultado.Items.AddRange(New Object() {"REGULAR", "VENCIDO"})
        Me.cbResultado.Location = New System.Drawing.Point(334, 85)
        Me.cbResultado.Name = "cbResultado"
        Me.cbResultado.Size = New System.Drawing.Size(109, 21)
        Me.cbResultado.TabIndex = 14
        '
        'tbDataVencimento
        '
        Me.tbDataVencimento.Location = New System.Drawing.Point(249, 85)
        Me.tbDataVencimento.Mask = "00/00/0000"
        Me.tbDataVencimento.Name = "tbDataVencimento"
        Me.tbDataVencimento.ReadOnly = True
        Me.tbDataVencimento.Size = New System.Drawing.Size(79, 20)
        Me.tbDataVencimento.TabIndex = 16
        Me.tbDataVencimento.ValidatingType = GetType(Date)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(246, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Vencimento "
        '
        'tbDataSorologia
        '
        Me.tbDataSorologia.Location = New System.Drawing.Point(161, 85)
        Me.tbDataSorologia.Mask = "00/00/0000"
        Me.tbDataSorologia.Name = "tbDataSorologia"
        Me.tbDataSorologia.Size = New System.Drawing.Size(82, 20)
        Me.tbDataSorologia.TabIndex = 13
        Me.tbDataSorologia.ValidatingType = GetType(Date)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(158, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Data sorologia "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Origem"
        '
        'cbOrigem
        '
        Me.cbOrigem.FormattingEnabled = True
        Me.cbOrigem.Items.AddRange(New Object() {"HRI", "CASA", "CESCRIM", "PG", "ITANHAÉM"})
        Me.cbOrigem.Location = New System.Drawing.Point(26, 85)
        Me.cbOrigem.Name = "cbOrigem"
        Me.cbOrigem.Size = New System.Drawing.Size(129, 21)
        Me.cbOrigem.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Doadora"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 26)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(477, 453)
        Me.TabControl1.TabIndex = 22
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TabPage1.Controls.Add(Me.btCancelar)
        Me.TabPage1.Controls.Add(Me.Button4)
        Me.TabPage1.Controls.Add(Me.btSalvarDoadora)
        Me.TabPage1.Controls.Add(Me.btAtualizarDoadora)
        Me.TabPage1.Controls.Add(Me.btExcluirDoadora)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.cbParto)
        Me.TabPage1.Controls.Add(Me.cbDoadoras)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label2)
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
        Me.TabPage1.Size = New System.Drawing.Size(469, 427)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Cadastro"
        '
        'btCancelar
        '
        Me.btCancelar.BackColor = System.Drawing.Color.Chocolate
        Me.btCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btCancelar.FlatAppearance.BorderSize = 0
        Me.btCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btCancelar.ForeColor = System.Drawing.Color.White
        Me.btCancelar.Location = New System.Drawing.Point(254, 391)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btCancelar.TabIndex = 30
        Me.btCancelar.Text = "Cancelar"
        Me.btCancelar.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Black
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(410, 391)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(33, 23)
        Me.Button4.TabIndex = 29
        Me.Button4.Text = "Sair"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'btSalvarDoadora
        '
        Me.btSalvarDoadora.BackColor = System.Drawing.Color.ForestGreen
        Me.btSalvarDoadora.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btSalvarDoadora.FlatAppearance.BorderSize = 0
        Me.btSalvarDoadora.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btSalvarDoadora.ForeColor = System.Drawing.Color.White
        Me.btSalvarDoadora.Location = New System.Drawing.Point(26, 391)
        Me.btSalvarDoadora.Name = "btSalvarDoadora"
        Me.btSalvarDoadora.Size = New System.Drawing.Size(75, 23)
        Me.btSalvarDoadora.TabIndex = 26
        Me.btSalvarDoadora.Text = "Salvar"
        Me.btSalvarDoadora.UseVisualStyleBackColor = False
        '
        'btAtualizarDoadora
        '
        Me.btAtualizarDoadora.BackColor = System.Drawing.Color.SteelBlue
        Me.btAtualizarDoadora.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btAtualizarDoadora.Enabled = False
        Me.btAtualizarDoadora.FlatAppearance.BorderSize = 0
        Me.btAtualizarDoadora.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btAtualizarDoadora.ForeColor = System.Drawing.Color.White
        Me.btAtualizarDoadora.Location = New System.Drawing.Point(102, 391)
        Me.btAtualizarDoadora.Name = "btAtualizarDoadora"
        Me.btAtualizarDoadora.Size = New System.Drawing.Size(75, 23)
        Me.btAtualizarDoadora.TabIndex = 27
        Me.btAtualizarDoadora.Text = "Atualizar"
        Me.btAtualizarDoadora.UseVisualStyleBackColor = False
        '
        'btExcluirDoadora
        '
        Me.btExcluirDoadora.BackColor = System.Drawing.Color.DarkRed
        Me.btExcluirDoadora.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btExcluirDoadora.Enabled = False
        Me.btExcluirDoadora.FlatAppearance.BorderSize = 0
        Me.btExcluirDoadora.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btExcluirDoadora.ForeColor = System.Drawing.Color.White
        Me.btExcluirDoadora.Location = New System.Drawing.Point(178, 391)
        Me.btExcluirDoadora.Name = "btExcluirDoadora"
        Me.btExcluirDoadora.Size = New System.Drawing.Size(75, 23)
        Me.btExcluirDoadora.TabIndex = 28
        Me.btExcluirDoadora.Text = "Excluir"
        Me.btExcluirDoadora.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cbTipoLeite)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.tbVolume)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.tbDataOrdenha)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Location = New System.Drawing.Point(26, 125)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(417, 260)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cadastro do leite"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.gbMotivos)
        Me.GroupBox2.Controls.Add(Me.rbNaoConforme)
        Me.GroupBox2.Controls.Add(Me.rbConforme)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 84)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(382, 166)
        Me.GroupBox2.TabIndex = 31
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Criterios de conformidade"
        '
        'gbMotivos
        '
        Me.gbMotivos.Controls.Add(Me.cbExamesVencidos)
        Me.gbMotivos.Controls.Add(Me.cbEmbalagem)
        Me.gbMotivos.Controls.Add(Me.cbRefrigeracao)
        Me.gbMotivos.Controls.Add(Me.cbVencidos15dias)
        Me.gbMotivos.Enabled = False
        Me.gbMotivos.Location = New System.Drawing.Point(23, 70)
        Me.gbMotivos.Name = "gbMotivos"
        Me.gbMotivos.Size = New System.Drawing.Size(335, 82)
        Me.gbMotivos.TabIndex = 2
        Me.gbMotivos.TabStop = False
        Me.gbMotivos.Text = "Motivos"
        '
        'cbExamesVencidos
        '
        Me.cbExamesVencidos.AutoSize = True
        Me.cbExamesVencidos.Location = New System.Drawing.Point(197, 48)
        Me.cbExamesVencidos.Name = "cbExamesVencidos"
        Me.cbExamesVencidos.Size = New System.Drawing.Size(109, 17)
        Me.cbExamesVencidos.TabIndex = 3
        Me.cbExamesVencidos.Text = "Exames vencidos"
        Me.cbExamesVencidos.UseVisualStyleBackColor = True
        '
        'cbEmbalagem
        '
        Me.cbEmbalagem.AutoSize = True
        Me.cbEmbalagem.Location = New System.Drawing.Point(197, 25)
        Me.cbEmbalagem.Name = "cbEmbalagem"
        Me.cbEmbalagem.Size = New System.Drawing.Size(81, 17)
        Me.cbEmbalagem.TabIndex = 2
        Me.cbEmbalagem.Text = "Embalagem"
        Me.cbEmbalagem.UseVisualStyleBackColor = True
        '
        'cbRefrigeracao
        '
        Me.cbRefrigeracao.AutoSize = True
        Me.cbRefrigeracao.Location = New System.Drawing.Point(23, 48)
        Me.cbRefrigeracao.Name = "cbRefrigeracao"
        Me.cbRefrigeracao.Size = New System.Drawing.Size(149, 17)
        Me.cbRefrigeracao.TabIndex = 1
        Me.cbRefrigeracao.Text = "Problemas de refrigeração"
        Me.cbRefrigeracao.UseVisualStyleBackColor = True
        '
        'cbVencidos15dias
        '
        Me.cbVencidos15dias.AutoSize = True
        Me.cbVencidos15dias.Location = New System.Drawing.Point(23, 25)
        Me.cbVencidos15dias.Name = "cbVencidos15dias"
        Me.cbVencidos15dias.Size = New System.Drawing.Size(168, 17)
        Me.cbVencidos15dias.TabIndex = 0
        Me.cbVencidos15dias.Text = "Vencimento superior a 15 dias"
        Me.cbVencidos15dias.UseVisualStyleBackColor = True
        '
        'rbNaoConforme
        '
        Me.rbNaoConforme.AutoSize = True
        Me.rbNaoConforme.Location = New System.Drawing.Point(99, 37)
        Me.rbNaoConforme.Name = "rbNaoConforme"
        Me.rbNaoConforme.Size = New System.Drawing.Size(92, 17)
        Me.rbNaoConforme.TabIndex = 1
        Me.rbNaoConforme.Text = "Não conforme"
        Me.rbNaoConforme.UseVisualStyleBackColor = True
        '
        'rbConforme
        '
        Me.rbConforme.AutoSize = True
        Me.rbConforme.Checked = True
        Me.rbConforme.Location = New System.Drawing.Point(23, 37)
        Me.rbConforme.Name = "rbConforme"
        Me.rbConforme.Size = New System.Drawing.Size(70, 17)
        Me.rbConforme.TabIndex = 0
        Me.rbConforme.TabStop = True
        Me.rbConforme.Text = "Conforme"
        Me.rbConforme.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(180, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 13)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Tipo do leite"
        '
        'cbTipoLeite
        '
        Me.cbTipoLeite.FormattingEnabled = True
        Me.cbTipoLeite.Location = New System.Drawing.Point(183, 45)
        Me.cbTipoLeite.Name = "cbTipoLeite"
        Me.cbTipoLeite.Size = New System.Drawing.Size(121, 21)
        Me.cbTipoLeite.TabIndex = 29
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(101, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "Volume"
        '
        'tbVolume
        '
        Me.tbVolume.Location = New System.Drawing.Point(104, 45)
        Me.tbVolume.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.tbVolume.Name = "tbVolume"
        Me.tbVolume.Size = New System.Drawing.Size(73, 20)
        Me.tbVolume.TabIndex = 27
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 13)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Data ordenha"
        '
        'tbDataOrdenha
        '
        Me.tbDataOrdenha.Location = New System.Drawing.Point(16, 44)
        Me.tbDataOrdenha.Mask = "00/00/0000"
        Me.tbDataOrdenha.Name = "tbDataOrdenha"
        Me.tbDataOrdenha.Size = New System.Drawing.Size(82, 20)
        Me.tbDataOrdenha.TabIndex = 25
        Me.tbDataOrdenha.ValidatingType = GetType(Date)
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(310, 47)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(47, 17)
        Me.RadioButton1.TabIndex = 23
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Apta"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(357, 47)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(55, 17)
        Me.RadioButton2.TabIndex = 24
        Me.RadioButton2.Text = "Inapta"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'cbParto
        '
        Me.cbParto.FormattingEnabled = True
        Me.cbParto.Location = New System.Drawing.Point(328, 46)
        Me.cbParto.Name = "cbParto"
        Me.cbParto.Size = New System.Drawing.Size(115, 21)
        Me.cbParto.TabIndex = 22
        '
        'cbDoadoras
        '
        Me.cbDoadoras.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbDoadoras.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbDoadoras.FormattingEnabled = True
        Me.cbDoadoras.Location = New System.Drawing.Point(26, 46)
        Me.cbDoadoras.Name = "cbDoadoras"
        Me.cbDoadoras.Size = New System.Drawing.Size(296, 21)
        Me.cbDoadoras.TabIndex = 21
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(469, 427)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Seleção para pasteurização"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 487)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(498, 22)
        Me.StatusStrip1.TabIndex = 23
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'FormBLHProcessamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 509)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormBLHProcessamento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleção LHOC"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gbMotivos.ResumeLayout(False)
        Me.gbMotivos.PerformLayout()
        CType(Me.tbVolume, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cbResultado As ComboBox
    Friend WithEvents tbDataVencimento As MaskedTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents tbDataSorologia As MaskedTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cbOrigem As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents cbDoadoras As ComboBox
    Friend WithEvents cbParto As ComboBox
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents tbDataOrdenha As MaskedTextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents tbVolume As NumericUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents cbTipoLeite As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rbNaoConforme As RadioButton
    Friend WithEvents rbConforme As RadioButton
    Friend WithEvents gbMotivos As GroupBox
    Friend WithEvents cbExamesVencidos As CheckBox
    Friend WithEvents cbEmbalagem As CheckBox
    Friend WithEvents cbRefrigeracao As CheckBox
    Friend WithEvents cbVencidos15dias As CheckBox
    Friend WithEvents btCancelar As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents btSalvarDoadora As Button
    Friend WithEvents btAtualizarDoadora As Button
    Friend WithEvents btExcluirDoadora As Button
    Friend WithEvents StatusStrip1 As StatusStrip
End Class
