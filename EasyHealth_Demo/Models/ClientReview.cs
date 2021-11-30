using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyHealth_Demo.Models
{
    public class ClientReview
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        [Range(0,10)]
        public int WaitTimeRating { get; set; }

        [Range(0, 10)]
        public int DoctorRating { get; set; }

        [Required]
        [StringLength(100)]
        public string Review { get; set; }

        [Required]
        public bool IsDoctorRecommended { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? ReviewDate { get; set; }

        public Client Client { get; set; }

        public Doctor Doctor { get; set; }
    }
}
