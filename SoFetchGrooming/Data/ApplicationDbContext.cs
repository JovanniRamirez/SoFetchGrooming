using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

        public DbSet<PetType> PetTypes { get; set; } = default!;

        public DbSet<ProductImage> ProductImages { get; set; } = default!;

        public DbSet<Product> Products { get; set; } = default!;

        public DbSet<ServiceType> ServiceTypes { get; set; } = default!;

        public DbSet<ShoppingCart> ShoppingCarts { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed PetTypes
            modelBuilder.Entity<PetType>().HasData(
                new PetType { PetTypeId = 1, PetTypeName = "Dog" },
                new PetType { PetTypeId = 2, PetTypeName = "Cat" }
            );
            
            // Configure the one-to-many relationship between Product and ProductImage
            modelBuilder.Entity<ProductImage>()
                .HasOne(p => p.Product)
                .WithMany(p => p.ProductImages)
                .HasForeignKey(p => p.ProductId);
            
            // Seed ServiceTypes
            modelBuilder.Entity<ServiceType>().HasData(
                new ServiceType { ServiceTypeId = 1, ServiceName = "Full Body Wash", ServiceDescription = "Complete body wash for pets.", ServicePrice = 0 },
                new ServiceType { ServiceTypeId = 2, ServiceName = "De-Shedding", ServiceDescription = "Remove excess shedding.", ServicePrice = 0 },
                new ServiceType { ServiceTypeId = 3, ServiceName = "Dog Grooming", ServiceDescription = "Complete grooming for dogs.", ServicePrice = 0 },
                new ServiceType { ServiceTypeId = 4, ServiceName = "Dog Nail Trimming", ServiceDescription = "Trimming and shaping of dog nails.", ServicePrice = 0 },
                new ServiceType { ServiceTypeId = 5, ServiceName = "Cat Nail Trimming", ServiceDescription = "Trimming and shaping of cat nails.", ServicePrice = 0 },
                new ServiceType { ServiceTypeId = 6, ServiceName = "Ear Cleaning", ServiceDescription = "Gentle cleaning of pet ears.", ServicePrice = 0 },
                new ServiceType { ServiceTypeId = 7, ServiceName = "Tooth Brushing", ServiceDescription = "Teeth brushing for pets.", ServicePrice = 0 },
                new ServiceType { ServiceTypeId = 8, ServiceName = "Gland Expression", ServiceDescription = "Helps maintain pet gland health.", ServicePrice = 0 },
                new ServiceType { ServiceTypeId = 9, ServiceName = "Brushing", ServiceDescription = "Regular brushing to remove tangles.", ServicePrice = 0 },
                new ServiceType { ServiceTypeId = 10, ServiceName = "Flea Control", ServiceDescription = "Treatment to remove fleas.", ServicePrice = 0 },
                new ServiceType { ServiceTypeId = 11, ServiceName = "Breed Specific Haircuts", ServiceDescription = "Special haircuts based on breed.", ServicePrice = 0 }
            );
        }
    }
}
