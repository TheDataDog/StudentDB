using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB.StudentRegistration
{
    internal class StudentDbContext : DbContext
    {
        //private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(new ConfigurationBuilder()
                                        .AddJsonFile("appSettings.json")
                                        .Build()
                                        .GetSection("ConnectionStrings")["StudentDB"]);
        }

    }
}
