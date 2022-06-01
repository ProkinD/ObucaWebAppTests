using ObućaWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObućaWebApp.Repositories
{
    public class ObucaRepository:IObucaRepository
    {
        private readonly ObucaWebAppDbModel _db;

        public ObucaRepository()
        {
            _db = new ObucaWebAppDbModel();
        }

        public ObucaRepository(ObucaWebAppDbModel db)
        {
            _db = db;
        }

        public List<Obuca> Get()
        {

            return _db.Obuce.ToList();
        }

        public Obuca GetId(int id)
        {
            return _db.Obuce.Find(id);
        }

        public bool Create(Obuca obuca)
        {
            var count1 = _db.Obuce.ToList().Count;


            _db.Obuce.Add(obuca);
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

        public bool Update(Obuca obuca)
        {
            var staraObuca = _db.Obuce.First(o => o.ObucaId == obuca.ObucaId);
            staraObuca.Naziv = obuca.Naziv;
            staraObuca.UrlSlike = obuca.UrlSlike;
            staraObuca.Velicina = obuca.Velicina;
            staraObuca.Kolicina = obuca.Kolicina;
            staraObuca.Cena = obuca.Cena;
            staraObuca.ProdavnicaId = obuca.ProdavnicaId;

            _db.SaveChanges();
            return true;

        }

        public bool Delete(Obuca obuca)
        {

            _db.Obuce.Remove(obuca);
            _db.SaveChanges();

            return true;
        }
    }
}