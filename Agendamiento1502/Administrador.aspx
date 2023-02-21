<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Administrador.aspx.vb" Inherits="Administrador" MasterPageFile="~/Site.master" Title="Opciones de administrador" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Title %></h1>

    <hr />


    <br />
    <div class="container ">

        <div class="row">
            <h2>Servicio y Recursos</h2>
            <hr />
        </div>
        <div class="row ms-5">
            <div class="col-3">
                <br />
                <h4>
                    <label for="lblServicio">Seleccione un servicio    </label>
                </h4>
                <asp:DropDownList ID="ddlServicios" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="NOM_SERVICIO" DataValueField="ID_SERVICIO" CssClass="form-select">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AgendamientoConnectionString %>" SelectCommand="SELECT [ID_SERVICIO], [NOM_SERVICIO] FROM [SERVICIO]"></asp:SqlDataSource>
                <br />
                <br />
            </div>
            <div class="col-3">
                <br />
                <asp:Button ID="linkbtnRegistrarNuevoServicio" runat="server" Text="Registrar Servicio" Width="160px" type="submit" CssClass="btn btn-outline-success " />
                <asp:Button ID="btnEditarServicio" runat="server" Text="Editar Servicio" Width="160px" type="submit" CssClass="btn btn-outline-success " />
            </div>

        </div>


        <div class="row ms-7">
            <div class="col-3">
                <h4>
                    <asp:Label ID="lblListaRecursos" runat="server" Text="Lista de Recursos"></asp:Label></h4>
            </div>
            <div class="col">
                <asp:Button ID="linkbtnNuevoRecurso" runat="server" Text="Registrar Recurso" Width="160px" type="submit" CssClass="btn btn-outline-success " data-bs-toggle="modal" data-bs-target="#staticBackdrop" />
            </div>

        </div>
        <br />
        <br />
        <div class="row ms-5">
            <br />
            <br />
            <asp:GridView ID="gvRecursos" runat="server" Width="951px"></asp:GridView>

            <table class="table table-striped">
                <thead>
                    <tr>

                        <th scope="col">Opciones</th>
                        <th scope="col">Nombre Recurso</th>
                        <th scope="col">Descripción</th>

                    </tr>
                </thead>
                <tbody>
                    <%For each r As Recurso In Session("recursos") %>
                    <tr>
                        <td>
                            <asp:LinkButton ID="linkBtnEditar" runat="server" OnClick="linkbtnNuevoRecurso_Click" CommandArgument='<%:r.id_recurso%>'>Editar</asp:LinkButton></td>
                        <td><%:r.nom_Recurso  %></td>
                        <td><%:r.desc_recurso   %></td>
                    </tr>
                    <%next %>
                </tbody>
            </table>

        </div>

    </div>
    <br />
    <br />
    <br />
    <div class="container ">

        <div class="row">
            <div class="col-1">
                <h2>Lugares</h2>
            </div>
            <div class="col-1">
                <asp:Button ID="linkbtnRegistrarNuevoLugar" runat="server" Text="Nuevo Lugar" Width="160px" type="submit" CssClass="btn btn-outline-success " />
                
            </div>

            <hr />
        </div>
        <div class="row ms-5">
            <asp:GridView ID="gvLugares" runat="server" Width="955px">
            </asp:GridView>
            <table class="table table-striped">
                <thead>
                    <tr>

                        <th scope="col">Opciones</th>
                        <th scope="col">Nombre Lugar</th>
                        <th scope="col">Descripción</th>

                    </tr>
                </thead>
                <tbody>
                    <%For each l As Lugar In Session("lugares") %>
                    <tr>
                        <%Dim idLugar = l.id_lugar  %>
                        <td>
                            <asp:LinkButton ID="linkBtnEditarLugar" runat="server" OnClick="linkbtnNuevoRecurso_Click" CommandArgument='<%:l.id_lugar%>'>Editar</asp:LinkButton></td>

                        <td><%:l.nom_lugar   %></td>
                        <td><%:l.descr_lugar    %></td>
                    </tr>
                    <%next %>
                </tbody>
            </table>
        </div>




    </div>


    <hr />


<!-- Modal -->
<div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h1 class="modal-title fs-5" id="exampleModalLabel">Modal title</h1>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        ...
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>
    </div>
  </div>
</div>


</asp:Content>

