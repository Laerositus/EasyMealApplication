using System;
using System.ComponentModel.DataAnnotations;

namespace EasyMealManagementGUI.Models.ViewModels
{
    public class RegisterModel
    {
        [Required]
        [UIHint("username")]
        public string Username { get; set; }

        [Required]
        [UIHint("email")]
        public string Email { get; set; }

        [Required]
        [UIHint("password")]
        public string Password { get; set; }

        [Required]
        [UIHint("date of birth")]
        public DateTime DOB { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }
}
