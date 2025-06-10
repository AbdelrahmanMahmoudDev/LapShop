using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LapShop.Domains.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "This field is required")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "This field is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; } = null!;
        public string ReturnUrl { get; set; } = string.Empty;
    }
}
