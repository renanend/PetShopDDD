using Microsoft.EntityFrameworkCore;
using Petshop.Domain.Connection;
using Petshop.Domain.Interfaces.Repositories;
using Petshop.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petshop.Infra.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly ContextPetShop _db;
        public RepositoryBase(ContextPetShop db)
        {
            _db = db;
        }
        public IUnitOfWork UnitOfWork()
        {
            return _db;
        }

        public void Add(TEntity entity)
        {
            _db.Set<TEntity>().Add(entity);
        }

        public void Dispose()
        {
            _db?.Dispose();
        }

        public TEntity GetById(int id)
        {
           return _db.Set<TEntity>().Find(id);
        }
    }
}
