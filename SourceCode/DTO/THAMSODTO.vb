Public Class THAMSODTO
    Shared _soLuongNhapToiThieu As Integer = 0
    Shared _soLuongTonToiDaTruocNhap As Integer = 300
    Shared _soLuongTonToiThieuSauBan As Integer = 0
    Shared _soTienNoToiDa As Decimal = 0
    Shared _suDungQuyDinh4 As Boolean = False

#Region "Properties"

    Public Shared Property SoLuongNhapToiThieu As Integer
        Get
            Return _soLuongNhapToiThieu
        End Get
        Set(value As Integer)
            _soLuongNhapToiThieu = value
        End Set
    End Property

    Public Shared Property SoLuongTonToiDaTruocNhap As Integer
        Get
            Return _soLuongTonToiDaTruocNhap
        End Get
        Set(value As Integer)
            _soLuongTonToiDaTruocNhap = value
        End Set
    End Property

    Public Shared Property SoLuongTonToiThieuSauBan As Integer
        Get
            Return _soLuongTonToiThieuSauBan
        End Get
        Set(value As Integer)
            _soLuongTonToiThieuSauBan = value
        End Set
    End Property

    Public Shared Property SoTienNoToiDa As Decimal
        Get
            Return _soTienNoToiDa
        End Get
        Set(value As Decimal)
            _soTienNoToiDa = value
        End Set
    End Property

    Public Shared Property SuDungQuyDinh4 As Boolean
        Get
            Return _suDungQuyDinh4
        End Get
        Set(value As Boolean)
            _suDungQuyDinh4 = value
        End Set
    End Property
#End Region

    'Destructor
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub


End Class
