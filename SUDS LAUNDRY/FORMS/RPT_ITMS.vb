Imports System.Data.SqlClient
Imports System.Configuration
Public Class RPT_ITMS
    Public connstring As String = ConfigurationManager.ConnectionStrings("SUDS_ConnectionString").ConnectionString
    Private Sub RPT_ITMS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CBX_CNAME.DataSource = SrC_CSTMER()
        CBX_CNAME.ValueMember = "CUSTOMER_CODE"
        CBX_CNAME.DisplayMember = "NAME"
        CBX_CNAME.SelectedIndex = -1
    End Sub
    Public Function SrC_CSTMER() As DataTable
        Dim dt_items As New DataTable
        Using conn As New SqlConnection(connstring)
            Using cmd As New SqlCommand("SELECT NAME,CUSTOMER_CODE FROM tbl_customer  ORDER BY NAME", conn)
                conn.Open()
                Dim RDR As SqlDataReader = cmd.ExecuteReader()
                dt_items.Load(RDR)
            End Using
        End Using
        Return dt_items
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CBX_CNAME.Text = "" Then
            MessageBox.Show("Select Customer")
        Else
            Dim creport As New report_itemsHistory
            Dim user As String = "sa"
            Dim pwd As String = "p@ssw0rd"
            creport.SetDatabaseLogon(user, pwd)
            creport.SetParameterValue("Cusname", CBX_CNAME.Text)
            creport.SetParameterValue("tCus", CBX_CNAME.SelectedValue.ToString)
            creport.SetParameterValue("tItem", tbxItms.Text)
            creport.SetParameterValue("tDate", DateTimePicker1.Text)
            CrystalReportViewer1.ReportSource = creport
            CrystalReportViewer1.Refresh()

        End If
    End Sub

    Private Sub TSB_EXIT_Click(sender As Object, e As EventArgs) Handles TSB_EXIT.Click
        Me.Dispose()
    End Sub

End Class