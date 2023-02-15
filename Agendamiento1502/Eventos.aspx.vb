
Imports System.Diagnostics

Partial Class Eventos
    Inherits System.Web.UI.Page
    Dim ctrlEventos = New ControladorEvento()

    Protected Sub gvEventos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvEventos.SelectedIndexChanged

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Debug.WriteLine("SESSIONES ")
        Debug.WriteLine(Session("user"))
        Debug.WriteLine(Session("pwd"))
        Dim listEventos_organizador = ctrlEventos.ListarEventosEmailTipo(Session("email"), "ORGANIZADOR")
        Dim listEventos_asistente = ctrlEventos.ListarEventosEmailTipo(Session("email"), "ASISTENTE")
        Dim listEventos_soporte = ctrlEventos.ListarEventosEmailTipo(Session("email"), "SOPORTE")

        ' Debug.WriteLine(Session("culture").ToString)
    End Sub


    Protected Sub btnListarEvento_Click(sender As Object, e As EventArgs) Handles btnListarEvento.Click
        Dim ctrlGoogleCalendar = New GoogleCalendarControlador("primary")

        'Dim listEventos = ctrlGoogleCalendar.ListarEventos()
        Dim listEventos = ctrlEventos.ListarEventos()
        gvEventos.DataSource = listEventos
        gvEventos.DataBind()

    End Sub

    Protected Sub gvEventos_DataBound(sender As Object, e As EventArgs) Handles gvEventos.DataBound
        ' Dim col As New DataGridViewColumn
        'col.HeaderText = "Acciones"
        ' gvEventos.Columns.Insert(gvEventos.Columns.Count, "Accion")
        ' dgv.Columns.Insert(dgv.ColumnCount, col)
        AgregarBotonesControl()
    End Sub

    Private Sub AgregarBotonesControl()
        For Each row In gvEventos.Rows
            Dim btnDetalle = New Button()
            btnDetalle.Text = "Detalle"
            btnDetalle.CommandName += "ListardetalleEvento"
            row.Cells(gvEventos.Columns.Count + 4).Controls.Add(btnDetalle)
            Debug.WriteLine("Detalle agregado")

        Next
    End Sub

    Private Sub ListardetalleEvento(sender As Object, e As EventArgs)
        Debug.WriteLine("Hola Mundo")

    End Sub



End Class
