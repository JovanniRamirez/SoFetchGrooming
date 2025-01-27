using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoFetchGrooming.Models
{
    public class PetList
    {
        [Key]
        public int PetListId { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User? User { get; set; }

        public List<Pet> Pets { get; set; } = new List<Pet>();
    }
}
