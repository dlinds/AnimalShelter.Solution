using Microsoft.EntityFrameworkCore;
using System;

namespace AnimalShelter.Models
{
  public class AnimalShelterContext : DbContext
  {
    public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options) : base(options)
    {

    }
    public DbSet<Animal> Animals { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Animal>()
          .HasData(
              new Animal { AnimalId = 1, Name = "Babby", Species = "Dog", Breed = "Beagle", Gender = "Female", Age = 6, AdoptionPrice = 500, GoodWithOtherAnimals = true, GoodWithChildren = true, DateListed = new DateTime(2022, 1, 15) },
              new Animal { AnimalId = 2, Name = "Billy", Species = "Dog", Breed = "Beagle", Gender = "Male", Age = 1, AdoptionPrice = 800, GoodWithOtherAnimals = true, GoodWithChildren = false, DateListed = new DateTime(2022, 3, 26) },
              new Animal { AnimalId = 3, Name = "Ned", Species = "Dog", Breed = "German Schnauzer", Gender = "Male", Age = 9, AdoptionPrice = 200, GoodWithOtherAnimals = false, GoodWithChildren = true, DateListed = new DateTime(2021, 11, 2) },
              new Animal { AnimalId = 4, Name = "Poppins", Species = "Dog", Breed = "Mutt", Gender = "Female", Age = 2, AdoptionPrice = 100, GoodWithOtherAnimals = true, GoodWithChildren = false, DateListed = new DateTime(2021, 11, 2) },
              new Animal { AnimalId = 5, Name = "Mr Scruffles", Species = "Dog", Breed = "Pomeranian", Gender = "Female", Age = 0, AdoptionPrice = 800, GoodWithOtherAnimals = true, GoodWithChildren = true, DateListed = new DateTime(2022, 1, 2) },
              new Animal { AnimalId = 6, Name = "Tabatha", Species = "Cat", Breed = "Tabby", Gender = "Male", Age = 15, AdoptionPrice = 70, GoodWithOtherAnimals = false, GoodWithChildren = false, DateListed = new DateTime(2020, 11, 2) },
              new Animal { AnimalId = 7, Name = "Pepper", Species = "Cat", Breed = "Calico", Gender = "Female", Age = 0, AdoptionPrice = 300, GoodWithOtherAnimals = false, GoodWithChildren = false, DateListed = new DateTime(2022, 3, 2) }
          );
    }
  }
}
