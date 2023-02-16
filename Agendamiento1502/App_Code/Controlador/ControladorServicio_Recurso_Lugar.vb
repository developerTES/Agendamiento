Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports Microsoft.VisualBasic

Public Class ControladorServicio_Recurso_Lugar
    Dim conn = New Conexion().conn

    Sub New()

    End Sub
    Public Function registrarNuevoServicio(servicio As String, email As String) As String
        Try
            conn.Open()
            Dim idServicio As String = Regex.Replace(servicio, "[^A-Za-z0-9\-/]", "")
            Dim cmd As New SqlCommand With {.Connection = conn}
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "registrarServicio"
            cmd.Parameters.AddWithValue("@EID_SERVICIO", idServicio)
            cmd.Parameters.AddWithValue("@ENOM_SERVICIO", servicio)
            cmd.Parameters.AddWithValue("@EEMAIL_SERVICIO", email)
            Dim rs = cmd.ExecuteNonQuery()
            Debug.WriteLine("Filas afectadas " & rs)
            If rs > 0 Then
                Return "Servicio agregado"
            Else
                Return Nothing
            End If
            conn.close()
        Catch ex As Exception
            Debug.WriteLine("Error en nuevo servicio " & ex.Message)

            Return "Error en nuevo servicio " & ex.Message
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

    Public Function obtenerServicios() As List(Of Servicio)
        Dim lstServicios As New List(Of Servicio)
        Try
            conn.Open()
            Dim strSQL = "SELECT * FROM SERVICIO"
            Dim cmd = New SqlCommand(strSQL, conn)
            Dim datareader = cmd.ExecuteReader()
            While datareader.Read()
                'Debug.WriteLine(datareader.GetInt32(0) & datareader.GetString(1) & datareader.GetString(2))
                Dim serv = New Servicio(datareader.GetString(0), datareader.GetString(1), datareader.GetString(2))
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

End Class
