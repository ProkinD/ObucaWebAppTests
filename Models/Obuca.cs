using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ObućaWebApp.Models
{
    public class Obuca
    {
        [Key]
        public int ObucaId { get; set; }
        public string UrlSlike { get; set; }
        public string Naziv { get; set; }
        public int Velicina { get; set; }
        public double Cena { get; set; }
        public int Kolicina { get; set; }
        public int ProdavnicaId { get; set; }
        [ForeignKey("ProdavnicaId")]
        public Prodavnica Prodavnica { get; set; }
               
    }
}