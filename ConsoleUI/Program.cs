﻿using Business.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Concrete;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args) 
        {
            ProductManager productManager = new ProductManager(new InMemoryProductDal());
            foreach(var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }


        }
        
    }


}
