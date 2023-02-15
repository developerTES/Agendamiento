<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <table style="width: 75%;" align="center">
        <tr>
            <td align="center">
                <img src="img/EscudoFEI.jpg" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Image ID="imgProceso" runat="server" ImageUrl="~/img/progress_bar.gif" 
                    Visible="False" />
            </td>
        </tr>
        <tr>
            <td align="center">
            </td>
        </tr>
        <tr>
            <td align="center">
                User-Usuario
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:TextBox runat="server" ID="txtUsuario" Font-Names="Calibri" Font-Size="12pt"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center">
                Password-Contraseña
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:TextBox runat="server" ID="txtPassword" Font-Names="Calibri" Font-Size="12pt"
                    TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center">
                <br />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnLogin" runat="server" Text="Login" />
                <br />
                <asp:Label ID="lblPath" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;<img alt="" src="img/imgBarraPeq.png" />
            </td>
        </tr>
        <tr>
            <td align="center">
                Agendamiento</td>
        </tr>
    </table>

 
   
    

</asp:Content>
