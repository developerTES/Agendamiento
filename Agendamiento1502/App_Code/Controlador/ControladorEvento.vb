﻿Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports Google.Apis.Calendar.v3.Data
Imports Microsoft.VisualBasic

Public Class ControladorEvento

    Dim conn = New Conexion().conn
    Dim ctrlGoogleCalendar As New GoogleCalendarControlador("primary")

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
            Debug.WriteLine(cita.date_inicio)
            Debug.WriteLine(cita.date_fin)
            cmd.Parameters.AddWithValue("@DATE_INICIO", cita.date_inicio)
            cmd.Parameters.AddWithValue("@DATE_FIN", cita.date_fin)
            Dim rs = cmd.ExecuteNonQuery()
            Debug.WriteLine("Filas afectadas " & rs)
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
                    strSQL = "SELECT * FROM EVENTO as e, CITA as c WHERE  e.ID_GOOGLEICALUID = c.ID_GOOGLEICALUID   AND EMAIL_ORGANIZADOR = @EMAIL ORDER BY c.DATE_INICIO "

                Case "ASISTENTE"
                    strSQL = "SELECT * FROM EVENTO as e, CITA as c, EVENTO_ASISTENTES as asis WHERE  e.ID_GOOGLEICALUID = c.ID_GOOGLEICALUID   AND e.ID_GOOGLEICALUID asis.ID_GOOGLEICALUID AND ID_ASISTENTE = @EMAIL ORDER BY c.DATE_INICIO "

                Case "SOPORTE"
                    strSQL = "SELECT * FROM EVENTO as e, CITA as c, EVENTO_SERVICIO as e_s, INTEGRANTE AS i WHERE 
                                e.ID_GOOGLEICALUID = c.ID_GOOGLEICALUID   AND
                                c.ID_GOOGLEICALUID = e_s.ID_GOOGLEICALUID AND 
                                e_s.ID_SERVICIO = i.ID_SERVICIO AND 
                                i.ID_INTEGRANTE  = @EMAIL
                                ORDER BY c.DATE_INICIO "
            End Select


            Dim cmd = New SqlCommand(strSQL, conn)
            cmd.Parameters.AddWithValue("@EMAIL", email)
            Dim rs = cmd.ExecuteReader()

            While rs.Read()
                Dim google_CalUID = rs.GetValue(0)

                lstStr.Add(google_CalUID)

            End While
            conn.close()

            For Each id In lstStr
                Dim ev = Me.getEvento(id)
                lst.Add(ev)
            Next
            Return lst

        Catch ex As Exception
            Debug.WriteLine("ERROR EN LISTAR EVENTOS " & ex.Message)
            Return Nothing
        End Try
    End Function



    Function getEvento(google_CalUID As String) As Evento
        Dim lstCitas As New List(Of Cita)
        Dim lstOcurrences = ctrlGoogleCalendar.getCitasEvento(google_CalUID)
        Dim ev As New Evento()
        For Each ocurrence In lstOcurrences
            Dim cita As New Cita(google_CalUID, 0, ocurrence.Start.Date, ocurrence.End.DateTime)
            lstCitas.Add(cita)
        Next

        Try
            conn.Open()
            Dim cmd = New SqlCommand("SELECT * FROM EVENTO WHERE ID_GOOGLEICALUID=@ID", conn)
            cmd.Parameters.AddWithValue("@ID", google_CalUID)
            Dim rs = cmd.ExecuteReader()

            While rs.Read()
                ev = New Evento(rs.GetValue(0), rs.GetValue(2), rs.GetValue(3), rs.GetValue(1), rs.GetValue(4), rs.GetValue(5))
            End While
            conn.close()
            Debug.WriteLine("CONEXION CERRADA cantidad de citas ocurrences " + lstOcurrences.Count.ToString)
            ev.evGoogle = ctrlGoogleCalendar.getEvento(google_CalUID)
            ev.citas = lstCitas
        Catch ex As Exception
            Debug.WriteLine("Error obteniendo evento " + ex.Message)
            Return Nothing
        End Try

        Return ev

    End Function
End Class
