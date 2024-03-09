Imports System.Data.SqlClient
Imports System.Configuration

Public Class PostPayment
    Dim SOA As String
    Dim balance As Double
    Dim dr_amt As Decimal
    Dim dr_num As Integer

    Public connstring As String = ConfigurationManager.ConnectionStrings("SUDS_ConnectionString").ConnectionString
    Private Function LOAD_SOA() As DataTable
        Dim dt_items As New DataTable

        Using conn As New SqlConnection(connstring)
            Using cmd As New SqlCommand("SELECT SoaSeries as 'SOA Series' ,CCODE ,Customer ,Department ,SrvcsType ,P_FROM ,P_TO,Total,isnull(Payment,0) as Payment FROM Tbl_SOA", conn)
                conn.Open()
                Dim RDR As SqlDataReader = cmd.ExecuteReader()
                dt_items.Load(RDR)
            End Using
        End Using
        Return dt_items

    End Function
    Private Function LOAD_SOA_DETAILS() As DataTable
        Dim dt_items As New DataTable

        Using conn As New SqlConnection(connstring)
            Using cmd As New SqlCommand("SELECT DRNUM AS 'DR#',ISNULL(pay_amt,0) AS 'Payments',PAYMENT_STAT-ISNULL(pay_amt,0) AS 'Balance' FROM TBL_SOA_DETAILS WHERE SOA_SERIES ='" & SOA & "' ORDER BY  PAYMENT_STAT-ISNULL(pay_amt,0) DESC,DRNUM ASC", conn)
                conn.Open()
                Dim RDR As SqlDataReader = cmd.ExecuteReader()
                dt_items.Load(RDR)
            End Using
        End Using
        Return dt_items

    End Function
    Public Sub DRIDDER()
        Dim totalWidth As Integer = DataGridView1.Width
        Dim c0 As Double = 0.05 ' 10%
        Dim c1 As Double = 0.35 ' 10%
        Dim c2 As Double = 0.3 ' 20%
        Dim c3 As Double = 0.3 ' 20%
        'Dim c4 As Double = 0.1 ' 10%
        'Dim c5 As Double = 0.1 ' 10%

        Dim c0w As Integer = CInt(totalWidth * c0)
        Dim c1w As Integer = CInt(totalWidth * c1)
        Dim c2w As Integer = CInt(totalWidth * c2)
        Dim c3w As Integer = CInt(totalWidth * c3)
        'Dim c4w As Integer = CInt(totalWidth * c4)
        'Dim c5w As Integer = CInt(totalWidth * c5)

        DataGridView1.Columns.Item(0).Width = c0w
        DataGridView1.Columns.Item(1).Width = c1w
        DataGridView1.Columns.Item(3).Width = c2w
        DataGridView1.Columns.Item(4).Width = c3w
        'DataGridView1.Columns.Item(6).Width = c4w
        'DataGridView1.Columns.Item(7).Width = c5w

    End Sub
    Private Sub PostPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim pw As Double = Panel1.Width / 2
        Dim ppw As Double = pw - 30
        Panel2.Width = ppw
        Panel3.Width = ppw
        SOA = ""
        'GroupBox1.Width = ppw
        Panel3.Location = New Point(pw, 53)
        'GroupBox1.Location = New Point(pw + 30, 32)
        DataGridView1.DefaultCellStyle.Font = New Font("Segoe UI", 10)
        DataGridView2.DefaultCellStyle.Font = New Font("Segoe UI", 10)
        DataGridView1.DataSource = LOAD_SOA()

        If DataGridView1.Rows.Count > 0 Then
            DataGridView1.Visible = True
            Label1.Text = "SOA LIST"
            Label2.Visible = True
            TextBox1.Visible = True
        Else
            DataGridView1.Visible = False
            Label1.Text = "NO SOA FOUND"
            Label2.Visible = False
            TextBox1.Visible = False
        End If

        SOA_detailsAll()
        Load_dtls()
        DataGridView1.Columns(2).Visible = False
        'DataGridView1.Columns(4).Visible = False
        DataGridView1.Columns(5).Visible = False
        DataGridView1.Columns(6).Visible = False
        DataGridView1.Columns(7).Visible = False
        DataGridView1.Columns(8).Visible = False
        DataGridView1.Columns(9).Visible = False
        DRIDDER()
    End Sub

    Private Sub PostPayment_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Dim pw As Double = Panel1.Width / 2
        Dim ppw As Double = pw - 30
        Panel2.Width = ppw
        Panel3.Width = ppw
        'GroupBox1.Width = ppw
        Panel3.Location = New Point(pw, 53)
        'GroupBox1.Location = New Point(pw + 30, 32)
    End Sub

    Public Sub SOA_details()
        DataGridView2.DataSource = LOAD_SOA_DETAILS()
        DataGridView2.ClearSelection()
        For Each dgvRow As DataGridViewRow In DataGridView2.Rows
            If dgvRow.Cells("DR#").Value = dr_num Then
                dgvRow.Selected = True
            End If
        Next
    End Sub
    Public Sub SOA_detailsAll()
        SOA_details()
        SOA_Header()
    End Sub
    Public Sub SOA_Header()
        DataGridView1.DataSource = LOAD_SOA()
        DataGridView1.ClearSelection()
        For Each dgvRow As DataGridViewRow In DataGridView1.Rows
            If dgvRow.Cells("SOA Series").Value.ToString = SOA Then
                dgvRow.Selected = True
            End If
        Next
    End Sub

    Public Sub Load_dtls()


        DataGridView2.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView2.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView2.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView2.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView2.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView2.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView2.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView2.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView2.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        DataGridView2.Columns(4).DefaultCellStyle.Format = "N2"
        DataGridView2.Columns(5).DefaultCellStyle.Format = "N2"
        DataGridView2.RowTemplate.Height = 25




    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If TypeOf DataGridView1.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
            SOA = ""
            balance = 0
            balance = DataGridView1.Rows(e.RowIndex).Cells(8).Value - DataGridView1.Rows(e.RowIndex).Cells(9).Value
            SOA = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
            lblsoa.Text = ": " & DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
            lblname.Text = ": " & DataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString
            lbldept.Text = ": " & DataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString
            lblprd.Text = ": " & DataGridView1.Rows(e.RowIndex).Cells(6).Value & " To " & DataGridView1.Rows(e.RowIndex).Cells(7).Value
            lblttl.Text = ": Php " & Convert.ToDecimal(DataGridView1.Rows(e.RowIndex).Cells(8).Value.ToString).ToString("N2")
            lblbal.Text = ": Php " & Convert.ToDecimal(balance).ToString("N2")

            SOA_detailsAll()
            If balance = 0 Then
                Button1.Enabled = False
            Else
                Button1.Enabled = True
            End If
            Panel3.Visible = True
        End If
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub TSB_EXIT_Click(sender As Object, e As EventArgs) Handles TSB_EXIT.Click
        Me.Dispose()
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        If TypeOf DataGridView2.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.ColumnIndex = 0 AndAlso e.RowIndex >= 0 Then
            dr_num = DataGridView2.Rows(e.RowIndex).Cells("DR#").Value
            If DataGridView2.Rows(e.RowIndex).Cells("Balance").Value <> 0 Then
                dr_amt = DataGridView2.Rows(e.RowIndex).Cells("Balance").Value
                'dr_num = DataGridView2.Rows(e.RowIndex).Cells("DR#").Value
                AdDr()
            Else
                MessageBox.Show("No changes made. DR No." & dr_num & " already paid in full.")
            End If
        ElseIf TypeOf DataGridView2.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.ColumnIndex = 1 AndAlso e.RowIndex >= 0 Then
            dr_amt = 0
            dr_num = DataGridView2.Rows(e.RowIndex).Cells("DR#").Value
            Dim bal As Decimal = DataGridView2.Rows(e.RowIndex).Cells("Balance").Value
            Dim pay_amt As Decimal = DataGridView2.Rows(e.RowIndex).Cells("Payment").Value
            If IsNumeric(DataGridView2.Rows(e.RowIndex).Cells("Payment").Value) AndAlso bal <> 0 AndAlso pay_amt <= bal Then
                dr_amt = DataGridView2.Rows(e.RowIndex).Cells("Payment").Value
                AdDr()
            Else
                MessageBox.Show("Invalid amount")
            End If

        End If
    End Sub
    Public Sub AdDr()
        Dim sqlCon = New SqlConnection(connstring)
        Using (sqlCon)
            Dim sqlComm As New SqlCommand With {
                .Connection = sqlCon,
                .CommandText = "SOA_PAYMENT",
                .CommandType = CommandType.StoredProcedure
            }

            sqlComm.Parameters.AddWithValue("@DRNUM", dr_num)
            sqlComm.Parameters.AddWithValue("@SOA_SERIES", SOA)
            sqlComm.Parameters.AddWithValue("@AMT", dr_amt)

            sqlCon.Open()
            'sqlComm.ExecuteNonQuery()
            Dim sdr As SqlDataReader = sqlComm.ExecuteReader()
            If (sdr.Read()) Then
                Dim bal As Decimal
                bal = sdr("BAL")
                lblbal.Text = ": Php " & Convert.ToDecimal(bal).ToString("N2")
                SOA_detailsAll()
            End If
            sdr.Close()
            sqlCon.Close()
        End Using
    End Sub

    Private Sub DataGridView2_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridView2.RowsAdded
        For Each row In DataGridView2.Rows
            row.Cells("Payment").Style.BackColor = Color.LemonChiffon
        Next
    End Sub
    Private Sub TextBox_keyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If e.KeyChar = "."c Then
            e.Handled = (CType(sender, TextBox).Text.IndexOf("."c) <> -1)
        ElseIf e.KeyChar <> ControlChars.Back Then
            e.Handled = ("0123456789".IndexOf(e.KeyChar) = -1)
        End If
    End Sub
    Private Sub Cell0_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub DataGridView2_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DataGridView2.EditingControlShowing
        If DataGridView2.CurrentCell.ColumnIndex = 2 Then
            AddHandler CType(e.Control, TextBox).KeyPress, AddressOf TextBox_keyPress
        Else
            AddHandler e.Control.KeyPress, AddressOf Cell0_KeyPress
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PayAll()
    End Sub
    Public Sub PayAllQue()
        Dim sqlCon = New SqlConnection(connstring)
        Using (sqlCon)
            Dim sqlComm As New SqlCommand With {
                .Connection = sqlCon,
                .CommandText = "SOA_PAYMENT",
                .CommandType = CommandType.StoredProcedure
            }

            sqlComm.Parameters.AddWithValue("@DRNUM", dr_num)
            sqlComm.Parameters.AddWithValue("@SOA_SERIES", SOA)
            sqlComm.Parameters.AddWithValue("@AMT", dr_amt)

            sqlCon.Open()
            'sqlComm.ExecuteNonQuery()
            Dim sdr As SqlDataReader = sqlComm.ExecuteReader()
            If (sdr.Read()) Then
                Dim bal As Decimal
                bal = sdr("BAL")
                lblbal.Text = ": Php " & Convert.ToDecimal(bal).ToString("N2")

            End If
            sdr.Close()
            sqlCon.Close()
        End Using
    End Sub
    Public Sub PayAll()
        For Each dgvRow As DataGridViewRow In DataGridView2.Rows
            If dgvRow.Cells("Balance").Value <> 0 Then
                dr_num = dgvRow.Cells("DR#").Value
                dr_amt = dgvRow.Cells("Balance").Value
                PayAllQue()
            End If
        Next
        SOA_detailsAll()
    End Sub


End Class