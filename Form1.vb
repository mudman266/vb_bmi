Public Class frmMain
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        ' Get the BMI
        Dim decBMI As Decimal
        If (lstMeasurement.SelectedIndex = 0) Then
            decBMI = Imperial_BMI()
        Else
            decBMI = Metric_BMI()
        End If
        ' Determine the catagory the BMI falls in
        Dim strWeightLabel As String
        If (decBMI < 18.5) Then
            strWeightLabel = "Underweight"
        ElseIf (decBMI < 24.9) Then
            strWeightLabel = "Normal Weight"
        ElseIf (decBMI < 29.9) Then
            strWeightLabel = "Overweight"
        Else
            strWeightLabel = "Obese"
        End If
        lblBMI.Text = "BMI: " & decBMI.ToString("F2") & " Catagorized as: " & strWeightLabel
    End Sub
    Private Sub Enable_Button(sender As Object, e As EventArgs) Handles txtWeight.TextChanged, txtHeight.TextChanged, lstMeasurement.SelectedValueChanged
        ' Enable the calculate button if both text boxes have a value and something is selected in the list box
        If (Not txtHeight.Text = "" And Not txtWeight.Text = "" And lstMeasurement.SelectedIndex > -1) Then
            btnCalculate.Enabled = True
        End If
    End Sub
    Private Function Imperial_BMI()
        Dim decBMI As Decimal
        Dim decHeight As Decimal
        Dim decWeight As Decimal
        Try
            decHeight = Convert.ToDecimal(txtHeight.Text)
            decWeight = Convert.ToDecimal(txtWeight.Text)
        Catch ex As Exception
            MsgBox("Invalid value found. Check height and weight and try again.")
        End Try
        decBMI = (decWeight / (decHeight * decHeight)) * 703
        Return decBMI
    End Function
    Private Function Metric_BMI()
        Dim decBMI As Decimal
        Dim decHeight As Decimal
        Dim decWeight As Decimal
        Try
            decHeight = Convert.ToDecimal(txtHeight.Text)
            decWeight = Convert.ToDecimal(txtWeight.Text)
        Catch ex As Exception
            MsgBox("Invalid value found. Check height and weight and try again.")
        End Try
        decBMI = decWeight / (decHeight * decHeight)
        Return decBMI
    End Function

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Show the splash screen for ~2 seconds
        Threading.Thread.Sleep(2000)
    End Sub
End Class
