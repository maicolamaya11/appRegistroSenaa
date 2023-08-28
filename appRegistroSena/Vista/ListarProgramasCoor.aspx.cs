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
    public partial class ListarProgramasCoor : System.Web.UI.Page
    {
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
    }
}