
Imports System.Diagnostics
Imports System.Net

Partial Class Eventos
    Inherits System.Web.UI.Page
    Dim ctrlEventos As New ControladorEvento()



    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Debug.WriteLine("SESSIONES ")
        Debug.WriteLine(Session("user"))
        Debug.WriteLine(Session("pwd"))
        If Session("user") IsNot Nothing Then
            'Response.Redirect("Eventos.aspx")
            Debug.WriteLine("Listando eventos")
            Dim listEventos_organizador = ctrlEventos.ListarEventosEmailTipo(Session("email"), "ORGANIZADOR")
            Dim listEventos_asistente = ctrlEventos.ListarEventosEmailTipo(Session("email"), "ASISTENTE")
            Dim listEventos_soporte = ctrlEventos.ListarEventosEmailTipo(Session("email"), "SOPORTE")
            Session("lst_org") = listEventos_organizador
            Session("lst_asis") = listEventos_asistente
            Session("lst_sop") = listEventos_soporte

        Else
            Response.Redirect("Default")
        End If


        ' Debug.WriteLine(Session("culture").ToString)
    End Sub






    Private Sub ListardetalleEvento(sender As Object, e As EventArgs)
        Debug.WriteLine("Hola Mundo")

    End Sub



End Class
