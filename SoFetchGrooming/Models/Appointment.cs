﻿using Microsoft.AspNetCore.Mvc.Rendering;
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
        public Appointment()
        {
            UserId = "";
            PetId = 0;
            ServiceTypeId = 0;
            AppointmentDate = DateTime.Now;
            AppointmentTime = TimeSpan.Zero;
        }

        /// <summary>
        /// AppointmentId property for the id of the appointment
        /// </summary>
        [Key]
        public int AppointmentId { get; set; }

        /// <summary>
        /// UserId property for the id of the user 
        /// </summary>
        [Required]
        public required string UserId { get; set; }

        /// <summary>
        /// User property for the user connects the userId to the ApplicationUser
        /// </summary>
        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }

        /// <summary>
        /// PetId property for the id of the pet
        /// </summary>
        [Required]
        [Display(Name = "Pet")]
        public int PetId { get; set; }

        /// <summary>
        /// ServiceTypeId property for the id of the service type
        /// </summary>
        [Required]
        [Display(Name = "Service Type")]
        public int ServiceTypeId { get; set; }

        /// <summary>
        /// AppointmentDate property for the date of the appointment
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Appointment Date")]
        public DateTime AppointmentDate { get; set; }

        /// <summary>
        /// AppointmentTime property for the time of the appointment
        /// </summary>
        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Appointment Time")]
        public TimeSpan AppointmentTime { get; set; }
    }

    public class AppointmentViewModel
    {
        public int? AppointmentId { get; set; } // Nullable for new appointments

        [Required]
        public required int PetId { get; set; }

        [Required]
        public required int ServiceTypeId { get; set; }

        [Required]
        public required DateTime AppointmentDate { get; set; }

        [Required]
        public required TimeSpan AppointmentTime { get; set; }

    }
}
