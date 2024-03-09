Public Class RPT_DAILYTRANS
    Private Sub RPT_DAILYTRANS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim creport As New report_dailyTransaction
        Dim user As String = "sa"
        Dim pwd As String = "p@ssw0rd"
        creport.SetDatabaseLogon(user, pwd)
        creport.SetParameterValue("tDate", DateTimePicker1.Text)
        creport.SetParameterValue("tTransType", "DAILY")
        'creport.Load("C:\New folder\SUDS LAUNDRY\SUDS LAUNDRY\SUDS LAUNDRY\FORMS\CrystalReport1.rpt")
        CrystalReportViewer1.ReportSource = creport
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim creport As New report_dailyTransaction
        Dim user As String = "sa"
        Dim pwd As String = "p@ssw0rd"
        creport.SetDatabaseLogon(user, pwd)
        creport.SetParameterValue("tDate", DateTimePicker1.Text)
        creport.SetParameterValue("tTransType", ComboBox1.Text)
        creport.SetParameterValue("tCus", tCus.Text)
        creport.SetParameterValue("tDept", tDept.Text)
        'creport.Load("C:\New folder\SUDS LAUNDRY\SUDS LAUNDRY\SUDS LAUNDRY\FORMS\CrystalReport1.rpt")
        CrystalReportViewer1.ReportSource = creport
        CrystalReportViewer1.Refresh()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close this window?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If result = DialogResult.Yes Then
            Me.Dispose()
        End If
    End Sub

    Private Sub TSB_EXIT_Click(sender As Object, e As EventArgs) Handles TSB_EXIT.Click
        Me.Dispose()
    End Sub
End Class