using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL.DALS
{
    public class DAL_NewCarArrival
    {
        CarExhibitionEntities db = new CarExhibitionEntities();

        public void NewCarArrival(T_NewCarArrival t)
        {
            db.T_NewCarArrival.Add(t);
            db.SaveChanges();
        }
    }
}
