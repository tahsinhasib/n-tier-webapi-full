﻿using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IProductFeatures
    {
        List<Product> SearchByName(string name);
        //List<Product> SearchByName(string name);
        //List<Product> SearchByName(string name);
        //List<Product> SearchByName(string name);
        //List<Product> SearchByName(string name);
        //List<Product> SearchByName(string name);

        List<Product> SearchByQuantity(int quantity); // New method

    }
}
