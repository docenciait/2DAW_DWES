namespace EjerciciosDeClaseWeb
{
    public class Program
    {
        /**
         * En este ejemplo se pueden ver c�mo al path del Endpoint
         * se puede llamar con un objeto o con lambdas.
         * Con lambdas tambi�n se puede renderizar el html, pero eso ser� mejor
         * verlo con el sistema de templates
         */
        
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                    
            var app = builder.Build();      

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
