Imports DTO
Imports MySql.Data.MySqlClient
Public Class PHIEUTHUTIENDAO

    ''' <summary>
    ''' Insert new PhieuThuTien into database
    ''' </summary>
    ''' <param name="phieuThuTien"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function InsertPhieuThuTien(ByVal phieuThuTien As PHIEUTHUTIENDTO, Optional ByRef exception As String = "") As Boolean
        Try
            'query
            Dim query As String = String.Format("insert into PHIEUTHUTIEN values('{0}', '{1}', '{2}',
                                                (select MaKhachHang from KHACHHANG where MaKhachHang='{3}'))",
                                                phieuThuTien.MaPhieuThu, phieuThuTien.SoTienThu, phieuThuTien.NgayThuTien, phieuThuTien.MaKhachHang)
            'excute query
            Dim reader As MySqlDataReader = MYSQLCONNECTIONDAO.ExcuteQuery(query, exception)
            If (exception = "") Then Return True
        Catch ex As Exception
            exception = ex.Message
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Get new PhieuThuTien ID
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function GetNewPhieuThuTienID(Optional ByRef exception As String = "") As String
        Dim indexID As Integer = 0
        Dim newID As String = Nothing
        Try
            'excute query 
            Dim reader As MySqlDataReader = MYSQLCONNECTIONDAO.ExcuteQuery("select Max(cast(Substring(MaPhieuThu,3, length(MaPhieuThu)-2) as unsigned)) as 'MaxMaPhieuThu' from PHIEUTHUTIEN", exception)

            'get the biggest MaPhieuThuTien index in database
            If (exception = "") Then
                While reader.Read

                    If (reader.IsDBNull(0)) Then
                        Exit While
                    End If

                    indexID = Integer.Parse(reader.GetString("MaxMaPhieuThu"))

                End While

                'set newID string
                newID = "PT" & (indexID + 1).ToString("00000000")

            End If
        Catch ex As Exception
            exception = ex.Message
        End Try

        Return newID
    End Function

    ''' <summary>
    ''' Remove PhieuThuTiens by customer ID
    ''' </summary>
    ''' <param name="maKhachHang"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function RemovePhieuThuTiens(ByVal maKhachHang As String, Optional ByRef exception As String = "") As Boolean
        Try
            'query
            Dim query As String = String.Format("delete from PhieuThuTien where MaKhachHang = '{0}'", maKhachHang)
            'excute query
            MYSQLCONNECTIONDAO.ExcuteQuery(query, exception)
            If (exception = "") Then Return True
        Catch ex As Exception
            exception = ex.Message
        End Try
        Return False

    End Function

    ''' <summary>
    ''' Count PhieuThuTien
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function CountPhieuThuTiens(Optional ByRef exception As String = "") As Integer
        Dim count As Integer = Nothing
        Try
            Dim query As String = String.Format("select count(*) from PHIEUTHUTIEN")
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
