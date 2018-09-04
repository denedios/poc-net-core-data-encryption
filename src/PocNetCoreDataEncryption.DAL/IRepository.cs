using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PocNetCoreDataEncryption.Domain;

namespace PocNetCoreDataEncryption.DAL
{
    public interface IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        void Add(TEntity entity);
        void AddOrUpdate(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Delete(object id);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = default(int?), int? take = default(int?));
        IQueryable<TEntity> GetAllAsQueryable();
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = default(int?), int? take = default(int?));
        TEntity GetById(object id);
        Task<TEntity> GetByIdAsync(object id);
        TEntity GetFirst(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null);
        TEntity GetOne(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "");
        Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}