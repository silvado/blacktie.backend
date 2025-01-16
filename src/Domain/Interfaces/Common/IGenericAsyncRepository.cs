namespace Domain.Interfaces.Common
{
    public interface IGenericAsyncRepository<TEntity> where TEntity : class
    {
        /// <summary>
        ///     Iqueryable entity of Entity Framework. Use this to execute query in database level.
        /// </summary>
        IQueryable<TEntity> Entity { get; }
        Task<TEntity?> GetByIdAsync(int id);
        Task<TEntity?> GetByIdNoTrackingAsync(int id);
        Task<List<TEntity>?> GetByIdsAsync(List<int> ids);
        Task<TEntity?> GetByGuidAsync(Guid id);
        Task<int> CountTotalAsync();
        Task<List<TEntity>?> GetAllAsync();
        Task<TEntity> AddAsync(TEntity entity);
        Task<List<TEntity>> AddListAsync(List<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task PublishAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteAndSaveAsync(TEntity entity);
        Task<TEntity> AddAndSaveAsync(TEntity entity);
        Task DeleteListAsync(List<TEntity> entities);
        Task DeleteListAndSaveAsync(List<TEntity> entities);
        Task<List<TEntity>> UpdateListAsync(List<TEntity> entities);
        Task<List<TEntity>> ToListAsync();
        Task DeleteAllAsync();
        Task SoftDeleteAllAsync();

        Task SoftDeleteAsync(int id);
        Task SoftDeleteGuidAsync(Guid id);

        TEntity DetachEntity(TEntity entity);
        Task UpdateNoTrackingAsync(TEntity entity);
        Task SoftDeleteGuidNoTrackingAsync(Guid id);
        Task SoftDeleteNoTrackingAsync(int id);
    }
}
