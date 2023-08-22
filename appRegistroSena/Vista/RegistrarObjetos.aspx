<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarObjetos.aspx.cs" Inherits="appRegistroSena.Vista.RegistrarObjetos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="css/RegistroObjeto.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container">

                <h2>Login</h2>

                <div class="form">
                    <div class="material">
                        <input type="text" required="required"/>
                        <span class="borda"></span>
                        <label>Usuário</label>
                    </div>
                    <div class="material">
                        <input type="password" required="required"/>
                        <span class="borda"></span>
                        <label>Senha</label>
                    </div>

                    <h3 id="test">Primeiro Acesso?</h3>
                    <a class="btn" href="#">Registrar</a>

                    <label class="material-checkbox">
                        <input type="checkbox"/>
                        <span>Lembrar senha?</span>
                        <div class="nova-senha">
                            <span>Esqueceu a senha?</span>
                        </div>
                    </label>

                    <div class="botao-acessar">
                        <button>Acessar</button>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
