using Zoo.Models.Dtos;

namespace Zoo.Web.Services.Contracts
{
    public interface IZooAnimalsService
    {
        Task<IEnumerable<AnimalDto>> GetAnimals();
        Task<AnimalDto> AddAnimal(CreateAnimalDto createAnimalDto);
        Task<AnimalDto> GetAnimal(int id);
        Task<AnimalDto> UpdateAnimal(AnimalDto updateAnimal);
        Task<AnimalDto> DeleteAnimal(int id);
    }
}
