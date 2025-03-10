using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoFetchGrooming.Models
{
    /// <summary>
    /// Pet class to represent the pets in the system
    /// </summary>
    public class Pet
    {
        public Pet()
        {
            UserId = "";
            PetName = "";
            PetTypeId = 0;
            PetBreed = "";
            PetColor = "";
            PetWeight = "";
            PetAge = "";
            PetGender = "";
            PetVaccination = "";
            PetAllergies = "";
            PetSpecialNeeds = "";
            PetMedications = "";
        }

        /// <summary>
        /// Pet ID is the ID of the pet
        /// </summary>
        [Key]
        public int PetId { get; set; }

        /// <summary>
        /// User ID is the ID of the user who owns the pet
        /// </summary>
        [Required(ErrorMessage = "User ID is required")]
        public required string UserId { get; set; }
        
        /// <summary>
        /// User is the user who owns the pet ForeignKey
        /// </summary>
        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }

        /// <summary>
        /// PetName is the name of the pet
        /// </summary>
        [Required(ErrorMessage = "Pet name is required")]
        [StringLength(50, ErrorMessage = "Pet name cannot exceed 50 characters")]
        public required string PetName { get; set; }

        /// <summary>
        /// PetTypeId is the Id of the type of pet (dog, cat, etc.)
        /// </summary>
        [Required(ErrorMessage = "Pet type is required")]
        [ForeignKey("PetType")]
        public int PetTypeId { get; set; }
        
        /// <summary>
        /// PetType is the type of pet ForeignKey
        /// </summary>
        public virtual PetType? PetType { get; set; }

        /// <summary>
        /// PetBreed is the breed of the pet
        /// </summary>
        [Required(ErrorMessage = "Pet breed is required")]
        [StringLength(50, ErrorMessage = "Pet breed cannot exceed 50 characters")]
        public required string PetBreed { get; set; }

        /// <summary>
        /// PetColor is the color of the pet
        /// </summary>
        [Required(ErrorMessage = "Pet color is required")]
        [StringLength(50, ErrorMessage = "Pet color cannot exceed 50 characters")]
        public required string PetColor { get; set; }

        /// <summary>
        /// PetWeight is the weight of the pet
        /// </summary>
        [Required(ErrorMessage = "Pet weight is required")]
        [StringLength(50, ErrorMessage = "Pet weight cannot exceed 50 characters")]
        public required string PetWeight { get; set; }

        /// <summary>
        /// PetAge is the age of the pet
        /// </summary>
        [Required(ErrorMessage = "Pet age is required")]
        [StringLength(50, ErrorMessage = "Pet age cannot exceed 50 characters")]
        public required string PetAge { get; set; }

        /// <summary>
        /// PetGender is specifies the sex of the pet
        /// </summary>
        [Required(ErrorMessage = "Pet gender is required")]
        [StringLength(50, ErrorMessage = "Pet gender cannot exceed 50 characters")]
        public required string PetGender { get; set; }

        /// <summary>
        /// PetVaccination is the vaccination status of the pet
        /// </summary>
        [Required(ErrorMessage = "Pet vaccination is required")]
        [StringLength(50, ErrorMessage = "Pet vaccination cannot exceed 50 characters")]
        public required string PetVaccination { get; set; }

        /// <summary>
        /// PetAllergies is the allergies of the pet
        /// </summary>
        [Required(ErrorMessage = "Pet allergies is required")]
        [StringLength(50, ErrorMessage = "Pet allergies cannot exceed 50 characters")]
        public required string PetAllergies { get; set; }

        /// <summary>
        /// PetSpecialNeeds is the special needs of the pet
        /// </summary>
        [Required(ErrorMessage = "Pet special needs are required")]
        [StringLength(50, ErrorMessage = "Pet special needs cannot exceed 50 characters")]
        public required string PetSpecialNeeds { get; set; }

        /// <summary>
        /// PetMedications is the medications of the pet
        /// </summary>
        [Required(ErrorMessage = "Pet medications are required")]
        [StringLength(50, ErrorMessage = "Pet medications cannot exceed 50 characters")]
        public required string PetMedications { get; set; }
    }

    /// <summary>
    /// From Adrian:
    /// I added this ViewModel to handle the Pet creation form
    /// to handle the UserId in the controller
    /// </summary>
    public class PetViewModel
    {
        public int? PetId { get; set; } // Id is nullable to handle the case where the user is creating a new pet

        [Required]
        public required string PetName { get; set; }

        [Required]
        public required int PetTypeId { get; set; }

        [Required]
        public required string PetBreed { get; set; }

        [Required]
        public required string PetColor { get; set; }

        [Required]
        public required string PetWeight { get; set; }

        [Required]
        public required string PetAge { get; set; }

        [Required]
        public required string PetGender { get; set; }

        [Required]
        public required string PetVaccination { get; set; }

        [Required]
        public required string PetAllergies { get; set; }

        [Required]
        public required string PetSpecialNeeds { get; set; }

        [Required]
        public required string PetMedications { get; set; }
    }
}


