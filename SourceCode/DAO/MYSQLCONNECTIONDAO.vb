Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Text
Public Class MYSQLCONNECTIONDAO
    Private Shared _mySql As MySqlConnection = Nothing
    Private Shared _reader As MySqlDataReader = Nothing
    Private Shared _adapter As New MySqlDataAdapter

    ''' <summary>
    ''' Connect to the database
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function ConnectToDatabase(ByVal server As String, ByVal user As String, ByVal password As String, ByVal database As String, Optional ByRef exception As String = "") As MySqlConnection
        Try
            'get a new mysql connection
            _mySql = New MySqlConnection

            'get connection
            _mySql.ConnectionString = String.Format("server={0};user={1};password={2};database={3}", server, user, password, database)

            'open database
            _mySql.Open()
        Catch ex As MySqlException
            exception = ex.Message
        End Try

        Return _mySql

    End Function

    ''' <summary>
    ''' DisConnect From Database
    ''' </summary>
    Public Shared Sub DisConnectFromDatabase(Optional ByRef exception As String = "")
        Try
            _mySql.Close()
        Catch ex As MySqlException
            exception = ex.Message
        Finally
            _mySql.Dispose()
            If (_reader IsNot Nothing) Then
                _reader.Dispose()
            End If
            If (_adapter IsNot Nothing) Then
                _adapter.Dispose()
            End If
        End Try

    End Sub

    ''' <summary>
    ''' Excute Query
    ''' </summary>
    ''' <param name="query"></param>
    ''' <returns></returns>
    Public Shared Function ExcuteQuery(ByVal query As String, Optional ByRef exception As String = "") As MySqlDataReader
        'we have to close previous reader first to be able to excute new reader
        If (Not (_reader Is Nothing)) Then
            _reader.Close()
        End If
        Dim command As New MySqlCommand(query, _mySql)
        'Excute reader
        Try

            _reader = command.ExecuteReader()
        Catch ex As MySqlException
            exception = ex.Message
        Finally
            command.Dispose()
        End Try
        Return _reader
    End Function

    ''' <summary>
    ''' Get DataTable
    ''' </summary>
    ''' <param name="query"></param>
    ''' <returns></returns>
    Public Shared Function GetDataTableByQuery(ByVal query As String, Optional ByRef exception As String = "") As DataTable
        'we have to close previous reader first to be able to excute new reader
        If (Not (_reader Is Nothing)) Then
            _reader.Close()
        End If

        'get a new datable
        Using dataTable As New DataTable
            'datatable to store information
            'Dim dataTable As DataTable = Nothing
            'get command
            Dim command As New MySqlCommand(query, _mySql)

            Try
                ''get a new datable
                'dataTable = New DataTable
                'select command
                _adapter.SelectCommand = command

                _adapter.Fill(dataTable)

            Catch ex As MySqlException
                exception = ex.Message
            Finally
                command.Dispose()
            End Try

            Return dataTable

        End Using
    End Function

    ''' <summary>
    ''' Excute Procedure
    ''' </summary>
    ''' <param name="procedureName"></param>
    ''' <returns></returns>
    Public Shared Function ExcuteProcedure(ByVal procedureName As String, ByRef exception As String, ByVal ParamArray values() As MySqlParameter) As MySqlDataReader
        'we have to close previous reader first to be able to excute new reader
        If (Not (_reader Is Nothing)) Then
            _reader.Close()
        End If

        'Excute reader
        Dim command As New MySqlCommand(procedureName, _mySql)
        Try

            command.CommandType = CommandType.StoredProcedure

            command.Parameters.AddRange(values)

            _reader = command.ExecuteReader()

        Catch ex As MySqlException
            exception = ex.Message
        Finally
            command.Dispose()
        End Try
        Return _reader
    End Function

    ''' <summary>
    ''' Get DataTable
    ''' </summary>
    ''' <param name="procedureName"></param>
    ''' <returns></returns>
    Public Shared Function GetDataTableByProcedure(ByVal procedureName As String, ByRef exception As String, ParamArray values() As MySqlParameter) As DataTable
        'we have to close previous reader first to be able to excute new reader
        If (Not (_reader Is Nothing)) Then
            _reader.Close()
        End If

        'get a new datable
        Using dataTable As New DataTable
            'datatable to store information
            'Dim dataTable As DataTable = Nothing
            'get command
            Dim command As New MySqlCommand(procedureName, _mySql)

            Try

                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddRange(values)
                'select command
                _adapter.SelectCommand = command
                'fill in datatable

                _adapter.Fill(dataTable)


            Catch ex As MySqlException
                exception = ex.Message
            Finally
                command.Dispose()
            End Try

            Return dataTable
        End Using
    End Function


End Class
