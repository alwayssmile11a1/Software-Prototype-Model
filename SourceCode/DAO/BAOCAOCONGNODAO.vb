Imports MySql.Data.MySqlClient
Imports DTO
Public Class BAOCAOCONGNODAO

#Region "Find"

    ''' <summary>
    ''' Find baocaocongno by thang and nam and maSach
    ''' </summary>
    ''' <param name="thang"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function FindBaoCaoCongNo(ByVal thang As Integer, ByVal nam As Integer, Optional ByRef exception As String = "") As BAOCAOCONGNODTO
        'a variable to store BaoCaoTon we found out
        Dim baoCaoCongNo As BAOCAOCONGNODTO = Nothing
        Try
            'query
            Dim query As String = String.Format("select* from BAOCAOCONGNO where Thang = '{0}' and Nam = '{1}'", thang, nam)

            'excute reader in MySQL
            Dim reader As MySqlDataReader = MYSQLCONNECTIONDAO.ExcuteQuery(query, exception)

            'If there is no exception
            If (exception = "") Then
                'get BaoCaoCongNo
                While reader.Read
                    baoCaoCongNo = New BAOCAOCONGNODTO(reader.GetString("MaBaoCaoCongNo"), reader.GetString("Thang"), reader.GetString("Nam"))
                End While
            End If

        Catch ex As Exception 'If there is exception
            exception = ex.Message
        End Try

        'return 
        Return baoCaoCongNo

    End Function

#End Region

#Region "Insert, Update"

    ''' <summary>
    ''' Insert a new BaoCaoCongNo when a new customer is inserted
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function InsertBaoCaoCongNo(ByVal baoCaoCongNo As BAOCAOCONGNODTO, Optional ByRef exception As String = "") As Boolean
        Try
            'query
            Dim query As String = String.Format("insert into BAOCAOCONGNO values('{0}', '{1}', '{2}')",
                                                baoCaoCongNo.MaBaoCaoCongNo, baoCaoCongNo.Thang, baoCaoCongNo.Nam)
            'excute query
            MYSQLCONNECTIONDAO.ExcuteQuery(query, exception)

            'if there is no exception, it means everything seems ok just now
            If (exception = "") Then Return True

        Catch ex As Exception
            exception = ex.Message
        End Try

        Return False
    End Function

    ''' <summary>
    ''' Remove BaoCaoCongNos by customer ID
    ''' </summary>
    ''' <param name="maKhachHang"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function RemoveBaoCaoCongNos(ByVal maKhachHang As String, Optional ByRef exception As String = "") As Boolean
        Try
            'query
            Dim query As String = String.Format("delete from BAOCAOCONGNO where MaKhachHang = '{0}'", maKhachHang)
            'excute query
            MYSQLCONNECTIONDAO.ExcuteQuery(query, exception)

            'if there is no exception, it means everything seems ok just now
            If (exception = "") Then Return True

        Catch ex As Exception
            exception = ex.Message
        End Try

        Return False
    End Function

#End Region

#Region "Some other functions"

    ''' <summary>
    ''' get new BaoCaoCongNo ID
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function GetNewBaoCaoCongNoID(Optional ByRef exception As String = "") As String

        Dim indexID As Integer = 0
        Dim newID As String = Nothing
        Try
            'excute query 
            Dim reader As MySqlDataReader = MYSQLCONNECTIONDAO.ExcuteQuery("select Max(cast(Substring(MaBaoCaoCongNo,3, length(MaBaoCaoCongNo)-2) as unsigned)) as 'MaxMaBaoCaoCongNo' from BAOCAOCONGNO", exception)

            'get the biggest MaChiTietTon index in database
            If (exception = "") Then
                While reader.Read
                    If (reader.IsDBNull(0)) Then
                        Exit While
                    End If

                    indexID = Integer.Parse(reader.GetString("MaxMaBaoCaoCongNo"))

                End While

                'set newID string
                newID = "BN" & (indexID + 1).ToString("00000000")

            End If

        Catch ex As Exception
            exception = ex.Message
        End Try

        'return new ID
        Return newID
    End Function

    ''' <summary>
    ''' Count the number of BaoCaoCongNo in database
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function CountBaoCaoCongNos(Optional ByRef exception As String = "") As Integer
        Dim count As Integer = Nothing

        Try
            Dim query As String = String.Format("select count(*) from BAOCAOCONGNO")
            Dim reader As MySqlDataReader = MYSQLCONNECTIONDAO.ExcuteQuery(query, exception)
            If (exception = "") Then
                While reader.Read
                    count = reader.GetString("count(*)")
                End While
            End If
        Catch ex As Exception
            exception = ex.Message
        End Try
        Return count

    End Function

#End Region

End Class
