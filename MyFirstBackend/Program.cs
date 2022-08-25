//1. Usings to work with EntityFramework
using Microsoft.EntityFrameworkCore;
using MyFirstBackend.DataAccess;
using MyFirstBackend.Services;
using MyFirstBackend.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

//2: Connection with SQL Server
const string connectionName = "UniversityDB";
var connectionStr = builder.Configuration.GetConnectionString(connectionName);

//3. Add Context
builder.Services.AddDbContext<UniversityDbContext>(options => options.UseSqlServer(connectionStr));

// Add services to the container.

builder.Services.AddControllers();

//4. Add Custom Services
builder.Services.AddScoped<IStudentsService, StudentsService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//5. CORS Configuration
builder.Services.AddCors(options => {
    options.AddPolicy(name: "CorsPolicy", builder => {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

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

//6. Tell app to use CORS
app.UseCors("CorsPolicy");

app.Run();
