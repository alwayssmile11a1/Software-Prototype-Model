Imports DTO
Imports DAO
Public Class CHITIETTONBUS

#Region "Find"

    ''' <summary>
    ''' Find chitietton by MaBaoCaoTon and maSach
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function FindChiTietTon(ByVal maBaoCaoTon As String, ByVal maSach As String, Optional ByRef exception As String = "") As CHITIETTONDTO
        Return CHITIETTONDAO.FindChiTietTon(maBaoCaoTon, maBaoCaoTon, exception)

    End Function

    ''' <summary>
    ''' Find ChiTietTons by thang and nam
    ''' </summary>
    ''' <param name="thang"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function SearchAllUnRemovedChiTietTons(ByVal thang As Integer, ByVal nam As Integer, Optional ByRef exception As String = "") As DataTable
        Return CHITIETTONDAO.SearchAllUnRemovedChiTietTons(thang, nam, exception)
    End Function

#End Region

#Region "Insert, Update, Delete"

    ''' <summary>
    ''' Insert a new ChiTietTon
    ''' </summary>
    ''' <param name="maSach"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function InsertChiTietTon(ByVal maBaoCaoTon As String, ByVal maSach As String, Optional ByRef exception As String = "") As Boolean

        Return CHITIETTONDAO.InsertChiTietTon(maBaoCaoTon, maBaoCaoTon, exception)
    End Function

    ''' <summary>
    ''' Update BaoCaoTon when do LapPhieuNhapSach or LapHoaDonBanSach
    ''' </summary>
    ''' <param name="maSach"></param>
    ''' <param name="soLuong"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function UpdateChiTietTon(ByVal thang As Integer, ByVal nam As Integer, ByVal maSach As String, ByVal soLuong As Integer, Optional ByRef exception As String = "") As Boolean

        Return CHITIETTONDAO.UpdateChiTietTon(thang, nam, maSach, soLuong, exception)

    End Function

#End Region

#Region "Some other functions"

    ''' <summary>
    ''' get new ChiTietTon ID
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function GetNewChiTietTonID(Optional ByRef exception As String = "") As String

        Return CHITIETTONDAO.GetNewChiTietTonID(exception)
    End Function


#End Region

End Class
