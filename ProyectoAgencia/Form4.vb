Imports MySql.Data.MySqlClient
Public Class Form4
    Private Const ConnectionString As String = "server=localhost;userid=root;password='';database=Project;"
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Dim frmAdmin As New Form8
        frmAdmin.Show()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim frmAdmin As New Form5
        frmAdmin.Show()
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim query As String = "SELECT * FROM vehiculos" ' Adapta tu_tabla al nombre real de tu tabla

        Using connection As New MySqlConnection(ConnectionString)
            Try
                ' Abrir conexión
                connection.Open()

                ' Crear un adaptador para la consulta
                Dim adapter As New MySqlDataAdapter(query, connection)

                ' Crear un DataTable para recibir los datos
                Dim dt As New DataTable()

                ' Llenar el DataTable con los datos de la consulta
                adapter.Fill(dt)

                ' Asignar el DataTable al DataGridView
                DataGridView1.DataSource = dt

            Catch ex As Exception
                ' Mostrar cualquier error que ocurra
                MessageBox.Show("Error al cargar los datos: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Application.Exit()
    End Sub
End Class