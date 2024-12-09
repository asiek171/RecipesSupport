using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RecipesSupport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly ILogger<RecipesController> _logger;
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService, ILogger<RecipesController> logger)
        {
            _recipeService = recipeService;
            _logger = logger;
        }

        [HttpGet("searchByIngredients")]
        public async Task<IActionResult> SearchByIngredients(string ingredients)
        {
            var result = await _recipeService.GetByIngredients(ingredients);
            return Ok(result);
        }

        [HttpGet("getRecipeInformation")]
        public IActionResult GetRecipeInformation([FromQuery] int recipeId)
        {
            var result = _recipeService.GetByRecipeId(recipeId);
            return Ok(result);
        }

    }
}
