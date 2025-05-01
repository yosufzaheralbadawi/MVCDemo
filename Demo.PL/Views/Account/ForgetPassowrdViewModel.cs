using System.ComponentModel.DataAnnotations;

namespace Demo.PL.Views.Account
{
    public class ForgetPassowrdViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Email is Nessecary")]
        public string Email { get; set; }
    }
}
