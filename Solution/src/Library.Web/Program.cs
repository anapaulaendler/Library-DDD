using Library.Application.DI;
using Library.Infra.Context;

var builder = WebApplication.CreateBuilder(args);

Initializer.Configure(builder.Services, builder.Configuration.GetConnectionString(nameof(AppDbContext)));
builder.Services.AddControllers()
    .AddJsonOptions(opts =>
    {
        opts.JsonSerializerOptions.Converters.Add(new RoleConverter());
    });

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
