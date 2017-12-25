Imports DTO
Imports MySql.Data.MySqlClient

Public Class CHITIETCONGNODAO
#Region "Find"

    ''' <summary>
    ''' Find chitietcongno by Mabaocaocongno and makhachhang
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function FindChiTietCongNo(ByVal maBaoCaoCongNo As String, ByVal maKhachHang As String, Optional ByRef exception As String = "") As CHITIETCONGNODTO
        'a variable to store BaoCaoTon we found out
        Dim chiTietCongNo As CHITIETCONGNODTO = Nothing
        Try
            'query
            Dim query As String = String.Format("select* from CHITIETCONGNO where MaBaoCaoCongNo = '{0}' and MaKhachHang = '{1}'", maBaoCaoCongNo, maKhachHang)

            'excute reader in MySQL
            Dim reader As MySqlDataReader = MYSQLCONNECTIONDAO.ExcuteQuery(query, exception)

            'If there is no exception
            If (exception = "") Then
                'get BaoCaoTon
                While reader.Read
                    chiTietCongNo = New CHITIETCONGNODTO(reader.GetString("MaChiTietCongNo"), reader.GetString("MaBaoCaoCongNo"), reader.GetString("MaKhachHang"),
                                                   reader.GetString("NoDau"), reader.GetString("NoPhatSinh"), reader.GetString("NoCuoi"))
                End While
            End If

        Catch ex As Exception 'If there is exception
            exception = ex.Message
        End Try

        'return 
        Return chiTietCongNo

    End Function

    ''' <summary>
    ''' Find ChiTietCongNos by thang and nam
    ''' </summary>
    ''' <param name="thang"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function SearchAllUnRemovedChiTietCongNos(ByVal thang As Integer, ByVal nam As Integer, Optional ByRef exception As String = "") As DataTable
        'store data
        Dim dataTable As DataTable = Nothing

        Try
            'query
            Dim query As String = String.Format("select MaChiTietCongNo as 'Mã Chi Tiết Công Nợ',ChiTietCongNo.MaKhachHang as 'Mã Khách Hàng',HoTenKhachHang as 'Họ Tên Khách Hàng', 
                                                 NoDau as 'Nợ Đầu', NoPhatSinh as 'Nợ Phát Sinh', NoCuoi as 'Nợ Cuối'
                                                 from BaoCaoCongNo, KhachHang, ChiTietCongNo where ChiTietCongNo.MaKhachHang = KhachHang.MaKhachHang 
                                                 and TinhTrang = true and BaoCaoCongNo.MaBaoCaoCongNo = ChiTietCongNo.MaBaoCaoCongNo
                                                 and Thang = '{0}' and Nam = '{1}'", thang, nam)

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
    ''' Insert a new ChiTietCongNo
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function InsertChiTietCongNo(ByVal maBaoCaoCongNo As String, ByVal maKhachHang As String, Optional ByRef exception As String = "") As Boolean

        Try
            'query
            Dim query As String = String.Format("insert into ChiTietCongNo values('{0}', (select MaBaoCaoCongNo from BaoCaoCongNo where MaBaoCaoCongNo='{1}'),
                                                (select MaKhachHang from KhachHang where MaKhachHang='{2}'),'{3}','{4}','{5}')",
                                                GetNewChiTietCongNoID, maBaoCaoCongNo, maKhachHang, 0, 0, 0)
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
    ''' Update BaoCaoCongNo
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function UpdateChiTietCongNo(ByVal thang As Integer, ByVal nam As Integer, ByVal maKhachHang As String, ByVal soTien As Decimal, Optional ByRef exception As String = "") As Boolean

        Dim baoCaoCongNo As BAOCAOCONGNODTO = BAOCAOCONGNODAO.FindBaoCaoCongNo(thang, nam)

        'if this thang is a new month
        If (baoCaoCongNo Is Nothing) Then
            UpdateAllChiTietCongNosByNewMonth(thang, nam, exception)
            If (exception <> "") Then Return False

            baoCaoCongNo = BAOCAOCONGNODAO.FindBaoCaoCongNo(thang, nam)
        End If

        'Find chitietton
        Dim chiTietCongNo As CHITIETCONGNODTO = FindChiTietCongNo(baoCaoCongNo.MaBaoCaoCongNo, maKhachHang, exception)

        'if there is exception from one line of code above
        If (exception <> "") Then Return False

        If (chiTietCongNo Is Nothing) Then
            InsertChiTietCongNo(baoCaoCongNo.MaBaoCaoCongNo, maKhachHang, exception)
            If (exception <> "") Then Return False
            'Find chitietcongno
            chiTietCongNo = FindChiTietCongNo(baoCaoCongNo.MaBaoCaoCongNo, maKhachHang, exception)
        End If

        Try
            'query
            Dim query As String = String.Format("Update ChiTietCongNo Set NoPhatSinh = '{0}', NoCuoi = '{1}' where MaChiTietCongNo = '{2}'",
                                                     chiTietCongNo.NoPhatSinh + soTien, chiTietCongNo.NoCuoi + soTien, chiTietCongNo.MaChiTietCongNo)

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
    ''' Update All BaoCaoCongNo if this month is a new month
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function UpdateAllChiTietCongNosByNewMonth(ByVal thang As Integer, ByVal nam As Integer, Optional ByRef exception As String = "") As Boolean

        Dim baoCaoCongNo As BAOCAOCONGNODTO = BAOCAOCONGNODAO.FindBaoCaoCongNo(thang, nam)
        'if this thang is not a new month
        If (baoCaoCongNo IsNot Nothing) Then
            Return False
        End If

        baoCaoCongNo = New BAOCAOCONGNODTO
        'get baocaoton
        baoCaoCongNo.Thang = thang
        baoCaoCongNo.Nam = nam
        baoCaoCongNo.MaBaoCaoCongNo = BAOCAOCONGNODAO.GetNewBaoCaoCongNoID(exception)
        If (exception <> "") Then Return False

        'Insert new BaoCaoTon
        BAOCAOCONGNODAO.InsertBaoCaoCongNo(baoCaoCongNo, exception)
        If (exception <> "") Then Return False

        'first thing we have to notice is that TonDau of this thang equal TonCuoi of previous thang
        'so we have to find previous BaoCaoTon
        Dim previousBaoCaoCongNo As BAOCAOCONGNODTO = Nothing
        'if this is thang 1, so previous thang is 12 of the last year
        If (thang = 1) Then
            previousBaoCaoCongNo = BAOCAOCONGNODAO.FindBaoCaoCongNo(12, nam - 1, exception)
        Else
            previousBaoCaoCongNo = BAOCAOCONGNODAO.FindBaoCaoCongNo(thang - 1, nam, exception)
        End If
        If (exception <> "") Then Return False


        'get all the customers in database
        Dim customerDataTable As DataTable = KHACHHANGDAO.FindCustomersByID("", exception)
        If (exception <> "") Then Return False

        Try
            'loop through all the books
            For index As Integer = 0 To customerDataTable.Rows.Count - 1

                'get MaSach
                Dim maKhachHang As String = customerDataTable.Rows.Item(index).Item("Mã Khách Hàng").ToString

                'first thing we have to notice is that TonDau of this thang equal TonCuoi of previous thang
                'so we have to find previous ChiTietTon
                Dim previousChiTietCongNo As CHITIETCONGNODTO = Nothing

                If (previousBaoCaoCongNo IsNot Nothing) Then
                    previousChiTietCongNo = FindChiTietCongNo(previousBaoCaoCongNo.MaBaoCaoCongNo, maKhachHang, exception)
                End If

                If (exception <> "") Then Return False
                If (previousChiTietCongNo IsNot Nothing) Then
                    'query
                    Dim query As String = String.Format("insert into CHITIETCONGNO values('{0}',(select MaBaoCaoCongNo from BaoCaoCongNo where MaBaoCaoCongNo='{1}'), 
                                                    (select MaKhachHang from KhachHang where MaKhachHang='{2}'),'{3}','{4}','{5}')",
                                                            GetNewChiTietCongNoID, baoCaoCongNo.MaBaoCaoCongNo, maKhachHang, previousChiTietCongNo.NoCuoi,
                                                            0, previousChiTietCongNo.NoCuoi)
                    'excute query
                    MYSQLCONNECTIONDAO.ExcuteQuery(query, exception)
                Else
                    InsertChiTietCongNo(baoCaoCongNo.MaBaoCaoCongNo, maKhachHang, exception)
                    If (exception <> "") Then Return False
                End If

            Next

            If (exception = "") Then Return True

        Catch ex As Exception
            exception = ex.Message
        End Try

        Return False
    End Function

#End Region

#Region "Some other functions"

    ''' <summary>
    ''' get new ChiTietCongNo ID
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function GetNewChiTietCongNoID(Optional ByRef exception As String = "") As String

        Dim indexID As Integer = 0
        Dim newID As String = Nothing
        Try
            'excute query 
            Dim reader As MySqlDataReader = MYSQLCONNECTIONDAO.ExcuteQuery("select Max(cast(Substring(MaChiTietCongNo,3, length(MaChiTietCongNo)-2) as unsigned)) as 'MaxMaChiTietCongNo' from CHITIETCONGNO", exception)

            'get the biggest MaChiTietCongNo index in database
            If (exception = "") Then
                While reader.Read
                    If (reader.IsDBNull(0)) Then
                        Exit While
                    End If

                    indexID = Integer.Parse(reader.GetString("MaxMaChiTietCongNo"))

                End While

                'set newID string
                newID = "CN" & (indexID + 1).ToString("00000000")

            End If

        Catch ex As Exception
            exception = ex.Message
        End Try

        'return new ID
        Return newID
    End Function


#End Region
End Class
