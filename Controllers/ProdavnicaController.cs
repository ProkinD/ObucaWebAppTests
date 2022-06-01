using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ObućaWebApp.Models;
using ObućaWebApp.Services;

namespace ObućaWebApp.Controllers
{
    public class ProdavnicaController : Controller
    {
        private readonly ProdavnicaService _service;

        public ProdavnicaController()
        {
            _service = new ProdavnicaService();
        }

        // GET: Prodavnica
        public ActionResult Index()
        {
            return View(_service.Get().ToList());
        }

        // GET: Prodavnica/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prodavnica prodavnica = _service.GetId((int)id) ;
            if (prodavnica == null)
            {
                return HttpNotFound();
            }
            return View(prodavnica);
        }

        // GET: Prodavnica/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prodavnica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdavnicaId,Adresa,Grad,Kontakt,URLSlike")] Prodavnica prodavnica)
        {
            if (ModelState.IsValid)
            {
                _service.Add(prodavnica);
                return RedirectToAction("Index");
            }

            return View(prodavnica);
        }

        // GET: Prodavnica/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prodavnica prodavnica = _service.GetId((int)id);
            if (prodavnica == null)
            {
                return HttpNotFound();
            }
            return View(prodavnica);
        }

        // POST: Prodavnica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdavnicaId,Adresa,Grad,Kontakt,URLSlike")] Prodavnica prodavnica)
        {
            if (ModelState.IsValid)
            {
                _service.Edit(prodavnica);

                return RedirectToAction("Index");
            }
            return View(prodavnica);
        }

        // GET: Prodavnica/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prodavnica prodavnica = _service.GetId((int)id);
            if (prodavnica == null)
            {
                return HttpNotFound();
            }
            return View(prodavnica);
        }

        // POST: Prodavnica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Prodavnica prodavnica = _service.Prodavnce.Find(id);
            _service.Remove(id);

            return RedirectToAction("Index");
        }

        /*protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _service.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
