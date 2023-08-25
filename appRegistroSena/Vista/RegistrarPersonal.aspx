<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Administrador.Master" AutoEventWireup="true" CodeBehind="RegistrarPersonal.aspx.cs" Inherits="appRegistroSena.Vista.RegistrarPersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/RegistrarPersonal.css" rel="stylesheet" />
    <script src="SweetAlert/Scripts/sweetalert.min.js"></script>
    <link href="SweetAlert/Styles/sweetalert.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="registration-container">
        <div class="registration-image">
            &nbsp;<img src="Imagenes/senacentro.png" alt="Imagen de Registro"></div>
        <div class="registration-form">
            <h2>Registro Personal</h2>
            <asp:TextBox ID="txtDocumento" runat="server" class="login-input" placeholder="Documento" required="" onkeypress="return isNumberKey(event) && isMaxLength(event)"></asp:TextBox>

<script>
    function isNumberKey(event) {
        var charCode = (event.which) ? event.which : event.keyCode;
        if (charCode > 31 && (charCode < 48 || charCode > 57)) {
            return false;
        }
        return true;
    }

    function isMaxLength(event) {
        var maxDigits = 10;
        var inputValue = document.getElementById('<%= txtDocumento.ClientID %>').value;

        if (inputValue.length >= maxDigits) {
            event.preventDefault();
            return false;
        }

        return true;
    }
</script>
            <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre" required=""></asp:TextBox>
            <asp:TextBox ID="txtApellido" runat="server" placeholder="Apellido" required=""></asp:TextBox>
            
            
             <asp:Label ID="Label1" runat="server" Text="Rol: "></asp:Label>
                        <select id="ddlRol" name="rol" runat="server" >
                            <option value="Seleccionar Rol">Seleccionar Rol</option>
                            <option value="Instructor">Instructor</option>
                            <option value="aprendiz">Aprendiz</option>
                          
                        </select>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Programa: " ></asp:Label>
            <asp:DropDownList ID="ddlPrograma" runat="server"></asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnRegistrarse" runat="server" Text="Registrarse" type="submit" onclick="btnRegistrarse_Click"/>
                
            
        </div>
    </div>
</asp:Content>
