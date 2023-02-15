
Partial Class RegistrarNuevoServicio
    Inherits System.Web.UI.Page

    Protected Sub btnNuevoServicio_Click(sender As Object, e As EventArgs) Handles btnNuevoServicio.Click
        Dim servicio = txtNuevoServicio.Text
        Dim email = txtEmailServicio.Text

        Dim ctrlServicio_Recurso As New ControladorServicio_Recurso_Lugar
        Dim msg = ctrlServicio_Recurso.registrarNuevoServicio(servicio, email)
        Dim msgbox = New clMensajes
        If msg IsNot Nothing Then

            Response.Write(msgbox.Mensajes(msg))
        Else
            Response.Write(MsgBox.Mensajes("No se pudo registrar el mensaje"))
        End If
    End Sub
End Class
