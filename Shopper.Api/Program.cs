using Shopper.Api.Extensions;
using Shopper.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);
builder.AddPresentation();

var app = builder.Build();

#region Seed Data
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var seeder = services.GetRequiredService<IDataSeederContext>();

await seeder.SeedAsync();
#endregion





app.AddMiddlewares();
