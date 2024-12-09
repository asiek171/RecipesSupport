using Application.Enums;
using Application.Services.Strategy.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Services.Strategy.Factory
{
    public class IntegrationStrategyFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public IntegrationStrategyFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IIntegrationStrategy GetStrategy(SystemType systemType)
        {
            return systemType switch
            {
                SystemType.Spoonacular => _serviceProvider.GetRequiredService<SpoonacularStrategy>(),
                SystemType.Nutritionix => _serviceProvider.GetRequiredService<NutritionixStrategy>(),
                SystemType.Edamam => _serviceProvider.GetRequiredService<EdamamStrategy>(),
                SystemType.TheMealDb => _serviceProvider.GetRequiredService<TheMealDbStrategy>(),
                _ => throw new ArgumentException("Not implemented tpe of integration")
            };
        }
    }
}
