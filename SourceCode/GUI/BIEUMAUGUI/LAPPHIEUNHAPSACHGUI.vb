Imports BUS
Imports DTO
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraEditors.Repository
Imports System.IO

Public Class LAPPHIEUNHAPSACHGUI

    'We just want to have only one instance of this class
    'That's why we use a shared variable
    Public Shared GUI As New LAPPHIEUNHAPSACHGUI

    Dim listOfBookIDs As List(Of String)

    Dim mainDataTable As DataTable = Nothing

#Region "All event"

    ''' <summary>
    ''' occur when the form is loading
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub LAPPHIEUNHAPSACHGUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'set NgayNhapTextBox by now
        NgayNhapDateTimePicker.Value = DateTime.Now

        'set SoLuongNhapItNhatTextBox and SoLuongTonToiDaTruocKhiNhapTextBox
        THAMSOBUS.GetThamSo()
        SoLuongNhapItNhatTextBox.Text = THAMSODTO.SoLuongNhapToiThieu.ToString
        SoLuongTonToiDaTextBox.Text = THAMSODTO.SoLuongTonToiDaTruocNhap.ToString

        'set readonly
        SoLuongNhapItNhatTextBox.ReadOnly = True
        SoLuongTonToiDaTextBox.ReadOnly = True

        'Setup LapPhieuNhapSachGridView
        SetupDataGridView()

        progressBarControl.Visible = False

        'Set Filter being displayed 
        OpenDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"

        'Set Filter being displayed 
        SaveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"


    End Sub

    ''' <summary>
    ''' when the user type in the right ID of a book, show TenSach, TheLoai, TacGia, SoLuongTon in rowcells
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub LapPhieuNhapSachGridView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles LapPhieuNhapSachGridView.CellValueChanging

        If (e.Column.FieldName = "MaSach") Then 'If user type in column MaSach

            If (e.Value.ToString <> "") Then
                'string to focus in listbox
                Dim stringToFocus As String = listOfBookIDs.Find(Function(s) s.Contains(e.Value.ToString().ToUpper()))

                'If listBookIDs has a string that contains e.Value (MaSach)  
                If (stringToFocus <> "") Then

                    'Show list box 
                    If (AllBookIDsListBox.Visible = False) Then
                        AllBookIDsListBox.Tag = e.RowHandle
                        'Calculate the postion of listbox to show 
                        Dim viewInfo As GridViewInfo = CType(LapPhieuNhapSachGridView.GetViewInfo(), GridViewInfo)
                        Dim gridCellInfo As GridCellInfo = viewInfo.GetGridCellInfo(e.RowHandle, e.Column)
                        Dim location As Point = New Point(gridCellInfo.Bounds.Location.X, gridCellInfo.Bounds.Location.Y + gridCellInfo.Bounds.Height)
                        'Set location
                        AllBookIDsListBox.Location = location
                        AllBookIDsListBox.Width = gridCellInfo.Bounds.Width
                        AllBookIDsListBox.Visible = True
                    End If

                    'Set the index of list box
                    AllBookIDsListBox.SelectedIndex = AllBookIDsListBox.FindString(stringToFocus)

                End If
            End If

            SetFocusedRowValue(e.Value.ToString())

        End If


    End Sub


    ''' <summary>
    ''' add new row if user press enter
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub LapPhieuNhapSachGridView_KeyUp(sender As Object, e As KeyEventArgs) Handles LapPhieuNhapSachGridView.KeyUp
        Try
            'If user press enter
            If (e.KeyCode = Keys.Enter) Then

                'just add new row if there isn't any row in GridView
                If (LapPhieuNhapSachGridView.RowCount = 0) Then
                    LapPhieuNhapSachGridView.AddNewRow()
                    LapPhieuNhapSachGridView.FocusedColumn = LapPhieuNhapSachGridView.Columns("MaSach")
                    Return
                End If

                'Get focused row
                Dim selectedRow As DataRow = LapPhieuNhapSachGridView.GetFocusedDataRow

                'If Row("SoLuongNhap") has already had something 
                'And user typed in row("MaSach") the right ID (ID has already existed in Database)
                'Note that we just have to check row SoLuongTon to know whether it's the right ID or not
                If (selectedRow("SoLuongNhap").ToString <> "" And selectedRow("SoLuongTon").ToString <> "") Then

                    'get the last row
                    Dim lastRow As DataRow = LapPhieuNhapSachGridView.GetDataRow(LapPhieuNhapSachGridView.GetRowHandle(LapPhieuNhapSachGridView.RowCount - 1))

                    'If user typed in lastRow the right ID (ID has already existed in Database)
                    'Note that we just have to check row SoLuongTon to know whether it's the right ID or not
                    'Why I have to do like this ? Actually this isn't strictly necessary but I just like this
                    'because i just want to add a new row when user has already typed in right things at the last row
                    If (lastRow("SoLuongNhap").ToString <> "" And lastRow("SoLuongTon").ToString <> "") Then
                        'Add new Row
                        LapPhieuNhapSachGridView.AddNewRow()

                        'focus to Column MaSach for more convenient
                        LapPhieuNhapSachGridView.FocusedColumn = LapPhieuNhapSachGridView.Columns("MaSach")
                    Else  'And if user hasn't typed in right things at the last row, let's focus the last row
                        'Calculate the position to show ToolTip
                        Dim viewInfo As GridViewInfo = CType(LapPhieuNhapSachGridView.GetViewInfo(), GridViewInfo)
                        Dim position As Point = LapPhieuNhapSachGridControl.PointToScreen(viewInfo.GetGridRowInfo(LapPhieuNhapSachGridView.GetRowHandle(LapPhieuNhapSachGridView.RowCount - 1)).Bounds.Location)

                        'Show ToolTip
                        ToolTipController.ShowHint("Bạn có lẽ phải điền đẩy đủ thông tin của dòng này trước khi thêm dòng mới" & vbNewLine &
                                                   "Note: Bạn cũng có thể sử dụng nút 'Append' để thêm dòng mới", position)

                        'Focus this row
                        LapPhieuNhapSachGridView.FocusedRowHandle = LapPhieuNhapSachGridView.GetRowHandle(LapPhieuNhapSachGridView.RowCount - 1)
                        LapPhieuNhapSachGridView.FocusedColumn = LapPhieuNhapSachGridView.Columns("MaSach")
                    End If
                End If
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Event is fired when row is added
    ''' Set the value of column STT
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub LapPhieuNhapSachGridView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles LapPhieuNhapSachGridView.InitNewRow
        'Set the value of column STT
        LapPhieuNhapSachGridView.GetDataRow(e.RowHandle)("STT") = LapPhieuNhapSachGridView.RowCount

        'Refesh cell to immediately display
        LapPhieuNhapSachGridView.RefreshRowCell(e.RowHandle, LapPhieuNhapSachGridView.Columns("STT"))
    End Sub

    ''' <summary>
    ''' Reset column STT when a row is deleted
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub LapPhieuNhapSachGridView_RowDeleted(sender As Object, e As DevExpress.Data.RowDeletedEventArgs) Handles LapPhieuNhapSachGridView.RowDeleted
        For index As Integer = 0 To LapPhieuNhapSachGridView.RowCount - 1
            LapPhieuNhapSachGridView.GetDataRow(LapPhieuNhapSachGridView.GetRowHandle(index))("STT") = index + 1
        Next
    End Sub

    ''' <summary>
    ''' set mask type of the cell when SoLuongNhap column is focused 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub LapPhieuNhapSachGridView_ShownEditor(sender As Object, e As EventArgs) Handles LapPhieuNhapSachGridView.ShownEditor
        'if user is focusing column SoLuongNhap
        If (LapPhieuNhapSachGridView.FocusedColumn.FieldName = "SoLuongNhap") Then
            'convert ActiveEditor to TextEditor
            Dim edit As DevExpress.XtraEditors.TextEdit = CType(LapPhieuNhapSachGridView.ActiveEditor, DevExpress.XtraEditors.TextEdit)

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
    ''' Hide listbox if user clicks somewhere within this form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub LAPPHIEUNHAPSACHGUI_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick
        AllBookIDsListBox.Visible = False
    End Sub

    ''' <summary>
    ''' Hide listbox if user clicks somewhere within this form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub LapPhieuNhapSachGridView_LostFocus(sender As Object, e As EventArgs) Handles LapPhieuNhapSachGridView.LostFocus
        AllBookIDsListBox.Visible = False
    End Sub

#End Region

#Region "Functions"

    ''' <summary>
    ''' Setup Gridview
    ''' </summary>
    Private Sub SetupDataGridView()
        'Create new datatable
        mainDataTable = New DataTable

        'Setup column STT
        mainDataTable.Columns.Add("STT").Caption = "STT"

        'Setup column MaSach
        mainDataTable.Columns.Add("MaSach").Caption = "Mã Sách"

        'Setup column SoLuongNhap
        mainDataTable.Columns.Add("SoLuongNhap").Caption = "Số Lượng Nhập"

        'Setup column TenSach
        mainDataTable.Columns.Add("TenSach").Caption = "Tên Sách"

        'Setup column TheLoai
        mainDataTable.Columns.Add("TheLoai").Caption = "Thể Loại"

        'Setup column TacGia
        mainDataTable.Columns.Add("TacGia").Caption = "Tác Giả"

        'Setup column SoLuongTon
        mainDataTable.Columns.Add("SoLuongTon").Caption = "Số Lượng Tồn"

        'Display
        LapPhieuNhapSachGridControl.DataSource = mainDataTable

        'add new row initially
        LapPhieuNhapSachGridView.AddNewRow()

        'set allowedit by false for columns: TenSach, TheLoai, TacGia, SoLuongTon to prevent user type in
        LapPhieuNhapSachGridView.Columns("STT").OptionsColumn.AllowEdit = False
        LapPhieuNhapSachGridView.Columns("TenSach").OptionsColumn.AllowEdit = False
        LapPhieuNhapSachGridView.Columns("TheLoai").OptionsColumn.AllowEdit = False
        LapPhieuNhapSachGridView.Columns("TacGia").OptionsColumn.AllowEdit = False
        LapPhieuNhapSachGridView.Columns("SoLuongTon").OptionsColumn.AllowEdit = False


        'don't allow filtering
        LapPhieuNhapSachGridView.Columns("STT").OptionsFilter.AllowFilter = False
        LapPhieuNhapSachGridView.Columns("MaSach").OptionsFilter.AllowFilter = False
        LapPhieuNhapSachGridView.Columns("TenSach").OptionsFilter.AllowFilter = False
        LapPhieuNhapSachGridView.Columns("TheLoai").OptionsFilter.AllowFilter = False
        LapPhieuNhapSachGridView.Columns("TacGia").OptionsFilter.AllowFilter = False
        LapPhieuNhapSachGridView.Columns("SoLuongTon").OptionsFilter.AllowFilter = False
        LapPhieuNhapSachGridView.Columns("SoLuongNhap").OptionsFilter.AllowFilter = False

        'don't allow sorting
        LapPhieuNhapSachGridView.Columns("STT").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
        LapPhieuNhapSachGridView.Columns("MaSach").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
        LapPhieuNhapSachGridView.Columns("TenSach").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
        LapPhieuNhapSachGridView.Columns("TheLoai").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
        LapPhieuNhapSachGridView.Columns("TacGia").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
        LapPhieuNhapSachGridView.Columns("SoLuongTon").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
        LapPhieuNhapSachGridView.Columns("SoLuongNhap").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False

        'just some more setups for the beauty
        LapPhieuNhapSachGridView.Columns("STT").Width = 5

        'Clear for sure
        If (listOfBookIDs IsNot Nothing) Then
            listOfBookIDs.Clear()
        End If

        AllBookIDsListBox.Items.Clear()

        'Get all book IDs
        listOfBookIDs = SACHBUS.GetAllBookIDs()

        'If it's not nothing
        If (listOfBookIDs IsNot Nothing) Then
            AllBookIDsListBox.Items.AddRange(listOfBookIDs.ToArray)
            AllBookIDsListBox.Visible = False
            AllBookIDsListBox.SelectedIndex = 0
            LapPhieuNhapSachGridControl.Controls.Add(AllBookIDsListBox)
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

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    ''' <summary>
    ''' Insert selected value of listbox into the cell of gridview
    ''' </summary>
    Private Sub InsertValueFromListBoxIntoCell()
        Try

            'Get row handle
            Dim rowHandle As Integer = Integer.Parse(AllBookIDsListBox.Tag.ToString)

            LapPhieuNhapSachGridView.SetRowCellValue(rowHandle, "MaSach", AllBookIDsListBox.SelectedItem.ToString())

            'Set row being focused
            LapPhieuNhapSachGridView.FocusedRowHandle = rowHandle

            SetFocusedRowValue(AllBookIDsListBox.SelectedItem.ToString())

            AllBookIDsListBox.Visible = False

        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Set focused row value
    ''' </summary>
    Private Sub SetFocusedRowValue(ByVal bookID As String)
        'Get row being focused
        Dim selectedRow As DataRow = LapPhieuNhapSachGridView.GetFocusedDataRow

        Dim rowHandle As Integer = LapPhieuNhapSachGridView.FocusedRowHandle

        'a String to hold exception
        Dim ex As String = ""

        'Find book to display later
        Dim book As SACHDTO = SACHBUS.FindBookByID(bookID, True, ex)

        'If having exception
        If (ex <> "") Then
            DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        'if user type in wrong book ID
        If (book Is Nothing) Then
            selectedRow("TenSach") = ""
            selectedRow("TheLoai") = ""
            selectedRow("TacGia") = ""
            selectedRow("SoLuongTon") = ""
        Else 'user type in right ID, then set columns value for the value of that book
            selectedRow("TenSach") = book.TenSach
            selectedRow("TheLoai") = book.TheLoai
            selectedRow("TacGia") = book.TacGia
            selectedRow("SoLuongTon") = book.SoLuongTon.ToString("n0")
        End If


        'Refesh cells to immediately display
        LapPhieuNhapSachGridView.RefreshRowCell(rowHandle, LapPhieuNhapSachGridView.Columns("TenSach"))
        LapPhieuNhapSachGridView.RefreshRowCell(rowHandle, LapPhieuNhapSachGridView.Columns("TheLoai"))
        LapPhieuNhapSachGridView.RefreshRowCell(rowHandle, LapPhieuNhapSachGridView.Columns("TacGia"))
        LapPhieuNhapSachGridView.RefreshRowCell(rowHandle, LapPhieuNhapSachGridView.Columns("SoLuongTon"))

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

                LapPhieuNhapSachGridControl.DataSource = DirectCast(button.Tag, DataTable)

                LapPhieuNhapSachGridView.OptionsBehavior.Editable = False
                LapPhieuNhapSachGridView.Appearance.Row.BackColor = Color.LightGray
                LapPhieuNhapSachGridView.Appearance.FocusedRow.BackColor = Color.DarkGray

            End If
        End If

    End Sub

    ''' <summary>
    ''' Delete all the rows in datagridview
    ''' </summary>
    Private Sub DeleteAllRowsInGridView()

        'set dataSource = mainDataTable and delete all the rows of this datatable 
        'do this to save the memory because we don't need to create new datatable over and over again
        LapPhieuNhapSachGridControl.DataSource = mainDataTable

        'Delete all the rows
        Do While (LapPhieuNhapSachGridView.RowCount > 0)
            LapPhieuNhapSachGridView.DeleteRow(LapPhieuNhapSachGridView.GetRowHandle(0))
        Loop

        'Add new row (this is just a option)
        LapPhieuNhapSachGridView.AddNewRow()

        LapPhieuNhapSachGridView.OptionsBehavior.Editable = True
        LapPhieuNhapSachGridView.Appearance.Row.BackColor = Color.White
        LapPhieuNhapSachGridView.Appearance.FocusedRow.BackColor = Color.Empty

    End Sub

    Public Sub RefreshGUI()
        Try
            'set SoLuongNhapItNhatTextBox and SoLuongTonToiDaTruocKhiNhapTextBox
            THAMSOBUS.GetThamSo()
            SoLuongNhapItNhatTextBox.Text = THAMSODTO.SoLuongNhapToiThieu.ToString
            SoLuongTonToiDaTextBox.Text = THAMSODTO.SoLuongTonToiDaTruocNhap.ToString

            'refresh cell value
            If (LapPhieuNhapSachGridView.OptionsBehavior.Editable = True) Then
                For index As Integer = 0 To LapPhieuNhapSachGridView.RowCount - 1
                    LapPhieuNhapSachGridView.FocusedRowHandle = index
                    SetFocusedRowValue(LapPhieuNhapSachGridView.GetFocusedDataRow()("MaSach").ToString())
                Next

            End If

            ''Refresh listBooks
            'Get all book IDs
            If (listOfBookIDs IsNot Nothing) Then
                listOfBookIDs.Clear()
            End If
            AllBookIDsListBox.Items.Clear()
            listOfBookIDs = SACHBUS.GetAllBookIDs()
            'If it's not nothing
            If (listOfBookIDs IsNot Nothing) Then
                AllBookIDsListBox.Items.AddRange(listOfBookIDs.ToArray)
                AllBookIDsListBox.SelectedIndex = 0
            End If

            'hide for sure
            AllBookIDsListBox.Visible = False
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Buttons"

    ''' <summary>
    ''' Apply button 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub LapPhieuNhapSachButton_Click(sender As Object, e As EventArgs) Handles LapPhieuNhapSachButton.Click

        'CHECK SOME ERRORS
        'Loop through all the row to check exception before inserting into database
        Dim i As Integer = 0
        Do While (i < LapPhieuNhapSachGridView.RowCount)
            'store error
            Dim errorMessage As String = ""

            'get datarow
            Dim selectedRow = LapPhieuNhapSachGridView.GetDataRow(LapPhieuNhapSachGridView.GetRowHandle(i))

            'If this row is not having the right book ID or row("SoLuongNhap") is not having anything
            If (selectedRow("SoLuongTon").ToString = "" Or selectedRow("SoLuongNhap").ToString = "") Then
                'set error message
                errorMessage = String.Format("Row {0}  Mã Sách: {1}   Tên Sách: {2}   Thể Loại: {3}   Tác Giả: {4}   Số Lượng Tồn: {5}  có mã sách không đúng hoặc bạn chưa nhập vào Số Lượng Nhập" & vbNewLine &
                                             "Bạn có muốn nhập lại không?" & vbNewLine &
                                             "Nhấn No để xóa dòng này", selectedRow("STT"), selectedRow("MaSach"), selectedRow("TenSach"),
                                              selectedRow("TheLoai"), selectedRow("TacGia"), selectedRow("SoLuongTon"))

            Else
                'If SoLuongNhap < SoLuongNhapToiThieu
                If (Integer.Parse(selectedRow("SoLuongNhap").ToString) < THAMSODTO.SoLuongNhapToiThieu) Then
                    errorMessage = String.Format("Row {0}  Số Lượng Nhập < Số Lượng Nhập Tối Thiểu, Bạn có muốn nhập lại không" & vbNewLine & vbNewLine &
                                                 "Nhấn No để xóa dòng này", selectedRow("STT"))
                Else
                    'If SoLuongTon > SoLuongTonToiDaTruocKhiNhap
                    If (Integer.Parse(selectedRow("SoLuongTon").ToString) > THAMSODTO.SoLuongTonToiDaTruocNhap) Then
                        errorMessage = String.Format("Row {0}  Số Lượng Tồn > Số Lượng Tồn Tối Đa, đầu sách này có lẽ không thể nhập nữa dựa vào quy định: Chỉ nhập các đầu sách có lượng tồn ít hơn {1} " & vbNewLine &
                                                     "Bạn có muốn nhập lại không?" & vbNewLine &
                                                     "Nhấn No để xóa dòng này", selectedRow("STT"), THAMSODTO.SoLuongTonToiDaTruocNhap)
                    End If
                End If
                End If

            'If exception occured, show it
            If (errorMessage <> "") Then
                'show errorMessage
                Dim result As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

                'if user choose Yes, return for user typing in
                If (result = DialogResult.Yes) Then
                    'focusing row is being needed to fix for more convenient
                    LapPhieuNhapSachGridView.FocusedRowHandle = i
                    Return
                Else
                    'Delete this row
                    LapPhieuNhapSachGridView.DeleteRow(LapPhieuNhapSachGridView.GetRowHandle(i))

                    'Since we deleted one row, we have to lower index by 1 to check the next row
                    i = i - 1
                End If
            End If

            i = i + 1
        Loop

        'if there isn't any row in GridView, just return
        If (LapPhieuNhapSachGridView.RowCount = 0) Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Không có thông tin trong bảng phiếu nhập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LapPhieuNhapSachGridView.AddNewRow()
            Return
        Else
            If (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn có chắc chắn muốn lập phiếu nhập này không?", "Cẩn Thận!!", MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If
        End If



        'INSERT INTO DATABASE
        'store exception
        Dim ex As String = ""

        'create a new PhieuNhap
        Dim phieuNhap As New PHIEUNHAPDTO

        'get new MaPhieuNhap
        phieuNhap.MaPhieuNhap = PHIEUNHAPBUS.GetNewPhieuNhapID(ex)

        'Show exception if occur
        If (ex <> "") Then
            DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        'Get ngay nhap
        phieuNhap.NgayNhap = String.Format("{0}-{1}-{2}", NgayNhapDateTimePicker.Value.Year, NgayNhapDateTimePicker.Value.Month, NgayNhapDateTimePicker.Value.Day)

        'Insert new phieunhap into database
        If (PHIEUNHAPBUS.InsertPhieuNhap(phieuNhap, ex) = False) Then
            DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        'Create new datatable' We do this on the purpose of saving current data in datagridview to display later in LichSuThaoTacPanel
        Dim dataTable As New DataTable
        'Setup column STT
        dataTable.Columns.Add("STT").Caption = "STT"
        'Setup column MaSach
        dataTable.Columns.Add("MaSach").Caption = "Mã Sách"
        'Setup column SoLuongNhap
        dataTable.Columns.Add("SoLuongNhap").Caption = "Số Lượng Nhập"
        'Setup column TenSach
        dataTable.Columns.Add("TenSach").Caption = "Tên Sách"
        'Setup column TheLoai
        dataTable.Columns.Add("TheLoai").Caption = "Thể Loại"
        'Setup column TacGia
        dataTable.Columns.Add("TacGia").Caption = "Tác Giả"
        'Setup column SoLuongTon
        dataTable.Columns.Add("SoLuongTon").Caption = "Số Lượng Tồn"

        'A variable just to store ChiTietPhieuNhap information
        Dim chiTietPhieuNhap As New CHITIETPHIEUNHAPDTO

        'Loop through all the row in GridView
        For index As Integer = 0 To LapPhieuNhapSachGridView.RowCount - 1

            'Get current row
            Dim selectedRow As DataRow = LapPhieuNhapSachGridView.GetDataRow(LapPhieuNhapSachGridView.GetRowHandle(index))

            'add to dataTable
            dataTable.Rows.Add(selectedRow.ItemArray.ToArray)
            'Get new MaChiTietPhieuNhap
            chiTietPhieuNhap.MaChiTietPhieuNhap = CHITIETPHIEUNHAPBUS.GetNewChiTietPhieuNhapID(ex)
            'Show exception if occur
            If (ex <> "") Then
                DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            'Other values
            chiTietPhieuNhap.MaPhieuNhap = phieuNhap.MaPhieuNhap
            chiTietPhieuNhap.MaSach = selectedRow("MaSach").ToString
            chiTietPhieuNhap.SoLuongNhap = Integer.Parse(selectedRow("SoLuongNhap").ToString)
            'Insert new ChiTietPhieuNhap into database
            If (CHITIETPHIEUNHAPBUS.InsertChiTietPhieuNhap(chiTietPhieuNhap, ex) = False) Then
                DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            'Update SoLuongTon of SACH
            If (SACHBUS.UpdateInventory(chiTietPhieuNhap.MaSach, chiTietPhieuNhap.SoLuongNhap, ex) = False) Then
                DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            'Update BaoCaoTon 
            If (CHITIETTONBUS.UpdateChiTietTon(NgayNhapDateTimePicker.Value.Month, NgayNhapDateTimePicker.Value.Year,
                                               chiTietPhieuNhap.MaSach, chiTietPhieuNhap.SoLuongNhap, ex) = False) Then
                DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

        Next

        DevExpress.XtraEditors.XtraMessageBox.Show("Lập phiếu nhập sách thành công", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'get information to display 
        Dim information As String = String.Format(NgayNhapDateTimePicker.Value.ToString() & "   Mã Phiếu Nhập: {0}   Số lượng đầu sách được nhập: {1}", phieuNhap.MaPhieuNhap, LapPhieuNhapSachGridView.RowCount)

        'Insert information into flow panel
        InsertInformationIntoFlowPanel("LẬP PHIẾU THÀNH CÔNG", dataTable, information, Color.Green)

        'Display dialog
        If (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn có muốn giữ lại thông tin hiện hành tại bảng phiếu nhập không?", "Question",
                                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
            DeleteAllRowsInGridView()
        Else
            LapPhieuNhapSachGridView.OptionsBehavior.Editable = False
            LapPhieuNhapSachGridView.Appearance.Row.BackColor = Color.LightGray
            LapPhieuNhapSachGridView.Appearance.FocusedRow.BackColor = Color.DarkGray
            LapPhieuNhapSachButton.Enabled = False
        End If


        SACHGUI.GUI.RefreshGUI()

    End Sub

    ''' <summary>
    ''' Delete All Rows
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TaoPhieuMoiButton_Click(sender As Object, e As EventArgs) Handles TaoPhieuMoiButton.Click
        'Show safe MessageBox
        Dim result As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Bạn có chắc chắn muốn xóa tất cả dòng?", "Cẩn Thận!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        'If user clicked Yes
        If (result = DialogResult.Yes) Then
            DeleteAllRowsInGridView()
            LapPhieuNhapSachButton.Enabled = True
        End If

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

            'TextBox
            worksheet.Cells(1, 1) = "Ngày Nhập: "
            worksheet.Cells(1, 2) = NgayNhapDateTimePicker.Value.ToString()
            worksheet.Cells(2, 1) = "Số lượng nhập tối thiểu: "
            worksheet.Cells(2, 2) = SoLuongNhapItNhatTextBox.Text
            worksheet.Cells(3, 1) = "Số lượng tồn tối đa trước khi nhập: "
            worksheet.Cells(3, 2) = SoLuongTonToiDaTextBox.Text

            reportProgressPercent = 6

            'Excel index starts from 1,1. As first Row would have the Column headers
            For iColumn As Integer = 1 To LapPhieuNhapSachGridView.Columns.Count
                worksheet.Cells(4, iColumn) = LapPhieuNhapSachGridView.Columns(iColumn - 1).FieldName

                'report progress
                reportProgressPercent = reportProgressPercent + 1
                ExportBackgroundWorker.ReportProgress(reportProgressPercent)
            Next

            'Set the value for remaining row of worksheet by the value being presented in GridView 
            For iRow As Integer = 0 To LapPhieuNhapSachGridView.RowCount - 1
                'get current row
                Dim selectedRow As DataRow = LapPhieuNhapSachGridView.GetDataRow(LapPhieuNhapSachGridView.GetRowHandle(iRow))

                'loop through all columns
                For iColumn As Integer = 1 To LapPhieuNhapSachGridView.Columns.Count

                    'As the saying above, Excel index starts from 1,1
                    'So the next row has the index of (2, iColumn)
                    worksheet.Cells(iRow + 5, iColumn) = selectedRow(iColumn - 1).ToString()

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


    ''' <summary>
    ''' Import from exel
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub NhapFileExcelButton_Click(sender As Object, e As EventArgs) Handles NhapFileExcelButton.Click
        'Show safe dialog
        If (DevExpress.XtraEditors.XtraMessageBox.Show("Thao tác này sẽ xóa toàn bộ thông tin hiện có trong bảng nhập, bạn có chắc chắn muốn thực hiện không?", "Cẩn Thận!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            DeleteAllRowsInGridView()
        Else
            Return
        End If

        'If user presses OK in OpenFileDialog
        If (OpenDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            'Use wait cursor
            UseWaitCursor = True

            Me.Enabled = False

            progressBarControl.Visible = True

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
                    CType(range.Cells(1, 3), Microsoft.Office.Interop.Excel.Range).Value2.ToString() = "SoLuongNhap") Then

                    'Loop
                    For index As Integer = 2 To range.Rows.Count

                        'get row to write in
                        Dim selectedRow As DataRow = LapPhieuNhapSachGridView.GetDataRow(LapPhieuNhapSachGridView.GetRowHandle(index - 2))

                        'Check SoLuongNhap'
                        If (CType(range.Cells(index, 3), Microsoft.Office.Interop.Excel.Range).Value2 IsNot Nothing) Then
                            'check format column SoLuongNhap in excel
                            Dim soLuongNhap As Integer = 0
                            Dim isNumber As Boolean = Integer.TryParse(CType(range.Cells(index, 3), Microsoft.Office.Interop.Excel.Range).Value2.ToString(), soLuongNhap)

                            'if it's number
                            If (isNumber = True) Then
                                'set the value of column SoLuongNhap
                                selectedRow("SoLuongNhap") = soLuongNhap
                            Else
                                Dim result As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Hàng " & index.ToString() & " có Số Lượng Nhập không phải là chữ số, bạn có muốn bỏ qua dòng này không?" & vbNewLine &
                                                                                "Chọn No sẽ đặt giá trị Số Lượng Nhập mặc định cho hàng này là 0" & vbNewLine &
                                                                                "Chọn Cancel để dừng toàn bộ quá trình Nhập từ file Excel", "Lỗi",
                                                                                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error)
                                If (result = DialogResult.Yes) Then
                                    Continue For
                                Else
                                    If (result = DialogResult.No) Then
                                        selectedRow("SoLuongNhap") = 0
                                    Else
                                        Exit For
                                    End If
                                End If

                            End If
                        Else
                            selectedRow("SoLuongNhap") = ""
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
                        LapPhieuNhapSachGridView.AddNewRow()

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
                worksheet.Cells(1, 3) = "SoLuongNhap"
                worksheet.Cells(2, 1) = "1"
                worksheet.Cells(2, 2) = "Nhập Mã sách ở đây"
                worksheet.Cells(2, 3) = "Nhập Số lượng nhập ở đây"
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


#End Region


End Class