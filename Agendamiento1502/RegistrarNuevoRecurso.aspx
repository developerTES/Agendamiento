<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RegistrarNuevoRecurso.aspx.vb" Inherits="RegistrarNuevoRecurso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous">
</head>
<body>
    <form runat="server">
        <br />
        <br />
        <h3>Registro de nuevo Recurso</h3>
        <div class="form-group">
            <%Dim id_servicio = Request.QueryString("id") %>
            <label for="lblNuevoRecurso">Nombre del recurso para  <%:id_servicio %> </label>
            
            <asp:TextBox ID="txtNuevoRecurso" runat="server" CssClass="form-control" placeholder="Ingrese un nuevo recurso"></asp:TextBox>

            <small id="emailHelp" class="form-text text-muted">Recurso contable y medible </small>
        </div>
        <br />
        <div class="form-group">
            
            <label for="lblDescrRecurso">Descripción del recurso </label>
            <asp:TextBox ID="txtdescrRecurso" runat="server" CssClass="form-control" placeholder="Opcional"></asp:TextBox>

        </div>
        <br />
        <asp:Button ID="btnNuevoRecurso" runat="server" Text="Registrar Recurso" Width="160px" type="submit" CssClass="btn btn-outline-success" />
    </form>
</body>
</html>
