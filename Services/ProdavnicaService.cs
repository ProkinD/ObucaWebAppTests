using ObućaWebApp.Models;
using ObućaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObućaWebApp.Services
{
    public class ProdavnicaService
    {
        private readonly IProdavnicaRepository _repository;

        public ProdavnicaService()
        {
            _repository = new ProdavnicaRepository();
        }

        public ProdavnicaService(IProdavnicaRepository repository)
        {
            _repository = repository;
        }

        public List<Prodavnica> Get()
        {
            return _repository.Get();
        }

        public Prodavnica GetId(int id)
        {
            return _repository.GetId(id);
        }

        public bool Add(Prodavnica prodavnica)
        {
            if (ProdavnicaDoesntExist(prodavnica))
            {
                _repository.Create(prodavnica);
                return true;

            }
            return false;
        }

        public List<Obuca> GetSveObuce(int id)
        {
           return _repository.GetSveObuce(id);
        }

        public bool Edit(Prodavnica prodavnica)
        {
            if (!ProdavnicaDoesntExist(prodavnica))
            {
                _repository.Update(prodavnica);

                return true;
            }

            return false;
        }

        public bool Remove(int id)
        {
            var prodavnicas = GetId(id);
            return _repository.Delete(prodavnicas);
        }

        public bool ProdavnicaDoesntExist(Prodavnica prodavnica)
        {
            var existingProdavnica = _repository.GetId(prodavnica.ProdavnicaId);
            return existingProdavnica == null;
        }
    }
}