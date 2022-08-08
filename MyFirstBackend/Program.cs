//1. Usings to work with EntityFramework
using Microsoft.EntityFrameworkCore;
using MyFirstBackend.DataAccess;

var builder = WebApplication.CreateBuilder(args);

//2: Connection with SQL Server
const string connectionName = "UniversityDB";
var connectionStr = builder.Configuration.GetConnectionString(connectionName);

//3. Add Context
builder.Services.AddDbContext<UniversityDbContext>(options => options.UseSqlServer(connectionStr));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
