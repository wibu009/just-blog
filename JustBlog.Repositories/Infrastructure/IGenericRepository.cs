using System.Linq.Expressions;

namespace JustBlog.Repositories.Infrastructure
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>List Of Entity</returns>
        IList<TEntity> GetAll();
        /// <summary>
        /// Get all entities with filter, order by, include properties
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns>Data after Query</returns>
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetById(int id);
        /// <summary>
        /// Find entity by condition (filter)
        /// </summary>
        /// <param name="condition"></param>
        /// <returns>Entity</returns>
        TEntity FindByCondition(Func<TEntity, bool> condition);
        /// <summary>
        /// Get by condition (filter)
        /// </summary>
        /// <param name="condition"></param>
        /// <returns>List Of Entity</returns>
        IList<TEntity> GetByCondition(Func<TEntity, bool> condition);
        /// <summary>
        /// Paging data
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IList<TEntity> GetPagedItems(int page, int pageSize);
        void Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
        void Delete(TEntity entityToDelete);
        void DeleteById(object id);
        int CountAll();
    }
}
