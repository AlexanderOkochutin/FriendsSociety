using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    /// <summary>
    /// Interface of Repository pattern
    /// </summary>
    /// <typeparam name="TEntity">Entity which implement IEntity interface</typeparam>
    public interface IRepository<TEntity> where TEntity: IEntity
    {
        /// <summary>
        /// Method for adding entity 
        /// </summary>
        void Add(TEntity entity);

        /// <summary>
        /// Method for update exist entity
        /// </summary>
        void Update(TEntity entity);

        /// <summary>
        /// Get entity by Id
        /// </summary>
        /// <param name="id">Id of exist entity</param>
    
        TEntity GetById(int id);

        /// <summary>
        /// Delete exist entity by Id
        /// </summary>
        /// <param name="id">Id of exist entity</param>
        void DeleteById(int id);

        /// <summary>
        /// Get All entities
        /// </summary>
        IEnumerable<TEntity> GetAll();
    }
}
