Imports DAO
Imports DTO
Public Class BAOCAOCONGNOBUS

#Region "Find"

    ''' <summary>
    ''' Find baocaocongno by thang and nam and maSach
    ''' </summary>
    ''' <param name="thang"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function FindBaoCaoCongNo(ByVal thang As Integer, ByVal nam As Integer, Optional ByRef exception As String = "") As BAOCAOCONGNODTO
        Return BAOCAOCONGNODAO.FindBaoCaoCongNo(thang, nam, exception)

    End Function

#End Region

#Region "Insert, Update"

    ''' <summary>
    ''' Insert a new BaoCaoCongNo when a new customer is inserted
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function InsertBaoCaoCongNo(ByVal baoCaoCongNo As BAOCAOCONGNODTO, Optional ByRef exception As String = "") As Boolean
        Return BAOCAOCONGNODAO.InsertBaoCaoCongNo(baoCaoCongNo, exception)
    End Function

#End Region

#Region "Some other functions"

    ''' <summary>
    ''' get new BaoCaoCongNo ID
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function GetNewBaoCaoCongNoID(Optional ByRef exception As String = "") As String

        Return BAOCAOCONGNODAO.GetNewBaoCaoCongNoID(exception)
    End Function


#End Region

End Class
