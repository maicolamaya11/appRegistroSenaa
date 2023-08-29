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
    public partial class ReporteRegistro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable tbPrograma = (DataTable)Session["ReporteRegistro"];

                ReportDataSource rds = new ReportDataSource("DataSet", tbPrograma);
                rds.Name = "DataSet";
                rds.Value = tbPrograma;

                RvRegistro.LocalReport.DataSources.Clear();
                RvRegistro.LocalReport.DataSources.Add(rds);
                RvRegistro.LocalReport.ReportPath = Server.MapPath("Reportes/ReportRegistro.rdlc");

                RvRegistro.DataBind();
                RvRegistro.Visible = true;
            }
        }
    }
}