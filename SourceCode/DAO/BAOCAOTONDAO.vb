Imports MySql.Data.MySqlClient
Imports DTO
Public Class BAOCAOTONDAO

#Region "Find"

    ''' <summary>
    ''' Find baocaoton by thang and nam and maSach
    ''' </summary>
    ''' <param name="thang"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function FindBaoCaoTon(ByVal thang As Integer, ByVal nam As Integer, Optional ByRef exception As String = "") As BAOCAOTONDTO
        'a variable to store BaoCaoTon we found out
        Dim baoCaoTon As BAOCAOTONDTO = Nothing
        Try
            'query
            Dim query As String = String.Format("select* from BAOCAOTON where Thang = '{0}' and Nam = '{1}'", thang, nam)

            'excute reader in MySQL
            Dim reader As MySqlDataReader = MYSQLCONNECTIONDAO.ExcuteQuery(query, exception)

            'If there is no exception
            If (exception = "") Then
                'get BaoCaoTon
                While reader.Read
                    baoCaoTon = New BAOCAOTONDTO(reader.GetString("MaBaoCaoTon"), reader.GetString("Thang"), reader.GetString("Nam"))
                End While
            End If

        Catch ex As Exception 'If there is exception
            exception = ex.Message
        End Try

        'return 
        Return baoCaoTon

    End Function

#End Region

#Region "Insert, Update, Delete"

    ''' <summary>
    ''' Insert a new BaoCaoTon when a new book is inserted
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function InsertBaoCaoTon(ByVal baoCaoTon As BAOCAOTONDTO, Optional ByRef exception As String = "") As Boolean
        Try
            'query
            Dim query As String = String.Format("insert into BAOCAOTON values('{0}', '{1}', '{2}')",
                                                baoCaoTon.MaBaoCaoTon, baoCaoTon.Thang, baoCaoTon.Nam)
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
    ''' Remove BaoCaoTons by book ID
    ''' </summary>
    ''' <param name="maSach"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function RemoveBaoCaoTons(ByVal maSach As String, Optional ByRef exception As String = "") As Boolean
        Try
            'query
            Dim query As String = String.Format("delete from BAOCAOTON where MaSach = '{0}'", maSach)
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
    ''' get new BaoCaoTon ID
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function GetNewBaoCaoTonID(Optional ByRef exception As String = "") As String

        Dim indexID As Integer = 0
        Dim newID As String = Nothing
        Try
            'excute query 
            Dim reader As MySqlDataReader = MYSQLCONNECTIONDAO.ExcuteQuery("select Max(cast(Substring(MaBaoCaoTon,3, length(MaBaoCaoTon)-2) as unsigned)) as 'MaxMaBaoCaoTon' from BAOCAOTON", exception)

            'get the biggest MaChiTietTon index in database
            If (exception = "") Then
                While reader.Read
                    If (reader.IsDBNull(0)) Then
                        Exit While
                    End If

                    indexID = Integer.Parse(reader.GetString("MaxMaBaoCaoTon"))

                End While

                'set newID string
                newID = "BT" & (indexID + 1).ToString("00000000")

            End If

        Catch ex As Exception
            exception = ex.Message
        End Try

        'return new ID
        Return newID
    End Function

    ''' <summary>
    ''' Count the number of BaoCaoTon in database
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function CountBaoCaoTons(Optional ByRef exception As String = "") As Integer
        Dim count As Integer = Nothing

        Try
            Dim query As String = String.Format("select count(*) from BAOCAOTON")
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

    ''' <summary>
    ''' Find baocaotons by thang and nam
    ''' </summary>
    ''' <param name="thang"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Private Shared Function FindAllBaoCaoTons(ByVal thang As Integer, ByVal nam As Integer, Optional ByRef exception As String = "") As DataTable
        'store data
        Dim dataTable As DataTable = Nothing

        Try
            'query
            Dim query As String = String.Format("select MaChiTietTon as 'Mã Chi Tiết Tồn',MaSach as 'Mã Sách', TonDau as 'Tồn Đầu', 
                                                 TonPhatSinh as 'Tồn Phát Sinh', TonCuoi as 'Tồn Cuối'
                                                 from BAOCAOTON where Thang = '{0}' and Nam = '{1}'", thang, nam)

            'get dataTable
            dataTable = MYSQLCONNECTIONDAO.GetDataTableByQuery(query, exception)

        Catch ex As Exception
            exception = ex.Message
        End Try

        Return dataTable

    End Function

#End Region

End Class
