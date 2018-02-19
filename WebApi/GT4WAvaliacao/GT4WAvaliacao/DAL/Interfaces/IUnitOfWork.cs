using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GT4WAvaliacao.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> BeginTransaction<TEntity>() where TEntity : class;
        void SaveChanges();
        void Rollback();
        T ExecuteTransacted<T>(Func<T> function) where T : class;
        void ExecuteTransacted(Action function);
    }
}