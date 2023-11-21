using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using Zoo.Models.Dtos;
using Zoo.Web.Services.Contracts;

namespace Zoo.Web.Services
{
    public class ZooAnimalsService : IZooAnimalsService
    {
        private readonly HttpClient _httpClient;

        public ZooAnimalsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<AnimalDto> UpdateAnimal(AnimalDto updateAnimal)
        {
            try
            {
                var jsonRequest = JsonConvert.SerializeObject(updateAnimal);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"api/ZooAnimal/{updateAnimal.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<AnimalDto>();
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception($"Http status code: {ex.StackTrace} message: {ex.Message}");
            }
        }
        public async Task<AnimalDto> GetAnimal(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/ZooAnimal/{id}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(AnimalDto);
                    }
                    return await response.Content.ReadFromJsonAsync<AnimalDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<AnimalDto> AddAnimal(CreateAnimalDto createAnimalDto)
        {
            try
            {
                var animalAddResponse = await _httpClient.
                                    PostAsJsonAsync<CreateAnimalDto>("api/ZooAnimal", createAnimalDto);
                if(animalAddResponse.IsSuccessStatusCode) 
                {
                    if (animalAddResponse.StatusCode == System.Net.HttpStatusCode.NoContent)
                    { 
                        return default(AnimalDto);
                    }
                    return await animalAddResponse.Content.ReadFromJsonAsync<AnimalDto>();
                }
                else
                {
                    var message = await animalAddResponse.Content.ReadAsStringAsync();
                    throw new Exception($"Http status:{animalAddResponse.StatusCode} Message -{message}");
                }
            }
            catch (Exception)
            {
                //log exception
                throw;
            }
        }

        public async Task<IEnumerable<AnimalDto>> GetAnimals()
        {
            try
            {
                var animals = await _httpClient.GetFromJsonAsync<IEnumerable<AnimalDto>>("api/ZooAnimal");
                return animals;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<AnimalDto> DeleteAnimal(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/ZooAnimal/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<AnimalDto>();
                }
                return default(AnimalDto);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
