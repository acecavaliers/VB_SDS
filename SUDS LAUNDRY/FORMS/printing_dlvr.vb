Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.ComponentModel

Public Class printing_dlvr
    Public connstring As String = ConfigurationManager.ConnectionStrings("SUDS_ConnectionString").ConnectionString
    Private Sub Printing_dlvr_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim creport As New report_delivery
        Dim user As String = "sa"
        Dim pwd As String = "p@ssw0rd"
        creport.SetDatabaseLogon(user, pwd)
        creport.SetParameterValue("crTextBox", DELIVERY.ToolStrip_DEL_DNUM.Text)
        CrystalReportViewer1.ReportSource = creport
        CrystalReportViewer1.Refresh()


    End Sub

    Private Sub printing_dlvr_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If DELIVERY.PRINT_STAT <> "Y" Then
            Try
                Dim conn1 As New SqlConnection(connstring)
                Dim scode As Integer = DELIVERY.ToolStrip_DEL_DNUM.Text
                Using command33 As New SqlCommand
                    command33.CommandText = "UPDATE tbl_delivery SET Printed='Y' WHERE DLVRY_ID=" & scode & ""
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