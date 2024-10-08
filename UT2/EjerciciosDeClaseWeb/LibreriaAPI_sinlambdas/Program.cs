using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libreria
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services for Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHttpLogging(opts =>
                opts.LoggingFields = HttpLoggingFields.RequestProperties);

            builder.Logging.AddFilter("Microsoft.AspNetCore.HttpLogging", LogLevel.Information);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseHttpLogging();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            var libros = new List<Libro>();
            int nextId = 1;

            app.MapGet("/", HandleWelcome);
            app.MapGet("/libros", HandleGetLibros);
            app.MapGet("/libros/{id}", HandleGetLibroById);
            app.MapPost("/libros", HandleCreateLibro);
            app.MapPut("/libros/{id}", HandleUpdateLibro);
            app.MapDelete("/libros/{id}", HandleDeleteLibro);

            app.Run();
        }

        private static void HandleWelcome(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.WriteAsync("Welcome").Wait();
        }

        private static void HandleGetLibros(HttpContext context)
        {
            var libros = GetLibros();
            context.Response.ContentType = "application/json";
            context.Response.WriteAsJsonAsync(libros).Wait();
        }

        private static void HandleGetLibroById(HttpContext context)
        {
            var libros = GetLibros();
            var id = int.Parse((string?)context.Request.RouteValues["id"] ?? "-1");
            var libro = libros.FirstOrDefault(l => l.Id == id);

            if (libro != null)
            {
                context.Response.ContentType = "application/json";
                context.Response.WriteAsJsonAsync(libro).Wait();
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
            }
        }

        private static void HandleCreateLibro(HttpContext context, List<Libro> libros)
        {
            // Deserializa el objeto Libro del cuerpo de la solicitud
            var libro = context.Request.ReadFromJsonAsync<Libro>().Result;

            // Si el libro no es nulo, lo procesamos
            if (libro != null)
            {
             
                libros.Add(libro); // Añadimos el libro a la colección
                context.Response.StatusCode = StatusCodes.Status201Created; // Indicamos que la creación fue exitosa
                context.Response.Headers.Location = $"/libros/{libro.Id}"; // Establecemos la ubicación del nuevo recurso
                context.Response.WriteAsJsonAsync(libro).Wait(); // Devolvemos el libro creado como respuesta
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest; // Indicamos un error de solicitud si el libro es nulo
            }
        }


        private static void HandleUpdateLibro(HttpContext context)
        {
            var libros = GetLibros();
            var id = int.Parse((string?)context.Request.RouteValues["id"] ?? "-1");
            var libro = libros.FirstOrDefault(l => l.Id == id);

            if (libro == null)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }

            var input = context.Request.ReadFromJsonAsync<Libro>().Result;

            if (input != null)
            {
                libro.Titulo = input.Titulo;
                libro.Autor = input.Autor;
                context.Response.WriteAsJsonAsync(libro).Wait();
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
        }

        private static void HandleDeleteLibro(HttpContext context)
        {
            var libros = GetLibros();
            var id = int.Parse((string?)context.Request.RouteValues["id"] ?? "-1");
            var libro = libros.FirstOrDefault(l => l.Id == id);

            if (libro != null)
            {
                libros.Remove(libro);
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.WriteAsJsonAsync(libro).Wait();
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
            }
        }

        private static List<Libro> GetLibros()
        {
            return new List<Libro>
            {
                new Libro { Id = 1, Titulo = "Cien años de soledad", Autor = "Gabriel García Márquez" },
                new Libro { Id = 2, Titulo = "Don Quijote de la Mancha", Autor = "Miguel de Cervantes" }
            };
        }

       


            private static int GetNextId(List<Libro> libros)
            {
                return libros.Any() ? libros.Max(l => l.Id) + 1 : 1;
            }

        public class Libro
        {
            public int Id { get; set; }
            public string Titulo { get; set; } = string.Empty;
            public string Autor { get; set; } = string.Empty;
        }
    }
}
