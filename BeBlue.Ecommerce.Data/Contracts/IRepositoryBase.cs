
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BeBlue.Ecommerce.Domain.Models;

namespace BeBlue.Ecommerce.Data.Contracts
{
    public interface IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(Int32 id);
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate);
    }
}
