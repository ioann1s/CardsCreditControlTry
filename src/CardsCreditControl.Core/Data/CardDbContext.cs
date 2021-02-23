using CardsCreditControl;
using CardsCreditControl.src.CardsCreditControl.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsCreditControl
{
    public class CardDbContext : DbContext 
    {
        const string connectionString = "Server=localhost;Database=crmdb;User Id=sa;Password=admin!@#123";

        public CardDbContext()
        {
            Console.WriteLine("ff");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)  
        {
            base.OnConfiguring(optionsBuilder);            
            optionsBuilder.UseSqlServer(connectionString); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CardTransaction>()   
               .ToTable("CardTransactions")          
               .HasKey(o => o.TransactionId);
            

            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Card>()   //χρήση της κλάσης Customer 
               .ToTable("Cards")           //ως πίνακα στο μοντέλο μου
            .HasKey (o=> new { o.CardNumber, o.Date });

            
            // modelBuilder.Entity<Customer>()
            //     .HasIndex(c => c.Vatnumber)
            //     .IsUnique();   

            //modelBuilder.Entity<Order>()   
            //    .ToTable("Order");           

            //   modelBuilder.Entity<Customer>() 
            //       .Property(c => c.TotalGross)
            //       .HasPrecision

            //     modelBuilder.Entity<Order>()
            //       .HasKey(o => o.OrderCode);
        }
    }
}
