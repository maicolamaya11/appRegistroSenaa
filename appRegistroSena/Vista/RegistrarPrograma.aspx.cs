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
    public partial class RegistrarPrograma : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string programa = txtPrograma.Text.Trim();
            string ficha = txtFicha.Text.Trim();

            ClProgramasE objPrograma = new ClProgramasE();
            objPrograma.programa = txtPrograma.Text;
            objPrograma.ficha = txtFicha.Text;


            txtPrograma.Text = string.Empty;
            txtFicha.Text = string.Empty;


            ClProgramasL objProgramas = new ClProgramasL();
            int registro = objProgramas.mtdRegistroPrograma(objPrograma);


            if (registro == 1)
            {

                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Usuario No Registrado! ', 'Su usuario no ha Sido Registrado Con Exito', 'warning')", true);
            }
        }
    }
}