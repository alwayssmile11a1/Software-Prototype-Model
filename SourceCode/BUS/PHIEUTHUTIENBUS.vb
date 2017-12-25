Imports DTO
Imports DAO
Public Class PHIEUTHUTIENBUS

    ''' <summary>
    ''' Insert new PhieuThuTien into database
    ''' </summary>
    ''' <param name="phieuThuTien"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function InsertPhieuThuTien(ByVal phieuThuTien As PHIEUTHUTIENDTO, Optional ByRef exception As String = "") As Boolean
        Return PHIEUTHUTIENDAO.InsertPhieuThuTien(phieuThuTien, exception)
    End Function

    ''' <summary>
    ''' Remove PhieuThuTiens by customer ID
    ''' </summary>
    ''' <param name="maKhachHang"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function RemovePhieuThuTiens(ByVal maKhachHang As String, Optional ByRef exception As String = "") As Boolean
        Return PHIEUTHUTIENDAO.RemovePhieuThuTiens(maKhachHang, exception)

    End Function

    ''' <summary>
    ''' Get new PhieuThuTien ID
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function GetNewPhieuThuTienID(Optional ByRef exception As String = "") As String
        Return PHIEUTHUTIENDAO.GetNewPhieuThuTienID(exception)
    End Function

    ''' <summary>
    ''' Count PhieuThuTien
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function CountPhieuThuTiens(Optional ByRef exception As String = "") As Integer
        Return PHIEUTHUTIENDAO.CountPhieuThuTiens(exception)
    End Function


End Class
