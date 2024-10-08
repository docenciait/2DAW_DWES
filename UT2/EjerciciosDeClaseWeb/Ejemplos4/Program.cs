using Microsoft.AspNetCore.Diagnostics;

namespace Ejemplos4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

             
            if (app.Environment.IsDevelopment())
            {
                // Para enrutar excepciones a /error

                app.UseExceptionHandler("/error");
            }

            app.MapGet("/", () => "Welcome!");

            // Simulando una ruta con error con excepción
            // método estático o dinámico: new BadServie().GetValues

            app.MapGet("/rutaerror", BadService.GetValues);

            app.MapGet("/error", () => "Sorry, there was a problem processing your request");

            //app.MapGet("/error", async context =>
            //{
            //    // Verifica si la solicitud proviene del middleware de manejo de errores
            //    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

            //    if (exceptionFeature == null)
            //    {
            //        // Si no fue invocado por el middleware, devuelve 404
            //        context.Response.StatusCode = StatusCodes.Status404NotFound;
            //        await context.Response.WriteAsync("Page not found");
            //        return;
            //    }

            //    // Si es invocado por el middleware, muestra el mensaje de error
            //    await context.Response.WriteAsync("Sorry, there was a problem processing your request.");
            //});

            app.Run();


        }

        // 
        class BadService
        {
            public static string GetValues()
            {
                throw new Exception("Oops, algo ha pasado!");
            }
        }
    }
}
