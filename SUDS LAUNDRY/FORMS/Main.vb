
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.ComponentModel
Imports System.IO
Imports System.Reflection
Imports System.Net

Public Class Main
    Public connstring As String = ConfigurationManager.ConnectionStrings("SUDS_ConnectionString").ConnectionString
    Public ROLE As String
    Dim btnMain As Boolean = True
    Dim btnTrans As Boolean = True
    Dim btnRep As Boolean = True
    Dim btn_type As String
    Public CurrentUserLoggedin As String
    Public USER_TYPE As String
    Public AUTHORIZE As Integer = 0
    Private prevButton As Button = Nothing
    Private Sub AddEmployeeToolStripMenuItem_Click(sender As Object, e As EventArgs)
        addemp.MdiParent = Me
        addemp.Dock = DockStyle.Fill
        addemp.Show()
        addemp.BringToFront()
    End Sub

    Private Sub AddCustomerToolStripMenuItem_Click(sender As Object, e As EventArgs)
        addcustomer.MdiParent = Me
        addcustomer.Dock = DockStyle.Fill
        addcustomer.Show()
        addcustomer.BringToFront()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Label5.Text ="Label5.Text (" & Timer1.Interval & ")"
        PANEL_ERROR.Visible = False ' Hide the panel
        Timer1.Stop() ' Stop the timer
    End Sub
    Public Sub ErrorBox()
        PANEL_ERROR.BackColor = Color.Red
        Label4.Image = My.Resources.important_20
        LBL_ERROR_MSG.Select()
        PANEL_ERROR.Visible = True
        Timer1.Interval = 3500 ' Set the timer interval to 3 seconds
        Timer1.Start() ' Start the timer
    End Sub
    Public Sub SuccessBox()
        PANEL_ERROR.BackColor = Color.LimeGreen
        Label4.Image = My.Resources.ok_20
        LBL_ERROR_MSG.Select()
        PANEL_ERROR.Visible = True
        Timer1.Interval = 3500 ' Set the timer interval to 3 seconds
        Timer1.Start() ' Start the timer
    End Sub
    Public Sub Btn_ctrl()
        If Login.userrole = "Accountant" Or Login.userrole = "Administrator" Then
            btnPP.Enabled = True
        Else
            btnPP.Enabled = False
        End If

        ' List of allowed roles
        Dim allowedRoles As New List(Of String) From {"Administrator", "Admin", "Accountant", "RECEIVER"}

        ' Check if the ROLE is in the allowedRoles list
        If allowedRoles.Contains(Login.userrole, StringComparer.OrdinalIgnoreCase) Then
            btnPd.Enabled = True
        Else
            btnPd.Enabled = False
        End If

    End Sub
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Label12.Text = "v" & Assembly.GetEntryAssembly().GetName().Version.ToString()

        Btn_ctrl()

        PanelMain.Height = 0
        PanelTrans.Height = 92
        Panel5.Height = 0
        btnTrans = False
        btnRep = False
        btn_main.Image = My.Resources.aBack1
        btn_trans.Image = My.Resources.aBack1
        btn_rep.Image = My.Resources.aBack1
        Me.CenterToScreen()
        image.MdiParent = Me
        image.Dock = DockStyle.Fill
        image.Show()
        image.BringToFront()
        TBX_UNAME.Select()

        Form1.MdiParent = Me
        Form1.Dock = DockStyle.Fill

        DELIVERY.MdiParent = Me
        DELIVERY.Dock = DockStyle.Fill

    End Sub
    Public Sub DBBackUp()
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim connectionString As String = "ThenData Source=172.16.4.55;Initial Catalog=SUDS_LAUNDRY;User Id=sa;Password=p@ssw0rd;"
            Dim backupPath As String = "\\172.16.4.55\suds_laundry backup db\SUDS_LAUNDRY_manual.bak"

            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Using command As SqlCommand = connection.CreateCommand()
                    command.CommandText = "BACKUP DATABASE SUDS_LAUNDRY TO DISK='" & backupPath & "'WITH INIT"
                    command.ExecuteNonQuery()
                    'MessageBox.Show("Backup complete", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim folderPath As String = "\\172.16.4.55\suds_laundry backup db"
                    LBL_ERROR_MSG.Text = "Alert: Database Backup Successful."
                    SuccessBox()
                    'Process.Start("explorer.exe", folderPath)
                End Using
            End Using

            Dim destinationDirectory As String = "\\172.16.2.7\mis\AC-Files\SUDS LOCAL\BackUpDB"
            Dim fileName As String = Path.GetFileName(backupPath)
            Dim destinationFilePath As String = Path.Combine(destinationDirectory, fileName)
            Dim count As Integer = 1

            While File.Exists(destinationFilePath)
                fileName = $"{Path.GetFileNameWithoutExtension(backupPath)}_{count}{Path.GetExtension(backupPath)}"
                destinationFilePath = Path.Combine(destinationDirectory, fileName)
                count += 1
            End While

            File.Copy(backupPath, destinationFilePath)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Cursor.Current = Cursors.Default

    End Sub
    Public Sub DBRestore()
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim conn As New SqlConnection(connstring)
            conn.Open()
            Dim database As String = conn.Database.ToString()
            Dim loc As String = "\\172.16.4.55\suds_laundry backup db\SUDS_LAUNDRY_manual.bak"

            Dim sqlStmt2 As String = String.Format("ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE")
            Dim bu2 As SqlCommand = New SqlCommand(sqlStmt2, conn)
            bu2.ExecuteNonQuery()
            Dim sqlStmt3 As String = "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK='" + loc + "'WITH REPLACE"
            Dim bu3 As SqlCommand = New SqlCommand(sqlStmt3, conn)
            bu3.ExecuteNonQuery()
            Dim sqlStmt4 As String = String.Format("ALTER DATABASE [" + database + "] SET MULTI_USER")
            Dim bu4 As New SqlCommand(sqlStmt4, conn)
            bu4.ExecuteNonQuery()
            MessageBox.Show("Database restore done successefuly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            conn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub Main_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        Try
            Dim currentTime As DateTime = DateTime.Now
            Dim targetTime As DateTime = DateTime.Today.AddHours(16.5) ' 5 PM
            If currentTime >= targetTime Then
                DBBackUp()
            End If
        Catch ex As Exception

        End Try

        Me.Dispose()
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TBX_PASS.PasswordChar = ""
        Else
            TBX_PASS.PasswordChar = "*"
        End If
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim sqlCon_C = New SqlConnection(connstring)
        Try
            Dim cmd As New SqlCommand("SELECT * FROM Tbl_users WHERE USERTYPE<> 'Employee' and status='ACTIVE' and uname ='" & TBX_UNAME.Text & "' AND password = '" & TBX_PASS.Text & "'", sqlCon_C)
            If (sqlCon_C.State <> ConnectionState.Open) Then
                sqlCon_C.Open()
            End If
            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            If sdr.HasRows Then
                sdr.Read()
                CurrentUserLoggedin = sdr("uname")
                ROLE = sdr("role")
                Login.userrole = sdr("role")
                USER_TYPE = sdr("USERTYPE")
                image.PictureBox1.Image = My.Resources.sds3
                Btn_ctrl()

                'If ROLE = "Administrator" Or ROLE = "Admin" Or ROLE = "Accountant" Or ROLE = "RECEIVER" Then
                '    btnPd.Enabled = True
                'Else
                '    btnPd.Enabled = False
                'End If

                If sdr("FM_EMP") = "Y" Then
                    btnEmp.Enabled = True
                Else
                    btnEmp.Enabled = False
                End If

                If sdr("FM_CST") = "Y" Then
                    btnCus.Enabled = True
                Else
                    btnCus.Enabled = False
                End If

                If sdr("FM_ITM") = "Y" Then
                    btnItm.Enabled = True
                Else
                    btnItm.Enabled = False
                End If

                If sdr("FM_SVRC") = "Y" Then
                    btnSvs.Enabled = True
                Else
                    btnSvs.Enabled = False
                End If

                If sdr("TR_RC") = "Y" Then
                    btnRr.Enabled = True
                Else
                    btnRr.Enabled = False
                End If

                If sdr("TR_DLVR") = "Y" Then
                    btnDr.Enabled = True
                Else
                    btnDr.Enabled = False
                End If

                If sdr("RPT_DT") = "Y" Then
                    btnDt.Enabled = True
                    btnItmH.Enabled = True
                Else
                    btnDt.Enabled = False
                End If

                If sdr("RPT_SOA") = "Y" Then
                    btnSoa.Enabled = True
                Else
                    btnSoa.Enabled = False
                End If


                If sdr("UT_BACKUP") = "Y" Then
                    'BTN_BACKUP.Enabled = True
                Else
                    BTN_BACKUP.Enabled = False
                End If

                If sdr("UT_RESTORE") = "Y" Then
                    'BTN_RESDB.Enabled = True
                Else
                    BTN_RESDB.Enabled = False
                End If
                Label10.Text = sdr("Name")
                'ToolStripLabel2.Text = ROLE
                USER_LOGIN()
            Else
                LBL_ERROR_MSG.Text = "Login failed: Invalid username or password, please try again!"
                ErrorBox()
            End If
            sqlCon_C.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub
    Public Sub USER_LOGIN()
        BTN_LOGOUT.Enabled = True
        PanelLogIn.Visible = False
        TBX_PASS.Text = ""
        TBX_UNAME.Text = ""
        'ToolStripButtonLogOut.Enabled = True
    End Sub
    Private Sub Main_Disposed(sender As Object, e As EventArgs) Handles MyBase.Disposed
        Application.Exit()
    End Sub

    Private Sub TBX_PASS_KeyDown(sender As Object, e As KeyEventArgs) Handles TBX_PASS.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1_Click(sender, e)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PANEL_ERROR.Visible = False
    End Sub

    Private Sub ToolStripButtonLogOut_Click(sender As Object, e As EventArgs)
        For Each aform As Form In Me.MdiChildren
            aform.Dispose()
        Next

        image.MdiParent = Me
        image.Dock = DockStyle.Fill
        image.Show()
        image.BringToFront()
        PanelLogIn.Visible = True


        TBX_UNAME.Select()
        'ToolStripButtonLogOut.Enabled = False
    End Sub


    Private Sub Btn_main_Click(sender As Object, e As EventArgs) Handles btn_trans.Click, btn_rep.Click, btn_main.Click
        If sender Is btn_main Then
            btn_main.FlatAppearance.BorderSize = 0
            btn_type = "Main"
            Timer2.Start()

        ElseIf sender Is btn_trans Then
            btn_trans.FlatAppearance.BorderSize = 0
            btn_type = "Trans"
            Timer2.Start()

        ElseIf sender Is btn_rep Then
            btn_rep.FlatAppearance.BorderSize = 0
            btn_type = "Rep"
            Timer2.Start()
        End If

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If btn_type = "Main" Then
            If btnMain = True Then
                If PanelMain.Height = PanelMain.MaximumSize.Height Then
                    Timer2.Stop()
                    btnMain = False
                Else
                    btn_main.Image = My.Resources.aDown1
                    PanelMain.Height += 20
                End If

            ElseIf btnMain = False Then
                If PanelMain.Height = PanelMain.MinimumSize.Height Then
                    Timer2.Stop()
                    btnMain = True
                Else
                    btn_main.Image = My.Resources.aBack1
                    PanelMain.Height -= 20
                End If
            End If
            PanelMain.Select()

        ElseIf btn_type = "Trans" Then
            If btnTrans = True Then
                If PanelTrans.Height = PanelTrans.MaximumSize.Height Then
                    Timer2.Stop()
                    btnTrans = False
                Else
                    btn_trans.Image = My.Resources.aDown1
                    PanelTrans.Height += 20
                End If

            ElseIf btnTrans = False Then
                If PanelTrans.Height = PanelTrans.MinimumSize.Height Then
                    Timer2.Stop()
                    btnTrans = True
                Else
                    btn_trans.Image = My.Resources.aBack1
                    PanelTrans.Height -= 20
                End If
            End If
            PanelTrans.Select()
        ElseIf btn_type = "Rep" Then
            If btnRep = True Then
                If PanelRep.Height = PanelRep.MaximumSize.Height Then
                    Timer2.Stop()
                    btnRep = False
                Else
                    btn_rep.Image = My.Resources.aDown1
                    PanelRep.Height += 20
                End If

            ElseIf btnRep = False Then
                If PanelRep.Height = PanelRep.MinimumSize.Height Then
                    Timer2.Stop()
                    btnRep = True
                Else
                    btn_rep.Image = My.Resources.aBack1
                    PanelRep.Height -= 20
                End If
            End If
            PanelRep.Select()
        End If
    End Sub


    Private Sub BtnEmp_Click_1(sender As Object, e As EventArgs) Handles btnSvs.Click, btnSoa.Click, btnRr.Click, btnPd.Click, btnItmH.Click, btnItm.Click, btnEmp.Click, btnDt.Click, btnDr.Click, btnCus.Click, btnPP.Click
        Login.VersionControl()

        If sender Is btnEmp Then
            addemp.MdiParent = Me
            addemp.Dock = DockStyle.Fill
            addemp.BringToFront()
            addemp.Show()
        ElseIf sender Is btnCus Then
            addcustomer.MdiParent = Me
            addcustomer.Dock = DockStyle.Fill
            addcustomer.BringToFront()
            addcustomer.Show()
        ElseIf sender Is btnItm Then
            addItems.MdiParent = Me
            addItems.Dock = DockStyle.Fill
            addItems.BringToFront()
            addItems.Show()
        ElseIf sender Is btnSvs Then
            addservice.MdiParent = Me
            addservice.Dock = DockStyle.Fill
            addservice.BringToFront()
            addservice.Show()
        ElseIf sender Is btnRr Then
            Form1.MdiParent = Me
            Form1.Dock = DockStyle.Fill
            Form1.BringToFront()
            Form1.Show()
        ElseIf sender Is btnDr Then
            DELIVERY.MdiParent = Me
            DELIVERY.Dock = DockStyle.Fill
            DELIVERY.BringToFront()
            DELIVERY.Show()
        ElseIf sender Is btnPd Then
            Pending.MdiParent = Me
            Pending.Dock = DockStyle.Fill
            Pending.BringToFront()
            Pending.Show()
        ElseIf sender Is btnDt Then
            RPT_DAILYTRANS.MdiParent = Me
            RPT_DAILYTRANS.Dock = DockStyle.Fill
            RPT_DAILYTRANS.BringToFront()
            RPT_DAILYTRANS.Show()
        ElseIf sender Is btnSoa Then
            RPT_SOA.MdiParent = Me
            RPT_SOA.Dock = DockStyle.Fill
            RPT_SOA.BringToFront()
            RPT_SOA.Show()

        ElseIf sender Is btnPP Then
            PostPayment.MdiParent = Me
            PostPayment.Dock = DockStyle.Fill
            PostPayment.BringToFront()
            PostPayment.Show()

        ElseIf sender Is btnItmH Then
            RPT_ITMS.MdiParent = Me
            RPT_ITMS.Dock = DockStyle.Fill
            RPT_ITMS.BringToFront()
            RPT_ITMS.Show()
        ElseIf sender Is BTN_BACKUP Then
            DBBackUp()
        ElseIf sender Is BTN_RESDB Then
            Dim folderPath As String = "\\172.16.4.55\suds_laundry backup db"
            Process.Start("explorer.exe", folderPath)
            LBL_ERROR_MSG.Text = "Alert: Feature is not yet enabled!"
            ErrorBox()

        End If

        DirectCast(sender, Button).BackColor = Color.Orange

        ' If there was a previously clicked button, set its background color to white
        If prevButton IsNot Nothing AndAlso prevButton IsNot sender Then
            prevButton.BackColor = Color.WhiteSmoke
        End If

        ' Store the currently clicked button as the previous button
        prevButton = DirectCast(sender, Button)
    End Sub

    Private Sub BTN_LOGOUT_Click(sender As Object, e As EventArgs) Handles BTN_LOGOUT.Click
        For Each aform As Form In Me.MdiChildren
            aform.Dispose()
        Next

        image.MdiParent = Me
        image.Dock = DockStyle.Fill
        image.Show()
        image.BringToFront()
        PanelLogIn.Visible = True
        For Each ctrl As Control In PanelMain.Controls
            If TypeOf ctrl Is Button Then
                CType(ctrl, Button).Enabled = False
            End If
        Next

        For Each ctrl As Control In PanelTrans.Controls
            If TypeOf ctrl Is Button Then
                CType(ctrl, Button).Enabled = False
            End If
        Next

        For Each ctrl As Control In PanelRep.Controls
            If TypeOf ctrl Is Button Then
                CType(ctrl, Button).Enabled = False
            End If
        Next

        Label10.Text = "------"
        Me.BackgroundImage = My.Resources.sds2B
        TBX_UNAME.Select()
    End Sub

    Private Sub PanelLogIn_Paint(sender As Object, e As PaintEventArgs) Handles PanelLogIn.Paint

    End Sub



    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles UPDATETOOLS.ItemClicked

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click


        ' Download the updated installer
        Dim client As New WebClient()
        Dim installerPath As String = Path.Combine(Path.GetTempPath(), "\\172.16.2.7\mis\AC-Files\SUDS LOCAL\SUDS LAUNDRY.application")

        Try

            Dim process As New Process()
            process.StartInfo.FileName = installerPath
            process.Start()

            ' Close the current instance of the application
            Application.Exit()
        Catch ex As Exception
            ' Handle download or installation errors
            MessageBox.Show("Error updating application: " & ex.Message, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub BTN_BACKUP_Click(sender As Object, e As EventArgs) Handles BTN_BACKUP.Click

    End Sub

    Private Sub BTN_RESDB_Click(sender As Object, e As EventArgs) Handles BTN_RESDB.Click

    End Sub

    Private Sub BtnSys_Click(sender As Object, e As EventArgs) Handles btnSys.Click

    End Sub







    'Private Sub CheckDatabaseConnection()
    '    Using connection As New SqlConnection(connstring)
    '        Try
    '            connection.Open()
    '            MessageBox.Show("Database connection successful.")
    '        Catch ex As Exception
    '            MessageBox.Show(ex.Message)
    '        Finally
    '            connection.Close()
    '        End Try
    '    End Using
    'End Sub
    'Private Sub PanelLogIn_VisibleChanged(sender As Object, e As EventArgs) Handles PanelLogIn.VisibleChanged
    '    If PanelLogIn.Visible = True Then
    '        CheckDatabaseConnection()
    '    End If
    'End Sub
End Class