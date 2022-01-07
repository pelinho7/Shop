using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DBAccess.Data;
using API.DBAccess.Entities;
using API.DBAccess.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).ConfigureLogging(logging =>
        {
            logging.ClearProviders();
            logging.AddConsole();
        }).Build();
            using var scope = host.Services.CreateScope();
            var services=scope.ServiceProvider;
            try{
                var context=services.GetRequiredService<DataContext>();
                var userManager=services.GetRequiredService<UserManager<AppUser>>();
                var roleManager=services.GetRequiredService<RoleManager<AppRole>>();
                var unitOfWork=services.GetRequiredService<IUnitOfWork>();
                await context.Database.MigrateAsync();
                await Seed.SeedUsers(userManager,roleManager);
                await Seed.SeedAgreement(unitOfWork);
            }
            catch(Exception ex){
                var logger=services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex,"An error during migration");
            }

            await host.RunAsync();
            // CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
