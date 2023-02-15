
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Net.Mail
Imports System.IO
Imports System.DirectoryServices
Imports System.Net
Imports System.Net.Mime
Imports System.Web.Configuration
Imports System.Diagnostics

Public Class FxEspeciales
    Public cnConexion As New SqlConnection

    Public objetoDML As New Object


    Public Function Login_AD(ByVal username As String, ByVal password As String, ByVal nomDominio As String) As Boolean
        'Funcion para el Login por active directory
        Dim Flag As Boolean = False
        Dim Entrada As New System.DirectoryServices.DirectoryEntry("LDAP://" & nomDominio, username, password)
        Dim Buscador As New System.DirectoryServices.DirectorySearcher(Entrada)
        Buscador.SearchScope = DirectoryServices.SearchScope.OneLevel
        Try
            Dim Resultado As System.DirectoryServices.SearchResult = Buscador.FindOne
            Flag = Not (Resultado Is Nothing)
        Catch ex As Exception
            Debug.WriteLine("Error en auth " & ex.Message)
            Flag = False
        End Try
        Return Flag
    End Function


End Class