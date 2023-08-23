<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="appRegistroSena.Vista.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="css/Login.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
                <div class="login-container">
                    <img src="Imagenes/Imagen1.png" />
                    <h2>Iniciar sesión</h2>

                    <asp:TextBox ID="txtDocumento" runat="server" class="login-input" placeholder="Usuario" required></asp:TextBox>
                    <asp:TextBox ID="txtContraseña" runat="server" CssClass="login-input" placeholder="Contraseña" TextMode="Password" required></asp:TextBox>
                    <asp:Button ID="btnIngresar"  class="login-button" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />

                    </div>

                      </center>


        </div>
    </form>
</body>
</html>
