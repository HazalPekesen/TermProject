using EntityLayer.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EntityLayer.ViewModels
{
    public class UserEditViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Ad alanı boş bırakılamaz!")]
        [Display(Name = "Kullanıcı Adı:")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "Email alanı boş bırakılamaz!")]
        [EmailAddress(ErrorMessage = "Email formatı yanlış!")]
        [Display(Name = "Email:")]
        public string Email { get; set; } = null!;

        [DataType(DataType.Date)]
        [Display(Name = "Doğum Tarihi:")]
        public DateTime? BirthDate { get; set; } // nullable olabilir

        [Display(Name = "Şehir:")]
        public string? City { get; set; }

        [Display(Name = "Profil Resmi:")]
        public IFormFile? Picture { get; set; }

        [Display(Name = "Cinsiyet:")]
        public Gender? Gender { get; set; }
    }
}
