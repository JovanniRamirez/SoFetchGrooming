using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace SoFetchGrooming.Models
{
    /// <summary>
    /// Appointment class
    /// </summary>
    public class Appointment
    {
        [Key]
        public int appointmentId { get; set; }

        [Required]
        public int userId { get; set; }

        [Required]
        public int petId { get; set; }

        [Required]
        public int serviceTypeId { get; set; }

        [Required]
        [Display(Name = "Appointment Date")]
        public DateTime appointmentDate { get; set; }

        [Required]
        [Display(Name = "Appointment Time")]
        public TimeSpan appointmentTime { get; set; }
    }

}
