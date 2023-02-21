
Imports System.Diagnostics

Partial Class editarLugar
    Inherits System.Web.UI.Page
    Dim ctrl As New ControladorServicio_Recurso_Lugar()
    Dim msg As New clMensajes

    Protected Sub btnNuevoLugar_Click(sender As Object, e As EventArgs) Handles btnNuevoLugar.Click

        Dim id = Request.QueryString("id")
        Dim rs = ""
        If id <> 0 Then
            Dim nom_lugar = txtNuevoLugar.Text
            Dim descr_lugar = txtdescrLugar.Text

            Dim lugar = New Lugar(id, nom_lugar, descr_lugar)
            rs = ctrl.editarLugar(lugar)
        Else
            Dim nom_lugar = txtNuevoLugar.Text
            Dim descr_lugar = txtdescrLugar.Text

            Dim lugar = New Lugar(id, nom_lugar, descr_lugar)
            rs = ctrl.registrarNuevoLugar(lugar)
        End If
        Response.Write(msg.Mensajes(rs))
        Response.Write(msg.Fx_CerrarVentana)

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Debug.WriteLine("ID DEL REPSONSE ES " & Request.QueryString("id"))
        Dim id = Request.QueryString("id")
        If id <> 0 Then
            Dim lugar As Lugar = ctrl.obtenerLugar(id)
            txtNuevoLugar.Text = lugar.nom_lugar
            txtdescrLugar.Text = lugar.descr_lugar
            btnNuevoLugar.Text = "Editar Lugar"
            lblRegistroLugar.Text = "Edición de lugar"
        Else
            btnNuevoLugar.Text = "Registrar Lugar"
        End If
    End Sub


End Class
