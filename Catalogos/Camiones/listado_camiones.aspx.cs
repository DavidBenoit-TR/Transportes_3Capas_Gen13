﻿using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Transportes_3Capas_Gen13.Utilidades;

namespace Transportes_3Capas_Gen13.Catalogos.Camiones
{
    public partial class listado_camiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //utilizamos la variable "IsPostBack" para controlar la primera vez que carga la página
            if (!IsPostBack)
            {
                cargarGrid();
            }
        }

        public void cargarGrid()
        {
            //cargar la información desde la BLL al GV
            GVCamiones.DataSource = BLL_Camiones.Get_Camiones();
            //mostramos los resultados renderizando la información
            GVCamiones.DataBind();
        }

        protected void Insertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("formulariocamiones.aspx");
        }

        protected void GVCamiones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //recupero el ID del renglón afectado
            int id_camion = int.Parse(GVCamiones.DataKeys[e.RowIndex].Values["ID_Camion"].ToString());
            //invoco mi método para eliminar mi camión
            string respuesta = BLL_Camiones.eliminar_Camion(id_camion);
            //preparamos el Sweet Alert
            string titulo, msg, tipo;
            if (respuesta.ToUpper().Contains("ERROR"))
            {
                titulo = "Error";
                msg = respuesta;
                tipo = "error";
            }
            else
            {
                titulo = "Correcto!";
                msg = respuesta;
                tipo = "success";
            }

            //sweet alert
            //debemos importar el usign de "using <NOMBRE_DE_TU_PROYECTO>.Utilidades;"
            sweetAlert.Sweet_Alert(titulo, msg, tipo, this.Page, this.GetType());
            //recargamos la página
            cargarGrid();
        }
        protected void GVCamiones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //defino si el comando (el click que se detecta) tiene la propiedad "Select"
            if (e.CommandName == "Select")
            {
                //recupero el índice en función de aqule elemnto que haya detonado el evento
                int varIndex = int.Parse(e.CommandArgument.ToString());
                //recupero el ID en función del índice que recuperamos anterormente
                string id = GVCamiones.DataKeys[varIndex].Values["ID_Camion"].ToString();
                //redirecciono al formulario de edición pasando como parámetro el ID
                Response.Redirect($"formulariocamiones.aspx?Id={id}");
            }
        }

        protected void GVCamiones_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GVCamiones_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GVCamiones_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }
    }
}