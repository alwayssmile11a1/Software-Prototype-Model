Imports BUS
Imports DTO
Public Class REMOVEDSACHGUI

    Public Shared GUI As New REMOVEDSACHGUI

    Private Sub REMOVEDSACHGUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Add items to KieuSoSanhComboBox
        SoLuongTonKieuSoSanhComboBox.Properties.Items.Add("Bằng")
        SoLuongTonKieuSoSanhComboBox.Properties.Items.Add("Lớn hơn")
        SoLuongTonKieuSoSanhComboBox.Properties.Items.Add("Lớn hơn hoặc bằng")
        SoLuongTonKieuSoSanhComboBox.Properties.Items.Add("Nhỏ hơn")
        SoLuongTonKieuSoSanhComboBox.Properties.Items.Add("Nhỏ hơn hoặc bằng")
        SoLuongTonKieuSoSanhComboBox.SelectedIndex = 2

        DonGiaKieuSoSanhComboBox.Properties.Items.Add("Bằng")
        DonGiaKieuSoSanhComboBox.Properties.Items.Add("Lớn hơn")
        DonGiaKieuSoSanhComboBox.Properties.Items.Add("Lớn hơn hoặc bằng")
        DonGiaKieuSoSanhComboBox.Properties.Items.Add("Nhỏ hơn")
        DonGiaKieuSoSanhComboBox.Properties.Items.Add("Nhỏ hơn hoặc bằng")
        DonGiaKieuSoSanhComboBox.SelectedIndex = 2

        'Addhandler
        AddHandler MaSachTraCuuTextBox.EditValueChanged, AddressOf TraCuuTextBox_EditValueChanged
        AddHandler TenSachTraCuuTextBox.EditValueChanged, AddressOf TraCuuTextBox_EditValueChanged
        AddHandler TheLoaiTraCuuTextBox.EditValueChanged, AddressOf TraCuuTextBox_EditValueChanged
        AddHandler TacGiaTraCuuTextBox.EditValueChanged, AddressOf TraCuuTextBox_EditValueChanged
        AddHandler SoLuongTonTraCuuTextBox.EditValueChanged, AddressOf TraCuuTextBox_EditValueChanged
        AddHandler DonGiaTraCuuTextBox.EditValueChanged, AddressOf TraCuuTextBox_EditValueChanged

        'display immediately
        FindRemovedBooks()

    End Sub

    Private Sub KhoiPhucSachButton_Click(sender As Object, e As EventArgs) Handles KhoiPhucSachButton.Click

        Dim selectedRow As DataRow = ThongTinSachGridView.GetDataRow(ThongTinSachGridView.FocusedRowHandle)

        If (selectedRow Is Nothing) Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Xin hãy chọn một dòng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        'show safe dialog
        Dim result As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Bạn có chắc chắn muốn khôi phục lại đầu sách này không? ", "Cẩn Thận!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        'if user press Yes button
        If (result = DialogResult.Yes) Then

            'store exception
            Dim ex As String = ""

            'retrieve book
            SACHBUS.RetriveRemovedBook(selectedRow.Item("Mã Sách").ToString, ex)

            'if something bad happened
            If (ex <> "") Then
                DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            DevExpress.XtraEditors.XtraMessageBox.Show("Khôi phục thành công", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'Show the things have changed
            FindRemovedBooks()

            SACHGUI.GUI.RefreshGUI()
            LAPHOADONBANSACHGUI.GUI.RefreshGUI()
            LAPPHIEUNHAPSACHGUI.GUI.RefreshGUI()

        End If

    End Sub

    Private Sub TraCuuTextBox_EditValueChanged(sender As Object, e As EventArgs)
        FindRemovedBooks()
    End Sub

    Private Sub SoLuongTonKieuSoSanhComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SoLuongTonKieuSoSanhComboBox.SelectedIndexChanged
        FindRemovedBooks()
    End Sub

    Private Sub DonGiaKieuSoSanhComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DonGiaKieuSoSanhComboBox.SelectedIndexChanged
        FindRemovedBooks()
    End Sub

    Private Sub FindRemovedBooks()
        'set up to compare SoLuongTon
        Dim soLuongTonCompareType As String = "="
        Select Case SoLuongTonKieuSoSanhComboBox.SelectedIndex
            Case 0 : soLuongTonCompareType = "="
            Case 1 : soLuongTonCompareType = ">"
            Case 2 : soLuongTonCompareType = ">="
            Case 3 : soLuongTonCompareType = "<"
            Case 4 : soLuongTonCompareType = "<="
        End Select

        Dim soLuongTonToCompare As Integer = 0
        If (SoLuongTonTraCuuTextBox.Text = "") Then
            soLuongTonCompareType = ">="
        Else
            soLuongTonToCompare = Integer.Parse(SoLuongTonTraCuuTextBox.Text, Globalization.NumberStyles.Number)
        End If

        'set up to compare DonGia
        Dim donGiaCompareType As String = "="
        Select Case DonGiaKieuSoSanhComboBox.SelectedIndex
            Case 0 : donGiaCompareType = "="
            Case 1 : donGiaCompareType = ">"
            Case 2 : donGiaCompareType = ">="
            Case 3 : donGiaCompareType = "<"
            Case 4 : donGiaCompareType = "<="
        End Select

        Dim donGiaToCompare As Decimal = 0
        If (DonGiaTraCuuTextBox.Text = "") Then
            donGiaCompareType = ">="
        Else
            donGiaToCompare = Decimal.Parse(DonGiaTraCuuTextBox.Text, Globalization.NumberStyles.Currency)
        End If

        Dim ex As String = ""
        ThongTinSachGridControl.DataSource = SACHBUS.SearchBooks(MaSachTraCuuTextBox.Text, TenSachTraCuuTextBox.Text, TheLoaiTraCuuTextBox.Text, TacGiaTraCuuTextBox.Text,
                                                                 donGiaToCompare, donGiaCompareType, soLuongTonToCompare, soLuongTonCompareType, False, ex)

        TongSoKetQuaLabelControl.Text = ThongTinSachGridView.RowCount.ToString + " kết quả trả về"

        If (ex <> "") Then
            DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub TimTatCaButton_Click(sender As Object, e As EventArgs) Handles TimTatCaButton.Click
        MaSachTraCuuTextBox.Text = ""
        TenSachTraCuuTextBox.Text = ""
        TheLoaiTraCuuTextBox.Text = ""
        TacGiaTraCuuTextBox.Text = ""
        SoLuongTonTraCuuTextBox.Text = ""
        DonGiaTraCuuTextBox.Text = ""
        FindRemovedBooks()
    End Sub

    Public Sub RefreshGUI()
        Try
            FindRemovedBooks()
        Catch ex As Exception

        End Try
    End Sub

End Class
