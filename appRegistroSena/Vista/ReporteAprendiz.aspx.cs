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
    public partial class ReporteAprendiz : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable tbUsuario = (DataTable)Session["ReporteAprendiz"];

                ReportDataSource rds = new ReportDataSource("DataSet", tbUsuario);
                rds.Name = "DataSet";
                rds.Value = tbUsuario;

                rvAprendiz.LocalReport.DataSources.Clear();
                rvAprendiz.LocalReport.DataSources.Add(rds);
                rvAprendiz.LocalReport.ReportPath = Server.MapPath("Reportes/ReportAprendiz.rdlc");

                rvAprendiz.DataBind();
                rvAprendiz.Visible = true;
            }
        }
    }
}