Imports ClassLibrary1

Public Class Form1

    Dim obj As New Class1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DataGridView1.DataSource = obj.ListarEmpleados()

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        lblcodigo.Text = DataGridView1.Item(0, e.RowIndex).Value
        txtnombre.Text = DataGridView1.Item(1, e.RowIndex).Value
        txtdireccion.Text = DataGridView1.Item(2, e.RowIndex).Value
        DateTimePicker1.Text = DataGridView1.Item(3, e.RowIndex).Value
        DateTimePicker2.Text = DataGridView1.Item(4, e.RowIndex).Value
        txtarea.Text = DataGridView1.Item(5, e.RowIndex).Value

    End Sub

    Private Sub RegistrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarToolStripMenuItem.Click

        Try
            obj.Insertar(txtnombre.Text, txtdireccion.Text, (CDate(DateTimePicker1.Text)), (CDate(DateTimePicker2.Text)), txtarea.Text)
            DataGridView1.DataSource = obj.ListarEmpleados
            MsgBox("Se registro el usuario: " + txtnombre.Text)

            txtnombre.Text = ""
            txtdireccion.Text = ""
            txtarea.Text = ""
            lblcodigo.Text = "A000"
            DateTimePicker1.Text = DateTime.Now
            DateTimePicker2.Text = DateTime.Now

        Catch ex As Exception

            MsgBox("Error al registrar usuario")

        End Try
    End Sub

    Private Sub ModificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem.Click
        Try
            obj.Modificar(lblcodigo.Text, txtnombre.Text, txtdireccion.Text, (DateTimePicker1.Text), (DateTimePicker2.Text), txtarea.Text)
            DataGridView1.DataSource = obj.ListarEmpleados
            MsgBox("Se modifico el usuario codigo: " + lblcodigo.Text)

            txtnombre.Text = ""
            txtdireccion.Text = ""
            txtarea.Text = ""
            lblcodigo.Text = "A000"
            DateTimePicker1.Text = DateTime.Now
            DateTimePicker2.Text = DateTime.Now

        Catch ex As Exception

            MsgBox("Error al modificar usuario")

        End Try

    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click

        Try
            obj.Eliminar(lblcodigo.Text)
            DataGridView1.DataSource = obj.ListarEmpleados
            MsgBox("Eliminado el usuario: " + lblcodigo.Text)

            txtnombre.Text = ""
            txtdireccion.Text = ""
            txtarea.Text = ""
            lblcodigo.Text = "A000"
            DateTimePicker1.Text = DateTime.Now
            DateTimePicker2.Text = DateTime.Now

        Catch ex As Exception

            MsgBox("Error al eliminar usuario")

        End Try

    End Sub

    Private Sub NuevoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem.Click

        txtnombre.Text = ""
        txtdireccion.Text = ""
        txtarea.Text = ""
        lblcodigo.Text = "A000"
        DateTimePicker1.Text = DateTime.Now
        DateTimePicker2.Text = DateTime.Now

    End Sub
End Class
