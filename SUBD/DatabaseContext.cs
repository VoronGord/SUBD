using DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DB
{
    class DatabaseContext : DbContext
    {
        const string CONFIG_FILE_ADDRESS = "config.txt";
        public DbSet<DType> Types { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
      
        public DbSet<Client> Clients { get; set; }
        public DatabaseContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(GetConnectionString());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("seq_type").StartsAt(1001).IncrementsBy(1);
            modelBuilder.HasSequence<int>("seq_order").StartsAt(2001).IncrementsBy(1);
            modelBuilder.HasSequence<int>("seq_product").StartsAt(3001).IncrementsBy(1);
            modelBuilder.HasSequence<int>("seq_client").StartsAt(4001).IncrementsBy(1);
            modelBuilder.HasSequence<int>("seq_provider").StartsAt(5001).IncrementsBy(1);
            modelBuilder.Entity<DType>().Property(it => it.Id).UseHiLo("seq_type");
            modelBuilder.Entity<Order>().Property(it => it.Id).UseHiLo("seq_order");
            modelBuilder.Entity<Product>().Property(it => it.Id).UseHiLo("seq_product");
            modelBuilder.Entity<Client>().Property(it => it.Id).UseHiLo("seq_client");
            modelBuilder.Entity<Provider>().Property(it => it.Id).UseHiLo("seq_provider");
        
        }
        string GetConnectionString()
        {
            if (!CheckConfigFile(CONFIG_FILE_ADDRESS))
            {
                throw new Exception("Неверный формат файла конфигурации");
            }            
            string[] data = new string[4];
            using(StreamReader sr = new StreamReader(CONFIG_FILE_ADDRESS, Encoding.GetEncoding(1251)))
            {
                int i = 0;
                string str = "";
                while ((str = sr.ReadLine()) != null)
                {
                    data[i] = str.Split(" ")[1];
                    Console.WriteLine(data[i]);
                    i++;
                }                
            }
            Console.WriteLine();
            return $"Host={data[0]};Port={data[1]};Username={data[2]};Database={data[3]};";
        }
        bool CheckConfigFile(string fileAddress)
        {
            int count = 0;
            using(StreamReader sr = new StreamReader(fileAddress))
            {
                while (sr.ReadLine() != null) 
                {
                    count++;
                }
            }
            return (count == 4) ? true : false;
        }        
    }
}
