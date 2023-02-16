
Imports System.Diagnostics
Imports System.Globalization
Imports System.Threading

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
End Class