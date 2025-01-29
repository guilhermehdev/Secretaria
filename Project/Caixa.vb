Public Class Caixa
    Dim vmain As New Main
    Dim mainTBs As Object = vmain.tbs
    Dim vvenda As New Vendas

    Dim sqlCaixa As String = "SELECT caixa.id,caixa.status,caixa.dataAbertura,caixa.dataFechamento,caixa.valorCredito,caixa.valorDebito,caixa.valorDinheiro,caixa.valorCheque,caixa.valorBoleto,caixa.retiradas,caixa.valorInicial,caixa.valorFinal,usuarios.nome FROM caixa JOIN usuarios ON caixa.id_usuario = usuarios.id "

    Dim dgCaixaCollumsHeaderText() As String = {"ID", "Status", "Data Abertura", "Data Fechamento", "Crédito", "Débito", "Dinheiro", "Cheque", "Boleto", "Retiradas", "Valor Inicial", "Valor Final", "Usuário"}
    Dim dgCaixaCollums() As Boolean = {False, False, True, True, True, True, True, True, True, True, True, True, True}
    Dim dgCaixaCollumsWidth() As Integer = {0, 50, 70, 70, 70, 70, 70, 70, 70, 70, 70, 70, 100}

    Private _id As Integer

    Public Property id() As Integer
        Get
            Return _id
        End Get
        Private Set(ByVal value As Integer)
            _id = value
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

    Private _dataAbertura As Date

    Public Property dataAbertura() As Date
        Get
            Return _dataAbertura
        End Get
        Private Set(ByVal value As Date)
            _dataAbertura = value
        End Set
    End Property

    Private _dataFechamento As Date

    Public Property dataFechamento() As Date
        Get
            Return _dataFechamento
        End Get
        Private Set(ByVal value As Date)
            _dataFechamento = value
        End Set
    End Property

    Private _valorInicial As Decimal

    Public Property valorInicial() As Decimal
        Get
            Return _valorInicial
        End Get
        Private Set(ByVal value As Decimal)
            _valorInicial = value
        End Set
    End Property

    Private _valorFinal As Decimal

    Public Property valorFinal() As Decimal
        Get
            Return _valorFinal
        End Get
        Private Set(ByVal value As Decimal)
            _valorFinal = value
        End Set
    End Property

    Private _fundoInicial As Decimal

    Public Property fundoInicial() As Decimal
        Get
            Return _fundoInicial
        End Get
        Private Set(ByVal value As Decimal)
            _fundoInicial = value
        End Set
    End Property

    Private _valorCredito As Decimal

    Public Property valorCredito() As Decimal
        Get
            Return _valorCredito
        End Get
        Private Set(ByVal value As Decimal)
            _valorCredito = value
        End Set
    End Property

    Private _valorDebito As Decimal

    Public Property valorDebito() As Decimal
        Get
            Return _valorDebito
        End Get
        Private Set(ByVal value As Decimal)
            _valorDebito = value
        End Set
    End Property

    Private _valorDinheiro As Decimal

    Public Property valorDinheiro() As Decimal
        Get
            Return _valorDinheiro
        End Get
        Private Set(ByVal value As Decimal)
            _valorDinheiro = value
        End Set
    End Property

    Private _receitas As Decimal

    Public Property receitas() As Decimal
        Get
            Return _receitas
        End Get
        Private Set(ByVal value As Decimal)
            _receitas = value
        End Set
    End Property

    Private _despesas As Decimal

    Public Property despesas() As Decimal
        Get
            Return _despesas
        End Get
        Private Set(ByVal value As Decimal)
            _despesas = value
        End Set
    End Property

    Private _retiradas As Decimal

    Public Property retiradas() As Decimal
        Get
            Return _retiradas
        End Get
        Private Set(ByVal value As Decimal)
            _retiradas = value
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

    Private _id_usuario As Integer

    Public Property id_usuario() As Integer
        Get
            Return _id_usuario
        End Get
        Private Set(ByVal value As Integer)
            _id_usuario = value
        End Set
    End Property

    Public Sub loadCash(ByVal grid As DataGridView, ByVal criterios As String)

        Try
            vmain.loadDataGrid(sqlCaixa & criterios, grid, dgCaixaCollums, dgCaixaCollumsHeaderText, dgCaixaCollumsWidth, DataGridViewAutoSizeColumnsMode.DisplayedCells)

        Catch ex As Exception
            vmain.showErrors(ex)
        End Try

    End Sub

    Public Function checkCash()
        Try
            Dim StsCaixa As Integer = vmain.SQLread("caixa", "status", "ORDER BY id DESC").Rows(0).Item(0)

            If StsCaixa = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            'vmain.showErrors(ex)
            Return False
        End Try

    End Function

    Public Function idCash()
        Dim caixas As DataTable

        Try
            caixas = vmain.SQLread("caixa", "id", "WHERE status = 1 ORDER BY id DESC")

            If caixas.Rows.Count > 0 Then
                Return caixas.Rows(0).Item(0)
            Else
                Return False
            End If

        Catch ex As Exception
            'vmain.showErrors(ex)
            Return False
        End Try

    End Function

    Public Function cashTotal(ByVal criterios As String)

        Try
            Dim total As Decimal = vmain.SQLread("caixa", "SUM(valorFinal)", criterios).Rows(0).Item(0)

            Return total

        Catch ex As Exception
            'vmain.showErrors(ex)
            Return vmain.showBRL("0,00")
        End Try

    End Function

    Public Sub open(ByVal data As String, Optional ByVal vlInicial As String = "0")
        Try

            If checkCash() = False Then

                _status = 1
                _dataAbertura = data
                _valorInicial = vlInicial
                _id_usuario = Flogin.idOperador

                vmain.SQLinsert("caixa", "status,dataAbertura,valorInicial,id_usuario", _status & ",'" & vmain.mysqlDateFormat(_dataAbertura) & "'," & vmain.saveBRL(_valorInicial) & "," & _id_usuario)

            End If

        Catch ex As Exception
            vmain.showErrors(ex)
        End Try
    End Sub

    Public Sub close(ByVal data As String, Optional ByVal vlInicial As Decimal = 0)
        Try
            If checkCash() Then

                _status = 0
                _dataFechamento = data
                _valorCredito = credito()
                _valorDebito = debito()
                _valorDinheiro = dinheiro()
                _valorFinal = sales()
                _id_usuario = Flogin.idOperador

                vmain.SQLupdate("caixa", "status=" & _status & ",dataFechamento='" & vmain.mysqlDateFormat(_dataFechamento) & "',valorFinal=" & vmain.saveBRL((_valorFinal + vlInicial) - retirada()) & ",valorCredito=" & vmain.saveBRL(_valorCredito) & ",valorDebito=" & vmain.saveBRL(_valorDebito) & ",valorDinheiro=" & vmain.saveBRL(_valorDinheiro) & ",valorCheque=" & vmain.saveBRL(cheque) & ",valorBoleto=" & vmain.saveBRL(boleto) & ",retiradas=" & vmain.saveBRL(retirada) & ",id_usuario=" & _id_usuario, "id", Nothing, idCash)

            End If

        Catch ex As Exception
            vmain.showErrors(ex)
        End Try
    End Sub

    Public Function dinheiro()
        Try
            Dim din As Decimal = (vmain.SQLread("pgto", "SUM(venda.total)", "JOIN venda ON pgto.id_venda = venda.id WHERE venda.id_caixa =" & idCash() & " AND pgto.id_tipo =1 OR pgto.id_tipo =5").Rows(0).Item(0))

            Return din
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function credito()
        Try
            Dim cred As Decimal = vmain.SQLread("pgto", "SUM(venda.total)", "JOIN venda ON pgto.id_venda = venda.id WHERE venda.id_caixa =" & idCash() & " AND pgto.id_tipo =2").Rows(0).Item(0)
            Return cred
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function debito()
        Try
            Dim deb As Decimal = vmain.SQLread("pgto", "SUM(venda.total)", "JOIN venda ON pgto.id_venda = venda.id WHERE venda.id_caixa =" & idCash() & " AND pgto.id_tipo =3").Rows(0).Item(0)
            Return deb
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function boleto()
        Try
            Dim bol As Decimal = vmain.SQLread("pgto", "SUM(venda.total)", "JOIN venda ON pgto.id_venda = venda.id WHERE venda.id_caixa =" & idCash() & " AND pgto.id_tipo =4").Rows(0).Item(0)
            Return bol
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function cheque()
        Try
            Dim chq As Decimal = vmain.SQLread("pgto", "SUM(venda.total)", "JOIN venda ON pgto.id_venda = venda.id WHERE venda.id_caixa =" & idCash() & " AND pgto.id_tipo =7").Rows(0).Item(0)
            Return chq
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function retirada()
        Try
            Dim ret As Decimal = vmain.SQLread("caixa_retiradas", "SUM(valor)", "WHERE id_caixa =" & idCash()).Rows(0).Item(0)
            Return ret
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function sales()
        Try
            Dim sell As Decimal = vmain.SQLread("venda", "SUM(total)", "WHERE id_caixa =" & idCash()).Rows(0).Item(0)
            Return sell
        Catch ex As Exception
            Return False
        End Try

    End Function

End Class
