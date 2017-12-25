<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class REMOVEDKHACHHANGGUI
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
        Me.KhoiPhucKhachHangButton = New DevExpress.XtraEditors.SimpleButton()
        Me.ThongTinKhachHangGridControl = New DevExpress.XtraGrid.GridControl()
        Me.ThongTinKhachHangGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SoTienNoTraCuuTextBox = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.EmailTraCuuTextBox = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.DienThoaiTraCuuTextBox = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.DiaChiTraCuuTextBox = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.HoTenTraCuuTextBox = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.MaKhachHangTraCuuTextBox = New DevExpress.XtraEditors.TextEdit()
        Me.KieuSoSanhComboBox = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.TongSoKetQuaLabelControl = New DevExpress.XtraEditors.LabelControl()
        Me.TimTatCaButton = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.ThongTinKhachHangGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ThongTinKhachHangGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoTienNoTraCuuTextBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmailTraCuuTextBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DienThoaiTraCuuTextBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DiaChiTraCuuTextBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HoTenTraCuuTextBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MaKhachHangTraCuuTextBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KieuSoSanhComboBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KhoiPhucKhachHangButton
        '
        Me.KhoiPhucKhachHangButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.KhoiPhucKhachHangButton.Appearance.BackColor = System.Drawing.Color.LightGray
        Me.KhoiPhucKhachHangButton.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KhoiPhucKhachHangButton.Appearance.Options.UseBackColor = True
        Me.KhoiPhucKhachHangButton.Appearance.Options.UseFont = True
        Me.KhoiPhucKhachHangButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.KhoiPhucKhachHangButton.Location = New System.Drawing.Point(366, 488)
        Me.KhoiPhucKhachHangButton.Name = "KhoiPhucKhachHangButton"
        Me.KhoiPhucKhachHangButton.Size = New System.Drawing.Size(175, 66)
        Me.KhoiPhucKhachHangButton.TabIndex = 10
        Me.KhoiPhucKhachHangButton.Text = "Khôi Phục Khách Hàng"
        '
        'ThongTinKhachHangGridControl
        '
        Me.ThongTinKhachHangGridControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ThongTinKhachHangGridControl.Location = New System.Drawing.Point(26, 198)
        Me.ThongTinKhachHangGridControl.MainView = Me.ThongTinKhachHangGridView
        Me.ThongTinKhachHangGridControl.Name = "ThongTinKhachHangGridControl"
        Me.ThongTinKhachHangGridControl.Size = New System.Drawing.Size(827, 271)
        Me.ThongTinKhachHangGridControl.TabIndex = 15
        Me.ThongTinKhachHangGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ThongTinKhachHangGridView})
        '
        'ThongTinKhachHangGridView
        '
        Me.ThongTinKhachHangGridView.GridControl = Me.ThongTinKhachHangGridControl
        Me.ThongTinKhachHangGridView.GroupPanelText = "Lập phiếu nhập sách"
        Me.ThongTinKhachHangGridView.Name = "ThongTinKhachHangGridView"
        Me.ThongTinKhachHangGridView.OptionsBehavior.Editable = False
        Me.ThongTinKhachHangGridView.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.[Default]
        Me.ThongTinKhachHangGridView.OptionsView.ShowGroupPanel = False
        '
        'SoTienNoTraCuuTextBox
        '
        Me.SoTienNoTraCuuTextBox.Location = New System.Drawing.Point(563, 41)
        Me.SoTienNoTraCuuTextBox.Name = "SoTienNoTraCuuTextBox"
        Me.SoTienNoTraCuuTextBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SoTienNoTraCuuTextBox.Properties.Appearance.Options.UseFont = True
        Me.SoTienNoTraCuuTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.SoTienNoTraCuuTextBox.Properties.Mask.EditMask = "c0"
        Me.SoTienNoTraCuuTextBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.SoTienNoTraCuuTextBox.Properties.MaxLength = 10
        Me.SoTienNoTraCuuTextBox.Size = New System.Drawing.Size(187, 24)
        Me.SoTienNoTraCuuTextBox.TabIndex = 7
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(320, 44)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(72, 18)
        Me.LabelControl1.TabIndex = 77
        Me.LabelControl1.Text = "Số Tiền Nợ"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(27, 76)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(49, 18)
        Me.LabelControl2.TabIndex = 68
        Me.LabelControl2.Text = "Họ Tên"
        '
        'EmailTraCuuTextBox
        '
        Me.EmailTraCuuTextBox.Location = New System.Drawing.Point(134, 162)
        Me.EmailTraCuuTextBox.Name = "EmailTraCuuTextBox"
        Me.EmailTraCuuTextBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmailTraCuuTextBox.Properties.Appearance.Options.UseFont = True
        Me.EmailTraCuuTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.EmailTraCuuTextBox.Size = New System.Drawing.Size(172, 24)
        Me.EmailTraCuuTextBox.TabIndex = 5
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(27, 108)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(44, 18)
        Me.LabelControl3.TabIndex = 70
        Me.LabelControl3.Text = "Địa Chỉ"
        '
        'DienThoaiTraCuuTextBox
        '
        Me.DienThoaiTraCuuTextBox.Location = New System.Drawing.Point(134, 134)
        Me.DienThoaiTraCuuTextBox.Name = "DienThoaiTraCuuTextBox"
        Me.DienThoaiTraCuuTextBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DienThoaiTraCuuTextBox.Properties.Appearance.Options.UseFont = True
        Me.DienThoaiTraCuuTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.DienThoaiTraCuuTextBox.Properties.Mask.EditMask = "(9999) 000-000"
        Me.DienThoaiTraCuuTextBox.Size = New System.Drawing.Size(172, 24)
        Me.DienThoaiTraCuuTextBox.TabIndex = 4
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(27, 137)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(69, 18)
        Me.LabelControl4.TabIndex = 73
        Me.LabelControl4.Text = "Điện Thoại"
        '
        'DiaChiTraCuuTextBox
        '
        Me.DiaChiTraCuuTextBox.Location = New System.Drawing.Point(134, 105)
        Me.DiaChiTraCuuTextBox.Name = "DiaChiTraCuuTextBox"
        Me.DiaChiTraCuuTextBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DiaChiTraCuuTextBox.Properties.Appearance.Options.UseFont = True
        Me.DiaChiTraCuuTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.DiaChiTraCuuTextBox.Size = New System.Drawing.Size(172, 24)
        Me.DiaChiTraCuuTextBox.TabIndex = 3
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(27, 165)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(33, 18)
        Me.LabelControl5.TabIndex = 75
        Me.LabelControl5.Text = "Email"
        '
        'HoTenTraCuuTextBox
        '
        Me.HoTenTraCuuTextBox.Location = New System.Drawing.Point(134, 73)
        Me.HoTenTraCuuTextBox.Name = "HoTenTraCuuTextBox"
        Me.HoTenTraCuuTextBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HoTenTraCuuTextBox.Properties.Appearance.Options.UseFont = True
        Me.HoTenTraCuuTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.HoTenTraCuuTextBox.Size = New System.Drawing.Size(172, 24)
        Me.HoTenTraCuuTextBox.TabIndex = 2
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(27, 44)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(104, 18)
        Me.LabelControl6.TabIndex = 66
        Me.LabelControl6.Text = "Mã Khách Hàng"
        '
        'MaKhachHangTraCuuTextBox
        '
        Me.MaKhachHangTraCuuTextBox.Location = New System.Drawing.Point(134, 41)
        Me.MaKhachHangTraCuuTextBox.Name = "MaKhachHangTraCuuTextBox"
        Me.MaKhachHangTraCuuTextBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaKhachHangTraCuuTextBox.Properties.Appearance.Options.UseFont = True
        Me.MaKhachHangTraCuuTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.MaKhachHangTraCuuTextBox.Size = New System.Drawing.Size(172, 24)
        Me.MaKhachHangTraCuuTextBox.TabIndex = 1
        '
        'KieuSoSanhComboBox
        '
        Me.KieuSoSanhComboBox.Location = New System.Drawing.Point(404, 41)
        Me.KieuSoSanhComboBox.Name = "KieuSoSanhComboBox"
        Me.KieuSoSanhComboBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KieuSoSanhComboBox.Properties.Appearance.Options.UseFont = True
        Me.KieuSoSanhComboBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.KieuSoSanhComboBox.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.KieuSoSanhComboBox.Size = New System.Drawing.Size(153, 24)
        Me.KieuSoSanhComboBox.TabIndex = 6
        '
        'TongSoKetQuaLabelControl
        '
        Me.TongSoKetQuaLabelControl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TongSoKetQuaLabelControl.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TongSoKetQuaLabelControl.Location = New System.Drawing.Point(761, 475)
        Me.TongSoKetQuaLabelControl.Name = "TongSoKetQuaLabelControl"
        Me.TongSoKetQuaLabelControl.Size = New System.Drawing.Size(92, 14)
        Me.TongSoKetQuaLabelControl.TabIndex = 78
        Me.TongSoKetQuaLabelControl.Text = "Tổng số kết quả"
        '
        'TimTatCaButton
        '
        Me.TimTatCaButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TimTatCaButton.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimTatCaButton.Appearance.Options.UseFont = True
        Me.TimTatCaButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.TimTatCaButton.Location = New System.Drawing.Point(761, 169)
        Me.TimTatCaButton.Name = "TimTatCaButton"
        Me.TimTatCaButton.Size = New System.Drawing.Size(92, 23)
        Me.TimTatCaButton.TabIndex = 20
        Me.TimTatCaButton.Text = "Tìm Tất Cả"
        '
        'LabelControl14
        '
        Me.LabelControl14.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl14.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl14.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl14.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.LabelControl14.Dock = System.Windows.Forms.DockStyle.Left
        Me.LabelControl14.Location = New System.Drawing.Point(0, 0)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(271, 25)
        Me.LabelControl14.TabIndex = 80
        Me.LabelControl14.Text = "Tra Cứu Khách Hàng Đã Xóa"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton1.Appearance.Options.UseFont = True
        Me.SimpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.SimpleButton1.Location = New System.Drawing.Point(625, 169)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(125, 23)
        Me.SimpleButton1.TabIndex = 81
        Me.SimpleButton1.Text = "Tìm theo điều kiện"
        '
        'REMOVEDKHACHHANGGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(902, 575)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.LabelControl14)
        Me.Controls.Add(Me.TimTatCaButton)
        Me.Controls.Add(Me.TongSoKetQuaLabelControl)
        Me.Controls.Add(Me.SoTienNoTraCuuTextBox)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.EmailTraCuuTextBox)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.DienThoaiTraCuuTextBox)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.DiaChiTraCuuTextBox)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.HoTenTraCuuTextBox)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.MaKhachHangTraCuuTextBox)
        Me.Controls.Add(Me.KieuSoSanhComboBox)
        Me.Controls.Add(Me.KhoiPhucKhachHangButton)
        Me.Controls.Add(Me.ThongTinKhachHangGridControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "REMOVEDKHACHHANGGUI"
        Me.Text = "REMOVEDKHACHHANGGUI"
        CType(Me.ThongTinKhachHangGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ThongTinKhachHangGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoTienNoTraCuuTextBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmailTraCuuTextBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DienThoaiTraCuuTextBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DiaChiTraCuuTextBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HoTenTraCuuTextBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MaKhachHangTraCuuTextBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KieuSoSanhComboBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents KhoiPhucKhachHangButton As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ThongTinKhachHangGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents ThongTinKhachHangGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SoTienNoTraCuuTextBox As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents EmailTraCuuTextBox As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DienThoaiTraCuuTextBox As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DiaChiTraCuuTextBox As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents HoTenTraCuuTextBox As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MaKhachHangTraCuuTextBox As DevExpress.XtraEditors.TextEdit
    Friend WithEvents KieuSoSanhComboBox As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents TongSoKetQuaLabelControl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TimTatCaButton As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
End Class
