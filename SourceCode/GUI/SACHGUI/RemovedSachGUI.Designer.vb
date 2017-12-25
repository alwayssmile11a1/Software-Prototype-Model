<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class REMOVEDSACHGUI
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
        Me.KhoiPhucSachButton = New DevExpress.XtraEditors.SimpleButton()
        Me.ThongTinSachGridControl = New DevExpress.XtraGrid.GridControl()
        Me.ThongTinSachGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.DonGiaKieuSoSanhComboBox = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.DonGiaTraCuuTextBox = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.SoLuongTonTraCuuTextBox = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.TacGiaTraCuuTextBox = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.TheLoaiTraCuuTextBox = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.TenSachTraCuuTextBox = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.MaSachTraCuuTextBox = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.SoLuongTonKieuSoSanhComboBox = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.TongSoKetQuaLabelControl = New DevExpress.XtraEditors.LabelControl()
        Me.TimTatCaButton = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.ThongTinSachGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ThongTinSachGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DonGiaKieuSoSanhComboBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DonGiaTraCuuTextBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoLuongTonTraCuuTextBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TacGiaTraCuuTextBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TheLoaiTraCuuTextBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TenSachTraCuuTextBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MaSachTraCuuTextBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoLuongTonKieuSoSanhComboBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KhoiPhucSachButton
        '
        Me.KhoiPhucSachButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.KhoiPhucSachButton.Appearance.BackColor = System.Drawing.Color.LightGray
        Me.KhoiPhucSachButton.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KhoiPhucSachButton.Appearance.Options.UseBackColor = True
        Me.KhoiPhucSachButton.Appearance.Options.UseFont = True
        Me.KhoiPhucSachButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.KhoiPhucSachButton.Location = New System.Drawing.Point(392, 441)
        Me.KhoiPhucSachButton.Name = "KhoiPhucSachButton"
        Me.KhoiPhucSachButton.Size = New System.Drawing.Size(155, 66)
        Me.KhoiPhucSachButton.TabIndex = 11
        Me.KhoiPhucSachButton.Text = "Khôi Phục Sách"
        '
        'ThongTinSachGridControl
        '
        Me.ThongTinSachGridControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ThongTinSachGridControl.Location = New System.Drawing.Point(30, 181)
        Me.ThongTinSachGridControl.MainView = Me.ThongTinSachGridView
        Me.ThongTinSachGridControl.Name = "ThongTinSachGridControl"
        Me.ThongTinSachGridControl.Size = New System.Drawing.Size(841, 244)
        Me.ThongTinSachGridControl.TabIndex = 49
        Me.ThongTinSachGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ThongTinSachGridView})
        '
        'ThongTinSachGridView
        '
        Me.ThongTinSachGridView.GridControl = Me.ThongTinSachGridControl
        Me.ThongTinSachGridView.GroupPanelText = "Lập phiếu nhập sách"
        Me.ThongTinSachGridView.Name = "ThongTinSachGridView"
        Me.ThongTinSachGridView.OptionsBehavior.Editable = False
        Me.ThongTinSachGridView.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.[Default]
        Me.ThongTinSachGridView.OptionsView.ShowGroupPanel = False
        '
        'DonGiaKieuSoSanhComboBox
        '
        Me.DonGiaKieuSoSanhComboBox.Location = New System.Drawing.Point(387, 72)
        Me.DonGiaKieuSoSanhComboBox.Name = "DonGiaKieuSoSanhComboBox"
        Me.DonGiaKieuSoSanhComboBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DonGiaKieuSoSanhComboBox.Properties.Appearance.Options.UseFont = True
        Me.DonGiaKieuSoSanhComboBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.DonGiaKieuSoSanhComboBox.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DonGiaKieuSoSanhComboBox.Size = New System.Drawing.Size(144, 24)
        Me.DonGiaKieuSoSanhComboBox.TabIndex = 9
        '
        'DonGiaTraCuuTextBox
        '
        Me.DonGiaTraCuuTextBox.Location = New System.Drawing.Point(537, 72)
        Me.DonGiaTraCuuTextBox.Name = "DonGiaTraCuuTextBox"
        Me.DonGiaTraCuuTextBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DonGiaTraCuuTextBox.Properties.Appearance.Options.UseFont = True
        Me.DonGiaTraCuuTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.DonGiaTraCuuTextBox.Properties.Mask.EditMask = "c0"
        Me.DonGiaTraCuuTextBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.DonGiaTraCuuTextBox.Properties.MaxLength = 10
        Me.DonGiaTraCuuTextBox.Size = New System.Drawing.Size(166, 24)
        Me.DonGiaTraCuuTextBox.TabIndex = 10
        '
        'LabelControl15
        '
        Me.LabelControl15.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl15.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl15.Location = New System.Drawing.Point(286, 75)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(51, 18)
        Me.LabelControl15.TabIndex = 74
        Me.LabelControl15.Text = "Đơn Giá"
        '
        'SoLuongTonTraCuuTextBox
        '
        Me.SoLuongTonTraCuuTextBox.Location = New System.Drawing.Point(537, 41)
        Me.SoLuongTonTraCuuTextBox.Name = "SoLuongTonTraCuuTextBox"
        Me.SoLuongTonTraCuuTextBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SoLuongTonTraCuuTextBox.Properties.Appearance.Options.UseFont = True
        Me.SoLuongTonTraCuuTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.SoLuongTonTraCuuTextBox.Properties.Mask.EditMask = "n0"
        Me.SoLuongTonTraCuuTextBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.SoLuongTonTraCuuTextBox.Properties.MaxLength = 9
        Me.SoLuongTonTraCuuTextBox.Size = New System.Drawing.Size(166, 24)
        Me.SoLuongTonTraCuuTextBox.TabIndex = 6
        '
        'LabelControl14
        '
        Me.LabelControl14.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl14.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl14.Location = New System.Drawing.Point(286, 44)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(92, 18)
        Me.LabelControl14.TabIndex = 72
        Me.LabelControl14.Text = "Số Lượng Tồn"
        '
        'TacGiaTraCuuTextBox
        '
        Me.TacGiaTraCuuTextBox.Location = New System.Drawing.Point(115, 142)
        Me.TacGiaTraCuuTextBox.Name = "TacGiaTraCuuTextBox"
        Me.TacGiaTraCuuTextBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TacGiaTraCuuTextBox.Properties.Appearance.Options.UseFont = True
        Me.TacGiaTraCuuTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.TacGiaTraCuuTextBox.Size = New System.Drawing.Size(152, 24)
        Me.TacGiaTraCuuTextBox.TabIndex = 4
        '
        'LabelControl13
        '
        Me.LabelControl13.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl13.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl13.Location = New System.Drawing.Point(29, 145)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(50, 18)
        Me.LabelControl13.TabIndex = 70
        Me.LabelControl13.Text = "Tác Giả"
        '
        'TheLoaiTraCuuTextBox
        '
        Me.TheLoaiTraCuuTextBox.Location = New System.Drawing.Point(115, 106)
        Me.TheLoaiTraCuuTextBox.Name = "TheLoaiTraCuuTextBox"
        Me.TheLoaiTraCuuTextBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TheLoaiTraCuuTextBox.Properties.Appearance.Options.UseFont = True
        Me.TheLoaiTraCuuTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.TheLoaiTraCuuTextBox.Size = New System.Drawing.Size(152, 24)
        Me.TheLoaiTraCuuTextBox.TabIndex = 3
        '
        'LabelControl12
        '
        Me.LabelControl12.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl12.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl12.Location = New System.Drawing.Point(29, 109)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(56, 18)
        Me.LabelControl12.TabIndex = 68
        Me.LabelControl12.Text = "Thể Loại"
        '
        'TenSachTraCuuTextBox
        '
        Me.TenSachTraCuuTextBox.Location = New System.Drawing.Point(115, 72)
        Me.TenSachTraCuuTextBox.Name = "TenSachTraCuuTextBox"
        Me.TenSachTraCuuTextBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TenSachTraCuuTextBox.Properties.Appearance.Options.UseFont = True
        Me.TenSachTraCuuTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.TenSachTraCuuTextBox.Size = New System.Drawing.Size(152, 24)
        Me.TenSachTraCuuTextBox.TabIndex = 2
        '
        'LabelControl11
        '
        Me.LabelControl11.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl11.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl11.Location = New System.Drawing.Point(29, 75)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(62, 18)
        Me.LabelControl11.TabIndex = 66
        Me.LabelControl11.Text = "Tên Sách"
        '
        'MaSachTraCuuTextBox
        '
        Me.MaSachTraCuuTextBox.Location = New System.Drawing.Point(115, 41)
        Me.MaSachTraCuuTextBox.Name = "MaSachTraCuuTextBox"
        Me.MaSachTraCuuTextBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaSachTraCuuTextBox.Properties.Appearance.Options.UseFont = True
        Me.MaSachTraCuuTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.MaSachTraCuuTextBox.Size = New System.Drawing.Size(152, 24)
        Me.MaSachTraCuuTextBox.TabIndex = 1
        '
        'LabelControl9
        '
        Me.LabelControl9.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Location = New System.Drawing.Point(29, 44)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(56, 18)
        Me.LabelControl9.TabIndex = 64
        Me.LabelControl9.Text = "Mã Sách"
        '
        'SoLuongTonKieuSoSanhComboBox
        '
        Me.SoLuongTonKieuSoSanhComboBox.Location = New System.Drawing.Point(387, 41)
        Me.SoLuongTonKieuSoSanhComboBox.Name = "SoLuongTonKieuSoSanhComboBox"
        Me.SoLuongTonKieuSoSanhComboBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SoLuongTonKieuSoSanhComboBox.Properties.Appearance.Options.UseFont = True
        Me.SoLuongTonKieuSoSanhComboBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.SoLuongTonKieuSoSanhComboBox.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SoLuongTonKieuSoSanhComboBox.Size = New System.Drawing.Size(144, 24)
        Me.SoLuongTonKieuSoSanhComboBox.TabIndex = 5
        '
        'TongSoKetQuaLabelControl
        '
        Me.TongSoKetQuaLabelControl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TongSoKetQuaLabelControl.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TongSoKetQuaLabelControl.Location = New System.Drawing.Point(779, 431)
        Me.TongSoKetQuaLabelControl.Name = "TongSoKetQuaLabelControl"
        Me.TongSoKetQuaLabelControl.Size = New System.Drawing.Size(92, 14)
        Me.TongSoKetQuaLabelControl.TabIndex = 77
        Me.TongSoKetQuaLabelControl.Text = "Tổng số kết quả"
        '
        'TimTatCaButton
        '
        Me.TimTatCaButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TimTatCaButton.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimTatCaButton.Appearance.Options.UseFont = True
        Me.TimTatCaButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.TimTatCaButton.Location = New System.Drawing.Point(779, 144)
        Me.TimTatCaButton.Name = "TimTatCaButton"
        Me.TimTatCaButton.Size = New System.Drawing.Size(92, 31)
        Me.TimTatCaButton.TabIndex = 78
        Me.TimTatCaButton.Text = "Tìm Tất Cả"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.LabelControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LabelControl1.Location = New System.Drawing.Point(0, 0)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(202, 25)
        Me.LabelControl1.TabIndex = 81
        Me.LabelControl1.Text = "Tra Cứu Sách Đã Xóa"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton1.Appearance.Options.UseFont = True
        Me.SimpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.SimpleButton1.Location = New System.Drawing.Point(648, 145)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(125, 30)
        Me.SimpleButton1.TabIndex = 82
        Me.SimpleButton1.Text = "Tìm theo điều kiện"
        '
        'REMOVEDSACHGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(906, 519)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.TimTatCaButton)
        Me.Controls.Add(Me.TongSoKetQuaLabelControl)
        Me.Controls.Add(Me.DonGiaKieuSoSanhComboBox)
        Me.Controls.Add(Me.DonGiaTraCuuTextBox)
        Me.Controls.Add(Me.LabelControl15)
        Me.Controls.Add(Me.SoLuongTonTraCuuTextBox)
        Me.Controls.Add(Me.LabelControl14)
        Me.Controls.Add(Me.TacGiaTraCuuTextBox)
        Me.Controls.Add(Me.LabelControl13)
        Me.Controls.Add(Me.TheLoaiTraCuuTextBox)
        Me.Controls.Add(Me.LabelControl12)
        Me.Controls.Add(Me.TenSachTraCuuTextBox)
        Me.Controls.Add(Me.LabelControl11)
        Me.Controls.Add(Me.MaSachTraCuuTextBox)
        Me.Controls.Add(Me.LabelControl9)
        Me.Controls.Add(Me.SoLuongTonKieuSoSanhComboBox)
        Me.Controls.Add(Me.KhoiPhucSachButton)
        Me.Controls.Add(Me.ThongTinSachGridControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "REMOVEDSACHGUI"
        Me.Text = "RemovedSachGUI"
        CType(Me.ThongTinSachGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ThongTinSachGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DonGiaKieuSoSanhComboBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DonGiaTraCuuTextBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoLuongTonTraCuuTextBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TacGiaTraCuuTextBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TheLoaiTraCuuTextBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TenSachTraCuuTextBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MaSachTraCuuTextBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoLuongTonKieuSoSanhComboBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents KhoiPhucSachButton As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ThongTinSachGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents ThongTinSachGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DonGiaKieuSoSanhComboBox As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents DonGiaTraCuuTextBox As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SoLuongTonTraCuuTextBox As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TacGiaTraCuuTextBox As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TheLoaiTraCuuTextBox As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TenSachTraCuuTextBox As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MaSachTraCuuTextBox As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SoLuongTonKieuSoSanhComboBox As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents TongSoKetQuaLabelControl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TimTatCaButton As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
End Class
