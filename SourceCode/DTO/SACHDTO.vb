Public Class SACHDTO
    Private _maSach As String
    Private _tenSach As String
    Private _theLoai As String
    Private _tacGia As String
    Private _soLuongTon As Integer
    Private _donGia As Decimal

    Public Property MaSach As String
        Get
            Return _maSach
        End Get
        Set(value As String)
            _maSach = value
        End Set
    End Property

    Public Property TenSach As String
        Get
            Return _tenSach
        End Get
        Set(value As String)
            _tenSach = value
        End Set
    End Property

    Public Property TheLoai As String
        Get
            Return _theLoai
        End Get
        Set(value As String)
            _theLoai = value
        End Set
    End Property

    Public Property TacGia As String
        Get
            Return _tacGia
        End Get
        Set(value As String)
            _tacGia = value
        End Set
    End Property

    Public Property SoLuongTon As Integer
        Get
            Return _soLuongTon
        End Get
        Set(value As Integer)
            _soLuongTon = value
        End Set
    End Property

    Public Property DonGia As Decimal
        Get
            Return _donGia
        End Get
        Set(value As Decimal)
            _donGia = value
        End Set
    End Property

    'Constructor
    Public Sub New(ByVal maSach As String, ByVal tenSach As String, ByVal theLoai As String,
                   ByVal tacGia As String, ByVal soLuongTon As Integer, ByVal donGia As Decimal)
        _maSach = maSach
        _tenSach = tenSach
        _theLoai = theLoai
        _tacGia = tacGia
        _soLuongTon = soLuongTon
        _donGia = donGia
    End Sub

    Public Sub New()
        _maSach = ""
        _tenSach = ""
        _theLoai = ""
        _tacGia = ""
        _soLuongTon = 0
        _donGia = 0F
    End Sub

    'Destructor
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub


End Class
