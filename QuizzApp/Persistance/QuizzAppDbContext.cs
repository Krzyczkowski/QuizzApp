using System;
using Microsoft.EntityFrameworkCore;
using QuizzApp.Models;

public class QuizzAppDbContext : DbContext
{
    public DbSet<Question> Question { get; set; } = null!;
    public DbSet<CorrectAnswer> CorrectAnswer { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!; 

   public QuizzAppDbContext(DbContextOptions<QuizzAppDbContext> options)
        : base(options)
    {
    }

}