﻿
Imports System.Data
Imports System.Diagnostics

Partial Class Administrador
    Inherits System.Web.UI.Page

    Dim ctrlServRecursoLugar = New ControladorServicio_Recurso_Lugar()
    Dim msg As New clMensajes

    Protected Sub registrarNuevoServicio()
        Debug.WriteLine("Hola Mundo")
    End Sub

    Protected Sub linkbtnRegistrarNuevoServicio_Click(sender As Object, e As EventArgs) Handles linkbtnRegistrarNuevoServicio.Click
        Dim msg As New clMensajes
        'Response.Write(msg.Mensajes("Hola Mundo"))
        Response.Write(msg.Fx_AbrirVentana("RegistrarNuevoServicio.aspx", "", 300, 300, 500, 300))
    End Sub
    Protected Sub ddlServicios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlServicios.SelectedIndexChanged
        lblNomServicio.Text = ddlServicios.SelectedItem.ToString
        lblListaRecursos.Text = "Lista de Recursos disponible de " & ddlServicios.SelectedItem.ToString
        Dim lstRecursosPorServicio = ctrlServRecursoLugar.obtenerRecursos(ddlServicios.SelectedIndex)
        gvRecursos.DataSource = lstRecursosPorServicio
        gvRecursos.DataBind()

    End Sub
    Protected Sub linkbtnNuevoRecurso_Click(sender As Object, e As EventArgs) Handles linkbtnNuevoRecurso.Click
        Dim msg As New clMensajes
        'Response.Write(msg.Mensajes("Hola Mundo"))
        Response.Write(msg.Fx_AbrirVentana("RegistrarNuevoRecurso.aspx", ddlServicios.SelectedIndex, 300, 300, 500, 300))
    End Sub
    Protected Sub gvLugares_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvLugares.SelectedIndexChanged

    End Sub





    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim columna = New ButtonField With {.HeaderText = "Accion", .CommandName = "EditarLugar", .Text = "Editar"}
            gvLugares.Columns.Insert(0, columna)
        End If



        Dim lstLugares = ctrlServRecursoLugar.obtenerLugares()
        gvLugares.DataSource = lstLugares

        gvLugares.DataBind()


    End Sub

    Protected Sub EditarLugar(sender As Object, e As EventArgs) Handles gvLugares.RowCommand
        Dim ev = CType(e, GridViewCommandEventArgs)
        Dim idRow = ev.CommandArgument
        Dim row = gvLugares.Rows.Item(Integer.Parse(idRow))
        Debug.WriteLine("Editando lugar" & row.Cells.Item(1).Text)
        Dim idLugar = row.Cells.Item(1).Text
        Response.Write(msg.Fx_AbrirVentana("editarLugar", idLugar, 600, 600, 600, 600))




    End Sub


    Protected Sub linkbtnRegistrarNuevoLugar_Click(sender As Object, e As EventArgs) Handles linkbtnRegistrarNuevoLugar.Click
        Response.Write(msg.Fx_AbrirVentana("editarLugar", 0, 600, 600, 600, 600))
    End Sub
End Class
