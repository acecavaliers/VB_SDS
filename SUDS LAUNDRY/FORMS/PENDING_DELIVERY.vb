Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Data.OleDb
Imports System.ComponentModel

Public Class PENDING_DELIVERY
    Public connstring As String = ConfigurationManager.ConnectionStrings("SUDS_ConnectionString").ConnectionString
    Private Sub PENDING_DELIVERY_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        Try
            For Each dgvRow As DataGridViewRow In DataGridView1.Rows
                If dgvRow.Cells("OPEN").Value = 0 Then
                    dgvRow.DefaultCellStyle.ForeColor = Color.Red
                End If
            Next
            DataGridView1.Columns(0).Width = 100
            DataGridView1.Columns(1).Width = 100
            DataGridView1.Columns(2).Width = 150
            DataGridView1.Columns(3).Width = 100
            DataGridView1.Columns(4).Width = 150
            DataGridView1.Columns("OPEN").Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
    '    Dim i As Integer
    '    Dim NUM As String
    '    With DataGridView1
    '        If e.RowIndex >= 0 Then
    '            i = .CurrentRow.Index
    '            NUM = .Rows(i).Cells(0).Value.ToString
    '            DELIVERY.D_REF.Text = NUM
    '            'DELIVERY.ToolStrip_DEL_DNUM.Text = NUM
    '        End If
    '    End With
    '    DELIVERY.Button2.PerformClick()
    '    Me.Dispose()
    'End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then 'make sure a valid cell is clicked
            Dim value As Integer = CInt(DataGridView1.Rows(e.RowIndex).Cells("OPEN").Value)
            If value = 0 Then
                MessageBox.Show("All items are already delivered and waiting for confirmation.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Dim i As Integer
                Dim NUM As String
                With DataGridView1
                    If e.RowIndex >= 0 Then
                        i = .CurrentRow.Index
                        NUM = .Rows(i).Cells(0).Value.ToString
                        DELIVERY.D_REF.Text = NUM
                    End If
                End With
                DELIVERY.Button2.PerformClick()
                Me.Dispose()
            End If
        End If
    End Sub


    Private Sub PENDING_DELIVERY_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Me.Dispose()
    End Sub

    Private Sub PENDING_DELIVERY_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Dispose()

    End Sub
End Class