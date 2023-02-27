
Imports System.Data
Imports System.Diagnostics

Partial Class Administrador
    Inherits System.Web.UI.Page

    Dim ctrlServRecursoLugar As New ControladorServicio_Recurso_Lugar()
    Dim msg As New clMensajes

    Protected Sub registrarNuevoServicio()
        Debug.WriteLine("Hola Mundo")
    End Sub

    Protected Sub linkbtnRegistrarNuevoServicio_Click(sender As Object, e As EventArgs) Handles linkbtnRegistrarNuevoServicio.Click
        Dim msg As New clMensajes
        'Response.Write(msg.Mensajes("Hola Mundo"))
        Response.Write(msg.Fx_AbrirVentana("RegistrarNuevoServicio.aspx", 0, 800, 400, 300, 300))
    End Sub
    Protected Sub ddlServicios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlServicios.SelectedIndexChanged
        'lblNomServicio.Text = ddlServicios.SelectedItem.ToString
        lblListaRecursos.Text = "Lista de Recursos disponible de " & ddlServicios.SelectedItem.ToString
        Dim lstRecursosPorServicio = ctrlServRecursoLugar.obtenerRecursos(ddlServicios.SelectedValue)
        Session("recursos") = ctrlServRecursoLugar.obtenerRecursos(ddlServicios.SelectedValue)
        'gvRecursos.DataSource = lstRecursosPorServicio
        'gvRecursos.DataBind()

    End Sub

    Protected Sub gvLugares_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvLugares.SelectedIndexChanged

    End Sub

    Protected Sub linkbtnNuevoRecurso_Click(sender As Object, e As EventArgs) Handles linkbtnNuevoRecurso.Click
        Dim msg As New clMensajes
        'Response.Write(msg.Mensajes("Hola Mundo"))
        Response.Write(msg.Fx_AbrirVentana("RegistrarNuevoRecurso.aspx", ddlServicios.SelectedValue, 400, 500, 500, 300))
    End Sub



    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Session("lugares") = ctrlServRecursoLugar.obtenerLugares()
        Session("servicios") = ctrlServRecursoLugar.obtenerServicios()
        Session("recursos") = ctrlServRecursoLugar.obtenerRecursos(ddlServicios.SelectedValue)
        If Not IsPostBack Then
            Dim columna = New ButtonField With {.HeaderText = "Accion", .CommandName = "EditarLugar", .Text = "Editar"}
            gvLugares.Columns.Insert(0, columna)
            Dim serv = ctrlServRecursoLugar.obtenerServicios()
            For Each s In serv
                ddlServicios.Items.Add(New ListItem(s.id_Servicio, s.nom_servicio))
            Next
            'ddlServicios.DataSource = ctrlServRecursoLugar.obtenerServicios()
            'ddlServicios.DataTextField()
            'ddlServicios.DataBind()

        End If

        'Dim lstLugares = ctrlServRecursoLugar.obtenerLugares()
        'gvLugares.DataSource = lstLugares

        ' gvLugares.DataBind()


    End Sub


    Protected Sub linkbtnRegistrarNuevoLugar_Click(sender As Object, e As EventArgs) Handles linkbtnRegistrarNuevoLugar.Click, linkBtnEditarLugar.Click
        Response.Write(msg.Fx_AbrirVentana("editarLugar", 0, 600, 600, 600, 600))
    End Sub
    Protected Sub btnEditarServicio_Click(sender As Object, e As EventArgs) Handles btnEditarServicio.Click
        Dim msg As New clMensajes
        'Response.Write(msg.Mensajes("Hola Mundo"))
        Response.Write(msg.Fx_AbrirVentana("RegistrarNuevoServicio.aspx", ddlServicios.SelectedValue, 800, 400, 300, 300))
    End Sub
End Class
