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
    }
}