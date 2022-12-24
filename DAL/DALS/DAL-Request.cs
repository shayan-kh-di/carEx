using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL.DALS
{
    public class DAL_Request
    {
        CarExhibitionEntities db = new CarExhibitionEntities();
        
        public void register(T_Request t)
        {
            db.T_Request.Add(t);
            db.SaveChanges();
        }
        public List<T_Request> ReadAll()
        {
           return db.T_Request.ToList();
        }
        public void Delete(T_Request t, int id)
        {
            var q = db.T_Request.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                db.T_Request.Remove(q.Single());
                db.SaveChanges();
            }
        }
    }
}
