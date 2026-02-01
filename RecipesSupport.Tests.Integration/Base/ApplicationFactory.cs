using Application.Services;
using Application.Services.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RecipesSupport.Application.Services;
using RecipesSupport.Application.Services.Interfaces;
using Xunit;

namespace RecipesSupport.Tests.Integration.Base
{
    [CollectionDefinition(("Shared Integration Tests"))]
    public class SharedApplicationFactory : ICollectionFixture<ApplicationFactory>
    {
    }

    public class ApplicationFactory : WebApplicationFactory<Program>
    {
        private IHost _appHost = null!;

        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureLogging(l =>
            {
                l.ClearProviders();
                l.AddConsole();
                l.SetMinimumLevel(LogLevel.Debug);
            });
            
            builder.UseEnvironment("Integration");
            _appHost = base.CreateHost(builder);
            return _appHost;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
           
            var conigurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.Integration.json", optional: true, reloadOnChange: true);

            var coniguration = conigurationBuilder.Build();
            builder.ConfigureServices(services =>
            {

                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<RecipesSupportDbContext>));
                if (descriptor != null)
                    services.Remove(descriptor);

                services.AddScoped<IRecipeService, RecipeService>();
                services.AddScoped<IRecipeScalingService, RecipeScallingService>();
                services.AddScoped<IConversionService, ConversionService>();
                //// Dodanie in-memory database dla testów
                //services.AddDbContext<RecipesSupportDbContext>(options =>
                //    options.UseInMemoryDatabase("RecipeDb_TST"));
            });

            builder.UseEnvironment("Integration"); // Ustaw środowisko testowe
            builder.UseConfiguration(coniguration);
        }

        public HttpClient AsNotAuthenticated()
        {
            var client = CreateClient(new WebApplicationFactoryClientOptions()
            {
                AllowAutoRedirect = false
            });
            return CreateClientWithBaseAddress(client);
        }

        public HttpClient CreateClientWithBaseAddress(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7069"); // Ustaw właściwy adres
            return client;
        }
    }
}