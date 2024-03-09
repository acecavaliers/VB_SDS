Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.ComponentModel
Public Class SERVICES
    Public connstring As String = ConfigurationManager.ConnectionStrings("SUDS_ConnectionString").ConnectionString
    Public stype As Integer = 0
    Public Function SrC_ServiceType() As DataTable
        Dim dt_items As New DataTable
        Using conn As New SqlConnection(connstring)
            Using cmd As New SqlCommand("SELECT service_code as 'CODE', service_type AS 'SERVICE TYPE' ,service_price AS 'REG PRICE',service_price_fnb AS 'FNB PRICE' FROM tbl_services WHERE service_status='ACTIVE' AND CCODE LIKE'%" & Form1.CBX_CNAME.SelectedValue & "%'", conn)
                conn.Open()
                Dim RDR As SqlDataReader = cmd.ExecuteReader()
                dt_items.Load(RDR)
            End Using
        End Using
        Return dt_items
    End Function

    Public Function SrC_ServiceType1() As DataTable
        Dim dt_items As New DataTable
        Using conn As New SqlConnection(connstring)
            Using cmd As New SqlCommand("SELECT service_code as 'CODE', service_type AS 'SERVICE TYPE' ,service_price AS 'REG PRICE',service_price_fnb AS 'FNB PRICE' FROM tbl_services WHERE service_status='ACTIVE' AND CCODE LIKE'%" & addItems.CBX_I_COM.SelectedValue & "%' ", conn)
                conn.Open()
                Dim RDR As SqlDataReader = cmd.ExecuteReader()
                dt_items.Load(RDR)
            End Using
        End Using
        Return dt_items
    End Function

    Private Sub SERVICES_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'DataGridView1.ReadOnly = True
        If stype <> 0 Then
            DataGridView1.DataSource = SrC_ServiceType1()
            Button1.Visible = True
        Else
            DataGridView1.DataSource = SrC_ServiceType()
            Button1.Visible = False
        End If


        DataGridView1.Columns(0).Width = 30
        DataGridView1.Columns(1).Width = 50
        DataGridView1.Columns(2).Width = 150
        DataGridView1.Columns(3).Width = 65
        DataGridView1.Columns(4).Width = 100

        DataGridView1.Columns(0).ReadOnly = False
        DataGridView1.Columns(1).ReadOnly = True
        DataGridView1.Columns(2).ReadOnly = True
        DataGridView1.Columns(3).ReadOnly = True
        DataGridView1.Columns(4).ReadOnly = True


    End Sub

    Private Sub SERVICES_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub SERVICES_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim values As New List(Of String)
        Dim names As String
        Dim i As Integer = 0
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(0).Value = True Then
                values.Add(row.Cells(1).Value.ToString())
                i += 1
            End If
        Next
        names = String.Join(",", values)
        If i <> 0 Then
            If addItems.TBX_SERVICE.Text = "" Then
                addItems.TBX_SERVICE.Text = addItems.TBX_SERVICE.Text & names
            Else
                addItems.TBX_SERVICE.Text = addItems.TBX_SERVICE.Text & "," & names
            End If
        End If
        Me.Dispose()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            If DataGridView1.Rows(e.RowIndex).Cells(0).Value = True Then
                DataGridView1.Rows(e.RowIndex).Cells(0).Value = False
                DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
            Else
                DataGridView1.Rows(e.RowIndex).Cells(0).Value = True
                DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.DodgerBlue
            End If
        End If
    End Sub
End Class