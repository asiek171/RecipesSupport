using Application.Services.Interfaces;
using Application.Services.Strategy.Factory;
using Application.Services.Strategy.Interfaces;
using MediatR;
using TheMealDbClient;

namespace Application.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IMediator _mediator;
     //   private readonly INutritionixService _nutritionix;
   //     private readonly ITheMealDbService _theMealDb;

        private readonly IntegrationStrategyFactory _strategyFactory;
        private  IntegrationContext _context;
        public RecipeService(IntegrationStrategyFactory strategyFactory, IntegrationContext context, IMediator mediator)
        {
            _strategyFactory = strategyFactory;
            _context = context;
            _mediator = mediator;


      //      _context = new IntegrationContext(strategy);
        }

        //public RecipeService(INutritionixService nutritionix, ITheMealDbService theMealDbService, IMediator mediator)
        //{
        //    _mediator = mediator;
        //    _nutritionix = nutritionix;
        //    _theMealDb = theMealDbService;
        //}

        public async Task<string> GetByIngredients(string ingedients)
        {

         //   return await _nutritionix.SearchRecipesByIngredients(ingedients);
            var strategy = _strategyFactory.GetStrategy(Enums.SystemType.Edamam);

            var result = await _context.ExecuteFetch(ingedients);

            return result;
        }

        //public string GetByRecipeId(int recipeId)
        //{
        //    return "under tests";//await _spoonacularService.GetRecipeInformation(recipeId);
        //}

        public Task<string> GetByRecipeId(int recipeId)
        {
            return Task.FromResult("under tests");
        }
    }
}
