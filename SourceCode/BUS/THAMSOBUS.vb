Imports DAO
Imports DTO
Public Class THAMSOBUS

    ''' <summary>
    ''' Update ThamSo in database
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function UpdateThamSo(Optional ByRef exception As String = "") As Boolean
        If (THAMSODTO.SoLuongNhapToiThieu < 0 Or THAMSODTO.SoLuongTonToiDaTruocNhap < 0 Or
            THAMSODTO.SoLuongTonToiThieuSauBan < 0 Or THAMSODTO.SoTienNoToiDa < 0) Then
            exception = "Giá trị tham số không được phép nhỏ hơn 0"
            Return False
        End If
        Return THAMSODAO.UpdateThamSo(exception)
    End Function

    ''' <summary>
    ''' Set ThamSo to ThamSoDTO (get the new ThamSo for ThamSoDTO)
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function GetThamSo(Optional ByRef exception As String = "") As Boolean
        Return THAMSODAO.GetThamSo(exception)
    End Function

End Class
