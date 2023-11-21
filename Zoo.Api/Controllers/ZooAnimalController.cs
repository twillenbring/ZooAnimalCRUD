using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zoo.Api.Entities;
using Zoo.Api.Extensions;
using Zoo.Api.Repositories;
using Zoo.Api.Repositories.Contracts;
using Zoo.Models.Dtos;

namespace Zoo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZooAnimalController : ControllerBase
    {
        private readonly IZooAnimalRepository _zooRepository;

        public ZooAnimalController(IZooAnimalRepository zooRepository)
        {
            _zooRepository = zooRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalDto>>> GetAnimals()
        {
            try
            {
                var animals = await _zooRepository.GetAllAnimalsAsync();
                if(animals == null)
                {
                    return NotFound();  
                }
                else
                {
                    var animalsDto = animals.ConvertToAnimalsDto();
                    return Ok(animalsDto);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, 
                                    "Error retrieving data from Database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<AnimalDto>> GetZooAnimalById(int id)
        {
            try
            {
                var result = await _zooRepository.GetAnimalByIdAsync(id);
                if(result == null)
                {
                    return NotFound();
                }
                return Ok(result.ConvertToAnimalDto());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
                
            }
        }
        [HttpPost]
        public async Task<ActionResult<AnimalDto>> CreateZooAnimalAsync([FromBody] CreateAnimalDto animalDto)
        {
            try
            {
                if (animalDto == null)
                {
                    return BadRequest("Invalid AnimalDto");
                }

                
                var newZooAnimal = await _zooRepository.CreateZooAnimalAsync(animalDto);
                
                return CreatedAtAction(nameof(GetZooAnimalById), new { id = newZooAnimal.Id }, newZooAnimal.ConvertToAnimalDto());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
            
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateZooAnimalAsync(int id, [FromBody] UpdateAnimalDto updateDto)
        {
            try
            {
                if (updateDto == null)
                {
                    return BadRequest("Invalid data");
                }

                // Validate if the id is valid
                if (id <= 0)
                {
                    return BadRequest("Invalid id");
                }

                // Retrieve the existing ZooAnimal from the repository
                var existingAnimal = await _zooRepository.GetAnimalByIdAsync(id);

                // Check if the animal with the given id exists
                if (existingAnimal == null)
                {
                    return NotFound($"Animal with id {id} not found");
                }

                // Update the properties with values from the DTO
                existingAnimal.Name = updateDto.Name;
                existingAnimal.Species = updateDto.Species;
                existingAnimal.Age = updateDto.Age;
                existingAnimal.Gender = updateDto.Gender;

                // Call the repository method to update the ZooAnimal
                await _zooRepository.UpdateZooAnimal(existingAnimal);    

                // Return a successful response
                return Ok($"Animal with id {id} updated successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteZooAnimal(int id)
        {
            try
            {
                // Validate if the id is valid
                if (id <= 0)
                {
                    return BadRequest("Invalid id");
                }

                // Retrieve the existing ZooAnimal from the repository
                var existingAnimal = await _zooRepository.GetAnimalByIdAsync(id);

                // Check if the animal with the given id exists
                if (existingAnimal == null)
                {
                    return NotFound($"Animal with id {id} not found");
                }
                await _zooRepository.DeleteZooAnimalAsync(id);
                return Ok($"Animal with {id} successfully deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

    }
}
