Public Class CHITIETPHIEUHOADONDTO
    Dim _maChiTietPhieuHoaDon As String
    Dim _maPhieuHoaDon As String
    Dim _maSach As String
    Dim _soLuongBan As Integer

#Region "Properties"
    Public Property MaChiTietPhieuHoaDon As String
        Get
            Return _maChiTietPhieuHoaDon
        End Get
        Set(value As String)
            _maChiTietPhieuHoaDon = value
        End Set
    End Property

    Public Property MaPhieuHoaDon As String
        Get
            Return _maPhieuHoaDon
        End Get
        Set(value As String)
            _maPhieuHoaDon = value
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

    Public Property SoLuongBan As Integer
        Get
            Return _soLuongBan
        End Get
        Set(value As Integer)
            _soLuongBan = value
        End Set
    End Property
#End Region

    'Contructor 
    Public Sub New()
        _maChiTietPhieuHoaDon = ""
        _maPhieuHoaDon = ""
        _maSach = ""
        _soLuongBan = 0
    End Sub

    Public Sub New(ByVal maChiTietPhieuHoaDon As String, ByVal maPhieuHoaDon As String, ByVal maSach As String, ByVal soLuongBan As Integer)
        _maChiTietPhieuHoaDon = maChiTietPhieuHoaDon
        _maPhieuHoaDon = maPhieuHoaDon
        _maSach = maSach
        _soLuongBan = soLuongBan
    End Sub

    'Destructor
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub



End Class
