<%@ Page Title="Eventos agendados" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Eventos.aspx.vb" Inherits="Eventos"  %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    

    
    <br />
    <hr />
    <% Dim ctrlServLug As New ControladorServicio_Recurso_Lugar()  %>
    <% Dim ctrlCalGoogle As New GoogleCalendarControlador("primary")  %>



    <h2><strong> Eventos Organizados por <%:Session("user") %> </strong></h2>
    <br />
    <%If Session("lst_org") IsNot Nothing Then %>
        
    <!--
    <div class="row">

        <%For each e As Evento In Session("lst_org")%>
        <div class="col-lg-4  ">
            
            <div class="card h-100" >
                <div class="card-body">
                    <h5 class="card-title"><%:e.nom_Evento  %> </h5>
                    <br />
                    <h6 class="card-subtitle mb-2 text-muted"><%: e.evGoogle.Description.Split("<br><br>")(0) %></h6>
                    <hr />
                    <%If e.citas(0).date_inicio.DayOfYear = e.citas(0).date_fin.DayOfYear  %>
                     <p Class="card-text"> <strong>Lugar y Fecha:  </strong> <%:ctrlServLug.obtenerLugar(e.id_lugar).nom_lugar  %>  -  (<%:e.citas(0).date_inicio.ToString("dd/MMM/yyy") %>)</p>
                      <p class="card-text">  <%:e.citas(0).date_inicio.ToString("hh:mm tt") %> - <%:e.citas(0).date_fin.ToString("hh:mm tt") %>  </p>
                        <%else %>
                    <p Class="card-text"> <strong>Lugar y Fecha:  </strong> <%:ctrlServLug.obtenerLugar(e.id_lugar).nom_lugar  %>  -  (<%:e.citas(0).date_inicio %> - <%:e.citas(0).date_fin %>)</p>
                    <%End if %>
                    
                    <a href = "<%:e.evGoogle.HtmlLink  %>" Class="card-link" target="_blank" >Ver Evento en Google Calendar</a>
                    <a href = "#" Class="card-link">Editar</a>
                </div>
            </div>
           <br />
        </div>


        

            
        <% Next %>
    </div>
        -->
    
    <%For each e As Evento In Session("lst_org")%>
    <div class="card mb-3" >
        <div class="row">
            <div class="col-md-4" >
                
                <h4 class="card-title"><%:e.nom_Evento  %> </h4>
                <br />
                <%If e.citas(0).date_inicio.DayOfYear = e.citas(0).date_fin.DayOfYear  %>
                     <h5 Class="card-text l-5"> <strong>Lugar y Fecha:  </strong> <%:ctrlServLug.obtenerLugar(e.id_lugar).nom_lugar  %>  -  (<%:e.citas(0).date_inicio.ToString("dd/MMM/yyy") %>)</h5>
                      <h6 class="card-text l-6">  <%:e.citas(0).date_inicio.ToString("hh:mm tt") %> - <%:e.citas(0).date_fin.ToString("hh:mm tt") %>  </h6>
                        <%else %>
                    <h5 Class="card-text l-5"> <strong>Lugar y Fecha:  </strong> <%:ctrlServLug.obtenerLugar(e.id_lugar).nom_lugar  %>  -  (<%:e.citas(0).date_inicio %> - <%:e.citas(0).date_fin %>)</h5>
                    <%End if %>
            </div>
            <div class="col-md-8">
                <div class="card-body">
                    <br />
                    <h5 class="card-title"><strong>Descripción </strong>  </h5>
                    <p class="card-text"><%: e.evGoogle.Description.Split("<br><br>")(0) %></p>
                    <p class="card-text"><a href = "<%:e.evGoogle.HtmlLink  %>" Class="card-link" target="_blank" >Ver Evento en Google Calendar</a>
                    <a href = "#" Class="card-link">Editar</ a></p>
                </div>
            </div>
        </div>
    </div>
    <% Next %>

    
    <%Else %>
    <h4>No hay eventos agendados</h4>

    <%End If %>

    

    <br />
    <hr />

    <h2> <strong>Eventos a los que es asistente <%:Session("user") %> </strong></h2>
    <br />
    <br />

    <%If Session("lst_asis") IsNot Nothing %>
    <%For each e As Evento In Session("lst_asis")%>
    <div class="card mb-3">
        <div class="row">
            <div class="col-md-4">

                <h4 class="card-title"><%:e.nom_Evento  %> </h4>
                <br />
                <%If e.citas(0).date_inicio.DayOfYear = e.citas(0).date_fin.DayOfYear  %>
                <h5 class="card-text l-5"><strong>Lugar y Fecha:  </strong><%:ctrlServLug.obtenerLugar(e.id_lugar).nom_lugar  %>  -  (<%:e.citas(0).date_inicio.ToString("dd/MMM/yyy") %>)</h5>
                <h6 class="card-text l-6"><%:e.citas(0).date_inicio.ToString("hh:mm tt") %> - <%:e.citas(0).date_fin.ToString("hh:mm tt") %>  </h6>
                <%else %>
                <h5 class="card-text l-5"><strong>Lugar y Fecha:  </strong><%:ctrlServLug.obtenerLugar(e.id_lugar).nom_lugar  %>  -  (<%:e.citas(0).date_inicio %> - <%:e.citas(0).date_fin %>)</h5>
                <%End if %>
            </div>
            <div class="col-md-8">
                <div class="card-body">
                    <br />
                    <h5 class="card-title"><strong>Descripción </strong></h5>
                    <p class="card-text"><%: e.evGoogle.Description.Split("<br><br>")(0) %></p>
                    <p class="card-text">
                        <a href="<%:e.evGoogle.HtmlLink  %>" class="card-link" target="_blank">Ver Evento en Google Calendar</a>
                        <a href="#" class="card-link">Editar</a>
                    </p>
                </div>
            </div>
        </div>
    </div>
         <% Next %>
    <%else %>
    <h4>No hay eventos agendados</h4>
    <%End if %>

    

    <br />
    <hr />

    <h2><strong>Eventos requeridos para soporte por <%:Session("user") %> </strong></h2>

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
