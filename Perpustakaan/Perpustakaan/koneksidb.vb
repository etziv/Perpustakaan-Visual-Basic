Imports MySql.Data.MySqlClient
Module koneksidb
    Public cmd As MySqlCommand
    Public cn As New MySqlConnection
    Public rd As MySqlDataReader
    Dim db As String
    Sub connect()
        db = "server=localhost;user=root;password=;database=dtbs1"
        cn = New MySqlConnection(db)
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
    End Sub
End Module
