using System.ComponentModel.DataAnnotations;

namespace EasyHealth_Demo.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [EmailAddress]
        [StringLength(20)]
        public string AdminEmail { get; set; }

        [Required]
        [StringLength(100)]
        public string PasswordHash { get; set; }
    }
}
