<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fbackup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fbackup))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btrestaurar = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblocalbkp = New System.Windows.Forms.ToolStripStatusLabel()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbstatus = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btdesativa = New System.Windows.Forms.Button()
        Me.btativar = New System.Windows.Forms.Button()
        Me.dtph2 = New System.Windows.Forms.DateTimePicker()
        Me.dtph1 = New System.Windows.Forms.DateTimePicker()
        Me.dtpdiaria = New System.Windows.Forms.DateTimePicker()
        Me.rbx = New System.Windows.Forms.RadioButton()
        Me.rbdiaria = New System.Windows.Forms.RadioButton()
        Me.btbackup = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ConfigToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MysqldumpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MysqlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "mysqldump"
        Me.OpenFileDialog1.InitialDirectory = "c:\wamp"
        '
        'btrestaurar
        '
        Me.btrestaurar.BackColor = System.Drawing.Color.SteelBlue
        Me.btrestaurar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btrestaurar.FlatAppearance.BorderSize = 0
        Me.btrestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btrestaurar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btrestaurar.ForeColor = System.Drawing.Color.White
        Me.btrestaurar.Location = New System.Drawing.Point(131, 33)
        Me.btrestaurar.Name = "btrestaurar"
        Me.btrestaurar.Size = New System.Drawing.Size(113, 62)
        Me.btrestaurar.TabIndex = 107
        Me.btrestaurar.Text = "RESTAURAR"
        Me.btrestaurar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btrestaurar.UseVisualStyleBackColor = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblocalbkp})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 115)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(256, 22)
        Me.StatusStrip1.TabIndex = 108
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblocalbkp
        '
        Me.lblocalbkp.Name = "lblocalbkp"
        Me.lblocalbkp.Size = New System.Drawing.Size(0, 17)
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "Selecione um local para o Backup"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lbstatus)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btdesativa)
        Me.GroupBox1.Controls.Add(Me.btativar)
        Me.GroupBox1.Controls.Add(Me.dtph2)
        Me.GroupBox1.Controls.Add(Me.dtph1)
        Me.GroupBox1.Controls.Add(Me.dtpdiaria)
        Me.GroupBox1.Controls.Add(Me.rbx)
        Me.GroupBox1.Controls.Add(Me.rbdiaria)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(541, 33)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(292, 186)
        Me.GroupBox1.TabIndex = 109
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Programar Backup"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(142, 135)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(13, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "e"
        '
        'lbstatus
        '
        Me.lbstatus.AutoSize = True
        Me.lbstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbstatus.Location = New System.Drawing.Point(59, 37)
        Me.lbstatus.Name = "lbstatus"
        Me.lbstatus.Size = New System.Drawing.Size(43, 13)
        Me.lbstatus.TabIndex = 11
        Me.lbstatus.Text = "Status"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Status:"
        '
        'btdesativa
        '
        Me.btdesativa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btdesativa.Location = New System.Drawing.Point(149, 157)
        Me.btdesativa.Name = "btdesativa"
        Me.btdesativa.Size = New System.Drawing.Size(137, 23)
        Me.btdesativa.TabIndex = 9
        Me.btdesativa.Text = "Desativa Backup Auto"
        Me.btdesativa.UseVisualStyleBackColor = True
        '
        'btativar
        '
        Me.btativar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btativar.Location = New System.Drawing.Point(6, 157)
        Me.btativar.Name = "btativar"
        Me.btativar.Size = New System.Drawing.Size(137, 23)
        Me.btativar.TabIndex = 7
        Me.btativar.Text = "Ativa Backup Auto"
        Me.btativar.UseVisualStyleBackColor = True
        '
        'dtph2
        '
        Me.dtph2.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtph2.Location = New System.Drawing.Point(158, 132)
        Me.dtph2.Name = "dtph2"
        Me.dtph2.ShowUpDown = True
        Me.dtph2.Size = New System.Drawing.Size(78, 20)
        Me.dtph2.TabIndex = 4
        '
        'dtph1
        '
        Me.dtph1.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtph1.Location = New System.Drawing.Point(158, 106)
        Me.dtph1.Name = "dtph1"
        Me.dtph1.ShowUpDown = True
        Me.dtph1.Size = New System.Drawing.Size(78, 20)
        Me.dtph1.TabIndex = 3
        '
        'dtpdiaria
        '
        Me.dtpdiaria.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpdiaria.Location = New System.Drawing.Point(158, 69)
        Me.dtpdiaria.Name = "dtpdiaria"
        Me.dtpdiaria.ShowUpDown = True
        Me.dtpdiaria.Size = New System.Drawing.Size(78, 20)
        Me.dtpdiaria.TabIndex = 2
        '
        'rbx
        '
        Me.rbx.AutoSize = True
        Me.rbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbx.Location = New System.Drawing.Point(45, 106)
        Me.rbx.Name = "rbx"
        Me.rbx.Size = New System.Drawing.Size(111, 17)
        Me.rbx.TabIndex = 1
        Me.rbx.TabStop = True
        Me.rbx.Text = "2 vezes ao dia às:"
        Me.rbx.UseVisualStyleBackColor = True
        '
        'rbdiaria
        '
        Me.rbdiaria.AutoSize = True
        Me.rbdiaria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbdiaria.Location = New System.Drawing.Point(45, 69)
        Me.rbdiaria.Name = "rbdiaria"
        Me.rbdiaria.Size = New System.Drawing.Size(98, 17)
        Me.rbdiaria.TabIndex = 0
        Me.rbdiaria.TabStop = True
        Me.rbdiaria.Text = "Diariamente às:"
        Me.rbdiaria.UseVisualStyleBackColor = True
        '
        'btbackup
        '
        Me.btbackup.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.btbackup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btbackup.FlatAppearance.BorderSize = 0
        Me.btbackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btbackup.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btbackup.ForeColor = System.Drawing.Color.White
        Me.btbackup.Location = New System.Drawing.Point(12, 33)
        Me.btbackup.Name = "btbackup"
        Me.btbackup.Size = New System.Drawing.Size(113, 62)
        Me.btbackup.TabIndex = 106
        Me.btbackup.Text = "BACKUP"
        Me.btbackup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btbackup.UseVisualStyleBackColor = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfigToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(256, 24)
        Me.MenuStrip1.TabIndex = 112
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ConfigToolStripMenuItem
        '
        Me.ConfigToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MysqldumpToolStripMenuItem, Me.MysqlToolStripMenuItem})
        Me.ConfigToolStripMenuItem.Name = "ConfigToolStripMenuItem"
        Me.ConfigToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.ConfigToolStripMenuItem.Text = "Config"
        '
        'MysqldumpToolStripMenuItem
        '
        Me.MysqldumpToolStripMenuItem.Name = "MysqldumpToolStripMenuItem"
        Me.MysqldumpToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.MysqldumpToolStripMenuItem.Text = "Mysqldump"
        '
        'MysqlToolStripMenuItem
        '
        Me.MysqlToolStripMenuItem.Name = "MysqlToolStripMenuItem"
        Me.MysqlToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.MysqlToolStripMenuItem.Text = "Mysql"
        '
        'Fbackup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(256, 137)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.btrestaurar)
        Me.Controls.Add(Me.btbackup)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fbackup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Backup"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btbackup As System.Windows.Forms.Button
    Friend WithEvents btrestaurar As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtph2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtph1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents rbx As System.Windows.Forms.RadioButton
    Friend WithEvents rbdiaria As System.Windows.Forms.RadioButton
    Friend WithEvents btdesativa As System.Windows.Forms.Button
    Friend WithEvents btativar As System.Windows.Forms.Button
    Friend WithEvents lbstatus As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpdiaria As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblocalbkp As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ConfigToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MysqldumpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MysqlToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
