<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RegistrarNuevoServicio.aspx.vb" Inherits="RegistrarNuevoServicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 590px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblNuevoServicio0" runat="server" Text="Nombre del Nuevo servicio" Font-Bold="True"></asp:Label>
        </div>
        <div>

            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
            <asp:Label ID="lblNuevoServicio" runat="server" Text="Nombre del Nuevo servicio"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNuevoServicio" runat="server" Width="308px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">E-Mail responsable del servicio </td>
                    <td>
                        <asp:TextBox ID="txtEmailServicio" runat="server" Width="303px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnNuevoServicio" runat="server" Text="Registrar Servicio" Width="160px" />
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
