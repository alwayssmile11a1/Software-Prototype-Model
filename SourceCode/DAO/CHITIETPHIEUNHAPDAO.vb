Imports MySql.Data.MySqlClient
Imports DTO

Public Class CHITIETPHIEUNHAPDAO

    ''' <summary>
    ''' Insert new ChiTietPhieuNhap into database
    ''' </summary>
    ''' <param name="chiTietPhieuNhap"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function InsertChiTietPhieuNhap(ByVal chiTietPhieuNhap As CHITIETPHIEUNHAPDTO, Optional ByRef exception As String = "") As Boolean
        Try
            'query
            Dim query As String = String.Format("insert into CHITIETPHIEUNHAP values('{0}',
                                                (select MaPhieuNhap from PHIEUNHAP where MaPhieuNhap='{1}'),
                                                (select MaSach from SACH where MaSach='{2}'),'{3}')",
                                                chiTietPhieuNhap.MaChiTietPhieuNhap, chiTietPhieuNhap.MaPhieuNhap,
                                                chiTietPhieuNhap.MaSach, chiTietPhieuNhap.SoLuongNhap)
            'excute query
            MYSQLCONNECTIONDAO.ExcuteQuery(query, exception)
            If (exception = "") Then Return True
        Catch ex As Exception
            exception = ex.Message
        End Try

        Return False
    End Function

    ''' <summary>
    ''' Get new ChiTietPhieuNhap ID
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function GetNewChiTietPhieuNhapID(Optional ByRef exception As String = "") As String
        Dim indexID As Integer = 0
        Dim newID As String = Nothing
        Try
            'excute query 
            Dim reader As MySqlDataReader = MYSQLCONNECTIONDAO.ExcuteQuery("select Max(cast(Substring(MaChiTietPhieuNhap,3, length(MaChiTietPhieuNhap)-2) as unsigned)) as 'MaxMaChiTietPhieuNhap' from CHITIETPHIEUNHAP", exception)

            'get the biggest MaChiTietPhieuNhap index in database
            If (exception = "") Then
                While reader.Read
                    If (reader.IsDBNull(0)) Then
                        Exit While
                    End If

                    indexID = Integer.Parse(reader.GetString("MaxMaChiTietPhieuNhap"))

                End While

                'set newID string
                newID = "CN" & (indexID + 1).ToString("00000000")

            End If
        Catch ex As Exception
            exception = ex.Message
        End Try

        Return newID
    End Function

    ''' <summary>
    ''' Remove ChiTietPhieuNhaps by MaSach 
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function RemoveChiTietPhieuNhaps(ByVal maSach As String, Optional ByRef exception As String = "") As Boolean
        Try
            'query
            Dim query As String = String.Format("delete from CHITIETPHIEUNHAP where MaSach = '{0}'", maSach)

            'excute query
            MYSQLCONNECTIONDAO.ExcuteQuery(query, exception)

            If (exception = "") Then Return True
        Catch ex As Exception
            exception = ex.Message
        End Try

        Return False
    End Function

    ''' <summary>
    ''' Count ChiTietPhieuNhap
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function CountChiTietPhieuNhaps(Optional ByRef exception As String = "") As Integer
        Dim count As Integer = Nothing
        Try
            Dim query As String = String.Format("select count(*) from CHITIETPHIEUNHAP")
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
