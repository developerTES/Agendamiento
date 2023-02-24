Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports Microsoft.VisualBasic

Public Class ControladorServicio_Recurso_Lugar
    Dim conn = New Conexion().conn

    Sub New()

    End Sub
    Public Function registrarNuevoServicio(servicio As String, emails As List(Of String)) As String
        Try
            conn.Open()
            Dim idServicio As String = Regex.Replace(servicio, "[^A-Za-z0-9\-/]", "")
            Dim cmd As New SqlCommand With {.Connection = conn}
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "registrarServicio"
            cmd.Parameters.AddWithValue("@EID_SERVICIO", idServicio)
            cmd.Parameters.AddWithValue("@ENOM_SERVICIO", servicio)
            'cmd.Parameters.AddWithValue("@EEMAIL_SERVICIO", email)
            Dim rs = cmd.ExecuteNonQuery()
            Debug.WriteLine("Filas afectadas " & rs)
            conn.close()
            Dim msg = registrarIntegrantes(idServicio, emails)

            Return msg
        Catch ex As Exception
            Debug.WriteLine("Error en nuevo servicio " & ex.Message)

            Return "Error en nuevo servicio " & ex.Message
        End Try
    End Function

    Private Function registrarIntegrantes(idServicio As String, emails As List(Of String)) As String
        Try
            conn.Open()

            For Each email In emails
                Dim strSQL = "INSERT INTO INTEGRANTE VALUES (@EID_SERVICIO, @EID_INTEGRANTE)"
                Dim cmd = New SqlCommand(strSQL, conn)
                cmd.Parameters.AddWithValue("@EID_SERVICIO", idServicio)
                cmd.Parameters.AddWithValue("@EID_INTEGRANTE", email)
                cmd.ExecuteNonQuery()

            Next


            conn.close()
            Return "Integrantes y servicio agregados !!"
        Catch ex As Exception
            Return "Error en registrarIntegrantes: " & ex.Message
        End Try
    End Function

    Public Function registrarNuevoRecurso(id_servicio As String, recurso As String, descripcion As Object) As String
        Try
            conn.Open()
            Dim cmd As New SqlCommand With {.Connection = conn}
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "registrarRecurso"
            cmd.Parameters.AddWithValue("@EID_SERVICIO", id_servicio)
            cmd.Parameters.AddWithValue("@ENOM_RECURSO", recurso)
            cmd.Parameters.AddWithValue("@EDESCR_RECURSO", descripcion)
            Dim rs = cmd.ExecuteNonQuery()
            Debug.WriteLine("Filas afectadas " & rs)
            If rs > 0 Then
                Return "Recurso agregado"
            Else
                Return Nothing
            End If
            conn.close()
        Catch ex As Exception
            Debug.WriteLine("Error en nuevo recurso " & ex.Message)
            Return "Error en nuevo Recurso " & ex.Message
        End Try
    End Function

    Public Function obtenerRecursos(id_servicio As String) As List(Of Recurso)

        Dim recursos As New List(Of Recurso)
        Debug.WriteLine("Obteniendo recursos de " & id_servicio)
        Try
            conn.Open()
            Dim strSQL = "SELECT ID_RECURSO as 'ID Recurso', NOM_RECURSO as 'Nombre Recurso', DESCR_RECURSO as 'Descripción' FROM RECURSO WHERE ID_SERVICIO  = @EID_SERVICIO"
            Dim cmd = New SqlCommand(strSQL, conn)
            cmd.Parameters.AddWithValue("@EID_SERVICIO", id_servicio)
            Dim datareader = cmd.ExecuteReader()
            While datareader.Read()
                Dim recurso As New Recurso(datareader.GetValue(0), datareader.GetValue(1), datareader.GetValue(2))
                recursos.Add(recurso)

            End While
            conn.close()
            Return recursos


        Catch ex As Exception
            Debug.WriteLine("Error en obtener recursos " + ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function obtenerLugares() As List(Of Lugar)
        Dim lugares As New List(Of Lugar)
        Try
            conn.Open()
            Dim strSQL = "SELECT *  FROM LUGAR"
            Dim cmd = New SqlCommand(strSQL, conn)

            Dim datareader = cmd.ExecuteReader()
            While datareader.Read()
                Dim lugar As New Lugar(datareader.GetValue(0), datareader.GetValue(1), datareader.GetValue(2))
                lugares.Add(lugar)

            End While
            conn.close()
            Return lugares


        Catch ex As Exception
            Debug.WriteLine("Error en obtener Lugares " + ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function registrarRecursosRequeridos(ev As Evento, serviciosRequeridos As List(Of Servicio)) As String
        Try
            conn.Open()
            For Each s In serviciosRequeridos
                If s.ObtenerDetalle IsNot Nothing Then
                    Dim strSQL = "INSERT INTO EVENTO_SERVICIO VALUES (@EID_SERVICIO, @EID_EVENTO, @DESCR_SERVICIO)"
                    Dim cmd = New SqlCommand(strSQL, conn)
                    cmd.Parameters.AddWithValue("@EID_SERVICIO", s.id_Servicio)
                    cmd.Parameters.AddWithValue("@EID_EVENTO", ev.id_GoogleCalUID)
                    cmd.Parameters.AddWithValue("@DESCR_SERVICIO", s.ObtenerDetalle())
                    cmd.ExecuteNonQuery()
                End If


            Next
            conn.close()
            Debug.WriteLine("Evento y recursos requeridos registrados exitosamente")
            Return "Evento y recursos requeridos registrados exitosamente"
        Catch ex As Exception
            Debug.WriteLine("Error en registrar recursos requeridos " + ex.Message)
            Return "Error en registrar recursos requeridos " + ex.Message
        End Try
    End Function

    Public Function registrarNuevoLugar(ByVal _lugar As Lugar) As String
        Try
            conn.Open()
            Dim strSQL = "INSERT INTO LUGAR VALUES (@ENOM, @EDESCR)"
            Dim cmd = New SqlCommand(strSQL, conn)
            cmd.Parameters.AddWithValue("@ENOM", _lugar.nom_lugar)
            cmd.Parameters.AddWithValue("@EDESCR", _lugar.descr_lugar)
            Dim rs = cmd.ExecuteNonQuery()
            Debug.WriteLine("Filas afectadas " & rs)
            conn.close()
            If rs > 0 Then
                Return "Nuevo Lugar Agregado!! "
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Return "Error en registrar Nuevo Lugar " & ex.Message
            conn.close()
        End Try
    End Function

    Public Function editarLugar(_lugar As Lugar) As Object
        Try
            conn.Open()
            Dim strSQL = "UPDATE LUGAR SET NOM_LUGAR = @ENOM, DESCR_LUGAR = @EDESCR WHERE ID_LUGAR = @EID ;"
            Dim cmd = New SqlCommand(strSQL, conn)
            cmd.Parameters.AddWithValue("@ENOM", _lugar.nom_lugar)
            cmd.Parameters.AddWithValue("@EDESCR", _lugar.descr_lugar)
            cmd.Parameters.AddWithValue("@EID", _lugar.id_lugar)
            Debug.WriteLine("ID EN EDITAR LUGAR ES ............." & _lugar.id_lugar)
            Dim rs = cmd.ExecuteNonQuery()

            conn.close()
            Return "Lugar Editado !! " & rs & ". "

        Catch ex As Exception
            conn.close()
            Return "Error en editar Lugar" & ex.Message

        End Try
    End Function

    Public Function ConstruirDetalleRecursos(serviciosRequeridos As List(Of Servicio)) As String
        Dim strDetalles = "<br><br><br><br><hr> SE REQUIEREN LOS SERVICIOS. "
        For Each serv In serviciosRequeridos
            strDetalles += "Servicio <strong> " & serv.nom_servicio & " </strong> <br>"
            For Each rec In serv.recursos
                strDetalles += rec.nom_Recurso & ": " + rec.detalles_recurso + "<br>"
            Next
            strDetalles += "<hr>"
        Next
        Return strDetalles
    End Function

    Public Function obtenerEmailsServicio(idServ As String) As List(Of String)
        Dim lstEmails As New List(Of String)
        Try
            conn.Open()
            Dim strSQL = "SELECT * FROM INTEGRANTE WHERE ID_SERVICIO = @E_IDSERVICIO "
            Dim cmd = New SqlCommand(strSQL, conn)
            cmd.Parameters.AddWithValue("@E_IDSERVICIO", idServ)
            Dim datareader = cmd.ExecuteReader()
            While datareader.Read()
                lstEmails.Add(datareader.GetString(1))
            End While
            conn.close()

            Return lstEmails

        Catch ex As Exception
            Debug.WriteLine("ERROR EN OBTENER EMAILS X SERVICIO " & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function obtenerServicios() As List(Of Servicio)
        Dim lstServicios As New List(Of Servicio)
        Try
            conn.Open()
            Dim strSQL = "SELECT * FROM SERVICIO"
            Dim cmd = New SqlCommand(strSQL, conn)
            Dim datareader = cmd.ExecuteReader()
            While datareader.Read()
                'Debug.WriteLine(datareader.GetInt32(0) & datareader.GetString(1) & datareader.GetString(2))
                Dim serv = New Servicio(datareader.GetString(0), datareader.GetString(1))
                lstServicios.Add(serv)

            End While
            conn.close()
            For Each s In lstServicios
                s.recursos = Me.obtenerRecursos(s.id_Servicio)
            Next
            Return lstServicios

        Catch ex As Exception
            Debug.WriteLine("ERROR EN OBTENER servicios " & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function obtenerRecurso(idServ As String, idRec As String) As Recurso
        Try
            conn.Open()
            Dim strSQL = "SELECT * FROM RECURSO WHERE ID_SERVICIO =@EID_SERVICIO AND ID_RECURSO =@EID_RECURSO"
            Dim cmd = New SqlCommand(strSQL, conn)
            cmd.Parameters.AddWithValue("@EID_SERVICIO", idServ)
            cmd.Parameters.AddWithValue("@EID_RECURSO", idRec)
            Dim datareader = cmd.ExecuteReader()
            Dim bool = datareader.Read()
            If bool Then
                Dim r As New Recurso(datareader.GetValue(1), datareader.GetValue(2), datareader.GetValue(3))
                conn.close()
                Return r
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Debug.WriteLine("ERROR EN OBTENER single recurso " & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function obtenerServicio(ByVal idServ As String) As Servicio

        Try
            conn.Open()
            Dim strSQL = "SELECT * FROM SERVICIO WHERE ID_SERVICIO =@EID_SERVICIO"
            Dim cmd = New SqlCommand(strSQL, conn)
            cmd.Parameters.AddWithValue("@EID_SERVICIO", idServ)
            Dim datareader = cmd.ExecuteReader()
            Dim bool = datareader.Read()

            If bool Then
                Dim S As New Servicio(datareader.GetValue(0), datareader.GetValue(1))
                conn.close()
                S.email_responsable = Me.obtenerEmailsServicio(idServ)

                Return S
            Else
                conn.close()
                Return Nothing
            End If

        Catch ex As Exception
            Debug.WriteLine("ERROR EN OBTENER single servicio " & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function obtenerLugar(ByVal _id As String) As Lugar
        Try
            conn.Open()
            Dim strSQL = "SELECT * FROM LUGAR WHERE ID_LUGAR  = @ID"
            Dim cmd = New SqlCommand(strSQL, conn)

            cmd.Parameters.AddWithValue("@ID", _id)

            Dim datareader = cmd.ExecuteReader()
            Dim bool = datareader.Read()
            If bool Then
                Dim lugar As New Lugar(datareader.GetValue(0), datareader.GetValue(1), datareader.GetValue(2))
                conn.close()
                Return lugar
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Debug.WriteLine("ERROR EN OBTENER LUGAR " & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function VerificarDisponibilidadLugar(strLugarID As String, datetimeinicio As Date, datetimeFin As Date) As String
        Try
            Dim lugar = Me.obtenerLugar(strLugarID)
            conn.Open()
            Dim cmd As New SqlCommand With {.Connection = conn}
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "verificarDisponibilidadLugar"
            cmd.Parameters.AddWithValue("@EID_LUGAR", strLugarID)
            cmd.Parameters.AddWithValue("@EDATE_INICIO", datetimeinicio)
            cmd.Parameters.AddWithValue("@EDATE_FIN", datetimeFin)
            'cmd.Parameters.AddWithValue("@EEMAIL_SERVICIO", email)


            Dim datareader = cmd.ExecuteReader()
            Dim bool = datareader.Read()
            If bool Then
                Dim citas As New List(Of Cita)
                Dim cita As New Cita(datareader.GetValue(0), datareader.GetValue(7), datareader.GetValue(8), datareader.GetValue(9))
                citas.Add(cita)
                Dim ev As New Evento(datareader.GetValue(0), datareader.GetValue(2), datareader.GetValue(3), datareader.GetValue(1), datareader.GetValue(4), datareader.GetValue(5), citas)

                Return "Hay un evento agendado actualmente en " & lugar.nom_lugar & " !  \n \n Nombre: " & ev.nom_Evento & " \n Organizado por: " & ev.email_organizador & " \n " & " Fecha: " & ev.citas(0).date_inicio & " - " & ev.citas(0).date_fin
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Debug.WriteLine("ERROR EN OBTENER LUGAR " & ex.Message)
            Return "ERROR verificar disponibilidad " & ex.Message
        End Try
    End Function

    Public Function comprobarInvitados(items As ListItemCollection, dateInicio As Date, dateFin As Date) As List(Of Asistente)
        Try
            Dim lstAsisAgendados As New List(Of Asistente)
            conn.Open()
        Catch ex As Exception
            Debug.WriteLine("Error comprobando invitados" + ex.Message)
            Return Nothing
        End Try
    End Function
End Class
