using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webstack_WC2_1.Models
{
    public class Product
    {
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public string Soort { get; set; }
        public decimal PrijsDecimal { get; set; }

        public Product()
        {
            
        }

        public Product(string naam, string beschrijving, string soort, decimal prijsDecimal)
        {
            Naam = naam;
            Beschrijving = beschrijving;
            Soort = soort;
            PrijsDecimal = prijsDecimal;
        }
    }
}