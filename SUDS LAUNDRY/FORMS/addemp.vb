Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Data.OleDb
Public Class addemp
    Public connstring As String = ConfigurationManager.ConnectionStrings("SUDS_ConnectionString").ConnectionString
    Public Usertype As String
    Dim STATUS As String
    Dim ID As String
    Dim UNAME As String
    Public CCODE As String
    Dim FM_EMP = "N", FM_CST = "N", FM_ITMS = "N", FM_SVRC = "N", TR_REC = "N", TR_DLVR = "N", RPT_DT = "N", RPT_SOA = "N", UT_USR = "N", UT_BACKUP = "N", UT_RESTORE = "N"

    Private Sub Addemp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()

        If Main.USER_TYPE <> "Superuser" Then
            CBX_USERTYPE.SelectedIndex = 0
            CBX_USERTYPE.Enabled = False
            For Each cc As Control In Me.Controls
                If TypeOf cc Is CheckBox Then
                    DirectCast(cc, CheckBox).Enabled = False
                End If
            Next
        Else
            CBX_USERTYPE.SelectedIndex = -1
            CBX_USERTYPE.Enabled = True
        End If

    End Sub
    Public Sub align()
        DataGridView1.Columns(" ").Width = 10
        DataGridView1.Columns("ID").Width = 20
        DataGridView1.Columns("NAME").Width = 100
        DataGridView1.Columns("ROLE").Width = 40
        DataGridView1.Columns("USERTYPE").Width = 40
    End Sub

    Private Sub ButtonAddUser_Click(sender As Object, e As EventArgs) Handles BTN_ADD_USR.Click

        ADD_USER()

    End Sub
    Private Sub ButtonUpdtUser_Click(sender As Object, e As EventArgs) Handles BTN_USR_UPDT.Click
        STATUS = CheckBox1.Text
        UpdtUsser()

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim columnCount As Integer = DataGridView1.Columns.Count

        DataGridView1.DataSource = SrcList()
        DataGridView1.Columns(" ").ReadOnly = False
        If columnCount = 0 Then
            align()
        End If
        For ttl As Integer = 1 To 18
            DataGridView1.Columns(ttl).ReadOnly = True
        Next
        For ttl As Integer = 6 To 18
            DataGridView1.Columns(ttl).Visible = False
        Next
        DataGridView1.Columns(0).Visible = False
        For Each dgvRow As DataGridViewRow In DataGridView1.Rows
            If dgvRow.Cells("STATUS").Value <> "ACTIVE" Then
                dgvRow.DefaultCellStyle.ForeColor = Color.Red
            End If
        Next
    End Sub
    Public Sub CLEAR_TXT()
        DataGridView1.ClearSelection()
        TBX_NAME.Text = Nothing
        TBX_U_PASS.Text = Nothing
        CBX_ROLE.Text = Nothing
        If Main.USER_TYPE <> "Superuser" Then
            CBX_USERTYPE.SelectedIndex = 0
            CBX_USERTYPE.Enabled = False
        Else
            CBX_USERTYPE.SelectedIndex = -1
            CBX_USERTYPE.Enabled = True
        End If
        For Each cc As Control In Me.Controls
            If TypeOf cc Is CheckBox Then
                DirectCast(cc, CheckBox).Checked = False
            End If
        Next
        CheckBox1.Checked = True
        BTN_USR_UPDT.Enabled = False
        BTN_USR_UPDT.FlatAppearance.BorderColor = Color.WhiteSmoke
        BTN_USR_UPDT.BackColor = Color.WhiteSmoke

    End Sub
    Public Sub ADD_USER()
        Try
            Dim sqlCon = New SqlConnection(connstring)
            Using (sqlCon)
                Dim sqlComm As New SqlCommand With {
                    .Connection = sqlCon,
                    .CommandText = "AddUser",
                    .CommandType = CommandType.StoredProcedure
                }
                sqlComm.Parameters.AddWithValue("@NAME", TBX_NAME.Text)
                sqlComm.Parameters.AddWithValue("@ROLE", CBX_ROLE.Text)
                sqlComm.Parameters.AddWithValue("@USERTYPE", CBX_USERTYPE.Text)
                sqlComm.Parameters.AddWithValue("@PW", TBX_U_PASS.Text)
                sqlComm.Parameters.AddWithValue("@STATUS", "ACTIVE")
                sqlComm.Parameters.AddWithValue("@FM_EMP", FM_EMP)
                sqlComm.Parameters.AddWithValue("@FM_CST", FM_CST)
                sqlComm.Parameters.AddWithValue("@FM_ITM", FM_SVRC)
                sqlComm.Parameters.AddWithValue("@FM_SVRC", FM_ITMS)
                sqlComm.Parameters.AddWithValue("@TR_REC", TR_REC)
                sqlComm.Parameters.AddWithValue("@TR_DLVR", TR_DLVR)

                sqlComm.Parameters.AddWithValue("@RPT_DT", RPT_DT)
                sqlComm.Parameters.AddWithValue("@RPT_SOA", RPT_SOA)

                sqlComm.Parameters.AddWithValue("@UT_USR", UT_USR)
                sqlComm.Parameters.AddWithValue("@UT_BACKUP", UT_BACKUP)
                sqlComm.Parameters.AddWithValue("@UT_RESTORE", UT_RESTORE)
                sqlCon.Open()
                If sqlComm.ExecuteNonQuery() = 1 Then
                    MessageBox.Show("Data successfuly addded")
                    Button1.PerformClick()
                    CLEAR_TXT()
                Else
                    MessageBox.Show("Error something went wrong!")
                End If
                sqlCon.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub UpdtUsser()
        Try
            Dim sqlCon = New SqlConnection(connstring)
            Using (sqlCon)
                Dim sqlComm As New SqlCommand With {
                    .Connection = sqlCon,
                    .CommandText = "UpdtUsser",
                    .CommandType = CommandType.StoredProcedure
                }
                sqlComm.Parameters.AddWithValue("@ID", ID)
                sqlComm.Parameters.AddWithValue("@NAME", TBX_NAME.Text)
                sqlComm.Parameters.AddWithValue("@ROLE", CBX_ROLE.Text)
                sqlComm.Parameters.AddWithValue("@USERTYPE", CBX_USERTYPE.Text)
                sqlComm.Parameters.AddWithValue("@STATUS", STATUS)
                sqlComm.Parameters.AddWithValue("@PW", TBX_U_PASS.Text)
                sqlComm.Parameters.AddWithValue("@UNAME", UNAME)
                sqlComm.Parameters.AddWithValue("@FM_EMP", FM_EMP)
                sqlComm.Parameters.AddWithValue("@FM_CST", FM_CST)
                sqlComm.Parameters.AddWithValue("@FM_ITM", FM_ITMS)

                sqlComm.Parameters.AddWithValue("@FM_SVRC", FM_ITMS)
                sqlComm.Parameters.AddWithValue("@TR_REC", TR_REC)
                sqlComm.Parameters.AddWithValue("@TR_DLVR", TR_DLVR)
                sqlComm.Parameters.AddWithValue("@RPT_DT", RPT_DT)
                sqlComm.Parameters.AddWithValue("@RPT_SOA", RPT_SOA)
                sqlComm.Parameters.AddWithValue("@UT_USR", UT_USR)
                sqlComm.Parameters.AddWithValue("@UT_BACKUP", UT_BACKUP)
                sqlComm.Parameters.AddWithValue("@UT_RESTORE", UT_RESTORE)
                sqlCon.Open()
                If sqlComm.ExecuteNonQuery() = 1 Then
                    MessageBox.Show("Data successfuly updated!")
                    Button1.PerformClick()
                    BTN_USR_UPDT.Enabled = False
                    CLEAR_TXT()
                Else
                    MessageBox.Show("Update Error!")
                End If
                sqlCon.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub CHK_FM_EMP_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_FM_EMP.CheckedChanged
        If CHK_FM_EMP.Checked = True Then
            FM_EMP = "Y"
        Else
            FM_EMP = "N"
        End If
    End Sub
    Private Sub CHK_FM_ITM_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_FM_ITM.CheckedChanged
        If CHK_FM_ITM.Checked = True Then
            FM_ITMS = "Y"
        Else
            FM_ITMS = "N"
        End If
    End Sub

    Private Sub CHK_TR_REC_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_TR_REC.CheckedChanged
        If CHK_TR_REC.Checked = True Then
            TR_REC = "Y"
        Else
            TR_REC = "N"
        End If
    End Sub

    Private Sub CHK_TR_DLVR_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_TR_DLVR.CheckedChanged
        If CHK_TR_DLVR.Checked = True Then
            TR_DLVR = "Y"
        Else
            TR_DLVR = "N"
        End If
    End Sub

    Private Sub CHK_UT_USER_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_UT_USER.CheckedChanged
        If CHK_UT_USER.Checked = True Then
            UT_USR = "Y"
        Else
            UT_USR = "N"
        End If
    End Sub
    Private Sub CHK_UT_BACKUP_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_UT_BACKUP.CheckedChanged
        If CHK_UT_BACKUP.Checked = True Then
            UT_BACKUP = "Y"
        Else
            UT_BACKUP = "N"
        End If
    End Sub
    Private Sub CHK_UT_RESTORE_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_UT_RESTORE.CheckedChanged
        If CHK_UT_RESTORE.Checked = True Then
            UT_RESTORE = "Y"
        Else
            UT_RESTORE = "N"
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

    Private Sub TBX_NAME_Leave_1(sender As Object, e As EventArgs) Handles TBX_U_PASS.Leave, TBX_NAME.Leave, CBX_USERTYPE.Leave, CBX_ROLE.Leave
        addEnable()
    End Sub

    Private Sub CHK_RPT_DT_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_RPT_DT.CheckedChanged
        If CHK_RPT_DT.Checked = True Then
            RPT_DT = "Y"
        Else
            RPT_DT = "N"
        End If
    End Sub

    Private Sub CHK_RPT_SOA_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_RPT_SOA.CheckedChanged
        If CHK_RPT_SOA.Checked = True Then
            RPT_SOA = "Y"
        Else
            RPT_SOA = "N"
        End If
    End Sub

    Private Sub CBX_USERTYPE_TextChanged(sender As Object, e As EventArgs) Handles CBX_USERTYPE.TextChanged
        If CBX_USERTYPE.Text = "Superuser" Then
            For Each cc As Control In Me.Controls
                If TypeOf cc Is CheckBox Then
                    DirectCast(cc, CheckBox).Checked = True
                    DirectCast(cc, CheckBox).Enabled = False
                End If
            Next
        ElseIf CBX_USERTYPE.Text = "User" Then
            For Each cc As Control In Me.Controls
                If TypeOf cc Is CheckBox Then
                    DirectCast(cc, CheckBox).Checked = False
                    DirectCast(cc, CheckBox).Enabled = True
                End If
            Next
            CheckBox1.Checked = True
            CheckBox1.Enabled = False
        Else
            For Each cc As Control In Me.Controls
                If TypeOf cc Is CheckBox Then
                    DirectCast(cc, CheckBox).Checked = False
                    DirectCast(cc, CheckBox).Enabled = False
                End If
            Next
            CheckBox1.Checked = True
        End If
    End Sub

    Private Sub CHK_FM_SRVC_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_FM_SRVC.CheckedChanged
        If CHK_FM_SRVC.Checked = True Then
            FM_SVRC = "Y"
        Else
            FM_SVRC = "N"
        End If
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CLEAR_TXT()
    End Sub

    Private Sub CHK_FM_CST_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_FM_CST.CheckedChanged
        If CHK_FM_CST.Checked = True Then
            FM_CST = "Y"
        Else
            FM_CST = "N"
        End If
    End Sub

    Private Function SrcList() As DataTable
        Dim dt_items As New DataTable
        dt_items.Columns.Add(" ", GetType(Boolean))
        Using conn As New SqlConnection(connstring)
            Using cmd As New SqlCommand("SELECT *
                                        FROM Tbl_users where uname <>'ADMIN' ORDER BY STATUS,ID", conn)
                conn.Open()
                Dim RDR As SqlDataReader = cmd.ExecuteReader()
                dt_items.Load(RDR)
            End Using
        End Using
        Return dt_items
        'ID, Name, ROLE, Usertype, STATUS, UNAME, PASSWORD, FM_EMP, FM_CST, FM_ITM,
        'FM_SVRC, RPT_DT, RPT_SOA, TR_RC, TR_DLVR, UT_USR, UT_BACKUP, UT_RESTORE 
    End Function
    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick

        DataGridView1.MultiSelect = True
        DataGridView1.Rows(e.RowIndex).Cells(0).Value = True

        Dim i As Integer
        With DataGridView1
            If e.RowIndex >= 0 Then
                i = .CurrentRow.Index
                TBX_NAME.Text = .Rows(i).Cells("NAME").Value.ToString
                TBX_U_PASS.Text = .Rows(i).Cells("PASSWORD").Value.ToString
                CBX_ROLE.Text = .Rows(i).Cells("ROLE").Value.ToString
                CBX_USERTYPE.Text = .Rows(i).Cells("USERTYPE").Value.ToString
                ID = .Rows(i).Cells("ID").Value.ToString
                UNAME = .Rows(i).Cells("UNAME").Value.ToString
                If .Rows(i).Cells("FM_EMP").Value.ToString = "Y" Then
                    CHK_FM_EMP.Checked = True
                Else
                    CHK_FM_EMP.Checked = False
                End If

                If .Rows(i).Cells("FM_CST").Value.ToString = "Y" Then
                    CHK_FM_CST.Checked = True
                Else
                    CHK_FM_CST.Checked = False
                End If

                If .Rows(i).Cells("FM_ITM").Value.ToString = "Y" Then
                    CHK_FM_ITM.Checked = True
                Else
                    CHK_FM_ITM.Checked = False
                End If


                If .Rows(i).Cells("FM_SVRC").Value.ToString = "Y" Then
                    CHK_FM_SRVC.Checked = True
                Else
                    CHK_FM_SRVC.Checked = False
                End If

                If .Rows(i).Cells("TR_RC").Value.ToString = "Y" Then
                    CHK_TR_REC.Checked = True
                Else
                    CHK_TR_REC.Checked = False
                End If

                If .Rows(i).Cells("TR_DLVR").Value.ToString = "Y" Then
                    CHK_TR_DLVR.Checked = True
                Else
                    CHK_TR_DLVR.Checked = False
                End If

                If .Rows(i).Cells("RPT_DT").Value.ToString = "Y" Then
                    CHK_RPT_DT.Checked = True
                Else
                    CHK_RPT_DT.Checked = False
                End If

                If .Rows(i).Cells("RPT_SOA").Value.ToString = "Y" Then
                    CHK_RPT_SOA.Checked = True
                Else
                    CHK_RPT_SOA.Checked = False
                End If

                If .Rows(i).Cells("UT_USR").Value.ToString = "Y" Then
                    CHK_UT_USER.Checked = True
                Else
                    CHK_UT_USER.Checked = False
                End If

                If .Rows(i).Cells("UT_BACKUP").Value.ToString = "Y" Then
                    CHK_UT_BACKUP.Checked = True
                Else
                    CHK_UT_BACKUP.Checked = False
                End If

                If .Rows(i).Cells("UT_RESTORE").Value.ToString = "Y" Then
                    CHK_UT_RESTORE.Checked = True
                Else
                    CHK_UT_RESTORE.Checked = False
                End If

                If .Rows(i).Cells("STATUS").Value.ToString = "ACTIVE" Then
                    CheckBox1.Checked = True
                Else
                    CheckBox1.Checked = False
                End If
                CheckBox1.Enabled = True

                BTN_ADD_USR.Enabled = False
                BTN_ADD_USR.BackColor = Color.WhiteSmoke
                BTN_ADD_USR.FlatAppearance.BorderColor = Color.WhiteSmoke
                If Main.USER_TYPE = "Superuser" Then
                    BTN_USR_UPDT.FlatAppearance.BorderColor = Color.Gray
                    BTN_USR_UPDT.BackColor = Color.White
                    BTN_USR_UPDT.Enabled = True
                End If
            End If
        End With

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Me.Dispose()
    End Sub

    Private Sub TBX_NAME_TextChanged_1(sender As Object, e As EventArgs) Handles TBX_NAME.TextChanged, CBX_ROLE.TextChanged
        addEnable()
    End Sub
    Public Sub addEnable()
        If TBX_NAME.Text <> "" AndAlso CBX_ROLE.Text <> "" AndAlso CBX_USERTYPE.Text <> "" Then
            BTN_ADD_USR.Enabled = True
            BTN_ADD_USR.BackColor = Color.White
            BTN_ADD_USR.FlatAppearance.BorderColor = Color.Gray
        Else
            BTN_ADD_USR.Enabled = False
            BTN_ADD_USR.BackColor = Color.WhiteSmoke
            BTN_ADD_USR.FlatAppearance.BorderColor = Color.WhiteSmoke
        End If
    End Sub



End Class