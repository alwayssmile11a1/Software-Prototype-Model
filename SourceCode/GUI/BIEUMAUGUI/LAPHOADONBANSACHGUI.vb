Imports BUS
Imports DTO
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class LAPHOADONBANSACHGUI

    'We just want to have only one instance of this class
    'That's why we use a shared variable
    Public Shared GUI As New LAPHOADONBANSACHGUI

    Dim listBookIDs As List(Of String)
    Dim listCustomerIDs As List(Of String)

    Dim mainDataTable As DataTable = Nothing

#Region "All events"

    Private Sub LAPHOADONBANSACHGUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'set datetime
        NgayLapHoaDonDateTimePicker.Value = DateTime.Now

        'Get and set ThamSo
        THAMSOBUS.GetThamSo()
        SoTienNoToiDaTextBox.Text = THAMSODTO.SoTienNoToiDa.ToString("c0")
        SoLuongTonToiThieuTextBox.Text = THAMSODTO.SoLuongTonToiThieuSauBan.ToString("n0")

        'Set readonly
        HoTenTextBox.ReadOnly = True
        DiaChiTextBox.ReadOnly = True
        SoTienNoTextBox.ReadOnly = True
        SoLuongTonToiThieuTextBox.ReadOnly = True
        SoTienNoToiDaTextBox.ReadOnly = True
        TongThanhTienTextBox.ReadOnly = True

        progressBarControl.Visible = False

        'Setup DataGridView
        SetupDataGridView()

        'Set Filter being displayed 
        SaveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"

        'Set Filter being displayed 
        OpenDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"

        'Clear for sure
        If (listCustomerIDs IsNot Nothing) Then
            listCustomerIDs.Clear()
        End If
        AllCustomerIDsListBox.Items.Clear()

        'Get all book IDs
        listCustomerIDs = KHACHHANGBUS.GetAllCustomerIDs()

        'If it's not nothing
        If (listCustomerIDs IsNot Nothing) Then
            AllCustomerIDsListBox.Items.AddRange(listCustomerIDs.ToArray)
            AllCustomerIDsListBox.Visible = False
            AllCustomerIDsListBox.SelectedIndex = 0
            'Set location and width
            AllCustomerIDsListBox.Location = New Point(MaKhachHangTextBox.Location.X + MaKhachHangTextBox.Width, MaKhachHangTextBox.Location.Y)
        End If


    End Sub

    Private Sub MaKhachHangTextBox_EditValueChanged(sender As Object, e As EventArgs) Handles MaKhachHangTextBox.EditValueChanged


        If (MaKhachHangTextBox.Text <> "") Then
            'String to focus in AllCustomerIDsListBox
            Dim stringToFocus As String = listCustomerIDs.Find(Function(s) s.Contains(MaKhachHangTextBox.Text.ToUpper()))

            'If listCustomerIDs has a string that contains current text
            If (stringToFocus <> "") Then
                'Show list box 
                If (AllCustomerIDsListBox.Visible = False) Then
                    AllCustomerIDsListBox.Visible = True
                End If
                'Set the index of list box
                AllCustomerIDsListBox.SelectedIndex = AllCustomerIDsListBox.FindString(stringToFocus)
            End If
        End If



        'a string variable to hold exception
        Dim ex As String = ""

        'store khachHang found out
        Dim khachHang As KHACHHANGDTO = Nothing
        'Find customer by ID (ID is typed in MaKhachHangTextBox)
        khachHang = KHACHHANGBUS.FindCustomerByID(MaKhachHangTextBox.Text, True, ex)

        'if ex <>"" means exception occured
        If (ex <> "") Then
            'Show exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If (khachHang Is Nothing) Then
            HoTenTextBox.Text = ""
            DiaChiTextBox.Text = ""
            SoTienNoTextBox.Text = ""
            ThongBaoLabel.Visible = False
            Return
        End If

        HoTenTextBox.Text = khachHang.HoTenKhachHang
        DiaChiTextBox.Text = khachHang.DiaChi
        SoTienNoTextBox.Text = khachHang.SoTienNo.ToString("c0")

        If (khachHang.SoTienNo > THAMSODTO.SoTienNoToiDa) Then
            ThongBaoLabel.Text = String.Format("Số tiền nợ > Số tiền nợ tối đa" & vbNewLine & "Khách hàng này có lẽ không thể mua sách tại thời điểm này " & vbNewLine &
                                               "Dựa trên quy định: Chỉ bán cho các khách hàng nợ không quá {0}",
                                               THAMSODTO.SoTienNoToiDa.ToString("c0"))
            ThongBaoLabel.Visible = True
        Else
            ThongBaoLabel.Visible = False
        End If
    End Sub

    Private Sub LapHoaDonBanSachGridView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles LapHoaDonBanSachGridView.CellValueChanging

        'If user type in column MaSach
        If (e.Column.FieldName = "MaSach") Then

            If (e.Value.ToString() <> "") Then
                'string to focus in allBookIDsListBox
                Dim stringToFocus As String = listBookIDs.Find(Function(s) s.Contains(e.Value.ToString().ToUpper()))

                'If listBookIDs has a string that contains e.Value (MaSach)  
                If (stringToFocus <> "") Then
                    'Show list box 
                    If (AllBookIDsListBox.Visible = False) Then
                        AllBookIDsListBox.Tag = e.RowHandle
                        'Calculate the postion of listbox to show 
                        Dim viewInfo As GridViewInfo = CType(LapHoaDonBanSachGridView.GetViewInfo(), GridViewInfo)
                        Dim gridCellInfo As GridCellInfo = viewInfo.GetGridCellInfo(e.RowHandle, e.Column)
                        Dim location As Point = New Point(gridCellInfo.Bounds.Location.X, gridCellInfo.Bounds.Location.Y + gridCellInfo.Bounds.Height)
                        'Set location and width
                        AllBookIDsListBox.Location = location
                        AllBookIDsListBox.Width = gridCellInfo.Bounds.Width
                        AllBookIDsListBox.Visible = True
                    End If

                    'Set the index of list box
                    AllBookIDsListBox.SelectedIndex = AllBookIDsListBox.FindString(stringToFocus)
                End If
            End If

            'Set values
            SetFocusedRowValue(e.Value.ToString())

            Else
                If (e.Column.FieldName = "SoLuongBan") Then
                'Get row is being focused
                Dim selectedRow As DataRow = LapHoaDonBanSachGridView.GetFocusedDataRow

                'If there is something in column SoLuongBan and DonGia
                If (e.Value.ToString <> "" And selectedRow("SoLuongTon").ToString <> "" And selectedRow("DonGia").ToString <> "") Then
                    'Calculate SoLuongTonSauBan
                    selectedRow("SoLuongTonSauBan") = (Integer.Parse(selectedRow("SoLuongTon").ToString) - Integer.Parse(e.Value.ToString)).ToString("n0")

                    'Calculate ThanhTien
                    selectedRow("ThanhTien") = (Decimal.Parse(selectedRow("DonGia").ToString, Globalization.NumberStyles.Currency) * Decimal.Parse(e.Value.ToString)).ToString("c0")
                Else
                    selectedRow("SoLuongTonSauBan") = ""
                    selectedRow("ThanhTien") = ""
                End If

                'Refresh Cells to immediately display
                LapHoaDonBanSachGridView.RefreshRowCell(e.RowHandle, LapHoaDonBanSachGridView.Columns("SoLuongTonSauBan"))
                LapHoaDonBanSachGridView.RefreshRowCell(e.RowHandle, LapHoaDonBanSachGridView.Columns("ThanhTien"))

            End If
        End If

        'Calculate TongThanhTien
        Dim tongThanhTien As Decimal = 0
        'Loop
        For index As Integer = 0 To LapHoaDonBanSachGridView.RowCount - 1
            Dim row As DataRow = LapHoaDonBanSachGridView.GetDataRow(LapHoaDonBanSachGridView.GetRowHandle(index))
            If (row("ThanhTien").ToString <> "") Then
                tongThanhTien = tongThanhTien + Decimal.Parse(row("ThanhTien").ToString, Globalization.NumberStyles.Currency)
            End If
        Next

        'Display
        TongThanhTienTextBox.Text = tongThanhTien.ToString("c0")

    End Sub

    ''' <summary>
    ''' add new row if user press enter
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub LapHoaDonBanSachGridView_KeyUp(sender As Object, e As KeyEventArgs) Handles LapHoaDonBanSachGridView.KeyUp
        Try
            'If user press enter
            If (e.KeyCode = Keys.Enter) Then

                'just add new row if there isn't any row in GridView
                If (LapHoaDonBanSachGridView.RowCount = 0) Then
                    LapHoaDonBanSachGridView.AddNewRow()
                    LapHoaDonBanSachGridView.FocusedColumn = LapHoaDonBanSachGridView.Columns("MaSach")
                    Return
                End If

                'Get focused row
                Dim selectedRow As DataRow = LapHoaDonBanSachGridView.GetFocusedDataRow

                'If Row("SoLuongBan") has already had something 
                'And user typed in row("MaSach") the right ID (ID has already existed in Database)
                'Note that we just have to check row DonGia to know whether it's the right ID or not
                If (selectedRow("SoLuongBan").ToString <> "" And selectedRow("DonGia").ToString <> "") Then

                    'get the last row
                    Dim lastRow As DataRow = LapHoaDonBanSachGridView.GetDataRow(LapHoaDonBanSachGridView.GetRowHandle(LapHoaDonBanSachGridView.RowCount - 1))

                    'If user typed in lastRow the right ID (ID has already existed in Database)
                    'Note that we just have to check row DonGia to know whether it's the right ID or not
                    'Why I have to do like this ? Actually this isn't strictly necessary but I just like this
                    'because i just want to add a new row when user has already typed in right things at the last row
                    If (lastRow("SoLuongBan").ToString <> "" And lastRow("DonGia").ToString <> "") Then
                        'Add new Row
                        LapHoaDonBanSachGridView.AddNewRow()

                        'focus to Column MaSach for more convenient
                        LapHoaDonBanSachGridView.FocusedColumn = LapHoaDonBanSachGridView.Columns("MaSach")
                    Else  'And if user hasn't typed in right things at the last row, let's focus the last row
                        'Calculate the position to show ToolTip
                        Dim viewInfo As GridViewInfo = CType(LapHoaDonBanSachGridView.GetViewInfo(), GridViewInfo)
                        Dim position As Point = LapHoaDonBanSachGridControl.PointToScreen(viewInfo.GetGridRowInfo(LapHoaDonBanSachGridView.GetRowHandle(LapHoaDonBanSachGridView.RowCount - 1)).Bounds.Location)

                        'Show ToolTip
                        ToolTipController.ShowHint("Bạn có lẽ phải điền đẩy đủ thông tin của dòng này trước khi thêm dòng mới" & vbNewLine &
                                                   "Note: Bạn cũng có thể sử dụng nút 'Append' để thêm dòng mới", position)

                        'Focus this row
                        LapHoaDonBanSachGridView.FocusedRowHandle = LapHoaDonBanSachGridView.GetRowHandle(LapHoaDonBanSachGridView.RowCount - 1)
                        LapHoaDonBanSachGridView.FocusedColumn = LapHoaDonBanSachGridView.Columns("MaSach")
                    End If
                End If
            End If
        Catch ex As Exception
            'Do nothing
        End Try
    End Sub

    ''' <summary>
    ''' Event is fired when row is added
    ''' Set the value of column STT
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub LapHoaDonBanSachGridView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles LapHoaDonBanSachGridView.InitNewRow
        'Set the value of column STT
        LapHoaDonBanSachGridView.GetDataRow(e.RowHandle)("STT") = LapHoaDonBanSachGridView.RowCount

        'Refesh cell to immediately display
        LapHoaDonBanSachGridView.RefreshRowCell(e.RowHandle, LapHoaDonBanSachGridView.Columns("STT"))
    End Sub

    ''' <summary>
    ''' Reset column STT when a row is deleted
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub LapHoaDonBanSachGridView_RowDeleted(sender As Object, e As DevExpress.Data.RowDeletedEventArgs) Handles LapHoaDonBanSachGridView.RowDeleted
        For index As Integer = 0 To LapHoaDonBanSachGridView.RowCount - 1
            LapHoaDonBanSachGridView.GetDataRow(LapHoaDonBanSachGridView.GetRowHandle(index))("STT") = index + 1
        Next
    End Sub

    ''' <summary>
    ''' set mask type of the cell when SoLuongBan column is focused 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub LapHoaDonBanSachGridView_ShownEditor(sender As Object, e As EventArgs) Handles LapHoaDonBanSachGridView.ShownEditor
        'if user is focusing column SoLuongNhap
        If (LapHoaDonBanSachGridView.FocusedColumn.FieldName = "SoLuongBan") Then
            'convert ActiveEditor to TextEditor
            Dim edit As DevExpress.XtraEditors.TextEdit = CType(LapHoaDonBanSachGridView.ActiveEditor, DevExpress.XtraEditors.TextEdit)

            'set mask type 
            edit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric

            edit.Properties.Mask.EditMask = "n0"

            edit.Properties.MaxLength = 9
        End If
    End Sub

    ''' <summary>
    ''' ListBox mouse clicked
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AllBookIDsListBox_MouseClick(sender As Object, e As MouseEventArgs) Handles AllBookIDsListBox.MouseClick
        InsertValueFromListBoxIntoCell()
    End Sub

    ''' <summary>
    ''' Hide the listbox if user clicks somewhere within this form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub LAPHOADONBANSACHGUI_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick
        AllBookIDsListBox.Visible = False
        AllCustomerIDsListBox.Visible = False
    End Sub

    ''' <summary>
    ''' ListBox mouse clicked
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AllCustomerIDsListBox_MouseClick(sender As Object, e As MouseEventArgs) Handles AllCustomerIDsListBox.MouseClick
        MaKhachHangTextBox.Text = AllCustomerIDsListBox.SelectedItem.ToString()
        AllCustomerIDsListBox.Visible = False
    End Sub

    ''' <summary>
    '''  Hide the listbox if user clicks somewhere within this form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MaKhachHangTextBox_Leave(sender As Object, e As EventArgs) Handles MaKhachHangTextBox.Leave
        AllCustomerIDsListBox.Visible = False
    End Sub

    ''' <summary>
    '''  Hide the listbox if user clicks somewhere within this form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub LapHoaDonBanSachGridView_LostFocus(sender As Object, e As EventArgs) Handles LapHoaDonBanSachGridView.LostFocus
        AllBookIDsListBox.Visible = False
    End Sub

#End Region

#Region "Functions"

    ''' <summary>
    ''' Setup datagridview
    ''' </summary>
    Private Sub SetupDataGridView()
        'create new datatable to fill in GridView
        mainDataTable = New DataTable

        'Setup column STT
        mainDataTable.Columns.Add("STT").Caption = "STT"

        'Setup column MaSach
        mainDataTable.Columns.Add("MaSach").Caption = "Mã Sách"

        'Setup column SoLuongBan
        mainDataTable.Columns.Add("SoLuongBan").Caption = "Số Lượng Bán"

        'Setup column SoLuongBan
        mainDataTable.Columns.Add("SoLuongTon").Caption = "Số Lượng Tồn"

        'Setup column DonGia
        mainDataTable.Columns.Add("DonGia").Caption = "Đơn giá"

        'Setup column TenSach
        mainDataTable.Columns.Add("TenSach").Caption = "Tên Sách"

        'Setup column TheLoai
        mainDataTable.Columns.Add("TheLoai").Caption = "Thể Loại"

        'Setup column TheLoai
        mainDataTable.Columns.Add("TacGia").Caption = "Tác Giả"

        'Setup column SoLuongTonSauBan
        mainDataTable.Columns.Add("SoLuongTonSauBan").Caption = "Số Lượng Tồn Sau Bán"

        'Setup column ThanhTien
        mainDataTable.Columns.Add("ThanhTien").Caption = "Thành Tiền"

        'Display
        LapHoaDonBanSachGridControl.DataSource = mainDataTable

        'add new row initially
        LapHoaDonBanSachGridView.AddNewRow()

        'set allowedit by false for columns: TenSach, TheLoai, TacGia, SoLuongTonSauBan,.. to prevent user type in
        LapHoaDonBanSachGridView.Columns("STT").OptionsColumn.AllowEdit = False
        LapHoaDonBanSachGridView.Columns("TenSach").OptionsColumn.AllowEdit = False
        LapHoaDonBanSachGridView.Columns("TheLoai").OptionsColumn.AllowEdit = False
        LapHoaDonBanSachGridView.Columns("TacGia").OptionsColumn.AllowEdit = False
        LapHoaDonBanSachGridView.Columns("SoLuongTon").OptionsColumn.AllowEdit = False
        LapHoaDonBanSachGridView.Columns("SoLuongTonSauBan").OptionsColumn.AllowEdit = False
        LapHoaDonBanSachGridView.Columns("DonGia").OptionsColumn.AllowEdit = False
        LapHoaDonBanSachGridView.Columns("ThanhTien").OptionsColumn.AllowEdit = False

        'don't allow filtering
        LapHoaDonBanSachGridView.Columns("STT").OptionsFilter.AllowFilter = False
        LapHoaDonBanSachGridView.Columns("MaSach").OptionsFilter.AllowFilter = False
        LapHoaDonBanSachGridView.Columns("TenSach").OptionsFilter.AllowFilter = False
        LapHoaDonBanSachGridView.Columns("TheLoai").OptionsFilter.AllowFilter = False
        LapHoaDonBanSachGridView.Columns("TacGia").OptionsFilter.AllowFilter = False
        LapHoaDonBanSachGridView.Columns("SoLuongBan").OptionsFilter.AllowFilter = False
        LapHoaDonBanSachGridView.Columns("SoLuongTon").OptionsFilter.AllowFilter = False
        LapHoaDonBanSachGridView.Columns("SoLuongTonSauBan").OptionsFilter.AllowFilter = False
        LapHoaDonBanSachGridView.Columns("DonGia").OptionsFilter.AllowFilter = False
        LapHoaDonBanSachGridView.Columns("ThanhTien").OptionsFilter.AllowFilter = False

        'don't allow sorting
        LapHoaDonBanSachGridView.Columns("STT").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
        LapHoaDonBanSachGridView.Columns("MaSach").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
        LapHoaDonBanSachGridView.Columns("TenSach").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
        LapHoaDonBanSachGridView.Columns("TheLoai").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
        LapHoaDonBanSachGridView.Columns("TacGia").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
        LapHoaDonBanSachGridView.Columns("SoLuongBan").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
        LapHoaDonBanSachGridView.Columns("SoLuongTon").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
        LapHoaDonBanSachGridView.Columns("SoLuongTonSauBan").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
        LapHoaDonBanSachGridView.Columns("DonGia").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
        LapHoaDonBanSachGridView.Columns("ThanhTien").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False

        'Set the Width of some columns
        LapHoaDonBanSachGridView.Columns("STT").Width = 5


        'Clear for sure
        If (listBookIDs IsNot Nothing) Then
            listBookIDs.Clear()
        End If
        AllBookIDsListBox.Items.Clear()
        'Get all book IDs
        listBookIDs = SACHBUS.GetAllBookIDs()

        'If it's not nothing
        If (listBookIDs IsNot Nothing) Then
            AllBookIDsListBox.Items.AddRange(listBookIDs.ToArray)
            AllBookIDsListBox.Visible = False
            AllBookIDsListBox.SelectedIndex = 0
            LapHoaDonBanSachGridControl.Controls.Add(AllBookIDsListBox)
        End If

    End Sub

    ''' <summary>
    ''' Override this to have full control of list box
    ''' </summary>
    ''' <param name="msg"></param>
    ''' <param name="keyData"></param>
    ''' <returns></returns>
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean

        If (AllBookIDsListBox.Visible) Then
            Select Case keyData
                Case Keys.Down
                    If (AllBookIDsListBox.SelectedIndex < AllBookIDsListBox.Items.Count) Then
                        AllBookIDsListBox.SelectedIndex = AllBookIDsListBox.SelectedIndex + 1
                    End If
                    Return True
                Case Keys.Up
                    If (AllBookIDsListBox.SelectedIndex > 0) Then
                        AllBookIDsListBox.SelectedIndex = AllBookIDsListBox.SelectedIndex - 1
                    End If
                    Return True
                Case Keys.Tab, Keys.Enter
                    InsertValueFromListBoxIntoCell()
            End Select
        End If

        If (AllCustomerIDsListBox.Visible) Then
            Select Case keyData
                Case Keys.Down
                    If (AllCustomerIDsListBox.SelectedIndex < AllCustomerIDsListBox.Items.Count) Then
                        AllCustomerIDsListBox.SelectedIndex = AllCustomerIDsListBox.SelectedIndex + 1
                    End If
                    Return True
                Case Keys.Up
                    If (AllCustomerIDsListBox.SelectedIndex > 0) Then
                        AllCustomerIDsListBox.SelectedIndex = AllCustomerIDsListBox.SelectedIndex - 1
                    End If
                    Return True
                Case Keys.Tab, Keys.Enter
                    MaKhachHangTextBox.Text = AllCustomerIDsListBox.SelectedItem.ToString()
                    AllCustomerIDsListBox.Visible = False
            End Select
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    ''' <summary>
    ''' Insert selected value from listbox into cell of gridview
    ''' </summary>
    Private Sub InsertValueFromListBoxIntoCell()
        Try
            'Get row handle
            Dim rowHandle As Integer = Integer.Parse(AllBookIDsListBox.Tag.ToString)

            LapHoaDonBanSachGridView.SetRowCellValue(rowHandle, "MaSach", AllBookIDsListBox.SelectedItem.ToString())

            'Set row being focused
            LapHoaDonBanSachGridView.FocusedRowHandle = rowHandle

            SetFocusedRowValue(AllBookIDsListBox.SelectedItem.ToString())

            AllBookIDsListBox.Visible = False

        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ''' <summary>
    ''' Set focused row value
    ''' </summary>
    ''' <param name="bookID"></param>
    Private Sub SetFocusedRowValue(ByVal bookID As String)
        'Get row is being focused
        Dim selectedRow As DataRow = LapHoaDonBanSachGridView.GetFocusedDataRow

        Dim rowHandle As Integer = LapHoaDonBanSachGridView.FocusedRowHandle

        'a String to hold exception
        Dim ex As String = ""

        'Find book to display later
        Dim book As SACHDTO = SACHBUS.FindBookByID(bookID, True, ex)

        'If there is exception
        If (ex <> "") Then
            DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        'if user typed in wrong book ID
        If (book Is Nothing) Then
            selectedRow("TenSach") = ""
            selectedRow("TheLoai") = ""
            selectedRow("TacGia") = ""
            selectedRow("DonGia") = ""
            selectedRow("SoLuongTon") = ""
            selectedRow("SoLuongTonSauBan") = ""
            selectedRow("ThanhTien") = ""
        Else 'user type in right ID, then set columns value for the value of that book
            selectedRow("TenSach") = book.TenSach
            selectedRow("TheLoai") = book.TheLoai
            selectedRow("TacGia") = book.TacGia
            selectedRow("DonGia") = book.DonGia.ToString("c0")
            selectedRow("SoLuongTon") = book.SoLuongTon.ToString()

            'If there is something in column SoLuongBan
            If (selectedRow("SoLuongBan").ToString <> "") Then
                'Calculate SoLuongTonSauBan
                selectedRow("SoLuongTonSauBan") = (book.SoLuongTon - Integer.Parse(selectedRow("SoLuongBan").ToString)).ToString("n0")

                'Calculate ThanhTien
                selectedRow("ThanhTien") = (book.DonGia * Integer.Parse(selectedRow("SoLuongBan").ToString)).ToString("c0")
            End If

        End If

        'Refresh Cells to immediately display
        LapHoaDonBanSachGridView.RefreshRowCell(rowHandle, LapHoaDonBanSachGridView.Columns("TenSach"))
        LapHoaDonBanSachGridView.RefreshRowCell(rowHandle, LapHoaDonBanSachGridView.Columns("TheLoai"))
        LapHoaDonBanSachGridView.RefreshRowCell(rowHandle, LapHoaDonBanSachGridView.Columns("TacGia"))
        LapHoaDonBanSachGridView.RefreshRowCell(rowHandle, LapHoaDonBanSachGridView.Columns("DonGia"))
        LapHoaDonBanSachGridView.RefreshRowCell(rowHandle, LapHoaDonBanSachGridView.Columns("SoLuongTon"))
        LapHoaDonBanSachGridView.RefreshRowCell(rowHandle, LapHoaDonBanSachGridView.Columns("SoLuongTonSauBan"))
        LapHoaDonBanSachGridView.RefreshRowCell(rowHandle, LapHoaDonBanSachGridView.Columns("ThanhTien"))
    End Sub

    ''' <summary>
    ''' Insert information into LichSuThaoTacFlowPanel
    ''' </summary>
    ''' <param name="captionButtonText"></param>
    ''' <param name="captionButtonTag"></param>
    ''' <param name="information"></param>
    ''' <param name="captionButtonForeColor"></param>
    Private Sub InsertInformationIntoFlowPanel(ByVal captionButtonText As String, ByVal captionButtonTag As Object, ByVal information As String, ByVal captionButtonForeColor As Color)

        Dim buttonFont As Font = New Font("Tahoma", 12, FontStyle.Bold)
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
        If (button.Tag IsNot Nothing) Then
            If (DevExpress.XtraEditors.XtraMessageBox.Show("Để xem chi tiết phiếu nhập này, toàn bộ thông tin hiện có trong bảng lập phiếu sẽ bị xóa, bạn có chắc chắn muốn thực hiện nó không?",
                                                           "Cẩn Thận", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes) Then

                LapHoaDonBanSachGridControl.DataSource = DirectCast(button.Tag, DataTable)

                LapHoaDonBanSachGridView.OptionsBehavior.Editable = False
                LapHoaDonBanSachGridView.Appearance.Row.BackColor = Color.LightGray
                LapHoaDonBanSachGridView.Appearance.FocusedRow.BackColor = Color.DarkGray

            End If
        End If

    End Sub

    ''' <summary>
    ''' Delete all the rows in datagridview
    ''' </summary>
    Private Sub DeleteAllRowsInGridView()

        'set dataSource = mainDataTable and delete all the rows of this datatable 
        'do this to save the memory because we don't need to create new datatable over and over again
        LapHoaDonBanSachGridControl.DataSource = mainDataTable

        'Delete all the rows
        Do While (LapHoaDonBanSachGridView.RowCount > 0)
            LapHoaDonBanSachGridView.DeleteRow(LapHoaDonBanSachGridView.GetRowHandle(0))
        Loop

        'Add new row (this is just a option)
        LapHoaDonBanSachGridView.AddNewRow()

        LapHoaDonBanSachGridView.OptionsBehavior.Editable = True
        LapHoaDonBanSachGridView.Appearance.Row.BackColor = Color.White
        LapHoaDonBanSachGridView.Appearance.FocusedRow.BackColor = Color.Empty

    End Sub

    Public Sub RefreshGUI()
        Try
            'Get and set ThamSo
            THAMSOBUS.GetThamSo()
            SoTienNoToiDaTextBox.Text = THAMSODTO.SoTienNoToiDa.ToString("c0")
            SoLuongTonToiThieuTextBox.Text = THAMSODTO.SoLuongTonToiThieuSauBan.ToString("n0")

            'refresh cell value
            If (LapHoaDonBanSachGridView.OptionsBehavior.Editable = True) Then
                For index As Integer = 0 To LapHoaDonBanSachGridView.RowCount - 1
                    LapHoaDonBanSachGridView.FocusedRowHandle = index
                    SetFocusedRowValue(LapHoaDonBanSachGridView.GetFocusedDataRow()("MaSach").ToString())
                Next

            End If

            'refresh customer
            MaKhachHangTextBox_EditValueChanged(Nothing, EventArgs.Empty)

            ''Refresh listBooks
            'Get all book IDs
            If (listBookIDs IsNot Nothing) Then
                listBookIDs.Clear()
            End If
            AllBookIDsListBox.Items.Clear()
            listBookIDs = SACHBUS.GetAllBookIDs()
            'If it's not nothing
            If (listBookIDs IsNot Nothing) Then
                AllBookIDsListBox.Items.AddRange(listBookIDs.ToArray)
                AllBookIDsListBox.SelectedIndex = 0
            End If

            ''Refresh listCustomers
            'Get all book IDs
            If (listCustomerIDs IsNot Nothing) Then
                listCustomerIDs.Clear()
            End If
            AllCustomerIDsListBox.Items.Clear()
            listCustomerIDs = KHACHHANGBUS.GetAllCustomerIDs()
            'If it's not nothing
            If (listCustomerIDs IsNot Nothing) Then
                AllCustomerIDsListBox.Items.AddRange(listCustomerIDs.ToArray)
                AllCustomerIDsListBox.SelectedIndex = 0
            End If

            'hide for sure
            AllBookIDsListBox.Visible = False
            AllCustomerIDsListBox.Visible = False
        Catch ex As Exception

        End Try
    End Sub


#End Region

#Region "Buttons"

    Private Sub TaoPhieuMoiButton_Click(sender As Object, e As EventArgs) Handles TaoPhieuMoiButton.Click
        'Show safe MessageBox
        Dim result As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Bạn có chắc chắn muốn xóa tất cả dòng?", "Cẩn Thận!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        'If user clicked Yes
        If (result = DialogResult.Yes) Then
            DeleteAllRowsInGridView()
            MaKhachHangTextBox.Text = ""
            LapHoaDonButton.Enabled = True
        End If
    End Sub

    Private Sub LapHoaDonButton_Click(sender As Object, e As EventArgs) Handles LapHoaDonButton.Click

        'If user hasn't typed in the right customer ID
        'Note that we just have to check SoTienNoTextBox
        If (SoTienNoTextBox.Text = "") Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Xin hãy nhập vào đúng mã khách hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        'Check SoTienNo
        If (Decimal.Parse(SoTienNoTextBox.Text, Globalization.NumberStyles.Currency) > THAMSODTO.SoTienNoToiDa) Then
            DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("Số tiền nợ > Số tiền nợ tối đa, khách hàng này có lẽ không thể mua sách tại thời điểm hiện tại dựa theo quy định: Chỉ bán cho các khách hàng nợ không quá {0}", THAMSODTO.SoTienNoToiDa),
                                                       "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        'Loop through all the row
        Dim i As Integer = 0
        Do While (i < LapHoaDonBanSachGridView.RowCount)
            'Store exception
            Dim errorMessage As String = ""

            'get datarow
            Dim selectedRow = LapHoaDonBanSachGridView.GetDataRow(LapHoaDonBanSachGridView.GetRowHandle(i))

            'If this row is not having the right book ID or row("SoLuongNhap") is not having anything
            If (selectedRow("DonGia").ToString = "" Or selectedRow("SoLuongBan").ToString = "") Then
                'set error message
                errorMessage = String.Format("Row {0}  MaSach: {1}   TenSach: {2}   TheLoai: {3}   TacGia: {4}   SoLuongBan: {5}   SoLuongTonSauBan: {6}   DonGia: {7}   ThanhTien: {8}  không có mã sách đúng hoặc bạn chưa nhập vào Số Lượng Bán" & vbNewLine &
                                                           "Bạn có muốn nhập lại không?" & vbNewLine &
                                                           "Nhấn No để xóa dòng này", selectedRow("STT"), selectedRow("MaSach"), selectedRow("TenSach"),
                                                            selectedRow("TheLoai"), selectedRow("TacGia"), selectedRow("SoLuongBan"), selectedRow("SoLuongTonSauBan"),
                                                            selectedRow("DonGia"), selectedRow("ThanhTien"))

            Else
                'If SoLuongSauBan < SoLuongTonToiThieuSauBan
                If (Integer.Parse(selectedRow("SoLuongTonSauBan").ToString) < THAMSODTO.SoLuongTonToiThieuSauBan) Then
                    errorMessage = String.Format("Row {0}  Số Lượng Tồn Sau Bán < Số Lượng Tồn Tối Thiểu Sau Bán, đầu sách này có lẽ không thể được bán nữa dựa trên quy định: Số lượng tồn sau bán ít nhất là {1}" & vbNewLine &
                                                          "Bạn có muốn nhập lại không?" & vbNewLine &
                                                          "Nhấn No để xóa dòng này", selectedRow("STT"), THAMSODTO.SoLuongTonToiThieuSauBan)
                End If
            End If

            If (errorMessage <> "") Then
                'show errorMessage
                Dim result As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

                'if user choose Yes, return for user typing in
                If (result = DialogResult.Yes) Then
                    'focusing row is being needed to fix for more convenient
                    LapHoaDonBanSachGridView.FocusedRowHandle = i
                    Return
                Else
                    'Delete this row
                    LapHoaDonBanSachGridView.DeleteRow(LapHoaDonBanSachGridView.GetRowHandle(i))

                    'Since we deleted one row, we have to lower index by 1 to check the next row
                    i = i - 1
                End If
            End If

            i = i + 1
        Loop

        'if there isn't any row in GridView, just return
        If (LapHoaDonBanSachGridView.RowCount = 0) Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Không có thông tin trong bảng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LapHoaDonBanSachGridView.AddNewRow()
            Return
        Else
            If (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn có chắc chắn muốn lập hóa đơn này không?", "Cẩn Thận!!", MessageBoxButtons.YesNo,
                                                           MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If
        End If

        'store exception
        Dim ex As String = ""

        'create a new PhieuHoaDon
        Dim phieuHoaDon As New PHIEUHOADONDTO

        'set values
        phieuHoaDon.MaPhieuHoaDon = PHIEUHOADONBUS.GetNewPhieuHoaDonID(ex)
        If (ex <> "") Then
            DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        'set other values
        phieuHoaDon.NgayLapHoaDon = String.Format("{0}-{1}-{2}", NgayLapHoaDonDateTimePicker.Value.Year, NgayLapHoaDonDateTimePicker.Value.Month,
                                           NgayLapHoaDonDateTimePicker.Value.Day)
        phieuHoaDon.MaKhachHang = MaKhachHangTextBox.Text

        'insert new phieuHoaDon into database
        If (PHIEUHOADONBUS.InsertPhieuHoaDon(phieuHoaDon, ex) = False) Then
            DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        'Update Customer debt
        If (KHACHHANGBUS.UpdateCustomerDebt(phieuHoaDon.MaKhachHang, Decimal.Parse(TongThanhTienTextBox.Text, Globalization.NumberStyles.Currency), ex) = False) Then
            DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        'Update BaoCaoCongNo
        If (CHITIETCONGNOBUS.UpdateChiTietCongNo(NgayLapHoaDonDateTimePicker.Value.Month, NgayLapHoaDonDateTimePicker.Value.Year, phieuHoaDon.MaKhachHang,
                                                 Decimal.Parse(TongThanhTienTextBox.Text, Globalization.NumberStyles.Currency), ex) = False) Then
            DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        'create new datatable to fill in GridView
        Dim dataTable = New DataTable
        'Setup column STT
        dataTable.Columns.Add("STT").Caption = "STT"
        'Setup column MaSach
        dataTable.Columns.Add("MaSach").Caption = "Mã Sách"
        'Setup column SoLuongBan
        dataTable.Columns.Add("SoLuongBan").Caption = "Số Lượng Bán"
        'Setup column SoLuongBan
        dataTable.Columns.Add("SoLuongTon").Caption = "Số Lượng Tồn"
        'Setup column DonGia
        dataTable.Columns.Add("DonGia").Caption = "Đơn giá"
        'Setup column TenSach
        dataTable.Columns.Add("TenSach").Caption = "Tên Sách"
        'Setup column TheLoai
        dataTable.Columns.Add("TheLoai").Caption = "Thể Loại"
        'Setup column TheLoai
        dataTable.Columns.Add("TacGia").Caption = "Tác Giả"
        'Setup column SoLuongTonSauBan
        dataTable.Columns.Add("SoLuongTonSauBan").Caption = "Số Lượng Tồn Sau Bán"
        'Setup column ThanhTien
        dataTable.Columns.Add("ThanhTien").Caption = "Thành Tiền"

        'Get new ChiTietPhieuHoaDon
        Dim chiTietPhieuHoaDon As New CHITIETPHIEUHOADONDTO

        'loop through all the row in GridView
        For index As Integer = 0 To LapHoaDonBanSachGridView.RowCount - 1

            'Get current row
            Dim selectedRow As DataRow = LapHoaDonBanSachGridView.GetDataRow(LapHoaDonBanSachGridView.GetRowHandle(index))

            'add to datatable 
            dataTable.Rows.Add(selectedRow.ItemArray.ToArray)

            'Set values
            chiTietPhieuHoaDon.MaChiTietPhieuHoaDon = CHITIETPHIEUHOADONBUS.GetNewChiTietPhieuHoaDonID(ex)
            If (ex <> "") Then
                DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            chiTietPhieuHoaDon.MaPhieuHoaDon = phieuHoaDon.MaPhieuHoaDon
            chiTietPhieuHoaDon.MaSach = selectedRow("MaSach").ToString
            chiTietPhieuHoaDon.SoLuongBan = Integer.Parse(selectedRow("SoLuongBan").ToString)

            'Insert new ChiTietPhieuNhap into database
            If (CHITIETPHIEUHOADONBUS.InsertChiTietPhieuHoaDon(chiTietPhieuHoaDon, ex) = False) Then
                DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            'Update SoLuongTon of SACH
            'Note that we have to put a minus before SoLuongBan because we want to lower SoLuongTon 
            If (SACHBUS.UpdateInventory(chiTietPhieuHoaDon.MaSach, -chiTietPhieuHoaDon.SoLuongBan, ex) = False) Then
                DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            'Update BaoCaoTon 
            'And we also have to put a minus before SoLuongBan here because the similar purpose above
            If (CHITIETTONBUS.UpdateChiTietTon(NgayLapHoaDonDateTimePicker.Value.Month, NgayLapHoaDonDateTimePicker.Value.Year, chiTietPhieuHoaDon.MaSach, -chiTietPhieuHoaDon.SoLuongBan, ex) = False) Then
                DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

        Next

        DevExpress.XtraEditors.XtraMessageBox.Show("Lập hóa đơn bán sách thành công", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'get information to display 
        Dim information As String = String.Format(NgayLapHoaDonDateTimePicker.Value.ToString() & "   Mã Phiếu Hóa Đơn: {0}   Mã Khách Hàng: {1}   Tổng Thành Tiền: {2}",
                                                  phieuHoaDon.MaPhieuHoaDon, phieuHoaDon.MaKhachHang, TongThanhTienTextBox.Text)

        'Insert information into flow panel
        InsertInformationIntoFlowPanel("LẬP PHIẾU THÀNH CÔNG", dataTable, information, Color.Green)

        'Display dialog
        If (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn có muốn giữ lại thông tin hiện hành tại bảng hóa đơn không?", "Question",
                                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
            DeleteAllRowsInGridView()
        Else
            LapHoaDonBanSachGridView.OptionsBehavior.Editable = False
            LapHoaDonBanSachGridView.Appearance.Row.BackColor = Color.LightGray
            LapHoaDonBanSachGridView.Appearance.FocusedRow.BackColor = Color.DarkGray
            LapHoaDonButton.Enabled = False
        End If

        SACHGUI.GUI.RefreshGUI()
        KHACHHANGGUI.GUI.RefreshGUI()
        LAPPHIEUTHUTIENGUI.GUI.RefreshGUI()

    End Sub


    Private Sub XuatFileExelButton_Click(sender As Object, e As EventArgs) Handles XuatFileExelButton.Click

        'If user presses OK
        If (SaveDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            UseWaitCursor = True
            progressBarControl.Visible = True
            Me.Enabled = False
            BackgroundWorker.WorkerReportsProgress = True
            BackgroundWorker.RunWorkerAsync()
        End If
    End Sub

    Private Sub backgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker.DoWork

        Dim reportProgressPercent As Integer = 1

        'Background worker
        BackgroundWorker.ReportProgress(1)

        'get excel application
        Dim excel As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application()
        BackgroundWorker.ReportProgress(2)

        'Add workbook to excel
        Dim workbook As Microsoft.Office.Interop.Excel.Workbook = excel.Workbooks.Add(Type.Missing)
        BackgroundWorker.ReportProgress(3)

        'Store worksheet
        Dim worksheet As Microsoft.Office.Interop.Excel.Worksheet = Nothing
        BackgroundWorker.ReportProgress(4)

        Try
            'Get active worksheet
            worksheet = CType(workbook.ActiveSheet, Microsoft.Office.Interop.Excel.Worksheet)
            BackgroundWorker.ReportProgress(5)

            reportProgressPercent = 5

            'TextBox
            worksheet.Cells(1, 1) = "Ngày lập hóa đơn: "
            worksheet.Cells(1, 2) = NgayLapHoaDonDateTimePicker.Value.ToString
            worksheet.Cells(2, 1) = "Mã khách hàng: "
            worksheet.Cells(2, 2) = MaKhachHangTextBox.Text
            worksheet.Cells(3, 1) = "Số lượng tồn tối thiểu sau khi bán: "
            worksheet.Cells(3, 2) = SoLuongTonToiThieuTextBox.Text
            worksheet.Cells(4, 1) = "Số tiền nợ tối đa: "
            worksheet.Cells(4, 2) = Decimal.Parse(SoTienNoToiDaTextBox.Text, Globalization.NumberStyles.Currency).ToString()

            reportProgressPercent = 6

            'Excel index starts from 1,1. As first Row would have the Column headers
            For iColumn As Integer = 1 To LapHoaDonBanSachGridView.Columns.Count
                worksheet.Cells(5, iColumn) = LapHoaDonBanSachGridView.Columns(iColumn - 1).FieldName

                'report progress
                reportProgressPercent = reportProgressPercent + 1
                BackgroundWorker.ReportProgress(reportProgressPercent)
            Next

            'Set the value for remaining row of worksheet by the value being presented in GridView 
            For iRow As Integer = 0 To LapHoaDonBanSachGridView.RowCount - 1
                'get current row
                Dim selectedRow As DataRow = LapHoaDonBanSachGridView.GetDataRow(LapHoaDonBanSachGridView.GetRowHandle(iRow))

                'loop through all columns
                For iColumn As Integer = 1 To LapHoaDonBanSachGridView.Columns.Count

                    'As the saying above, Excel index starts from 1,1
                    'So the next row has the index of (2, iColumn)
                    worksheet.Cells(iRow + 6, iColumn) = selectedRow(iColumn - 1).ToString()

                    'report progress
                    If (reportProgressPercent < 98) Then
                        reportProgressPercent = reportProgressPercent + 1
                        BackgroundWorker.ReportProgress(reportProgressPercent)
                    End If
                Next
            Next

            'Don't allow displaying alerts
            'this is just a setup to prevent some kind of disturb things
            excel.DisplayAlerts = False

            'Save Workbook
            workbook.SaveAs(SaveDialog.FileName)

            'report progress
            BackgroundWorker.ReportProgress(99)

            excel.DisplayAlerts = True

            'report progress
            BackgroundWorker.ReportProgress(100)

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

    Private Sub backgroundWorker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker.ProgressChanged
        progressBarControl.EditValue = e.ProgressPercentage
        progressBarControl.Text = progressBarControl.EditValue.ToString()
    End Sub

    Private Sub backgroundWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker.RunWorkerCompleted
        Me.Enabled = True
        progressBarControl.Visible = False
        UseWaitCursor = False
    End Sub


    Private Sub NhapFileExcelButton_Click(sender As Object, e As EventArgs) Handles NhapFileExcelButton.Click
        'Show safe dialog
        If (DevExpress.XtraEditors.XtraMessageBox.Show("Thao tác này sẽ xóa toàn bộ thông tin hiện có trong bảng hóa đơn, bạn có chắc chắn muốn thực hiện không?", "Cẩn Thận!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            DeleteAllRowsInGridView()
        Else
            Return
        End If

        'If user presses OK in OpenFileDialog
        If (OpenDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            'Use wait cursor
            UseWaitCursor = True
            progressBarControl.Visible = True
            Me.Enabled = False

            'setup progress bar
            progressBarControl.EditValue = 1
            progressBarControl.Text = progressBarControl.EditValue.ToString()

            'get excel application
            Dim excel As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application()
            'setup progress bar
            progressBarControl.EditValue = 2
            progressBarControl.Text = progressBarControl.EditValue.ToString()

            'Add workbook to excel
            Dim workbook As Microsoft.Office.Interop.Excel.Workbook = excel.Workbooks.Open(OpenDialog.FileName)
            'setup progress bar
            progressBarControl.EditValue = 3
            progressBarControl.Text = progressBarControl.EditValue.ToString()

            'Store worksheet
            Dim worksheet As Microsoft.Office.Interop.Excel.Worksheet = Nothing
            'setup progress bar
            progressBarControl.EditValue = 4
            progressBarControl.Text = progressBarControl.EditValue.ToString()

            'Get range to read column and row
            Dim range As Microsoft.Office.Interop.Excel.Range = Nothing
            'setup progress bar
            progressBarControl.EditValue = 5
            progressBarControl.Text = progressBarControl.EditValue.ToString()

            Try
                'Get active worksheet
                worksheet = CType(workbook.ActiveSheet, Microsoft.Office.Interop.Excel.Worksheet)

                'Get current range
                range = worksheet.UsedRange

                'Don't allow displaying alerts
                'this is just a setup to prevent some kind of disturb things
                excel.DisplayAlerts = False

                'Check header
                If (CType(range.Cells(1, 1), Microsoft.Office.Interop.Excel.Range).Value2.ToString() = "STT" And
                    CType(range.Cells(1, 2), Microsoft.Office.Interop.Excel.Range).Value2.ToString() = "MaSach" And
                    CType(range.Cells(1, 3), Microsoft.Office.Interop.Excel.Range).Value2.ToString() = "SoLuongBan") Then

                    'Loop
                    For index As Integer = 2 To range.Rows.Count

                        'get row to write in
                        Dim selectedRow As DataRow = LapHoaDonBanSachGridView.GetDataRow(LapHoaDonBanSachGridView.GetRowHandle(index - 2))

                        'Check SoLuongNhap'
                        If (CType(range.Cells(index, 3), Microsoft.Office.Interop.Excel.Range).Value2 IsNot Nothing) Then
                            'check format column SoLuongNhap in excel
                            Dim soLuongNhap As Integer = 0
                            Dim isNumber As Boolean = Integer.TryParse(CType(range.Cells(index, 3), Microsoft.Office.Interop.Excel.Range).Value2.ToString(), soLuongNhap)

                            'if it's number
                            If (isNumber = True) Then
                                'set the value of column SoLuongNhap
                                selectedRow("SoLuongBan") = soLuongNhap
                            Else
                                Dim result As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Hàng " & index.ToString() & " có Số Lượng Bán không phải là chữ số, bạn có muốn bỏ qua dòng này không?" & vbNewLine &
                                                                                "Chọn No sẽ đặt giá trị Số Lượng Bán mặc định cho hàng này là 0" & vbNewLine &
                                                                                "Chọn Cancel để dừng toàn bộ quá trình Nhập từ file Excel", "Lỗi",
                                                                                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error)
                                If (result = DialogResult.Yes) Then
                                    Continue For
                                Else
                                    If (result = DialogResult.No) Then
                                        selectedRow("SoLuongBan") = 0
                                    Else
                                        Exit For
                                    End If
                                End If

                            End If
                        Else
                            selectedRow("SoLuongBan") = ""
                        End If


                        'Check MaSach'
                        If (CType(range.Cells(index, 2), Microsoft.Office.Interop.Excel.Range).Value2 IsNot Nothing) Then
                            'set the value of column MaSach
                            selectedRow("MaSach") = CType(range.Cells(index, 2), Microsoft.Office.Interop.Excel.Range).Value2.ToString()

                            SetFocusedRowValue(selectedRow("MaSach").ToString())
                        Else
                            selectedRow("MaSach") = ""
                        End If

                        'Add New Row
                        LapHoaDonBanSachGridView.AddNewRow()

                        If (Integer.Parse(progressBarControl.EditValue.ToString()) < 99) Then
                            'setup progress bar
                            progressBarControl.EditValue = Integer.Parse(progressBarControl.EditValue.ToString()) + index
                            progressBarControl.Text = progressBarControl.EditValue.ToString()
                        End If

                    Next

                    'setup progress bar
                    progressBarControl.EditValue = 100
                    progressBarControl.Text = progressBarControl.EditValue.ToString()

                    'Display successful dialog
                    DevExpress.XtraEditors.XtraMessageBox.Show("Nhập File Exel thành công", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else

                    'Display false dialog
                    DevExpress.XtraEditors.XtraMessageBox.Show("File Format không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If



            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                'Clean up
                GC.Collect()
                GC.WaitForPendingFinalizers()

                'release range
                System.Runtime.InteropServices.Marshal.ReleaseComObject(range)

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

                'setup 
                Me.Enabled = True
                UseWaitCursor = False
                progressBarControl.Visible = False

            End Try
        End If
    End Sub


    Private Sub LayFileExcelFormatButton_Click(sender As Object, e As EventArgs) Handles LayFileExcelFormatButton.Click
        'If user presses OK in OpenFileDialog
        If (SaveDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            'Use wait cursor
            UseWaitCursor = True

            'get excel application
            Dim excel As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application()

            'Add workbook to excel
            Dim workbook As Microsoft.Office.Interop.Excel.Workbook = excel.Workbooks.Add(Type.Missing)

            'Store worksheet
            Dim worksheet As Microsoft.Office.Interop.Excel.Worksheet = Nothing

            Try
                'Get active worksheet
                worksheet = CType(workbook.ActiveSheet, Microsoft.Office.Interop.Excel.Worksheet)

                'Do some works
                worksheet.Cells(1, 1) = "STT"
                worksheet.Cells(1, 2) = "MaSach"
                worksheet.Cells(1, 3) = "SoLuongBan"
                worksheet.Cells(2, 1) = "1"
                worksheet.Cells(2, 2) = "Nhập Mã sách ở đây"
                worksheet.Cells(2, 3) = "Nhập Số lượng bán ở đây"
                worksheet.Cells(3, 1) = "2"

                'Don't allow displaying alerts
                'this is just a setup to prevent some kind of disturb things
                excel.DisplayAlerts = False

                'Save Workbook
                workbook.SaveAs(SaveDialog.FileName)

                'Display successful dialog
                DevExpress.XtraEditors.XtraMessageBox.Show("Lấy File Exel mẫu thành công", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information)


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

                'setup 
                UseWaitCursor = False

            End Try
        End If
    End Sub

    Private Sub LapPhieuThuTienButton_Click(sender As Object, e As EventArgs) Handles LapPhieuThuTienButton.Click
        'set TopLevel = false to allow adding into panel Control
        LAPPHIEUTHUTIENGUI.GUI.TopLevel = False

        'Dock Fill in the panel Control
        LAPPHIEUTHUTIENGUI.GUI.Dock = DockStyle.Fill

        'get panel control (parent of this form)
        Dim panelControl = Me.Parent

        'We have to clear this first 
        'if not, panel control will add control over and over again
        panelControl.Controls.Clear()

        'Add LAPPHIEUTHUTIENGUI to PanelControl
        panelControl.Controls.Add(LAPPHIEUTHUTIENGUI.GUI)

        'Show LAPPHIEUTHUTIENGUI form
        LAPPHIEUTHUTIENGUI.GUI.Show()

        'Bring this PanelControl to front to display it
        panelControl.BringToFront()

        'set the text of MaKhachHangTextBox
        LAPPHIEUTHUTIENGUI.GUI.GetMaKhachHangTextBox().Text = MaKhachHangTextBox.Text
        'set this just for sure
        LAPPHIEUTHUTIENGUI.GUI.GetAllCustomerIDsListBox().Visible = False

    End Sub


#End Region


End Class