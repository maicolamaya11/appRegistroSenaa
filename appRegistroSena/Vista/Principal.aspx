<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Principal.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="appRegistroSena.Vista.Principal1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/PaginaInicio.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <!-- Carousel Start -->
    <div class="container-fluid p-0 mb-5 pb-5">
        <div id="header-carousel" class="carousel slide carousel-fade" data-ride="carousel">
          
            <div class="carousel-inner">
                <div class="carousel-item position-relative active" style="min-height: 100vh;">
                    <img class="position-absolute w-100 h-100" src="Imagenes/senacentro.png" style="object-fit: cover;">
                    <div class="carousel-caption d-flex flex-column align-items-center justify-content-center">
                        <div class="p-3" style="max-width: 900px;">
                            <h6 class="text-white text-uppercase mb-3 animate__animated animate__fadeInDown" style="letter-spacing: 3px;">Pagina de Registros</h6>
                            <h3 class="display-3 text-capitalize text-white mb-3">Vehicular y Peatonal</h3>
                            <p class="mx-md-5 px-5">Desde aqui podras registrar el ingreso y salida de cualquier herramienta o vehiculo particulr dale click al boton para iniciar</p>
                            <a class="btn btn-outline-light py-3 px-4 mt-3 animate__animated animate__fadeInUp" href="Login.aspx">Comienza</a>
                        </div>
                    </div>
                </div>
               
            </div>
        </div>
    </div>
    <!-- Carousel End -->
</asp:Content>
