using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL.BLLS
{
    public class BLL_Login
    {
        DAL.DALS.DAL_Login dal = new DAL.DALS.DAL_Login();
        //this is github test

        public byte Login(string UserName, string Password)
        {
            return dal.Login(UserName, Password);
        }

        public void Register(T_Login h)
        {
            dal.Register(h);
        }
        public bool Exist(string PhoneNumber, string Email)
        {
            return dal.Exist(PhoneNumber, Email);
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
