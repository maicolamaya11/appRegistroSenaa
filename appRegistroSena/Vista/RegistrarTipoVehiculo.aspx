<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Vigilante.Master" AutoEventWireup="true" CodeBehind="RegistrarTipoVehiculo.aspx.cs" Inherits="appRegistroSena.Vista.RegistrarTipoVehiculo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/RegistroObjeto.css" rel="stylesheet" />
    <script src="JavaScript/RegistrarObjeto.js"></script>
    <link href="css/Buscar.css" rel="stylesheet" />
    <script type="module" src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.esm.js"></script>
    <script nomodule src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.js"></script>
    <link href="css/Buscar.css" rel="stylesheet" />
    <script src="SweetAlert/Scripts/sweetalert.min.js"></script>
    <link href="SweetAlert/Styles/sweetalert.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main">
        <div class="containers a-containers" id="a-containers">
            <div class="form" id="a-form" action="#">
                <h2 class="form_title title">Registrar Vehiculos</h2>
                <div class="buscar-caja">
                    <asp:TextBox ID="txtBuscar" class="buscar-txt" runat="server" placeholder="Buscar"></asp:TextBox>
                    <asp:Button ID="btnBuscar" class="buscar-btn" runat="server" Text="" OnClick="btnBuscar_Click" /><i class="far fa-search"></i>
                </div>
                <asp:DropDownList ID="ddlPorteria" class="form__input" runat="server"></asp:DropDownList>
                <asp:DropDownList ID="ddlPersonal" class="form__input" runat="server"></asp:DropDownList>
                <asp:TextBox ID="txtNombre" class="form__input" runat="server" placeholder="Nombre" ReadOnly="true"></asp:TextBox>
                <asp:TextBox ID="txtApellido" class="form__input" runat="server" placeholder="Apellido" ReadOnly="true"></asp:TextBox>
                <asp:DropDownList ID="ddlTipoVehiculo" class="form__input" runat="server"></asp:DropDownList>
                <asp:TextBox ID="txtPlaca" class="form__input" runat="server" placeholder="Placa"></asp:TextBox>
                <asp:TextBox ID="txtColor" class="form__input" runat="server" placeholder="Color"></asp:TextBox>
                <asp:TextBox ID="txtMarca" class="form__input" runat="server" placeholder="Marca"></asp:TextBox>

                <asp:Button ID="btnRegistrar" class="switch__button button submit" runat="server" Text="Registrar" OnClick="btnRegistrar_Click"/>
            </div>
        </div>
        <div class="containers b-containers" id="b-containers">

            <div class="switch" id="switch-cnt">
                <div class="switch__circle"></div>

                <div class="switch__circle switch__circle--t"></div>
                <div class="switch__container" id="switch-c1">
                    <img src="Imagenes/Logosimbolo-SENA-PRINCIPAL.png" alt="Sena" />
                </div>
            </div>
        </div>
    </div>

    <script>
        document.addEventListener("DOMContentLoaded", function () {
            var dropdown = document.getElementById('<%= ddlTipoVehiculo.ClientID %>');
                var textbox = document.getElementById('<%= txtPlaca.ClientID %>');

                dropdown.addEventListener("change", function () {
                    var selectedValue = dropdown.value;

                    if (selectedValue === "Bicicleta") {
                        textbox.style.display = "none"; // Muestra el TextBox
                    } else {
                        textbox.style.display = "block"; // Oculta el TextBox
                    }
                });
            });
    </script>

</asp:Content>
