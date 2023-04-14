using Io.Schnurr.Circles.Api;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();

var app = builder.Build();

app.UseCors(builder => builder
    .WithOrigins(app.Configuration["AllowSpecificOrigins"]?.Split(";") ?? throw new Exception("Allowed origins not found"))
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.UseHttpsRedirection();

app.MapRoutes();

app.Run();
