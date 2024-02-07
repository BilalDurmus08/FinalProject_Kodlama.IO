using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase <TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {

        public void Add(TEntity Entity)
        { //We used "using" object like below. because this way more efficient
          //IDisposable pattern Implementaiton of C#
            using (TContext northwindContext = new TContext())
            {
                var addedEntity = northwindContext.Entry(Entity);  //In this line we catch the referrance of Entity
                addedEntity.State = EntityState.Added; //We said that this object will add.
                northwindContext.SaveChanges(); //We after 2 line added to db
            }

        }

        public void Delete(TEntity Entity)
        {
            using (TContext northwindContext = new TContext())
            {
                var deletedEntity = northwindContext.Entry(Entity);
                deletedEntity.State = EntityState.Deleted;
                northwindContext.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext northwindContext = new TContext())
            {
                return northwindContext.Set<TEntity>().SingleOrDefault(filter);
            }

        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext northwindContext = new TContext())
            {
                return filter == null
                ? northwindContext.Set<TEntity>().ToList()
                : northwindContext.Set<TEntity>().Where(filter).ToList();
            }

        }

        public void Update(TEntity Entity)
        {
            using (TContext northwindContext = new TContext())
            {
                var UpdatedContext = northwindContext.Entry(Entity);
                UpdatedContext.State = EntityState.Modified;
                northwindContext.SaveChanges();
            }

        }


    }

}
