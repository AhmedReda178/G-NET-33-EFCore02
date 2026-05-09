using EventHub.Data;

namespace EventHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new EventHubDbContext();
            context.Database.EnsureCreated();

            Console.WriteLine("Database created successfully!");
            Console.ReadKey();
        }
    }
}
