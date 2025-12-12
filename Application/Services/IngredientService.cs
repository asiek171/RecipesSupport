using Application.Handlers;
using Application.Models;
using Application.Services.Interfaces;
using MediatR;

namespace Application.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IMediator _mediator;
        public IngredientService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<bool> Add(Ingredient model)
        {
            try
            {
                await _mediator.Send(new AddIngredientCommand(model));
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<Ingredient> Get()
        {
            throw new NotImplementedException();
        }
    }
}
