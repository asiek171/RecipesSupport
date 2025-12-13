using Application.Models;
using Infrastructure.Data;
using MediatR;

namespace Application.Handlers
{
    public record AddIngredientCommand(Ingredient model) : IRequest;
    public class AddIngredientCommandHandler : IRequestHandler<AddIngredientCommand>
    {
        private readonly RecipesSupportDbContext _DbContext;
        public AddIngredientCommandHandler(RecipesSupportDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task Handle(AddIngredientCommand request, CancellationToken cancellationToken)
        {
             _DbContext.Ingredients.Add(new Domain.Models.Ingredient
            {
                Name = request.model.Name,
                NormalizedName = request.model.NormalizedName,
                Category = request.model.Category,
            });

            await _DbContext.SaveChangesAsync();
        }
    }
}
