using Petshop.Domain.Entities;
using Petshop.Domain.Interfaces.Repositories;
using Petshop.Domain.Interfaces.Services;
using Petshop.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petshop.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void AddCliente(Cliente cliente)
        {
            _clienteRepository.AddCliente(cliente);
            _clienteRepository.UnitOfWork().Commit();
        }

        public void EditCliente(Cliente cliente)
        {
            var clienteExiste = _clienteRepository.GetClienteBy(cliente.IdCliente);
            clienteExiste.Nome = cliente.Nome;
            clienteExiste.Email = cliente.Email;
            clienteExiste.Telefone = cliente.Telefone;
            _clienteRepository.UnitOfWork().Commit();
        }

        public List<Cliente> GetClientes()
        {
            return _clienteRepository.GetClientes();
        }

        public Cliente ObterClientePorId(int id)
        {
            return _clienteRepository.GetClienteBy(id);
        }

        public void RemoveCliente(int id)
        {
            var clienteExiste = _clienteRepository.GetClienteBy(id);
            _clienteRepository.RemoveCliente(clienteExiste);
            _clienteRepository.UnitOfWork().Commit();
        }
    }
}
