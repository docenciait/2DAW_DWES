using Microsoft.AspNetCore.HttpLogging;

namespace Libreria
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services for swagger

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddHttpLogging(
                opts => opts.LoggingFields = HttpLoggingFields.RequestProperties
           );

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

            app.MapGet("/", () => "Welcome");

            app.MapGet("/libros", () => libros);

            app.MapGet("/libros/{id}", (int id) => libros.FirstOrDefault(libro => libro.Id == id));

            app.MapPost("/libros", (Libro libro) =>
            {
                libro.Id = nextId++;
                libros.Add(libro);
                return Results.Created($"/libros/{libro.Id}", libro);
            });

            app.MapPut("/libros/{id}", (int id, Libro input) =>
            {
                var libro = libros.FirstOrDefault(l => l.Id == id);
                if (libro is null) return Results.NotFound();

                libro.Titulo = input.Titulo;
                libro.Autor = input.Autor;
                return Results.Ok(libro);
            });

            app.MapDelete("/libros/{id}", (int id) =>
            {
                var libro = libros.FirstOrDefault(l => l.Id == id);
                if (libro is not null)
                {
                    libros.Remove(libro);
                    return Results.Ok(libro);
                }
                return Results.NotFound();
            });


            app.Run();
        }

        public class Libro
        {
            public int Id { get; set; }
            public string Titulo { get; set; }
            public string Autor { get; set; }
        }

    }
}
