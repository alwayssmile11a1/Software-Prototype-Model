Imports DTO
Imports MySql.Data.MySqlClient
Public Class PHIEUNHAPDAO

    ''' <summary>
    ''' Insert new PhieuNhap into database
    ''' </summary>
    ''' <param name="phieuNhap"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function InsertPhieuNhap(ByVal phieuNhap As PHIEUNHAPDTO, Optional ByRef exception As String = "") As Boolean
        Try
            'query
            Dim query As String = String.Format("insert into PHIEUNHAP values('{0}','{1}')", phieuNhap.MaPhieuNhap, phieuNhap.NgayNhap.ToString)

            'excute query
            MYSQLCONNECTIONDAO.ExcuteQuery(query, exception)

            'insert ChiTietPhieuNhap
            If (exception = "") Then Return True

        Catch ex As Exception
            exception = ex.Message
        End Try
        Return False

    End Function

    ''' <summary>
    ''' Get new PhieuNhap ID
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function GetNewPhieuNhapID(Optional ByRef exception As String = "") As String
        Dim indexID As Integer = 0
        Dim newID As String = Nothing
        Try
            'excute query 
            Dim reader As MySqlDataReader = MYSQLCONNECTIONDAO.ExcuteQuery("select Max(cast(Substring(MaPhieuNhap,3, length(MaPhieuNhap)-2) as unsigned)) as 'MaxMaPhieuNhap' from PHIEUNHAP", exception)

            'get the biggest MaPhieuNhap index in database
            If (exception = "") Then
                While reader.Read
                    If (reader.IsDBNull(0)) Then
                        Exit While
                    End If

                    indexID = Integer.Parse(reader.GetString("MaxMaPhieuNhap"))

                End While

                'set newID string
                newID = "PN" & (indexID + 1).ToString("00000000")

            End If
        Catch ex As Exception
            exception = ex.Message
        End Try

        Return newID
    End Function

    ''' <summary>
    ''' Count PhieuNhap
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function CountPhieuNhaps(Optional ByRef exception As String = "") As Integer
        Dim count As Integer = Nothing
        Try
            Dim query As String = String.Format("select count(*) from PHIEUNHAP")
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
