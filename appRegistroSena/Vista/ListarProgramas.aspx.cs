using appRegistroSena.Entidades;
using appRegistroSena.Logica;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appRegistroSena.Vista
{
    public partial class ListarProgramas : System.Web.UI.Page
    {
        ClProgramasL objProgramasL = new ClProgramasL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClProgramasL objProgramaL = new ClProgramasL();
                List<ClProgramasE> listaPersonal = objProgramaL.mtdListarPrograma();
                string Json = JsonConvert.SerializeObject(listaPersonal, Newtonsoft.Json.Formatting.Indented);
                ClientScript.RegisterStartupScript(GetType(), "JsonScript", $"var jsonData = {Json};", true);
            }
        }
        [WebMethod]
        public static List<ClProgramasE> mtdListar()
        {
            ClProgramasL objProgramaL = new ClProgramasL();
            List<ClProgramasE> listaProgramas = objProgramaL.mtdListarPrograma();

            return listaProgramas;
        }
        [WebMethod]
        public static List<ClProgramasE> cargardatos(int idProgramas)
        {
            
            var Page = HttpContext.Current.Handler as ListarProgramas;
            List<ClProgramasE> list = Page.objProgramasL.mtdIdPersonal(idProgramas);
            return list;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ClProgramasL objDatosL = new ClProgramasL();
            ClProgramasE obDatos = new ClProgramasE();
            obDatos.idPrograma = int.Parse(txtDato.Text);
            obDatos.programa = txtPrograma.Text;
            obDatos.ficha = txtFicha.Text;
            obDatos.jornada = txtJornada.Text;
           
            int Actualizar = objDatosL.mtdActualizar(obDatos);
            if (Actualizar >= 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('¡Actualizar Producto!', 'Se ha Actualizado el producto " + obDatos.programa + "', 'success')", true);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ClProgramasL objDatosL = new ClProgramasL();
            ClProgramasE obDatos = new ClProgramasE();
            int Eliminar = objDatosL.mtdEliminar(int.Parse(txtDato.Text));
            if (Eliminar == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('¡Eliminar Producto!', 'Se ha Eliminado el producto " + obDatos.programa + "', 'warning')", true);
            }
        }
    }
}