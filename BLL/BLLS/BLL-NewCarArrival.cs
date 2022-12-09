using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL.BLLS
{
    public class BLL_NewCarArrival
    {
        DAL.DALS.DAL_NewCarArrival dal = new DAL.DALS.DAL_NewCarArrival();
        public void NewCarArrival(T_NewCarArrival t)
        {
            dal.NewCarArrival(t);
        }
    }
}
