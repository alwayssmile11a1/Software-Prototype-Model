<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class THELOAIGUI
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
        Me.MaTheLoaiMoiButton = New DevExpress.XtraEditors.SimpleButton()
        Me.TheLoaiGridControl = New DevExpress.XtraGrid.GridControl()
        Me.TheLoaiGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TenTheLoaiTextBox = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.MaTheLoaiTextBox = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.DongYThemButton = New DevExpress.XtraEditors.SimpleButton()
        Me.XoaTheLoaiButton = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.TheLoaiGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TheLoaiGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TenTheLoaiTextBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MaTheLoaiTextBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MaTheLoaiMoiButton
        '
        Me.MaTheLoaiMoiButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MaTheLoaiMoiButton.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaTheLoaiMoiButton.Appearance.Options.UseFont = True
        Me.MaTheLoaiMoiButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.MaTheLoaiMoiButton.Location = New System.Drawing.Point(451, 136)
        Me.MaTheLoaiMoiButton.Name = "MaTheLoaiMoiButton"
        Me.MaTheLoaiMoiButton.Size = New System.Drawing.Size(144, 34)
        Me.MaTheLoaiMoiButton.TabIndex = 43
        Me.MaTheLoaiMoiButton.Text = "Lấy Mã thể loại mới"
        '
        'TheLoaiGridControl
        '
        Me.TheLoaiGridControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TheLoaiGridControl.Location = New System.Drawing.Point(24, 12)
        Me.TheLoaiGridControl.MainView = Me.TheLoaiGridView
        Me.TheLoaiGridControl.Name = "TheLoaiGridControl"
        Me.TheLoaiGridControl.Size = New System.Drawing.Size(395, 248)
        Me.TheLoaiGridControl.TabIndex = 45
        Me.TheLoaiGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.TheLoaiGridView})
        '
        'TheLoaiGridView
        '
        Me.TheLoaiGridView.GridControl = Me.TheLoaiGridControl
        Me.TheLoaiGridView.GroupPanelText = "Lập phiếu nhập sách"
        Me.TheLoaiGridView.Name = "TheLoaiGridView"
        Me.TheLoaiGridView.OptionsBehavior.Editable = False
        Me.TheLoaiGridView.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.[Default]
        Me.TheLoaiGridView.OptionsView.ShowGroupPanel = False
        '
        'TenTheLoaiTextBox
        '
        Me.TenTheLoaiTextBox.Location = New System.Drawing.Point(444, 91)
        Me.TenTheLoaiTextBox.Name = "TenTheLoaiTextBox"
        Me.TenTheLoaiTextBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TenTheLoaiTextBox.Properties.Appearance.Options.UseFont = True
        Me.TenTheLoaiTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.TenTheLoaiTextBox.Size = New System.Drawing.Size(165, 24)
        Me.TenTheLoaiTextBox.TabIndex = 47
        '
        'LabelControl13
        '
        Me.LabelControl13.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl13.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl13.Location = New System.Drawing.Point(444, 67)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(87, 18)
        Me.LabelControl13.TabIndex = 49
        Me.LabelControl13.Text = "Tên Thể Loại"
        '
        'MaTheLoaiTextBox
        '
        Me.MaTheLoaiTextBox.Location = New System.Drawing.Point(444, 37)
        Me.MaTheLoaiTextBox.Name = "MaTheLoaiTextBox"
        Me.MaTheLoaiTextBox.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaTheLoaiTextBox.Properties.Appearance.Options.UseFont = True
        Me.MaTheLoaiTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.MaTheLoaiTextBox.Size = New System.Drawing.Size(165, 24)
        Me.MaTheLoaiTextBox.TabIndex = 46
        '
        'LabelControl12
        '
        Me.LabelControl12.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl12.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl12.Location = New System.Drawing.Point(444, 13)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(81, 18)
        Me.LabelControl12.TabIndex = 48
        Me.LabelControl12.Text = "Mã Thể Loại"
        '
        'DongYThemButton
        '
        Me.DongYThemButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DongYThemButton.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DongYThemButton.Appearance.Options.UseFont = True
        Me.DongYThemButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.DongYThemButton.Location = New System.Drawing.Point(473, 176)
        Me.DongYThemButton.Name = "DongYThemButton"
        Me.DongYThemButton.Size = New System.Drawing.Size(102, 54)
        Me.DongYThemButton.TabIndex = 50
        Me.DongYThemButton.Text = "Đồng ý thêm"
        '
        'XoaTheLoaiButton
        '
        Me.XoaTheLoaiButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XoaTheLoaiButton.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XoaTheLoaiButton.Appearance.Options.UseFont = True
        Me.XoaTheLoaiButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.XoaTheLoaiButton.Location = New System.Drawing.Point(163, 266)
        Me.XoaTheLoaiButton.Name = "XoaTheLoaiButton"
        Me.XoaTheLoaiButton.Size = New System.Drawing.Size(108, 50)
        Me.XoaTheLoaiButton.TabIndex = 51
        Me.XoaTheLoaiButton.Text = "Xóa"
        '
        'THELOAIGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(635, 328)
        Me.Controls.Add(Me.XoaTheLoaiButton)
        Me.Controls.Add(Me.DongYThemButton)
        Me.Controls.Add(Me.TenTheLoaiTextBox)
        Me.Controls.Add(Me.LabelControl13)
        Me.Controls.Add(Me.MaTheLoaiTextBox)
        Me.Controls.Add(Me.LabelControl12)
        Me.Controls.Add(Me.TheLoaiGridControl)
        Me.Controls.Add(Me.MaTheLoaiMoiButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "THELOAIGUI"
        Me.Text = "Quản lý thể loại"
        CType(Me.TheLoaiGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TheLoaiGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TenTheLoaiTextBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MaTheLoaiTextBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MaTheLoaiMoiButton As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TheLoaiGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents TheLoaiGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TenTheLoaiTextBox As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MaTheLoaiTextBox As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DongYThemButton As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XoaTheLoaiButton As DevExpress.XtraEditors.SimpleButton
End Class
