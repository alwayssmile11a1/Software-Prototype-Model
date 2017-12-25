
Imports DTO
Imports DAO

Public Class CHITIETCONGNOBUS
#Region "Find"

    ''' <summary>
    ''' Find chitietcongno by Mabaocaocongno and makhachhang
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function FindChiTietCongNo(ByVal maBaoCaoCongNo As String, ByVal maKhachHang As String, Optional ByRef exception As String = "") As CHITIETCONGNODTO
        Return CHITIETCONGNODAO.FindChiTietCongNo(maBaoCaoCongNo, maKhachHang, exception)

    End Function

    ''' <summary>
    ''' Find ChiTietCongNos by thang and nam
    ''' </summary>
    ''' <param name="thang"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function SearchAllUnRemovedChiTietCongNos(ByVal thang As Integer, ByVal nam As Integer, Optional ByRef exception As String = "") As DataTable
        Return CHITIETCONGNODAO.SearchAllUnRemovedChiTietCongNos(thang, nam, exception)

    End Function

#End Region

#Region "Insert, Update, Delete"

    ''' <summary>
    ''' Insert a new ChiTietCongNo
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function InsertChiTietCongNo(ByVal maBaoCaoCongNo As String, ByVal maKhachHang As String, Optional ByRef exception As String = "") As Boolean
        Return CHITIETCONGNODAO.InsertChiTietCongNo(maBaoCaoCongNo, maBaoCaoCongNo, exception)

    End Function

    ''' <summary>
    ''' Update BaoCaoCongNo
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function UpdateChiTietCongNo(ByVal thang As Integer, ByVal nam As Integer, ByVal maKhachHang As String, ByVal soTien As Decimal, Optional ByRef exception As String = "") As Boolean

        Return CHITIETCONGNODAO.UpdateChiTietCongNo(thang, nam, maKhachHang, soTien, exception)

    End Function


#End Region

#Region "Some other functions"

    ''' <summary>
    ''' get new ChiTietCongNo ID
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function GetNewChiTietCongNoID(Optional ByRef exception As String = "") As String

        Return CHITIETCONGNODAO.GetNewChiTietCongNoID(exception)
    End Function


#End Region
End Class
