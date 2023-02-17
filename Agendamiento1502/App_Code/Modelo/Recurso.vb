Imports Microsoft.VisualBasic

Public Class Recurso

    'Valores de la Base de datos
    Public Property nom_Recurso As String
    Public Property desc_recurso As String

    Public Property id_recurso As String

    'Valor virtual en el momento de construir el recurso pedido desde el front end (Ej "2 BEBIDAS con AZUCAR "    [CANT][RECURSO][DETALLES])
    Public Property detalles_recurso As String

    Sub New(ByVal id_recurso As String, ByVal nom_recurso As String, ByVal descr_recurso As String)
        Me.nom_Recurso = nom_recurso
        Me.desc_recurso = descr_recurso
        Me.id_recurso = id_recurso
    End Sub

    Public Sub setDetallesRecurso(v As String)
        Me.detalles_recurso = v
    End Sub
End Class
