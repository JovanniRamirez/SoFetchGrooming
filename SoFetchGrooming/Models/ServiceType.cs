using System.ComponentModel.DataAnnotations;

namespace SoFetchGrooming.Models
{
    public class ServiceType
    {
        [Key]
        public int ServiceTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string ServiceName { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string ServiceDescription { get; set; } = string.Empty;

        [Required]
        public double ServicePrice { get; set; }
    }
}
