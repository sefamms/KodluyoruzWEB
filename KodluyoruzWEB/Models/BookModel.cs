using KodluyoruzWEB.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KodluyoruzWEB.Models
{
    public class BookModel
    { 
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage ="Başlık alanı giriniz")]
        public string title { get; set; }
        [Required(ErrorMessage = "Yazaar alanı giriniz")]
        public string author { get; set; }
        [Required(ErrorMessage = "Tanım alanı giriniz")]
        public string desciption { get; set; }
        [Required(ErrorMessage = "Kategori alanı giriniz")]
        public string category { get; set; }
        public int languageId { get; set; }
        public string language { get; set; }
        public int? totalPages { get; set; }
        public IFormFile coverPhoto { get; set; }
        public string coverImageUrl { get; set; }
        [Display(Name ="Kitap Resimleri Seçiniz")]
        public IFormFileCollection GalleryFiles { get; set; }

        public List<GalleryModel> Gallery { get; set; }
        [Display(Name ="Kitabı Pdf Formatında Yükle")]
        public IFormFile BookPdf { get; set; }
        public string BookPdfUrl { get; set; }

    }
} 
