using System;
using Microsoft.EntityFrameworkCore;

namespace TriviaDbGenerator
{
    internal class TriviaDbContext : DbContext
    {
        public DbSet<Question> Question { get; set; }

        // Connection string do bazy SQL Server
        static readonly string connectionString = "";


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Użyj SQL Server jako dostawcy
            options.UseSqlServer(connectionString);
        }
    }
}
