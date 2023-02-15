Imports Google.Apis.Calendar.v3.Data
Imports Microsoft.VisualBasic

Public Class EventoGoogleCalendar

    Public Property strName As String
    Public Property strDescription As String
    Public Property datetimeInicio As DateTime
    Public Property datetimeFin As DateTime
    Public Property lstInvitados As List(Of EventAttendee)
    Public Property lstRecurrenceRules As List(Of String)

    Public Sub New(_strName As String, _strDescription As String, _datetimeInicio As DateTime, _datetimeFin As DateTime, _invitados As List(Of EventAttendee))
        Me.strName = _strName
        Me.strDescription = _strDescription
        Me.datetimeInicio = _datetimeInicio
        Me.datetimeFin = _datetimeFin
        Me.lstInvitados = _invitados

    End Sub

    Public Sub New(_strName As String, _strDescription As String, _invitados As List(Of EventAttendee), _recurrencerules As List(Of String))
        Me.strName = _strName
        Me.strDescription = _strDescription

        Me.lstInvitados = _invitados
        Me.lstRecurrenceRules = _recurrencerules
    End Sub


End Class
