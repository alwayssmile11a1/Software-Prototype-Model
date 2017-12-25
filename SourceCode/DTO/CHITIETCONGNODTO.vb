Public Class CHITIETCONGNODTO

    Dim _maChiTietCongNo As String
    Dim _maBaoCaoCongNo As String
    Dim _maKhachHang As String
    Dim _noDau As Decimal
    Dim _noCuoi As Decimal
    Dim _noPhatSinh As Decimal

#Region "Properties"
    Public Property MaChiTietCongNo As String
        Get
            Return _maChiTietCongNo
        End Get
        Set(value As String)
            _maChiTietCongNo = value
        End Set
    End Property

    Public Property MaKhachHang As String
        Get
            Return _maKhachHang
        End Get
        Set(value As String)
            _maKhachHang = value
        End Set
    End Property

    Public Property NoDau As Decimal
        Get
            Return _noDau
        End Get
        Set(value As Decimal)
            _noDau = value
        End Set
    End Property

    Public Property NoCuoi As Decimal
        Get
            Return _noCuoi
        End Get
        Set(value As Decimal)
            _noCuoi = value
        End Set
    End Property

    Public Property NoPhatSinh As Decimal
        Get
            Return _noPhatSinh
        End Get
        Set(value As Decimal)
            _noPhatSinh = value
        End Set
    End Property

    Public Property MaBaoCaoCongNo As String
        Get
            Return _maBaoCaoCongNo
        End Get
        Set(value As String)
            _maBaoCaoCongNo = value
        End Set
    End Property

#End Region

    'Contructor 
    Public Sub New()
        _maChiTietCongNo = ""
        _maBaoCaoCongNo = ""
        _maKhachHang = ""
        _noDau = 0
        _noCuoi = 0
        _noPhatSinh = 0
    End Sub

    Public Sub New(ByVal maChiTietCongNo As String, ByVal maBaoCaoCongNo As String, ByVal maKhachHang As String, ByVal noDau As Decimal, ByVal noPhatSinh As Decimal, ByVal noCuoi As Decimal)
        _maChiTietCongNo = maChiTietCongNo
        _maBaoCaoCongNo = maBaoCaoCongNo
        _maKhachHang = maKhachHang
        _noDau = noDau
        _noCuoi = noCuoi
        _noPhatSinh = noPhatSinh
    End Sub

    'Destructor
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class
