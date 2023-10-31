Imports MySql.Data.MySqlClient

Public Class Form2
    Private connectionInstance As New Connection2()
    Dim frm1 As New Connection2()


    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs)

    End Sub

    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim numVIN As Integer = Integer.Parse(TextBox1.Text)
        Dim marca As String = TextBox2.Text
        Dim modelo As String = TextBox3.Text
        Dim anio As String = TextBox4.Text
        Dim kilometraje As String = TextBox5.Text


        If frm1.InsertVehicle(numVIN, marca, modelo, anio, kilometraje) Then
            MessageBox.Show("Vehículo insertado con éxito.")
        Else
            MessageBox.Show("Hubo un error al insertar el vehículo.")
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim frmAdmin As New Form3
        frmAdmin.Show()

    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)


    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Dim frmAdmin As New Form7
        frmAdmin.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Obtener los datos desde los TextBox
        Dim numVIN As Integer = Integer.Parse(TextBox1.Text)
        Dim marca As String = TextBox2.Text
        Dim modelo As String = TextBox3.Text
        Dim anio As String = TextBox4.Text
        Dim kilometraje As String = TextBox5.Text


        ' Llamar a la función UpdateVehicle para editar el vehículo
        Dim resultado As Boolean = frm1.UpdateVehicle(numVIN, marca, modelo, anio, kilometraje)

        If resultado Then
            MessageBox.Show("Vehículo editado con éxito.")
        Else
            MessageBox.Show("Error al editar el vehículo.")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Asumiendo que tienes un TextBox (por ejemplo, txtNumVIN) donde el usuario introduce el NumVIN del vehículo a eliminar.
        Dim numVIN As Integer
        If Integer.TryParse(TextBox1.Text, numVIN) Then ' Intentamos convertir el texto a un número entero.
            If frm1.EliminarVehiculo(numVIN) Then
                MessageBox.Show("Vehículo eliminado con éxito.")
                ' Opcionalmente, puedes limpiar el TextBox después de una eliminación exitosa.
                TextBox1.Clear()
            Else
                MessageBox.Show("Error al eliminar el vehículo.")
            End If
        Else
            MessageBox.Show("Por favor, ingrese un NumVIN válido.")
        End If
    End Sub

    Private Sub LinkLabel3_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Application.Exit()
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Dim form2 As New Form6()
        form2.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim numVIN As Integer = Integer.Parse(TextBox1.Text)
        Dim dt As DataTable = frm1.GetVehicleByNumVIN(numVIN)

        If dt.Rows.Count > 0 Then
            Dim row As DataRow = dt.Rows(0)
            TextBox2.Text = row("Marca").ToString()
            TextBox3.Text = row("Modelo").ToString()
            TextBox4.Text = row("Anio").ToString()
            TextBox5.Text = row("Kilometraje").ToString()
            ' Ya tienes el NumVIN, pero si deseas mostrarlo nuevamente en otro TextBox, puedes hacerlo.
        Else
            MessageBox.Show("No se encontró un vehículo con el NumVIN especificado.")
        End If

    End Sub
End Class