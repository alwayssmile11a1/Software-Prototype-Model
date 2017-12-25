Imports DAO
Imports DTO

Public Class BAOCAOTONBUS

#Region "Find"

    ''' <summary>
    ''' Find baocaoton by thang and nam and maSach
    ''' </summary>
    ''' <param name="thang"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function FindBaoCaoTon(ByVal thang As Integer, ByVal nam As Integer, Optional ByRef exception As String = "") As BAOCAOTONDTO
        Return BAOCAOTONDAO.FindBaoCaoTon(thang, nam, exception)

    End Function

#End Region

#Region "Insert, Update, Delete"

    ''' <summary>
    ''' Insert a new BaoCaoTon when a new book is inserted
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function InsertBaoCaoTon(ByVal baoCaoTon As BAOCAOTONDTO, Optional ByRef exception As String = "") As Boolean
        Return BAOCAOTONDAO.InsertBaoCaoTon(baoCaoTon, exception)
    End Function

#End Region

#Region "Some other functions"

    ''' <summary>
    ''' get new BaoCaoTon ID
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function GetNewBaoCaoTonID(Optional ByRef exception As String = "") As String

        Return BAOCAOTONDAO.GetNewBaoCaoTonID(exception)
    End Function

#End Region

End Class
