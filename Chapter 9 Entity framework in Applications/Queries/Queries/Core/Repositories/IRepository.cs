using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Queries.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //Find an enity with id and return it
        TEntity Get(int id);

        //Return all objects
        IEnumerable<TEntity> GetAll();

        //Find if exists by filtering objects with an expression
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        // This method was not in the videos, but I thought it would be useful to add.
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        //Add object
        void Add(TEntity entity);

        //Add list of objects
        void AddRange(IEnumerable<TEntity> entities);
        
        //Remove object
        void Remove(TEntity entity);

        //Remove range
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}