using System.ComponentModel.DataAnnotations;

namespace EasyMealManagementGUI.Models.ViewModels
{
    public class LoginModel
    {

        [Required]
        [UIHint("email")]
        public string Email { get; set; }

        [Required]
        [UIHint("password")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }
}
