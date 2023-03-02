<%@ Page Title="Eventos agendados" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeFile="Eventos.aspx.vb" Inherits="Eventos"  %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    

    
    <br />
    <hr />
    <% Dim ctrlServLug As New ControladorServicio_Recurso_Lugar()  %>
    <% Dim ctrlCalGoogle As New GoogleCalendarControlador("primary")  %>



    <div class="accordion accordion-flush" id="accordionFlushExample">

        <!--Acordeón collapse de Eventos por organizador-->
        <div class="accordion-item">
            <h2 class="accordion-header" id="flush-headingOne">
                <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapseOne" aria-expanded="false" aria-controls="flush-collapseOne">
                    <h2><strong>Eventos a los que es asistente <%:Session("user") %> </strong></h2>
                </button>
            </h2>
            <div id="flush-collapseOne" class="accordion-collapse collapse" aria-labelledby="flush-headingOne" data-bs-parent="#accordionFlushExample">
                <div class="accordion-body">

                    <%If Session("lst_org") IsNot Nothing %>
                    <%For each e As Evento In Session("lst_org")%>

                    
                    <div class="card">
                        <div class ="card-header">
                            <h4 class="card-title"><%:e.nom_Evento  %> </h4>
                             <%If e.citas(0).date_inicio.DayOfYear = e.citas(0).date_fin.DayOfYear  %>
                                <h5 class="card-text l-5"><strong>Lugar y Fecha:  </strong><%:ctrlServLug.obtenerLugar(e.id_lugar).nom_lugar  %>  -  (<%:e.citas(0).date_inicio.ToString("dd/MMM/yyy") %>)</h5>
                                <h6 class="card-text l-6"><%:e.citas(0).date_inicio.ToString("hh:mm tt") %> - <%:e.citas(0).date_fin.ToString("hh:mm tt") %>  </h6>
                                <%else %>
                                <h5 class="card-text l-5"><strong>Lugar y Fecha:  </strong><%:ctrlServLug.obtenerLugar(e.id_lugar).nom_lugar  %>  -  (<%:e.citas(0).date_inicio %> - <%:e.citas(0).date_inicio.ToString("hh:mm tt")%> - <%e.citas(0).date_fin.ToString("hh:mm")%>)</h5>
                                <%End If %>
                        </div>
                        <div class="card-body">
                            <p class="card-body "><%:e.evGoogle.Description  %></p>
                        </div>
                        <div class="card-footer">
                            
                            
                            <a href=" <%:e.evGoogle.HtmlLink  %>" class="btn btn-success" target="_blank">Ver en Calendar</a>
                            
                            
                            <asp:button type="button" class="btn btn-primary"  data-toggle="modal" data-target="#myModal<%:e.id_GoogleCalUID  %>">Cancelar Evento</asp:button>

                            <div id="myModal<%:e.id_GoogleCalUID  %>" class="modal in" role="dialog">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h4 class="modal-title">Cancelar Evento <%:e.nom_Evento%> </h4>
                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                        </div>
                                        <div class="modal-body">
                                            <div class="form-check ">
                                            <h1><%:e.nom_Evento%></h1>
                                            <p><%:e.evGoogle.Description.Split("<br><br>")(0) %></p>
                                            <h3><%:e.citas(0).date_inicio.ToString("m") %> - <%:e.citas(0).date_inicio.ToString("m") %> </h3>
                                            <h3><%:ctrlServLug.obtenerLugar(e.id_lugar).nom_lugar  %></h3>
                                             
                                            <hr />
                                            <br />
                                            </div>
                                            <%Dim idGoogle = e.id_GoogleCalUID  %>
                                            
                                            <button type="submit" class="btn btn-danger" id="btnCancelarDef" onclick="ShowCurrentTime('<%:e.id_GoogleCalUID  %>')">Cancelar</button>
                                            


                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%:idGoogle%>' />
                                            <asp:LinkButton ID="lnkBtn" runat="server" CommandArgument='<%:idGoogle%>' Text="Cancelar?????" autopostback="true" />
                                            
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            

                        </div>
                    </div>
                        
                    <% Next %>
                    <%else %>
                    <h4>No hay eventos agendados</h4>
                    <%End if %>
                </div>
            </div>
        </div>



        <!--Acordeón collapse de Eventos invitado-->
        <div class="accordion-item">
            <h2 class="accordion-header" id="flush-headingTwo">
                <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapseTwo" aria-expanded="false" aria-controls="flush-collapseTwo">
                    <h2><strong>Eventos a los que es asistente <%: Session("user") %> </strong></h2>
                </button>
            </h2>
            <div id="flush-collapseTwo" class="accordion-collapse collapse" aria-labelledby="flush-headingTwo" data-bs-parent="#accordionFlushExample">
                <div class="accordion-body">

                    <%If Session("lst_asis") IsNot Nothing %>
                    <%For each e As Evento In Session("lst_asis")%>
                    <div class="card mb-3">
                        <div class ="card-header">
                            <h4 class="card-title"><%:e.nom_Evento  %> </h4>
                             <%If e.citas(0).date_inicio.DayOfYear = e.citas(0).date_fin.DayOfYear  %>
                                <h5 class="card-text l-5"><strong>Lugar y Fecha:  </strong><%:ctrlServLug.obtenerLugar(e.id_lugar).nom_lugar  %>  -  (<%:e.citas(0).date_inicio.ToString("dd/MMM/yyy") %>)</h5>
                                <h6 class="card-text l-6"><%:e.citas(0).date_inicio.ToString("hh:mm tt") %> - <%:e.citas(0).date_fin.ToString("hh:mm tt") %>  </h6>
                                <%else %>
                                <h5 class="card-text l-5"><strong>Lugar y Fecha:  </strong><%:ctrlServLug.obtenerLugar(e.id_lugar).nom_lugar  %>  -  (<%:e.citas(0).date_inicio %> - <%:e.citas(0).date_fin %>)</h5>
                                <%End if %>
                        </div>
                        <div class="card-body">

                        </div>
                        <div class="card-footer">

                        </div>
                    </div>
                    <% Next %>
                    <%else %>
                    <h4>No hay eventos agendados</h4>
                    <%End if %>
                </div>
            </div>
        </div>


        <!--Acordeón collapse de Eventos requieren soporte-->
        <div class="accordion-item">
                <h2 class="accordion-header" id="flush-headingThree">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapseTwo" aria-expanded="false" aria-controls="flush-collapseThree">
                        Hola Mundo
                    </button>
                </h2>
                <div id="flush-collapseThree" class="accordion-collapse collapse" aria-labelledby="flush-headingThree" data-bs-parent="#accordionFlushExample">
                    <div class="accordion-body">

                        Hola Muindo
                    </div>
                </div>
            </div>


            
        </div>



    
    <br />
    
        
   
    
    

    

    <br />
    <hr />

    
    <br />
    <br />

    

    

    <br />
    <hr />

    <h2><strong>Eventos requeridos para soporte por <%:  Session("user") %> </strong></h2>

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


    <script type="text/javascript">

        function ShowCurrentTime(id) {


            alert("Hola Mundo desde AJAX ")
            $.ajax({
                type: "POST",
                async: false,
                url: "Eventos.aspx/PrintGoogleCAL",

                data: "{'str': '" +id+ "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert("Failure");
                },
                error: function (jqXhr, textStatus, errorThrown) {
                    console.log(errorThrown);
                }
            });
        }
        function OnSuccess(response) {
            //alert(response.d);
            var result = response.d;
            alert("SUCCESS");
            alert(result);
        }
    </script>
    
</asp:Content>
