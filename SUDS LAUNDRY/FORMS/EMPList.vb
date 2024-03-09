Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.ComponentModel
Public Class EMPList
    Public connstring As String = ConfigurationManager.ConnectionStrings("SUDS_ConnectionString").ConnectionString
    Public NAMES As String
    Public CDX As String
    Public Function SrC_RCVR() As DataTable
        Dim dt_items As New DataTable
        Using conn As New SqlConnection(connstring)
            Using cmd As New SqlCommand("SELECT NAME FROM Tbl_users  WHERE name like '%" & TextBox1.Text & "%' and STATUS='ACTIVE' and uname not in('ADMIN','USER','Administrator') ORDER BY name", conn)
                conn.Open()
                Dim RDR As SqlDataReader = cmd.ExecuteReader()
                dt_items.Load(RDR)
            End Using
        End Using
        Return dt_items
    End Function

    Private Sub EMPList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        DataGridView1.DataSource = SrC_RCVR()
        DataGridView1.ClearSelection()
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        'DataGridView1.Columns(0).Width = 20
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim values As New List(Of String)
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(0).Value = True Then
                values.Add(row.Cells(1).Value.ToString())
            End If
        Next
        NAMES = String.Join(",", values)
        If CDX = "DEL_SORT" Then
            DELIVERY.CBX_D_SORT.Text = NAMES
        ElseIf CDX = "DEL_RSORT" Then
            DELIVERY.CBX_D_R_SORT.Text = NAMES
        ElseIf CDX = "REC_SORT" Then
            Form1.CBX_SORT.Text = NAMES
        ElseIf CDX = "REC_DEL_TEAM" Then
            Form1.CBX_DLVR_TEAM.Text = NAMES
        ElseIf CDX = "DLVR_DEL_TEAM" Then
            DELIVERY.CBX_D_DEL_TEAM.Text = NAMES
        End If
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        ' Search for a value that contains "John" in the first column of the DataGridView
        Dim searchValue As String = TextBox1.Text

        Dim rowIndex As Integer = -1
        If DataGridView1.Rows.Count > 0 Then
            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.Cells(1).Value IsNot Nothing AndAlso row.Cells(1).Value.ToString().Contains(searchValue) Then
                    rowIndex = row.Index
                    Exit For
                End If
            Next
        End If

        ' Highlight the row that contains the search value
        If rowIndex <> -1 Then
            DataGridView1.Rows(rowIndex).Selected = True
            DataGridView1.CurrentCell = DataGridView1.Rows(rowIndex).Cells(1)
        End If

        'DataGridView1.DataSource = SrC_RCVR()
        'DataGridView1.ClearSelection()
        'DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
    End Sub
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Down Then
            Me.SelectNextControl(sender, True, True, True, True)
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

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