Public Class Form3
    Dim frm1 As New Connection2()

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("Activo")
        ComboBox1.Items.Add("Espero")
        ComboBox1.Items.Add("Terminado")
    End Sub
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Asumiendo que tienes un TextBox (por ejemplo, txtNumVIN) donde el usuario introduce el NumVIN del vehículo a eliminar.
        Dim idMantenimiento As Integer
        If Integer.TryParse(TextBox5.Text, idMantenimiento) Then ' Intentamos convertir el texto a un número entero.
            If frm1.EliminarMantenimiento(idMantenimiento) Then
                MessageBox.Show("Mantenimiento eliminado con éxito.")
                ' Opcionalmente, puedes limpiar el TextBox después de una eliminación exitosa.
                TextBox5.Clear()
            Else
                MessageBox.Show("Error al eliminar el vehículo.")
            End If
        Else
            MessageBox.Show("Por favor, ingrese un NumVIN válido.")
        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim frmAdmin As New Form2
        frmAdmin.Show()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim frmAdmin As New Form7
        frmAdmin.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim idMantenimiento As Integer = Integer.Parse(TextBox5.Text)
        Dim Nombre As String = TextBox4.Text
        Dim Servicio As String = TextBox2.Text
        Dim Descripcion As String = TextBox3.Text
        Dim Tecnico As String = TextBox1.Text
        Dim Estado As String = ComboBox1.SelectedItem.ToString()
        Dim NumVIN As Integer = Integer.Parse(TextBox6.Text)



        If frm1.InsertarMantenimiento(idMantenimiento, Nombre, Servicio, Descripcion, Tecnico, Estado, NumVIN) Then
            MessageBox.Show("Mantenimiento generado con éxito.")
        Else
            MessageBox.Show("Hubo un error al generar.")
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Obtener los datos desde los TextBox
        Dim idMantenimiento As Integer = Integer.Parse(TextBox5.Text)
        Dim Nombre As String = TextBox4.Text
        Dim Servicio As String = TextBox2.Text
        Dim Descripcion As String = TextBox3.Text
        Dim Tecnico As String = TextBox1.Text
        Dim Estado As String = ComboBox1.SelectedItem.ToString()
        Dim NumVIN As Integer = Integer.Parse(TextBox6.Text)

        ' Llamar a la función UpdateVehicle para editar el vehículo
        Dim resultado As Boolean = frm1.UpdateMantenimiento(idMantenimiento, Nombre, Servicio, Descripcion, Tecnico, Estado, NumVIN)

        If resultado Then
            MessageBox.Show("Mantenimiento editado con éxito.")
        Else
            MessageBox.Show("Error al editar.")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim idMantenimiento As Integer = Integer.Parse(TextBox5.Text)
        Dim dt As DataTable = frm1.GetMantByNumVIN(idMantenimiento)

        If dt.Rows.Count > 0 Then
            Dim row As DataRow = dt.Rows(0)
            TextBox4.Text = row("Nombre").ToString()
            TextBox2.Text = row("Servicio").ToString()
            TextBox3.Text = row("Descripcion").ToString()
            TextBox1.Text = row("Tecnico").ToString()
            TextBox6.Text = row("NumVIN").ToString()
            ' Ya tienes el NumVIN, pero si deseas mostrarlo nuevamente en otro TextBox, puedes hacerlo.
        Else
            MessageBox.Show("No se encontró el mantenimiento.")
        End If

    End Sub
End Class