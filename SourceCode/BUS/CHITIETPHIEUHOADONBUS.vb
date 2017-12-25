Imports DTO
Imports DAO
Public Class CHITIETPHIEUHOADONBUS

    ''' <summary>
    ''' Insert new ChiTietPhieuHoaDon into database
    ''' </summary>
    ''' <param name="chiTietPhieuHoaDon"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function InsertChiTietPhieuHoaDon(ByVal chiTietPhieuHoaDon As CHITIETPHIEUHOADONDTO, Optional ByRef exception As String = "") As Boolean
        Return CHITIETPHIEUHOADONDAO.InsertChiTietPhieuHoaDon(chiTietPhieuHoaDon, exception)

    End Function

    ''' <summary>
    ''' Remove ChiTietPhieuHoaDons by book ID
    ''' </summary>
    ''' <param name="maSach"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function RemoveChiTietPhieuHDsByBookID(ByVal maSach As String, Optional ByRef exception As String = "") As Boolean
        Return CHITIETPHIEUHOADONDAO.RemoveChiTietPhieuHDsByBookID(maSach, exception)

    End Function

    ''' <summary>
    ''' Get new ChiTietPhieuHoaDon ID
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function GetNewChiTietPhieuHoaDonID(Optional ByRef exception As String = "") As String
        Return CHITIETPHIEUHOADONDAO.GetNewChiTietPhieuHoaDonID(exception)
    End Function

    ''' <summary>
    ''' Count ChiTietPhieuHoaDon
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function CountChiTietPhieuHoaDons(Optional ByRef exception As String = "") As Integer
        Return CHITIETPHIEUHOADONDAO.CountChiTietPhieuHoaDons(exception)
    End Function

End Class
