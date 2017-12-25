Imports DAO

Public Class MYSQLCONNECTIONBUS

    Public Shared Function ConnectToDatabase(ByVal server As String, ByVal user As String, ByVal password As String, ByVal database As String, Optional ByRef exception As String = "") As Boolean
        Try
            MYSQLCONNECTIONDAO.ConnectToDatabase(server, user, password, database, exception)
            If (exception = "") Then
                Return True
            End If

        Catch ex As Exception
            exception = ex.Message
        End Try
        Return False
    End Function

    Public Shared Function DisConnectFromDatabase(Optional ByRef exception As String = "") As Boolean
        Try
            MYSQLCONNECTIONDAO.DisConnectFromDatabase()
            Return True
        Catch ex As Exception
            exception = ex.Message
        End Try

        Return False
    End Function

End Class
