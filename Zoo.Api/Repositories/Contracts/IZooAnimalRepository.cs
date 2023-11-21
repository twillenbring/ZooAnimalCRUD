using Zoo.Api.Entities;
using Zoo.Models.Dtos;

namespace Zoo.Api.Repositories.Contracts
{
    public interface IZooAnimalRepository
    {
        Task<IEnumerable<ZooAnimal>> GetAllAnimalsAsync();
        Task<ZooAnimal> GetAnimalByIdAsync(int id);
        Task DeleteZooAnimalAsync(int id);
        Task UpdateZooAnimal(ZooAnimal zooAnimal);
        Task<ZooAnimal> CreateZooAnimalAsync(CreateAnimalDto animalDto);

    }
}
