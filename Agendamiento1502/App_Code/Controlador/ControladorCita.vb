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
End Class
