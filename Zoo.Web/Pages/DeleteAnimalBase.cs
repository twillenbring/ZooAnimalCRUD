using Microsoft.AspNetCore.Components;
using Zoo.Models.Dtos;

namespace Zoo.Web.Pages
{
    public class DeleteAnimalBase: ComponentBase
    {
        [Parameter]
        public AnimalDto? Animal { get; set; }
        [Parameter] 
        public EventCallback<bool> OnClose { get; set; }
        public string title = string.Empty;

        protected override void OnParametersSet()
        {
            title = $"Delete {Animal?.Name}";
        }

        public void Confirm()
        {
            OnClose.InvokeAsync(true);
        }
        public void Cancel()
        {
            OnClose.InvokeAsync(false);
        }
    }
}
