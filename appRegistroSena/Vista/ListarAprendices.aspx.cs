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
    public partial class ListarAprendices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClProgramasL objPrograma = new ClProgramasL();
                List<ClProgramasE> listaProgramas = new List<ClProgramasE>();
                listaProgramas = objPrograma.mtdLlistarPrograma();
                ddlPrograma.DataSource = listaProgramas;
                ddlPrograma.DataTextField = "programa";
                ddlPrograma.DataValueField = "idPrograma";
                ddlPrograma.DataBind();
                ddlPrograma.Items.Insert(0, new ListItem("Seleccione:", "0"));

            }
            if (!IsPostBack)
            {
                ClPersonalL objPersonalL = new ClPersonalL();
                List<ClPersonalE> listaPersonal = objPersonalL.mtdListarAprendices();
                string Json = JsonConvert.SerializeObject(listaPersonal, Newtonsoft.Json.Formatting.Indented);
                ClientScript.RegisterStartupScript(GetType(), "JsonScript", $"var jsonData = {Json};", true);
            }
        }
        [WebMethod]
        public static List<ClPersonalE> mtdCargarDatos(int idPersonal)
        {
            ClPersonalL objRegistro = new ClPersonalL();
            List<ClPersonalE> Registro = objRegistro.mtdRegistroPersonal(idPersonal);
            if (Registro.Count > 0)
            {
                return Registro;
            }
            return null;
        }
        [WebMethod]
        public static string mtdActualizarAprendiz(object data)
        {
            ClPersonalL objPersonalL = new ClPersonalL();
            ClPersonalE objActualizarPersonal = new ClPersonalE();

            var datos = data as IDictionary<string, object>;

            objActualizarPersonal.nombres = datos["nombres"].ToString();
            objActualizarPersonal.apellidos = datos["apellidos"].ToString();
            objActualizarPersonal.documento = datos["documento"].ToString();
            objActualizarPersonal.idPrograma= int.Parse(datos["idPrograma"].ToString());
            

            int resultado = objPersonalL.mtdEditarP(objActualizarPersonal);

            return "success"; // Devuelve una respuesta al cliente
        }
        [WebMethod]
        public static List<ClPersonalE> mtdListar()
        {
            ClPersonalL objPersonalL = new ClPersonalL();
            List<ClPersonalE> listaPersonal = objPersonalL.mtdListarAprendices();

            return listaPersonal;
        }
    }
}