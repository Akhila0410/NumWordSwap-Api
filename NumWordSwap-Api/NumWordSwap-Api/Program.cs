using Microsoft.Net.Http.Headers;
using NumWordSwap_Api.Interfaces;
using NumWordSwap_Api.Services;

/**
 * Configuring the .Net 6.0 App with needed Services for creating API Endpoints, Swagger Documentation 
 * and Mapping Controllers to the API Endpoints.
 * 
 * @author Akhila Rachupalli
 *
 */

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Dependency Injections
builder.Services.AddTransient<INumWordSwapService, NumWordSwapService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

builder.Services.AddSwaggerGen();
// Register the Swagger services
builder.Services.AddSwaggerDocument(settings => settings.Title = "Num Word Swap Application Api");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3(c => c.DocumentTitle = "Num Word Swap Application Api");
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();

