using Microsoft.AspNetCore.Components;
using Zoo.Models.Dtos;
using Zoo.Web.Services.Contracts;

namespace Zoo.Web.Pages
{
    public class EditAnimalBase: ComponentBase
    {
        [Inject]
        public IZooAnimalsService ZooAnimalsService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string title = string.Empty;
        [Parameter]
        public int? Id { get; set; }
        //public AnimalDto? existingAnimal;
        public AnimalDto? newAnimal;
        protected override async Task OnInitializedAsync()
        {
            if(Id is not null) 
            {
                var animalFound = await ZooAnimalsService.GetAnimal(Id.Value);
                
                newAnimal = new()
                {
                    Id = animalFound.Id,
                    Name = animalFound.Name,
                    Species = animalFound.Species,
                    Age = animalFound.Age,
                    Gender = animalFound.Gender,
                };
                title = $"Edit {newAnimal.Name}";
            }
            else 
            {
                newAnimal = new()
                {
                    Name = string.Empty,
                    Species = string.Empty,
                    Age = 0,
                    Gender = string.Empty
                };
                title = "New Animal";
            }
        }

        public async Task HandleSubmit()
        {
            if(newAnimal!.Id == 0)
            {
                var updateAnimal = FromAnimalDto(newAnimal);
                await ZooAnimalsService.AddAnimal(updateAnimal);
            }
            else
            {
                await ZooAnimalsService.UpdateAnimal(newAnimal!);
            }
            NavigationManager.NavigateTo("/");
        }

        public void Cancel()
        { 
            NavigationManager.NavigateTo("/");
        }

        public static CreateAnimalDto FromAnimalDto(AnimalDto animalDto)
        {
            return new CreateAnimalDto
            {
                Name = animalDto.Name,
                Species = animalDto.Species,
                Age = animalDto.Age,
                Gender = animalDto.Gender
            };
        }
    }
}
