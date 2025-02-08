using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoFetchGrooming.Models
{
    /// <summary>
    /// PetList class to represent the list of pets in the system
    /// </summary>
    public class PetList
    {
        /// <summary>
        /// PetListId is the ID of the pet list
        /// </summary>
        [Key]
        public int PetListId { get; set; }

        /// <summary>
        /// UserId is the ID of the user who owns the pet list
        /// </summary>
        [Required]
        public required string UserId { get; set; }

        /// <summary>
        /// User is the user who owns the pet list ForeignKey
        /// </summary>
        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }

        /// <summary>
        /// Pets is the list of pets in the pet list
        /// </summary>
        public List<Pet> Pets { get; set; } = new List<Pet>();
    }
}
