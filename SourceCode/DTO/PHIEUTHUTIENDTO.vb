Public Class PHIEUTHUTIENDTO
    Private _maPhieuThu As String
    Private _soTienThu As Decimal
    Private _ngayThuTien As String
    Private _maKhachHang As String

#Region "Properties"
    Public Property MaPhieuThu As String
        Get
            Return _maPhieuThu
        End Get
        Set(value As String)
            _maPhieuThu = value
        End Set
    End Property

    Public Property SoTienThu As Decimal
        Get
            Return _soTienThu
        End Get
        Set(value As Decimal)
            _soTienThu = value
        End Set
    End Property

    Public Property NgayThuTien As String
        Get
            Return _ngayThuTien
        End Get
        Set(value As String)
            _ngayThuTien = value
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
#End Region

    'Constructor
    Public Sub New()
        _maPhieuThu = ""
        _soTienThu = 0
        _maKhachHang = ""
        _ngayThuTien = DateTime.Now.Date
    End Sub

    Public Sub New(ByVal maPhieuThu As String, ByVal soTienThu As Decimal, ByVal maKhachHang As String, ByVal ngayThuTien As String)
        _maPhieuThu = maPhieuThu
        _soTienThu = soTienThu
        _maKhachHang = maKhachHang
        _ngayThuTien = ngayThuTien
    End Sub

    'Destructor
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
