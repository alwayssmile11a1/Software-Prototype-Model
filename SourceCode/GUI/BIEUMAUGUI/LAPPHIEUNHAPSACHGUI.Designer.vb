<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LAPPHIEUNHAPSACHGUI
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
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.SoLuongNhapItNhatTextBox = New DevExpress.XtraEditors.TextEdit()
        Me.SoLuongTonToiDaTextBox = New DevExpress.XtraEditors.TextEdit()
        Me.LapPhieuNhapSachButton = New DevExpress.XtraEditors.SimpleButton()
        Me.NgayNhapDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.TaoPhieuMoiButton = New DevExpress.XtraEditors.SimpleButton()
        Me.LapPhieuNhapSachGridControl = New DevExpress.XtraGrid.GridControl()
        Me.LapPhieuNhapSachGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.ToolTipController = New DevExpress.Utils.ToolTipController(Me.components)
        Me.XuatFileExcelButton = New DevExpress.XtraEditors.SimpleButton()
        Me.progressBarControl = New DevExpress.XtraEditors.ProgressBarControl()
        Me.ExportBackgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.SaveDialog = New System.Windows.Forms.SaveFileDialog()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.NhapFileExcelButton = New DevExpress.XtraEditors.SimpleButton()
        Me.OpenDialog = New System.Windows.Forms.OpenFileDialog()
        Me.LayFileExcelFormatButton = New DevExpress.XtraEditors.SimpleButton()
        Me.AllBookIDsListBox = New DevExpress.XtraEditors.ListBoxControl()
        Me.LichSuThaoTacFlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.SoLuongNhapItNhatTextBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoLuongTonToiDaTextBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LapPhieuNhapSachGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LapPhieuNhapSachGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.progressBarControl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AllBookIDsListBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LichSuThaoTacFlowLayoutPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(26, 43)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(168, 18)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Ngày lập phiếu nhập sách"
        '
        'LabelControl2
        '
        Me.LabelControl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(26, 71)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(149, 18)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Số lượng nhập tối thiểu"
        '
        'LabelControl3
        '
        Me.LabelControl3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(26, 102)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(200, 18)
        Me.LabelControl3.TabIndex = 4
        Me.LabelControl3.Text = "Số lượng tồn tối đa trước nhập"
        '
        'SoLuongNhapItNhatTextBox
        '
        Me.SoLuongNhapItNhatTextBox.Location = New System.Drawing.Point(241, 68)
        Me.SoLuongNhapItNhatTextBox.Name = "SoLuongNhapItNhatTextBox"
        '
        '
        '
        Me.SoLuongNhapItNhatTextBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SoLuongNhapItNhatTextBox.Properties.Appearance.Options.UseFont = True
        Me.SoLuongNhapItNhatTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.SoLuongNhapItNhatTextBox.Size = New System.Drawing.Size(121, 24)
        Me.SoLuongNhapItNhatTextBox.TabIndex = 10
        '
        'SoLuongTonToiDaTextBox
        '
        Me.SoLuongTonToiDaTextBox.Location = New System.Drawing.Point(241, 99)
        Me.SoLuongTonToiDaTextBox.Name = "SoLuongTonToiDaTextBox"
        '
        '
        '
        Me.SoLuongTonToiDaTextBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SoLuongTonToiDaTextBox.Properties.Appearance.Options.UseFont = True
        Me.SoLuongTonToiDaTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.SoLuongTonToiDaTextBox.Size = New System.Drawing.Size(121, 24)
        Me.SoLuongTonToiDaTextBox.TabIndex = 11
        '
        'LapPhieuNhapSachButton
        '
        Me.LapPhieuNhapSachButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.LapPhieuNhapSachButton.Appearance.BackColor = System.Drawing.Color.LightGray
        Me.LapPhieuNhapSachButton.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LapPhieuNhapSachButton.Appearance.Options.UseBackColor = True
        Me.LapPhieuNhapSachButton.Appearance.Options.UseFont = True
        Me.LapPhieuNhapSachButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.LapPhieuNhapSachButton.Location = New System.Drawing.Point(493, 473)
        Me.LapPhieuNhapSachButton.Name = "LapPhieuNhapSachButton"
        Me.LapPhieuNhapSachButton.Size = New System.Drawing.Size(118, 45)
        Me.LapPhieuNhapSachButton.TabIndex = 4
        Me.LapPhieuNhapSachButton.Text = "Lập Phiếu"
        '
        'NgayNhapDateTimePicker
        '
        Me.NgayNhapDateTimePicker.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NgayNhapDateTimePicker.Location = New System.Drawing.Point(241, 37)
        Me.NgayNhapDateTimePicker.Name = "NgayNhapDateTimePicker"
        Me.NgayNhapDateTimePicker.Size = New System.Drawing.Size(199, 26)
        Me.NgayNhapDateTimePicker.TabIndex = 4
        '
        'TaoPhieuMoiButton
        '
        Me.TaoPhieuMoiButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TaoPhieuMoiButton.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaoPhieuMoiButton.Appearance.Options.UseFont = True
        Me.TaoPhieuMoiButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.TaoPhieuMoiButton.Location = New System.Drawing.Point(25, 473)
        Me.TaoPhieuMoiButton.Name = "TaoPhieuMoiButton"
        Me.TaoPhieuMoiButton.Size = New System.Drawing.Size(121, 44)
        Me.TaoPhieuMoiButton.TabIndex = 20
        Me.TaoPhieuMoiButton.Text = "Tạo Phiếu Mới"
        '
        'LapPhieuNhapSachGridControl
        '
        Me.LapPhieuNhapSachGridControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LapPhieuNhapSachGridControl.Location = New System.Drawing.Point(26, 138)
        Me.LapPhieuNhapSachGridControl.MainView = Me.LapPhieuNhapSachGridView
        Me.LapPhieuNhapSachGridControl.Name = "LapPhieuNhapSachGridControl"
        Me.LapPhieuNhapSachGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1})
        Me.LapPhieuNhapSachGridControl.Size = New System.Drawing.Size(1052, 329)
        Me.LapPhieuNhapSachGridControl.TabIndex = 1
        Me.LapPhieuNhapSachGridControl.UseEmbeddedNavigator = True
        Me.LapPhieuNhapSachGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.LapPhieuNhapSachGridView})
        '
        'LapPhieuNhapSachGridView
        '
        Me.LapPhieuNhapSachGridView.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.LapPhieuNhapSachGridView.Appearance.OddRow.Options.UseBackColor = True
        Me.LapPhieuNhapSachGridView.Appearance.Row.BackColor = System.Drawing.Color.White
        Me.LapPhieuNhapSachGridView.Appearance.Row.Options.UseBackColor = True
        Me.LapPhieuNhapSachGridView.GridControl = Me.LapPhieuNhapSachGridControl
        Me.LapPhieuNhapSachGridView.Name = "LapPhieuNhapSachGridView"
        Me.LapPhieuNhapSachGridView.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.[Default]
        Me.LapPhieuNhapSachGridView.OptionsView.ShowGroupPanel = False
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        '
        'XuatFileExcelButton
        '
        Me.XuatFileExcelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XuatFileExcelButton.Appearance.BackColor = System.Drawing.Color.LightGray
        Me.XuatFileExcelButton.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XuatFileExcelButton.Appearance.Options.UseBackColor = True
        Me.XuatFileExcelButton.Appearance.Options.UseFont = True
        Me.XuatFileExcelButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.XuatFileExcelButton.Location = New System.Drawing.Point(970, 472)
        Me.XuatFileExcelButton.Name = "XuatFileExcelButton"
        Me.XuatFileExcelButton.Size = New System.Drawing.Size(108, 45)
        Me.XuatFileExcelButton.TabIndex = 5
        Me.XuatFileExcelButton.Text = "Xuất File Excel"
        '
        'progressBarControl
        '
        Me.progressBarControl.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.progressBarControl.EditValue = "0"
        Me.progressBarControl.Location = New System.Drawing.Point(0, 624)
        Me.progressBarControl.Name = "progressBarControl"
        '
        '
        '
        Me.progressBarControl.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.progressBarControl.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.progressBarControl.Properties.ShowTitle = True
        Me.progressBarControl.Properties.Step = 1
        Me.progressBarControl.Size = New System.Drawing.Size(1117, 30)
        Me.progressBarControl.TabIndex = 13
        '
        'ExportBackgroundWorker
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
        Me.LabelControl14.Size = New System.Drawing.Size(202, 25)
        Me.LabelControl14.TabIndex = 81
        Me.LabelControl14.Text = "Lập Phiếu Nhập Sách"
        '
        'NhapFileExcelButton
        '
        Me.NhapFileExcelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NhapFileExcelButton.Appearance.BackColor = System.Drawing.Color.LightGray
        Me.NhapFileExcelButton.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NhapFileExcelButton.Appearance.Options.UseBackColor = True
        Me.NhapFileExcelButton.Appearance.Options.UseFont = True
        Me.NhapFileExcelButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.NhapFileExcelButton.Location = New System.Drawing.Point(840, 473)
        Me.NhapFileExcelButton.Name = "NhapFileExcelButton"
        Me.NhapFileExcelButton.Size = New System.Drawing.Size(123, 44)
        Me.NhapFileExcelButton.TabIndex = 15
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
        Me.LayFileExcelFormatButton.Location = New System.Drawing.Point(724, 473)
        Me.LayFileExcelFormatButton.Name = "LayFileExcelFormatButton"
        Me.LayFileExcelFormatButton.Size = New System.Drawing.Size(110, 25)
        Me.LayFileExcelFormatButton.TabIndex = 85
        Me.LayFileExcelFormatButton.Text = "Lấy File Excel Mẫu"
        Me.LayFileExcelFormatButton.ToolTip = "Xuất một file excel theo format giúp bổ trợ cho việc Nhập từ File Excel"
        '
        'AllBookIDsListBox
        '
        Me.AllBookIDsListBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.AllBookIDsListBox.Location = New System.Drawing.Point(26, 202)
        Me.AllBookIDsListBox.Name = "AllBookIDsListBox"
        Me.AllBookIDsListBox.TabIndex = 86
        Me.AllBookIDsListBox.Visible = False
        '
        'LichSuThaoTacFlowLayoutPanel
        '
        Me.LichSuThaoTacFlowLayoutPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LichSuThaoTacFlowLayoutPanel.AutoScroll = True
        Me.LichSuThaoTacFlowLayoutPanel.BackColor = System.Drawing.Color.Gainsboro
        Me.LichSuThaoTacFlowLayoutPanel.Controls.Add(Me.LabelControl10)
        Me.LichSuThaoTacFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.LichSuThaoTacFlowLayoutPanel.Location = New System.Drawing.Point(0, 532)
        Me.LichSuThaoTacFlowLayoutPanel.Name = "LichSuThaoTacFlowLayoutPanel"
        Me.LichSuThaoTacFlowLayoutPanel.Size = New System.Drawing.Size(1117, 122)
        Me.LichSuThaoTacFlowLayoutPanel.TabIndex = 87
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
        Me.LabelControl10.Size = New System.Drawing.Size(173, 27)
        Me.LabelControl10.TabIndex = 0
        Me.LabelControl10.Text = "Lịch Sử Lập Phiếu"
        '
        'LAPPHIEUNHAPSACHGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1117, 654)
        Me.Controls.Add(Me.AllBookIDsListBox)
        Me.Controls.Add(Me.LayFileExcelFormatButton)
        Me.Controls.Add(Me.NhapFileExcelButton)
        Me.Controls.Add(Me.LabelControl14)
        Me.Controls.Add(Me.progressBarControl)
        Me.Controls.Add(Me.XuatFileExcelButton)
        Me.Controls.Add(Me.LapPhieuNhapSachGridControl)
        Me.Controls.Add(Me.TaoPhieuMoiButton)
        Me.Controls.Add(Me.NgayNhapDateTimePicker)
        Me.Controls.Add(Me.LapPhieuNhapSachButton)
        Me.Controls.Add(Me.SoLuongTonToiDaTextBox)
        Me.Controls.Add(Me.SoLuongNhapItNhatTextBox)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LichSuThaoTacFlowLayoutPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "LAPPHIEUNHAPSACHGUI"
        Me.Text = "LAPPHIEUNHAPSACHGUI"
        CType(Me.SoLuongNhapItNhatTextBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoLuongTonToiDaTextBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LapPhieuNhapSachGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LapPhieuNhapSachGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.progressBarControl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AllBookIDsListBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LichSuThaoTacFlowLayoutPanel.ResumeLayout(False)
        Me.LichSuThaoTacFlowLayoutPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents NgayNhapDateTimePicker As DateTimePicker
    Friend WithEvents ExportBackgroundWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents SaveDialog As SaveFileDialog
    Friend WithEvents OpenDialog As OpenFileDialog
    Friend WithEvents LichSuThaoTacFlowLayoutPanel As FlowLayoutPanel
    Private WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Private WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Private WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Private WithEvents SoLuongNhapItNhatTextBox As DevExpress.XtraEditors.TextEdit
    Private WithEvents SoLuongTonToiDaTextBox As DevExpress.XtraEditors.TextEdit
    Private WithEvents LapPhieuNhapSachButton As DevExpress.XtraEditors.SimpleButton
    Private WithEvents TaoPhieuMoiButton As DevExpress.XtraEditors.SimpleButton
    Private WithEvents LapPhieuNhapSachGridControl As DevExpress.XtraGrid.GridControl
    Private WithEvents LapPhieuNhapSachGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents ToolTipController As DevExpress.Utils.ToolTipController
    Private WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Private WithEvents XuatFileExcelButton As DevExpress.XtraEditors.SimpleButton
    Private WithEvents progressBarControl As DevExpress.XtraEditors.ProgressBarControl
    Private WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Private WithEvents NhapFileExcelButton As DevExpress.XtraEditors.SimpleButton
    Private WithEvents LayFileExcelFormatButton As DevExpress.XtraEditors.SimpleButton
    Private WithEvents AllBookIDsListBox As DevExpress.XtraEditors.ListBoxControl
    Private WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
End Class
