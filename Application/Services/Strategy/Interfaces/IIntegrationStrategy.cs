namespace Application.Services.Strategy.Interfaces
{
    public interface IIntegrationStrategy
    {
        Task<string> FetchRecipes(string query);
    }
}
