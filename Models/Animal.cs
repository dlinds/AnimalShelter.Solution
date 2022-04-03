using System.ComponentModel.DataAnnotations;
using System;
namespace AnimalShelter.Models
{
  public class Animal
  {
    public int AnimalId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Species { get; set; }
    [Required]
    public string Breed { get; set; }
    [Required]
    public string Gender { get; set; }
    [Required]
    public int Age { get; set; }
    [Required]
    public int AdoptionPrice { get; set; }
    [Required]
    public bool GoodWithOtherAnimals { get; set; }
    [Required]
    public bool GoodWithChildren { get; set; }
    [Required]
    public DateTime DateListed { get; set; }
    [Required]
    public string AnimalPhotoURL { get; set; }

  }
}
