﻿using AutoMapper;
using Chamados.Domain.Entities;
using Chamados.Infra.Repositories;
using Chamados.MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chamados.MVC.Controllers
{// Nunca chamar repositorio da presentation
    public class ClientesController : Controller
    {
        private readonly ClienteRepository _clienteRepository = new ClienteRepository();
                    
        // GET: Clientes
        public ActionResult Index()
        {
            var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable <ClienteViewModel>>( _clienteRepository.GetAll());
            return View(clienteViewModel);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(cliente);
                _clienteRepository.Add(clienteDomain);

                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
