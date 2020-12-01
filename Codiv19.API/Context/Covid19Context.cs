using Codiv19.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Codiv19.API.Context
{
    public class Covid19Context: DbContext
    {
        public Covid19Context()
        {

        }

        public Covid19Context(DbContextOptions<Covid19Context> options) : base(options)
        {
        }

        public virtual DbSet<Paciente> paciente{ get; set; }
        public virtual DbSet<Login> login { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                        .AddJsonFile("appsettings.json")
                                        .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("COVID2019DataBase"));
            }
        }
    }
}
