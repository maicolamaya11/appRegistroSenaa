using appRegistroSena.Entidades;
using appRegistroSena.Logica;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appRegistroSena.Vista
{
    public partial class Lista : System.Web.UI.Page
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



                if (!IsPostBack)
                {
                    ClPersonalL objPersonalL = new ClPersonalL();
                    List<ClPersonalE> listaPersonal = objPersonalL.mtdListarInstructor();
                    string Json = JsonConvert.SerializeObject(listaPersonal, Newtonsoft.Json.Formatting.Indented);
                    ClientScript.RegisterStartupScript(GetType(), "JsonScript", $"var jsonData = {Json};", true);

                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string busqueda = txtBusqueda.Value.Trim();

            //if (!string.IsNullOrEmpty(busqueda))
            //{
            //    ClUsuarioL objServicio = new ClUsuarioL();
            //    List<ClUsuarioE> lista = objServicio.mtdBuscarInstructor(busqueda);

            //    ClUsuarioL objProgramas = new ClUsuarioL();
            //    List<ClProgramasE> listaP = objProgramas.mtdListarProgramas();

            //    if (lista.Count > 0)
            //    {
                    //gvInstructor.DataSource = lista;
                    //gvInstructor.DataBind();
                    //gvInstructor.Visible = true;


            //    }
            //    else
            //    {
            //        //gvInstructor.Visible = false;

            //    }

            //    if (listaP != null)
            //    {
            //        Session["programa"] = listaP;
            //        Session["Instructor"] = lista;
            //    }

            //}

        }

        public DataTable ConvertirTabla(List<ClUsuarioE> lista, List<ClProgramasE> listaPrograma)
        {
            DataTable tabla = new DataTable();

            tabla.Columns.Add("idUsuario", typeof(int));
            tabla.Columns.Add("nombre", typeof(string));
            tabla.Columns.Add("apellido", typeof(string));
            tabla.Columns.Add("telefono", typeof(string));
            tabla.Columns.Add("email", typeof(string));
            tabla.Columns.Add("documento", typeof(string));
            tabla.Columns.Add("programa", typeof(string));
            tabla.Columns.Add("ficha", typeof(string));
            tabla.Columns.Add("jornada", typeof(string));

            for (int i = 0; i < lista.Count; i++)
            {
                ClUsuarioE Usuario = lista[i];
                ClProgramasE programas = listaPrograma.FirstOrDefault(c => c.idPrograma == Usuario.idPrograma);
                tabla.Rows.Add(Usuario.idUsuario,
                    Usuario.nombre,
                    Usuario.apellido,
                    Usuario.telefono,
                    Usuario.email,
                    Usuario.documento,
                    programas != null ? programas.ficha : string.Empty,
                    programas != null ? programas.programa : string.Empty,
                    programas != null ? programas.jornada : string.Empty);
            }
            return tabla;
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            List<ClUsuarioE> listaUsuario = (List<ClUsuarioE>)Session["Instructor"];
            List<ClProgramasE> listaPrograma = (List<ClProgramasE>)Session["programa"];

            DataTable dtUsuarios = ConvertirTabla(listaUsuario, listaPrograma);

            Session["ReporteInstructor"] = dtUsuarios;
            Response.Redirect("ReporteInstructor.aspx");
        }


    }


}

