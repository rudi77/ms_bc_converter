using System.Reflection;
using MsBcConverter.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Prometheus;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MsBcConverter.Api
{
    public class Startup
    {
       public static readonly string VERSION;

       static Startup()
       {
           VERSION = Assembly.GetExecutingAssembly()?.GetName()?.Version?.ToString() ?? string.Empty;
       }

        public void ConfigureAndRun(WebApplicationBuilder builder)
        {
            Configure(builder);
            Run(builder);       
        }

        private void Configure(WebApplicationBuilder builder)
        {
            // TODO: Add services to the container.



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            var logger = new LoggerConfiguration()
              .ReadFrom.Configuration(builder.Configuration)
              .Enrich.FromLogContext()
              .CreateLogger();

            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);
            builder.Services.AddSwaggerGen();
        }

        private void Run(WebApplicationBuilder builder)
        {
            // Run
            var app = builder.Build();
            app.UseSwagger();

            
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            app.UseAuthorization();
            app.MapControllers();
            app.UseMetricServer();
            app.Run();
        }
    }
}
