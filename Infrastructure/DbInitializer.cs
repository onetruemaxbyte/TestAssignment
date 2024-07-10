using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public static class DbInitializer
{
    public static void Initialize(ApplicationDbContext context)
    {
        if (context.Database.GetPendingMigrations().Any())
        {
            Console.WriteLine("Applying pending migrations...");
            context.Database.Migrate();
            Console.WriteLine("Migrations applied successfully.");
        }
        else
        {
            Console.WriteLine("No pending migrations found.");
        }
    }
}