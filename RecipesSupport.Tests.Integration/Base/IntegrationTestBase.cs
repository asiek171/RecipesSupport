using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Infrastructure.Data;

namespace RecipesSupport.Tests.Integration.Base
{
    public class IntegrationTestBase : IClassFixture<WebApplicationFactory<Program>>
    {
        protected readonly HttpClient TestClient;
        private readonly WebApplicationFactory<Program> _factory;

        public IntegrationTestBase()
        {
            _factory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        // Usunięcie rzeczywistej bazy danych
                        var descriptor = services.SingleOrDefault(
                            d => d.ServiceType == typeof(DbContextOptions<RecipesSupportDbContext>));
                        if (descriptor != null)
                            services.Remove(descriptor);

                        // Dodanie in-memory database dla testów
                        services.AddDbContext<RecipesSupportDbContext>(options =>
                            options.UseInMemoryDatabase("RecipeDb_TST"));
                    });
                });

            TestClient = _factory.CreateClient();
        }
    }
}
