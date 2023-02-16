Imports Microsoft.VisualBasic

Public Class Servicio

    Public Property id_Servicio As String
    Public Property nom_servicio As String
    Public Property email_responsable As String
    Public Property recursos As List(Of Recurso)


    Sub New(ByVal _id As String, ByVal nom_servicio As String, ByVal _email As String, _recursos As List(Of Recurso))
        Me.id_servicio = _id
        Me.nom_servicio = nom_servicio
        Me.email_responsable = _email
        Me.recursos = _recursos

    End Sub

    Sub New(ByVal _id As String, ByVal nom_servicio As String, ByVal _email As String)
        Me.id_Servicio = _id
        Me.nom_servicio = nom_servicio
        Me.email_responsable = _email


    End Sub



End Class
