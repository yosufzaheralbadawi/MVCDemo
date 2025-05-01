using System.ComponentModel.DataAnnotations;

namespace Demo.PL.Views.Account
{
    public class ResatPasswordViewModel
    {
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

    }
}
