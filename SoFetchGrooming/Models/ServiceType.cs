using System.ComponentModel.DataAnnotations;

namespace SoFetchGrooming.Models
{
    /// <summary>
    /// ServiceType class to represent the type of service
    /// </summary>
    public class ServiceType
    {
        /// <summary>
        /// ServiceTypeId property for the id of the service type
        /// </summary>
        [Key]
        public int ServiceTypeId { get; set; }

        /// <summary>
        /// ServiceName property for the name of the service
        /// </summary>
        [Required]
        [StringLength(50)]
        public string ServiceName { get; set; } = string.Empty;

        /// <summary>
        /// ServiceDescription property for the description of the service
        /// </summary>
        [Required]
        [StringLength(500)]
        public string ServiceDescription { get; set; } = string.Empty;

        /// <summary>
        /// ServicePrice property for the price of the service
        /// </summary>
        [Required]
        public double ServicePrice { get; set; }
    }
}
