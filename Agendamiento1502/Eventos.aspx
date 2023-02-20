﻿<%@ Page Title="Eventos" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Eventos.aspx.vb" Inherits="Eventos" %>

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
                <td> <%:   ev.evGoogle.Description  %></td>
                
                <td><%:ev.evGoogle.Start.DateTime  %>  - <%:ev.evGoogle.End.DateTime  %> </td>
                <td><%: ctrlServLug.obtenerLugar(ev.id_lugar).nom_lugar   %></td>
            </tr>
            <% Next %>
        </tbody>
    </table>

    <br />
    <hr />

    <h2>Eventos a los que es asistente <%:Session("user") %> </h2>

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
                <td><%:   ev.evGoogle.Description  %>  </td>
                <td><%:ev.evGoogle.Start.DateTime  %>  - <%:ev.evGoogle.End.DateTime  %> </td>
                <td><%:ev.id_lugar  %></td>
            </tr>
            <% Next %>
        </tbody>
    </table>

    <br />
    <hr />

    <h2>Eventos requeridos para soporte por <%:Session("user") %> </h2>

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
            <%For each ev As Evento In Session("lst_sop")%>
            <tr>
                <td><%:ev.nom_Evento %></td>
                <td><%:   ev.evGoogle.Description  %>  </td>
                <td><%:ev.evGoogle.Start.DateTime  %>  - <%:ev.evGoogle.End.DateTime  %> </td>
                <td><%:ev.id_lugar  %></td>
            </tr>
            <% Next %>
        </tbody>
    </table>
    
</asp:Content>
