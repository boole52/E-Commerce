using Etities.Concrete;
using System.Collections.Generic;

namespace MvcWebUI.Models
{
    public class ProductUpdateViewModel
    {
        public Product Product { get; set; }
        public List<Category> Catgorires { get; set; }
    }
}