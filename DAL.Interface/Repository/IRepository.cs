using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
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
