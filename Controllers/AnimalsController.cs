using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using AnimalShelter.Models;

namespace AnimalShelter.Solution.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AnimalsController : ControllerBase
  {
    private readonly AnimalShelterContext _db;

    public AnimalsController(AnimalShelterContext db)
    {
      _db = db;
    }
    /// <summary>
    /// Gets all animals currently in the shelter.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /Animals
    ///     {
    ///     }
    ///
    /// </remarks>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Animal>>> Get()
    {
      return await _db.Animals.ToListAsync();
    }
    /// <summary>
    /// Gets animal by Id.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /Animals
    ///     {
    ///        AnimalId: 3
    ///     }
    ///
    /// </remarks>
    /// <param name="id">Id of the animal</param>
    /// <response code="404">No animals with this Id exist</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<Animal>> GetAnimalById(int id)
    {
      Animal animal = await _db.Animals.FindAsync(id);

      if (animal == null)
      {
        return NotFound();
      }

      return animal;
    }
    /// <summary>
    /// Creates a new animal.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Animals
    ///     {
    ///        "name": "Buddy",
    ///        "species": "Dog",
    ///        "breed": "Australian Shepard",
    ///        "gender": "Male",
    ///        "age": 0,
    ///        "adoptionPrice": 800,
    ///        "goodWithOtherAnimals": true,
    ///        "goodWithChildren": true,
    ///        "dateListed": (2022, 3, 2)
    ///     }
    ///
    /// </remarks>
    /// <param name="animal">Animal Object</param>
    /// <response code="404">No animals with this Id exist</response>
    [HttpPost]
    public async Task<ActionResult<Animal>> Post(Animal animal)
    {
      _db.Animals.Add(animal);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetAnimalById), new { id = animal.AnimalId }, animal);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Animal animal)
    {
      if (id != animal.AnimalId)
      {
        return BadRequest();
      }
      _db.Entry(animal).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!AnimalExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnimal(int id)
    {
      var animal = await _db.Animals.FindAsync(id);
      if (animal == null)
      {
        return NotFound();
      }

      _db.Animals.Remove(animal);
      await _db.SaveChangesAsync();

      return NoContent();
    }
    private bool AnimalExists(int id)
    {
      return _db.Animals.Any(e => e.AnimalId == id);
    }
  }
}
