using Library.Application.DI;

var builder = WebApplication.CreateBuilder(args);

Initializer.Register(builder.Services, builder.Configuration);

builder.Services.AddOpenApi();

builder.Services.AddMemoryCache();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
