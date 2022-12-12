using System.Linq.Expressions;
using JustBlog.Core.Database;
using Microsoft.EntityFrameworkCore;

namespace JustBlog.Repositories.Infrastructure
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly JustBlogContext Context;
        protected readonly DbSet<TEntity> DbSet;
        public GenericRepository(JustBlogContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }
        public virtual IList<TEntity> GetAll()
        {
            return DbSet.ToList();
        }
        public virtual TEntity GetById(int id)
        {
            return DbSet.Find(id)!;
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                         (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity FindByCondition(Func<TEntity, bool> condition)
        {
            return DbSet.First(condition);
        }
        public virtual IList<TEntity> GetByCondition(Func<TEntity, bool> condition)
        {
            return DbSet.Where(condition).ToList();
        }
        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void DeleteById(object id)
        {
            TEntity entityToDelete = DbSet.Find(id)!;
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public IList<TEntity> GetPagedItems(int page, int pageSize)
        {
            return DbSet.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public int CountAll()
        {
            return DbSet.Count();
        }
    }
}
