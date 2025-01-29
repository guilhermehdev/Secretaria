<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRelatorioPrazos
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRelatorioPrazos))
        Me.NumericUpDownEmAndamento = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btOKEmAndamento = New System.Windows.Forms.Button()
        Me.lbEmAndamento = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopiarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btOKVencidos = New System.Windows.Forms.Button()
        Me.lbVencidos = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopiarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbDestino = New System.Windows.Forms.ComboBox()
        Me.cbPeriodoVencido = New System.Windows.Forms.ComboBox()
        CType(Me.NumericUpDownEmAndamento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NumericUpDownEmAndamento
        '
        Me.NumericUpDownEmAndamento.Location = New System.Drawing.Point(177, 43)
        Me.NumericUpDownEmAndamento.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.NumericUpDownEmAndamento.Name = "NumericUpDownEmAndamento"
        Me.NumericUpDownEmAndamento.Size = New System.Drawing.Size(75, 20)
        Me.NumericUpDownEmAndamento.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Dias para o vencimento (max 30)"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btOKEmAndamento)
        Me.GroupBox1.Controls.Add(Me.lbEmAndamento)
        Me.GroupBox1.Controls.Add(Me.NumericUpDownEmAndamento)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 53)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(347, 412)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Em andamento"
        '
        'btOKEmAndamento
        '
        Me.btOKEmAndamento.Location = New System.Drawing.Point(258, 41)
        Me.btOKEmAndamento.Name = "btOKEmAndamento"
        Me.btOKEmAndamento.Size = New System.Drawing.Size(75, 23)
        Me.btOKEmAndamento.TabIndex = 3
        Me.btOKEmAndamento.Text = "OK"
        Me.btOKEmAndamento.UseVisualStyleBackColor = True
        '
        'lbEmAndamento
        '
        Me.lbEmAndamento.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lbEmAndamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEmAndamento.FormattingEnabled = True
        Me.lbEmAndamento.ItemHeight = 15
        Me.lbEmAndamento.Location = New System.Drawing.Point(13, 70)
        Me.lbEmAndamento.Name = "lbEmAndamento"
        Me.lbEmAndamento.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbEmAndamento.Size = New System.Drawing.Size(320, 319)
        Me.lbEmAndamento.TabIndex = 2
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopiarToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(110, 26)
        '
        'CopiarToolStripMenuItem
        '
        Me.CopiarToolStripMenuItem.Name = "CopiarToolStripMenuItem"
        Me.CopiarToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.CopiarToolStripMenuItem.Text = "Copiar"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbPeriodoVencido)
        Me.GroupBox2.Controls.Add(Me.btOKVencidos)
        Me.GroupBox2.Controls.Add(Me.lbVencidos)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(365, 53)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(349, 412)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Vencidos"
        '
        'btOKVencidos
        '
        Me.btOKVencidos.Location = New System.Drawing.Point(257, 41)
        Me.btOKVencidos.Name = "btOKVencidos"
        Me.btOKVencidos.Size = New System.Drawing.Size(75, 23)
        Me.btOKVencidos.TabIndex = 4
        Me.btOKVencidos.Text = "OK"
        Me.btOKVencidos.UseVisualStyleBackColor = True
        '
        'lbVencidos
        '
        Me.lbVencidos.ContextMenuStrip = Me.ContextMenuStrip2
        Me.lbVencidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbVencidos.FormattingEnabled = True
        Me.lbVencidos.ItemHeight = 15
        Me.lbVencidos.Location = New System.Drawing.Point(12, 70)
        Me.lbVencidos.Name = "lbVencidos"
        Me.lbVencidos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbVencidos.Size = New System.Drawing.Size(320, 319)
        Me.lbVencidos.TabIndex = 2
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopiarToolStripMenuItem1})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(110, 26)
        '
        'CopiarToolStripMenuItem1
        '
        Me.CopiarToolStripMenuItem1.Name = "CopiarToolStripMenuItem1"
        Me.CopiarToolStripMenuItem1.Size = New System.Drawing.Size(109, 22)
        Me.CopiarToolStripMenuItem1.Text = "Copiar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Vencidos no período de"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 465)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(729, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(119, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Destino"
        '
        'cbDestino
        '
        Me.cbDestino.FormattingEnabled = True
        Me.cbDestino.Location = New System.Drawing.Point(61, 15)
        Me.cbDestino.Name = "cbDestino"
        Me.cbDestino.Size = New System.Drawing.Size(298, 21)
        Me.cbDestino.TabIndex = 8
        Me.cbDestino.Tag = "Destinatário"
        '
        'cbPeriodoVencido
        '
        Me.cbPeriodoVencido.FormattingEnabled = True
        Me.cbPeriodoVencido.Location = New System.Drawing.Point(136, 42)
        Me.cbPeriodoVencido.Name = "cbPeriodoVencido"
        Me.cbPeriodoVencido.Size = New System.Drawing.Size(115, 21)
        Me.cbPeriodoVencido.TabIndex = 5
        '
        'FRelatorioPrazos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(729, 487)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbDestino)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FRelatorioPrazos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Prazos"
        CType(Me.NumericUpDownEmAndamento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents NumericUpDownEmAndamento As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbEmAndamento As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbVencidos As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btOKEmAndamento As System.Windows.Forms.Button
    Friend WithEvents btOKVencidos As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbDestino As System.Windows.Forms.ComboBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopiarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopiarToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cbPeriodoVencido As System.Windows.Forms.ComboBox
End Class
