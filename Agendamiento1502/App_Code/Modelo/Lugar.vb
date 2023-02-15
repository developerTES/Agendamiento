Imports Microsoft.VisualBasic

Public Class Lugar
    Public Property id_lugar As String
    Public Property nom_lugar As String
    Public Property descr_lugar As String

    Sub New(ByVal _idlugar As String, ByVal _nomlugar As String, ByVal _descr_lugar As String)
        Me.id_lugar = _idlugar
        Me.nom_lugar = _nomlugar
        Me.descr_lugar = _descr_lugar
    End Sub
End Class
