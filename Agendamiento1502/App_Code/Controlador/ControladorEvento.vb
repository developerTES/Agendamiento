Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports Google.Apis.Calendar.v3.Data
Imports Microsoft.VisualBasic

Public Class ControladorEvento

    Dim conn = New Conexion().conn


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

    Public Function ListarEventos()
        Try
            conn.Open()
            Dim cmd As New SqlCommand With {.Connection = conn}
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "listarEventos"
            Dim rs = cmd.ExecuteReader()
            For Each row In rs
                Debug.WriteLine(row(0))
                Debug.WriteLine(row(1))
            Next

            Debug.WriteLine("Exito")
        Catch ex As Exception
            Debug.WriteLine("Error " & ex.Message)
        End Try
    End Function

    Public Function ListarEventosEmailTipo(ByVal email As String, ByVal tipo As String) As List(Of Evento)
        Try
            conn.Open()
            Debug.WriteLine("Dentro de liostar eventos")
            conn.close()


        Catch ex As Exception
            Debug.WriteLine("ERROR EN LISTAR EVENTOS " & ex.Message)

        End Try
    End Function



End Class
