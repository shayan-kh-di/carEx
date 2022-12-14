using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL.DALS
{
    public class DAL_SellCar
    {
        CarExhibitionEntities db = new CarExhibitionEntities();

        public void register(T_SellCar t)
        {
            db.T_SellCar.Add(t);
            db.SaveChanges();
        }
        public List<T_SellCar> ReadAll()
        {
            return (db.T_SellCar).ToList();
        }
        public void Delete(T_SellCar t, int id)
        {
            var q = db.T_SellCar.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                db.T_SellCar.Remove(q.Single());
                db.SaveChanges();
            }
        }
    }
}
