using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    public interface IRepository<TEntity> where TEntity: IEntity
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        TEntity GetById(int id);
        void DeleteById(int id);
        IEnumerable<TEntity> GetAll();
        TEntity GetByPredicate(Expression<Func<TEntity,bool>> f);
    }
}
