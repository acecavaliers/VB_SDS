<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class addservice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(addservice))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStripR_RECNUM = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.BTN_SRVC_UPDT = New System.Windows.Forms.Button()
        Me.BTN_SRVS_ADD = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TBX_CCODE = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DataGridSRVC = New System.Windows.Forms.DataGridView()
        Me.TBX_SRVC_TYPE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CBX_I_COM = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolStripR_RECNUM.SuspendLayout()
        CType(Me.DataGridSRVC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
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
        Me.ToolStripR_RECNUM.Size = New System.Drawing.Size(1280, 29)
        Me.ToolStripR_RECNUM.TabIndex = 31
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
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(371, 169)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(125, 34)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "      Clear fields"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'BTN_SRVC_UPDT
        '
        Me.BTN_SRVC_UPDT.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BTN_SRVC_UPDT.Enabled = False
        Me.BTN_SRVC_UPDT.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.BTN_SRVC_UPDT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_SRVC_UPDT.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SRVC_UPDT.ForeColor = System.Drawing.Color.Black
        Me.BTN_SRVC_UPDT.Image = CType(resources.GetObject("BTN_SRVC_UPDT.Image"), System.Drawing.Image)
        Me.BTN_SRVC_UPDT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SRVC_UPDT.Location = New System.Drawing.Point(243, 169)
        Me.BTN_SRVC_UPDT.Name = "BTN_SRVC_UPDT"
        Me.BTN_SRVC_UPDT.Size = New System.Drawing.Size(125, 34)
        Me.BTN_SRVC_UPDT.TabIndex = 4
        Me.BTN_SRVC_UPDT.Text = "      Update"
        Me.BTN_SRVC_UPDT.UseVisualStyleBackColor = False
        '
        'BTN_SRVS_ADD
        '
        Me.BTN_SRVS_ADD.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BTN_SRVS_ADD.Enabled = False
        Me.BTN_SRVS_ADD.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.BTN_SRVS_ADD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_SRVS_ADD.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SRVS_ADD.ForeColor = System.Drawing.Color.Black
        Me.BTN_SRVS_ADD.Image = CType(resources.GetObject("BTN_SRVS_ADD.Image"), System.Drawing.Image)
        Me.BTN_SRVS_ADD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SRVS_ADD.Location = New System.Drawing.Point(115, 169)
        Me.BTN_SRVS_ADD.Name = "BTN_SRVS_ADD"
        Me.BTN_SRVS_ADD.Size = New System.Drawing.Size(125, 34)
        Me.BTN_SRVS_ADD.TabIndex = 4
        Me.BTN_SRVS_ADD.Text = "Add"
        Me.BTN_SRVS_ADD.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(1155, 27)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(93, 29)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "View all services"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'TBX_CCODE
        '
        Me.TBX_CCODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TBX_CCODE.Location = New System.Drawing.Point(1116, 173)
        Me.TBX_CCODE.Name = "TBX_CCODE"
        Me.TBX_CCODE.ReadOnly = True
        Me.TBX_CCODE.Size = New System.Drawing.Size(129, 29)
        Me.TBX_CCODE.TabIndex = 47
        Me.TBX_CCODE.TabStop = False
        Me.TBX_CCODE.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 29)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Service Name"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridSRVC
        '
        Me.DataGridSRVC.AllowUserToAddRows = False
        Me.DataGridSRVC.AllowUserToResizeRows = False
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridSRVC.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridSRVC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridSRVC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridSRVC.BackgroundColor = System.Drawing.Color.White
        Me.DataGridSRVC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridSRVC.Location = New System.Drawing.Point(6, 62)
        Me.DataGridSRVC.Name = "DataGridSRVC"
        Me.DataGridSRVC.RowHeadersVisible = False
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridSRVC.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridSRVC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridSRVC.Size = New System.Drawing.Size(1242, 367)
        Me.DataGridSRVC.TabIndex = 54
        '
        'TBX_SRVC_TYPE
        '
        Me.TBX_SRVC_TYPE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TBX_SRVC_TYPE.Location = New System.Drawing.Point(118, 60)
        Me.TBX_SRVC_TYPE.Name = "TBX_SRVC_TYPE"
        Me.TBX_SRVC_TYPE.Size = New System.Drawing.Size(378, 29)
        Me.TBX_SRVC_TYPE.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkOrange
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(17, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(233, 27)
        Me.Label1.TabIndex = 59
        Me.Label1.Text = "ADD SERVICE TYPE"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 29)
        Me.Label4.TabIndex = 61
        Me.Label4.Text = "Price per Kg"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox1
        '
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Location = New System.Drawing.Point(118, 93)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(129, 29)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Location = New System.Drawing.Point(122, 127)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(79, 25)
        Me.CheckBox1.TabIndex = 62
        Me.CheckBox1.Text = "ACTIVE"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CBX_I_COM
        '
        Me.CBX_I_COM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBX_I_COM.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBX_I_COM.FormattingEnabled = True
        Me.CBX_I_COM.Location = New System.Drawing.Point(118, 28)
        Me.CBX_I_COM.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CBX_I_COM.Name = "CBX_I_COM"
        Me.CBX_I_COM.Size = New System.Drawing.Size(378, 29)
        Me.CBX_I_COM.TabIndex = 63
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 28)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(114, 29)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "Company"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(253, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 29)
        Me.Label6.TabIndex = 66
        Me.Label6.Text = "FNB Price per Kg"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox2
        '
        Me.TextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox2.Location = New System.Drawing.Point(366, 93)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(130, 29)
        Me.TextBox2.TabIndex = 3
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox3
        '
        Me.TextBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox3.Location = New System.Drawing.Point(80, 27)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(1069, 29)
        Me.TextBox3.TabIndex = 67
        Me.TextBox3.Visible = False
        Me.TextBox3.WordWrap = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TBX_CCODE)
        Me.GroupBox1.Controls.Add(Me.TBX_SRVC_TYPE)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.BTN_SRVS_ADD)
        Me.GroupBox1.Controls.Add(Me.CBX_I_COM)
        Me.GroupBox1.Controls.Add(Me.BTN_SRVC_UPDT)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1256, 219)
        Me.GroupBox1.TabIndex = 68
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Service Details"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.TextBox3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.DataGridSRVC)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 273)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1254, 435)
        Me.GroupBox2.TabIndex = 69
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Services List"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 29)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "  Search"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Visible = False
        '
        'addservice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1280, 720)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStripR_RECNUM)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "addservice"
        Me.Text = "addservice"
        Me.ToolStripR_RECNUM.ResumeLayout(False)
        Me.ToolStripR_RECNUM.PerformLayout()
        CType(Me.DataGridSRVC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ToolStripR_RECNUM As ToolStrip
    Friend WithEvents ToolStripButton7 As ToolStripButton
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents Button2 As Button
    Friend WithEvents BTN_SRVC_UPDT As Button
    Friend WithEvents BTN_SRVS_ADD As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents TBX_CCODE As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents DataGridSRVC As DataGridView
    Friend WithEvents TBX_SRVC_TYPE As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents CBX_I_COM As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label2 As Label
End Class
