using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Rutas
    {
        //Create
        public static string insert_Rutas(Rutas_VO ruta)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_InsertarRuta",
                    "@Camion_ID", ruta.Camion_ID,
                    "@Chofer_ID", ruta.Chofer_ID,
                    "@Distancia", ruta.Distancia,
                    "@Fecha_salida", ruta.Fecha_salida,
                    "@Fecha_llegadaestimada", ruta.Fecha_llegadaestimada,
                    "@Fecha_llegadareal", ruta.Fecha_llegadareal,
                    "@Direccionorigen_ID", ruta.Direccionorigen_ID,
                    "@Direcciondestino_ID", ruta.Direcciondestino_ID
                    );

                if (respuesta != 0)
                {
                    salida = "Ruta registrado con éxito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                salida = "Error: " + e.Message;
                salida = $"Error: {e.Message}";
            }
            return salida;
        }

        //Read
        public static List<Rutas_VO> Get_Rutas(params object[] parametros)
        {
            //creo una lista de objetox VO
            List<Rutas_VO> list = new List<Rutas_VO>();
            try
            {
                //creo un DataSet el cuál recibirá lo que devuelva la ejecución del método "execute_DataSet" de la clase "metodos_datos"
                DataSet ds_Rutas = metodos_datos.execute_DataSet("sp_ListarRutas", parametros);
                //recorro cada renglón existente de nuestro ds creando objetos del tipo VO y añadiendolos a la lista
                foreach (DataRow dr in ds_Rutas.Tables[0].Rows)
                {
                    list.Add(new Rutas_VO(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Update
        public static string actualizar_Rutas(Rutas_VO ruta)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_ActualizarCamion",
                    "@Camion_ID", ruta.Camion_ID,
                    "@Chofer_ID", ruta.Chofer_ID,
                    "@Distancia", ruta.Distancia,
                    "@Fecha_salida", ruta.Fecha_salida,
                    "@Fecha_llegadaestimada", ruta.Fecha_llegadaestimada,
                    "@Fecha_llegadareal", ruta.Fecha_llegadareal,
                    "@Direccionorigen_ID", ruta.Direccionorigen_ID,
                    "@Direcciondestino_ID", ruta.Direcciondestino_ID,
                    "@ID_Ruta", ruta.ID_Ruta
                    );

                if (respuesta != 0)
                {
                    salida = "Ruta actualizada con éxito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                salida = $"Error: {e.Message}";
            }
            return salida;
        }

        //Delete
        public static string eliminar_Rutas(int id)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_EliminarRuta",
                    "@ID_Ruta", id
                    );

                if (respuesta != 0)
                {
                    salida = "Ruta eliminada con éxito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                salida = $"Error: {e.Message}";
            }
            return salida;
        }
    }
}
