using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoFetchGrooming.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public required string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public required string UserEmail { get; set; }

        [Required]
        [StringLength(50)]
        public required string UserPassword { get; set; }

        [Required]
        [StringLength(50)]
        public required string UserPhone { get; set; }

        // Navigation Property
        public virtual required ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
