using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarExhibition_BE;

namespace CarExhibition_DAL
{
    public class Login_DAL
    {
        CarExhibitionEntities db = new CarExhibitionEntities();

        public byte Login(string UserName, string Password)
        {
            if (db.T_Login.Count() == 0)
            {
                return 0;
            }
            else
            {
                if (db.T_Login.Any(i => i.UserName == UserName && i.Password == Password))
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
        }

        public void Register(T_Login h)
        {
            db.T_Login.Add(h);
            db.SaveChanges();
        }

        public bool Exist(T_Login h)
        {
            var q = db.T_Login.Where(i=> i.Mobile == h.Mobile
                    && i.Email == h.Email);
            if (q.Count() == 1)
            {
                return true;
            }
            else
                return false;
        }
        public List<T_Login> ReadAll()
        {
            return ((db.T_Login)).ToList();
        }
        public void Update(int id, T_Login h)
        {
            var q = db.T_Login.Where(i => i.id == id).FirstOrDefault();
            if (q != null)
            {
                q.Email = h.Email;
                q.Mobile = h.Mobile;
                q.Password = h.Password;
                db.SaveChanges();
            }
        }
    }
}
