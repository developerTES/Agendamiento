
Imports System.Diagnostics
Imports System.Globalization
Imports System.Threading
Imports System.Web.Services

Partial Class _Default
    Inherits Page

    Protected Overrides Sub InitializeCulture()
        MyBase.InitializeCulture()

        If Session("culture") IsNot Nothing Then
            Dim ci As New CultureInfo(Session("culture").ToString())
            Thread.CurrentThread.CurrentCulture = ci
            Thread.CurrentThread.CurrentUICulture = ci
        Else
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US")
            'Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US")
        End If
    End Sub


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblError.Text = Session("msg")
        lblPath.Text = Session("email")
    End Sub
    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Dim clsLogin As New FxEspeciales
        Dim bool = clsLogin.Login_AD(txtUsuario.Text, txtPassword.Text, "english.local")

        If bool Then
            Debug.WriteLine("Inicio Exitoso")
            Session("user") = txtUsuario.Text
            Session("email") = Session("user") & "@englishschool.edu.co"
            Response.Redirect("Eventos.aspx")

        Else
            Debug.WriteLine("Inicio NO Exitoso")
            Session("msg") = "Datos Inválidos"
            Response.Redirect("Default.aspx")
        End If



    End Sub


    Protected Sub btn_Click(sender As Object, e As EventArgs)


    End Sub

    <WebMethod()>
    Public Shared Function AddProductToCart(pID As String) As String

        Console.WriteLine("Error en add product ")
        'Dim selectedProduct As String = String.Format("+ {0} - {1} - {2}", pID)

        'HttpContext.Current.Session("test") += selectedProduct

        Return pID

    End Function

    <WebMethod()>
    Public Shared Function GetData(ByVal ID As String) As String
        Console.WriteLine("Hola Mundo")
        'Return ID
        Return "VALOR DESDE LA FUNCION"
    End Function




End Class