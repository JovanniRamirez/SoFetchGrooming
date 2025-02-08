using System.ComponentModel.DataAnnotations;

namespace SoFetchGrooming.Models
{
    /// <summary>
    /// PetType class to represent the type of pet
    /// </summary>
    public class PetType
    {
        /// <summary>
        /// PetTypeId property for the id of the pet type
        /// </summary>
        [Key]
        public int PetTypeId { get; set; }

        /// <summary>
        /// PetTypeName property for the name of the pet type
        /// </summary>
        [Required]
        [StringLength(50)]
        public required string PetTypeName { get; set; }
    }
}
