Imports BUS
Imports DTO

Public Class REMOVEDKHACHHANGGUI

    Public Shared GUI As New REMOVEDKHACHHANGGUI


    Private Sub REMOVEDKHACHHANGGUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Setup KieuSoSanhComboBox
        KieuSoSanhComboBox.Properties.Items.Add("Bằng")
        KieuSoSanhComboBox.Properties.Items.Add("Lớn hơn")
        KieuSoSanhComboBox.Properties.Items.Add("Lớn hơn hoặc bằng")
        KieuSoSanhComboBox.Properties.Items.Add("Nhỏ hơn")
        KieuSoSanhComboBox.Properties.Items.Add("Nhỏ hơn hoặc bằng")
        KieuSoSanhComboBox.SelectedIndex = 2

        'Addhandler
        AddHandler MaKhachHangTraCuuTextBox.EditValueChanged, AddressOf TraCuuTextBox_EditValueChanged
        AddHandler HoTenTraCuuTextBox.EditValueChanged, AddressOf TraCuuTextBox_EditValueChanged
        AddHandler DienThoaiTraCuuTextBox.EditValueChanged, AddressOf TraCuuTextBox_EditValueChanged
        AddHandler EmailTraCuuTextBox.EditValueChanged, AddressOf TraCuuTextBox_EditValueChanged
        AddHandler DiaChiTraCuuTextBox.EditValueChanged, AddressOf TraCuuTextBox_EditValueChanged
        AddHandler SoTienNoTraCuuTextBox.EditValueChanged, AddressOf TraCuuTextBox_EditValueChanged

        'Display immediately
        FindRemovedCustomers()

    End Sub

    Private Sub KhoiPhucKhachHangButton_Click(sender As Object, e As EventArgs) Handles KhoiPhucKhachHangButton.Click

        'Get selected row
        Dim selectedRow As DataRow = ThongTinKhachHangGridView.GetDataRow(ThongTinKhachHangGridView.FocusedRowHandle)

        If (selectedRow Is Nothing) Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Xin hãy chọn một dòng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        'show safe dialog
        Dim result As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Bạn có chắc chắn muốn khôi phục lại khách hàng này không? ", "Cẩn Thận!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        'if user press Yes button
        If (result = DialogResult.Yes) Then

            'store exception
            Dim ex As String = ""

            'retrieve book
            KHACHHANGBUS.RetriveRemovedCustomer(selectedRow.Item("Mã Khách Hàng").ToString(), ex)

            'if something bad happened
            If (ex <> "") Then
                DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            DevExpress.XtraEditors.XtraMessageBox.Show("Khôi phục thành công ", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'show the things have changed
            FindRemovedCustomers()

            KHACHHANGGUI.GUI.RefreshGUI()
            LAPHOADONBANSACHGUI.GUI.RefreshGUI()
            LAPPHIEUTHUTIENGUI.GUI.RefreshGUI()

        End If

    End Sub

    Private Sub TraCuuTextBox_EditValueChanged(sender As Object, e As EventArgs)
        FindRemovedCustomers()
    End Sub

    Private Sub TimTheoComboBox_SelectedIndexChanged(sender As Object, e As EventArgs)
        FindRemovedCustomers()
    End Sub

    Private Sub FindRemovedCustomers()

        'set up to compare type
        Dim compareType As String = "="
        Select Case KieuSoSanhComboBox.SelectedIndex
            Case 0 : compareType = "="
            Case 1 : compareType = ">"
            Case 2 : compareType = ">="
            Case 3 : compareType = "<"
            Case 4 : compareType = "<="
        End Select

        Dim soTienNoToCompare As Decimal = -999999999
        If (SoTienNoTraCuuTextBox.Text = "") Then
            compareType = ">="
        Else
            soTienNoToCompare = Decimal.Parse(SoTienNoTraCuuTextBox.Text, Globalization.NumberStyles.Currency)
        End If


        Dim ex As String = ""
        ThongTinKhachHangGridControl.DataSource = KHACHHANGBUS.SearchCustomers(MaKhachHangTraCuuTextBox.Text, HoTenTraCuuTextBox.Text, DiaChiTraCuuTextBox.Text, DienThoaiTraCuuTextBox.Text,
                                                                                EmailTraCuuTextBox.Text, compareType, soTienNoToCompare, False, ex)

        TongSoKetQuaLabelControl.Text = ThongTinKhachHangGridView.RowCount.ToString + " kết quả trả về"

        If (ex <> "") Then
            DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub TimTatCaButton_Click(sender As Object, e As EventArgs) Handles TimTatCaButton.Click
        HoTenTraCuuTextBox.Text = ""
        DiaChiTraCuuTextBox.Text = ""
        DienThoaiTraCuuTextBox.Text = ""
        EmailTraCuuTextBox.Text = ""
        SoTienNoTraCuuTextBox.Text = ""
        FindRemovedCustomers()
    End Sub

    Public Sub RefreshGUI()
        Try
            FindRemovedCustomers()
        Catch ex As Exception

        End Try
    End Sub

End Class