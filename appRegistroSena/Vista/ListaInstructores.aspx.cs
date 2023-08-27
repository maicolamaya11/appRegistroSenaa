using appRegistroSena.Entidades;
using appRegistroSena.Logica;
using Newtonsoft.Json;
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
                List<ClPersonalE> listaPersonal = objPersonalL.mtdListarInstructor();
                string Json = JsonConvert.SerializeObject(listaPersonal, Newtonsoft.Json.Formatting.Indented);
                ClientScript.RegisterStartupScript(GetType(), "JsonScript", $"var jsonData = {Json};", true);
            }
        }
    }
    }
