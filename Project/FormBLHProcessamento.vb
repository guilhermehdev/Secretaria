Imports UglyToad.PdfPig.DocumentLayoutAnalysis.WordExtractor

Public Class FormBLHProcessamento
    Dim m As New Main
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
    End Sub

    Private Sub tbDataSorologia_TextChanged(sender As Object, e As EventArgs) Handles tbDataSorologia.TextChanged
        If tbDataSorologia.Text.Length = 10 Then
            Try
                Dim dataDigitada As Date = Date.ParseExact(tbDataSorologia.Text, "dd/MM/yyyy", Nothing)
                Dim dataSomada As Date = dataDigitada.AddMonths(6)
                tbDataVencimento.Text = dataSomada.ToString("dd/MM/yyyy")

                If dataSomada < Date.Now Then
                    cbResultado.SelectedIndex = 1
                Else
                    cbResultado.SelectedIndex = 0
                End If

            Catch ex As Exception
                MsgBox("Data inválida.", MsgBoxStyle.Critical)
                tbDataVencimento.Text = ""
            End Try
        End If
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

End Class