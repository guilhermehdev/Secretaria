﻿Public Class Fstart

    Private Sub btOuvidoria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOuvidoria.Click
        FmainOuvidoria.Show()
        Me.Visible = False
    End Sub

    Private Sub btEmendas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEmendas.Click
        FormAME.Show()
        Me.Visible = False
    End Sub

    Private Sub btRecepcao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRecepcao.Click
        FmainEMTU.Show()
        Me.Visible = False
    End Sub

    Private Sub btSair_Click(sender As Object, e As EventArgs) Handles btSair.Click
        Me.Close()
    End Sub

    Private Sub btCNES_Click_1(sender As Object, e As EventArgs) Handles btCNES.Click
        FplanejCNES.Show()
        Me.Visible = False
    End Sub

End Class