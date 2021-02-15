using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MetWorkingUserApplication.Interfaces
{
    public interface IRepository<TEntity> where TEntity :class
    {
        void Delete(TEntity entityToDelete);
        void Delete(object id);
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null, 
            Func<IQueryable<TEntity>, 
            IOrderedQueryable<TEntity>> orderBy = null,      
            string includeProperties = ""
        );
        TEntity GetByID(object id);
        IEnumerable<TEntity> GetWithRawSql(string query, 
        params object[] parameters);
        void Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
    }
}