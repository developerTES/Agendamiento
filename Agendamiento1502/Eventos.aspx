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
    <% Dim ctrlServLug As New ControladorServicio_Recurso_Lugar()  %>
    <h2> Eventos Organizados por <%:Session("user") %> </h2>

    <%If Session("lst_org") IsNot Nothing Then %>
        <table class="table table-bordered">
        <thead>
            <tr>
                <th scope="col">Ver en Google Calendar</th>
                <th scope="col">Nombre Evento</th>
                <th scope="col">Descripción</th>
                <th scope="col">Fecha</th>
                <th scope="col">Lugar</th>
            </tr>
        </thead>
        <tbody>
            <%For each ev As Evento In Session("lst_org")%>
            <tr>
                <td><a href="#" class="link-info">Ver</a></td>
                <td><%:ev.nom_Evento %></td>
                <td> <%:   ev.evGoogle.Description.Split("<br><br>")(0)   %></td>
                
                <td><%:ev.evGoogle.Start.DateTime  %>  - <%:ev.evGoogle.End.DateTime  %> </td>
                <td><%: ctrlServLug.obtenerLugar(ev.id_lugar).nom_lugar   %></td>
            </tr>
            <% Next %>
        </tbody>
    </table>
    
    <%else %>
    <h4>No hay eventos agendados</h4>

    <%End If %>

    

    <br />
    <hr />

    <h2>Eventos a los que es asistente <%:Session("user") %> </h2>

    <%If Session("lst_asis") IsNot Nothing %>
        <table class="table table-bordered">
        <thead>
            <tr>
                <th scope="col">Nombre Evento</th>
                <th scope="col">Descripción</th>
                <th scope="col">Fecha</th>
                <th scope="col">Lugar</th>
            </tr>
        </thead>
        <tbody>



            <%For each ev As Evento In Session("lst_asis")%>
            <tr>
                <td><%:ev.nom_Evento %></td>
                <td><%: ev.evGoogle.Description.Split("<br><br>")(0)  %>  </td>
                <td><%:ev.evGoogle.Start.DateTime  %>  - <%:ev.evGoogle.End.DateTime  %> </td>
                <td><%:ev.id_lugar  %></td>
            </tr>
            <% Next %>
        </tbody>
    </table>
    <%else %>
    <h4>No hay eventos agendados</h4>
    <%End if %>

    

    <br />
    <hr />

    <h2>Eventos requeridos para soporte por <%:Session("user") %> </h2>

    <%If Session("lst_stop") IsNot Nothing Then%>
        <table class="table table-bordered">
        <thead>
            <tr>
                <th scope="col">Nombre Evento</th>
                <th scope="col">Descripción</th>
                <th scope="col">Fecha</th>
                <th scope="col">Lugar</th>
            </tr>
        </thead>
        <tbody>
            <%For Each ev As Evento In Session("lst_sop")%>
            <tr>
                <td><%:ev.nom_Evento %></td>
                <% Dim html As New HtmlString((ev.evGoogle.Description)) %>
                <td><%:ev.evGoogle.Description.Split("<br><br>")(0)  %>  </td>
                <td><%:ev.evGoogle.Start.DateTime  %>  - <%:ev.evGoogle.End.DateTime  %> </td>
                <td><%:ev.id_lugar  %></td>
            </tr>
            <% Next %>
        </tbody>
    </table>
    <%      Else %>
    <h4>No hay eventos agendados</h4>
        <%End If%>

    
    
</asp:Content>
