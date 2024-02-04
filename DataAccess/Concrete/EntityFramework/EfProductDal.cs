using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product Entity)
        { //We used "using" object like below. because this way more efficient
          //IDisposable pattern Implementaiton of C#
            using (NorthwindContext northwindContext = new NorthwindContext())
            {       
                var addedEntity = northwindContext.Entry(Entity);  //In this line we catch the referrance of Entity
                addedEntity.State = EntityState.Added; //We said that this object will add.
                northwindContext.SaveChanges(); //We after 2 line added to db
            }

        }   

        public void Delete(Product Entity)
        {
            using (NorthwindContext northwindContext = new NorthwindContext())
            {
                var deletedEntity = northwindContext.Entry(Entity);
                deletedEntity.State = EntityState.Deleted;
                northwindContext.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext northwindContext = new NorthwindContext())
            {
                return northwindContext.Set<Product>().SingleOrDefault(filter);
            }

        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext northwindContext = new NorthwindContext())
            {
                return filter == null
                ? northwindContext.Set<Product>().ToList()
                : northwindContext.Set<Product>().Where(filter).ToList();
            }

        }

        public void Update(Product Entity)
        {
            using (NorthwindContext northwindContext = new NorthwindContext())
            {
                var UpdatedContext = northwindContext.Entry(Entity);
                UpdatedContext.State = EntityState.Modified;
                northwindContext.SaveChanges();
            }

        
        }
    }

}
