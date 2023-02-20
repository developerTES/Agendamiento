Imports Microsoft.VisualBasic
Imports Google.Apis.Calendar.v3

Public Class Evento

    Public Property id_lugar As String
    Public Property id_GoogleCalUID As String
    Public Property nom_Evento As String
    Public Property strTipoEvento As String
    Public Property strRecurrencia As String
    Public Property email_organizador As String
    Public Property citas As List(Of Cita)
    Public Property evGoogle As Data.Event

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

    Sub New(ByVal id_GoogleCalUID As String, ByVal email_organizador As String, ByVal nom_evento As String, ByVal id_lugar As String, ByVal strTipoEvento As String, ByVal strRecurrencia As String, ByVal citas As List(Of Cita), ByVal evGoogle As Data.Event)
        Me.New(id_GoogleCalUID, email_organizador, nom_evento, id_lugar, strTipoEvento, strRecurrencia, citas)
        Me.evGoogle = evGoogle
    End Sub

    Sub New(ByVal id_GoogleCalUID As String, ByVal email_organizador As String, ByVal nom_evento As String, ByVal id_lugar As String, ByVal strTipoEvento As String, ByVal strRecurrencia As String, ByVal citas As List(Of Cita))
        Me.New(id_GoogleCalUID, email_organizador, nom_evento, id_lugar, strTipoEvento, strRecurrencia)
        Me.citas = citas
    End Sub

    Sub New()

    End Sub

End Class
