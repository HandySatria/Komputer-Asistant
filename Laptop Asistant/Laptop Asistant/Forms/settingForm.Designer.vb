<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class settingForm
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnToken = New System.Windows.Forms.Button()
        Me.txtToken = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboPwd = New System.Windows.Forms.CheckBox()
        Me.btnPwd = New System.Windows.Forms.Button()
        Me.txtPwd = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboNotif = New System.Windows.Forms.CheckBox()
        Me.btnNotif = New System.Windows.Forms.Button()
        Me.txtNotif = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboStartUp = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnUser = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnToken)
        Me.GroupBox1.Controls.Add(Me.txtToken)
        Me.GroupBox1.Location = New System.Drawing.Point(27, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(419, 146)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Token"
        '
        'btnToken
        '
        Me.btnToken.BackColor = System.Drawing.Color.Wheat
        Me.btnToken.Location = New System.Drawing.Point(298, 85)
        Me.btnToken.Name = "btnToken"
        Me.btnToken.Size = New System.Drawing.Size(91, 35)
        Me.btnToken.TabIndex = 2
        Me.btnToken.Text = "Edit"
        Me.btnToken.UseVisualStyleBackColor = False
        '
        'txtToken
        '
        Me.txtToken.Location = New System.Drawing.Point(32, 27)
        Me.txtToken.Multiline = True
        Me.txtToken.Name = "txtToken"
        Me.txtToken.Size = New System.Drawing.Size(356, 52)
        Me.txtToken.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboPwd)
        Me.GroupBox2.Controls.Add(Me.btnPwd)
        Me.GroupBox2.Controls.Add(Me.txtPwd)
        Me.GroupBox2.Location = New System.Drawing.Point(27, 187)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(419, 118)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Password"
        '
        'cboPwd
        '
        Me.cboPwd.AutoSize = True
        Me.cboPwd.Location = New System.Drawing.Point(298, 28)
        Me.cboPwd.Name = "cboPwd"
        Me.cboPwd.Size = New System.Drawing.Size(90, 21)
        Me.cboPwd.TabIndex = 3
        Me.cboPwd.Text = "tampilkan"
        Me.cboPwd.UseVisualStyleBackColor = True
        '
        'btnPwd
        '
        Me.btnPwd.BackColor = System.Drawing.Color.Wheat
        Me.btnPwd.Location = New System.Drawing.Point(298, 67)
        Me.btnPwd.Name = "btnPwd"
        Me.btnPwd.Size = New System.Drawing.Size(91, 35)
        Me.btnPwd.TabIndex = 2
        Me.btnPwd.Text = "Edit"
        Me.btnPwd.UseVisualStyleBackColor = False
        '
        'txtPwd
        '
        Me.txtPwd.Location = New System.Drawing.Point(32, 26)
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPwd.Size = New System.Drawing.Size(253, 22)
        Me.txtPwd.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboNotif)
        Me.GroupBox3.Controls.Add(Me.btnNotif)
        Me.GroupBox3.Controls.Add(Me.txtNotif)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(482, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(410, 180)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'cboNotif
        '
        Me.cboNotif.AutoSize = True
        Me.cboNotif.Location = New System.Drawing.Point(258, 36)
        Me.cboNotif.Name = "cboNotif"
        Me.cboNotif.Size = New System.Drawing.Size(18, 17)
        Me.cboNotif.TabIndex = 3
        Me.cboNotif.UseVisualStyleBackColor = True
        '
        'btnNotif
        '
        Me.btnNotif.BackColor = System.Drawing.Color.Wheat
        Me.btnNotif.Location = New System.Drawing.Point(297, 122)
        Me.btnNotif.Name = "btnNotif"
        Me.btnNotif.Size = New System.Drawing.Size(91, 35)
        Me.btnNotif.TabIndex = 2
        Me.btnNotif.Text = "Edit"
        Me.btnNotif.UseVisualStyleBackColor = False
        '
        'txtNotif
        '
        Me.txtNotif.Location = New System.Drawing.Point(258, 65)
        Me.txtNotif.Name = "txtNotif"
        Me.txtNotif.Size = New System.Drawing.Size(68, 22)
        Me.txtNotif.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(332, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 17)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "menit"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(89, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(163, 17)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Notifikasi Dikirim Setiap :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(236, 17)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Notifikasi Komputer Masih Menyala :"
        '
        'cboStartUp
        '
        Me.cboStartUp.AutoSize = True
        Me.cboStartUp.Location = New System.Drawing.Point(246, 35)
        Me.cboStartUp.Name = "cboStartUp"
        Me.cboStartUp.Size = New System.Drawing.Size(18, 17)
        Me.cboStartUp.TabIndex = 3
        Me.cboStartUp.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(29, 35)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(211, 17)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "jalankan saat komputer dimulai :"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.DataGridView1)
        Me.GroupBox5.Controls.Add(Me.btnUser)
        Me.GroupBox5.Location = New System.Drawing.Point(27, 335)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(419, 373)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(22, 21)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(263, 333)
        Me.DataGridView1.TabIndex = 3
        '
        'btnUser
        '
        Me.btnUser.BackColor = System.Drawing.Color.Wheat
        Me.btnUser.Location = New System.Drawing.Point(298, 21)
        Me.btnUser.Name = "btnUser"
        Me.btnUser.Size = New System.Drawing.Size(91, 35)
        Me.btnUser.TabIndex = 2
        Me.btnUser.Text = "Edit"
        Me.btnUser.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cboStartUp)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Location = New System.Drawing.Point(482, 202)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(302, 87)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        '
        'settingForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(928, 720)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "settingForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SETTING"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnToken As Button
    Friend WithEvents txtToken As TextBox
    Friend WithEvents btnPwd As Button
    Friend WithEvents txtPwd As TextBox
    Friend WithEvents cboNotif As CheckBox
    Friend WithEvents btnNotif As Button
    Friend WithEvents txtNotif As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cboStartUp As CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents btnUser As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents cboPwd As CheckBox
    Friend WithEvents GroupBox4 As GroupBox
End Class
