using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyHealth_Demo.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required]
        [StringLength(100)]
        public string PracticingFrom { get; set; }
        [Required]
        [StringLength(20)]
        public string Specialization { get; set; }

        [ForeignKey("Hospital")]
        public int HospitalId { get; set; }

        // navigation property
        public Hospital Hospital { get; set; }

        public ClientReview ClientReview { get; set; }

        public Appointment Appointment { get; set; }
    }
}
