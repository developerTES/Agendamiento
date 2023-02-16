
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports Google.Apis.Calendar.v3.Data

Partial Class Nuevo_Evento
    Inherits System.Web.UI.Page

    Dim ctrlGoogleCalendario As New GoogleCalendarControlador("primary")
    Dim ctrlEvento As New ControladorEvento()
    Dim ctrlCita As New ControladorCita()
    Dim ctrlServRecursoLugar As New ControladorServicio_Recurso_Lugar()

    Protected Sub btnRegistrarEvento_Click(sender As Object, e As EventArgs) Handles btnRegistrarEvento.Click


        Dim strNombre = txtNombreEvento.Text
        Dim strDescripcion = txtDescripcionEvento.Text
        Dim strLugarID = ddlLugar.SelectedValue
        Dim respuesta = ""

        Dim invitados As New List(Of EventAttendee)
        Dim lstAsistentes As New List(Of Asistente)

        For Each inv In cbxlInvitados.Items
            Dim invitado As New EventAttendee()
            invitado.Email = inv.ToString
            invitados.Add(invitado)
            lstAsistentes.Add(New Asistente(inv.ToString))
        Next

        If cbRepitencia.Checked Then
            Dim strIntervalo = txtRepeticiones.Text
            Dim TipoRepeticion = ddlTipoRepitencia.SelectedIndex
            Dim SemanaDias = lbxSemana.GetSelectedIndices.ToList

            Dim strDateRepitenciaFecha = ""
            Dim strRepitenciaVeces = ""
            If cbRepitenciaFecha.Checked Then
                strDateRepitenciaFecha = txtRepitenciaFechaFin.Text
            ElseIf cbRepitenciaVeces.Checked Then
                strRepitenciaVeces = txtBoxNumVeces.Text
            End If

            Dim horaInicio = txtHoraRepitenciaInicio.Text
            Dim horaFin = txtHoraRepitenciaFin.Text

            Dim Reglas_Recurrencia = ctrlGoogleCalendario.setRecurrencia(strIntervalo, TipoRepeticion, SemanaDias, strDateRepitenciaFecha, strRepitenciaVeces)


            Dim eventoGoogleCal = New EventoGoogleCalendar(strNombre, strDescripcion, invitados, Reglas_Recurrencia)
            Dim eventoGoogleCreado = ctrlGoogleCalendario.RegistrarEventoRecurrente(eventoGoogleCal, horaInicio, horaFin)
            Dim evento As New Evento(eventoGoogleCreado.Id, Session("email"), strNombre, strLugarID, "REUNION", "ESRECURRENTE")

            respuesta = ctrlEvento.RegistrarEventoRecurrente(evento, lstAsistentes)
            If respuesta IsNot Nothing Then
                Dim respuestas = ctrlCita.registrarCitasEventoRecurrente(evento)
                Debug.WriteLine(respuesta)
                Debug.WriteLine(respuestas)
                Me.registrarRecursos()
            Else
                Debug.WriteLine("No se pudo registrar el evento!!")
            End If

        Else

            Dim datetimeInicio = DateTime.Parse(txtDatetimeInicio.Text)
            Dim datetimeFin = DateTime.Parse(txtDatetimeFin.Text)



            Dim eventoGoogleCal = New EventoGoogleCalendar(strNombre, strDescripcion, datetimeInicio, datetimeFin, invitados)
            Dim eventoGoogleCreado = ctrlGoogleCalendario.RegistrarEventoSimple(eventoGoogleCal)

            Dim evento As New Evento(eventoGoogleCreado.Id, Session("email"), strNombre, strLugarID, "REUNION", "NORECURRENTE")

            Dim cita As New Cita(eventoGoogleCreado.Id, eventoGoogleCreado.Id, eventoGoogleCreado.Start.DateTime, eventoGoogleCreado.End.DateTime)
            respuesta = ctrlEvento.RegistrarEventoSimple(evento, lstAsistentes, cita)
            If respuesta IsNot Nothing Then

                Debug.WriteLine(respuesta)
                Me.registrarRecursos()
            Else
                Debug.WriteLine("No se pudo registrar el evento!!")
            End If


        End If







    End Sub

    Private Sub registrarRecursos()
        For Each control In Page.Controls
            If TypeOf (control) Is CheckBox Then
                Debug.WriteLine(control.ToString)
            End If
        Next
    End Sub



    Protected Sub txtInvitado_TextChanged(sender As Object, e As EventArgs) Handles txtInvitado.TextChanged



    End Sub



    Protected Sub btnAgregarInvitado_Click(sender As Object, e As EventArgs) Handles btnAgregarInvitado.Click
        Dim strEmail = txtInvitado.Text

        cbxlInvitados.Items.Add(strEmail)

    End Sub
    Protected Sub btnRetirarSeleccionados_Click(sender As Object, e As EventArgs) Handles btnRetirarSeleccionados.Click

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load


        If Not Me.IsPostBack Then
            Me.BindRepeater()
        End If

        'cargarCamposRepitencia(False)
        If cbRepitencia.Checked = True Then
            cargarCamposRepitencia(True)
            cargarCamposNoRepitencia(False)
            If ddlTipoRepitencia.SelectedIndex <> 1 Then
                cargarSubCamposRepitenciaMeses(False)
            Else
                'cargarSubCamposRepitenciaMeses(True)
            End If
            cargarSubCamposRepitenciaMeses(False)

        Else
            cargarCamposRepitencia(False)
            cargarCamposNoRepitencia(True)
            cargarSubCamposRepitenciaMeses(False)
        End If
        txtDatetimeInicio.Attributes.Item("min") = DateTime.Now()


        Dim lstServicios = ctrlServRecursoLugar.obtenerServicios()

        Session("lstServicios") = lstServicios
        Dim lst = Page.Request.Form

        Debug.WriteLine("LIsta de controles checkbox")
        For Each control In lst
            'If TypeOf (control) Is CheckBox Then
            Debug.WriteLine(control)
            'End If
        Next

        'Dim ss As String = Await WebView1.InvokeScriptAsync("eval", New String() {"document.getElementById('userresponse').value;"})



    End Sub

    Private Sub BindRepeater()

        Dim servicios = ctrlServRecursoLugar.obtenerServicios
        rptServicios.DataSource = servicios
        rptServicios.DataBind()


    End Sub

    Protected Sub cargarCamposNoRepitencia(ByVal estado As Boolean)
        'cbxlRepitencia.Items.FindByValue("No se repite").Selected = Not estado
        lblFechaInicio.Visible = estado
        lblFechaFin.Visible = estado
        txtDatetimeInicio.Visible = estado
        txtDatetimeFin.Visible = estado


    End Sub
    Protected Sub cargarCamposRepitencia(ByVal estado As Boolean)
        'cbxlRepitencia.Items.FindByValue("Se repite").Selected = Not estado
        lblRepitencia.Visible = estado
        lblRepetirCada.Visible = estado
        'lblRepetirCada0.Visible = estado
        txtRepeticiones.Visible = estado
        ddlTipoRepitencia.Visible = estado
        'ddlSemanaDias.Visible = estado
        lblTermina.Visible = estado
        cbRepitenciaFecha.Visible = estado
        cbRepitenciaVeces.Visible = estado
        lblRepitencia1.Visible = estado
        lblRepitencia2.Visible = estado
        txtRepitenciaFechaFin.Visible = estado
        txtBoxNumVeces.Visible = estado
        lblRepitencia3.Visible = estado
        lblHoraRepitenciaInicio.Visible = estado
        lblHoraRepitenciaFin.Visible = estado
        txtHoraRepitenciaInicio.Visible = estado
        txtHoraRepitenciaFin.Visible = estado
        cargarSubCamposRepitenciaMeses(estado)

    End Sub

    Private Sub cargarSubCamposRepitenciaMeses(v As Boolean)
        lblRepetirCada0.Visible = v

        lbxSemana.Visible = v
    End Sub

    Private Sub cargarSubCamposRepitenciaFinFecha(v As Boolean)
        txtRepitenciaFechaFin.Enabled = v
        lblRepitencia1.Enabled = v
        lbxSemana.Visible = v
    End Sub

    Private Sub cargarSubCamposRepitenciaFinVeces(v As Boolean)
        lblRepitencia2.Enabled = v
        txtBoxNumVeces.Enabled = v
        lblRepitencia3.Enabled = v
    End Sub

    Protected Sub cbRepitencia_CheckedChanged(sender As Object, e As EventArgs) Handles cbRepitencia.CheckedChanged
        If cbRepitencia.Checked = True Then
            cargarCamposRepitencia(True)
            cargarCamposNoRepitencia(False)
            If ddlTipoRepitencia.SelectedIndex <> 1 Then
                cargarSubCamposRepitenciaMeses(False)
            Else
                'cargarSubCamposRepitenciaMeses(True)
            End If
            cargarSubCamposRepitenciaMeses(False)
        Else
            cargarCamposRepitencia(False)
            cargarCamposNoRepitencia(True)
        End If
    End Sub
    Protected Sub ddlTipoRepitencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlTipoRepitencia.SelectedIndexChanged
        If ddlTipoRepitencia.SelectedIndex = 1 Then
            cargarSubCamposRepitenciaMeses(True)


        Else
            cargarSubCamposRepitenciaMeses(False)

        End If
    End Sub

    Protected Sub ddlTipoRepitencia_Load(sender As Object, e As EventArgs) Handles ddlTipoRepitencia.Load
        If ddlTipoRepitencia.SelectedIndex = 1 Then
            cargarSubCamposRepitenciaMeses(True)
        Else
            cargarSubCamposRepitenciaMeses(False)
        End If
    End Sub


    Protected Sub cbRepitenciaFecha_CheckedChanged(sender As Object, e As EventArgs) Handles cbRepitenciaFecha.CheckedChanged
        If cbRepitenciaFecha.Checked = True Then
            cargarSubCamposRepitenciaFinFecha(True)
            cargarSubCamposRepitenciaFinVeces(False)
            cbRepitenciaVeces.Checked = False
        Else
            cargarSubCamposRepitenciaFinFecha(False)
            'cbRepitenciaVeces.Checked = True
        End If
    End Sub
    Protected Sub cbRepitenciaVeces_CheckedChanged(sender As Object, e As EventArgs) Handles cbRepitenciaVeces.CheckedChanged
        If cbRepitenciaVeces.Checked = True Then
            cargarSubCamposRepitenciaFinFecha(False)
            cargarSubCamposRepitenciaFinVeces(True)
            cbRepitenciaFecha.Checked = False
        Else
            cargarSubCamposRepitenciaFinFecha(True)
            'cbRepitenciaVeces.Checked = False
        End If
    End Sub
    Protected Sub txtRepitenciaFechaFin_TextChanged(sender As Object, e As EventArgs) Handles txtRepitenciaFechaFin.TextChanged



    End Sub
    Protected Sub txtHoraRepitenciaInicio_TextChanged(sender As Object, e As EventArgs) Handles txtHoraRepitenciaInicio.TextChanged

    End Sub

    Protected Sub txtDatetimeInicio_TextChanged(sender As Object, e As EventArgs) Handles txtDatetimeInicio.TextChanged
        Try
            If Convert.ToDateTime(txtDatetimeInicio.Text) < DateTime.Now() Then
                Dim msg = New clMensajes
                msg.Mensajes("La fecha debe ser mayor a la actual")
                MsgBox("La fecha debe ser mayor a la actual")
            End If
        Catch ex As Exception

        End Try

        Try
            If Convert.ToDateTime(txtDatetimeInicio.Text) > Convert.ToDateTime(txtDatetimeFin.Text) Then
                Dim msg = New clMensajes
                msg.Mensajes("La fecha debe ser mayor a la actual")
                MsgBox("La fecha Inicial debe ser mayor a la fecha final")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtDatetimeFin_TextChanged(sender As Object, e As EventArgs) Handles txtDatetimeFin.TextChanged

    End Sub
End Class


