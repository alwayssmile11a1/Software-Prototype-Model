Imports MySql.Data.MySqlClient
Imports DTO
Imports System.Xml

Public Class KHACHHANGDAO

    'query to execute in MySQL
    Private Shared query As String = ""

#Region "Insert, Update, Remove"

    ''' <summary>
    ''' Insert a new customer
    ''' Used procedure
    ''' </summary>
    ''' <param name="khachHang"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function InsertCustomer(ByVal khachHang As KHACHHANGDTO, Optional ByRef exception As String = "") As Boolean
        'query = String.Format("insert into KHACHHANG values('{0}','{1}','{2}','{3}','{4}','{5}')",
        '                                        khachHang.MaKhachHang, khachHang.HoTenKhachHang, khachHang.DiaChi, khachHang.DienThoai, khachHang.EMail, khachHang.SoTienNo)
        'Return DoCustomerTask(exception)

        Try

            'ExcuteQuery
            MYSQLCONNECTIONDAO.ExcuteProcedure("InsertCustomer", exception, New MySqlParameter("@_MaKhachHang", khachHang.MaKhachHang),
                                               New MySqlParameter("@_TenKhachHang", khachHang.HoTenKhachHang),
                                               New MySqlParameter("@_DiaChi", khachHang.DiaChi), New MySqlParameter("@_DienThoai", khachHang.DienThoai),
                                               New MySqlParameter("@_Email", khachHang.EMail), New MySqlParameter("@_SoTienNo", khachHang.SoTienNo),
                                               New MySqlParameter("@_TinhTrang", True))

            'if there is no exception
            If (exception = "") Then Return True

        Catch ex As Exception
            exception = ex.Message
        End Try

        Return False

    End Function

    ''' <summary>
    ''' Delete a Customer
    ''' </summary>
    ''' <param name="maKhachHang"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function RemoveCustomer(ByVal maKhachHang As String, Optional ByRef exception As String = "") As Boolean
        ''Find the book by ID
        'Dim customer As KHACHHANGDTO = FindCustomerByID(maKhachHang, exception)

        'If (customer Is Nothing) Then
        '    Return False
        'End If

        ''Create the XmlDocument.
        'Dim xmlDoc As XmlDocument = New XmlDocument()
        ''Load xml Document
        'xmlDoc.Load("RemovedCustomers.xml")

        ''if this customer has been removed 
        'If (xmlDoc.SelectSingleNode("Customers/CustomerID[text()='" + maKhachHang + "']") IsNot Nothing) Then
        '    Return False
        'End If

        ''Create node
        'Dim customerIDNode As XmlNode = xmlDoc.CreateElement("CustomerID")
        'customerIDNode.InnerText = maKhachHang

        'xmlDoc.DocumentElement.AppendChild(customerIDNode)

        'xmlDoc.Save("RemovedCustomers.xml")

        'Return True

        Try

            'ExcuteQuery
            MYSQLCONNECTIONDAO.ExcuteProcedure("UpdateCustomerStatus", exception, New MySqlParameter("@_MaKhachHang", maKhachHang),
                                               New MySqlParameter("@_TinhTrang", False))

            'if there is no exception
            If (exception = "") Then Return True

        Catch ex As Exception
            exception = ex.Message
        End Try

        Return False

    End Function

    ''' <summary>
    ''' Update a customer by ID
    ''' Used procedure
    ''' </summary>
    ''' <param name="khachHang"></param>
    ''' <returns></returns>
    Public Shared Function UpdateCustomer(ByVal khachHang As KHACHHANGDTO, Optional ByRef exception As String = "") As Boolean
        'query = String.Format("update KhachHang set HoTenKhachHang='{1}',DiaChi='{2}', DienThoai='{3}',Email='{4}' where MaKhachHang='{0}'",
        '                                         khachHang.MaKhachHang, khachHang.HoTenKhachHang, khachHang.DiaChi, khachHang.DienThoai, khachHang.EMail)
        'Return DoCustomerTask(exception)

        Try

            'ExcuteQuery
            MYSQLCONNECTIONDAO.ExcuteProcedure("UpdateCustomer", exception, New MySqlParameter("@_MaKhachHang", khachHang.MaKhachHang),
                                               New MySqlParameter("@_TenKhachHang", khachHang.HoTenKhachHang),
                                               New MySqlParameter("@_DiaChi", khachHang.DiaChi), New MySqlParameter("@_DienThoai", khachHang.DienThoai),
                                               New MySqlParameter("@_Email", khachHang.EMail))

            'if there is no exception
            If (exception = "") Then Return True

        Catch ex As Exception
            exception = ex.Message
        End Try

        Return False


    End Function

    ''' <summary>
    ''' Update customer debt after payment or before payment
    ''' Used procedure
    ''' </summary>
    ''' <param name="maKhachHang"></param>
    ''' <param name="soTien"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function UpdateCustomerDebt(ByVal maKhachHang As String, ByVal soTien As Decimal, Optional ByRef exception As String = "") As Boolean
        'query = String.Format("update KhachHang set SoTienNo=SoTienNo + {0} where MaKhachHang='{1}'",
        '                                        soTien, maKhachHang)
        'Return DoCustomerTask(exception)

        Try

            'ExcuteQuery
            MYSQLCONNECTIONDAO.ExcuteProcedure("UpdateCustomerDebt", exception, New MySqlParameter("@_MaKhachHang", maKhachHang),
                                                                            New MySqlParameter("@_SoTien", soTien))

            'if there is no exception
            If (exception = "") Then Return True

        Catch ex As Exception
            exception = ex.Message
        End Try

        Return False

    End Function

    ''' <summary>
    ''' retrieve removed customer
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function RetriveRemovedCustomer(ByVal maKhachHang As String, Optional ByRef exception As String = "") As Boolean

        'Try
        '    'Create the XmlDocument.
        '    Dim xmlDoc As XmlDocument = New XmlDocument()
        '    'Load xml Document
        '    xmlDoc.Load("RemovedBooks.xml")

        '    'if this book has been removed 
        '    Dim customerToRetrieve = xmlDoc.SelectSingleNode("Customers/CustomerID[text()='" + maKhachHang + "']")
        '    If (customerToRetrieve IsNot Nothing) Then
        '        xmlDoc.RemoveChild(customerToRetrieve)
        '        Return True
        '    Else
        '        Return False
        '    End If

        'Catch ex As Exception 'exception from system, not mysqlException
        '    exception = ex.Message
        'End Try
        'Return False

        Try

            'ExcuteQuery
            MYSQLCONNECTIONDAO.ExcuteProcedure("UpdateCustomerStatus", exception, New MySqlParameter("@_MaKhachHang", maKhachHang),
                                               New MySqlParameter("@_TinhTrang", True))

            'if there is no exception
            If (exception = "") Then Return True

        Catch ex As Exception
            exception = ex.Message
        End Try

        Return False

    End Function

#End Region

#Region "Find Customers"

    ''' <summary>
    ''' Find a customer by the exact ID
    ''' Used procedure
    ''' </summary>
    ''' <param name="maKhachHang"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function FindCustomerByID(ByVal maKhachHang As String, ByVal tinhTrang As Boolean, Optional ByRef exception As String = "") As KHACHHANGDTO
        'a variable to store khachhang's information
        Dim khachHang As KHACHHANGDTO = Nothing
        Try
            'query
            'query = String.Format("select* from KHACHHANG where MaKhachHang='{0}'", maKhachHang)

            ''reader
            'Dim reader As MySqlDataReader = MYSQLCONNECTIONDAO.ExcuteQuery(query, exception)

            Dim reader As MySqlDataReader = MYSQLCONNECTIONDAO.ExcuteProcedure("FindCustomer", exception, New MySqlParameter("@_MaKhachHang", maKhachHang),
                                                                                                          New MySqlParameter("@_TinhTrang", tinhTrang))

            'if there is no exception
            If (exception = "") Then
                'get the khachhang's information
                While (reader.Read)
                    khachHang = New KHACHHANGDTO(reader.GetString("MaKhachHang"), reader.GetString("HoTenKhachHang"), reader.GetString("DiaChi"),
                                             reader.GetString("DienThoai"), reader.GetString("Email"), reader.GetString("SoTienNo"))
                End While
            End If
        Catch ex As Exception
            exception = ex.Message
        End Try

        Return khachHang
    End Function

    ''' <summary>
    ''' Search customers
    ''' Used procedure
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function SearchCustomers(ByVal maKhachHang As String, ByVal tenKhachHang As String, ByVal diaChi As String, ByVal dienThoai As String,
                                       ByVal eMail As String, ByVal soTienNoCompareType As String,
                                       ByVal soTienNo As Decimal, ByVal tinhTrang As Boolean, Optional ByRef exception As String = "") As DataTable

        'store data
        Dim dataTable As DataTable = Nothing

        'query = String.Format("select MaKhachHang As 'Mã Khách Hàng', HoTenKhachHang As 'Họ Tên Khách Hàng', DiaChi As 'Địa Chỉ',DienThoai As 'Điện Thoại',
        '                              Email As 'Email',SoTienNo As 'Số Tiền Nợ' from KhachHang where MaKhachHang like '%{0}%' and  
        '                              HoTenKhachHang like '%{1}%' and DiaChi like '%{2}%' and DienThoai like '%{3}%' and Email like '%{4}%' and SoTienNo {5} '{6}'",
        '                              maKhachHang, tenKhachHang, diaChi, dienThoai, eMail, soTienNoCompareType, soTienNo)


        Try
            'dataTable = MYSQLCONNECTIONDAO.GetDataTableByQuery(query, exception
            dataTable = MYSQLCONNECTIONDAO.GetDataTableByProcedure("FindCustomers", exception, New MySqlParameter("@_MaKhachHang", maKhachHang),
                                                                   New MySqlParameter("@_TenKhachHang", tenKhachHang), New MySqlParameter("@_DiaChi", diaChi),
                                                                   New MySqlParameter("@_DienThoai", dienThoai), New MySqlParameter("@_Email", eMail),
                                                                   New MySqlParameter("@_SoTienNo", soTienNo),
                                                                   New MySqlParameter("@_SoTienNoCompareType", soTienNoCompareType),
                                                                   New MySqlParameter("@_TinhTrang", tinhTrang))

        Catch ex As Exception 'exception from system, not mysqlException
            exception = ex.Message
        End Try
        Return dataTable
        'Return books
    End Function

    ''' <summary>
    '''Get all customer unremoved ids
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function GetAllCustomerIDs(Optional ByRef exception As String = "") As List(Of String)

        'store data
        Dim customerIDs As List(Of String) = Nothing


        Try

            customerIDs = New List(Of String)

            Dim query = String.Format("select MaKhachHang from KHACHHANG where TinhTrang = true")

            'Excute query in MySQL
            Dim reader As MySqlDataReader = MYSQLCONNECTIONDAO.ExcuteQuery(query, exception)

            If (exception = "") Then
                While (reader.Read)
                    customerIDs.Add(reader.GetString("MaKhachHang"))
                End While
            End If

        Catch ex As Exception 'exception from system, not mysqlException
            exception = ex.Message
        End Try

        Return customerIDs

    End Function


#End Region

#Region "other functions"

    ''' <summary>
    ''' get new customer ID
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function GetNewCustomerID(Optional ByRef exception As String = "") As String
        'the index of ID
        Dim indexID As Integer = 0
        'new ID string
        Dim newID As String = Nothing
        Try
            'excute query 
            Dim reader As MySqlDataReader = MYSQLCONNECTIONDAO.ExcuteQuery("select Max(cast(Substring(MaKhachHang,3, length(MaKhachHang)-2) as unsigned)) as 'MaxMaKhachHang' from KHACHHANG", exception)

            'get the biggest MaKhachHang in database
            If (exception = "") Then
                While reader.Read

                    If (reader.IsDBNull(0)) Then
                        Exit While
                    End If

                    indexID = Integer.Parse(reader.GetString("MaxMaKhachHang"))

                End While

                'get the next ID
                newID = "KH" & (indexID + 1).ToString("0000")

            End If

        Catch ex As Exception
            exception = ex.Message
        End Try

        Return newID
    End Function

#End Region

#Region "Don't mind"

    ''' <summary>
    ''' this function is used like a pattern for all the other find customers function
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Private Shared Function FindCustomers(Optional ByRef exception As String = "") As DataTable
        'a dataTable to store data
        Dim dataTable As DataTable = Nothing
        Try
            dataTable = MYSQLCONNECTIONDAO.GetDataTableByQuery(query, exception)

        Catch ex As Exception 'exception from system, not mysqlException
            exception = ex.Message
        End Try

        Return dataTable
    End Function

    ''' <summary>
    ''' a pattern function for some task 
    ''' </summary>
    Private Shared Function DoCustomerTask(Optional ByRef exception As String = "") As Boolean
        Try
            MYSQLCONNECTIONDAO.ExcuteQuery(query, exception)
            If (exception = "") Then Return True
        Catch ex As Exception
            exception = ex.Message
        End Try
        Return False

    End Function

    ''' <summary>
    ''' Find Customers has the little similar ID 
    ''' </summary>
    ''' <param name="maKhachHang"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function FindCustomersByID(ByVal maKhachHang As String, Optional ByRef exception As String = "") As DataTable
        query = String.Format("select MaKhachHang As 'Mã Khách Hàng', HoTenKhachHang As 'Tên Khách Hàng', DienThoai As 'Điện Thoại', 
                                      DiaChi As 'Địa Chỉ', Email As 'Email', SoTienNo As 'Số Tiền Nợ' from KHACHHANG where MaKhachHang like '%{0}%'", maKhachHang)
        Return FindCustomers(exception)
    End Function

    ''' <summary>
    ''' Find Customers by Name
    ''' </summary>
    ''' <param name="tenKhachHang"></param>
    ''' <returns></returns>
    Public Shared Function FindCustomersByName(ByVal tenKhachHang As String, Optional ByRef exception As String = "") As DataTable
        query = String.Format("select MaKhachHang As 'Mã Khách Hàng', HoTenKhachHang As 'Tên Khách Hàng', DienThoai As 'Điện Thoại', 
                                      DiaChi As 'Địa Chỉ', Email As 'Email', SoTienNo As 'Số Tiền Nợ' from KhachHang where HoTenKhachHang like '%{0}%'", tenKhachHang)
        Return FindCustomers(exception)
    End Function

    ''' <summary>
    ''' Find Customers by address
    ''' </summary>
    ''' <param name="diaChi"></param>
    ''' <returns></returns>
    Public Shared Function FindCustomersByAddress(ByVal diaChi As String, Optional ByRef exception As String = "") As DataTable

        query = String.Format("select MaKhachHang As 'Mã Khách Hàng', HoTenKhachHang As 'Tên Khách Hàng', DienThoai As 'Điện Thoại', 
                                      DiaChi As 'Địa Chỉ', Email As 'Email', SoTienNo As 'Số Tiền Nợ' from KhachHang where DiaChi like '%{0}%'", diaChi)
        Return FindCustomers(exception)
    End Function

    ''' <summary>
    ''' Find Customers by phonenumber
    ''' </summary>
    ''' <param name="dienThoai"></param>
    ''' <returns></returns>
    Public Shared Function FindCustomersByPhone(ByVal dienThoai As String, Optional ByRef exception As String = "") As DataTable
        query = String.Format("select MaKhachHang As 'Mã Khách Hàng', HoTenKhachHang As 'Tên Khách Hàng', DienThoai As 'Điện Thoại', 
                                      DiaChi As 'Địa Chỉ', Email As 'Email', SoTienNo As 'Số Tiền Nợ' from KhachHang where DienThoai like '%{0}%'", dienThoai)
        Return FindCustomers(exception)
    End Function

    ''' <summary>
    ''' Find Customers by email
    ''' </summary>
    ''' <param name="email"></param>
    ''' <returns></returns>
    Public Shared Function FindCustomersByEmail(ByVal email As String, Optional ByRef exception As String = "") As DataTable
        query = String.Format("select MaKhachHang As 'Mã Khách Hàng', HoTenKhachHang As 'Tên Khách Hàng', DienThoai As 'Điện Thoại', 
                                      DiaChi As 'Địa Chỉ', Email As 'Email', SoTienNo As 'Số Tiền Nợ' from KhachHang where eMail like '%{0}%'", email)

        Return FindCustomers(exception)
    End Function

    ''' <summary>
    ''' Find customers by debt
    ''' </summary>
    ''' <param name="soTienNo"></param>
    ''' <param name="compareType"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function FindCustomersbyDebt(ByVal soTienNo As Decimal, ByVal compareType As String, Optional ByRef exception As String = "") As DataTable
        query = String.Format("select MaKhachHang As 'Mã Khách Hàng', HoTenKhachHang As 'Tên Khách Hàng', DienThoai As 'Điện Thoại', 
                                      DiaChi As 'Địa Chỉ', Email As 'Email', SoTienNo As 'Số Tiền Nợ' from KHACHHANG where SoTienNo {0} '{1}'", compareType, soTienNo)
        Return FindCustomers(exception)
    End Function

    ''' <summary>
    ''' Count books
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function CountCustomers(Optional ByRef exception As String = "") As Integer
        Dim count As Integer = Nothing
        Try
            'excute query 
            Dim reader As MySqlDataReader = MYSQLCONNECTIONDAO.ExcuteQuery("select count(*) from KHACHHANG", exception)

            'count
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
    ''' Find removed customers
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function FindRemovedCustomers(Optional ByRef exception As String = "") As List(Of KHACHHANGDTO)

        'store data
        Dim customers As List(Of KHACHHANGDTO) = New List(Of KHACHHANGDTO)

        Try
            'Create the XmlDocument.
            Dim xmlDoc As XmlDocument = New XmlDocument()
            'Load xml Document
            xmlDoc.Load("RemovedBooks.xml")

            'Loop through all the removed books
            For Each node As XmlNode In xmlDoc.SelectNodes("Customers/CustomerID")
                Dim customer = FindCustomerByID(node.InnerText, exception)
                If (exception <> "") Then Return Nothing
                customers.Add(customer)
            Next

        Catch ex As Exception 'exception from system, not mysqlException
            exception = ex.Message
        End Try
        Return customers
        'Return books
    End Function

#End Region

End Class
