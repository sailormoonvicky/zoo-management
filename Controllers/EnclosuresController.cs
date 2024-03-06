using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ZooManagement.Controllers;

[ApiController]
[Route("/enclosures")]
public class EnclosuresController: Controller
{
    private readonly Zoo _zoo;
    public EnclosuresController(Zoo zoo)
    {
        _zoo = zoo;
    }

    [HttpGet]
    public IActionResult GetById([FromQuery] int id, int pageSize=10, int pageNum=1)
    {
        var matchingAnimals = _zoo.Animals
            .Include(animal => animal.Enclosure)
            .Include(animal => animal.Species)
            .Where(animal => animal.EnclosureId == id)
            .OrderBy(animal => animal.Name);
        if (matchingAnimals == null)
        {
            return NotFound();
        }
        var queryAnimals = matchingAnimals.Skip((pageNum-1)*pageSize).Take(pageSize).ToList();
        return Ok(queryAnimals);
    }
}