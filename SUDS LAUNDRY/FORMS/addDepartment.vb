Imports System.Data.SqlClient
Imports System.Configuration
Public Class addDepartment
    Public connstring As String = ConfigurationManager.ConnectionStrings("SUDS_ConnectionString").ConnectionString
    Dim DEP_ID As String
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
    Private Function DepartmentList() As DataTable
        Dim dt_items As New DataTable
        Using conn As New SqlConnection(connstring)
            Using cmd As New SqlCommand("  SELECT dep_ID as'DEP_ID', T1.NAME AS 'COMPANY',DEP_NAME,DEP_STAT FROM TBL_DEPARTMENT T0 INNER JOIN TBL_CUSTOMER T1 ON T0.CCODE=T1.CUSTOMER_CODE", conn)
                conn.Open()
                Dim RDR As SqlDataReader = cmd.ExecuteReader()
                dt_items.Load(RDR)
            End Using
        End Using
        Return dt_items
    End Function
    Public Sub ADD_Deppartment()
        Try
            Dim sqlCon = New SqlConnection(connstring)
            Using (sqlCon)
                Dim sqlComm As New SqlCommand With {
                    .Connection = sqlCon,
                    .CommandText = "AddDepart",
                    .CommandType = CommandType.StoredProcedure
                }

                sqlComm.Parameters.AddWithValue("@CCODE", CBX_I_COM.SelectedValue)
                sqlComm.Parameters.AddWithValue("@DEPNAME", TBX_DEPART.Text)

                sqlCon.Open()
                If sqlComm.ExecuteNonQuery() = 1 Then

                End If
                sqlCon.Close()
                MessageBox.Show("New item successfully added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DataGridDEPT.DataSource = DepartmentList()
                CLEAR_TXT()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub UPDT_DEPT()
        Try
            Dim sqlCon = New SqlConnection(connstring)
            Using (sqlCon)
                Dim sqlComm As New SqlCommand With {
                    .Connection = sqlCon,
                    .CommandText = "UpdtDepart",
                    .CommandType = CommandType.StoredProcedure
                }
                sqlComm.Parameters.AddWithValue("@DCODE", DEP_ID)
                sqlComm.Parameters.AddWithValue("@NAME", TBX_DEPART.Text)
                sqlComm.Parameters.AddWithValue("@STAT", CheckBox1.Text)

                sqlCon.Open()
                If sqlComm.ExecuteNonQuery() = 1 Then

                End If
                sqlCon.Close()
                MessageBox.Show("Record successfully updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DataGridDEPT.DataSource = DepartmentList()
                CLEAR_TXT()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub CLEAR_TXT()
        TBX_DEPART.Text = Nothing
        CBX_I_COM.Text = Nothing
        DEP_ID = Nothing
        CBX_I_COM.Enabled = True
        CBX_I_COM.SelectedIndex = -1
        BTN_CUS_ADD.Enabled = False
        BTN_CUS_UPDT.Enabled = False
    End Sub
    Private Sub addDepartment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        CBX_I_COM.DataSource = SrC_CSTMER()
        CBX_I_COM.ValueMember = "CUSTOMER_CODE"
        CBX_I_COM.DisplayMember = "NAME"
        CBX_I_COM.SelectedIndex = -1
        DataGridDEPT.ReadOnly = True
    End Sub
    Public Function CHECK_CNT() As Integer
        Dim sqlCon_C As New SqlConnection(connstring)
        Dim count As Integer = 0
        Dim ccode As String = CBX_I_COM.SelectedValue.ToString
        Dim DEP_NAME As String = TBX_DEPART.Text

        Try
            Dim cmd As New SqlCommand("SELECT COUNT(DEP_NAME) AS CNT FROM TBL_DEPARTMENT WHERE CCODE='" & ccode & "' AND DEP_NAME='" & DEP_NAME & "'", sqlCon_C)

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
    Private Sub BTN_CUS_ADD_Click(sender As Object, e As EventArgs) Handles BTN_CUS_ADD.Click
        Dim result As Integer = CHECK_CNT()
        If result = 0 Then
            ADD_Deppartment()
        Else
            MessageBox.Show("Item '" & TBX_DEPART.Text & "' already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TBX_DEPART.Select()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CLEAR_TXT()
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataGridDEPT.DataSource = DepartmentList()
        DataGridDEPT.Columns("DEP_ID").Width = 25
        DataGridDEPT.Columns("COMPANY").Width = 80
        DataGridDEPT.Columns("DEP_NAME").Width = 80
        DataGridDEPT.Columns("DEP_STAT").Width = 80
    End Sub

    Private Sub DataGridDEPT_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridDEPT.CellMouseDoubleClick
        Dim i As Integer
        With DataGridDEPT
            If e.RowIndex >= 0 Then
                i = .CurrentRow.Index
                DEP_ID = .Rows(i).Cells(0).Value.ToString
                CBX_I_COM.Text = .Rows(i).Cells(1).Value.ToString
                TBX_DEPART.Text = .Rows(i).Cells(2).Value.ToString
                If .Rows(i).Cells(3).Value = "ACTIVE" Then
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

    Private Sub BTN_CUS_UPDT_Click(sender As Object, e As EventArgs) Handles BTN_CUS_UPDT.Click
        UPDT_DEPT()
    End Sub

    Private Sub TBX_DEPART_TextChanged(sender As Object, e As EventArgs) Handles TBX_DEPART.TextChanged
        If CBX_I_COM.SelectedIndex <> -1 AndAlso TBX_DEPART.Text <> "" Then
            BTN_CUS_ADD.Enabled = True
        Else
            BTN_CUS_ADD.Enabled = False
        End If
    End Sub
End Class