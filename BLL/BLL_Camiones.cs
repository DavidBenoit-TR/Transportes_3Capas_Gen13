using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Camiones
    {
        //Create
        public static string insert_Camion(Camiones_VO camion)
        {
            return DAL_Camiones.insert_Camion(camion);
        }
        //Read
        public static List<Camiones_VO> Get_Camiones(params object[] parametros)
        {
            return DAL_Camiones.Get_Camiones(parametros);
        }

        public static List<Camiones_VO> Get_Camiones_x_Disponibilidad()
        {
            List<Camiones_VO> lista_vacia = new List<Camiones_VO>();
            List<Camiones_VO> lista_origen = DAL_Camiones.Get_Camiones();

            foreach (var c in lista_origen)
            {
                if (c.Disponibilidad)
                {
                    lista_vacia.Add(c);
                }
            }
            return lista_vacia;
        }

        //Update
        public static string actualizar_Camion(Camiones_VO camion)
        {
            return DAL_Camiones.actualizar_Camion(camion);
        }

        //Delete
        public static string eliminar_Camion(int id)
        {
            return DAL_Camiones.eliminar_Camion(id);
        }
    }
}
