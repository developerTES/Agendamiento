<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <table style="width: 75%;" align="center">
        <tr>
            <td align="center">
                <img src="img/EscudoFEI.jpg" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Image ID="imgProceso" runat="server" ImageUrl="~/img/progress_bar.gif" 
                    Visible="False" />
            </td>
        </tr>
        <tr>
            <td align="center">
            </td>
        </tr>
        <tr>
            <td align="center">
                User-Usuario
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:TextBox runat="server" ID="txtUsuario" Font-Names="Calibri" Font-Size="12pt"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center">
                Password-Contraseña
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:TextBox runat="server" ID="txtPassword" Font-Names="Calibri" Font-Size="12pt"
                    TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center">
                <br />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnLogin" runat="server" Text="Login" />
                <br />
                <input type="button" id="btnAddToCart"/>
                <input type="button" id="theBtn" onclick="ShowText()" value="Go" />
                
                <script type="text/javascript">
        function ShowText() {
            PageMethods.GetText("Hola Mundo", OnSuccess);
        }
        function OnSuccess(response) {
            alert(response);
        }
    </script>
                <asp:Label ID="lblPath" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;<img alt="" src="img/imgBarraPeq.png" />
            </td>
        </tr>
        <tr>
            <td align="center">
                Agendamiento</td>
        </tr>
    </table>

 
   <script type="text/javascript">

        $(function () {
            $('#btnAddToCart').click(function () {
                alert("Hola Mundo")
                var result = $.ajax({
                    type: "POST",
                    url: "Default.aspx/AddProductToCart",
                    data: '{ pID: "1833" }',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: succeeded,
                    failure: function (msg) {
                        alert(msg);
                    },
                    error: function (xhr, err) {
                        alert(err);
                    }
                });
            });
        });

        function succeeded(msg) {
            alert(msg.d);
        }
    
    </script>

    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#theBtn").click(function () {
                $.post({
                    url: 'Default.aspx/GetData',
                    type: 'POST',
                    //using get all textbox selector-you can use a different selector
                    data: '{"ID": "5" }',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data, textStatus, jQxhr) {
                        //don't forget the .d
                        alert("sssss " + data.textStatus);
                        alert("sssss " + data);
                        console.log("Exito")
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        console.log(errorThrown);
                    }
                });
            })
        })
    </script>
    

</asp:Content>
