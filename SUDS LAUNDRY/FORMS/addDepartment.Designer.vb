<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class addDepartment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(addDepartment))
        Me.TBX_DEPART = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DataGridDEPT = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStripR_RECNUM = New System.Windows.Forms.ToolStrip()
        Me.CBX_I_COM = New System.Windows.Forms.ComboBox()
        Me.BTN_CUS_ADD = New System.Windows.Forms.Button()
        Me.BTN_CUS_UPDT = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        CType(Me.DataGridDEPT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TBX_DEPART
        '
        Me.TBX_DEPART.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TBX_DEPART.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_DEPART.Location = New System.Drawing.Point(209, 53)
        Me.TBX_DEPART.Name = "TBX_DEPART"
        Me.TBX_DEPART.Size = New System.Drawing.Size(310, 25)
        Me.TBX_DEPART.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(208, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 17)
        Me.Label5.TabIndex = 61
        Me.Label5.Text = "Department Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 17)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Company Name"
        '
        'DataGridDEPT
        '
        Me.DataGridDEPT.AllowUserToAddRows = False
        Me.DataGridDEPT.AllowUserToResizeRows = False
        Me.DataGridDEPT.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridDEPT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridDEPT.BackgroundColor = System.Drawing.Color.White
        Me.DataGridDEPT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridDEPT.Location = New System.Drawing.Point(12, 194)
        Me.DataGridDEPT.Name = "DataGridDEPT"
        Me.DataGridDEPT.RowHeadersVisible = False
        Me.DataGridDEPT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridDEPT.Size = New System.Drawing.Size(504, 384)
        Me.DataGridDEPT.TabIndex = 58
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Gainsboro
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(436, 163)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 28)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "View all"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gray
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(-4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(170, 27)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "ADD DEPARTMENT"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ToolStripR_RECNUM
        '
        Me.ToolStripR_RECNUM.AutoSize = False
        Me.ToolStripR_RECNUM.BackColor = System.Drawing.Color.Gray
        Me.ToolStripR_RECNUM.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStripR_RECNUM.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripR_RECNUM.ImageScalingSize = New System.Drawing.Size(12, 12)
        Me.ToolStripR_RECNUM.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStripR_RECNUM.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripR_RECNUM.Name = "ToolStripR_RECNUM"
        Me.ToolStripR_RECNUM.Padding = New System.Windows.Forms.Padding(0)
        Me.ToolStripR_RECNUM.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStripR_RECNUM.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStripR_RECNUM.Size = New System.Drawing.Size(534, 29)
        Me.ToolStripR_RECNUM.TabIndex = 64
        Me.ToolStripR_RECNUM.Text = "ToolStrip1"
        '
        'CBX_I_COM
        '
        Me.CBX_I_COM.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBX_I_COM.FormattingEnabled = True
        Me.CBX_I_COM.Location = New System.Drawing.Point(15, 53)
        Me.CBX_I_COM.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CBX_I_COM.Name = "CBX_I_COM"
        Me.CBX_I_COM.Size = New System.Drawing.Size(186, 25)
        Me.CBX_I_COM.TabIndex = 2
        '
        'BTN_CUS_ADD
        '
        Me.BTN_CUS_ADD.BackColor = System.Drawing.Color.White
        Me.BTN_CUS_ADD.Enabled = False
        Me.BTN_CUS_ADD.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BTN_CUS_ADD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_CUS_ADD.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_CUS_ADD.ForeColor = System.Drawing.Color.Black
        Me.BTN_CUS_ADD.Image = CType(resources.GetObject("BTN_CUS_ADD.Image"), System.Drawing.Image)
        Me.BTN_CUS_ADD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_CUS_ADD.Location = New System.Drawing.Point(11, 115)
        Me.BTN_CUS_ADD.Name = "BTN_CUS_ADD"
        Me.BTN_CUS_ADD.Size = New System.Drawing.Size(168, 30)
        Me.BTN_CUS_ADD.TabIndex = 4
        Me.BTN_CUS_ADD.Text = "Add"
        Me.BTN_CUS_ADD.UseVisualStyleBackColor = False
        '
        'BTN_CUS_UPDT
        '
        Me.BTN_CUS_UPDT.BackColor = System.Drawing.Color.White
        Me.BTN_CUS_UPDT.Enabled = False
        Me.BTN_CUS_UPDT.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BTN_CUS_UPDT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_CUS_UPDT.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_CUS_UPDT.ForeColor = System.Drawing.Color.Black
        Me.BTN_CUS_UPDT.Image = CType(resources.GetObject("BTN_CUS_UPDT.Image"), System.Drawing.Image)
        Me.BTN_CUS_UPDT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_CUS_UPDT.Location = New System.Drawing.Point(181, 115)
        Me.BTN_CUS_UPDT.Name = "BTN_CUS_UPDT"
        Me.BTN_CUS_UPDT.Size = New System.Drawing.Size(168, 30)
        Me.BTN_CUS_UPDT.TabIndex = 5
        Me.BTN_CUS_UPDT.Text = "      Update"
        Me.BTN_CUS_UPDT.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(351, 115)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(168, 30)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "      Clear fields"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(19, 85)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(68, 21)
        Me.CheckBox1.TabIndex = 63
        Me.CheckBox1.Text = "ACTIVE"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'addDepartment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(534, 590)
        Me.Controls.Add(Me.CBX_I_COM)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStripR_RECNUM)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.TBX_DEPART)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.BTN_CUS_UPDT)
        Me.Controls.Add(Me.BTN_CUS_ADD)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DataGridDEPT)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "addDepartment"
        CType(Me.DataGridDEPT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TBX_DEPART As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents DataGridDEPT As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents ToolStripR_RECNUM As ToolStrip
    Friend WithEvents CBX_I_COM As ComboBox
    Friend WithEvents BTN_CUS_ADD As Button
    Friend WithEvents BTN_CUS_UPDT As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents CheckBox1 As CheckBox
End Class
