using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repository.Mongo.Cqrs
{
    /// <summary>
    /// query base class for CQRS pattern
    /// </summary>
    public class ReadRepository<T> : IReadRepository<T>
        where T : IEntity
    {
        #region Construtor

        /// <summary>
        /// contructor
        /// </summary>
        /// <param name="repository">Repository or CachedRepository</param>
        public ReadRepository(IRepository<T> repository)
        {
            Repository = repository;
        }

        internal IRepository<T> Repository { get; }

        #endregion Construtor

        #region MongoSpecific

        /// <summary>
        /// filter for collection
        /// </summary>
        public FilterDefinitionBuilder<T> Filter
        {
            get
            {
                return Repository.Filter;
            }
        }

        /// <summary>
        /// projector for collection
        /// </summary>
        public ProjectionDefinitionBuilder<T> Project
        {
            get
            {
                return Repository.Project;
            }
        }

        #endregion MongoSpecific

        #region CRUD

        /// <summary>
        /// find entities
        /// </summary>
        /// <param name="filter">expression filter</param>
        /// <returns>collection of entity</returns>
        public IEnumerable<T> Find(Expression<Func<T, bool>> filter)
        {
            return Repository.Find(filter);
        }

        /// <summary>
        /// find entities with paging
        /// </summary>
        /// <param name="filter">expression filter</param>
        /// <param name="pageIndex">page index, based on 0</param>
        /// <param name="size">number of items in page</param>
        /// <returns>collection of entity</returns>
        public IEnumerable<T> Find(Expression<Func<T, bool>> filter, int pageIndex, int size)
        {
            return Repository.Find(filter, pageIndex, size);
        }

        /// <summary>
        /// find entities with paging and ordering
        /// </summary>
        /// <param name="filter">expression filter</param>
        /// <param name="order">ordering parameters</param>
        /// <param name="pageIndex">page index, based on 0</param>
        /// <param name="size">number of items in page</param>
        /// <returns>collection of entity</returns>
        public IEnumerable<T> Find(Expression<Func<T, bool>> filter, Expression<Func<T, object>> order, int pageIndex, int size)
        {
            return Repository.Find(filter, order, pageIndex, size);
        }

        /// <summary>
        /// find entities with paging and ordering in direction
        /// </summary>
        /// <param name="filter">expression filter</param>
        /// <param name="order">ordering parameters</param>
        /// <param name="pageIndex">page index, based on 0</param>
        /// <param name="size">number of items in page</param>
        /// <param name="isDescending">ordering direction</param>
        /// <returns>collection of entity</returns>
        public IEnumerable<T> Find(Expression<Func<T, bool>> filter, Expression<Func<T, object>> order, int pageIndex, int size, bool isDescending)
        {
            return Repository.Find(filter, order, pageIndex, size, isDescending);
        }

        /// <summary>
        /// get by id
        /// </summary>
        /// <param name="id">id value</param>
        /// <returns>entity of <typeparamref name="T"/></returns>
        public T Get(string id)
        {
            return Repository.Get(id);
        }

        #endregion CRUD

        #region Simplicity

        /// <summary>
        /// validate if filter result exists
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>true if exists, otherwise false</returns>
        public bool Any(Expression<Func<T, bool>> filter)
        {
            return Repository.Any(filter);
        }

        #endregion Simplicity
    }
}