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


         [HttpGet("?page={page}")]
        public IActionResult GetByPage([FromRoute] int page = 0)
        {
            const int PageSize = 20;
            var animalsList = _zoo.Animals.ToList();
            // booksList = booksList.OrderBy(title => title.BookTitle).ToList();
            var count = animalsList.Count();
            var animalsData = animalsList.Skip(page * PageSize).Take(PageSize).ToList();
            // ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);
            // ViewBag.Page = page;
            return Ok(animalsData);
        }
}