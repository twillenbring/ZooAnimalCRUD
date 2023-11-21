using Microsoft.EntityFrameworkCore;
using Zoo.Api.Entities;

namespace Zoo.Api.Data
{
    public class ZooDbContext: DbContext
    {
        public ZooDbContext(DbContextOptions<ZooDbContext> options): base(options) 
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ZooAnimal>().HasData(new ZooAnimal
            {
                Id = 1,
                Name = "Mia",
                Species = "Lion",
                Age = 4,
                Gender = "Female"
            });
            modelBuilder.Entity<ZooAnimal>().HasData(new ZooAnimal
            {
                Id = 2,
                Name = "Mason",
                Species = "Jaguar",
                Age = 3,
                Gender = "Male"
            });
            modelBuilder.Entity<ZooAnimal>().HasData(new ZooAnimal
            {
                Id = 3,
                Name = "Henry",
                Species = "Orangutan",
                Age = 2,
                Gender = "Male"
            });
            modelBuilder.Entity<ZooAnimal>().HasData(new ZooAnimal
            {
                Id = 4,
                Name = "Rae",
                Species = "Bear",
                Age = 1,
                Gender = "Male"
            });


        }

        public DbSet<ZooAnimal> ZooAnimals {  get; set; }
    }
}
