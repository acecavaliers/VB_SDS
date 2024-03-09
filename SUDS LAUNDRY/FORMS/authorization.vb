Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports System.Data.OleDb
Public Class AUTHORIZATION
    Public connstring As String = ConfigurationManager.ConnectionStrings("SUDS_ConnectionString").ConnectionString
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Dispose()
    End Sub

    Private Sub AUTHORIZATION_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim sqlCon_C = New SqlConnection(connstring)
        Try
            Dim cmd As New SqlCommand("SELECT * FROM Tbl_users WHERE  UserType='Superuser' and uname ='" & TBX_UNAME.Text & "' AND password = '" & TBX_PASS.Text & "'", sqlCon_C)
            If (sqlCon_C.State <> ConnectionState.Open) Then
                sqlCon_C.Open()
            End If
            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            If sdr.HasRows Then
                Main.AUTHORIZE = 1
                Me.Dispose()
            Else
                MsgBox("Invalid username or password, Please try again!", MsgBoxStyle.Critical)
            End If
            sqlCon_C.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TBX_UNAME_TextChanged(sender As Object, e As EventArgs) Handles TBX_UNAME.TextChanged

    End Sub

    Private Sub TBX_PASS_KeyDown(sender As Object, e As KeyEventArgs) Handles TBX_PASS.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button3_Click(sender, e)
        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub
End Class