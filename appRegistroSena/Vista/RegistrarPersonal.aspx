<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Administrador.Master" AutoEventWireup="true" CodeBehind="RegistrarPersonal.aspx.cs" Inherits="appRegistroSena.Vista.RegistrarPersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/RegistrarPersonal.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="registration-container">
        <div class="registration-image">
            <img src="Imagenes/senacentro.png" alt="Imagen de Registro">
        </div>
        <div class="registration-form">
            <h2>Registro Personal</h2>
            <asp:TextBox ID="txtDocumento" runat="server" placeholder="Documento"></asp:TextBox>
            <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre"></asp:TextBox>
            <asp:TextBox ID="txtApellid0" runat="server" placeholder="Apellido"></asp:TextBox>
            
             <asp:Label ID="Label1" runat="server" Text="Rol: "></asp:Label>
                        <select id="ddlRol" name="rol" runat="server">
                            <option value="Seleccionar Rol">Seleccionar Rol</option>
                            <option value="Instructor">Instructor</option>
                            <option value="aprendiz">Aprendiz</option>
                          
                        </select>
            <asp:DropDownList ID="ddlPrograma" runat="server"></asp:DropDownList>
            <br />
            <br />
                <button type="submit">Registrarse</button>
            
        </div>
    </div>
</asp:Content>
