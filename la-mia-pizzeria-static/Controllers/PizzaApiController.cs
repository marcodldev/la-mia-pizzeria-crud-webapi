using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaApiController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetPizzas()
        {
            using (PizzaContext ctx = new PizzaContext())
            {
                IQueryable<Pizza> pizzas = ctx.Pizze;

                return Ok(pizzas.ToList());
            }
        }

    }
}
