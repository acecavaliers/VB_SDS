<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class addemp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(addemp))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CBX_ROLE = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TBX_NAME = New System.Windows.Forms.TextBox()
        Me.ToolStripR_RECNUM = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TBX_U_PASS = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.CHK_FM_EMP = New System.Windows.Forms.CheckBox()
        Me.CHK_FM_CST = New System.Windows.Forms.CheckBox()
        Me.CHK_FM_ITM = New System.Windows.Forms.CheckBox()
        Me.CHK_TR_DLVR = New System.Windows.Forms.CheckBox()
        Me.CHK_TR_REC = New System.Windows.Forms.CheckBox()
        Me.CHK_UT_RESTORE = New System.Windows.Forms.CheckBox()
        Me.CHK_UT_BACKUP = New System.Windows.Forms.CheckBox()
        Me.CHK_UT_USER = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BTN_USR_UPDT = New System.Windows.Forms.Button()
        Me.BTN_ADD_USR = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CBX_USERTYPE = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.CHK_FM_SRVC = New System.Windows.Forms.CheckBox()
        Me.CHK_RPT_DT = New System.Windows.Forms.CheckBox()
        Me.CHK_RPT_SOA = New System.Windows.Forms.CheckBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripR_RECNUM.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Gainsboro
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(484, 32)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(117, 28)
        Me.Button1.TabIndex = 24
        Me.Button1.Text = "View all user"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'CBX_ROLE
        '
        Me.CBX_ROLE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.CBX_ROLE.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBX_ROLE.FormattingEnabled = True
        Me.CBX_ROLE.Location = New System.Drawing.Point(13, 164)
        Me.CBX_ROLE.Name = "CBX_ROLE"
        Me.CBX_ROLE.Size = New System.Drawing.Size(223, 29)
        Me.CBX_ROLE.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 146)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 17)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Role/Position"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 17)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Name"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(484, 63)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(768, 597)
        Me.DataGridView1.TabIndex = 21
        '
        'TBX_NAME
        '
        Me.TBX_NAME.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TBX_NAME.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_NAME.Location = New System.Drawing.Point(14, 64)
        Me.TBX_NAME.Name = "TBX_NAME"
        Me.TBX_NAME.Size = New System.Drawing.Size(450, 29)
        Me.TBX_NAME.TabIndex = 1
        '
        'ToolStripR_RECNUM
        '
        Me.ToolStripR_RECNUM.AutoSize = False
        Me.ToolStripR_RECNUM.BackColor = System.Drawing.Color.DarkOrange
        Me.ToolStripR_RECNUM.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStripR_RECNUM.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripR_RECNUM.ImageScalingSize = New System.Drawing.Size(12, 12)
        Me.ToolStripR_RECNUM.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton7, Me.ToolStripSeparator8})
        Me.ToolStripR_RECNUM.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStripR_RECNUM.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripR_RECNUM.Name = "ToolStripR_RECNUM"
        Me.ToolStripR_RECNUM.Padding = New System.Windows.Forms.Padding(0)
        Me.ToolStripR_RECNUM.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStripR_RECNUM.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStripR_RECNUM.Size = New System.Drawing.Size(1264, 29)
        Me.ToolStripR_RECNUM.TabIndex = 29
        Me.ToolStripR_RECNUM.Text = "ToolStrip1"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton7.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(24, 26)
        Me.ToolStripButton7.ToolTipText = "Close"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.AutoSize = False
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 24)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 17)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "Password"
        '
        'TBX_U_PASS
        '
        Me.TBX_U_PASS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TBX_U_PASS.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_U_PASS.Location = New System.Drawing.Point(14, 114)
        Me.TBX_U_PASS.Name = "TBX_U_PASS"
        Me.TBX_U_PASS.Size = New System.Drawing.Size(450, 29)
        Me.TBX_U_PASS.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Gainsboro
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 203)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(450, 24)
        Me.Label6.TabIndex = 47
        Me.Label6.Text = "File Maintenance"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Gainsboro
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(14, 375)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(450, 24)
        Me.Label10.TabIndex = 54
        Me.Label10.Text = "Reports"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Gainsboro
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(14, 305)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(450, 24)
        Me.Label13.TabIndex = 51
        Me.Label13.Text = "Transactions"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Gainsboro
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(14, 444)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(450, 24)
        Me.Label14.TabIndex = 55
        Me.Label14.Text = "Utilities"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CHK_FM_EMP
        '
        Me.CHK_FM_EMP.AutoSize = True
        Me.CHK_FM_EMP.Enabled = False
        Me.CHK_FM_EMP.Location = New System.Drawing.Point(17, 229)
        Me.CHK_FM_EMP.Name = "CHK_FM_EMP"
        Me.CHK_FM_EMP.Size = New System.Drawing.Size(112, 21)
        Me.CHK_FM_EMP.TabIndex = 5
        Me.CHK_FM_EMP.Text = "Add Employee"
        Me.CHK_FM_EMP.UseVisualStyleBackColor = True
        '
        'CHK_FM_CST
        '
        Me.CHK_FM_CST.AutoSize = True
        Me.CHK_FM_CST.Enabled = False
        Me.CHK_FM_CST.Location = New System.Drawing.Point(17, 247)
        Me.CHK_FM_CST.Name = "CHK_FM_CST"
        Me.CHK_FM_CST.Size = New System.Drawing.Size(111, 21)
        Me.CHK_FM_CST.TabIndex = 6
        Me.CHK_FM_CST.Text = "Add Customer"
        Me.CHK_FM_CST.UseVisualStyleBackColor = True
        '
        'CHK_FM_ITM
        '
        Me.CHK_FM_ITM.AutoSize = True
        Me.CHK_FM_ITM.Enabled = False
        Me.CHK_FM_ITM.Location = New System.Drawing.Point(17, 265)
        Me.CHK_FM_ITM.Name = "CHK_FM_ITM"
        Me.CHK_FM_ITM.Size = New System.Drawing.Size(80, 21)
        Me.CHK_FM_ITM.TabIndex = 7
        Me.CHK_FM_ITM.Text = "Add Item"
        Me.CHK_FM_ITM.UseVisualStyleBackColor = True
        '
        'CHK_TR_DLVR
        '
        Me.CHK_TR_DLVR.AutoSize = True
        Me.CHK_TR_DLVR.Enabled = False
        Me.CHK_TR_DLVR.Location = New System.Drawing.Point(17, 350)
        Me.CHK_TR_DLVR.Name = "CHK_TR_DLVR"
        Me.CHK_TR_DLVR.Size = New System.Drawing.Size(73, 21)
        Me.CHK_TR_DLVR.TabIndex = 9
        Me.CHK_TR_DLVR.Text = "Delivery"
        Me.CHK_TR_DLVR.UseVisualStyleBackColor = True
        '
        'CHK_TR_REC
        '
        Me.CHK_TR_REC.AutoSize = True
        Me.CHK_TR_REC.Enabled = False
        Me.CHK_TR_REC.Location = New System.Drawing.Point(17, 332)
        Me.CHK_TR_REC.Name = "CHK_TR_REC"
        Me.CHK_TR_REC.Size = New System.Drawing.Size(82, 21)
        Me.CHK_TR_REC.TabIndex = 8
        Me.CHK_TR_REC.Text = "Receiving"
        Me.CHK_TR_REC.UseVisualStyleBackColor = True
        '
        'CHK_UT_RESTORE
        '
        Me.CHK_UT_RESTORE.AutoSize = True
        Me.CHK_UT_RESTORE.Enabled = False
        Me.CHK_UT_RESTORE.Location = New System.Drawing.Point(17, 506)
        Me.CHK_UT_RESTORE.Name = "CHK_UT_RESTORE"
        Me.CHK_UT_RESTORE.Size = New System.Drawing.Size(131, 21)
        Me.CHK_UT_RESTORE.TabIndex = 12
        Me.CHK_UT_RESTORE.Text = "Restore Database"
        Me.CHK_UT_RESTORE.UseVisualStyleBackColor = True
        '
        'CHK_UT_BACKUP
        '
        Me.CHK_UT_BACKUP.AutoSize = True
        Me.CHK_UT_BACKUP.Enabled = False
        Me.CHK_UT_BACKUP.Location = New System.Drawing.Point(17, 488)
        Me.CHK_UT_BACKUP.Name = "CHK_UT_BACKUP"
        Me.CHK_UT_BACKUP.Size = New System.Drawing.Size(127, 21)
        Me.CHK_UT_BACKUP.TabIndex = 11
        Me.CHK_UT_BACKUP.Text = "Backup Database"
        Me.CHK_UT_BACKUP.UseVisualStyleBackColor = True
        '
        'CHK_UT_USER
        '
        Me.CHK_UT_USER.AutoSize = True
        Me.CHK_UT_USER.Enabled = False
        Me.CHK_UT_USER.Location = New System.Drawing.Point(17, 470)
        Me.CHK_UT_USER.Name = "CHK_UT_USER"
        Me.CHK_UT_USER.Size = New System.Drawing.Size(60, 21)
        Me.CHK_UT_USER.TabIndex = 10
        Me.CHK_UT_USER.Text = "Users"
        Me.CHK_UT_USER.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Location = New System.Drawing.Point(17, 557)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(68, 21)
        Me.CheckBox1.TabIndex = 13
        Me.CheckBox1.Text = "ACTIVE"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.DarkOrange
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Image = CType(resources.GetObject("Label4.Image"), System.Drawing.Image)
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Location = New System.Drawing.Point(17, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(233, 27)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "ADD EMPLOYEE"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BTN_USR_UPDT
        '
        Me.BTN_USR_UPDT.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BTN_USR_UPDT.Enabled = False
        Me.BTN_USR_UPDT.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.BTN_USR_UPDT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_USR_UPDT.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_USR_UPDT.ForeColor = System.Drawing.Color.Black
        Me.BTN_USR_UPDT.Image = CType(resources.GetObject("BTN_USR_UPDT.Image"), System.Drawing.Image)
        Me.BTN_USR_UPDT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_USR_UPDT.Location = New System.Drawing.Point(165, 586)
        Me.BTN_USR_UPDT.Name = "BTN_USR_UPDT"
        Me.BTN_USR_UPDT.Size = New System.Drawing.Size(146, 34)
        Me.BTN_USR_UPDT.TabIndex = 15
        Me.BTN_USR_UPDT.Text = "      Update"
        Me.BTN_USR_UPDT.UseVisualStyleBackColor = False
        '
        'BTN_ADD_USR
        '
        Me.BTN_ADD_USR.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BTN_ADD_USR.Enabled = False
        Me.BTN_ADD_USR.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.BTN_ADD_USR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_ADD_USR.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_ADD_USR.ForeColor = System.Drawing.Color.Black
        Me.BTN_ADD_USR.Image = CType(resources.GetObject("BTN_ADD_USR.Image"), System.Drawing.Image)
        Me.BTN_ADD_USR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_ADD_USR.Location = New System.Drawing.Point(12, 586)
        Me.BTN_ADD_USR.Name = "BTN_ADD_USR"
        Me.BTN_ADD_USR.Size = New System.Drawing.Size(146, 34)
        Me.BTN_ADD_USR.TabIndex = 14
        Me.BTN_ADD_USR.Text = "Add"
        Me.BTN_ADD_USR.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Gainsboro
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(11, 531)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(453, 24)
        Me.Label7.TabIndex = 71
        Me.Label7.Text = "Status"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CBX_USERTYPE
        '
        Me.CBX_USERTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBX_USERTYPE.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBX_USERTYPE.FormattingEnabled = True
        Me.CBX_USERTYPE.Items.AddRange(New Object() {"Employee", "User", "Superuser"})
        Me.CBX_USERTYPE.Location = New System.Drawing.Point(241, 164)
        Me.CBX_USERTYPE.Name = "CBX_USERTYPE"
        Me.CBX_USERTYPE.Size = New System.Drawing.Size(223, 29)
        Me.CBX_USERTYPE.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(239, 146)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 17)
        Me.Label8.TabIndex = 73
        Me.Label8.Text = "User Type"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(318, 586)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(146, 34)
        Me.Button2.TabIndex = 74
        Me.Button2.Text = "      Clear fields"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'CHK_FM_SRVC
        '
        Me.CHK_FM_SRVC.AutoSize = True
        Me.CHK_FM_SRVC.Enabled = False
        Me.CHK_FM_SRVC.Location = New System.Drawing.Point(17, 283)
        Me.CHK_FM_SRVC.Name = "CHK_FM_SRVC"
        Me.CHK_FM_SRVC.Size = New System.Drawing.Size(102, 21)
        Me.CHK_FM_SRVC.TabIndex = 75
        Me.CHK_FM_SRVC.Text = "Add Services"
        Me.CHK_FM_SRVC.UseVisualStyleBackColor = True
        '
        'CHK_RPT_DT
        '
        Me.CHK_RPT_DT.AutoSize = True
        Me.CHK_RPT_DT.Location = New System.Drawing.Point(17, 402)
        Me.CHK_RPT_DT.Name = "CHK_RPT_DT"
        Me.CHK_RPT_DT.Size = New System.Drawing.Size(125, 21)
        Me.CHK_RPT_DT.TabIndex = 76
        Me.CHK_RPT_DT.Text = "Daily Transaction"
        Me.CHK_RPT_DT.UseVisualStyleBackColor = True
        '
        'CHK_RPT_SOA
        '
        Me.CHK_RPT_SOA.AutoSize = True
        Me.CHK_RPT_SOA.Location = New System.Drawing.Point(17, 420)
        Me.CHK_RPT_SOA.Name = "CHK_RPT_SOA"
        Me.CHK_RPT_SOA.Size = New System.Drawing.Size(187, 21)
        Me.CHK_RPT_SOA.TabIndex = 77
        Me.CHK_RPT_SOA.Text = "SOA (Statement of account)"
        Me.CHK_RPT_SOA.UseVisualStyleBackColor = True
        '
        'addemp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1264, 681)
        Me.Controls.Add(Me.CHK_RPT_SOA)
        Me.Controls.Add(Me.CHK_RPT_DT)
        Me.Controls.Add(Me.CHK_FM_SRVC)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.CBX_USERTYPE)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.CHK_UT_RESTORE)
        Me.Controls.Add(Me.CHK_UT_BACKUP)
        Me.Controls.Add(Me.CHK_UT_USER)
        Me.Controls.Add(Me.CHK_TR_DLVR)
        Me.Controls.Add(Me.CHK_TR_REC)
        Me.Controls.Add(Me.CHK_FM_ITM)
        Me.Controls.Add(Me.CHK_FM_CST)
        Me.Controls.Add(Me.CHK_FM_EMP)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TBX_U_PASS)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ToolStripR_RECNUM)
        Me.Controls.Add(Me.BTN_USR_UPDT)
        Me.Controls.Add(Me.BTN_ADD_USR)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CBX_ROLE)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.TBX_NAME)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "addemp"
        Me.Text = "addemp"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripR_RECNUM.ResumeLayout(False)
        Me.ToolStripR_RECNUM.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BTN_USR_UPDT As Button
    Friend WithEvents BTN_ADD_USR As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents CBX_ROLE As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TBX_NAME As TextBox
    Friend WithEvents ToolStripR_RECNUM As ToolStrip
    Friend WithEvents ToolStripButton7 As ToolStripButton
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TBX_U_PASS As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents CHK_FM_EMP As CheckBox
    Friend WithEvents CHK_FM_CST As CheckBox
    Friend WithEvents CHK_FM_ITM As CheckBox
    Friend WithEvents CHK_TR_DLVR As CheckBox
    Friend WithEvents CHK_TR_REC As CheckBox
    Friend WithEvents CHK_UT_RESTORE As CheckBox
    Friend WithEvents CHK_UT_BACKUP As CheckBox
    Friend WithEvents CHK_UT_USER As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Label7 As Label
    Friend WithEvents CBX_USERTYPE As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents CHK_FM_SRVC As CheckBox
    Friend WithEvents CHK_RPT_DT As CheckBox
    Friend WithEvents CHK_RPT_SOA As CheckBox
End Class
