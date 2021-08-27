using Petshop.Domain.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petshop.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        TEntity GetById(int id);

        IUnitOfWork UnitOfWork();

        void Remove(TEntity entity);

        List<TEntity> GetAll();
    }
}
