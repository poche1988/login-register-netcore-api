using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public sealed class Repository<T> : IRepository<T> where T : class, IHasId
    {
        #region Private Members

        private readonly DataContext _dbContext;
        private readonly DbSet<T> _dbSet;

        #endregion

        #region Constructor

        public Repository(DataContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>(); ;
        }

        #endregion
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public IQueryable<T> AsQueryable()
        {
            return _dbSet;
        }

        public void Attach(T entity)
        {
            _dbSet.Attach(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where);
        }

        public T First(Expression<Func<T, bool>> where)
        {
            return _dbSet.First(where);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.SingleOrDefault(a => a.Id == id);
        }

        public T Single(Expression<Func<T, bool>> where)
        {
            return _dbSet.Single(where);
        }

        public void Upsert(T entity)
        {
            if (entity.Id > 0)
            {
                Attach(entity);
            }
            else
            {
                Add(entity);
            }
        }
    }

    public static class QueryableExtension
    {
        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes)
            where T : class
        {
            if (includes != null && includes.Count() > 0)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query;
        }
    }
}
