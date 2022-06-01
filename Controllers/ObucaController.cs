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
    public class ObucaController : Controller
    {
        private readonly ObucaService _service;
        private readonly ProdavnicaService _pService;

        public ObucaController()
        {
            _service = new ObucaService();
            _pService = new ProdavnicaService();
        }
        // GET: Obuca
        public ActionResult Index()
        {
            var obuce = _service.Get();
            return View(obuce.ToList());
        }

        // GET: Obuca/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Obuca obuca = _service.GetId((int)id);
            if (obuca == null)
            {
                return HttpNotFound();
            }
            return View(obuca);
        }

        // GET: Obuca/Create
        public ActionResult Create()
        {
            ViewBag.ProdavnicaId = new SelectList(_pService.Get(), "ProdavnicaId", "Adresa");
            return View();
        }

        // POST: Obuca/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ObucaId,UrlSlike,Naziv,Velicina,Cena,Kolicina,ProdavnicaId")] Obuca obuca)
        {
            if (ModelState.IsValid)
            {
                _service.Add(obuca);
                return RedirectToAction("Index");
            }

            ViewBag.ProdavnicaId = new SelectList(_pService.Get(), "ProdavnicaId", "Adresa", obuca.ProdavnicaId);
            return View(obuca);
        }

        // GET: Obuca/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Obuca obuca = _service.GetId((int)id);
            if (obuca == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProdavnicaId = new SelectList(_pService.Get(), "ProdavnicaId", "Adresa", obuca.ProdavnicaId);
            return View(obuca);
        }

        // POST: Obuca/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ObucaId,UrlSlike,Naziv,Velicina,Cena,Kolicina,ProdavnicaId")] Obuca obuca)
        {
            if (ModelState.IsValid)
            {
                _service.Edit(obuca);
                return RedirectToAction("Index");
            }
            ViewBag.ProdavnicaId = new SelectList(_pService.Get(), "ProdavnicaId", "Adresa", obuca.ProdavnicaId);
            return View(obuca);
        }

        // GET: Obuca/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Obuca obuca = _service.GetId((int)id);
            if (obuca == null)
            {
                return HttpNotFound();
            }

            return View(obuca);
            
        }

        // POST: Obuca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
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
