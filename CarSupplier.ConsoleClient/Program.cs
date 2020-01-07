using CarSupplier.Hosting;

namespace CarSupplier.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var applicationBuilder = ApplicationBuilder<IApplicationRunner>.UseStartup<Startup>();

            var application = applicationBuilder.Build();

            application.Run();
        }
    }
}
