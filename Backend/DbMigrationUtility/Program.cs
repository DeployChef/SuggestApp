using System;
using System.IO;
using System.Linq;
using DbMigrationUtility.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SuggestService.Entities;

namespace DbMigrationUtility
{
    class Program : IDesignTimeDbContextFactory<SuggestDbContext>
    {
        public SuggestDbContext CreateDbContext(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var configuration = configurationBuilder.Build();
            var connectionString = configuration.GetConnectionString("Storage");

            var optionsBuilder = new DbContextOptionsBuilder<SuggestDbContext>().UseNpgsql(connectionString);

            return new SuggestDbContext(optionsBuilder.Options);
        }

        static void Main(string[] args)
        {
            var p = new Program();

            using (var sc = p.CreateDbContext(null))
            {
                Console.WriteLine("Migration start...");
                sc.Database.Migrate();
                sc.SaveChanges();
                Console.WriteLine("Migration completed");

                sc.Suggests.RemoveRange(sc.Suggests);

                var testData = File.ReadAllLines("testdata.txt");

                sc.Suggests.AddRange(testData.Select(c=>
                {
                    Console.WriteLine($"Add {c}");
                    return new SuggestEntity { Suggestion = c };
                }));

                Console.WriteLine("Add data completed");
                sc.SaveChanges();
            }
            Console.WriteLine("");
            Console.WriteLine("Done.");
            Console.ReadLine();
        }

    }
}
