using CoreLayer.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities.Repositories
{
    public class GenericRepositoryBase<TEntity, TContext> : IGenericRepository<TEntity>
        where TEntity : class
        where TContext : DbContext, new()
    {
        public void Delete(TEntity par)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(par);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }         
        }

        public void Insert(TEntity par)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(par);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }            
        }

        public List<TEntity> List(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity par)
        {
            using (TContext context = new TContext())
            {
                var updated = context.Entry(par);
                updated.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

    }
}
