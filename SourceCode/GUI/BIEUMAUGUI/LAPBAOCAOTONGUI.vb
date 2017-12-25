Imports DTO
Imports BUS
Public Class LAPBAOCAOTONGUI

    Public Shared GUI As New LAPBAOCAOTONGUI

    Private Sub LAPBAOCAOTONGUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'set up DateTimePicker
        ThangLapBaoCaoDateTimePicker.Format = DateTimePickerFormat.Custom
        ThangLapBaoCaoDateTimePicker.CustomFormat = "MMMM yyyy"
        ThangLapBaoCaoDateTimePicker.ShowUpDown = True

        progressBarControl.Visible = False

    End Sub

    Private Sub LapBaoCaoButton_Click(sender As Object, e As EventArgs) Handles LapBaoCaoButton.Click
        'Store exception
        Dim ex As String = ""

        'Get DataTable
        Dim dataTable As DataTable = CHITIETTONBUS.SearchAllUnRemovedChiTietTons(ThangLapBaoCaoDateTimePicker.Value.Month, ThangLapBaoCaoDateTimePicker.Value.Year, ex)

        If (ex <> "") Then
            DevExpress.XtraEditors.XtraMessageBox.Show(ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        'add column STT
        Dim sTTColumn As DataColumn = New DataColumn("STT")
        dataTable.Columns.Add(sTTColumn)
        sTTColumn.SetOrdinal(0)

        'set value of cells of column STT
        For index As Integer = 0 To dataTable.Rows.Count - 1
            dataTable.Rows.Item(index).Item("STT") = index + 1
        Next

        LapBaoCaoTonGridControl.DataSource = dataTable

        DevExpress.XtraEditors.XtraMessageBox.Show("Lập báo cáo thành công", "THÀNH CÔNG", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub XuatFileExelButton_Click(sender As Object, e As EventArgs) Handles XuatFileExelButton.Click

        'Set Filter being displayed 
        SaveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"

        'If user presses OK
        If (SaveDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            progressBarControl.Visible = True
            UseWaitCursor = True
            Me.Enabled = False
            BackgroundWorker.WorkerReportsProgress = True
            BackgroundWorker.RunWorkerAsync()
        End If
    End Sub

    Private Sub backgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker.DoWork

        'report progress percent
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

            'Excel index starts from 1,1. As first Row would have the Column headers
            For iColumn As Integer = 1 To LapBaoCaoTonGridView.Columns.Count
                worksheet.Cells(1, iColumn) = LapBaoCaoTonGridView.Columns(iColumn - 1).FieldName

                'report progress
                reportProgressPercent = reportProgressPercent + 1
                BackgroundWorker.ReportProgress(reportProgressPercent)
            Next

            'Set the value for remaining row of worksheet by the value being presented in GridView 
            For iRow As Integer = 0 To LapBaoCaoTonGridView.RowCount - 1
                'get current row
                Dim selectedRow As DataRow = LapBaoCaoTonGridView.GetDataRow(LapBaoCaoTonGridView.GetRowHandle(iRow))

                'loop through all columns
                For iColumn As Integer = 1 To LapBaoCaoTonGridView.Columns.Count

                    'As the saying above, Excel index starts from 1,1
                    'So the next row has the index of (2, iColumn)
                    worksheet.Cells(iRow + 2, iColumn) = selectedRow(iColumn - 1).ToString()

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

            excel.Quit()

        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
        Finally
            workbook.Close()
            excel.Quit()
            workbook = Nothing
            excel = Nothing
            GC.Collect()
        End Try
    End Sub

    Private Sub backgroundWorker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker.ProgressChanged
        progressBarControl.EditValue = e.ProgressPercentage
        progressBarControl.Text = progressBarControl.EditValue.ToString()
    End Sub

    Private Sub backgroundWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker.RunWorkerCompleted
        Me.Enabled = True
        UseWaitCursor = False
        progressBarControl.Visible = False
    End Sub

End Class