using ComprasPublicas.Aplicacao.Config.IoC;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Portal de Compras Públicas Web API",
        Description = "API responsável por cadastrar e informar dados para pregão eletronico.",
        Contact = new OpenApiContact() { Name = "Portal", Email = "compraspublicas@portalcompraspublicas.com" },
        License = new OpenApiLicense() { Name = "MIT License", Url = new Uri("https://opensource.org/licenses/MIT") }
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// IoC - Injection Dependency.
var connction = builder.Configuration.GetConnectionString("SqlServer");
builder.Services.RegisterDatabase(connction);
builder.Services.AddDependencyInjectionSetup();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
