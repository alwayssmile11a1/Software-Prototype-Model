<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class XtraUserControl1
    Inherits DevExpress.XtraEditors.XtraUserControl
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub


#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Dim TileItemElement1 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement2 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Me.tileBar = New DevExpress.XtraBars.Navigation.TileBar()
        Me.tileBarGroupTables = New DevExpress.XtraBars.Navigation.TileBarGroup()
        Me.eployeesTileBarItem = New DevExpress.XtraBars.Navigation.TileBarItem()
        Me.customersTileBarItem = New DevExpress.XtraBars.Navigation.TileBarItem()
        Me.navigationFrame = New DevExpress.XtraBars.Navigation.NavigationFrame()
        Me.employeesNavigationPage = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.employeesLabelControl = New DevExpress.XtraEditors.LabelControl()
        Me.customersNavigationPage = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.customersLabelControl = New DevExpress.XtraEditors.LabelControl()
        CType(Me.navigationFrame, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.navigationFrame.SuspendLayout()
        Me.employeesNavigationPage.SuspendLayout()
        Me.customersNavigationPage.SuspendLayout()
        Me.SuspendLayout()
        '
        'tileBar
        '
        Me.tileBar.AllowDrag = False
        Me.tileBar.AllowGlyphSkinning = True
        Me.tileBar.AllowSelectedItem = True
        Me.tileBar.AppearanceGroupText.ForeColor = System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.tileBar.AppearanceGroupText.Options.UseForeColor = True
        Me.tileBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.tileBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.tileBar.DropDownButtonWidth = 30
        Me.tileBar.DropDownOptions.BeakColor = System.Drawing.Color.Empty
        Me.tileBar.Groups.Add(Me.tileBarGroupTables)
        Me.tileBar.IndentBetweenGroups = 10
        Me.tileBar.IndentBetweenItems = 10
        Me.tileBar.ItemPadding = New System.Windows.Forms.Padding(8, 6, 12, 6)
        Me.tileBar.Location = New System.Drawing.Point(0, 0)
        Me.tileBar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tileBar.MaxId = 3
        Me.tileBar.MaximumSize = New System.Drawing.Size(0, 110)
        Me.tileBar.MinimumSize = New System.Drawing.Size(100, 110)
        Me.tileBar.Name = "tileBar"
        Me.tileBar.Padding = New System.Windows.Forms.Padding(29, 11, 29, 11)
        Me.tileBar.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.None
        Me.tileBar.SelectedItem = Me.eployeesTileBarItem
        Me.tileBar.SelectionBorderWidth = 2
        Me.tileBar.SelectionColorMode = DevExpress.XtraBars.Navigation.SelectionColorMode.UseItemBackColor
        Me.tileBar.ShowGroupText = False
        Me.tileBar.Size = New System.Drawing.Size(800, 110)
        Me.tileBar.TabIndex = 1
        Me.tileBar.Text = "tileBar"
        Me.tileBar.WideTileWidth = 150
        '
        'tileBarGroupTables
        '
        Me.tileBarGroupTables.Items.Add(Me.eployeesTileBarItem)
        Me.tileBarGroupTables.Items.Add(Me.customersTileBarItem)
        Me.tileBarGroupTables.Name = "tileBarGroupTables"
        Me.tileBarGroupTables.Text = "TABLES"
        '
        'eployeesTileBarItem
        '
        Me.eployeesTileBarItem.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.eployeesTileBarItem.AppearanceItem.Normal.Options.UseBackColor = True
        Me.eployeesTileBarItem.DropDownOptions.BeakColor = System.Drawing.Color.Empty
        TileItemElement1.ImageUri.Uri = "Cube;Size32x32;GrayScaled"
        TileItemElement1.Text = "Employees"
        Me.eployeesTileBarItem.Elements.Add(TileItemElement1)
        Me.eployeesTileBarItem.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.[Default]
        Me.eployeesTileBarItem.Name = "eployeesTileBarItem"
        '
        'customersTileBarItem
        '
        Me.customersTileBarItem.DropDownOptions.BeakColor = System.Drawing.Color.Empty
        TileItemElement2.ImageUri.Uri = "Cube;Size32x32;GrayScaled"
        TileItemElement2.Text = "Customers"
        Me.customersTileBarItem.Elements.Add(TileItemElement2)
        Me.customersTileBarItem.Id = 2
        Me.customersTileBarItem.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide
        Me.customersTileBarItem.Name = "customersTileBarItem"
        '
        'navigationFrame
        '
        Me.navigationFrame.Controls.Add(Me.employeesNavigationPage)
        Me.navigationFrame.Controls.Add(Me.customersNavigationPage)
        Me.navigationFrame.Dock = System.Windows.Forms.DockStyle.Fill
        Me.navigationFrame.Location = New System.Drawing.Point(0, 110)
        Me.navigationFrame.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.navigationFrame.Name = "navigationFrame"
        Me.navigationFrame.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {Me.employeesNavigationPage, Me.customersNavigationPage})
        Me.navigationFrame.SelectedPage = Me.employeesNavigationPage
        Me.navigationFrame.Size = New System.Drawing.Size(800, 490)
        Me.navigationFrame.TabIndex = 0
        Me.navigationFrame.Text = "navigationFrame"
        '
        'employeesNavigationPage
        '
        Me.employeesNavigationPage.Caption = "employeesNavigationPage"
        Me.employeesNavigationPage.Controls.Add(Me.employeesLabelControl)
        Me.employeesNavigationPage.Name = "employeesNavigationPage"
        Me.employeesNavigationPage.Size = New System.Drawing.Size(800, 490)
        '
        'employeesLabelControl
        '
        Me.employeesLabelControl.Appearance.Font = New System.Drawing.Font("Tahoma", 25.25!)
        Me.employeesLabelControl.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.employeesLabelControl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.employeesLabelControl.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.employeesLabelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.employeesLabelControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.employeesLabelControl.Location = New System.Drawing.Point(0, 0)
        Me.employeesLabelControl.Name = "employeesLabelControl"
        Me.employeesLabelControl.Size = New System.Drawing.Size(800, 490)
        Me.employeesLabelControl.TabIndex = 2
        Me.employeesLabelControl.Text = "Employees"
        '
        'customersNavigationPage
        '
        Me.customersNavigationPage.Caption = "customersNavigationPage"
        Me.customersNavigationPage.Controls.Add(Me.customersLabelControl)
        Me.customersNavigationPage.Name = "customersNavigationPage"
        Me.customersNavigationPage.Size = New System.Drawing.Size(800, 490)
        '
        'customersLabelControl
        '
        Me.customersLabelControl.Appearance.Font = New System.Drawing.Font("Tahoma", 25.25!)
        Me.customersLabelControl.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.customersLabelControl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.customersLabelControl.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.customersLabelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.customersLabelControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.customersLabelControl.Location = New System.Drawing.Point(0, 0)
        Me.customersLabelControl.Name = "customersLabelControl"
        Me.customersLabelControl.Size = New System.Drawing.Size(800, 490)
        Me.customersLabelControl.TabIndex = 2
        Me.customersLabelControl.Text = "Customers"
        '
        'XtraUserControl1
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.navigationFrame)
        Me.Controls.Add(Me.tileBar)
        Me.Name = "XtraUserControl1"
        Me.Size = New System.Drawing.Size(800, 600)
        CType(Me.navigationFrame, System.ComponentModel.ISupportInitialize).EndInit()
        Me.navigationFrame.ResumeLayout(False)
        Me.employeesNavigationPage.ResumeLayout(False)
        Me.customersNavigationPage.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private WithEvents tileBar As DevExpress.XtraBars.Navigation.TileBar
    Private navigationFrame As DevExpress.XtraBars.Navigation.NavigationFrame
    Private tileBarGroupTables As DevExpress.XtraBars.Navigation.TileBarGroup
    Private eployeesTileBarItem As DevExpress.XtraBars.Navigation.TileBarItem
    Private customersTileBarItem As DevExpress.XtraBars.Navigation.TileBarItem
    Private employeesNavigationPage As DevExpress.XtraBars.Navigation.NavigationPage
    Private customersNavigationPage As DevExpress.XtraBars.Navigation.NavigationPage
    Private employeesLabelControl As DevExpress.XtraEditors.LabelControl
    Private customersLabelControl As DevExpress.XtraEditors.LabelControl

End Class
