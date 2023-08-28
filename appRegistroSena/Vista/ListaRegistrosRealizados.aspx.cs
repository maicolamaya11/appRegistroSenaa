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

        public static List<ClRegistroE> mtdCargarDatos(int idRegistro)
        {
            ClRegistroL objRegistro = new ClRegistroL();
            List<ClRegistroE> Registro = objRegistro.mtdRegistroCodigo(idRegistro);
            if (Registro.Count > 0)
            {
                return Registro;
            }
            return null;
        }

        [WebMethod]
        public static string mtdActualizarPersonal(object data)
        {
            ClRegistroL objPersonalL = new ClRegistroL();
            ClRegistroE objActualizarPersonal = new ClRegistroE();

            var datos = data as IDictionary<string, object>;

            objActualizarPersonal.codigo = datos["codigo"].ToString();
            objActualizarPersonal.estado = datos["estado"].ToString();
            objActualizarPersonal.fechaIngreso = datos["fechaIngreso"].ToString();
            objActualizarPersonal.horaIngreso = datos["horaIngreso"].ToString();
            objActualizarPersonal.fechaSalida = datos["fechaSalida"].ToString();
            objActualizarPersonal.horaSalida = datos["horaSalida"].ToString();
            objActualizarPersonal.documentoPerson = datos["documentoPerson"].ToString();
            objActualizarPersonal.nombrePort = datos["nombrePort"].ToString();


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

            var data = formData as IDictionary<string, object>;
            objEliminarPersonal.idRegistro = int.Parse(data["idRegistro"].ToString());


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