Imports System.IO
Imports System.Text
Imports MySql.Data.MySqlClient
Public Class Form5
    Private Const ConnectionString As String = "server=localhost;userid=root;password='';database=Project;"
    Private Sub Column1_Disposed(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim frmAdmin As New Form4
        frmAdmin.Show()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub LinkLabel4_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim frmAdmin As New Form8
        frmAdmin.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim query As String = "SELECT * FROM mantenimiento" ' Adapta tu_tabla al nombre real de tu tabla

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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Crea un SaveFileDialog para que el usuario pueda elegir dónde guardar el archivo
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "CSV Files (*.csv)|*.csv"
        saveFileDialog.DefaultExt = "csv"
        saveFileDialog.AddExtension = True

        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            ' Abre el archivo elegido para escritura
            Using sw As New StreamWriter(saveFileDialog.FileName, False, Encoding.UTF8)
                ' Escribe los encabezados de columna
                Dim columnHeaders = From dgvColumn In DataGridView1.Columns.Cast(Of DataGridViewColumn)()
                                    Select dgvColumn.HeaderText
                sw.WriteLine(String.Join(",", columnHeaders))

                ' Escribe las filas de datos
                For Each dgvRow As DataGridViewRow In DataGridView1.Rows
                    If Not dgvRow.IsNewRow Then
                        Dim cells = From cell As DataGridViewCell In dgvRow.Cells
                                    Select If(cell.Value Is Nothing, "", cell.Value.ToString())
                        sw.WriteLine(String.Join(",", cells))
                    End If
                Next
            End Using

            MessageBox.Show("Datos exportados con éxito!")
        End If
    End Sub
End Class