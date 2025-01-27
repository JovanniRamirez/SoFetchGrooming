using System.ComponentModel.DataAnnotations;

namespace SoFetchGrooming.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Required]
        public string AdminName { get; set; }

        [Required]
        public string AdminEmail { get; set; }
    }
}
