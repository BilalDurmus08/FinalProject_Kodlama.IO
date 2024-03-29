﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{ 
    public class CategoryManager : ICategoryService
       {
           ICategoryDal _categoryDal;
           //I took ICategoryDal from constructure.
           public CategoryManager(ICategoryDal categoryDal)
           {
               _categoryDal = categoryDal;
           }

            public List<Category> GetAll()
            {
            return _categoryDal.GetAll();
            }

            public Category GetById(int CategoryId)
            {
                return _categoryDal.Get(c => c.CategoryId == CategoryId);
            }


        }

}
