using appRegistroSena.Entidades;
using appRegistroSena.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appRegistroSena.Vista
{
    public partial class RegistrarPersonal : System.Web.UI.Page
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

            }
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            ClPersonalE objPersonalE = new ClPersonalE();
            objPersonalE.nombres = txtNombre.Text;
            objPersonalE.apellidos = txtApellido.Text;
            objPersonalE.documento = txtDocumento.Text;
            objPersonalE.rol = ddlRol.SelectedIndex.ToString();
            objPersonalE.idPrograma = int.Parse(ddlPrograma.SelectedValue.ToString());



            ClPersonalL objPersonalL = new ClPersonalL();
            int registro = objPersonalL.mtdRegistroPersonal(objPersonalE);


            if (registro > 0)
            {

                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Registrado Exitososamente! ', 'Su usuario ha sido Registrado', 'success')", true);
            }
        }
    }
}