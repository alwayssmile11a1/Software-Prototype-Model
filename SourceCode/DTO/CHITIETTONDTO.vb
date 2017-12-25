Public Class CHITIETTONDTO
    Dim _maChiTietTon As String
    Dim _maBaoCaoTon As String
    Dim _maSach As String
    Dim _tonDau As Integer
    Dim _tonPhatSinh As Integer
    Dim _tonCuoi As Integer

#Region "Properties"

    Public Property MaChiTietTon As String
        Get
            Return _maChiTietTon
        End Get
        Set(value As String)
            _maChiTietTon = value
        End Set
    End Property

    Public Property MaSach As String
        Get
            Return _maSach
        End Get
        Set(value As String)
            _maSach = value
        End Set
    End Property

    Public Property TonDau As Integer
        Get
            Return _tonDau
        End Get
        Set(value As Integer)
            _tonDau = value
        End Set
    End Property

    Public Property TonPhatSinh As Integer
        Get
            Return _tonPhatSinh
        End Get
        Set(value As Integer)
            _tonPhatSinh = value
        End Set
    End Property

    Public Property TonCuoi As Integer
        Get
            Return _tonCuoi
        End Get
        Set(value As Integer)
            _tonCuoi = value
        End Set
    End Property

    Public Property MaBaoCaoTon As String
        Get
            Return _maBaoCaoTon
        End Get
        Set(value As String)
            _maBaoCaoTon = value
        End Set
    End Property


#End Region

    'Contructor 
    Public Sub New()
        _maChiTietTon = ""
        _maBaoCaoTon = ""
        _maSach = ""
        _tonDau = 0
        _tonPhatSinh = 0
        _tonCuoi = 0
    End Sub

    Public Sub New(ByVal maChiTietTon As String, ByVal maBaoCaoTon As String, ByVal maSach As String, ByVal tonDau As Integer, ByVal tonPhatSinh As Integer, ByVal tonCuoi As Integer)
        _maChiTietTon = maChiTietTon
        _maSach = maSach
        _maBaoCaoTon = maBaoCaoTon
        _tonDau = tonDau
        _tonPhatSinh = tonPhatSinh
        _tonCuoi = tonCuoi
    End Sub

    'Destructor
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class

