namespace Ejemplo6_creandoapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            WebApplication app = builder.Build();
            var people = new List<Person>
            {
                new("Tom", "Hanks"),
                new("Denzel", "Washington"),
                new("Leondardo", "DiCaprio"),
                new("Al", "Pacino"),
                new("Morgan", "Freeman"),
            };

            app.MapGet("/", () => "Welcome");
            //app.MapGet("/person/{name}", (string name) => people.Where(p => p.FirstName.StartsWith(name)));
            app.MapGet("/person/{name}", (string name) => BuscaPersona(people, name));
            
            // Búsqueda por fullname
            app.MapGet("/person/{name}/{lastname}", (string name, string lastname) => BuscaPersonaNombreCompleto(people, name, lastname));
           
            app.Run();
        }

        public record Person(string FirstName, string LastName);

        public static List<Person> BuscaPersona(List<Person> people, string name)
        {
            var result = new List<Person>();

            foreach (var person in people)
            {
                if (person.FirstName.StartsWith(name))
                {
                    result.Add(person);
                }
            }

            return result;
        }

        public static List<Person> BuscaPersonaNombreCompleto(List<Person> people, string firstName, string lastName)
        {
            
            var result = new List<Person>();
            foreach (var person in people)
            {
                // Busca personas que coincidan con el nombre y apellido
                if (person.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                    person.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(person);
                }
            }

            return result;
        }

    }
}
