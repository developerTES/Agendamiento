Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports Google.Apis.Calendar.v3.Data
Imports Microsoft.VisualBasic

Public Class ControladorEvento

    Dim conn = New Conexion().conn
    Dim ctrlGoogleCalendar As New GoogleCalendarControlador("primary")
    Sub New()

    End Sub

    Public Function RegistrarEventoSimple(evento As Evento, lstAsistentes As List(Of Asistente), cita As Cita) As String
        Try
            conn.Open()
            Dim cmd As New SqlCommand With {.Connection = conn}
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "registrarEventoSimple"
            cmd.Parameters.AddWithValue("@EID_GOOGLEICALUID", evento.id_GoogleCalUID)
            cmd.Parameters.AddWithValue("@EID_LUGAR", evento.id_lugar)
            cmd.Parameters.AddWithValue("@ETIPO_EVENTO", evento.strTipoEvento)
            cmd.Parameters.AddWithValue("@ERECURRENCIA", evento.strRecurrencia)
            cmd.Parameters.AddWithValue("@EID_cITA", 1)
            cmd.Parameters.AddWithValue("@ENOM_EVENTO", evento.nom_Evento)
            cmd.Parameters.AddWithValue("@EEMAIL_organizador", evento.email_organizador)
            cmd.Parameters.AddWithValue("@E_ESTADO", "confirmed") 'o cancelled'
            Debug.WriteLine(cita.date_inicio)
            Debug.WriteLine(cita.date_fin)
            cmd.Parameters.AddWithValue("@DATE_INICIO", cita.date_inicio)
            cmd.Parameters.AddWithValue("@DATE_FIN", cita.date_fin)
            Dim rs = cmd.ExecuteNonQuery()
            Debug.WriteLine("Filas afectadas " & rs)
            If rs > 0 Then

                Try
                    For Each asistente In lstAsistentes
                        Debug.WriteLine("Asistent e ID" & asistente.email_asistente, evento.id_GoogleCalUID)
                        Dim cmd2 As New SqlCommand With {.Connection = conn}
                        cmd2.CommandType = CommandType.StoredProcedure
                        cmd2.CommandText = "registrarAsistenteEvento"
                        cmd2.Parameters.AddWithValue("@EID_GOOGLEICALUID", evento.id_GoogleCalUID)
                        cmd2.Parameters.AddWithValue("@EID_ASISTENTE", asistente.email_asistente)
                        rs = cmd2.ExecuteNonQuery()
                    Next
                    Return "Se pudo crear el evento, asistentes notificados"
                Catch ex As Exception
                    Debug.WriteLine("ERROR EN REGISTRAR ASISTENTES EVENTOSIMPLE " & ex.Message & ex.StackTrace)
                    Return Nothing
                End Try

            Else
                Debug.WriteLine("ERROR EN REGISTRAREVENTOSIMPLE: filas afectadas 0 ")
                Return Nothing
            End If
            conn.Close()
        Catch ex As Exception
            Debug.WriteLine("ERROR EN REGISTRAREVENTOSIMPLE " & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function RegistrarEventoRecurrente(evento As Evento, lstAsistentes As List(Of Asistente)) As String
        Try
            conn.Open()

            Dim cmd As New SqlCommand With {.Connection = conn}
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "registrarEventoRecurrente"
            cmd.Parameters.AddWithValue("@EID_GOOGLEICALUID", evento.id_GoogleCalUID)
            cmd.Parameters.AddWithValue("@EID_LUGAR", evento.id_lugar)
            cmd.Parameters.AddWithValue("@ETIPO_EVENTO", evento.strTipoEvento)
            cmd.Parameters.AddWithValue("@ERECURRENCIA", evento.strRecurrencia)
            cmd.Parameters.AddWithValue("@ENOM_EVENTO", evento.nom_Evento)
            cmd.Parameters.AddWithValue("@EEMAIL_organizador", evento.email_organizador)
            cmd.Parameters.AddWithValue("@E_ESTADO", "confirmed") 'o cancelled'
            Dim rs = cmd.ExecuteNonQuery()
            If rs > 0 Then

                Try
                    For Each asistente In lstAsistentes
                        Dim cmd2 As New SqlCommand With {.Connection = conn}
                        cmd2.CommandType = CommandType.StoredProcedure
                        cmd2.CommandText = "registrarAsistenteEvento"
                        cmd2.Parameters.AddWithValue("@EID_GOOGLEICALUID", evento.id_GoogleCalUID)
                        cmd2.Parameters.AddWithValue("@EID_ASISTENTE", asistente.email_asistente)
                        rs = cmd2.ExecuteNonQuery()
                    Next
                    Return "Se pudo crear el evento, asistentes notificados"
                Catch ex As Exception
                    Debug.WriteLine("ERROR EN REGISTRAREVENTOSIMPLE " & ex.Message)
                    Return Nothing
                End Try
            End If

        Catch ex As Exception
            Debug.WriteLine("ERROR EN REGISTRAREVENTORECURRENTE " & ex.Message)
            Return Nothing
        End Try
    End Function


    Public Function ListarEventosEmailTipo(ByVal email As String, ByVal tipo As String) As List(Of Evento)
        Dim lst As New List(Of Evento)
        Dim lstStr As New List(Of String)
        Dim strSQL = ""
        Try
            conn.Open()
            Select Case tipo
                Case "ORGANIZADOR"
                    strSQL = "SELECT * FROM EVENTO as e, CITA as c WHERE  e.ID_GOOGLEICALUID = c.ID_GOOGLEICALUID   AND EMAIL_ORGANIZADOR = @EMAIL and c.date_inicio > GETDATE()  ORDER BY c.DATE_INICIO "

                Case "ASISTENTE"
                    strSQL = "SELECT * FROM EVENTO as e, CITA as c, ASISTENTE_EVENTO as asis WHERE  e.ID_GOOGLEICALUID = c.ID_GOOGLEICALUID   AND e.ID_GOOGLEICALUID = asis.ID_GOOGLEICALUID AND ID_ASISTENTE = @EMAIL and c.date_inicio > GETDATE() ORDER BY c.DATE_INICIO "

                Case "SOPORTE"
                    strSQL = "SELECT * FROM EVENTO as e, CITA as c, EVENTO_SERVICIO as e_s, INTEGRANTE AS i WHERE 
                                e.ID_GOOGLEICALUID = c.ID_GOOGLEICALUID   AND
                                c.ID_GOOGLEICALUID = e_s.ID_GOOGLEICALUID AND 
                                e_s.ID_SERVICIO = i.ID_SERVICIO AND 
                                i.ID_INTEGRANTE  = @EMAIL AND
                                c.date_inicio > GETDATE()
                                ORDER BY c.DATE_INICIO "
            End Select


            Dim cmd = New SqlCommand(strSQL, conn)
            cmd.Parameters.AddWithValue("@EMAIL", email)
            Dim rs = cmd.ExecuteReader()

            While rs.Read()

                Dim google_CalUID = rs.GetValue(0)
                Debug.WriteLine("Listando eventos dde " & google_CalUID)
                If ctrlGoogleCalendar.verificarEvento(google_CalUID) Then
                    Debug.WriteLine("EVENTO SIN CANCELAR")
                    Dim c As New Cita(rs.GetValue(0), rs.GetValue(8), rs.GetValue(9), rs.GetValue(10))
                    Debug.WriteLine("CITA ES " & c.id_GoogleICalUID & c.date_inicio)
                    Dim lstCitas As New List(Of Cita)
                    lstCitas.Add(c)
                    Dim e As New Evento(rs.GetValue(0), rs.GetValue(2), rs.GetValue(3), rs.GetValue(1), rs.GetValue(4), rs.GetValue(5), rs.GetValue(6), lstCitas, ctrlGoogleCalendar.getEvento(rs.GetValue(0)))
                    lst.Add(e)
                Else
                    Debug.WriteLine("EVENTO CANCELADO")
                End If


            End While

            conn.close()



            Return lst

        Catch ex As Exception
            Debug.WriteLine("ERROR EN LISTAR EVENTOS " & ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function



    Function getEvento(google_CalUID As String) As Evento

        Dim ctrlCita As New ControladorCita()
        Dim lstCitas = ctrlCita.obtenerCitasEvento(google_CalUID)

        Dim ev As New Evento()


        Try
            conn.Open()
            Dim cmd = New SqlCommand("SELECT * FROM EVENTO WHERE ID_GOOGLEICALUID=@ID", conn)
            cmd.Parameters.AddWithValue("@ID", google_CalUID)
            Dim rs = cmd.ExecuteReader()

            While rs.Read()
                ev = New Evento(rs.GetValue(0), rs.GetValue(2), rs.GetValue(3), rs.GetValue(1), rs.GetValue(4), rs.GetValue(5), rs.GetValue(6))
            End While
            conn.close()

            ev.evGoogle = ctrlGoogleCalendar.getEvento(google_CalUID)
            ev.citas = lstCitas
        Catch ex As Exception
            Debug.WriteLine("Error obteniendo evento " + ex.Message)
            Return Nothing
        End Try

        Return ev




    End Function

    Friend Function obtenerEventosXLugar(strLugarID As String) As List(Of Evento)
        Try
            Dim lstEv As New List(Of Evento)
            conn.Open()
            Dim cmd = New SqlCommand("SELECT * FROM EVENTO WHERE id_lugar = @EID_LUGAR ", conn)
            cmd.Parameters.AddWithValue("@EID_LUGAR", strLugarID)
            Dim rs = cmd.ExecuteReader()
            While rs.Read()

                Dim e As New Evento(rs.GetValue(0), rs.GetValue(2), rs.GetValue(3), rs.GetValue(1), rs.GetValue(4), rs.GetValue(5), rs.GetValue(6))
                lstEv.Add(e)
            End While
            conn.close()
            Return lstEv
        Catch ex As Exception
            Debug.WriteLine("Error en obtenerEventosXLugar " + ex.Message)
            Return Nothing
        End Try
    End Function
End Class
