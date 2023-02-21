<%@ Page Language="VB" AutoEventWireup="false" CodeFile="editarLugar.aspx.vb" Inherits="editarLugar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous">

</head>
<body>
    <div class="ms-5 me-5 my-5  ">
    <form id="form1" runat="server">
        <br />
        <br />
        
        <h2><asp:Label ID="lblRegistroLugar" runat="server" Text="Registro de Nuevo Lugar"></asp:Label></h2>
        <div class="form-group">
            <label for="lblNombreLugar">Nombre del lugar</label>
            <asp:TextBox ID="txtNuevoLugar" runat="server"  placeholder="Lugar" CssClass="form-control"></asp:TextBox>
            <small id="emailHelp" class="form-text text-muted">Lugar que se podrá reservar para agendar eventos</small>
        </div>
        <br />
        <div class="form-group">
            <label for="exampleInputPassword1">Descripción del lugar </label>
            <asp:TextBox ID="txtdescrLugar" runat="server" CssClass="form-control" placeholder="Opcional"></asp:TextBox>
        </div>
        <br />
        <br />
        <asp:Button ID="btnNuevoLugar" runat="server" Text="Registrar Lugar"  CssClass="btn btn-outline-success" />
    </form>
        </div>
    
</body>
</html>
