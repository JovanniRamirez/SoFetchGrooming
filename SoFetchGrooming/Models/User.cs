﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoFetchGrooming.Models
{
    /// <summary>
    /// Represents a user in the identity system
    /// Extends the IdentityUser class from the Microsoft.AspNetCore.Identity namespace
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// Property for the first name of the user.
        /// </summary>
        [Required]
        [StringLength(50)]
        public required string FirstName { get; set; }

        /// <summary>
        /// Property for the last name of the user.
        /// </summary>
        [Required]
        [StringLength(50)]
        public required string LastName { get; set; }

        // Navigation Property
        public virtual required ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
