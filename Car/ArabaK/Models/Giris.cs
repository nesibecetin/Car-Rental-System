using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArabaK.Models
{
    public class Giris
    {
        [Required(ErrorMessage = "Lütfen mail adresinizi giriniz.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
        [DataType(DataType.Password)]
        [Display(Name = "Sifre")]
        public string Password { get; set; }
    }
}