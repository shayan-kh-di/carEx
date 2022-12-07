using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarExhibition_BE;
using CarExhibition_DAL;

namespace CarExhibition_BLL
{
    public class Login_BLL
    {
        Login_DAL dal = new Login_DAL();

        public byte Login(string UserName, string Password)
        {
            return dal.Login(UserName, Password);
        }

        public void Register(T_Login h)
        {
            dal.Register(h);
        }
        public bool Exist(T_Login h)
        {
            return dal.Exist(h);
        }
        public List<T_Login> ReadAll()
        {
            return dal.ReadAll();
        }
        public void Update(int id, T_Login h)
        {
            dal.Update(id, h);
        }
    }
}
