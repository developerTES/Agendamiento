Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports Microsoft.VisualBasic

Public Class ControladorCita

    Dim conn = New Conexion().conn

    Public Sub New()
    End Sub

    Public Function registrarCitasEventoRecurrente(evento As Evento) As String

        Try
            Dim ctrlGoogleCalendar = New GoogleCalendarControlador("primary")
            Dim lstCitasEvento = ctrlGoogleCalendar.getCitasEvento(evento.id_GoogleCalUID)
            For Each cita In lstCitasEvento
                conn.Open()

                Dim cmd As New SqlCommand With {.Connection = conn}
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "registrarCita"
                cmd.Parameters.AddWithValue("@EID_GOOGLEICALUID", evento.id_GoogleCalUID)
                cmd.Parameters.AddWithValue("@EID_CITA", Split(cita.Id, "_")(1))
                cmd.Parameters.AddWithValue("@DATE_INICIO", cita.Start.DateTime)
                cmd.Parameters.AddWithValue("@DATE_FIN", cita.End.DateTime)
                Dim rs = cmd.ExecuteNonQuery()
                Debug.WriteLine("INICIO : " & cita.Start.DateTime)
                conn.close()
            Next
            Debug.WriteLine("Eventos registrados ")
            Return "Citas registradas en evento recurenete"
        Catch ex As Exception
            Debug.WriteLine("Error en registrarcitaseventorecurrente " & ex.Message)
            Return Nothing
        End Try

    End Function

    Friend Function obtenerCitasEvento(google_CalUID As String) As List(Of Cita)
        Try
            Dim lstCita As New List(Of Cita)
            conn.Open()
            Dim strSQL = "SELECT * FROM CITA WHERE ID_GOOGLEICALUID = @EID_GOOGLEICALUID"
            Dim cmd = New SqlCommand(strSQL, conn)
            cmd.Parameters.AddWithValue("@EID_GOOGLEICALUID", google_CalUID)

            Dim ds = cmd.ExecuteReader()
            While ds.Read()
                Dim c As New Cita(ds.GetValue(0), ds.GetValue(1), ds.GetValue(2), ds.GetValue(3))
                lstCita.Add(c)
            End While
            conn.close()
            Return lstCita
        Catch ex As Exception
            Debug.WriteLine("Error en obtener citas de evento " & ex.Message)
            Return Nothing
        End Try
    End Function
End Class
