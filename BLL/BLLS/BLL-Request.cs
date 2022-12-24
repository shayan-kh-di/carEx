using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace BLL.BLLS
{
    public class BLL_Request
    {
        DAL.DALS.DAL_Request dal = new DAL.DALS.DAL_Request();

        public void register(T_Request t)
        {
            dal.register(t);
        }
        public List<T_Request> ReadAll()
        {
            return dal.ReadAll();
        }
        public void Delete(T_Request t, int id)
        {
            dal.Delete(t, id);
        }
    }
}
