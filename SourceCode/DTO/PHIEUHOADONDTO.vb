Public Class PHIEUHOADONDTO
    Private _maPhieuHoaDon As String
    Private _maKhachHang As String
    Private _ngayLapHoaDon As String

    Public Property MaPhieuHoaDon As String
        Get
            Return _maPhieuHoaDon
        End Get
        Set(value As String)
            _maPhieuHoaDon = value
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

    Public Property NgayLapHoaDon As String
        Get
            Return _ngayLapHoaDon
        End Get
        Set(value As String)
            _ngayLapHoaDon = value
        End Set
    End Property

    'Constructor
    Public Sub New()
        _maPhieuHoaDon = ""
        _maKhachHang = ""
        _ngayLapHoaDon = DateTime.Today
    End Sub

    Public Sub New(ByVal maPhieuHoaDon As String, ByVal maKhachHang As String, ByVal ngayLapHoaDon As String)
        _maPhieuHoaDon = maPhieuHoaDon
        _maKhachHang = maKhachHang
        _ngayLapHoaDon = ngayLapHoaDon
    End Sub

    'Destructor
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class
