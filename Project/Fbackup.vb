Imports System.IO
Imports System.Security.Permissions
Imports System.Security

Public Class Fbackup
    Public vmain As New Main
    Dim vlog As New Logs

    Private Sub btbackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btbackup.Click
        Flogin.opinterno = "backup"
        Flogin.ShowDialog()
    End Sub

    Private Sub Fbackup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblocalbkp.Text = "Último backup: " & My.Settings.bkplocal
        lbstatus.Text = My.Settings.bkpstatus
        dtpdiaria.Text = My.Settings.bkpdiario
        dtph1.Text = My.Settings.bkp1x
        dtph2.Text = My.Settings.bkp2x

        If lbstatus.Text = "Ativado" Then
            btativar.Enabled = False
            btdesativa.Enabled = True
            dtpdiaria.Enabled = False
            dtph1.Enabled = False
            dtph2.Enabled = False
        Else
            btativar.Enabled = True
            btdesativa.Enabled = False
            dtpdiaria.Enabled = True
            dtph1.Enabled = True
            dtph2.Enabled = True
        End If

        If My.Settings.bkptipo = "0" Then
            rbdiaria.Checked = True
        ElseIf My.Settings.bkptipo = "1" Then
            rbx.Checked = True
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btrestaurar.Click
        OpenFileDialog1.Filter = "SQL (*.sql)|*.sql"
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            Try
                vmain.restoreBackup(OpenFileDialog1)
                MsgBox("Backup restaurado com sucesso! ", MsgBoxStyle.Information)
                vlog.insertLog("BACKUP RESTAURADO", Flogin.idOperador)
            Catch ex As Exception
                'MsgBox(ex.Message)
            End Try

        End If

    End Sub

    Private Sub btativar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btativar.Click
        If Not rbdiaria.Checked = True And Not rbx.Checked = True Then

            MsgBox("Por favor selecione um dos tipos de backup!", MsgBoxStyle.Information)
            Exit Sub
        Else
            If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                My.Settings.bkplocal = FolderBrowserDialog1.SelectedPath
                My.Settings.bkpstatus = "Ativado"

                If rbdiaria.Checked = True Then
                    My.Settings.bkptipo = "0"
                    My.Settings.bkpdiario = FormatDateTime(dtpdiaria.Value.TimeOfDay.ToString)
                    My.Settings.Save()
                ElseIf rbx.Checked = True Then
                    My.Settings.bkptipo = "1"
                    My.Settings.bkp1x = FormatDateTime(dtph1.Value.TimeOfDay.ToString)
                    My.Settings.bkp2x = FormatDateTime(dtph2.Value.TimeOfDay.ToString)
                    My.Settings.Save()
                End If

                FmainOuvidoria.Tbackup.Enabled = True
                FmainOuvidoria.Tbackup.Start()
                My.Settings.bkptimer = "ativo"

                btativar.Enabled = False
                btdesativa.Enabled = True
                dtpdiaria.Enabled = False
                dtph1.Enabled = False
                dtph2.Enabled = False

                lbstatus.Text = My.Settings.bkpstatus

                MsgBox("Backup programado com sucesso!", MsgBoxStyle.Information)
                lblocalbkp.Text = "Local do backup: " & My.Settings.bkplocal
            End If

        End If

    End Sub

    Private Sub btdesativa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btdesativa.Click
        My.Settings.bkpstatus = "Desativado"
        My.Settings.bkptimer = "inativo"

        FmainOuvidoria.Tbackup.Stop()
        btativar.Enabled = True
        btdesativa.Enabled = False
        dtpdiaria.Enabled = True
        dtph1.Enabled = True
        dtph2.Enabled = True

        lbstatus.Text = My.Settings.bkpstatus
    End Sub

    Private Sub MysqldumpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MysqldumpToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            My.Settings.mysqldump = OpenFileDialog1.FileName
            My.Settings.Save()
        End If

    End Sub

    Private Sub MysqlToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MysqlToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            My.Settings.mysql = OpenFileDialog1.FileName
            My.Settings.Save()
        End If
    End Sub
End Class