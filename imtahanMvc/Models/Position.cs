using imtahanMvc.Models.BaseEntites;
using System.ComponentModel.DataAnnotations;

namespace imtahanMvc.Models
{
    public class Position : BaseEntity
    {
        [Required,
            MaxLength(15, ErrorMessage = "Maksimum simvol sayi 15 dir"),
            MinLength(2, ErrorMessage = "Minumum uzunluq 2 dir")]
        public string Name { get; set; }
        public List<Teachers>? Teachers { get; set; }
    }
}
