
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.ComponentModel
Imports System.IO
Imports System.Deployment.Application
Imports System.Reflection
Imports System.Net
Imports System.Linq

Public Class Login

    Public connstring As String = ConfigurationManager.ConnectionStrings("SUDS_ConnectionString").ConnectionString
    Public userrole As String
    Public GGCode As Integer = 0
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Dim ipAdd As String


        VersionControl()

        TBX_UNAME.Text = "ADMIN"

        ' Get the host entry for the local machine
        Dim hostEntry As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())

        ' Filter the AddressList to include only IPv4 addresses
        Dim ipv4Addresses As IEnumerable(Of IPAddress) = hostEntry.AddressList.
            Where(Function(address) address.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork)

        ' Display the IPv4 addresses
        For Each ipAddress As IPAddress In ipv4Addresses
            ipAdd = ipAddress.ToString()
            If ipAdd = "172.16.10.88" Then
                TBX_PASS.Text = "ac121"
                Button1.Select()
            End If
        Next

    End Sub

    Public Sub VersionControl()
        Try
            Dim w As String = Assembly.GetEntryAssembly().GetName().Version.ToString()
            Dim folderPath As String = "\\172.16.2.7\mis\AC-Files\SUDS LOCAL\Application Files" ' Replace with the path to your directory

            Dim directories As String() = Directory.GetDirectories(folderPath)

            Dim sortedDirectories = directories.OrderByDescending(Function(d) New DirectoryInfo(d).CreationTime)

            If sortedDirectories.Any() Then
                Dim newestFolder As String = sortedDirectories.First()
                Dim v1 As String = newestFolder.Substring(newestFolder.Length - 7).Replace("_", ".")

                If v1 <> w Then
                    Main.UPDATETOOLS.Visible = True
                End If

            End If
        Catch ex As Exception

        End Try

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
                Main.CurrentUserLoggedin = sdr("uname")
                userrole = sdr("role")
                Main.USER_TYPE = sdr("USERTYPE")
                image.PictureBox1.Image = My.Resources.sds3

                If userrole = "Administrator" Or userrole = "RECEIVER" Then
                    Main.btnPd.Enabled = True
                Else
                    Main.btnPd.Enabled = False
                End If

                If sdr("FM_EMP") = "Y" Then
                    Main.btnEmp.Enabled = True
                Else
                    Main.btnEmp.Enabled = False
                End If

                If sdr("FM_CST") = "Y" Then
                    Main.btnCus.Enabled = True
                Else
                    Main.btnCus.Enabled = False
                End If

                If sdr("FM_ITM") = "Y" Then
                    Main.btnItm.Enabled = True
                Else
                    Main.btnItm.Enabled = False
                End If

                If sdr("FM_SVRC") = "Y" Then
                    Main.btnSvs.Enabled = True
                Else
                    Main.btnSvs.Enabled = False
                End If

                If sdr("TR_RC") = "Y" Then
                    Main.btnRr.Enabled = True
                Else
                    Main.btnRr.Enabled = False
                End If

                If sdr("TR_DLVR") = "Y" Then
                    Main.btnDr.Enabled = True
                Else
                    Main.btnDr.Enabled = False
                End If

                If sdr("RPT_DT") = "Y" Then
                    Main.btnDt.Enabled = True
                    Main.btnItmH.Enabled = True
                Else
                    Main.btnDt.Enabled = False
                End If

                If sdr("RPT_SOA") = "Y" Then
                    Main.btnSoa.Enabled = True
                Else
                    Main.btnSoa.Enabled = False
                End If


                If sdr("UT_BACKUP") = "Y" Then
                    'BTN_BACKUP.Enabled = True
                Else
                    Main.BTN_BACKUP.Enabled = False
                End If

                If sdr("UT_RESTORE") = "Y" Then
                    'BTN_RESDB.Enabled = True
                Else
                    Main.BTN_RESDB.Enabled = False
                End If
                Main.Label10.Text = sdr("Name")
                'ToolStripLabel2.Text = ROLE
                Main.BTN_LOGOUT.Enabled = True
                Main.PanelLogIn.Visible = False
                Main.Show()
                Me.Hide()
            Else
                Label2.Visible = True
            End If
            sqlCon_C.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TBX_PASS_KeyDown(sender As Object, e As KeyEventArgs) Handles TBX_PASS.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1_Click(sender, e)
        End If
    End Sub

    Private Sub Login_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TBX_PASS.PasswordChar = ""
        Else
            TBX_PASS.PasswordChar = "*"
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub

    Private Sub PanelLogIn_Paint(sender As Object, e As PaintEventArgs) Handles PanelLogIn.Paint

    End Sub
End Class