Imports MySql.Data.MySqlClient
Imports DTO

Public Class CHITIETTONDAO

#Region "Find"

    ''' <summary>
    ''' Find chitietton by MaBaoCaoTon and maSach
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function FindChiTietTon(ByVal maBaoCaoTon As String, ByVal maSach As String, Optional ByRef exception As String = "") As CHITIETTONDTO
        'a variable to store BaoCaoTon we found out
        Dim chiTietTon As CHITIETTONDTO = Nothing
        Try
            'query
            Dim query As String = String.Format("select* from CHITIETTON where MaBaoCaoTon = '{0}' and MaSach = '{1}'", maBaoCaoTon, maSach)

            'excute reader in MySQL
            Dim reader As MySqlDataReader = MYSQLCONNECTIONDAO.ExcuteQuery(query, exception)

            'If there is no exception
            If (exception = "") Then
                'get BaoCaoTon
                While reader.Read
                    chiTietTon = New CHITIETTONDTO(reader.GetString("MaChiTietTon"), reader.GetString("MaBaoCaoTon"), reader.GetString("MaSach"),
                                                   reader.GetString("TonDau"), reader.GetString("TonPhatSinh"), reader.GetString("TonCuoi"))
                End While
            End If

        Catch ex As Exception 'If there is exception
            exception = ex.Message
        End Try

        'return 
        Return chiTietTon

    End Function

    ''' <summary>
    ''' Find ChiTietTons by thang and nam
    ''' </summary>
    ''' <param name="thang"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function SearchAllUnRemovedChiTietTons(ByVal thang As Integer, ByVal nam As Integer, Optional ByRef exception As String = "") As DataTable
        'store data
        Dim dataTable As DataTable = Nothing

        Try
            'query
            Dim query As String = String.Format("select MaChiTietTon as 'Mã Chi Tiết Tồn',ChiTietTon.MaSach as 'Mã Sách',TenSach as 'Tên Sách', TonDau as 'Tồn Đầu', 
                                                 TonPhatSinh as 'Tồn Phát Sinh', TonCuoi as 'Tồn Cuối'
                                                 from BaoCaoTon, Sach, ChiTietTon where ChiTietTon.MaSach = Sach.MaSach and TinhTrang = true 
                                                 and BaoCaoTon.MaBaoCaoTon = ChiTietTon.MaBaoCaoTon and Thang = '{0}' and Nam = '{1}'", thang, nam)

            'get dataTable
            dataTable = MYSQLCONNECTIONDAO.GetDataTableByQuery(query, exception)

        Catch ex As Exception
            exception = ex.Message
        End Try

        Return dataTable

    End Function

#End Region

#Region "Insert, Update, Delete"

    ''' <summary>
    ''' Insert a new ChiTietTon
    ''' </summary>
    ''' <param name="maSach"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function InsertChiTietTon(ByVal maBaoCaoTon As String, ByVal maSach As String, Optional ByRef exception As String = "") As Boolean

        Try
            'query
            Dim query As String = String.Format("insert into ChiTietTon values('{0}', (select MaBaoCaoTon from BaoCaoTon where MaBaoCaoTon='{1}'),
                                                (select MaSach from SACH where MaSach='{2}'),'{3}','{4}','{5}')",
                                                GetNewChiTietTonID, maBaoCaoTon, maSach, 0, 0, 0)
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
    ''' Update BaoCaoTon when do LapPhieuNhapSach or LapHoaDonBanSach
    ''' </summary>
    ''' <param name="maSach"></param>
    ''' <param name="soLuong"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function UpdateChiTietTon(ByVal thang As Integer, ByVal nam As Integer, ByVal maSach As String, ByVal soLuong As Integer, Optional ByRef exception As String = "") As Boolean

        Dim baoCaoTon As BAOCAOTONDTO = BAOCAOTONDAO.FindBaoCaoTon(thang, nam)

        'if this thang is a new month
        If (baoCaoTon Is Nothing) Then
            UpdateAllChiTietTonsByNewMonth(thang, nam, exception)
            If (exception <> "") Then Return False
            baoCaoTon = BAOCAOTONDAO.FindBaoCaoTon(thang, nam, exception)
            If (exception <> "") Then Return False
        End If

        'Find chitietton
        Dim chiTietTon As CHITIETTONDTO = FindChiTietTon(baoCaoTon.MaBaoCaoTon, maSach, exception)

        'if there is exception from one line of code above
        If (exception <> "") Then Return False

        If (chiTietTon Is Nothing) Then
            InsertChiTietTon(baoCaoTon.MaBaoCaoTon, maSach, exception)
            If (exception <> "") Then Return False
            'Find chitietton
            chiTietTon = FindChiTietTon(baoCaoTon.MaBaoCaoTon, maSach, exception)
        End If

        Try
            'query
            Dim query As String = String.Format("Update CHITIETTON Set TonPhatSinh = '{0}', TonCuoi = '{1}' where MaChiTietTon = '{2}'",
                                                     chiTietTon.TonPhatSinh + soLuong, chiTietTon.TonCuoi + soLuong, chiTietTon.MaChiTietTon)

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
    ''' Update All BaoCaoTon if this month is a new month
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function UpdateAllChiTietTonsByNewMonth(ByVal thang As Integer, ByVal nam As Integer, Optional ByRef exception As String = "") As Boolean

        Dim baoCaoTon As BAOCAOTONDTO = BAOCAOTONDAO.FindBaoCaoTon(thang, nam)
        'if this thang is not a new month
        If (baoCaoTon IsNot Nothing) Then
            Return False
        End If

        baoCaoTon = New BAOCAOTONDTO
        'get baocaoton
        baoCaoTon.Thang = thang
        baoCaoTon.Nam = nam
        baoCaoTon.MaBaoCaoTon = BAOCAOTONDAO.GetNewBaoCaoTonID(exception)
        If (exception <> "") Then Return False

        'Insert new BaoCaoTon
        BAOCAOTONDAO.InsertBaoCaoTon(baoCaoTon, exception)
        If (exception <> "") Then Return False

        'first thing we have to notice is that TonDau of this thang equal TonCuoi of previous thang
        'so we have to find previous BaoCaoTon
        Dim previousBaoCaoTon As BAOCAOTONDTO = Nothing
        'if this is thang 1, so previous thang is 12 of the last year
        If (thang = 1) Then
            previousBaoCaoTon = BAOCAOTONDAO.FindBaoCaoTon(12, nam - 1, exception)
        Else
            previousBaoCaoTon = BAOCAOTONDAO.FindBaoCaoTon(thang - 1, nam, exception)
        End If
        If (exception <> "") Then Return False

        'get all the books in database
        Dim bookDataTable As DataTable = SACHDAO.FindBooksByID("", exception)
        If (exception <> "") Then Return False

        Try
            'loop through all the books
            For index As Integer = 0 To bookDataTable.Rows.Count - 1

                'get MaSach
                Dim maSach As String = bookDataTable.Rows.Item(index).Item("Mã Sách").ToString

                'first thing we have to notice is that TonDau of this thang equal TonCuoi of previous thang
                'so we have to find previous ChiTietTon
                Dim previousChiTietTon As CHITIETTONDTO = Nothing

                If (previousBaoCaoTon IsNot Nothing) Then
                    previousChiTietTon = FindChiTietTon(previousBaoCaoTon.MaBaoCaoTon, maSach, exception)
                End If

                If (exception <> "") Then Return False
                If (previousChiTietTon IsNot Nothing) Then
                    'query
                    Dim query As String = String.Format("insert into CHITIETTON values('{0}',(select MaBaoCaoTon from BaoCaoTon where MaBaoCaoTon='{1}'), 
                                                    (select MaSach from SACH where MaSach='{2}'),'{3}','{4}','{5}')",
                                                            GetNewChiTietTonID, baoCaoTon.MaBaoCaoTon, maSach, previousChiTietTon.TonCuoi,
                                                            0, previousChiTietTon.TonCuoi)
                    'excute query
                    MYSQLCONNECTIONDAO.ExcuteQuery(query, exception)
                Else
                    InsertChiTietTon(baoCaoTon.MaBaoCaoTon, maSach, exception)
                    If (exception <> "") Then Return False
                End If

            Next

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
    ''' get new ChiTietTon ID
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function GetNewChiTietTonID(Optional ByRef exception As String = "") As String

        Dim indexID As Integer = 0
        Dim newID As String = Nothing
        Try
            'excute query 
            Dim reader As MySqlDataReader = MYSQLCONNECTIONDAO.ExcuteQuery("select Max(cast(Substring(MaChiTietTon,3, length(MaChiTietTon)-2) as unsigned)) as 'MaxMaChiTietTon' from CHITIETTON", exception)

            'get the biggest MaChiTietTon index in database
            If (exception = "") Then
                While reader.Read
                    If (reader.IsDBNull(0)) Then
                        Exit While
                    End If

                    indexID = Integer.Parse(reader.GetString("MaxMaChiTietTon"))

                End While

                'set newID string
                newID = "CT" & (indexID + 1).ToString("00000000")

            End If

        Catch ex As Exception
            exception = ex.Message
        End Try

        'return new ID
        Return newID
    End Function


#End Region


End Class
