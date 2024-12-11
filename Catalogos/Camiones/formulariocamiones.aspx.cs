using BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace Transportes_3Capas_Gen13.Catalogos.Camiones
{
    public partial class formulariocamiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //valido si es Postback
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                {
                    //Voy a insertar
                    Titulo.Text = "Agregar Camión";
                    subTitulo.Text = "Registro de un nuevo camión";
                    lbldisponibilidad.Visible = false;
                    chkdisponibilidad.Visible = false;
                    imgfoto.Visible = false;
                    lblurlfoto.Visible = false;
                }
                else
                {
                    //Voy a Actualizar
                    //Recupero el ID que proviene de la URL
                    int _id = Convert.ToInt32(Request.QueryString["Id"]);
                    //obtengo el objeto original de la BD y coloco sus valores en os campos correspondientes
                    Camiones_VO _camion_original = BLL_Camiones.Get_Camiones("@ID_Camion", _id)[0];
                    //valido que realmente obtenga el objeto y sus valores, de lo contrario, me regreso al formulario
                    if (_camion_original.ID_Camion != 0)
                    {
                        //si encontré el Camión y coloco sus valores
                        Titulo.Text = "Actualizar camión";
                        subTitulo.Text = $"Modificar los datos del camión #{_id}";
                        txtmatricula.Text = _camion_original.Matricula;
                        txtcapacidad.Text = _camion_original.Capacidad.ToString();
                        txtkilometraje.Text = _camion_original.Kilometraje.ToString();
                        txttipo.Text = _camion_original.Tipo_Camion.ToString();
                        txtmarca.Text = _camion_original.Marca;
                        txtmodelo.Text = _camion_original.Modelo;
                        chkdisponibilidad.Checked = _camion_original.Disponibilidad;
                        imgfoto.ImageUrl = _camion_original.UrlFoto;
                    }
                    else
                    {
                        //no encontré el objeto y me voy pa' tras
                        Response.Redirect("listado_camiones.aspx");
                    }
                }
            }
        }

        protected void btnsubeimagen_Click(object sender, EventArgs e)
        {
            //este método sirve para guardar y almacenar la imagen en el servidor y posteriormente recuperar la info desde la BD

            if (subeimagen.Value != "")
            {
                //recupero el nombre del archivo
                string filename = Path.GetFileName(subeimagen.Value);
                //valido la extención del archivo
                string fileExt = Path.GetExtension(filename).ToLower();
                if ((fileExt != ".jpg") && (fileExt != ".png"))
                {
                    //Sweet Alert
                }
                else
                {
                    //verifico que existe el directorio en el servidor, para poder almacenar la imagen, de lo contrario, procedo a crearlo
                    string pathdir = Server.MapPath("~/Imagenes/Camiones/");
                    //~ (virgulilla) hace referencia a la dirección completa del servidor, independientemenete de donde esté instalado, permitiendo que la validicación funciones en diferentes entornos

                    //si no existe el directorio, lo creamos
                    if (!Directory.Exists(pathdir))
                    {
                        //creo el directorio
                        Directory.CreateDirectory(pathdir);
                    }

                    //subo la imagen a la carpeta del servidor
                    subeimagen.PostedFile.SaveAs(pathdir + filename);
                    //recuperamos la ruta de la URL que almacenaremos en la BD
                    string urlfoto = "/Imagenes/Camiones/" + filename;
                    //mostramos en pantalla la URL creada
                    this.urlfoto.Text = urlfoto;
                    //mostramos la imagen
                    imgcamion.ImageUrl = urlfoto;
                    //Sweet Alert
                }
            }
            else
            {
                //Sweet Alert
            }
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            string titulo = "", respuesta = "", tipo = "", salida = "";
            try
            {
                //creamos el objeto que enviaremos para actualizar o insertar a las BD
                //existen 2 formas de instanciar y llenar un objeto
                //forma 1 (por atributos)
                Camiones_VO _camion_aux = new Camiones_VO();
                _camion_aux.Matricula = txtmatricula.Text;
                _camion_aux.Marca = txtmarca.Text;
                _camion_aux.Tipo_Camion = txttipo.Text;
                _camion_aux.Modelo = txtmodelo.Text;
                _camion_aux.Capacidad = Convert.ToInt32(txtcapacidad.Text);
                _camion_aux.Kilometraje = Convert.ToDouble(txtkilometraje.Text);
                _camion_aux.UrlFoto = imgcamion.ImageUrl;
                _camion_aux.Disponibilidad = chkdisponibilidad.Checked;
                //forma 2 (durante la propia intancia)
                Camiones_VO _camion_aux_2 = new Camiones_VO()
                {
                    Matricula = txtmatricula.Text,
                    Marca = txtmarca.Text,
                    Tipo_Camion = txttipo.Text,
                    Modelo = txtmodelo.Text,
                    Capacidad = Convert.ToInt32(txtcapacidad.Text),
                    Kilometraje = Convert.ToDouble(txtkilometraje.Text),
                    UrlFoto = imgcamion.ImageUrl
                };
                //decido si voy a insertar o actualizar
                if (Request.QueryString["Id"] == null)
                {
                    //Voy a insertar
                    _camion_aux.Disponibilidad = true;
                    salida = BLL_Camiones.insert_Camion(_camion_aux);
                }
                else
                {
                    //Actualizar
                    _camion_aux.ID_Camion = int.Parse(Request.QueryString["Id"]);
                    salida = BLL_Camiones.actualizar_Camion(_camion_aux);
                }
                //preparamos la salida para cachar un error y mostra el Sweeet Alert
                if (salida.ToUpper().Contains("ERROR")) { } else { }
            }
            catch (Exception ex)
            {
                titulo = "Error";
                respuesta = ex.Message;
                tipo = "error";
            }
            //sweet alert
        }
    }
}