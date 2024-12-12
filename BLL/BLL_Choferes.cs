using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Choferes
    {
        public static List<Choferes_VO> Get_Choferes(params object[] parametros)
        {
            return DAL_Choferes.Get_Choferes(parametros);
        }
    }
}
