using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repository.Mongo.Cqrs
{
    /// <summary>
    /// command base class for CQRS pattern
    /// </summary>
    public class WriteRepository<T> : ReadRepository<T>, IWriteRepository<T>
        where T : IEntity
    {
        #region Constructor

        /// <summary>
        /// contructor
        /// </summary>
        /// <param name="repository">Repository or CachedRepository</param>
        public WriteRepository(IRepository<T> repository) : base(repository)
        {
        }

        #endregion Constructor

        #region MongoSpecific

        /// <summary>
        /// mongo collection
        /// </summary>
        public IMongoCollection<T> Collection
        {
            get
            {
                return Repository.Collection;
            }
        }

        /// <summary>
        /// updater for collection
        /// </summary>
        public UpdateDefinitionBuilder<T> Updater
        {
            get
            {
                return Repository.Updater;
            }
        }

        #endregion MongoSpecific

        #region CRUD

        /// <summary>
        /// delete items with filter
        /// </summary>
        /// <param name="filter">expression filter</param>
        public void Delete(Expression<Func<T, bool>> filter)
        {
            Repository.Delete(filter);
        }

        /// <summary>
        /// delete entity
        /// </summary>
        /// <param name="entity">entity</param>
        public void Delete(T entity)
        {
            Repository.Delete(entity);
        }

        /// <summary>
        /// delete by id
        /// </summary>
        /// <param name="id">id</param>
        public void Delete(string id)
        {
            Repository.Delete(id);
        }

        /// <summary>
        /// insert entity collection
        /// </summary>
        /// <param name="entities">collection of entities</param>
        public void Insert(IEnumerable<T> entities)
        {
            Repository.Insert(entities);
        }

        /// <summary>
        /// insert entity
        /// </summary>
        /// <param name="entity">entity</param>
        public void Insert(T entity)
        {
            Repository.Insert(entity);
        }

        /// <summary>
        /// replace collection of entities
        /// </summary>
        /// <param name="entities">collection of entities</param>
        public void Replace(IEnumerable<T> entities)
        {
            Repository.Replace(entities);
        }

        /// <summary>
        /// replace an existing entity
        /// </summary>
        /// <param name="entity">entity</param>
        public void Replace(T entity)
        {
            Repository.Replace(entity);
        }

        /// <summary>
        /// update found entities by filter with updated fields
        /// </summary>
        /// <param name="filter">collection filter</param>
        /// <param name="update">updated field(s)</param>
        /// <returns>true if successful, otherwise false</returns>
        public bool Update(FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            return Repository.Update(filter, update);
        }

        /// <summary>
        /// update an entity with updated fields
        /// </summary>
        /// <param name="entity">entity</param>
        /// <param name="update">updated field(s)</param>
        /// <returns>true if successful, otherwise false</returns>
        public bool Update(T entity, UpdateDefinition<T> update)
        {
            return Repository.Update(entity, update);
        }

        /// <summary>
        /// update a property field in entities
        /// </summary>
        /// <typeparam name="TField">field type</typeparam>
        /// <param name="filter">filter</param>
        /// <param name="field">field</param>
        /// <param name="value">new value</param>
        /// <returns>true if successful, otherwise false</returns>
        public bool Update<TField>(FilterDefinition<T> filter, Expression<Func<T, TField>> field, TField value)
        {
            return Repository.Update(filter, field, value);
        }

        /// <summary>
        /// update a property field in an entity
        /// </summary>
        /// <typeparam name="TField">field type</typeparam>
        /// <param name="entity">entity</param>
        /// <param name="field">field</param>
        /// <param name="value">new value</param>
        /// <returns>true if successful, otherwise false</returns>
        public bool Update<TField>(T entity, Expression<Func<T, TField>> field, TField value)
        {
            return Repository.Update(entity, field, value);
        }

        #endregion CRUD
    }
}