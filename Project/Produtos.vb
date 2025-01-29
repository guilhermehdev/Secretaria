Public Class Produtos

    Dim vmain As New Main
    Dim mainTBs As Object = vmain.tbs
    Public WithEvents _gridview As DataGridView

    Dim query As String = "SELECT produtos.id,produtos.cod,produtos_tipo.descricao AS tipo,produtos.descricao,produtos.valor,produtos.estoque,produtos.compra,produtos.loja,produtos.tamanho,produtos.custo FROM produtos JOIN produtos_tipo ON produtos.id_tipo = produtos_tipo.id "
    Dim reload As String = query & " ORDER BY descricao"

    Dim dgMainCollumsHeaderText() As String = {"ID", "Cod", "Tipo", "Descrição", "Valor", "Estoque", "Compra", "Loja", "Tam", "Custo"}
    Dim dgMainCollums() As Boolean = {False, True, True, True, True, True, True, True, True, True}
    Dim dgMainWidth() As Integer = {0, 80, 100, 233, 70, 70, 70, 100, 40, 70}

    Private _id As Integer

    Public Property id() As Integer
        Get
            Return _id
        End Get
        Private Set(ByVal value As Integer)
            _id = value
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

    Private _tipo As Integer

    Public Property tipo() As Integer
        Get
            Return _tipo
        End Get
        Private Set(ByVal value As Integer)
            _tipo = value
        End Set
    End Property

    Private _desc As String

    Public Property desc() As String
        Get
            Return _desc
        End Get
        Private Set(ByVal value As String)
            _desc = value
        End Set
    End Property

    Private _valor As Decimal

    Public Property valor() As String
        Get
            Return _valor
        End Get
        Private Set(ByVal value As String)
            _valor = value
        End Set
    End Property

    Private _estoque As Integer

    Public Property estoque() As Integer
        Get
            Return _estoque
        End Get
        Private Set(ByVal value As Integer)
            _estoque = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Function validate(ByVal cod As TextBox, ByVal tipo As ComboBox, ByVal desc As TextBox, ByVal valor As MaskedTextBox, ByVal estoque As NumericUpDown)

        If cod.Text = String.Empty Then
            MsgBox("Preencha o campo Cod! Somente números.", MsgBoxStyle.Exclamation)
            cod.Focus()
            Return 0
        ElseIf tipo.Text = String.Empty Then
            MsgBox("Selecione o Tipo!", MsgBoxStyle.Exclamation)
            tipo.Focus()
            Return 0
        ElseIf desc.Text = "  /  /" Then
            MsgBox("Preencha o campo Descrição!", MsgBoxStyle.Exclamation)
            desc.Focus()
            Return 0
        ElseIf valor.Text = String.Empty Then
            MsgBox("Preencha o campo Valor!", MsgBoxStyle.Exclamation)
            valor.Focus()
            Return 0
        ElseIf estoque.Text = "" Then
            MsgBox("Preencha o campo Estoque!", MsgBoxStyle.Exclamation)
            estoque.Focus()
            Return 0
        Else
            Return 1
        End If

    End Function

    Public Function loadProdutos(ByVal container As Integer, Optional ByVal grid As DataGridView = Nothing, Optional ByVal combo As ComboBox = Nothing, Optional ByVal criterios As String = "", Optional ByVal orderby As String = "descricao", Optional ByVal collumMode As DataGridViewAutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells)

        Try

            If container = 0 Then
                vmain.loadDataGrid(query & " " & criterios & " ORDER BY " & orderby, grid, dgMainCollums, dgMainCollumsHeaderText, dgMainWidth, collumMode, False)
            ElseIf container = 1 Then
                vmain.loadComboBox(query & " " & criterios & " ORDER BY " & orderby, combo, "id", "descricao")
            End If

            vmain.datagrid = grid

            Return True

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Sub loadTipos(ByVal combo As ComboBox)
        vmain.loadComboBox("SELECT id,descricao FROM produtos_tipo ORDER BY descricao", combo, "descricao", "id")
    End Sub


    Public Sub saveProduto(ByVal cod As String, ByVal tipo As Integer, ByVal desc As String, ByVal valor As String, ByVal estoque As Integer, ByVal grid As DataGridView, ByVal compra As String, ByVal loja As String, ByVal tamanho As String, ByVal custo As String)

        _cod = cod
        _tipo = tipo
        _desc = desc
        _valor = valor
        _estoque = estoque
        vmain.datagrid = grid

        vmain.SQLinsert("produtos", "cod,id_tipo,descricao,valor,estoque,compra,loja,tamanho,custo", "'" & _cod & "'," & _tipo & ",'" & _desc & "','" & vmain.saveBRL(_valor) & "'," & _estoque & ",'" & compra & "','" & loja & "','" & tamanho & "','" & vmain.saveBRL(custo) & "'", True, True, reload, grid, True)

    End Sub

    Public Sub updateProduto(ByVal id As Integer, ByVal cod As String, ByVal tipo As Integer, ByVal desc As String, ByVal valor As String, ByVal estoque As Integer, ByVal grid As DataGridView, ByVal compra As String, ByVal loja As String, ByVal tamanho As String, ByVal custo As String)

        _cod = cod
        _tipo = tipo
        _desc = desc
        _valor = valor
        _estoque = estoque
        vmain.datagrid = grid

        vmain.SQLupdate("produtos", "cod='" & _cod & "',id_tipo=" & _tipo & ",descricao='" & _desc & "',valor='" & vmain.saveBRL(_valor) & "',estoque=" & _estoque & ",compra='" & compra & "',loja='" & loja & "',tamanho='" & tamanho & "',custo='" & vmain.saveBRL(custo) & "'", "id", grid, 0, "", True, True, reload)

    End Sub

    Public Sub deleteProduto(ByVal id As Integer, ByVal grid As DataGridView)
        _id = id

        vmain.SQLdelete("produtos", "id", grid, 0, True, True, reload)
        vmain.datagrid = grid

    End Sub

    Public Function checkStorage(ByVal idProduto As Integer)
        Try
            Dim qtd As Integer = vmain.SQLread("produtos", "estoque", "WHERE id=" & idProduto).Rows(0).Item(0)
            Return qtd
        Catch ex As Exception
            Return False
        End Try

    End Function


    Public Sub back2Storage(ByVal idProduto As Integer, ByVal qtd As Integer, Optional ByVal grid As DataGridView = Nothing)
        Dim qtdAtual As Integer = vmain.SQLread("produtos", "estoque", "WHERE id =" & idProduto).Rows(0).Item(0)

        _estoque = qtdAtual + qtd

        vmain.SQLupdate("produtos", "estoque=" & _estoque, "id", grid, idProduto)
    End Sub

    Public Sub leaveStorage(ByVal idProduto As Integer, ByVal qtd As Integer, Optional ByVal grid As DataGridView = Nothing)
        Dim qtdAtual As Integer = vmain.SQLread("produtos", "estoque", "WHERE id =" & idProduto).Rows(0).Item(0)

        _estoque = qtdAtual - qtd

        vmain.SQLupdate("produtos", "estoque=" & _estoque, "id", grid, idProduto)
    End Sub

    Public Function loadProdutoUsuario(ByVal id_Produto As Integer)
        Dim dtResult As DataTable

        Try
            dtResult = vmain.SQLread("produto_usuario", "id,id_produto,id_usuario,data", "WHERE id_produto =" & id_Produto)

            If dtResult.Rows.Count > 0 Then
                Return dtResult
            Else
                Return dtResult
            End If


        Catch ex As Exception
            Return Nothing
        End Try

    End Function

End Class
