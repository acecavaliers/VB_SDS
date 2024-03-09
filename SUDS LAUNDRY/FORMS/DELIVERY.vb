Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports System.Data.OleDb
Imports System.ComponentModel

Public Class DELIVERY
    Public connstring As String = ConfigurationManager.ConnectionStrings("SUDS_ConnectionString").ConnectionString
    Public DEL_NUM As Integer = 0
    Public DEL_max As Integer = 0
    Public REFERENCE_NUM As Integer = 0
    Public DEL_STAT As String
    Public PRINT_STAT As String
    Dim dr_status As String
    Public price_per_kg As Double
    Dim SOA_DR As Integer = 0
    Dim SOA_PAID As String
    Public Function SrC_CHKR() As DataTable
        Dim dt_items As New DataTable
        Using conn As New SqlConnection(connstring)
            Using cmd As New SqlCommand("SELECT * FROM Tbl_users  WHERE  STATUS='ACTIVE'  and uname not in('ADMIN','USER') ORDER BY name", conn)
                conn.Open()
                Dim RDR As SqlDataReader = cmd.ExecuteReader()
                dt_items.Load(RDR)
            End Using
        End Using
        Return dt_items
    End Function

    Public Sub CLEAR()

        CBX_D_CNAME.Text = ""
        D_PICKUPFORM.Text = ""
        CBX_D_SORT.Text = Nothing
        D_TYPE_SERVE.Text = Nothing
        D_DATE.Text = Nothing
        D_DELFORMNUM.Text = Nothing
        CBX_D_DEL_TEAM.Text = Nothing
        D_REF.Text = Nothing
        CBX_D_R_SORT.Text = Nothing
        CBX_D_CHK.Text = Nothing
        D_REMARKS.Text = Nothing
        ToolStrip_DEL_DNUM.Text = Nothing
        CheckBox1.Checked = False
        DataGridView1.DataSource = Nothing
        'DataGridView1.ReadOnly = False
        TBX_STATUS.Text = Nothing
        TBX_STATUS.BackColor = Color.White
        CBX_FNB.Text = Nothing
        CBX_D_DEPART.Text = Nothing
        LBL_QTY.Text = "0.00"
        LBL_Price_per_Kg.Text = Nothing

    End Sub
    Public Sub READ_ONLY()
        CBX_D_CNAME.Enabled = False
        D_PICKUPFORM.Enabled = False
        CBX_D_SORT.Enabled = False
        D_TYPE_SERVE.Enabled = False
        D_DATE.Enabled = False
        D_DELFORMNUM.Enabled = False
        D_REF.Enabled = False
        CBX_D_R_SORT.Enabled = False
        CBX_D_CHK.Enabled = False
        D_REMARKS.Enabled = False
        ToolStrip_DEL_DNUM.Enabled = False
        CheckBox1.Enabled = False
        DataGridView1.ReadOnly = True
        ButtonSAVE_DEL.Enabled = False
        BTN_COPYFROMRECEIVING.Enabled = False
        CBX_D_DEL_TEAM.Enabled = False
    End Sub
    Public Sub READ_FALSE()
        CBX_D_CNAME.Enabled = True
        CBX_D_DEL_TEAM.Enabled = True
        D_PICKUPFORM.Enabled = True
        CBX_D_SORT.Enabled = True
        'D_TYPE_SERVE.Enabled = True
        D_DATE.Enabled = True
        D_DELFORMNUM.Enabled = True
        D_REF.Enabled = True
        CBX_D_R_SORT.Enabled = True
        CBX_D_CHK.Enabled = True
        D_REMARKS.Enabled = True
        ToolStrip_DEL_DNUM.Enabled = True
        CheckBox1.Enabled = True
        DataGridView1.Enabled = True
        DataGridView1.ReadOnly = True
        ButtonSAVE_DEL.Enabled = True
        BTN_COPYFROMRECEIVING.Enabled = True
    End Sub

    Private Sub ToolStrip1_ItemAdded(sender As Object, e As ToolStripItemEventArgs) Handles ToolStrip2.ItemAdded
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
    Public Function CUSTOMERSLIST() As DataTable
        Dim dt_items As New DataTable
        Using conn As New SqlConnection(connstring)
            Using cmd As New SqlCommand(" SELECT DISTINCT T0.CCODE,NAME FROM tbl_order T0
                                          INNER JOIN tbl_customer T1 ON T0.CCODE=T1.CUSTOMER_CODE
                                          INNER JOIN TBL_ORDR_DETAILS T2 ON T2.ORDR_ID=T0.OrDER_ID
                                          WHERE OPEN_QTY<>0", conn)
                conn.Open()
                Dim RDR As SqlDataReader = cmd.ExecuteReader()
                dt_items.Load(RDR)
            End Using
        End Using
        Return dt_items
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        PANEL_ERROR.Visible = False ' Hide the panel
        Timer1.Stop()
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


    Private Sub DELIVERY_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()

        DateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss tt"
        ButtonSAVE_DEL.Location = New Point(3, 1)
        BTN_CONFRM_DLVR.Location = New Point(172, 1)
        CBX_D_CHK.DataSource = SrC_CHKR()
        CBX_D_CHK.ValueMember = "NAME"
        CBX_D_CHK.DisplayMember = "NAME"
        CBX_D_CHK.SelectedIndex = -1
        DATA_G()
        DataGridView1.ClearSelection()
        DataGridView1.Rows(10).ReadOnly = True
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray
        DataGridView1.Rows(10).DefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        DataGridView1.Rows(10).DefaultCellStyle.BackColor = Color.DarkGray
        DataGridView1.Rows(10).Cells(1).Value = "Total"

        If Form1.drSrc <> 0 Then
            DELIVER_DETAILS()
            ToolStrip_DEL_DNUM.Text = DEL_NUM
        End If

    End Sub
    Public Sub DATA_G()
        Dim ITC, TNM, WP, PP, QTY, OPQ, T, TAMT As New DataGridViewTextBoxColumn

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

        For ttl As Integer = 1 To 11
            DataGridView1.Rows.Add("", "", "", "", "", "")
        Next
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.Columns(0).ReadOnly = True
        DataGridView1.Columns.Item("ITEMCODE").Width = 15
        DataGridView1.Columns(1).ReadOnly = True
        DataGridView1.Columns.Item("TNM").Width = 60
        DataGridView1.Columns(2).ReadOnly = True
        DataGridView1.Columns.Item("WEIGHTPIECE").Width = 18
        DataGridView1.Columns.Item("PRICE").Width = 15
        DataGridView1.Columns(3).ReadOnly = True
        DataGridView1.Columns.Item("QTY").Width = 15
        DataGridView1.Columns(4).ReadOnly = True
        DataGridView1.Columns.Item("OPENQTY").Width = 15
        DataGridView1.Columns(5).ReadOnly = True
        DataGridView1.Columns.Item("TOTALWEIGHT").Width = 15
        DataGridView1.Columns.Item("TOTALAMOUNT").Width = 100
        DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


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
    Public Sub CLR_ROWS()
        CheckBox1.Checked = False
        For Each row As DataGridViewRow In DataGridView1.Rows
            For Each cell As DataGridViewCell In row.Cells
                cell.Value = Nothing
            Next
            If row.Index <> 10 Then
                row.DefaultCellStyle.BackColor = Color.WhiteSmoke
                row.Cells(4).Style.BackColor = Color.WhiteSmoke
            End If
        Next
        DataGridView1.Rows(10).Cells(1).Value = "Total"
        DataGridView1.Rows(10).DefaultCellStyle.BackColor = Color.DarkGray
    End Sub
    Public Sub BindData()
        DataGridView1.Enabled = True
        DataGridView1.ReadOnly = False

        Try
            Dim REC_NUM = D_REF.Text
            Dim sqlCon = New SqlConnection(connstring)
            sqlCon.Open()
            Using (sqlCon)
                Dim sqlComm As New SqlCommand With {
                    .Connection = sqlCon,
                    .CommandText = "SHOW_ODR_FOR_DEL",
                    .CommandType = CommandType.StoredProcedure
                }
                sqlComm.Parameters.AddWithValue("@ID", REC_NUM)
                Using da As New SqlDataAdapter()
                    da.SelectCommand = sqlComm
                    Using sdr As SqlDataReader = sqlComm.ExecuteReader()
                        If sdr.HasRows Then
                            sdr.Read()
                            D_PICKUPFORM.Text = sdr("PICK_UP_REF_NUM")
                            CBX_D_DEPART.Text = sdr("DEPT")
                            D_TYPE_SERVE.Text = sdr("TYPE_OF_SERVICE")
                            D_REMARKS.Text = sdr("Remarks")
                            CBX_FNB.Text = sdr("FNB")
                            LBL_QTY.Text = sdr("TOTAL_QTY")
                            price_per_kg = sdr("Price_per_Kg")
                            LBL_Price_per_Kg.Text = "Php/Kg : " & price_per_kg
                        Else
                            LBL_ERROR_MSG.Text = "Error: No Result found please try again"
                            ErrorBox()
                        End If
                    End Using
                    Using dt As New DataTable()
                        da.Fill(dt)
                        PREV_DLVR.DataGridView2.DataSource = dt
                        Dim CNT As Integer = PREV_DLVR.DataGridView2.RowCount
                        CLR_ROWS()
                        If CNT <> 0 Then
                            Dim ttl As Integer = 0
                            For Each row In PREV_DLVR.DataGridView2.Rows
                                Dim price As Double = Double.Parse(row.Cells("Price_per_Kg").Value) * Double.Parse(row.Cells("WEIGHT_PER_PIECE").Value)
                                DataGridView1.Rows(ttl).Cells(0).Value = row.Cells("ITEMCODE").Value.ToString
                                DataGridView1.Rows(ttl).Cells(1).Value = row.Cells("DESCRIPTION").Value.ToString
                                DataGridView1.Rows(ttl).Cells(2).Value = row.Cells("WEIGHT_PER_PIECE").Value.ToString
                                DataGridView1.Rows(ttl).Cells(3).Value = FormatNumber(price, 2)
                                DataGridView1.Rows(ttl).Cells(4).Value = row.Cells("OPEN_QTY").Value.ToString
                                DataGridView1.Rows(ttl).Cells(4).Style.BackColor = Color.WhiteSmoke
                                DataGridView1.Rows(ttl).Cells(5).Value = row.Cells("OPEN_QTY").Value.ToString
                                DataGridView1.Rows(ttl).Cells(6).Value = FormatNumber(row.Cells("TOTAL WEIGHT").Value.ToString, 2)
                                DataGridView1.Rows(ttl).Cells(7).Value = FormatNumber(price * Double.Parse(row.Cells("OPEN_QTY").Value), 2)
                                DataGridView1.Rows(ttl).DefaultCellStyle.BackColor = Color.WhiteSmoke
                                DataGridView1.Columns(5).Visible = True
                                DataGridView1.Rows(ttl).Cells(4).ReadOnly = False
                                DataGridView1.Rows(ttl).Cells(4).Style.BackColor = Color.LemonChiffon
                                ttl += 1
                            Next

                        End If
                        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                        DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    End Using
                    SubtotalComputation()
                End Using

            End Using
            sqlCon.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub SOA_Checker()
        Try
            Dim conn As New SqlConnection(connstring)



            Dim command3 As New Data.SqlClient.SqlCommand With {
                .CommandText = "SELECT DRNUM,ISNULL(PAID,'N') as PAID FROM TBL_SOA_DETAILS WHERE DRNUM = " & DEL_NUM & ""
            }
            conn.Open()
            command3.Connection = conn
            command3.ExecuteNonQuery()
            Dim sdr As SqlDataReader = command3.ExecuteReader()
            If (sdr.Read()) Then
                SOA_DR = sdr("DRNUM")
                SOA_PAID = sdr("PAID")
            End If
            If SOA_DR = DEL_NUM Then
                CheckBox2.Checked = True
            Else
                CheckBox2.Checked = False
            End If

            If SOA_PAID = "PAID" Then
                CheckBox3.Checked = True
            Else
                CheckBox3.Checked = False
            End If
            sdr.Close()
            conn.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub DELIVER_DETAILS()
        CLR_ROWS()
        D_DELFORMNUM.ReadOnly = True
        CBX_FNB.Text = Nothing
        Try
            Dim sqlCon = New SqlConnection(connstring)
            sqlCon.Open()
            Using (sqlCon)
                Dim sqlComm As New SqlCommand With {
                    .Connection = sqlCon,
                    .CommandText = "DELIVER_DETAILS",
                    .CommandType = CommandType.StoredProcedure
                }
                sqlComm.Parameters.AddWithValue("@ID", DEL_NUM)
                Using da As New SqlDataAdapter()
                    da.SelectCommand = sqlComm
                    Using sdr As SqlDataReader = sqlComm.ExecuteReader()
                        If sdr.HasRows Then
                            sdr.Read()
                            tbx_cname.Visible = True
                            CBX_D_CNAME.Visible = False
                            tbx_cname.Text = sdr("NAME")
                            D_PICKUPFORM.Text = sdr("PICK_UP_REF_NUM")
                            CBX_D_SORT.Text = sdr("SORTER")
                            D_TYPE_SERVE.Text = sdr("TYPE_OF_SERVICE")
                            D_DATE.Text = sdr("DATE")
                            CBX_D_DEL_TEAM.Text = sdr("DELIVERY_TEAM")
                            D_REMARKS.Text = sdr("Remarks")
                            CBX_D_R_SORT.Text = sdr("SORTED_RECEIVED_BY")
                            CBX_D_CHK.Text = sdr("CHECKED_BY")
                            D_TOTAL.Text = sdr("TOTAL_WEIGHT")
                            D_REF.Text = sdr("REFERENCE")
                            TBX_STATUS.Text = sdr("STATUS").Replace(" ", "")
                            If sdr("DELFORMNUM") <> 0 Then
                                D_DELFORMNUM.Text = sdr("DELFORMNUM")
                            Else
                                D_DELFORMNUM.Text = ""
                            End If

                            CBX_FNB.Text = sdr("FNB")
                            PRINT_STAT = sdr("Printed")
                            CBX_D_DEPART.Text = sdr("DEPT")
                            TBX_RECEIVED.Text = sdr("DR_RECEIVED_BY")
                            TBX_DATE_RECEIVED.Text = sdr("DELIVERY_DATE")
                            LBL_QTY.Text = sdr("TOTAL_QTY")
                            price_per_kg = sdr("Price_per_Kg")
                            LBL_Price_per_Kg.Text = "Php/Kg : " & price_per_kg

                        End If
                    End Using
                    Using dt As New DataTable()
                        da.Fill(dt)
                        PREV_DLVR.DataGridView2.DataSource = dt
                        Dim CNT As Integer = PREV_DLVR.DataGridView2.RowCount
                        If CNT <> 0 Then
                            Dim ttl As Integer = 0
                            For Each row In PREV_DLVR.DataGridView2.Rows
                                Dim price As Double = Double.Parse(row.Cells("Price_per_Kg").Value) * Double.Parse(row.Cells("WEIGHT_PER_PIECE").Value)
                                DataGridView1.Rows(ttl).Cells(0).Value = row.Cells("ITEMCODE").Value.ToString
                                DataGridView1.Rows(ttl).Cells(1).Value = row.Cells("DESCRIPTION").Value.ToString
                                DataGridView1.Rows(ttl).Cells(2).Value = row.Cells("WEIGHT_PER_PIECE").Value.ToString
                                DataGridView1.Rows(ttl).Cells(3).Value = FormatNumber(price, 2)
                                DataGridView1.Rows(ttl).Cells(4).Value = row.Cells("QTY").Value.ToString
                                DataGridView1.Rows(ttl).Cells(4).Style.BackColor = Color.WhiteSmoke
                                DataGridView1.Rows(ttl).Cells(5).Value = row.Cells("QTY").Value.ToString
                                DataGridView1.Rows(ttl).Cells(6).Value = FormatNumber(row.Cells("TOTAL WEIGHT").Value.ToString, 2)
                                DataGridView1.Rows(ttl).Cells(7).Value = FormatNumber(price * Double.Parse(row.Cells("QTY").Value), 2)
                                DataGridView1.Rows(ttl).DefaultCellStyle.BackColor = Color.WhiteSmoke
                                DataGridView1.Columns(5).Visible = False
                                ttl += 1
                            Next

                        End If
                        DataGridView1.ClearSelection()
                        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                        DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        READ_ONLY()
                        SubtotalComputation()

                    End Using
                End Using
            End Using
            sqlCon.Close()
            SOA_Checker()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        If TBX_STATUS.Text = "CANCELLED" Then
            TSB_CANCEL_DOC.Enabled = False
            TBX_STATUS.BackColor = Color.Red
            BTN_CONFRM_DLVR.Enabled = False
        ElseIf TBX_STATUS.Text = "Partial-In-Transit" Or TBX_STATUS.Text = "Final-In-Transit" Or TBX_STATUS.Text = "In-Transit" Then
            TSB_CANCEL_DOC.Enabled = True
            BTN_CONFRM_DLVR.Enabled = True
            TBX_STATUS.BackColor = Color.DarkOrange
        ElseIf TBX_STATUS.Text = "Partial-Confirmed" Or TBX_STATUS.Text = "Final-Confirmed" Or TBX_STATUS.Text = "Confirmed" Then
            TBX_STATUS.BackColor = Color.Blue
            BTN_CONFRM_DLVR.Enabled = False
            TSB_CANCEL_DOC.Enabled = True
        End If
    End Sub
    Private Sub ToolStripBTN_D_1STREC_Click(sender As Object, e As EventArgs) Handles ToolStripBTN_D_1STREC.Click
        CheckBox1.Checked = False
        DEL_NUM = 1
        tbx_cname.Visible = True
        DELIVER_DETAILS()
        ToolStrip_DEL_DNUM.Text = 1
        DataGridView1.Enabled = False
        PENDING_DELIVERY.Dispose()

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        bindData()
    End Sub

    Private Sub DLVR_STATUS()
        Try
            Dim conn1 As New SqlConnection(connstring)
            Dim orderID As Integer = D_REF.Text
            Using command33 As New SqlCommand
                command33.CommandText = "select T0.TOTAL_WEIGHT,T0.STATUS,ISNULL((select SUM(TOTAL_WEIGHT) from tbl_delivery WHERE REFERENCE=T0.OrDER_ID AND STATUS<>'CANCELLED' ),0)  AS DtOTAL
                                      from tbl_order T0 
                                      where OrDER_ID=" & orderID & ""
                conn1.Open()
                command33.Connection = conn1
                command33.ExecuteNonQuery()
                Dim sdrr As SqlDataReader = command33.ExecuteReader()
                If (sdrr.Read()) Then
                    If sdrr("DtOTAL") = 0 Then
                        If sdrr("TOTAL_WEIGHT") = D_TOTAL.Text Then
                            DEL_STAT = "In-Transit"
                        ElseIf sdrr("TOTAL_WEIGHT") <> D_TOTAL.Text Then
                            DEL_STAT = "Partial-In-Transit"
                        End If
                    Else
                        If sdrr("TOTAL_WEIGHT") = D_TOTAL.Text + sdrr("DtOTAL") Then
                            DEL_STAT = "Final-In-Transit"
                        Else
                            DEL_STAT = "Partial-In-Transit"
                        End If
                    End If
                End If
                sdrr.Close()
            End Using
            conn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub Printauto()

        Cursor.Current = Cursors.WaitCursor
        Dim report As New report_delivery 'Replace "CrystalReport1" with the name of your report
        report.SetParameterValue("crTextBox", ToolStrip_DEL_DNUM.Text)
        report.SetDatabaseLogon("sa", "p@ssw0rd", "172.16.4.55", "SUDS_LAUNDRY")
        Dim crv As New CrystalDecisions.Windows.Forms.CrystalReportViewer With {
            .ReportSource = report
        }
        crv.Refresh()
        report.PrintToPrinter(1, False, 0, 0) 'Print the report

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub ButtonSAVE_DEL_Click(sender As Object, e As EventArgs) Handles ButtonSAVE_DEL.Click

        DLVR_STATUS()
        If D_DELFORMNUM.Text = "" Then
            D_DELFORMNUM.Text = "0"
        End If

        Dim rowCount As Integer = 0
        For Each row In DataGridView1.Rows
            If row.CELLS(0).VALUE <> "" Then
                rowCount += 1
            End If
        Next
        If CBX_D_SORT.Text = "" Then
            LBL_ERROR_MSG.Text = "Error: Process by field required!"
            ErrorBox()
            CBX_D_SORT.Select()

        ElseIf CBX_D_R_SORT.Text = "" Then
            LBL_ERROR_MSG.Text = "Error: Packed by field required!"
            ErrorBox()
            CBX_D_R_SORT.Select()
        Else
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to save this Delivery entry?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                'D_DATE.Value = DateTime.Now
                Try
                    Dim conn As New SqlConnection(connstring)
                    Dim command As New Data.SqlClient.SqlCommand
                    Dim command2 As New Data.SqlClient.SqlCommand
                    Dim command3 As New Data.SqlClient.SqlCommand
                    Dim ORDER As Integer
                    command.CommandText = "INSERT INTO tbl_delivery (DLVRY_ID,CCODE,DATE,PICK_UP_REF_NUM,SORTER,TYPE_OF_SERVICE,Remarks,SORTED_RECEIVED_BY,CHECKED_BY,TOTAL_WEIGHT,DELIVERY_TEAM,REFERENCE,STATUS,DELFORMNUM,Added_by,FNB,Printed,DEPT,TOTAL_QTY,Price_per_Kg) 
                            VALUES (@ID_DR,@CCODE,@DATE,@PICK_UP_REF_NUM,@SORTER,@TYPE_OF_SERVICE,@Remarks,@SORTED_RECEIVED_BY,@CHECKED_BY,@TOTAL_WEIGHT,@DELIVERY_TEAM,@REFERENCE,@STATUS,@DELFORMNUM,@AddedBy,@FNB,'N',@DEPART,@TTQTY,@Price_per_Kg)"
                    command2.CommandText = "INSERT INTO TBL_DLVRY_DETAILS (DLVR_ID,ITEMCODE,DESCRIPTION,WEIGHT_PER_PIECE,QTY,TOTAL_WEIGHT,CCODE,REFERENCE) 
                            VALUES (@ORDR_ID,@ITEMCODE,@DESCRIPTION,@WEIGHT_PER_PIECE,@QTY,@WEIGHT_PER_PIECE*@QTY,@CCODE,@REFERENCE)"

                    'VALUES (@ORDR_ID,@ITEMCODE,@DESCRIPTION,@WEIGHT_PER_PIECE,@QTY,@TOTAL_WEIGHT,@CCODE,@REFERENCE)"
                    command3.CommandText = "Select ISNULL(NUM,0)+1 As'RDR' FROM (SELECT MAX(DLVRY_ID) AS 'NUM' FROM tbl_delivery)XX"
                    conn.Open()
                    command3.Connection = conn
                    command3.ExecuteNonQuery()
                    Dim sdr As SqlDataReader = command3.ExecuteReader()
                    If (sdr.Read()) Then
                        ORDER = sdr("RDR")
                    End If
                    sdr.Close()
                    command.Parameters.Add("@ID_DR", SqlDbType.Int).Value = ORDER
                    command.Parameters.Add("@CCODE", SqlDbType.VarChar).Value = CBX_D_CNAME.SelectedValue
                    command.Parameters.Add("@DATE", SqlDbType.DateTime).Value = D_DATE.Value
                    'command.Parameters.Add("@DELIVERY_DATE", SqlDbType.DateTime).Value = D_DATE.Value
                    command.Parameters.Add("@PICK_UP_REF_NUM", SqlDbType.VarChar).Value = D_PICKUPFORM.Text
                    command.Parameters.Add("@SORTER", SqlDbType.VarChar).Value = CBX_D_SORT.Text
                    command.Parameters.Add("@TYPE_OF_SERVICE", SqlDbType.VarChar).Value = D_TYPE_SERVE.Text
                    command.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = D_REMARKS.Text
                    command.Parameters.Add("@SORTED_RECEIVED_BY", SqlDbType.VarChar).Value = CBX_D_R_SORT.Text
                    command.Parameters.Add("@CHECKED_BY", SqlDbType.VarChar).Value = CBX_D_CHK.Text
                    command.Parameters.Add("@TOTAL_WEIGHT", SqlDbType.Decimal).Value = D_TOTAL.Text
                    command.Parameters.Add("@DELIVERY_TEAM", SqlDbType.VarChar).Value = CBX_D_DEL_TEAM.Text
                    command.Parameters.Add("@REFERENCE", SqlDbType.VarChar).Value = D_REF.Text
                    command.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = DEL_STAT
                    command.Parameters.Add("@DELFORMNUM", SqlDbType.Int).Value = D_DELFORMNUM.Text
                    command.Parameters.Add("@FNB", SqlDbType.VarChar).Value = CBX_FNB.Text
                    command.Parameters.Add("@DEPART", SqlDbType.VarChar).Value = CBX_D_DEPART.Text
                    command.Parameters.Add("@AddedBy", SqlDbType.VarChar).Value = Main.CurrentUserLoggedin
                    command.Parameters.Add("@TTQTY", SqlDbType.Decimal).Value = LBL_QTY.Text
                    command.Parameters.Add("@Price_per_Kg", SqlDbType.Decimal).Value = price_per_kg

                    command2.Parameters.Add("@ORDR_ID", SqlDbType.Int).Value = ORDER
                    command2.Parameters.Add("@ITEMCODE", SqlDbType.VarChar)
                    command2.Parameters.Add("@DESCRIPTION", SqlDbType.VarChar)
                    command2.Parameters.Add("@WEIGHT_PER_PIECE", SqlDbType.Decimal)
                    command2.Parameters.Add("@QTY", SqlDbType.Decimal)
                    'command2.Parameters.Add("@TOTAL_WEIGHT", SqlDbType.Decimal)
                    command2.Parameters.Add("@CCODE", SqlDbType.VarChar).Value = CBX_D_CNAME.SelectedValue
                    command2.Parameters.Add("@REFERENCE", SqlDbType.VarChar).Value = D_REF.Text

                    command.Connection = conn
                    command2.Connection = conn
                    command.ExecuteNonQuery()
                    For i As Integer = 0 To rowCount - 1
                        command2.Parameters(1).Value = DataGridView1.Rows(i).Cells(0).Value
                        command2.Parameters(2).Value = DataGridView1.Rows(i).Cells(1).Value
                        command2.Parameters(3).Value = DataGridView1.Rows(i).Cells(2).Value
                        command2.Parameters(4).Value = DataGridView1.Rows(i).Cells(4).Value
                        'command2.Parameters(5).Value = DataGridView1.Rows(i).Cells(2).Value * DataGridView1.Rows(i).Cells(4).Value
                        'command2.Parameters(5).Value = DataGridView1.Rows(i).Cells(6).Value
                        command2.ExecuteNonQuery()
                    Next
                    Using (conn)
                        Dim sqlComm As New SqlCommand With {
                            .Connection = conn
                        }
                    End Using
                    conn.Close()
                    LBL_ERROR_MSG.Text = "Success: Delivery Added"
                    SuccessBox()
                    Dim sqlCon = New SqlConnection(connstring)
                    Using (sqlCon)
                        Dim sqlComm As New SqlCommand With {
                            .Connection = sqlCon,
                            .CommandText = "UpdateOrdrDetail",
                            .CommandType = CommandType.StoredProcedure
                        }
                        sqlComm.Parameters.AddWithValue("@REF", D_REF.Text)
                        sqlComm.Parameters.AddWithValue("@DEL_ID", ORDER)
                        sqlCon.Open()
                        If sqlComm.ExecuteNonQuery() = 1 Then
                        End If
                        sqlCon.Close()
                    End Using
                    ToolStripButton5_Click(sender, e)
                    printauto()
                Catch ex As Exception
                    MessageBox.Show("Fatal Error")
                End Try
            End If
        End If


    End Sub

    Private Sub ToolStripBTN_D_PREV_Click(sender As Object, e As EventArgs) Handles ToolStripBTN_D_PREV.Click
        CheckBox1.Checked = False
        If ToolStrip_DEL_DNUM.Text <> "" Then
            tbx_cname.Visible = True
            DEL_NUM = ToolStrip_DEL_DNUM.Text
            DEL_NUM -= 1
            DELIVER_DETAILS()
            ToolStrip_DEL_DNUM.Text = DEL_NUM
            DataGridView1.Enabled = False

        End If
    End Sub

    Private Sub ToolStrip_DEL_DNUM_TextChanged(sender As Object, e As EventArgs) Handles ToolStrip_DEL_DNUM.TextChanged
        If ToolStrip_DEL_DNUM.Text <> "" Then
            BTN_BASE_DOC.Enabled = True
            TSBTN_PRNT.Enabled = True
            If ToolStrip_DEL_DNUM.Text > 1 Then
                ToolStripBTN_D_PREV.Enabled = True
            Else
                ToolStripBTN_D_PREV.Enabled = False
            End If
        Else
            BTN_BASE_DOC.Enabled = False
            TSBTN_PRNT.Enabled = False
        End If
    End Sub

    Private Sub ToolStripBTN_D_NXT_Click(sender As Object, e As EventArgs) Handles ToolStripBTN_D_NXT.Click
        CheckBox1.Checked = False
        CHECK_MAx_Dlvr()
        If ToolStrip_DEL_DNUM.Text <> "" Then
            DEL_NUM = 1 + ToolStrip_DEL_DNUM.Text
            If DEL_NUM <= DEL_max Then
                tbx_cname.Visible = True
                DELIVER_DETAILS()
                ToolStrip_DEL_DNUM.Text = DEL_NUM
                DataGridView1.Enabled = False
            Else
                LBL_ERROR_MSG.Text = "Error: Last record reached"
                ErrorBox()
                ToolStrip_DEL_DNUM.Text = DEL_max
            End If
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BTN_COPYFROMRECEIVING.Click
        PREV_DLVR.DataGridView2.DataSource = Nothing
        If CBX_D_CNAME.Text <> "" Then
            Try
                Dim SRC = CBX_D_CNAME.SelectedValue.ToString
                Dim conn As New SqlConnection(connstring)
                Dim cmd As New SqlCommand("SELECT T0.OrDER_ID AS 'RR Entry No.',T0.PICK_UP_REF_NUM AS 'Pick-up No.',T1.NAME as 'Customer Name',DEPT,TYPE_OF_SERVICE,Status,T0.DATE as 'RR Date',
                ISNULL((select SUM(OPEN_QTY) from TBL_ORDR_DETAILS A0 where A0.ORDR_ID=T0.OrDER_ID),0) AS 'OPEN' ,
                ISNULL((
                SELECT convert(varchar(20),DLVRY_ID) + ', ' AS 'data()'
                FROM tbl_delivery
                where REFERENCE=T0.OrDER_ID
                FOR XML PATH('')
                ),'') as DR#
                from tbl_order T0 
                INNER JOIN tbl_customer T1 ON T1.CUSTOMER_CODE=T0.CCODE 
                where STATUS not in ('COMPLETED','CANCELLED') and CCODE='" & SRC & "' ", conn)
                Dim DA As New SqlDataAdapter With {
                    .SelectCommand = cmd
                }
                Dim dt_items As New DataTable
                dt_items.Clear()
                DA.Fill(dt_items)
                If dt_items.Rows.Count >= 1 Then
                    PENDING_DELIVERY.DataGridView1.DataSource = dt_items
                    PENDING_DELIVERY.ShowDialog()
                Else
                    LBL_ERROR_MSG.Text = "Error: No pending delivery for " & CBX_D_CNAME.Text & ""
                    ErrorBox()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Me.Dispose()
            End Try
        End If
    End Sub
    Private Sub ClearSelectedRowAndMoveUp()

        Dim rowIndex As Integer = DataGridView1.SelectedCells(0).RowIndex
        For Each cell As DataGridViewCell In DataGridView1.Rows(rowIndex).Cells
            cell.Value = Nothing
        Next
        For i As Integer = rowIndex To DataGridView1.Rows.Count - 1
            Dim row As DataGridViewRow = DataGridView1.Rows(i)
            For Each cell As DataGridViewCell In row.Cells
                If Not String.IsNullOrEmpty(cell.Value) AndAlso i < DataGridView1.Rows.Count - 1 Then
                    DataGridView1.Rows(i - 1).Cells(cell.ColumnIndex).Value = cell.Value
                    cell.Value = Nothing
                End If
            Next
        Next
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ClearSelectedRowAndMoveUp()
        For Each dgvRow As DataGridViewRow In DataGridView1.Rows
            If dgvRow.Cells(0).Value = "" AndAlso dgvRow.Cells(1).Value = "" Then
                dgvRow.DefaultCellStyle.BackColor = Color.WhiteSmoke
                dgvRow.Cells(4).Style.BackColor = Color.WhiteSmoke
                dgvRow.Cells(4).ReadOnly = True
            End If
        Next
        SubtotalComputation()
    End Sub
    Public Sub SubtotalComputation()
        Try
            Dim tot As Double = 0
            Dim tkg As Double = 0
            Dim tamt As Double = 0
            For Each dgvRow As DataGridViewRow In DataGridView1.Rows
                If dgvRow.Cells(0).Value <> "" AndAlso dgvRow.Cells(2).Value <> "" AndAlso dgvRow.Cells(4).Value <> "" Then
                    tot += CDbl(dgvRow.Cells(6).Value)
                    tamt += CDbl(dgvRow.Cells(7).Value)
                    tkg += CDbl(dgvRow.Cells(4).Value)
                End If
            Next
            DataGridView1.Rows(10).Cells(6).Value = FormatNumber(tot, 2)
            DataGridView1.Rows(10).Cells(7).Value = FormatNumber(tamt, 2)
            DataGridView1.Rows(10).Cells(4).Value = FormatNumber(tkg, 2)
            D_TOTAL.Text = FormatNumber(tot, 2)
            LBL_QTY.Text = FormatNumber(tkg, 2)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub DataGridView1_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseDoubleClick
        If DataGridView1.SelectedRows.Count > 0 Then ' Check if a row is selected
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0) ' Get the selected row

            ' Ask the user to confirm the deletion
            Dim confirm As DialogResult = MessageBox.Show("Are you sure you want to delete this row?", "Confirm Deletion", MessageBoxButtons.YesNo)

            If confirm = DialogResult.Yes Then ' If the user confirms the deletion
                'DataGridView1.Rows.Remove(selectedRow) ' Remove the row from the DataGridView
                Button3_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub DataGridView1_ColumnAdded(sender As Object, e As DataGridViewColumnEventArgs) Handles DataGridView1.ColumnAdded
        e.Column.SortMode = DataGridViewColumnSortMode.NotSortable
    End Sub
    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If e.ColumnIndex = 4 AndAlso DataGridView1.Rows(e.RowIndex).Cells(7).Value <> "" AndAlso TBX_STATUS.Text = "" Then 'AndAlso GRID_CHANGER =
            Dim err1 As Integer = 0
            Dim I As Integer
            With DataGridView1
                I = .CurrentRow.Index
                If .Rows(I).Cells(0).Value <> "" Then
                    'If IsDBNull(.Rows(I).Cells(4).Value) Then
                    '    .Rows(I).Cells(4).Value = "0"
                    'End If
                    If .Rows(I).Cells(4).Value > 0 AndAlso CDbl(.Rows(I).Cells(4).Value) <= CDbl(.Rows(I).Cells(5).Value) Then
                        .Rows(I).Cells(6).Value = .Rows(I).Cells(4).Value * .Rows(I).Cells(2).Value
                    Else
                        LBL_ERROR_MSG.Text = "Error: Invalid quantity for item: " & .Rows(I).Cells(1).Value & ", please try again"
                        ErrorBox()
                    End If
                End If
            End With
            SubtotalComputation()
            For Each dgvRow As DataGridViewRow In DataGridView1.Rows
                If dgvRow.Cells(0).Value <> "" AndAlso dgvRow.Cells(7).Value <> "" AndAlso CDbl(dgvRow.Cells(4).Value) > CDbl(dgvRow.Cells(5).Value) Then
                    err1 += 1
                    dgvRow.DefaultCellStyle.ForeColor = Color.Red
                ElseIf dgvRow.Cells(0).Value <> "" AndAlso dgvRow.Cells(7).Value <> "" AndAlso CDbl(dgvRow.Cells("QTY").Value) = 0 Then
                    err1 += 1
                    dgvRow.DefaultCellStyle.ForeColor = Color.Red
                Else
                    dgvRow.DefaultCellStyle.ForeColor = Color.Black
                End If
            Next
            If err1 = 0 Then
                ButtonSAVE_DEL.Enabled = True
            Else
                ButtonSAVE_DEL.Enabled = False
            End If
        End If
    End Sub
    Private Sub DataGridView1_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
        If DataGridView1.IsCurrentCellDirty Then
            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)

        End If
    End Sub
    Private Sub DataGridView1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        If DataGridView1.CurrentCell.ColumnIndex = 4 Then
            AddHandler CType(e.Control, TextBox).KeyPress, AddressOf TextBox_keyPress
        Else
            AddHandler e.Control.KeyPress, AddressOf Cell0_KeyPress
        End If
    End Sub
    Private Sub Cell0_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        e.Handled = True
    End Sub
    Private Sub TextBox_keyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If e.KeyChar = "."c Then
            e.Handled = (CType(sender, TextBox).Text.IndexOf("."c) <> -1)
        ElseIf e.KeyChar <> ControlChars.Back Then
            e.Handled = ("0123456789".IndexOf(e.KeyChar) = -1)
        End If
    End Sub
    Public Sub CHECK_MAx_Dlvr()
        Dim sqlCon_C = New SqlConnection(connstring)
        Try
            Dim cmd As New SqlCommand("select ISNULL(MAX(DLVRY_ID),0)as rec from  tbl_delivery", sqlCon_C)
            If (sqlCon_C.State <> ConnectionState.Open) Then
                sqlCon_C.Open()
            End If
            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            sdr.Read()
            DEL_max = sdr("rec")
            sdr.Close()
            sqlCon_C.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        CheckBox1.Checked = False
        CLR_ROWS()
        CHECK_MAx_Dlvr()
        DEL_NUM = DEL_max
        tbx_cname.Visible = True
        DELIVER_DETAILS()
        ToolStrip_DEL_DNUM.Text = DEL_NUM
        DataGridView1.Enabled = False
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        CLEAR()
        tbx_cname.Visible = False
        CBX_D_CNAME.Visible = True
        CheckBox1.Checked = True
        READ_FALSE()
        BTN_COPYFROMRECEIVING.Enabled = False
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            DataGridView1.DataSource = Nothing
            'CBX_D_CNAME.BackColor = Color.LemonChiffon
            D_PICKUPFORM.BackColor = Color.LemonChiffon
            D_REF.BackColor = Color.LemonChiffon
            'CBX_D_SORT.BackColor = Color.LemonChiffon
            'D_TYPE_SERVE.BackColor = Color.LemonChiffon
            'D_DATE.BackColor = Color.LemonChiffon
            'D_DELFORMNUM.BackColor = Color.LemonChiffon
            'CBX_D_DEL_TEAM.BackColor = Color.LemonChiffon
            'D_REF.BackColor = Color.LemonChiffon
            'CBX_D_R_SORT.BackColor = Color.LemonChiffon
            'CBX_D_CHK.BackColor = Color.LemonChiffon
            'D_REMARKS.BackColor = Color.LemonChiffon
            ButtonSAVE_DEL.Enabled = False
            D_PICKUPFORM.ReadOnly = False
            'D_REMARKS.ReadOnly = False
            D_REF.ReadOnly = False
            BTN_COPYFROMRECEIVING.Enabled = False
        Else
            'CBX_D_CNAME.BackColor = Color.White
            D_PICKUPFORM.BackColor = Color.White
            'CBX_D_SORT.BackColor = Color.White
            'D_TYPE_SERVE.BackColor = Color.White
            'D_DATE.BackColor = Color.White
            'D_DELFORMNUM.BackColor = Color.White
            'CBX_D_DEL_TEAM.BackColor = Color.White
            'D_REF.BackColor = Color.White
            'CBX_D_R_SORT.BackColor = Color.White
            'CBX_D_CHK.BackColor = Color.White
            'D_REMARKS.BackColor = Color.White
            ButtonSAVE_DEL.Enabled = True
            D_PICKUPFORM.ReadOnly = True
            D_REF.ReadOnly = True

        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Dim result As DialogResult = MessageBox.Show("This action cannot be undone are you sure you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If result = DialogResult.Yes Then
            CLEAR()
            READ_FALSE()
        End If
    End Sub

    Private Sub ToolStrip_DEL_DNUM_KeyDown(sender As Object, e As KeyEventArgs) Handles ToolStrip_DEL_DNUM.KeyDown
        If e.KeyData = Keys.Enter Then
            DEL_NUM = ToolStrip_DEL_DNUM.Text
            CHECK_MAx_Dlvr()
            If ToolStrip_DEL_DNUM.Text <> "" Then
                If DEL_max >= DEL_NUM Then
                    DELIVER_DETAILS()

                    ToolStrip_DEL_DNUM.Text = DEL_NUM
                Else
                    LBL_ERROR_MSG.Text = "Error: Last data record reached"
                    ErrorBox()
                    ToolStrip_DEL_DNUM.Text = DEL_max
                End If
            End If
        End If
    End Sub

    Private Sub ToolStrip_DEL_DNUM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ToolStrip_DEL_DNUM.KeyPress
        If e.KeyChar = "."c Then
            e.Handled = (CType(sender, TextBox).Text.IndexOf("."c) <> -1)
        ElseIf e.KeyChar <> ControlChars.Back Then
            e.Handled = ("0123456789".IndexOf(e.KeyChar) = -1)
        End If
    End Sub

    Private Sub D_PICKUPFORM_KeyDown(sender As Object, e As KeyEventArgs) Handles D_PICKUPFORM.KeyDown,
        CBX_D_CNAME.KeyDown, D_PICKUPFORM.KeyDown, CBX_D_SORT.KeyDown, D_TYPE_SERVE.KeyDown, D_DATE.KeyDown, D_DELFORMNUM.KeyDown,
    CBX_D_DEL_TEAM.KeyDown, D_REF.KeyDown, CBX_D_R_SORT.KeyDown, CBX_D_CHK.KeyDown, D_REMARKS.KeyDown, ToolStrip_DEL_DNUM.KeyDown

        If e.KeyData = Keys.Enter Then
            If CheckBox1.Checked = True Then

                If sender Is D_PICKUPFORM Then
                    SEARCH.PICKUPFORMNO = D_PICKUPFORM.Text

                ElseIf sender Is D_REF Then
                    SEARCH.REFERENCE = D_REF.Text

                End If
                'SEARCH.PICKUPFORMNO = D_PICKUPFORM.Text
                'SEARCH.C_CODE = CBX_D_CNAME.Text
                'SEARCH.SORTER = CBX_D_SORT.Text
                'SEARCH.TYPE_OF_SERVICE = D_TYPE_SERVE.Text
                'SEARCH.R_DATE = ""
                'SEARCH.DEL_DATE = ""
                'SEARCH.DEL_TEAM = CBX_D_DEL_TEAM.Text
                'SEARCH.DELFORMNO = D_DELFORMNUM.Text
                'SEARCH.REFERENCE = D_REF.Text
                'SEARCH.REMARKS = D_REMARKS.Text
                'SEARCH.SORT_REC = CBX_D_R_SORT.Text
                'SEARCH.CHECKEDBY = CBX_D_CHK.Text
                SEARCH.TTYPE = "DLVR"
                SEARCH.ShowDialog()
            End If

        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        DEL_NUM = ToolStrip_DEL_DNUM.Text
        DELIVER_DETAILS()
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        LBL_ERROR_MSG.Text = "Error: No Delivery Record found"
        ErrorBox()
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        CLEAR()
        tbx_cname.Visible = False
        CBX_D_CNAME.Visible = True
        CLR_ROWS()
        READ_FALSE()
        D_DELFORMNUM.ReadOnly = False
        BTN_CONFRM_DLVR.Enabled = False
        DataGridView1.ReadOnly = True
        'CBX_D_CNAME.SelectedIndex = -1

    End Sub
    Private Sub DELIVERY_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Pending.Src_ID = 2 Then
            Pending.Button2.PerformClick()
        End If
        Me.Dispose()
    End Sub

    Private Sub DELIVERY_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Form1.BringToFront()
    End Sub

    Private Sub BTN_BASE_DOC_Click(sender As Object, e As EventArgs) Handles BTN_BASE_DOC.Click

        Dim frm As New Form1()
        frm.ToolStripButton1.Enabled = False
        frm.FormBorderStyle = FormBorderStyle.FixedSingle
        frm.Show()
        frm.ToolStripTBX_R_NUM.Text = D_REF.Text
        frm.BringToFront()
        frm.ButtonDrefHidden.PerformClick()
    End Sub

    Private Sub DataGridView1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        For Each row In DataGridView1.Rows
            If row.CELLS(0).VALUE <> "" AndAlso row.CELLS(7).VALUE <> "" Then
                SubtotalComputation()
            End If
        Next
    End Sub

    Private Sub TSBTN_PRNT_Click(sender As Object, e As EventArgs) Handles TSBTN_PRNT.Click
        If PRINT_STAT <> "Y" Then
            Try
                Dim conn1 As New SqlConnection(connstring)
                Dim scode As Integer = ToolStrip_DEL_DNUM.Text
                Using command33 As New SqlCommand
                    command33.CommandText = "UPDATE tbl_delivery SET Printed='Y' WHERE DLVRY_ID=" & scode & ""
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
        'printing_dlvr.Show()
    End Sub

    Private Sub TSB_CANCEL_DOC_Click(sender As Object, e As EventArgs) Handles TSB_CANCEL_DOC.Click
        Main.AUTHORIZE = 0
        AUTHORIZATION.ShowDialog()
        If Main.AUTHORIZE = 1 Then
            CANCELDLVR()
            ToolStripButton2_Click(sender, e)
        End If
    End Sub
    Public Sub CANCELDLVR()
        Try
            Dim sqlCon = New SqlConnection(connstring)
            Dim rowsAffected As Integer
            Using (sqlCon)
                Dim sqlComm As New SqlCommand With {
                    .Connection = sqlCon,
                    .CommandText = "CancelDlvr",
                    .CommandType = CommandType.StoredProcedure
                }
                sqlComm.Parameters.AddWithValue("@ID", ToolStrip_DEL_DNUM.Text)
                sqlCon.Open()
                rowsAffected = sqlComm.ExecuteNonQuery()
                LBL_ERROR_MSG.Text = "Success: Delivery entry no." & ToolStrip_DEL_DNUM.Text & " cancellation successful"
                SuccessBox()
                sqlCon.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DELIVERY_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        Me.ActiveControl = Nothing
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles BTN_CONFRM_DLVR.Click
        If BTN_CONFRM_DLVR.Text <> "Update" Then

            If TBX_RECEIVED.Text <> "" Then
                Dim dr_stat As String = TBX_STATUS.Text
                dr_status = dr_stat.Replace("In-Transit", "Confirmed")

                Dim result As DialogResult = MessageBox.Show("Are you sure you want to 'CONFIRM' this Delivery entry?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    D_DATE.Value = DateTime.Now
                    Try
                        Dim sqlCon = New SqlConnection(connstring)
                        Dim rowsAffected As Integer
                        Using (sqlCon)
                            Dim sqlComm As New SqlCommand With {
                                .Connection = sqlCon,
                                .CommandText = "Confirmed_DLVR",
                                .CommandType = CommandType.StoredProcedure
                            }
                            sqlComm.Parameters.AddWithValue("@ID", ToolStrip_DEL_DNUM.Text)
                            sqlComm.Parameters.AddWithValue("@DEL_DATE", DateTimePicker1.Value)
                            sqlComm.Parameters.AddWithValue("@Stat", dr_status)
                            sqlComm.Parameters.AddWithValue("@REF", D_REF.Text)
                            sqlComm.Parameters.AddWithValue("@ReceivedBy", TBX_RECEIVED.Text)
                            sqlCon.Open()
                            rowsAffected = sqlComm.ExecuteNonQuery()

                            LBL_ERROR_MSG.Text = "Success: Delivery entry no. " & ToolStrip_DEL_DNUM.Text & " successful Confirmed!"
                            SuccessBox()
                            DELIVER_DETAILS()
                            sqlCon.Close()
                        End Using

                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                End If
            Else
                LBL_ERROR_MSG.Text = "Error: Received by and received date is required, please try again"
                ErrorBox()
                TBX_RECEIVED.Select()
            End If
        Else
            Dim sqlCon_C = New SqlConnection(connstring)
            Dim scode As Integer = ToolStrip_DEL_DNUM.Text
            Try
                Dim cmd As New SqlCommand("UPDATE tbl_delivery set DELIVERY_DATE='" & DateTimePicker1.Value & "' where DLVRY_ID=" & scode & "", sqlCon_C)
                If (sqlCon_C.State <> ConnectionState.Open) Then
                    sqlCon_C.Open()
                End If
                Dim sdr As SqlDataReader = cmd.ExecuteReader()
                DELIVER_DETAILS()
                sqlCon_C.Close()
                BTN_CONFRM_DLVR.Enabled = False
                MessageBox.Show("Delivery No." & scode & " delivery date updated.")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If

    End Sub

    Private Sub TSB_EXIT_Click(sender As Object, e As EventArgs) Handles TSB_EXIT.Click
        Me.Dispose()
    End Sub

    Private Sub DataGridView1_ColumnHeaderCellChanged(sender As Object, e As DataGridViewColumnEventArgs) Handles DataGridView1.ColumnHeaderCellChanged

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        D_DATE.Value = DateTime.Now
    End Sub

    Private Sub CBX_D_CHK_KeyPress(sender As Object, e As KeyPressEventArgs) Handles D_TYPE_SERVE.KeyPress, CBX_D_SORT.KeyPress, CBX_D_R_SORT.KeyPress, CBX_D_DEL_TEAM.KeyPress, CBX_D_CNAME.KeyPress, CBX_D_CHK.KeyPress
        e.Handled = True
    End Sub


    Private Sub CBX_D_SORT_Enter(sender As Object, e As EventArgs) Handles CBX_D_SORT.Enter
        EMPList.CDX = "DEL_SORT"
        EMPList.ShowDialog()

    End Sub

    Private Sub CBX_D_R_SORT_Enter(sender As Object, e As EventArgs) Handles CBX_D_R_SORT.Enter
        EMPList.CDX = "DEL_RSORT"
        EMPList.ShowDialog()
    End Sub

    Private Sub TBX_STATUS_TextChanged(sender As Object, e As EventArgs) Handles TBX_STATUS.TextChanged
        Dim searchValue As String = "Confirmed"
        Dim cancelhValue As String = "CANCELLED"
        If TBX_STATUS.Text = "" Then
            Label15.Visible = False
            Label14.Visible = False
            TBX_DATE_RECEIVED.Visible = False
            DateTimePicker1.Visible = False
            Label5.Visible = False
            TBX_RECEIVED.Visible = False
            ButtonSAVE_DEL.Location = New Point(3, 1)
            BTN_CONFRM_DLVR.Location = New Point(172, 1)
            'anchorBtn()
        ElseIf TBX_STATUS.Text.ToString().Contains(searchValue) Then
            Label15.Visible = True
            Label14.Visible = True
            TBX_DATE_RECEIVED.Visible = True
            TBX_RECEIVED.Visible = True
            TBX_RECEIVED.Enabled = False
            TBX_DATE_RECEIVED.Enabled = True
            DateTimePicker1.Visible = False
            Label5.Visible = False
            ButtonSAVE_DEL.Location = New Point(3, 55)
            BTN_CONFRM_DLVR.Location = New Point(172, 55)
            BTN_CONFRM_DLVR.Text = "Update"
            'anchorBtn()
        ElseIf TBX_STATUS.Text.ToString().Contains(cancelhValue) Then
            Label15.Visible = False
            Label14.Visible = False
            TBX_DATE_RECEIVED.Visible = False
            TBX_RECEIVED.Visible = False
            TBX_RECEIVED.Enabled = False
            TBX_DATE_RECEIVED.Enabled = False
            ButtonSAVE_DEL.Location = New Point(3, 1)
            BTN_CONFRM_DLVR.Location = New Point(172, 1)

        Else
            Label15.Visible = True
            Label14.Visible = True
            TBX_DATE_RECEIVED.Visible = True
            TBX_DATE_RECEIVED.Enabled = True
            TBX_RECEIVED.Visible = True
            TBX_RECEIVED.Enabled = True
            ButtonSAVE_DEL.Location = New Point(3, 55)
            BTN_CONFRM_DLVR.Location = New Point(172, 55)
            BTN_CONFRM_DLVR.Text = "Confirm"
            'anchorBtn()
        End If
    End Sub

    Private Sub CBX_D_CNAME_Enter(sender As Object, e As EventArgs) Handles CBX_D_CNAME.Enter
        CBX_D_CNAME.DataSource = CUSTOMERSLIST()
        CBX_D_CNAME.ValueMember = "CCODE"
        CBX_D_CNAME.DisplayMember = "NAME"
        CBX_D_CNAME.SelectedIndex = -1
    End Sub

    Private Sub CBX_D_SORT_Click(sender As Object, e As EventArgs) Handles CBX_D_SORT.Click
        EMPList.CDX = "DEL_SORT"
        EMPList.ShowDialog()
    End Sub

    Private Sub CBX_D_R_SORT_Click(sender As Object, e As EventArgs) Handles CBX_D_R_SORT.Click
        EMPList.CDX = "DEL_RSORT"
        EMPList.ShowDialog()
    End Sub

    Private Sub CBX_D_DEL_TEAM_Enter(sender As Object, e As EventArgs) Handles CBX_D_DEL_TEAM.Enter
        EMPList.CDX = "DLVR_DEL_TEAM"
        EMPList.ShowDialog()
    End Sub

    Private Sub TBX_RECEIVED_TextChanged(sender As Object, e As EventArgs) Handles TBX_RECEIVED.TextChanged
        If TBX_RECEIVED.Text = "" Then
            TBX_DATE_RECEIVED.Text = Nothing

        End If
    End Sub

    Private Sub TBX_DATE_RECEIVED_Click(sender As Object, e As EventArgs) Handles TBX_DATE_RECEIVED.Click
        If CheckBox2.Checked = False Then
            If TBX_DATE_RECEIVED.Enabled = True Then
                BTN_CONFRM_DLVR.Enabled = False
                DateTimePicker1.Visible = True
                Label5.Visible = True
                DateTimePicker1.Select()
            End If
        End If
    End Sub


    Private Sub DateTimePicker1_Leave_1(sender As Object, e As EventArgs) Handles DateTimePicker1.Leave

        'If BTN_CONFRM_DLVR.Text <> "Update" Then
        TBX_DATE_RECEIVED.Text = DateTimePicker1.Value.ToString
            DateTimePicker1.Visible = False
            Label5.Visible = False
            BTN_CONFRM_DLVR.Enabled = True
        'Else
        '    DateTimePicker1.Visible = False
        '    Label5.Visible = False
        'End If


    End Sub

    Private Sub DateTimePicker1_KeyDown(sender As Object, e As KeyEventArgs) Handles DateTimePicker1.KeyDown
        If e.KeyData = Keys.Enter Then
            TBX_DATE_RECEIVED.Text = DateTimePicker1.Value.ToString
            DateTimePicker1.Visible = False
            Label5.Visible = False
            BTN_CONFRM_DLVR.Enabled = True
        End If
    End Sub
    Private Sub CBX_D_CNAME_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBX_D_CNAME.SelectedIndexChanged
        ToolStripButton1.PerformClick()
    End Sub

    Private Sub D_DELFORMNUM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles D_DELFORMNUM.KeyPress
        If e.KeyChar = "."c Then
            e.Handled = (CType(sender, TextBox).Text.IndexOf("."c) <> -1)
        ElseIf e.KeyChar <> ControlChars.Back Then
            e.Handled = ("0123456789".IndexOf(e.KeyChar) = -1)
        End If
    End Sub

    Private Sub TBX_DATE_RECEIVED_TextChanged(sender As Object, e As EventArgs) Handles TBX_DATE_RECEIVED.TextChanged
        If BTN_CONFRM_DLVR.Text = "Update" Then
            BTN_CONFRM_DLVR.Enabled = True
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        If BTN_CONFRM_DLVR.Text = "Update" Then
            BTN_CONFRM_DLVR.Enabled = True
        End If
    End Sub
End Class