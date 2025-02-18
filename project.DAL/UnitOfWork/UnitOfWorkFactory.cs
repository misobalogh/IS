﻿using Microsoft.EntityFrameworkCore;

namespace project.DAL.UnitOfWork
{
    public class UnitOfWorkFactory(IDbContextFactory<ApplicationDbContext> dbContextFactory) : IUnitOfWorkFactory
    {
        public IUnitOfWork Create() => new UnitOfWork(dbContextFactory.CreateDbContext());

    }
}
