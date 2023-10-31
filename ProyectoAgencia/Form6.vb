
Imports MySql.Data.MySqlClient
Public Class Form6

    Private Const ConnectionString As String = "server=localhost;userid=root;password='';database=Project;"

    Private Function GetData(query As String) As DataTable
        Dim dt As New DataTable()

        Using conn As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand(query, conn)
                conn.Open()
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    dt.Load(dr)
                End Using
            End Using
        End Using
        Return dt
    End Function
    Private Sub LoadDataIntoChart()
        Dim query As String = "SELECT idMantenimiento, Estado FROM mantenimiento"
        Dim dt As DataTable = GetData(query)

        Chart1.DataSource = dt
        Chart1.Series("Series1").XValueMember = "Estado"
        Chart1.Series("Series1").YValueMembers = "idMantenimiento"
        Chart1.DataBind()
    End Sub
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadDataIntoChart()
    End Sub

    Private Sub Chart1_Click(sender As Object, e As EventArgs) Handles Chart1.Click

    End Sub
End Class