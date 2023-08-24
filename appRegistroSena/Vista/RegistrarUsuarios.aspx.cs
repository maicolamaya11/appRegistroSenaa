using appRegistroSena.Entidades;
using appRegistroSena.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appRegistroSena.Vista
{
    public partial class RegistrarUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombres = txtNombres.Value.Trim();
            string apellidos = txtApellidos.Value.Trim();
            string telefono = txtTelefono.Value.Trim();
            string email = txtEmail.Value.Trim();
            string clave = txtClave.Value.Trim();
            string documento = txtDocumento.Value.Trim();

            ClUsuarioE objUsuario = new ClUsuarioE();
            objUsuario.nombre = txtNombres.Value;
            objUsuario.apellido = txtApellidos.Value;
            objUsuario.telefono = txtTelefono.Value;
            objUsuario.email = txtEmail.Value;
            objUsuario.clave = txtClave.Value;
            objUsuario.documento = txtDocumento.Value;
            objUsuario.rol = ddlRol.SelectedIndex.ToString();


            txtNombres.Value = string.Empty;
            txtApellidos.Value = string.Empty;
            txtTelefono.Value = string.Empty;
            txtEmail.Value = string.Empty;
            txtClave.Value = string.Empty;
            txtDocumento.Value = string.Empty;
            ddlRol.SelectedIndex = 0;

            ClUsuarioL objUsuarios = new ClUsuarioL();
            int registro = objUsuarios.mtdRegistroUsuario(objUsuario);


            if (registro == 1)
            {


            }
        }
    }
}
