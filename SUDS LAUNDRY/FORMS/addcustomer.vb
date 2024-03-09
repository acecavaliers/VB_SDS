Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Data.OleDb
Public Class addcustomer
    Public connstring As String = ConfigurationManager.ConnectionStrings("SUDS_ConnectionString").ConnectionString
    Dim tr As Integer = 0
    Public CCODE As String
    Public Sub customer_id()
        Dim sqlCon_C = New SqlConnection(connstring)
        Try
            Dim cmd As New SqlCommand("select  RIGHT('000' + CAST(max(replace(CUSTOMER_CODE,'C',''))+1 AS varchar(3)) , 3)AS id from tbl_customer", sqlCon_C)
            If (sqlCon_C.State <> ConnectionState.Open) Then
                sqlCon_C.Open()
            End If
            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            sdr.Read()
            CCODE = "C" & sdr("id")
            sdr.Close()
            sqlCon_C.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub CLEAR_TXT()
        TBX_CCODE.Text = Nothing
        TBX_C_NAME.Text = Nothing
        TBX_C_ADD.Text = Nothing
        TBX_C_CON_NUM.Text = Nothing
        TBX_TIN.Text = Nothing
        TBX_COMP_NAME.Text = Nothing
        TBX_PU_INDEX.Text = Nothing
        tr = 0
        btn_add_Dsabl()
        btn_updt_Dsabl()
    End Sub
    Public Sub ADD_CUSTOMER()
        Try
            Dim sqlCon = New SqlConnection(connstring)
            Using (sqlCon)
                Dim sqlComm As New SqlCommand With {
                    .Connection = sqlCon,
                    .CommandText = "AddCustomer",
                    .CommandType = CommandType.StoredProcedure
                }

                sqlComm.Parameters.AddWithValue("@CUSTOMER_CODE", TBX_CCODE.Text)
                sqlComm.Parameters.AddWithValue("@NAME", TBX_C_NAME.Text)
                sqlComm.Parameters.AddWithValue("@COMPANYNAME", TBX_COMP_NAME.Text)
                sqlComm.Parameters.AddWithValue("@TIN", TBX_TIN.Text)
                sqlComm.Parameters.AddWithValue("@ADDRESS", TBX_C_ADD.Text)
                sqlComm.Parameters.AddWithValue("@CONTACT", TBX_C_CON_NUM.Text)
                sqlComm.Parameters.AddWithValue("@STATUS", CheckBox1.Text)
                sqlComm.Parameters.AddWithValue("@PUINDEX", TBX_PU_INDEX.Text)
                sqlCon.Open()
                If sqlComm.ExecuteNonQuery() = 1 Then
                    MessageBox.Show("Customer: " & TBX_C_NAME.Text & " successfully added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CLEAR_TXT()
                End If
                sqlCon.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub UPDT_CUSTOMER()
        Try
            Dim sqlCon = New SqlConnection(connstring)
            Using (sqlCon)
                Dim sqlComm As New SqlCommand With {
                    .Connection = sqlCon,
                    .CommandText = "UpdtCustomer",
                    .CommandType = CommandType.StoredProcedure
                }

                sqlComm.Parameters.AddWithValue("@CUSTOMER_CODE", TBX_CCODE.Text)
                sqlComm.Parameters.AddWithValue("@NAME", TBX_C_NAME.Text)
                sqlComm.Parameters.AddWithValue("@COMPANYNAME", TBX_COMP_NAME.Text)
                sqlComm.Parameters.AddWithValue("@TIN", TBX_TIN.Text)
                sqlComm.Parameters.AddWithValue("@ADDRESS", TBX_C_ADD.Text)
                sqlComm.Parameters.AddWithValue("@CONTACT", TBX_C_CON_NUM.Text)
                sqlComm.Parameters.AddWithValue("@STATUS", CheckBox1.Text)
                sqlComm.Parameters.AddWithValue("@PUINDEX", TBX_PU_INDEX.Text)
                sqlCon.Open()
                Dim RowsAffected As Integer = sqlComm.ExecuteNonQuery()
                If RowsAffected > 0 Then
                End If
                sqlCon.Close()
            End Using
            MessageBox.Show("Record for customer: " & TBX_C_NAME.Text & " successfully updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DataGridCUST.DataSource = CUSTOMERList()
            For Each dgvRow As DataGridViewRow In DataGridCUST.Rows
                If dgvRow.Cells("STATUS").Value <> "ACTIVE" Then
                    dgvRow.DefaultCellStyle.ForeColor = Color.Red
                End If
            Next
            CLEAR_TXT()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Function CUSTOMERList() As DataTable
        Dim dt_items As New DataTable
        Using conn As New SqlConnection(connstring)
            Using cmd As New SqlCommand("SELECT CUSTOMER_CODE AS 'CODE',company_name AS 'COMPANY NAME',NAME AS 'TRADE NAME',ADDRESS,[CONTACT NO],TIN,C_STAT AS 'STATUS',PU_INDEX AS 'PU' FROM tbl_customer ORDER BY C_STAT  ", conn)
                conn.Open()
                Dim RDR As SqlDataReader = cmd.ExecuteReader()
                dt_items.Load(RDR)
            End Using
        End Using
        Return dt_items
    End Function

    Private Sub TBC_C_NAME_Leave(sender As Object, e As EventArgs) Handles TBX_C_NAME.Leave
        If tr = 0 AndAlso TBX_C_NAME.Text <> "" Then
            customer_id()
            TBX_CCODE.Text = CCODE.ToString
        End If
    End Sub
    '==========//ADD CUSTOMER
    Private Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataGridCUST_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridCUST.CellMouseDoubleClick
        Dim i As Integer
        With DataGridCUST
            If e.RowIndex >= 0 Then
                i = .CurrentRow.Index
                tr = 1

                TBX_CCODE.Text = .Rows(i).Cells("CODE").Value.ToString
                TBX_C_NAME.Text = .Rows(i).Cells("TRADE NAME").Value.ToString
                TBX_C_ADD.Text = .Rows(i).Cells("ADDRESS").Value.ToString
                TBX_C_CON_NUM.Text = .Rows(i).Cells("CONTACT NO").Value.ToString.Replace(" ", "")
                TBX_TIN.Text = .Rows(i).Cells("TIN").Value.ToString
                TBX_COMP_NAME.Text = .Rows(i).Cells("COMPANY NAME").Value.ToString
                TBX_PU_INDEX.Text = .Rows(i).Cells("PU").Value.ToString
                If .Rows(i).Cells(5).Value = "ACTIVE" Then
                    CheckBox1.Checked = True
                Else
                    CheckBox1.Checked = False
                End If

                btn_add_Dsabl()
                btn_updt_enl()
            End If
        End With
    End Sub


    Private Sub TBX_CCODE_TextChanged(sender As Object, e As EventArgs) Handles TBX_CCODE.TextChanged

    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Me.Dispose()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataGridCUST.DataSource = CUSTOMERList()
        For Each dgvRow As DataGridViewRow In DataGridCUST.Rows
            If dgvRow.Cells("STATUS").Value <> "ACTIVE" Then
                dgvRow.DefaultCellStyle.ForeColor = Color.Red
            End If
        Next
        CLEAR_TXT()
    End Sub


    Private Sub BTN_ADD_USR_Click(sender As Object, e As EventArgs) Handles BTN_CUS_ADD.Click
        ADD_CUSTOMER()
        DataGridCUST.DataSource = CUSTOMERList()
    End Sub

    Private Sub BTN_CUS_UPDT_Click_1(sender As Object, e As EventArgs) Handles BTN_CUS_UPDT.Click
        UPDT_CUSTOMER()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        CLEAR_TXT()
    End Sub
    Private Sub btn_add_Dsabl()
        BTN_CUS_ADD.Enabled = False
        BTN_CUS_ADD.BackColor = Color.WhiteSmoke
        BTN_CUS_ADD.FlatAppearance.BorderColor = Color.WhiteSmoke
    End Sub
    Private Sub btn_add_enl()
        BTN_CUS_ADD.Enabled = True
        BTN_CUS_ADD.BackColor = Color.White
        BTN_CUS_ADD.FlatAppearance.BorderColor = Color.Gray
    End Sub
    Private Sub btn_updt_Dsabl()
        BTN_CUS_UPDT.Enabled = False
        BTN_CUS_UPDT.BackColor = Color.WhiteSmoke
        BTN_CUS_UPDT.FlatAppearance.BorderColor = Color.WhiteSmoke
    End Sub
    Private Sub btn_updt_enl()
        BTN_CUS_UPDT.Enabled = True
        BTN_CUS_UPDT.BackColor = Color.White
        BTN_CUS_UPDT.FlatAppearance.BorderColor = Color.Gray
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBX_TIN.KeyPress
        If e.KeyChar = "."c Then
            e.Handled = (CType(sender, TextBox).Text.IndexOf("."c) <> -1)
        ElseIf e.KeyChar <> ControlChars.Back Then
            e.Handled = ("0123456789".IndexOf(e.KeyChar) = -1)
        End If

        If TBX_TIN.Text.Length < 12 And (TBX_TIN.Text.Length + 1) Mod 4 = 0 And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            TBX_TIN.Text = TBX_TIN.Text.Insert(TBX_TIN.Text.Length, "-" & e.KeyChar)
            TBX_TIN.SelectionStart = TBX_TIN.Text.Length
        ElseIf TBX_TIN.Text.Length >= 17 And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TBX_C_CON_NUM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBX_C_CON_NUM.KeyPress
        If e.KeyChar = "."c Then
            e.Handled = (CType(sender, TextBox).Text.IndexOf("."c) <> -1)
        ElseIf e.KeyChar <> ControlChars.Back Then
            e.Handled = ("0123456789".IndexOf(e.KeyChar) = -1)
        End If

        If TBX_C_CON_NUM.Text.Length >= 11 And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            CheckBox1.Text = "ACTIVE"
            CheckBox1.ForeColor = Color.Green
        Else
            CheckBox1.Text = "INACTIVE"
            CheckBox1.ForeColor = Color.Red
        End If
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        addDepartment.Show()
    End Sub

    Private Sub ToolStripR_RECNUM_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStripR_RECNUM.ItemClicked

    End Sub

    Private Sub addcustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridCUST.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Regular)

    End Sub

    Private Sub TBX_COMP_NAME_TextChanged(sender As Object, e As EventArgs) Handles TBX_COMP_NAME.TextChanged, TBX_C_NAME.TextChanged, TBX_C_ADD.TextChanged

        If TBX_CCODE.Text <> "" AndAlso TBX_C_ADD.Text <> "" AndAlso TBX_C_NAME.Text <> "" AndAlso TBX_COMP_NAME.Text <> "" AndAlso tr = 0 Then
            btn_add_enl()
        Else
            btn_add_Dsabl()
        End If

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub TBX_PU_INDEX_Leave(sender As Object, e As EventArgs) Handles TBX_PU_INDEX.Leave
        Dim sqlCon_C = New SqlConnection(connstring)
        Try
            Dim cmd As New SqlCommand("select COUNT(PU_INDEX) AS CNT from tbl_customer WHERE PU_INDEX='" & TBX_PU_INDEX.Text & "'", sqlCon_C)
            If (sqlCon_C.State <> ConnectionState.Open) Then
                sqlCon_C.Open()
            End If
            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            sdr.Read()
            If sdr("CNT") > 0 Then
                MessageBox.Show("Already assigned to another customer. Please assign different value.")
                TBX_PU_INDEX.Select()
            End If
            sdr.Close()
            sqlCon_C.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class