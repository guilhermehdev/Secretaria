﻿Imports MySql.Data.MySqlClient
Imports System.Text
Imports System.IO
Imports System.Text.RegularExpressions

Public Class Main

    Public vconexao As MySqlConnection
    Public Sql As String
    Public findId As Integer

    Public WithEvents datagrid As DataGridView
    Public WithEvents bnew As Button
    Public WithEvents bsave As Button
    Public WithEvents bupdate As Button
    Public WithEvents bdelete As Button
    Public WithEvents bcancel As Button
    Public WithEvents bexit As Button

    Public tbs(30) As Object
    Public dgCVisible(30) As Boolean
    Public dgCHeader(30) As String
    Public dgCWidth(30) As Integer
   

    Public Sub connection(ByVal conectar As Boolean)

        If conectar Then
            Try
                vconexao = New MySqlConnection
                vconexao.ConnectionString = "server=" & My.Settings.server & "; user=" & My.Settings.user & "; password=" & My.Settings.password & "; database=" & My.Settings.database
                vconexao.Open()
            Catch ex As Exception
                MsgBox("Não foi possível realizar a conexão com o servidor!" & vbCrLf & vbCrLf & "Erro: " & ex.Message, MsgBoxStyle.Information)
                FConnSettings.ShowDialog()
            End Try

        Else
            vconexao.Close()
        End If
    End Sub

    Public Sub databaseBackup(ByVal caminhofixo As String)
        Dim comando As String

        If My.Settings.mysqldump = String.Empty Then
            If Fbackup.OpenFileDialog1.ShowDialog = DialogResult.OK Then
                My.Settings.mysqldump = Fbackup.OpenFileDialog1.FileName
            End If
        Else
            comando = Chr(34) & My.Settings.mysqldump & Chr(34) & " -h " & My.Settings.server & " -u " & My.Settings.user & " -p" & My.Settings.password & " " & My.Settings.database & "  > " & caminhofixo & "\" & My.Settings.database & "-" + Format(Date.Now.Day.ToString) + "-" + Format(Date.Now.Month.ToString) + "-" + Format(Date.Now.Year.ToString) + "-Hora-" + Format(Date.Now.Hour.ToString) + "_" + Format(Date.Now.Minute.ToString) & ".sql"
            Try
                Shell("cmd.exe /c" & comando)

                If My.Settings.bkpstatus = "Desativado" Then
                    MsgBox("Backup realizado com sucesso!", MsgBoxStyle.Information)
                End If

            Catch ex As Exception
                showErrors(ex)
            End Try
        End If
    End Sub

    Public Sub restoreBackup(ByVal ofd As OpenFileDialog)
        Dim comando As String

        comando = Chr(34) & My.Settings.mysql & Chr(34) & " -h " & My.Settings.server & " -u " & My.Settings.user & " -p" & My.Settings.password & " " & My.Settings.database & "  <" & ofd.FileName

        Try
            Shell("cmd.exe /c" & comando)

        Catch ex As Exception
            showErrors(ex)
        End Try

    End Sub

    Public Function doQuery(ByVal sql As String, Optional ByVal errorMsg As Boolean = False) 'insert/update/delete
        Try
            connection(True)
            Dim command As New MySqlCommand
            command.Connection = vconexao
            command.CommandText = sql
            command.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            If errorMsg Then
                showErrors(ex)
            End If
            Throw
        Finally
            connection(False)
        End Try
    End Function

    Public Function getDataset(ByVal sql As String, Optional ByVal errorMsg As Boolean = False) As DataTable
        Dim dspesquisa As New DataTable
        Try
            connection(True)
            Dim objcomando As New MySqlCommand(sql, vconexao)
            Dim dsadapter As New MySqlDataAdapter
            dsadapter.SelectCommand = objcomando
            dsadapter.Fill(dspesquisa)
        Catch ex As Exception
            If errorMsg Then
                showErrors(ex)
            End If
        Finally
            connection(False)
        End Try

        Return dspesquisa

    End Function

    Public Sub Fade(ByVal obj As Object, ByVal TotalSeconds As Single)
        If TotalSeconds = 0 Then
            obj.Opacity = 1
            Exit Sub
        End If
        Dim [then] As Double = DateAndTime.Timer
        Dim difference As Double = 0
        'difference is the percentage of the total seconds elapsed
        Do While difference < 1
            obj.Opacity = difference

            difference = (DateAndTime.Timer - [then]) / TotalSeconds
            System.Threading.Thread.Sleep(10)
        Loop
        obj.Opacity = 1
    End Sub

    Public Function searchDataTable(ByVal datatable As DataTable, ByVal searchedRefField As String, ByVal locationOfValueToBeSearched As String, ByVal fieldToBeReturned As String)

        Try

            Dim rows() As DataRow = datatable.Select(searchedRefField & "='" & locationOfValueToBeSearched & "'")
            If rows.Count > 0 Then
                Return (rows(0).Item(fieldToBeReturned))
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    'CRUD___________________________________________________________________________________

    Public Function SQLGeneric(ByVal query As String, Optional ByVal debugMsg As Boolean = False)
        Try
            Sql = query
            doQuery(Sql, debugMsg)

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function SQLinsert(ByVal table As String, ByVal fields As String, ByVal values As String, Optional ByVal message As Boolean = False, Optional ByVal reloadGrid As Boolean = False, Optional ByVal sqlReload As String = "", Optional ByVal grid As DataGridView = Nothing, Optional ByVal debugMsg As Boolean = False)


        Try
            Sql = "INSERT INTO " & table & "(" & fields & ") VALUES(" & values & ")"
            doQuery(Sql, debugMsg)

            If message Then
                msgInsert("Cadastrado com sucesso!")
            End If

            If reloadGrid Then
                Sql = "SELECT LAST_INSERT_ID() FROM " & table & " LIMIT 1"
                Dim dtLastId As DataTable = getDataset(Sql)

                findId = dtLastId.Rows(0).Item(0)

                loadDataGrid(sqlReload, datagrid, dgCVisible, dgCHeader)
            End If

            Return True
        Catch ex As Exception
            Return ex.Message.ToString
        End Try

    End Function

    Public Function SQLread(ByVal table As String, ByVal fields As String, Optional ByVal criterios As String = Nothing) As DataTable
        Dim data As DataTable
        Try
            Sql = "SELECT " & fields & " FROM " & table & " " & criterios
            data = getDataset(Sql)

            Return data

        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function SQLupdate(ByVal table As String, ByVal updateFields As String, ByVal PKName As String, Optional ByVal dataGrid As DataGridView = Nothing, Optional ByVal PKLocation As Integer = Nothing, Optional ByVal criterios As String = Nothing, Optional ByVal message As Boolean = False, Optional ByVal reloadGrid As Boolean = False, Optional ByVal sqlReload As String = "", Optional ByVal debugMsg As Boolean = False, Optional ByVal PKCell As Integer = 0)

        ' MessageBox.Show(updateFields)

        Try
            If Not IsNothing(dataGrid) Then
                PKLocation = dataGrid.SelectedRows.Item(0).Cells(PKCell).Value
            End If

            Sql = "UPDATE " & table & " SET " & updateFields & " WHERE " & PKName & " =" & PKLocation & criterios

            doQuery(Sql, debugMsg)

            If message Then
                msgUpdate("Atualizado com sucesso!")
            End If

            If reloadGrid Then
                loadDataGrid(sqlReload, dataGrid, dgCVisible, dgCHeader)
            End If

            Return True

        Catch ex As Exception
            If debugMsg Then
                showErrors(ex)

            End If
            Return False
        End Try

    End Function

    Public Function SQLdelete(ByVal table As String, ByVal primaryKey As String, ByVal dataGrid As DataGridView, ByVal dataGridPKCollum As Integer, Optional ByVal message As Boolean = False, Optional ByVal reloadGrid As Boolean = False, Optional ByVal sqlReload As String = "", Optional ByVal debugMsg As Boolean = False)

        If MessageBox.Show("Deseja realmente excluir esse Item?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3) = DialogResult.Yes Then
            Try

                Sql = "DELETE FROM " & table & " WHERE " & primaryKey & " =" & dataGrid.SelectedRows.Item(0).Cells(dataGridPKCollum).Value
                doQuery(Sql, debugMsg)

                If message Then
                    msgDelete("Excluido com sucesso!")
                End If

                If reloadGrid Then
                    loadDataGrid(sqlReload, dataGrid, dgCVisible, dgCHeader)
                End If

                Return True

            Catch ex As Exception
                msgError("Não pôde ser excluído, pode haver dependências!")
                Return False
            End Try

        Else
            Return False
        End If

    End Function

    'END CRUD_________________________________________________________________________________

    Public Function msgInfo(ByVal msgText As String) As String
        Return MsgBox(msgText, MsgBoxStyle.Information, "Aviso")
    End Function
    Public Function msgError(ByVal msgText As String) As String
        Return MsgBox(msgText, MsgBoxStyle.Critical, "Erro")
    End Function
    Public Function msgAlert(ByVal msgText As String) As String
        Return MsgBox(msgText, MsgBoxStyle.Exclamation, "Alerta")
    End Function
    Public Function msgDelete(ByVal msgText As String) As String
        Return MsgBox(msgText, MsgBoxStyle.Information, "Excluir")
    End Function
    Public Function msgUpdate(ByVal msgText As String) As String
        Return MsgBox(msgText, MsgBoxStyle.Information, "Atualizar")
    End Function
    Public Function msgInsert(ByVal msgText As String) As String
        Return MsgBox(msgText, MsgBoxStyle.Information, "Salvar")
    End Function
    Public Function msgQuestion(ByVal msgText As String, ByVal Title As String) As String
        If MessageBox.Show(msgText, Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3) = DialogResult.Yes Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub gridCellEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles datagrid.CellEnter, datagrid.CellClick
        Try
            findId = datagrid.SelectedRows.Item(0).Cells(0).Value
        Catch ex As Exception

        End Try
    End Sub

    Public Function loadDataGrid(ByVal sql As String, ByVal grid As DataGridView, ByVal collumsVisible() As Boolean, ByVal collumsHeaderText() As String, Optional ByVal collumsWidth() As Integer = Nothing, Optional ByVal collumMode As DataGridViewAutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None, Optional ByVal errorMsg As Boolean = False) As DataTable
        Dim dados As New DataTable
        datagrid = grid
        dgCVisible = collumsVisible
        dgCHeader = collumsHeaderText
        dgCWidth = collumsWidth


        Try
            dados = getDataset(sql, errorMsg)

            If dados.Rows.Count > 0 Then
                datagrid.DataSource = dados
                datagrid.AutoSizeColumnsMode = collumMode

                For i = 0 To datagrid.Columns.Count - 1
                    datagrid.Columns(i).Visible = dgCVisible(i)
                    datagrid.Columns(i).HeaderText = dgCHeader(i)
                    If Not IsNothing(dgCWidth) Then
                        datagrid.Columns(i).Width = dgCWidth(i)
                    End If
                Next

                For Each row As DataGridViewRow In datagrid.Rows
                    If row.Cells(0).Value = findId Then
                        datagrid.Rows(row.Index).Selected = True
                        If datagrid.Rows(row.Index).Selected = True Then
                            datagrid.FirstDisplayedScrollingRowIndex = row.Index
                        End If
                    End If
                Next

                Return dados
            Else
                datagrid.DataSource = Nothing
                Return Nothing
            End If

        Catch ex As Exception
            'showErrors(ex)
            Return Nothing
        End Try

    End Function

    Public Sub dataGridToTextBox() Handles datagrid.CellEnter, datagrid.CellClick
        Try
            Dim cells(datagrid.SelectedRows.Item(0).Cells.Count - 1) As String

            For i = 1 To datagrid.SelectedRows.Item(0).Cells.Count - 1
                cells(i) = datagrid.SelectedRows.Item(0).Cells(i).Value
                If TypeOf (tbs(i)) Is TextBox Or TypeOf (tbs(i)) Is MaskedTextBox Or TypeOf (tbs(i)) Is ComboBox Then
                    tbs(i).text = cells(i)
                ElseIf TypeOf (tbs(i)) Is NumericUpDown Then
                    tbs(i).value = cells(i)
                ElseIf TypeOf (tbs(i)) Is CheckBox Then
                    If cells(i) = "0" Then
                        tbs(i).Checked = False
                    Else
                        tbs(i).Checked = True
                    End If

                End If

            Next

        Catch ex As Exception
            'showErrors(ex)
        End Try

    End Sub

    Private Sub gridMouseRightClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles datagrid.MouseDown
        Dim hti As DataGridView.HitTestInfo = datagrid.HitTest(e.X, e.Y)
        Try
            datagrid.Rows(hti.RowIndex).Selected = True
        Catch ex As Exception

        End Try
    End Sub

    Public Function loadComboBox(ByVal sql As String, ByVal cbox As ComboBox, ByVal field2Show As String, ByVal fieldValue As String, Optional ByVal errorMsg As Boolean = False)
        Dim vobjconexao As New Main
        Dim dados As New DataTable

        Try
            dados = vobjconexao.getDataset(sql, errorMsg)
            If dados.Rows.Count > 0 Then
                cbox.DataSource = dados
                cbox.DisplayMember = field2Show
                cbox.ValueMember = fieldValue
            End If

            Return dados
        Catch ex As Exception

        End Try

        Return False

    End Function

    Public Sub activeFields(ByVal container As Control, ByVal state As Boolean)
        On Error Resume Next

        For Each item In container.Controls
            If item.Tag <> 1 Then
                item.Enabled = state
            End If
        Next

    End Sub

    Public Function requiredFields(ByVal ParamArray colection() As Object)

        For Each obj In colection
            If TypeOf obj Is System.Windows.Forms.TextBox Then
                If obj.Text = Nothing Then
                    msgAlert("Campo " & obj.tag & " não pode ser vazio!")
                    obj.focus()
                    Return False
                    Exit For
                End If

            ElseIf TypeOf obj Is System.Windows.Forms.ComboBox Then
                If obj.Text = Nothing Then
                    msgAlert("Campo " & obj.tag & " não pode ser vazio!")
                    obj.focus()
                    Return False
                    Exit For
                End If

            ElseIf TypeOf obj Is System.Windows.Forms.MaskedTextBox Then

                If obj.Text = "  /  /" Then
                    msgAlert("Campo " & obj.tag & " não pode ser vazio!")
                    obj.focus()
                    Return False
                    Exit For
                End If

            End If

        Next

        Return True

    End Function

    Public Sub clearFields(ByVal container As Control)

        On Error Resume Next

        Dim item As Object

        For Each item In container.Controls
            'If TypeOf item Is System.Windows.Forms.GroupBox Then
            'clearFields(item)
            'End If

            If TypeOf item Is System.Windows.Forms.TextBox Then
                item.clear()
            ElseIf TypeOf item Is System.Windows.Forms.ComboBox Then
                item.text = ""
                item.SelectedIndex = 0
            ElseIf TypeOf item Is System.Windows.Forms.MaskedTextBox Then
                item.clear()
            ElseIf TypeOf item Is System.Windows.Forms.CheckBox Then
                item.checked = False
            End If

        Next

    End Sub

    Public Sub activeButtons(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnew.Click, bsave.Click, bupdate.Click, bdelete.Click, bcancel.Click
        Dim button As Button
        button = CType(sender, Button)

        Try
            Select Case button.Name

                Case "btnew"
                    bsave.Enabled = True
                    bupdate.Enabled = False
                    bdelete.Enabled = False
                    bcancel.Enabled = True
                    bnew.Enabled = False

                Case "btsave"
                    bupdate.Enabled = False
                    bsave.Enabled = False
                    bdelete.Enabled = False
                    bcancel.Enabled = True
                    bnew.Enabled = True

                Case "btupdate"
                    bsave.Enabled = False
                    bdelete.Enabled = False
                    bcancel.Enabled = True
                    bnew.Enabled = True

                Case "btdelete"
                    bsave.Enabled = False
                    bupdate.Enabled = False
                    bcancel.Enabled = True
                    bnew.Enabled = True
                    bdelete.Enabled = False

                Case "btcancel"
                    bsave.Enabled = False
                    bupdate.Enabled = False
                    bdelete.Enabled = False
                    bnew.Enabled = True
                    bcancel.Enabled = True
            End Select

        Catch ex As Exception
            'showErrors(ex)
        End Try

    End Sub

    Public Function showBRL(ByVal value As String)
        Try
            Return "R$ " & Format(CDec(value), "#,##0.00")
        Catch ex As Exception
            Return "R$ 0,00"
        End Try
    End Function

    Public Function saveBRL(ByVal value As String)
        Try
            Return Replace(Format(Convert.ToDouble(value), "###0.00"), ",", ".")
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function mysqlDateFormat(ByVal data As String)
        Try
            Return Format(CDate(data), "yyyy-MM-dd")
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Sub gridRowStyle(ByVal datagrid As DataGridView, ByVal background As Color, ByVal font As Color)

        Try

            For row = 0 To datagrid.RowCount - 1

                datagrid.Rows.Item(row).DefaultCellStyle.BackColor = background
                datagrid.Rows.Item(row).DefaultCellStyle.ForeColor = font

            Next

        Catch ex As Exception
            'showErrors(ex)
        End Try


    End Sub

    Public Sub gridCellStyle(ByVal cellCollum As Integer, ByVal cellBack As Color, ByVal cellFont As Color)

        Try

            For row = 0 To datagrid.RowCount - 1

                datagrid.Rows.Item(row).Cells(cellCollum).Style.BackColor = cellBack
                datagrid.Rows.Item(row).Cells(cellCollum).Style.ForeColor = cellFont

            Next

        Catch ex As Exception
            'showErrors(ex)
        End Try


    End Sub
    Public Function showErrors(ByVal x As Exception)
        Dim index As Integer

        index = x.StackTrace.IndexOf("linha")

        Return MessageBox.Show("Erro: " + x.Message + _
        vbCrLf + _
        "Metodo onde ocorreu o erro: " + x.TargetSite.Name + _
        vbCrLf + _
        "Linha onde ocorreu o erro: " + x.StackTrace.Substring(index))

    End Function

    Public Function SafeSqlLiteral(ByVal strValue, ByVal intLevel) As String
        ' intLevel represent how thorough the value will be checked for dangerous code
        ' intLevel (1) - Do just the basic. This level will already counter most of the SQL injection attacks
        ' intLevel (2) - &nbsp; (non breaking space) will be added to most words used in SQL queries to prevent unauthorized access to the database. Safe to be printed back into HTML code. Don't use for usernames or passwords

        If Not IsDBNull(strValue) Then
            If intLevel > 0 Then
                strValue = Replace(strValue, "'", "''") ' Most important one! This line alone can prevent most injection attacks
                strValue = Replace(strValue, "--", "")
                strValue = Replace(strValue, "[", "[[]")
                strValue = Replace(strValue, "%", "[%]")
            End If

            If intLevel > 1 Then
                Dim myArray As Array
                myArray = Split("xp_ ;update ;insert ;select ;drop ;alter ;create ;rename ;delete ;replace ", ";")
                Dim i, i2, intLenghtLeft As Integer
                For i = LBound(myArray) To UBound(myArray)
                    Dim rx As New Regex(myArray(i), RegexOptions.Compiled Or RegexOptions.IgnoreCase)
                    Dim matches As MatchCollection = rx.Matches(strValue)
                    i2 = 0
                    For Each match As Match In matches
                        Dim groups As GroupCollection = match.Groups
                        intLenghtLeft = groups.Item(0).Index + Len(myArray(i)) + i2
                        strValue = Left(strValue, intLenghtLeft - 1) & "&nbsp;" & Right(strValue, Len(strValue) - intLenghtLeft)
                        i2 += 5
                    Next
                Next
            End If

        End If

        Return strValue

    End Function

    Private Function LoadIconFromFile(ByVal fileName As String) As Icon
        Return New Icon(fileName, New Size(32, 32))
    End Function

    Public Function carregaImagem(ByVal fileName As String) As Byte()
        'Método para carregar uma imagem do disco e retorná-la como um byteStream
        Dim fs As FileStream = New FileStream(fileName, FileMode.Open, FileAccess.Read)
        Dim br As BinaryReader = New BinaryReader(fs)
        Return (br.ReadBytes(Convert.ToInt32(br.BaseStream.Length)))

    End Function


    Public Sub insere_imagem_mysql(ByVal ofd As OpenFileDialog, ByVal sql As String)
        Dim conn As New MySqlConnection
        Dim cmd As New MySqlCommand

        Dim FileSize As UInt32
        Dim rawData() As Byte
        Dim fs As FileStream

        conn.ConnectionString = "server=localhost;" _
            & "uid=" & My.Settings.user & ";" _
            & "pwd=" & My.Settings.password & ";" _
            & "database=" & My.Settings.database

        Try

            fs = New FileStream(ofd.FileName, FileMode.Open, FileAccess.Read)
            FileSize = fs.Length

            rawData = New Byte(FileSize) {}
            fs.Read(rawData, 0, FileSize)
            fs.Close()

            conn.Open()

            cmd.Connection = conn
            cmd.CommandText = sql
            cmd.Parameters.AddWithValue("@FileSize", FileSize)
            cmd.Parameters.AddWithValue("@File", rawData)

            cmd.ExecuteNonQuery()

            ' MessageBox.Show("File Inserted into database successfully!", _
            '"Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

            conn.Close()

        Catch ex As Exception
            showErrors(ex)
        End Try

    End Sub

    Public Sub ler_imagem_mysql()
        Dim conn As New MySqlConnection
        Dim cmd As New MySqlCommand
        Dim myData As MySqlDataReader
        Dim SQL As String
        Dim rawData() As Byte
        Dim FileSize As UInt32
        Dim fs As FileStream

        conn.ConnectionString = "server=localhost;" _
            & "uid=" & My.Settings.user & ";" _
            & "pwd=" & My.Settings.password & ";" _
            & "database=" & My.Settings.database

        SQL = "SELECT logo,logotam FROM usuariodados"

        Try
            conn.Open()

            cmd.Connection = conn
            cmd.CommandText = SQL

            myData = cmd.ExecuteReader

            If Not myData.HasRows Then Throw New Exception("There are no BLOBs to save")

            myData.Read()

            FileSize = myData.GetUInt32(myData.GetOrdinal("logotam"))
            rawData = New Byte(FileSize) {}

            myData.GetBytes(myData.GetOrdinal("logo"), 0, rawData, 0, FileSize)

            fs = New FileStream("C:\newfile.png", FileMode.OpenOrCreate, FileAccess.Write)
            fs.Write(rawData, 0, FileSize)
            fs.Close()

            myData.Close()
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("There was an error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function getDataFromDatagridRow(ByVal datagrid As DataGridView)
        Dim row = datagrid.SelectedRows.Item(0)
        Dim arrOfCells As New List(Of String)
        Dim numberOfCells As Integer = datagrid.ColumnCount

        For i = 0 To numberOfCells - 1
            arrOfCells.Add(row.Cells(i).Value.ToString)
        Next

        Return arrOfCells

    End Function

    Public Sub copyFromDataGrid(ByVal datagrid As DataGridView)
        datagrid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText

        Clipboard.SetDataObject(datagrid.GetClipboardContent)
    End Sub

    Public Sub copyFromDataGridWithHeaders(ByVal dg As DataGridView)
        dg.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText

        Dim clipData As String = dg.GetClipboardContent.GetText()

        Dim lines As String() = Regex.Split(clipData, "rn")

        Dim newClipData As New StringBuilder

        Dim tab As Char = vbTab

        For Each line As String In lines

            newClipData.Append(line.Substring(line.IndexOf(tab) + 1) + vbCrLf)

        Next
        Clipboard.SetText(newClipData.ToString(), TextDataFormat.Text)

    End Sub

End Class


