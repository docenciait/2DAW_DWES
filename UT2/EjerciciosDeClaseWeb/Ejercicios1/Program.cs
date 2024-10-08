
using Microsoft.AspNetCore.HttpLogging;

namespace Ejercicios1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services for swagger

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddHttpLogging(
                opts => opts.LoggingFields = HttpLoggingFields.RequestProperties
           );

            builder.Logging.AddFilter("Microsoft.AspNetCore.HttpLogging", LogLevel.Information);

            WebApplication app = builder.Build();

          
            if (app.Environment.IsDevelopment())
            {
                app.UseHttpLogging();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
          
            

            app.MapGet("/", () => "Hello World!");
            app.MapGet("/person", () => new Person("john","Doe"));

            app.Run();

        }
        public record Person(string FirstName, string LastName);

      
    }
}
