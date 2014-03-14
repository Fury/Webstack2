using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Webstack_WC2_1.Models
{
    public class ProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public int SelectedCategory { get; set; }
        public SelectList CategorieSelectList { get; set; }
    }
}