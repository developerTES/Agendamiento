
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
    Dim msg As New clMensajes()

    Protected Sub btnRegistrarEvento_Click(sender As Object, e As EventArgs) Handles btnRegistrarEvento.Click


        Dim strNombre = txtNombreEvento.Text
        Dim strDescripcion = txtDescripcionEvento.Text.ToString
        Debug.WriteLine("DESCRIPCION ES " + strDescripcion.ToString)
        Dim strLugarID = ddlLugar.SelectedValue
        Dim respuesta = ""

        Dim invitados As New List(Of EventAttendee)
        Dim lstAsistentes As New List(Of Asistente)



        Dim serviciosRequeridos = Me.obtenerServiciosRequeridos()
        For Each inv In cbxlInvitados.Items
            Dim invitado As New EventAttendee()
            invitado.Email = inv.ToString
            invitados.Add(invitado)
            lstAsistentes.Add(New Asistente(inv.ToString))
        Next

        For Each serv In serviciosRequeridos
            For Each email_servicio In serv.email_responsable
                Debug.WriteLine("ESTOY EN SERVICIOS, el email es" & email_servicio)

                'If lstAsistentes.Contains(New Asistente(email_servicio)) Then

                If lstAsistentes.Exists(Function(asis) asis.email_asistente = email_servicio) Then
                    Debug.WriteLine("Asistente repetido !!!!!!!")
                Else
                    Debug.WriteLine("Asistente no repetido !!!!!!!")
                    Dim invitado As New EventAttendee()
                    invitado.Email = email_servicio
                    invitados.Add(invitado)
                    lstAsistentes.Add(New Asistente(email_servicio))
                End If


            Next

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
            Dim eventoGoogleCreado = ctrlGoogleCalendario.RegistrarEventoRecurrente(eventoGoogleCal, horaInicio, horaFin, serviciosRequeridos)
            Dim evento As New Evento(eventoGoogleCreado.Id, Session("email"), strNombre, strLugarID, "REUNION", "ESRECURRENTE")

            respuesta = ctrlEvento.RegistrarEventoRecurrente(evento, lstAsistentes)
            If respuesta IsNot Nothing Then
                Dim respuestas = ctrlCita.registrarCitasEventoRecurrente(evento)

                Debug.WriteLine(respuesta)
                Debug.WriteLine(respuestas)

                respuesta += ctrlServRecursoLugar.registrarRecursosRequeridos(evento, serviciosRequeridos) & respuestas
                Response.Write(msg.Mensajes(respuesta))
                'Me.registrarRecursos(serviciosRequeridos)
            Else
                Response.Write(msg.Mensajes(("No se pudo registrar el evento!!" & respuesta)))
                'msg.Mensajes("No se pudo registrar el evento!!")
                'Debug.WriteLine("No se pudo registrar el evento!!")
            End If

        Else

            Dim datetimeinicio As New DateTime()
            Dim datetimeFin As New DateTime()
            Try
                datetimeinicio = DateTime.Parse(txtDatetimeInicio.Text)
                datetimeFin = DateTime.Parse(txtDatetimeFin.Text)
            Catch ex As Exception
                Response.Write(msg.Mensajes(("Ingrese una fecha válida!!" & respuesta)))
            End Try




            Dim eventoGoogleCal = New EventoGoogleCalendar(strNombre, strDescripcion, datetimeInicio, datetimeFin, invitados)
            Dim eventoGoogleCreado = ctrlGoogleCalendario.RegistrarEventoSimple(eventoGoogleCal, serviciosRequeridos)

            Dim evento As New Evento(eventoGoogleCreado.Id, Session("email"), strNombre, strLugarID, "REUNION", "NORECURRENTE")

            Dim cita As New Cita(eventoGoogleCreado.Id, eventoGoogleCreado.Id, eventoGoogleCreado.Start.DateTime, eventoGoogleCreado.End.DateTime)
            respuesta = ctrlEvento.RegistrarEventoSimple(evento, lstAsistentes, cita)
            If respuesta IsNot Nothing Then

                Debug.WriteLine(respuesta)
                Dim res = ctrlServRecursoLugar.registrarRecursosRequeridos(evento, serviciosRequeridos)
                Response.Write(msg.Mensajes(respuesta))

                'Response.Redirect("Eventos.aspx")
            Else

                Response.Write(msg.Mensajes(("No se pudo registrar el evento!!" & respuesta)))
            End If


        End If







    End Sub




    Protected Sub txtInvitado_TextChanged(sender As Object, e As EventArgs) Handles txtInvitado.TextChanged



    End Sub



    Protected Sub btnAgregarInvitado_Click(sender As Object, e As EventArgs) Handles btnAgregarInvitado.Click
        Dim strEmail = txtInvitado.Text



        Dim existe = False
        For Each i In cbxlInvitados.Items
            If i.Text = strEmail Then
                existe = True
            End If
        Next

        If existe Then
        Else
            cbxlInvitados.Items.Add(strEmail)
            For Each i As ListItem In cbxlInvitados.Items
                i.Selected = True
            Next
        End If

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




        If (Page.IsPostBack) Then

        End If




        'Dim ss As String = Await WebView1.InvokeScriptAsync("eval", New String() {"document.getElementById('userresponse').value;"})



    End Sub

    Private Sub BindRepeater()

        Dim servicios = ctrlServRecursoLugar.obtenerServicios



    End Sub

    Private Function obtenerServiciosRequeridos() As List(Of Servicio)
        'Session("lstServicios") = lstServicios
        Dim servicioActual = ""
        'Dim lstServRecursos As New List(Of List(Of Recurso))
        Dim lstServRecursos As New List(Of Servicio)
        Dim s As New Servicio()
        Dim r As New List(Of Recurso)
        'lstServRecursos.Add(New List(Of String))
        ' lstServRecursos.Add(New List(Of String))

        Dim lstRecursosServicios As New List(Of String)

        For Each control In Request.Form

            If control.ToString.Substring(0, 7) = "txtCant" Or control.ToString.Substring(0, 7) = "txtDesc" Then
                lstRecursosServicios.Add(control)
            End If
        Next

        For i As Integer = 0 To lstRecursosServicios.Count - 1 Step 2
            Dim idServ = lstRecursosServicios(i).Split("_")(1)
            Dim idRec = lstRecursosServicios(i + 1).Split("_")(2)
            If servicioActual <> idServ Then

                If servicioActual <> "" Then
                    s.recursos = r
                    If s.recursos.Count <> 0 Then
                        lstServRecursos.Add(s)

                    End If
                    r = New List(Of Recurso)

                End If

                servicioActual = idServ

                s = ctrlServRecursoLugar.obtenerServicio(servicioActual)
                Debug.WriteLine("SERVICIO")

            Else

            End If


            Dim miRec = ctrlServRecursoLugar.obtenerRecurso(servicioActual, idRec)
            Debug.WriteLine(" rec " & servicioActual & idRec & ": " & Request.Form(lstRecursosServicios(i)) & "DESC " & Request.Form(lstRecursosServicios(i + 1)))
            miRec.setDetallesRecurso(Request.Form(lstRecursosServicios(i)).ToString & ".  " & Request.Form(lstRecursosServicios(i + 1).ToString))
            If Integer.Parse(Request.Form(lstRecursosServicios(i))) > 0 Then
                r.Add(miRec)
            Else
                Debug.WriteLine("CANT Y DESCR VACIOS")
            End If




        Next
        Try
            If s.recursos.Count <> 0 Then
                lstServRecursos.Add(s)

            End If
        Catch ex As Exception

        End Try

        For Each servicio In lstServRecursos
            Debug.WriteLine("SERVICIO ------- " & servicio.nom_servicio)
            For Each recurso In servicio.recursos

                Debug.WriteLine("DETALLES " + recurso.detalles_recurso)
            Next
        Next

        Return lstServRecursos
    End Function

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
            panelNoRepitencia.Visible = False
            panelRepitencia.Visible = True
            'panelNoRepitencia.Controls.a
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
            panelNoRepitencia.Visible = True
            panelRepitencia.Visible = False
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

    Protected Sub txtHoraRepitenciaInicio_TextChanged(sender As Object, e As EventArgs) Handles txtHoraRepitenciaInicio.TextChanged

        Try
            Dim h_i = txtHoraRepitenciaInicio.Text
            Dim h_f = txtHoraRepitenciaFin.Text
            Debug.WriteLine(h_i)
            Debug.WriteLine(h_f)
            If h_i.CompareTo(h_f) > 0 Then
                If h_i IsNot Nothing And h_f IsNot Nothing Then
                    Response.Write(msg.Mensajes("La hora inicial no debe ser mayor a la hora final!"))
                    txtHoraRepitenciaFin.Text = ""
                End If

            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub
    Protected Sub txtRepitenciaFechaFin_TextChanged(sender As Object, e As EventArgs) Handles txtRepitenciaFechaFin.TextChanged
        Try
            Dim h_i = txtHoraRepitenciaInicio.Text
            Dim h_f = txtHoraRepitenciaFin.Text
            Debug.WriteLine(h_i)
            Debug.WriteLine(h_f)
            If h_i.CompareTo(h_f) > 0 Then
                If h_i IsNot Nothing And h_f IsNot Nothing Then
                    Response.Write(msg.Mensajes("La hora inicial no debe ser mayor a la hora final!"))
                    txtHoraRepitenciaFin.Text = ""
                End If

            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub


    Protected Sub txtDatetimeInicio_TextChanged(sender As Object, e As EventArgs) Handles txtDatetimeInicio.TextChanged
        Try
            Dim d_inicio = Convert.ToDateTime(txtDatetimeInicio.Text)
            Dim d_final = Convert.ToDateTime(txtDatetimeFin.Text)

            If d_inicio.CompareTo(DateTime.Now().AddDays(1)) <> 1 Then
                Dim msg = New clMensajes

                'Debug.WriteLine("Datetime es " & DateTime.Now().AddDays(1).ToString)
                Response.Write(msg.Mensajes("La fecha debe ser superior a 24 horas!"))
                txtDatetimeInicio.Text = DateTime.Now().AddDays(1)
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try

        Try
            Dim d_inicio = Convert.ToDateTime(txtDatetimeInicio.Text)
            Dim d_final = Convert.ToDateTime(txtDatetimeFin.Text)
            If d_inicio.CompareTo(d_final) = 1 Then
                Response.Write(msg.Mensajes("La fecha inicial debe ser superior a la fecha final!"))
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try

    End Sub

    Protected Sub txtDatetimeFin_TextChanged(sender As Object, e As EventArgs) Handles txtDatetimeFin.TextChanged
        Try
            Dim d_inicio = Convert.ToDateTime(txtDatetimeInicio.Text)
            Dim d_final = Convert.ToDateTime(txtDatetimeFin.Text)
            If d_inicio.CompareTo(d_final) = 1 Then
                Response.Write(msg.Mensajes("La fecha inicial debe ser superior a la fecha final!"))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtDescripcionEvento_TextChanged(sender As Object, e As EventArgs) Handles txtDescripcionEvento.TextChanged

    End Sub
    Protected Sub ddlLugar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlLugar.SelectedIndexChanged
        If txtDatetimeInicio.Text IsNot Nothing And txtDatetimeFin.Text IsNot Nothing Then
            Dim strLugarID = ddlLugar.SelectedValue
            Dim datetimeinicio As New DateTime()
            Dim datetimeFin As New DateTime()
            Try
                datetimeinicio = DateTime.Parse(txtDatetimeInicio.Text)
                datetimeFin = DateTime.Parse(txtDatetimeFin.Text)

                Dim strRta = ctrlServRecursoLugar.VerificarDisponibilidadLugar(strLugarID, datetimeinicio, datetimeFin)

            Catch ex As Exception
                Response.Write(msg.Mensajes(("Error")))
            End Try
        End If
    End Sub

End Class


