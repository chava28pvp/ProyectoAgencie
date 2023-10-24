Imports MySql.Data.MySqlClient

Public Class Form1
    Private connectionInstance As New Connection2()
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("Admin")
        ComboBox1.Items.Add("User")
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim connection As MySqlConnection = connectionInstance.OpenConnection()
        If connection IsNot Nothing AndAlso connection.State = ConnectionState.Open Then
            Dim cmd As New MySqlCommand
            cmd.Connection = connection
            cmd.CommandText = "SELECT * FROM usuario WHERE Nombre=@Nombre AND Contrasena=@Contrasena AND Rol = @Rol"
            cmd.Parameters.AddWithValue("@Nombre", TextBox1.Text)
            cmd.Parameters.AddWithValue("@Contrasena", TextBox2.Text) 'Considera usar hash en lugar de texto plano
            cmd.Parameters.AddWithValue("@Rol", ComboBox1.SelectedItem.ToString())

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            If reader.HasRows Then
                reader.Read() 'Leer el primer registro que coincida
                Dim rol As String = reader("Rol").ToString()
                MessageBox.Show("Inicio de sesión exitoso como " & rol)
                If rol = "Admin" Then
                    Dim frmAdmin As New Form2
                    frmAdmin.Show()
                ElseIf rol = "User" Then
                    Dim frmUser As New Form4
                    frmUser.Show()
                End If
                Me.Hide() 'Opcional, si deseas ocultar el formulario de inicio de sesión
            Else
                MessageBox.Show("Credenciales incorrectas o el rol no coincide.")
            End If
            reader.Close()
            connectionInstance.CloseConnection(connection)
        Else
            MessageBox.Show("Error al conectarse a la base de datos.")
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

        Dim connection As MySqlConnection = connectionInstance.OpenConnection()

        If connection IsNot Nothing AndAlso connection.State = ConnectionState.Open Then
            MessageBox.Show("Conexión exitosa!")
            ' Cerrar la conexión
            connectionInstance.CloseConnection(connection)
        Else
            MessageBox.Show("Error al conectarse a la base de datos.")
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class
