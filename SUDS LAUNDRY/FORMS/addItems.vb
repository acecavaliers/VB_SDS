Imports System.Data.SqlClient
Imports System.Configuration

Public Class AddItems
    Public connstring As String = ConfigurationManager.ConnectionStrings("SUDS_ConnectionString").ConnectionString
    Dim CCODE As String
    Dim FNB As String
    Dim ITMSRC_itm As String
    Dim ITMSRC_Cus As String
    'Dim off_set As Integer = 0
    Dim itms_statCode As String
    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Me.Dispose()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Public Function SrC_ServiceType() As DataTable
        Dim dt_items As New DataTable
        Using conn As New SqlConnection(connstring)
            Using cmd As New SqlCommand("SELECT * FROM tbl_services WHERE service_status='ACTIVE' AND CCODE like'%" & CBX_I_COM.SelectedValue & "%'ORDER BY SERVICE_TYPE", conn)
                conn.Open()
                Dim RDR As SqlDataReader = cmd.ExecuteReader()
                dt_items.Load(RDR)
            End Using
        End Using
        Return dt_items
    End Function
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
    Public Sub ADD_ITEM()
        Try
            Dim sqlCon = New SqlConnection(connstring)
            Using (sqlCon)
                Dim sqlComm As New SqlCommand With {
                    .Connection = sqlCon,
                    .CommandText = "AddItem",
                    .CommandType = CommandType.StoredProcedure
                }

                sqlComm.Parameters.AddWithValue("@ITEMCODE", TBX_CCODE.Text)
                sqlComm.Parameters.AddWithValue("@CCODE", CBX_I_COM.SelectedValue)
                sqlComm.Parameters.AddWithValue("@SCODE", TBX_SERVICE.Text)
                sqlComm.Parameters.AddWithValue("@NAME", TBX_NAME.Text)
                sqlComm.Parameters.AddWithValue("@FNB", FNB)
                sqlComm.Parameters.AddWithValue("@WEIGHT", Double.Parse(TBX_WP.Text))

                sqlCon.Open()
                If sqlComm.ExecuteNonQuery() = 1 Then

                End If
                sqlCon.Close()
                MessageBox.Show("New item successfully added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                finder()
                CLEAR_TXT()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub UPDT_ITEM()
        Try
            Dim sqlCon = New SqlConnection(connstring)
            Using (sqlCon)
                Dim sqlComm As New SqlCommand With {
                    .Connection = sqlCon,
                    .CommandText = "UpdtItem",
                    .CommandType = CommandType.StoredProcedure
                }
                sqlComm.Parameters.AddWithValue("@ITEMCODE", TBX_CCODE.Text)
                sqlComm.Parameters.AddWithValue("@NAME", TBX_NAME.Text)
                sqlComm.Parameters.AddWithValue("@SCODE", TBX_SERVICE.Text)
                sqlComm.Parameters.AddWithValue("@FNB", FNB)
                sqlComm.Parameters.AddWithValue("@WEIGHT", Double.Parse(TBX_WP.Text))

                sqlCon.Open()
                If sqlComm.ExecuteNonQuery() = 1 Then

                End If
                sqlCon.Close()
                MessageBox.Show("Record successfully updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DataGridITMS.DataSource = Nothing
                finder()

                CLEAR_TXT()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub CLEAR_TXT()
        TBX_CCODE.Text = Nothing
        TBX_NAME.Text = Nothing
        TBX_WP.Text = Nothing
        TBX_SERVICE.Text = Nothing
        CBX_I_COM.SelectedIndex = -1
        BTN_CUS_ADD.Enabled = False
        BTN_CUS_UPDT.Enabled = False
    End Sub

    Private Sub AddItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DataGridITMS.ReadOnly = True
        CBX_I_COM.DataSource = SrC_CSTMER()
        CBX_I_COM.ValueMember = "CUSTOMER_CODE"
        CBX_I_COM.DisplayMember = "NAME"
        CBX_I_COM.SelectedIndex = -1

        ComboBox1.DataSource = SrC_CSTMER()
        ComboBox1.ValueMember = "CUSTOMER_CODE"
        ComboBox1.DisplayMember = "NAME"
        ComboBox1.SelectedIndex = -1


        If CheckBox1.Checked = True Then
            CheckBox1.ForeColor = Color.Green
            FNB = "Y"
        Else
            CheckBox1.ForeColor = Color.Black
            FNB = "N"
        End If
    End Sub

    Private Sub DataGridView1_ColumnAdded(sender As Object, e As DataGridViewColumnEventArgs) Handles DataGridITMS.ColumnAdded
        e.Column.SortMode = DataGridViewColumnSortMode.NotSortable
    End Sub
    Public Sub ITEM_CODE()
        Dim sqlCon_C = New SqlConnection(connstring)
        Try
            Dim cmd As New SqlCommand("SELECT RIGHT('000' + CAST(COUNT(NAME)+1 AS varchar(3)) , 3) AS CNT FROM tbl_item WHERE C_CODE='" & CBX_I_COM.SelectedValue & "'", sqlCon_C)
            If (sqlCon_C.State <> ConnectionState.Open) Then
                sqlCon_C.Open()
            End If
            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            sdr.Read()
            TBX_CCODE.Text = CBX_I_COM.SelectedValue & sdr("CNT")
            sdr.Close()
            sqlCon_C.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Function MASTERITEMList() As DataTable
        Dim dt_items As New DataTable
        'Dim ccode As String
        If CBX_I_COM.SelectedIndex > -1 Then
            ccode = CBX_I_COM.SelectedValue
        Else
            ccode = ""
        End If
        Using conn As New SqlConnection(connstring)
            Using cmd As New SqlCommand("SELECT ITEMCODE,T0.NAME AS 'ITEM DESC',WEIGHT,FNB, T1.NAME AS 'CUSTOMER NAME',itm_stat 
                                            FROM tbl_item T0 INNER JOIN tbl_customer T1 ON T0.C_CODE=T1.CUSTOMER_CODE 
                                            WHERE T0.NAME LIKE '%" & ITMSRC_itm & "%' AND T1.NAME LIKE '%" & ITMSRC_Cus & "%' ORDER BY C_CODE asc,ITEMCODE asc ,itm_stat desc ", conn)
                conn.Open()
                Dim RDR As SqlDataReader = cmd.ExecuteReader()
                dt_items.Load(RDR)
            End Using
        End Using
        Return dt_items

    End Function


    Private Sub CBX_I_COM_Leave(sender As Object, e As EventArgs) Handles CBX_I_COM.Leave
        ITEM_CODE()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ITMSRC_itm = ""
        finder()
    End Sub
    Public Sub Finder()
        DataGridITMS.DataSource = MASTERITEMList()
        Dim totalWidth As Integer = DataGridITMS.Width
        Dim c0 As Double = 0.1 ' 10%
        Dim c1 As Double = 0.3 ' 30%
        Dim c2 As Double = 0.1 ' 10%
        Dim c3 As Double = 0.1 ' 10%
        Dim c4 As Double = 0.3 ' 30%
        'Dim c5 As Double = 0.1 ' 10%

        Dim c0w As Integer = CInt(totalWidth * c0)
        Dim c1w As Integer = CInt(totalWidth * c1)
        Dim c2w As Integer = CInt(totalWidth * c2)
        Dim c3w As Integer = CInt(totalWidth * c3)
        Dim c4w As Integer = CInt(totalWidth * c4)
        'Dim c5w As Integer = CInt(totalWidth * c5)

        DataGridITMS.Columns(0).Width = c0w
        DataGridITMS.Columns(1).Width = c1w
        DataGridITMS.Columns(2).Width = c2w
        DataGridITMS.Columns(3).Width = c3w
        DataGridITMS.Columns(4).Width = c4w
        DataGridITMS.Columns(5).Visible = False

    End Sub
    Public Function CHECK_ITM() As Integer
        Dim sqlCon_C As New SqlConnection(connstring)
        Dim count As Integer = 0

        Try
            Dim cmd As New SqlCommand("SELECT COUNT(NAME) AS CNT FROM tbl_item WHERE C_CODE='" & CCODE & "' AND NAME='" & TBX_NAME.Text & "'", sqlCon_C)

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


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles BTN_CUS_ADD.Click
        CCODE = CBX_I_COM.SelectedValue.ToString
        Dim result As Integer = CHECK_ITM()
        If result = 0 Then
            ADD_ITEM()
        Else
            MessageBox.Show("Item '" & TBX_NAME.Text & "' already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TBX_NAME.Select()
        End If

    End Sub
    Public Sub Add_enbl()
        If TBX_CCODE.Text <> "" AndAlso TBX_NAME.Text <> "" AndAlso TBX_WP.Text <> "" AndAlso CBX_I_COM.Enabled <> False AndAlso TBX_SERVICE.Text <> "" AndAlso CBX_I_COM.Text <> "" Then
            BTN_CUS_ADD.Enabled = True
        Else
            BTN_CUS_ADD.Enabled = False
        End If
    End Sub

    Private Sub DataGridITMS_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridITMS.CellMouseDoubleClick
        Dim i As Integer
        With DataGridITMS
            If e.RowIndex >= 0 Then
                i = .CurrentRow.Index
                TBX_NAME.Text = .Rows(i).Cells("ITEM DESC").Value.ToString
                TBX_WP.Text = .Rows(i).Cells("WEIGHT").Value.ToString
                TBX_CCODE.Text = .Rows(i).Cells("ITEMCODE").Value.ToString
                CBX_I_COM.Text = .Rows(i).Cells("CUSTOMER NAME").Value.ToString
                'TBX_SERVICE.Text = .Rows(i).Cells("scode").Value.ToString
                If .Rows(i).Cells("FNB").Value = "Y" Then
                    CheckBox1.Checked = True
                Else
                    CheckBox1.Checked = False
                End If
                BTN_CUS_UPDT.Enabled = True
                CBX_I_COM.Enabled = False
                BTN_CUS_ADD.Enabled = False
            End If
        End With
    End Sub

    Private Sub BTN_CUS_UPDT_Click_1(sender As Object, e As EventArgs) Handles BTN_CUS_UPDT.Click
        UPDT_ITEM()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        CBX_I_COM.Text = Nothing
        TBX_SERVICE.Text = Nothing
        CBX_I_COM.Enabled = True
        CLEAR_TXT()
    End Sub


    Private Sub CBX_I_COM_Enter(sender As Object, e As EventArgs) Handles CBX_I_COM.Enter
        CBX_I_COM.DataSource = SrC_CSTMER()
        CBX_I_COM.ValueMember = "CUSTOMER_CODE"
        CBX_I_COM.DisplayMember = "NAME"
        CBX_I_COM.SelectedIndex = -1
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            CheckBox1.ForeColor = Color.Green
            FNB = "Y"
        Else
            CheckBox1.ForeColor = Color.Black
            FNB = "N"
        End If
    End Sub

    Private Sub TBX_WP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBX_WP.KeyPress
        If e.KeyChar = "."c Then
            e.Handled = (CType(sender, TextBox).Text.IndexOf("."c) <> -1)
        ElseIf e.KeyChar <> ControlChars.Back Then
            e.Handled = ("0123456789".IndexOf(e.KeyChar) = -1)
        End If
    End Sub

    Private Sub TBX_SERVICE_Enter(sender As Object, e As EventArgs) Handles TBX_SERVICE.Enter, TBX_SERVICE.Click
        If CBX_I_COM.Text <> "" Then
            SERVICES.stype = 1
            SERVICES.ShowDialog()
        End If

    End Sub

    Private Sub TBX_SERVICE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBX_SERVICE.KeyPress
        If Asc(e.KeyChar) = Keys.Back Then
            ' Allow the backspace keypress to be processed
        Else
            ' Set the Handled property to true to prevent the keypress from being processed
            e.Handled = True
        End If
    End Sub

    Private Sub CBX_I_COM_TextChanged(sender As Object, e As EventArgs) Handles TBX_WP.TextChanged, TBX_SERVICE.TextChanged, TBX_NAME.TextChanged, CBX_I_COM.TextChanged
        add_enbl()
    End Sub

    Private Sub TBX_SRC_TextChanged(sender As Object, e As EventArgs) Handles TBX_SRC.TextChanged
        If TBX_SRC.Text <> "" Then
            ITMSRC_itm = TBX_SRC.Text
            finder()
        End If
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        PrintMasteList.ShowDialog()
    End Sub

    Private Sub ComboBox1_TextChanged(sender As Object, e As EventArgs) Handles ComboBox1.TextChanged
        ITMSRC_itm = ""
        ITMSRC_Cus = ComboBox1.Text
        finder()
    End Sub

    Private Sub DataGridITMS_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridITMS.CellMouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            DataGridITMS.ClearSelection()
            DataGridITMS.Rows(e.RowIndex).Selected = True
            itms_statCode = DataGridITMS.Rows(e.RowIndex).Cells(0).Value
            If DataGridITMS.Rows(e.RowIndex).Cells(5).Value = 0 Then
                ActiveToolStripMenuItem1.Enabled = True
                InActiveToolStripMenuItem1.Enabled = False
            Else
                ActiveToolStripMenuItem1.Enabled = False
                InActiveToolStripMenuItem1.Enabled = True
            End If
            ContextMenuStrip1.Show(DataGridITMS, e.Location)
            ContextMenuStrip1.Show(Cursor.Position)
        End If
    End Sub

    Private Sub SetActiveToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ActiveToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ActiveToolStripMenuItem1.Click
        'MessageBox.Show(itms_statCode)
        Try
            Dim conn1 As New SqlConnection(connstring)
            Using command33 As New SqlCommand
                command33.CommandText = "update tbl_item set itm_stat=1 WHERE ITEMCODE='" & itms_statCode & "'"
                conn1.Open()
                command33.Connection = conn1
                command33.ExecuteNonQuery()
                Dim sdrr As SqlDataReader = command33.ExecuteReader()
                sdrr.Close()
            End Using
            conn1.Close()
            MessageBox.Show("Item Status set to 'ACTIVE'")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Button1.PerformClick()
    End Sub

    Private Sub InActiveToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles InActiveToolStripMenuItem1.Click
        'MessageBox.Show(itms_statCode)
        Try
            Dim conn1 As New SqlConnection(connstring)
            Using command33 As New SqlCommand
                command33.CommandText = "update tbl_item set itm_stat=0 WHERE ITEMCODE='" & itms_statCode & "'"
                conn1.Open()
                command33.Connection = conn1
                command33.ExecuteNonQuery()
                Dim sdrr As SqlDataReader = command33.ExecuteReader()
                sdrr.Close()
            End Using
            conn1.Close()
            MessageBox.Show("Item Status set to 'In-ACTIVE'")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Button1.PerformClick()
    End Sub

    Private Sub DataGridITMS_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridITMS.RowsAdded
        Try
            For Each dgvRow As DataGridViewRow In DataGridITMS.Rows
                If dgvRow.Cells(5).Value = 0 Then
                    dgvRow.DefaultCellStyle.ForeColor = Color.Red
                Else
                    dgvRow.DefaultCellStyle.ForeColor = Color.Black
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
End Class