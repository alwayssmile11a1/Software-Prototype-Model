Imports DAO
Imports DTO
Public Class THELOAIBUS

    ''' <summary>
    ''' Insert new TheLoai into database
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function InsertTheLoai(ByVal theLoai As THELOAIDTO, Optional ByRef exception As String = "") As Boolean
        Return THELOAIDAO.InsertTheLoai(theLoai, exception)

    End Function

    ''' <summary>
    ''' Get new TheLoai ID
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function GetNewPhieuNhapID(Optional ByRef exception As String = "") As String
        Return THELOAIDAO.GetNewPhieuNhapID(exception)
    End Function

    ''' <summary>
    ''' Remove TheLoai 
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function RemoveTheLoai(ByVal maTheLoai As String, Optional ByRef exception As String = "") As Boolean
        Return THELOAIDAO.RemoveTheLoai(maTheLoai, exception)

    End Function

    ''' <summary>
    ''' Find all TheLoais into database
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function FindAllTheLoais(Optional ByRef exception As String = "") As DataTable
        Return THELOAIDAO.FindAllTheLoais(exception)
    End Function

End Class
