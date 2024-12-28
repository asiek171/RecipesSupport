using Application.Services;
using Application.Services.Interfaces;
using Application.Services.Strategy;
using Application.Services.Strategy.Factory;
using EdamamClient;
using EdamamClient.Configuration;
using NutritionixClient;
using NutritionixClient.Configuration;
using SpoonacularClient;
using TheMealDbClient;
using TheMealDbClient.Configuration;

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
            

            services.AddScoped<SpoonacularStrategy>();
            services.AddScoped<NutritionixStrategy>();
            services.AddScoped<EdamamStrategy>();
            services.AddScoped<TheMealDbStrategy>();

            services.AddScoped<IntegrationStrategyFactory>();

            return services;
        }
    }
}
