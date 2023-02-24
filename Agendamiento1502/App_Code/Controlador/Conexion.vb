Imports System.Data.SqlClient
Imports System.Diagnostics
Imports Microsoft.VisualBasic

Public Class Conexion


    Public Property conn As SqlConnection



    Sub New()
        Try
            Me.conn = New SqlConnection("Server=ESCARABAJO\DEVELOPER;Database=Reserva;User Id=sa;Password=Developer23")
            Debug.WriteLine("Conectado")
        Catch ex As Exception
            Debug.WriteLine("No hay conexion " & ex.Message)
        End Try

    End Sub



End Class


