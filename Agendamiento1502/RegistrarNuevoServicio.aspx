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
                    <td class="auto-style13" colspan="2">
                        <asp:TextBox ID="txtNuevoServicio" runat="server" Width="213px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style15">E-Mail responsables del servicio </td>
                    <td class="auto-style16">
                        <asp:TextBox ID="txtEmailServicio" runat="server" Width="209px" TextMode="Email"></asp:TextBox>
                    </td>
                    <td class="auto-style12">
                        <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" Width="111px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style11" colspan="2">
                        <asp:CheckBoxList ID="cbxlResponsables" runat="server" AutoPostBack="True" Width="646px">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="btnNuevoServicio" runat="server" Text="Registrar Servicio" Width="160px" />
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
