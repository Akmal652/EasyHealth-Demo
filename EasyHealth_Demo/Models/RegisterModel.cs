using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EasyHealth_Demo.Models
{
    [Keyless]
    public class RegisterModel
    {
        [Required(ErrorMessage = "Please enter your first name.")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name.")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your phone number.")]
        [Phone]
        [StringLength(20, MinimumLength = 10)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter your email.")]
        [EmailAddress]
        [StringLength(20)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        [DataType(DataType.Password)]
        [StringLength(10, MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please re-enter your password.")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
