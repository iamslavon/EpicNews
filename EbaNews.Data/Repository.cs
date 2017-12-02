using EbaNews.Core.Entities;
using EbaNews.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EbaNews.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext context;
        private readonly DbSet<T> dbSet;

        public Repository()
        {
            context = new ApplicationContext();
            dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Add(IEnumerable<T> entities)
        {
            dbSet.AddRange(entities);
        }

        public T Get(object id)
        {
            return dbSet.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public IEnumerable<T> GetAllBy(Func<T, bool> predicateFunc)
        {
            return dbSet.Where(predicateFunc);
        }

        public void Remove(T entity)
        {
            CheckIfDeatached(entity);

            dbSet.Remove(entity);
        }

        public void Remove(object id)
        {
            Remove(Get(id));
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                CheckIfDeatached(entity);
            }

            dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        private void CheckIfDeatached(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
        }
    }
}
