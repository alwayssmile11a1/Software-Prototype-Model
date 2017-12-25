<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class THAYDOIQUYDINHGUI
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
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SoLuongNhapItNhatTextBox = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.SoLuongTonToiDaTruocKhiNhapTextBox = New DevExpress.XtraEditors.TextEdit()
        Me.TienNoToiDaTextBox = New DevExpress.XtraEditors.TextEdit()
        Me.LuongTonToiThieuSauBanTextBox = New DevExpress.XtraEditors.TextEdit()
        Me.SuDungQuyDinh4CheckBox = New DevExpress.XtraEditors.CheckEdit()
        Me.ApplyButton = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.SoLuongNhapItNhatTextBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoLuongTonToiDaTruocKhiNhapTextBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TienNoToiDaTextBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LuongTonToiThieuSauBanTextBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SuDungQuyDinh4CheckBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(27, 86)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(300, 29)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Số Lượng Nhập Tối Thiểu"
        '
        'SoLuongNhapItNhatTextBox
        '
        Me.SoLuongNhapItNhatTextBox.Location = New System.Drawing.Point(504, 83)
        Me.SoLuongNhapItNhatTextBox.Name = "SoLuongNhapItNhatTextBox"
        Me.SoLuongNhapItNhatTextBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SoLuongNhapItNhatTextBox.Properties.Appearance.Options.UseFont = True
        Me.SoLuongNhapItNhatTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.SoLuongNhapItNhatTextBox.Properties.Mask.EditMask = "n0"
        Me.SoLuongNhapItNhatTextBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.SoLuongNhapItNhatTextBox.Properties.MaxLength = 9
        Me.SoLuongNhapItNhatTextBox.Size = New System.Drawing.Size(439, 36)
        Me.SoLuongNhapItNhatTextBox.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(27, 152)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(442, 29)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Số Lượng Tồn Tối Đa Trước Khi Nhập"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(27, 220)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(213, 29)
        Me.LabelControl3.TabIndex = 3
        Me.LabelControl3.Text = "Số Tiền Nợ Tối Đa"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(27, 291)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(385, 29)
        Me.LabelControl4.TabIndex = 4
        Me.LabelControl4.Text = "Số Lượng Tồn Tối Thiểu Sau Bán"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(27, 369)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(241, 29)
        Me.LabelControl5.TabIndex = 5
        Me.LabelControl5.Text = "Sử Dụng Quy Định 4"
        '
        'SoLuongTonToiDaTruocKhiNhapTextBox
        '
        Me.SoLuongTonToiDaTruocKhiNhapTextBox.Location = New System.Drawing.Point(504, 149)
        Me.SoLuongTonToiDaTruocKhiNhapTextBox.Name = "SoLuongTonToiDaTruocKhiNhapTextBox"
        Me.SoLuongTonToiDaTruocKhiNhapTextBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SoLuongTonToiDaTruocKhiNhapTextBox.Properties.Appearance.Options.UseFont = True
        Me.SoLuongTonToiDaTruocKhiNhapTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.SoLuongTonToiDaTruocKhiNhapTextBox.Properties.Mask.EditMask = "n0"
        Me.SoLuongTonToiDaTruocKhiNhapTextBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.SoLuongTonToiDaTruocKhiNhapTextBox.Properties.MaxLength = 9
        Me.SoLuongTonToiDaTruocKhiNhapTextBox.Size = New System.Drawing.Size(439, 36)
        Me.SoLuongTonToiDaTruocKhiNhapTextBox.TabIndex = 2
        '
        'TienNoToiDaTextBox
        '
        Me.TienNoToiDaTextBox.Location = New System.Drawing.Point(504, 217)
        Me.TienNoToiDaTextBox.Name = "TienNoToiDaTextBox"
        Me.TienNoToiDaTextBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TienNoToiDaTextBox.Properties.Appearance.Options.UseFont = True
        Me.TienNoToiDaTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.TienNoToiDaTextBox.Properties.Mask.EditMask = "c0"
        Me.TienNoToiDaTextBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TienNoToiDaTextBox.Properties.MaxLength = 10
        Me.TienNoToiDaTextBox.Size = New System.Drawing.Size(439, 36)
        Me.TienNoToiDaTextBox.TabIndex = 3
        '
        'LuongTonToiThieuSauBanTextBox
        '
        Me.LuongTonToiThieuSauBanTextBox.Location = New System.Drawing.Point(504, 285)
        Me.LuongTonToiThieuSauBanTextBox.Name = "LuongTonToiThieuSauBanTextBox"
        Me.LuongTonToiThieuSauBanTextBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LuongTonToiThieuSauBanTextBox.Properties.Appearance.Options.UseFont = True
        Me.LuongTonToiThieuSauBanTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.LuongTonToiThieuSauBanTextBox.Properties.Mask.EditMask = "n0"
        Me.LuongTonToiThieuSauBanTextBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.LuongTonToiThieuSauBanTextBox.Properties.MaxLength = 9
        Me.LuongTonToiThieuSauBanTextBox.Size = New System.Drawing.Size(439, 36)
        Me.LuongTonToiThieuSauBanTextBox.TabIndex = 4
        '
        'SuDungQuyDinh4CheckBox
        '
        Me.SuDungQuyDinh4CheckBox.Location = New System.Drawing.Point(504, 366)
        Me.SuDungQuyDinh4CheckBox.Name = "SuDungQuyDinh4CheckBox"
        Me.SuDungQuyDinh4CheckBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuDungQuyDinh4CheckBox.Properties.Appearance.Options.UseFont = True
        Me.SuDungQuyDinh4CheckBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.SuDungQuyDinh4CheckBox.Properties.Caption = "Sử dụng"
        Me.SuDungQuyDinh4CheckBox.Size = New System.Drawing.Size(405, 35)
        Me.SuDungQuyDinh4CheckBox.TabIndex = 5
        '
        'ApplyButton
        '
        Me.ApplyButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ApplyButton.Appearance.BackColor = System.Drawing.Color.LightGray
        Me.ApplyButton.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApplyButton.Appearance.Options.UseBackColor = True
        Me.ApplyButton.Appearance.Options.UseFont = True
        Me.ApplyButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.ApplyButton.Location = New System.Drawing.Point(405, 486)
        Me.ApplyButton.Name = "ApplyButton"
        Me.ApplyButton.Size = New System.Drawing.Size(168, 90)
        Me.ApplyButton.TabIndex = 6
        Me.ApplyButton.Text = "Áp Dụng"
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
        Me.LabelControl14.Size = New System.Drawing.Size(255, 35)
        Me.LabelControl14.TabIndex = 83
        Me.LabelControl14.Text = "Thay Đổi Quy Định"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(27, 419)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(489, 18)
        Me.LabelControl6.TabIndex = 84
        Me.LabelControl6.Text = "Quy định 4: Số tiền thu không được vượt quá số tiền khách hàng đang nợ"
        '
        'THAYDOIQUYDINHGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(990, 588)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.LabelControl14)
        Me.Controls.Add(Me.ApplyButton)
        Me.Controls.Add(Me.SuDungQuyDinh4CheckBox)
        Me.Controls.Add(Me.LuongTonToiThieuSauBanTextBox)
        Me.Controls.Add(Me.TienNoToiDaTextBox)
        Me.Controls.Add(Me.SoLuongTonToiDaTruocKhiNhapTextBox)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.SoLuongNhapItNhatTextBox)
        Me.Controls.Add(Me.LabelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "THAYDOIQUYDINHGUI"
        Me.Text = "THAYDOIQUYDINHGUI"
        CType(Me.SoLuongNhapItNhatTextBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoLuongTonToiDaTruocKhiNhapTextBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TienNoToiDaTextBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LuongTonToiThieuSauBanTextBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SuDungQuyDinh4CheckBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SoLuongNhapItNhatTextBox As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SoLuongTonToiDaTruocKhiNhapTextBox As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TienNoToiDaTextBox As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LuongTonToiThieuSauBanTextBox As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SuDungQuyDinh4CheckBox As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents ApplyButton As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
End Class
