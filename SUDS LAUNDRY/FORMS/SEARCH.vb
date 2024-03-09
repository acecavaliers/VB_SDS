Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Data.OleDb
Imports System.ComponentModel

Public Class SEARCH
    Public connstring As String = ConfigurationManager.ConnectionStrings("SUDS_ConnectionString").ConnectionString
    Public C_CODE, PICKUPFORMNO, SORTER, TYPE_OF_SERVICE, R_DATE, DEL_DATE, DEL_TEAM, REMARKS, SORT_REC, CHECKEDBY, DELFORMNO, REFERENCE, TTYPE As String

    Private Sub SEARCH_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CenterToScreen()
        Try
            If TTYPE = "RDR" Then
                DataGridView1.DataSource = SrcrES()
                If DataGridView1.Rows.Count > 2 Then

                ElseIf DataGridView1.Rows.Count = 1 Then
                    Form1.ToolStripTBX_R_NUM.Text = DataGridView1.Rows(0).Cells("OrDER_ID").Value.ToString
                    Form1.ButtonDrefHidden.PerformClick()
                    Me.Dispose()
                    Form1.CheckBox1.Checked = False
                ElseIf DataGridView1.Rows.Count < 1 Then
                    Me.Dispose()
                    MessageBox.Show("No Record found!")
                End If
            ElseIf TTYPE = "DLVR" Then
                DataGridView1.DataSource = SrcrDEL()
                If DataGridView1.Rows.Count > 2 Then

                ElseIf DataGridView1.Rows.Count = 1 Then
                    DELIVERY.ToolStrip_DEL_DNUM.Text = DataGridView1.Rows(0).Cells("DR Entry No.").Value.ToString
                    DELIVERY.ToolStripButton2.PerformClick()
                    Me.Dispose()
                    DELIVERY.CheckBox1.Checked = False
                ElseIf DataGridView1.Rows.Count < 1 Then
                    Me.Dispose()
                    DELIVERY.ToolStripButton6.PerformClick()
                End If
            ElseIf TTYPE = "DREF" Then
                DataGridView1.DataSource = SrcrDELREF()
                If DataGridView1.Rows.Count > 2 Then

                ElseIf DataGridView1.Rows.Count = 1 Then

                    DELIVERY.ToolStrip_DEL_DNUM.Text = DataGridView1.Rows(0).Cells("DR Entry No.").Value.ToString
                    DELIVERY.ToolStripButton2.PerformClick()
                    DELIVERY.CheckBox1.Checked = False
                    'Me.Dispose()



                ElseIf DataGridView1.Rows.Count < 1 Then
                    DELIVERY.ToolStripButton6.PerformClick()
                    Me.Dispose()
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub SEARCH_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        Dim i As Integer
        If TTYPE = "RDR" Then
            With DataGridView1
                If e.RowIndex >= 0 Then
                    i = .CurrentRow.Index
                    Form1.ToolStripTBX_R_NUM.Text = .Rows(i).Cells(0).Value.ToString
                End If
            End With
            Form1.ButtonDrefHidden.PerformClick()
            Form1.CheckBox1.Checked = False
            If CheckBox1.Checked = False Then
                Me.Dispose()
            Else
                Form1.BringToFront()
            End If
        ElseIf TTYPE = "DLVR" Then
            With DataGridView1
                If e.RowIndex >= 0 Then
                    i = .CurrentRow.Index
                    DELIVERY.ToolStrip_DEL_DNUM.Text = .Rows(i).Cells(0).Value.ToString
                End If
            End With
            DELIVERY.ToolStripButton2.PerformClick()
            DELIVERY.CheckBox1.Checked = False
            If CheckBox1.Checked = False Then
                Me.Dispose()
            Else
                DELIVERY.BringToFront()
            End If
        ElseIf TTYPE = "DREF" Then
            Dim DFRS As Integer = 0
            With DataGridView1
                If e.RowIndex >= 0 Then
                    i = .CurrentRow.Index
                    DFRS = .Rows(i).Cells(0).Value.ToString
                End If
            End With
            Dim newDeliveryForm As New DELIVERY()
            newDeliveryForm.Show()
            newDeliveryForm.FormBorderStyle = FormBorderStyle.FixedSingle

            newDeliveryForm.ToolStrip_DEL_DNUM.Text = DFRS
            newDeliveryForm.ToolStripButton2.PerformClick()
            newDeliveryForm.ToolStrip2.Enabled = False
            newDeliveryForm.DataGridView1.Enabled = False
            newDeliveryForm.BTN_CONFRM_DLVR.Visible = False
            newDeliveryForm.ButtonSAVE_DEL.Visible = False
            newDeliveryForm.CheckBox1.Checked = False
            newDeliveryForm.BringToFront()
            'If CheckBox1.Checked = False Then
            '    Me.Dispose()
            'Else
            '    newDeliveryForm.BringToFront()
            'End If
        End If


    End Sub

    Private Function SrcrES() As DataTable
        Dim dt_items As New DataTable

        Using conn As New SqlConnection(connstring)
            Using cmd As New SqlCommand("SELECT OrDER_ID as 'RR Entry No.',PICK_UP_REF_NUM as 'Pick-up No.',T1.NAME as 'Customer name',Status,DATE as 'RR Date'
                                            ,PICK_UP_REF_NUM as 'Pickup No'
                                            FROM tbl_order T0 INNER JOIN tbl_customer T1 ON T0.CCODE=T1.CUSTOMER_CODE
                                            WHERE T1.NAME LIKE '%" & C_CODE & "%'
                                            AND PICK_UP_REF_NUM LIKE '%" & PICKUPFORMNO & "%' 
                                            AND SORTER LIKE '%" & SORTER & "%'
                                            AND TYPE_OF_SERVICE LIKE '%" & TYPE_OF_SERVICE & "%'
                                            AND DATE LIKE '%" & R_DATE & "%'
                                            AND DELIVERY_DATE LIKE '%" & DEL_DATE & "%'
                                            AND DELIVERY_TEAM LIKE '%" & DEL_TEAM & "%'
                                            AND Remarks LIKE '%" & REMARKS & "%'
                                            AND SORTED_RECEIVED_BY LIKE '%" & SORT_REC & "%'
                                            AND CHECKED_BY LIKE '%" & CHECKEDBY & "%'
                                            ORDER BY OrDER_ID
                                            ", conn)
                conn.Open()
                Dim RDR As SqlDataReader = cmd.ExecuteReader()
                dt_items.Load(RDR)
            End Using
        End Using

        Return dt_items
    End Function
    Private Function SrcrDEL() As DataTable
        Dim dt_items As New DataTable

        Using conn As New SqlConnection(connstring)
            Using cmd As New SqlCommand("SELECT DLVRY_ID as 'DR Entry No.',DELFORMNUM as 'DR FORM NUMBER',T1.NAME as 'Customer name',Status,DATE as 'DR Date' 
                                         ,PICK_UP_REF_NUM as 'Pickup No'
                                            FROM tbl_delivery T0 INNER JOIN tbl_customer T1 ON T0.CCODE=T1.CUSTOMER_CODE
                                            WHERE PICK_UP_REF_NUM LIKE '%" & PICKUPFORMNO & "%' 
                                            AND REFERENCE LIKE '%" & REFERENCE & "%'
                                            ORDER BY DLVRY_ID
                                            ", conn)
                conn.Open()
                Dim RDR As SqlDataReader = cmd.ExecuteReader()
                dt_items.Load(RDR)
            End Using
        End Using
        Return dt_items
    End Function
    Private Function SrcrDELREF() As DataTable
        Dim dt_items As New DataTable

        Using conn As New SqlConnection(connstring)
            Using cmd As New SqlCommand("SELECT DLVRY_ID as 'DR Entry No.',DELFORMNUM as 'DR FORM NUMBER',T1.NAME as 'Customer name',Status,DATE as 'DR Date' 
                                            ,PICK_UP_REF_NUM as 'Pickup No'
                                            FROM tbl_delivery T0 INNER JOIN tbl_customer T1 ON T0.CCODE=T1.CUSTOMER_CODE
                                            WHERE  REFERENCE =" & REFERENCE & "
                                            ORDER BY DLVRY_ID
                                            ", conn)
                conn.Open()
                Dim RDR As SqlDataReader = cmd.ExecuteReader()
                dt_items.Load(RDR)
            End Using
        End Using
        Return dt_items
    End Function
End Class