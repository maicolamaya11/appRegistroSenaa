using appRegistroSena.Entidades;
using appRegistroSena.Logca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appRegistroSena.Vista
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string documento = txtDocumento.Text;
            string contraseña = txtContraseña.Text;


            ClUsuarioL objUsuarioL = new ClUsuarioL();
            ClUsuarioE objDatosU = objUsuarioL.mtdDatosLogin(documento, contraseña);
            //ClCoachL objCoachL = new ClCoachL();
            //ClCoachE objDatosC = objCoachL.mtdDatosLogin(documento, contraseña);

            if (objDatosU != null)

            {
                Session["Usuario"] = objDatosU.nombre + " " + objDatosU.apellido;
                Session["id"] = objDatosU.idUsuario;
                Response.Redirect("~/Vista/Index.aspx");
            }
            //else if (objDatosC != null)
            //{
            //    Session["Coach"] = objDatosC.nombre + " " + objDatosC.apellido;
            //    Session["id"] = objDatosC.idCoach;
            //    Response.Redirect("~/Vista/editarCoach.aspx");
            //}

            else
            {
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Usuario o Contraseña incorrectos');", true);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Usuario o Contraseña incorrectos')", true);
            }
        }
    }
}