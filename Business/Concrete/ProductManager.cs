using Business.Abstract;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            //Some business code blocks
            //Is he allows to use ? 
            if(product.ProductName.Length < 2)
            {
                return new ErrorResult("An error was encountered while adding process"); 
            }

            _productDal.Add(product);
            return new SuccessResult("Added process Successful"); //we gave "true" as default. The message is choice
        }

        public List<Product> GetAll()
        {
            //Some business code blocks
            //Is he allows to use ? 

            return _productDal.GetAll();

        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryID == id);
        }

        public Product GetByProductId(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll().Where(p => p.UnitPrice > min && p.UnitPrice < max).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }

}