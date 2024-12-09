using Application.Services.Interfaces;
using Application.Services;
using SpoonacularClient;
using Microsoft.Extensions.DependencyInjection;
using NutritionixClient.Configuration;
using NutritionixClient;
using Application.Services.Strategy;
using TheMealDbClient.Configuration;
using Application.Services.Strategy.Interfaces;
using Application.Services.Strategy.Factory;
using TheMealDbClient;
using EdamamClient.Configuration;
using EdamamClient;

namespace RecipesSupport.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomCashing(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddOutputCache();

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IIngredientService, IngredientService>();

            return services;
        }

        public static IServiceCollection AddExternalIntegrationServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Spoonacular
            services.ConfigureOptions<SpoonacularSettings>(configuration);
            services.AddHttpClient<ISpoonacularService, SpoonacularService>();
            services.AddScoped<ISpoonacularService, SpoonacularService>();
            //Spoonacular 


            //Nutritionix
            services.ConfigureOptions<NutritionixSettings>(configuration);
            services.AddHttpClient<INutritionixService, NutritionixService>();
            services.AddScoped<INutritionixService, NutritionixService>();
            //Nutritionix 

            //Edamam
            services.ConfigureOptions<EdamamSettings>(configuration);
            services.AddHttpClient<IEdamamService, EdamamService>();
            services.AddScoped<IEdamamService, EdamamService>();
            //Edamam 

            //TheMealDb
            services.ConfigureOptions<TheMealDbSettings>(configuration);
            services.AddHttpClient<ITheMealDbService, TheMealDbService>();
            services.AddScoped<ITheMealDbService, TheMealDbService>();
            //TheMealDb 

            return services;
        }

        public static IServiceCollection AddStrategy(this IServiceCollection services)
        {

            services.AddScoped<IntegrationStrategyFactory>();
            services.AddScoped<IntegrationContext>();

            services.AddScoped<IIntegrationStrategy, SpoonacularStrategy>();
            services.AddScoped<IIntegrationStrategy,NutritionixStrategy>();
            services.AddScoped<IIntegrationStrategy,EdamamStrategy>();
            services.AddScoped<IIntegrationStrategy,TheMealDbStrategy>();

            return services;
        }
    }
}
