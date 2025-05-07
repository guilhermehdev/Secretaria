Public Class BLH
    Dim m As New Main
    Public Function percentualCreme(creme1 As Double, total1 As Double, creme2 As Double, total2 As Double, creme3 As Double, total3 As Double) As Double
        ' Validações para evitar divisões por zero
        If total1 = 0 Or total2 = 0 Or total3 = 0 Then
            Throw New ArgumentException("Os divisores não podem ser zero.")
        End If

        ' Cálculo conforme a fórmula do Excel
        Dim parte1 As Double = (creme1 * 100 / total1)
        Dim parte2 As Double = (creme2 * 100 / total2)
        Dim parte3 As Double = (creme3 * 100 / total3)

        ' Média final
        Dim resultado As Double = (parte1 + parte2 + parte3) / 3

        Return resultado
    End Function

    Public Function PercentualDeGordura(creme1 As Double, total1 As Double, creme2 As Double, total2 As Double, creme3 As Double, total3 As Double) As Double
        ' Validações para evitar divisões por zero
        If total1 = 0 Or total2 = 0 Or total3 = 0 Then
            Throw New ArgumentException("Os divisores não podem ser zero.")
        End If

        ' Cálculo conforme a fórmula do Excel
        Dim parte1 As Double = (((creme1 * 100 / total1) - 0.59) / 1.46)
        Dim parte2 As Double = (((creme2 * 100 / total2) - 0.59) / 1.46)
        Dim parte3 As Double = (((creme3 * 100 / total3) - 0.59) / 1.46)

        ' Média final
        Dim resultado As Double = (parte1 + parte2 + parte3) / 3

        Return resultado
    End Function

    Public Function Kcal(creme1 As Double, total1 As Double, creme2 As Double, total2 As Double, creme3 As Double, total3 As Double) As Double
        ' Validações para evitar divisões por zero
        If total1 = 0 Or total2 = 0 Or total3 = 0 Then
            Throw New ArgumentException("Os divisores não podem ser zero.")
        End If

        ' Constante de peso e valor adicional
        Dim peso As Double = 66.8
        Dim adicional As Double = 290

        ' Cálculo conforme a fórmula do Excel
        Dim parte1 As Double = ((creme1 * 100 / total1) * peso + adicional)
        Dim parte2 As Double = ((creme2 * 100 / total2) * peso + adicional)
        Dim parte3 As Double = ((creme3 * 100 / total3) * peso + adicional)

        ' Média final
        Dim resultado As Double = (parte1 + parte2 + parte3) / 3

        Return resultado
    End Function

    Public Sub loadPartos(combobox As ComboBox, idDoadora As Integer)
        If m.loadComboBox($"SELECT id, data FROM blh_partos WHERE id_doadora={idDoadora} ORDER BY data DESC", combobox, "data", "id").Rows.count = 0 Then
            combobox.DataSource = Nothing
        End If
    End Sub

End Class
