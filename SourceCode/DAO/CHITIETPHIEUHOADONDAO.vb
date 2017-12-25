Imports DTO
Imports MySql.Data.MySqlClient

Public Class CHITIETPHIEUHOADONDAO

    ''' <summary>
    ''' Insert new ChiTietPhieuHoaDon into database
    ''' </summary>
    ''' <param name="chiTietPhieuHoaDon"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function InsertChiTietPhieuHoaDon(ByVal chiTietPhieuHoaDon As CHITIETPHIEUHOADONDTO, Optional ByRef exception As String = "") As Boolean
        Try
            'query
            Dim query As String = String.Format("insert into CHITIETPHIEUHD values('{0}', (select MaPhieuHoaDon from PHIEUHOADON where MaPhieuHoaDon='{1}'),
                                                (select MaSach from SACH where MaSach='{2}'),'{3}')", chiTietPhieuHoaDon.MaChiTietPhieuHoaDon,
                                                chiTietPhieuHoaDon.MaPhieuHoaDon, chiTietPhieuHoaDon.MaSach, chiTietPhieuHoaDon.SoLuongBan)
            'excute query
            MYSQLCONNECTIONDAO.ExcuteQuery(query, exception)
            If (exception = "") Then Return True
        Catch ex As Exception
            exception = ex.Message
        End Try
        Return False

    End Function

    ''' <summary>
    ''' Remove ChiTietPhieuHoaDons by book ID
    ''' </summary>
    ''' <param name="maSach"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function RemoveChiTietPhieuHDsByBookID(ByVal maSach As String, Optional ByRef exception As String = "") As Boolean
        Try
            'query
            Dim query As String = String.Format("delete from CHITIETPHIEUHD where MaSach = '{0}'", maSach)
            'excute query
            MYSQLCONNECTIONDAO.ExcuteQuery(query, exception)
            If (exception = "") Then Return True
        Catch ex As Exception
            exception = ex.Message
        End Try
        Return False

    End Function

    ''' <summary>
    ''' Get new ChiTietPhieuHoaDon ID
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function GetNewChiTietPhieuHoaDonID(Optional ByRef exception As String = "") As String
        Dim indexID As Integer = 0
        Dim newID As String = Nothing
        Try
            'excute query 
            Dim reader As MySqlDataReader = MYSQLCONNECTIONDAO.ExcuteQuery("select Max(cast(Substring(MaChiTietPhieuHoaDon,3, length(MaChiTietPhieuHoaDon)-2) as unsigned)) as 'MaxMaChiTietPhieuHoaDon' from CHITIETPHIEUHD", exception)

            'get the biggest MaChiTietPhieuHoa index in database
            If (exception = "") Then
                While reader.Read
                    If (reader.IsDBNull(0)) Then
                        Exit While
                    End If

                    indexID = Integer.Parse(reader.GetString("MaxMaChiTietPhieuHoaDon"))

                End While

            'set newID string
            newID = "CH" & (indexID + 1).ToString("00000000")

            End If
        Catch ex As Exception
            exception = ex.Message
        End Try

        Return newID
    End Function

    ''' <summary>
    ''' Count ChiTietPhieuHoaDon
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function CountChiTietPhieuHoaDons(Optional ByRef exception As String = "") As Integer
        Dim count As Integer = Nothing
        Try
            Dim query As String = String.Format("select count(*) from CHITIETPHIEUHD")
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
