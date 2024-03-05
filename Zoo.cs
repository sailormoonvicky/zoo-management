using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ZooManagement.Enums;
using ZooManagement.Models;

namespace ZooManagement;

public class Zoo : DbContext
{
    public DbSet<Animal> Animals { get; set;} =null!;
    public DbSet<Species> Species { get; set;} = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Database=zoo; Username=zoo; Password=zoo;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // var lion = new Species
        // {
        //     Id = -1,
        //     Name = "lion",
        //     Classification = Classification.Mammal,
        // };
        // modelBuilder.Entity<Species>().HasData(lion);

        var speciesList = new List<Species> // Species: Mammal, Reptile, Bird, Insect, Fish, Invertebrate,
        {
            new Species { Id = -1, Name = "lion", Classification = Classification.Mammal },
            new Species { Id = -2, Name = "giraffe", Classification = Classification.Mammal },
            new Species { Id = -3, Name = "hippo", Classification = Classification.Mammal },
            new Species { Id = -4, Name = "eagle", Classification = Classification.Bird },
            new Species { Id = -5, Name = "swan", Classification = Classification.Bird },
            new Species { Id = -6, Name = "python", Classification = Classification.Reptile },
            new Species { Id = -7, Name = "tortoise", Classification = Classification.Reptile },
            new Species { Id = -8, Name = "jellyfish", Classification = Classification.Fish },
            new Species { Id = -9, Name = "seahorse", Classification = Classification.Fish },
            new Species { Id = -10, Name = "octopus", Classification = Classification.Invertebrate},
            new Species { Id = -11, Name = "startfish", Classification = Classification.Invertebrate},
            new Species { Id = -12, Name = "ladybug", Classification = Classification.Insect},
            new Species { Id = -13, Name = "bumblebee", Classification = Classification.Insect},
        };
    modelBuilder.Entity<Species>().HasData(speciesList.ToArray());

        var simba = new Animal
        {
            Id = -1,
            Name = "simba",
            SpeciesId = -1,
            Sex = Sex.Male,
            DateOfBirth = new DateOnly(1998,10,13),
            DateOfAcquisition = new DateOnly(2000,1,1)
        };

        var nala = new Animal
        {
            Id = -2,
            Name = "nala",
            SpeciesId = -1,
            Sex = Sex.Male,
            DateOfBirth = new DateOnly(1997,9,18),
            DateOfAcquisition = new DateOnly(2001,2,3)
        };

        modelBuilder.Entity<Animal>().HasData(simba,nala);

        var animals = new List<Animal>();
        int animalId = -3; 

        Random rnd = new Random();
        DateOnly RandomDate(int startYear, int endYear) =>
            new DateOnly(rnd.Next(startYear, endYear), rnd.Next(1, 13), rnd.Next(1, 29));

        foreach (var species in speciesList) // 13
        {
            for (int i = 0; i < 20; i++)
            {
                animals.Add(new Animal
                {
                    Id = animalId--,
                    Name = $"{species.Name} #{animalId}",
                    SpeciesId = species.Id,
                    Sex = (Sex)rnd.Next(0, 2),
                    DateOfBirth = RandomDate(2010, 2020),
                    DateOfAcquisition = RandomDate(2020, 2023)
                });
            }
        }

        modelBuilder.Entity<Animal>().HasData(animals.ToArray());
    }
    }