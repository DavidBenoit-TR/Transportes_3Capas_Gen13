using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Choferes
    {
        //Read
        //Read
        public static List<Choferes_VO> Get_Choferes(params object[] parametros)
        {
            //creo una lista de objetox VO
            List<Choferes_VO> list = new List<Choferes_VO>();
            try
            {
                //creo un DataSet el cuál recibirá lo que devuelva la ejecución del método "execute_DataSet" de la clase "metodos_datos"
                DataSet ds_Rutas = metodos_datos.execute_DataSet("sp_ListarChoferes", parametros);
                //recorro cada renglón existente de nuestro ds creando objetos del tipo VO y añadiendolos a la lista
                foreach (DataRow dr in ds_Rutas.Tables[0].Rows)
                {
                    list.Add(new Choferes_VO(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
