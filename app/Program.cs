using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardsCreditControl.src.CardsCreditControl.Core.Model;


namespace CardsCreditControl
{
    public class Program
    {
        public static void Main(string[] args)
        {

            using var dbContext = new CardDbContext();

            var Transaction = new CardTransaction()
            {
                CardNumber = "5243656319135443",
                TransactionType = 1,
                Amount = 100M,
                status = true
            };

            dbContext.Database.EnsureCreated();
            dbContext.Add(Transaction);


            dbContext.SaveChanges();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
