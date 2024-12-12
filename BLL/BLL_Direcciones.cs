using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Direcciones
    {
        public static List<Direcciones_VO> Get_Direcciones(params object[] parametros)
        {
            return DAL_Direcciones.Get_Direcciones(parametros);
        }
    }
}
