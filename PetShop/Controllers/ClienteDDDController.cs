using Microsoft.AspNetCore.Mvc;
using Petshop.Domain.Entities;
using Petshop.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.Controllers
{

    public class ClienteDDDController : Controller
    {
        // GET: ClienteController
        private readonly IClienteService _clienteService;
        public ClienteDDDController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        public ActionResult Index()
        {
            return View(_clienteService.GetClientes());
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            var cliente = _clienteService.ObterClientePorId(id);

            return View(cliente);
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                _clienteService.AddCliente(cliente);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            var cliente = _clienteService.ObterClientePorId(id);

            return View(cliente);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Cliente cliente)
        {
            try
            {
                _clienteService.EditCliente(cliente);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            var clienteExiste = _clienteService.ObterClientePorId(id);
            return View(clienteExiste);
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Cliente cliente)
        {
            try
            {
                _clienteService.RemoveCliente(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
