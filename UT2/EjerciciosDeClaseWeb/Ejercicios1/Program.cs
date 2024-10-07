using Microsoft.AspNetCore.HttpLogging;

namespace Ejercicios1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddHttpLogging(
                opts => opts.LoggingFields = HttpLoggingFields.RequestProperties
           );

            builder.Logging.AddFilter("Microsoft.AspNetCore.HttpLogging", LogLevel.Information);

            WebApplication app = builder.Build();

          
            if (app.Environment.IsDevelopment())
            {
                app.UseHttpLogging();
            }
          
            

            app.MapGet("/", () => "Hello World!");
            app.MapGet("/person", () => new Person("john","Doe"));

            app.Run();

        }
        public record Person(string FirstName, string LastName);

      
    }
}
