<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Administrador.Master" AutoEventWireup="true" CodeBehind="RegistrarPrograma.aspx.cs" Inherits="appRegistroSena.Vista.RegistrarPrograma" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8">
    <title>Registrar Servicio</title>
    <link href="css/Estilos_RegistrarPrograma.css" rel="stylesheet" />
    <!-- Fontawesome CDN Link -->
    <script src="https://kit.fontawesome.com/e5246dcec8.js" crossorigin="anonymous"></script>
    <script src="SweetAlert/Scripts/sweetalert.min.js"></script>
    <link href="SweetAlert/Styles/sweetalert.css" rel="stylesheet" />

    <meta name="viewport" content="width=device-width, initial-scale=1.0">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <input type="checkbox" id="flip">
        <div class="cover">
            <div class="front">
                <img src="Imagenes/14590066_686015764883572_4190911499130567525_o.jpg" alt="">
                <div class="text">
                    <span class="text-1">Registrar Programa
                        <br>
                        De Formación.</span>
                    <span class="text-2">En el siguiente formulario se puede realizar un registro de los programas que no se encuentren registrados.</span>
                </div>
            </div>
        </div>
        <div class="forms">
            <div class="form-content">
                <div class="login-form">
                    <div class="title">Registrar Programa</div>
                    <div action="#">
                        <div class="input-boxes">
                            <div class="input-box">
                                <i class="fa-solid fa-screwdriver-wrench"></i>
                                <asp:TextBox ID="txtPrograma" placeholder="Ingresar Nombre Programa" runat="server"></asp:TextBox>
                            </div>
                            <div class="input-box">
                                <i class="fa-solid fa-screwdriver-wrench"></i>
                                <asp:TextBox ID="txtFicha" placeholder="Ingresar Numero Ficha" runat="server"></asp:TextBox>
                            </div>
                            <div class="input-box">
                                <i class="fa-solid fa-screwdriver-wrench"></i>
                                <asp:TextBox ID="txtJornada" placeholder="Ingresar Jornada" runat="server"></asp:TextBox>
                            </div>
                            <div class="button input-box">
                                <asp:Button ID="Button1" runat="server" Text="Registrar" OnClick="Button1_Click1"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
