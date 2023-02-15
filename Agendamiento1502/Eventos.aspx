<%@ Page Title="Eventos" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Eventos.aspx.vb" Inherits="Eventos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Mis Eventos</h3>

    <asp:Button ID="btnListarEvento" runat="server" Text="ListarEventos" />

    <br />
    <br />
    <div>

        <asp:GridView ID="gvEventos" runat="server">
        </asp:GridView>

    </div>
    
</asp:Content>
