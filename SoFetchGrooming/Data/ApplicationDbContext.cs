﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoFetchGrooming.Models;

namespace SoFetchGrooming.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Admin> Admins { get; set; } = default!;

        public DbSet<ApplicationUser> ApplicationUsers { get; set; } = default!;

        public DbSet<Appointment> Appointment { get; set; } = default!;

        public DbSet<CartItem> CartItems { get; set; } = default!;

        public DbSet<Order> Orders { get; set; } = default!;

        public DbSet<OrderItem> OrderItems { get; set; } = default!;

        public DbSet<Pet> Pets { get; set; } = default!;

        public DbSet<PetList> PetLists { get; set; } = default!;

        public DbSet<PetType> PetTypes { get; set; } = default!;

        public DbSet<Product> Products { get; set; } = default!;

        public DbSet<ServiceType> ServiceTypes { get; set; } = default!;

        public DbSet<ShoppingCart> ShoppingCarts { get; set; } = default!;


    }
}
