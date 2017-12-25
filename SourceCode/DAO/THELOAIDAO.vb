Imports DTO
Imports MySql.Data.MySqlClient
Public Class THELOAIDAO

    ''' <summary>
    ''' Insert new TheLoai into database
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function InsertTheLoai(ByVal theLoai As THELOAIDTO, Optional ByRef exception As String = "") As Boolean
        Try
            'query
            Dim query As String = String.Format("insert into TheLoai values('{0}','{1}')", theLoai.MaTheLoai, theLoai.TenTheLoai)

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
    ''' Find all TheLoais into database
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function FindAllTheLoais(Optional ByRef exception As String = "") As DataTable
        'store data
        Dim dataTable As DataTable = Nothing

        Try
            'query
            Dim query As String = String.Format("select MaTheLoai as 'Mã Thể loại', TenTheLoai as 'Tên Thể Loại' from TheLoai")

            'get dataTable
            dataTable = MYSQLCONNECTIONDAO.GetDataTableByQuery(query, exception)

        Catch ex As Exception
            exception = ex.Message
        End Try

        Return dataTable

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
            Dim reader As MySqlDataReader = MYSQLCONNECTIONDAO.ExcuteQuery("select Max(cast(Substring(MaTheLoai,3, length(MaTheLoai)-2) as unsigned)) as 'MaxMaTheLoai' from THELOAI", exception)

            'get the biggest MaTheLoai index in database
            If (exception = "") Then
                While reader.Read
                    If (reader.IsDBNull(0)) Then
                        Exit While
                    End If

                    indexID = Integer.Parse(reader.GetString("MaxMaTheLoai"))

                End While

                'set newID string
                newID = "TL" & (indexID + 1).ToString("00000000")

            End If
        Catch ex As Exception
            exception = ex.Message
        End Try

        Return newID
    End Function

    ''' <summary>
    ''' Insert new PhieuNhap into database
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function RemoveTheLoai(ByVal maTheLoai As String, Optional ByRef exception As String = "") As Boolean
        Try
            'query
            Dim query As String = String.Format("delete from TheLoai where MaTheLoai = '{0}'", maTheLoai)

            'excute query
            MYSQLCONNECTIONDAO.ExcuteQuery(query, exception)

            'insert ChiTietPhieuNhap
            If (exception = "") Then Return True

        Catch ex As Exception
            exception = ex.Message
        End Try
        Return False

    End Function

End Class
