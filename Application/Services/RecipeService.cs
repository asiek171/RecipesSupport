using Application.Services.Interfaces;
using Application.Services.Strategy.Factory;
using MediatR;

namespace Application.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IMediator _mediator;

        private readonly IntegrationStrategyFactory _strategyFactory;
        public RecipeService(IntegrationStrategyFactory strategyFactory,
                             IMediator mediator)
        {
            _strategyFactory = strategyFactory;
            _mediator = mediator;
        }

        public async Task<string> GetByIngredients(string ingredients)
        {
            var strategy = _strategyFactory.GetStrategy(Application.Enums.SystemType.Edamam);

            var result = await strategy.FetchRecipes(ingredients);

            return result;
        }

        public async Task<string> GetByRecipeId(int recipeId)
        {
            throw new NotImplementedException();
        }


    }
}
