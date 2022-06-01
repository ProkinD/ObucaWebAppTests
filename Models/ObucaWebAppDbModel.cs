using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ObućaWebApp.Models
{
    public class ObucaWebAppDbModel : DbContext
    {
        public ObucaWebAppDbModel() 
            : base("name=ObucaWebAppDbModel")
        {
        }

        public ObucaWebAppDbModel(DbConnection connection)
           : base(connection, true)
        {
            Database.SetInitializer<ObucaWebAppDbModel>(new CreateDatabaseIfNotExists<ObucaWebAppDbModel>());

        }
        public virtual DbSet<Obuca> Obuce { get; set; }
        public virtual DbSet<Prodavnica> Prodavnce { get; set; }

    }
}