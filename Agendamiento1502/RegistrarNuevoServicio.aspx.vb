
Imports System.Diagnostics

Partial Class RegistrarNuevoServicio
    Inherits System.Web.UI.Page


    'Dim lstEmails As New Dictionary(Of String, String)
    Dim ctrlServ As New ControladorServicio_Recurso_Lugar()
    Dim msg As New clMensajes()

    Protected Sub btnNuevoServicio_Click(sender As Object, e As EventArgs) Handles btnNuevoServicio.Click

        Dim servicio = txtNuevoServicio.Text
        Dim emails As New List(Of String)
        For Each lst As ListItem In cbxlResponsables.Items
            If lst.Selected = True Then
                emails.Add(lst.Text)

            End If
        Next


        Dim ctrlServicio_Recurso As New ControladorServicio_Recurso_Lugar
        Dim msg = ctrlServicio_Recurso.registrarNuevoServicio(servicio, emails)
        Dim msgbox = New clMensajes
        If msg IsNot Nothing Then

            Response.Write(msgbox.Mensajes(msg))
        Else
            Response.Write(msgbox.Mensajes("No se pudo registrar el Servicio"))
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim id = Request.QueryString("id")
        Debug.WriteLine("ID DEL REPSONSE")
        Debug.WriteLine(id)
        Try
            If id <> "0" Then
                Dim servicio = ctrlServ.obtenerServicio(id)
                btnNuevoServicio.Text = "Editar Servicio"
                txtNuevoServicio.Text = servicio.nom_servicio
                cbxlResponsables.DataSource = servicio.email_responsable
                txtNuevoServicio.Enabled = False
                cbxlResponsables.DataBind()
                For Each i As ListItem In cbxlResponsables.Items
                    i.Selected = True
                Next
            End If
        Catch ex As Exception

        End Try

    End Sub


    Protected Sub btnSeleccionar_Click(sender As Object, e As EventArgs) Handles btnSeleccionar.Click

        Dim existe = False
        For Each i In cbxlResponsables.Items
            If i.Text = txtEmailServicio.Text Then
                existe = True
            End If
        Next

        If existe Then
        Else
            cbxlResponsables.Items.Add(txtEmailServicio.Text)
            For Each i As ListItem In cbxlResponsables.Items
                i.Selected = True
            Next
        End If







    End Sub
    Protected Sub cbxlResponsables_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxlResponsables.SelectedIndexChanged
        'lstEmails = New List(Of String)


    End Sub
    Protected Sub txtNuevoServicio_TextChanged(sender As Object, e As EventArgs) Handles txtNuevoServicio.TextChanged
        Dim serv = ctrlServ.obtenerServicio(txtNuevoServicio.Text)
        If serv IsNot Nothing Then
            Debug.WriteLine("El servicio ya existe")
            Response.Write(msg.Mensajes("El servicio ya existe"))
            txtNuevoServicio.Text = ""
        Else
            'Debug.WriteLine("El servicio no existe")
        End If
    End Sub
End Class
