using appRegistroSena.Entidades;
using appRegistroSena.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Web.Services;

namespace appRegistroSena.Vista
{
    public partial class ListaRegistrosRealizados : System.Web.UI.Page
    {
        ClRegistroL objProgramasL = new ClRegistroL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClRegistroL objPersonalL = new ClRegistroL();
                List<ClSalidaE> listaPersonal = objPersonalL.mtdListarRegistros();
                string Json = JsonConvert.SerializeObject(listaPersonal, Newtonsoft.Json.Formatting.Indented);
                ClientScript.RegisterStartupScript(GetType(), "JsonScript", $"var jsonData = {Json};", true);
            }
        }

        [WebMethod]
        public static List<ClSalidaE> mtdListar()
        {
            ClRegistroL objPersonalL = new ClRegistroL();
            List<ClSalidaE> listaPersonal = objPersonalL.mtdListarRegistros();

            return listaPersonal;
        }
        [WebMethod]
        public static int cargardatos(int idRegistro)
        {

            var Page = HttpContext.Current.Handler as ListaRegistrosRealizados;
            int id = Page.objProgramasL.mtdActualizacion(idRegistro);
            return id;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ClSalidaL objSalidaL = new ClSalidaL();
            ClSalida1E objDatos = new ClSalida1E();

            objDatos.estado = txtEstado.Text;
            objDatos.observacion = txtObservacion.Text;

            int registro = objSalidaL.mtdIngresarSalida(objDatos);

            ClRegistroL objPersonalL = new ClRegistroL();
            ClSalidaE objActualizarPersonal = new ClSalidaE();

            int idRegistro = int.Parse(txtDato.Text);
            int resultado = objPersonalL.mtdActualizacion(idRegistro);

            if (resultado >= 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('¡Actualizar Salida!', 'Se ha Actualizado la Salida " + objActualizarPersonal.codigo + "', 'success')", true);
            }
        }
    }
}