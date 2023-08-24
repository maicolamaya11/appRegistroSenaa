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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClRegistroL objPersonalL = new ClRegistroL();
                List<ClRegistroE> listaPersonal = objPersonalL.mtdListarRegistros();
                string Json = JsonConvert.SerializeObject(listaPersonal, Newtonsoft.Json.Formatting.Indented);
                ClientScript.RegisterStartupScript(GetType(), "JsonScript", $"var jsonData = {Json};", true);
            }
        }

        [WebMethod]
        public static List<ClRegistroE> mtdCargarDatos(int Codigo)
        {
            ClRegistroL objRegistro = new ClRegistroL();
            List<ClRegistroE> Registro = objRegistro.mtdListarRegistros();
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
            objActualizarPersonal.documentoPerson = datos["documento"].ToString();
            objActualizarPersonal.nombrePort = datos["nombrePorteria"].ToString();
            objActualizarPersonal.documentoUsua = datos["documento"].ToString();

            int resultado = objPersonalL.mtdActualizacion(objActualizarPersonal);

            return "success"; // Devuelve una respuesta al cliente
        }

        [WebMethod]
        public static List<ClRegistroE> mtdListar()
        {
            ClRegistroL objPersonalL = new ClRegistroL();
            List<ClRegistroE> listaPersonal = objPersonalL.mtdListarRegistros();

            return listaPersonal;
        }

        [WebMethod]
        public static string mtdEliminar(object formData)
        {
            ClRegistroL objPersonal = new ClRegistroL();
            ClRegistroE objEliminarPersonal = new ClRegistroE();

            var data = formData as IDictionary<string, object>;
            objEliminarPersonal.codigo = data["codigo"].ToString();

            int resultado = objPersonal.mtdEliminar(objEliminarPersonal);
            return string.Empty;
        }
    }
}