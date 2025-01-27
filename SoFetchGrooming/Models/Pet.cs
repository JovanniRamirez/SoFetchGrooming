using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoFetchGrooming.Models
{
    public class Pet
    {
        [Key]
        public int PetId { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User? User { get; set; }

        [Required]
        public required string PetName { get; set; }

        [Required]
        public required string PetType { get; set; }

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
