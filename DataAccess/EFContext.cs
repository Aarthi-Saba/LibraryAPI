using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pocos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataAccess
{
    public class EFContext : DbContext
    {
        public DbSet<UserPoco> Users { get; set; }
        public DbSet<BookPoco> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(SqlConnection());
            base.OnConfiguring(optionsBuilder);
        }
        private string SqlConnection()
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            return root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookPoco>(e => {
                e.HasOne(p => p.BookUserInfo).WithMany(f => f.UsersBookCollection);
            });

            modelBuilder.Entity<UserPoco>(e =>
            {
                e.HasMany(p => p.UsersBookCollection).WithOne(f => f.BookUserInfo);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
