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
  [Produces("application/json")]
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
    /// <param name="gender">Gender of animal</param>
    /// <param name="species">Animal species (dog or cat)</param>
    /// <param name="breed">Species breed (Beagle, Calico)</param>
    /// <param name="age">Animal age</param>
    /// <param name="ageSearchType">Find older or younger than age param</param>
    /// <param name="adoptionBudget">Find animals less than price</param>
    /// <param name="goodWithOtherAnimals">Find animals less than price</param>
    /// <param name="goodWithChildren">Find animals less than price</param>
    /// <param name="sort">New or old</param>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Animal>>> Get(string gender, string species, string breed, int age, string ageSearchType, int adoptionBudget, string goodWithOtherAnimals, string goodWithChildren, string sort)
    {
      var query = _db.Animals.AsQueryable();


      if (gender != null)
      {
        query = query.OrderBy(animal => animal.DateListed).Where(animal => animal.Gender == gender);
      }
      if (species != null)
      {
        query = query.OrderBy(animal => animal.DateListed).Where(animal => animal.Species == species);
      }
      if (breed != null)
      {
        query = query.OrderBy(animal => animal.Breed).Where(animal => animal.Breed == breed);
      }
      if (age > 0)
      {
        if (ageSearchType == "older")
        {
          query = query.OrderBy(animal => animal.Breed).Where(animal => animal.Age > age);
        }
        else if (ageSearchType == "younger")
        {
          query = query.OrderBy(animal => animal.Breed).Where(animal => animal.Age < age);
        }
        else
        {
          query = query.OrderBy(animal => animal.Breed).Where(animal => animal.Age == age);
        }
      }
      if (adoptionBudget > 0)
      {
        query = query.OrderBy(animal => animal.Breed).Where(animal => animal.AdoptionPrice < adoptionBudget);
      }
      if (goodWithOtherAnimals == "true")
      {
        query = query.OrderBy(animal => animal.Breed).Where(animal => animal.GoodWithOtherAnimals == true);
      }
      else if (goodWithOtherAnimals == "false")
      {
        query = query.OrderBy(animal => animal.Breed).Where(animal => animal.GoodWithOtherAnimals == false);
      }
      if (goodWithChildren == "true")
      {
        query = query.OrderBy(animal => animal.Breed).Where(animal => animal.GoodWithChildren == true);
      }
      else if (goodWithChildren == "false")
      {
        query = query.OrderBy(animal => animal.Breed).Where(animal => animal.GoodWithChildren == false);
      }



      if (sort == "new")
      {
        query = query.OrderByDescending(animal => animal.DateListed);
      }
      else
      {
        query = query.OrderBy(animal => animal.DateListed);
      }
      return await query.ToListAsync();
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
    /// Gets all current breeds.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /Animals/breeds
    ///     {
    ///     }
    ///
    /// </remarks>
    /// <response code="404">No animals currently exist, so there are no breeds</response>
    [HttpGet("breeds")]
    public async Task<ActionResult<IEnumerable<string>>> GetBreeds()
    {
      var query = _db.Animals.AsQueryable();
      var uniqueBreeds = query.Select(p => p.Breed)
                                  .Distinct().ToListAsync();


      // query = query.Select(animal => animal.Breed);

      return await uniqueBreeds;

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
    ///        "dateListed": "2022-01-15T00:00:00"
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

    /// <summary>
    /// Edits an existing animal.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT /Animals
    ///     {
    ///        "AnimalId": 4
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
    /// <param name="id">Id of the animal</param>
    /// <response code="404">No animals with this Id exist</response>
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
    /// <summary>
    /// Deletes animal by Id.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE /Animals
    ///     {
    ///        AnimalId: 3
    ///     }
    ///
    /// </remarks>
    /// <param name="id">Id of the animal</param>
    /// <response code="404">No animals with this Id exist</response>
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
