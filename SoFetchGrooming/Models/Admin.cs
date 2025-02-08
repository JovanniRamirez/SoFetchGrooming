using System.ComponentModel.DataAnnotations;

namespace SoFetchGrooming.Models
{
    /// <summary>
    /// Admin class
    /// Most likely removed if we are to use Identity for Admins
    /// </summary>
    public class Admin
    {
        /// <summary>
        /// AdminId property for the id of the admin
        /// </summary>
        [Key]
        public int AdminId { get; set; }

        /// <summary>
        /// AdminName property for the name of the admin
        /// </summary>
        [Required]
        [StringLength(50)]
        public string AdminName { get; set; }

        /// <summary>
        /// AdminEmail property for the email of the admin
        /// </summary>
        [Required]
        [StringLength(50)]
        public string AdminEmail { get; set; }
    }
}
