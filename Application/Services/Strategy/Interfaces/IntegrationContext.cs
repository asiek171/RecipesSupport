namespace Application.Services.Strategy.Interfaces
{
    public class IntegrationContext
    {
        private readonly IIntegrationStrategy _integrationStrategy;

        public IntegrationContext(IIntegrationStrategy integrationStrategy)
        {
            _integrationStrategy = integrationStrategy;
        }

        public Task<string> ExecuteFetch(string ingredients)
        {
            return _integrationStrategy.FetchRecipes(ingredients);
        }
    }
}
