using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appRegistroSena.Vista
{
    public partial class ReportePrograma : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable tbPrograma = (DataTable)Session["ReportePrograma"];

                ReportDataSource rds = new ReportDataSource("DataSet", tbPrograma);
                rds.Name = "DataSet";
                rds.Value = tbPrograma;

                RvPrograma.LocalReport.DataSources.Clear();
                RvPrograma.LocalReport.DataSources.Add(rds);
                RvPrograma.LocalReport.ReportPath = Server.MapPath("Reportes/ReportPrograma.rdlc");

                RvPrograma.DataBind();
                RvPrograma.Visible = true;
            }
        }
    }
}