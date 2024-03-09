<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class addcustomer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(addcustomer))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStripR_RECNUM = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.TBX_CCODE = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DataGridCUST = New System.Windows.Forms.DataGridView()
        Me.TBX_C_CON_NUM = New System.Windows.Forms.TextBox()
        Me.TBX_C_ADD = New System.Windows.Forms.TextBox()
        Me.TBX_C_NAME = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BTN_CUS_UPDT = New System.Windows.Forms.Button()
        Me.BTN_CUS_ADD = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TBX_TIN = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TBX_COMP_NAME = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TBX_PU_INDEX = New System.Windows.Forms.TextBox()
        Me.ToolStripR_RECNUM.SuspendLayout()
        CType(Me.DataGridCUST, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolStripR_RECNUM.TabIndex = 30
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
        'TBX_CCODE
        '
        Me.TBX_CCODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TBX_CCODE.Location = New System.Drawing.Point(334, 110)
        Me.TBX_CCODE.Name = "TBX_CCODE"
        Me.TBX_CCODE.ReadOnly = True
        Me.TBX_CCODE.Size = New System.Drawing.Size(129, 29)
        Me.TBX_CCODE.TabIndex = 2
        Me.TBX_CCODE.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(17, 315)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 17)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "Contact No."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(17, 372)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 17)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "Address"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 204)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 17)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = " Trade Name"
        '
        'DataGridCUST
        '
        Me.DataGridCUST.AllowUserToAddRows = False
        Me.DataGridCUST.AllowUserToResizeRows = False
        Me.DataGridCUST.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridCUST.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridCUST.BackgroundColor = System.Drawing.Color.White
        Me.DataGridCUST.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridCUST.Location = New System.Drawing.Point(484, 72)
        Me.DataGridCUST.Name = "DataGridCUST"
        Me.DataGridCUST.RowHeadersVisible = False
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridCUST.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridCUST.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridCUST.Size = New System.Drawing.Size(784, 597)
        Me.DataGridCUST.TabIndex = 34
        '
        'TBX_C_CON_NUM
        '
        Me.TBX_C_CON_NUM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TBX_C_CON_NUM.Location = New System.Drawing.Point(17, 334)
        Me.TBX_C_CON_NUM.Name = "TBX_C_CON_NUM"
        Me.TBX_C_CON_NUM.Size = New System.Drawing.Size(446, 29)
        Me.TBX_C_CON_NUM.TabIndex = 5
        '
        'TBX_C_ADD
        '
        Me.TBX_C_ADD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TBX_C_ADD.Location = New System.Drawing.Point(17, 391)
        Me.TBX_C_ADD.Multiline = True
        Me.TBX_C_ADD.Name = "TBX_C_ADD"
        Me.TBX_C_ADD.Size = New System.Drawing.Size(446, 85)
        Me.TBX_C_ADD.TabIndex = 6
        '
        'TBX_C_NAME
        '
        Me.TBX_C_NAME.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TBX_C_NAME.Location = New System.Drawing.Point(17, 224)
        Me.TBX_C_NAME.Name = "TBX_C_NAME"
        Me.TBX_C_NAME.Size = New System.Drawing.Size(446, 29)
        Me.TBX_C_NAME.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkOrange
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(16, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(233, 27)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "ADD CUSTOMER"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Gainsboro
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(484, 41)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(166, 28)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "View all customer"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(334, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 17)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Company Code"
        '
        'BTN_CUS_UPDT
        '
        Me.BTN_CUS_UPDT.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BTN_CUS_UPDT.Enabled = False
        Me.BTN_CUS_UPDT.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.BTN_CUS_UPDT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_CUS_UPDT.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_CUS_UPDT.ForeColor = System.Drawing.Color.Black
        Me.BTN_CUS_UPDT.Image = CType(resources.GetObject("BTN_CUS_UPDT.Image"), System.Drawing.Image)
        Me.BTN_CUS_UPDT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_CUS_UPDT.Location = New System.Drawing.Point(17, 548)
        Me.BTN_CUS_UPDT.Name = "BTN_CUS_UPDT"
        Me.BTN_CUS_UPDT.Size = New System.Drawing.Size(446, 34)
        Me.BTN_CUS_UPDT.TabIndex = 9
        Me.BTN_CUS_UPDT.Text = "      Update"
        Me.BTN_CUS_UPDT.UseVisualStyleBackColor = False
        '
        'BTN_CUS_ADD
        '
        Me.BTN_CUS_ADD.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BTN_CUS_ADD.Enabled = False
        Me.BTN_CUS_ADD.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.BTN_CUS_ADD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_CUS_ADD.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_CUS_ADD.ForeColor = System.Drawing.Color.Black
        Me.BTN_CUS_ADD.Image = CType(resources.GetObject("BTN_CUS_ADD.Image"), System.Drawing.Image)
        Me.BTN_CUS_ADD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_CUS_ADD.Location = New System.Drawing.Point(17, 508)
        Me.BTN_CUS_ADD.Name = "BTN_CUS_ADD"
        Me.BTN_CUS_ADD.Size = New System.Drawing.Size(446, 34)
        Me.BTN_CUS_ADD.TabIndex = 8
        Me.BTN_CUS_ADD.Text = "Add"
        Me.BTN_CUS_ADD.UseVisualStyleBackColor = False
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
        Me.Button2.Location = New System.Drawing.Point(17, 588)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(446, 34)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "      Clear fields"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(17, 260)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 17)
        Me.Label6.TabIndex = 47
        Me.Label6.Text = "TIN"
        '
        'TBX_TIN
        '
        Me.TBX_TIN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TBX_TIN.Location = New System.Drawing.Point(17, 279)
        Me.TBX_TIN.Name = "TBX_TIN"
        Me.TBX_TIN.Size = New System.Drawing.Size(446, 29)
        Me.TBX_TIN.TabIndex = 4
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(21, 477)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(79, 25)
        Me.CheckBox1.TabIndex = 7
        Me.CheckBox1.Text = "ACTIVE"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Gainsboro
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(17, 41)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(172, 29)
        Me.Button3.TabIndex = 49
        Me.Button3.Text = "ADD DEPARTMENT"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(17, 91)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 17)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "Company Name"
        '
        'TBX_COMP_NAME
        '
        Me.TBX_COMP_NAME.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TBX_COMP_NAME.Location = New System.Drawing.Point(17, 110)
        Me.TBX_COMP_NAME.Name = "TBX_COMP_NAME"
        Me.TBX_COMP_NAME.Size = New System.Drawing.Size(311, 29)
        Me.TBX_COMP_NAME.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(17, 146)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(178, 17)
        Me.Label8.TabIndex = 53
        Me.Label8.Text = "PICK UP REFERENCE INITIAL"
        '
        'TBX_PU_INDEX
        '
        Me.TBX_PU_INDEX.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TBX_PU_INDEX.Location = New System.Drawing.Point(17, 169)
        Me.TBX_PU_INDEX.MaxLength = 1
        Me.TBX_PU_INDEX.Name = "TBX_PU_INDEX"
        Me.TBX_PU_INDEX.Size = New System.Drawing.Size(178, 29)
        Me.TBX_PU_INDEX.TabIndex = 2
        '
        'addcustomer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1280, 720)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TBX_PU_INDEX)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TBX_COMP_NAME)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TBX_TIN)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.BTN_CUS_UPDT)
        Me.Controls.Add(Me.BTN_CUS_ADD)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TBX_CCODE)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DataGridCUST)
        Me.Controls.Add(Me.TBX_C_CON_NUM)
        Me.Controls.Add(Me.TBX_C_ADD)
        Me.Controls.Add(Me.TBX_C_NAME)
        Me.Controls.Add(Me.ToolStripR_RECNUM)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "addcustomer"
        Me.Text = "addcustomer"
        Me.ToolStripR_RECNUM.ResumeLayout(False)
        Me.ToolStripR_RECNUM.PerformLayout()
        CType(Me.DataGridCUST, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStripR_RECNUM As ToolStrip
    Friend WithEvents ToolStripButton7 As ToolStripButton
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents TBX_CCODE As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents DataGridCUST As DataGridView
    Friend WithEvents TBX_C_CON_NUM As TextBox
    Friend WithEvents TBX_C_ADD As TextBox
    Friend WithEvents TBX_C_NAME As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents BTN_CUS_UPDT As Button
    Friend WithEvents BTN_CUS_ADD As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents TBX_TIN As TextBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents TBX_COMP_NAME As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TBX_PU_INDEX As TextBox
End Class
