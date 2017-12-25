Imports BUS
Imports DTO
Imports System.Xml
Imports System.IO
Imports Geocoding.Google
Imports Geocoding
Imports System.Collections.Generic

Public Class KHACHHANGGUI

    'Since we don't want to create new instance of this class over and over again
    'So using a Shared variable (like a static in C#) makes sense
    Public Shared GUI As New KHACHHANGGUI

    'a string to store the thing user is about to do
    Dim task As String = ""

#Region "All events"

    Private Sub KHACHHANG_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Setup KieuSoSanhComboBox
        KieuSoSanhComboBox.Properties.Items.Add("Bằng")
        KieuSoSanhComboBox.Properties.Items.Add("Lớn hơn")
        KieuSoSanhComboBox.Properties.Items.Add("Lớn hơn hoặc bằng")
        KieuSoSanhComboBox.Properties.Items.Add("Nhỏ hơn")
        KieuSoSanhComboBox.Properties.Items.Add("Nhỏ hơn hoặc bằng")
        KieuSoSanhComboBox.SelectedIndex = 2

        'Set up some text boxes to prevent user type in
        HoTenTextBox.ReadOnly = True
        DiaChiTextBox.ReadOnly = True
        DienThoaiTextBox.ReadOnly = True
        EmailTextBox.ReadOnly = True
        SoTienNoTextBox.ReadOnly = True

        'Allow null input
        SoTienNoTraCuuTextBox.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
        DienThoaiTextBox.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True

        'Add Handler
        AddHandler MaKhachHangTraCuuTextBox.EditValueChanged, AddressOf TraCuuTextBox_EditValueChanged
        AddHandler HoTenTraCuuTextBox.EditValueChanged, AddressOf TraCuuTextBox_EditValueChanged
        AddHandler DienThoaiTraCuuTextBox.EditValueChanged, AddressOf TraCuuTextBox_EditValueChanged
        AddHandler EmailTraCuuTextBox.EditValueChanged, AddressOf TraCuuTextBox_EditValueChanged
        AddHandler DiaChiTraCuuTextBox.EditValueChanged, AddressOf TraCuuTextBox_EditValueChanged
        AddHandler SoTienNoTraCuuTextBox.EditValueChanged, AddressOf TraCuuTextBox_EditValueChanged

        'Do this to immediately display all customers 
        FindCustomers()

        'Set Filter being displayed 
        SaveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"

    End Sub

    ''' <summary>
    ''' Find customer when the value in text boxes changed
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TraCuuTextBox_EditValueChanged(sender As Object, e As EventArgs)
        FindCustomers()
    End Sub

    Private Sub TimTheoComboBox_SelectedIndexChanged(sender As Object, e As EventArgs)
        FindCustomers()
    End Sub

    ''' <summary>
    ''' Display the information of a customer when click a row  
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ThongTinKhachHangGridView_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles ThongTinKhachHangGridView.RowClick
        'We check this because we don't want to change the text in text boxes when user is doing adding 
        If (task <> "Add") Then
            'get selected row
            Dim selectedRow As DataRow = ThongTinKhachHangGridView.GetDataRow(e.RowHandle)

            'set the text of MaKhachHangTextBox
            MaKhachHangTextBox.Text = selectedRow.Item("Mã Khách Hàng").ToString
        End If

    End Sub

    ''' <summary>
    ''' Find customer when the text of MaKhachHangTextBox changed
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MaKhachHangTextBox_EditValueChanged(sender As Object, e As EventArgs) Handles MaKhachHangTextBox.EditValueChanged
        'a string variable to hold exception
        Dim ex As String = ""
        Dim khachHang As KHACHHANGDTO = Nothing
        'Find customer by ID (ID is typed in MaKhachHangTextBox)
        khachHang = KHACHHANGBUS.FindCustomerByID(MaKhachHangTextBox.Text, True, ex)

        'if ex <>"" mean exception occured
        If (ex <> "") Then
            DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        'if khachHang is nothing
        If (khachHang Is Nothing) Then
            HoTenTextBox.Text = ""
            DiaChiTextBox.Text = ""
            DienThoaiTextBox.Text = ""
            EmailTextBox.Text = ""
            SoTienNoTextBox.Text = ""

            Return
        End If

        'set the text
        HoTenTextBox.Text = khachHang.HoTenKhachHang
        DiaChiTextBox.Text = khachHang.DiaChi
        DienThoaiTextBox.Text = khachHang.DienThoai
        EmailTextBox.Text = khachHang.EMail
        SoTienNoTextBox.Text = khachHang.SoTienNo.ToString("c0")

    End Sub

    ''' <summary>
    ''' Apply the mask of the text to the text 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SoTienNoTextBox_Leave(sender As Object, e As EventArgs) Handles SoTienNoTextBox.Leave
        SoTienNoTextBox.Text = SoTienNoTextBox.Text
    End Sub

    ''' <summary>
    ''' Apply the mask of the text to the text 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SoTienNoTraCuuTextBox_Leave(sender As Object, e As EventArgs) Handles SoTienNoTraCuuTextBox.Leave
        SoTienNoTraCuuTextBox.Text = SoTienNoTraCuuTextBox.Text
    End Sub

#End Region

#Region "Functions"

    ''' <summary>
    ''' Do Adding
    ''' </summary>
    Private Sub DoAdding()
        'if there is nothing in text boxes
        If (HoTenTextBox.Text = "" Or DiaChiTextBox.Text = "" Or DienThoaiTextBox.Text = "") Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Xin hãy điền đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        'show safe dialog
        Dim result As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Bạn có chắc chắn muốn thêm khách hàng này không? ", "Cảnh báo!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        'if user press Yes button
        If (result = DialogResult.Yes) Then
            'Store exception
            Dim ex As String = ""

            'get khachhang information
            Dim khachHang As New KHACHHANGDTO(MaKhachHangTextBox.Text, HoTenTextBox.Text, DiaChiTextBox.Text, DienThoaiTextBox.Text,
                                          EmailTextBox.Text, 0)

            'if nothing bad happened
            If (KHACHHANGBUS.InsertCustomer(khachHang, ex) = True) Then

                ''we have to create a new BaoCaoCongNo for this customer
                'If (BAOCAOCONGNOBUS.InsertBaoCaoCongNo(MaKhachHangTextBox.Text, DateTime.Now.Month, DateTime.Now.Year, ex) = False) Then
                '    DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    'Insert information into LichSuThaoTacTextBox
                '    InsertInformationIntoFlowPanel("LỖI", "", DateTime.Now.ToString() & "  " & ex, Color.Red)
                'End If

                'Show message
                DevExpress.XtraEditors.XtraMessageBox.Show("Thêm thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)


                'a string to hold KhachHang's information to append into LichSuThaoTacTextBox 
                Dim khachHangInformation As String = String.Format(DateTime.Now.ToString() & "  Mã Khách Hàng: {0}   Khách hàng: {1}   Địa Chỉ: {2}   Điện Thoại: {3}   Email: {4}   Số Tiền Nợ: {5}",
                                                                        MaKhachHangTextBox.Text, HoTenTextBox.Text, DiaChiTextBox.Text, DienThoaiTextBox.Text,
                                                                        EmailTextBox.Text, SoTienNoTextBox.Text)

                'Insert information into LichSuThaoTacFlowPanel
                InsertInformationIntoFlowPanel("THÊM THÀNH CÔNG", MaKhachHangTextBox.Text, khachHangInformation, Color.Green)

                'Update MaKhachHang in MaKhachHangTextBox
                MaKhachHangTextBox.Text = KHACHHANGBUS.GetNewCustomerID()
                SoTienNoTextBox.Text = "0"

                LAPHOADONBANSACHGUI.GUI.RefreshGUI()
                LAPPHIEUTHUTIENGUI.GUI.RefreshGUI()

                Return
            End If

            'Or something bad happened
            DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Insert information into LichSuThaoTacTextBox
            InsertInformationIntoFlowPanel("THÊM THẤT BẠI", "", DateTime.Now.ToString() & "  " & ex, Color.Red)
        End If

    End Sub

    ''' <summary>
    ''' Do Deleting
    ''' </summary>
    Private Sub DoDeleting()

        'a variable to store exception
        Dim ex As String = ""

        'if user hasn't typed in the right ID
        If (KHACHHANGBUS.FindCustomerByID(MaKhachHangTextBox.Text, True, ex) Is Nothing) Then
            If (ex <> "") Then
                'Show exception
                DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                DevExpress.XtraEditors.XtraMessageBox.Show("Không tồn tại khách hàng này trong cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            Return
        End If

        'show safe dialog
        Dim result As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này không? ", "Cẩn thận!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        'if user press Yes button
        If (result = DialogResult.Yes) Then

            'if nothing bad happened
            If (KHACHHANGBUS.RemoveCustomer(MaKhachHangTextBox.Text, ex) = True) Then
                'Show message
                DevExpress.XtraEditors.XtraMessageBox.Show("Xóa thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'a string to hold KhachHang's information to append into LichSuThaoTacTextBox 
                Dim khachHangInformation As String = String.Format(DateTime.Now.ToString() & "  " & "Mã Khách Hàng: {0}   Khách hàng: {1}   Địa Chỉ: {2}   Điện Thoại: {3}   Email: {4}   Số Tiền Nợ: {5}",
                                                               MaKhachHangTextBox.Text, HoTenTextBox.Text, DiaChiTextBox.Text, DienThoaiTextBox.Text,
                                                               EmailTextBox.Text, SoTienNoTextBox.Text)


                'Insert information into LichSuThaoTacFlowPanel
                InsertInformationIntoFlowPanel("XÓA THÀNH CÔNG", "", khachHangInformation, Color.Green)

                'Simply set this to delete all the text in the others text boxes 
                MaKhachHangTextBox.Text = ""


                'Update removed customers gridview
                REMOVEDKHACHHANGGUI.GUI.RefreshGUI()
                LAPHOADONBANSACHGUI.GUI.RefreshGUI()
                LAPPHIEUTHUTIENGUI.GUI.RefreshGUI()

                Return
            End If

            'Or something bad happened
            DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Insert information into LichSuThaoTacTextBox
            InsertInformationIntoFlowPanel("XÓA THẤT BẠI", "", DateTime.Now.ToString() & "  " & ex, Color.Red)


        End If


    End Sub

    ''' <summary>
    ''' Do Updating
    ''' </summary>
    Private Sub DoUpdating()
        'a variable to store exception
        Dim ex As String = ""

        'if user hasn't typed in the right ID
        If (KHACHHANGBUS.FindCustomerByID(MaKhachHangTextBox.Text, True, ex) Is Nothing) Then
            If (ex <> "") Then
                'Show exception
                DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                DevExpress.XtraEditors.XtraMessageBox.Show("Không tồn tại khách hàng này trong cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            Return
        End If

        'if there is nothing in text boxes
        If (HoTenTextBox.Text = "" Or DiaChiTextBox.Text = "" Or DienThoaiTextBox.Text = "" Or SoTienNoTextBox.Text = "") Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Xin hãy điền đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        'show safe dialog
        Dim result As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Bạn có chắc chắn muốn cập nhật không? ", "Cẩn thận!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        'if user press Yes button
        If (result = DialogResult.Yes) Then

            'a variable to store khachHang information to do updating
            Dim khachHang As New KHACHHANGDTO(MaKhachHangTextBox.Text, HoTenTextBox.Text, DiaChiTextBox.Text, DienThoaiTextBox.Text,
                                          EmailTextBox.Text, Decimal.Parse(SoTienNoTextBox.Text, Globalization.NumberStyles.Currency))

            'if there is nothing bad happened
            If (KHACHHANGBUS.UpdateCustomer(khachHang, ex) = True) Then
                'Show message
                DevExpress.XtraEditors.XtraMessageBox.Show("Cập nhật thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'a string to hold KhachHang's information to append into LichSuThaoTacTextBox 
                Dim khachHangInformation As String = String.Format(DateTime.Now.ToString() & "  " & "Mã Khách Hàng: {0}   Khách hàng: {1}   Địa Chỉ: {2}   Điện Thoại: {3}   Email: {4}   Số Tiền Nợ: {5}",
                                                                    MaKhachHangTextBox.Text, HoTenTextBox.Text, DiaChiTextBox.Text, DienThoaiTextBox.Text,
                                                                    EmailTextBox.Text, SoTienNoTextBox.Text)

                'Insert information into LichSuThaoTacFlowPanel
                InsertInformationIntoFlowPanel("CẬP NHẬT THÀNH CÔNG", MaKhachHangTextBox.Text, khachHangInformation, Color.Green)

                LAPHOADONBANSACHGUI.GUI.RefreshGUI()
                LAPPHIEUTHUTIENGUI.GUI.RefreshGUI()

                Return

            End If

            'Or something bad happened
            DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Insert information into LichSuThaoTacTextBox
            InsertInformationIntoFlowPanel("CẬP NHẬT THẤT BẠI", "", DateTime.Now.ToString() & "  " & ex, Color.Red)

        End If

    End Sub

    Private Sub FindCustomers()

        'set up to compare type
        Dim compareType As String = "="
        Select Case KieuSoSanhComboBox.SelectedIndex
            Case 0 : compareType = "="
            Case 1 : compareType = ">"
            Case 2 : compareType = ">="
            Case 3 : compareType = "<"
            Case 4 : compareType = "<="
        End Select

        'get soTienNo to compare
        Dim soTienNoToCompare As Decimal = -999999999
        If (SoTienNoTraCuuTextBox.Text = "") Then
            compareType = ">="
        Else
            soTienNoToCompare = Decimal.Parse(SoTienNoTraCuuTextBox.Text, Globalization.NumberStyles.Currency)
        End If

        'store exception
        Dim ex As String = ""

        'Find customers
        ThongTinKhachHangGridControl.DataSource = KHACHHANGBUS.SearchCustomers(MaKhachHangTraCuuTextBox.Text, HoTenTraCuuTextBox.Text, DiaChiTraCuuTextBox.Text, DienThoaiTraCuuTextBox.Text,
                                                                                EmailTraCuuTextBox.Text, compareType, soTienNoToCompare, True, ex)

        'show exception if occur
        If (ex <> "") Then
            DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        'update tongsoketqualabel
        TongSoKetQuaLabelControl.Text = ThongTinKhachHangGridView.RowCount.ToString + " kết quả trả về"


    End Sub

    ''' <summary>
    ''' Insert information into LichSuThaoTacFlowPanel
    ''' </summary>
    ''' <param name="captionButtonText"></param>
    ''' <param name="captionButtonTag"></param>
    ''' <param name="information"></param>
    ''' <param name="captionButtonForeColor"></param>
    Private Sub InsertInformationIntoFlowPanel(ByVal captionButtonText As String, ByVal captionButtonTag As String, ByVal information As String, ByVal captionButtonForeColor As Color)

        Dim buttonFont As Font = New Font("Tahoma", 10, FontStyle.Bold)
        Dim labelFont As Font = New Font("Tahoma", 12)

        'captionButton
        Dim captionButton As DevExpress.XtraEditors.SimpleButton = New DevExpress.XtraEditors.SimpleButton()
        captionButton.Text = captionButtonText
        captionButton.Font = buttonFont
        captionButton.AutoSize = True
        captionButton.ForeColor = captionButtonForeColor
        captionButton.Tag = captionButtonTag
        LichSuThaoTacFlowLayoutPanel.Controls.Add(captionButton)

        'Add handler
        AddHandler captionButton.Click, AddressOf captionButton_Click

        'information label
        Dim informationLabel As Label = New Label()
        informationLabel.Text = information
        informationLabel.Font = labelFont
        informationLabel.AutoSize = True
        LichSuThaoTacFlowLayoutPanel.Controls.Add(informationLabel)

        LichSuThaoTacFlowLayoutPanel.ScrollControlIntoView(informationLabel)

        buttonFont.Dispose()
        labelFont.Dispose()
    End Sub

    ''' <summary>
    ''' Do something
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub captionButton_Click(sender As Object, e As EventArgs)
        Dim button As DevExpress.XtraEditors.SimpleButton = CType(sender, DevExpress.XtraEditors.SimpleButton)
        If (button.Tag.ToString() <> "") Then
            CapNhatButton.PerformClick()
            MaKhachHangTextBox.Text = button.Tag.ToString()
        End If

    End Sub

    Public Sub RefreshGUI()
        Try
            FindCustomers()
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Buttons"

    Private Sub ThemButton_Click(sender As Object, e As EventArgs) Handles ThemButton.Click
        'Set background
        ThemButton.Appearance.BackColor = Color.DimGray
        ThemButton.Appearance.ForeColor = Color.White

        XoaButton.Appearance.BackColor = Color.LightGray
        XoaButton.Appearance.ForeColor = Color.Black

        CapNhatButton.Appearance.BackColor = Color.LightGray
        CapNhatButton.Appearance.ForeColor = Color.Black


        'allow user to type in
        HoTenTextBox.ReadOnly = False
        DiaChiTextBox.ReadOnly = False
        DienThoaiTextBox.ReadOnly = False
        EmailTextBox.ReadOnly = False

        'set up ThucHienButton
        ThucHienButton.Text = "Đồng Ý Thêm"
        ThucHienButton.Visible = True

        'set the task string
        task = "Add"

        'set up MaKhachHangTextBox
        MaKhachHangTextBox.Text = KHACHHANGBUS.GetNewCustomerID()
        MaKhachHangTextBox.ReadOnly = True

        'set up SoTienNoTextBox
        SoTienNoTextBox.Text = Decimal.Parse("0").ToString("c0")
        SoTienNoTextBox.ReadOnly = True

    End Sub

    Private Sub CapNhatButton_Click(sender As Object, e As EventArgs) Handles CapNhatButton.Click
        'Set background
        ThemButton.Appearance.BackColor = Color.LightGray
        ThemButton.Appearance.ForeColor = Color.Black

        XoaButton.Appearance.BackColor = Color.LightGray
        XoaButton.Appearance.ForeColor = Color.Black

        CapNhatButton.Appearance.BackColor = Color.DimGray
        CapNhatButton.Appearance.ForeColor = Color.White

        MaKhachHangTextBox.ReadOnly = False
        HoTenTextBox.ReadOnly = False
        DiaChiTextBox.ReadOnly = False
        DienThoaiTextBox.ReadOnly = False
        EmailTextBox.ReadOnly = False
        SoTienNoTextBox.ReadOnly = True
        ThucHienButton.Visible = True
        ThucHienButton.Text = "Đồng Ý Cập Nhật"
        task = "Update"
    End Sub

    Private Sub XoaButton_Click(sender As Object, e As EventArgs) Handles XoaButton.Click
        'Set background
        ThemButton.Appearance.BackColor = Color.LightGray
        ThemButton.Appearance.ForeColor = Color.Black

        XoaButton.Appearance.BackColor = Color.DimGray
        XoaButton.Appearance.ForeColor = Color.White

        CapNhatButton.Appearance.BackColor = Color.LightGray
        CapNhatButton.Appearance.ForeColor = Color.Black

        'setup  
        MaKhachHangTextBox.ReadOnly = False
        HoTenTextBox.ReadOnly = True
        DiaChiTextBox.ReadOnly = True
        DienThoaiTextBox.ReadOnly = True
        EmailTextBox.ReadOnly = True
        SoTienNoTextBox.ReadOnly = True
        ThucHienButton.Visible = True
        ThucHienButton.Text = "Đồng Ý Xóa"
        task = "Remove"
    End Sub

    Private Sub ThucHienButton_Click(sender As Object, e As EventArgs) Handles ThucHienButton.Click
        Select Case (task)
            Case "Add"
                DoAdding()
                'we do this to immediately show the thing changed
                FindCustomers()
            Case "Remove"
                DoDeleting()
                'we do this to immediately show the thing changed
                FindCustomers()
            Case "Update"
                DoUpdating()
                'we do this to immediately show the thing changed
                FindCustomers()
        End Select


    End Sub

    Private Sub TimTatCaButton_Click(sender As Object, e As EventArgs) Handles TimTatCaButton.Click
        MaKhachHangTraCuuTextBox.Text = ""
        HoTenTraCuuTextBox.Text = ""
        DiaChiTraCuuTextBox.Text = ""
        DienThoaiTraCuuTextBox.Text = ""
        EmailTraCuuTextBox.Text = ""
        SoTienNoTraCuuTextBox.Text = ""
        FindCustomers()
    End Sub

    Private Sub TuDongHoanThanhButton_Click(sender As Object, e As EventArgs) Handles TuDongHoanThanhButton.Click
        Try
            If (task <> "Add" And task <> "Update") Then Return
            If (DiaChiTextBox.Text = "") Then Return
            Dim geocoder As IGeocoder = New GoogleGeocoder("AIzaSyA5CtspQbmuAk0PZrGGe0VPOvlPMlU-Qdw")
            Dim addresses As IEnumerable(Of Address) = geocoder.Geocode(DiaChiTextBox.Text)
            If (DevExpress.XtraEditors.XtraMessageBox.Show(addresses.First().FormattedAddress, "Thay thế địa chỉ hiện tại bằng địa chỉ này?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                DiaChiTextBox.Text = addresses.First().FormattedAddress
            End If

        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show("Không có kết nối mạng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Export to Exel
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub XuatFileExcelButton_Click(sender As Object, e As EventArgs) Handles XuatFileExcelButton.Click

        'If user presses OK
        If (SaveDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            UseWaitCursor = True
            Me.Enabled = False
            progressBarControl.Visible = True
            ExportBackgroundWorker.WorkerReportsProgress = True
            ExportBackgroundWorker.RunWorkerAsync()
        End If

    End Sub

    Private Sub ExportBackgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles ExportBackgroundWorker.DoWork

        Dim reportProgressPercent As Integer = 1

        'Background worker
        ExportBackgroundWorker.ReportProgress(1)

        'get excel application
        Dim excel As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application()
        ExportBackgroundWorker.ReportProgress(2)

        'Add workbook to excel
        Dim workbook As Microsoft.Office.Interop.Excel.Workbook = excel.Workbooks.Add(Type.Missing)
        ExportBackgroundWorker.ReportProgress(3)

        'Store worksheet
        Dim worksheet As Microsoft.Office.Interop.Excel.Worksheet = Nothing
        ExportBackgroundWorker.ReportProgress(4)

        Try
            'Get active worksheet
            worksheet = CType(workbook.ActiveSheet, Microsoft.Office.Interop.Excel.Worksheet)
            ExportBackgroundWorker.ReportProgress(5)

            reportProgressPercent = 5

            'Excel index starts from 1,1. As first Row would have the Column headers
            For iColumn As Integer = 1 To ThongTinKhachHangGridView.Columns.Count
                worksheet.Cells(1, iColumn) = ThongTinKhachHangGridView.Columns(iColumn - 1).FieldName

                'report progress
                reportProgressPercent = reportProgressPercent + 1
                ExportBackgroundWorker.ReportProgress(reportProgressPercent)
            Next

            'Set the value for remaining row of worksheet by the value being presented in GridView 
            For iRow As Integer = 0 To ThongTinKhachHangGridView.RowCount - 1
                'get current row
                Dim selectedRow As DataRow = ThongTinKhachHangGridView.GetDataRow(ThongTinKhachHangGridView.GetRowHandle(iRow))

                'loop through all columns
                For iColumn As Integer = 1 To ThongTinKhachHangGridView.Columns.Count

                    'As the saying above, Excel index starts from 1,1
                    'So the next row has the index of (2, iColumn)
                    worksheet.Cells(iRow + 2, iColumn) = selectedRow(iColumn - 1).ToString()

                    'report progress
                    If (reportProgressPercent < 98) Then
                        reportProgressPercent = reportProgressPercent + 1
                        ExportBackgroundWorker.ReportProgress(reportProgressPercent)
                    End If
                Next
            Next

            'Don't allow displaying alerts
            'this is just a setup to prevent some kind of disturb things
            excel.DisplayAlerts = False

            'Save Workbook
            workbook.SaveAs(SaveDialog.FileName)

            'report progress
            ExportBackgroundWorker.ReportProgress(99)

            excel.DisplayAlerts = True

            'report progress
            ExportBackgroundWorker.ReportProgress(100)

            'Display successful dialog
            DevExpress.XtraEditors.XtraMessageBox.Show("Xuất File Exel thành công", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'Clean up
            GC.Collect()
            GC.WaitForPendingFinalizers()

            'release worksheet
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet)

            'close and release workbook
            workbook.Close()
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook)

            'close and release excel
            excel.Quit()
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel)

            'set this for sure
            workbook = Nothing
            excel = Nothing
        End Try

    End Sub

    Private Sub ExportBackgroundWorker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles ExportBackgroundWorker.ProgressChanged
        progressBarControl.EditValue = e.ProgressPercentage
        progressBarControl.Text = progressBarControl.EditValue.ToString()
    End Sub

    Private Sub ExportBackgroundWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ExportBackgroundWorker.RunWorkerCompleted
        Me.Enabled = True
        progressBarControl.Visible = False
        UseWaitCursor = False
    End Sub

#End Region

#Region "Don't mind"
    'Private Sub ThongTinTimKiemTextBox_EditValueChanged(sender As Object, e As EventArgs) Handles ThongTinTimKiemTextBox.EditValueChanged
    '    'clear dataTable before add rows again
    '    dataTable.Clear()
    '    'If there is nothing in the thongtintimkiemtextbox, load all customer
    '    If (ThongTinTimKiemTextBox.Text = "") Then
    '        'take adventage of this function to show all customer
    '        FindCustomer(AddressOf KHACHHANGBUS.FindCustomersByID)
    '        Return
    '    End If

    '    Select Case TimTheoComboBox.SelectedIndex
    '        Case 0
    '            FindCustomer(AddressOf KHACHHANGBUS.FindCustomersByID)
    '        Case 1
    '            FindCustomer(AddressOf KHACHHANGBUS.FindCustomersByName)
    '        Case 2
    '            FindCustomer(AddressOf KHACHHANGBUS.FindCustomersByPhone)
    '        Case 3
    '            FindCustomer(AddressOf KHACHHANGBUS.FindCustomersByAddress)
    '        Case 4
    '            FindCustomer(AddressOf KHACHHANGBUS.FindCustomersByEmail)
    '        Case 5
    '            FindCustomerByDebt()
    '    End Select

    'End Sub

    '''' <summary>
    '''' a delegate to easily address to others function
    '''' </summary>
    '''' <param name="information"></param>
    '''' <param name="exception"></param>
    '''' <returns></returns>
    'Private Delegate Function FindCustomerDelegate(ByVal information As String, ByRef exception As String) As DataTable

    'Private Sub FindCustomer(ByVal functionDelegate As FindCustomerDelegate)
    '    'a variable to hold exception
    '    Dim ex As String = ""

    '    'get dataTable
    '    dataTable = functionDelegate(ThongTinTimKiemTextBox.Text, ex)

    '    'if there is exception
    '    If (ex <> "") Then
    '        DevExpress.XtraEditors.XtraMessageBox.Show(ex)
    '        Return
    '    End If

    '    'dataTable.PrimaryKey = New DataColumn() {dataTable.Columns("Mã Khách Hàng")}
    '    'dataTable.Rows.Find("MKH2").Delete()

    '    'Show datable for user to see
    '    ThongTinKhachHangGridControl.DataSource = dataTable

    'End Sub

    'Private Sub FindCustomerByDebt()
    '    'a variable to hold exception
    '    Dim ex As String = ""

    '    'set the type of compare that user want to use
    '    Dim compareType As String = ""

    '    Select Case KieuSoSanhComboBox.SelectedIndex
    '        Case 0
    '            compareType = "="
    '        Case 1
    '            compareType = ">"
    '        Case 2
    '            compareType = "<"
    '    End Select

    '    'get datatable
    '    dataTable = KHACHHANGBUS.FindCustomersbyDebt(Decimal.Parse(ThongTinTimKiemTextBox.Text), compareType, ex)

    '    'if there is exception
    '    If (ex <> "") Then
    '        DevExpress.XtraEditors.XtraMessageBox.Show(ex)
    '        Return
    '    End If

    '    'Show datable for user to see
    '    ThongTinKhachHangGridControl.DataSource = dataTable

    'End Sub

#End Region


End Class