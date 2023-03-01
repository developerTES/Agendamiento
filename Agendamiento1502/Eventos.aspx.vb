
Imports System.Diagnostics
Imports System.Net
Imports System.Web.Services

Partial Class Eventos
    Inherits System.Web.UI.Page
    Dim ctrlEventos As New ControladorEvento()



    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Debug.WriteLine("SESSIONES ")
        Debug.WriteLine(Session("user"))
        Debug.WriteLine(Session("pwd"))
        If Not Me.IsPostBack Then
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

        End If



        ' Debug.WriteLine(Session("culture").ToString)
    End Sub


    <System.Web.Services.WebMethod()>
    Public Shared Function GetCurrentTime()
        'Public Shared Function GetCurrentTime(ByVal name As String) As String
        Debug.WriteLine("Hola Mundo ")
        'Return "Hello " & name & Environment.NewLine & "The Current Time is: " &
        'DateTime.Now.ToString()
    End Function

    <WebMethod>
    Public Shared Function PrintGoogleCAL(id As String) As String
        Debug.WriteLine("Hola Munmdo cal")
        Debug.WriteLine(id)
        Return "Exitoso"
    End Function



    Private Sub ListardetalleEvento(ByVal idGoogleCal As String)
        Debug.WriteLine("Hola Mundo")

    End Sub



End Class
