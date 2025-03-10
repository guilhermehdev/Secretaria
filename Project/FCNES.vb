Imports iTextSharp.text.pdf

Public Class FCNES
    Dim pdfPath As String = Application.StartupPath & "/PDF/equipes.pdf"
    Dim xml As New XML
    Private Sub PlanejamentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlanejamentoToolStripMenuItem.Click
        FplanejCNES.Show()
    End Sub

    Private Sub FCNES_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim estabelecimentos = xml.equipesXML()

        For Each est In estabelecimentos
            'Console.WriteLine($"Estabelecimento: {est.NOME}")
            'Console.WriteLine($"Tipo: {est.TIPOUNIDADE}")
            'Console.WriteLine($"CNES: {est.CNES}")
            Dim nome = est.NOME

            Dim unidade As New FlowLayoutPanel()

            unidade.Name = nome
            unidade.AllowDrop = True
            unidade.Width = 200
            unidade.Height = 200
            unidade.BorderStyle = BorderStyle.FixedSingle
            PanelContainer.Controls.Add(unidade)

            ' AddHandler unidade.DragEnter, AddressOf unidade_DragEnter
            'AddHandler unidade.DragDrop, AddressOf unidade_DragDrop

            If est.Equipes IsNot Nothing Then
                For Each eq In est.Equipes
                    Console.WriteLine($"  Equipe: {eq.NomeReferencia}")

                    If eq.Profissionais IsNot Nothing Then
                        For Each prof In eq.Profissionais
                            Console.WriteLine($"    Profissional: {prof.Nome} (CNS: {prof.CNS}, CPF: {prof.CPF})")
                        Next
                    End If
                Next
            End If

            Console.WriteLine(New String("-"c, 50))
        Next

    End Sub

    Private Sub FCNES_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PanelContainer.Height = Me.Height
    End Sub

End Class