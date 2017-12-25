Public Class KHACHHANGDTO
    Private _maKhachHang As String
    Private _hoTenKhachHang As String
    Private _diaChi As String
    Private _dienThoai As String
    Private _eMail As String
    Private _soTienNo As Decimal

#Region "Properties"
    Public Property MaKhachHang As String
        Get
            Return _maKhachHang
        End Get
        Set(value As String)
            _maKhachHang = value
        End Set
    End Property

    Public Property HoTenKhachHang As String
        Get
            Return _hoTenKhachHang
        End Get
        Set(value As String)
            _hoTenKhachHang = value
        End Set
    End Property

    Public Property DiaChi As String
        Get
            Return _diaChi
        End Get
        Set(value As String)
            _diaChi = value
        End Set
    End Property

    Public Property DienThoai As String
        Get
            Return _dienThoai
        End Get
        Set(value As String)
            _dienThoai = value
        End Set
    End Property

    Public Property EMail As String
        Get
            Return _eMail
        End Get
        Set(value As String)
            _eMail = value
        End Set
    End Property

    Public Property SoTienNo As Decimal
        Get
            Return _soTienNo
        End Get
        Set(value As Decimal)
            _soTienNo = value
        End Set
    End Property
#End Region

#Region "Constructor and Destructor"
    'Constructor
    Public Sub New()
        MaKhachHang = ""
        HoTenKhachHang = ""
        DiaChi = ""
        DienThoai = ""
        EMail = ""
        SoTienNo = 0
    End Sub

    Public Sub New(ByVal maKhachHang As String, ByVal hoTenKhachHang As String, ByVal diaChi As String, ByVal dienThoai As String, ByVal eMail As String, ByVal soTienNo As Decimal)
        Me.MaKhachHang = maKhachHang
        Me.HoTenKhachHang = hoTenKhachHang
        Me.DiaChi = diaChi
        Me.DienThoai = dienThoai
        Me.EMail = eMail
        Me.SoTienNo = soTienNo
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
#End Region

End Class
