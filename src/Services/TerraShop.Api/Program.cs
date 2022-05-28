using TerraShop.Api.Configurator;
using TerraShop.Api.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomOperationIds(api => api.ActionDescriptor.Id);
    options.CustomSchemaIds(type => type.FriendlyId(true)
                                                   .Replace("[", "Of")
                                                   .Replace("]", "")
                                                   .Replace("+", string.Empty)
                                   );
});
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddTerraShopServices(connectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
