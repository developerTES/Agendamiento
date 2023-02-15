
Imports System.Diagnostics

Partial Class RegistrarNuevoRecurso
    Inherits System.Web.UI.Page

    Protected Sub btnNuevoRecurso_Click(sender As Object, e As EventArgs) Handles btnNuevoRecurso.Click
        Dim recurso = txtNuevoRecurso.Text
        Dim descripcion = txtdescrRecurso.Text

        Dim ctrlServicio_Recurso As New ControladorServicio_Recurso_Lugar
        Debug.WriteLine("ID DEL REPSONSE ES " & Request.QueryString("id"))
        Dim id_servicio = Request.QueryString("id")
        Dim msg = ctrlServicio_Recurso.registrarNuevoRecurso(id_servicio, recurso, descripcion)
        Dim msgbox = New clMensajes
        If msg IsNot Nothing Then

            Response.Write(msgbox.Mensajes(msg))
        Else
            Response.Write(msgbox.Mensajes("No se pudo registrar el mensaje"))
        End If
    End Sub
End Class
