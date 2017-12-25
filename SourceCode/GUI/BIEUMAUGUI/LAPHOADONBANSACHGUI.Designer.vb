<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LAPHOADONBANSACHGUI
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LapHoaDonBanSachGridControl = New DevExpress.XtraGrid.GridControl()
        Me.LapHoaDonBanSachGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.HoTenTextBox = New DevExpress.XtraEditors.TextEdit()
        Me.DiaChiTextBox = New DevExpress.XtraEditors.TextEdit()
        Me.MaKhachHangTextBox = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.SoTienNoTextBox = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.SoLuongTonToiThieuTextBox = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.SoTienNoToiDaTextBox = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LapHoaDonButton = New DevExpress.XtraEditors.SimpleButton()
        Me.NgayLapHoaDonDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.ToolTipController = New DevExpress.Utils.ToolTipController(Me.components)
        Me.TaoPhieuMoiButton = New DevExpress.XtraEditors.SimpleButton()
        Me.TongThanhTienTextBox = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.ThongBaoLabel = New DevExpress.XtraEditors.LabelControl()
        Me.XuatFileExelButton = New DevExpress.XtraEditors.SimpleButton()
        Me.progressBarControl = New DevExpress.XtraEditors.ProgressBarControl()
        Me.BackgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.SaveDialog = New System.Windows.Forms.SaveFileDialog()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.OpenDialog = New System.Windows.Forms.OpenFileDialog()
        Me.NhapFileExcelButton = New DevExpress.XtraEditors.SimpleButton()
        Me.LayFileExcelFormatButton = New DevExpress.XtraEditors.SimpleButton()
        Me.AllBookIDsListBox = New DevExpress.XtraEditors.ListBoxControl()
        Me.AllCustomerIDsListBox = New DevExpress.XtraEditors.ListBoxControl()
        Me.LapPhieuThuTienButton = New DevExpress.XtraEditors.SimpleButton()
        Me.LichSuThaoTacFlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.LapHoaDonBanSachGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LapHoaDonBanSachGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HoTenTextBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DiaChiTextBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MaKhachHangTextBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoTienNoTextBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoLuongTonToiThieuTextBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoTienNoToiDaTextBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TongThanhTienTextBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.progressBarControl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AllBookIDsListBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AllCustomerIDsListBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LichSuThaoTacFlowLayoutPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(31, 122)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(44, 18)
        Me.LabelControl3.TabIndex = 25
        Me.LabelControl3.Text = "Địa Chỉ"
        '
        'LapHoaDonBanSachGridControl
        '
        Me.LapHoaDonBanSachGridControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LapHoaDonBanSachGridControl.Location = New System.Drawing.Point(31, 201)
        Me.LapHoaDonBanSachGridControl.MainView = Me.LapHoaDonBanSachGridView
        Me.LapHoaDonBanSachGridControl.Name = "LapHoaDonBanSachGridControl"
        Me.LapHoaDonBanSachGridControl.Size = New System.Drawing.Size(1063, 302)
        Me.LapHoaDonBanSachGridControl.TabIndex = 8
        Me.LapHoaDonBanSachGridControl.UseEmbeddedNavigator = True
        Me.LapHoaDonBanSachGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.LapHoaDonBanSachGridView})
        '
        'LapHoaDonBanSachGridView
        '
        Me.LapHoaDonBanSachGridView.GridControl = Me.LapHoaDonBanSachGridControl
        Me.LapHoaDonBanSachGridView.GroupPanelText = "Lập phiếu nhập sách"
        Me.LapHoaDonBanSachGridView.Name = "LapHoaDonBanSachGridView"
        Me.LapHoaDonBanSachGridView.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.[Default]
        Me.LapHoaDonBanSachGridView.OptionsView.ShowGroupPanel = False
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(31, 95)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(133, 18)
        Me.LabelControl2.TabIndex = 21
        Me.LabelControl2.Text = "Họ Tên Khách Hàng"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(31, 41)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(124, 18)
        Me.LabelControl1.TabIndex = 20
        Me.LabelControl1.Text = "Ngày Lập Hóa Đơn"
        '
        'HoTenTextBox
        '
        Me.HoTenTextBox.Location = New System.Drawing.Point(193, 91)
        Me.HoTenTextBox.Name = "HoTenTextBox"
        Me.HoTenTextBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HoTenTextBox.Properties.Appearance.Options.UseFont = True
        Me.HoTenTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.HoTenTextBox.Size = New System.Drawing.Size(196, 24)
        Me.HoTenTextBox.TabIndex = 3
        '
        'DiaChiTextBox
        '
        Me.DiaChiTextBox.Location = New System.Drawing.Point(193, 117)
        Me.DiaChiTextBox.Name = "DiaChiTextBox"
        Me.DiaChiTextBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DiaChiTextBox.Properties.Appearance.Options.UseFont = True
        Me.DiaChiTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.DiaChiTextBox.Size = New System.Drawing.Size(196, 24)
        Me.DiaChiTextBox.TabIndex = 4
        '
        'MaKhachHangTextBox
        '
        Me.MaKhachHangTextBox.Location = New System.Drawing.Point(193, 65)
        Me.MaKhachHangTextBox.Name = "MaKhachHangTextBox"
        Me.MaKhachHangTextBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaKhachHangTextBox.Properties.Appearance.Options.UseFont = True
        Me.MaKhachHangTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.MaKhachHangTextBox.Size = New System.Drawing.Size(143, 24)
        Me.MaKhachHangTextBox.TabIndex = 2
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(31, 70)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(104, 18)
        Me.LabelControl4.TabIndex = 28
        Me.LabelControl4.Text = "Mã Khách Hàng"
        '
        'SoTienNoTextBox
        '
        Me.SoTienNoTextBox.Location = New System.Drawing.Point(193, 143)
        Me.SoTienNoTextBox.Name = "SoTienNoTextBox"
        Me.SoTienNoTextBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SoTienNoTextBox.Properties.Appearance.Options.UseFont = True
        Me.SoTienNoTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.SoTienNoTextBox.Size = New System.Drawing.Size(196, 24)
        Me.SoTienNoTextBox.TabIndex = 5
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(31, 148)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(156, 18)
        Me.LabelControl5.TabIndex = 30
        Me.LabelControl5.Text = "Số Tiền Khách Hàng Nợ"
        '
        'SoLuongTonToiThieuTextBox
        '
        Me.SoLuongTonToiThieuTextBox.Location = New System.Drawing.Point(597, 116)
        Me.SoLuongTonToiThieuTextBox.Name = "SoLuongTonToiThieuTextBox"
        Me.SoLuongTonToiThieuTextBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SoLuongTonToiThieuTextBox.Properties.Appearance.Options.UseFont = True
        Me.SoLuongTonToiThieuTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.SoLuongTonToiThieuTextBox.Size = New System.Drawing.Size(110, 24)
        Me.SoLuongTonToiThieuTextBox.TabIndex = 11
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(428, 115)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(163, 36)
        Me.LabelControl6.TabIndex = 32
        Me.LabelControl6.Text = "Số Lượng Tồn Tối Thiểu " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Sau Khi Bán "
        '
        'SoTienNoToiDaTextBox
        '
        Me.SoTienNoToiDaTextBox.Location = New System.Drawing.Point(597, 145)
        Me.SoTienNoToiDaTextBox.Name = "SoTienNoToiDaTextBox"
        Me.SoTienNoToiDaTextBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SoTienNoToiDaTextBox.Properties.Appearance.Options.UseFont = True
        Me.SoTienNoToiDaTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.SoTienNoToiDaTextBox.Size = New System.Drawing.Size(110, 24)
        Me.SoTienNoToiDaTextBox.TabIndex = 12
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(428, 153)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(120, 18)
        Me.LabelControl7.TabIndex = 34
        Me.LabelControl7.Text = "Số Tiền Nợ Tối Đa"
        '
        'LapHoaDonButton
        '
        Me.LapHoaDonButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.LapHoaDonButton.Appearance.BackColor = System.Drawing.Color.LightGray
        Me.LapHoaDonButton.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LapHoaDonButton.Appearance.Options.UseBackColor = True
        Me.LapHoaDonButton.Appearance.Options.UseFont = True
        Me.LapHoaDonButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.LapHoaDonButton.Location = New System.Drawing.Point(495, 509)
        Me.LapHoaDonButton.Name = "LapHoaDonButton"
        Me.LapHoaDonButton.Size = New System.Drawing.Size(117, 45)
        Me.LapHoaDonButton.TabIndex = 9
        Me.LapHoaDonButton.Text = "Lập Hóa Đơn"
        '
        'NgayLapHoaDonDateTimePicker
        '
        Me.NgayLapHoaDonDateTimePicker.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NgayLapHoaDonDateTimePicker.Location = New System.Drawing.Point(193, 33)
        Me.NgayLapHoaDonDateTimePicker.Name = "NgayLapHoaDonDateTimePicker"
        Me.NgayLapHoaDonDateTimePicker.Size = New System.Drawing.Size(207, 26)
        Me.NgayLapHoaDonDateTimePicker.TabIndex = 37
        '
        'TaoPhieuMoiButton
        '
        Me.TaoPhieuMoiButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TaoPhieuMoiButton.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.TaoPhieuMoiButton.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaoPhieuMoiButton.Appearance.Options.UseBackColor = True
        Me.TaoPhieuMoiButton.Appearance.Options.UseFont = True
        Me.TaoPhieuMoiButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.TaoPhieuMoiButton.Location = New System.Drawing.Point(30, 509)
        Me.TaoPhieuMoiButton.Name = "TaoPhieuMoiButton"
        Me.TaoPhieuMoiButton.Size = New System.Drawing.Size(120, 45)
        Me.TaoPhieuMoiButton.TabIndex = 38
        Me.TaoPhieuMoiButton.Text = "Tạo Phiếu Mới"
        '
        'TongThanhTienTextBox
        '
        Me.TongThanhTienTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TongThanhTienTextBox.Location = New System.Drawing.Point(900, 169)
        Me.TongThanhTienTextBox.Name = "TongThanhTienTextBox"
        Me.TongThanhTienTextBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TongThanhTienTextBox.Properties.Appearance.Options.UseFont = True
        Me.TongThanhTienTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.TongThanhTienTextBox.Size = New System.Drawing.Size(193, 26)
        Me.TongThanhTienTextBox.TabIndex = 13
        '
        'LabelControl8
        '
        Me.LabelControl8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Location = New System.Drawing.Point(756, 172)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(138, 19)
        Me.LabelControl8.TabIndex = 40
        Me.LabelControl8.Text = "Tổng Thành Tiền"
        '
        'ThongBaoLabel
        '
        Me.ThongBaoLabel.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ThongBaoLabel.Appearance.ForeColor = System.Drawing.Color.Red
        Me.ThongBaoLabel.Location = New System.Drawing.Point(418, 39)
        Me.ThongBaoLabel.Name = "ThongBaoLabel"
        Me.ThongBaoLabel.Size = New System.Drawing.Size(79, 18)
        Me.ThongBaoLabel.TabIndex = 41
        Me.ThongBaoLabel.Text = "Thông Báo"
        Me.ThongBaoLabel.Visible = False
        '
        'XuatFileExelButton
        '
        Me.XuatFileExelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XuatFileExelButton.Appearance.BackColor = System.Drawing.Color.LightGray
        Me.XuatFileExelButton.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XuatFileExelButton.Appearance.Options.UseBackColor = True
        Me.XuatFileExelButton.Appearance.Options.UseFont = True
        Me.XuatFileExelButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.XuatFileExelButton.Location = New System.Drawing.Point(983, 509)
        Me.XuatFileExelButton.Name = "XuatFileExelButton"
        Me.XuatFileExelButton.Size = New System.Drawing.Size(110, 45)
        Me.XuatFileExelButton.TabIndex = 10
        Me.XuatFileExelButton.Text = "Xuất File Exel"
        '
        'progressBarControl
        '
        Me.progressBarControl.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.progressBarControl.EditValue = "0"
        Me.progressBarControl.Location = New System.Drawing.Point(0, 662)
        Me.progressBarControl.Name = "progressBarControl"
        Me.progressBarControl.Properties.ShowTitle = True
        Me.progressBarControl.Properties.Step = 1
        Me.progressBarControl.Size = New System.Drawing.Size(1122, 31)
        Me.progressBarControl.TabIndex = 43
        '
        'BackgroundWorker
        '
        '
        'LabelControl14
        '
        Me.LabelControl14.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.LabelControl14.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl14.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl14.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.LabelControl14.Dock = System.Windows.Forms.DockStyle.Left
        Me.LabelControl14.Location = New System.Drawing.Point(0, 0)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(218, 25)
        Me.LabelControl14.TabIndex = 82
        Me.LabelControl14.Text = "Lập Hóa Đơn Bán Sách"
        '
        'NhapFileExcelButton
        '
        Me.NhapFileExcelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NhapFileExcelButton.Appearance.BackColor = System.Drawing.Color.LightGray
        Me.NhapFileExcelButton.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NhapFileExcelButton.Appearance.Options.UseBackColor = True
        Me.NhapFileExcelButton.Appearance.Options.UseFont = True
        Me.NhapFileExcelButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.NhapFileExcelButton.Location = New System.Drawing.Point(853, 509)
        Me.NhapFileExcelButton.Name = "NhapFileExcelButton"
        Me.NhapFileExcelButton.Size = New System.Drawing.Size(124, 45)
        Me.NhapFileExcelButton.TabIndex = 83
        Me.NhapFileExcelButton.Text = "Nhập Từ File Excel"
        '
        'LayFileExcelFormatButton
        '
        Me.LayFileExcelFormatButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LayFileExcelFormatButton.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.LayFileExcelFormatButton.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayFileExcelFormatButton.Appearance.Options.UseBackColor = True
        Me.LayFileExcelFormatButton.Appearance.Options.UseFont = True
        Me.LayFileExcelFormatButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.LayFileExcelFormatButton.Location = New System.Drawing.Point(735, 510)
        Me.LayFileExcelFormatButton.Name = "LayFileExcelFormatButton"
        Me.LayFileExcelFormatButton.Size = New System.Drawing.Size(112, 25)
        Me.LayFileExcelFormatButton.TabIndex = 84
        Me.LayFileExcelFormatButton.Text = "Lấy File Excel Mẫu"
        Me.LayFileExcelFormatButton.ToolTip = "Xuất một file excel theo format giúp bổ trợ cho việc Nhập từ File Excel"
        '
        'AllBookIDsListBox
        '
        Me.AllBookIDsListBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.AllBookIDsListBox.Location = New System.Drawing.Point(31, 264)
        Me.AllBookIDsListBox.Name = "AllBookIDsListBox"
        Me.AllBookIDsListBox.Size = New System.Drawing.Size(120, 95)
        Me.AllBookIDsListBox.TabIndex = 87
        Me.AllBookIDsListBox.Visible = False
        '
        'AllCustomerIDsListBox
        '
        Me.AllCustomerIDsListBox.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AllCustomerIDsListBox.Appearance.Options.UseFont = True
        Me.AllCustomerIDsListBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.AllCustomerIDsListBox.Location = New System.Drawing.Point(342, 65)
        Me.AllCustomerIDsListBox.Name = "AllCustomerIDsListBox"
        Me.AllCustomerIDsListBox.Size = New System.Drawing.Size(92, 95)
        Me.AllCustomerIDsListBox.TabIndex = 88
        Me.AllCustomerIDsListBox.Visible = False
        '
        'LapPhieuThuTienButton
        '
        Me.LapPhieuThuTienButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.LapPhieuThuTienButton.Appearance.BackColor = System.Drawing.Color.LightGray
        Me.LapPhieuThuTienButton.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LapPhieuThuTienButton.Appearance.Options.UseBackColor = True
        Me.LapPhieuThuTienButton.Appearance.Options.UseFont = True
        Me.LapPhieuThuTienButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.LapPhieuThuTienButton.Location = New System.Drawing.Point(330, 509)
        Me.LapPhieuThuTienButton.Name = "LapPhieuThuTienButton"
        Me.LapPhieuThuTienButton.Size = New System.Drawing.Size(159, 25)
        Me.LapPhieuThuTienButton.TabIndex = 89
        Me.LapPhieuThuTienButton.Text = "Đến Lập Phiếu Thu Tiền"
        '
        'LichSuThaoTacFlowLayoutPanel
        '
        Me.LichSuThaoTacFlowLayoutPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LichSuThaoTacFlowLayoutPanel.AutoScroll = True
        Me.LichSuThaoTacFlowLayoutPanel.BackColor = System.Drawing.Color.Gainsboro
        Me.LichSuThaoTacFlowLayoutPanel.Controls.Add(Me.LabelControl10)
        Me.LichSuThaoTacFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.LichSuThaoTacFlowLayoutPanel.Location = New System.Drawing.Point(0, 571)
        Me.LichSuThaoTacFlowLayoutPanel.Name = "LichSuThaoTacFlowLayoutPanel"
        Me.LichSuThaoTacFlowLayoutPanel.Size = New System.Drawing.Size(1122, 122)
        Me.LichSuThaoTacFlowLayoutPanel.TabIndex = 90
        Me.LichSuThaoTacFlowLayoutPanel.WrapContents = False
        '
        'LabelControl10
        '
        Me.LabelControl10.Appearance.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.LabelControl10.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl10.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.LabelControl10.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.LabelControl10.Location = New System.Drawing.Point(3, 3)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(203, 27)
        Me.LabelControl10.TabIndex = 0
        Me.LabelControl10.Text = "Lịch Sử Lập Hóa Đơn"
        '
        'LAPHOADONBANSACHGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1122, 693)
        Me.Controls.Add(Me.LapPhieuThuTienButton)
        Me.Controls.Add(Me.AllCustomerIDsListBox)
        Me.Controls.Add(Me.AllBookIDsListBox)
        Me.Controls.Add(Me.LayFileExcelFormatButton)
        Me.Controls.Add(Me.NhapFileExcelButton)
        Me.Controls.Add(Me.LabelControl14)
        Me.Controls.Add(Me.progressBarControl)
        Me.Controls.Add(Me.XuatFileExelButton)
        Me.Controls.Add(Me.ThongBaoLabel)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.TongThanhTienTextBox)
        Me.Controls.Add(Me.TaoPhieuMoiButton)
        Me.Controls.Add(Me.NgayLapHoaDonDateTimePicker)
        Me.Controls.Add(Me.LapHoaDonButton)
        Me.Controls.Add(Me.SoTienNoToiDaTextBox)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.SoLuongTonToiThieuTextBox)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.SoTienNoTextBox)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.MaKhachHangTextBox)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.DiaChiTextBox)
        Me.Controls.Add(Me.HoTenTextBox)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LapHoaDonBanSachGridControl)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LichSuThaoTacFlowLayoutPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "LAPHOADONBANSACHGUI"
        Me.Text = "LAPHOADONBANSACHGUI"
        CType(Me.LapHoaDonBanSachGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LapHoaDonBanSachGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HoTenTextBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DiaChiTextBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MaKhachHangTextBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoTienNoTextBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoLuongTonToiThieuTextBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoTienNoToiDaTextBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TongThanhTienTextBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.progressBarControl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AllBookIDsListBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AllCustomerIDsListBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LichSuThaoTacFlowLayoutPanel.ResumeLayout(False)
        Me.LichSuThaoTacFlowLayoutPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LapHoaDonBanSachGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents LapHoaDonBanSachGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents HoTenTextBox As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DiaChiTextBox As DevExpress.XtraEditors.TextEdit
    Friend WithEvents MaKhachHangTextBox As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SoTienNoTextBox As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SoLuongTonToiThieuTextBox As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SoTienNoToiDaTextBox As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LapHoaDonButton As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents NgayLapHoaDonDateTimePicker As DateTimePicker
    Friend WithEvents ToolTipController As DevExpress.Utils.ToolTipController
    Friend WithEvents TaoPhieuMoiButton As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TongThanhTienTextBox As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ThongBaoLabel As DevExpress.XtraEditors.LabelControl
    Friend WithEvents XuatFileExelButton As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents progressBarControl As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents BackgroundWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents SaveDialog As SaveFileDialog
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents OpenDialog As OpenFileDialog
    Friend WithEvents NhapFileExcelButton As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayFileExcelFormatButton As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents AllBookIDsListBox As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents AllCustomerIDsListBox As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents LapPhieuThuTienButton As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LichSuThaoTacFlowLayoutPanel As FlowLayoutPanel
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
End Class
