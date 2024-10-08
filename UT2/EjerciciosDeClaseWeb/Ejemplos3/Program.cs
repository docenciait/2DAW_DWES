namespace Ejemplos3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            
            WebApplication app = builder.Build();

            // Welcome page
            //app.UseWelcomePage();

            // Default: index.htm, index.html, default.htm, default.html
            app.UseDefaultFiles();


            // Otro fichero
            //DefaultFilesOptions options = new DefaultFilesOptions();
            //options.DefaultFileNames.Clear(); //clears the default list
            //options.DefaultFileNames.Add("home.html"); //adds home.html as the first option in the list
            //app.UseDefaultFiles(options); //pass options to the middleware
    

            // Para index
            app.UseStaticFiles();

            app.Run();
        }
    }
}
