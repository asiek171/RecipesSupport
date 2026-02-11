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

        public RecipesController(
            IRecipeService service,
            ILogger<RecipesController> logger)
        {
            _recipeService = service;
            _logger = logger;
        }

        [HttpGet("searchByIngredients")]
        public async Task<IActionResult> SearchByIngredients(string ingredients)
        {
            var result = await _recipeService.GetByIngredients(ingredients);

            return Ok(result);
        }


        [HttpGet("searchAcrossAllSystemsAsync")]
        public async Task<IActionResult> SearchAcrossAllSystemsAsync(string ingredients, CancellationToken ct)
        {
            var result = await _recipeService.SearchAcrossAllSystemsAsync(ingredients, ct);

            return Ok(result);
        }


        [HttpGet("getRecipeInformation")]
        public IActionResult GetRecipeInformation([FromQuery] int recipeId)
        {
            //   var result = _recipeService.GetByRecipeId(recipeId);
            return Ok();//result);
        }

    }
}