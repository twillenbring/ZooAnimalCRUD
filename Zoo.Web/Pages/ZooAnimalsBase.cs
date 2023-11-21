using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Zoo.Models.Dtos;
using Zoo.Web.Services.Contracts;

namespace Zoo.Web.Pages
{
    public class ZooAnimalsBase: ComponentBase
    {
        public AnimalDto? currentAnimal;
        [Inject]
        public IZooAnimalsService ZooAnimalsService { get; set;}
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public IEnumerable<AnimalDto>? Animals { get; set;}

        protected override async Task OnInitializedAsync()
        {
            Animals = await ZooAnimalsService.GetAnimals();
        }

        public void CreateZooAnimal()
        {
            NavigationManager.NavigateTo("/animal");
        }

        public void EditAnimal(int id)
        {
            NavigationManager.NavigateTo($"/animal/{id}");
        }

        public async Task OnDeleteModalClose(bool accepted)
        {
            if(accepted)
            {
                await ZooAnimalsService.DeleteAnimal(currentAnimal!.Id);
                Animals = await ZooAnimalsService.GetAnimals();
            }
            
        }
        public void SetCurrentAnimal(AnimalDto animal)
        {
            currentAnimal = animal;
            
        }

       
    }
}
