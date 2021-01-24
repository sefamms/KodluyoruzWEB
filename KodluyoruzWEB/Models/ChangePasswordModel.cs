using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KodluyoruzWEB.Models
{
    public class ChangePasswordModel
    {
        [Required,DataType(DataType.Password),Display(Name ="Şimdiki Parola")]
        public string currentPassword { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "Yeni Parola")]
        public string newPassword { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "Parola Onaya")]
        [Compare("newPassword",ErrorMessage ="Parolalar eşleşmiyor")]
        public string confirmPassword { get; set; }
    }
}
