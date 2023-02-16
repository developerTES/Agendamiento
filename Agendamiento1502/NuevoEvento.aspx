<%@ Page Language="VB" AutoEventWireup="false" CodeFile="NuevoEvento.aspx.vb" Inherits="Nuevo_Evento" MasterPageFile="~/Site.master"  %>


<asp:Content runat ="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
  
    
    <div>
        <asp:Label ID="Evento" runat="server" Text="Evento"></asp:Label>
    </div>

    <div>

        <table class="nav-justified">
            <tr>
                <td style="width: 198px" class="modal-sm">&nbsp;</td>
                <td style="width: 198px" class="modal-sm">&nbsp;</td>
                <td style="width: 231px" class="modal-sm">&nbsp;</td>
                <td class="modal-sm" colspan="4">
                    &nbsp;</td>
                <td style="width: 237px">
                    &nbsp;</td>
                <td style="width: 426px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 198px" class="modal-sm">&nbsp;</td>
                <td style="width: 198px" class="modal-sm">&nbsp;</td>
                <td style="width: 231px" class="modal-sm">&nbsp;</td>
                <td class="modal-sm" colspan="4">
                    &nbsp;</td>
                <td style="width: 237px">
                    &nbsp;</td>
                <td style="width: 426px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 198px" class="modal-sm"><span style="font-weight: bold"> <p class="h1">Nombre </p> </span></td>
                <td style="width: 198px" class="modal-sm">&nbsp;</td>
                <td style="width: 231px" class="modal-sm">&nbsp;</td>
                <td class="modal-sm" colspan="4">
                    <asp:TextBox ID="txtNombreEvento" runat="server" Width="244px" CssClass="form-control input-lg"></asp:TextBox>
                </td>
                <td style="width: 237px">
                    &nbsp;</td>
                <td style="width: 426px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 198px" class="modal-sm"><span style="font-weight: bold">Descripción</span></td>
                <td style="width: 198px" class="modal-sm">&nbsp;</td>
                <td style="width: 231px" class="modal-sm">&nbsp;</td>
                <td class="modal-sm" colspan="4">
                    <asp:TextBox ID="txtDescripcionEvento" runat="server" Width="243px"></asp:TextBox>
                </td>
                <td style="width: 237px">
                    &nbsp;</td>
                <td style="width: 426px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 198px" class="modal-sm">&nbsp;</td>
                <td style="width: 198px" class="modal-sm">&nbsp;</td>
                <td style="width: 231px" class="modal-sm">&nbsp;</td>
                <td class="modal-sm" colspan="4">&nbsp;</td>
                <td style="width: 237px">
                    &nbsp;</td>
                <td style="width: 426px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 198px" class="modal-sm">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Hora del Evento"></asp:Label>
                </td>
                <td style="width: 198px" class="modal-sm">
                    <asp:CheckBox ID="cbRepitencia" runat="server" AutoPostBack ="true" />
                    <asp:Label ID="lblInfo" runat="server" Text="Se repite"></asp:Label>
                </td>
                <td style="width: 231px" class="modal-sm">
                    &nbsp;</td>
                <td colspan="2">
                    <asp:Label ID="lblFechaInicio" runat="server" Font-Bold="True" Text="Fecha Inicio"></asp:Label>
                </td>
                <td class="modal-sm" colspan="2">
                    <asp:TextBox ID="txtDatetimeInicio" runat="server" Width="180px" TextMode="DateTimeLocal" AutoPostBack="True" ></asp:TextBox>
                </td>
                <td style="width: 237px">
                    &nbsp;</td>
                <td style="width: 426px">
                    &nbsp;</td>
                <td style="width: 25px">
                    &nbsp;</td>
            </tr>
            <%--
                <asp:CompareValidator ID="cmpVal1" runat="server" ControlToCompare="txtDatetimeInicio"
                ControlToValidate="txtDatetimeFin" Type="Date" Operator="LessThan"
                ErrorMessage="EndDate must be greater than StartDate"
                ></asp:CompareValidator>

               --%>
            
            <tr>
                <td style="width: 198px" class="modal-sm">&nbsp;</td>
                <td style="width: 198px" class="modal-sm">&nbsp;</td>
                <td style="width: 231px" class="modal-sm">
                    &nbsp;</td>
                <td colspan="2">
                    <asp:Label ID="lblFechaFin" runat="server" Font-Bold="True" Text="Fecha Fin"></asp:Label>
                </td>
                <td class="modal-sm" colspan="2">
                    <asp:TextBox ID="txtDatetimeFin" runat="server" Width="188px" TextMode="DateTimeLocal" AutoPostBack="True"></asp:TextBox>
                </td>
                <td style="width: 237px">&nbsp;</td>
                <td style="width: 426px">
                    &nbsp;</td>
                <td style="width: 25px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 198px; height: 22px;"></td>
                <td style="width: 198px; height: 22px;">
                    <asp:Label ID="lblRepitencia" runat="server" Font-Bold="True" Text="Repitencia"></asp:Label>
                </td>
                <td style="width: 231px; height: 22px;"></td>
                <td style="height: 22px;" colspan="2"></td>
                <td style="height: 22px;">
                    <asp:Label ID="lblHoraRepitenciaInicio" runat="server" Font-Bold="True" Text="Inicio"></asp:Label>
                </td>
                <td style="height: 22px;">
                    <asp:Label ID="lblHoraRepitenciaFin" runat="server" Font-Bold="True" Text="Fin"></asp:Label>
                </td>
                <td style="width: 237px; height: 22px;"></td>
                <td style="height: 22px; width: 426px;"></td>
                <td style="height: 22px"></td>
            </tr>
            <tr>
                <td style="width: 198px; height: 20px;"></td>
                <td style="width: 198px; height: 20px;"></td>
                <td style="width: 231px; height: 20px;">
                    <asp:Label ID="lblRepetirCada" runat="server" Text="Repetir cada"></asp:Label>
                </td>
                <td style="width: 550px; height: 20px;">
                    <asp:TextBox ID="txtRepeticiones" runat="server" TextMode="Number" Width="70px">1</asp:TextBox>
                    <asp:DropDownList ID="ddlTipoRepitencia" runat="server" AutoPostBack ="true">
                        <asp:ListItem Selected="True">Días</asp:ListItem>
                        <asp:ListItem>Semanas</asp:ListItem>
                        <asp:ListItem>Meses</asp:ListItem>
                        <asp:ListItem>Años</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 291px; height: 20px;" colspan="2">
                    <asp:TextBox ID="txtHoraRepitenciaInicio" runat="server" TextMode="Time" Width="103px" AutoPostBack="True"></asp:TextBox>
                </td>
                <td style="width: 284px; height: 20px;">
                    <asp:TextBox ID="txtHoraRepitenciaFin" runat="server" TextMode="Time" AutoPostBack="True"></asp:TextBox>
                </td>
                <td style="width: 237px; height: 20px;">
                    </td>
                <td style="height: 20px; width: 426px;">
                    </td>
                <td style="height: 20px">
                    </td>
            </tr>
            <tr>
                <td style="width: 198px; height: 15px;"></td>
                <td style="width: 198px; height: 15px;"></td>
                <td style="width: 231px; height: 15px;">
                    <asp:Label ID="lblRepetirCada0" runat="server" Text="Se repite el"></asp:Label>
                </td>
                <td style="width: 550px; height: 15px;">
                    <asp:ListBox ID="lbxSemana" runat="server" SelectionMode="Multiple" Width="138px" Height="123px">
                        <asp:ListItem>Lunes</asp:ListItem>
                        <asp:ListItem>Martes</asp:ListItem>
                        <asp:ListItem>Miércoles</asp:ListItem>
                        <asp:ListItem>Jueves</asp:ListItem>
                        <asp:ListItem>Viernes</asp:ListItem>
                        <asp:ListItem>Sábado</asp:ListItem>
                        <asp:ListItem>Domingo</asp:ListItem>
                    </asp:ListBox>
                </td>
                <td style="height: 15px;" colspan="3">
                    &nbsp;</td>
                <td style="width: 237px; height: 15px;">
                    <asp:Label ID="lblTermina" runat="server" Text="Termina"></asp:Label>
                </td>
                <td style="height: 15px; width: 426px">
                    <asp:CheckBox ID="cbRepitenciaFecha" runat="server" AutoPostBack ="true" />
                    <asp:Label ID="lblRepitencia1" runat="server" Text="El"></asp:Label>
                </td>
                <td style="height: 15px">
                    <asp:TextBox ID="txtRepitenciaFechaFin" runat="server" TextMode="Date" AutoPostBack="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 198px; height: 20px;" class="modal-sm"></td>
                <td style="width: 198px; height: 20px;" class="modal-sm"></td>
                <td style="width: 231px; height: 20px;" class="modal-sm"></td>
                <td style="height: 20px;" class="modal-sm" colspan="4"></td>
                <td style="width: 237px; height: 20px;"></td>
                <td style="height: 20px; width: 426px">
                    <asp:CheckBox ID="cbRepitenciaVeces" runat="server" AutoPostBack ="true" />
                    <asp:Label ID="lblRepitencia2" runat="server" Text="Después de"></asp:Label>
                </td>
                <td style="height: 20px">
                    <asp:TextBox ID="txtBoxNumVeces" runat="server" Height="22px" TextMode="Number" Width="51px"></asp:TextBox>
                    <asp:Label ID="lblRepitencia3" runat="server" Text=" repeticiones"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 198px" class="modal-sm">&nbsp;</td>
                <td style="width: 198px" class="modal-sm">&nbsp;</td>
                <td style="width: 231px" class="modal-sm">&nbsp;</td>
                <td class="modal-sm" colspan="4">&nbsp;</td>
                <td style="width: 237px">&nbsp;</td>
                <td style="width: 426px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 198px" class="modal-sm">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Ubicación del Evento"></asp:Label>
                </td>
                <td style="width: 198px" class="modal-sm">
                    &nbsp;</td>
                <td style="width: 231px" class="modal-sm">
                    &nbsp;</td>
                <td class="modal-sm" colspan="4">
                    &nbsp;</td>
                <td style="width: 237px">
                    &nbsp;</td>
                <td style="width: 426px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>

            
        </table>

    </div>
    <asp:Label ID="Label2" runat="server" Text="Seleccione el Lugar"></asp:Label>
    <asp:DropDownList ID="ddlLugar" runat="server" DataSourceID="SqlDataSource1" DataTextField="NOM_LUGAR" DataValueField="ID_LUGAR" style="margin-bottom: 6">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AgendamientoConnectionString %>" SelectCommand="SELECT [NOM_LUGAR], [ID_LUGAR] FROM [LUGAR]"></asp:SqlDataSource>
    <br />
    <br />
    <hr />
    <div>

        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Large" Text="Invitados"></asp:Label>

    </div>

    


    <div>
        <table class="nav-justified">
            <tr>
                <td style="height: 20px; width: 488px">
                <asp:Label ID="lblInfo1" runat="server" Text="Ingrese correo de invitados"></asp:Label>  </td>
                <td style="height: 20px; width: 247px">  <asp:TextBox ID="txtInvitado" runat="server" Width="219px" TextMode="Email"></asp:TextBox>
                </td>
                <td style="height: 20px; width: 271px;">
                    <asp:Button ID="btnAgregarInvitado" runat="server" CssClass="col-xs-offset-0" Text="Agregar Invitado" />
                </td>
                <td style="height: 20px">
                        &nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 488px">&nbsp;</td>
                <td style="width: 247px">&nbsp;</td>
                <td>
                        <asp:Button ID="btnRetirarSeleccionados" runat="server" Text="Retirar Seleccionados" CssClass="col-xs-offset-0" Width="159px" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>

        <asp:CheckBoxList ID="cbxlInvitados" runat="server"></asp:CheckBoxList>
        </DIV>
        <hr />

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
                                        <div class="form-check">

                                            <input class="form-check-input form-control" type="checkbox" value="" id="cb<%=serv.id_Servicio %>_<%=recurso.nom_Recurso  %>" name="cb<%=serv.id_Servicio  %>_<%=recurso.id_recurso  %>"   >
                                            <% Dim rec As String = recurso.nom_Recurso  %>
                                        <h3><%:  rec   %> </h3>  <h5><%:  recurso.desc_recurso    %></h5>
                                        </div>


                                    </div>
                                    <div class="col">
                                        
                                        
                                         <input type="number" class="form-control" placeholder="Cantidad de recursos" id="txtCant_<%=serv.id_Servicio %>_<%=recurso.nom_Recurso  %>" name="txtCant_<%=serv.id_Servicio %>_<%=recurso.id_recurso   %>" aria-label="Username" aria-describedby="basic-addon1">
                                    </div>
                                    <div class="col">
                                        
                                       <input type="text" class="form-control" placeholder="Detalles" id="txtDesc_<%=serv.id_Servicio %>_<%=recurso.nom_Recurso  %>" name="txtDesc_<%=serv.id_Servicio %>_<%=recurso.id_recurso   %>" aria-label="Username" aria-describedby="basic-addon1"> 
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
                    <td style="height: 20px; width: 637px">

                        </td>
                    <td style="height: 20px; width: 990px;">
                        </td>
                </tr>
                <tr>
                    <td style="width: 637px">
               
                        &nbsp;</td>
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
