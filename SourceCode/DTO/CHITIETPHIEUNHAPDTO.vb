Public Class CHITIETPHIEUNHAPDTO
    Private _maChiTietPhieuNhap As String
    Private _maPhieuNhap As String
    Private _maSach As String
    Private _soLuongNhap As Integer

    Public Property MaChiTietPhieuNhap As String
        Get
            Return _maChiTietPhieuNhap
        End Get
        Set(value As String)
            _maChiTietPhieuNhap = value
        End Set
    End Property

    Public Property MaPhieuNhap As String
        Get
            Return _maPhieuNhap
        End Get
        Set(value As String)
            _maPhieuNhap = value
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

    Public Property SoLuongNhap As Integer
        Get
            Return _soLuongNhap
        End Get
        Set(value As Integer)
            _soLuongNhap = value
        End Set
    End Property

    'Contructor 
    Public Sub New()
        _maChiTietPhieuNhap = ""
        _maPhieuNhap = ""
        _maSach = ""
        _soLuongNhap = 0
    End Sub

    Public Sub New(ByVal maChiTietPhieuNhap As String, ByVal maPhieuNhap As String, ByVal maSach As String, ByVal soLuongNhap As Integer)
        _maChiTietPhieuNhap = maChiTietPhieuNhap
        _maPhieuNhap = maPhieuNhap
        _maSach = maSach
        _soLuongNhap = soLuongNhap
    End Sub

    'Destructor
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub


End Class
