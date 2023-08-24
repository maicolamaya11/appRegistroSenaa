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
    public partial class RegObjeto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClPorteriaL objPorteriaL = new ClPorteriaL();
                List<ClPorteriaE> listaPorteria = objPorteriaL.mtdListarServicio();

                ddlPorteria.DataSource = listaPorteria;
                ddlPorteria.DataTextField = "nombrePorteria";
                ddlPorteria.DataValueField = "idPorteria";
                ddlPorteria.DataBind();
            }
            
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string documento = txtBuscar.Text;
            ClPersonalL objPersonalL = new ClPersonalL();
            List<ClPersonalE> listaPersonal = objPersonalL.mtdBuscar(documento);

            ddlPersonal.DataSource = listaPersonal;
            ddlPersonal.DataTextField = "documento";
            ddlPersonal.DataValueField = "idPersonal";
            ddlPersonal.DataBind();

            txtNombre.Text = listaPersonal[0].nombres;
            txtApellido.Text = listaPersonal[0].apellidos;
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            ClRegistroE objDatos = new ClRegistroE();
            //objDatos.horaIngreso = DateTime.Now;
            objDatos.horaSalida = "";
            objDatos.idPersonal = 1;
            objDatos.idPorteria = int.Parse(ddlPorteria.SelectedValue.ToString());
            objDatos.idUsuario = 1;

            ClRegistroL objRegistroL = new ClRegistroL();
            int resultado = objRegistroL.mtdRegistrar(objDatos);

            if (resultado == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Usuario No Registrado! ', 'Su usuario no ha Sido Registrado Con Exito', 'warning')", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Registrado Exitososamente! ', 'Su usuario ha Sido Registrado', 'success')", true);
            }
        }
    }
}