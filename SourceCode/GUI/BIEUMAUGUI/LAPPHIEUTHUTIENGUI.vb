Imports BUS
Imports DTO
Public Class LAPPHIEUTHUTIENGUI

    Public Shared GUI As New LAPPHIEUTHUTIENGUI

    Private listCustomerIDs As List(Of String)

    Private Sub LAPPHIEUTHUTIENGUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Set up TextBox
        HotenTextBox.ReadOnly = True
        DiaChiTextBox.ReadOnly = True
        DienThoaiTextBox.ReadOnly = True
        EmailTextBox.ReadOnly = True
        SoTienNoTextBox.ReadOnly = True
        SoTienThuTextBox.ReadOnly = True

        'Set up NgayThuTien
        NgayThuTienDateTimePicker.Value = DateTime.Now

        SoTienNoTextBox.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
        SoTienThuTextBox.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
        TienTraKhachTextBox.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
        TienKhachTraTextBox.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True

        'Get ThamSo
        THAMSOBUS.GetThamSo()


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

        'Store KhachHang found out
        Dim khachHang As KHACHHANGDTO = Nothing

        'Store exception
        Dim ex As String = ""

        'Find customer by ID
        khachHang = KHACHHANGBUS.FindCustomerByID(MaKhachHangTextBox.Text, True, ex)

        'if exception occured, show it
        If (ex <> "") Then
            DevExpress.XtraEditors.XtraMessageBox.Show(ex)
            Return
        End If

        If (khachHang Is Nothing) Then
            HotenTextBox.Text = ""
            DiaChiTextBox.Text = ""
            DienThoaiTextBox.Text = ""
            EmailTextBox.Text = ""
            SoTienNoTextBox.Text = ""
        Else

            HotenTextBox.Text = khachHang.HoTenKhachHang
            DiaChiTextBox.Text = khachHang.DiaChi
            DienThoaiTextBox.Text = khachHang.DienThoai
            EmailTextBox.Text = khachHang.EMail
            SoTienNoTextBox.Text = khachHang.SoTienNo.ToString()

            If (TienKhachTraTextBox.Text <> "") Then
                'Calculate SoTienThua
                TienTraKhachTextBox.Text = (Decimal.Parse(TienKhachTraTextBox.Text, Globalization.NumberStyles.Currency) - Decimal.Parse(SoTienNoTextBox.Text, Globalization.NumberStyles.Currency)).ToString()
            Else
                TienTraKhachTextBox.Text = ""
            End If

        End If

    End Sub

    Private Sub LapPhieuThuButton_Click(sender As Object, e As EventArgs) Handles LapPhieuThuButton.Click
        'Check if user typed in the right ID and SoTienThu or not
        If (SoTienNoTextBox.Text = "" Or SoTienThuTextBox.Text = "") Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Xin hãy điền đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If (Decimal.Parse(TienTraKhachTextBox.Text, Globalization.NumberStyles.Currency) < 0 Or Decimal.Parse(TienKhachTraTextBox.Text, Globalization.NumberStyles.Currency) < 0) Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Số tiền phải lớn hơn 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If


        'Check SoTienNo and SoTienThu
        If (THAMSODTO.SuDungQuyDinh4 = True) Then
            If (Decimal.Parse(SoTienThuTextBox.Text, Globalization.NumberStyles.Currency) > Decimal.Parse(SoTienNoTextBox.Text, Globalization.NumberStyles.Currency)) Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Số tiền thu không được vượt quá số tiền khách hàng nợ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        End If

        'Show safe dialog
        Dim result As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Bạn có chắc chắn muốn lập phiếu thu tiền không?", "Cẩn Thận!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        'If user pressed Yes button
        If (result = DialogResult.Yes) Then
            'store exception
            Dim ex As String = ""

            'create new PhieuThuTien
            Dim phieuThuTien As New PHIEUTHUTIENDTO

            'Get new ID
            phieuThuTien.MaPhieuThu = PHIEUTHUTIENBUS.GetNewPhieuThuTienID(ex)
            If (ex <> "") Then
                DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            'set some information
            phieuThuTien.NgayThuTien = String.Format("{0}-{1}-{2}", NgayThuTienDateTimePicker.Value.Year, NgayThuTienDateTimePicker.Value.Month, NgayThuTienDateTimePicker.Value.Day)
            phieuThuTien.SoTienThu = Decimal.Parse(SoTienThuTextBox.Text, Globalization.NumberStyles.Currency)
            phieuThuTien.MaKhachHang = MaKhachHangTextBox.Text

            'Insert PhieuThuTien into database
            If (PHIEUTHUTIENBUS.InsertPhieuThuTien(phieuThuTien, ex) = False) Then
                DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            'Update Debt of customer
            If (KHACHHANGBUS.UpdateCustomerDebt(phieuThuTien.MaKhachHang, -phieuThuTien.SoTienThu, ex) = False) Then
                DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            'Update BaoCaoCongNo
            If (CHITIETCONGNOBUS.UpdateChiTietCongNo(NgayThuTienDateTimePicker.Value.Month, NgayThuTienDateTimePicker.Value.Year, phieuThuTien.MaKhachHang, -phieuThuTien.SoTienThu, ex) = False) Then
                DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            'Show success dialog
            DevExpress.XtraEditors.XtraMessageBox.Show("Lập phiếu thu tiền thành công", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim information As String = String.Format("{0}  Mã Khách Hàng: {1}  Tên Khách Hàng: {2}   Địa Chỉ: {3}   Email: {4}   Điện Thoại: {5}   Số Tiền Thu: {6}   Số Tiền Nợ Còn Lại: {7}",
                                                       NgayThuTienDateTimePicker.Value, MaKhachHangTextBox.Text.ToUpper(), HotenTextBox.Text, DiaChiTextBox.Text,
                                                       EmailTextBox.Text, DienThoaiTextBox.Text, SoTienThuTextBox.Text,
                                                       (Decimal.Parse(SoTienNoTextBox.Text, Globalization.NumberStyles.Currency) - (Decimal.Parse(SoTienThuTextBox.Text, Globalization.NumberStyles.Currency))).ToString("c0"))

            Dim message As String = String.Format("{0}" & vbNewLine & "   Mã Khách Hàng: {1}" & vbNewLine & "   Tên Khách Hàng: {2} " & vbNewLine &
                                                  "   Địa Chỉ: {3} " & vbNewLine & "   Email: {4} " & vbNewLine & "   Điện Thoại: {5} " & vbNewLine &
                                                  "   Số Tiền Thu: {6}  " & vbNewLine & "   Số Tiền Nợ Còn Lại: {7}",
                                                    NgayThuTienDateTimePicker.Value, MaKhachHangTextBox.Text.ToUpper(), HotenTextBox.Text, DiaChiTextBox.Text,
                                                    EmailTextBox.Text, DienThoaiTextBox.Text, SoTienThuTextBox.Text,
                                                   (Decimal.Parse(SoTienNoTextBox.Text, Globalization.NumberStyles.Currency) - (Decimal.Parse(SoTienThuTextBox.Text, Globalization.NumberStyles.Currency))).ToString("c0"))

            InsertInformationIntoFlowPanel(MaKhachHangTextBox.Text.ToUpper(), message, information, Color.Green)


            TienKhachTraTextBox.Text = ""
            TienTraKhachTextBox.Text = ""
            MaKhachHangTextBox.Text = ""
            AllCustomerIDsListBox.Visible = False

            KHACHHANGGUI.GUI.RefreshGUI()

            Return
        End If

    End Sub

    ''' <summary>
    ''' Check SoTienThu and SoTienNo
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SoTienThuTextBox_EditValueChanged(sender As Object, e As EventArgs) Handles SoTienThuTextBox.EditValueChanged

        'If (TienTraKhachTextBox.Text <> "" And TienKhachTraTextBox.Text <> "") Then
        '    'Calculate SoTienThu
        '    SoTienThuTextBox.Text = (Decimal.Parse(TienKhachTraTextBox.Text, Globalization.NumberStyles.Currency) - Decimal.Parse(TienTraKhachTextBox.Text, Globalization.NumberStyles.Currency)).ToString()
        'Else
        '    SoTienThuTextBox.Text = ""
        'End If

        'Check SoTienNo and SoTienThu
        If (THAMSODTO.SuDungQuyDinh4 = True And SoTienNoTextBox.Text <> "" And SoTienThuTextBox.Text <> "" And TienTraKhachTextBox.Text <> "") Then
            If (Decimal.Parse(SoTienThuTextBox.Text, Globalization.NumberStyles.Currency) > Decimal.Parse(SoTienNoTextBox.Text, Globalization.NumberStyles.Currency)) Then
                ThongBaoLabel.Text = "Số tiền thu không được vượt quá số tiền khách hàng nợ"
                ThongBaoLabel.Visible = True
            Else
                ThongBaoLabel.Visible = False
            End If
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

        Dim buttonFont As Font = New Font("Tahoma", 13, FontStyle.Bold)
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
            DevExpress.XtraEditors.XtraMessageBox.Show(button.Tag.ToString(), "Thông Tin Phiếu Thu Tiền", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    ''' <summary>
    ''' Override this to have full control of list box
    ''' </summary>
    ''' <param name="msg"></param>
    ''' <param name="keyData"></param>
    ''' <returns></returns>
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
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
    Private Sub LAPPHIEUTHUTIENGUI_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick
        AllCustomerIDsListBox.Visible = False
    End Sub

    Private Sub TienKhachTraTextBox_EditValueChanged(sender As Object, e As EventArgs) Handles TienKhachTraTextBox.EditValueChanged
        If (SoTienNoTextBox.Text <> "" And TienKhachTraTextBox.Text <> "") Then
            'Calculate SoTienThua
            TienTraKhachTextBox.Text = (Decimal.Parse(TienKhachTraTextBox.Text, Globalization.NumberStyles.Currency) - Decimal.Parse(SoTienNoTextBox.Text, Globalization.NumberStyles.Currency)).ToString()
            If (Decimal.Parse(TienTraKhachTextBox.Text, Globalization.NumberStyles.Currency) < 0) Then
                TienTraKhachTextBox.Text = "0 "
            End If
        Else
                TienTraKhachTextBox.Text = ""
        End If

    End Sub

    Private Sub TienTraKhachTextBox_EditValueChanged(sender As Object, e As EventArgs) Handles TienTraKhachTextBox.EditValueChanged
        If (TienTraKhachTextBox.Text <> "" And TienKhachTraTextBox.Text <> "") Then
            'Calculate SoTienThu
            SoTienThuTextBox.Text = (Decimal.Parse(TienKhachTraTextBox.Text, Globalization.NumberStyles.Currency) - Decimal.Parse(TienTraKhachTextBox.Text, Globalization.NumberStyles.Currency)).ToString()
        Else
            SoTienThuTextBox.Text = ""
        End If
    End Sub

    Public Sub RefreshGUI()
        Try

            'refresh customer
            MaKhachHangTextBox_EditValueChanged(Nothing, EventArgs.Empty)

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
                AllCustomerIDsListBox.Visible = False
                AllCustomerIDsListBox.SelectedIndex = 0
            End If

            AllCustomerIDsListBox.Visible = False
        Catch ex As Exception

        End Try
    End Sub


End Class