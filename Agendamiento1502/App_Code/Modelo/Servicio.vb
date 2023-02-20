Imports Microsoft.VisualBasic

Public Class Servicio

    Public Property id_Servicio As String
    Public Property nom_servicio As String
    Public Property email_responsable As List(Of String)
    Public Property recursos As List(Of Recurso)


    Sub New(ByVal _id As String, ByVal nom_servicio As String, ByVal _emails As List(Of String), _recursos As List(Of Recurso))
        Me.id_Servicio = _id
        Me.nom_servicio = nom_servicio
        Me.email_responsable = _emails
        Me.recursos = _recursos

    End Sub

    Sub New()
        Me.recursos = New List(Of Recurso)
    End Sub

    Sub New(ByVal _id As String, ByVal nom_servicio As String)
        Me.id_Servicio = _id
        Me.nom_servicio = nom_servicio



    End Sub

    Function ObtenerDetalle() As String
        Dim detalle = ""
        For Each r In recursos
            detalle += r.nom_Recurso & ": " & r.detalles_recurso & ". "
        Next
        Return detalle
    End Function
End Class
