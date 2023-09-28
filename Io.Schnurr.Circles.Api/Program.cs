using FluentValidation;
using Io.Schnurr.Circles.Api;
using Io.Schnurr.Circles.Shared.Models;
using Io.Schnurr.Circles.Shared.Validators;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
builder.Services.AddScoped<IValidator<Advertisement>, AdvertisementValidator>();

var app = builder.Build();

app.UseCors(builder => builder
    .WithOrigins(app.Configuration["AllowSpecificOrigins"]?.Split(";") ?? throw new Exception("Allowed origins not found"))
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.UseHttpsRedirection();

app.MapRoutes();

app.Run();
