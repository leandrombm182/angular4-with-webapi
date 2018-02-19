using CommonServiceLocator;
using GT4WAvaliacao.DAL.DALContext;
using GT4WAvaliacao.DAL.Interfaces;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GT4WAvaliacao.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private Context _context;
        private bool _disposed;
        public UnitOfWork(Context context)
        {
            _context = context;
        }
        public IGenericRepository<TEntity> BeginTransaction<TEntity>() where TEntity : class
        {
            var repository = ServiceLocator.Current.GetInstance<IGenericRepository<TEntity>>();
            repository.Initialize(_context);
            return repository;

        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public T ExecuteTransacted<T>(Func<T> function) where T : class
        {

            try
            {
                return function();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void ExecuteTransacted(Action function)
        {
            try
            {
                function();
                SaveChanges();
            }
            catch (Exception ex)
            {
                Rollback();
                throw ex;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            _context
                .ChangeTracker
                .Entries()
                .ToList()
                .ForEach(x => x.Reload());
        }


    }
}