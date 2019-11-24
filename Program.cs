using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using japan_dashboard_api.Store;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace japan_dashboard_api
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var host = CreateHostBuilder(args).Build();

      using (var scope = host.Services.CreateScope())
      {
        var services = scope.ServiceProvider;
        var logger = services.GetRequiredService<ILogger<Program>>();

        try
        {
          logger.LogInformation("Getting context...");
          var context = services.GetRequiredService<DataContext>();

          logger.LogInformation("Migrating existing database...");
          context.Database.Migrate();

          logger.LogInformation("Seeding data into database...");
          Seed.SeedAll(context);
        }
        catch (Exception ex)
        {
          logger.LogError(ex, "An error has occured during migration!");
        }
      }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();
            });
  }
}
