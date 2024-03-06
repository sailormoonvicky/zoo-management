using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ZooManagement.Controllers;

[ApiController]
[Route("/animals")]
public class AnimalsController: Controller
{
    private readonly Zoo _zoo;
    public AnimalsController(Zoo zoo)
    {
        _zoo = zoo;
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var matchingAnimal = _zoo.Animals
            .Include(animal => animal.Species)
            .SingleOrDefault(animal => animal.Id == id);
        if (matchingAnimal == null)
        {
            return NotFound();
        }
        return Ok(matchingAnimal);
    }


        //  [HttpGet("/page={page}")]
        // public IActionResult GetByPage([FromRoute] int page = 0)
        // {
        //     const int PageSize = 2;
        //     var animalsList = _zoo.Animals.ToList();
        //     var count = animalsList.Count();
        //     var animalsData = animalsList.Skip(page * PageSize).Take(PageSize).ToList();
        //     return Ok(animalsData);
        // }

        [HttpGet]
        public IActionResult GetByPageAndSize([FromQuery] int page = 1, int pageSize=10)
        {
            // PageSize = 2;
            //var defaultPageSize = PageSize==null?3:PageSize;
            var animalsList = _zoo.Animals.Include(animal => animal.Species)
                                          .OrderBy(animal => animal.Species.Name)
                                          .ThenBy(animal => animal.Name)
                                          .ToList();
            // var count = animalsList.Count;
            var animalsData = animalsList.Skip((page-1 )* pageSize).Take(pageSize).ToList();
            return Ok(animalsData);
        }
}

// 1. ? in the end point
// 2. required parameters and optional parameters
// 3. why GetByPage and GetByPageAndSize don't work at same time?
// 4. How to oderby/sort?
// 5. how to handle with enums in the csv conversion?
// 6. Create "Enclosure" property in Animal and randomly assign an enclosure (list?)? - Class enclosure with id