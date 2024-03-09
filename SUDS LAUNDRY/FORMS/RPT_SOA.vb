Imports System.Data.SqlClient
Imports System.Configuration
Public Class RPT_SOA
    Public connstring As String = ConfigurationManager.ConnectionStrings("SUDS_ConnectionString").ConnectionString

    Dim servicescked As String
    'Dim servicesCTR As Integer
    Dim SOA_SERIES As String
    Dim SOA_PREV As String
    Dim SOA_ttl As Double
    Private Sub RPT_SOA_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim currentDate As DateTime = DateTime.Today
        Label4.Text = currentDate.ToString("MM/dd/yy")
        DateTimePicker1.CustomFormat = "MM/dd/yyyy"
        DateTimePicker2.CustomFormat = "MM/dd/yyyy"

        CBX_CNAME.DataSource = SrC_CSTMER()
        CBX_CNAME.ValueMember = "CUSTOMER_CODE"
        CBX_CNAME.DisplayMember = "NAME"
        CBX_CNAME.SelectedIndex = -1

        CBX_DEPART.DataSource = SrC_DEPARTMENT()
        CBX_DEPART.ValueMember = "dep_ID"
        CBX_DEPART.DisplayMember = "DEP_NAME"
        CBX_DEPART.SelectedIndex = -1

        'Dim creport As New report_soa
        'Dim user As String = "sa"
        'Dim pwd As String = "p@ssw0rd"
        'creport.SetDatabaseLogon(user, pwd)
        'creport.SetParameterValue("CSTNAME", "0")
        'creport.SetParameterValue("SVC_TYPE", "0")
        ''creport.SetParameterValue("P_FROM", "10/01/2023")
        ''creport.SetParameterValue("P_TO", "10/31/2023")
        'creport.SetParameterValue("P_FROM", DateTimePicker1.Text)
        'creport.SetParameterValue("P_TO", DateTimePicker2.Text)
        'creport.SetParameterValue("DEPART", "0")
        'CrystalReportViewer2.ReportSource = creport
        'CrystalReportViewer2.Refresh()

        'Me.ReportViewer1.RefreshReport()
    End Sub
    Private Sub CBX_DEPART_GotFocus(sender As Object, e As EventArgs) Handles CBX_DEPART.GotFocus
        If CBX_CNAME.Text <> "" Then
            CBX_DEPART.DataSource = SrC_DEPARTMENT()
            CBX_DEPART.ValueMember = "dep_ID"
            CBX_DEPART.DisplayMember = "DEP_NAME"
            CBX_DEPART.SelectedIndex = -1
        End If

    End Sub
    Public Function SrC_CSTMER() As DataTable
        Dim dt_items As New DataTable
        Using conn As New SqlConnection(connstring)
            Using cmd As New SqlCommand("SELECT NAME,CUSTOMER_CODE FROM tbl_customer  ORDER BY NAME", conn)
                conn.Open()
                Dim RDR As SqlDataReader = cmd.ExecuteReader()
                dt_items.Load(RDR)
            End Using
        End Using
        Return dt_items
    End Function
    Public Function SrC_DEPARTMENT() As DataTable
        Dim dt_items As New DataTable
        Using conn As New SqlConnection(connstring)
            Using cmd As New SqlCommand("SELECT * FROM TBL_DEPARTMENT WHERE CCODE LIKE'%" & CBX_CNAME.SelectedValue & "%' And DEP_STAT ='ACTIVE'", conn)
                conn.Open()
                Dim RDR As SqlDataReader = cmd.ExecuteReader()
                dt_items.Load(RDR)
            End Using
        End Using
        Return dt_items
    End Function
    Public Function SrC_ServiceType() As DataTable
        Dim dt_items As New DataTable
        Using conn As New SqlConnection(connstring)
            Using cmd As New SqlCommand("SELECT '' AS 'service_type', 'ALL' AS 'NAME'
                                        UNION ALL
                                        SELECT service_type, service_type AS 'NAME' FROM tbl_services WHERE  service_status='ACTIVE' AND CCODE='" & CBX_CNAME.SelectedValue & "'", conn)
                conn.Open()
                Dim RDR As SqlDataReader = cmd.ExecuteReader()
                dt_items.Load(RDR)
            End Using
        End Using
        Return dt_items
    End Function
    Private Sub CBX_CNAME_Leave(sender As Object, e As EventArgs) Handles CBX_CNAME.Leave

        If CBX_CNAME.Text <> "" Then
            CheckedListBox1.Items.Clear()
            Using connection As New SqlConnection(connstring)
                connection.Open()
                Dim rowCount As Integer = 0
                Dim query As String = "SELECT '' AS 'service_type', 'ALL' AS 'NAME'
                                        UNION ALL
                                        SELECT service_type, service_type AS 'NAME' FROM tbl_services WHERE   CCODE='" & CBX_CNAME.SelectedValue & "'"
                Using command As New SqlCommand(query, connection)
                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            CheckedListBox1.Items.Add(reader("NAME").ToString())
                            rowCount += 1
                        End While
                    End Using
                End Using

                Panel2.Height = 189 + 20 * rowCount
                CheckedListBox1.Height = 20 * rowCount
            End Using


            Panel2.Visible = True

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CheckBox1.Checked = False
        SeriesGen()
        Dim checkedItemCount As Integer = CountCheckedItems()
        If checkedItemCount = 0 Then
            MessageBox.Show("No Selected Service Type")
        Else
            GetSelectedValues()
            Dim creport As New report_soa
            Dim user As String = "sa"
            Dim pwd As String = "p@ssw0rd"
            creport.SetDatabaseLogon(user, pwd)
            creport.SetParameterValue("CSTNAME", CBX_CNAME.Text)
            creport.SetParameterValue("SVC_TYPE", servicescked)
            creport.SetParameterValue("P_FROM", DateTimePicker1.Text)
            creport.SetParameterValue("P_TO", DateTimePicker2.Text)
            creport.SetParameterValue("DEPART", CBX_DEPART.Text)
            creport.SetParameterValue("SOA", SOA_SERIES)
            CrystalReportViewer2.ReportSource = creport
            CrystalReportViewer2.Refresh()

            'CheckBox1.Visible = True
            'Button2.Visible = True
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close this window?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If result = DialogResult.Yes Then
            Me.Dispose()
        End If
    End Sub

    'Private Sub HasCheckedItems()
    '    servicesCTR = 0
    '    For i As Integer = 0 To CheckedListBox1.Items.Count - 1
    '        If CheckedListBox1.GetItemChecked(i) Then
    '            servicesCTR += 1
    '        End If
    '    Next
    'End Sub

    Private Sub CBX_CNAME_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBX_CNAME.SelectedIndexChanged
        CBX_DEPART.Text = Nothing
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        DateTimePicker2.MinDate = DateTimePicker1.Value
    End Sub

    Private Sub TSB_EXIT_Click(sender As Object, e As EventArgs) Handles TSB_EXIT.Click
        Me.Dispose()
    End Sub

    Private Sub CheckedListBox1_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles CheckedListBox1.ItemCheck
        If e.Index = 0 Then
            For i As Integer = 1 To CheckedListBox1.Items.Count - 1
                CheckedListBox1.SetItemChecked(i, False)
            Next
        ElseIf e.Index > 0 Then
            CheckedListBox1.SetItemChecked(0, False)
        End If
    End Sub

    Private Sub GetSelectedValues()

        Dim selectedValues As New List(Of String)

        Dim r As Integer

        If CheckedListBox1.GetItemChecked(0) Then
            r = 1
        Else
            r = 2
        End If
        If r = 1 Then
            servicescked = ""
        Else
            For i As Integer = 0 To CheckedListBox1.Items.Count - 1
                If CheckedListBox1.GetItemChecked(i) Then
                    selectedValues.Add(CheckedListBox1.Items(i).ToString())
                End If
            Next
            servicescked = String.Join(",", selectedValues)

        End If

    End Sub

    Private Function CountCheckedItems() As Integer
        Dim checkedCount As Integer = 0

        For i As Integer = 0 To CheckedListBox1.Items.Count - 1
            If CheckedListBox1.GetItemChecked(i) Then
                checkedCount += 1
            End If
        Next

        Return checkedCount
    End Function

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            SOA_ttl = 0
            Try
                Dim conn As New SqlConnection(connstring)
                Dim storedProcedureName As String = "SP_SUDS_SOA_Amount"
                Using connection As New SqlConnection(connstring)
                    Using command As New SqlCommand(storedProcedureName, connection)
                        command.CommandType = CommandType.StoredProcedure

                        ' Add parameters if your stored procedure requires them
                        command.Parameters.AddWithValue("@SP_CSTOMER", CBX_CNAME.Text)
                        command.Parameters.AddWithValue("@SP_SRVC_TYPE", servicescked)
                        command.Parameters.AddWithValue("@SP_DEPART", CBX_DEPART.Text)
                        command.Parameters.AddWithValue("@SP_P_FROM", DateTimePicker1.Text)
                        command.Parameters.AddWithValue("@SP_P_TO", DateTimePicker2.Text)

                        connection.Open()

                        ' Execute the stored procedure
                        command.ExecuteNonQuery()

                        Dim sdr As SqlDataReader = command.ExecuteReader()
                        If (sdr.Read()) Then
                            SOA_ttl = sdr("ttl")
                            Label7.Text = sdr("ttl")
                        End If
                        sdr.Close()

                        ''PREV SOA
                        Dim command3 As New Data.SqlClient.SqlCommand With {
                            .CommandText = "select top 1 SoaSeries from tbl_soa where Total <> ISNULL(Payment,0) AND Department='" & CBX_DEPART.Text & "' AND CCODE='" & CBX_CNAME.SelectedValue.ToString & "'order by createdate desc"
                        }
                        conn.Open()
                        command3.Connection = conn
                        command3.ExecuteNonQuery()
                        Dim sdr3 As SqlDataReader = command3.ExecuteReader()
                        If (sdr3.Read()) Then
                            SOA_PREV = sdr3("SoaSeries")
                        Else
                            SOA_PREV = ""
                        End If
                        sdr3.Close()

                        connection.Close()
                    End Using
                End Using
            Catch ex As Exception
            End Try

            Button2.Enabled = True

        Else
            Button2.Enabled = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If SOA_ttl = 0 Then
            MessageBox.Show("NO RESULT")
        Else
            Dim result As DialogResult = MessageBox.Show("This operation is irreversible. By selecting 'Yes', you affirm that all data is accurate.", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                ADD_SOA()

                CheckBox1.Visible = False
                Button2.Visible = False
            End If
        End If

    End Sub

    Public Sub SeriesGen()
        Try

            Dim conn As New SqlConnection(connstring)

            Dim SOA_ID As Integer = 0

            Dim command3 As New Data.SqlClient.SqlCommand With {
                .CommandText = "SELECT ISNULL(MAX(id),0)+1 AS ID from tbl_soa"
            }
            conn.Open()
            command3.Connection = conn
            command3.ExecuteNonQuery()
            Dim sdr As SqlDataReader = command3.ExecuteReader()
            If (sdr.Read()) Then
                SOA_ID = sdr("ID")
            End If
            sdr.Close()
            conn.Close()

            Dim formattedNumber As String = SOA_ID.ToString("D8")
            SOA_SERIES = CBX_CNAME.SelectedValue.ToString & formattedNumber
            'SOA_SERIES = CBX_CNAME.SelectedValue.ToString & Label4.Text.Replace("/", "") & "-" & formattedNumber


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub ADD_SOA()
        Try
            SeriesGen()
            Dim sqlCon = New SqlConnection(connstring)

            Dim command2 As New Data.SqlClient.SqlCommand
            sqlCon.Open()
            command2.CommandText = "INSERT INTO Tbl_SOA(SoaSeries,CCODE,Customer,Department,SrvcsType,P_FROM,P_TO,Total,PrevSoa,Payment) 
                                    VALUES(@soa_series,@CCode,@Cname,@depart,@svtype,@pfrom,@pto,@Total,@PrevSoa,0)"
            command2.Parameters.Add("@soa_series", SqlDbType.VarChar).Value = SOA_SERIES
            command2.Parameters.Add("@CCode", SqlDbType.VarChar).Value = CBX_CNAME.SelectedValue.ToString
            command2.Parameters.Add("@Cname", SqlDbType.VarChar).Value = CBX_CNAME.Text
            command2.Parameters.Add("@depart", SqlDbType.VarChar).Value = CBX_DEPART.Text
            command2.Parameters.Add("@svtype", SqlDbType.VarChar).Value = servicescked
            command2.Parameters.Add("@pfrom", SqlDbType.Date).Value = DateTimePicker1.Value
            command2.Parameters.Add("@pto", SqlDbType.Date).Value = DateTimePicker2.Value
            command2.Parameters.Add("@Total", SqlDbType.Decimal).Value = SOA_ttl
            command2.Parameters.Add("@PrevSoa", SqlDbType.VarChar).Value = SOA_PREV
            command2.Connection = sqlCon
            command2.ExecuteNonQuery()
            sqlCon.Close()

            INSERT_SOA_DETAILS()

            MessageBox.Show("SOA: successfully added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CheckBox1.Checked = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub INSERT_SOA_DETAILS()

        Dim sqlCon = New SqlConnection(connstring)
        Using (sqlCon)
            Dim sqlComm As New SqlCommand With {
                .Connection = sqlCon,
                .CommandText = "Insert_SOA_DETAILS",
                .CommandType = CommandType.StoredProcedure
            }

            sqlComm.Parameters.AddWithValue("@SOA_CSTOMER", CBX_CNAME.Text)
            sqlComm.Parameters.AddWithValue("@SOA_SRVC_TYPE", servicescked)
            sqlComm.Parameters.AddWithValue("@SOA_DEPART", CBX_DEPART.Text)
            sqlComm.Parameters.AddWithValue("@SOA_P_FROM", DateTimePicker1.Value)
            sqlComm.Parameters.AddWithValue("@SOA_P_TO", DateTimePicker2.Value)
            sqlComm.Parameters.AddWithValue("@SOA_SOASRS", SOA_SERIES)

            sqlCon.Open()
            If sqlComm.ExecuteNonQuery() = 1 Then
                MessageBox.Show("Data added successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            sqlCon.Close()
        End Using

    End Sub


End Class