using imtahanMvc.Models.BaseEntites;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace imtahanMvc.Models
{
    public class Teachers : BaseEntity
    {
        [Required,
            MaxLength(15, ErrorMessage = "Maksimum simvol sayi 15 dir"),
            MinLength(2, ErrorMessage = "Minumum uzunluq 2 dir")]
        public string Name { get; set; }
        [Required,
            MaxLength(15, ErrorMessage = "Maksimum simvol sayi 15 dir"),
            MinLength(2, ErrorMessage = "Minumum uzunluq 2 dir")]
        public string Surname { get; set; }
        [Required,
            MaxLength(15, ErrorMessage = "Maksimum simvol sayi 15 dir"),
            MinLength(2, ErrorMessage = "Minumum uzunluq 2 dir")]
        public string ImgUrl  { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
        public Position? Position { get; set; }
    }
}
