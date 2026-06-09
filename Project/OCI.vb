Imports System.IO
Imports iTextSharp.text.pdf

Public Class OCI

    Public Sub GerarOCI()

        Dim pdfOrigem As String =
            "OCI Ortopedia.pdf"

        Dim pdfDestino As String =
            "OCI_Preenchida.pdf"

        Dim reader As New PdfReader(pdfOrigem)

        Dim stamper As New PdfStamper(
            reader,
            New FileStream(
                pdfDestino,
                FileMode.Create
            )
        )

        Dim campos =
            stamper.AcroFields

        campos.SetField(
            "ESTABELECIMENTO",
            "AMBULATORIO MEDICO DE ESPECIALIDADES DE PERUIBE"
        )

        campos.SetField(
            "CNES",
            "7036892"
        )

        campos.SetField(
            "3 - NOME DO PACIENTE",
           FormAMEOCI.txtNomePaciente.Text
        )

        campos.SetField(
            "6 - CPF",
            FormAMEOCI.txtCpfPaciente.Text
        )

        campos.SetField(
            "19 - PROCEDIMENTO",
            FormAMEOCI.txtProcedimentoPrincipal.Text
        )

        campos.SetField(
            "COD principal",
            FormAMEOCI.txtProcedimentoPrincipal.SelectedValue.ToString()
        )

        campos.SetField(
            "PROCED 1",
            FormAMEOCI.dgvProcedimentos.Rows(0).Cells(2).Value.ToString()
        )

        campos.SetField(
            "COD PROCED1",
            FormAMEOCI.dgvProcedimentos.Rows(0).Cells(0).Value.ToString()
        )

        campos.SetField(
            "QTD1",
            FormAMEOCI.dgvProcedimentos.Rows(0).Cells(1).Value.ToString()
        )

        stamper.FormFlattening = True

        stamper.Close()
        reader.Close()



    End Sub

End Class
