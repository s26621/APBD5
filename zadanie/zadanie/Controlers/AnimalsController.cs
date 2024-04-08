using Microsoft.AspNetCore.Mvc;
using zadanie.Models;

namespace zadanie.Controlers;

[Route("api/animals")]
[ApiController]
public class AnimalsController : ControllerBase
{

    private static readonly List<Animal> Animals = new()
    {
        new Animal(1, "Bodzio","pies",25.5,"zlota",new List<Visit>()
        {
            new (DateTime.Parse("2020-10-10"),"ddd",123.34),
            new (DateTime.Parse("2021-10-10"),"aaa",108.21),
            new (DateTime.Parse("2022-10-10"),"eee",135.34)
        }),
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
    [HttpGet("{id:int}/visits")]
    public IActionResult GetVisits(int id)
    {
        var animal = Animals.FirstOrDefault(s => s.Id == id);
        if (animal == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }

        return Ok(animal.Visits);
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
            return NotFound($"Animal with id {id} was not found");
        }

        Animals.Remove(animalToEdit);
        Animals.Add(animal);
        return NoContent();
    }
    
    [HttpPut("{id:int}/visits")]
    public IActionResult AddVisit(int id, Visit visit)
    {
        var animalToEdit = Animals.FirstOrDefault(s => s.Id == id);
        if (animalToEdit == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }
        
        animalToEdit.Visits.Add(visit);
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