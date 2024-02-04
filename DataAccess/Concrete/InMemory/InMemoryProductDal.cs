using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{       // We will not use this class. I quit to write code inside of this class. But for template this class should exist
        //I use EntityFramework folder to use "NorthWind" database
    public class InMemoryProductDal : IProductDal
    {               //Convention naming
        List<Product> _products;
        public InMemoryProductDal()
        {
            //Like those are comes from Oracle, Sql, DataBase
        _products = new List<Product> {
        new Product {CategoryID = 1, ProductId = 1, ProductName = "Car", UnitPrice = 15, UnitsInStock = 65},
        new Product {CategoryID = 1, ProductId = 2, ProductName = "Glass", UnitPrice = 534, UnitsInStock = 45},
        new Product {CategoryID = 2, ProductId = 3, ProductName = "Mouse", UnitPrice = 234, UnitsInStock = 678},
        new Product {CategoryID = 2, ProductId = 4, ProductName = "Hat", UnitPrice = 5, UnitsInStock = 9},
        new Product {CategoryID = 2, ProductId = 5, ProductName = "Jar", UnitPrice = 16, UnitsInStock = 7},

        };
        
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
           Product deleteProduct = null;
            /*   foreach (Product p in _products)
               {
                   if(p.CategoryID == product.CategoryID) 
                   { 
                       deleteProduct = p; break; 
                   }
               } */
            deleteProduct = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            _products.Remove(deleteProduct);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryID == categoryId).ToList();

        }

        public void Update(Product product)
        {
            Product ProductToUpdate;
            ProductToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            ProductToUpdate.ProductName = product.ProductName;
            ProductToUpdate.UnitPrice = product.UnitPrice;
            ProductToUpdate.CategoryID = product.CategoryID; 
            ProductToUpdate.UnitsInStock = product.UnitsInStock;

        }

    }

}
