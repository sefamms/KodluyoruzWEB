using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KodluyoruzWEB.Data
{
    public class Books
    {
        
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string desciption { get; set; }
        public string category { get; set; }
        public int languageId { get; set; }

        public Language Language { get; set; }
        public int totalPages { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string coverImageUrl { get; set; }

        public ICollection<BookGallery> bookGalery { get; set; }

        public string  bookPdfUrl { get; set; }
    }
}
