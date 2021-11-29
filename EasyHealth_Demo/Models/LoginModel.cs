using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EasyHealth_Demo.Models
{
    [Keyless]
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter email.")]
        [EmailAddress]
        [StringLength(20)]
        public string EmailEntered { get; set; }

        [Required(ErrorMessage = "Please enter password.")]
        [StringLength(10)]
        [DataType(DataType.Password)]
        public string PasswordEntered { get; set; }
    }
}
