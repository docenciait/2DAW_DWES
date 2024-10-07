namespace EjerciciosDeClaseWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
         
            // Add services for swagger

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            var app = builder.Build();

            // Configuración Swagger

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.MapGet("/", new Imprimir().Imprime);

            app.MapGet("/", () => Results.Text("<h1>Hello World</h1>","text/html"));

            app.Run();
        }

        //public class Imprimir
        //{
        //    public string Imprime()
        //    {
        //        return "Hello World";
        //    }
        //}
    }
}
