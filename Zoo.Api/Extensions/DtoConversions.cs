using Zoo.Api.Entities;
using Zoo.Models.Dtos;

namespace Zoo.Api.Extensions
{
    public static class DtoConversions
    {
        public static AnimalDto ConvertToAnimalDto(this ZooAnimal zooAnimal) 
        {
            if(zooAnimal == null)
            {
                throw new ArgumentNullException(nameof(zooAnimal));
            }
            return new AnimalDto
            {
                Id = zooAnimal.Id,
                Name = zooAnimal.Name,
                Species = zooAnimal.Species,
                Age = zooAnimal.Age,
                Gender = zooAnimal.Gender,
            };
        }
        public static IEnumerable<AnimalDto> ConvertToAnimalsDto(this IEnumerable<ZooAnimal> zooAnimals)
        {
            if(zooAnimals == null)
            {
                throw new ArgumentNullException(nameof(zooAnimals));
            }
            return zooAnimals.Select(animals => animals.ConvertToAnimalDto());
        }
    }
}
