Imports DTO
Imports DAO
Public Class CHITIETPHIEUNHAPBUS

    ''' <summary>
    ''' Insert new ChiTietPhieuNhap into database
    ''' </summary>
    ''' <param name="chiTietPhieuNhap"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function InsertChiTietPhieuNhap(ByVal chiTietPhieuNhap As CHITIETPHIEUNHAPDTO, Optional ByRef exception As String = "") As Boolean
        Return CHITIETPHIEUNHAPDAO.InsertChiTietPhieuNhap(chiTietPhieuNhap, exception)
    End Function

    ''' <summary>
    ''' Get new ChiTietPhieuNhap ID
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function GetNewChiTietPhieuNhapID(Optional ByRef exception As String = "") As String
        Return CHITIETPHIEUNHAPDAO.GetNewChiTietPhieuNhapID(exception)
    End Function

    ''' <summary>
    ''' Remove ChiTietPhieuNhaps by MaSach 
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function RemoveChiTietPhieuNhaps(ByVal maSach As String, Optional ByRef exception As String = "") As Boolean
        Return CHITIETPHIEUNHAPDAO.RemoveChiTietPhieuNhaps(maSach, exception)
    End Function

    ''' <summary>
    ''' Count ChiTietPhieuNhap
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function CountChiTietPhieuNhap(Optional ByRef exception As String = "") As Integer
        Return CHITIETPHIEUHOADONDAO.CountChiTietPhieuHoaDons(exception)
    End Function

End Class
