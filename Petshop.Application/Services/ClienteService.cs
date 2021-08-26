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
        private readonly IRepositoryBase<Cliente> _clienteRepositoryBase;
        public ClienteService(IClienteRepository clienteRepository, IRepositoryBase<Cliente> clienteRepositoryBase)
        {
            _clienteRepository = clienteRepository;
            _clienteRepositoryBase = clienteRepositoryBase;
        }

        public void AddCliente(Cliente cliente)
        {
            _clienteRepositoryBase.Add(cliente);
            _clienteRepositoryBase.UnitOfWork().Commit();
        }

        public void EditCliente(Cliente cliente)
        {
            var clienteExiste = _clienteRepositoryBase.GetById(cliente.IdCliente);
            clienteExiste.Nome = cliente.Nome;
            clienteExiste.Email = cliente.Email;
            clienteExiste.Telefone = cliente.Telefone;

            _clienteRepositoryBase.UnitOfWork().Commit();
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
            var clienteExiste = _clienteRepositoryBase.GetById(id);
            _clienteRepositoryBase.Remove(clienteExiste);
            _clienteRepository.UnitOfWork().Commit();
        }
    }
}
