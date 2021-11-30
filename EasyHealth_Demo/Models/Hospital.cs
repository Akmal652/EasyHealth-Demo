using System.ComponentModel.DataAnnotations;


namespace EasyHealth_Demo.Models
{
    public class Hospital
    {
        [Key]
        public int HospitalId { get; set; }

        [Required]
        [StringLength(100)]
        public string HospitalName { get; set; }

        [Required]
        public int FirstconsultationFee { get; set; }
        [Required]
        public int FollowupconsultationFee { get; set; }
        [Required]
        [StringLength(50)]
        public string StreetAddress { get; set; }
        [Required]
        [StringLength(20)]
        public string City { get; set; }
        [Required]
        [StringLength(20)]
        public string State { get; set; }
        [Required]
        [StringLength(20)]
        public string Country { get; set; }
        [Required]
        public int Pincode { get; set; }

        public Doctor Doctor { get; set; }

        public Appointment Appointment { get; set; }
    }
}
