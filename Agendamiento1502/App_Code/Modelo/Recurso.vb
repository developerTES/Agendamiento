Imports Microsoft.VisualBasic

Public Class Recurso

    Public Property nom_Recurso As String
    Public Property desc_recurso As String

    Sub New(ByVal nom_recurso As String, ByVal descr_recurso As String)
        Me.nom_Recurso = nom_recurso
        Me.desc_recurso = descr_recurso
    End Sub


End Class
