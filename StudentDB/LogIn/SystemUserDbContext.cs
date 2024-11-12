using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB.LogIn
{
    internal class SystemUserDbContext : DbContext
    {
        public DbSet<SystemUser> SystemUsers { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(new ConfigurationBuilder()
                                        .AddJsonFile("appSettings.json")
                                        .Build()
                                        .GetSection("ConnectionStrings")["StudentDB"]);
        }
    }
}
