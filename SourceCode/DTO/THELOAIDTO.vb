Public Class THELOAIDTO
    Private _maTheLoai As String
    Private _TenTheLoai As String

    Public Property MaTheLoai As String
        Get
            Return _maTheLoai
        End Get
        Set(value As String)
            _maTheLoai = value
        End Set
    End Property

    Public Property TenTheLoai As String
        Get
            Return _TenTheLoai
        End Get
        Set(value As String)
            _TenTheLoai = value
        End Set
    End Property

    'Constructor
    Public Sub New()
        _maTheLoai = ""
        _TenTheLoai = ""
    End Sub

    Public Sub New(ByVal maTheLoai As String, ByVal tenTheLoai As String)
        _maTheLoai = maTheLoai
        _TenTheLoai = tenTheLoai
    End Sub

    'Destructor
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class
