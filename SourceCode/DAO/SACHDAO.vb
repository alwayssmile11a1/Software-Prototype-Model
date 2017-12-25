Imports MySql.Data.MySqlClient
Imports DTO
Imports System.Xml

Public Class SACHDAO

    'a string to hold the code to execute in Mysql 
    Private Shared query As String = ""

#Region "Find"

    ''' <summary>
    ''' Find a book by its ID
    ''' Used procedure
    ''' </summary>
    ''' <param name="maSach"></param>
    ''' <returns></returns>
    Public Shared Function FindBookByID(ByVal maSach As String, ByVal tinhTrang As Boolean, Optional ByRef exception As String = "") As SACHDTO
        'a variable to store the book found out
        Dim book As SACHDTO = Nothing
        Try
            ''query 
            'query = String.Format("select* from SACH where MaSach ='{0}'", maSach)

            'Excute procedure in MySQL
            Dim reader As MySqlDataReader = MYSQLCONNECTIONDAO.ExcuteProcedure("FindBook", exception, New MySqlParameter("@_MaSach", maSach),
                                                                                                      New MySqlParameter("@_TinhTrang", tinhTrang))

            'Excute query in MySQL
            'Dim reader As MySqlDataReader = MYSQLCONNECTIONDAO.ExcuteQuery(query, exception)

            'If there is not exception
            If (exception = "") Then
                While reader.Read
                    book = New SACHDTO(reader.GetString("MaSach"), reader.GetString("TenSach"), reader.GetString("TheLoai"),
                                   reader.GetString("TacGia"), reader.GetString("SoLuongTon"), reader.GetString("DonGia"))
                End While
            End If
        Catch ex As Exception 'Exception from system( not from MySql)
            exception = ex.Message
        End Try
        Return book

    End Function

    ''' <summary>
    ''' search books
    ''' Used procedure
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function SearchBooks(ByVal maSach As String, ByVal tenSach As String, ByVal theLoai As String, ByVal tacGia As String,
                                       ByVal donGia As Decimal, ByVal donGiaCompareType As String,
                                       ByVal soLuongTon As Integer, ByVal soLuongTonCompareType As String, ByVal tinhTrang As Boolean,
                                       Optional ByRef exception As String = "") As DataTable

        'store data
        Dim dataTable As DataTable = Nothing

        'query = String.Format("select MaSach As 'Mã Sách', TenSach As 'Tên Sách', TheLoai As 'Thể Loại',TacGia As 'Tác Giả',
        '                              SoLuongTon As 'Số Lượng Tồn',DonGia As 'Đơn Giá' from SACH where MaSach like '%{0}%' and  
        '                              TenSach like '%{1}%' and TheLoai like '%{2}%' and TacGia like '%{3}%' and DonGia {4} '{5}' and SoLuongTon {6} '{7}'",
        '                              maSach, tenSach, theLoai, tacGia, donGiaCompareType, donGia, soLuongTonCompareType, soLuongTon)

        Try
            'dataTable = MYSQLCONNECTIONDAO.GetDataTableByQuery(query, exception)
            dataTable = MYSQLCONNECTIONDAO.GetDataTableByProcedure("FindBooks", exception, New MySqlParameter("@_MaSach", maSach), New MySqlParameter("@_TenSach", tenSach),
                                               New MySqlParameter("@_TheLoai", theLoai), New MySqlParameter("@_TacGia", tacGia),
                                               New MySqlParameter("@_DonGia", donGia), New MySqlParameter("@_DonGiaCompareType", donGiaCompareType),
                                               New MySqlParameter("@_SoLuongTon", soLuongTon), New MySqlParameter("@_SoLuongTonCompareType", soLuongTonCompareType),
                                               New MySqlParameter("@_TinhTrang", tinhTrang))
        Catch ex As Exception 'exception from system, not mysqlException
            exception = ex.Message
        End Try
        Return dataTable
        'Return books
    End Function

    ''' <summary>
    '''Get all unremoved book ids
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function GetAllBookIDs(Optional ByRef exception As String = "") As List(Of String)

        'store data
        Dim bookIDs As List(Of String) = Nothing


        Try

            bookIDs = New List(Of String)

            Dim query = String.Format("select MaSach from SACH where TinhTrang = true")

            'Excute query in MySQL
            Dim reader As MySqlDataReader = MYSQLCONNECTIONDAO.ExcuteQuery(query, exception)

            If (exception = "") Then
                While (reader.Read)
                    bookIDs.Add(reader.GetString("MaSach"))
                End While
            End If

        Catch ex As Exception 'exception from system, not mysqlException
            exception = ex.Message
        End Try

        Return bookIDs

    End Function


#End Region

#Region "Insert, Remove, Update"

    ''' <summary>
    ''' Insert a book into database
    ''' Used procedure
    ''' </summary>
    ''' <param name="book"></param>
    ''' <returns></returns>
    Public Shared Function InsertBook(ByVal book As SACHDTO, Optional ByRef exception As String = "") As Boolean
        'query = String.Format("Insert into SACH values('{0}','{1}','{2}','{3}','{4}','{5}')",
            '                                          book.MaSach, book.TenSach, book.TheLoai, book.TacGia, book.SoLuongTon, book.DonGia)
            'Return DoBookTask(exception)

            Try

            'ExcuteQuery
            MYSQLCONNECTIONDAO.ExcuteProcedure("InsertBook", exception, New MySqlParameter("@_MaSach", book.MaSach), New MySqlParameter("@_TenSach", book.TenSach),
                                               New MySqlParameter("@_TheLoai", book.TheLoai), New MySqlParameter("@_TacGia", book.TacGia),
                                               New MySqlParameter("@_SoLuongTon", book.SoLuongTon), New MySqlParameter("@_DonGia", book.DonGia),
                                               New MySqlParameter("@_TinhTrang", True))

            'if there is no exception
            If (exception = "") Then Return True

        Catch ex As Exception
            exception = ex.Message
        End Try

        Return False

    End Function

    ''' <summary>
    ''' remove a book by changing its TrangThai
    ''' </summary>
    ''' <param name="maSach"></param>
    ''' <returns></returns>
    Public Shared Function RemoveBook(ByVal maSach As String, Optional ByRef exception As String = "") As Boolean

        'query = String.Format("delete from SACH where MaSach = '{0}'", maSach)
        'Return DoBookTask(exception)

        ''Find the book by ID
        'Dim book As SACHDTO = FindBookByID(maSach, exception)

        'If (book Is Nothing) Then
        '    Return False
        'End If

        ''Create the XmlDocument.
        'Dim xmlDoc As XmlDocument = New XmlDocument()
        ''Load xml Document
        'xmlDoc.Load("RemovedBooks.xml")

        ''if this book has been removed 
        'If (xmlDoc.SelectSingleNode("Books/BookID[text()='" + maSach + "']") IsNot Nothing) Then
        '    Return False
        'End If

        ''Create node
        'Dim bookIDNode As XmlNode = xmlDoc.CreateElement("BookID")
        'bookIDNode.InnerText = maSach

        'xmlDoc.DocumentElement.AppendChild(bookIDNode)

        'xmlDoc.Save("RemovedBooks.xml")

        'Return True

        Try

            'ExcuteQuery
            MYSQLCONNECTIONDAO.ExcuteProcedure("UpdateBookStatus", exception, New MySqlParameter("@_MaSach", maSach),
                                               New MySqlParameter("@_TinhTrang", False))

            'if there is no exception
            If (exception = "") Then Return True

        Catch ex As Exception
            exception = ex.Message
        End Try

        Return False

    End Function

    ''' <summary>
    ''' Update a book by its ID
    ''' Used procedure
    ''' </summary>
    ''' <param name="book"></param>
    ''' <returns></returns>
    Public Shared Function UpdateBook(ByVal book As SACHDTO, Optional ByRef exception As String = "") As Boolean
        'query = String.Format("update SACH set TenSach='{1}',TheLoai='{2}', TacGia='{3}',DonGia='{4}' where MaSach='{0}'",
        '                                           book.MaSach, book.TenSach, book.TheLoai, book.TacGia, book.DonGia)
        'Return DoBookTask(exception)
        Try

            'ExcuteQuery
            MYSQLCONNECTIONDAO.ExcuteProcedure("UpdateBook", exception, New MySqlParameter("@_MaSach", book.MaSach), New MySqlParameter("@_TenSach", book.TenSach),
                                               New MySqlParameter("@_TheLoai", book.TheLoai), New MySqlParameter("@_TacGia", book.TacGia),
                                               New MySqlParameter("@_DonGia", book.DonGia))

            'if there is no exception
            If (exception = "") Then Return True

        Catch ex As Exception
            exception = ex.Message
        End Try

        Return False

    End Function

    ''' <summary>
    ''' Update soLuongTon after selling or importing
    ''' used procedure
    ''' </summary>
    ''' <param name="maSach"></param>
    ''' <param name="soLuong"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function UpdateInventory(ByVal maSach As String, ByVal soLuong As Integer, Optional ByRef exception As String = "") As Boolean
        'query = String.Format("update SACH set SoLuongTon = SoLuongTon + {0} where MaSach='{1}'",
        '                                        soLuong, maSach)
        'Return DoBookTask(exception)

        Try

            'ExcuteQuery
            MYSQLCONNECTIONDAO.ExcuteProcedure("UpdateBookInventory", exception, New MySqlParameter("@_MaSach", maSach),
                                               New MySqlParameter("@_SoLuong", soLuong))

            'if there is no exception
            If (exception = "") Then Return True

        Catch ex As Exception
            exception = ex.Message
        End Try

        Return False

    End Function

    ''' <summary>
    ''' retrieve removed books
    ''' used procedure
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function RetriveRemovedBook(ByVal maSach As String, Optional ByRef exception As String = "") As Boolean

        'Try
        '    'Create the XmlDocument.
        '    Dim xmlDoc As XmlDocument = New XmlDocument()
        '    'Load xml Document
        '    xmlDoc.Load("RemovedBooks.xml")

        '    'if this book has been removed 
        '    Dim bookToRetrieve = xmlDoc.SelectSingleNode("Books/BookID[text()='" + maSach + "']")
        '    If (bookToRetrieve IsNot Nothing) Then
        '        xmlDoc.RemoveChild(bookToRetrieve)
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
            MYSQLCONNECTIONDAO.ExcuteProcedure("UpdateBookStatus", exception, New MySqlParameter("@_MaSach", maSach),
                                               New MySqlParameter("@_TinhTrang", True))

            'if there is no exception
            If (exception = "") Then Return True

        Catch ex As Exception
            exception = ex.Message
        End Try

        Return False

    End Function

#End Region

#Region "Other functions"

    ''' <summary>
    ''' get new book ID
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function GetNewBookID(Optional ByRef exception As String = "") As String
        Dim indexID As Integer = 0
        Dim newID As String = Nothing
        Try
            'excute query 
            Dim reader As MySqlDataReader = MYSQLCONNECTIONDAO.ExcuteQuery("select Max(cast(Substring(MaSach,3, length(MaSach)-2) as unsigned)) as 'MaxMaSach' from SACH", exception)

            'get the biggest MaSach index in database
            If (exception = "") Then
                While reader.Read

                    If (reader.IsDBNull(0)) Then
                        Exit While
                    End If

                    indexID = Integer.Parse(reader.GetString("MaxMaSach"))

                End While

                'set newID string
                newID = "MS" & (indexID + 1).ToString("0000")


            End If

        Catch ex As Exception
            exception = ex.Message
        End Try

        Return newID
    End Function

#End Region

#Region "Don't mind"

    ''' <summary>
    ''' Find books has the little similar in the ID
    ''' </summary>
    ''' <param name="maSach"></param>
    ''' <returns></returns>
    Public Shared Function FindBooksByID(ByVal maSach As String, Optional ByRef exception As String = "") As DataTable
        query = String.Format("select MaSach As 'Mã Sách', TenSach As 'Tên Sách', TheLoai As 'Thể Loại',TacGia As 'Tác Giả',
                                      SoLuongTon As 'Số Lượng Tồn',DonGia As 'Đơn Giá' from SACH where MaSach like '%{0}%'", maSach)
        Return FindBooks(exception)
    End Function

    ''' <summary>
    ''' Find books by its name
    ''' </summary>
    ''' <param name="tenSach"></param>
    ''' <returns></returns>
    Public Shared Function FindBooksByName(ByVal tenSach As String, Optional ByRef exception As String = "") As DataTable
        query = String.Format("select MaSach As 'Mã Sách', TenSach As 'Tên Sách', TheLoai As 'Thể Loại',TacGia As 'Tác Giả',
                                      SoLuongTon As 'Số Lượng Tồn',DonGia As 'Đơn Giá' from SACH where TenSach like '%{0}%'", tenSach)
        Return FindBooks(exception)
    End Function

    ''' <summary>
    ''' Find books by its Author Name
    ''' </summary>
    ''' <param name="tacGia"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function FindBooksbyAuthorName(ByVal tacGia As String, Optional ByRef exception As String = "") As DataTable

        query = String.Format("select MaSach As 'Mã Sách', TenSach As 'Tên Sách', TheLoai As 'Thể Loại',TacGia As 'Tác Giả',
                                      SoLuongTon As 'Số Lượng Tồn',DonGia As 'Đơn Giá' from SACH where TacGia like'%{0}%'", tacGia)
        Return FindBooks(exception)
    End Function

    ''' <summary>
    ''' Find books by Type
    ''' </summary>
    ''' <param name="theLoai"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function FindBooksbyType(ByVal theLoai As String, Optional ByRef exception As String = "") As DataTable

        query = String.Format("select MaSach As 'Mã Sách', TenSach As 'Tên Sách', TheLoai As 'Thể Loại',TacGia As 'Tác Giả',
                                      SoLuongTon As 'Số Lượng Tồn',DonGia As 'Đơn Giá' from SACH where TheLoai like'%{0}%'", theLoai)
        Return FindBooks(exception)
    End Function

    ''' <summary>
    ''' Find books by price
    ''' </summary>
    ''' <param name="donGia"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function FindBooksbyPrice(ByVal donGia As Decimal, ByVal compareType As String, Optional ByRef exception As String = "") As DataTable
        query = String.Format("select MaSach As 'Mã Sách', TenSach As 'Tên Sách', TheLoai As 'Thể Loại',TacGia As 'Tác Giả',
                                      SoLuongTon As 'Số Lượng Tồn',DonGia As 'Đơn Giá' from SACH where DonGia {0} '{1}'", compareType, donGia)
        Return FindBooks(exception)
    End Function

    ''' <summary>
    ''' Find books by soLuongTon
    ''' </summary>
    ''' <param name="soLuongTon"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function FindBooksbyInventory(ByVal soLuongTon As Integer, ByVal compareType As String, Optional ByRef exception As String = "") As DataTable
        query = String.Format("select MaSach As 'Mã Sách', TenSach As 'Tên Sách', TheLoai As 'Thể Loại',TacGia As 'Tác Giả',
                                      SoLuongTon As 'Số Lượng Tồn',DonGia As 'Đơn Giá' from SACH where soLuongTon {0} '{1}'", compareType, soLuongTon)
        Return FindBooks(exception)
    End Function

    ''' <summary>
    ''' this function is used like a pattern for all the other find books function
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Private Shared Function FindBooks(Optional ByRef exception As String = "") As DataTable
        'store data
        Dim dataTable As DataTable = Nothing
        Try
            dataTable = MYSQLCONNECTIONDAO.GetDataTableByQuery(query, exception)
        Catch ex As Exception 'exception from system, not mysqlException
            exception = ex.Message
        End Try
        Return dataTable
        'Return books
    End Function

    ''' <summary>
    ''' Count books
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function CountBooks(Optional ByRef exception As String = "") As Integer
        Dim count As Integer = Nothing
        Try
            'excute query 
            Dim reader As MySqlDataReader = MYSQLCONNECTIONDAO.ExcuteQuery("select count(*) from SACH", exception)

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
    ''' a pattern function for some task 
    ''' </summary>
    Private Shared Function DoBookTask(Optional ByRef exception As String = "") As Boolean
        Try

            'ExcuteQuery
            MYSQLCONNECTIONDAO.ExcuteQuery(query, exception)

            'if there is no exception
            If (exception = "") Then Return True

        Catch ex As Exception
            exception = ex.Message
        End Try

        Return False

    End Function

    ''' <summary>
    ''' Find removed books
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function FindRemovedBooks(Optional ByRef exception As String = "") As List(Of SACHDTO)

        'store data
        Dim books As List(Of SACHDTO) = New List(Of SACHDTO)

        Try
            'Create the XmlDocument.
            Dim xmlDoc As XmlDocument = New XmlDocument()
            'Load xml Document
            xmlDoc.Load("RemovedBooks.xml")

            'Loop through all the removed books
            For Each node As XmlNode In xmlDoc.SelectNodes("Books/BookID")
                Dim book = FindBookByID(node.InnerText, exception)
                If (exception <> "") Then Return Nothing
                books.Add(book)
            Next

        Catch ex As Exception 'exception from system, not mysqlException
            exception = ex.Message
        End Try
        Return books
        'Return books
    End Function

#End Region

End Class
