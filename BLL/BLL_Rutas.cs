using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Rutas
    {
        //Create
        public static string insert_Rutas(Rutas_VO ruta)
        {
            return DAL_Rutas.insert_Rutas(ruta);
        }

        //Read
        public static List<Rutas_VO> Get_Rutas(params object[] parametros)
        {
            return DAL_Rutas.Get_Rutas(parametros);
        }

        //Update
        public static string actualizar_Rutas(Rutas_VO ruta)
        {
            return DAL_Rutas.actualizar_Rutas(ruta);
        }

        //Delete
        public static string eliminar_Rutas(int id)
        {
            return DAL_Rutas.eliminar_Rutas(id);
        }

    }
}
