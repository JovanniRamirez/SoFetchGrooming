using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace SoFetchGrooming.Models
{
    /// <summary>
    /// Appointment class
    /// </summary>
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [Required]
        public required string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual required ApplicationUser User { get; set; }


        [Required]
        public int PetId { get; set; }

        [Required]
        public int ServiceTypeId { get; set; }

        [Required]
        [Display(Name = "Appointment Date")]
        public DateTime AppointmentDate { get; set; }

        [Required]
        [Display(Name = "Appointment Time")]
        public TimeSpan AppointmentTime { get; set; }
    }

}
