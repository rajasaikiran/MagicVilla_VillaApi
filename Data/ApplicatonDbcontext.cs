using MagicVilla_VillaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaApi.Data
{
    public class ApplicatonDbcontext : DbContext
    {
        public ApplicatonDbcontext(DbContextOptions<ApplicatonDbcontext> options) 
            : base(options)
        { }
   
        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Name = "Test",
                    Description = "Connection was successfully established with the server, but then an error occurred duri",
                    ImageUrl = "Dummy",
                    Occupency = 10,
                    Rate = 102125,
                    Sqft= 1024
                }
                );

         }
    }
}
