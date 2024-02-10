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
            //ProductDetailDtoTEST();
            ErrorDataResultTEST();

        }

        private static void ErrorDataResultTEST()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            var result = productManager.GetAll();
            if (result.Success == true)
            {
                foreach (var entity in result.Data)
                {
                    Console.WriteLine("ProductName: " + entity.ProductName + " CategoryName: " + entity.UnitPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ProductDetailDtoTEST()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            var result = productManager.GetProductDetailss();
            if (result.Success == true)
            {
                foreach (ProductDetailDto detailDto in result.Data)
                {
                    Console.WriteLine("ProductName: " + detailDto.ProductName + " CategoryName: " + detailDto.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
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
            foreach (var product in productManager2.GetAllByCategoryId(2).Data)
            {
                Console.WriteLine(product.ProductName + " " + product.UnitPrice);
            }
        }


    }


}