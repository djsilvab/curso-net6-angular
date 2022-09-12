using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace VersionControlAPI.Helper
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            //Add Swagger Documentation for each version we have
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }
        }

        public void Configure(string name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        #region metodo_privados
        private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Title = "My .Net API RestFull",
                Version = description.ApiVersion.ToString(),
                Description = "This is my first API Versioning control",
                Contact = new OpenApiContact
                {
                    Email = "djsilvab@gmail.com",
                    Name = "Martín"
                }
            };

            if (description.IsDeprecated)
            {
                info.Description += "This API version has been deprecated";
            }

            return info;
        }

        #endregion
    }
}
