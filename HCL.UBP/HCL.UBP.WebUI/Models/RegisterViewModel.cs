using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HCL.UBP.WebUI.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(36, ErrorMessage = "The {0} must be at least {2} characters and maximum 36 characters long.", MinimumLength = 8)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [StringLength(36, ErrorMessage = "The {0} must be at least {2} characters and maximum 36 characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}