using ObućaWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObućaWebApp.Repositories
{
    public interface IObucaRepository
    {
        List<Obuca> Get();
        Obuca GetId(int id);

        //Obuca GetProdavnica(Prodavnica prodavnica);
        bool Create(Obuca clan);
        bool Update(Obuca clan);
        bool Delete(Obuca clan);
    }
}