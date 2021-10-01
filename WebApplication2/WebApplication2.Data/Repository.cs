using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApplication2.Data
{
    public class Repository<TEntity>where TEntity :class
    {
        public DbSet<TEntity> dbSet;
        private readonly AppContext dbcontext;

        public Repository(AppContext context)
        {
            dbcontext = context;
            dbSet = context.Set<TEntity>();
        }
        // query all list
        public virtual IQueryable<TEntity> AsQueryable()
        {
            return dbcontext.Set<TEntity>();
        }

        public virtual void Delete(TEntity entity)
        {
            dbcontext.Set<TEntity>().Remove(entity);
        }
        public virtual void Insert(TEntity entity)
        {
            dbcontext.Set<TEntity>().Add(entity);
        }
        public virtual void Update(TEntity entity)
        {
            dbcontext.Entry(entity).State= EntityState.Modified;
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entity)
        {
            dbcontext.Set<TEntity>().RemoveRange(entity);
        }
        
        public virtual void AddRange(IEnumerable<TEntity> entity)
        {
            dbcontext.Set<TEntity>().AddRange(entity);
        }


    }
}
