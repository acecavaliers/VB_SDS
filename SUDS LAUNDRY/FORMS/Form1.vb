Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Data.OleDb
Public Class Form1
    Public connstring As String = ConfigurationManager.ConnectionStrings("SUDS_ConnectionString").ConnectionString
    Public CCODE As String
    ReadOnly DEL_NUM As Integer
    Dim REC_NUM As Integer
    Dim REC_MAX_NUM As Integer
    ReadOnly current_row_NUM As Integer
    Public countRows As Integer = 0
    Public price_per_kg As Double
    Dim total_price As Double
    Public GRID_CHANGER As Integer = 0
    Public PRINT_STAT As String
    Dim sum_OPENQTY As Double = 0
    Dim sum_QTY As Double = 0
    Public drSrc As Integer = 0
    Public Property CrystalReportviewer1 As Object




    Public Function SrC_CSTMER() As DataTable
        Dim dt_items As New DataTable
        Using conn As New SqlConnection(connstring)
            Using cmd As New SqlCommand("SELECT *  FROM tbl_customer WHERE C_STAT='ACTIVE' ORDER BY NAME", conn)
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

    Public Function SrC_CHKR() As DataTable
        Dim dt_items As New DataTable
        Using conn As New SqlConnection(connstring)
            Using cmd As New SqlCommand("SELECT * FROM Tbl_users  WHERE  STATUS='ACTIVE'  and uname not in('ADMIN','USER','Administrator') ORDER BY name", conn)
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
            Using cmd As New SqlCommand("SELECT * FROM tbl_services WHERE service_status='ACTIVE' AND CCODE like'%" & CBX_CNAME.SelectedValue & "%'ORDER BY SERVICE_TYPE", conn)
                conn.Open()
                Dim RDR As SqlDataReader = cmd.ExecuteReader()
                dt_items.Load(RDR)
            End Using
        End Using
        Return dt_items
    End Function
    Public Sub REC_CLEARTEXT()
        CBX_CNAME.Text = Nothing
        PICK_UP_FORM_NO.Text = Nothing
        CBX_SORT.Text = Nothing
        TYPE_SERVICE.Text = Nothing
        CBX_DEPART.Text = Nothing
        CBX_DLVR_TEAM.Text = Nothing
        REMARKS.Text = Nothing
        TBX_RELEASED_BY.Text = Nothing
        CBX_CHKR.Text = Nothing
        ToolStripTBX_R_NUM.Text = Nothing
        TOTAL_W.Text = "0.00"
        TBX_STATUS.Text = Nothing
        TBX_STATUS.BackColor = Color.White
        BTN_EDIT_ITEMS.Enabled = False
        Label10.Select()
        CBX_FNB.Text = Nothing
        Label15.Text = "0.00"
        DataGridView1.Columns(5).Visible = False
    End Sub
    Public Sub CLR_ROWS()
        CheckBox1.Checked = False
        For Each row As DataGridViewRow In DataGridView1.Rows
            For Each cell As DataGridViewCell In row.Cells
                cell.Value = Nothing ' or cell.Value = DBNull.Value
            Next
            If row.Index <> 10 Then
                row.DefaultCellStyle.BackColor = Color.WhiteSmoke
                row.Cells(4).Style.BackColor = Color.WhiteSmoke
                row.Cells(8).Style.BackColor = Color.WhiteSmoke
            End If
        Next
        DataGridView1.Rows(10).Cells(1).Value = "Total"
        DataGridView1.Rows(10).DefaultCellStyle.BackColor = Color.DarkGray
        If DataGridView1.Columns.Count > 9 Then
            Dim columnIndex As Integer = DataGridView1.Columns.IndexOf(DataGridView1.Columns("Adjustment"))
            DataGridView1.Columns.RemoveAt(columnIndex)
        End If
    End Sub
    Public Sub REC_READONLY()
        CBX_CNAME.Enabled = False
        PICK_UP_FORM_NO.Enabled = False
        CBX_SORT.Enabled = False
        TYPE_SERVICE.Enabled = False
        CBX_DEPART.Enabled = False
        CBX_DLVR_TEAM.Enabled = False
        REMARKS.ReadOnly = True
        TBX_RELEASED_BY.Enabled = False
        CBX_CHKR.Enabled = False
        DataGridView1.Enabled = False
        DataGridView1.ClearSelection()
        BTN_ITMS_SHOW.Enabled = False
        Button2.Enabled = False
        ToolStripTBX_R_NUM.Enabled = False
        Label10.Select()
        CBX_FNB.Enabled = False
    End Sub
    Public Sub REC_ENABLE()
        CBX_CNAME.Enabled = True
        PICK_UP_FORM_NO.Enabled = True
        CBX_SORT.Enabled = True
        TYPE_SERVICE.Enabled = True
        CBX_DEPART.Enabled = True
        CBX_DLVR_TEAM.Enabled = True
        REMARKS.ReadOnly = False
        TBX_RELEASED_BY.Enabled = True
        CBX_CHKR.Enabled = True
        DataGridView1.Enabled = True
        DataGridView1.ClearSelection()
        'BTN_ITMS_SHOW.Enabled = True
        Button2.Enabled = True
        Label10.Select()
        ToolStripTBX_R_NUM.Enabled = True
        CBX_FNB.Enabled = True
    End Sub
    Private Sub ToolStrip1_ItemAdded(sender As Object, e As ToolStripItemEventArgs) Handles ToolStripR_RECNUM.ItemAdded
        If TypeOf e.Item Is ToolStripButton Then
            AddHandler DirectCast(e.Item, ToolStripButton).MouseEnter, AddressOf ToolStripButton_MouseEnter
            AddHandler DirectCast(e.Item, ToolStripButton).MouseLeave, AddressOf ToolStripButton_MouseLeave
        End If
    End Sub

    Private Sub ToolStripButton_MouseEnter(sender As Object, e As EventArgs)
        DirectCast(sender, ToolStripButton).BackColor = Color.DimGray
    End Sub

    Private Sub ToolStripButton_MouseLeave(sender As Object, e As EventArgs)
        DirectCast(sender, ToolStripButton).BackColor = Color.Black
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Label5.Text ="Label5.Text (" & Timer1.Interval & ")"
        PANEL_ERROR.Visible = False ' Hide the panel
        Timer1.Stop() ' Stop the timer
    End Sub
    Public Sub ErrorBox()
        PANEL_ERROR.BackColor = Color.Red
        ERR_ICON.Image = My.Resources.important_20
        LBL_ERROR_MSG.Select()
        PANEL_ERROR.Visible = True
        Timer1.Interval = 3500 ' Set the timer interval to 3 seconds
        Timer1.Start() ' Start the timer
    End Sub
    Public Sub SuccessBox()
        PANEL_ERROR.BackColor = Color.LimeGreen
        ERR_ICON.Image = My.Resources.ok_20
        LBL_ERROR_MSG.Select()
        PANEL_ERROR.Visible = True
        Timer1.Interval = 3500 ' Set the timer interval to 3 seconds
        Timer1.Start() ' Start the timer
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        'Me.CenterToParent()
        If Main.Label10.Text = "ADMIN" Then
            DateTimePicker1.Enabled = True
        Else
            DateTimePicker1.Enabled = False
        End If

        CBX_CNAME.DataSource = SrC_CSTMER()
        CBX_CNAME.ValueMember = "CUSTOMER_CODE"
        CBX_CNAME.DisplayMember = "NAME"
        CBX_CNAME.SelectedIndex = -1

        CBX_CHKR.DataSource = SrC_CHKR()
        CBX_CHKR.ValueMember = "NAME"
        CBX_CHKR.DisplayMember = "NAME"
        CBX_CHKR.SelectedIndex = -1

        CBX_DEPART.DataSource = SrC_DEPARTMENT()
        CBX_DEPART.ValueMember = "dep_ID"
        CBX_DEPART.DisplayMember = "DEP_NAME"
        CBX_DEPART.SelectedIndex = -1

        TYPE_SERVICE.DataSource = SrC_ServiceType()
        TYPE_SERVICE.ValueMember = "service_code"
        TYPE_SERVICE.DisplayMember = "service_type"
        TYPE_SERVICE.SelectedIndex = -1

        Label10.Select()


        DATA_G()
        DataGridView1.ClearSelection()
        DataGridView1.Columns("OPENQTY").Visible = False
        DataGridView1.Rows(10).ReadOnly = True
        DataGridView1.Columns(6).ReadOnly = True
        DataGridView1.Columns(7).ReadOnly = True
        DataGridView1.Columns(8).ReadOnly = True
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray
        DataGridView1.Rows(10).DefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        DataGridView1.Rows(10).DefaultCellStyle.BackColor = Color.DarkGray
        DataGridView1.Rows(10).Cells(1).Value = "Total"

    End Sub
    Public Sub DATA_G()
        Dim ITC, TNM, WP, PP, QTY, OPQ, T, TAMT, PUQ As New DataGridViewTextBoxColumn

        ITC.DataPropertyName = "ITEMCODE"
        ITC.HeaderText = "ITEM CODE"
        ITC.Name = "ITEMCODE"
        DataGridView1.Columns.Add(ITC)

        TNM.DataPropertyName = "TNM"
        TNM.HeaderText = "ITEM DESCRIPTION"
        TNM.Name = "TNM"
        DataGridView1.Columns.Add(TNM)

        WP.DataPropertyName = "WEIGHTPIECE"
        WP.HeaderText = "WEIGHT/PIECE"
        WP.Name = "WEIGHTPIECE"
        DataGridView1.Columns.Add(WP)

        PP.DataPropertyName = "PRICE"
        PP.HeaderText = "PRICE/PIECE"
        PP.Name = "PRICE"
        DataGridView1.Columns.Add(PP)

        QTY.DataPropertyName = "QTY"
        QTY.HeaderText = "QTY"
        QTY.Name = "QTY"
        DataGridView1.Columns.Add(QTY)


        OPQ.DataPropertyName = "OPENQTY"
        OPQ.HeaderText = "OPEN QTY"
        OPQ.Name = "OPENQTY"
        DataGridView1.Columns.Add(OPQ)

        T.DataPropertyName = "TOTALWEIGHT"
        T.HeaderText = "T. WEIGHT"
        T.Name = "TOTALWEIGHT"
        DataGridView1.Columns.Add(T)

        TAMT.DataPropertyName = "TOTALAMOUNT"
        TAMT.HeaderText = "T. AMOUNT"
        TAMT.Name = "TOTALAMOUNT"
        DataGridView1.Columns.Add(TAMT)

        PUQ.DataPropertyName = "PUQTY"
        PUQ.HeaderText = "PUQTY"
        PUQ.Name = "PUQTY"
        DataGridView1.Columns.Add(PUQ)



        For ttl As Integer = 1 To 11
            DataGridView1.Rows.Add("", "", "", "", "", "")
        Next

        Dim totalWidth As Integer = DataGridView1.Width
        Dim c0 As Double = 0.1 ' 10%
        Dim c1 As Double = 0.3 ' 30%
        Dim c2 As Double = 0.1 ' 10%
        Dim c3 As Double = 0.1 ' 10%
        Dim c4 As Double = 0.07 ' 7%
        Dim c5 As Double = 0.07 ' 7%
        Dim c6 As Double = 0.1 ' 10%
        Dim c7 As Double = 0.1 ' 30%
        Dim c8 As Double = 0.06 ' 6%
        'Dim c3 As Double = 0.35 ' 10%

        Dim c0w As Integer = CInt(totalWidth * c0)
        Dim c1w As Integer = CInt(totalWidth * c1)
        Dim c2w As Integer = CInt(totalWidth * c2)
        Dim c3w As Integer = CInt(totalWidth * c3)
        Dim c4w As Integer = CInt(totalWidth * c4)
        Dim c5w As Integer = CInt(totalWidth * c5)
        Dim c6w As Integer = CInt(totalWidth * c6)
        Dim c7w As Integer = CInt(totalWidth * c7)
        Dim c8w As Integer = CInt(totalWidth * c8)
        'Dim c3w As Integer = CInt(totalWidth * c3)

        DataGridView1.Columns.Item("ITEMCODE").Width = c0w
        DataGridView1.Columns.Item("TNM").Width = c1w
        DataGridView1.Columns.Item("WEIGHTPIECE").Width = c2w
        DataGridView1.Columns.Item("PRICE").Width = c3w
        DataGridView1.Columns.Item("QTY").Width = c4w
        DataGridView1.Columns.Item("OPENQTY").Width = c5w
        DataGridView1.Columns.Item("TOTALWEIGHT").Width = c6w
        DataGridView1.Columns.Item("TOTALAMOUNT").Width = c7w
        DataGridView1.Columns.Item("PUQTY").Width = c8w
        'DataGridView1.Columns(3).Width = c3w


        'DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.Columns(0).ReadOnly = True
        'DataGridView1.Columns.Item("ITEMCODE").Width = 15
        DataGridView1.Columns(1).ReadOnly = True
        'DataGridView1.Columns.Item("TNM").Width = 60
        DataGridView1.Columns(2).ReadOnly = True
        'DataGridView1.Columns.Item("WEIGHTPIECE").Width = 18
        'DataGridView1.Columns.Item("PRICE").Width = 15
        DataGridView1.Columns(3).ReadOnly = True
        'DataGridView1.Columns.Item("QTY").Width = 15
        DataGridView1.Columns(4).ReadOnly = True
        'DataGridView1.Columns.Item("OPENQTY").Width = 15
        DataGridView1.Columns(5).ReadOnly = True
        'DataGridView1.Columns.Item("TOTALWEIGHT").Width = 15
        'DataGridView1.Columns.Item("TOTALAMOUNT").Width = 100
        DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


    End Sub

    Public Sub CHECK_MAX_ORDER()
        Dim sqlCon_C = New SqlConnection(connstring)
        Try
            Dim cmd As New SqlCommand("select ISNULL(MAX(ORDER_ID),0)as rec from  tbl_order", sqlCon_C)
            If (sqlCon_C.State <> ConnectionState.Open) Then
                sqlCon_C.Open()
            End If
            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            sdr.Read()
            REC_MAX_NUM = sdr("rec")
            sdr.Close()
            sqlCon_C.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ToolStripBTN_R_1ST_Click(sender As Object, e As EventArgs) Handles ToolStripBTN_R_1ST.Click

        GRID_CHANGER = 1
        REC_NUM = 1
        CLR_ROWS()
        ORDER_DETAILS()
        ToolStripTBX_R_NUM.Text = 1

    End Sub
    Private Sub ToolStripBTN_R_PREV_Click(sender As Object, e As EventArgs) Handles ToolStripBTN_R_PREV.Click
        REC_NUM = ToolStripTBX_R_NUM.Text
        REC_NUM -= 1
        CLR_ROWS()
        ORDER_DETAILS()
        ToolStripTBX_R_NUM.Text = REC_NUM
    End Sub
    Private Sub ToolStripBTN_R_NXT_Click(sender As Object, e As EventArgs) Handles ToolStripBTN_R_NXT.Click
        CHECK_MAX_ORDER()
        If ToolStripTBX_R_NUM.Text <> "" Then
            REC_NUM = 1 + ToolStripTBX_R_NUM.Text
            If REC_NUM <= REC_MAX_NUM Then
                ORDER_DETAILS()
                ToolStripTBX_R_NUM.Text = REC_NUM

            Else
                LBL_ERROR_MSG.Text = "Error: Last record reached"
                ErrorBox()
                ToolStripTBX_R_NUM.Text = REC_MAX_NUM
            End If
        End If
    End Sub
    Private Sub ToolStripBTN_R_LAST_Click(sender As Object, e As EventArgs) Handles ToolStripBTN_R_LAST.Click
        'PREV.Show()
        DataGridView1.DefaultCellStyle.BackColor = Color.Gainsboro
        GRID_CHANGER = 1
        CLR_ROWS()
        CHECK_MAX_ORDER()
        REC_NUM = REC_MAX_NUM
        ORDER_DETAILS()
        ToolStripTBX_R_NUM.Text = REC_NUM
        'PREV.Show()
    End Sub

    Private Sub ToolStripTBX_R_NUM_TextChanged(sender As Object, e As EventArgs) Handles ToolStripTBX_R_NUM.TextChanged
        Dim I As Integer
        If ToolStripTBX_R_NUM.Text <> "" Then
            I = ToolStripTBX_R_NUM.Text
            TSBTN_PRNT.Enabled = True
            BTN_RELATED_DOCS.Enabled = True
            If I > 1 Then
                ToolStripBTN_R_PREV.Enabled = True
            Else
                ToolStripBTN_R_PREV.Enabled = False
            End If
        Else
            BTN_RELATED_DOCS.Enabled = False
            TSBTN_PRNT.Enabled = False

        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim result As DialogResult = MessageBox.Show("This action cannot be undone are you sure you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If result = DialogResult.Yes Then
            PREV.DataGridView2.DataSource = Nothing
            CLR_ROWS()
            REC_CLEARTEXT()
            REC_ENABLE()
            CheckBox1.Checked = False
        End If


    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Login.VersionControl()
        DateTimePicker1.Value = DateTime.Now
        'GRID_CHANGER = 0
        Label8.Visible = False
        TBX_STATUS.Visible = False
        CLR_ROWS()
        REC_CLEARTEXT()
        REC_ENABLE()
        CBX_CNAME.Focus()

    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            Dim i As Integer = 0
            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.Cells(0).Value = "" AndAlso row.Cells(1).Value = "" Then
                    i += 1
                End If
            Next
            DataGridView1.Focus()
            If CBX_CNAME.Text = "" Then
                LBL_ERROR_MSG.Text = "Error: No customer selected"
                ErrorBox()
                CBX_CNAME.Select()
            ElseIf TYPE_SERVICE.Text = "" Then
                LBL_ERROR_MSG.Text = "Error: No service type selected"
                ErrorBox()
                TYPE_SERVICE.Select()
            ElseIf BTN_ITMS_SHOW.Enabled = True AndAlso CBX_CNAME.SelectedIndex <> -1 Then
                If i = 0 Then
                    LBL_ERROR_MSG.Text = "Error: Maximum of 10 items only!"
                    ErrorBox()
                Else
                    Try
                        ITEMS.ShowDialog()
                    Catch ex As Exception
                    End Try
                End If
            End If

        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles BTN_RELATED_DOCS.Click

        Try
            ' Open a connection to the database
            Using connection As New SqlConnection(connstring)
                connection.Open()

                ' Define the SQL query
                Dim sqlQuery As String = "SELECT COUNT(DLVRY_ID) AS CTR FROM tbl_delivery WHERE REFERENCE=" & ToolStripTBX_R_NUM.Text & ""

                ' Execute the query
                Using command As New SqlCommand(sqlQuery, connection)
                    ' Execute the query and get the result
                    Dim result As Integer = CInt(command.ExecuteScalar())

                    If result > 0 Then

                        SEARCH.REFERENCE = ToolStripTBX_R_NUM.Text
                        SEARCH.TTYPE = "DREF"
                        SEARCH.ShowDialog()
                        PREV.Dispose()

                    Else

                        LBL_ERROR_MSG.Text = "Alert: No Delivery record found for RR No. " & ToolStripTBX_R_NUM.Text
                        ErrorBox()

                    End If

                End Using
            End Using
        Catch ex As Exception
            ' Handle exceptions
            MessageBox.Show("Error: " & ex.Message)
        End Try

        'DELIVERY.Dispose()
        'DELIVERY.FormBorderStyle = FormBorderStyle.FixedSingle
        'DELIVERY.D_REF.Text = ToolStripTBX_R_NUM.Text
        'DELIVERY.Show()
        'DELIVERY.BringToFront()


    End Sub

    Private Sub ToolStripTBX_R_NUM_KeyDown(sender As Object, e As KeyEventArgs) Handles ToolStripTBX_R_NUM.KeyDown
        If e.KeyData = Keys.Enter Then
            CLR_ROWS()
            If ToolStripTBX_R_NUM.Text <> "" Then
                REC_NUM = ToolStripTBX_R_NUM.Text
                ORDER_DETAILS()
                'REC_READONLY()
            End If
        End If

    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles BTN_ITMS_SHOW.Click
        Dim i As Integer = 0
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(0).Value = "" AndAlso row.Cells(1).Value = "" Then
                i = +1
            End If
        Next
        If CBX_CNAME.Text = "" AndAlso TYPE_SERVICE.Text = "" Then
            LBL_ERROR_MSG.Text = "Error: No customer or service type selected"
            ErrorBox()
        Else
            If i = 0 Then
                LBL_ERROR_MSG.Text = "Error: Maximum of 10 items only!"
                ErrorBox()
            Else
                Try
                    ITEMS.ShowDialog()
                Catch ex As Exception
                End Try
            End If
        End If

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        CLR_ROWS()
        CheckBox1.Checked = True

    End Sub

    Private Sub PICK_UP_FORM_NO_KeyDown(sender As Object, e As KeyEventArgs) Handles PICK_UP_FORM_NO.KeyDown, CBX_CNAME.KeyDown, TYPE_SERVICE.KeyDown, DateTimePicker1.KeyDown,
    DateTimePiCKuP.KeyDown, REMARKS.KeyDown, CBX_SORT.KeyDown, TBX_RELEASED_BY.KeyDown, CBX_DLVR_TEAM.KeyDown, CBX_CHKR.KeyDown

        If e.KeyData = Keys.Enter Then
            If CheckBox1.Checked = True Then
                If sender Is PICK_UP_FORM_NO Then
                    SEARCH.PICKUPFORMNO = PICK_UP_FORM_NO.Text

                End If
                'SEARCH.PICKUPFORMNO = PICK_UP_FORM_NO.Text
                'SEARCH.C_CODE = CBX_CNAME.Text
                'SEARCH.SORTER = CBX_SORT.Text
                'SEARCH.TYPE_OF_SERVICE = TYPE_SERVICE.Text
                'SEARCH.R_DATE = ""
                'SEARCH.DEL_DATE = ""
                'SEARCH.DEL_TEAM = CBX_DLVR_TEAM.Text
                'SEARCH.REMARKS = REMARKS.Text
                'SEARCH.SORT_REC = TBX_RELEASED_BY.Text
                'SEARCH.CHECKEDBY = CBX_CHKR.Text
                SEARCH.TTYPE = "RDR"
                SEARCH.ShowDialog()
            Else

            End If
        End If
    End Sub
    Public Sub Printauto()

        Cursor.Current = Cursors.WaitCursor
        Dim report As New report_receive 'Replace "CrystalReport1" with the name of your report
        report.SetParameterValue("crTextBox", ToolStripTBX_R_NUM.Text)
        report.SetDatabaseLogon("sa", "p@ssw0rd", "172.16.4.55", "SUDS_LAUNDRY")
        Dim crv As New CrystalDecisions.Windows.Forms.CrystalReportViewer With {
            .ReportSource = report
        }
        crv.Refresh()
        report.PrintToPrinter(1, False, 0, 0) 'Print the report

        Cursor.Current = Cursors.Default

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If Main.Label10.Text <> "ADMIN" Then
            DateTimePicker1.Value = DateTime.Now
        End If

        Dim rowcheck As Integer = 0
        Dim puqty As Integer = 0
        total_price = Double.Parse(TOTAL_W.Text) * price_per_kg

        For Each dgvRow As DataGridViewRow In DataGridView1.Rows
            If dgvRow.Cells(0).Value <> "" AndAlso dgvRow.Cells(5).Value = "" OrElse dgvRow.Cells(4).Value = "0" Then
                rowcheck += 1
            End If
            If dgvRow.Cells(0).Value <> "" AndAlso dgvRow.Cells(8).Value = "" Then
                puqty += 1
            End If
        Next

        If CBX_CNAME.Text = "" Then
            LBL_ERROR_MSG.Text = "Error: Customer field required"
            ErrorBox()
            CBX_CNAME.Select()

        ElseIf CBX_DEPART.Text = "" Then
            LBL_ERROR_MSG.Text = "Error: Department field required"
            ErrorBox()
            CBX_DEPART.Select()

        ElseIf PICK_UP_FORM_NO.Text = "" Then
            LBL_ERROR_MSG.Text = "Error: Pick-up form number field required"
            ErrorBox()
            PICK_UP_FORM_NO.Select()

        ElseIf CBX_SORT.Text = "" Then
            LBL_ERROR_MSG.Text = "Error: Sorter field required"
            ErrorBox()
            CBX_SORT.Select()

        ElseIf TYPE_SERVICE.Text = "" Then
            LBL_ERROR_MSG.Text = "Error: Service type field required"
            ErrorBox()
            TYPE_SERVICE.Select()


        ElseIf CBX_FNB.Text = "" Then
            LBL_ERROR_MSG.Text = "Error: FNB field required"
            ErrorBox()
            CBX_FNB.Select()

        ElseIf CBX_DLVR_TEAM.Text = "" Then
            LBL_ERROR_MSG.Text = "Error: Delivery team  field required"
            ErrorBox()
            CBX_DLVR_TEAM.Select()
        ElseIf DataGridView1.Rows(0).Cells(0).Value = "" Then
            LBL_ERROR_MSG.Text = "Error: No items selected!"
            ErrorBox()
        ElseIf REMARKS.Text = "" Then
            LBL_ERROR_MSG.Text = "Error: Remarks field required"
            ErrorBox()
            REMARKS.Select()
        ElseIf TBX_RELEASED_BY.Text = "" Then
            LBL_ERROR_MSG.Text = "Error: RELEASED BY field required"
            ErrorBox()
            TBX_RELEASED_BY.Select()
        ElseIf CBX_CHKR.Text = "" Then
            LBL_ERROR_MSG.Text = "Error: Checker field required"
            ErrorBox()
            CBX_CHKR.Select()
        ElseIf rowcheck > 0 Then
            LBL_ERROR_MSG.Text = "Error: Invalid quantity! please check item details"
            ErrorBox()
        ElseIf puqty > 0 Then
            LBL_ERROR_MSG.Text = "Error: Invalid Pickup quantity! please check item details"
            ErrorBox()
        Else
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to save this Receiving entry?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                CHCKER()
                INSERT_ORDER()
                ToolStripBTN_R_LAST_Click(sender, e)
                printauto()
            End If
        End If

    End Sub
    Public Sub INSERT_ORDER()
        Try
            Dim sqlCon = New SqlConnection(connstring)
            Using (sqlCon)
                Dim sqlComm As New SqlCommand With {
                    .Connection = sqlCon,
                    .CommandText = "Insert_Order",
                    .CommandType = CommandType.StoredProcedure
                }

                sqlComm.Parameters.AddWithValue("@CCODE", CBX_CNAME.SelectedValue)
                sqlComm.Parameters.AddWithValue("@DATE", DateTimePicker1.Value)
                sqlComm.Parameters.AddWithValue("@DELIVERY_DATE", DateTimePiCKuP.Value)
                sqlComm.Parameters.AddWithValue("@PICK_UP_REF_NUM", PICK_UP_FORM_NO.Text)
                sqlComm.Parameters.AddWithValue("@SORTER", CBX_SORT.Text)
                sqlComm.Parameters.AddWithValue("@TYPE_OF_SERVICE", TYPE_SERVICE.Text)
                sqlComm.Parameters.AddWithValue("@Remarks", REMARKS.Text)
                sqlComm.Parameters.AddWithValue("@SORTED_RECEIVED_BY", TBX_RELEASED_BY.Text)
                sqlComm.Parameters.AddWithValue("@CHECKED_BY", CBX_CHKR.Text)
                sqlComm.Parameters.AddWithValue("@TOTAL_WEIGHT", Double.Parse(TOTAL_W.Text))
                sqlComm.Parameters.AddWithValue("@DELIVERY_TEAM", CBX_DLVR_TEAM.Text)
                sqlComm.Parameters.AddWithValue("@SRVC_PRICE", price_per_kg)
                sqlComm.Parameters.AddWithValue("@SRVC_TOTAL_PRICE", total_price)
                sqlComm.Parameters.AddWithValue("@AddedBy", Main.CurrentUserLoggedin)
                sqlComm.Parameters.AddWithValue("@FNB", CBX_FNB.Text)
                sqlComm.Parameters.AddWithValue("@DEPT", CBX_DEPART.Text)
                sqlComm.Parameters.AddWithValue("@STATUS", "IN PROCESS")
                sqlComm.Parameters.AddWithValue("@TTQTY ", Double.Parse(Label15.Text))
                sqlCon.Open()
                If sqlComm.ExecuteNonQuery() = 1 Then
                    MessageBox.Show("Data added successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                INSERT_ORDER_DETAILS()
                sqlCon.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub INSERT_ORDER_DETAILS()
        Dim conn As New SqlConnection(connstring)

        Dim command2 As New Data.SqlClient.SqlCommand
        Dim command3 As New Data.SqlClient.SqlCommand
        Dim ORDER As Integer
        conn.Open()
        command3.CommandText = "SELECT MAX(OrDER_ID) AS 'RDR' FROM tbl_order"
        command2.CommandText = "INSERT INTO TBL_ORDR_DETAILS (ORDR_ID,ITEMCODE,DESCRIPTION,WEIGHT_PER_PIECE,QTY,TOTAL_WEIGHT,OPEN_QTY,LineNum,CCODE,PUQTY) 
                                VALUES (@ORDR_ID,@ITEMCODE,@DESCRIPTION,@WEIGHT_PER_PIECE,@QTY,@TOTAL_WEIGHT,@OPEN_QTY,@LINENUM,@CCODE,@PUQTY)"


        command3.Connection = conn
        command3.ExecuteNonQuery()
        Dim sdr As SqlDataReader = command3.ExecuteReader()
        If (sdr.Read()) Then
            ORDER = sdr("RDR")
        End If
        sdr.Close()
        command2.Parameters.Add("@ORDR_ID", SqlDbType.Int).Value = ORDER
        command2.Parameters.Add("@ITEMCODE", SqlDbType.VarChar)
        command2.Parameters.Add("@DESCRIPTION", SqlDbType.VarChar)
        command2.Parameters.Add("@WEIGHT_PER_PIECE", SqlDbType.VarChar)
        command2.Parameters.Add("@QTY", SqlDbType.Decimal)
        command2.Parameters.Add("@TOTAL_WEIGHT", SqlDbType.Decimal)
        command2.Parameters.Add("@OPEN_QTY", SqlDbType.Decimal)
        command2.Parameters.Add("@LINENUM", SqlDbType.Int)
        command2.Parameters.Add("@CCODE", SqlDbType.VarChar).Value = CBX_CNAME.SelectedValue
        command2.Parameters.Add("@PUQTY", SqlDbType.Int)
        command2.Connection = conn
        For i As Integer = 0 To countRows - 1
            command2.Parameters(1).Value = DataGridView1.Rows(i).Cells(0).Value.ToString
            command2.Parameters(2).Value = DataGridView1.Rows(i).Cells(1).Value.ToString
            command2.Parameters(3).Value = DataGridView1.Rows(i).Cells(2).Value.ToString
            command2.Parameters(4).Value = DataGridView1.Rows(i).Cells(4).Value.ToString
            command2.Parameters(5).Value = DataGridView1.Rows(i).Cells(6).Value.ToString
            command2.Parameters(6).Value = DataGridView1.Rows(i).Cells(4).Value.ToString
            command2.Parameters(7).Value = i + 1
            command2.Parameters(9).Value = DataGridView1.Rows(i).Cells("PUQTY").Value.ToString
            command2.ExecuteNonQuery()
        Next
        conn.Close()
    End Sub
    Public Sub BindData()
        Try
            GRID_CHANGER = 1
            sum_QTY = 0
            sum_OPENQTY = 0
            Dim sqlCon = New SqlConnection(connstring)
            sqlCon.Open()
            Using (sqlCon)
                Dim sqlComm As New SqlCommand With {
                    .Connection = sqlCon,
                    .CommandText = "ShowOrder",
                    .CommandType = CommandType.StoredProcedure
                }
                sqlComm.Parameters.AddWithValue("@ID", REC_NUM)
                Using da As New SqlDataAdapter()
                    da.SelectCommand = sqlComm
                    Using sdr As SqlDataReader = sqlComm.ExecuteReader()
                        If sdr.HasRows Then
                            sdr.Read()
                            TBX_STATUS.Text = sdr("STATUS")
                            PICK_UP_FORM_NO.Text = sdr("PICK_UP_REF_NUM")
                            CBX_CNAME.Text = sdr("NAME")
                            CBX_SORT.Text = sdr("SORTER")
                            TYPE_SERVICE.Text = sdr("TYPE_OF_SERVICE")
                            DateTimePicker1.Text = sdr("DATE")
                            DateTimePiCKuP.Text = sdr("DELIVERY_DATE")
                            CBX_DLVR_TEAM.Text = sdr("DELIVERY_TEAM")
                            REMARKS.Text = sdr("Remarks")
                            TBX_RELEASED_BY.Text = sdr("SORTED_RECEIVED_BY")
                            CBX_CHKR.Text = sdr("CHECKED_BY")
                            TOTAL_W.Text = sdr("TOTAL_W")
                            CBX_FNB.Text = sdr("FNB")
                            PRINT_STAT = sdr("Printed")
                            CBX_DEPART.Text = sdr("DEPT")
                            lbl_price.Text = "Php/Kg : " & sdr("Price_per_Kg")
                            Label15.Text = sdr("TOTAL_QTY")
                            price_per_kg = sdr("Price_per_Kg")
                        Else
                            LBL_ERROR_MSG.Text = "Error: No Result found please try again"
                            ErrorBox()
                        End If
                    End Using
                    Using dt As New DataTable()
                        da.Fill(dt)
                        PREV.DataGridView2.DataSource = dt
                        Dim CNT As Integer = PREV.DataGridView2.RowCount
                        CLR_ROWS()
                        If CNT <> 0 Then
                            Dim ttl As Integer = 0
                            For Each row In PREV.DataGridView2.Rows
                                Dim price As Double = Double.Parse(row.Cells("Price_per_Kg").Value) * Double.Parse(row.Cells("WEIGHT_PER_PIECE").Value)
                                DataGridView1.Rows(ttl).Cells(0).Value = row.Cells("ITEMCODE").Value.ToString
                                DataGridView1.Rows(ttl).Cells(1).Value = row.Cells("DESCRIPTION").Value.ToString
                                DataGridView1.Rows(ttl).Cells(2).Value = row.Cells("WEIGHT_PER_PIECE").Value.ToString
                                DataGridView1.Rows(ttl).Cells(3).Value = price
                                DataGridView1.Rows(ttl).Cells(4).Value = row.Cells("QTY").Value.ToString
                                'DataGridView1.Rows(ttl).Cells(4).Style.BackColor = Color.WhiteSmoke
                                DataGridView1.Rows(ttl).Cells(5).Value = row.Cells("OPEN_QTY").Value.ToString
                                DataGridView1.Rows(ttl).Cells(6).Value = row.Cells("TOTAL_WEIGHT").Value.ToString
                                DataGridView1.Rows(ttl).Cells(7).Value = price * Double.Parse(row.Cells("QTY").Value)
                                DataGridView1.Rows(ttl).Cells("PUQTY").Value = row.Cells("PUQTY").Value.ToString
                                'DataGridView1.Rows(ttl).DefaultCellStyle.BackColor = Color.WhiteSmoke
                                DataGridView1.Columns(5).Visible = True
                                ttl += 1
                            Next
                            REC_READONLY()
                        End If
                        DataGridView1.ClearSelection()
                    End Using

                End Using
            End Using
            sqlCon.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub ORDER_DETAILS()
        bindData()
        Label8.Visible = True
        TBX_STATUS.Visible = True
        If TBX_STATUS.Text = "COMPLETED" Then
            TBX_STATUS.BackColor = Color.Blue
            TBX_STATUS.ForeColor = Color.White

            TSB_CANCEL_DOC.Enabled = False
            BTN_ITMS_SHOW.Enabled = False
            BTN_EDIT_ITEMS.Enabled = False

        ElseIf TBX_STATUS.Text = "IN PROCESS PARTIAL" Then
            TBX_STATUS.BackColor = Color.Yellow
            TBX_STATUS.ForeColor = Color.Black

            TSB_CANCEL_DOC.Enabled = False
            BTN_ITMS_SHOW.Enabled = False
            BTN_EDIT_ITEMS.Enabled = True

        ElseIf TBX_STATUS.Text = "IN PROCESS" Then
            TBX_STATUS.BackColor = Color.Green
            TBX_STATUS.ForeColor = Color.White

            TSB_CANCEL_DOC.Enabled = True
            BTN_ITMS_SHOW.Enabled = False
            BTN_EDIT_ITEMS.Enabled = True

        ElseIf TBX_STATUS.Text = "CANCELLED" Then
            TBX_STATUS.BackColor = Color.Red
            TBX_STATUS.ForeColor = Color.White

            TSB_CANCEL_DOC.Enabled = False
            BTN_ITMS_SHOW.Enabled = False
            BTN_EDIT_ITEMS.Enabled = False
        End If

        For Each row In DataGridView1.Rows
            If row.Cells(0).Value <> "" AndAlso row.Cells(1).Value <> "" Then
                sum_OPENQTY += CDbl(row.Cells(5).Value)
                sum_QTY += CDbl(row.Cells(4).Value)
            End If
        Next
        BTN_RDR_UPDT.Enabled = False
        SubtotalComputation()

    End Sub
    Public Sub CANCELORDR()
        Try
            Dim sqlCon = New SqlConnection(connstring)
            Dim rowsAffected As Integer
            Using (sqlCon)
                Dim sqlComm As New SqlCommand With {
                    .Connection = sqlCon,
                    .CommandText = "CancelOrdr",
                    .CommandType = CommandType.StoredProcedure
                }
                sqlComm.Parameters.AddWithValue("@ID", ToolStripTBX_R_NUM.Text)
                sqlCon.Open()
                'If sqlComm.ExecuteNonQuery() = 1 Then
                rowsAffected = sqlComm.ExecuteNonQuery()
                MessageBox.Show("Receiving entry no." & ToolStripTBX_R_NUM.Text & " cancellation successful", "Receiving Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information)

                sqlCon.Close()

            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click_3(sender As Object, e As EventArgs) Handles BTN_RDR_UPDT.Click
        Dim rowcheck As Integer = 0
        Dim puqty As Integer = 0
        total_price = Double.Parse(TOTAL_W.Text) * price_per_kg

        For Each dgvRow As DataGridViewRow In DataGridView1.Rows
            If dgvRow.Cells(0).Value <> "" AndAlso dgvRow.Cells(5).Value = "" OrElse dgvRow.Cells(4).Value = "0" Then
                rowcheck += 1
            End If
            If dgvRow.Cells(0).Value <> "" AndAlso dgvRow.Cells(8).Value = "" Then
                puqty += 1
            End If
        Next
        If CBX_CNAME.Text = "" Then
            LBL_ERROR_MSG.Text = "Error: Customer field required"
            ErrorBox()
            CBX_CNAME.Select()

        ElseIf CBX_DEPART.Text = "" Then
            LBL_ERROR_MSG.Text = "Error: Department field required"
            ErrorBox()
            CBX_DEPART.Select()

        ElseIf CBX_DEPART.Text = "" Then
            LBL_ERROR_MSG.Text = "Error: Department field required"
            ErrorBox()
            CBX_DEPART.Select()

        ElseIf PICK_UP_FORM_NO.Text = "" Then
            LBL_ERROR_MSG.Text = "Error: Pick-up form number field required"
            ErrorBox()
            PICK_UP_FORM_NO.Select()

        ElseIf CBX_SORT.Text = "" Then
            LBL_ERROR_MSG.Text = "Error: Sorter field required"
            ErrorBox()
            CBX_SORT.Select()

        ElseIf TYPE_SERVICE.Text = "" Then
            LBL_ERROR_MSG.Text = "Error: Service type field required"
            ErrorBox()
            TYPE_SERVICE.Select()


        ElseIf CBX_FNB.Text = "" Then
            LBL_ERROR_MSG.Text = "Error: FNB field required"
            ErrorBox()
            CBX_FNB.Select()

        ElseIf CBX_DLVR_TEAM.Text = "" Then
            LBL_ERROR_MSG.Text = "Error: Delivery team  field required"
            ErrorBox()
            CBX_DLVR_TEAM.Select()
        ElseIf DataGridView1.Rows(0).Cells(0).Value = "" Then
            LBL_ERROR_MSG.Text = "Error: No items selected!"
            ErrorBox()
        ElseIf REMARKS.Text = "" Then
            LBL_ERROR_MSG.Text = "Error: Remarks field required"
            ErrorBox()
            REMARKS.Select()
        ElseIf TBX_RELEASED_BY.Text = "" Then
            LBL_ERROR_MSG.Text = "Error: RELEASED BY field required"
            ErrorBox()
            TBX_RELEASED_BY.Select()
        ElseIf CBX_CHKR.Text = "" Then
            LBL_ERROR_MSG.Text = "Error: Checker field required"
            ErrorBox()
            CBX_CHKR.Select()
        ElseIf rowcheck > 0 Then
            LBL_ERROR_MSG.Text = "Error: Invalid quantity! please check item details"
            ErrorBox()
        ElseIf puqty > 0 Then
            LBL_ERROR_MSG.Text = "Error: Invalid Pickup quantity! please check item details"
            ErrorBox()
        Else
            Dim lineNum As Integer = 0
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to update this Receiving entry?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If result = DialogResult.Yes Then
                Dim table As New DataTable
                Try
                    Dim conn As New SqlConnection(connstring)

                    Dim MyCommand As New SqlCommand
                    conn.Open()
                    For Each row In DataGridView1.Rows
                        If row.Cells(0).Value <> "" AndAlso row.Cells(1).Value <> "" Then
                            Dim iCODE As String = row.Cells(0).Value.ToString.Replace(" ", "")
                            Dim Adjvalue As Double
                            lineNum += 1
                            If row.Cells("Adjustment").Value = "" Then
                                Adjvalue = 0
                            Else
                                Adjvalue = Double.Parse(row.Cells("Adjustment").Value)
                            End If
                            'MessageBox.Show(Adjvalue)
                            MyCommand = New SqlCommand("INSERTFROMDG", conn) With {
                                .CommandType = CommandType.StoredProcedure
                            }
                            MyCommand.Parameters.AddWithValue("@ORDR_ID", ToolStripTBX_R_NUM.Text)
                            MyCommand.Parameters.AddWithValue("@ITEMCODE", iCODE)
                            MyCommand.Parameters.AddWithValue("@DESCRIPTION", row.Cells(1).Value)
                            MyCommand.Parameters.AddWithValue("@WEIGHT_PER_PIECE", row.Cells(2).Value)
                            MyCommand.Parameters.AddWithValue("@QTY", Double.Parse(row.Cells(4).Value))
                            MyCommand.Parameters.AddWithValue("@OPEN_QTY", row.Cells(5).Value)
                            MyCommand.Parameters.AddWithValue("@TOTAL_WEIGHT", row.Cells(6).Value)
                            MyCommand.Parameters.AddWithValue("@CCODE", CBX_CNAME.SelectedValue)
                            MyCommand.Parameters.AddWithValue("@PRN1", PICK_UP_FORM_NO.Text)
                            MyCommand.Parameters.AddWithValue("@STR1", CBX_SORT.Text)
                            MyCommand.Parameters.AddWithValue("@TOS1", TYPE_SERVICE.Text)
                            MyCommand.Parameters.AddWithValue("@REM1", REMARKS.Text)
                            MyCommand.Parameters.AddWithValue("@SRB1", TBX_RELEASED_BY.Text)
                            MyCommand.Parameters.AddWithValue("@CB1", CBX_CHKR.Text)
                            MyCommand.Parameters.AddWithValue("@DT1", CBX_DLVR_TEAM.Text)
                            MyCommand.Parameters.AddWithValue("@DEPART", CBX_DEPART.Text)
                            MyCommand.Parameters.AddWithValue("@Loggedin", Main.CurrentUserLoggedin)
                            MyCommand.Parameters.AddWithValue("@PricePerKg", price_per_kg)
                            MyCommand.Parameters.AddWithValue("@TTQTY", price_per_kg)
                            MyCommand.Parameters.AddWithValue("@ADJ_QTY", Adjvalue)
                            MyCommand.Parameters.AddWithValue("@PUQTY", row.Cells(8).Value)
                            MyCommand.ExecuteNonQuery()
                        End If
                    Next
                    conn.Close()
                    BTN_RDR_UPDT.Enabled = False
                    LBL_ERROR_MSG.Text = "Success: Receiving entry update successful"
                    SuccessBox()
                    BTN_PREV_ORDR_Click(sender, e)
                Catch ex As Exception
                    MsgBox("CRITICAL ERROR :" & ex.Message)
                End Try

            End If
        End If


    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        If CheckBox1.Checked = True Then
            REC_CLEARTEXT()
            DataGridView1.DataSource = Nothing
            PICK_UP_FORM_NO.BackColor = Color.LemonChiffon

            REC_ENABLE()
            BTN_ITMS_SHOW.Enabled = False
            Button2.Enabled = False
            DataGridView1.ClearSelection()
        Else

            PICK_UP_FORM_NO.BackColor = Color.White

            DataGridView1.ClearSelection()
        End If
    End Sub

    Private Sub TYPE_SERVICE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TYPE_SERVICE.KeyPress, CBX_CNAME.KeyPress, CBX_CHKR.KeyPress, CBX_SORT.KeyPress, CBX_DLVR_TEAM.KeyPress
        e.Handled = True
    End Sub

    Private Sub Trgger()
        If ToolStripTBX_R_NUM.Text <> "" Then
            REC_NUM = ToolStripTBX_R_NUM.Text
            ORDER_DETAILS()
            REC_READONLY()
        End If
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs)
        LBL_ERROR_MSG.Text = "Error: No Records found!"
        ErrorBox()
    End Sub

    Private Sub DataGridView1_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseDoubleClick
        If DataGridView1.SelectedRows.Count > 0 Then ' Check if a row is selected
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0) ' Get the selected row

            ' Ask the user to confirm the deletion
            Dim confirm As DialogResult = MessageBox.Show("Are you sure you want to delete this row?", "Confirm Deletion", MessageBoxButtons.YesNo)

            If confirm = DialogResult.Yes Then ' If the user confirms the deletion

                If TBX_STATUS.Text <> "" Then
                    Try
                        Dim conn1 As New SqlConnection(connstring)
                        Dim OrdrID As Integer = ToolStripTBX_R_NUM.Text
                        Dim itmCODE As String = selectedRow.Cells(0).Value.ToString.Replace(" ", "")
                        Dim LogedUser As String = Main.CurrentUserLoggedin
                        conn1.Open()
                        Using command1 As New SqlCommand
                            command1.CommandText = "INSERT INTO TBL_TRAIL_ORDR_DETAILS([ORDR_ID],[DESCRIPTION],[WEIGHT_PER_PIECE],[QTY],[TOTAL_WEIGHT],[OPEN_QTY],[CCODE],[ITEMCODE],[EDITEDBY])
                        Select [ORDR_ID],[DESCRIPTION],[WEIGHT_PER_PIECE],[QTY],[TOTAL_WEIGHT],[OPEN_QTY],[CCODE],[ITEMCODE],'" & LogedUser & "'
		                FROM TBL_ORDR_DETAILS WHERE ORDR_ID=" & OrdrID & " AND ITEMCODE='" & itmCODE & "'"
                            command1.Connection = conn1
                            command1.ExecuteNonQuery()
                        End Using
                        Using command33 As New SqlCommand
                            command33.CommandText = "DELETE FROM TBL_ORDR_DETAILS WHERE ORDR_ID=" & OrdrID & " AND ITEMCODE='" & itmCODE & "'"
                            command33.Connection = conn1
                            command33.ExecuteNonQuery()
                        End Using
                        conn1.Close()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try

                End If
                Button5_Click(sender, e)
                DataGridView1.ClearSelection()
            End If
        End If
    End Sub
    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        'If e.KeyData = Keys.Delete Then
        '    Dim rowindex = DataGridView1.CurrentRow.Index
        '    DataGridView1.Rows(rowindex).Selected = True
        '    Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this item?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)
        '    If result = DialogResult.Yes Then
        '        If TBX_STATUS.Text <> "" Then
        '            Try
        '                Dim conn1 As New SqlConnection(connstring)
        '                Dim OrdrID As Integer = ToolStripTBX_R_NUM.Text
        '                Dim itmCODE As String = DataGridView1.Rows(rowindex).Cells(0).Value.ToString.Replace(" ", "")
        '                Dim LogedUser As String = Main.CurrentUserLoggedin
        '                conn1.Open()
        '                Using command1 As New SqlCommand
        '                    command1.CommandText = "INSERT INTO TBL_TRAIL_ORDR_DETAILS([ORDR_ID],[DESCRIPTION],[WEIGHT_PER_PIECE],[QTY],[TOTAL_WEIGHT],[OPEN_QTY],[CCODE],[ITEMCODE],[EDITEDBY])
        '                Select [ORDR_ID],[DESCRIPTION],[WEIGHT_PER_PIECE],[QTY],[TOTAL_WEIGHT],[OPEN_QTY],[CCODE],[ITEMCODE],'" & LogedUser & "'
        '          FROM TBL_ORDR_DETAILS WHERE ORDR_ID=" & OrdrID & " AND ITEMCODE='" & itmCODE & "'"
        '                    command1.Connection = conn1
        '                    command1.ExecuteNonQuery()
        '                End Using
        '                Using command33 As New SqlCommand
        '                    command33.CommandText = "DELETE FROM TBL_ORDR_DETAILS WHERE ORDR_ID=" & OrdrID & " AND ITEMCODE='" & itmCODE & "'"
        '                    command33.Connection = conn1
        '                    command33.ExecuteNonQuery()
        '                End Using
        '                conn1.Close()
        '            Catch ex As Exception
        '                MessageBox.Show(ex.Message)
        '            End Try

        '        End If
        '        Button5_Click(sender, e)
        '        DataGridView1.ClearSelection()
        '    End If

        'End If
    End Sub
    Private Sub DataGridView1_ColumnAdded(sender As Object, e As DataGridViewColumnEventArgs) Handles DataGridView1.ColumnAdded
        e.Column.SortMode = DataGridViewColumnSortMode.NotSortable
    End Sub
    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        CHCKER()

        If TBX_STATUS.Text = "" Then
            GRID_CHANGER = 0
        End If

        Try
            If e.ColumnIndex = 4 AndAlso GRID_CHANGER = 0 Then
                Dim I As Integer
                With DataGridView1
                    If e.RowIndex <= countRows - 1 Then
                        I = .CurrentRow.Index
                        If .Rows(I).Cells(4).Value = "" Then
                            .Rows(I).Cells(4).Value = "0"
                        End If
                        .Rows(I).Cells(7).Value = FormatNumber(Double.Parse(.Rows(I).Cells(4).Value) * Double.Parse(.Rows(I).Cells(3).Value), 2)
                        .Rows(I).Cells(6).Value = FormatNumber(Double.Parse(.Rows(I).Cells(4).Value) * Double.Parse(.Rows(I).Cells(2).Value), 2)
                        .Rows(I).Cells(5).Value = FormatNumber(.Rows(I).Cells(4).Value, 2)
                        SubtotalComputation()
                    End If

                End With
            End If
            If e.ColumnIndex = 9 Then
                Try
                    Dim I As Integer
                    With DataGridView1
                        If e.RowIndex <= countRows - 1 Then
                            I = .CurrentRow.Index
                            If IsDBNull(.Rows(I).Cells(9).Value) Then
                                .Rows(I).Cells(9).Value = 0
                            End If

                            Dim VALs As Double = CDbl(Val(.Rows(I).Cells(4).Value)) + CDbl(Val(.Rows(I).Cells(9).Value))
                            If VALs < 0 Then
                                BTN_RDR_UPDT.Enabled = False
                                .Rows(I).DefaultCellStyle.ForeColor = Color.Red
                                MsgBox("Adjustment error negative quatity must not be lower than -" & .Rows(I).Cells(4).Value & ".")
                            Else
                                BTN_RDR_UPDT.Enabled = Enabled
                                .Rows(I).DefaultCellStyle.ForeColor = Color.Black
                            End If
                        End If
                    End With
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView1_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellLeave
        CHCKER()

        If TBX_STATUS.Text = "" Then
            GRID_CHANGER = 0
        End If

        Try
            If e.ColumnIndex = 4 AndAlso GRID_CHANGER = 0 Then
                Dim I As Integer
                With DataGridView1
                    If e.RowIndex <= countRows - 1 Then
                        I = .CurrentRow.Index
                        If .Rows(I).Cells(8).Value = "" Then
                            .Rows(I).Cells(8).Value = .Rows(I).Cells(4).Value
                        End If
                    End If
                End With
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView1_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
        If DataGridView1.IsCurrentCellDirty Then
            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
            'Handle the cell change event
            'Do something...
        End If
    End Sub

    Private Sub DataGridView1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        If DataGridView1.CurrentCell.ColumnIndex = 3 Or DataGridView1.CurrentCell.ColumnIndex = 8 Then
            AddHandler CType(e.Control, TextBox).KeyPress, AddressOf TextBox_keyPress
        ElseIf DataGridView1.CurrentCell.ColumnIndex = 6 Then
            AddHandler CType(e.Control, TextBox).KeyPress, AddressOf TextBox_keyPress
        End If
    End Sub

    Private Sub TextBox_keyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)

        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Or (e.KeyChar = "-") Then
            e.Handled = False
        ElseIf e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub
    Public Sub CHCKER()
        countRows = 0
        For Each dgvRow As DataGridViewRow In DataGridView1.Rows
            If dgvRow.Cells(0).Value <> "" AndAlso dgvRow.Cells(1).Value <> "" Then
                countRows += 1
            End If
        Next
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles BTN_TOTAL.Click

    End Sub
    Private Sub ClearSelectedRowAndMoveUp()
        ' Get the index of the selected row.
        Dim rowIndex As Integer = DataGridView1.SelectedCells(0).RowIndex
        ' Clear the cells of the selected row.
        For Each cell As DataGridViewCell In DataGridView1.Rows(rowIndex).Cells
            cell.Value = Nothing
        Next
        ' Move up the contents of the rows below it where the cell is not empty except for the last row.
        For i As Integer = rowIndex + 1 To DataGridView1.Rows.Count - 1
            Dim row As DataGridViewRow = DataGridView1.Rows(i)
            For Each cell As DataGridViewCell In row.Cells
                If Not String.IsNullOrEmpty(cell.Value) AndAlso i < DataGridView1.Rows.Count - 1 Then
                    DataGridView1.Rows(i - 1).Cells(cell.ColumnIndex).Value = cell.Value
                    cell.Value = Nothing
                End If
            Next
        Next
    End Sub
    Public Sub SubtotalComputation()
        Try
            Dim tot As Double = 0
            Dim tkg As Double = 0
            Dim tamt As Double = 0
            For Each dgvRow As DataGridViewRow In DataGridView1.Rows
                If dgvRow.Cells(5).Value <> "" AndAlso dgvRow.Cells(2).Value <> "" Then
                    tot += CDbl(dgvRow.Cells(6).Value)
                    tamt += CDbl(dgvRow.Cells(7).Value)
                    tkg += CDbl(dgvRow.Cells(4).Value)
                End If
            Next
            DataGridView1.Rows(10).Cells(6).Value = FormatNumber(tot, 2)
            DataGridView1.Rows(10).Cells(7).Value = FormatNumber(tamt, 2)
            DataGridView1.Rows(10).Cells(5).Value = FormatNumber(tkg, 2)
            DataGridView1.Rows(10).Cells(4).Value = FormatNumber(tkg, 2)
            TOTAL_W.Text = FormatNumber(tot, 2)
            Label15.Text = FormatNumber(tkg, 2)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles BTN_DEL_ROWS.Click
        GRID_CHANGER = 1
        ClearSelectedRowAndMoveUp()
        For Each dgvRow As DataGridViewRow In DataGridView1.Rows
            If dgvRow.Cells(0).Value = "" AndAlso dgvRow.Cells(1).Value = "" Then
                dgvRow.DefaultCellStyle.BackColor = Color.WhiteSmoke
                dgvRow.Cells(4).Style.BackColor = Color.WhiteSmoke
                dgvRow.Cells(4).ReadOnly = True
                dgvRow.Cells(8).Style.BackColor = Color.WhiteSmoke
                dgvRow.Cells(8).ReadOnly = True
            End If
        Next
        SubtotalComputation()

    End Sub
    Private Sub MyDGV_RowPostPaint(sender As Object,
    e As DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint

        Dim grid As DataGridView = CType(sender, DataGridView)
        Dim rowIdx As String
        If e.RowIndex + 1 <> 11 Then
            rowIdx = (e.RowIndex + 1).ToString()
        Else
            rowIdx = ""
        End If

        Dim rowFont As New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

        Dim centerFormat = New StringFormat With {
            .Alignment = StringAlignment.Far,
            .LineAlignment = StringAlignment.Near
        }

        Dim headerBounds As Rectangle = New Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height)
        e.Graphics.DrawString(rowIdx, rowFont, SystemBrushes.ControlText, headerBounds, centerFormat)
    End Sub

    Private Sub ToolStripTBX_R_NUM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ToolStripTBX_R_NUM.KeyPress
        If e.KeyChar = "."c Then
            e.Handled = (CType(sender, TextBox).Text.IndexOf("."c) <> -1)
        ElseIf e.KeyChar <> ControlChars.Back Then
            e.Handled = ("0123456789".IndexOf(e.KeyChar) = -1)
        End If
    End Sub
    Private Sub Button4_Click_2(sender As Object, e As EventArgs) Handles ButtonDrefHidden.Click
        If ToolStripTBX_R_NUM.Text <> "" Then
            REC_NUM = ToolStripTBX_R_NUM.Text
            PREV.DataGridView2.DataSource = Nothing
            ORDER_DETAILS()
            REC_READONLY()
        End If
    End Sub
    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles TSBTN_PRNT.Click
        If PRINT_STAT <> "Y" Then
            Try
                Dim conn1 As New SqlConnection(connstring)
                Dim scode As Integer = ToolStripTBX_R_NUM.Text
                Using command33 As New SqlCommand
                    command33.CommandText = "UPDATE tbl_order SET Printed='Y' WHERE OrDER_ID=" & scode & ""
                    conn1.Open()
                    command33.Connection = conn1
                    command33.ExecuteNonQuery()
                    Dim sdrr As SqlDataReader = command33.ExecuteReader()
                    sdrr.Close()
                End Using
                conn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
        printauto()
        'printing.ShowDialog()


    End Sub

    Private Sub TSB_CANCEL_DOC_Click(sender As Object, e As EventArgs) Handles TSB_CANCEL_DOC.Click

        If TBX_STATUS.Text = "IN PROCESS" AndAlso sum_OPENQTY = sum_QTY Then
            Main.AUTHORIZE = 0
            AUTHORIZATION.ShowDialog()
            If Main.AUTHORIZE = 1 Then
                CANCELORDR()
                ORDER_DETAILS()
            End If
        Else
            LBL_ERROR_MSG.Text = "Error: Please canacel existing delivery for this entry first"
            ErrorBox()
        End If
    End Sub

    Private Sub CBX_CNAME_TextChanged(sender As Object, e As EventArgs) Handles CBX_CNAME.TextChanged
        ITEMS.DataGridView1.DataSource = Nothing
        CBX_DEPART.Text = Nothing
        If TBX_STATUS.Text = "" Then
            TYPE_SERVICE.Text = Nothing
        End If

    End Sub
    Private Sub BTN_PREV_ORDR_Click(sender As Object, e As EventArgs) Handles BTN_PREV_ORDR.Click
        CLR_ROWS()
        REC_NUM = ToolStripTBX_R_NUM.Text
        ORDER_DETAILS()
    End Sub

    Private Sub Form1_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        Me.ActiveControl = Nothing
    End Sub

    Private Sub DataGridView1_Leave(sender As Object, e As EventArgs) Handles DataGridView1.Leave
        DataGridView1.ClearSelection()
    End Sub
    Private Sub CBX_CNAME_Leave(sender As Object, e As EventArgs) Handles CBX_CNAME.Leave
        If CBX_CNAME.SelectedIndex <> -1 Then
            BTN_ITMS_SHOW.Enabled = True
        Else
            BTN_ITMS_SHOW.Enabled = False
        End If
        If CBX_CNAME.Text = "VENUE88 HOTEL AND EVENTS PLACE" Then
            DataGridView1.Columns(2).ReadOnly = False
        Else
            DataGridView1.Columns(2).ReadOnly = True
        End If
    End Sub


    Private Sub CBX_CHKR_Leave(sender As Object, e As EventArgs) Handles CBX_CHKR.Leave
        If CBX_CHKR.Text <> "" Then
            Dim resultIndex As Integer = CBX_CHKR.FindStringExact(CBX_CHKR.Text)
            If resultIndex = -1 Then
                LBL_ERROR_MSG.Text = "Error: Checker name does not exist! Please try again"
                ErrorBox()
                CBX_CHKR.Select()
            End If
        End If

    End Sub
    Private Sub PICK_UP_FORM_NO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PICK_UP_FORM_NO.Validating


        'Dim R1 As String
        Dim res As Integer = 0

        If PICK_UP_FORM_NO.Text <> "" AndAlso TBX_STATUS.Text = "" AndAlso CheckBox1.Checked = False Then
            Dim sqlCon_C = New SqlConnection(connstring)

            If IsNumeric(PICK_UP_FORM_NO.Text(0)) Then
            Else
                Try
                    Dim cmd1 As New SqlCommand("SELECT PU_INDEX from tbl_customer WHERE CUSTOMER_CODE='" & CBX_CNAME.SelectedValue.ToString & "'", sqlCon_C)
                    If (sqlCon_C.State <> ConnectionState.Open) Then
                        sqlCon_C.Open()
                    End If
                    Dim sdr1 As SqlDataReader = cmd1.ExecuteReader()
                    sdr1.Read()
                    If sdr1("PU_INDEX") <> PICK_UP_FORM_NO.Text(0) Then
                        LBL_ERROR_MSG.Text = "Warning: Pick UP reference number should begin with '" & sdr1("PU_INDEX") & "' for  " & CBX_CNAME.Text & "."
                        ErrorBox()
                        e.Cancel = True
                    End If
                    sdr1.Close()
                    sqlCon_C.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            End If

            Try

                Dim cmd As New SqlCommand("SELECT PICK_UP_REF_NUM FROM tbl_order WHERE STATUS <>'CANCELLED' AND PICK_UP_REF_NUM='" & PICK_UP_FORM_NO.Text & "'", sqlCon_C)
                If (sqlCon_C.State <> ConnectionState.Open) Then
                    sqlCon_C.Open()
                End If
                Dim sdr As SqlDataReader = cmd.ExecuteReader()
                If sdr.HasRows Then
                    res = 1
                End If
                sqlCon_C.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            If res <> 0 Then
                LBL_ERROR_MSG.Text = "Warning: Pick UP reference number " & PICK_UP_FORM_NO.Text & " already used, please enter unused Pick UP reference number."
                ErrorBox()
                e.Cancel = True
            End If
        End If

    End Sub

    Public Sub NewFrm()

        Dim column As New DataGridViewTextBoxColumn With {
                        .HeaderText = "Adjustment",
                        .Name = "Adjustment",
                        .Width = 20
                    }

        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns.Add(column)

        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Cells(0).Value <> "" AndAlso DataGridView1.Rows(i).Cells(1).Value <> "" Then
                DataGridView1.Rows(i).Cells("Adjustment").Value = "0"
            End If
            If DataGridView1.Rows(i).Cells(0).Value <> "" AndAlso DataGridView1.Rows(i).Cells(4).Value = DataGridView1.Rows(i).Cells(5).Value Then
                DataGridView1.Rows(i).Cells("Adjustment").ReadOnly = False
                DataGridView1.Rows(i).Cells("Adjustment").Style.BackColor = Color.LemonChiffon
            Else
                DataGridView1.Rows(i).Cells("Adjustment").ReadOnly = True
            End If
        Next

        BTN_RDR_UPDT.Enabled = True
        REC_ENABLE()
        Button2.Enabled = False
        BTN_EDIT_ITEMS.Enabled = False
        BTN_ITMS_SHOW.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BTN_EDIT_ITEMS.Click
        Main.AUTHORIZE = 0
        AUTHORIZATION.ShowDialog()
        If Main.AUTHORIZE = 1 Then

            NewFrm()




        End If
    End Sub

    Private Sub TSB_EXIT_Click(sender As Object, e As EventArgs) Handles TSB_EXIT.Click
        Me.Dispose()
    End Sub

    Private Sub CBX_SORT_Enter(sender As Object, e As EventArgs) Handles CBX_SORT.Enter
        If TBX_STATUS.Text <> "COMPLETED" Then
            EMPList.CDX = "REC_SORT"
            EMPList.ShowDialog()
        End If
    End Sub

    Private Sub CBX_DLVR_TEAM_Enter(sender As Object, e As EventArgs) Handles CBX_DLVR_TEAM.Enter
        If TBX_STATUS.Text <> "COMPLETED" Then
            EMPList.CDX = "REC_DEL_TEAM"
            EMPList.ShowDialog()
        End If
    End Sub

    Private Sub CBX_SORT_Click(sender As Object, e As EventArgs) Handles CBX_SORT.Click
        If TBX_STATUS.Text <> "COMPLETED" Then
            EMPList.CDX = "REC_SORT"
            EMPList.ShowDialog()
        End If
    End Sub

    Private Sub CBX_DLVR_TEAM_Click(sender As Object, e As EventArgs) Handles CBX_DLVR_TEAM.Click
        If TBX_STATUS.Text <> "COMPLETED" Then
            EMPList.CDX = "REC_DEL_TEAM"
            EMPList.ShowDialog()
        End If
    End Sub

    Private Sub CBX_DEPART_GotFocus(sender As Object, e As EventArgs) Handles CBX_DEPART.GotFocus
        If CBX_CNAME.Text <> "" Then
            CBX_DEPART.DataSource = SrC_DEPARTMENT()
            CBX_DEPART.ValueMember = "dep_ID"
            CBX_DEPART.DisplayMember = "DEP_NAME"
            CBX_DEPART.SelectedIndex = -1
        End If
    End Sub
    Private Sub TYPE_SERVICE_GotFocus(sender As Object, e As EventArgs) Handles TYPE_SERVICE.GotFocus
        If CBX_CNAME.Text <> "" Then
            TYPE_SERVICE.DataSource = SrC_ServiceType()
            TYPE_SERVICE.ValueMember = "service_code"
            TYPE_SERVICE.DisplayMember = "service_type"
            TYPE_SERVICE.SelectedIndex = -1
        End If
    End Sub

    Private Sub CBX_FNB_TextChanged(sender As Object, e As EventArgs) Handles CBX_FNB.TextChanged
        If TBX_STATUS.Text = "" Then
            TYPE_SERVICE.Text = Nothing
            lbl_price.Text = ""
        End If
    End Sub
    Private Sub TYPE_SERVICE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TYPE_SERVICE.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        SERVICES.ShowDialog()
    End Sub



    Private Sub CBX_CNAME_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBX_CNAME.SelectedIndexChanged

        If CBX_CNAME.Text <> "" Then
            CCODE = CBX_CNAME.SelectedIndex.ToString
        End If

    End Sub

    Private Sub TYPE_SERVICE_Leave(sender As Object, e As EventArgs) Handles TYPE_SERVICE.Leave

    End Sub

    Private Sub TYPE_SERVICE_TextChanged(sender As Object, e As EventArgs) Handles TYPE_SERVICE.TextChanged

        If CBX_FNB.Text <> "" AndAlso TYPE_SERVICE.Text <> "" Then
            Try
                Dim conn1 As New SqlConnection(connstring)
                Dim scode As String = TYPE_SERVICE.SelectedValue.ToString
                Using command33 As New SqlCommand
                    command33.CommandText = "select service_price,service_price_fnb from tbl_services where  service_code='" & scode & "'"
                    conn1.Open()
                    command33.Connection = conn1
                    command33.ExecuteNonQuery()
                    Dim sdrr As SqlDataReader = command33.ExecuteReader()
                    If (sdrr.Read()) Then
                        If CBX_FNB.Text = "Y" Then
                            price_per_kg = sdrr("service_price_fnb")
                            lbl_price.Text = "Php/Kg : " & sdrr("service_price_fnb")
                        ElseIf CBX_FNB.Text = "N" Then
                            price_per_kg = sdrr("service_price")
                            lbl_price.Text = "Php/Kg : " & sdrr("service_price")
                        Else
                            price_per_kg = 0
                            lbl_price.Text = ""
                        End If
                    End If
                    sdrr.Close()
                End Using
                conn1.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

    End Sub

    Private Sub PICK_UP_FORM_NO_Leave(sender As Object, e As EventArgs) Handles PICK_UP_FORM_NO.Leave

    End Sub
End Class
