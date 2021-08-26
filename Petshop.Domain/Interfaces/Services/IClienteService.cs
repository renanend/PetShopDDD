using Petshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petshop.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        List<Cliente> GetClientes();
        void EditCliente(Cliente cliente);
        void AddCliente(Cliente cliente);
        void RemoveCliente(int id);
        Cliente ObterClientePorId(int id);
    }
}
