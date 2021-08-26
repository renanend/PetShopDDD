using Petshop.Domain.Connection;
using Petshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petshop.Domain.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        List<Cliente> GetClientes();
        Cliente GetClienteBy(int id);
        void AddCliente(Cliente cliente);
        void RemoveCliente(Cliente cliente);
        IUnitOfWork UnitOfWork();
    }
}
