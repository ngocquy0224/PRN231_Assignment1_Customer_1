using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyStoreDB"));
        }
        public virtual DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder optionsBuilder)
        {
            optionsBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    username = "qqq",
                    password = "B888",
                    fullname = "Pham Ngoc Quy",
                    gender = "Male",
                    birthday = new DateTime(1990, 1, 1),
                    address = "123 ABC Street, Hanoi"
                },
        new Customer
        {
            username = "jdoe",
            password = "J123",
            fullname = "John Doe",
            gender = "Male",
            birthday = new DateTime(1985, 5, 15),
            address = "456 XYZ Avenue, Ho Chi Minh City"
        }
            );
        }
    }
}
