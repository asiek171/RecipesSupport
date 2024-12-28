using Application.Models;
using Infrastructure.Data;
using MediatR;

namespace Application.Handlers
{
    public record AddIngredientCommand(Ingredient model) : IRequest<bool>;
    public class AddIngredientCommandHandler : IRequestHandler<AddIngredientCommand, bool>
    {
        private readonly RecipesSupportDbContext _DbContext;
        public AddIngredientCommandHandler(RecipesSupportDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public Task<bool> Handle(AddIngredientCommand request, CancellationToken cancellationToken)
        {
             _DbContext.Ingredients.Add(new Domain.Models.Ingredient
            {
                Name = request.model.Name,
                Quantity = request.model.Quantity,
                Type = request.model.Type
            });

            _DbContext.SaveChanges();

            return Task.FromResult(true);
        }
    }
}
