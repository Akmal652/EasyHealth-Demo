using Microsoft.EntityFrameworkCore;
using EasyHealth_Demo.Models;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace EasyHealth_Demo.DBContexts
{
    public class ClientContext:DbContext
    {
        public ClientContext(DbContextOptions<ClientContext> options) : base(options) { }

        //dbset
        public DbSet<Client> Clients { get; set; }

        //Model Creating method
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    ClientId = 100,
                    FirstName = "Akmal",
                    LastName = "Faisal",
                    PhoneNumber = "0134122235",
                    Email = "andthen23@gmail.com",
                    PasswordHash = "$2a$12$ocDGfpobOAfJiFiG/Efs5e3kM1ZmqsJ2xsuTFD16UEUMkYACINlpq"
                });
        }
    }
}
