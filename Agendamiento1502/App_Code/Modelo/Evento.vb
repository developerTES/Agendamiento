Imports Microsoft.VisualBasic

Public Class Evento

    Public Property id_lugar As String
    Public Property id_GoogleCalUID As String
    Public Property nom_Evento As String
    Public Property strTipoEvento As String
    Public Property strRecurrencia As String
    Public Property email_organizador As String

    Sub New(ByVal id_GoogleCalUID As String, ByVal email_organizador As String, ByVal nom_evento As String, ByVal id_lugar As String, ByVal strTipoEvento As String, ByVal strRecurrencia As String)
        Me.id_lugar = id_lugar
        Me.id_GoogleCalUID = id_GoogleCalUID
        If email_organizador IsNot Nothing Then
            Me.email_organizador = email_organizador
        Else
            Me.email_organizador = "correofalsosinautenticacion@gmail.com"
        End If

        Me.nom_Evento = nom_evento
        Me.strTipoEvento = strTipoEvento
        Me.strRecurrencia = strRecurrencia
    End Sub
End Class
