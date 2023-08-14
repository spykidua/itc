using ITC.DataAccess.Entities;
using ITC.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using ITC.DataAccess.Interfaces.Repositories;
using ITC.DataAccess.Repositories;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace ITC.DataAccess
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private readonly IDictionary<Type, object> _repositoryStorage;

        public UnitOfWork(DbContext context)
        {
            _context = context;
            _repositoryStorage = new Dictionary<Type, object>();
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositoryStorage.ContainsKey(typeof(TEntity)))
            {
                return _repositoryStorage[typeof(TEntity)] as IGenericRepository<TEntity>;
            }

            var repository = new GenericRepository<TEntity>(_context);
            _repositoryStorage.Add(typeof(TEntity), repository);

            return repository;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public Task SaveChangesAsync() => _context.SaveChangesAsync();

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
