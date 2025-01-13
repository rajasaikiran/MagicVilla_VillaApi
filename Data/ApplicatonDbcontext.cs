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
                    Name = "First Villa",
                    Description = "Connection was successfully established with the server, but then an error occurred duri",
                    ImageUrl = "Dummy",
                    Occupency = 130,
                    Rate = 104342125,
                     Sqft = 1024
                },
                   new Villa()
                   {
                       Id = 2,
                       Name = "Second Villa",
                       Description = "Connection was successfully established with the server, but then an error occurred duri",
                       ImageUrl = "Dummy",
                       Occupency = 1430,
                       Rate = 104342125,
                       Sqft = 1024
                   },
                          new Villa()
                          {
                              Id = 3,
                              Name = "Third Villa",
                              Description = "Connection was successfully established with the server, but then an error occurred duri",
                              ImageUrl = "Dummy",
                              Occupency = 1530,
                              Rate = 1742125,
                              Sqft = 1024
                          }
                );

         }
    }
}
