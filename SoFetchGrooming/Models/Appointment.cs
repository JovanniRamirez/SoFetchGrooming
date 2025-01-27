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
        public int appointmentId { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual required User User { get; set; }


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
