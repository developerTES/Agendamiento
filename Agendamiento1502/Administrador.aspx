<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Administrador.aspx.vb" Inherits="Administrador" MasterPageFile="~/Site.master" Title="Opciones de administrador" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr />
 
    <div>

        <table class="nav-justified">
            <tr>
                <td class="modal-lg" style="width: 160px">&nbsp;</td>
                <td class="modal-sm" style="width: 299px">
                    <asp:Label ID="lblServyRecursos" runat="server" Font-Bold="True" Font-Size="Large" Text="Servicio y Recursos"></asp:Label>
                </td>
                <td style="width: 197px">&nbsp;</td>
                <td style="width: 264px">&nbsp;</td>
                <td style="width: 228px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>

    </div>

    <div>

     

        <table class="nav-justified">
            <tr>
                <td class="modal-lg" style="width: 162px; height: 73px">
                    &nbsp;</td>
                <td class="modal-lg" style="width: 293px; height: 73px">
                    <asp:Label ID="lblInfoServicio" runat="server" Text="Seleccione un servicio "></asp:Label>
                </td>
                <td style="height: 73px; width: 197px">
                    <asp:DropDownList ID="ddlServicios" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="NOM_SERVICIO" DataValueField="ID_SERVICIO" Height="37px" Width="166px">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AgendamientoConnectionString %>" SelectCommand="SELECT [ID_SERVICIO], [NOM_SERVICIO] FROM [SERVICIO]"></asp:SqlDataSource>
                </td>
                <td style="height: 73px; width: 270px">
                </td>
                <td style="height: 73px; width: 226px">
                    <asp:LinkButton ID="linkbtnRegistrarNuevoServicio" runat="server">Registrar Nuevo Servicio</asp:LinkButton>
                </td>
                <td style="height: 73px"></td>
            </tr>
            <tr>
                <td class="modal-lg" style="width: 162px; height: 20px">&nbsp;</td>
                <td class="modal-lg" style="width: 293px; height: 20px">&nbsp;</td>
                <td style="height: 20px; width: 197px">&nbsp;</td>
                <td style="height: 20px; width: 270px">&nbsp;</td>
                <td style="height: 20px; width: 226px">&nbsp;</td>
                <td style="height: 20px">&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-lg" style="width: 162px; height: 20px">&nbsp;</td>
                <td class="modal-lg" style="width: 293px; height: 20px">
                    <asp:Label ID="lblNomServicio" runat="server" Font-Bold="True" Text="Servicio"></asp:Label>
                </td>
                <td style="height: 20px; width: 197px">
                    <asp:LinkButton ID="linkbtnNuevoRecurso" runat="server">Nuevo recurso</asp:LinkButton>
                </td>
                <td style="height: 20px; width: 270px">&nbsp;</td>
                <td style="height: 20px; width: 226px">&nbsp;</td>
                <td style="height: 20px">&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-lg" style="width: 162px; height: 20px">&nbsp;</td>
                <td class="modal-lg" style="width: 293px; height: 20px">&nbsp;</td>
                <td style="height: 20px; width: 197px">&nbsp;</td>
                <td style="height: 20px; width: 270px">&nbsp;</td>
                <td style="height: 20px; width: 226px">&nbsp;</td>
                <td style="height: 20px">&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-lg" style="width: 162px; height: 20px">&nbsp;</td>
                <td class="modal-lg" style="height: 20px" colspan="4">
                    <asp:Label ID="lblListaRecursos" runat="server" Text="Lista de Recursos"></asp:Label>
                </td>
                <td style="height: 20px">&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-lg" style="width: 162px; height: 20px">&nbsp;</td>
                <td class="modal-lg" style="width: 293px; height: 20px">&nbsp;</td>
                <td style="height: 20px; width: 197px">&nbsp;</td>
                <td style="height: 20px; width: 270px">&nbsp;</td>
                <td style="height: 20px; width: 226px">&nbsp;</td>
                <td style="height: 20px">&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-lg" style="width: 162px; height: 69px"></td>
                <td class="modal-lg" style="height: 69px" colspan="4">
                    <asp:GridView ID="gvRecursos" runat="server" Width="951px">
                    </asp:GridView>
                </td>
                <td style="height: 69px"></td>
            </tr>
            <tr>
                <td class="modal-lg" style="width: 162px; height: 20px">&nbsp;</td>
                <td class="modal-lg" style="width: 293px; height: 20px">&nbsp;</td>
                <td style="height: 20px; width: 197px">&nbsp;</td>
                <td style="height: 20px; width: 270px">&nbsp;</td>
                <td style="height: 20px; width: 226px">&nbsp;</td>
                <td style="height: 20px">&nbsp;</td>
            </tr>
            </table>

 
        <hr />

        <div>

     

        <table class="nav-justified">
            <tr>
                <td class="modal-lg" style="width: 162px; height: 20px">&nbsp;</td>
                <td class="modal-lg" style="width: 293px; height: 20px">
                    <asp:Label ID="lblServyRecursos0" runat="server" Font-Bold="True" Font-Size="Large" Text="Lugares"></asp:Label>
                </td>
                <td style="height: 20px; width: 197px">&nbsp;</td>
                <td style="height: 20px; width: 270px">
                    <asp:LinkButton ID="linkbtnRegistrarNuevoLugar" runat="server">Registrar Nuevo Lugar</asp:LinkButton>
                </td>
                <td style="height: 20px; width: 200px">&nbsp;</td>
                <td style="height: 20px">&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-lg" style="width: 162px; height: 20px">&nbsp;</td>
                <td class="modal-lg" style="width: 293px; height: 20px">
                    &nbsp;</td>
                <td style="height: 20px; width: 197px">&nbsp;</td>
                <td style="height: 20px; width: 270px">&nbsp;</td>
                <td style="height: 20px; width: 200px">&nbsp;</td>
                <td style="height: 20px">&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-lg" style="width: 162px; height: 20px">&nbsp;</td>
                <td class="modal-lg" style="width: 293px; height: 20px">
                    &nbsp;</td>
                <td style="height: 20px; width: 197px">&nbsp;</td>
                <td style="height: 20px; width: 270px">&nbsp;</td>
                <td style="height: 20px; width: 200px">&nbsp;</td>
                <td style="height: 20px">&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-lg" style="width: 162px; height: 20px">&nbsp;</td>
                <td class="modal-lg" colspan="4" rowspan="2">
                    <asp:GridView ID="gvLugares" runat="server" Width="955px">
                    </asp:GridView>
                </td>
                <td style="height: 20px">&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-lg" style="width: 162px; height: 20px">&nbsp;</td>
                <td style="height: 20px">&nbsp;</td>
            </tr>
            </table>

        </div>


    </div>
    
</asp:Content>

