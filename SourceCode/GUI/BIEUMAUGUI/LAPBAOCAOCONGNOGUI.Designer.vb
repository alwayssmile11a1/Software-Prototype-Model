<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LAPBAOCAOCONGNOGUI
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
        Me.LapBaoCaoCongNoGridControl = New DevExpress.XtraGrid.GridControl()
        Me.LapBaoCaoCongNoGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LapBaoCaoButton = New DevExpress.XtraEditors.SimpleButton()
        Me.ThangLapBaoCaoDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.XuatFileExelButton = New DevExpress.XtraEditors.SimpleButton()
        Me.SaveDialog = New System.Windows.Forms.SaveFileDialog()
        Me.BackgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.progressBarControl = New DevExpress.XtraEditors.ProgressBarControl()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.LapBaoCaoCongNoGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LapBaoCaoCongNoGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.progressBarControl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LapBaoCaoCongNoGridControl
        '
        Me.LapBaoCaoCongNoGridControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LapBaoCaoCongNoGridControl.Location = New System.Drawing.Point(37, 107)
        Me.LapBaoCaoCongNoGridControl.MainView = Me.LapBaoCaoCongNoGridView
        Me.LapBaoCaoCongNoGridControl.Name = "LapBaoCaoCongNoGridControl"
        Me.LapBaoCaoCongNoGridControl.Size = New System.Drawing.Size(956, 348)
        Me.LapBaoCaoCongNoGridControl.TabIndex = 27
        Me.LapBaoCaoCongNoGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.LapBaoCaoCongNoGridView})
        '
        'LapBaoCaoCongNoGridView
        '
        Me.LapBaoCaoCongNoGridView.GridControl = Me.LapBaoCaoCongNoGridControl
        Me.LapBaoCaoCongNoGridView.GroupPanelText = "Lập phiếu nhập sách"
        Me.LapBaoCaoCongNoGridView.Name = "LapBaoCaoCongNoGridView"
        Me.LapBaoCaoCongNoGridView.OptionsBehavior.Editable = False
        Me.LapBaoCaoCongNoGridView.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.[Default]
        Me.LapBaoCaoCongNoGridView.OptionsView.ShowGroupPanel = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(36, 62)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(172, 18)
        Me.LabelControl1.TabIndex = 25
        Me.LabelControl1.Text = "Tháng Cần Lập Báo Cáo"
        '
        'LapBaoCaoButton
        '
        Me.LapBaoCaoButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.LapBaoCaoButton.Appearance.BackColor = System.Drawing.Color.LightGray
        Me.LapBaoCaoButton.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LapBaoCaoButton.Appearance.Options.UseBackColor = True
        Me.LapBaoCaoButton.Appearance.Options.UseFont = True
        Me.LapBaoCaoButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.LapBaoCaoButton.Location = New System.Drawing.Point(448, 461)
        Me.LapBaoCaoButton.Name = "LapBaoCaoButton"
        Me.LapBaoCaoButton.Size = New System.Drawing.Size(120, 45)
        Me.LapBaoCaoButton.TabIndex = 2
        Me.LapBaoCaoButton.Text = "Lập Báo Cáo "
        '
        'ThangLapBaoCaoDateTimePicker
        '
        Me.ThangLapBaoCaoDateTimePicker.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ThangLapBaoCaoDateTimePicker.Location = New System.Drawing.Point(223, 56)
        Me.ThangLapBaoCaoDateTimePicker.Name = "ThangLapBaoCaoDateTimePicker"
        Me.ThangLapBaoCaoDateTimePicker.Size = New System.Drawing.Size(217, 26)
        Me.ThangLapBaoCaoDateTimePicker.TabIndex = 1
        '
        'XuatFileExelButton
        '
        Me.XuatFileExelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.XuatFileExelButton.Appearance.BackColor = System.Drawing.Color.LightGray
        Me.XuatFileExelButton.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XuatFileExelButton.Appearance.Options.UseBackColor = True
        Me.XuatFileExelButton.Appearance.Options.UseFont = True
        Me.XuatFileExelButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.XuatFileExelButton.Location = New System.Drawing.Point(598, 461)
        Me.XuatFileExelButton.Name = "XuatFileExelButton"
        Me.XuatFileExelButton.Size = New System.Drawing.Size(121, 45)
        Me.XuatFileExelButton.TabIndex = 3
        Me.XuatFileExelButton.Text = "Xuất File Exel"
        '
        'BackgroundWorker
        '
        '
        'progressBarControl
        '
        Me.progressBarControl.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.progressBarControl.EditValue = "0"
        Me.progressBarControl.Location = New System.Drawing.Point(0, 516)
        Me.progressBarControl.Name = "progressBarControl"
        '
        '
        '
        Me.progressBarControl.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.progressBarControl.Properties.Appearance.BackColor2 = System.Drawing.Color.Black
        Me.progressBarControl.Properties.ShowTitle = True
        Me.progressBarControl.Properties.Step = 1
        Me.progressBarControl.Size = New System.Drawing.Size(1028, 21)
        Me.progressBarControl.TabIndex = 44
        '
        'LabelControl14
        '
        Me.LabelControl14.Appearance.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.LabelControl14.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl14.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl14.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.LabelControl14.Dock = System.Windows.Forms.DockStyle.Left
        Me.LabelControl14.Location = New System.Drawing.Point(0, 0)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(258, 31)
        Me.LabelControl14.TabIndex = 83
        Me.LabelControl14.Text = "Lập Báo Cáo Công Nợ"
        '
        'LAPBAOCAOCONGNOGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 537)
        Me.Controls.Add(Me.LabelControl14)
        Me.Controls.Add(Me.progressBarControl)
        Me.Controls.Add(Me.XuatFileExelButton)
        Me.Controls.Add(Me.LapBaoCaoButton)
        Me.Controls.Add(Me.ThangLapBaoCaoDateTimePicker)
        Me.Controls.Add(Me.LapBaoCaoCongNoGridControl)
        Me.Controls.Add(Me.LabelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "LAPBAOCAOCONGNOGUI"
        Me.Text = "LAPBAOCAOCONGNOGUI"
        CType(Me.LapBaoCaoCongNoGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LapBaoCaoCongNoGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.progressBarControl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ThangLapBaoCaoDateTimePicker As DateTimePicker
    Friend WithEvents SaveDialog As SaveFileDialog
    Friend WithEvents BackgroundWorker As System.ComponentModel.BackgroundWorker
    Private WithEvents LapBaoCaoCongNoGridControl As DevExpress.XtraGrid.GridControl
    Private WithEvents LapBaoCaoCongNoGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Private WithEvents LapBaoCaoButton As DevExpress.XtraEditors.SimpleButton
    Private WithEvents XuatFileExelButton As DevExpress.XtraEditors.SimpleButton
    Private WithEvents progressBarControl As DevExpress.XtraEditors.ProgressBarControl
    Private WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
End Class
