using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KodluyoruzWEB.Models
{
    public class SignUpUserModel
    {
        [Required(ErrorMessage ="Email adresi giriniz")]
        [EmailAddress(ErrorMessage ="Geçerli bir email adresi giriniz")]
        [Display(Name ="Email adress")]
        public string email { get; set; }
        [Required(ErrorMessage = "Parola giriniz")]
        [Display(Name ="Parola")]
        [Compare("confirmPassword",ErrorMessage ="Parolalar eşleşmiyor")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Display(Name ="Parola tekrar")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Parolanızı tekrar giriniz")]
        public string confirmPassword { get; set; }

        [Required(ErrorMessage ="Lütfen adınızı girin")]
        public string firstName { get; set; }
        public string lastName { get; set; }

    }
}
