Imports BUS
Imports DTO

Public Class SACHGUI

    'Since we don't want to create new instance of this class over and over again
    'So using a Shared variable (like a static in C#) makes sense
    Public Shared GUI As New SACHGUI

    'a string to store the thing user is about to do
    Dim task As String = ""

#Region "All events"

    Private Sub SACHGUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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


        'Set up some text boxes to prevent user type in
        TenSachTextBox.ReadOnly = True
        TheLoaiComboBox.ReadOnly = True
        TacGiaTextBox.ReadOnly = True
        SoLuongTonTextBox.ReadOnly = True
        DonGiaTextBox.ReadOnly = True

        'Allow null value
        SoLuongTonTraCuuTextBox.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
        DonGiaTraCuuTextBox.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True


        'AddHandler
        AddHandler MaSachTraCuuTextBox.EditValueChanged, AddressOf TraCuuTextBox_EditValueChanged
        AddHandler TenSachTraCuuTextBox.EditValueChanged, AddressOf TraCuuTextBox_EditValueChanged
        AddHandler TheLoaiTraCuuTextBox.EditValueChanged, AddressOf TraCuuTextBox_EditValueChanged
        AddHandler TacGiaTraCuuTextBox.EditValueChanged, AddressOf TraCuuTextBox_EditValueChanged
        AddHandler SoLuongTonTraCuuTextBox.EditValueChanged, AddressOf TraCuuTextBox_EditValueChanged
        AddHandler DonGiaTraCuuTextBox.EditValueChanged, AddressOf TraCuuTextBox_EditValueChanged

        'Do this to immediately display all the books in database
        FindBooks()

        'Set Filter being displayed 
        SaveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"

        Dim dataTable As DataTable = THELOAIBUS.FindAllTheLoais()

        For index As Integer = 0 To dataTable.Rows.Count - 1
            TheLoaiComboBox.Properties.Items.Add(dataTable.Rows.Item(index).Item("Tên Thể Loại").ToString)
        Next

    End Sub

    ''' <summary>
    ''' FindBooks on text changed
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TraCuuTextBox_EditValueChanged(sender As Object, e As EventArgs)
        FindBooks()
    End Sub

    Private Sub SoLuongTonKieuSoSanhComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SoLuongTonKieuSoSanhComboBox.SelectedIndexChanged
        FindBooks()
    End Sub

    Private Sub DonGiaKieuSoSanhComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DonGiaKieuSoSanhComboBox.SelectedIndexChanged
        FindBooks()
    End Sub

    Private Sub MaSachTextBox_EditValueChanged(sender As Object, e As EventArgs) Handles MaSachTextBox.EditValueChanged
        'store exception
        Dim ex As String = ""

        'find book to display
        Dim book As SACHDTO = SACHBUS.FindBookByID(MaSachTextBox.Text, True, ex)

        'if there is exception, show it
        If (ex <> "") Then
            DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        'book is nothing
        If (book Is Nothing) Then
            TenSachTextBox.Text = ""
            TheLoaiComboBox.Text = ""
            TacGiaTextBox.Text = ""
            DonGiaTextBox.Text = ""
            SoLuongTonTextBox.Text = ""
            Return
        End If

        'show the book
        TenSachTextBox.Text = book.TenSach
        TheLoaiComboBox.Text = book.TheLoai
        TacGiaTextBox.Text = book.TacGia
        DonGiaTextBox.Text = book.DonGia.ToString("c0")
        SoLuongTonTextBox.Text = book.SoLuongTon.ToString("n0")

    End Sub

    ''' <summary>
    ''' Display the book when click a row
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ThongTinSachGridView_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles ThongTinSachGridView.RowClick
        'We check this because we don't want to change the text in text boxes when user is doing adding 
        If (task <> "Add") Then
            'get selected row
            Dim selectedRow As DataRow = ThongTinSachGridView.GetDataRow(e.RowHandle)

            'set the text of MaKhachHangTextBox
            MaSachTextBox.Text = selectedRow.Item("Mã Sách").ToString
        End If

    End Sub

    ''' <summary>
    ''' Apply the mask to the text
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DonGiaTextBox_Leave(sender As Object, e As EventArgs) Handles DonGiaTextBox.Leave
        DonGiaTextBox.Text = DonGiaTextBox.Text
    End Sub

    ''' <summary>
    ''' Apply the mask to the text
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DonGiaTraCuuTextBox_Leave(sender As Object, e As EventArgs) Handles DonGiaTraCuuTextBox.Leave
        DonGiaTraCuuTextBox.Text = DonGiaTraCuuTextBox.Text
    End Sub

    ''' <summary>
    ''' Apply the mask to the text
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SoLuongTonTraCuuTextBox_Leave(sender As Object, e As EventArgs) Handles SoLuongTonTraCuuTextBox.Leave
        SoLuongTonTraCuuTextBox.Text = SoLuongTonTraCuuTextBox.Text
    End Sub

#End Region

#Region "Functions"

    ''' <summary>
    ''' Do Adding
    ''' </summary>
    Private Sub DoAdding()

        'if there is nothing in text boxes
        If (TenSachTextBox.Text = "" Or TacGiaTextBox.Text = "" Or DonGiaTextBox.Text = "" Or TheLoaiComboBox.Text = "") Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Xin hãy điền đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        'show safe dialog
        Dim result As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Bạn có chắc chắn muốn thêm sách này? ", "Cẩn thận!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        'if user press Yes button
        If (result = DialogResult.Yes) Then
            'hold exception
            Dim ex As String = ""

            'get new book
            Dim book As New SACHDTO(MaSachTextBox.Text, TenSachTextBox.Text, TheLoaiComboBox.Text, TacGiaTextBox.Text, 0, Decimal.Parse(DonGiaTextBox.Text, Globalization.NumberStyles.Currency))

            'insert into database
            If (SACHBUS.InsertBook(book, ex) = True) Then

                ''we have to create a new BaoCaoTon for this book
                'If (BAOCAOTONBUS.InsertBaoCaoTon(MaSachTextBox.Text, DateTime.Now.Month, DateTime.Now.Year, ex) = False) Then
                '    'Show exception
                '    DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    'Insert information into LichSuThaoTacFlowPanel
                '    InsertInformationIntoFlowPanel("LỖI", "", DateTime.Now.ToString() & "  " & ex, Color.Red)
                'End If

                'Show message
                DevExpress.XtraEditors.XtraMessageBox.Show("Thêm thành công", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information)


                'a string to hold KhachHang's information to append into LichSuThaoTacTextBox 
                Dim bookInformation As String = String.Format(DateTime.Now.ToString() & "  " & "Mã Sách: {0}   Tên Sách: {1}   Thể Loại: {2}   Tác Giả: {3}   Số Lượng Tồn: {4}   Đơn Giá: {5}",
                                                                        MaSachTextBox.Text, TenSachTextBox.Text, TheLoaiComboBox.Text, TacGiaTextBox.Text, 0,
                                                                        DonGiaTextBox.Text)

                'Insert book information into LichSuThaoTacFlowPanel
                InsertInformationIntoFlowPanel("THÊM THÀNH CÔNG", MaSachTextBox.Text, bookInformation, Color.Green)

                'Update MaSach in MaSachTextBox
                MaSachTextBox.Text = SACHBUS.GetNewBookID()
                SoLuongTonTextBox.Text = "0"

                LAPPHIEUNHAPSACHGUI.GUI.RefreshGUI()
                LAPHOADONBANSACHGUI.GUI.RefreshGUI()

                Return
            End If

            'Show exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Insert information into LichSuThaoTacFlowPanel
            InsertInformationIntoFlowPanel("THÊM THẤT BẠI", "", DateTime.Now.ToString() & "  " & ex, Color.Red)

            Return
        End If


    End Sub

    ''' <summary>
    ''' Do Deleting
    ''' </summary>
    Private Sub DoDeleting()

        'a variable to store exception
        Dim ex As String = ""

        'if user hasn't typed in the right ID
        If (SACHBUS.FindBookByID(MaSachTextBox.Text, True, ex) Is Nothing) Then
            If (ex <> "") Then
                'Show exception
                DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                DevExpress.XtraEditors.XtraMessageBox.Show("Không tồn tại sách này trong cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            Return
        End If

        'show safe dialog
        Dim result As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Bạn có chắc chắn muốn xóa không? ", "Cẩn thận!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        'if user press Yes button
        If (result = DialogResult.Yes) Then

            'if nothing bad happened
            If (SACHBUS.RemoveBook(MaSachTextBox.Text, ex) = True) Then
                'Show message
                DevExpress.XtraEditors.XtraMessageBox.Show("Xóa thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'a string to hold KhachHang's information to append into LichSuThaoTacTextBox 
                Dim bookInformation As String = String.Format(DateTime.Now.ToString() & "  " & "Mã Sách: {0}   Tên Sách: {1}   Thể Loại: {2}   Tác Giả: {3}   Số Lượng Tồn: {4}   Đơn Giá: {5}",
                                                                        MaSachTextBox.Text, TenSachTextBox.Text, TheLoaiComboBox.Text, TacGiaTextBox.Text,
                                                                        SoLuongTonTextBox.Text, DonGiaTextBox.Text)

                'Insert book information into LichSuThaoTacFlowPanel
                InsertInformationIntoFlowPanel("XÓA THÀNH CÔNG", "", bookInformation, Color.Green)


                'Simply set this to delete all the text in the others text boxes 
                MaSachTextBox.Text = ""

                'Update removedSach gridview
                REMOVEDSACHGUI.GUI.RefreshGUI()
                LAPPHIEUNHAPSACHGUI.GUI.RefreshGUI()
                LAPHOADONBANSACHGUI.GUI.RefreshGUI()

                Return

            End If

            'Show exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Insert information into LichSuThaoTacFlowPanel
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
        If (SACHBUS.FindBookByID(MaSachTextBox.Text, True, ex) Is Nothing) Then
            If (ex <> "") Then
                'Show exception
                DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                DevExpress.XtraEditors.XtraMessageBox.Show("Không tồn tại sách này trong cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            Return
        End If

        'if there is nothing in text boxes
        If (TenSachTextBox.Text = "" Or TheLoaiComboBox.Text = "" Or TacGiaTextBox.Text = "" Or DonGiaTextBox.Text = "") Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Xin hãy điền đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        'show safe dialog
        Dim result As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Bạn có chắc chắn muốn cập nhật không? ", "Cẩn thận!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        'if user press Yes button
        If (result = DialogResult.Yes) Then

            'if nothing bad happened
            Dim book As New SACHDTO(MaSachTextBox.Text, TenSachTextBox.Text, TheLoaiComboBox.Text, TacGiaTextBox.Text, Integer.Parse(SoLuongTonTextBox.Text), Decimal.Parse(DonGiaTextBox.Text, Globalization.NumberStyles.Currency))

            If (SACHBUS.UpdateBook(book, ex) = True) Then
                'Show message
                DevExpress.XtraEditors.XtraMessageBox.Show("Cập nhật thành công", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'a string to hold KhachHang's information to append into LichSuThaoTacTextBox 
                Dim bookInformation As String = String.Format(DateTime.Now.ToString() & "  " & "Mã Sách: {0}   Tên Sách: {1}   Thể Loại: {2}   Tác Giả: {3}   Số Lượng Tồn: {4}   Đơn Giá: {5}",
                                                               MaSachTextBox.Text, TenSachTextBox.Text, TheLoaiComboBox.Text, TacGiaTextBox.Text,
                                                               SoLuongTonTextBox.Text, DonGiaTextBox.Text)

                'Insert book information into LichSuThaoTacFlowPanel
                InsertInformationIntoFlowPanel("CẬP NHẬT THÀNH CÔNG", MaSachTextBox.Text, bookInformation, Color.Green)

                LAPPHIEUNHAPSACHGUI.GUI.RefreshGUI()
                LAPHOADONBANSACHGUI.GUI.RefreshGUI()

                Return
            End If

            'Show exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Insert information into LichSuThaoTacFlowPanel
            InsertInformationIntoFlowPanel("CẬP NHẬT THẤT BẠI", "", DateTime.Now.ToString() & "  " & ex, Color.Red)


        End If

    End Sub

    Private Sub FindBooks()
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
                                                                 donGiaToCompare, donGiaCompareType, soLuongTonToCompare, soLuongTonCompareType, True, ex)

        TongSoKetQuaLabelControl.Text = ThongTinSachGridView.RowCount.ToString + " kết quả trả về"

        If (ex <> "") Then
            DevExpress.XtraEditors.XtraMessageBox.Show(ex)
        End If
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

        'scroll panel 
        LichSuThaoTacFlowLayoutPanel.ScrollControlIntoView(informationLabel)

        'dispose for sure
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
            MaSachTextBox.Text = button.Tag.ToString()
        End If

    End Sub

    Public Sub RefreshGUI()
        Try
            FindBooks()
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
        TenSachTextBox.ReadOnly = False
        TheLoaiComboBox.ReadOnly = False
        TacGiaTextBox.ReadOnly = False
        DonGiaTextBox.ReadOnly = False

        'set up ThucHienButton
        ThucHienButton.Text = "Đồng Ý Thêm"
        ThucHienButton.Visible = True

        'set the task string
        task = "Add"

        'set up MaKhachHangTextBox
        Dim ex As String = ""
        MaSachTextBox.Text = SACHBUS.GetNewBookID(ex)
        If (ex <> "") Then
            'Show exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        MaSachTextBox.ReadOnly = True

        'set up SoLuongTonTextBox
        SoLuongTonTextBox.Text = "0"
        SoLuongTonTextBox.ReadOnly = True
    End Sub

    Private Sub CapNhatButton_Click(sender As Object, e As EventArgs) Handles CapNhatButton.Click
        'Set background
        ThemButton.Appearance.BackColor = Color.LightGray
        ThemButton.Appearance.ForeColor = Color.Black

        XoaButton.Appearance.BackColor = Color.LightGray
        XoaButton.Appearance.ForeColor = Color.Black

        CapNhatButton.Appearance.BackColor = Color.DimGray
        CapNhatButton.Appearance.ForeColor = Color.White

        MaSachTextBox.ReadOnly = False
        TenSachTextBox.ReadOnly = False
        TacGiaTextBox.ReadOnly = False
        TheLoaiComboBox.ReadOnly = False
        DonGiaTextBox.ReadOnly = False
        SoLuongTonTextBox.ReadOnly = True
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

        MaSachTextBox.ReadOnly = False
        TenSachTextBox.ReadOnly = True
        TacGiaTextBox.ReadOnly = True
        TheLoaiComboBox.ReadOnly = True
        DonGiaTextBox.ReadOnly = True
        SoLuongTonTextBox.ReadOnly = True
        ThucHienButton.Visible = True
        ThucHienButton.Text = "Đồng Ý Xóa"
        task = "Remove"

    End Sub

    Private Sub ThucHienButton_Click(sender As Object, e As EventArgs) Handles ThucHienButton.Click
        Select Case (task)
            Case "Add"
                DoAdding()
                'we do this to immediately show the thing changed
                FindBooks()
            Case "Remove"
                DoDeleting()
                'we do this to immediately show the thing changed
                FindBooks()
            Case "Update"
                DoUpdating()
                'we do this to immediately show the thing changed
                FindBooks()
        End Select

    End Sub

    Private Sub TimTatCaButton_Click(sender As Object, e As EventArgs) Handles TimTatCaButton.Click
        MaSachTraCuuTextBox.Text = ""
        TenSachTraCuuTextBox.Text = ""
        TheLoaiTraCuuTextBox.Text = ""
        TacGiaTraCuuTextBox.Text = ""
        SoLuongTonTraCuuTextBox.Text = ""
        DonGiaTraCuuTextBox.Text = ""
        FindBooks()
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
            For iColumn As Integer = 1 To ThongTinSachGridView.Columns.Count
                worksheet.Cells(1, iColumn) = ThongTinSachGridView.Columns(iColumn - 1).FieldName

                'report progress
                reportProgressPercent = reportProgressPercent + 1
                ExportBackgroundWorker.ReportProgress(reportProgressPercent)
            Next

            'Set the value for remaining row of worksheet by the value being presented in GridView 
            For iRow As Integer = 0 To ThongTinSachGridView.RowCount - 1
                'get current row
                Dim selectedRow As DataRow = ThongTinSachGridView.GetDataRow(ThongTinSachGridView.GetRowHandle(iRow))

                'loop through all columns
                For iColumn As Integer = 1 To ThongTinSachGridView.Columns.Count

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

    Private Sub ThemTheLoaiButton_Click(sender As Object, e As EventArgs) Handles ThemTheLoaiButton.Click
        Dim theLoaiGUI As THELOAIGUI = New THELOAIGUI
        theLoaiGUI.StartPosition = FormStartPosition.CenterScreen
        theLoaiGUI.ShowDialog()

        'Set TheLoaiConmbobox
        TheLoaiComboBox.Properties.Items.Clear()

        Dim dataTable As DataTable = THELOAIBUS.FindAllTheLoais()
        For index As Integer = 0 To dataTable.Rows.Count - 1
            TheLoaiComboBox.Properties.Items.Add(dataTable.Rows.Item(index).Item("Tên Thể Loại").ToString)
        Next

    End Sub

#End Region


#Region "Don't mind"

    '''' <summary>
    '''' a delegate to easily address to other similar function
    '''' </summary>
    '''' <param name="information"></param>
    '''' <param name="exception"></param>
    '''' <returns></returns>
    'Private Delegate Function FindBooksDelegate(ByVal information As String, ByRef exception As String) As DataTable

    '''' <summary>
    '''' Find Book 
    '''' </summary>
    '''' <param name="funtionDelegate"></param>
    'Private Sub FindBooks(ByVal funtionDelegate As FindBooksDelegate)
    '    'a variable to store exception
    '    Dim ex As String = ""

    '    'get datatable
    '    dataTable = funtionDelegate(ThongTinTimKiemTextBox.Text, ex)

    '    'if there is exception, show it and then return
    '    If (ex <> "") Then
    '        DevExpress.XtraEditors.XtraMessageBox.Show(ex)
    '        Return
    '    End If

    '    'fill dataTable into DaTaGridView
    '    ThongTinSachGridControl.DataSource = dataTable
    'End Sub

    '''' <summary>
    '''' Find books by price
    '''' </summary>
    'Private Sub FindBooksByPrice()
    '    'a variable to store exception
    '    Dim ex As String = ""

    '    'compare type
    '    Dim compareType As String = "="

    '    'get compare type
    '    If (SoLuongTonKieuSoSanhComboBox.SelectedIndex = 1) Then
    '        compareType = ">"
    '    Else
    '        If (SoLuongTonKieuSoSanhComboBox.SelectedIndex = 2) Then
    '            compareType = "<"
    '        End If
    '    End If

    '    'get dataTable
    '    dataTable = SACHBUS.FindBooksbyPrice(Decimal.Parse(ThongTinTimKiemTextBox.Text), compareType, ex)

    '    'if there is exception, show it
    '    If (ex <> "") Then
    '        DevExpress.XtraEditors.XtraMessageBox.Show(ex)
    '        Return
    '    End If

    '    'fill datatable into datagridview
    '    ThongTinSachGridControl.DataSource = dataTable
    'End Sub

    '''' <summary>
    '''' Find books by inventory
    '''' </summary>
    'Private Sub FindBooksByInventory()

    '    'bla bla the same as find books by price function
    '    Dim ex As String = ""
    '    Dim compareType As String = "="

    '    Select Case SoLuongTonKieuSoSanhComboBox.SelectedIndex
    '        Case 0
    '            compareType = "="
    '        Case 1
    '            compareType = ">"
    '        Case 2
    '            compareType = "<"
    '    End Select


    '    dataTable = SACHBUS.FindBooksbyInventory(Integer.Parse(ThongTinTimKiemTextBox.Text), compareType, ex)

    '    If (ex <> "") Then
    '        DevExpress.XtraEditors.XtraMessageBox.Show(ex)
    '        Return
    '    End If

    '    ThongTinSachGridControl.DataSource = dataTable
    'End Sub

    'Private Sub ThongTinTimKiemTextBox_EditValueChanged(sender As Object, e As EventArgs) Handles ThongTinTimKiemTextBox.EditValueChanged
    '    'clear datatable first just for sure
    '    dataTable.Clear()

    '    'If there is nothing in the textbox, load all the books
    '    If (ThongTinTimKiemTextBox.Text = "") Then
    '        'take adventage of this function to show all books
    '        'because there is nothing in textbox, this function will just show all the books
    '        FindBooks(AddressOf SACHBUS.FindBooksByID)
    '        Return
    '    End If

    '    Select Case TimTheoComboBox.SelectedIndex
    '        Case 0 'Find book by MaSach
    '            FindBooks(AddressOf SACHBUS.FindBooksByID)
    '        Case 1 'Find books by TenSach
    '            FindBooks(AddressOf SACHBUS.FindBooksByName)
    '        Case 2 'Find books by TenTacGia
    '            FindBooks(AddressOf SACHBUS.FindBooksByAuthorName)
    '        Case 3 'Find books by TheLoai
    '            FindBooks(AddressOf SACHBUS.FindBooksbyType)
    '        Case 4 'Find books by DonGia
    '            FindBooksByPrice()
    '        Case 5 'Find books by SoLuongTon
    '            FindBooksByInventory()
    '    End Select
    'End Sub

#End Region


End Class