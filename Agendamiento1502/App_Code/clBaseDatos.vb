Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.Common


Public Class clBaseDatos
    'Public Shared strServidor As String = "SRV-W2K19-TEST"
    Public Shared strServidor As String = "172.16.3.54"

    Public Function fxAbrir_Conexion_Transportes() As SqlConnection
        Dim strConexion As String = "Persist Security Info=False;Integrated Security=SSPI;database=Transportes;server=" & strServidor & ";connect timeout=30"
        Dim cnConexion As New SqlConnection(strConexion)
        cnConexion.Open()
        Return cnConexion
    End Function
    Public Function fxAbrir_Conexion_Presupuesto() As SqlConnection
        Dim strConexion As String = "Persist Security Info=False;Integrated Security=SSPI;database=Presupuesto;server=" & strServidor & ";connect timeout=30"
        'Dim strConexion As String = "Persist Security Info=False;Integrated Security=SSPI;database=Presupuesto;server=" & strServidor & ";connect timeout=5"
        'Dim strConexion As String = "Server=" & strServidor & ";Database=Presupuesto;User Id=UsuarioSQL;Password=usuariosql"
        Dim cnConexion As New SqlConnection(strConexion)
        cnConexion.Open()
        Return cnConexion
    End Function
    Public Function fxAbrir_Conexion_Fotos() As SqlConnection
        Dim strConexion As String = "Persist Security Info=False;Integrated Security=SSPI;database=FotosTES;server=" & strServidor & ";connect timeout=30"
        Dim cnConexion As New SqlConnection(strConexion)
        cnConexion.Open()
        Return cnConexion
    End Function
    Public Function fxAbrir_Conexion_Novasoft() As SqlConnection
        Dim strConexion As String = "Persist Security Info=False;Integrated Security=SSPI;database=Novasoft;server=" & strServidor & ";connect timeout=30"
        Dim cnConexion As New SqlConnection(strConexion)
        cnConexion.Open()
        Return cnConexion
    End Function
    Public Function fxAbrir_Conexion_Llarmis() As SqlConnection
        Dim strConexion As String = "Persist Security Info=False;Integrated Security=SSPI;database=Llarmis;server=" & strServidor & ";connect timeout=30"
        Dim cnConexion As New SqlConnection(strConexion)
        cnConexion.Open()
        Return cnConexion
    End Function
    Public Function fxAbrir_Conexion_Matriculartes() As SqlConnection
        Dim strConexion As String = "Persist Security Info=False;Integrated Security=SSPI;database=MatricularTES;server=" & strServidor & ";connect timeout=30"
        Dim cnConexion As New SqlConnection(strConexion)
        cnConexion.Open()
        Return cnConexion
    End Function
    Public Function fxAbrir_Conexion_Reportes() As SqlConnection
        Dim strConexion As String = "Persist Security Info=False;Integrated Security=SSPI;database=ReporTES;server=" & strServidor & ";connect timeout=30"
        Dim cnConexion As New SqlConnection(strConexion)
        cnConexion.Open()
        Return cnConexion
    End Function
    Public Function fxAbrir_Conexion_Extracurriculares() As SqlConnection
        Dim strConexion As String = "Persist Security Info=False;Integrated Security=SSPI;database=ExtracurricularTES;server=" & strServidor & ";connect timeout=30"
        Dim cnConexion As New SqlConnection(strConexion)
        cnConexion.Open()
        Return cnConexion
    End Function

    Public Function fxAbrir_Conexion_Deportes() As SqlConnection
        Dim strConexion As String = "Persist Security Info=False;Integrated Security=SSPI;database=DeporTES;server=" & strServidor & ";connect timeout=30"
        Dim cnConexion As New SqlConnection(strConexion)
        cnConexion.Open()
        Return cnConexion
    End Function
    Public Sub proCerrar_Conexion(ByVal Conexion_Abierta As SqlConnection)
        Conexion_Abierta.Close()
    End Sub
    Public Function fxCargar_Lector(ByVal strSQL As String, ByVal cnConexion As SqlConnection) As SqlDataReader
        Dim objLector As SqlDataReader : Dim cmComando As New SqlCommand(strSQL, cnConexion)
        objLector = cmComando.ExecuteReader
        Return objLector
    End Function

    Public Function fxCargar_Lector(ByVal strSQL As String, ByVal sqlParametros As SqlParameter(), ByVal cnConexion As SqlConnection) As SqlDataReader
        Dim objLector As SqlDataReader
        Dim cmComando As New SqlCommand(strSQL, cnConexion)
        If Not sqlParametros Is Nothing Then
            For Each p In sqlParametros
                cmComando.Parameters.AddWithValue(p.ParameterName, p.Value)
            Next
        End If
        objLector = cmComando.ExecuteReader
        Return objLector
    End Function

    Public Function fxEjecutar_DML(ByVal strSQL As String, ByVal cnConexion As SqlConnection, Optional sqlParametros As SqlParameter() = Nothing) As Boolean
        Dim objLector As SqlDataReader
        Try
            Dim cmComando As New SqlCommand(strSQL, cnConexion)
            If Not sqlParametros Is Nothing Then
                For Each p In sqlParametros
                    cmComando.Parameters.AddWithValue(p.ParameterName, p.Value)
                Next
            End If
            objLector = cmComando.ExecuteReader
            Return True
        Catch ex As Exception
            'Throw ex
            Return False
        End Try
    End Function
    Public Function FxCargarConsulta(ByVal strSQL As String,
     ByVal cnConexion As Object,
     ByVal TipoSalida As Boolean) As Object
        Dim vecRespuesta(2) As Object
        Try
            vecRespuesta(0) = True
            Select Case TipoSalida
                Case True 'Devuelve un Datareader
                    Dim objLector As SqlDataReader
                    Dim cmComando As New SqlCommand(strSQL, DirectCast(cnConexion, SqlConnection))
                    objLector = cmComando.ExecuteReader
                    vecRespuesta(1) = objLector
                    If objLector.HasRows = False Then
                        vecRespuesta(0) = False
                        vecRespuesta(1) = "NoData"
                    End If
                Case False 'Devuelve Una Tabla
                    Dim daRetorno As New SqlDataAdapter(strSQL, DirectCast(cnConexion, SqlConnection))
                    Dim dtRetorno As New DataTable
                    daRetorno.Fill(dtRetorno)
                    vecRespuesta(1) = dtRetorno
            End Select
        Catch ex As Exception
            vecRespuesta(0) = False
            vecRespuesta(1) = Replace(ex.Message, "'", " ")
            vecRespuesta(1) = Replace(vecRespuesta(1), Chr(13), " ")
            vecRespuesta(1) = Replace(vecRespuesta(1), Chr(10), " ")
            vecRespuesta(2) = ex.InnerException
        End Try
        Return vecRespuesta
    End Function
    Public Function fx_Ejecutar_DML(ByVal strSQL As String, ByVal cnConexion As SqlConnection) As Array
        Dim objLector As SqlDataReader
        Dim vecRespuesta(2) As String
        Try
            Dim cmComando As New SqlCommand(strSQL, cnConexion)
            objLector = cmComando.ExecuteReader
            vecRespuesta(0) = "True"
            vecRespuesta(1) = ""
        Catch ex As Exception
            vecRespuesta(0) = "False"
            vecRespuesta(1) = ex.Message
        End Try
        Return vecRespuesta
    End Function
    Public Function fxConocer_UltimoID(ByVal strSQL As String, ByVal cnConexion As SqlConnection) As Integer
        'Recordar escribir el alias Ultimo en la instruccion sql para determinar a que columna se sacara el ultimo
        Dim objLector As SqlDataReader : Dim cmComando As New SqlCommand(strSQL, cnConexion)
        objLector = cmComando.ExecuteReader
        Try
            objLector.Read()
            Dim intUltimo As Integer = objLector("Ultimo")
            Return intUltimo
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Function fxConocer_ID(ByVal strSQL As String, ByVal cnConexion As SqlConnection) As Integer
        'Recordar escribir el alias Ultimo en la instruccion sql para determinar a que columna se sacara el ultimo
        Dim objLector As SqlDataReader : Dim cmComando As New SqlCommand(strSQL, cnConexion)
        objLector = cmComando.ExecuteReader
        objLector.Read()
        Dim intId As Integer = objLector("ID")
        Return intId
    End Function
    'Funciones JC
    Public Shared Function fxAbrir_Conexion_Budget() As SqlConnection
        Dim strConexion As String = "Persist Security Info=False;Integrated Security=SSPI;database=Presupuesto;server=" & strServidor & ";connect timeout=30" 'HOGARES\HOGAR   172.16.2.52\SQLEXPRESS
        Dim cnConexion As New SqlConnection(strConexion)
        cnConexion.Open()
        Return cnConexion
    End Function
    ''' <summary>
    ''' Funcion que Retorna el resultado de una consulta contenida en un Stored Procedure
    ''' </summary>
    ''' <param name="strProcedimiento">Nombre del Procedimiento Almacenado a Consultar</param>
    ''' <param name="strValores">Valores según la consulta</param>
    ''' <param name="Conexion">Conexion a traves de la cual se realizara la consulta</param>
    ''' <returns>Retorna un Lector con los Resultados de la Consulta.</returns>
    ''' <remarks></remarks>
    Public Function FxCargarLector_SP(ByVal strProcedimiento As String, ByVal strValores As Dictionary(Of String, Object), ByVal Conexion As SqlConnection) As SqlDataReader
        Dim objLector As SqlDataReader
        Dim cmdComando As SqlCommand = New SqlCommand(strProcedimiento, Conexion)
        cmdComando.CommandText = strProcedimiento
        cmdComando.CommandType = CommandType.StoredProcedure
        For Each valor As KeyValuePair(Of String, Object) In strValores
            Dim parametros As DbParameter = cmdComando.CreateParameter()
            parametros.ParameterName = valor.Key
            parametros.Value = valor.Value
            cmdComando.Parameters.Add(parametros)
        Next
        Try
            objLector = cmdComando.ExecuteReader
            Return objLector
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
