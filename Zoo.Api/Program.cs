using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Zoo.Api.Data;
using Zoo.Api.Repositories;
using Zoo.Api.Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextPool<ZooDbContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ZooConnectionString"));
});
builder.Services.AddScoped<IZooAnimalRepository, ZooAnimalRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(policy =>
{
    policy.WithOrigins("https://localhost:7298", "http://localhost:5141")
          .AllowAnyMethod()
          .WithHeaders(HeaderNames.ContentType);
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
