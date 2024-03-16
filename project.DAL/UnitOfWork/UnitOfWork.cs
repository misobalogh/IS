﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using project.DAL.Entities;
using project.DAL.Mappers;
using project.DAL.Repositories;

namespace project.DAL.UnitOfWork
{
    public sealed class UnitOfWork(DbContext dbContext) : IUnitOfWork
    {
        private readonly DbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public IRepository<TEntity> GetRepository<TEntity, TEntityMapper>()
            where TEntity : class, IEntity
            where TEntityMapper : IEntityMapper<TEntity>, new()
            => new Repository<TEntity>(_dbContext, new TEntityMapper());

        public async Task CommitAsync() => await _dbContext.SaveChangesAsync();

        public async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();
    }
}
