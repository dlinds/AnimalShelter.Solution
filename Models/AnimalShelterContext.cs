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
              new Animal { AnimalId = 1, Name = "Babby", Species = "Dog", Breed = "Beagle", Gender = "Female", Age = 6, AdoptionPrice = 500, GoodWithOtherAnimals = true, GoodWithChildren = true, DateListed = new DateTime(2022, 1, 15), AnimalPhotoURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTsuPg3g3nAvGkX3pJKCxVT92YlipcQW87tMQ&usqp=CAU" },
              new Animal { AnimalId = 2, Name = "Billy", Species = "Dog", Breed = "Beagle", Gender = "Male", Age = 1, AdoptionPrice = 800, GoodWithOtherAnimals = true, GoodWithChildren = false, DateListed = new DateTime(2022, 3, 26), AnimalPhotoURL = "https://dogsbestlife.com/wp-content/uploads/2020/05/Beagle-scaled.jpeg" },
              new Animal { AnimalId = 3, Name = "Ned", Species = "Dog", Breed = "German Schnauzer", Gender = "Male", Age = 9, AdoptionPrice = 200, GoodWithOtherAnimals = false, GoodWithChildren = true, DateListed = new DateTime(2021, 11, 2), AnimalPhotoURL = "https://www.akc.org/wp-content/uploads/2017/11/Standard-Schnauzer-standing-outdoors.jpg" },
              new Animal { AnimalId = 4, Name = "Poppins", Species = "Dog", Breed = "Mutt", Gender = "Female", Age = 2, AdoptionPrice = 100, GoodWithOtherAnimals = true, GoodWithChildren = false, DateListed = new DateTime(2021, 11, 2), AnimalPhotoURL = "https://images.ctfassets.net/sfnkq8lmu5d7/1j5LJ5cIY1gfqE90AxvD6V/11c51d0709478c75d9a6716d92b28c08/2021_0714_national_mutt_day.jpg?w=1000&h=750&fl=progressive&q=80&fm=jpg" },
              new Animal { AnimalId = 5, Name = "Mr Scruffles", Species = "Dog", Breed = "Pomeranian", Gender = "Female", Age = 0, AdoptionPrice = 800, GoodWithOtherAnimals = true, GoodWithChildren = true, DateListed = new DateTime(2022, 1, 2), AnimalPhotoURL = "https://highlandcanine.com/wp-content/uploads/2021/03/pomeranian-running-and-happy.jpg" },
              new Animal { AnimalId = 6, Name = "Tabatha", Species = "Cat", Breed = "Tabby", Gender = "Male", Age = 15, AdoptionPrice = 70, GoodWithOtherAnimals = false, GoodWithChildren = false, DateListed = new DateTime(2020, 11, 2), AnimalPhotoURL = "https://s36537.pcdn.co/wp-content/uploads/2017/11/Mackerel-Tabby-cat.jpg.optimal.jpg" },
              new Animal { AnimalId = 7, Name = "Pepper", Species = "Cat", Breed = "Calico", Gender = "Female", Age = 0, AdoptionPrice = 300, GoodWithOtherAnimals = false, GoodWithChildren = false, DateListed = new DateTime(2022, 3, 2), AnimalPhotoURL = "https://cat-world.com/wp-content/uploads/2016/09/all-about-calico-cats.jpg" }
          );
    }
  }
}
