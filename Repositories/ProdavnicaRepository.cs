using ObućaWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ObućaWebApp.Repositories
{
    public class ProdavnicaRepository : IProdavnicaRepository
    {
        private readonly ObucaWebAppDbModel _db;
        public ProdavnicaRepository()
        {
            _db = new ObucaWebAppDbModel();
        }

        public ProdavnicaRepository(ObucaWebAppDbModel db)
        {
            _db = db;
        }


        public bool Create(Prodavnica prodavnica)
        {
            var count1 = _db.Prodavnce.ToList().Count;


            _db.Prodavnce.Add(prodavnica);
            _db.SaveChanges();
            var count2 = _db.Obuce.ToList().Count;

            if (count1 == count2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Delete(Prodavnica prodavnica)
        {
            _db.Prodavnce.Remove(prodavnica);
            _db.SaveChanges();
            return true;
        }

        public List<Prodavnica> Get()
        {
            return _db.Prodavnce.Include("Obuce").ToList();
        }

        public Prodavnica GetId(int id)
        {
            return _db.Prodavnce.Where(p => p.ProdavnicaId == id).Include("Obuce").FirstOrDefault();
        }

        public List<Obuca> GetSveObuce(int id)
        {
            return _db.Prodavnce.Find(id).Obuce.ToList();
        }

        public bool Update(Prodavnica prodavnica)
        {
            var staraProdavnica = _db.Prodavnce.First(p => p.ProdavnicaId == prodavnica.ProdavnicaId);

            staraProdavnica.Adresa = prodavnica.Adresa;
            staraProdavnica.Grad = prodavnica.Grad;
            staraProdavnica.Kontakt = prodavnica.Kontakt;
            staraProdavnica.URLSlike = prodavnica.URLSlike;

            _db.SaveChanges();
            return true;
        }
    }
}