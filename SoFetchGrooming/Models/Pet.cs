using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoFetchGrooming.Models
{
    /// <summary>
    /// Pet class to represent the pets in the system
    /// </summary>
    public class Pet
    {
        /// <summary>
        /// Pet ID is the ID of the pet
        /// </summary>
        [Key]
        public int PetId { get; set; }

        /// <summary>
        /// User ID is the ID of the user who owns the pet
        /// </summary>
        [Required]
        public required string UserId { get; set; }
        
        /// <summary>
        /// User is the user who owns the pet ForeignKey
        /// </summary>
        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }

        /// <summary>
        /// PetName is the name of the pet
        /// </summary>
        [Required]
        [StringLength(50)]
        public required string PetName { get; set; }

        /// <summary>
        /// PetTypeId is the Id of the type of pet (dog, cat, etc.)
        /// </summary>
        [Required]
        [ForeignKey("PetType")]
        public int PetTypeId { get; set; }
        
        /// <summary>
        /// PetType is the type of pet ForeignKey
        /// </summary>
        public virtual PetType? PetType { get; set; }

        /// <summary>
        /// PetBreed is the breed of the pet
        /// </summary>
        [Required]
        [StringLength(50)]
        public required string PetBreed { get; set; }

        /// <summary>
        /// PetColor is the color of the pet
        /// </summary>
        [Required]
        [StringLength(50)]
        public required string PetColor { get; set; }

        /// <summary>
        /// PetWeight is the weight of the pet
        /// </summary>
        [Required]
        [StringLength(50)]
        public required string PetWeight { get; set; }

        /// <summary>
        /// PetAge is the age of the pet
        /// </summary>
        [Required]
        [StringLength(50)]
        public required string PetAge { get; set; }

        /// <summary>
        /// PetGender is specifies the sex of the pet
        /// </summary>
        [Required]
        [StringLength(50)]
        public required string PetGender { get; set; }

        /// <summary>
        /// PetVaccination is the vaccination status of the pet
        /// </summary>
        [Required]
        [StringLength(50)]
        public required string PetVaccination { get; set; }

        /// <summary>
        /// PetAllergies is the allergies of the pet
        /// </summary>
        [Required]
        [StringLength(50)]
        public required string PetAllergies { get; set; }

        /// <summary>
        /// PetSpecialNeeds is the special needs of the pet
        /// </summary>
        [Required]
        [StringLength(50)]
        public required string PetSpecialNeeds { get; set; }

        /// <summary>
        /// PetMedications is the medications of the pet
        /// </summary>
        [Required]
        [StringLength(50)]
        public required string PetMedications { get; set; }
    }

    /// <summary>
    /// From Adrian:
    /// I added this ViewModel to handle the Pet creation form
    /// to handle the UserId in the controller
    /// </summary>
    public class PetViewModel
    {
        [Required]
        public string PetName { get; set; }

        [Required]
        public int PetTypeId { get; set; }

        [Required]
        public string PetBreed { get; set; }

        [Required]
        public string PetColor { get; set; }

        [Required]
        public string PetWeight { get; set; }

        [Required]
        public string PetAge { get; set; }

        [Required]
        public string PetGender { get; set; }

        [Required]
        public string PetVaccination { get; set; }

        [Required]
        public string PetAllergies { get; set; }

        [Required]
        public string PetSpecialNeeds { get; set; }

        [Required]
        public string PetMedications { get; set; }
    }
}


