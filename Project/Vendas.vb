Public Class Vendas
    Dim vmain As New Main
    Dim vprodutos As New Produtos
    Dim vlog As New Logs
    Public WithEvents _gridview As DataGridView
    Public WithEvents _form As Form
    Dim labelSubtotal As Object

    Dim queryPedidos As String = "SELECT pedidos.id,produtos.id AS idProduto,produtos.descricao,pedidos.qtd,produtos.valor,pedidos.subtotal FROM pedidos JOIN produtos ON pedidos.id_produto = produtos.id WHERE pedidos.id_venda ="

    Dim dgPedidosCollumsHeaderText() As String = {"ID", "IDProduto", "Descrição", "Qtd", "Preço", "Subtotal"}
    Dim dgPedidosCollums() As Boolean = {False, False, True, True, True, True}
    Dim dgPedidosWidth() As Integer = {0, 0, 140, 30, 50, 60}

    Dim queryPgto As String = "SELECT pgto.id,pgto_tipo.descricao,pgto.nparcelas,pgto.valorparcela,pgto.valor FROM pgto JOIN pgto_tipo ON pgto.id_tipo = pgto_tipo.id WHERE pgto.id_venda ="

    Dim dgPgtoCollumsHeaderText() As String = {"ID", "Forma", "X Parc", "Parc", "Valor"}
    Dim dgPgtoCollums() As Boolean = {False, True, True, True, True}
    Dim dgPgtoCollumsWidth() As Integer = {0, 120, 50, 80, 80}

    Dim queryVendas As String = "SELECT DISTINCT venda.id,venda.cod,venda.`data`,cliente.descricao,venda.total,venda.acrescimos,venda.descontos FROM venda LEFT JOIN cliente ON venda.id_cliente = cliente.id JOIN pgto ON pgto.id_venda = venda.id "

    Dim dgVendasCollumsHeaderText() As String = {"ID", "Cod", "Data", "Cliente", "Total", "Acréscimo", "Desconto"}
    Dim dgVendasCollums() As Boolean = {False, True, True, True, True, True, True}
    Dim dgVendasCollumsWidth() As Integer = {0, 60, 70, 200, 70, 80, 80}


    Private _id As Integer

    Public Property id() As Integer
        Get
            Return _id
        End Get
        Private Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _cod As Integer

    Public Property cod() As Integer
        Get
            Return _cod
        End Get
        Private Set(ByVal value As Integer)
            _cod = value
        End Set
    End Property

    Private _status As Integer

    Public Property status() As Integer
        Get
            Return _status
        End Get
        Private Set(ByVal value As Integer)
            _status = value
        End Set
    End Property

    Private _data As String

    Public Property data() As Date
        Get
            Return _data
        End Get
        Private Set(ByVal value As Date)
            _data = value
        End Set
    End Property

    Private _acrescimo As Decimal

    Public Property acrescimo() As Decimal
        Get
            Return _acrescimo
        End Get
        Private Set(ByVal value As Decimal)
            _acrescimo = value
        End Set
    End Property

    Private _desconto As Decimal

    Public Property desconto() As Decimal
        Get
            Return _desconto
        End Get
        Private Set(ByVal value As Decimal)
            _desconto = value
        End Set
    End Property

    Private _total As Decimal

    Public Property total() As Decimal
        Get
            Return _total
        End Get
        Private Set(ByVal value As Decimal)
            _total = value
        End Set
    End Property

    Private _idCliente As Integer

    Public Property idCliente() As Integer
        Get
            Return _idCliente
        End Get
        Private Set(ByVal value As Integer)
            _idCliente = value
        End Set
    End Property

    Private _idPgto As Integer

    Public Property idPgto() As Integer
        Get
            Return _idPgto
        End Get
        Private Set(ByVal value As Integer)
            _idPgto = value
        End Set
    End Property

    Private _idCaixa As Integer

    Public Property idCaixa() As Integer
        Get
            Return _idCaixa
        End Get
        Private Set(ByVal value As Integer)
            _idCaixa = value
        End Set
    End Property

    Private _idUsuario As Integer

    Public Property idUsuario() As Integer
        Get
            Return _idUsuario
        End Get
        Private Set(ByVal value As Integer)
            _idUsuario = value
        End Set
    End Property

    Private _idProduto As Integer

    Public Property idProduto() As Integer
        Get
            Return _idProduto
        End Get
        Private Set(ByVal value As Integer)
            _idProduto = value
        End Set
    End Property

    Private _idVenda As Integer

    Public Property idVenda() As Integer
        Get
            Return _idVenda
        End Get
        Private Set(ByVal value As Integer)
            _idVenda = value
        End Set
    End Property

    Public Function codGenerator(ByVal idCliente As Integer)
        Dim cod As String
        Try
            cod = _idVenda & Date.Today.Day & Date.Today.Month & Date.Today.Year & idCliente

            If cod.Length >= 15 Then
                cod.Remove(14)
                cod = cod + 1
            End If

            Return cod
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub loadPedidos(ByVal grid As DataGridView, ByVal idVenda As Integer, Optional ByVal collumMode As DataGridViewAutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells, Optional ByVal label As Object = Nothing)

        vmain.loadDataGrid(queryPedidos & idVenda, grid, dgPedidosCollums, dgPedidosCollumsHeaderText, dgPedidosWidth, collumMode, False)
        subtotalPedido(labelSubtotal)
        subtotalPedido(label)

    End Sub

    Public Sub loadPgto(ByVal grid As DataGridView, ByVal idVenda As Integer, Optional ByVal collumMode As DataGridViewAutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells)

        vmain.loadDataGrid(queryPgto & idVenda, grid, dgPgtoCollums, dgPgtoCollumsHeaderText, dgPgtoCollumsWidth, collumMode)

    End Sub

    Public Sub showSells(ByVal grid As DataGridView, Optional ByVal criterios As String = "")

        Try
            vmain.loadDataGrid(queryVendas & criterios & " ORDER BY venda.id DESC", grid, dgVendasCollums, dgVendasCollumsHeaderText, dgVendasCollumsWidth, DataGridViewAutoSizeColumnsMode.DisplayedCells)

        Catch ex As Exception
            vmain.showErrors(ex)
        End Try

    End Sub

    Public Function sellsQtd(ByVal criterios As String)
        Dim sel As Decimal
        Try
            sel = vmain.SQLread("venda", "COUNT(id)", "WHERE status =0 " & criterios).Rows(0).Item(0)

            Return sel
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function sellsCash(ByVal criterios As String)
        Dim sel As Decimal
        Try
            sel = vmain.SQLread("venda", "SUM(total)", "WHERE status =0 " & criterios).Rows(0).Item(0)

            Return sel
        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Function checkStatus()
        Try
            Dim StsCaixa As Integer = vmain.SQLread("caixa", "status", "ORDER BY id DESC").Rows(0).Item(0)

            If StsCaixa = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function openSell(ByVal idCliente As Integer)
        Dim Msg As String = "Caixa fechado! Abra-o para prosseguir."

        Try

            If checkStatus() Then

                _status = 1
                _data = vmain.mysqlDateFormat(Date.Now)
                _idCliente = idCliente
                _idCaixa = vmain.SQLread("caixa", "id", "ORDER BY id DESC").Rows(0).Item(0)
                _idUsuario = Flogin.idOperador

                vmain.SQLinsert("venda", "status,data,id_cliente,id_caixa,id_usuario", _status & ",'" & _data & "'," & _idCliente & "," & _idCaixa & "," & _idUsuario, False, False)

                _idVenda = vmain.SQLread("venda", "id", "ORDER BY id DESC").Rows(0).Item(0)


                Return True
            Else
                vmain.msgAlert(Msg)
                Return False
            End If

        Catch ex As Exception
            'vmain.msgAlert(ex.Message)
            Return False
        End Try

    End Function

    Public Sub cancelSell(ByVal idSell As Integer)
        Try
            If checkStatus() Then
                Dim dtQtd As DataTable = vmain.SQLread("pedidos", "id_produto,qtd", "WHERE id_venda =" & idSell)
                Dim dtSell As DataTable = vmain.SQLread("venda", "id,cod,total", "WHERE id =" & idSell)

                For Each row In dtQtd.Rows
                    vprodutos.back2Storage(row.item(0), row.item(1))
                Next

                vmain.SQLGeneric("DELETE FROM venda WHERE id =" & idSell)

                vlog.insertLog("VENDA CANCELADA | COD: " & dtSell.Rows(0).Item(1) & " - VALOR: " & dtSell.Rows(0).Item(2), Flogin.idOperador)

            End If
        Catch ex As Exception
            'vmain.showErrors(ex)
        End Try
    End Sub

    Public Function discounts(ByVal idSell As Integer)
        Dim desc As Decimal
        Try
            desc = vmain.SQLread("pgto", "SUM(valor)", "WHERE id_tipo=6 AND id_venda=" & idSell).Rows(0).Item(0)
            Return desc
        Catch ex As Exception
            Return 0
        End Try

    End Function

    Public Function interest(ByVal idSell As Integer)
        Dim acre As Decimal
        Try
            acre = vmain.SQLread("pgto", "SUM(valor)", "WHERE id_tipo=5 AND id_venda=" & idSell).Rows(0).Item(0)
            Return acre
        Catch ex As Exception
            Return 0
        End Try

    End Function

    Public Sub remFromCart(ByVal grid As DataGridView, Optional ByVal lbSubtotal As Object = Nothing)
        Try

            If checkStatus() Then

                If vmain.SQLdelete("pedidos", "id", grid, 0) Then
                    loadPedidos(grid, _idVenda, DataGridViewAutoSizeColumnsMode.Fill)
                    lbSubtotal.text = vmain.showBRL(subtotal(idVenda))
                End If
            End If

        Catch ex As Exception
            'vmain.showErrors(ex)
        End Try
    End Sub

    Public Sub addPgto(ByVal forma As Integer, ByVal grid As DataGridView, ByVal valor As String, Optional ByVal nparc As Integer = 1, Optional ByVal vlParc As Decimal = 0, Optional ByVal lbSubtotal As Object = Nothing)
        Try
            If checkStatus() Then

                vmain.SQLinsert("pgto", "valor,nparcelas,valorparcela,id_tipo,id_venda", vmain.saveBRL(valor) & "," & nparc & "," & vmain.saveBRL(vlParc) & "," & forma & "," & _idVenda)
                loadPgto(grid, _idVenda, DataGridViewAutoSizeColumnsMode.Fill)

                lbSubtotal.text = vmain.showBRL(subtotal(idVenda))

            End If
        Catch ex As Exception
            'vmain.showErrors(ex)
        End Try
    End Sub

    Public Sub remPgto(ByVal grid As DataGridView, Optional ByVal lbSubtotal As Object = Nothing)
        Try
            If checkStatus() Then

                If vmain.SQLdelete("pgto", "id", grid, 0) Then
                    loadPgto(grid, _idVenda, DataGridViewAutoSizeColumnsMode.Fill)
                    lbSubtotal.text = vmain.showBRL(subtotal(idVenda))
                End If

            End If
        Catch ex As Exception
            'vmain.showErrors(ex)
        End Try
    End Sub

    Public Function subtotalPedido(ByVal idSell As Integer, Optional ByVal lbSubtotal As Object = Nothing)
        Try
            If checkStatus() Then
                Dim valorAtual As Decimal = vmain.SQLread("pedidos", "SUM(subtotal)", "WHERE id_venda =" & idSell).Rows(0).Item(0)

                If Not IsNothing(lbSubtotal) Then
                    lbSubtotal.text = vmain.showBRL(valorAtual)
                    Return valorAtual
                Else
                    Return valorAtual
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
            vmain.showErrors(ex)
        End Try

    End Function

    Public Function subtotalPgto(ByVal idSell As Integer)
        Try

            Dim valorAtual As Decimal = vmain.SQLread("pgto", "SUM(valor)", "WHERE id_venda =" & idSell & " AND id_tipo <> 5 AND id_tipo <> 6").Rows(0).Item(0)

            Return valorAtual

        Catch ex As Exception
            Return 0
            vmain.showErrors(ex)
        End Try

    End Function

    Public Function subtotal(ByVal idSell As Integer)
        Try
            If checkStatus() Then
                If (subtotalPedido(idSell) - subtotalPgto(idSell) - discounts(idSell)) + interest(idSell) < 0 Then
                    Return 0
                Else
                    Return (subtotalPedido(idSell) - subtotalPgto(idSell) - discounts(idSell))
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            vmain.showErrors(ex)
            Return False
        End Try

    End Function

    Public Function totalGeral(ByVal idSell As Integer)
        Dim total As Decimal
        Dim acre As Decimal
        Dim desc As Decimal

        Try
            If checkStatus() Then
                If interest(idSell) Then
                    acre = interest(idSell)
                Else
                    acre = 0
                End If

                If discounts(idSell) Then
                    desc = discounts(idSell)
                Else
                    desc = 0
                End If

                total = (subtotalPedido(idSell) + acre) - desc

                Return total
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function changes(ByVal vlRecebido As String, ByVal vlVenda As String)
        Try
            Dim troco As Decimal = CDec(vlRecebido - vlVenda)

            If troco < 0 Then
                troco = 0
            End If
            Return vmain.showBRL(troco)
        Catch ex As Exception
            'vmain.showErrors(ex)
            Return 0
        End Try

    End Function

    Public Sub fluxoSell(ByVal fase As Integer, ByVal gb1 As GroupBox, ByVal gb2 As GroupBox, ByVal gb3 As GroupBox, ByVal form As Form)


        Select Case fase
            Case 1
                gb1.Visible = True
                gb1.Location = New Point(5, 50)
                gb2.Visible = False
                gb3.Visible = False
            Case 2
                gb1.Visible = False
                gb2.Visible = True
                gb2.Location = New Point(5, 50)
                gb3.Visible = False
            Case 3
                gb1.Visible = False
                gb2.Visible = False
                gb3.Visible = True
                gb3.Location = New Point(5, 50)
        End Select

        form.Size = New System.Drawing.Size(620, 450)

    End Sub

End Class
