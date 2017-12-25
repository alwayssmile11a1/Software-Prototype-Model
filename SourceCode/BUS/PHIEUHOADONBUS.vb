Imports DTO
Imports DAO
Public Class PHIEUHOADONBUS

    ''' <summary>
    ''' Insert new PhieuHoaDon into database
    ''' </summary>
    ''' <param name="phieuHoaDon"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function InsertPhieuHoaDon(ByVal phieuHoaDon As PHIEUHOADONDTO, Optional ByRef exception As String = "") As Boolean
        Return PHIEUHOADONDAO.InsertPhieuHoaDon(phieuHoaDon, exception)
    End Function

    ''' <summary>
    ''' Get new PhieuHoaDon ID
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function GetNewPhieuHoaDonID(Optional ByRef exception As String = "") As String
        Return PHIEUHOADONDAO.GetNewPhieuHoaDonID(exception)
    End Function

    ''' <summary>
    ''' Remove PhieuHoaDons by customer ID
    ''' </summary>
    ''' <param name="maKhachHang"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function RemovePhieuHoaDons(ByVal maKhachHang As String, Optional ByRef exception As String = "") As Boolean
        Return PHIEUHOADONDAO.RemovePhieuHoaDons(maKhachHang, exception)

    End Function

    ''' <summary>
    ''' Count PhieuHoaDon
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function CountPhieuHoaDons(Optional ByRef exception As String = "") As Integer
        Return PHIEUHOADONDAO.CountPhieuHoaDons(exception)
    End Function

End Class
