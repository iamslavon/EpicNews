using EbaNews.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EbaNews.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);

        void Add(IEnumerable<T> entities);

        T Get(object id);

        IQueryable<T> GetAll();

        IEnumerable<T> GetAllBy(Func<T, bool> predicateFunc);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        void Remove(object id);

        void Update(T entity);

        void SaveChanges();
    }
}
