using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KodluyoruzWEB.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public  Product product { get; set; }
        public int CategoryId { get; set; }
        public Category category { get; set; }
    
    }
}
