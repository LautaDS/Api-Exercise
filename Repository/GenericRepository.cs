using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Repository;

namespace UnitOfWork.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        internal DbContext context;
        internal DbSet<T> dbSet;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            dbSet = this.context.Set<T>();
        }
       
        public virtual IEnumerable<T> GetAll() => dbSet.ToList();
        public virtual T findId(Object Id)
        { 
                return dbSet.Find(Id);
          
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);//traigo los nuevos valores 
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }
    }
}