using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EasyHealth_Demo.Models
{
    [Keyless]
    public class RegisterAdminModel
    {
        [Required(ErrorMessage = "Please enter email.")]
        [EmailAddress]
        [StringLength(20)]
        public string AdminEmailEntered { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        [DataType(DataType.Password)]
        [StringLength(10, MinimumLength = 6)]
        public string AdminPassword { get; set; }

        [Required(ErrorMessage = "Please re-enter your password.")]
        [DataType(DataType.Password)]
        [Compare("AdminPassword")]
        public string ConfirmAdminPassword { get; set; }
    }
}
