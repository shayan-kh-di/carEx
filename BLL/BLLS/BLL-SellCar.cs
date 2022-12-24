﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace BLL.BLLS
{
    public class BLL_SellCar
    {
        DAL.DALS.DAL_SellCar dal = new DAL.DALS.DAL_SellCar(); 
        public void register(T_SellCar t)
        {
            dal.register(t);
        }
        public List<T_SellCar> ReadAll()
        {
            return dal.ReadAll();
        }
        public void Delete(T_SellCar t, int id)
        {
            dal.Delete(t, id);
        }
    }
}
