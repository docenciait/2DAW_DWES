namespace EjerciciosDeClaseWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            //app.MapGet("/", new Imprimir().Imprime);

            app.MapGet("/", () => "Hello World");

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
