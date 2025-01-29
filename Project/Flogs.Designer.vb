<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Flogs
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Flogs))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpInicial = New System.Windows.Forms.DateTimePicker()
        Me.dgLogs = New System.Windows.Forms.DataGridView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.btSair = New System.Windows.Forms.Button()
        Me.tbSearch = New System.Windows.Forms.TextBox()
        Me.lbNomeFantasia = New System.Windows.Forms.Label()
        Me.btSearchLog = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgLogs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtpFinal)
        Me.GroupBox1.Controls.Add(Me.dtpInicial)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(295, 59)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Selecione o período"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(141, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "à"
        '
        'dtpFinal
        '
        Me.dtpFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFinal.Location = New System.Drawing.Point(160, 24)
        Me.dtpFinal.Name = "dtpFinal"
        Me.dtpFinal.Size = New System.Drawing.Size(117, 26)
        Me.dtpFinal.TabIndex = 6
        '
        'dtpInicial
        '
        Me.dtpInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInicial.Location = New System.Drawing.Point(18, 24)
        Me.dtpInicial.Name = "dtpInicial"
        Me.dtpInicial.Size = New System.Drawing.Size(117, 26)
        Me.dtpInicial.TabIndex = 4
        '
        'dgLogs
        '
        Me.dgLogs.AllowUserToAddRows = False
        Me.dgLogs.AllowUserToDeleteRows = False
        Me.dgLogs.AllowUserToResizeRows = False
        Me.dgLogs.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgLogs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgLogs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkSeaGreen
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkSeaGreen
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgLogs.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgLogs.GridColor = System.Drawing.SystemColors.Control
        Me.dgLogs.Location = New System.Drawing.Point(12, 77)
        Me.dgLogs.MultiSelect = False
        Me.dgLogs.Name = "dgLogs"
        Me.dgLogs.ReadOnly = True
        Me.dgLogs.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgLogs.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgLogs.RowHeadersWidth = 4
        Me.dgLogs.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgLogs.Size = New System.Drawing.Size(576, 343)
        Me.dgLogs.TabIndex = 27
        Me.dgLogs.TabStop = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 436)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(600, 22)
        Me.StatusStrip1.TabIndex = 28
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'btSair
        '
        Me.btSair.BackColor = System.Drawing.Color.DarkGray
        Me.btSair.FlatAppearance.BorderSize = 0
        Me.btSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btSair.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSair.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btSair.Location = New System.Drawing.Point(532, 12)
        Me.btSair.Name = "btSair"
        Me.btSair.Size = New System.Drawing.Size(56, 59)
        Me.btSair.TabIndex = 45
        Me.btSair.Text = "Sair"
        Me.btSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btSair.UseVisualStyleBackColor = False
        '
        'tbSearch
        '
        Me.tbSearch.BackColor = System.Drawing.SystemColors.Info
        Me.tbSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbSearch.Location = New System.Drawing.Point(313, 51)
        Me.tbSearch.Name = "tbSearch"
        Me.tbSearch.Size = New System.Drawing.Size(178, 20)
        Me.tbSearch.TabIndex = 46
        Me.tbSearch.Tag = "1"
        '
        'lbNomeFantasia
        '
        Me.lbNomeFantasia.AutoSize = True
        Me.lbNomeFantasia.Location = New System.Drawing.Point(310, 35)
        Me.lbNomeFantasia.Name = "lbNomeFantasia"
        Me.lbNomeFantasia.Size = New System.Drawing.Size(121, 13)
        Me.lbNomeFantasia.TabIndex = 47
        Me.lbNomeFantasia.Text = "Localizar Log contendo:"
        '
        'btSearchLog
        '
        ' Me.btSearchLog.Image = Global.Project.My.Resources.Resources.l2
        Me.btSearchLog.Location = New System.Drawing.Point(493, 37)
        Me.btSearchLog.Name = "btSearchLog"
        Me.btSearchLog.Size = New System.Drawing.Size(33, 35)
        Me.btSearchLog.TabIndex = 48
        Me.btSearchLog.Tag = "1"
        Me.btSearchLog.UseVisualStyleBackColor = True
        '
        'Flogs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 458)
        Me.Controls.Add(Me.btSearchLog)
        Me.Controls.Add(Me.tbSearch)
        Me.Controls.Add(Me.lbNomeFantasia)
        Me.Controls.Add(Me.btSair)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.dgLogs)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Flogs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Logs do sistema"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgLogs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgLogs As System.Windows.Forms.DataGridView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents btSair As System.Windows.Forms.Button
    Friend WithEvents tbSearch As System.Windows.Forms.TextBox
    Friend WithEvents lbNomeFantasia As System.Windows.Forms.Label
    Friend WithEvents btSearchLog As System.Windows.Forms.Button
End Class
