Imports DTO
Imports DAO
Public Class PHIEUNHAPBUS

    ''' <summary>
    ''' Insert new PhieuNhap into database
    ''' </summary>
    ''' <param name="phieuNhap"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function InsertPhieuNhap(ByVal phieuNhap As PHIEUNHAPDTO, Optional ByRef exception As String = "") As Boolean
        Return PHIEUNHAPDAO.InsertPhieuNhap(phieuNhap, exception)
    End Function

    ''' <summary>
    ''' Get new PhieuNhap ID
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function GetNewPhieuNhapID(Optional ByRef exception As String = "") As String
        Return PHIEUNHAPDAO.GetNewPhieuNhapID(exception)
    End Function

    ''' <summary>
    ''' Count PhieuNhap
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function CountPhieuNhap(Optional ByRef exception As String = "") As Integer
        Return PHIEUNHAPDAO.CountPhieuNhaps(exception)
    End Function


End Class
