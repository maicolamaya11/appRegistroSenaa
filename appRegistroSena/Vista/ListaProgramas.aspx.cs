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
    public partial class ListaProgramas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClUsuarioL objServicio = new ClUsuarioL();
            List<ClProgramasE> lista = objServicio.mtdListarProgramas();
            gvProgramas.DataSource = lista;

            gvProgramas.DataBind();
        }

        protected void btnGuardar_Click2(object sender, EventArgs e)
        {
            string busqueda = txtBusqueda.Value.Trim();

            if (!string.IsNullOrEmpty(busqueda))
            {
                ClUsuarioL objServicio = new ClUsuarioL();
                List<ClProgramasE> lista = objServicio.mtdBuscarProgramas(busqueda);

                ClPersonalL objProgramas = new ClPersonalL();
                List<ClPersonalE> listaP = objProgramas.mtdListarVigilante();

                if (lista.Count > 0)
                {
                    gvProgramas.DataSource = lista;
                    gvProgramas.DataBind();
                    gvProgramas.Visible = true;


                }
                else
                {
                    gvProgramas.Visible = false;

                }

                if (listaP != null)
                {
                    Session["programa"] = listaP;
                    Session["Personal"] = lista;
                }

            }
        }

        public DataTable ConvertirTabla(List<ClProgramasE> lista, List<ClPersonalE> listaPrograma)
        {
            DataTable tabla = new DataTable();

            tabla.Columns.Add("idPrograma", typeof(int));
            tabla.Columns.Add("programa", typeof(string));
            tabla.Columns.Add("ficha", typeof(string));
            tabla.Columns.Add("jornada", typeof(string));

            for (int i = 0; i < lista.Count; i++)
            {
                ClProgramasE Programa = lista[i];
                ClPersonalE personal = listaPrograma.FirstOrDefault(c => c.idPrograma == Programa.idPrograma);
                tabla.Rows.Add(Programa.idPrograma,
                    Programa.programa,
                    Programa.ficha,
                    Programa.jornada);
            }
            return tabla;
        }

        protected void btnImprimir_Click1(object sender, EventArgs e)
        {
            List<ClProgramasE> listaVigilante = (List<ClProgramasE>)Session["programa"];
            List<ClProgramasE> listaPr = (List<ClProgramasE>)Session["programa"];
            


        }
    }
}
