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
    public partial class ListaRegistros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClRegistroL objServicio = new ClRegistroL();
            List<ClRegistroE> lista = objServicio.mtdListaRegistros();
            gvRegistro.DataSource = lista;

            gvRegistro.DataBind();
        }

        protected void btnGuardar_Click1(object sender, EventArgs e)
        {
            string busqueda = txtBusqueda.Value.Trim();

            if (!string.IsNullOrEmpty(busqueda))
            {
                ClRegistroL objUsuario = new ClRegistroL();
                List<ClRegistroE> lista = objUsuario.mtdBuscarRegistro(busqueda);

                ClUsuarioL objProgramas = new ClUsuarioL();
                List<ClUsuarioE> listaP = objProgramas.mtdListarAprendices();

                if (lista.Count > 0)
                {
                    gvRegistro.DataSource = lista;
                    gvRegistro.DataBind();
                    gvRegistro.Visible = true;


                }
                else
                {
                    gvRegistro.Visible = false;

                }

                if (listaP != null)
                {
                    Session["usuario"] = listaP;
                    Session["Registro"] = lista;
                }

            }
        }
        public DataTable ConvertirTabla(List<ClRegistroE> lista, List<ClUsuarioE> listaPrograma)
        {
            DataTable tabla = new DataTable();

            tabla.Columns.Add("idRegistro", typeof(string));
            tabla.Columns.Add("codigo", typeof(string));
            tabla.Columns.Add("fechaIngreso", typeof(string));
            tabla.Columns.Add("nombrePorteria", typeof(string));
            tabla.Columns.Add("documento", typeof(string));
            tabla.Columns.Add("documentoP", typeof(string));

            for (int i = 0; i < lista.Count; i++)
            {
                ClRegistroE Registro = lista[i];
                ClUsuarioE programas = listaPrograma.FirstOrDefault(c => c.idUsuario == Registro.idUsuario);
                tabla.Rows.Add(Registro.idRegistro,
                    Registro.codigo,
                    Registro.fechaIngreso,
                    Registro.nombrePort,
                    Registro.documentoUsua,
                    Registro.documentoPerson);
                //programas != null ? programas.ficha : string.Empty,
                //    programas != null ? programas.programa : string.Empty,
                //    programas != null ? programas.jornada : string.Empty);
            }
            return tabla;
        }

        protected void btnImprimir_Click1(object sender, EventArgs e)
        {
            List<ClRegistroE> listaUsuario = (List<ClRegistroE>)Session["Registro"];
            List<ClUsuarioE> listaPrograma = (List<ClUsuarioE>)Session["usuario"];

            DataTable dtUsuarios = ConvertirTabla(listaUsuario, listaPrograma);

            Session["ReporteRegistro"] = dtUsuarios;
            Response.Redirect("ReporteRegistro.aspx");
        }
    }
}

