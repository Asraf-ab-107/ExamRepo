using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace imtahanMvc.Models
{
    public class AppUser : IdentityUser
    {
        [Required,
            MaxLength(15,ErrorMessage ="Maksimum simvol sayi 15 dir"),
            MinLength(2,ErrorMessage ="Minumum uzunluq 2 dir")]
        public string Name { get; set; }
        [Required,
            MaxLength(15, ErrorMessage = "Maksimum simvol sayi 15 dir"),
            MinLength(2, ErrorMessage = "Minumum uzunluq 2 dir")]
        public string SurName { get; set; }
    }
}
