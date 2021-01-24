using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KodluyoruzWEB.Models
{
    public class SignInModel
    {
        [Required,EmailAddress]
        [Display(Name = "Email")]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string password { get; set; }
        [Display(Name ="Beni Hatırla")]
        public bool rememberMe { get; set; }
    }
}
