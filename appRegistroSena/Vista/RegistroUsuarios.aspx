<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Vigilante.Master" AutoEventWireup="true" CodeBehind="RegistroUsuarios.aspx.cs" Inherits="appRegistroSena.Vista.RegistroUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <!-- ===== Iconscout CSS ===== -->
    <link rel="stylesheet" href="https://unicons.iconscout.com/release/v4.0.0/css/line.css">

    <!-- ===== CSS ===== -->
    <link href="css/Estilos_RegistroUsuario.css" rel="stylesheet" />
    <script src="script.js"></script>
    <title>Registrar Usuario</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div class="containers" runat="server">
            <div class="forms">
                <div class="form login">
                    <span class="title">Registrar Usuario</span>

                    <div action="#">
                        <div class="input-field">
                            <input id="txtNombres" runat="server" type="text" placeholder="Nombres" required>
                            <i class="uil uil-envelope icon"></i>
                        </div>
                        <div class="input-field">
                            <input id="txtApellidos" runat="server" type="text" placeholder="Apellidos" required>
                            <i class="uil uil-envelope icon"></i>
                        </div>
                        <div class="input-field">
                            <input id="txtTelefono" runat="server" type="text" placeholder="Telefono" required>
                            <i class="uil uil-envelope icon"></i>
                        </div>
                        <div class="input-field">
                            <input id="txtEmail" runat="server" type="text" placeholder="Email" required>
                            <i class="uil uil-envelope icon"></i>
                        </div>
                        <div class="input-field">
                            <input id="txtClave" type="password" runat="server" class="password" placeholder="Contraseña" required>
                            <i class="uil uil-lock icon"></i>
                            <i class="uil uil-eye-slash showHidePw"></i>
                        </div>
                        <div class="input-field">
                            <input id="txtDocumento" runat="server" type="text" placeholder="Documento" required>
                            <i class="uil uil-envelope icon"></i>
                        </div>
                        <div class="input-field">
                            <asp:Label ID="Label1" runat="server" Text="Rol: "></asp:Label>
                            <select id="ddlRol" name="rol" runat="server">
                                <option value="Seleccionar Rol">Seleccionar Rol</option>
                                <option value="administrador">Administrador</option>
                                <option value="aprendiz">Aprendiz</option>
                                <option value="coordinador">Coordinador</option>
                            </select>
                        </div>

                        <div class="input-field button">
                            <asp:Button ID="btnRegistrar" type="button" value="Login" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
  
    </asp:Content>
    
        