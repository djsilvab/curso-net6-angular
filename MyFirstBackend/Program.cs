//1. Usings to work with EntityFramework
using Microsoft.EntityFrameworkCore;
using MyFirstBackend.DataAccess;
using MyFirstBackend.Services;
using MyFirstBackend.Services.Contracts;
using MyFirstBackend.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//2: Connection with SQL Server
const string connectionName = "UniversityDB";
var connectionStr = builder.Configuration.GetConnectionString(connectionName);

//3. Add Context
builder.Services.AddDbContext<UniversityDbContext>(options => options.UseSqlServer(connectionStr));

//7. Add Service of JWT Autorization
builder.Services.AddJwtServices(builder.Configuration);

// Add services to the container.

builder.Services.AddControllers();

//4. Add Custom Services
builder.Services.AddScoped<IStudentsService, StudentsService>();

//8. Add Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserOnlyPolicy", policy => policy.RequireClaim("UserOnly", "User01"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//9. Config Swagger to take care of Authorization of JWT
builder.Services.AddSwaggerGen(options => {
    //We define the security for authorization
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization Header using Bearer Scheme"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{ }
        }
    });
});

//5. CORS Configuration
builder.Services.AddCors();
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: "CorsPolicy", builder =>
//    {
//        //builder.AllowAnyOrigin();
//        //builder.AllowAnyMethod();
//        //builder.AllowAnyHeader();

//        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
//    });
//});

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
//app.UseCors("CorsPolicy");
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.Run();
