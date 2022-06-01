using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ObućaWebApp.Models
{
    public class Prodavnica
    {
        public Prodavnica()
        {
            Obuce = new List<Obuca>();
        }

        [Key]
        public int ProdavnicaId { get; set; }
        public string Adresa { get; set; }
        public string Grad { get; set; }
        public string Kontakt { get; set; }
        
        public ICollection<Obuca> Obuce { get; set; }
        public string URLSlike { get; set; }
    }
}