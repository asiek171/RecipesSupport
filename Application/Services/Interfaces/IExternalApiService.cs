using Application.Models;

namespace Application.Services.Interfaces
{
    internal interface IExternalApiService
    {
        List<Recipe> Get();
    }
}
