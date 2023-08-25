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
    public partial class ListaInstructores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClUsuarioL objServicio = new ClUsuarioL();
            List<ClUsuarioE> lista = objServicio.mtdListarInstructor();
            gvInstructor.DataSource = lista;

            gvInstructor.DataBind();
        }
    }
}