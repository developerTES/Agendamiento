Imports Microsoft.VisualBasic

Public Class clMensajes

    Public Function Mensajes(ByVal strMensaje As String) As String
        Dim sScript As String
        sScript = Replace(strMensaje, "'", " ")
        sScript = Replace(sScript, Chr(13), " ")
        sScript = Replace(sScript, Chr(10), " ")
        sScript = "<script>javascript:alert(' " & sScript & "');</script>"
        Return sScript
    End Function
    Public Function Fx_Limpiar_Mensaje_Excepcion(strMensaje As String) As String

        strMensaje = Replace(strMensaje, "'", " ")
        strMensaje = Replace(strMensaje, Chr(13), " ")
        strMensaje = Replace(strMensaje, Chr(10), " ")

        Return strMensaje
    End Function
    Public Function Fx_AbrirVentana(ByVal strNomPagWeb As String, ByVal strParametro As String, ByVal strAncho As String, ByVal strLargo As String, ByVal strX As String, ByVal strY As String) As String
        Dim strScript As String
        strScript = "<script language=javascript> {window.open('" & strNomPagWeb & "?id=" & strParametro & "', '_blank','width=" & strAncho & " height=" & strLargo & " left=" & strX & " top=" & strY & ",resizable=no,location=no')}</script>"
        Return strScript
    End Function
    Public Function Fx_CerrarVentana() As String
        Dim strScript As String
        strScript = "<script language=javascript type=text/javascript> { var ventana = window.self; ventana.opener = window.self; ventana.close(); parent.close(); }</script>"
        Return (strScript)
    End Function

End Class