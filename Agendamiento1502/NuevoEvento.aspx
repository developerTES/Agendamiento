<%@ Page Language="VB" AutoEventWireup="false" CodeFile="NuevoEvento.aspx.vb" Inherits="Nuevo_Evento" MasterPageFile="~/Site.master"  %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">


    <h2>Registro de Nuevo Evento/Reserva</h2>
    <br />
    <br />
    <div class="row">
        <br />
        <br />
        <div class="col-md-4 col-sm-12 col-xs-12">



            <div class="row">
                <div class="form-group">
                    <h3>
                        <label for="exampleFormControlInput1">Nombre del Evento</label>
                    </h3>
                    <asp:TextBox ID="txtNombreEvento" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>


            <div class="row">
                <div class="form-group">
                    <h3>
                        <label for="exampleFormControlInput1">Descripción del evento</label>
                    </h3>
                    <asp:TextBox ID="txtDescripcionEvento" runat="server" Height="200px" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <hr />
        </div>

        <div class="col-md-8 col-sm-12 col-xs-12">
            <div class="row">
                <h3>
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Hora del Evento"></asp:Label>
                </h3>
            </div>
            <br />
            <br />

            <div class="row">
                <div class="form-check">
                    <asp:Label ID="lblInfo" runat="server" Text="Se repite"></asp:Label>
                    <asp:CheckBox ID="cbRepitencia" runat="server" AutoPostBack="true" />
                </div>

            </div>
            <br />


            <div class="row">
                <asp:Panel ID="panelNoRepitencia" runat="server" Visible="true">


                    <div class="row">




                        <div class="col-md-4 col-xs-12 col-sm-12">

                            <div class="form-group">
                                <h4>
                                    <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio"></asp:Label>
                                </h4>

                                <asp:TextBox ID="txtDatetimeInicio" runat="server" Width="180px" TextMode="DateTimeLocal" AutoPostBack="True" CssClass="form-control"></asp:TextBox>
                                <small id="FechaHelp" class="form-text text-muted">La fecha de inicio debe ser superior a 24 horas.</small>
                            </div>




                        </div>

                        <div class="col-md-4 col-xs-12 col-sm-12">
                            <div class="form-group">
                                <h4>
                                    <asp:Label ID="lblFechaFin" runat="server" Text="Fecha Fin"></asp:Label></h4>

                                <asp:TextBox ID="txtDatetimeFin" runat="server" Width="188px" TextMode="DateTimeLocal" AutoPostBack="True" CssClass="form-control"></asp:TextBox>
                            </div>

                        </div>

                        <hr />
                    </div>





                </asp:Panel>

                <asp:Panel ID="panelRepitencia" runat="server" Visible="false">
                    Repitencia
                    
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Repitencia"></asp:Label>


                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Inicio"></asp:Label>

                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Fin"></asp:Label>
                    <asp:Label ID="lblRepitencia" runat="server" Font-Bold="True" Text="Repitencia"></asp:Label>
                    <asp:Label ID="lblHoraRepitenciaInicio" runat="server" Font-Bold="True" Text="Inicio"></asp:Label>
                    <asp:Label ID="lblHoraRepitenciaFin" runat="server" Font-Bold="True" Text="Fin"></asp:Label>
                    <asp:Label ID="lblRepetirCada" runat="server" Text="Repetir cada"></asp:Label>
                    <asp:TextBox ID="txtRepeticiones" runat="server" TextMode="Number" Width="70px" Style="height: 22px" min="1">1</asp:TextBox>
                    <asp:DropDownList ID="ddlTipoRepitencia" runat="server" AutoPostBack="true">
                        <asp:ListItem Selected="True">Días</asp:ListItem>
                        <asp:ListItem>Semanas</asp:ListItem>
                        <asp:ListItem>Meses</asp:ListItem>
                        <asp:ListItem>Años</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtHoraRepitenciaInicio" runat="server" TextMode="Time" Width="103px" AutoPostBack="True"></asp:TextBox>
                    <asp:TextBox ID="txtHoraRepitenciaFin" runat="server" TextMode="Time" AutoPostBack="True"></asp:TextBox>
                    <asp:Label ID="lblRepetirCada0" runat="server" Text="Se repite el"></asp:Label>
                    <asp:ListBox ID="lbxSemana" runat="server" SelectionMode="Multiple" Width="138px" Height="123px">
                        <asp:ListItem>Lunes</asp:ListItem>
                        <asp:ListItem>Martes</asp:ListItem>
                        <asp:ListItem>Miércoles</asp:ListItem>
                        <asp:ListItem>Jueves</asp:ListItem>
                        <asp:ListItem>Viernes</asp:ListItem>
                        <asp:ListItem>Sábado</asp:ListItem>
                        <asp:ListItem>Domingo</asp:ListItem>
                    </asp:ListBox>
                    <asp:Label ID="lblTermina" runat="server" Text="Termina"></asp:Label>
                    <asp:CheckBox ID="cbRepitenciaFecha" runat="server" AutoPostBack="true" />
                    <asp:Label ID="lblRepitencia1" runat="server" Text="El"></asp:Label>
                    <asp:TextBox ID="txtRepitenciaFechaFin" runat="server" TextMode="Date" AutoPostBack="True"></asp:TextBox>
                    <asp:CheckBox ID="cbRepitenciaVeces" runat="server" AutoPostBack="true" />
                    <asp:Label ID="lblRepitencia2" runat="server" Text="Después de"></asp:Label>
                    <asp:TextBox ID="txtBoxNumVeces" runat="server" Height="22px" TextMode="Number" Width="51px" min="1"></asp:TextBox>
                    <asp:Label ID="lblRepitencia3" runat="server" Text=" repeticiones"></asp:Label>
                    <hr />
                </asp:Panel>

                <br />
                <br />
            </div>
            <div class="row">
                <br />
                <br />
                <h3>
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Ubicación del Evento"></asp:Label></h3>
                <h5>
                    <asp:Label ID="Label2" runat="server" Text="Seleccione el Lugar"></asp:Label></h5>
                <br />
                <asp:DropDownList ID="ddlLugar" runat="server" DataSourceID="SqlDataSource1" DataTextField="NOM_LUGAR" DataValueField="ID_LUGAR" Style="margin-bottom: 6" CssClass="form-control" AutoPostBack="True">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AgendamientoConnectionString %>" SelectCommand="SELECT [NOM_LUGAR], [ID_LUGAR] FROM [LUGAR]"></asp:SqlDataSource>
                <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
  Launch demo modal
</button>



            </div>
            <br />
                <hr />
            <div class="row">

                <br />
                

                <h3>
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Large" Text="Invitados"></asp:Label></h3>
                <br />
                <div class="col-md-8 col-xs-12 col-sm-12 form-inline">



                    <br />
                        <div class="row">
                            <h5>
                                <asp:Label ID="lblInfo1" runat="server" Text="Ingrese correo de invitados"></asp:Label></h5>
                        </div>

                        <asp:TextBox ID="txtInvitado" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
                        <asp:Button ID="btnAgregarInvitado" runat="server" CssClass="btn btn-secondary" Text="Agregar Invitado" />
                        <asp:Button ID="btnRetirarSeleccionados" runat="server" Text="Retirar Seleccionados" CssClass="btn btn-secondary" />

                    



                </div>
                <div class="col-md-4 col-xs-12 col-sm-12">
                    <asp:CheckBoxList ID="cbxlInvitados" runat="server" ></asp:CheckBoxList>
                </div>


            </div>
            <br />
        </div>



        <hr />
        <br />
        <br />
    </div>




    <br />
    <br />



    <div>


        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Large" Text="Servicios y Recursos"></asp:Label>
        <br />
        <br />

        <div class="accordion accordion-flush" id="accordionFlushExample">
            <% For Each serv As Servicio In Session.Item("lstServicios")%>
            <div class="accordion-item">
                <h2 class="accordion-header" id="flush-headingOne">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapse<%:serv.id_Servicio %>" aria-expanded="false" aria-controls="flush-collapseOne">
                        <h3><%: serv.nom_servicio  %> </h3>
                    </button>
                </h2>
                <div id="flush-collapse<%:serv.id_Servicio %>" class="accordion-collapse collapse" aria-labelledby="flush-headingOne" data-bs-parent="#accordionFlushExample">
                    <div class="accordion-body">

                        <% For Each recurso As Recurso In serv.recursos %>

                        <div class="container text-center">
                            <div class="row align-items-start">
                                <div class="col">



                                    <% Dim rec As String = recurso.nom_Recurso  %>
                                    <h3><%:  rec   %> </h3>
                                    <h5><%:  recurso.desc_recurso    %></h5>



                                </div>
                                <div class="col">


                                    <input value="0" min="0" type="number" class="form-control" placeholder="Cantidad de recursos" id="txtCant_<%=serv.id_Servicio %>_<%=recurso.nom_Recurso  %>" name="txtCant_<%=serv.id_Servicio %>_<%=recurso.id_recurso   %>" aria-label="Username" aria-describedby="basic-addon1" size="10">
                                    <small id="Cantidad" class="form-text text-muted align-content-center">Cantidad requerida del recurso. Si no se requiere, el valor es cero.
                                    </small>
                                </div>
                                <div class="col">

                                    <input type="text" class="form-control" placeholder="Detalles" id="txtDesc_<%=serv.id_Servicio %>_<%=recurso.nom_Recurso  %>" name="txtDesc_<%=serv.id_Servicio %>_<%=recurso.id_recurso   %>" aria-label="Username" aria-describedby="basic-addon1">
                                    <small id="Descr" class="form-text text-muted"></small>
                                </div>
                            </div>
                        </div>

                        <br />


                        <%Next%>
                    </div>
                </div>
            </div>

            <%Next%>
        </div>




    </div>



    <br />

    <div>

        <table class="nav-justified">
            <tr>
                <td style="height: 20px; width: 637px"></td>
                <td style="height: 20px; width: 990px;"></td>
            </tr>
            <tr>
                <td style="width: 637px">&nbsp;</td>
                <td style="width: 990px">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 637px">

                    <asp:Button ID="btnRegistrarEvento" runat="server" Font-Bold="True" Text="Registrar Evento" Width="144px" Height="26px" />
                </td>
                <td style="width: 990px">&nbsp;</td>
            </tr>
        </table>

    </div>




</asp:Content>
