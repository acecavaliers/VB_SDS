Imports System.Data.SqlClient
Imports System.Configuration
Imports CrystalDecisions.CrystalReports.Engine
Imports System.ComponentModel
Public Class PrintMasteList
    Public connstring As String = ConfigurationManager.ConnectionStrings("SUDS_ConnectionString").ConnectionString
    Dim param As String
    Private Sub PrintMasteList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        param = addItems.ComboBox1.Text.ToString
        Dim creport As New report_MasterList
        Dim user As String = "sa"
        Dim pwd As String = "p@ssw0rd"
        creport.SetDatabaseLogon(user, pwd)
        creport.SetParameterValue("crTextBox", param)
        'creport.Load("C:\New folder\SUDS LAUNDRY\SUDS LAUNDRY\SUDS LAUNDRY\FORMS\CrystalReport1.rpt")
        CrystalReportViewer2.ReportSource = creport
        CrystalReportViewer2.Refresh()
    End Sub
End Class