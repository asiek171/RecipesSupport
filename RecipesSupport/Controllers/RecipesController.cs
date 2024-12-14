using Application.Services.Interfaces;
using Application.Services.Strategy.Factory;
using Application.Services.Strategy.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace RecipesSupport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly ILogger<RecipesController> _logger;
        private readonly IRecipeService _recipeService;
        private readonly IntegrationStrategyFactory _strategyFactory;

        public RecipesController(
           IntegrationStrategyFactory strategyFactory,
           IRecipeService service,
             ILogger<RecipesController> logger)
        {
            _recipeService = service;
            _strategyFactory = strategyFactory;
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
            //   var result = _recipeService.GetByRecipeId(recipeId);
            return Ok();//result);
        }

    }
}
