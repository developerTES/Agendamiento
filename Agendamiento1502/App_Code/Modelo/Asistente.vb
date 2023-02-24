Imports Microsoft.VisualBasic

Public Class Asistente

    Public Property nom_asistente As String
    Public Property email_asistente As String

    Sub New(ByVal _email As String)
        Me.email_asistente = _email
    End Sub

    Sub New(ByVal _nom As String, ByVal _email As String)
        Me.nom_asistente = _nom
        Me.email_asistente = _email
    End Sub

End Class
