Imports DAO
Imports DTO
Imports System.Text.RegularExpressions

Public Class SACHBUS

#Region "Find"

    ''' <summary>
    ''' Find a book by its ID
    ''' Used procedure
    ''' </summary>
    ''' <param name="maSach"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function FindBookByID(ByVal maSach As String, ByVal tinhTrang As Boolean, Optional ByRef exception As String = "") As SACHDTO
        ''Create the XmlDocument.
        'Dim xmlDoc As XmlDocument = New XmlDocument()
        ''Load xml Document
        'xmlDoc.Load("RemovedBooks.xml")

        ''if this book has been removed 
        'If (xmlDoc.SelectSingleNode("Books/BookID[text()='" + maSach.ToUpper + "']") IsNot Nothing) Then
        '    Return Nothing
        'End If

        Return SACHDAO.FindBookByID(maSach, tinhTrang, exception)

    End Function

    ''' <summary>
    ''' Search books
    ''' Used procedure
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function SearchBooks(ByVal maSach As String, ByVal tenSach As String, ByVal theLoai As String, ByVal tacGia As String,
                                       ByVal donGia As Decimal, ByVal donGiaCompareType As String,
                                       ByVal soLuongTon As Integer, ByVal soLuongTonCompareType As String,
                                       ByVal tinhTrang As Boolean,
                                       Optional ByRef exception As String = "") As DataTable

        'Dim dataTable As DataTable = SACHDAO.SearchBooks(maSach, tenSach, theLoai, tacGia, donGia, donGiaCompareType, soLuongTon, soLuongTonCompareType, exception)

        'If (exception <> "") Then Return dataTable

        'dataTable.PrimaryKey = New DataColumn() {dataTable.Columns("Mã Sách")}

        ''Create the XmlDocument.
        'Dim xmlDoc As XmlDocument = New XmlDocument()
        ''Load xml Document
        'xmlDoc.Load("RemovedBooks.xml")

        ''If this is the removed book
        'For Each node As XmlNode In xmlDoc.SelectNodes("Books/BookID")
        '    If (dataTable.Rows.Find(node.InnerText) IsNot Nothing) Then
        '        dataTable.Rows.Find(node.InnerText).Delete()
        '    End If

        'Next

        'Return dataTable

        Return SACHDAO.SearchBooks(maSach, tenSach, theLoai, tacGia, donGia, donGiaCompareType, soLuongTon, soLuongTonCompareType, tinhTrang, exception)

    End Function

    ''' <summary>
    '''Get all unremoved book ids
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function GetAllBookIDs(Optional ByRef exception As String = "") As List(Of String)

        Return SACHDAO.GetAllBookIDs(exception)

    End Function

#End Region

#Region "Remove, Update, Insert"

    ''' <summary>
    ''' Remove a book by its ID
    ''' don't need to check if maSach has the right format because if maSach has the wrong format, it doesn't have in the database initially anyway  
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function RemoveBook(ByVal maSach As String, Optional ByRef exception As String = "") As Boolean
        Return SACHDAO.RemoveBook(maSach, exception)
    End Function

    ''' <summary>
    ''' Insert a book into database
    ''' should check the format of all information of the book before insert into database
    ''' Used procedure
    ''' </summary>
    ''' <param name="book"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function InsertBook(ByVal book As SACHDTO, Optional ByRef exception As String = "") As Boolean
        If (IsRightFormat(book, exception) = True) Then
            Return SACHDAO.InsertBook(book, exception)
        End If
        Return False
    End Function

    ''' <summary>
    ''' Update a Book by its ID
    '''Used procedure
    ''' </summary>
    ''' <param name="book"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function UpdateBook(ByVal book As SACHDTO, Optional ByRef exception As String = "") As Boolean
        If (IsRightFormat(book, exception) = True) Then
            Return SACHDAO.UpdateBook(book, exception)
        End If
        Return False
    End Function

    ''' <summary>
    ''' Update SoLuongTon by bookID
    '''  Used procedure
    ''' </summary>
    ''' <param name="maSach"></param>
    ''' <param name="soLuong"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function UpdateInventory(ByVal maSach As String, ByVal soLuong As Integer, Optional ByRef exception As String = "") As Boolean
        Return SACHDAO.UpdateInventory(maSach, soLuong, exception)
    End Function

    ''' <summary>
    ''' retrieve removed books
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function RetriveRemovedBook(ByVal maSach As String, Optional ByRef exception As String = "") As Boolean

        Return SACHDAO.RetriveRemovedBook(maSach, exception)
    End Function

#End Region

#Region "other functions"

    ''' <summary>
    ''' get new book ID
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function GetNewBookID(Optional ByRef exception As String = "") As String
        Return SACHDAO.GetNewBookID(exception)
    End Function

#End Region

#Region "Check Exception"

    ''' <summary>
    ''' Check format of all information in the book. True means right format 
    ''' </summary>
    ''' <param name="book"></param>
    ''' <returns></returns>
    Private Shared Function IsRightFormat(ByVal book As SACHDTO, Optional ByRef exception As String = "") As Boolean

        If (book.MaSach.Count > 10) Then
            exception = "Mã sách tối đa 10 kí tự"
            Return False
        End If

        If (book.TenSach.Count > 100 Or book.TenSach.Trim.Count <= 0) Then
            exception = "Tên sách không dưới 0 kí tự và tối đa 100 kí tự"
            Return False
        End If

        If (book.TheLoai.Count > 50 Or book.TheLoai.Trim.Count <= 0) Then
            exception = "Thể loại không dưới 0 kí tự và tối đa 50 kí tự"
            Return False
        End If

        If (book.TacGia.Count > 50 Or book.TacGia.Trim.Count <= 0) Then
            exception = "Tác giả không dưới 0 kí tự và tối đa 50 kí tự"
            Return False
        End If

        If (Regex.IsMatch(book.TenSach.Trim, "^[\s\w]*$") = False Or Regex.IsMatch(book.TacGia.Trim, "^[\s\w]*$") = False) Then
            exception = "tên sách hoặc tác giả không được chứa kí tự đặc biệt"
            Return False
        End If

        If (book.DonGia > 9999999999) Then
            exception = "Đơn giá tối đa 10 kí tự"
            Return False
        End If



        Return True
    End Function

#End Region

#Region "Don't mind"

    ''' <summary>
    ''' Find  books by its ID
    ''' </summary>
    ''' <param name="maSach"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function FindBooksByID(ByVal maSach As String, Optional ByRef exception As String = "") As DataTable
        Return SACHDAO.FindBooksByID(maSach, exception)
    End Function

    ''' <summary>
    ''' Find Books by its Name
    ''' </summary>
    ''' <param name="tenSach"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function FindBooksByName(ByVal tenSach As String, Optional ByRef exception As String = "") As DataTable
        Return SACHDAO.FindBooksByName(tenSach, exception)
    End Function

    ''' <summary>
    ''' Find Books by its Author Name
    ''' </summary>
    ''' <param name="tacGia"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function FindBooksByAuthorName(ByVal tacGia As String, Optional ByRef exception As String = "") As DataTable
        Return SACHDAO.FindBooksbyAuthorName(tacGia, exception)
    End Function

    ''' <summary>
    ''' Find books by Type
    ''' </summary>
    ''' <param name="theLoai"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function FindBooksbyType(ByVal theLoai As String, Optional ByRef exception As String = "") As DataTable
        Return SACHDAO.FindBooksbyType(theLoai, exception)
    End Function

    ''' <summary>
    ''' Find books by inventory
    ''' </summary>
    ''' <param name="soLuongTon"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function FindBooksbyInventory(ByVal soLuongTon As Integer, ByVal compareType As String, Optional ByRef exception As String = "") As DataTable
        Return SACHDAO.FindBooksbyInventory(soLuongTon, compareType, exception)
    End Function

    ''' <summary>
    ''' Find books by price
    ''' </summary>
    ''' <param name="donGia"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function FindBooksbyPrice(ByVal donGia As Decimal, ByVal compareType As String, Optional ByRef exception As String = "") As DataTable
        Return SACHDAO.FindBooksbyPrice(donGia, compareType, exception)
    End Function

    ''' <summary>
    ''' Count books
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function CountBooks(Optional ByRef exception As String = "") As Integer
        Return SACHDAO.CountBooks(exception)
    End Function

    ''' <summary>
    ''' Find removed books
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function FindRemovedBooks(Optional ByRef exception As String = "") As List(Of SACHDTO)

        Return SACHDAO.FindRemovedBooks(exception)
    End Function

#End Region

End Class
