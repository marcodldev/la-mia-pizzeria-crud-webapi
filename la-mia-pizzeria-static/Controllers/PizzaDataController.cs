using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaDataController : ControllerBase
    {


        private readonly PizzaContext _context;

        public PizzaDataController(PizzaContext context)
        {
            _context = context;
        }

        [Route("categorie")]
        [HttpGet]
        public IActionResult GetCategorie()
        {
            return Ok(_context.Categorie.ToList());
        }

        [Route("ingredienti")]
        [HttpGet]
        public IActionResult GetIngredienti()
        {
            return Ok(_context.Ingredienti.ToList());
        }

    }
}

