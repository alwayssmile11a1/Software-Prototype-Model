Imports BUS
Imports DTO

Public Class THAYDOIQUYDINHGUI

    Public Shared GUI As New THAYDOIQUYDINHGUI

    Private Sub THAYDOIQUYDINHGUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'a variable to store exception
        Dim ex As String = ""

        'Get thamso's information
        'This function will update arguments SoLuongNhapToiThieu, SoLuongTonSauToiThieu, ...
        THAMSOBUS.GetThamSo(ex)

        'if there is exception
        If (ex <> "") Then
            MessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        'Set the text in text boxes by thamso's information
        SoLuongNhapItNhatTextBox.Text = THAMSODTO.SoLuongNhapToiThieu.ToString
        LuongTonToiThieuSauBanTextBox.Text = THAMSODTO.SoLuongTonToiThieuSauBan.ToString
        SoLuongTonToiDaTruocKhiNhapTextBox.Text = THAMSODTO.SoLuongTonToiDaTruocNhap.ToString
        TienNoToiDaTextBox.Text = THAMSODTO.SoTienNoToiDa.ToString("c0")
        SuDungQuyDinh4CheckBox.Checked = THAMSODTO.SuDungQuyDinh4

    End Sub

    Private Sub ApplyButton_Click(sender As Object, e As EventArgs) Handles ApplyButton.Click
        'if there is nothing in any text boxes 
        If (SoLuongNhapItNhatTextBox.Text = "" Or LuongTonToiThieuSauBanTextBox.Text = "" Or SoLuongTonToiDaTruocKhiNhapTextBox.Text = "" Or TienNoToiDaTextBox.Text = "") Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Xin hãy điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        'store exception
        Dim ex As String = ""

        'we have to save the old ThamSo for sure
        'if we didn't save that and exception occur, we have to revert them
        Dim oldSoLuongNhapToiThieu As Integer = THAMSODTO.SoLuongNhapToiThieu
        Dim oldSoLuongTonSauToiThieu As Integer = THAMSODTO.SoLuongTonToiThieuSauBan
        Dim oldSoLuongTonToiDaTruocNhap As Integer = THAMSODTO.SoLuongTonToiDaTruocNhap
        Dim oldSoTienNoToiDa As Decimal = THAMSODTO.SoTienNoToiDa
        Dim oldSuDungQuyDinh4 As Boolean = THAMSODTO.SuDungQuyDinh4

        'set thamso's information
        THAMSODTO.SoLuongNhapToiThieu = Integer.Parse(SoLuongNhapItNhatTextBox.Text)
        THAMSODTO.SoLuongTonToiThieuSauBan = Integer.Parse(LuongTonToiThieuSauBanTextBox.Text)
        THAMSODTO.SoLuongTonToiDaTruocNhap = Integer.Parse(SoLuongTonToiDaTruocKhiNhapTextBox.Text)
        THAMSODTO.SoTienNoToiDa = Decimal.Parse(TienNoToiDaTextBox.Text, Globalization.NumberStyles.Currency)
        THAMSODTO.SuDungQuyDinh4 = SuDungQuyDinh4CheckBox.Checked

        'Update ThamSo
        THAMSOBUS.UpdateThamSo(ex)

        'if there is exception, show it
        If (ex <> "") Then
            DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Revert
            THAMSODTO.SoLuongNhapToiThieu = oldSoLuongNhapToiThieu
            THAMSODTO.SoLuongTonToiThieuSauBan = oldSoLuongTonSauToiThieu
            THAMSODTO.SoLuongTonToiDaTruocNhap = oldSoLuongTonToiDaTruocNhap
            THAMSODTO.SoTienNoToiDa = oldSoTienNoToiDa
            THAMSODTO.SuDungQuyDinh4 = oldSuDungQuyDinh4

            'Update ThamSo again
            THAMSOBUS.UpdateThamSo(ex)
            Return
        End If

        'show success message
        MessageBox.Show("Cập nhật thành công", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'Do this to immediately show the things have changed
        LAPPHIEUNHAPSACHGUI.GUI.RefreshGUI()
        LAPHOADONBANSACHGUI.GUI.RefreshGUI()

    End Sub

    Private Sub TienNoToiDaTextBox_Leave(sender As Object, e As EventArgs) Handles TienNoToiDaTextBox.Leave
        TienNoToiDaTextBox.Text = TienNoToiDaTextBox.Text
    End Sub

End Class