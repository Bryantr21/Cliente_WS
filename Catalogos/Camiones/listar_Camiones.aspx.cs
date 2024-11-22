using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cliente_WS.Camiones_Service;
using Cliente_WS.Utilidades;

namespace Cliente_WS.Catalogos.Camiones
{
    public partial class listar_Camiones : System.Web.UI.Page
    {
        camiones_ServiceSoapClient camiones_Client_WS;
        protected void Page_Load(object sender, EventArgs e)
        {
            camiones_Client_WS = new camiones_ServiceSoapClient();

            if (!IsPostBack)
            {
                cargarGrid();

            }
        }
        public void cargarGrid()
        {
            //carga info desde bll al gv
            GVCamiones.DataSource = camiones_Client_WS.GetCamiones(new ArrayOfAnyType { });
            GVCamiones.DataBind();
        }
        protected void Insertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("fornulariocamiones.aspx");
        }

        protected void GVCamiones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int varIndex = int.Parse(e.CommandArgument.ToString());
                String id = camiones_Client_WS.DataKeys[varIndex].Values["Id_Camion"].ToString();
                Response.Redirect($"fornulariocamiones.aspx?Id={id}");

            }
        }

        protected void GVCamiones_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVCamiones.EditIndex = e.NewEditIndex;
            cargarGrid();
        }

        protected void GVCamiones_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int idcamion = int.Parse(GVCamiones.DataKeys[e.RowIndex].Values["Id_Camion"].ToString());
            string matricula = e.NewValues["Matricula"].ToString();
            string Tipocamion = e.NewValues["Tipo_camion"].ToString();
            string Foto = e.NewValues["UrlFoto"].ToString();
            CheckBox chaux = (CheckBox)GVCamiones.Rows[e.RowIndex].FindControl("chkEditDisponible");
            bool disponibilidad = chaux.Checked;
            Camiones_VO _camion = camiones_Client_WS.GetCamiones(new ArrayOfAnyType { "@Id_Camion", idcamion })[0];
            Camiones_VO _camionAux = new Camiones_VO();
            _camionAux.Id_Camion = idcamion;
            _camionAux.Matricula = matricula;
            _camionAux.Disponibilidad = disponibilidad;
            _camionAux.Tipo_Camion = Tipocamion;
            _camionAux.UrlFoto = Foto;
            _camionAux.Marca = _camion.Marca;
            _camionAux.Modelo = _camion.Modelo;
            _camionAux.Capacidad = _camion.Capacidad;
            _camionAux.Kilometraje = _camion.Kilometraje;
            //sweetAlert
            string respuesta = "";
            string titulo, msg, tipo;
            try
            {
                respuesta = camiones_Client_WS.ActualizarCamion(_camionAux);
                if (respuesta.ToUpper().Contains("Error"))
                {
                    titulo = "Error";
                    msg = respuesta;
                    tipo = "error";
                }
                else
                {
                    titulo = "Correcto";
                    msg = respuesta;
                    tipo = "success";
                }
            }
            catch (Exception ex)
            {
                titulo = "Opss..";
                msg = ex.Message;
                tipo = "error";
            }
        }

        protected void GVCamiones_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVCamiones.EditIndex = -1;
            cargarGrid();
        }

        protected void GVCamiones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idcamion = int.Parse(GVCamiones.DataKeys[e.RowIndex].Values["Id_Camion"].ToString());
            string respuesta = camiones_Client_WS.EliminarCamion(idcamion);
            string titulo, msg, tipo;
            if (respuesta.ToUpper().Contains("Error"))
            {
                titulo = "Error";
                msg = respuesta;
                tipo = "error";
            }
            else
            {
                titulo = "Correcto";
                msg = respuesta;
                tipo = "success";
            }
            sweetAlert.Sweet_Alert(titulo, msg, tipo, this.Page, this.GetType());
            cargarGrid();
        }
    }
}