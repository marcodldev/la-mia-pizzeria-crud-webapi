using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using System.Data.Entity;

namespace la_mia_pizzeria_static.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaApiController : ControllerBase
    {

        private readonly PizzaContext _context;

        public PizzaApiController(PizzaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPizzas([FromQuery] string? name)
        {
            var pizzas = _context.Pizze
                //.Include(p => p.Categorie)
                //.Include(p => p.Ingredienti)
                .Where(p => name == null || p.Name.ToLower().Contains(name.ToLower())).ToList();

            return Ok(pizzas);
        }

        [HttpGet("{id}")]
        public IActionResult GetPizza(int id)
        {
            var pizza = _context.Pizze.FirstOrDefault(p => p.Id == id);

            if (pizza is null)
            {
                return NotFound();
            }

            return Ok(pizza);
        }

        [HttpPut("{id}")]
        public IActionResult PutPizza(int id, [FromBody] Pizza pizza)
        {
            var pizzaSalvata = _context.Pizze.FirstOrDefault(p => p.Id == id);

            if (pizzaSalvata is null)
            {
                return NotFound();
            }

            pizzaSalvata.Name = pizza.Name;
            pizzaSalvata.ImgUrl = pizza.ImgUrl;
            pizzaSalvata.Description = pizza.Description;
            pizzaSalvata.Prezzo = pizza.Prezzo;
            pizzaSalvata.CategorieId = pizza.CategorieId;


            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IActionResult NuovaPizza(Pizza pizza)
        {
            _context.Pizze.Add(pizza);
            _context.SaveChanges();

            return Ok(pizza);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePizza(int id)
        {
            var pizzaSalvata = _context.Pizze.FirstOrDefault(p => p.Id == id);

            if (pizzaSalvata is null)
            {
                return NotFound();
            }

            _context.Pizze.Remove(pizzaSalvata);
            _context.SaveChanges();

            return Ok();
        }

    }
}
