using System;
using System.Runtime.ConstrainedExecution;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace Lab10ex3.Models
{
	internal class ShopDbcontext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Tag> Tags { get; set; }


        public ShopDbcontext()
		{
            Database.EnsureCreated();

        }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql(@"Host=localhost;Username=postgres;Password=postgres;Database='Lab10ex3'");

        public int GetStockProducer(string name, string cui)
        {
            using var ctx = new ShopDbcontext();

            int stock = ctx.Products
                .Where(e => e.Producer.Name == name && e.Producer.Cui == cui)
                .ToList()
                .Sum(e => e.Stock);

            return stock;


        }

        public int GetStockProducer(int id)
        {
            using var ctx = new ShopDbcontext();

            int stock = ctx.Products
                .Where(e => e.Id == id)
                .ToList()
                .Sum(e => e.Stock);

            return stock;


        }
     

    }
    }


