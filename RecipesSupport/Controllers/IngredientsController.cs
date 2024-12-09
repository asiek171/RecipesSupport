using Application.Models;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RecipesSupport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly ILogger<IngredientsController> _logger;
        private readonly IIngredientService _ingredientService;

        public IngredientsController (IIngredientService ingredientService, 
            ILogger <IngredientsController> logger)
        {
            _ingredientService = ingredientService;
            _logger = logger;
        }

        [HttpPost(Name = "Add")]
        public async Task<IActionResult> Add(Ingredient model)
        {
            return  await _ingredientService.Add(model) ? Ok(model) : BadRequest();
        }
    }
}
