using Business.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Concrete;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args) 
        {
            ProductManager productManager1 = new ProductManager(new InMemoryProductDal());
            foreach(var product in productManager1.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }
            Console.WriteLine("--------------------");

            ProductManager productManager2 = new ProductManager(new EntityFrameworkProductDal());
            foreach (var product in productManager2.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }

        }
        
    }


}
