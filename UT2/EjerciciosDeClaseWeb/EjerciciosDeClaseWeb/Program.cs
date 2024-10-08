namespace EjerciciosDeClaseWeb
{
    public class Program
    {
        /**
         * En este ejemplo se pueden ver cómo al path del Endpoint
         * se puede llamar con un objeto o con lambdas.
         * Con lambdas también se puede renderizar el html, pero eso será mejor
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
