Imports System.IO
Imports System.Net
Imports com.itextpdf.text.pdf

Public Class FplanejCNES
    Dim xml As New XML
    Dim pdf As New PDF
    Dim profs As DataTable
    Dim arrayOfMedicos As Array
    Dim columnIndex As Integer
    Dim main As New Main

    Private Sub FplanejCNES_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        xml.cbFormaContEstab(cbFormaContratoEstab)
        cbFormaContratoEstab.SelectedIndex = -1
        cbcbFormaContratoEmpreg.SelectedIndex = -1
        cbDetalhamento.SelectedIndex = -1
        clearLabels()
        copyXMLfromServer()
    End Sub

    Private Sub copyXMLfromServer()
        Try

            If My.Settings.server = "" Then
                FConnSettings.ShowDialog()
                Exit Sub
            End If

            If Not Directory.Exists(Application.StartupPath & "\PDF") Or Not File.Exists(Application.StartupPath & "\PDF\PROFISSIONAIS.pdf") Then
                Directory.CreateDirectory(Application.StartupPath & "\PDF")

                Dim origem As String = $"http://{My.Settings.server}/Secretaria/CNES/PROFISSIONAIS.pdf"
                Dim destino As String = Application.StartupPath & "\PDF\PROFISSIONAIS.pdf"

                ' Verificar se o arquivo existe no servidor HTTP
                Dim request As HttpWebRequest = CType(WebRequest.Create(origem), HttpWebRequest)
                request.Method = "HEAD"

                Using response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                    If response.StatusCode = HttpStatusCode.OK Then
                        Dim clienteWeb As New WebClient()
                        clienteWeb.DownloadFile(origem, destino)
                        MsgBox("Atualizando arquivo de profissionais...")
                    Else
                        MsgBox("Arquivo não encontrado no servidor.")
                    End If
                End Using
            End If

        Catch ex As Exception
            MessageBox.Show("Erro ao copiar arquivo: " & ex.Message)
        End Try
    End Sub

    Function QuebrarTexto(texto As String, larguraMaxima As Integer, fonte As Font) As List(Of String)
        Dim partes As New List(Of String)
        Dim palavras = texto.Split(" "c)
        Dim linhaAtual As String = String.Empty

        For Each palavra In palavras
            If TextRenderer.MeasureText(linhaAtual & " " & palavra, fonte).Width > larguraMaxima Then
                partes.Add(linhaAtual)
                linhaAtual = palavra
            Else
                linhaAtual &= If(String.IsNullOrEmpty(linhaAtual), "", " ") & palavra
            End If
        Next

        If Not String.IsNullOrEmpty(linhaAtual) Then
            partes.Add(linhaAtual & vbCrLf & vbCrLf)
        End If

        Return partes
    End Function

    Private Sub cbFormaContratoEstab_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFormaContratoEstab.SelectionChangeCommitted
        xml.cbFormaContEmpregador(cbcbFormaContratoEmpreg, cbFormaContratoEstab.SelectedValue)
        cbcbFormaContratoEmpreg.SelectedIndex = -1
    End Sub

    Private Sub cbcbFormaContratoEmpreg_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbcbFormaContratoEmpreg.SelectionChangeCommitted
        xml.cbDetalhaento(cbDetalhamento, cbFormaContratoEstab.SelectedValue, cbcbFormaContratoEmpreg.SelectedValue)
        cbDetalhamento.SelectedIndex = -1
        dgPlanejamento.DataSource = Nothing
    End Sub

    Private Sub cbDetalhamento_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDetalhamento.SelectionChangeCommitted
        Dim gestao = 0
        Dim fc As String = cbFormaContratoEstab.SelectedValue & cbcbFormaContratoEmpreg.SelectedValue & cbDetalhamento.SelectedValue
        If rbPublico.Checked Then
            gestao = 0
        ElseIf rbPrivado.Checked Then
            gestao = 1
        End If

        Dim data = pdf.getProf(fc, "", "", gestao)

        dgPlanejamento.DataSource = data
        datagridConfig(False)

        CBOmedicos(data, gestao)
        CBOenfermeiros(data, gestao)
        CBOacs(data, gestao)
        CBOoutrosNivelSuperior(data, gestao)
        CBOoutrosNivelMedio(data, gestao)

    End Sub

    Private Sub datagridConfig(Optional collumCBOvisible = True)
        Try
            dgPlanejamento.Columns(4).Visible = collumCBOvisible
            dgPlanejamento.Columns(0).Width = 80
            dgPlanejamento.Columns(1).Width = 100
            dgPlanejamento.Columns(2).Width = 250
            dgPlanejamento.Columns(3).Width = 300
            ToolStripStatusLabel1.Text = "Registros: " & dgPlanejamento.Rows.Count
        Catch ex As Exception

        End Try
    End Sub

    Private Sub getByCBO(data As DataTable, CBOarray As String(), lbTotal As Label, listBox As ListBox)
        Dim cpfCboDict As New Dictionary(Of String, HashSet(Of Integer))
        Dim cpfList As New HashSet(Of String) ' Lista de CPFs únicos, somente com CBOs válidos
        Dim cboCount As New Dictionary(Of Integer, Integer) ' Contagem global de CBOs válidos

        For Each row As DataRow In data.Rows
            Dim cpf As String = row.Item(0).ToString()
            Dim cbo As Integer = Convert.ToInt32(row.Item(4))

            ' Verificar se o CBO é válido
            If CBOarray.Contains(cbo.ToString()) Then
                ' Adicionar CPF e CBO ao dicionário
                If Not cpfCboDict.ContainsKey(cpf) Then
                    cpfCboDict(cpf) = New HashSet(Of Integer)
                End If

                If Not cpfCboDict(cpf).Contains(cbo) Then
                    cpfCboDict(cpf).Add(cbo)

                    If Not cboCount.ContainsKey(cbo) Then
                        cboCount(cbo) = 0
                    End If
                    cboCount(cbo) += 1
                End If

                ' Adicionar CPF à lista apenas se tiver um CBO válido
                cpfList.Add(cpf)
            Else

            End If
        Next

        Dim total As Integer
        Dim listCBOS As New List(Of String)
        For Each cbo In cboCount.Keys
            Dim partes = QuebrarTexto($"{cbo} - {xml.getCBOXML(cbo)}: {cboCount(cbo)}", listBox.Width - 20, listBox.Font)
            For Each parte In partes
                listBox.Items.Add(parte)
            Next
            total += cboCount(cbo)
        Next

        lbTotal.Text = total.ToString()

    End Sub

    Private Sub CBOmedicos(fcDatatable As DataTable, ByVal gestao As Integer)
        Dim cbosMedicos As String() = {223305, 225103, 225112, 225120, 225121, 225124, 225125, 225127, 225133, 225270, 225250, 225142, 225275, 225155, 225165, 225320, 225185, 225203, 225225, 225235, 225151, 225265, 225135, 225180, 225285, 225310, 225140}
        lbMedicos.Items.Clear()
        getByCBO(fcDatatable, cbosMedicos, lbMedTotal, lbMedicos)
    End Sub

    Private Sub CBOenfermeiros(fcDatatable As DataTable, ByVal gestao As Integer)
        Dim cbosEnf As String() = {223505, 223545, 223565}
        lbEnfermeiro.Items.Clear()
        getByCBO(fcDatatable, cbosEnf, lbEnfTotal, lbEnfermeiro)
    End Sub

    Private Sub CBOacs(fcDatatable As DataTable, ByVal gestao As String)
        Dim cbosACS As String() = {515105}
        lbACS.Items.Clear()
        getByCBO(fcDatatable, cbosACS, lbACStotal, lbACS)
    End Sub

    Private Sub CBOoutrosNivelSuperior(fcDatatable As DataTable, ByVal gestao As String)
        Dim cbosNivelSuperior As String() = {221205, 221105, 223208, 223212, 223240, 223256, 223260, 223268, 223293, 223405, 223415, 223605, 223710, 223810, 223905, 251510, 251605, 111415, 123115, 131205}
        lbSuperior.Items.Clear()
        getByCBO(fcDatatable, cbosNivelSuperior, lbNSTotal, lbSuperior)
    End Sub

    Private Sub CBOoutrosNivelMedio(fcDatatable As DataTable, ByVal gestao As String)
        Dim cbosNivelMedio As String() = {313220, 322245, 322250, 322430, 515215, 422110, 322605, 324115, 325110, 351605, 322205, 322230, 322410, 322415, 324120, 324220, 325115, 351105, 352210, 324205, 410105, 411005, 411010, 412110, 413110, 422105, 422205, 515140}
        lbMedio.Items.Clear()
        getByCBO(fcDatatable, cbosNivelMedio, lbNMTotal, lbMedio)
    End Sub

    Private Sub rbPublico_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPublico.CheckedChanged
        cbFormaContratoEstab.SelectedIndex = -1
        cbcbFormaContratoEmpreg.SelectedIndex = -1
        cbDetalhamento.SelectedIndex = -1
        clearLabels()
    End Sub

    Private Sub rbPrivado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPrivado.CheckedChanged
        cbFormaContratoEstab.SelectedIndex = -1
        cbcbFormaContratoEmpreg.SelectedIndex = -1
        cbDetalhamento.SelectedIndex = -1
        clearLabels()
    End Sub

    Private Sub clearLabels()
        dgPlanejamento.DataSource = Nothing
        lbACS.Items.Clear()
        lbEnfermeiro.Items.Clear()
        lbMedicos.Items.Clear()
        lbMedio.Items.Clear()
        lbSuperior.Items.Clear()

        lbMedTotal.Text = "0"
        lbEnfTotal.Text = "0"
        lbACStotal.Text = "0"
        lbNSTotal.Text = "0"
        lbNMTotal.Text = "0"

    End Sub

    Private Sub TextBoxCPF_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCPF.TextChanged
        If TextBoxCPF.Text.Length >= 11 Then
            dgPlanejamento.DataSource = pdf.getProfByNameORCPF(TextBoxCPF.Text)
            datagridConfig()
        End If
    End Sub

    Private Sub TextBoxNome_TextChanged(sender As Object, e As EventArgs) Handles TextBoxNome.TextChanged
        If TextBoxNome.Text.Length >= 5 Then
            dgPlanejamento.DataSource = pdf.getProfByNameORCPF(Nothing, TextBoxNome.Text)
            datagridConfig()
        End If
    End Sub

    Private Sub dgPlanejamento_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgPlanejamento.CellMouseClick
        If e.Button = MouseButtons.Right Then
            If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
                ' Seleciona a célula clicada
                dgPlanejamento.ClearSelection()
                dgPlanejamento.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True

                columnIndex = e.ColumnIndex
                main.copyFromDatagridview(dgPlanejamento, columnIndex)
                main.msgInfo("Copiado!")
                'MessageBox.Show($"Célula selecionada: Linha {e.RowIndex}, Coluna {e.ColumnIndex}")
            End If
        End If
    End Sub

    Private Sub FecharToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FecharToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub ImportarPDFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportarPDFToolStripMenuItem.Click
        Dim filePath = Application.StartupPath & "\PDF\PROFISSIONAIS.pdf"
        OpenFileDialog1.Filter = "pdf Files (*.pdf)|*.pdf"
        OpenFileDialog1.FileName = "PROFISSIONAIS.pdf"

        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim pdfFile = OpenFileDialog1.FileName
            If File.Exists(filePath) Then
                If MessageBox.Show("Substituir arquivo existente?", "Atenção", MessageBoxButtons.YesNoCancel) = DialogResult.Yes Then
                    File.Copy(pdfFile, filePath, True)
                Else
                    Exit Sub
                End If
            Else
                File.Copy(pdfFile, filePath, False)
            End If
            MessageBox.Show("Importado com sucesso!", "Importar arquivo PDF", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub UploadPDFParaServidorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadPDFParaServidorToolStripMenuItem.Click
        OpenFileDialog1.Filter = "pdf Files (*.pdf)|*.pdf"

        OpenFileDialog1.ShowDialog()

        Dim arquivoLocal As String = OpenFileDialog1.FileName
        Dim caminhoServidor As String = $"\\{My.Settings.server}\htdocs\Secretaria\CNES\PROFISSIONAIS.pdf"

        Try
            File.Copy(arquivoLocal, caminhoServidor, True)
            MessageBox.Show("Arquivo copiado com sucesso!")

        Catch ex As Exception
            ' MessageBox.Show($"Erro ao copiar arquivo: {ex.Message}{vbCrLf}{ex.StackTrace}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class