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
    public partial class ListaVigilantes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClPersonalL objServicio = new ClPersonalL();
            List<ClPersonalE> lista = objServicio.mtdListarVigilante();
            gvVigilante.DataSource = lista;

            gvVigilante.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string busqueda = txtBusqueda.Value.Trim();

            if (!string.IsNullOrEmpty(busqueda))
            {
                ClPersonalL objServicio = new ClPersonalL();
                List<ClPersonalE> lista = objServicio.mtdBuscarVigilante(busqueda);

                ClUsuarioL objProgramas = new ClUsuarioL();
                List<ClProgramasE> listaP = objProgramas.mtdListarProgramas();

                if (lista.Count > 0)
                {
                    gvVigilante.DataSource = lista;
                    gvVigilante.DataBind();
                    gvVigilante.Visible = true;


                }
                else
                {
                    gvVigilante.Visible = false;

                }

                if (listaP != null)
                {
                    Session["programa"] = listaP;
                    Session["Personal"] = lista;
                }

            }
        }

        public DataTable ConvertirTabla(List<ClPersonalE> lista, List<ClProgramasE> listaPrograma)
        {
            DataTable tabla = new DataTable();

            tabla.Columns.Add("idPersonal", typeof(int));
            tabla.Columns.Add("nombres", typeof(string));
            tabla.Columns.Add("apellidos", typeof(string));
            tabla.Columns.Add("documento", typeof(string));

            for (int i = 0; i < lista.Count; i++)
            {
                ClPersonalE Personal = lista[i];
                ClProgramasE programas = listaPrograma.FirstOrDefault(c => c.idPrograma == Personal.idPrograma);
                tabla.Rows.Add(Personal.idPersonal,
                    Personal.nombres,
                    Personal.apellidos,
                    Personal.documento);
            }
            return tabla;
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            List<ClPersonalE> listaVigilante = (List<ClPersonalE>)Session["Personal"];
            List<ClProgramasE> listaPrograma = (List<ClProgramasE>)Session["programa"];

            DataTable dtUsuarios = ConvertirTabla(listaVigilante, listaPrograma);

            Session["ReporteVigilante"] = dtUsuarios;
            Response.Redirect("ReporteVigilante.aspx");
        }
    }
}