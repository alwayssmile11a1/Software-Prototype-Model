Public Class BAOCAOCONGNODTO
    Dim _maBaoCaoCongNo As String
    Dim _thang As Integer
    Dim _nam As Integer


#Region "Properties"
    Public Property MaBaoCaoCongNo As String
        Get
            Return _maBaoCaoCongNo
        End Get
        Set(value As String)
            _maBaoCaoCongNo = value
        End Set
    End Property

    Public Property Thang As Integer
        Get
            Return _thang
        End Get
        Set(value As Integer)
            _thang = value
        End Set
    End Property

    Public Property Nam As Integer
        Get
            Return _nam
        End Get
        Set(value As Integer)
            _nam = value
        End Set
    End Property
#End Region

    'Contructor 
    Public Sub New()
        _maBaoCaoCongNo = ""
        _thang = 0
        Nam = 0
    End Sub

    Public Sub New(ByVal maBaoCaoCongNo As String, ByVal thang As Integer, ByVal nam As Integer)
        _maBaoCaoCongNo = maBaoCaoCongNo
        _thang = thang
        _nam = nam
    End Sub

    'Destructor
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class
