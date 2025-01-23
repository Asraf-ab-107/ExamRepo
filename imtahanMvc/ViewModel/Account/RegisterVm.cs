using System.ComponentModel.DataAnnotations;

namespace imtahanMvc.ViewModel.Account
{
    public class RegisterVm
    {
        [Required,
            MaxLength(15, ErrorMessage = "Maksimum simvol sayi 15 dir"),
            MinLength(2, ErrorMessage = "Minumum uzunluq 2 dir")]
        public string Name { get; set; }
        [Required,
            MaxLength(15, ErrorMessage = "Maksimum simvol sayi 15 dir"),
            MinLength(2, ErrorMessage = "Minumum uzunluq 2 dir")]
        public string SurName { get; set; }
        [Required,
            MaxLength(15, ErrorMessage = "Maksimum simvol sayi 15 dir"),
            MinLength(2, ErrorMessage = "Minumum uzunluq 2 dir"),
            ]
        public string UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password),Compare(nameof(Password))]
        public string PasswordConfirm { get; set; }

    }
}
