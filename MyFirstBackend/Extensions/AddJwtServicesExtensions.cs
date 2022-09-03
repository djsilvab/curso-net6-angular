using Microsoft.AspNetCore.Authentication.JwtBearer;
using MyFirstBackend.Models.DataModels;
using Microsoft.IdentityModel.Tokens;

namespace MyFirstBackend.Extensions
{
    public static class AddJwtServicesExtensions
    {
        public static void AddJwtServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Add JWT Settings
            var jwtSettings = new JwtSettings();
            configuration.Bind("JsonWebTokenKeys", jwtSettings);

            //Add Singleton of JWT Settings
            services.AddSingleton(jwtSettings);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                //options.Authority = "";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtSettings.IssuerSigningKey)),
                    ValidateIssuer = jwtSettings.ValidateIssuer,
                    ValidateAudience = jwtSettings.ValidateAudience,
                    ValidAudience =jwtSettings.ValidAudience,
                    RequireExpirationTime = jwtSettings.RequireExpirationTime,
                    ClockSkew = TimeSpan.FromDays(1)
                };
            }); 

        }
    }
}
