Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports System.Data.OleDb
Imports System.ComponentModel
Public Class Pending
    Public connstring As String = ConfigurationManager.ConnectionStrings("SUDS_ConnectionString").ConnectionString
    Public Src_ID As Integer = 0
    Private Sub Pending_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Function LOAD_RR() As DataTable
        Dim dt_items As New DataTable

        Using conn As New SqlConnection(connstring)
            Using cmd As New SqlCommand("SELECT OrDER_ID AS 'RR No.',IIF(t2.DLVRY_ID IS NULL,0,DLVRY_ID) AS 'DR No.',t0.PICK_UP_REF_NUM AS 'PICKUP No.',FORMAT(t0.DATE, 'MMM dd, yyyy')as 'Date',T0.DEPT,T1.NAME AS CUSTOMER,t0.TYPE_OF_SERVICE,t0.STATUS 
                FROM tbl_order T0
                INNER JOIN tbl_customer T1 ON T0.CCODE=T1.CUSTOMER_CODE
                LEFT JOIN tbl_delivery T2 ON T0.OrDER_ID=T2.REFERENCE and T2.STATUS LIKE '%In-Transit%'
                WHERE t0.STATUS LIKE '%IN PROCESS%'
                ORDER BY t2.REFERENCE,T0.DATE", conn)
                conn.Open()
                Dim RDR As SqlDataReader = cmd.ExecuteReader()
                dt_items.Load(RDR)
            End Using
        End Using
        Return dt_items

    End Function
    Private Function LOAD_DR() As DataTable
        Dim dt_items As New DataTable

        Using conn As New SqlConnection(connstring)
            Using cmd As New SqlCommand("SELECT DLVRY_ID AS 'DR No.',REFERENCE AS 'RR No.',PICK_UP_REF_NUM AS 'PICKUP No.',FORMAT(t0.DATE, 'MMM dd, yyyy')as 'Date', T0.DEPT,T1.NAME AS CUSTOMER,TYPE_OF_SERVICE,STATUS 
                FROM tbl_delivery T0
                INNER JOIN tbl_customer T1 ON T0.CCODE=T1.CUSTOMER_CODE
                WHERE STATUS LIKE '%In-Transit%'
                ORDER BY DATE", conn)
                conn.Open()
                Dim RDR As SqlDataReader = cmd.ExecuteReader()
                dt_items.Load(RDR)
            End Using
        End Using
        Return dt_items

    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Me.Dispose()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.BackColor = Color.DarkOrange
        Button1.BackColor = Color.WhiteSmoke
        DataGrid_Load.DataSource = Nothing
        Src_ID = 2
        DataGrid_Load.DataSource = LOAD_DR()
        DataGrid_Load.Visible = True
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.BackColor = Color.DarkOrange
        Button2.BackColor = Color.WhiteSmoke
        DataGrid_Load.DataSource = Nothing
        Src_ID = 1
        DataGrid_Load.DataSource = LOAD_RR()
        DataGrid_Load.Visible = True
    End Sub

    'Private Sub DataGrid_Load_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGrid_Load.CellMouseDoubleClick
    '    Dim i As Integer
    '    If Src_ID = 2 Then
    '        DELIVERY.FormBorderStyle = FormBorderStyle.FixedSingle
    '        DELIVERY.Show()
    '        With DataGrid_Load
    '            If e.RowIndex >= 0 Then
    '                i = .CurrentRow.Index
    '                DELIVERY.ToolStrip_DEL_DNUM.Text = .Rows(i).Cells(1).Value.ToString
    '            End If
    '        End With
    '        DELIVERY.ToolStripButton2.PerformClick()
    '    Else
    '    End If
    'End Sub
    Private Sub DataGrid_Load_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGrid_Load.CellContentClick
        If TypeOf DataGrid_Load.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
            If Src_ID = 1 Then
                Try
                    'MessageBox.Show(DataGrid_Load.Rows(e.RowIndex).Cells(1).Value.ToString)
                    'Dim frm As New Form1()
                    'frm.ToolStripButton1.Enabled = False
                    'frm.FormBorderStyle = FormBorderStyle.FixedSingle
                    'frm.Show()
                    'frm.ToolStripTBX_R_NUM.Text = DataGrid_Load.Rows(e.RowIndex).Cells(1).Value.ToString
                    'frm.BringToFront()
                    'frm.ButtonDrefHidden.PerformClick()
                    Main.btnRr.PerformClick()
                    Form1.ToolStripTBX_R_NUM.Text = DataGrid_Load.Rows(e.RowIndex).Cells(1).Value.ToString
                    Form1.BringToFront()
                    Form1.ButtonDrefHidden.PerformClick()

                Catch ex As Exception

                End Try
            ElseIf Src_ID = 2 Then
                Try
                    'DELIVERY.FormBorderStyle = FormBorderStyle.FixedSingle
                    'DELIVERY.Show()
                    'DELIVERY.ToolStrip_DEL_DNUM.Text = DataGrid_Load.Rows(e.RowIndex).Cells(1).Value.ToString
                    'DELIVERY.BringToFront()
                    'DELIVERY.ToolStripButton2.PerformClick()
                    Main.btnDr.PerformClick()
                    DELIVERY.ToolStrip_DEL_DNUM.Text = DataGrid_Load.Rows(e.RowIndex).Cells(1).Value.ToString
                    DELIVERY.BringToFront()
                    DELIVERY.ToolStripButton2.PerformClick()
                Catch ex As Exception

                End Try

            End If

        End If
    End Sub
    Private Sub DataGridView1_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles DataGrid_Load.CellFormatting
        If e.RowIndex Mod 2 = 0 AndAlso e.ColumnIndex <> 0 Then
            e.CellStyle.BackColor = Color.WhiteSmoke
        Else
            e.CellStyle.BackColor = DataGrid_Load.DefaultCellStyle.BackColor
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Me.Dispose()
    End Sub
End Class