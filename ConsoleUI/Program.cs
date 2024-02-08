using Business.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Concrete;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();
            //CategoryTest();
            ProductDetailDtoTEST();

        }

        private static void ProductDetailDtoTEST()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (ProductDetailDto p in productManager.GetProductDetails())
            {
                Console.WriteLine("ProductName: " + p.ProductName + " CategoryName: " + p.CategoryName);
            }
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (Category category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName + " " + category.CategoryId);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager2 = new ProductManager(new EfProductDal());
            foreach (var product in productManager2.GetAllByCategoryId(2))
            {
                Console.WriteLine(product.ProductName + " " + product.UnitPrice);
            }
        }


    }


}