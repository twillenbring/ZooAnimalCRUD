using Microsoft.EntityFrameworkCore;
using Zoo.Api.Data;
using Zoo.Api.Entities;
using Zoo.Api.Repositories.Contracts;
using Zoo.Models.Dtos;

namespace Zoo.Api.Repositories
{
    public class ZooAnimalRepository : IZooAnimalRepository
    {
        private readonly ZooDbContext _zooDbContext;

        public ZooAnimalRepository(ZooDbContext zooDbContext)
        {
            _zooDbContext = zooDbContext;
        }

        public async Task<ZooAnimal> CreateZooAnimalAsync(CreateAnimalDto animalDto)
        {
            var newZooAnimal = new ZooAnimal
            {
                Name = animalDto.Name,
                Species = animalDto.Species,
                Age = animalDto.Age,
                Gender = animalDto.Gender
                
            };
            if(newZooAnimal != null )
            {
                var result = await _zooDbContext.ZooAnimals.AddAsync( newZooAnimal );
                await _zooDbContext.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }

        public async Task DeleteZooAnimalAsync(int id)
        {
            var result = await _zooDbContext.ZooAnimals.FindAsync(id);
            if(result != null)
            {
                _zooDbContext.ZooAnimals.Remove(result);
                await _zooDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ZooAnimal>> GetAllAnimalsAsync()
        {
            return await _zooDbContext.ZooAnimals.ToListAsync();
           
        }

        public async Task<ZooAnimal> GetAnimalByIdAsync(int id)
        {
            var result = await _zooDbContext.ZooAnimals.FirstOrDefaultAsync(z => z.Id == id);
            if(result == null)
            {
                return null;
            }
            return result;
        }

        public async Task UpdateZooAnimal(ZooAnimal zooAnimal)
        {
            await _zooDbContext.SaveChangesAsync();
        }
    }
}
