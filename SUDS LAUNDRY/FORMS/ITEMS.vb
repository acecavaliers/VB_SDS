Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.ComponentModel

Public Class ITEMS
    Public connstring As String = ConfigurationManager.ConnectionStrings("SUDS_ConnectionString").ConnectionString
    Dim itms As String
    Private Sub ITEMS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Try
            Dim values As New List(Of String)

            Dim i As Integer = 0
            For Each row As DataGridViewRow In Form1.DataGridView1.Rows
                If row.Cells(0).Value <> "" Then
                    values.Add("'" & row.Cells(0).Value.ToString() & "'")
                    i += 1
                End If
            Next
            If i = 0 Then
                itms = "''"
            Else
                itms = String.Join(",", values)
            End If
            DataGridView1.DataSource = SrcList()
            DataGridView1.Columns(0).Width = 30
            DataGridView1.Columns(1).Width = 200
            DataGridView1.Columns(2).Width = 80
            'DGTEMP()
            DataGridView1.ClearSelection()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Down Then
            Me.SelectNextControl(sender, True, True, True, True)
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub


    Private Function SrcList() As DataTable
        Dim dt_items As New DataTable
        'Dim C_CODE As String = Form1.TYPE_SERVICE.SelectedValue.ToString
        Dim C_CODE As String = Form1.CBX_CNAME.SelectedValue.ToString

        Using conn As New SqlConnection(connstring)
            'Using cmd As New SqlCommand("SELECT itemcode as 'Item Code',NAME as 'Item Description' ,WEIGHT FROM tbl_item WHERE SERVICE_CODE  LIKE'%" & C_CODE & "%' AND NAME LIKE'%" & TextBox1.Text & "%' AND FNB LIKE'%" & Form1.CBX_FNB.Text & "%' AND ITEMCODE not in (" & itms & ")ORDER BY NAME", conn)
            Using cmd As New SqlCommand("SELECT itemcode as 'Item Code',NAME as 'Item Description' ,WEIGHT FROM tbl_item WHERE itm_stat =1 AND C_CODE ='" & C_CODE & "' AND NAME LIKE'%" & TextBox1.Text & "%' AND FNB LIKE'%" & Form1.CBX_FNB.Text & "%' AND ITEMCODE not in (" & itms & ")ORDER BY NAME", conn)
                conn.Open()
                Dim RDR As SqlDataReader = cmd.ExecuteReader()
                dt_items.Load(RDR)
            End Using
        End Using
        Return dt_items
    End Function

    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        If DataGridView1.CurrentCell.ColumnIndex = 0 Then
            AddHandler CType(e.Control, TextBox).KeyPress, AddressOf TextBox_keyPress
        End If
    End Sub

    Private Sub TextBox_keyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If e.KeyChar = "."c Then
            e.Handled = (CType(sender, TextBox).Text.IndexOf("."c) <> -1)
        ElseIf e.KeyChar <> ControlChars.Back Then
            e.Handled = ("0123456789".IndexOf(e.KeyChar) = -1)
        End If
    End Sub
    Private Sub TextBox2_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        DataGridView1.DataSource = SrcList()
        'DGTEMP()
        DataGridView1.Columns(0).Width = 30
        DataGridView1.Columns(1).Width = 200
        DataGridView1.Columns(2).Width = 80

    End Sub
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        DataGridView1.DataSource = SrcList()
        DataGridView1.ClearSelection()
        'DGTEMP()
        DataGridView1.Columns(0).Width = 30
        DataGridView1.Columns(1).Width = 200
        DataGridView1.Columns(2).Width = 80
    End Sub
    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyData = Keys.Enter Then
            Dim countRows As Integer = 0
            For Each dgvRow As DataGridViewRow In Form1.DataGridView1.Rows  'NOTE: Use dgvMonitoringBoard.Rows - 1  if AllowUserToAddRows property is set to True
                If dgvRow.Cells(0).Value <> "" Then
                    countRows += 1
                End If
            Next
            Dim test As Boolean = False
            For Each row As DataGridViewRow In DataGridView1.SelectedRows
                For Each f1row In Form1.DataGridView1.Rows
                    If row.Cells("Item Code").Value.ToString = f1row.Cells(0).Value Then
                        test = True
                        Exit For
                    End If
                Next
                If test = False Then
                    'If countRows <= 9 Then
                    If Form1.DataGridView1.Rows(countRows).Cells(1).Value = "" Then
                        Form1.DataGridView1.ClearSelection()
                        Form1.DataGridView1.Rows(countRows).Cells(0).Value = row.Cells("Item Code").Value.ToString
                        Form1.DataGridView1.Rows(countRows).Cells(1).Value = row.Cells("Item Description").Value.ToString
                        Form1.DataGridView1.Rows(countRows).Cells(2).Value = row.Cells("WEIGHT").Value.ToString
                        Form1.DataGridView1.Rows(countRows).Cells(3).Value = FormatNumber(Form1.price_per_kg * Double.Parse(row.Cells("WEIGHT").Value), 2)
                        Form1.DataGridView1.Rows(countRows).Cells(4).ReadOnly = False
                        Form1.DataGridView1.Rows(countRows).Cells(8).ReadOnly = False
                        Form1.DataGridView1.Rows(countRows).DefaultCellStyle.BackColor = Color.White
                        Form1.DataGridView1.Rows(countRows).Selected = True
                        Form1.DataGridView1.Rows(countRows).Cells(4).Style.BackColor = Color.LemonChiffon
                        Form1.DataGridView1.Rows(countRows).Cells(8).Style.BackColor = Color.LemonChiffon
                        Form1.DataGridView1.Focus()
                        Form1.DataGridView1.CurrentCell = Form1.DataGridView1.Rows(countRows).Cells(3)
                        Form1.GRID_CHANGER = 0
                        Me.Dispose()
                    End If
                Else
                    MessageBox.Show(Me, "Item Already Added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Next
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        Dim countRows As Integer = 0

        For Each dgvRow As DataGridViewRow In Form1.DataGridView1.Rows  'NOTE: Use dgvMonitoringBoard.Rows - 1  if AllowUserToAddRows property is set to True
                If dgvRow.Cells(0).Value <> "" Then
                    countRows += 1
                End If
            Next
            Dim test As Boolean = False
            For Each row As DataGridViewRow In DataGridView1.SelectedRows
                For Each f1row In Form1.DataGridView1.Rows
                    If row.Cells("Item Code").Value.ToString = f1row.Cells(0).Value Then
                        test = True
                        Exit For
                    End If
                Next
                If test = False Then
                    'If countRows <= 9 Then
                    If Form1.DataGridView1.Rows(countRows).Cells(1).Value = "" Then
                        Form1.DataGridView1.ClearSelection()
                        Form1.DataGridView1.Rows(countRows).Cells(0).Value = row.Cells("Item Code").Value.ToString
                        Form1.DataGridView1.Rows(countRows).Cells(1).Value = row.Cells("Item Description").Value.ToString
                        Form1.DataGridView1.Rows(countRows).Cells(2).Value = row.Cells("WEIGHT").Value.ToString
                        Form1.DataGridView1.Rows(countRows).Cells(3).Value = FormatNumber(Form1.price_per_kg * Double.Parse(row.Cells("WEIGHT").Value), 2)
                        Form1.DataGridView1.Rows(countRows).Cells(4).ReadOnly = False
                        Form1.DataGridView1.Rows(countRows).Cells(8).ReadOnly = False
                        Form1.DataGridView1.Rows(countRows).DefaultCellStyle.BackColor = Color.White
                        Form1.DataGridView1.Rows(countRows).Selected = True
                        Form1.DataGridView1.Rows(countRows).Cells(4).Style.BackColor = Color.LemonChiffon
                        Form1.DataGridView1.Rows(countRows).Cells(8).Style.BackColor = Color.LemonChiffon
                        Form1.DataGridView1.Focus()
                        Form1.DataGridView1.CurrentCell = Form1.DataGridView1.Rows(countRows).Cells(3)
                        Form1.GRID_CHANGER = 0
                        Me.Dispose()
                    End If
                Else
                    MessageBox.Show(Me, "Item Already Added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Next
            Me.Dispose()


    End Sub

    Private Sub ITEMS_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Dispose()
    End Sub


    Private Sub ITEMS_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub DataGridView1_ColumnAdded(sender As Object, e As DataGridViewColumnEventArgs) Handles DataGridView1.ColumnAdded
        e.Column.SortMode = DataGridViewColumnSortMode.NotSortable
    End Sub
End Class