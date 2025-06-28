using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LapShop.Domains.ViewModels
{
    public class AuthVM
    {
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(20, ErrorMessage = "First name cannot exceed 20 characters")]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(20, ErrorMessage = "Last name cannot exceed 20 characters")]
        public string LastName { get; set; } = null!;
        [Required(ErrorMessage = "This field is required")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "This field is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; } = null!;
        [ValidateNever]
        public string ReturnUrl { get; set; } = string.Empty;
    }
}
