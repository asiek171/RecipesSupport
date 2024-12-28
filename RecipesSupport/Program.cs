
using Application.Handlers;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using RecipesSupport.Extensions;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddCustomCashing();
builder.Services.AddStrategy();
builder.Services.AddApplicationServices();
builder.Services.AddExternalIntegrationServices(builder.Configuration);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddIngredientCommandHandler).Assembly));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RecipesSupportDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Db")));
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.ConfigObject.TryItOutEnabled = true;
    });
}

app.UseMiddleware<RequestTimingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

