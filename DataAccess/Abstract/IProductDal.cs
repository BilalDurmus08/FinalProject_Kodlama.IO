﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal
    {
        List<Product> GetAll();
        void Add(Product product);
        void Delete(Product product);
        void Update(Product product);

        List<Product> GetAllByCategory(int categoryId);


    }

}