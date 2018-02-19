

using GT4WAvaliacao.DAL.DALContext;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GT4WAvaliacao.DAL.Interfaces
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : class
    {
        void Initialize(Context context);


        TEntity GetById(int id, params Expression<Func<TEntity, object>>[] includes);
        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes);
        void Add(TEntity entity);
        void Update(TEntity entity);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        void Remove(int id);

        

    }
}