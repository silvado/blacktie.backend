﻿using Domain.Entities.Abstracts;
using Domain.Interfaces.Common;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Repository.Common
{
    public class GenericAsyncRepository<TEntity> : IGenericAsyncRepository<TEntity> where TEntity : class
    {
        protected readonly BlacktieDbContext _dbContext;

        protected DbSet<TEntity> DbSet
        {
            get { return _dbContext.Set<TEntity>(); }
        }
        public GenericAsyncRepository(BlacktieDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public virtual IQueryable<TEntity> Entity => _dbContext.Set<TEntity>();
        public virtual async Task<TEntity?> GetByIdAsync(int id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);
            if (entity is Entity baseEntity && baseEntity.IsDeleted)
            {
                return null;
            }
            return entity;
        }
        public virtual async Task<TEntity?> GetByGuidAsync(Guid id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);
            if (entity is Entity baseEntity && baseEntity.IsDeleted)
            {
                return null;
            }
            return entity;
        }
        public virtual async Task<TEntity?> GetByIdNoTrackingAsync(int id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);
            if (entity is Entity baseEntity && baseEntity.IsDeleted)
            {
                return null;
            }
            if (entity != null)
                _dbContext.Entry(entity).State = EntityState.Detached;
            return entity;
        }
        public virtual async Task<TEntity?> GetByGuidNoTrackingAsync(Guid id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);
            if (entity is Entity baseEntity && baseEntity.IsDeleted)
            {
                return null;
            }
            if (entity != null)
                _dbContext.Entry(entity).State = EntityState.Detached;
            return entity;
        }
        public async Task<List<TEntity>?> GetByIdsAsync(List<int> ids)
        {
            List<TEntity> toReturn = new();
            foreach (var id in ids)
            {
                var entity = await _dbContext.Set<TEntity>().FindAsync(id);
                if (entity != null) 
                {
                    _dbContext.Entry(entity).State = EntityState.Detached;
                    if (entity is Entity baseEntity)
                    {
                        if (!baseEntity.IsDeleted)
                        {
                            toReturn.Add(entity);
                        }
                    }
                    else
                    {
                        toReturn.Add(entity);
                    }
                }                
                
            }
            return toReturn;
        }
        public async Task<List<TEntity>> GetByIdsAsNoTrackingAsync(List<int> ids)
        {
            List<TEntity> toReturn = new();
            foreach (var id in ids)
            {
                var elementFound = await _dbContext.Set<TEntity>().FindAsync(id);
                if (elementFound != null)
                {
                    _dbContext.Entry(elementFound).State = EntityState.Detached;
                    toReturn.Add(elementFound);
                }
            }

            return toReturn;
        }
        public virtual async Task<List<TEntity>?> GetAllAsync()
        {
            if (typeof(Entity).IsAssignableFrom(typeof(TEntity)))
            {
                return await _dbContext.Set<TEntity>()
                    .AsNoTracking()
                    .OfType<Entity>()
                    .Where(entity => !entity.IsDeleted)
                    .Cast<TEntity>()
                    .ToListAsync();
            }
            else
            {
                return await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
            }
        }
        public async Task<List<TEntity>> ToListAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }
        public virtual async Task<int> CountTotalAsync()
        {
            return await EntityFrameworkQueryableExtensions.CountAsync(_dbContext.Set<TEntity>());
        }
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            return entity;
        }
        public virtual async Task<TEntity> AddAndSaveAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public virtual async Task<List<TEntity>> AddListAsync(List<TEntity> entities)
        {
            await _dbContext.Set<TEntity>().AddRangeAsync(entities);
            return entities;
        }
        public virtual async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;

            if (entity is Sistema)
            {
                _dbContext.Entry(entity).Property(nameof(Sistema.Username)).IsModified = false;
                _dbContext.Entry(entity).Property(nameof(Sistema.Configuracao)).IsModified = false;
                _dbContext.Entry(entity).Property(nameof(Sistema.CreatedAt)).IsModified = false;
                _dbContext.Entry(entity).Property(nameof(Sistema.CreatedByUserId)).IsModified = false;
                _dbContext.Entry(entity).Property(nameof(Sistema.PublishedAt)).IsModified = false;
                _dbContext.Entry(entity).Property(nameof(Sistema.PublishedByUserId)).IsModified = false;
            }

            await _dbContext.SaveChangesAsync();
        }
        public virtual async Task PublishAsync(TEntity entity)
        {
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            if (entity is Sistema)
            {
                _dbContext.Entry(entity).Property(nameof(Sistema.Username)).IsModified = false;
                _dbContext.Entry(entity).Property(nameof(Sistema.Password)).IsModified = false;
                _dbContext.Entry(entity).Property(nameof(Sistema.CreatedByUserId)).IsModified = false;
            }

            await _dbContext.SaveChangesAsync();
        }
        public virtual async Task UpdateNoTrackingAsync(TEntity entity)
        {
            await Task.Run(() => _dbContext.Entry(entity).CurrentValues.SetValues(entity));
        }
        public virtual async Task<List<TEntity>> UpdateListAsync(List<TEntity> entities)
        {
            await Task.Run(() => _dbContext.Set<TEntity>().UpdateRange(entities));
            return entities;
        }
        public virtual async Task DeleteAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await Task.CompletedTask;
        }
        public virtual async Task DeleteListAsync(List<TEntity> entities)
        {
            await Task.Run(() => _dbContext.Set<TEntity>().RemoveRange(entities));
        }
        public virtual async Task DeleteListAndSaveAsync(List<TEntity> entities)
        {
            await Task.Run(() => _dbContext.Set<TEntity>().RemoveRange(entities));
            await _dbContext.SaveChangesAsync();
        }
        public virtual async Task DeleteAndSaveAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        public virtual async Task DeleteAllAsync()
        {
            var elements = await _dbContext.Set<TEntity>().ToListAsync();
            _dbContext.Set<TEntity>().RemoveRange(elements);
            await _dbContext.SaveChangesAsync();
        }
        public virtual async Task SoftDeleteAllAsync()
        {
            var entities = await _dbContext.Set<TEntity>().ToListAsync();
            entities.ForEach(model =>
            {
                if (model is Domain.Entities.Abstracts.Entity baseEntity)
                {
                    baseEntity.IsDeleted = true;
                    EntityEntry<TEntity> _entry = _dbContext.Entry(model);
                    DbSet.Attach(model);
                    _entry.State = EntityState.Modified;
                }
            });

            await _dbContext.SaveChangesAsync();
        }
        public virtual async Task SoftDeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity is Domain.Entities.Abstracts.Entity baseEntity)
            {
                baseEntity.IsDeleted = true;
                await UpdateAsync(entity);
            }
        }

        public virtual async Task SoftDeleteGuidAsync(Guid id)
        {
            var entity = await GetByGuidAsync(id);
            if (entity is Domain.Entities.Abstracts.Entity baseEntity)
            {
                baseEntity.IsDeleted = true;
                await UpdateAsync(entity);
            }
        }
        public virtual TEntity DetachEntity(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Detached;
            return entity;
        }
        public virtual async Task SoftDeleteGuidNoTrackingAsync(Guid id)
        {
            var entity = await GetByGuidAsync(id);
            if (entity is Domain.Entities.Abstracts.Entity baseEntity)
            {
                baseEntity.IsDeleted = true;
                await UpdateNoTrackingAsync(entity);
            }
        }
        public virtual async Task SoftDeleteNoTrackingAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity is Domain.Entities.Abstracts.Entity baseEntity)
            {
                baseEntity.IsDeleted = true;
                await UpdateNoTrackingAsync(entity);
            }
        }

        protected List<string> messages = new List<string>();
    }
}
