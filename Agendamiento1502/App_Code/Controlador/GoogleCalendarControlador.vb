Imports Microsoft.VisualBasic

Imports System.IO
Imports System.Threading

Imports Google.Apis.Calendar.v3
Imports Google.Apis.Calendar.v3.Data
Imports Google.Apis.Calendar.v3.EventsResource
Imports Google.Apis.Services
Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Util.Store
Imports System.Diagnostics

Public Class GoogleCalendarControlador

    Public Property calendarID As String
    Public Property service As CalendarService
    Dim ctrlServLugarRec As New ControladorServicio_Recurso_Lugar()
    'Dim ctrlEvento As New ControladorEvento()

    Public Sub New(strCalendarID As String)
        Me.calendarID = strCalendarID
        Dim credential As UserCredential

        Using stream = New FileStream("C:\Users\developer\source\repos\Agendamiento\Agendamiento\Bin\client_secrets.json", FileMode.Open, FileAccess.Read)
            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.FromStream(stream).Secrets, {CalendarService.Scope.Calendar}, "user", CancellationToken.None, New FileDataStore("Calendar.MyEvents")).Result
        End Using

        service = New CalendarService(New BaseClientService.Initializer() With {
            .HttpClientInitializer = credential,
            .ApplicationName = "Calendar API Sample"
        })
        Me.Conectar()
    End Sub


    Public Function Conectar() As Boolean
        Debug.WriteLine("Calendar API Sample: List MyCalendar")
        Debug.WriteLine("================================")
        Dim scopes As IList(Of String) = {"profile", "email", "CalendarService.Scope.Calendar"}

        Try



            Dim calendarList = service.CalendarList.List.ExecuteAsync()

            Dim Calendar = service.Calendars.Get(Me.calendarID).Execute()
            Debug.WriteLine("Calendario Conectado! :")
            Debug.WriteLine("Calendar Name :")
            Debug.WriteLine(Calendar.Summary)
            Debug.WriteLine(Calendar.Description)
            Return True
        Catch ex As AggregateException

            For Each e In ex.InnerExceptions
                Debug.WriteLine("ERROR: " & e.Message)
            Next
            Return False
        End Try
    End Function

    Public Function setRecurrencia(strIntervalo As String, TipoRepeticion As Integer, SemanaDias As List(Of Integer), strDateRepitenciaFecha As String, strRepitenciaVeces As String) As List(Of String)
        Dim example = "RRULE:FREQ=WEEKLY;UNTIL=20230228T170000Z"
        Dim rules As New List(Of String)
        Dim rule = "RRULE:"
        Dim week = {"MO", "TU", "WE", "TH", "FR", "SA", "SU"}


        Select Case TipoRepeticion
            Case 0
                rule += "FREQ=DAILY;"
            Case 1
                rule += "FREQ=WEEKLY;"
            Case 2
                rule += "FREQ=MONTHLY;"
            Case 3
                rule += "FREQ=YEARLY;"
        End Select



        If TipoRepeticion = 1 Then
            rule += "BYDAY="
            Dim i = 0
            For Each dia In SemanaDias
                rule += week(dia)
                i += 1
                If i < SemanaDias.Count Then
                    rule += ","
                End If
            Next
            rule += ";"
        End If

        rule += "INTERVAL=" & strIntervalo & ";"

        If strDateRepitenciaFecha <> "" Then
            Dim fecha = Date.Parse(strDateRepitenciaFecha)

            rule += "UNTIL=" & fecha.Year & fecha.Month.ToString("D2") & fecha.Day.ToString("D2") + "T235959Z"
        ElseIf strRepitenciaVeces <> "" Then
            rule += "COUNT=" & strRepitenciaVeces
        End If
        Debug.WriteLine("LA REGLA DE RECURRENCIA ES ............" + rule)
        rules.Add(rule)
        Debug.WriteLine("LOS DIAS ELEGIDOS SON ............")
        For Each i In SemanaDias
            Debug.WriteLine(i)
        Next


        Return rules

    End Function

    Public Function RegistrarEventoRecurrente(_evento As EventoGoogleCalendar, _horaInicio As String, _horaFin As String, _serviciosRequeridos As List(Of Servicio)) As Data.Event

        Dim ev = New Data.Event()
        Dim strDescripcionServicios = ctrlServLugarRec.ConstruirDetalleRecursos(_serviciosRequeridos)
        Try
            Dim start1 = New DateTime()
            start1 = start1.AddYears(DateTime.Today.Year - 1)
            start1 = start1.AddMonths(DateTime.Today.Month - 1)
            start1 = start1.AddDays(DateTime.Today.Day - 1)
            start1 = start1.AddMinutes(Convert.ToDateTime(_horaInicio).Minute)
            start1 = start1.AddHours(Convert.ToDateTime(_horaInicio).Hour)


            Dim endtime1 = New DateTime()
            endtime1 = endtime1.AddYears(DateTime.Today.Year - 1)
            endtime1 = endtime1.AddMonths(DateTime.Today.Month - 1)
            endtime1 = endtime1.AddDays(DateTime.Today.Day - 1)
            endtime1 = endtime1.AddMinutes(Convert.ToDateTime(_horaFin).Minute)
            endtime1 = endtime1.AddHours(Convert.ToDateTime(_horaFin).Hour)



            Dim start = New EventDateTime With {.DateTime = start1, .TimeZone = "America/Bogota"}
            Dim end_time = New EventDateTime With {.DateTime = endtime1, .TimeZone = "America/Bogota"}

            ev.Start = start
            ev.End = end_time
            ev.Summary = _evento.strName
            ev.Description = _evento.strDescription & strDescripcionServicios
            ev.Recurrence = _evento.lstRecurrenceRules


            ev.Attendees = _evento.lstInvitados

            Dim request = service.Events.Insert(ev, calendarID)
            request.SendNotifications = True
            Dim eventoCreado = request.Execute()

            Debug.WriteLine("Detalles del evento ")
            Debug.WriteLine(eventoCreado.ICalUID)
            Debug.WriteLine(eventoCreado.Organizer.Email)

            'Debug.WriteLine(ev.Creator.DisplayName)
            Return eventoCreado
        Catch ex As Exception
            Debug.WriteLine("Exception .! ")
            Debug.WriteLine(ex.StackTrace)
            Debug.WriteLine(ex.Message)
            Return ev
        End Try
    End Function




    Public Function RegistrarEventoSimple(_evento As EventoGoogleCalendar, _serviciosRequeridos As List(Of Servicio)) As Data.Event
        Dim ev = New Data.Event()
        Dim strDescripcionServicios = ctrlServLugarRec.ConstruirDetalleRecursos(_serviciosRequeridos)

        Try

            Dim start = New EventDateTime()
            start.DateTime = _evento.datetimeInicio

            Debug.WriteLine("LA FECHA DE INICIO DEL EVENTO SIMPLE ES!!!  " & start.DateTime)

            Dim end_Date = New EventDateTime()
            end_Date.DateTime = _evento.datetimeFin

            Dim invitados As New List(Of EventAttendee)


            ev.Start = start
            ev.End = end_Date
            ev.Summary = _evento.strName
            ev.Description = _evento.strDescription & strDescripcionServicios


            ev.Attendees = _evento.lstInvitados


            Dim request = service.Events.Insert(ev, calendarID)
            request.SendNotifications = True
            Dim eventoCreado = request.Execute()


            Debug.WriteLine("Detalles del evento ")
            Debug.WriteLine(eventoCreado.ICalUID)
            Debug.WriteLine(eventoCreado.Id)
            Debug.WriteLine(eventoCreado.Organizer.Email)
            Debug.WriteLine(eventoCreado.Recurrence)
            Debug.WriteLine(eventoCreado.Summary)
            Debug.WriteLine(eventoCreado.HtmlLink)
            'Debug.WriteLine(ev.Creator.DisplayName)
            Return eventoCreado
        Catch ex As Exception
            Debug.WriteLine("Exception .! ")
            Debug.WriteLine(ex.StackTrace)
            Debug.WriteLine(ex.Message)
            Return ev
        End Try
    End Function

    Public Function ListarEventos() As List(Of EventoGoogleCalendar)

        Try
            '// Define parameters of request.
            Dim ListRequest As ListRequest = service.Events.List(calendarID)
            Dim listEventos As New List(Of EventoGoogleCalendar)

            ListRequest.TimeMin = DateTime.Now
            ListRequest.ShowDeleted = False
            ListRequest.SingleEvents = True
            ListRequest.MaxResults = 20
            ListRequest.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime

            '// List events.
            Dim Events As Events = ListRequest.Execute()
            Debug.WriteLine("Upcoming events:")
            If Events.Items IsNot Nothing And Events.Items.Count > 0 Then
                Debug.WriteLine("Si  hay eventos!")

                For Each ev As Data.Event In Events.Items
                    'Dim hora As String = ev.Start.DateTime.ToString()
                    'Debug.WriteLine("{0} ({1})", ev.Summary, hora)
                    Dim evento As New EventoGoogleCalendar(ev.Summary, ev.Description, ev.Start.DateTime, ev.End.DateTime, ev.Attendees)
                    listEventos.Add(evento)
                Next

                Return listEventos

            Else
                Debug.WriteLine("No upcoming events found.")
                Return listEventos
            End If


        Catch ex As Exception
            Debug.WriteLine("Excepcion .. ")
            Debug.WriteLine(ex.StackTrace)
            Debug.WriteLine(ex.Message)
            Return Nothing
        End Try

    End Function

    Function getCitasEvento(id_GoogleCalUID As String) As List(Of Data.Event)

        ' If verificarEvento(id_GoogleCalUID) Then
        Dim request = service.Events.Instances("primary", id_GoogleCalUID)

            request.PageToken = Nothing

            Dim events = request.Execute()


        For Each ev In events.Items

            'Debug.WriteLine(ev.Id)
            'Debug.WriteLine(ev.Start.DateTime)
        Next
        Return events.Items
            'Else
        ' Return Nothing
        'End If

    End Function


    Function getEvento(id_GoogleCalUID As String) As Data.Event
        Dim request = service.Events.Get(calendarID, id_GoogleCalUID)
        Dim ev = request.Execute()
        Return ev
    End Function


    'Function addInvitadosServicios()
    '   service.Events.Update()
    'End Function
End Class
