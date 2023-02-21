<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RegistrarNuevoServicio.aspx.vb" Inherits="RegistrarNuevoServicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 62%;
        }
        .auto-style2 {
            width: 395px;
        }
        .auto-style3 {
            width: 395px;
            height: 224px;
        }
        .auto-style11 {
            width: 97px;
            text-align: center;
            height: 76px;
        }
        .auto-style12 {
            width: 97px;
            height: 58px;
        }
        .auto-style13 {
            width: 97px;
        }
        .auto-style15 {
            width: 395px;
            height: 58px;
        }
        .auto-style16 {
            height: 58px;
        }
    </style>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous">
</head>
<body>
    

    <form runat ="server">
        
            <div class="form-group col-md-6">
                <br />
                <h3>
                    <asp:Label ID="Label1" runat="server" Text="Registro nuevo servicio" Font-Bold="True"></asp:Label>
                </h3>
                <br />
                <hr />
                <label for="lblServicio">Nombre del servicio</label>
                <asp:TextBox ID="txtNuevoServicio" runat="server" Width="213px" CssClass="form-control" placeholder="Servicio" required AutoPostBack="True"></asp:TextBox>
                <div class="invalid-feedback">Ingrese el nombre del servicio</div>
            </div>
        <br />
        
            <div class="form-group row">
                
            <div class="form-group col-md-3">
                
                <asp:TextBox ID="txtEmailServicio" runat="server" Width="209px" TextMode="Email" CssClass="form-control" placeholder="E-Mail responsables del servicio"></asp:TextBox>

            </div>
            <div class="form-group col-md-3">
                <asp:Button ID="btnSeleccionar" runat="server" Text="Agregar" Width="111px" CssClass="btn btn-outline-info" />
            </div>
            <div class="form-group col-md-6">
                <asp:CheckBoxList ID="cbxlResponsables" runat="server" AutoPostBack="True" Width="646px"> </asp:CheckBoxList>
            </div>
                </div>
      <br />
        <hr />
    <div class="form-row">
        <asp:Button ID="btnNuevoServicio" runat="server" Text="Registrar Servicio" Width="160px"  CssClass="btn btn-outline-success" type="submit"/>

    </div>

  </form>


</body>




</html>
