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

 
    <table class="tbl">  
      <tr>  
          <td colspan="2">  
              <asp:Button ID="btnEnglish" runat="server" meta:resourceKey="btnEnglish"  
                  />  
              <asp:Button ID="btnSpanish" runat="server" meta:resourceKey="btnSpanish"  
                   />  
          </td>  
      </tr>  
      <tr>  
          <td>  
              <asp:Label ID="lblFirstName" runat="server"   
              AssociatedControlID="txtFirstName" meta:resourceKey="lblFirstName"></asp:Label>  
          </td>  
          <td>  
              <asp:TextBox ID="txtFirstName" runat="server" CssClass="textbox"  
              meta:resourceKey="txtFirstName"></asp:TextBox>  
          </td>  
      </tr>  
      <tr>  
          <td>  
              <asp:Label ID="lblLastName" runat="server"  
              AssociatedControlID="txtLastName" meta:resourceKey="lblLastName"></asp:Label>  
          </td>  
          <td>  
              <asp:TextBox ID="txtLastName" runat="server" CssClass="textbox"  
              meta:resourceKey="txtLastName"></asp:TextBox>  
          </td>  
      </tr>  
      <tr>  
          <td>  
              <asp:Label ID="lblMobile" runat="server"  
              AssociatedControlID="txtMobile" meta:resourceKey="lblMobile"></asp:Label>  
          </td>  
          <td>  
              <asp:TextBox ID="txtMobile" runat="server" CssClass="textbox"  
              meta:resourceKey="txtMobile"></asp:TextBox>  
          </td>  
      </tr>  
      <tr>  
          <td>  
              <asp:Label ID="lblOrganisation" runat="server"  
              AssociatedControlID="txtOrganisation" meta:resourceKey="lblOrganisation"></asp:Label>  
          </td>  
          <td>  
              <asp:TextBox ID="txtOrganisation" runat="server" CssClass="textbox"  
              meta:resourceKey="txtOrganisation"></asp:TextBox>  
          </td>  
      </tr>  
      <tr>  
          <td valign="top">  
              <asp:Label ID="lblAddress" runat="server"  
              AssociatedControlID="txtAddress" meta:resourceKey="lblAddress"></asp:Label>  
          </td>  
          <td>  
              <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"  
              meta:resourceKey="txtAddress"></asp:TextBox>  
          </td>  
      </tr>  
  </table> 
    

</asp:Content>
