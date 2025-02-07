<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOuvidoriasOK
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
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgProtocolosOK = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RichTextBoxRespostaAutorizada = New System.Windows.Forms.RichTextBox()
        Me.btCopiaResposta = New System.Windows.Forms.Button()
        Me.tbBuscaProtocolo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgProtocolosOK, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgProtocolosOK
        '
        Me.dgProtocolosOK.AllowUserToAddRows = False
        Me.dgProtocolosOK.AllowUserToDeleteRows = False
        Me.dgProtocolosOK.AllowUserToOrderColumns = True
        Me.dgProtocolosOK.AllowUserToResizeRows = False
        Me.dgProtocolosOK.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgProtocolosOK.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgProtocolosOK.BackgroundColor = System.Drawing.Color.White
        Me.dgProtocolosOK.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgProtocolosOK.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgProtocolosOK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgProtocolosOK.DefaultCellStyle = DataGridViewCellStyle18
        Me.dgProtocolosOK.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.dgProtocolosOK.Location = New System.Drawing.Point(6, 50)
        Me.dgProtocolosOK.MultiSelect = False
        Me.dgProtocolosOK.Name = "dgProtocolosOK"
        Me.dgProtocolosOK.ReadOnly = True
        Me.dgProtocolosOK.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProtocolosOK.RowHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.dgProtocolosOK.RowHeadersWidth = 4
        Me.dgProtocolosOK.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgProtocolosOK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgProtocolosOK.Size = New System.Drawing.Size(551, 233)
        Me.dgProtocolosOK.TabIndex = 31
        Me.dgProtocolosOK.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.tbBuscaProtocolo)
        Me.GroupBox1.Controls.Add(Me.dgProtocolosOK)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(563, 289)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Gainsboro
        Me.GroupBox2.Controls.Add(Me.btCopiaResposta)
        Me.GroupBox2.Controls.Add(Me.RichTextBoxRespostaAutorizada)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.GroupBox2.Location = New System.Drawing.Point(12, 307)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(563, 289)
        Me.GroupBox2.TabIndex = 33
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Resposta"
        '
        'RichTextBoxRespostaAutorizada
        '
        Me.RichTextBoxRespostaAutorizada.BackColor = System.Drawing.Color.Ivory
        Me.RichTextBoxRespostaAutorizada.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBoxRespostaAutorizada.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBoxRespostaAutorizada.Location = New System.Drawing.Point(6, 43)
        Me.RichTextBoxRespostaAutorizada.Name = "RichTextBoxRespostaAutorizada"
        Me.RichTextBoxRespostaAutorizada.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.RichTextBoxRespostaAutorizada.Size = New System.Drawing.Size(551, 240)
        Me.RichTextBoxRespostaAutorizada.TabIndex = 0
        Me.RichTextBoxRespostaAutorizada.Text = ""
        '
        'btCopiaResposta
        '
        Me.btCopiaResposta.BackColor = System.Drawing.Color.Gainsboro
        Me.btCopiaResposta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btCopiaResposta.FlatAppearance.BorderSize = 0
        Me.btCopiaResposta.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btCopiaResposta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCopiaResposta.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btCopiaResposta.Location = New System.Drawing.Point(482, 14)
        Me.btCopiaResposta.Name = "btCopiaResposta"
        Me.btCopiaResposta.Size = New System.Drawing.Size(75, 23)
        Me.btCopiaResposta.TabIndex = 1
        Me.btCopiaResposta.Text = "Copiar"
        Me.btCopiaResposta.UseVisualStyleBackColor = False
        '
        'tbBuscaProtocolo
        '
        Me.tbBuscaProtocolo.BackColor = System.Drawing.SystemColors.ControlText
        Me.tbBuscaProtocolo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbBuscaProtocolo.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.tbBuscaProtocolo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBuscaProtocolo.ForeColor = System.Drawing.Color.Orange
        Me.tbBuscaProtocolo.Location = New System.Drawing.Point(77, 25)
        Me.tbBuscaProtocolo.MaxLength = 8
        Me.tbBuscaProtocolo.Name = "tbBuscaProtocolo"
        Me.tbBuscaProtocolo.Size = New System.Drawing.Size(105, 22)
        Me.tbBuscaProtocolo.TabIndex = 34
        Me.tbBuscaProtocolo.Tag = "Nº Protocolo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(7, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Nº Protocolo:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, -4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 18)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Protocolo"
        '
        'FormOuvidoriasOK
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(587, 608)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormOuvidoriasOK"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ouvidorias autorizadas para envio"
        CType(Me.dgProtocolosOK, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgProtocolosOK As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents RichTextBoxRespostaAutorizada As RichTextBox
    Friend WithEvents btCopiaResposta As Button
    Friend WithEvents tbBuscaProtocolo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
