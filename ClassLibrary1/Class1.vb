Imports System.Data.SqlClient

Public Class Class1
    Dim con As New SqlConnection("server=DESKTOP-920EQSM\SQLEXPRESS; integrated security=true; Database=crudIngreso ")

    Public Function ListarEmpleados() As DataTable
        Dim da As New SqlDataAdapter("pb_listar", con)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function

    Public Function Insertar(nom As String, direc As String, fechaing As Date, fechater As Date, area As Char)
        Dim da As New SqlCommand("pb_nuevo", con)
        da.CommandType = CommandType.StoredProcedure
        da.Parameters.AddWithValue("@nombre", nom)
        da.Parameters.AddWithValue("@direccion", direc)
        da.Parameters.AddWithValue("@fechaing", fechaing)
        da.Parameters.AddWithValue("@fechater", fechater)
        da.Parameters.AddWithValue("@area", area)
        con.Open()
        Dim resp As Integer
        Try
            resp = da.ExecuteNonQuery
            con.Close()
        Catch ex As Exception
            MsgBox("Error al registar")
        End Try
        Return resp
    End Function

    Public Function Eliminar(codigo As String)
        Dim elim As New SqlCommand("pb_eliminar", con)
        elim.CommandType = CommandType.StoredProcedure
        elim.Parameters.AddWithValue("@codigo", codigo)
        con.Open()
        Dim elimina As Integer = elim.ExecuteNonQuery
        con.Close()
        Return elimina
    End Function

    Public Function Modificar(codigo As String, nom As String, direc As String, fechaing As Date, fechater As Date, area As Char)
        Dim act As New SqlCommand("pb_modificar", con)
        act.CommandType = CommandType.StoredProcedure
        act.Parameters.AddWithValue("codigo", codigo)
        act.Parameters.AddWithValue("@nombre", nom)
        act.Parameters.AddWithValue("@direccion", direc)
        act.Parameters.AddWithValue("@fechaing", fechaing)
        act.Parameters.AddWithValue("@fechater", fechater)
        act.Parameters.AddWithValue("@area", area)
        con.Open()
        Dim actualiza As String = act.ExecuteNonQuery
        con.Close()
        Return actualiza
    End Function


End Class
