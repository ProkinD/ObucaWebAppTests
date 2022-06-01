using ObućaWebApp.Models;
using ObućaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObućaUnitTests
{
    class ObucaFakeRepository : IObucaRepository
    {
        public bool Create(Obuca obuca)
        {
            List<Obuca> artikli = new List<Obuca>();
            artikli.Add(new Obuca { ObucaId = 6, Naziv = "Puma", UrlSlike = "///", Velicina = 43, Cena = 9000.99, Kolicina = 4, ProdavnicaId = 2});
            artikli.Add(new Obuca { ObucaId = 8, Naziv = "Nike", UrlSlike = "///", Velicina = 44, Cena = 19000.99, Kolicina = 2, ProdavnicaId = 1});
            artikli.Add(new Obuca { ObucaId = 7, Naziv = "Reebok", UrlSlike = "///", Velicina = 45, Cena = 7000, Kolicina = 6, ProdavnicaId = 2});
           
            foreach (var a in artikli)
            {
                if (a.ObucaId != obuca.ObucaId)
                {
                    artikli.Add(obuca);
                    return true;
                }
            }
            return false;
        }

        public bool Delete(Obuca obuca)
        {
            List<Obuca> artikli = new List<Obuca>();
            artikli.Add(new Obuca { ObucaId = 6, Naziv = "Puma", UrlSlike = "///", Velicina = 43, Cena = 9000.99, Kolicina = 4, ProdavnicaId = 2 });
            artikli.Add(new Obuca { ObucaId = 8, Naziv = "Nike", UrlSlike = "///", Velicina = 44, Cena = 19000.99, Kolicina = 2, ProdavnicaId = 1 });
            artikli.Add(new Obuca { ObucaId = 7, Naziv = "Reebok", UrlSlike = "///", Velicina = 45, Cena = 7000, Kolicina = 6, ProdavnicaId = 2 });

            foreach (var a in artikli)
            {
                if (a.ObucaId == obuca.ObucaId)
                {
                    artikli.Remove(obuca);
                    return true;
                }
            }
            return false;
        }

        public List<Obuca> Get()
        {
            List<Obuca> artikli = new List<Obuca>();
            artikli.Add(new Obuca { ObucaId = 6, Naziv = "Puma", UrlSlike = "///", Velicina = 43, Cena = 9000.99, Kolicina = 4, ProdavnicaId = 2 });
            artikli.Add(new Obuca { ObucaId = 8, Naziv = "Nike", UrlSlike = "///", Velicina = 44, Cena = 19000.99, Kolicina = 2, ProdavnicaId = 1 });
            artikli.Add(new Obuca { ObucaId = 7, Naziv = "Reebok", UrlSlike = "///", Velicina = 45, Cena = 7000, Kolicina = 6, ProdavnicaId = 2 });

            return artikli;
        }

        public Obuca GetProdavnica(Prodavnica prodavnica)
        {
            List<Obuca> artikli = new List<Obuca>();
            artikli.Add(new Obuca { ObucaId = 6, Naziv = "Puma", UrlSlike = "///", Velicina = 43, Cena = 9000.99, Kolicina = 4, ProdavnicaId = 2 });
            artikli.Add(new Obuca { ObucaId = 8, Naziv = "Nike", UrlSlike = "///", Velicina = 44, Cena = 19000.99, Kolicina = 2, ProdavnicaId = 1 });
            artikli.Add(new Obuca { ObucaId = 7, Naziv = "Reebok", UrlSlike = "///", Velicina = 45, Cena = 7000, Kolicina = 6, ProdavnicaId = 2 });

            foreach (var a in artikli)
            {
                if (a.ProdavnicaId == prodavnica.ProdavnicaId)
                {
                    return a;
                }
            }
            return null;
        }

        public Obuca GetId(int id)
        {
            List<Obuca> artikli = new List<Obuca>();
            artikli.Add(new Obuca { ObucaId = 6, Naziv = "Puma", UrlSlike = "///", Velicina = 43, Cena = 9000.99, Kolicina = 4, ProdavnicaId = 2 });
            artikli.Add(new Obuca { ObucaId = 8, Naziv = "Nike", UrlSlike = "///", Velicina = 44, Cena = 19000.99, Kolicina = 2, ProdavnicaId = 1 });
            artikli.Add(new Obuca { ObucaId = 7, Naziv = "Reebok", UrlSlike = "///", Velicina = 45, Cena = 7000, Kolicina = 6, ProdavnicaId = 2 });

            foreach (var a in artikli)
            {
                if (a.ObucaId == id)
                {
                    return a;
                }
            }
            return null;
        }

        public bool Update(Obuca obuca)
        {
            List<Obuca> artikli = new List<Obuca>();
            artikli.Add(new Obuca { ObucaId = 6, Naziv = "Puma", UrlSlike = "///", Velicina = 43, Cena = 9000.99, Kolicina = 4, ProdavnicaId = 2 });
            artikli.Add(new Obuca { ObucaId = 8, Naziv = "Nike", UrlSlike = "///", Velicina = 44, Cena = 19000.99, Kolicina = 2, ProdavnicaId = 1 });
            artikli.Add(new Obuca { ObucaId = 7, Naziv = "Reebok", UrlSlike = "///", Velicina = 45, Cena = 7000, Kolicina = 6, ProdavnicaId = 2 });

            foreach (var a in artikli)
            {
                if (a.ObucaId == obuca.ObucaId)
                {
                    a.Naziv = obuca.Naziv;
                    a.UrlSlike = obuca.UrlSlike;
                    a.Velicina = obuca.Velicina;
                    a.Cena = obuca.Cena;
                    a.Kolicina = obuca.Kolicina;
                    return true;
                }
            }
            return false;
        }
    }
}
