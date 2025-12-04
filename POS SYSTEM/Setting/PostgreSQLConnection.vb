Imports Npgsql
Imports NpgsqlTypes
Imports System.Data
Imports System.Windows.Forms ' Required for MessageBox in error handling

Public Class PostgreSQLConnection

    ' IMPORTANT: Change the connection string to match your environment settings
    Private connectionString As String =
        "Host=127.0.0.1;Port=5432;Username=postgres;Password=kira23;Database=POS-Database;"

    ' Open connection (Made Private for better encapsulation)
    Private Function OpenConn() As NpgsqlConnection
        Try
            Dim conn As New NpgsqlConnection(connectionString)
            conn.Open()
            Return conn
        Catch ex As Exception
            Throw New Exception("PostgreSQL connection error: " & ex.Message)
        End Try
    End Function

    ' Execute SELECT and return DataTable with Parameters (Recommended Secure Method)
    Public Function GetData(sql As String, Optional parameters As NpgsqlParameter() = Nothing) As DataTable
        Dim dt As New DataTable()

        Try
            Using connection As NpgsqlConnection = OpenConn()
                Using cmd As New NpgsqlCommand(sql, connection)
                    If parameters IsNot Nothing Then
                        cmd.Parameters.AddRange(parameters)
                    End If
                    Using da As New NpgsqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Query error: " & ex.Message)
        End Try

        Return dt
    End Function

    ' Execute SELECT and retrieve a single value with Parameters
    Public Function GetField(sql As String, Optional parameters As NpgsqlParameter() = Nothing) As String
        Dim result As Object = Nothing
        Try
            Using connection As NpgsqlConnection = OpenConn()
                Using cmd As New NpgsqlCommand(sql, connection)
                    If parameters IsNot Nothing Then
                        cmd.Parameters.AddRange(parameters)
                    End If
                    result = cmd.ExecuteScalar()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("GetField error: " & ex.Message)
        End Try

        If result IsNot Nothing AndAlso Not Convert.IsDBNull(result) Then
            Return result.ToString()
        Else
            Return ""
        End If
    End Function

    ' Execute INSERT/UPDATE/DELETE (Simple, non-transactional)
    Public Function ExecuteNonQuery(sql As String) As Integer
        Try
            Using connection As NpgsqlConnection = OpenConn()
                Using cmd As New NpgsqlCommand(sql, connection)
                    Return cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("ExecuteNonQuery error: " & ex.Message)
        End Try
    End Function

    ' ⭐ New Transactional Method for POS Posting (Header and Detail) ⭐
    Public Function ExecuteTransaction(ByVal headerQuery As String, ByVal headerParams As NpgsqlParameter(),
                                       ByVal detailQuery As String, ByVal detailData As List(Of NpgsqlParameter())) As Boolean

        Using conn As New NpgsqlConnection(connectionString)
            conn.Open()
            Dim transaction As NpgsqlTransaction = conn.BeginTransaction()

            Try
                ' 1. Insert Header
                Using cmdHeader As New NpgsqlCommand(headerQuery, conn, transaction)
                    cmdHeader.Parameters.AddRange(headerParams)
                    cmdHeader.ExecuteNonQuery()
                End Using

                ' 2. Insert Details (Looping through all detail rows)
                Using cmdDetail As New NpgsqlCommand(detailQuery, conn, transaction)
                    For Each detailParams In detailData
                        cmdDetail.Parameters.Clear()
                        cmdDetail.Parameters.AddRange(detailParams)
                        cmdDetail.ExecuteNonQuery()
                    Next
                End Using

                ' 3. Commit Transaction
                transaction.Commit()
                Return True

            Catch ex As Exception
                ' 4. Rollback on error
                transaction.Rollback()
                MessageBox.Show("Transaction failed and was rolled back: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False

            End Try
        End Using
    End Function

    Public Function TestConnection() As Boolean
        Try
            Using conn As New NpgsqlConnection(connectionString)
                conn.Open()
                Return conn.State = ConnectionState.Open
            End Using
        Catch ex As Exception
            MessageBox.Show("Connection Failed: " & ex.Message)
            Return False
        End Try
    End Function
End Class