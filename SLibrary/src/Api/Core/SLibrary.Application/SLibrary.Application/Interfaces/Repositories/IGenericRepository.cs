using SLibrary.Api.Domain.Models;
using System.Linq.Expressions;

namespace SLibrary.Application.Interfaces.Repositories;
public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    #region Add Operations
    Task<int> AddAsync(TEntity entity);

    int Add(TEntity entity);

    int Add(IEnumerable<TEntity> entites);

    Task<int> AddAsync(IEnumerable<TEntity> entities);
    #endregion

    #region Update Operations
    Task<int> UpdateAsync(TEntity entity);

    int Update(TEntity entity);
    #endregion

    #region Delete Operations
    Task<int> DeleteAsync(TEntity entity);

    int Delete(TEntity entity);

    Task<int> DeleteAsync(Guid id);

    int Delete(Guid id);
    #endregion

    #region Get Operations
    Task<List<TEntity>> GetAll(bool noTracking = true);

    Task<List<TEntity>> GetList(
        Expression<Func<TEntity, bool>> predicate,
        bool noTracking = true,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        params Expression<Func<TEntity, object>>[] includes);

    Task<TEntity> GetByIdAsync(
        Guid id,
        bool noTracking = true,
        params Expression<Func<TEntity, object>>[] includes);

    Task<TEntity> GetSingleAsync(
        Expression<Func<TEntity,
        bool>> predicate,
        bool noTracking = true,
        params Expression<Func<TEntity, object>>[] includes);

    Task<TEntity> FirstOrDefaultAsync(
        Expression<Func<TEntity,
        bool>> predicate,
        bool noTracking = true,
        params Expression<Func<TEntity, object>>[] includes);

    IQueryable<TEntity> Get(
        Expression<Func<TEntity,
        bool>> predicate,
        bool noTracking = true,
        params Expression<Func<TEntity, object>>[] includes);
    #endregion

}

