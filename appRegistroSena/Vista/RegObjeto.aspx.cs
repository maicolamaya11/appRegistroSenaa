using appRegistroSena.Entidades;
using appRegistroSena.Logica;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace appRegistroSena.Vista
{
    public partial class RegObjeto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClPorteriaL objPorteriaL = new ClPorteriaL();
                List<ClPorteriaE> listaPorteria = objPorteriaL.mtdListarServicio();

                ddlPorteria.DataSource = listaPorteria;
                ddlPorteria.DataTextField = "nombrePorteria";
                ddlPorteria.DataValueField = "idPorteria";
                ddlPorteria.DataBind();


               
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            string documento = txtBuscar.Text;
            ClPersonalL objPersonalL = new ClPersonalL();
            List<ClPersonalE> listaPersonal = objPersonalL.mtdBuscar(documento);

            ddlPersonal.DataSource = listaPersonal;
            ddlPersonal.DataTextField = "documento";
            ddlPersonal.DataValueField = "idPersonal";
            ddlPersonal.DataBind();



            txtNombre.Text = listaPersonal[0].nombres;
            txtApellido.Text = listaPersonal[0].apellidos;


        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            ClTipoObjetoE objDatos1 = new ClTipoObjetoE();
            objDatos1.nombre = txtNombreTipo.Text;
            objDatos1.cantidad = int.Parse(txtCantidad.Text);
            objDatos1.observaciones = txtObservaciones.Text;

            try
            {
                // TODO: Add insert logic here
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:44338/api/TipoObjeto");
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string jsonProducto = JsonConvert.SerializeObject(objDatos1);
                    var content = new StringContent(jsonProducto, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = httpClient.PostAsync("https://localhost:44338/api/TipoObjeto", content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Registrado Exitososamente! ', 'Su usuario ha Sido Registrado', 'success')", true);
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Usuario No Registrado! ', 'Su usuario no ha Sido Registrado Con Exito', 'warning')", true);

                    }
                }

            }
            catch
            {

            }


            ClRegistroE objDatos = new ClRegistroE();


            objDatos.estado = "Pendiente";
            //objDatos.idSalida = 0;
            objDatos.idPersonal = int.Parse(ddlPersonal.SelectedValue.ToString());
            objDatos.idPorteria = int.Parse(ddlPorteria.SelectedValue.ToString());
            objDatos.idUsuario = 1;

            ClRegistroL objRegistroL = new ClRegistroL();
            int resultado = objRegistroL.mtdRegistrar(objDatos);

            if (resultado == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Usuario No Registrado! ', 'Su usuario no ha Sido Registrado Con Exito', 'warning')", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Registrado Exitososamente! ', 'Su usuario ha Sido Registrado', 'success')", true);
            }

            //RegistrarServicio.ServicioSoapClient servicio = new RegistrarServicio.ServicioSoapClient();
            

        }
    }
}