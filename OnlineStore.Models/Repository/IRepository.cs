using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OnlineStore.Data.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        TEntity Find(int id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        public void Update(TEntity entity);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
    
}
