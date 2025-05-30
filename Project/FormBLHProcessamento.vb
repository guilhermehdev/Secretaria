﻿Imports UglyToad.PdfPig.DocumentLayoutAnalysis.WordExtractor

Public Class FormBLHProcessamento
    Dim m As New Main
    Dim blh As New BLH
    Dim queryLeite As String = "SELECT blh_leite.id, blh_cadastro.nome AS doadora, blh_cadastro.dtnasc AS nasc, blh_partos.`data` AS parto, blh_leite.data_ordenha AS ordenha,blh_leite.volume AS volume, blh_leite.tipo_leite AS tl, blh_leite.origem AS origem, blh_leite.data_sorologia AS sorologia, blh_leite.vencimento_sorologia AS vencimento, blh_leite.resultado_sorologia AS resultado, blh_leite.apta_inapta AS apta, blh_leite.conforme AS conforme, blh_leite.vencimento_sup AS motivo_vencimento, blh_leite.problema_refrigera AS motivo_refrigeracao, blh_leite.embalagem AS motivo_embalagem, blh_leite.exames_vencidos AS motivo_exames
        FROM blh_cadastro 
        JOIN blh_leite ON blh_leite.id_doadora = blh_cadastro.id
        JOIN blh_partos ON blh_leite.id_parto = blh_partos.id"

    Private Sub loadProcessamento()
        'm.loadDataGrid("SELECT blh_cadastro.nome, blh_cadastro.parto, blh_processamento.dataPasteurizacao, blh_processamento.origem, blh_processamento.frasco, blh_processamento.tl,
        'blh_processamento.ordenha, blh_processamento.parto, blh_processamento.creme1, blh_processamento.creme2, blh_processamento.creme3, blh_processamento.total1,
        'blh_processamento.total2, blh_processamento.total3, blh_processamento.percentCreme, blh_processamento.percentGordura, blh_processamento.calorias,
        'blh_processamento.acidez, blh_processamento.bgbl, blh_processamento.ml, blh_processamento.dataDistrib, blh_processamento.destino
        'FROM blh_cadastro 
        'JOIN blh_processamento ON blh_processamento.id_cadastro = blh_cadastro.id", dgBLHprocessamento, {True, True, True, True, True, True, True, True, True, True, True, True, True, True, True, True, True, True, True, True, True, True}, {"Doadora", "Parto", "Pasteurização", "Origem", "Frasco", "TL", "Ordenha", "Parto", "Creme1", "Creme2", "Creme3", "Total1", "Total2", "Total3", "% Creme", "% Gordura", "Kal", "Acidez", "BGBL", "ML", "Dsitribuição", "Destino"}, {250, 80, 80, 60, 30, 30, 80, 80, 40, 40, 40, 40, 40, 40, 40, 40, 50, 40, 80, 40, 80, 60},, True)
    End Sub

    Private Function tipoLeite()
        Dim dataOrdenha As Date = Date.ParseExact(tbDataOrdenha.Text, "dd/MM/yyyy", Nothing)
        Dim diferenca As TimeSpan = Date.Now - dataOrdenha

        If diferenca.Days <= 7 Then
            Return 0
        ElseIf diferenca.Days >= 8 And diferenca.Days <= 15 Then
            Return 1
        ElseIf diferenca.Days > 15 Then
            Return 2
        End If

        Return False

    End Function

    Private Sub loadDoadoras()
        m.loadComboBox("SELECT id, nome FROM blh_cadastro ORDER BY nome", cbDoadoras, "nome", "id")
        cbDoadoras.SelectedIndex = -1
    End Sub
    Private Function SimNao(valor As Object) As String
        If IsDBNull(valor) Then Return "NÃO"

        Dim str = valor.ToString().Trim().ToUpper()

        If str = "SIM" OrElse str = "NÃO" Then
            Return str ' já foi convertido, retorna direto
        End If

        Dim num As Integer
        If Integer.TryParse(str, num) Then
            Return If(num = 0, "NÃO", "SIM")
        End If

        Return "NÃO" ' fallback padrão se não for número nem SIM/NÃO
    End Function

    Private Sub loadLeite(Optional where As String = "")
        m.loadDataGrid(queryLeite & $" {where} ORDER BY id DESC", dgLeite, {False, True, True, True, True, True, True, True, True, True, True, True, True, True, True, True, True}, {"ID", "Doadora", "Nasc", "Parto", "Ordenha", "Volume", "TL", "Origem", "Sorologia", "Vencimento", "Resultado", "Apta", "Conforme", "Vencimento > 15 dias", "Problema de refrigeracao", "Problema de Embalagem", "Exames vencidos"}, {0, 250, 70, 70, 70, 60, 30, 60, 70, 70, 60, 60, 60, 60, 60, 60, 60}, DataGridViewAutoSizeColumnsMode.None, True)
    End Sub
    Private Sub loadPasteurizacao(Optional criteria As String = "")
        dgSelecaoLeite.Columns.Clear()

        m.loadDataGrid($"SELECT blh_leite.id, blh_leite.data_ordenha AS data, blh_leite.tipo_leite AS tipo, blh_leite.origem, blh_cadastro.nome AS doadora, blh_leite.volume AS ml  
            FROM blh_leite JOIN blh_cadastro ON blh_cadastro.id = blh_leite.id_doadora
            WHERE blh_leite.conforme = 1 {criteria} ORDER BY DATA DESC, tipo, origem, doadora, ml", dgSelecaoLeite, {False, True, True, True, True, True}, {"", "Data", "TL", "Origem", "Doadora", "ML"}, {0, 70, 20, 70, 220, 50})

        Dim chkCol As New DataGridViewCheckBoxColumn()
        chkCol.HeaderText = "#"
        chkCol.Name = "chck"
        chkCol.Width = 30
        dgSelecaoLeite.Columns.Insert(0, chkCol)

        If dgSelecaoLeite.RowCount > 0 Then
            dgSelecaoLeite.Columns(2).ReadOnly = True
            dgSelecaoLeite.Columns(3).ReadOnly = True
            dgSelecaoLeite.Columns(4).ReadOnly = True
            dgSelecaoLeite.Columns(5).ReadOnly = True
            dgSelecaoLeite.Columns(6).ReadOnly = True
            btSalvarSelecionados.Enabled = True
        Else
            btSalvarSelecionados.Enabled = False
        End If
    End Sub

    Private Sub getCheckboxValue()
        For Each row As DataGridViewRow In dgSelecaoLeite.Rows
            If Convert.ToBoolean(row.Cells("chck").Value) = True Then
                Dim id As String = row.Cells("Id").Value.ToString()
                ' Use o ID como quiser
                MsgBox("Selecionado: " & id)
            End If
        Next
    End Sub

    Private Sub FormBLHProcessamento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' loadProcessamento()
        Dim comboSource As New Dictionary(Of String, String)()

        comboSource.Add("C", "COLOSTRO")
        comboSource.Add("T", "TRANSIÇÃO")
        comboSource.Add("M", "MADURO")

        cbTipoLeite.DataSource = New BindingSource(comboSource, Nothing)
        cbTipoLeite.DisplayMember = "Value"
        cbTipoLeite.ValueMember = "Key"
        cbTipoLeite.SelectedIndex = -1

        loadDoadoras()
        loadLeite()
        dgLeite.ClearSelection()
    End Sub

    Private Sub tbDataOrdenha_TextChanged(sender As Object, e As EventArgs) Handles tbDataOrdenha.TextChanged
        If tbDataOrdenha.Text.Length = 10 Then
            cbTipoLeite.SelectedIndex = tipoLeite()
        End If

    End Sub

    Private Sub rbConforme_CheckedChanged(sender As Object, e As EventArgs) Handles rbConforme.CheckedChanged
        If rbConforme.Checked Then
            gbMotivos.Enabled = False
            cbEmbalagem.Checked = False
            cbExamesVencidos.Checked = False
            cbRefrigeracao.Checked = False
            cbVencidos15dias.Checked = False
        ElseIf rbNaoConforme.Checked Then
            gbMotivos.Enabled = True
            cbEmbalagem.Checked = False
            cbExamesVencidos.Checked = False
            cbRefrigeracao.Checked = False
            cbVencidos15dias.Checked = False
        End If

    End Sub

    Private Sub btSalvarDoadora_Click(sender As Object, e As EventArgs) Handles btSalvarDoadora.Click

        Dim conforme As String = If(rbConforme.Checked, 1, 0)

        If tbDataOrdenha.Text = "" Or tbVolume.Value = 0 Or cbTipoLeite.SelectedIndex = -1 Or cbOrigem.SelectedItem Is Nothing Or cbDoadoras.SelectedValue Is Nothing Or cbParto.SelectedValue Is Nothing Then
            MsgBox("Preencha todos os campos obrigatórios.", MsgBoxStyle.Critical)
            Return
        End If

        If m.SQLinsert("blh_leite", "data_ordenha, volume, tipo_leite, origem, conforme, vencimento_sup, problema_refrigera, embalagem, exames_vencidos, id_doadora, id_parto", "'" & m.mysqlDateFormat(tbDataOrdenha.Text) & "', " & tbVolume.Value & ", '" & cbTipoLeite.SelectedValue.ToString & "', '" & cbOrigem.SelectedItem & "'," & conforme & ", " & cbVencidos15dias.CheckState & ", " & cbRefrigeracao.CheckState & ", " & cbEmbalagem.CheckState & ", " & cbExamesVencidos.CheckState & ", " & cbDoadoras.SelectedValue & ", " & cbParto.SelectedValue, True) Then
            loadLeite()
        End If
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub cbDoadoras_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbDoadoras.SelectionChangeCommitted
        If cbDoadoras.SelectedValue IsNot Nothing Then
            BLH.loadPartos(cbParto, cbDoadoras.SelectedValue)
        End If
    End Sub

    Private Sub dgLeite_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)
        Debug.Write(e.Exception.ToString())
    End Sub

    Private Sub dgLeite_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgLeite.CellFormatting
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub

        If e.ColumnIndex = 10 Then
            If e.Value IsNot Nothing AndAlso e.Value.ToString().Trim().ToUpper() = "VENCIDO" Then
                e.CellStyle.ForeColor = Color.Red
            Else
                e.CellStyle.ForeColor = Color.Black
            End If
        End If

        ' Colunas 12 a 15 são as que devem mostrar "SIM"/"NÃO"
        If e.ColumnIndex >= 13 AndAlso e.ColumnIndex <= 16 Then
            Dim valor As Object = e.Value

            If Not IsDBNull(valor) Then
                Dim numero As Integer
                If Integer.TryParse(valor.ToString(), numero) Then
                    e.Value = If(numero = 0, "NÃO", "SIM")
                    e.CellStyle.ForeColor = If(numero = 0, Color.Green, Color.DarkOrange)
                    e.CellStyle.Font = New Font(dgLeite.Font, FontStyle.Bold)
                    e.FormattingApplied = True
                End If
            Else
                e.Value = "NÃO"
                e.FormattingApplied = True
                e.CellStyle.ForeColor = Color.Red
            End If
        End If

        If e.ColumnIndex >= 11 AndAlso e.ColumnIndex <= 12 Then
            Dim valor As Object = e.Value

            If Not IsDBNull(valor) Then
                Dim numero As Integer
                If Integer.TryParse(valor.ToString(), numero) Then
                    e.Value = If(numero = 0, "NÃO", "SIM")
                    e.CellStyle.ForeColor = If(numero = 0, Color.Red, Color.SteelBlue)
                    e.CellStyle.Font = New Font(dgLeite.Font, FontStyle.Bold)
                    e.FormattingApplied = True
                End If
            Else
                e.Value = "NÃO"
                e.FormattingApplied = True
                e.CellStyle.ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub btExcluirDoadora_Click(sender As Object, e As EventArgs) Handles btExcluirLeite.Click
        If m.SQLdelete("blh_leite", "id", dgLeite, 0, True, True, queryLeite, True) Then
            btExcluirLeite.Enabled = False
        End If
    End Sub
    Private Sub tbBuscaDoadora_TextChanged(sender As Object, e As EventArgs) Handles tbBuscaDoadora.TextChanged
        If tbBuscaDoadora.Text.Length > 3 Then
            loadLeite($"WHERE blh_cadastro.nome LIKE '%{tbBuscaDoadora.Text}%'")
        Else
            loadLeite()
        End If
    End Sub
    Private Sub tbBuscaDN_TextChanged(sender As Object, e As EventArgs) Handles tbBuscaDN.TextChanged
        If tbBuscaDN.Text <> "  /  /" Then
            loadLeite($"WHERE blh_cadastro.dtnasc ='{m.mysqlDateFormat(tbBuscaDN.Text)}'")
        Else
            loadLeite()
        End If
    End Sub
    Private Sub btCancelar_Click(sender As Object, e As EventArgs) Handles btCancelar.Click
        tbBuscaDoadora.Text = ""
        tbBuscaDN.Text = ""
        cbDoadoras.SelectedIndex = -1
        cbParto.SelectedIndex = -1
        tbDataOrdenha.Text = ""
        tbVolume.Value = 0
        cbTipoLeite.SelectedIndex = -1
        cbOrigem.SelectedIndex = -1
        rbConforme.Checked = True
        gbMotivos.Enabled = False
        cbDoadoras.Focus()
    End Sub

    Private Sub dgLeite_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgLeite.CellEnter
        If dgLeite.RowCount > 0 Then
            btExcluirLeite.Enabled = True
        Else
            btExcluirLeite.Enabled = False
        End If

    End Sub
    Private Sub tbDataFin_ValueChanged(sender As Object, e As EventArgs) Handles tbDataFin.ValueChanged
        If IsDate(tbDataFin.Value.Date) And IsDate(tbDataIni.Value) Then
            loadPasteurizacao($"AND blh_leite.data_ordenha BETWEEN '{m.mysqlDateFormat(tbDataIni.Text)}' AND '{m.mysqlDateFormat(tbDataFin.Text)}'")
        Else
            MsgBox("Necessário data inicial e data final.", MsgBoxStyle.Critical)
            tbDataIni.Focus()
        End If
    End Sub

    Private Sub dgSelecaoLeite_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgSelecaoLeite.CellFormatting
        If e.ColumnIndex = 6 Then
            If Not IsDBNull(e.Value) AndAlso IsNumeric(e.Value) Then
                e.Value = Format(CDec(e.Value), "N2")
                e.FormattingApplied = True
            End If
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btSalvarSelecionados.Click
        getCheckboxValue()
    End Sub

    Private Sub dgSelecaoLeite_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgSelecaoLeite.CellValueChanged
        If e.ColumnIndex = 0 Then ' Supondo que o checkbox esteja na coluna 0
            Dim row = dgSelecaoLeite.Rows(e.RowIndex)
            Dim marcado As Boolean = Convert.ToBoolean(row.Cells(0).Value)

            If marcado Then
                AdicionarPainel(row)
            Else
                RemoverPainelPorId(row.Cells("Id").Value.ToString())
            End If
        End If
    End Sub

    Private Sub AdicionarPainel(row As DataGridViewRow)
        Dim id As String = row.Cells(1).Value.ToString()
        Dim nome As String = row.Cells(5).Value.ToString()
        Dim ml As String = row.Cells(6).Value.ToString()

        ' Evita duplicar
        If FlowSelecionados.Controls.ContainsKey("pnl_" & id) Then Exit Sub

        Dim pnl As New Panel With {
        .Name = "pnl_" & id,
        .Size = New Size(250, 30),
        .BackColor = Color.LightGray,
        .Margin = New Padding(2)
    }

        Dim lbl As New Label With {
        .Text = $"{nome} (ML: {ml})",
        .AutoSize = False,
        .TextAlign = ContentAlignment.MiddleLeft,
        .Size = New Size(170, 30),
        .Location = New Point(0, 0)
    }

        Dim btn As New Button With {
        .Text = "X",
        .Size = New Size(30, 30),
        .Location = New Point(180, 0),
        .Tag = id
    }

        AddHandler btn.Click, AddressOf RemoverPainel_Click

        pnl.Controls.Add(lbl)
        pnl.Controls.Add(btn)
        FlowSelecionados.Controls.Add(pnl)
    End Sub

    Private Sub RemoverPainel_Click(sender As Object, e As EventArgs)
        Dim btn = DirectCast(sender, Button)
        Dim id As String = btn.Tag.ToString()
        RemoverPainelPorId(id)

        ' Desmarca checkbox na grid
        For Each row As DataGridViewRow In dgSelecaoLeite.Rows
            If row.Cells("Id").Value.ToString() = id Then
                row.Cells(0).Value = False
                Exit For
            End If
        Next
    End Sub


    Private Sub RemoverPainelPorId(id As String)
        Dim nomePainel = "pnl_" & id
        If FlowSelecionados.Controls.ContainsKey(nomePainel) Then
            FlowSelecionados.Controls.RemoveByKey(nomePainel)
        End If
    End Sub


    Private Sub dgSelecaoLeite_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgSelecaoLeite.CurrentCellDirtyStateChanged
        If dgSelecaoLeite.IsCurrentCellDirty Then
            dgSelecaoLeite.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

End Class