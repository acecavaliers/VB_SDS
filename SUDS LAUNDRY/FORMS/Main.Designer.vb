<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TBX_UNAME = New System.Windows.Forms.TextBox()
        Me.TBX_PASS = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PanelLogIn = New System.Windows.Forms.Panel()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.PANEL_ERROR = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.LBL_ERROR_MSG = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.BTN_RESDB = New System.Windows.Forms.Button()
        Me.BTN_BACKUP = New System.Windows.Forms.Button()
        Me.btnSys = New System.Windows.Forms.Button()
        Me.PanelRep = New System.Windows.Forms.Panel()
        Me.btnPP = New System.Windows.Forms.Button()
        Me.btnItmH = New System.Windows.Forms.Button()
        Me.btnSoa = New System.Windows.Forms.Button()
        Me.btnDt = New System.Windows.Forms.Button()
        Me.btn_rep = New System.Windows.Forms.Button()
        Me.PanelTrans = New System.Windows.Forms.Panel()
        Me.btnPd = New System.Windows.Forms.Button()
        Me.btnDr = New System.Windows.Forms.Button()
        Me.btnRr = New System.Windows.Forms.Button()
        Me.btn_trans = New System.Windows.Forms.Button()
        Me.BTN_LOGOUT = New System.Windows.Forms.Button()
        Me.PanelMain = New System.Windows.Forms.Panel()
        Me.btnSvs = New System.Windows.Forms.Button()
        Me.btnItm = New System.Windows.Forms.Button()
        Me.btnCus = New System.Windows.Forms.Button()
        Me.btnEmp = New System.Windows.Forms.Button()
        Me.btn_main = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.UPDATETOOLS = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.PanelLogIn.SuspendLayout()
        Me.PANEL_ERROR.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.PanelRep.SuspendLayout()
        Me.PanelTrans.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.UPDATETOOLS.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.DarkOrange
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Image = CType(resources.GetObject("Label2.Image"), System.Drawing.Image)
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(388, 32)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "    User Login"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TBX_UNAME
        '
        Me.TBX_UNAME.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TBX_UNAME.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_UNAME.Location = New System.Drawing.Point(7, 63)
        Me.TBX_UNAME.Name = "TBX_UNAME"
        Me.TBX_UNAME.Size = New System.Drawing.Size(183, 25)
        Me.TBX_UNAME.TabIndex = 1
        '
        'TBX_PASS
        '
        Me.TBX_PASS.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_PASS.Location = New System.Drawing.Point(196, 63)
        Me.TBX_PASS.Name = "TBX_PASS"
        Me.TBX_PASS.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TBX_PASS.Size = New System.Drawing.Size(183, 25)
        Me.TBX_PASS.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(7, 121)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(372, 34)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Login"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.Black
        Me.CheckBox1.Location = New System.Drawing.Point(12, 92)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(119, 21)
        Me.CheckBox1.TabIndex = 3
        Me.CheckBox1.Text = "Show password"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(9, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 17)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Username"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(202, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 17)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Password"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PanelLogIn
        '
        Me.PanelLogIn.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PanelLogIn.BackColor = System.Drawing.Color.White
        Me.PanelLogIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PanelLogIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelLogIn.Controls.Add(Me.Label3)
        Me.PanelLogIn.Controls.Add(Me.Label1)
        Me.PanelLogIn.Controls.Add(Me.CheckBox1)
        Me.PanelLogIn.Controls.Add(Me.Button1)
        Me.PanelLogIn.Controls.Add(Me.TBX_PASS)
        Me.PanelLogIn.Controls.Add(Me.TBX_UNAME)
        Me.PanelLogIn.Controls.Add(Me.Label2)
        Me.PanelLogIn.Location = New System.Drawing.Point(443, 196)
        Me.PanelLogIn.Name = "PanelLogIn"
        Me.PanelLogIn.Size = New System.Drawing.Size(389, 181)
        Me.PanelLogIn.TabIndex = 6
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'PANEL_ERROR
        '
        Me.PANEL_ERROR.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PANEL_ERROR.BackColor = System.Drawing.Color.LimeGreen
        Me.PANEL_ERROR.Controls.Add(Me.Label5)
        Me.PANEL_ERROR.Controls.Add(Me.Button3)
        Me.PANEL_ERROR.Controls.Add(Me.LBL_ERROR_MSG)
        Me.PANEL_ERROR.Controls.Add(Me.Label4)
        Me.PANEL_ERROR.Location = New System.Drawing.Point(128, 662)
        Me.PANEL_ERROR.Name = "PANEL_ERROR"
        Me.PANEL_ERROR.Size = New System.Drawing.Size(1144, 31)
        Me.PANEL_ERROR.TabIndex = 8
        Me.PANEL_ERROR.Visible = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(891, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(218, 17)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "This will disappear after 5 seconds"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label5.Visible = False
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.Black
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(1114, 5)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(26, 21)
        Me.Button3.TabIndex = 10
        Me.Button3.UseVisualStyleBackColor = False
        '
        'LBL_ERROR_MSG
        '
        Me.LBL_ERROR_MSG.BackColor = System.Drawing.Color.Transparent
        Me.LBL_ERROR_MSG.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_ERROR_MSG.ForeColor = System.Drawing.Color.White
        Me.LBL_ERROR_MSG.Location = New System.Drawing.Point(50, 7)
        Me.LBL_ERROR_MSG.Name = "LBL_ERROR_MSG"
        Me.LBL_ERROR_MSG.Size = New System.Drawing.Size(960, 18)
        Me.LBL_ERROR_MSG.TabIndex = 10
        Me.LBL_ERROR_MSG.Text = "Username"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Image = Global.SUDS_LAUNDRY.My.Resources.Resources.ok_20
        Me.Label4.Location = New System.Drawing.Point(24, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 19)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "      "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DimGray
        Me.Label10.Location = New System.Drawing.Point(1, 642)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(126, 19)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "User"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.btnSys)
        Me.Panel3.Controls.Add(Me.PanelRep)
        Me.Panel3.Controls.Add(Me.btn_rep)
        Me.Panel3.Controls.Add(Me.PanelTrans)
        Me.Panel3.Controls.Add(Me.btn_trans)
        Me.Panel3.Controls.Add(Me.BTN_LOGOUT)
        Me.Panel3.Controls.Add(Me.PanelMain)
        Me.Panel3.Controls.Add(Me.btn_main)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(3, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(128, 696)
        Me.Panel3.TabIndex = 27
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Silver
        Me.Panel5.Controls.Add(Me.BTN_RESDB)
        Me.Panel5.Controls.Add(Me.BTN_BACKUP)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel5.Location = New System.Drawing.Point(0, 545)
        Me.Panel5.MaximumSize = New System.Drawing.Size(131, 63)
        Me.Panel5.MinimumSize = New System.Drawing.Size(131, 1)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(131, 63)
        Me.Panel5.TabIndex = 32
        '
        'BTN_RESDB
        '
        Me.BTN_RESDB.BackColor = System.Drawing.SystemColors.Control
        Me.BTN_RESDB.Enabled = False
        Me.BTN_RESDB.FlatAppearance.BorderSize = 0
        Me.BTN_RESDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_RESDB.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_RESDB.Image = CType(resources.GetObject("BTN_RESDB.Image"), System.Drawing.Image)
        Me.BTN_RESDB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_RESDB.Location = New System.Drawing.Point(0, 32)
        Me.BTN_RESDB.Name = "BTN_RESDB"
        Me.BTN_RESDB.Size = New System.Drawing.Size(128, 30)
        Me.BTN_RESDB.TabIndex = 20
        Me.BTN_RESDB.Text = "     Restore DB"
        Me.BTN_RESDB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_RESDB.UseVisualStyleBackColor = False
        '
        'BTN_BACKUP
        '
        Me.BTN_BACKUP.BackColor = System.Drawing.SystemColors.Control
        Me.BTN_BACKUP.Enabled = False
        Me.BTN_BACKUP.FlatAppearance.BorderSize = 0
        Me.BTN_BACKUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_BACKUP.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_BACKUP.Image = CType(resources.GetObject("BTN_BACKUP.Image"), System.Drawing.Image)
        Me.BTN_BACKUP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_BACKUP.Location = New System.Drawing.Point(0, 1)
        Me.BTN_BACKUP.Name = "BTN_BACKUP"
        Me.BTN_BACKUP.Size = New System.Drawing.Size(128, 30)
        Me.BTN_BACKUP.TabIndex = 19
        Me.BTN_BACKUP.Text = "     Back Up DB"
        Me.BTN_BACKUP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_BACKUP.UseVisualStyleBackColor = False
        '
        'btnSys
        '
        Me.btnSys.BackColor = System.Drawing.Color.DimGray
        Me.btnSys.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnSys.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnSys.FlatAppearance.BorderSize = 0
        Me.btnSys.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSys.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSys.ForeColor = System.Drawing.Color.White
        Me.btnSys.Image = CType(resources.GetObject("btnSys.Image"), System.Drawing.Image)
        Me.btnSys.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSys.Location = New System.Drawing.Point(0, 519)
        Me.btnSys.Name = "btnSys"
        Me.btnSys.Size = New System.Drawing.Size(128, 26)
        Me.btnSys.TabIndex = 35
        Me.btnSys.Text = "SYSTEM"
        Me.btnSys.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSys.UseVisualStyleBackColor = False
        '
        'PanelRep
        '
        Me.PanelRep.BackColor = System.Drawing.Color.Silver
        Me.PanelRep.Controls.Add(Me.btnPP)
        Me.PanelRep.Controls.Add(Me.btnItmH)
        Me.PanelRep.Controls.Add(Me.btnSoa)
        Me.PanelRep.Controls.Add(Me.btnDt)
        Me.PanelRep.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelRep.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanelRep.Location = New System.Drawing.Point(0, 397)
        Me.PanelRep.MaximumSize = New System.Drawing.Size(131, 122)
        Me.PanelRep.MinimumSize = New System.Drawing.Size(131, 1)
        Me.PanelRep.Name = "PanelRep"
        Me.PanelRep.Size = New System.Drawing.Size(131, 122)
        Me.PanelRep.TabIndex = 31
        '
        'btnPP
        '
        Me.btnPP.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnPP.Enabled = False
        Me.btnPP.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.btnPP.FlatAppearance.BorderSize = 0
        Me.btnPP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPP.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPP.ForeColor = System.Drawing.Color.Black
        Me.btnPP.Image = CType(resources.GetObject("btnPP.Image"), System.Drawing.Image)
        Me.btnPP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPP.Location = New System.Drawing.Point(0, 63)
        Me.btnPP.Name = "btnPP"
        Me.btnPP.Size = New System.Drawing.Size(131, 30)
        Me.btnPP.TabIndex = 5
        Me.btnPP.Text = "       Post Payment"
        Me.btnPP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPP.UseVisualStyleBackColor = False
        '
        'btnItmH
        '
        Me.btnItmH.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnItmH.Enabled = False
        Me.btnItmH.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.btnItmH.FlatAppearance.BorderSize = 0
        Me.btnItmH.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnItmH.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnItmH.ForeColor = System.Drawing.Color.Black
        Me.btnItmH.Image = CType(resources.GetObject("btnItmH.Image"), System.Drawing.Image)
        Me.btnItmH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnItmH.Location = New System.Drawing.Point(0, 94)
        Me.btnItmH.Name = "btnItmH"
        Me.btnItmH.Size = New System.Drawing.Size(131, 30)
        Me.btnItmH.TabIndex = 4
        Me.btnItmH.Text = "       Item History"
        Me.btnItmH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnItmH.UseVisualStyleBackColor = False
        '
        'btnSoa
        '
        Me.btnSoa.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSoa.Enabled = False
        Me.btnSoa.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.btnSoa.FlatAppearance.BorderSize = 0
        Me.btnSoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSoa.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSoa.ForeColor = System.Drawing.Color.Black
        Me.btnSoa.Image = CType(resources.GetObject("btnSoa.Image"), System.Drawing.Image)
        Me.btnSoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSoa.Location = New System.Drawing.Point(0, 32)
        Me.btnSoa.Name = "btnSoa"
        Me.btnSoa.Size = New System.Drawing.Size(131, 30)
        Me.btnSoa.TabIndex = 3
        Me.btnSoa.Text = "       SOA"
        Me.btnSoa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSoa.UseVisualStyleBackColor = False
        '
        'btnDt
        '
        Me.btnDt.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnDt.Enabled = False
        Me.btnDt.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.btnDt.FlatAppearance.BorderSize = 0
        Me.btnDt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDt.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDt.ForeColor = System.Drawing.Color.Black
        Me.btnDt.Image = CType(resources.GetObject("btnDt.Image"), System.Drawing.Image)
        Me.btnDt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDt.Location = New System.Drawing.Point(0, 1)
        Me.btnDt.Name = "btnDt"
        Me.btnDt.Size = New System.Drawing.Size(131, 30)
        Me.btnDt.TabIndex = 2
        Me.btnDt.Text = "       Daily Trans"
        Me.btnDt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDt.UseVisualStyleBackColor = False
        '
        'btn_rep
        '
        Me.btn_rep.BackColor = System.Drawing.Color.DimGray
        Me.btn_rep.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_rep.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btn_rep.FlatAppearance.BorderSize = 0
        Me.btn_rep.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_rep.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_rep.ForeColor = System.Drawing.Color.White
        Me.btn_rep.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_rep.Location = New System.Drawing.Point(0, 371)
        Me.btn_rep.Name = "btn_rep"
        Me.btn_rep.Size = New System.Drawing.Size(128, 26)
        Me.btn_rep.TabIndex = 34
        Me.btn_rep.Text = "REPORTS"
        Me.btn_rep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_rep.UseVisualStyleBackColor = False
        '
        'PanelTrans
        '
        Me.PanelTrans.BackColor = System.Drawing.Color.Silver
        Me.PanelTrans.Controls.Add(Me.btnPd)
        Me.PanelTrans.Controls.Add(Me.btnDr)
        Me.PanelTrans.Controls.Add(Me.btnRr)
        Me.PanelTrans.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTrans.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanelTrans.Location = New System.Drawing.Point(0, 279)
        Me.PanelTrans.MaximumSize = New System.Drawing.Size(131, 92)
        Me.PanelTrans.MinimumSize = New System.Drawing.Size(131, 1)
        Me.PanelTrans.Name = "PanelTrans"
        Me.PanelTrans.Size = New System.Drawing.Size(131, 92)
        Me.PanelTrans.TabIndex = 30
        '
        'btnPd
        '
        Me.btnPd.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnPd.Enabled = False
        Me.btnPd.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.btnPd.FlatAppearance.BorderSize = 0
        Me.btnPd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPd.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPd.ForeColor = System.Drawing.Color.Black
        Me.btnPd.Image = CType(resources.GetObject("btnPd.Image"), System.Drawing.Image)
        Me.btnPd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPd.Location = New System.Drawing.Point(0, 63)
        Me.btnPd.Name = "btnPd"
        Me.btnPd.Size = New System.Drawing.Size(131, 30)
        Me.btnPd.TabIndex = 4
        Me.btnPd.Text = "       Pending"
        Me.btnPd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPd.UseVisualStyleBackColor = False
        '
        'btnDr
        '
        Me.btnDr.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnDr.Enabled = False
        Me.btnDr.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.btnDr.FlatAppearance.BorderSize = 0
        Me.btnDr.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDr.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDr.ForeColor = System.Drawing.Color.Black
        Me.btnDr.Image = CType(resources.GetObject("btnDr.Image"), System.Drawing.Image)
        Me.btnDr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDr.Location = New System.Drawing.Point(0, 32)
        Me.btnDr.Name = "btnDr"
        Me.btnDr.Size = New System.Drawing.Size(131, 30)
        Me.btnDr.TabIndex = 3
        Me.btnDr.Text = "       Delivery"
        Me.btnDr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDr.UseVisualStyleBackColor = False
        '
        'btnRr
        '
        Me.btnRr.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnRr.Enabled = False
        Me.btnRr.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.btnRr.FlatAppearance.BorderSize = 0
        Me.btnRr.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRr.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRr.ForeColor = System.Drawing.Color.Black
        Me.btnRr.Image = CType(resources.GetObject("btnRr.Image"), System.Drawing.Image)
        Me.btnRr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRr.Location = New System.Drawing.Point(0, 1)
        Me.btnRr.Name = "btnRr"
        Me.btnRr.Size = New System.Drawing.Size(131, 30)
        Me.btnRr.TabIndex = 2
        Me.btnRr.Text = "       Receiving"
        Me.btnRr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRr.UseVisualStyleBackColor = False
        '
        'btn_trans
        '
        Me.btn_trans.BackColor = System.Drawing.Color.DimGray
        Me.btn_trans.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_trans.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btn_trans.FlatAppearance.BorderSize = 0
        Me.btn_trans.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_trans.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_trans.ForeColor = System.Drawing.Color.White
        Me.btn_trans.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_trans.Location = New System.Drawing.Point(0, 253)
        Me.btn_trans.Name = "btn_trans"
        Me.btn_trans.Size = New System.Drawing.Size(128, 26)
        Me.btn_trans.TabIndex = 33
        Me.btn_trans.Text = "TRANSACTIONS"
        Me.btn_trans.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_trans.UseVisualStyleBackColor = False
        '
        'BTN_LOGOUT
        '
        Me.BTN_LOGOUT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BTN_LOGOUT.BackColor = System.Drawing.SystemColors.Control
        Me.BTN_LOGOUT.Enabled = False
        Me.BTN_LOGOUT.FlatAppearance.BorderSize = 0
        Me.BTN_LOGOUT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_LOGOUT.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_LOGOUT.Image = CType(resources.GetObject("BTN_LOGOUT.Image"), System.Drawing.Image)
        Me.BTN_LOGOUT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_LOGOUT.Location = New System.Drawing.Point(3, 663)
        Me.BTN_LOGOUT.Name = "BTN_LOGOUT"
        Me.BTN_LOGOUT.Size = New System.Drawing.Size(126, 29)
        Me.BTN_LOGOUT.TabIndex = 25
        Me.BTN_LOGOUT.Text = "      LogOut"
        Me.BTN_LOGOUT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_LOGOUT.UseVisualStyleBackColor = False
        '
        'PanelMain
        '
        Me.PanelMain.BackColor = System.Drawing.Color.Silver
        Me.PanelMain.Controls.Add(Me.btnSvs)
        Me.PanelMain.Controls.Add(Me.btnItm)
        Me.PanelMain.Controls.Add(Me.btnCus)
        Me.PanelMain.Controls.Add(Me.btnEmp)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelMain.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanelMain.Location = New System.Drawing.Point(0, 128)
        Me.PanelMain.MaximumSize = New System.Drawing.Size(131, 125)
        Me.PanelMain.MinimumSize = New System.Drawing.Size(131, 1)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Size = New System.Drawing.Size(131, 125)
        Me.PanelMain.TabIndex = 29
        '
        'btnSvs
        '
        Me.btnSvs.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSvs.Enabled = False
        Me.btnSvs.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.btnSvs.FlatAppearance.BorderSize = 0
        Me.btnSvs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSvs.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSvs.ForeColor = System.Drawing.Color.Black
        Me.btnSvs.Image = CType(resources.GetObject("btnSvs.Image"), System.Drawing.Image)
        Me.btnSvs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSvs.Location = New System.Drawing.Point(0, 94)
        Me.btnSvs.Name = "btnSvs"
        Me.btnSvs.Size = New System.Drawing.Size(131, 30)
        Me.btnSvs.TabIndex = 5
        Me.btnSvs.Text = "       Services"
        Me.btnSvs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSvs.UseVisualStyleBackColor = False
        '
        'btnItm
        '
        Me.btnItm.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnItm.Enabled = False
        Me.btnItm.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.btnItm.FlatAppearance.BorderSize = 0
        Me.btnItm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnItm.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnItm.ForeColor = System.Drawing.Color.Black
        Me.btnItm.Image = CType(resources.GetObject("btnItm.Image"), System.Drawing.Image)
        Me.btnItm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnItm.Location = New System.Drawing.Point(0, 63)
        Me.btnItm.Name = "btnItm"
        Me.btnItm.Size = New System.Drawing.Size(131, 30)
        Me.btnItm.TabIndex = 4
        Me.btnItm.Text = "       Items"
        Me.btnItm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnItm.UseVisualStyleBackColor = False
        '
        'btnCus
        '
        Me.btnCus.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnCus.Enabled = False
        Me.btnCus.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.btnCus.FlatAppearance.BorderSize = 0
        Me.btnCus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCus.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCus.ForeColor = System.Drawing.Color.Black
        Me.btnCus.Image = CType(resources.GetObject("btnCus.Image"), System.Drawing.Image)
        Me.btnCus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCus.Location = New System.Drawing.Point(0, 32)
        Me.btnCus.Name = "btnCus"
        Me.btnCus.Size = New System.Drawing.Size(131, 30)
        Me.btnCus.TabIndex = 3
        Me.btnCus.Text = "       Customer"
        Me.btnCus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCus.UseVisualStyleBackColor = False
        '
        'btnEmp
        '
        Me.btnEmp.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnEmp.Enabled = False
        Me.btnEmp.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.btnEmp.FlatAppearance.BorderSize = 0
        Me.btnEmp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEmp.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmp.ForeColor = System.Drawing.Color.Black
        Me.btnEmp.Image = CType(resources.GetObject("btnEmp.Image"), System.Drawing.Image)
        Me.btnEmp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEmp.Location = New System.Drawing.Point(0, 1)
        Me.btnEmp.Name = "btnEmp"
        Me.btnEmp.Size = New System.Drawing.Size(131, 30)
        Me.btnEmp.TabIndex = 2
        Me.btnEmp.Text = "       Employee"
        Me.btnEmp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEmp.UseVisualStyleBackColor = False
        '
        'btn_main
        '
        Me.btn_main.BackColor = System.Drawing.Color.DimGray
        Me.btn_main.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_main.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btn_main.FlatAppearance.BorderSize = 0
        Me.btn_main.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_main.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_main.ForeColor = System.Drawing.Color.White
        Me.btn_main.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_main.Location = New System.Drawing.Point(0, 102)
        Me.btn_main.Name = "btn_main"
        Me.btn_main.Size = New System.Drawing.Size(128, 26)
        Me.btn_main.TabIndex = 32
        Me.btn_main.Text = "MAINTAINANCE"
        Me.btn_main.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_main.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.BackgroundImage = CType(resources.GetObject("Panel4.BackgroundImage"), System.Drawing.Image)
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(128, 102)
        Me.Panel4.TabIndex = 31
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(65, 75)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 20)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "1.0.0.0"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Timer2
        '
        Me.Timer2.Interval = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(3, 696)
        Me.Panel1.TabIndex = 29
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(131, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(2, 696)
        Me.Panel2.TabIndex = 30
        '
        'UPDATETOOLS
        '
        Me.UPDATETOOLS.AutoSize = False
        Me.UPDATETOOLS.BackColor = System.Drawing.Color.LimeGreen
        Me.UPDATETOOLS.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.UPDATETOOLS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel3, Me.ToolStripButton1, Me.ToolStripLabel1})
        Me.UPDATETOOLS.Location = New System.Drawing.Point(133, 0)
        Me.UPDATETOOLS.Name = "UPDATETOOLS"
        Me.UPDATETOOLS.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.UPDATETOOLS.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.UPDATETOOLS.Size = New System.Drawing.Size(1141, 32)
        Me.UPDATETOOLS.TabIndex = 32
        Me.UPDATETOOLS.Text = "ToolStrip1"
        Me.UPDATETOOLS.Visible = False
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.AutoSize = False
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(5, 29)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButton1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStripButton1.Size = New System.Drawing.Size(134, 29)
        Me.ToolStripButton1.Text = "Click here to update"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStripLabel1.Size = New System.Drawing.Size(499, 29)
        Me.ToolStripLabel1.Text = "Notification: An updated version is now available, kindly update your application" &
    "."
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1274, 696)
        Me.Controls.Add(Me.UPDATETOOLS)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.PANEL_ERROR)
        Me.Controls.Add(Me.PanelLogIn)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Main"
        Me.Text = "SUDS LAUNDRY GENSAN"
        Me.PanelLogIn.ResumeLayout(False)
        Me.PanelLogIn.PerformLayout()
        Me.PANEL_ERROR.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.PanelRep.ResumeLayout(False)
        Me.PanelTrans.ResumeLayout(False)
        Me.PanelMain.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.UPDATETOOLS.ResumeLayout(False)
        Me.UPDATETOOLS.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents TBX_UNAME As TextBox
    Friend WithEvents TBX_PASS As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PanelLogIn As Panel
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents PANEL_ERROR As Panel
    Friend WithEvents Button3 As Button
    Friend WithEvents LBL_ERROR_MSG As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label5 As Label
    Friend WithEvents BTN_RESDB As Button
    Friend WithEvents BTN_BACKUP As Button
    Friend WithEvents BTN_LOGOUT As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PanelMain As Panel
    Friend WithEvents btnEmp As Button
    Friend WithEvents btn_main As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label12 As Label
    Friend WithEvents PanelRep As Panel
    Friend WithEvents btnItmH As Button
    Friend WithEvents btnSoa As Button
    Friend WithEvents btnDt As Button
    Friend WithEvents btn_rep As Button
    Friend WithEvents PanelTrans As Panel
    Friend WithEvents btnPd As Button
    Friend WithEvents btnDr As Button
    Friend WithEvents btnRr As Button
    Friend WithEvents btn_trans As Button
    Friend WithEvents btnSvs As Button
    Friend WithEvents btnItm As Button
    Friend WithEvents btnCus As Button
    Friend WithEvents Timer2 As Timer
    Friend WithEvents Panel5 As Panel
    Friend WithEvents btnSys As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents UPDATETOOLS As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents btnPP As Button
End Class
