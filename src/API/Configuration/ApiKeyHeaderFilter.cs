using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace API.Configuration
{
    public class ApiKeyHeaderFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "x-api-key",
                In = ParameterLocation.Header,
                Description = "API Key necessária para acessar os endpoints",
                Required = true, // Defina como `false` se não for obrigatório em todos os casos
                Schema = new OpenApiSchema
                {
                    Type = "string"
                }
            });
        }
    }
}
