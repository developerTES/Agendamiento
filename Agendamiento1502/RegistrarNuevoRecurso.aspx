<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RegistrarNuevoRecurso.aspx.vb" Inherits="RegistrarNuevoRecurso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
            <asp:Label ID="lblNuevoRecurso" runat="server" Text="Nombre del Nuevo recurso"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNuevoRecurso" runat="server" Width="308px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Descripcion del nuevo recurso </td>
                    <td>
                        <asp:TextBox ID="txtdescrRecurso" runat="server" Width="303px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnNuevoRecurso" runat="server" Text="Registrar Recurso" Width="160px" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
