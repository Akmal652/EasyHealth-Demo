using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace EasyHealth_Demo.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        [StringLength(20)]
        public string EmailEntered { get; set; }

        [Required]
        [StringLength(10)]
        [DataType(DataType.Password)]
        public string PasswordEntered { get; set; }
    }
}
