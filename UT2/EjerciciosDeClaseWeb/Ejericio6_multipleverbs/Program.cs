namespace Ejericio6_multipleverbs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            WebApplication app = builder.Build();

       
            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapGet("/fruit", () => Fruit.All); // Lambda expression

            var getFruit = (string id) => Fruit.All[id];
            app.MapGet("/fruit/{id}", getFruit); // lambda expression

            app.MapPost("/fruit/{id}", Handlers.AddFruit); // static method

            Handlers handlers = new();
            app.MapPut("/fruit/{id}", handlers.ReplaceFruit); // instance method

            app.MapDelete("/fruit/{id}", DeleteFruit); // local function

            app.MapGet("/", () => "Welcome");

            app.Run();

            void DeleteFruit(string id)
            {
                Fruit.All.Remove(id);
            }
        }
        

        record Fruit(string Name, int Stock)
        {
            public static readonly Dictionary<string, Fruit> All = new();
        };

        class Handlers
        {
            public void ReplaceFruit(string id, Fruit fruit)
            {
                Fruit.All[id] = fruit;
            }

            public static void AddFruit(string id, Fruit fruit)
            {
                Fruit.All.Add(id, fruit);
            }
        }
    }
}
