using GT4WAvaliacao.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using GT4WAvaliacao.DAL.DALContext;
using System.Data.Entity;

namespace GT4WAvaliacao.DAL.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public static Context _context;

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }



        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().Where(predicate);

            foreach (var path in includes)
            {
                query = query.Include(path);
            }          

            return query.ToList();
        }

        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            ;

            foreach (var include in includes)
            {
                query.Include(include);
            }

            return query.ToList();
        }

        public TEntity GetById(int id, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            foreach (var include in includes)
            {
                query.Include(include);
            }
            return ((IDbSet<TEntity>)query).Find(id);
        }

        public void Initialize(Context context)
        {
            _context = context;
        }

        public void Remove(int id)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            _context.Set<TEntity>().Remove(((IDbSet<TEntity>)query).Find(id));
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}