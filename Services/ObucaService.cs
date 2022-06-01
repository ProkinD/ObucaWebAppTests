using ObućaWebApp.Models;
using ObućaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObućaWebApp.Services
{
    public class ObucaService
    {
        private readonly IObucaRepository _repository;

        public ObucaService()
        {
            _repository = new ObucaRepository();
        }

        public ObucaService(IObucaRepository repository)
        {
            _repository = repository;
        }

        public List<Obuca> Get()
        {
            return _repository.Get();
        }

        public Obuca GetId(int id)
        {
            return _repository.GetId(id);
        }

        public bool Add(Obuca obuca)
        {
            if (ObucaDoesntExist(obuca))
            {
                _repository.Create(obuca);
                return true;

            }

            return false;

        }


        public bool Edit(Obuca obuca)
        {
            if (!ObucaDoesntExist(obuca))
            {
                _repository.Update(obuca);

                return true;
            }

            return false;
        }

        public bool Remove(int id)
        {

            var obucas = GetId(id);

            return  _repository.Delete(obucas);

        }

        public bool ObucaDoesntExist(Obuca obuca)
        {
            var existingObuca = _repository.GetId(obuca.ObucaId);
            return existingObuca == null;
        }

    }
}