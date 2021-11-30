using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyHealth_Demo.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        [ForeignKey("Hospital")]
        public int HospitalId { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime EndTime { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? AppointmentDate { get; set; }

        [Required]
        public string AppointmentStatus { get; set; }
        [Required]
        public string AppBookingChannelName { get; set; }

        public Client Client { get; set; }

        public Doctor Doctor { get; set; }

        public Hospital Hospital { get; set; }
    }
}
