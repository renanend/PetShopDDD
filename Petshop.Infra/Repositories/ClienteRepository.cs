using Petshop.Domain.Connection;
using Petshop.Domain.Entities;
using Petshop.Domain.Interfaces.Repositories;
using Petshop.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petshop.Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ContextPetShop _db;
        public ClienteRepository(ContextPetShop db)
        {
            _db = db;
        }

        public IUnitOfWork UnitOfWork()
        {
            return _db;
        }

        public void AddCliente(Cliente cliente)
        {
            _db.Add(cliente);
        }

        public Cliente GetClienteBy(int id)
        {
            return _db.Cliente.Find(id);
        }

        public List<Cliente> GetClientes()
        {
            return _db.Cliente.ToList();
        }

        public void RemoveCliente(Cliente cliente)
        {
            _db.Remove(cliente);
        }
    }
}
