Imports DTO
Imports MySql.Data.MySqlClient

Public Class THAMSODAO

    ''' <summary>
    ''' Update ThamSo 
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function UpdateThamSo(Optional ByRef exception As String = "") As Boolean
        Try
            'query
            Dim query As String = String.Format("Update THAMSO set SoLuongNhapToiThieu = {0}, SoLuongTonToiDaTruocNhap = {1},
                                                SoLuongTonSauToiThieu = {2},SoTienNoToiDa ={3}, SuDungQuyDinh4 = {4}",
                                                THAMSODTO.SoLuongNhapToiThieu, THAMSODTO.SoLuongTonToiDaTruocNhap, THAMSODTO.SoLuongTonToiThieuSauBan,
                                                THAMSODTO.SoTienNoToiDa, THAMSODTO.SuDungQuyDinh4)
            'excute reader
            Dim reader As MySqlDataReader = MYSQLCONNECTIONDAO.ExcuteQuery(query, exception)

            If (exception = "") Then Return True

        Catch ex As Exception
            exception = ex.Message
        End Try

        Return False
    End Function

    ''' <summary>
    ''' Set ThamSo to ThamSoDTO (get the new ThamSo for ThamSoDTO)
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <returns></returns>
    Public Shared Function GetThamSo(Optional ByRef exception As String = "") As Boolean
        Try
            'query
            Dim query As String = String.Format("select* from THAMSO")

            'excute reader
            Dim reader As MySqlDataReader = MYSQLCONNECTIONDAO.ExcuteQuery(query, exception)

            'if there is no exception
            If (exception = "") Then

                'get thamso
                While reader.Read
                    THAMSODTO.SoLuongNhapToiThieu = reader.GetString("SoLuongNhapToiThieu")
                    THAMSODTO.SoLuongTonToiDaTruocNhap = reader.GetString("SoLuongTonToiDaTruocNhap")
                    THAMSODTO.SoLuongTonToiThieuSauBan = reader.GetString("SoLuongTonSauToiThieu")
                    THAMSODTO.SoTienNoToiDa = reader.GetString("SoTienNoToiDa")
                    THAMSODTO.SuDungQuyDinh4 = reader.GetString("SuDungQuyDinh4")
                End While

                Return True

            End If
        Catch ex As Exception
            exception = ex.Message
        End Try

        Return False
    End Function

End Class
