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
        public List<T_NewCarArrival> ReadAll()
        {
            return (db.T_NewCarArrival).ToList();
        }
        public void Delete(T_NewCarArrival t , int id)
        {
            var q = db.T_NewCarArrival.Where(i => i.Id == id);
            if (q.Count() == 1)
            {
                db.T_NewCarArrival.Remove(q.Single());
                db.SaveChanges();
            }
        }
    }
}
