using Microsoft.AspNetCore.Mvc;
using zadanie.Models;

namespace zadanie.Controlers;

[Route("api/animals")]
[ApiController]
public class AnimalsController : ControllerBase
{

    private static readonly List<Animal> Animals = new()
    {
        new Animal(1, "Bodzio","pies",25.5,"zlota"),
        new Animal(2, "Ryszard", "kucyk", 100.32, "kasztanowata"),
        new Animal(3, "Pysia", "kot", 3, "ruda"),
        new Animal(4, "Mysia", "swinka morska", 0.5, "czarna"),
        new Animal(5, "Lolka", "pies", 4,"biala")
    };
    
    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(Animals);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = Animals.FirstOrDefault(s => s.Id == id);
        if (animal == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }

        return Ok(animal);
    }

    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        Animals.Add(animal);
        return StatusCode((StatusCodes.Status201Created));
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var animalToEdit = Animals.FirstOrDefault(s => s.Id == id);
        if (animalToEdit == null)
        {
            return NotFound($"Nie znaleziono zwierzecia z id {id}");
        }

        Animals.Remove(animalToEdit);
        Animals.Add(animal);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animalToEdit = Animals.FirstOrDefault(s => s.Id == id);
        if (animalToEdit == null)
        {
            return NoContent();
        }

        Animals.Remove(animalToEdit);
        return NoContent();
    }
}