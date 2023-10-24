Public Class Form7
    Dim frm1 As New Connection2()
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim frmAdmin As New Form2
        frmAdmin.Show()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim frmAdmin As New Form3
        frmAdmin.Show()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim NumServVIN As Integer = Integer.Parse(TextBox2.Text)
        Dim FechaAsign As String = DateTimePicker1.Text
        Dim NumVIN As Integer = Integer.Parse(TextBox1.Text)



        If frm1.InsertarServicio(NumServVIN, FechaAsign, NumVIN) Then
            MessageBox.Show("Vehículo insertado con éxito.")
        Else
            MessageBox.Show("Hubo un error al insertar el vehículo.")
        End If
    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Obtener los datos desde los TextBox
        Dim NumServVIN As Integer = Integer.Parse(TextBox2.Text)
        Dim FechaAsign As String = DateTimePicker1.Text
        Dim NumVIN As Integer = Integer.Parse(TextBox1.Text)


        ' Llamar a la función UpdateVehicle para editar el vehículo
        Dim resultado As Boolean = frm1.UpdateServicio(NumServVIN, FechaAsign, NumVIN)

        If resultado Then
            MessageBox.Show("Vehículo editado con éxito.")
        Else
            MessageBox.Show("Error al editar el vehículo.")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Asumiendo que tienes un TextBox (por ejemplo, txtNumVIN) donde el usuario introduce el NumVIN del vehículo a eliminar.
        Dim NumServVIN As Integer
        If Integer.TryParse(TextBox2.Text, NumServVIN) Then ' Intentamos convertir el texto a un número entero.
            If frm1.EliminarVehiculo(NumServVIN) Then
                MessageBox.Show("Vehículo eliminado con éxito.")
                ' Opcionalmente, puedes limpiar el TextBox después de una eliminación exitosa.
                TextBox2.Clear()
            Else
                MessageBox.Show("Error al eliminar el vehículo.")
            End If
        Else
            MessageBox.Show("Por favor, ingrese un NumVIN válido.")
        End If
    End Sub
End Class