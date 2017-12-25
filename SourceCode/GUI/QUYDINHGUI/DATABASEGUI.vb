Imports BUS
Public Class DATABASEGUI

    Public Shared GUI As New DATABASEGUI

    Private Sub DATABASEGUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ServerTextBox.Text = "localhost"
        DatabaseNameTextBox.Text = "bookmanagementdatabase"
        PasswordTextBox.Properties.PasswordChar = "*"c
        PasswordTextBox.Text = "son11son"
        UserTextBox.Text = "root"


    End Sub

    Private Sub KetNoiButton_Click(sender As Object, e As EventArgs) Handles KetNoiButton.Click
        Dim ex As String = ""

        'Connect to database
        MYSQLCONNECTIONBUS.ConnectToDatabase(ServerTextBox.Text, UserTextBox.Text, PasswordTextBox.Text, DatabaseNameTextBox.Text, ex)

        If (ex <> "") Then
            DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show("Kết nối thành công", "THÀNH CÔNG", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

End Class