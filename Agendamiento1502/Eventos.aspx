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

    <br />
    <hr />

    <h2> Eventos Organizados por <%:Session("user") %> </h2>

    <table class="table table-bordered">
  <thead>
      <tr>
          <th scope="col">Nombre Evento</th>
          <th scope="col">Descricpión</th>
          <th scope="col">Fecha</th>
          <th scope="col">Lugar</th>
      </tr>
  </thead>
        <tbody>
            <%For each ev As Evento In Session("lst_org")%>
            <tr>
                <th scope="row">1</th>
                <td>Mark</td>
                <td>Otto</td>
                <td>@mdo</td>
            </tr>
            <% Next %>
        </tbody>
</table>
    
</asp:Content>
