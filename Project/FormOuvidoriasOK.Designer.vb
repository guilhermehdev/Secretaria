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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgProtocolosOK = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btRefresh = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbBuscaProtocolo = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btCopiaResposta = New System.Windows.Forms.Button()
        Me.RichTextBoxRespostaAutorizada = New System.Windows.Forms.RichTextBox()
        Me.btConcluirOuvidoria = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.StatusLabelRegistrosOuve = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btClose = New System.Windows.Forms.Button()
        CType(Me.dgProtocolosOK, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgProtocolosOK.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgProtocolosOK.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.dgProtocolosOK.Location = New System.Drawing.Point(6, 50)
        Me.dgProtocolosOK.MultiSelect = False
        Me.dgProtocolosOK.Name = "dgProtocolosOK"
        Me.dgProtocolosOK.ReadOnly = True
        Me.dgProtocolosOK.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProtocolosOK.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgProtocolosOK.RowHeadersWidth = 4
        Me.dgProtocolosOK.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgProtocolosOK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgProtocolosOK.Size = New System.Drawing.Size(551, 233)
        Me.dgProtocolosOK.TabIndex = 31
        Me.dgProtocolosOK.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btRefresh)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.tbBuscaProtocolo)
        Me.GroupBox1.Controls.Add(Me.dgProtocolosOK)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(563, 289)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        '
        'btRefresh
        '
        Me.btRefresh.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btRefresh.BackgroundImage = Global.Project.My.Resources.Resources.reload
        Me.btRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btRefresh.FlatAppearance.BorderSize = 0
        Me.btRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btRefresh.ForeColor = System.Drawing.Color.White
        Me.btRefresh.Location = New System.Drawing.Point(188, 11)
        Me.btRefresh.Name = "btRefresh"
        Me.btRefresh.Size = New System.Drawing.Size(45, 36)
        Me.btRefresh.TabIndex = 37
        Me.btRefresh.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(5, -4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 18)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Protocolo"
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
        'tbBuscaProtocolo
        '
        Me.tbBuscaProtocolo.BackColor = System.Drawing.SystemColors.ControlText
        Me.tbBuscaProtocolo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbBuscaProtocolo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbBuscaProtocolo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBuscaProtocolo.ForeColor = System.Drawing.Color.Orange
        Me.tbBuscaProtocolo.Location = New System.Drawing.Point(77, 25)
        Me.tbBuscaProtocolo.MaxLength = 8
        Me.tbBuscaProtocolo.Name = "tbBuscaProtocolo"
        Me.tbBuscaProtocolo.Size = New System.Drawing.Size(105, 22)
        Me.tbBuscaProtocolo.TabIndex = 34
        Me.tbBuscaProtocolo.Tag = "Nº Protocolo"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
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
        'RichTextBoxRespostaAutorizada
        '
        Me.RichTextBoxRespostaAutorizada.BackColor = System.Drawing.Color.Linen
        Me.RichTextBoxRespostaAutorizada.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBoxRespostaAutorizada.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBoxRespostaAutorizada.Location = New System.Drawing.Point(6, 43)
        Me.RichTextBoxRespostaAutorizada.Name = "RichTextBoxRespostaAutorizada"
        Me.RichTextBoxRespostaAutorizada.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.RichTextBoxRespostaAutorizada.Size = New System.Drawing.Size(551, 240)
        Me.RichTextBoxRespostaAutorizada.TabIndex = 0
        Me.RichTextBoxRespostaAutorizada.Text = ""
        '
        'btConcluirOuvidoria
        '
        Me.btConcluirOuvidoria.BackColor = System.Drawing.Color.ForestGreen
        Me.btConcluirOuvidoria.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btConcluirOuvidoria.FlatAppearance.BorderSize = 0
        Me.btConcluirOuvidoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btConcluirOuvidoria.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btConcluirOuvidoria.Location = New System.Drawing.Point(375, 602)
        Me.btConcluirOuvidoria.Name = "btConcluirOuvidoria"
        Me.btConcluirOuvidoria.Size = New System.Drawing.Size(119, 32)
        Me.btConcluirOuvidoria.TabIndex = 34
        Me.btConcluirOuvidoria.Text = "Concluir Ouvidoria"
        Me.btConcluirOuvidoria.UseVisualStyleBackColor = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabelRegistrosOuve})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 642)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(585, 22)
        Me.StatusStrip1.TabIndex = 35
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusLabelRegistrosOuve
        '
        Me.StatusLabelRegistrosOuve.Name = "StatusLabelRegistrosOuve"
        Me.StatusLabelRegistrosOuve.Size = New System.Drawing.Size(38, 17)
        Me.StatusLabelRegistrosOuve.Text = "status"
        '
        'btClose
        '
        Me.btClose.BackColor = System.Drawing.Color.IndianRed
        Me.btClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btClose.FlatAppearance.BorderSize = 0
        Me.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btClose.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btClose.Location = New System.Drawing.Point(500, 602)
        Me.btClose.Name = "btClose"
        Me.btClose.Size = New System.Drawing.Size(75, 32)
        Me.btClose.TabIndex = 36
        Me.btClose.Text = "Sair"
        Me.btClose.UseVisualStyleBackColor = False
        '
        'FormOuvidoriasOK
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(585, 664)
        Me.Controls.Add(Me.btClose)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btConcluirOuvidoria)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormOuvidoriasOK"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ouvidorias autorizadas para concluir"
        CType(Me.dgProtocolosOK, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgProtocolosOK As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents RichTextBoxRespostaAutorizada As RichTextBox
    Friend WithEvents btCopiaResposta As Button
    Friend WithEvents tbBuscaProtocolo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btRefresh As Button
    Friend WithEvents btConcluirOuvidoria As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents StatusLabelRegistrosOuve As ToolStripStatusLabel
    Friend WithEvents btClose As Button
End Class
