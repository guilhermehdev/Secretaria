Public Class Clientes
    Dim vmain As New Main
    Dim mainTBs As Object = vmain.tbs
    Public WithEvents _gridview As DataGridView
    Public WithEvents _form As Form

    Dim query As String = "SELECT * FROM cliente "
    Dim reload As String = query & " ORDER BY descricao"

    Dim dgMainCollumsHeaderText() As String = {"ID", "Cod", "Tipo", "Nasc/Abertura", "Nome/Fantasia", "CPF/CNPJ", "Endereço", "Número", "Bairro", "Cidade", "UF", "CEP", "Tel", "Cel", "Email", "Obs"}
    Dim dgMainCollums() As Boolean = {False, True, True, True, True, True, True, True, True, True, True, True, True, True, True, True}

    Private _id As Integer

    Public Property id() As Integer
        Get
            Return _id
        End Get
        Private Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _tipo As String

    Public Property tipo() As String
        Get
            Return _tipo
        End Get
        Private Set(ByVal value As String)
            _tipo = value
        End Set
    End Property

    Private _cod As String

    Public Property cod() As String
        Get
            Return _cod
        End Get
        Private Set(ByVal value As String)
            _cod = value
        End Set
    End Property

    Private _nome As String

    Public Property nome() As String
        Get
            Return _nome
        End Get
        Private Set(ByVal value As String)
            _nome = value
        End Set
    End Property

    Private _nasc As String

    Public Property nasc() As Date
        Get
            Return _nasc
        End Get
        Private Set(ByVal value As Date)
            _nasc = value
        End Set
    End Property

    Private _cpfcnpj As String

    Public Property cpfcnpj() As String
        Get
            Return _cpfcnpj
        End Get
        Private Set(ByVal value As String)
            _cpfcnpj = value
        End Set
    End Property

    Private _endereco As String

    Public Property endereco() As String
        Get
            Return _endereco
        End Get
        Private Set(ByVal value As String)
            _endereco = value
        End Set
    End Property

    Private _num As String

    Public Property num() As String
        Get
            Return _num
        End Get
        Private Set(ByVal value As String)
            _num = value
        End Set
    End Property

    Private _bairro As String

    Public Property bairro() As String
        Get
            Return _bairro
        End Get
        Private Set(ByVal value As String)
            _bairro = value
        End Set
    End Property

    Private _cidade As String

    Public Property cidade() As String
        Get
            Return _cidade
        End Get
        Private Set(ByVal value As String)
            _cidade = value
        End Set
    End Property

    Private _uf As String

    Public Property uf() As String
        Get
            Return _uf
        End Get
        Private Set(ByVal value As String)
            _uf = value
        End Set
    End Property

    Private _tel As String

    Public Property tel() As String
        Get
            Return _tel
        End Get
        Private Set(ByVal value As String)
            _tel = value
        End Set
    End Property

    Private _cel As String

    Public Property cel() As String
        Get
            Return _cel
        End Get
        Private Set(ByVal value As String)
            _cel = value
        End Set
    End Property

    Private _email As String

    Public Property email() As String
        Get
            Return _email
        End Get
        Private Set(ByVal value As String)
            _email = value
        End Set
    End Property

    Private _obs As String

    Public Property obs() As String
        Get
            Return _obs
        End Get
        Private Set(ByVal value As String)
            _obs = value
        End Set
    End Property

    Public Function validate(ByVal cod As TextBox, ByVal tipo As ComboBox, ByVal desc As TextBox, ByVal nasc As MaskedTextBox, ByVal cpfcnpj As MaskedTextBox, ByVal tel As MaskedTextBox)

        If cod.Text = String.Empty Or Not IsNumeric(cod.Text) Then
            MsgBox("Preencha o campo Cod! Somente números.", MsgBoxStyle.Exclamation)
            cod.Focus()
            Return 0
        ElseIf tipo.Text = String.Empty Then
            MsgBox("Selecione o Tipo!", MsgBoxStyle.Exclamation)
            tipo.Focus()
            Return 0
        ElseIf nasc.Text = "  /  /" Then
            MsgBox("Preencha o campo Nasc!", MsgBoxStyle.Exclamation)
            nasc.Focus()
            Return 0
        ElseIf desc.Text = String.Empty Then
            MsgBox("Preencha o campo Nome!", MsgBoxStyle.Exclamation)
            desc.Focus()
            Return 0
        ElseIf cpfcnpj.Text = "" Then
            MsgBox("Preencha o campo CPF/CNPJ!", MsgBoxStyle.Exclamation)
            cpfcnpj.Focus()
            Return 0
        ElseIf tel.Text = "       -" Then
            MsgBox("Preencha o campo Telefone!", MsgBoxStyle.Exclamation)
            tel.Focus()
            Return 0
        Else
            Return 1
        End If

    End Function

    Public Sub loadClientes(ByVal container As Integer, Optional ByVal grid As DataGridView = Nothing, Optional ByVal combo As ComboBox = Nothing, Optional ByVal criterios As String = "", Optional ByVal orderby As String = "descricao", Optional ByVal collumMode As DataGridViewAutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells)

        If container = 0 Then
            vmain.loadDataGrid(query & criterios & " ORDER BY " & orderby, grid, dgMainCollums, dgMainCollumsHeaderText, Nothing, collumMode, False)
        ElseIf container = 1 Then
            vmain.loadComboBox(query & criterios & " ORDER BY " & orderby, combo, "id", "descricao")
        End If

        vmain.datagrid = grid
        _gridview = grid

    End Sub

    Public Sub saveCliente(ByVal cod As Integer, ByVal tipo As String, ByVal desc As String, ByVal nasc As String, ByVal cpfcnpj As String, ByVal endereco As String, ByVal num As String, ByVal bairro As String, ByVal cidade As String, ByVal uf As String, ByVal tel As String, ByVal cel As String, ByVal email As String, ByVal obs As String, ByVal cep As String, ByVal grid As DataGridView)

        _cod = cod
        _tipo = tipo
        _nome = desc
        _nasc = vmain.mysqlDateFormat(nasc)
        _cpfcnpj = cpfcnpj
        _endereco = endereco
        _num = num
        _bairro = bairro
        _cidade = cidade
        _uf = uf
        _tel = tel
        _cel = cel
        _email = email
        _obs = obs

        vmain.SQLinsert("cliente", "cod,tipo,descricao,dtnasc,cpf_cnpj,endereco,numero,bairro,cidade,uf,tel,cel,email,obs,cep", _cod & ",'" & _tipo & "','" & _nome & "','" & _nasc & "','" & _cpfcnpj & "','" & _endereco & "','" & _num & "','" & _bairro & "','" & _cidade & "','" & _uf & "','" & _tel & "','" & _cel & "','" & _email & "','" & _obs & "','" & cep & "'", True, True, reload, grid)

    End Sub

    Public Sub updateCliente(ByVal id As Integer, ByVal cod As Integer, ByVal tipo As String, ByVal desc As String, ByVal nasc As String, ByVal cpfcnpj As String, ByVal endereco As String, ByVal num As String, ByVal bairro As String, ByVal cidade As String, ByVal uf As String, ByVal tel As String, ByVal cel As String, ByVal email As String, ByVal obs As String, ByVal cep As String, ByVal grid As DataGridView)

        _id = id
        _cod = cod
        _tipo = tipo
        _nome = desc
        _nasc = vmain.mysqlDateFormat(nasc)
        _cpfcnpj = cpfcnpj
        _endereco = endereco
        _num = num
        _bairro = bairro
        _cidade = cidade
        _uf = uf
        _tel = tel
        _cel = cel
        _email = email
        _obs = obs

        vmain.SQLupdate("cliente", "cod=" & _cod & ",tipo='" & _tipo & "',descricao='" & _nome & "',dtnasc='" & _nasc & "',cpf_cnpj='" & _cpfcnpj & "',endereco='" & _endereco & "',numero='" & _num & "',bairro='" & _bairro & "',cidade='" & _cidade & "',uf='" & _uf & "',tel='" & _tel & "',cel='" & _cel & "',email='" & _email & "',obs='" & _obs & "',cep='" & cep & "'", "id", grid, 0, "", True, True, reload)

    End Sub

    Public Sub deleteCliente(ByVal id As Integer, ByVal grid As DataGridView)
        _id = id

        vmain.SQLdelete("cliente", "id", grid, 0, True, True, reload)

    End Sub

End Class
