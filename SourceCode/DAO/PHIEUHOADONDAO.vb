Imports DTO
Imports MySql.Data.MySqlClient
Public Class PHIEUHOADONDAO

    ''' <summary>
    ''' Insert new PhieuHoaDon into database
    ''' </summary>
    ''' <param name="phieuHoaDon"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function InsertPhieuHoaDon(ByVal phieuHoaDon As PHIEUHOADONDTO, Optional ByRef exception As String = "") As Boolean
        Try
            'query
            Dim query As String = String.Format("insert into PHIEUHOADON values('{0}', (select MaKhachHang from KHACHHANG where MaKhachHang='{1}'),'{2}')",
                                                phieuHoaDon.MaPhieuHoaDon, phieuHoaDon.MaKhachHang, phieuHoaDon.NgayLapHoaDon.ToString)
            'excute query
            Dim reader As MySqlDataReader = MYSQLCONNECTIONDAO.ExcuteQuery(query, exception)

            If (exception = "") Then Return True
        Catch ex As Exception
            exception = ex.Message
        End Try

        Return False
    End Function

    ''' <summary>
    ''' Remove PhieuHoaDons by customer ID
    ''' </summary>
    ''' <param name="maKhachHang"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function RemovePhieuHoaDons(ByVal maKhachHang As String, Optional ByRef exception As String = "") As Boolean
        Try
            'query
            Dim query As String = String.Format("delete from PHIEUHOADON where MaKhachHang = '{0}'", maKhachHang)
            'excute query
            MYSQLCONNECTIONDAO.ExcuteQuery(query, exception)
            If (exception = "") Then Return True
        Catch ex As Exception
            exception = ex.Message
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Get new PhieuHoaDon ID
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function GetNewPhieuHoaDonID(Optional ByRef exception As String = "") As String
        Dim indexID As Integer = 0
        Dim newID As String = Nothing
        Try
            'excute query 
            Dim reader As MySqlDataReader = MYSQLCONNECTIONDAO.ExcuteQuery("select Max(cast(Substring(MaPhieuHoaDon,3, length(MaPhieuHoaDon)-2) as unsigned)) as 'MaxMaPhieuHoaDon' from PHIEUHOADON", exception)

            'get the biggest MaPhieuHoaDon index in database
            If (exception = "") Then
                While reader.Read
                    If (reader.IsDBNull(0)) Then
                        Exit While
                    End If

                    indexID = Integer.Parse(reader.GetString("MaxMaPhieuHoaDon"))

                End While

                'set newID string
                newID = "HD" & (indexID + 1).ToString("00000000")

            End If
        Catch ex As Exception
            exception = ex.Message
        End Try

        Return newID
    End Function

    ''' <summary>
    ''' Count PhieuHoaDon
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function CountPhieuHoaDons(Optional ByRef exception As String = "") As Integer
        Dim count As Integer = Nothing
        Try
            Dim query As String = String.Format("select count(*) from PHIEUHOADON")
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


End Class
