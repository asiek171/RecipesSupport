namespace RecipesSupport.Extensions
{
    public static class OptionsExtensions
    {
        public static IServiceCollection ConfigureOptions<TOptions>(this IServiceCollection services, IConfiguration configuration)
            where TOptions : class
        {
            var sectionName = typeof(TOptions).Name.Replace("Settings", "");
            services.Configure<TOptions>(configuration.GetSection(sectionName));
            return services;
        }
    }
}
