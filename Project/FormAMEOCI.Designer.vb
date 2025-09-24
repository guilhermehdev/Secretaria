<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAMEOCI
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtCompetencia = New System.Windows.Forms.TextBox()
        Me.txtNumApac = New System.Windows.Forms.TextBox()
        Me.txtApacAnterior = New System.Windows.Forms.TextBox()
        Me.txtCNESSolicitante = New System.Windows.Forms.TextBox()
        Me.txtCnesExecutante = New System.Windows.Forms.TextBox()
        Me.dtValidadeIni = New System.Windows.Forms.DateTimePicker()
        Me.dtValidadeFim = New System.Windows.Forms.DateTimePicker()
        Me.cboTipoApac = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtNomeDiretor = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtProntuario = New System.Windows.Forms.TextBox()
        Me.chkSituacaoRua = New System.Windows.Forms.CheckBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtTelefone = New System.Windows.Forms.TextBox()
        Me.txtEtnia = New System.Windows.Forms.TextBox()
        Me.cboRaca = New System.Windows.Forms.ComboBox()
        Me.cboSexo = New System.Windows.Forms.ComboBox()
        Me.dtNascimento = New System.Windows.Forms.DateTimePicker()
        Me.txtMunicipioNome = New System.Windows.Forms.TextBox()
        Me.txtMunicipioCod = New System.Windows.Forms.TextBox()
        Me.txtCep = New System.Windows.Forms.MaskedTextBox()
        Me.txtBairro = New System.Windows.Forms.TextBox()
        Me.txtComplemento = New System.Windows.Forms.TextBox()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.txtEndereco = New System.Windows.Forms.TextBox()
        Me.txtNomeResponsavel = New System.Windows.Forms.TextBox()
        Me.txtNomeMae = New System.Windows.Forms.TextBox()
        Me.txtNomePaciente = New System.Windows.Forms.TextBox()
        Me.txtCnsPaciente = New System.Windows.Forms.TextBox()
        Me.txtCpfPaciente = New System.Windows.Forms.MaskedTextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dtAltaObito = New System.Windows.Forms.DateTimePicker()
        Me.cboMotivoSaida = New System.Windows.Forms.ComboBox()
        Me.txtCodOrgaoEmissor = New System.Windows.Forms.TextBox()
        Me.txtNomeAutorizador = New System.Windows.Forms.TextBox()
        Me.dtSolicitacao = New System.Windows.Forms.DateTimePicker()
        Me.txtCidSecundario = New System.Windows.Forms.TextBox()
        Me.txtCidPrincipal = New System.Windows.Forms.TextBox()
        Me.cboCaraterAtendimento = New System.Windows.Forms.ComboBox()
        Me.dtAutorizacao = New System.Windows.Forms.DateTimePicker()
        Me.txtCnsAutorizador = New System.Windows.Forms.TextBox()
        Me.txtNomeMedicoSolicitante = New System.Windows.Forms.TextBox()
        Me.txtCnsMedicoSolicitante = New System.Windows.Forms.TextBox()
        Me.txtProcedimentoPrincipal = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnRemoverProcedimento = New System.Windows.Forms.Button()
        Me.btnAdicionarProcedimento = New System.Windows.Forms.Button()
        Me.CnesTerceiro = New System.Windows.Forms.TextBox()
        Me.CnsExecutante = New System.Windows.Forms.TextBox()
        Me.CidSecundario = New System.Windows.Forms.TextBox()
        Me.Descricao = New System.Windows.Forms.TextBox()
        Me.CidPrincipal = New System.Windows.Forms.TextBox()
        Me.Quantidade = New System.Windows.Forms.TextBox()
        Me.CBOmed = New System.Windows.Forms.TextBox()
        Me.CodProcedimento = New System.Windows.Forms.TextBox()
        Me.gridProcedimentos = New System.Windows.Forms.DataGridView()
        Me.btnGerarArquivo = New System.Windows.Forms.Button()
        Me.txtCnsDiretor = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.gridProcedimentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCompetencia
        '
        Me.txtCompetencia.Location = New System.Drawing.Point(18, 25)
        Me.txtCompetencia.Name = "txtCompetencia"
        Me.txtCompetencia.Size = New System.Drawing.Size(100, 20)
        Me.txtCompetencia.TabIndex = 0
        '
        'txtNumApac
        '
        Me.txtNumApac.Location = New System.Drawing.Point(137, 25)
        Me.txtNumApac.Name = "txtNumApac"
        Me.txtNumApac.Size = New System.Drawing.Size(100, 20)
        Me.txtNumApac.TabIndex = 1
        '
        'txtApacAnterior
        '
        Me.txtApacAnterior.Location = New System.Drawing.Point(261, 25)
        Me.txtApacAnterior.Name = "txtApacAnterior"
        Me.txtApacAnterior.Size = New System.Drawing.Size(100, 20)
        Me.txtApacAnterior.TabIndex = 2
        '
        'txtCNESSolicitante
        '
        Me.txtCNESSolicitante.Location = New System.Drawing.Point(381, 25)
        Me.txtCNESSolicitante.Name = "txtCNESSolicitante"
        Me.txtCNESSolicitante.Size = New System.Drawing.Size(100, 20)
        Me.txtCNESSolicitante.TabIndex = 3
        '
        'txtCnesExecutante
        '
        Me.txtCnesExecutante.Location = New System.Drawing.Point(18, 51)
        Me.txtCnesExecutante.Name = "txtCnesExecutante"
        Me.txtCnesExecutante.Size = New System.Drawing.Size(100, 20)
        Me.txtCnesExecutante.TabIndex = 4
        '
        'dtValidadeIni
        '
        Me.dtValidadeIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtValidadeIni.Location = New System.Drawing.Point(137, 51)
        Me.dtValidadeIni.Name = "dtValidadeIni"
        Me.dtValidadeIni.Size = New System.Drawing.Size(99, 20)
        Me.dtValidadeIni.TabIndex = 5
        '
        'dtValidadeFim
        '
        Me.dtValidadeFim.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtValidadeFim.Location = New System.Drawing.Point(243, 51)
        Me.dtValidadeFim.Name = "dtValidadeFim"
        Me.dtValidadeFim.Size = New System.Drawing.Size(99, 20)
        Me.dtValidadeFim.TabIndex = 6
        '
        'cboTipoApac
        '
        Me.cboTipoApac.FormattingEnabled = True
        Me.cboTipoApac.Location = New System.Drawing.Point(349, 50)
        Me.cboTipoApac.Name = "cboTipoApac"
        Me.cboTipoApac.Size = New System.Drawing.Size(132, 21)
        Me.cboTipoApac.TabIndex = 7
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtCnsDiretor)
        Me.GroupBox1.Controls.Add(Me.txtCompetencia)
        Me.GroupBox1.Controls.Add(Me.cboTipoApac)
        Me.GroupBox1.Controls.Add(Me.txtNumApac)
        Me.GroupBox1.Controls.Add(Me.dtValidadeFim)
        Me.GroupBox1.Controls.Add(Me.txtApacAnterior)
        Me.GroupBox1.Controls.Add(Me.dtValidadeIni)
        Me.GroupBox1.Controls.Add(Me.txtNomeDiretor)
        Me.GroupBox1.Controls.Add(Me.txtCNESSolicitante)
        Me.GroupBox1.Controls.Add(Me.txtCnesExecutante)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(497, 126)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cabeçalho"
        '
        'txtNomeDiretor
        '
        Me.txtNomeDiretor.Location = New System.Drawing.Point(18, 77)
        Me.txtNomeDiretor.Name = "txtNomeDiretor"
        Me.txtNomeDiretor.Size = New System.Drawing.Size(249, 20)
        Me.txtNomeDiretor.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtProntuario)
        Me.GroupBox2.Controls.Add(Me.chkSituacaoRua)
        Me.GroupBox2.Controls.Add(Me.txtEmail)
        Me.GroupBox2.Controls.Add(Me.txtTelefone)
        Me.GroupBox2.Controls.Add(Me.txtEtnia)
        Me.GroupBox2.Controls.Add(Me.cboRaca)
        Me.GroupBox2.Controls.Add(Me.cboSexo)
        Me.GroupBox2.Controls.Add(Me.dtNascimento)
        Me.GroupBox2.Controls.Add(Me.txtMunicipioNome)
        Me.GroupBox2.Controls.Add(Me.txtMunicipioCod)
        Me.GroupBox2.Controls.Add(Me.txtCep)
        Me.GroupBox2.Controls.Add(Me.txtBairro)
        Me.GroupBox2.Controls.Add(Me.txtComplemento)
        Me.GroupBox2.Controls.Add(Me.txtNumero)
        Me.GroupBox2.Controls.Add(Me.txtEndereco)
        Me.GroupBox2.Controls.Add(Me.txtNomeResponsavel)
        Me.GroupBox2.Controls.Add(Me.txtNomeMae)
        Me.GroupBox2.Controls.Add(Me.txtNomePaciente)
        Me.GroupBox2.Controls.Add(Me.txtCnsPaciente)
        Me.GroupBox2.Controls.Add(Me.txtCpfPaciente)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 151)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(497, 221)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Identificação do Paciente"
        '
        'txtProntuario
        '
        Me.txtProntuario.Location = New System.Drawing.Point(243, 33)
        Me.txtProntuario.Name = "txtProntuario"
        Me.txtProntuario.Size = New System.Drawing.Size(100, 20)
        Me.txtProntuario.TabIndex = 18
        '
        'chkSituacaoRua
        '
        Me.chkSituacaoRua.AutoSize = True
        Me.chkSituacaoRua.Location = New System.Drawing.Point(137, 192)
        Me.chkSituacaoRua.Name = "chkSituacaoRua"
        Me.chkSituacaoRua.Size = New System.Drawing.Size(81, 17)
        Me.chkSituacaoRua.TabIndex = 17
        Me.chkSituacaoRua.Text = "CheckBox1"
        Me.chkSituacaoRua.UseVisualStyleBackColor = True
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(18, 190)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(100, 20)
        Me.txtEmail.TabIndex = 10
        '
        'txtTelefone
        '
        Me.txtTelefone.Location = New System.Drawing.Point(378, 164)
        Me.txtTelefone.Name = "txtTelefone"
        Me.txtTelefone.Size = New System.Drawing.Size(100, 20)
        Me.txtTelefone.TabIndex = 16
        '
        'txtEtnia
        '
        Me.txtEtnia.Location = New System.Drawing.Point(272, 164)
        Me.txtEtnia.Name = "txtEtnia"
        Me.txtEtnia.Size = New System.Drawing.Size(100, 20)
        Me.txtEtnia.TabIndex = 15
        '
        'cboRaca
        '
        Me.cboRaca.FormattingEnabled = True
        Me.cboRaca.Items.AddRange(New Object() {"BRANCA", "PRETA", "PARDA", "AMARELA", "INDIGENA"})
        Me.cboRaca.Location = New System.Drawing.Point(115, 163)
        Me.cboRaca.Name = "cboRaca"
        Me.cboRaca.Size = New System.Drawing.Size(121, 21)
        Me.cboRaca.TabIndex = 14
        '
        'cboSexo
        '
        Me.cboSexo.FormattingEnabled = True
        Me.cboSexo.Items.AddRange(New Object() {"M", "F"})
        Me.cboSexo.Location = New System.Drawing.Point(18, 163)
        Me.cboSexo.Name = "cboSexo"
        Me.cboSexo.Size = New System.Drawing.Size(67, 21)
        Me.cboSexo.TabIndex = 13
        '
        'dtNascimento
        '
        Me.dtNascimento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtNascimento.Location = New System.Drawing.Point(244, 138)
        Me.dtNascimento.Name = "dtNascimento"
        Me.dtNascimento.Size = New System.Drawing.Size(99, 20)
        Me.dtNascimento.TabIndex = 12
        '
        'txtMunicipioNome
        '
        Me.txtMunicipioNome.Location = New System.Drawing.Point(137, 137)
        Me.txtMunicipioNome.Name = "txtMunicipioNome"
        Me.txtMunicipioNome.Size = New System.Drawing.Size(100, 20)
        Me.txtMunicipioNome.TabIndex = 11
        '
        'txtMunicipioCod
        '
        Me.txtMunicipioCod.Location = New System.Drawing.Point(18, 137)
        Me.txtMunicipioCod.Name = "txtMunicipioCod"
        Me.txtMunicipioCod.Size = New System.Drawing.Size(100, 20)
        Me.txtMunicipioCod.TabIndex = 10
        '
        'txtCep
        '
        Me.txtCep.Location = New System.Drawing.Point(369, 111)
        Me.txtCep.Name = "txtCep"
        Me.txtCep.Size = New System.Drawing.Size(100, 20)
        Me.txtCep.TabIndex = 9
        '
        'txtBairro
        '
        Me.txtBairro.Location = New System.Drawing.Point(243, 111)
        Me.txtBairro.Name = "txtBairro"
        Me.txtBairro.Size = New System.Drawing.Size(100, 20)
        Me.txtBairro.TabIndex = 8
        '
        'txtComplemento
        '
        Me.txtComplemento.Location = New System.Drawing.Point(137, 111)
        Me.txtComplemento.Name = "txtComplemento"
        Me.txtComplemento.Size = New System.Drawing.Size(100, 20)
        Me.txtComplemento.TabIndex = 7
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(18, 111)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(100, 20)
        Me.txtNumero.TabIndex = 6
        '
        'txtEndereco
        '
        Me.txtEndereco.Location = New System.Drawing.Point(137, 85)
        Me.txtEndereco.Name = "txtEndereco"
        Me.txtEndereco.Size = New System.Drawing.Size(332, 20)
        Me.txtEndereco.TabIndex = 5
        '
        'txtNomeResponsavel
        '
        Me.txtNomeResponsavel.Location = New System.Drawing.Point(18, 85)
        Me.txtNomeResponsavel.Name = "txtNomeResponsavel"
        Me.txtNomeResponsavel.Size = New System.Drawing.Size(100, 20)
        Me.txtNomeResponsavel.TabIndex = 4
        '
        'txtNomeMae
        '
        Me.txtNomeMae.Location = New System.Drawing.Point(243, 59)
        Me.txtNomeMae.Name = "txtNomeMae"
        Me.txtNomeMae.Size = New System.Drawing.Size(226, 20)
        Me.txtNomeMae.TabIndex = 3
        '
        'txtNomePaciente
        '
        Me.txtNomePaciente.Location = New System.Drawing.Point(18, 59)
        Me.txtNomePaciente.Name = "txtNomePaciente"
        Me.txtNomePaciente.Size = New System.Drawing.Size(219, 20)
        Me.txtNomePaciente.TabIndex = 2
        '
        'txtCnsPaciente
        '
        Me.txtCnsPaciente.Location = New System.Drawing.Point(137, 33)
        Me.txtCnsPaciente.Name = "txtCnsPaciente"
        Me.txtCnsPaciente.Size = New System.Drawing.Size(100, 20)
        Me.txtCnsPaciente.TabIndex = 1
        '
        'txtCpfPaciente
        '
        Me.txtCpfPaciente.Location = New System.Drawing.Point(18, 33)
        Me.txtCpfPaciente.Name = "txtCpfPaciente"
        Me.txtCpfPaciente.Size = New System.Drawing.Size(100, 20)
        Me.txtCpfPaciente.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dtAltaObito)
        Me.GroupBox3.Controls.Add(Me.cboMotivoSaida)
        Me.GroupBox3.Controls.Add(Me.txtCodOrgaoEmissor)
        Me.GroupBox3.Controls.Add(Me.txtNomeAutorizador)
        Me.GroupBox3.Controls.Add(Me.dtSolicitacao)
        Me.GroupBox3.Controls.Add(Me.txtCidSecundario)
        Me.GroupBox3.Controls.Add(Me.txtCidPrincipal)
        Me.GroupBox3.Controls.Add(Me.cboCaraterAtendimento)
        Me.GroupBox3.Controls.Add(Me.dtAutorizacao)
        Me.GroupBox3.Controls.Add(Me.txtCnsAutorizador)
        Me.GroupBox3.Controls.Add(Me.txtNomeMedicoSolicitante)
        Me.GroupBox3.Controls.Add(Me.txtCnsMedicoSolicitante)
        Me.GroupBox3.Controls.Add(Me.txtProcedimentoPrincipal)
        Me.GroupBox3.Location = New System.Drawing.Point(515, 15)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(455, 238)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "OCI"
        '
        'dtAltaObito
        '
        Me.dtAltaObito.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtAltaObito.Location = New System.Drawing.Point(148, 211)
        Me.dtAltaObito.Name = "dtAltaObito"
        Me.dtAltaObito.Size = New System.Drawing.Size(99, 20)
        Me.dtAltaObito.TabIndex = 9
        '
        'cboMotivoSaida
        '
        Me.cboMotivoSaida.FormattingEnabled = True
        Me.cboMotivoSaida.Location = New System.Drawing.Point(21, 211)
        Me.cboMotivoSaida.Name = "cboMotivoSaida"
        Me.cboMotivoSaida.Size = New System.Drawing.Size(121, 21)
        Me.cboMotivoSaida.TabIndex = 8
        '
        'txtCodOrgaoEmissor
        '
        Me.txtCodOrgaoEmissor.Location = New System.Drawing.Point(21, 188)
        Me.txtCodOrgaoEmissor.Name = "txtCodOrgaoEmissor"
        Me.txtCodOrgaoEmissor.Size = New System.Drawing.Size(149, 20)
        Me.txtCodOrgaoEmissor.TabIndex = 14
        '
        'txtNomeAutorizador
        '
        Me.txtNomeAutorizador.Location = New System.Drawing.Point(21, 136)
        Me.txtNomeAutorizador.Name = "txtNomeAutorizador"
        Me.txtNomeAutorizador.Size = New System.Drawing.Size(264, 20)
        Me.txtNomeAutorizador.TabIndex = 13
        '
        'dtSolicitacao
        '
        Me.dtSolicitacao.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtSolicitacao.Location = New System.Drawing.Point(186, 32)
        Me.dtSolicitacao.Name = "dtSolicitacao"
        Me.dtSolicitacao.Size = New System.Drawing.Size(99, 20)
        Me.dtSolicitacao.TabIndex = 12
        '
        'txtCidSecundario
        '
        Me.txtCidSecundario.Location = New System.Drawing.Point(232, 162)
        Me.txtCidSecundario.Name = "txtCidSecundario"
        Me.txtCidSecundario.Size = New System.Drawing.Size(100, 20)
        Me.txtCidSecundario.TabIndex = 11
        '
        'txtCidPrincipal
        '
        Me.txtCidPrincipal.Location = New System.Drawing.Point(126, 162)
        Me.txtCidPrincipal.Name = "txtCidPrincipal"
        Me.txtCidPrincipal.Size = New System.Drawing.Size(100, 20)
        Me.txtCidPrincipal.TabIndex = 10
        '
        'cboCaraterAtendimento
        '
        Me.cboCaraterAtendimento.FormattingEnabled = True
        Me.cboCaraterAtendimento.Location = New System.Drawing.Point(291, 31)
        Me.cboCaraterAtendimento.Name = "cboCaraterAtendimento"
        Me.cboCaraterAtendimento.Size = New System.Drawing.Size(149, 21)
        Me.cboCaraterAtendimento.TabIndex = 7
        '
        'dtAutorizacao
        '
        Me.dtAutorizacao.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtAutorizacao.Location = New System.Drawing.Point(21, 162)
        Me.dtAutorizacao.Name = "dtAutorizacao"
        Me.dtAutorizacao.Size = New System.Drawing.Size(99, 20)
        Me.dtAutorizacao.TabIndex = 6
        '
        'txtCnsAutorizador
        '
        Me.txtCnsAutorizador.Location = New System.Drawing.Point(21, 110)
        Me.txtCnsAutorizador.Name = "txtCnsAutorizador"
        Me.txtCnsAutorizador.Size = New System.Drawing.Size(264, 20)
        Me.txtCnsAutorizador.TabIndex = 3
        '
        'txtNomeMedicoSolicitante
        '
        Me.txtNomeMedicoSolicitante.Location = New System.Drawing.Point(21, 84)
        Me.txtNomeMedicoSolicitante.Name = "txtNomeMedicoSolicitante"
        Me.txtNomeMedicoSolicitante.Size = New System.Drawing.Size(264, 20)
        Me.txtNomeMedicoSolicitante.TabIndex = 2
        '
        'txtCnsMedicoSolicitante
        '
        Me.txtCnsMedicoSolicitante.Location = New System.Drawing.Point(21, 58)
        Me.txtCnsMedicoSolicitante.Name = "txtCnsMedicoSolicitante"
        Me.txtCnsMedicoSolicitante.Size = New System.Drawing.Size(264, 20)
        Me.txtCnsMedicoSolicitante.TabIndex = 1
        '
        'txtProcedimentoPrincipal
        '
        Me.txtProcedimentoPrincipal.Location = New System.Drawing.Point(21, 32)
        Me.txtProcedimentoPrincipal.Name = "txtProcedimentoPrincipal"
        Me.txtProcedimentoPrincipal.Size = New System.Drawing.Size(159, 20)
        Me.txtProcedimentoPrincipal.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnRemoverProcedimento)
        Me.GroupBox4.Controls.Add(Me.btnAdicionarProcedimento)
        Me.GroupBox4.Controls.Add(Me.CnesTerceiro)
        Me.GroupBox4.Controls.Add(Me.CnsExecutante)
        Me.GroupBox4.Controls.Add(Me.CidSecundario)
        Me.GroupBox4.Controls.Add(Me.Descricao)
        Me.GroupBox4.Controls.Add(Me.CidPrincipal)
        Me.GroupBox4.Controls.Add(Me.Quantidade)
        Me.GroupBox4.Controls.Add(Me.CBOmed)
        Me.GroupBox4.Controls.Add(Me.CodProcedimento)
        Me.GroupBox4.Controls.Add(Me.gridProcedimentos)
        Me.GroupBox4.Location = New System.Drawing.Point(515, 259)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(455, 243)
        Me.GroupBox4.TabIndex = 11
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Procedimentos secundários"
        '
        'btnRemoverProcedimento
        '
        Me.btnRemoverProcedimento.Location = New System.Drawing.Point(102, 205)
        Me.btnRemoverProcedimento.Name = "btnRemoverProcedimento"
        Me.btnRemoverProcedimento.Size = New System.Drawing.Size(75, 23)
        Me.btnRemoverProcedimento.TabIndex = 42
        Me.btnRemoverProcedimento.Text = "Remover"
        Me.btnRemoverProcedimento.UseVisualStyleBackColor = True
        '
        'btnAdicionarProcedimento
        '
        Me.btnAdicionarProcedimento.Location = New System.Drawing.Point(21, 205)
        Me.btnAdicionarProcedimento.Name = "btnAdicionarProcedimento"
        Me.btnAdicionarProcedimento.Size = New System.Drawing.Size(75, 23)
        Me.btnAdicionarProcedimento.TabIndex = 41
        Me.btnAdicionarProcedimento.Text = "Adicionar"
        Me.btnAdicionarProcedimento.UseVisualStyleBackColor = True
        '
        'CnesTerceiro
        '
        Me.CnesTerceiro.Location = New System.Drawing.Point(304, 46)
        Me.CnesTerceiro.Name = "CnesTerceiro"
        Me.CnesTerceiro.Size = New System.Drawing.Size(136, 20)
        Me.CnesTerceiro.TabIndex = 40
        '
        'CnsExecutante
        '
        Me.CnsExecutante.Location = New System.Drawing.Point(128, 46)
        Me.CnsExecutante.Name = "CnsExecutante"
        Me.CnsExecutante.Size = New System.Drawing.Size(170, 20)
        Me.CnsExecutante.TabIndex = 39
        '
        'CidSecundario
        '
        Me.CidSecundario.Location = New System.Drawing.Point(22, 73)
        Me.CidSecundario.Name = "CidSecundario"
        Me.CidSecundario.Size = New System.Drawing.Size(100, 20)
        Me.CidSecundario.TabIndex = 38
        '
        'Descricao
        '
        Me.Descricao.Location = New System.Drawing.Point(128, 20)
        Me.Descricao.Name = "Descricao"
        Me.Descricao.Size = New System.Drawing.Size(170, 20)
        Me.Descricao.TabIndex = 34
        '
        'CidPrincipal
        '
        Me.CidPrincipal.Location = New System.Drawing.Point(21, 46)
        Me.CidPrincipal.Name = "CidPrincipal"
        Me.CidPrincipal.Size = New System.Drawing.Size(100, 20)
        Me.CidPrincipal.TabIndex = 37
        '
        'Quantidade
        '
        Me.Quantidade.Location = New System.Drawing.Point(304, 20)
        Me.Quantidade.Name = "Quantidade"
        Me.Quantidade.Size = New System.Drawing.Size(30, 20)
        Me.Quantidade.TabIndex = 36
        '
        'CBOmed
        '
        Me.CBOmed.Location = New System.Drawing.Point(340, 20)
        Me.CBOmed.Name = "CBOmed"
        Me.CBOmed.Size = New System.Drawing.Size(100, 20)
        Me.CBOmed.TabIndex = 35
        '
        'CodProcedimento
        '
        Me.CodProcedimento.Location = New System.Drawing.Point(22, 20)
        Me.CodProcedimento.Name = "CodProcedimento"
        Me.CodProcedimento.Size = New System.Drawing.Size(100, 20)
        Me.CodProcedimento.TabIndex = 33
        '
        'gridProcedimentos
        '
        Me.gridProcedimentos.AllowUserToAddRows = False
        Me.gridProcedimentos.AllowUserToDeleteRows = False
        Me.gridProcedimentos.AllowUserToOrderColumns = True
        Me.gridProcedimentos.AllowUserToResizeRows = False
        Me.gridProcedimentos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridProcedimentos.BackgroundColor = System.Drawing.Color.White
        Me.gridProcedimentos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.gridProcedimentos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridProcedimentos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gridProcedimentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridProcedimentos.DefaultCellStyle = DataGridViewCellStyle2
        Me.gridProcedimentos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.gridProcedimentos.Location = New System.Drawing.Point(21, 99)
        Me.gridProcedimentos.MultiSelect = False
        Me.gridProcedimentos.Name = "gridProcedimentos"
        Me.gridProcedimentos.ReadOnly = True
        Me.gridProcedimentos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridProcedimentos.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.gridProcedimentos.RowHeadersWidth = 4
        Me.gridProcedimentos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.gridProcedimentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridProcedimentos.Size = New System.Drawing.Size(419, 100)
        Me.gridProcedimentos.TabIndex = 32
        Me.gridProcedimentos.TabStop = False
        '
        'btnGerarArquivo
        '
        Me.btnGerarArquivo.Location = New System.Drawing.Point(12, 508)
        Me.btnGerarArquivo.Name = "btnGerarArquivo"
        Me.btnGerarArquivo.Size = New System.Drawing.Size(99, 23)
        Me.btnGerarArquivo.TabIndex = 12
        Me.btnGerarArquivo.Text = "Gerar arquivo"
        Me.btnGerarArquivo.UseVisualStyleBackColor = True
        '
        'txtCnsDiretor
        '
        Me.txtCnsDiretor.Location = New System.Drawing.Point(273, 77)
        Me.txtCnsDiretor.Name = "txtCnsDiretor"
        Me.txtCnsDiretor.Size = New System.Drawing.Size(208, 20)
        Me.txtCnsDiretor.TabIndex = 8
        '
        'FormAMEOCI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(998, 560)
        Me.Controls.Add(Me.btnGerarArquivo)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormAMEOCI"
        Me.Text = "OCI"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.gridProcedimentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtCompetencia As TextBox
    Friend WithEvents txtNumApac As TextBox
    Friend WithEvents txtApacAnterior As TextBox
    Friend WithEvents txtCNESSolicitante As TextBox
    Friend WithEvents txtCnesExecutante As TextBox
    Friend WithEvents dtValidadeIni As DateTimePicker
    Friend WithEvents dtValidadeFim As DateTimePicker
    Friend WithEvents cboTipoApac As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtMunicipioCod As TextBox
    Friend WithEvents txtCep As MaskedTextBox
    Friend WithEvents txtBairro As TextBox
    Friend WithEvents txtComplemento As TextBox
    Friend WithEvents txtNumero As TextBox
    Friend WithEvents txtEndereco As TextBox
    Friend WithEvents txtNomeResponsavel As TextBox
    Friend WithEvents txtNomeMae As TextBox
    Friend WithEvents txtNomePaciente As TextBox
    Friend WithEvents txtCnsPaciente As TextBox
    Friend WithEvents txtCpfPaciente As MaskedTextBox
    Friend WithEvents chkSituacaoRua As CheckBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtTelefone As TextBox
    Friend WithEvents txtEtnia As TextBox
    Friend WithEvents cboRaca As ComboBox
    Friend WithEvents cboSexo As ComboBox
    Friend WithEvents dtNascimento As DateTimePicker
    Friend WithEvents txtMunicipioNome As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents dtAltaObito As DateTimePicker
    Friend WithEvents cboMotivoSaida As ComboBox
    Friend WithEvents cboCaraterAtendimento As ComboBox
    Friend WithEvents dtAutorizacao As DateTimePicker
    Friend WithEvents txtNomeDiretor As TextBox
    Friend WithEvents txtCnsAutorizador As TextBox
    Friend WithEvents txtNomeMedicoSolicitante As TextBox
    Friend WithEvents txtCnsMedicoSolicitante As TextBox
    Friend WithEvents txtProcedimentoPrincipal As TextBox
    Friend WithEvents txtProntuario As TextBox
    Friend WithEvents txtCidSecundario As TextBox
    Friend WithEvents txtCidPrincipal As TextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents gridProcedimentos As DataGridView
    Friend WithEvents CodProcedimento As TextBox
    Friend WithEvents btnRemoverProcedimento As Button
    Friend WithEvents btnAdicionarProcedimento As Button
    Friend WithEvents CnesTerceiro As TextBox
    Friend WithEvents CnsExecutante As TextBox
    Friend WithEvents CidSecundario As TextBox
    Friend WithEvents CidPrincipal As TextBox
    Friend WithEvents Quantidade As TextBox
    Friend WithEvents CBOmed As TextBox
    Friend WithEvents Descricao As TextBox
    Friend WithEvents btnGerarArquivo As Button
    Friend WithEvents dtSolicitacao As DateTimePicker
    Friend WithEvents txtNomeAutorizador As TextBox
    Friend WithEvents txtCodOrgaoEmissor As TextBox
    Friend WithEvents txtCnsDiretor As TextBox
End Class
