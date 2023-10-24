Imports MySql.Data.MySqlClient
Public Class Connection2


    Private Const ConnectionString As String = "server=localhost;userid=root;password='';database=Project;"
    Public Function InsertVehicle(numVIN As Integer, marca As String, modelo As String, anio As String, kilometraje As String) As Boolean
        Using connection As New MySqlConnection(ConnectionString)
            Try
                connection.Open()
                Dim cmd As New MySqlCommand("INSERT INTO vehiculos (NumVIN, Marca, Modelo, Anio, Kilometraje) VALUES (@NumVIN, @Marca, @Modelo, @Anio, @Kilometraje)", connection)

                cmd.Parameters.AddWithValue("@NumVIN", numVIN)
                cmd.Parameters.AddWithValue("@Marca", marca)
                cmd.Parameters.AddWithValue("@Modelo", modelo)
                cmd.Parameters.AddWithValue("@Anio", anio)
                cmd.Parameters.AddWithValue("@Kilometraje", kilometraje)


                cmd.ExecuteNonQuery()

                Return True 'Insertado con éxito
            Catch ex As Exception
                ' Manejar error
                Console.WriteLine("Error al insertar en vehiculos: " & ex.Message)
                Return False 'Error al insertar
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function InsertarMantenimiento(ByVal idMantenimiento As Integer, ByVal Nombre As String, ByVal Servicio As String, ByVal Descripcion As String, ByVal Tecnico As String, ByVal Estado As String, ByVal NumVIN As Integer) As Boolean

        Dim query As String = "INSERT INTO mantenimiento (idMantenimiento, Nombre, Servicio, Descripcion, Tecnico, Estado, NumVIN) VALUES (@idMantenimiento, @Nombre, @Servicio, @Descripcion, @Tecnico, @Estado, @NumVIN)"

        Using conn As MySqlConnection = New MySqlConnection(ConnectionString)
            Using cmd As MySqlCommand = New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@idMantenimiento", idMantenimiento)
                cmd.Parameters.AddWithValue("@Nombre", Nombre)
                cmd.Parameters.AddWithValue("@Servicio", Servicio)
                cmd.Parameters.AddWithValue("@Descripcion", Descripcion)
                cmd.Parameters.AddWithValue("@Tecnico", Tecnico)
                cmd.Parameters.AddWithValue("@Estado", Estado)
                cmd.Parameters.AddWithValue("@NumVIN", NumVIN)

                conn.Open()

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    Return True
                Else
                    Return False
                End If
            End Using
        End Using

    End Function
    Public Function InsertarServicio(ByVal NumServVIN As Integer, ByVal FechaAsign As String, ByVal NumVIN As Integer) As Boolean

        Dim query As String = "INSERT INTO proximo_servicio (NumServVIN, FechaAsign, NumVIN) VALUES (@NumServVIN, @FechaAsign, @NumVIN)"

        Using conn As MySqlConnection = New MySqlConnection(ConnectionString)
            Using cmd As MySqlCommand = New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@NumServVIN", NumServVIN)
                cmd.Parameters.AddWithValue("@FechaAsign", FechaAsign)
                cmd.Parameters.AddWithValue("@NumVIN", NumVIN)



                conn.Open()

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    Return True
                Else
                    Return False
                End If
            End Using
        End Using

    End Function
    Public Function UpdateServicio(ByVal NumServVIN As Integer, ByVal FechaAsign As String, ByVal NumVIN As Integer) As Boolean
        Using connection As New MySqlConnection(ConnectionString)
            Try
                connection.Open()

                Dim cmd As New MySqlCommand("UPDATE proximo_servicio SET FechaAsign = @FechaAsign, NumVIN = @NumVIN WHERE NumServVIN = @NumServVIN", connection)


                cmd.Parameters.AddWithValue("@FechaAsign", FechaAsign)
                cmd.Parameters.AddWithValue("@NumVIN", NumVIN)

                cmd.Parameters.AddWithValue("@NumServVIN", NumServVIN)

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    Return True 'Edición exitosa
                Else
                    Return False 'No se editó ningún registro
                End If

            Catch ex As Exception
                ' Manejar error
                Console.WriteLine("Error al editar vehículo: " & ex.Message)
                Return False 'Error al editar
            Finally
                connection.Close()
            End Try
        End Using
    End Function
    Public Function EliminarServicio(ByVal NumServVIN As Integer) As Boolean

        Using connection As New MySqlConnection(ConnectionString)
            Try
                connection.Open()

                Dim query As String = "DELETE FROM proximo_servicio WHERE NumServVIN = @NumServVIN"
                Dim cmd As New MySqlCommand(query, connection)

                cmd.Parameters.AddWithValue("@NumServVIN", NumServVIN)

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    Return True 'Eliminación exitosa
                Else
                    Return False 'No se eliminó ningún registro
                End If

            Catch ex As Exception
                Console.WriteLine("Error al eliminar vehiculo: " & ex.Message)
                Return False 'Error al eliminar
            Finally
                connection.Close()
            End Try
        End Using
    End Function
    Public Function OpenConnection() As MySqlConnection
            Dim connection As New MySqlConnection(ConnectionString)
            Try
                connection.Open()
                Return connection
            Catch ex As MySqlException
                ' Manejar el error (p.ej. mostrando un mensaje al usuario)
                Console.WriteLine("Error conectando a la base de datos: " & ex.Message)
                Return Nothing
            End Try
        End Function
    Public Function UpdateVehicle(ByVal NumVIN As Integer, ByVal Marca As String, ByVal Modelo As String, ByVal Anio As String, ByVal Kilometraje As String) As Boolean
        Using connection As New MySqlConnection(ConnectionString)
            Try
                connection.Open()

                Dim cmd As New MySqlCommand("UPDATE vehiculos SET Marca = @Marca, Modelo = @Modelo, Anio = @Anio, Kilometraje = @Kilometraje, WHERE NumVIN = @NumVIN", connection)


                cmd.Parameters.AddWithValue("@Marca", Marca)
                cmd.Parameters.AddWithValue("@Modelo", Modelo)
                cmd.Parameters.AddWithValue("@Anio", Anio)
                cmd.Parameters.AddWithValue("@Kilometraje", Kilometraje)
                cmd.Parameters.AddWithValue("@NumVIN", NumVIN)

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    Return True 'Edición exitosa
                Else
                    Return False 'No se editó ningún registro
                End If

            Catch ex As Exception
                ' Manejar error
                Console.WriteLine("Error al editar vehículo: " & ex.Message)
                Return False 'Error al editar
            Finally
                connection.Close()
            End Try
        End Using
    End Function
    Public Function UpdateMantenimiento(idMantenimiento As Integer, Nombre As String, Servicio As String, Descripcion As String, Tecnico As String, Estado As String, NumVIN As Integer) As Boolean
        Using connection As New MySqlConnection(ConnectionString)
            Try
                connection.Open()

                Dim cmd As New MySqlCommand("UPDATE mantenimiento SET Nombre = @Nombre, Servicio = @Servicio, Descripcion = @Descripcion, Tecnico = @Tecnico, Estado = @Estado, NumVIN = @NumVIN WHERE idMantenimiento = @idMantenimiento", connection)

                cmd.Parameters.AddWithValue("@IdMantenimiento", idMantenimiento)
                cmd.Parameters.AddWithValue("@Nombre", Nombre)
                cmd.Parameters.AddWithValue("@Servicio", Servicio)
                cmd.Parameters.AddWithValue("@Descripcion", Descripcion)
                cmd.Parameters.AddWithValue("@Tecnico", Tecnico)
                cmd.Parameters.AddWithValue("@Estado", Estado)

                cmd.Parameters.AddWithValue("@NumVIN", NumVIN)
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    Return True 'Edición exitosa
                Else
                    Return False 'No se editó ningún registro
                End If

            Catch ex As Exception
                ' Manejar error
                Console.WriteLine("Error al editar Mantenimiento: " & ex.Message)
                Return False 'Error al editar
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function EliminarVehiculo(ByVal NumVIN As Integer) As Boolean

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()

                Dim query As String = "DELETE FROM vehiculos WHERE NumVIN = @NumVIN"
                Dim cmd As New MySqlCommand(query, connection)

                cmd.Parameters.AddWithValue("@NumVIN", NumVIN)

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    Return True 'Eliminación exitosa
                Else
                    Return False 'No se eliminó ningún registro
                End If

            Catch ex As Exception
                Console.WriteLine("Error al eliminar vehiculo: " & ex.Message)
                Return False 'Error al eliminar
            Finally
                connection.Close()
            End Try
        End Using
    End Function
    Public Function EliminarMantenimiento(ByVal idMantenimiento As Integer) As Boolean

        Using connection As New MySqlConnection(ConnectionString)
            Try
                connection.Open()

                Dim query As String = "DELETE FROM mantenimiento WHERE idMantenimiento = @idMantenimiento"
                Dim cmd As New MySqlCommand(query, connection)

                cmd.Parameters.AddWithValue("@idMantenimiento", idMantenimiento)

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    Return True 'Eliminación exitosa
                Else
                    Return False 'No se eliminó ningún registro
                End If

            Catch ex As Exception
                Console.WriteLine("Error al eliminar ID: " & ex.Message)
                Return False 'Error al eliminar
            Finally
                connection.Close()
            End Try
        End Using
    End Function
    Public Sub CloseConnection(ByVal connection As MySqlConnection)
        Try
            If connection IsNot Nothing AndAlso connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        Catch ex As MySqlException
            ' Manejar el error (p.ej. mostrando un mensaje al usuario)
            Console.WriteLine("Error cerrando la conexión: " & ex.Message)
        End Try
    End Sub


End Class

