Imports System.Data.SqlClient
Imports System.Configuration
Imports CrystalDecisions.CrystalReports.Engine
Imports System.ComponentModel

Public Class printing
    Public connstring As String = ConfigurationManager.ConnectionStrings("SUDS_ConnectionString").ConnectionString
    Private Sub Printing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        Dim creport As New report_receive
        Dim user As String = "sa"
        Dim pwd As String = "p@ssw0rd"
        creport.SetDatabaseLogon(user, pwd)
        creport.SetParameterValue("crTextBox", Form1.ToolStripTBX_R_NUM.Text)
        'creport.Load("C:\New folder\SUDS LAUNDRY\SUDS LAUNDRY\SUDS LAUNDRY\FORMS\CrystalReport1.rpt")
        CrystalReportViewer1.ReportSource = creport
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub printing_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Form1.PRINT_STAT <> "Y" Then
            Try
                Dim conn1 As New SqlConnection(connstring)
                Dim scode As Integer = Form1.ToolStripTBX_R_NUM.Text
                Using command33 As New SqlCommand
                    command33.CommandText = "UPDATE tbl_order SET Printed='Y' WHERE OrDER_ID=" & scode & ""
                    conn1.Open()
                    command33.Connection = conn1
                    command33.ExecuteNonQuery()
                    Dim sdrr As SqlDataReader = command33.ExecuteReader()
                    sdrr.Close()
                End Using
                conn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
        Me.Dispose()
    End Sub
End Class