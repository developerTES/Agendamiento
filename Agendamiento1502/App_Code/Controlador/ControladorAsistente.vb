Imports System.Data.SqlClient
Imports System.Diagnostics
Imports Microsoft.VisualBasic

Public Class ControladorAsistente
    Public Function getEmailsPersonalTES() As Object
        Try
            Dim asis As New List(Of Asistente)
            Dim clBD As New clBaseDatos()
            Dim conn = clBD.fxAbrir_Conexion_Novasoft
            conn.Open()
            Dim strSQL = "SELECT e_mail, (ap1_emp  + ' '+ ap2_emp+ ' '+nom_emp + ' <'+e_mail +'>') AS INFO FROM rhh_emplea  where est_lab in ('01','02','04') order by ap1_emp,ap2_emp"
            Dim cmd = New SqlCommand(strSQL, conn)



            Dim datareader = cmd.ExecuteReader()

            While datareader.Read()
                asis.Add(New Asistente(datareader.GetValue(0), datareader.GetValue(1)))
            End While
            conn.Close()
            Return asis
        Catch ex As Exception
            Debug.WriteLine("Error obteniendo emails " + ex.Message)
            Return Nothing
        End Try
    End Function
End Class
