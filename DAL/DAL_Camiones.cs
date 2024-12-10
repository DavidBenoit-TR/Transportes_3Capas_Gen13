using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Camiones
    {
        //Create

        //Read
        public static List<Camiones_VO> Get_Camiones(params object[] parametros)
        {
            //creo una lista de objetox VO
            List<Camiones_VO> list = new List<Camiones_VO>();
            try
            {
                //creo un DataSet el cuál recibirá lo que devuelva la ejecución del método "execute_DataSet" de la clase "metodos_datos"
                DataSet ds_camiones = metodos_datos.execute_DataSet("sp_ListarCamiones", parametros);
                //recorro cada renglón existente de nuestro ds creando objetos del tipo VO y añadiendolos a la lista
                foreach (DataRow dr in ds_camiones.Tables[0].Rows)
                {
                    list.Add(new Camiones_VO(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Update

        //Delete
    }
}
