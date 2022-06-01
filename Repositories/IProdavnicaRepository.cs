using ObućaWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObućaWebApp.Repositories
{
    public interface IProdavnicaRepository
    {
        List<Prodavnica> Get();
        Prodavnica GetId(int id);

        List<Obuca> GetSveObuce(int id);
        bool Create(Prodavnica prodavnica);
        bool Update(Prodavnica prodavnica);
        bool Delete(Prodavnica prodavnica);
    }
}