Imports System.ComponentModel
Imports System.Text
Imports MySql.Data.MySqlClient
Imports BUS
Imports System.IO
Imports System.Xml

Partial Public Class _MainForm

    Shared Sub New()
        DevExpress.UserSkins.BonusSkins.Register()
        DevExpress.Skins.SkinManager.EnableFormSkins()
    End Sub
    Public Sub New()
        InitializeComponent()

    End Sub


    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PanelControl.Dock = DockStyle.Fill

        'store exception
        Dim ex As String = ""

        'Connect to database
        MYSQLCONNECTIONBUS.ConnectToDatabase("localhost", "root", "son11son", "bookmanagementdatabase", ex)

        If (ex <> "") Then
            DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    ''' <summary>
    ''' Disconnect after form closed
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub _MainForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        MYSQLCONNECTIONBUS.DisConnectFromDatabase()
    End Sub

    ''' <summary>
    ''' Show safe dialog when form is closing
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub _MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If (DevExpress.XtraEditors.XtraMessageBox.Show("Một số công việc có thể chưa hoàn thành, bạn có chắc chắn muốn thoát không?", "Cẩn Thận!!",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No) Then
            e.Cancel() = True
        End If

    End Sub

#Region "Tile items click"

#Region "Parent tile items"

    Private Sub KhachHangTileItem_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles KhachHangTileItem.ItemClick
        'KhachHangTileControl.Show()
        'KhachHangTileControl.BringToFront()
        AddControlToPanel(KHACHHANGGUI.GUI)
    End Sub

    Private Sub SachTileItem_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles SachTileItem.ItemClick
        'SachTileControl.Show()
        'SachTileControl.BringToFront()
        AddControlToPanel(SACHGUI.GUI)
    End Sub

    Private Sub BieuMauTileItem_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles BieuMauTileItem.ItemClick
        BieuMauTileControl.Dock = DockStyle.Fill
        BieuMauTileControl.BringToFront()
        BieuMauTileControl.Show()
    End Sub

    Private Sub QuyDinhTileItem_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles QuyDinhTileItem.ItemClick
        QuyDinhTileControl.Dock = DockStyle.Fill
        QuyDinhTileControl.BringToFront()
        QuyDinhTileControl.Show()
    End Sub

    Private Sub BaoCaoTileItem_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles BaoCaoTileItem.ItemClick
        BaoCaoTileControl.Dock = DockStyle.Fill
        BaoCaoTileControl.BringToFront()
        BaoCaoTileControl.Show()
    End Sub

    Private Sub DuLieuDaXoaTileItem_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles DuLieuDaXoaTileItem.ItemClick
        DuLieuDaXoaTileControl.Dock = DockStyle.Fill
        DuLieuDaXoaTileControl.BringToFront()
        DuLieuDaXoaTileControl.Show()
    End Sub

#End Region

#Region "Child tile items"


    Private Sub LapPhieuThuTienTileItem_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles LapPhieuThuTienTileItem.ItemClick
        AddControlToPanel(LAPPHIEUTHUTIENGUI.GUI)
    End Sub

    Private Sub LapPhieuNhapSachTileItem_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles LapPhieuNhapSachTileItem.ItemClick
        AddControlToPanel(LAPPHIEUNHAPSACHGUI.GUI)
    End Sub

    Private Sub LapHoaDonBanSachTileItem_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles LapHoaDonBanSachTileItem.ItemClick
        AddControlToPanel(LAPHOADONBANSACHGUI.GUI)
    End Sub

    Private Sub ThayDoiQuyDinhTileItem_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles ThayDoiQuyDinhTileItem.ItemClick
        AddControlToPanel(THAYDOIQUYDINHGUI.GUI)
    End Sub

    Private Sub LapBaoCaoTonTileItem_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles LapBaoCaoTonTileItem.ItemClick
        AddControlToPanel(LAPBAOCAOTONGUI.GUI)
    End Sub

    Private Sub LapBaoCaoCongNoTileItem_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles LapBaoCaoCongNoTileItem.ItemClick
        AddControlToPanel(LAPBAOCAOCONGNOGUI.GUI)
    End Sub

    Private Sub SachDaXoaTileItem_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles SachDaXoaTileItem.ItemClick
        AddControlToPanel(REMOVEDSACHGUI.GUI)
    End Sub

    Private Sub KhachHangDaXoaTileItem_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles KhachHangDaXoaTileItem.ItemClick
        AddControlToPanel(REMOVEDKHACHHANGGUI.GUI)
    End Sub

    Private Sub DatabaseTileItem_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles DatabaseTileItem.ItemClick
        AddControlToPanel(DATABASEGUI.GUI)
    End Sub

#End Region

#End Region

    ''' <summary>
    ''' Add control to panel
    ''' </summary>
    ''' <param name="GUI"></param>
    Private Sub AddControlToPanel(ByVal GUI As Form)
        'We have to clear this first 
        'if not, panel control will add control over and over again
        PanelControl.Controls.Clear()
        'set TopLevel = false to allow adding into panel Control
        GUI.TopLevel = False
        'Dock Fill in the panel Control
        GUI.Dock = DockStyle.Fill
        'Add this Form to PanelControl
        PanelControl.Controls.Add(GUI)

        'Show this form
        GUI.Show()
        'Bring this PanelControl to front to display it
        PanelControl.BringToFront()

    End Sub


End Class
