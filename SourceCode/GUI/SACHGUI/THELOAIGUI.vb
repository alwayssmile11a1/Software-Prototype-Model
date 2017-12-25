Imports BUS
Imports DTO
Public Class THELOAIGUI


    Private Sub THELOAIGUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim ex As String = ""

        Dim dataTable As DataTable = THELOAIBUS.FindAllTheLoais(ex)
        If (ex <> "") Then
            'Show exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            TheLoaiGridControl.DataSource = dataTable
        End If

        MaTheLoaiTextBox.ReadOnly = True

    End Sub

    Private Sub MaTheLoaiMoiButton_Click(sender As Object, e As EventArgs) Handles MaTheLoaiMoiButton.Click
        Dim ex As String = ""

        MaTheLoaiTextBox.Text = THELOAIBUS.GetNewPhieuNhapID(ex)

        If (ex <> "") Then
            'Show exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If

    End Sub

    Private Sub DongYThemButton_Click(sender As Object, e As EventArgs) Handles DongYThemButton.Click

        If (TenTheLoaiTextBox.Text = "" Or MaTheLoaiTextBox.Text = "") Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Xin hãy nhập đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        'show safe dialog
        Dim result As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Bạn có chắc chắn muốn thêm không? ", "Cẩn Thận!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If (result = DialogResult.No) Then
            Return
        End If

        Dim ex As String = ""

        THELOAIBUS.InsertTheLoai(New THELOAIDTO(MaTheLoaiTextBox.Text, TenTheLoaiTextBox.Text), ex)

        If (ex <> "") Then
            'Show exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MaTheLoaiTextBox.Text = THELOAIBUS.GetNewPhieuNhapID(ex)
            TenTheLoaiTextBox.Text = ""
            DevExpress.XtraEditors.XtraMessageBox.Show("Thêm thành công", "THÀNH CÔNG", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Dim dataTable As DataTable = THELOAIBUS.FindAllTheLoais(ex)
        If (ex <> "") Then
            'Show exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            TheLoaiGridControl.DataSource = dataTable
        End If

    End Sub

    Private Sub XoaTheLoaiButton_Click(sender As Object, e As EventArgs) Handles XoaTheLoaiButton.Click
        Dim selectedRow As DataRow = TheLoaiGridView.GetDataRow(TheLoaiGridView.FocusedRowHandle)

        If (selectedRow Is Nothing) Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Xin hãy chọn một dòng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        'show safe dialog
        Dim result As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Bạn có chắc chắn muốn xóa không? ", "Cẩn Thận!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If (result = DialogResult.No) Then
            Return
        End If

        Dim ex As String = ""

        THELOAIBUS.RemoveTheLoai(selectedRow("Mã Thể Loại").ToString(), ex)

        If (ex <> "") Then
            'Show exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show("Xóa thành công", "THÀNH CÔNG", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Dim dataTable As DataTable = THELOAIBUS.FindAllTheLoais(ex)
        If (ex <> "") Then
            'Show exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            TheLoaiGridControl.DataSource = dataTable
        End If

    End Sub
End Class