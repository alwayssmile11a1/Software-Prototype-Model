Public Class BAOCAOTONDTO
    Dim _maBaoCaoTon As String
    Dim _thang As Integer
    Dim _nam As Integer


#Region "Properties"

    Public Property MaBaoCaoTon As String
        Get
            Return _maBaoCaoTon
        End Get
        Set(value As String)
            _maBaoCaoTon = value
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
        _maBaoCaoTon = ""
        _thang = 0
        _nam = 0
    End Sub

    Public Sub New(ByVal maBaoCaoTon As String, ByVal thang As Integer, ByVal nam As Integer)
        _maBaoCaoTon = maBaoCaoTon
        _thang = thang
        _nam = nam
    End Sub

    'Destructor
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class
