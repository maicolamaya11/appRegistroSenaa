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
    public partial class ReporteInstructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable tbUsuario = (DataTable)Session["ReporteInstructor"];

                ReportDataSource rds = new ReportDataSource("DataSet", tbUsuario);
                rds.Name = "DataSet";
                rds.Value = tbUsuario;

                rvInstructores.LocalReport.DataSources.Clear();
                rvInstructores.LocalReport.DataSources.Add(rds);
                rvInstructores.LocalReport.ReportPath = Server.MapPath("Reportes/ReportInstructor.rdlc");

                rvInstructores.DataBind();
                rvInstructores.Visible = true;
            }
        }
    }
}