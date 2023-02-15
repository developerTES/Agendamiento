Imports Microsoft.VisualBasic

Public Class Cita

    Public Property id_GoogleICalUID As String
    Public Property id_cita As String
    Public Property date_inicio As DateTime
    Public Property date_fin As DateTime

    Sub New(ByVal _id_GoogleICalUID As String, ByVal _id_cita As String, ByVal _date_inicio As DateTime, ByVal _date_fin As DateTime)
        Me.id_GoogleICalUID = _id_GoogleICalUID
        Me.id_cita = _id_cita
        Me.date_inicio = _date_inicio
        Me.date_fin = _date_fin
    End Sub

End Class
