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
    public partial class ReporteVigilante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable tbVigilante = (DataTable)Session["ReporteVigilante"];

                ReportDataSource rds = new ReportDataSource("DataSet", tbVigilante);
                rds.Name = "DataSet";
                rds.Value = tbVigilante;

                RvVigilante.LocalReport.DataSources.Clear();
                RvVigilante.LocalReport.DataSources.Add(rds);
                RvVigilante.LocalReport.ReportPath = Server.MapPath("Reportes/ReportVigilante.rdlc");

                RvVigilante.DataBind();
                RvVigilante.Visible = true;
            }
        }
    }
}