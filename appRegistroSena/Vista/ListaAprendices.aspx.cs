using appRegistroSena.Entidades;
using appRegistroSena.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appRegistroSena.Vista
{
    public partial class ListaAprendices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClUsuarioL objServicio = new ClUsuarioL();
            List<ClUsuarioE> lista = objServicio.mtdListarAprendices();
            gvAprendiz.DataSource = lista;

            gvAprendiz.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string busqueda = txtBusqueda.Value.Trim();

            if (!string.IsNullOrEmpty(busqueda))
            {
                ClUsuarioL objUsuario = new ClUsuarioL();
                List<ClUsuarioE> lista = objUsuario.mtdBuscarAprendiz(busqueda);

                ClUsuarioL objProgramas = new ClUsuarioL();
                List<ClProgramasE> listaP = objProgramas.mtdListarProgramas();

                if (lista.Count > 0)
                {
                    gvAprendiz.DataSource = lista;
                    gvAprendiz.DataBind();
                    gvAprendiz.Visible = true;


                }
                else
                {
                    gvAprendiz.Visible = false;

                }

                if (listaP != null)
                {
                    Session["programa"] = listaP;
                    Session["Aprendiz"] = lista;
                }

            }
        }

        public DataTable ConvertirTabla(List<ClUsuarioE> lista, List<ClProgramasE> listaPrograma)
        {
            DataTable tabla = new DataTable();

            tabla.Columns.Add("idUsuario", typeof(string));
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
                    Usuario.ficha,
                    Usuario.programa,
                    Usuario.jornada);
                //programas != null ? programas.ficha : string.Empty,
                //    programas != null ? programas.programa : string.Empty,
                //    programas != null ? programas.jornada : string.Empty);
            }
            return tabla;
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            List<ClUsuarioE> listaUsuario = (List<ClUsuarioE>)Session["Aprendiz"];
            List<ClProgramasE> listaPrograma = (List<ClProgramasE>)Session["programa"];

            DataTable dtUsuarios = ConvertirTabla(listaUsuario, listaPrograma);

            Session["ReporteAprendiz"] = dtUsuarios;
            Response.Redirect("ReporteAprendiz.aspx");
        }
    }
}