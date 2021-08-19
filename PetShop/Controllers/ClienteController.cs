using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Petshop.Domain.Entities;
using Petshop.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.Controllers
{
    public class ClienteController : Controller
    {
        // GET: ClienteController
        private readonly ContextPetShop _db;
        public ClienteController(ContextPetShop db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            return View(_db.Cliente.ToList());
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            var cliente = _db.Cliente.Find(id);

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
                _db.Add(cliente);
                _db.SaveChanges();
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
            var cliente = _db.Cliente.Find(id);

            return View(cliente);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Cliente cliente)
        {
            try
            {
                var clienteExiste = _db.Cliente.Find(id);
                clienteExiste.Nome = cliente.Nome;
                clienteExiste.Email = cliente.Email;
                clienteExiste.Telefone = cliente.Telefone;

                _db.SaveChanges();

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
            var clienteExiste = _db.Cliente.Find(id);
            return View(clienteExiste);
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Cliente cliente)
        {
            try
            {
                var clienteExiste = _db.Cliente.Find(id);
                _db.Remove(clienteExiste);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
