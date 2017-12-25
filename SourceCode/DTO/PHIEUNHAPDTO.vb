Public Class PHIEUNHAPDTO
    Private _maPhieuNhap As String
    Private _ngayNhap As String

    Public Property MaPhieuNhap As String
        Get
            Return _maPhieuNhap
        End Get
        Set(value As String)
            _maPhieuNhap = value
        End Set
    End Property

    Public Property NgayNhap As String
        Get
            Return _ngayNhap
        End Get
        Set(value As String)
            _ngayNhap = value
        End Set
    End Property

    'Constructor
    Public Sub New()
        _maPhieuNhap = ""
        _ngayNhap = DateTime.Today
    End Sub

    Public Sub New(ByVal maPhieuNhap As String, ByVal ngayNhap As String)
        _maPhieuNhap = maPhieuNhap
        _ngayNhap = ngayNhap
    End Sub

    'Destructor
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class
