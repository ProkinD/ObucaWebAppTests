using ObućaWebApp.Models;
using ObućaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObućaUnitTests
{
    class ProdavnicaFakeRepository : IProdavnicaRepository
    {
        public bool Create(Prodavnica prodavnica)
        {
            List<Prodavnica> prodavnice = new List<Prodavnica>();
            prodavnice.Add(new Prodavnica { ProdavnicaId = 4, Adresa = "Karađorđeva bb", Grad = "Beograd", Kontakt = "prod@karadjorjeva.com", URLSlike = "//////" });
            prodavnice.Add(new Prodavnica { ProdavnicaId = 5, Adresa = "Markova bb", Grad = "Kikinda", Kontakt = "prod@markova.com", URLSlike = "//////" });
            prodavnice.Add(new Prodavnica { ProdavnicaId = 6, Adresa = "Uroseva bb", Grad = "Beograd", Kontakt = "prod@uroseva.com", URLSlike = "//////" });

            foreach (var p in prodavnice)
            {
                if (p.ProdavnicaId != prodavnica.ProdavnicaId)
                {
                    prodavnice.Add(prodavnica);
                    return true;
                }
            }
            return false;
        }

        public bool Delete(Prodavnica prodavnica)
        {
            List<Prodavnica> prodavnice = new List<Prodavnica>();
            prodavnice.Add(new Prodavnica { ProdavnicaId = 4, Adresa = "Karađorđeva bb", Grad = "Beograd", Kontakt = "prod@karadjorjeva.com", URLSlike = "//////" });
            prodavnice.Add(new Prodavnica { ProdavnicaId = 5, Adresa = "Markova bb", Grad = "Kikinda", Kontakt = "prod@markova.com", URLSlike = "//////" });
            prodavnice.Add(new Prodavnica { ProdavnicaId = 6, Adresa = "Uroseva bb", Grad = "Beograd", Kontakt = "prod@uroseva.com", URLSlike = "//////" });

            foreach (var p in prodavnice)
            {
                if (p.ProdavnicaId == prodavnica.ProdavnicaId)
                {
                    prodavnice.Remove(prodavnica);
                    return true;
                }
            }
            return false;
        }

        public List<Prodavnica> Get()
        {
            List<Prodavnica> prodavnice = new List<Prodavnica>();
            prodavnice.Add(new Prodavnica { ProdavnicaId = 4, Adresa = "Karađorđeva bb", Grad = "Beograd", Kontakt = "prod@karadjorjeva.com", URLSlike = "//////" });
            prodavnice.Add(new Prodavnica { ProdavnicaId = 5, Adresa = "Markova bb", Grad = "Kikinda", Kontakt = "prod@markova.com", URLSlike = "//////" });
            prodavnice.Add(new Prodavnica { ProdavnicaId = 6, Adresa = "Uroseva bb", Grad = "Beograd", Kontakt = "prod@uroseva.com", URLSlike = "//////" });

            return prodavnice;
        }

        public List<Obuca> GetSveObuce(int id)
        {
            List<Prodavnica> prodavnice = new List<Prodavnica>();
            prodavnice.Add(new Prodavnica { ProdavnicaId = 4, Adresa = "Karađorđeva bb", Grad = "Beograd", Kontakt = "prod@karadjorjeva.com", URLSlike = "//////" });
            prodavnice.Add(new Prodavnica { ProdavnicaId = 5, Adresa = "Markova bb", Grad = "Kikinda", Kontakt = "prod@markova.com", URLSlike = "//////" });
            prodavnice.Add(new Prodavnica { ProdavnicaId = 6, Adresa = "Uroseva bb", Grad = "Beograd", Kontakt = "prod@uroseva.com", URLSlike = "//////" });

            foreach (var p in prodavnice)
            {
                if (p.ProdavnicaId == id)
                {
                    return p.Obuce.ToList();
                }
            }
            return null;
        }

        public Prodavnica GetId(int id)
        {
            List<Prodavnica> prodavnice = new List<Prodavnica>();
            prodavnice.Add(new Prodavnica { ProdavnicaId = 4, Adresa = "Karađorđeva bb", Grad = "Beograd", Kontakt = "prod@karadjorjeva.com", URLSlike = "//////" });
            prodavnice.Add(new Prodavnica { ProdavnicaId = 5, Adresa = "Markova bb", Grad = "Kikinda", Kontakt = "prod@markova.com", URLSlike = "//////" });
            prodavnice.Add(new Prodavnica { ProdavnicaId = 6, Adresa = "Uroseva bb", Grad = "Beograd", Kontakt = "prod@uroseva.com", URLSlike = "//////" });

            foreach (var p in prodavnice)
            {
                if (p.ProdavnicaId == id)
                {
                    return p;
                }
            }
            return null;
        }

        public bool Update(Prodavnica prodavnica)
        {
            List<Prodavnica> prodavnice = new List<Prodavnica>();
            prodavnice.Add(new Prodavnica { ProdavnicaId = 4, Adresa = "Karađorđeva bb", Grad = "Beograd", Kontakt = "prod@karadjorjeva.com", URLSlike = "//////" });
            prodavnice.Add(new Prodavnica { ProdavnicaId = 5, Adresa = "Markova bb", Grad = "Kikinda", Kontakt = "prod@markova.com", URLSlike = "//////" });
            prodavnice.Add(new Prodavnica { ProdavnicaId = 6, Adresa = "Uroseva bb", Grad = "Beograd", Kontakt = "prod@uroseva.com", URLSlike = "//////" });

            foreach (var p in prodavnice)
            {
                if (p.ProdavnicaId == prodavnica.ProdavnicaId)
                {
                    p.Adresa= prodavnica.Adresa;
                    p.URLSlike = prodavnica.URLSlike;
                    p.Grad = prodavnica.Grad;
                    p.Kontakt = prodavnica.Kontakt;
                    return true;
                }
            }
            return false;
        }
    }
}
