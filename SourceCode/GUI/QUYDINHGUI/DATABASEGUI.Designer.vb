<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DATABASEGUI
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.KetNoiButton = New DevExpress.XtraEditors.SimpleButton()
        Me.PasswordTextBox = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.ServerTextBox = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.DatabaseNameTextBox = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.UserTextBox = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PasswordTextBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ServerTextBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatabaseNameTextBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UserTextBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl14
        '
        Me.LabelControl14.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.LabelControl14.Appearance.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl14.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl14.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.LabelControl14.Dock = System.Windows.Forms.DockStyle.Left
        Me.LabelControl14.Location = New System.Drawing.Point(0, 0)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(146, 35)
        Me.LabelControl14.TabIndex = 96
        Me.LabelControl14.Text = "DATABASE"
        '
        'KetNoiButton
        '
        Me.KetNoiButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.KetNoiButton.Appearance.BackColor = System.Drawing.Color.LightGray
        Me.KetNoiButton.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KetNoiButton.Appearance.Options.UseBackColor = True
        Me.KetNoiButton.Appearance.Options.UseFont = True
        Me.KetNoiButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.KetNoiButton.Location = New System.Drawing.Point(354, 373)
        Me.KetNoiButton.Name = "KetNoiButton"
        Me.KetNoiButton.Size = New System.Drawing.Size(168, 90)
        Me.KetNoiButton.TabIndex = 95
        Me.KetNoiButton.Text = "Kết Nối"
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.Location = New System.Drawing.Point(354, 200)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        '
        '
        '
        Me.PasswordTextBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswordTextBox.Properties.Appearance.Options.UseFont = True
        Me.PasswordTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.PasswordTextBox.Properties.MaxLength = 9
        Me.PasswordTextBox.Size = New System.Drawing.Size(439, 36)
        Me.PasswordTextBox.TabIndex = 87
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(96, 203)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(115, 29)
        Me.LabelControl2.TabIndex = 88
        Me.LabelControl2.Text = "Password"
        '
        'ServerTextBox
        '
        Me.ServerTextBox.Location = New System.Drawing.Point(354, 97)
        Me.ServerTextBox.Name = "ServerTextBox"
        '
        '
        '
        Me.ServerTextBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ServerTextBox.Properties.Appearance.Options.UseFont = True
        Me.ServerTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.ServerTextBox.Size = New System.Drawing.Size(439, 36)
        Me.ServerTextBox.TabIndex = 86
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(96, 100)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(77, 29)
        Me.LabelControl1.TabIndex = 97
        Me.LabelControl1.Text = "Server"
        '
        'DatabaseNameTextBox
        '
        Me.DatabaseNameTextBox.Location = New System.Drawing.Point(354, 255)
        Me.DatabaseNameTextBox.Name = "DatabaseNameTextBox"
        '
        '
        '
        Me.DatabaseNameTextBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatabaseNameTextBox.Properties.Appearance.Options.UseFont = True
        Me.DatabaseNameTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.DatabaseNameTextBox.Size = New System.Drawing.Size(439, 36)
        Me.DatabaseNameTextBox.TabIndex = 98
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(96, 258)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(188, 29)
        Me.LabelControl3.TabIndex = 99
        Me.LabelControl3.Text = "Database Name"
        '
        'UserTextBox
        '
        Me.UserTextBox.Location = New System.Drawing.Point(354, 150)
        Me.UserTextBox.Name = "UserTextBox"
        '
        '
        '
        Me.UserTextBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserTextBox.Properties.Appearance.Options.UseFont = True
        Me.UserTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.UserTextBox.Size = New System.Drawing.Size(439, 36)
        Me.UserTextBox.TabIndex = 100
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(96, 153)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(54, 29)
        Me.LabelControl4.TabIndex = 101
        Me.LabelControl4.Text = "User"
        '
        'DATABASEGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(886, 498)
        Me.Controls.Add(Me.UserTextBox)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.DatabaseNameTextBox)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LabelControl14)
        Me.Controls.Add(Me.KetNoiButton)
        Me.Controls.Add(Me.PasswordTextBox)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.ServerTextBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "DATABASEGUI"
        Me.Text = "DATABASEGUI"
        CType(Me.PasswordTextBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ServerTextBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatabaseNameTextBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UserTextBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Private WithEvents KetNoiButton As DevExpress.XtraEditors.SimpleButton
    Private WithEvents PasswordTextBox As DevExpress.XtraEditors.TextEdit
    Private WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Private WithEvents ServerTextBox As DevExpress.XtraEditors.TextEdit
    Private WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Private WithEvents DatabaseNameTextBox As DevExpress.XtraEditors.TextEdit
    Private WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Private WithEvents UserTextBox As DevExpress.XtraEditors.TextEdit
    Private WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
End Class
