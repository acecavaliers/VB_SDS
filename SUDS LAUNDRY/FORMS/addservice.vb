Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Data.OleDb
Public Class Addservice
    Public connstring As String = ConfigurationManager.ConnectionStrings("SUDS_ConnectionString").ConnectionString
    'Dim STATUS As String
    'Dim ID As String
    Dim tr As Integer
    Public CCODE As String
    Private Sub ToolStripButton7_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Me.Dispose()
    End Sub
    Public Function SrC_CSTMER() As DataTable
        Dim dt_items As New DataTable
        Using conn As New SqlConnection(connstring)
            Using cmd As New SqlCommand("SELECT *  FROM tbl_customer  ORDER BY NAME", conn)
                conn.Open()
                Dim RDR As SqlDataReader = cmd.ExecuteReader()
                dt_items.Load(RDR)
            End Using
        End Using
        Return dt_items
    End Function
    Public Sub Customer_id()
        Dim sqlCon_C = New SqlConnection(connstring)
        Try
            Dim cmd As New SqlCommand("SELECT RIGHT('000' + CAST(max(service_code)+1 AS varchar(3)) , 3)AS id FROM tbl_services", sqlCon_C)
            If (sqlCon_C.State <> ConnectionState.Open) Then
                sqlCon_C.Open()
            End If
            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            sdr.Read()
            CCODE = sdr("id")
            sdr.Close()
            sqlCon_C.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Addservice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CBX_I_COM.DataSource = SrC_CSTMER()
        CBX_I_COM.ValueMember = "CUSTOMER_CODE"
        CBX_I_COM.DisplayMember = "NAME"
        CBX_I_COM.SelectedIndex = -1
        Dim headerStyle As New DataGridViewCellStyle With {
            .Font = New Font("Segoe UI", 10, FontStyle.Regular)
        }
        DataGridSRVC.ColumnHeadersDefaultCellStyle = headerStyle

    End Sub

    Private Sub Btn_add_Dsabl()
        BTN_SRVS_ADD.Enabled = False
        BTN_SRVS_ADD.BackColor = Color.WhiteSmoke
        BTN_SRVS_ADD.FlatAppearance.BorderColor = Color.WhiteSmoke
    End Sub
    Private Sub Btn_add_enl()
        BTN_SRVS_ADD.Enabled = True
        BTN_SRVS_ADD.BackColor = Color.White
        BTN_SRVS_ADD.FlatAppearance.BorderColor = Color.Gray
    End Sub
    Private Sub Btn_updt_Dsabl()
        BTN_SRVC_UPDT.Enabled = False
        BTN_SRVC_UPDT.BackColor = Color.WhiteSmoke
        BTN_SRVC_UPDT.FlatAppearance.BorderColor = Color.WhiteSmoke
    End Sub
    Private Sub Btn_updt_enl()
        BTN_SRVC_UPDT.Enabled = True
        BTN_SRVC_UPDT.BackColor = Color.White
        BTN_SRVC_UPDT.FlatAppearance.BorderColor = Color.Gray
    End Sub
    Public Sub CLEAR_TXT()
        TBX_CCODE.Text = Nothing
        TBX_SRVC_TYPE.Text = Nothing
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
        CheckBox1.Checked = True
        CheckBox1.Enabled = False
        CBX_I_COM.Text = Nothing
        CBX_I_COM.Enabled = True
        tr = 0
        Btn_add_Dsabl()
        Btn_updt_Dsabl()
    End Sub
    Public Function CHECK_CNT() As Integer
        Dim sqlCon_C As New SqlConnection(connstring)
        Dim count As Integer = 0
        Dim ccode As String = CBX_I_COM.SelectedValue.ToString
        Dim service_type As String = TBX_SRVC_TYPE.Text

        Try
            Dim cmd As New SqlCommand("SELECT COUNT(service_type) AS CNT FROM tbl_services WHERE CCODE='" & ccode & "' AND service_type='" & service_type & "'", sqlCon_C)

            If sqlCon_C.State <> ConnectionState.Open Then
                sqlCon_C.Open()
            End If

            Dim sdr As SqlDataReader = cmd.ExecuteReader()

            If sdr.Read() Then
                ' Check if the result contains the "CNT" column and is not null
                If Not sdr.IsDBNull(sdr.GetOrdinal("CNT")) Then
                    count = sdr.GetInt32(sdr.GetOrdinal("CNT"))
                End If
            End If

            sdr.Close()
            sqlCon_C.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return count
    End Function
    Private Sub BTN_SRVS_ADD_Click(sender As Object, e As EventArgs) Handles BTN_SRVS_ADD.Click

        Dim result As Integer = CHECK_CNT()
        If result = 0 Then
            ADD_SRVCS()
        Else
            MessageBox.Show("Item '" & TBX_SRVC_TYPE.Text & "' already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TBX_SRVC_TYPE.Select()
        End If

    End Sub
    Public Sub ADD_SRVCS()
        Try
            Dim sqlCon = New SqlConnection(connstring)

            Dim command2 As New Data.SqlClient.SqlCommand
            sqlCon.Open()
            command2.CommandText = "INSERT INTO tbl_services(service_code,service_type,service_price,service_status,CCODE,service_price_fnb) 
                                    VALUES(@srvc_code,@SRVC_type,@SRVC_PRICE,@SRVC_STATUS,@CCODE,@SRVC_PRICE_FNB)"
            command2.Parameters.Add("@srvc_code", SqlDbType.VarChar).Value = TBX_CCODE.Text
            command2.Parameters.Add("@SRVC_type", SqlDbType.VarChar).Value = TBX_SRVC_TYPE.Text
            command2.Parameters.Add("@SRVC_PRICE", SqlDbType.Decimal).Value = Double.Parse(TextBox1.Text)
            command2.Parameters.Add("@SRVC_PRICE_FNB", SqlDbType.Decimal).Value = Double.Parse(TextBox2.Text)
            command2.Parameters.Add("@CCODE", SqlDbType.VarChar).Value = CBX_I_COM.SelectedValue
            command2.Parameters.Add("@SRVC_STATUS", SqlDbType.VarChar).Value = "ACTIVE"
            command2.Connection = sqlCon
            command2.ExecuteNonQuery()
            sqlCon.Close()
            MessageBox.Show("Service: " & TBX_SRVC_TYPE.Text & " successfully added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CLEAR_TXT()
            Button1.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub UPDT_STVC()
        Try
            Dim sqlCon = New SqlConnection(connstring)
            Using (sqlCon)
                Dim sqlComm As New SqlCommand With {
                    .Connection = sqlCon,
                    .CommandText = "Updt_Srvc",
                    .CommandType = CommandType.StoredProcedure
                }

                sqlComm.Parameters.AddWithValue("@SCODE", TBX_CCODE.Text)
                sqlComm.Parameters.AddWithValue("@STYPE", TBX_SRVC_TYPE.Text)
                sqlComm.Parameters.AddWithValue("@SSTATUS", CheckBox1.Text)
                sqlComm.Parameters.AddWithValue("@SPRICE", Double.Parse(TextBox1.Text))
                sqlComm.Parameters.AddWithValue("@FNB_PRICE", Double.Parse(TextBox2.Text))
                sqlCon.Open()
                Dim RowsAffected As Integer = sqlComm.ExecuteNonQuery()
                If RowsAffected > 0 Then
                End If
                sqlCon.Close()
            End Using
            MessageBox.Show("Service Type: " & TBX_SRVC_TYPE.Text & " successfully updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CLEAR_TXT()
            Button1.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BTN_CUS_UPDT_Click(sender As Object, e As EventArgs) Handles BTN_SRVC_UPDT.Click
        UPDT_STVC()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataGridSRVC.DataSource = SrvcList()
        For ttl As Integer = 1 To 7
            DataGridSRVC.Columns(ttl).ReadOnly = True
        Next
        DataGridSRVC.Columns(" ").Visible = False
        'DataGridSRVC.Columns(" ").Width = 5
        DataGridSRVC.Columns("Service Code").Width = 20
        DataGridSRVC.Columns("Service Type").Width = 80
        DataGridSRVC.Columns("REG. Price").Width = 20
        DataGridSRVC.Columns("FNB Price").Width = 20
        DataGridSRVC.Columns("Status").Width = 20
        DataGridSRVC.Columns("CCODE").Width = 20
        DataGridSRVC.Columns("CUSTOMER").Width = 100
        For Each dgvRow As DataGridViewRow In DataGridSRVC.Rows
            If dgvRow.Cells("STATUS").Value <> "ACTIVE" Then
                dgvRow.DefaultCellStyle.ForeColor = Color.Red
                dgvRow.Cells(" ").Value = "FALSE"
            Else
                dgvRow.Cells(" ").Value = "TRUE"
            End If
        Next
    End Sub
    Private Function SrvcList() As DataTable
        Dim dt_items As New DataTable
        dt_items.Columns.Add(" ", GetType(Boolean))
        Using conn As New SqlConnection(connstring)
            Using cmd As New SqlCommand("SELECT service_code AS 'Service Code',service_type as 'Service Type',service_price AS 'REG. Price',service_price_fnb AS 'FNB Price', service_status as'Status',CCODE,NAME AS 'CUSTOMER' FROM tbl_services T0
                                        INNER JOIN TBL_CUSTOMER T1 ON T0.CCODE=T1.CUSTOMER_CODE
                                        WHERE service_code<>'000'ORDER BY CCODE,service_type ", conn)
                conn.Open()
                Dim RDR As SqlDataReader = cmd.ExecuteReader()
                dt_items.Load(RDR)
            End Using
        End Using
        Return dt_items
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CLEAR_TXT()
        DataGridSRVC.ClearSelection()
        Me.ActiveControl = Nothing
    End Sub

    Private Sub TBX_SRVC_TYPE_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged, TBX_SRVC_TYPE.TextChanged
        If TBX_SRVC_TYPE.Text <> "" AndAlso TextBox1.Text <> "" AndAlso tr = 0 Then
            Btn_add_enl()
        Else
            Btn_add_Dsabl()
        End If
    End Sub

    Private Sub TBX_SRVC_TYPE_Leave(sender As Object, e As EventArgs) Handles TBX_SRVC_TYPE.Leave
        If tr = 0 Then
            Customer_id()
            TBX_CCODE.Text = CCODE.ToString
        End If
    End Sub

    Private Sub DataGridSRVC_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridSRVC.CellMouseDoubleClick
        Dim i As Integer
        With DataGridSRVC
            If e.RowIndex >= 0 Then
                i = .CurrentRow.Index
                tr = 1
                CBX_I_COM.Enabled = False
                TBX_CCODE.Text = .Rows(i).Cells("Service Code").Value.ToString
                TBX_SRVC_TYPE.Text = .Rows(i).Cells("Service Type").Value.ToString
                TextBox1.Text = .Rows(i).Cells("REG. Price").Value.ToString
                TextBox2.Text = .Rows(i).Cells("FNB Price").Value.ToString
                CBX_I_COM.Text = .Rows(i).Cells("CUSTOMER").Value.ToString
                If .Rows(i).Cells("STATUS").Value.ToString = "ACTIVE" Then
                    CheckBox1.Checked = True
                Else
                    CheckBox1.Checked = False
                End If

                Btn_updt_enl()
                CheckBox1.Enabled = True
            End If
        End With
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

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class