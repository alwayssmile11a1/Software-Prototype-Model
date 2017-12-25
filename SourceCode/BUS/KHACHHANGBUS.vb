Imports DAO
Imports DTO
Imports System.Text.RegularExpressions

Public Class KHACHHANGBUS

#Region "Find"

    ''' <summary>
    ''' Find a customer by ID
    ''' used procedure
    ''' </summary>
    ''' <param name="maKhachHang"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function FindCustomerByID(ByVal maKhachHang As String, ByVal tinhTrang As Boolean, Optional ByRef exception As String = "") As KHACHHANGDTO

        ''Create the XmlDocument.
        'Dim xmlDoc As XmlDocument = New XmlDocument()
        ''Load xml Document
        'xmlDoc.Load("RemovedCustomers.xml")

        ''if this book has been removed 
        'If (xmlDoc.SelectSingleNode("Customers/CustomerID[text()='" + maKhachHang.ToUpper + "']") IsNot Nothing) Then
        '    Return Nothing
        'End If

        Return KHACHHANGDAO.FindCustomerByID(maKhachHang, tinhTrang, exception)

    End Function

    ''' <summary>
    ''' Search customers
    ''' used procedure
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function SearchCustomers(ByVal maKhachHang As String, ByVal tenKhachHang As String, ByVal diaChi As String, ByVal dienThoai As String,
                                       ByVal eMail As String, ByVal soTienNoCompareType As String,
                                       ByVal soTienNo As Decimal, ByVal tinhTrang As Boolean, Optional ByRef exception As String = "") As DataTable

        'Dim dataTable As DataTable = KHACHHANGDAO.SearchCustomers(maKhachHang, tenKhachHang, diaChi, dienThoai, eMail, soTienNoCompareType, soTienNo, exception)

        'If (exception <> "") Then Return dataTable

        'dataTable.PrimaryKey = New DataColumn() {dataTable.Columns("Mã Khách Hàng")}

        ''Create the XmlDocument.
        'Dim xmlDoc As XmlDocument = New XmlDocument()
        ''Load xml Document
        'xmlDoc.Load("RemovedCustomers.xml")

        ''If this is the removed book
        'For Each node As XmlNode In xmlDoc.SelectNodes("Customers/CustomerID")
        '    If (dataTable.Rows.Find(node.InnerText) IsNot Nothing) Then
        '        dataTable.Rows.Find(node.InnerText).Delete()
        '    End If
        'Next

        'Return dataTable

        Return KHACHHANGDAO.SearchCustomers(maKhachHang, tenKhachHang, diaChi, dienThoai, eMail, soTienNoCompareType, soTienNo, tinhTrang, exception)

    End Function

    ''' <summary>
    '''Get all customer unremoved ids
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function GetAllCustomerIDs(Optional ByRef exception As String = "") As List(Of String)

        Return KHACHHANGDAO.GetAllCustomerIDs(exception)

    End Function

#End Region

#Region "Other functions"

    ''' <summary>
    ''' get new customer ID
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function GetNewCustomerID(Optional ByRef exception As String = "") As String
        Return KHACHHANGDAO.GetNewCustomerID()
    End Function

#End Region

#Region "Insert, Remove, Update"

    ''' <summary>
    ''' Insert new customer into Database
    ''' used procedure
    ''' </summary>
    ''' <param name="khachHang"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function InsertCustomer(ByVal khachHang As KHACHHANGDTO, Optional ByRef exception As String = "") As Boolean
        If (IsRightFormat(khachHang, exception) = True) Then
            Return KHACHHANGDAO.InsertCustomer(khachHang, exception)
        End If
        Return False
    End Function

    ''' <summary>
    ''' Remove a customer by ID
    ''' used procedure
    ''' </summary>
    ''' <param name="maKhachHang"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function RemoveCustomer(ByVal maKhachHang As String, Optional ByRef exception As String = "") As Boolean
        Return KHACHHANGDAO.RemoveCustomer(maKhachHang, exception)
    End Function

    ''' <summary>
    ''' Update a customer by ID
    ''' used procedure
    ''' </summary>
    ''' <param name="khachHang"></param>
    ''' <returns></returns>
    Public Shared Function UpdateCustomer(ByVal khachHang As KHACHHANGDTO, Optional ByRef exception As String = "") As Boolean
        If (IsRightFormat(khachHang, exception) = True) Then
            Return KHACHHANGDAO.UpdateCustomer(khachHang, exception)
        End If
        Return False
    End Function

    ''' <summary>
    ''' Update customer's debt
    ''' used procedure
    ''' </summary>
    ''' <param name="maKhachHang"></param>
    ''' <param name="soTien"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function UpdateCustomerDebt(ByVal maKhachHang As String, ByVal soTien As Decimal, Optional ByRef exception As String = "") As Boolean
        Return KHACHHANGDAO.UpdateCustomerDebt(maKhachHang, soTien, exception)
    End Function

    ''' <summary>
    ''' retrieve removed customer
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function RetriveRemovedCustomer(ByVal maKhachHang As String, Optional ByRef exception As String = "") As Boolean

        Return KHACHHANGDAO.RetriveRemovedCustomer(maKhachHang, exception)

    End Function

#End Region

#Region "Check Format"

    ''' <summary>
    ''' Check Format
    ''' </summary>
    ''' <param name="khachHang"></param>
    ''' <returns></returns>
    Private Shared Function IsRightFormat(ByVal khachHang As KHACHHANGDTO, Optional ByRef exception As String = "") As Boolean
        If (khachHang.MaKhachHang.Count > 10) Then
            exception = "Mã khách hàng không quá 10 kí tự"
            Return False
        End If
        If (khachHang.HoTenKhachHang.Count > 100 Or khachHang.HoTenKhachHang.Trim.Count <= 0) Then
            exception = "Họ tên khách hàng không dưới 0 ký tự và không quá 100 kí tự"
            Return False
        End If
        If (khachHang.DiaChi.Count > 100 Or khachHang.DiaChi.Trim.Count <= 0) Then
            exception = "Địa chỉ khách hàng không dưới 0 ký tự và không quá 100 kí tự"
            Return False
        End If

        If (khachHang.DienThoai.Count > 20 Or khachHang.DienThoai.Trim.Count <= 0) Then
            exception = "Điện thoại không dưới 0 ký tự và không quá 20 kí tự"
            Return False
        End If

        If (khachHang.EMail.Count > 50) Then
            exception = "không quá 50 kí tự"
            Return False
        End If

        If (Regex.IsMatch(khachHang.HoTenKhachHang.Trim, "^[\s\w]*$") = False Or Regex.IsMatch(khachHang.DiaChi.Trim, "^[\s\w]*$") = False Or
                                                                       Regex.IsMatch(khachHang.DienThoai.Trim, "^[\s\w]*$") = False) Then
            exception = "tên khách hàng, địa chỉ hoặc điện thoại không được chứa kí tự đặc biệt"
            Return False
        End If

        If (FormatChecking.CheckValid.IsValidPhoneNumber(khachHang.DienThoai, FormatChecking.CountryCode.Vietnam) = False) Then
            exception = "Số điện thoại không hợp lệ"
            Return False
        End If

        If (khachHang.EMail <> "" And FormatChecking.CheckValid.IsValidEmail(khachHang.EMail) = False) Then
            exception = "Email không hợp lệ"
            Return False
        End If


        If (khachHang.SoTienNo > 9999999999) Then
            exception = "Đơn giá tối đa 10 kí tự"
            Return False
        End If

        Return True

    End Function

#End Region


#Region "Don't mind"

    Public Shared Function FindCustomersByID(ByVal maKhachHang As String, Optional ByRef exception As String = "") As DataTable
        Return KHACHHANGDAO.FindCustomersByID(maKhachHang, exception)
    End Function

    Public Shared Function FindCustomersByName(ByVal tenKhachHang As String, Optional ByRef exception As String = "") As DataTable
        Return KHACHHANGDAO.FindCustomersByName(tenKhachHang, exception)

    End Function

    Public Shared Function FindCustomersByAddress(ByVal diaChi As String, Optional ByRef exception As String = "") As DataTable
        Return KHACHHANGDAO.FindCustomersByAddress(diaChi, exception)

    End Function

    ''' <summary>
    ''' Find Customers by Phonenumber
    ''' </summary>
    ''' <param name="dienThoai"></param>
    ''' <returns></returns>
    Public Shared Function FindCustomersByPhone(ByVal dienThoai As String, Optional ByRef exception As String = "") As DataTable
        Return KHACHHANGDAO.FindCustomersByPhone(dienThoai, exception)
    End Function

    ''' <summary>
    ''' Find Customers by email
    ''' </summary>
    ''' <param name="email"></param>
    ''' <returns></returns>
    Public Shared Function FindCustomersByEmail(ByVal email As String, Optional ByRef exception As String = "") As DataTable
        Return KHACHHANGDAO.FindCustomersByEmail(email, exception)
    End Function

    ''' <summary>
    ''' Find Customers by debt
    ''' </summary>
    ''' <param name="soTienNo"></param>
    ''' <param name="compareType"></param>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function FindCustomersbyDebt(ByVal soTienNo As Decimal, ByVal compareType As String, Optional ByRef exception As String = "") As DataTable
        Return KHACHHANGDAO.FindCustomersbyDebt(soTienNo, compareType, exception)
    End Function

    ''' <summary>
    ''' Count books
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function CountCustomers(Optional ByRef exception As String = "") As Integer
        Return KHACHHANGDAO.CountCustomers(exception)
    End Function

    ''' <summary>
    ''' Find removed customers
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function FindRemovedCustomers(Optional ByRef exception As String = "") As List(Of KHACHHANGDTO)
        Return KHACHHANGDAO.FindRemovedCustomers(exception)

    End Function

#End Region

End Class
