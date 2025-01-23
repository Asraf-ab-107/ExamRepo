using System.ComponentModel.DataAnnotations;

namespace imtahanMvc.ViewModel.Account
{
    public class LoginVm
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RemeberMe { get; set; }
    }
}
